Imports Longkong.Pojjaman.BusinessLogic
Imports longkong.Pojjaman.Services
Imports Longkong.Core.Services

Namespace Longkong.Pojjaman.Gui.Panels
  Public Class RptIncomingWhtFilterSubPanel
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
    Friend WithEvents cmbMonth As System.Windows.Forms.ComboBox
    Friend WithEvents lblMonth As System.Windows.Forms.Label
    Friend WithEvents lblYear As System.Windows.Forms.Label
    Friend WithEvents cmbYear As System.Windows.Forms.ComboBox
    Friend WithEvents btnSupplierEnd As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents txtSupplierCodeEnd As System.Windows.Forms.TextBox
    Friend WithEvents lblSupplierEnd As System.Windows.Forms.Label
    Friend WithEvents btnSupplierStart As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents txtSupplierCodeStart As System.Windows.Forms.TextBox
    Friend WithEvents lblSupplierStart As System.Windows.Forms.Label
    Friend WithEvents chkIncludeChildren As System.Windows.Forms.CheckBox
    Friend WithEvents btnCCCodeStart As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents txtCCCodeStart As System.Windows.Forms.TextBox
    Friend WithEvents lblCCStart As System.Windows.Forms.Label
    Friend WithEvents txtCostCenterName As System.Windows.Forms.TextBox
    Friend WithEvents cmbWhtType As System.Windows.Forms.ComboBox
    Friend WithEvents lblWhtType As System.Windows.Forms.Label
    Friend WithEvents chkIncludeChildSupplierGroup As System.Windows.Forms.CheckBox
    Friend WithEvents btnSpgCodeStart As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents txtSpgCodeStart As System.Windows.Forms.TextBox
    Friend WithEvents lblSpgStart As System.Windows.Forms.Label
    Friend WithEvents txtSupplierGroupName As System.Windows.Forms.TextBox
    Friend WithEvents txtPayDocDateEnd As System.Windows.Forms.TextBox
    Friend WithEvents txtPayDocDateStart As System.Windows.Forms.TextBox
    Friend WithEvents lblPayDocDateStart As System.Windows.Forms.Label
    Friend WithEvents dtpPayDocDateStart As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpPayDocDateEnd As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtCodeEnd As System.Windows.Forms.TextBox
    Friend WithEvents lblCodeEnd As System.Windows.Forms.Label
    Friend WithEvents txtCodeStart As System.Windows.Forms.TextBox
    Friend WithEvents lblCodeStart As System.Windows.Forms.Label
    Friend WithEvents btnAcctBookEndFind As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents txtAcctBookEnd As System.Windows.Forms.TextBox
    Friend WithEvents lblAcctBookEnd As System.Windows.Forms.Label
    Friend WithEvents btnAcctBookStartFind As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents txtAcctBookStart As System.Windows.Forms.TextBox
    Friend WithEvents lblAcctBookStart As System.Windows.Forms.Label
    Friend WithEvents lblPayDocDateEnd As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
      Me.components = New System.ComponentModel.Container()
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(RptIncomingWhtFilterSubPanel))
      Me.grbDetail = New Longkong.Pojjaman.Gui.Components.FixedGroupBox()
      Me.grbDocDate = New Longkong.Pojjaman.Gui.Components.FixedGroupBox()
      Me.txtCodeEnd = New System.Windows.Forms.TextBox()
      Me.lblCodeEnd = New System.Windows.Forms.Label()
      Me.txtCodeStart = New System.Windows.Forms.TextBox()
      Me.lblCodeStart = New System.Windows.Forms.Label()
      Me.txtPayDocDateEnd = New System.Windows.Forms.TextBox()
      Me.txtPayDocDateStart = New System.Windows.Forms.TextBox()
      Me.lblPayDocDateStart = New System.Windows.Forms.Label()
      Me.lblPayDocDateEnd = New System.Windows.Forms.Label()
      Me.dtpPayDocDateStart = New System.Windows.Forms.DateTimePicker()
      Me.dtpPayDocDateEnd = New System.Windows.Forms.DateTimePicker()
      Me.chkIncludeChildSupplierGroup = New System.Windows.Forms.CheckBox()
      Me.btnSpgCodeStart = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.txtSpgCodeStart = New System.Windows.Forms.TextBox()
      Me.lblSpgStart = New System.Windows.Forms.Label()
      Me.txtSupplierGroupName = New System.Windows.Forms.TextBox()
      Me.cmbWhtType = New System.Windows.Forms.ComboBox()
      Me.lblWhtType = New System.Windows.Forms.Label()
      Me.chkIncludeChildren = New System.Windows.Forms.CheckBox()
      Me.btnCCCodeStart = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.txtCCCodeStart = New System.Windows.Forms.TextBox()
      Me.lblCCStart = New System.Windows.Forms.Label()
      Me.txtCostCenterName = New System.Windows.Forms.TextBox()
      Me.btnSupplierEnd = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.txtSupplierCodeEnd = New System.Windows.Forms.TextBox()
      Me.lblSupplierEnd = New System.Windows.Forms.Label()
      Me.btnSupplierStart = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.txtSupplierCodeStart = New System.Windows.Forms.TextBox()
      Me.lblSupplierStart = New System.Windows.Forms.Label()
      Me.cmbYear = New System.Windows.Forms.ComboBox()
      Me.lblYear = New System.Windows.Forms.Label()
      Me.cmbMonth = New System.Windows.Forms.ComboBox()
      Me.lblMonth = New System.Windows.Forms.Label()
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
      Me.btnAcctBookEndFind = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.txtAcctBookEnd = New System.Windows.Forms.TextBox()
      Me.lblAcctBookEnd = New System.Windows.Forms.Label()
      Me.btnAcctBookStartFind = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.txtAcctBookStart = New System.Windows.Forms.TextBox()
      Me.lblAcctBookStart = New System.Windows.Forms.Label()
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
      Me.grbDetail.Controls.Add(Me.grbDocDate)
      Me.grbDetail.Controls.Add(Me.btnSearch)
      Me.grbDetail.Controls.Add(Me.btnReset)
      Me.grbDetail.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.grbDetail.Location = New System.Drawing.Point(8, 8)
      Me.grbDetail.Name = "grbDetail"
      Me.grbDetail.Size = New System.Drawing.Size(808, 226)
      Me.grbDetail.TabIndex = 0
      Me.grbDetail.TabStop = False
      Me.grbDetail.Text = "Find"
      '
      'grbDocDate
      '
      Me.grbDocDate.Controls.Add(Me.btnAcctBookEndFind)
      Me.grbDocDate.Controls.Add(Me.txtCodeEnd)
      Me.grbDocDate.Controls.Add(Me.txtAcctBookEnd)
      Me.grbDocDate.Controls.Add(Me.lblCodeEnd)
      Me.grbDocDate.Controls.Add(Me.lblAcctBookEnd)
      Me.grbDocDate.Controls.Add(Me.txtCodeStart)
      Me.grbDocDate.Controls.Add(Me.btnAcctBookStartFind)
      Me.grbDocDate.Controls.Add(Me.lblCodeStart)
      Me.grbDocDate.Controls.Add(Me.txtAcctBookStart)
      Me.grbDocDate.Controls.Add(Me.txtPayDocDateEnd)
      Me.grbDocDate.Controls.Add(Me.lblAcctBookStart)
      Me.grbDocDate.Controls.Add(Me.txtPayDocDateStart)
      Me.grbDocDate.Controls.Add(Me.lblPayDocDateStart)
      Me.grbDocDate.Controls.Add(Me.lblPayDocDateEnd)
      Me.grbDocDate.Controls.Add(Me.dtpPayDocDateStart)
      Me.grbDocDate.Controls.Add(Me.dtpPayDocDateEnd)
      Me.grbDocDate.Controls.Add(Me.chkIncludeChildSupplierGroup)
      Me.grbDocDate.Controls.Add(Me.btnSpgCodeStart)
      Me.grbDocDate.Controls.Add(Me.txtSpgCodeStart)
      Me.grbDocDate.Controls.Add(Me.lblSpgStart)
      Me.grbDocDate.Controls.Add(Me.txtSupplierGroupName)
      Me.grbDocDate.Controls.Add(Me.cmbWhtType)
      Me.grbDocDate.Controls.Add(Me.lblWhtType)
      Me.grbDocDate.Controls.Add(Me.chkIncludeChildren)
      Me.grbDocDate.Controls.Add(Me.btnCCCodeStart)
      Me.grbDocDate.Controls.Add(Me.txtCCCodeStart)
      Me.grbDocDate.Controls.Add(Me.lblCCStart)
      Me.grbDocDate.Controls.Add(Me.txtCostCenterName)
      Me.grbDocDate.Controls.Add(Me.btnSupplierEnd)
      Me.grbDocDate.Controls.Add(Me.txtSupplierCodeEnd)
      Me.grbDocDate.Controls.Add(Me.lblSupplierEnd)
      Me.grbDocDate.Controls.Add(Me.btnSupplierStart)
      Me.grbDocDate.Controls.Add(Me.txtSupplierCodeStart)
      Me.grbDocDate.Controls.Add(Me.lblSupplierStart)
      Me.grbDocDate.Controls.Add(Me.cmbYear)
      Me.grbDocDate.Controls.Add(Me.lblYear)
      Me.grbDocDate.Controls.Add(Me.cmbMonth)
      Me.grbDocDate.Controls.Add(Me.lblMonth)
      Me.grbDocDate.Controls.Add(Me.txtDocDateEnd)
      Me.grbDocDate.Controls.Add(Me.txtDocDateStart)
      Me.grbDocDate.Controls.Add(Me.lblDocDateStart)
      Me.grbDocDate.Controls.Add(Me.lblDocDateEnd)
      Me.grbDocDate.Controls.Add(Me.dtpDocDateStart)
      Me.grbDocDate.Controls.Add(Me.dtpDocDateEnd)
      Me.grbDocDate.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.grbDocDate.Location = New System.Drawing.Point(16, 16)
      Me.grbDocDate.Name = "grbDocDate"
      Me.grbDocDate.Size = New System.Drawing.Size(780, 172)
      Me.grbDocDate.TabIndex = 0
      Me.grbDocDate.TabStop = False
      Me.grbDocDate.Text = "Date"
      '
      'txtCodeEnd
      '
      Me.Validator.SetDataType(Me.txtCodeEnd, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtCodeEnd, "")
      Me.txtCodeEnd.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtCodeEnd, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtCodeEnd, -15)
      Me.Validator.SetInvalidBackColor(Me.txtCodeEnd, System.Drawing.Color.Empty)
      Me.txtCodeEnd.Location = New System.Drawing.Point(642, 16)
      Me.txtCodeEnd.MaxLength = 50
      Me.Validator.SetMinValue(Me.txtCodeEnd, "")
      Me.txtCodeEnd.Name = "txtCodeEnd"
      Me.Validator.SetRegularExpression(Me.txtCodeEnd, "")
      Me.Validator.SetRequired(Me.txtCodeEnd, False)
      Me.txtCodeEnd.Size = New System.Drawing.Size(120, 21)
      Me.txtCodeEnd.TabIndex = 21
      '
      'lblCodeEnd
      '
      Me.lblCodeEnd.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblCodeEnd.ForeColor = System.Drawing.Color.Black
      Me.lblCodeEnd.Location = New System.Drawing.Point(610, 16)
      Me.lblCodeEnd.Name = "lblCodeEnd"
      Me.lblCodeEnd.Size = New System.Drawing.Size(32, 18)
      Me.lblCodeEnd.TabIndex = 20
      Me.lblCodeEnd.Text = "To"
      Me.lblCodeEnd.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
      '
      'txtCodeStart
      '
      Me.Validator.SetDataType(Me.txtCodeStart, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtCodeStart, "")
      Me.txtCodeStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtCodeStart, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtCodeStart, -15)
      Me.Validator.SetInvalidBackColor(Me.txtCodeStart, System.Drawing.Color.Empty)
      Me.txtCodeStart.Location = New System.Drawing.Point(490, 16)
      Me.txtCodeStart.MaxLength = 50
      Me.Validator.SetMinValue(Me.txtCodeStart, "")
      Me.txtCodeStart.Name = "txtCodeStart"
      Me.Validator.SetRegularExpression(Me.txtCodeStart, "")
      Me.Validator.SetRequired(Me.txtCodeStart, False)
      Me.txtCodeStart.Size = New System.Drawing.Size(120, 21)
      Me.txtCodeStart.TabIndex = 19
      '
      'lblCodeStart
      '
      Me.lblCodeStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblCodeStart.ForeColor = System.Drawing.Color.Black
      Me.lblCodeStart.Location = New System.Drawing.Point(378, 16)
      Me.lblCodeStart.Name = "lblCodeStart"
      Me.lblCodeStart.Size = New System.Drawing.Size(104, 18)
      Me.lblCodeStart.TabIndex = 18
      Me.lblCodeStart.Text = "Start Supplier"
      Me.lblCodeStart.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'txtPayDocDateEnd
      '
      Me.Validator.SetDataType(Me.txtPayDocDateEnd, Longkong.Pojjaman.Gui.Components.DataTypeConstants.DateTimeType)
      Me.Validator.SetDisplayName(Me.txtPayDocDateEnd, "")
      Me.Validator.SetGotFocusBackColor(Me.txtPayDocDateEnd, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtPayDocDateEnd, -15)
      Me.Validator.SetInvalidBackColor(Me.txtPayDocDateEnd, System.Drawing.Color.Empty)
      Me.txtPayDocDateEnd.Location = New System.Drawing.Point(272, 112)
      Me.txtPayDocDateEnd.MaxLength = 10
      Me.Validator.SetMinValue(Me.txtPayDocDateEnd, "")
      Me.txtPayDocDateEnd.Name = "txtPayDocDateEnd"
      Me.Validator.SetRegularExpression(Me.txtPayDocDateEnd, "")
      Me.Validator.SetRequired(Me.txtPayDocDateEnd, False)
      Me.txtPayDocDateEnd.Size = New System.Drawing.Size(99, 20)
      Me.txtPayDocDateEnd.TabIndex = 16
      '
      'txtPayDocDateStart
      '
      Me.Validator.SetDataType(Me.txtPayDocDateStart, Longkong.Pojjaman.Gui.Components.DataTypeConstants.DateTimeType)
      Me.Validator.SetDisplayName(Me.txtPayDocDateStart, "")
      Me.Validator.SetGotFocusBackColor(Me.txtPayDocDateStart, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtPayDocDateStart, -15)
      Me.Validator.SetInvalidBackColor(Me.txtPayDocDateStart, System.Drawing.Color.Empty)
      Me.txtPayDocDateStart.Location = New System.Drawing.Point(120, 112)
      Me.txtPayDocDateStart.MaxLength = 10
      Me.Validator.SetMinValue(Me.txtPayDocDateStart, "")
      Me.txtPayDocDateStart.Name = "txtPayDocDateStart"
      Me.Validator.SetRegularExpression(Me.txtPayDocDateStart, "")
      Me.Validator.SetRequired(Me.txtPayDocDateStart, False)
      Me.txtPayDocDateStart.Size = New System.Drawing.Size(99, 20)
      Me.txtPayDocDateStart.TabIndex = 13
      '
      'lblPayDocDateStart
      '
      Me.lblPayDocDateStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblPayDocDateStart.ForeColor = System.Drawing.Color.Black
      Me.lblPayDocDateStart.Location = New System.Drawing.Point(8, 112)
      Me.lblPayDocDateStart.Name = "lblPayDocDateStart"
      Me.lblPayDocDateStart.Size = New System.Drawing.Size(104, 18)
      Me.lblPayDocDateStart.TabIndex = 12
      Me.lblPayDocDateStart.Text = "วันที่จ่าย"
      Me.lblPayDocDateStart.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblPayDocDateEnd
      '
      Me.lblPayDocDateEnd.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblPayDocDateEnd.ForeColor = System.Drawing.Color.Black
      Me.lblPayDocDateEnd.Location = New System.Drawing.Point(240, 112)
      Me.lblPayDocDateEnd.Name = "lblPayDocDateEnd"
      Me.lblPayDocDateEnd.Size = New System.Drawing.Size(32, 24)
      Me.lblPayDocDateEnd.TabIndex = 15
      Me.lblPayDocDateEnd.Text = "ถึง"
      Me.lblPayDocDateEnd.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
      '
      'dtpPayDocDateStart
      '
      Me.dtpPayDocDateStart.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
      Me.dtpPayDocDateStart.Location = New System.Drawing.Point(120, 112)
      Me.dtpPayDocDateStart.Name = "dtpPayDocDateStart"
      Me.dtpPayDocDateStart.Size = New System.Drawing.Size(120, 20)
      Me.dtpPayDocDateStart.TabIndex = 14
      Me.dtpPayDocDateStart.TabStop = False
      '
      'dtpPayDocDateEnd
      '
      Me.dtpPayDocDateEnd.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
      Me.dtpPayDocDateEnd.Location = New System.Drawing.Point(272, 112)
      Me.dtpPayDocDateEnd.Name = "dtpPayDocDateEnd"
      Me.dtpPayDocDateEnd.Size = New System.Drawing.Size(120, 20)
      Me.dtpPayDocDateEnd.TabIndex = 17
      Me.dtpPayDocDateEnd.TabStop = False
      '
      'chkIncludeChildSupplierGroup
      '
      Me.chkIncludeChildSupplierGroup.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.chkIncludeChildSupplierGroup.Location = New System.Drawing.Point(490, 64)
      Me.chkIncludeChildSupplierGroup.Name = "chkIncludeChildSupplierGroup"
      Me.chkIncludeChildSupplierGroup.Size = New System.Drawing.Size(128, 24)
      Me.chkIncludeChildSupplierGroup.TabIndex = 26
      Me.chkIncludeChildSupplierGroup.Text = "Included Child Supplier"
      '
      'btnSpgCodeStart
      '
      Me.btnSpgCodeStart.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnSpgCodeStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.btnSpgCodeStart.ForeColor = System.Drawing.SystemColors.Control
      Me.btnSpgCodeStart.Location = New System.Drawing.Point(586, 40)
      Me.btnSpgCodeStart.Name = "btnSpgCodeStart"
      Me.btnSpgCodeStart.Size = New System.Drawing.Size(24, 22)
      Me.btnSpgCodeStart.TabIndex = 24
      Me.btnSpgCodeStart.TabStop = False
      Me.btnSpgCodeStart.ThemedImage = CType(resources.GetObject("btnSpgCodeStart.ThemedImage"), System.Drawing.Bitmap)
      '
      'txtSpgCodeStart
      '
      Me.Validator.SetDataType(Me.txtSpgCodeStart, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtSpgCodeStart, "")
      Me.txtSpgCodeStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtSpgCodeStart, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtSpgCodeStart, -15)
      Me.Validator.SetInvalidBackColor(Me.txtSpgCodeStart, System.Drawing.Color.Empty)
      Me.txtSpgCodeStart.Location = New System.Drawing.Point(490, 40)
      Me.txtSpgCodeStart.MaxLength = 50
      Me.Validator.SetMinValue(Me.txtSpgCodeStart, "")
      Me.txtSpgCodeStart.Name = "txtSpgCodeStart"
      Me.Validator.SetRegularExpression(Me.txtSpgCodeStart, "")
      Me.Validator.SetRequired(Me.txtSpgCodeStart, False)
      Me.txtSpgCodeStart.Size = New System.Drawing.Size(96, 21)
      Me.txtSpgCodeStart.TabIndex = 23
      '
      'lblSpgStart
      '
      Me.lblSpgStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblSpgStart.ForeColor = System.Drawing.Color.Black
      Me.lblSpgStart.Location = New System.Drawing.Point(394, 40)
      Me.lblSpgStart.Name = "lblSpgStart"
      Me.lblSpgStart.Size = New System.Drawing.Size(88, 18)
      Me.lblSpgStart.TabIndex = 22
      Me.lblSpgStart.Text = "Supplier Group"
      Me.lblSpgStart.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'txtSupplierGroupName
      '
      Me.Validator.SetDataType(Me.txtSupplierGroupName, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtSupplierGroupName, "")
      Me.txtSupplierGroupName.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtSupplierGroupName, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtSupplierGroupName, -15)
      Me.Validator.SetInvalidBackColor(Me.txtSupplierGroupName, System.Drawing.Color.Empty)
      Me.txtSupplierGroupName.Location = New System.Drawing.Point(610, 40)
      Me.txtSupplierGroupName.MaxLength = 50
      Me.Validator.SetMinValue(Me.txtSupplierGroupName, "")
      Me.txtSupplierGroupName.Name = "txtSupplierGroupName"
      Me.txtSupplierGroupName.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtSupplierGroupName, "")
      Me.Validator.SetRequired(Me.txtSupplierGroupName, False)
      Me.txtSupplierGroupName.Size = New System.Drawing.Size(160, 21)
      Me.txtSupplierGroupName.TabIndex = 25
      '
      'cmbWhtType
      '
      Me.cmbWhtType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbWhtType.Location = New System.Drawing.Point(120, 16)
      Me.cmbWhtType.Name = "cmbWhtType"
      Me.cmbWhtType.Size = New System.Drawing.Size(120, 21)
      Me.cmbWhtType.TabIndex = 1
      '
      'lblWhtType
      '
      Me.lblWhtType.BackColor = System.Drawing.Color.Transparent
      Me.lblWhtType.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblWhtType.ForeColor = System.Drawing.SystemColors.WindowText
      Me.lblWhtType.Location = New System.Drawing.Point(8, 16)
      Me.lblWhtType.Name = "lblWhtType"
      Me.lblWhtType.Size = New System.Drawing.Size(104, 18)
      Me.lblWhtType.TabIndex = 0
      Me.lblWhtType.Text = "Type of Tax"
      Me.lblWhtType.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'chkIncludeChildren
      '
      Me.chkIncludeChildren.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.chkIncludeChildren.Location = New System.Drawing.Point(490, 136)
      Me.chkIncludeChildren.Name = "chkIncludeChildren"
      Me.chkIncludeChildren.Size = New System.Drawing.Size(128, 24)
      Me.chkIncludeChildren.TabIndex = 37
      Me.chkIncludeChildren.Text = "Include Sub CC:"
      '
      'btnCCCodeStart
      '
      Me.btnCCCodeStart.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnCCCodeStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.btnCCCodeStart.ForeColor = System.Drawing.SystemColors.Control
      Me.btnCCCodeStart.Location = New System.Drawing.Point(586, 112)
      Me.btnCCCodeStart.Name = "btnCCCodeStart"
      Me.btnCCCodeStart.Size = New System.Drawing.Size(24, 22)
      Me.btnCCCodeStart.TabIndex = 35
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
      Me.txtCCCodeStart.Location = New System.Drawing.Point(490, 112)
      Me.txtCCCodeStart.MaxLength = 50
      Me.Validator.SetMinValue(Me.txtCCCodeStart, "")
      Me.txtCCCodeStart.Name = "txtCCCodeStart"
      Me.Validator.SetRegularExpression(Me.txtCCCodeStart, "")
      Me.Validator.SetRequired(Me.txtCCCodeStart, False)
      Me.txtCCCodeStart.Size = New System.Drawing.Size(96, 21)
      Me.txtCCCodeStart.TabIndex = 34
      '
      'lblCCStart
      '
      Me.lblCCStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblCCStart.ForeColor = System.Drawing.Color.Black
      Me.lblCCStart.Location = New System.Drawing.Point(410, 112)
      Me.lblCCStart.Name = "lblCCStart"
      Me.lblCCStart.Size = New System.Drawing.Size(72, 18)
      Me.lblCCStart.TabIndex = 33
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
      Me.txtCostCenterName.Location = New System.Drawing.Point(610, 112)
      Me.txtCostCenterName.MaxLength = 50
      Me.Validator.SetMinValue(Me.txtCostCenterName, "")
      Me.txtCostCenterName.Name = "txtCostCenterName"
      Me.txtCostCenterName.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtCostCenterName, "")
      Me.Validator.SetRequired(Me.txtCostCenterName, False)
      Me.txtCostCenterName.Size = New System.Drawing.Size(152, 21)
      Me.txtCostCenterName.TabIndex = 36
      '
      'btnSupplierEnd
      '
      Me.btnSupplierEnd.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnSupplierEnd.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.btnSupplierEnd.ForeColor = System.Drawing.SystemColors.Control
      Me.btnSupplierEnd.Location = New System.Drawing.Point(738, 88)
      Me.btnSupplierEnd.Name = "btnSupplierEnd"
      Me.btnSupplierEnd.Size = New System.Drawing.Size(24, 22)
      Me.btnSupplierEnd.TabIndex = 32
      Me.btnSupplierEnd.TabStop = False
      Me.btnSupplierEnd.ThemedImage = CType(resources.GetObject("btnSupplierEnd.ThemedImage"), System.Drawing.Bitmap)
      '
      'txtSupplierCodeEnd
      '
      Me.Validator.SetDataType(Me.txtSupplierCodeEnd, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtSupplierCodeEnd, "")
      Me.txtSupplierCodeEnd.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtSupplierCodeEnd, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtSupplierCodeEnd, -15)
      Me.Validator.SetInvalidBackColor(Me.txtSupplierCodeEnd, System.Drawing.Color.Empty)
      Me.txtSupplierCodeEnd.Location = New System.Drawing.Point(642, 88)
      Me.txtSupplierCodeEnd.MaxLength = 50
      Me.Validator.SetMinValue(Me.txtSupplierCodeEnd, "")
      Me.txtSupplierCodeEnd.Name = "txtSupplierCodeEnd"
      Me.Validator.SetRegularExpression(Me.txtSupplierCodeEnd, "")
      Me.Validator.SetRequired(Me.txtSupplierCodeEnd, False)
      Me.txtSupplierCodeEnd.Size = New System.Drawing.Size(96, 21)
      Me.txtSupplierCodeEnd.TabIndex = 31
      '
      'lblSupplierEnd
      '
      Me.lblSupplierEnd.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblSupplierEnd.ForeColor = System.Drawing.Color.Black
      Me.lblSupplierEnd.Location = New System.Drawing.Point(610, 88)
      Me.lblSupplierEnd.Name = "lblSupplierEnd"
      Me.lblSupplierEnd.Size = New System.Drawing.Size(32, 18)
      Me.lblSupplierEnd.TabIndex = 30
      Me.lblSupplierEnd.Text = "To"
      Me.lblSupplierEnd.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
      '
      'btnSupplierStart
      '
      Me.btnSupplierStart.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnSupplierStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.btnSupplierStart.ForeColor = System.Drawing.SystemColors.Control
      Me.btnSupplierStart.Location = New System.Drawing.Point(586, 88)
      Me.btnSupplierStart.Name = "btnSupplierStart"
      Me.btnSupplierStart.Size = New System.Drawing.Size(24, 22)
      Me.btnSupplierStart.TabIndex = 29
      Me.btnSupplierStart.TabStop = False
      Me.btnSupplierStart.ThemedImage = CType(resources.GetObject("btnSupplierStart.ThemedImage"), System.Drawing.Bitmap)
      '
      'txtSupplierCodeStart
      '
      Me.Validator.SetDataType(Me.txtSupplierCodeStart, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtSupplierCodeStart, "")
      Me.txtSupplierCodeStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtSupplierCodeStart, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtSupplierCodeStart, -15)
      Me.Validator.SetInvalidBackColor(Me.txtSupplierCodeStart, System.Drawing.Color.Empty)
      Me.txtSupplierCodeStart.Location = New System.Drawing.Point(490, 88)
      Me.txtSupplierCodeStart.MaxLength = 50
      Me.Validator.SetMinValue(Me.txtSupplierCodeStart, "")
      Me.txtSupplierCodeStart.Name = "txtSupplierCodeStart"
      Me.Validator.SetRegularExpression(Me.txtSupplierCodeStart, "")
      Me.Validator.SetRequired(Me.txtSupplierCodeStart, False)
      Me.txtSupplierCodeStart.Size = New System.Drawing.Size(96, 21)
      Me.txtSupplierCodeStart.TabIndex = 28
      '
      'lblSupplierStart
      '
      Me.lblSupplierStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblSupplierStart.ForeColor = System.Drawing.Color.Black
      Me.lblSupplierStart.Location = New System.Drawing.Point(397, 88)
      Me.lblSupplierStart.Name = "lblSupplierStart"
      Me.lblSupplierStart.Size = New System.Drawing.Size(85, 18)
      Me.lblSupplierStart.TabIndex = 27
      Me.lblSupplierStart.Text = "Start Supplier"
      Me.lblSupplierStart.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'cmbYear
      '
      Me.cmbYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbYear.Location = New System.Drawing.Point(120, 64)
      Me.cmbYear.Name = "cmbYear"
      Me.cmbYear.Size = New System.Drawing.Size(120, 21)
      Me.cmbYear.TabIndex = 5
      '
      'lblYear
      '
      Me.lblYear.BackColor = System.Drawing.Color.Transparent
      Me.lblYear.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblYear.ForeColor = System.Drawing.SystemColors.WindowText
      Me.lblYear.Location = New System.Drawing.Point(8, 64)
      Me.lblYear.Name = "lblYear"
      Me.lblYear.Size = New System.Drawing.Size(104, 18)
      Me.lblYear.TabIndex = 4
      Me.lblYear.Text = "Year Tax:"
      Me.lblYear.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'cmbMonth
      '
      Me.cmbMonth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbMonth.Location = New System.Drawing.Point(120, 40)
      Me.cmbMonth.Name = "cmbMonth"
      Me.cmbMonth.Size = New System.Drawing.Size(120, 21)
      Me.cmbMonth.TabIndex = 3
      '
      'lblMonth
      '
      Me.lblMonth.BackColor = System.Drawing.Color.Transparent
      Me.lblMonth.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblMonth.ForeColor = System.Drawing.SystemColors.WindowText
      Me.lblMonth.Location = New System.Drawing.Point(8, 40)
      Me.lblMonth.Name = "lblMonth"
      Me.lblMonth.Size = New System.Drawing.Size(104, 18)
      Me.lblMonth.TabIndex = 2
      Me.lblMonth.Text = "Tax Month"
      Me.lblMonth.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'txtDocDateEnd
      '
      Me.Validator.SetDataType(Me.txtDocDateEnd, Longkong.Pojjaman.Gui.Components.DataTypeConstants.DateTimeType)
      Me.Validator.SetDisplayName(Me.txtDocDateEnd, "")
      Me.Validator.SetGotFocusBackColor(Me.txtDocDateEnd, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtDocDateEnd, -15)
      Me.Validator.SetInvalidBackColor(Me.txtDocDateEnd, System.Drawing.Color.Empty)
      Me.txtDocDateEnd.Location = New System.Drawing.Point(272, 88)
      Me.txtDocDateEnd.MaxLength = 10
      Me.Validator.SetMinValue(Me.txtDocDateEnd, "")
      Me.txtDocDateEnd.Name = "txtDocDateEnd"
      Me.Validator.SetRegularExpression(Me.txtDocDateEnd, "")
      Me.Validator.SetRequired(Me.txtDocDateEnd, False)
      Me.txtDocDateEnd.Size = New System.Drawing.Size(99, 20)
      Me.txtDocDateEnd.TabIndex = 10
      '
      'txtDocDateStart
      '
      Me.Validator.SetDataType(Me.txtDocDateStart, Longkong.Pojjaman.Gui.Components.DataTypeConstants.DateTimeType)
      Me.Validator.SetDisplayName(Me.txtDocDateStart, "")
      Me.Validator.SetGotFocusBackColor(Me.txtDocDateStart, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtDocDateStart, -15)
      Me.Validator.SetInvalidBackColor(Me.txtDocDateStart, System.Drawing.Color.Empty)
      Me.txtDocDateStart.Location = New System.Drawing.Point(120, 88)
      Me.txtDocDateStart.MaxLength = 10
      Me.Validator.SetMinValue(Me.txtDocDateStart, "")
      Me.txtDocDateStart.Name = "txtDocDateStart"
      Me.Validator.SetRegularExpression(Me.txtDocDateStart, "")
      Me.Validator.SetRequired(Me.txtDocDateStart, False)
      Me.txtDocDateStart.Size = New System.Drawing.Size(99, 20)
      Me.txtDocDateStart.TabIndex = 7
      '
      'lblDocDateStart
      '
      Me.lblDocDateStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblDocDateStart.ForeColor = System.Drawing.Color.Black
      Me.lblDocDateStart.Location = New System.Drawing.Point(8, 88)
      Me.lblDocDateStart.Name = "lblDocDateStart"
      Me.lblDocDateStart.Size = New System.Drawing.Size(104, 18)
      Me.lblDocDateStart.TabIndex = 6
      Me.lblDocDateStart.Text = "Start Date"
      Me.lblDocDateStart.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblDocDateEnd
      '
      Me.lblDocDateEnd.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblDocDateEnd.ForeColor = System.Drawing.Color.Black
      Me.lblDocDateEnd.Location = New System.Drawing.Point(240, 86)
      Me.lblDocDateEnd.Name = "lblDocDateEnd"
      Me.lblDocDateEnd.Size = New System.Drawing.Size(32, 24)
      Me.lblDocDateEnd.TabIndex = 9
      Me.lblDocDateEnd.Text = "End Date"
      Me.lblDocDateEnd.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
      '
      'dtpDocDateStart
      '
      Me.dtpDocDateStart.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
      Me.dtpDocDateStart.Location = New System.Drawing.Point(120, 88)
      Me.dtpDocDateStart.Name = "dtpDocDateStart"
      Me.dtpDocDateStart.Size = New System.Drawing.Size(120, 20)
      Me.dtpDocDateStart.TabIndex = 8
      Me.dtpDocDateStart.TabStop = False
      '
      'dtpDocDateEnd
      '
      Me.dtpDocDateEnd.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
      Me.dtpDocDateEnd.Location = New System.Drawing.Point(272, 88)
      Me.dtpDocDateEnd.Name = "dtpDocDateEnd"
      Me.dtpDocDateEnd.Size = New System.Drawing.Size(120, 20)
      Me.dtpDocDateEnd.TabIndex = 11
      Me.dtpDocDateEnd.TabStop = False
      '
      'btnSearch
      '
      Me.btnSearch.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnSearch.Location = New System.Drawing.Point(712, 194)
      Me.btnSearch.Name = "btnSearch"
      Me.btnSearch.Size = New System.Drawing.Size(75, 23)
      Me.btnSearch.TabIndex = 2
      Me.btnSearch.Text = "Find"
      '
      'btnReset
      '
      Me.btnReset.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnReset.Location = New System.Drawing.Point(624, 194)
      Me.btnReset.Name = "btnReset"
      Me.btnReset.Size = New System.Drawing.Size(75, 23)
      Me.btnReset.TabIndex = 1
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
      'btnAcctBookEndFind
      '
      Me.btnAcctBookEndFind.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnAcctBookEndFind.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.btnAcctBookEndFind.ForeColor = System.Drawing.SystemColors.Control
      Me.btnAcctBookEndFind.Location = New System.Drawing.Point(367, 138)
      Me.btnAcctBookEndFind.Name = "btnAcctBookEndFind"
      Me.btnAcctBookEndFind.Size = New System.Drawing.Size(24, 22)
      Me.btnAcctBookEndFind.TabIndex = 48
      Me.btnAcctBookEndFind.TabStop = False
      Me.btnAcctBookEndFind.ThemedImage = CType(resources.GetObject("btnAcctBookEndFind.ThemedImage"), System.Drawing.Bitmap)
      '
      'txtAcctBookEnd
      '
      Me.Validator.SetDataType(Me.txtAcctBookEnd, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtAcctBookEnd, "")
      Me.txtAcctBookEnd.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtAcctBookEnd, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtAcctBookEnd, -15)
      Me.Validator.SetInvalidBackColor(Me.txtAcctBookEnd, System.Drawing.Color.Empty)
      Me.txtAcctBookEnd.Location = New System.Drawing.Point(272, 138)
      Me.Validator.SetMinValue(Me.txtAcctBookEnd, "")
      Me.txtAcctBookEnd.Name = "txtAcctBookEnd"
      Me.Validator.SetRegularExpression(Me.txtAcctBookEnd, "")
      Me.Validator.SetRequired(Me.txtAcctBookEnd, False)
      Me.txtAcctBookEnd.Size = New System.Drawing.Size(96, 21)
      Me.txtAcctBookEnd.TabIndex = 44
      '
      'lblAcctBookEnd
      '
      Me.lblAcctBookEnd.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblAcctBookEnd.ForeColor = System.Drawing.Color.Black
      Me.lblAcctBookEnd.Location = New System.Drawing.Point(241, 138)
      Me.lblAcctBookEnd.Name = "lblAcctBookEnd"
      Me.lblAcctBookEnd.Size = New System.Drawing.Size(24, 18)
      Me.lblAcctBookEnd.TabIndex = 47
      Me.lblAcctBookEnd.Text = "ถึง"
      Me.lblAcctBookEnd.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
      '
      'btnAcctBookStartFind
      '
      Me.btnAcctBookStartFind.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnAcctBookStartFind.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.btnAcctBookStartFind.ForeColor = System.Drawing.SystemColors.Control
      Me.btnAcctBookStartFind.Location = New System.Drawing.Point(216, 138)
      Me.btnAcctBookStartFind.Name = "btnAcctBookStartFind"
      Me.btnAcctBookStartFind.Size = New System.Drawing.Size(24, 22)
      Me.btnAcctBookStartFind.TabIndex = 46
      Me.btnAcctBookStartFind.TabStop = False
      Me.btnAcctBookStartFind.ThemedImage = CType(resources.GetObject("btnAcctBookStartFind.ThemedImage"), System.Drawing.Bitmap)
      '
      'txtAcctBookStart
      '
      Me.Validator.SetDataType(Me.txtAcctBookStart, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtAcctBookStart, "")
      Me.txtAcctBookStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtAcctBookStart, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtAcctBookStart, -15)
      Me.Validator.SetInvalidBackColor(Me.txtAcctBookStart, System.Drawing.Color.Empty)
      Me.txtAcctBookStart.Location = New System.Drawing.Point(120, 138)
      Me.Validator.SetMinValue(Me.txtAcctBookStart, "")
      Me.txtAcctBookStart.Name = "txtAcctBookStart"
      Me.Validator.SetRegularExpression(Me.txtAcctBookStart, "")
      Me.Validator.SetRequired(Me.txtAcctBookStart, False)
      Me.txtAcctBookStart.Size = New System.Drawing.Size(96, 21)
      Me.txtAcctBookStart.TabIndex = 43
      '
      'lblAcctBookStart
      '
      Me.lblAcctBookStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblAcctBookStart.ForeColor = System.Drawing.Color.Black
      Me.lblAcctBookStart.Location = New System.Drawing.Point(24, 138)
      Me.lblAcctBookStart.Name = "lblAcctBookStart"
      Me.lblAcctBookStart.Size = New System.Drawing.Size(88, 18)
      Me.lblAcctBookStart.TabIndex = 45
      Me.lblAcctBookStart.Text = "ตั้งแต่สมุดรายวัน"
      Me.lblAcctBookStart.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'RptIncomingWhtFilterSubPanel
      '
      Me.Controls.Add(Me.grbDetail)
      Me.Name = "RptIncomingWhtFilterSubPanel"
      Me.Size = New System.Drawing.Size(824, 242)
      Me.grbDetail.ResumeLayout(False)
      Me.grbDocDate.ResumeLayout(False)
      Me.grbDocDate.PerformLayout()
      CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
      Me.ResumeLayout(False)

    End Sub

#End Region

#Region " SetLabelText "
    Public Sub SetLabelText()

      '-----------------NEW FILTER-------------
      Me.lblCodeStart.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptIncomingWhtFilterSubPanel.lblCodeStart}")
      Me.Validator.SetDisplayName(txtCodeStart, lblCodeStart.Text)

      Me.lblCodeEnd.Text = Me.StringParserService.Parse("${res:Global.FilterPanelTo}")
      Me.Validator.SetDisplayName(txtCodeEnd, lblCodeEnd.Text)

      Me.lblPayDocDateStart.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptIncomingWhtFilterSubPanel.lblPayDocDateStart}")
      Me.Validator.SetDisplayName(txtPayDocDateStart, lblPayDocDateStart.Text)

      Me.lblPayDocDateEnd.Text = Me.StringParserService.Parse("${res:Global.FilterPanelTo}")
      Me.Validator.SetDisplayName(txtPayDocDateEnd, lblPayDocDateEnd.Text)
      '-----------------NEW FILTER-------------

      Me.lblDocDateStart.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptIncomingWhtFilterSubPanel.lblDocDateStart}")
      Me.Validator.SetDisplayName(txtDocDateStart, lblDocDateStart.Text)

      Me.lblSupplierStart.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptIncomingWhtFilterSubPanel.lblSupplierStart}")
      Me.Validator.SetDisplayName(txtSupplierCodeStart, lblSupplierStart.Text)

      Me.lblCCStart.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptIncomingWhtFilterSubPanel.lblCCStart}")
      Me.Validator.SetDisplayName(txtCCCodeStart, lblCCStart.Text)

      Me.lblWhtType.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptIncomingWhtFilterSubPanel.lblWhtType}")
      Me.lblYear.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptIncomingWhtFilterSubPanel.lblYear}")
      Me.lblMonth.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptIncomingWhtFilterSubPanel.lblMonth}")

      ' Global
      Me.lblSupplierEnd.Text = Me.StringParserService.Parse("${res:Global.FilterPanelTo}")
      Me.Validator.SetDisplayName(txtSupplierCodeEnd, lblSupplierEnd.Text)

      Me.lblDocDateEnd.Text = Me.StringParserService.Parse("${res:Global.FilterPanelTo}")
      Me.Validator.SetDisplayName(txtDocDateEnd, lblDocDateEnd.Text)
      ' Button
      Me.btnSearch.Text = Me.StringParserService.Parse("${res:Global.SearchButtonText}")
      Me.btnReset.Text = Me.StringParserService.Parse("${res:Global.ResetButtonText}")
      ' Group box
      Me.grbDetail.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptIncomingWhtFilterSubPanel.grbDetail}")
      Me.grbDocDate.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptIncomingWhtFilterSubPanel.grbDocDate}")

      'Checkbox
      Me.chkIncludeChildren.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptIncomingWhtFilterSubPanel.chkIncludeChildren}")
      Me.lblSpgStart.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptIncomingWhtFilterSubPanel.lblSpgStart}")
      Me.chkIncludeChildSupplierGroup.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptIncomingWhtFilterSubPanel.chkIncludeChildSupplierGroup}")

    End Sub
#End Region

#Region " Member "
    Private m_DocDateEnd As Date
    Private m_DocDateStart As Date

    Private m_PayDocDateEnd As Date
    Private m_PayDocDateStart As Date

    Private m_cc As Costcenter
    Private m_suppliergroup As SupplierGroup

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
    Public Property PayDocDateEnd() As Date      Get        Return m_PayDocDateEnd      End Get      Set(ByVal Value As Date)        m_PayDocDateEnd = Value      End Set    End Property    Public Property PayDocDateStart() As Date      Get        Return m_PayDocDateStart      End Get      Set(ByVal Value As Date)        m_PayDocDateStart = Value      End Set    End Property

    Public Property DocDateEnd() As Date      Get        Return m_DocDateEnd      End Get      Set(ByVal Value As Date)        m_DocDateEnd = Value      End Set    End Property    Public Property DocDateStart() As Date      Get        Return m_DocDateStart      End Get      Set(ByVal Value As Date)        m_DocDateStart = Value      End Set    End Property
    Public Property Costcenter() As Costcenter
      Get
        Return m_cc
      End Get
      Set(ByVal Value As Costcenter)
        m_cc = Value
      End Set
    End Property
    Public Property SupplierGroup() As SupplierGroup
      Get
        Return m_suppliergroup
      End Get
      Set(ByVal Value As SupplierGroup)
        m_suppliergroup = Value
      End Set
    End Property
#End Region

#Region " Methods "
    Private Sub RegisterDropdown()
      'ประเภทภาษีหัก ณ ที่จ่าย
      WitholdingTaxType.ListCodeDescriptionInComboBox(Me.cmbWhtType, "wht_type", True)
      cmbWhtType.SelectedIndex = 0
    End Sub
    Private Sub PopulateStatus()
      Dim baseDate As Date = AccountBaseDate.GetBaseDateFromDB() 'CDate(Configuration.GetConfig("BaseDate"))
      Dim years(9) As Date
      For i As Integer = 0 To 9
        years(i) = DateAdd(DateInterval.Year, i, baseDate)
      Next
      Dim myDateTimeService As DateTimeService = CType(ServiceManager.Services.GetService(GetType(DateTimeService)), DateTimeService)
      myDateTimeService.ListYearsInComboBox(Me.cmbYear, years)
      myDateTimeService.ListMonthsInComboBox(Me.cmbMonth, False, , False)
    End Sub
    Private Sub Initialize()
      PopulateStatus()
      RegisterDropdown()
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

      Me.Costcenter = New Costcenter

      Dim dtStart As Date = Date.Now.Subtract(New TimeSpan(7, 0, 0, 0))
      Me.txtDocDateStart.Text = MinDateToNull(dtStart, "")
      Me.dtpDocDateStart.Value = dtStart
      Me.DocDateStart = dtStart

      Me.txtDocDateEnd.Text = MinDateToNull(Date.Now, "")
      Me.dtpDocDateEnd.Value = Date.Now
      Me.DocDateEnd = Date.Now

      Me.txtPayDocDateStart.Text = MinDateToNull(dtStart, "")
      Me.dtpPayDocDateStart.Value = dtStart
      Me.PayDocDateStart = dtStart

      Me.txtPayDocDateEnd.Text = MinDateToNull(Date.Now, "")
      Me.dtpPayDocDateEnd.Value = Date.Now
      Me.PayDocDateEnd = Date.Now

      Me.cmbYear.SelectedIndex = (Date.Now.Year - AccountBaseDate.GetBaseDateFromDB().Year) 'CDate(Configuration.GetConfig("BaseDate")).Year)
      Me.cmbMonth.SelectedIndex = Date.Now.Month - 1
      Me.SupplierGroup = New SupplierGroup

    End Sub
    Public Overrides Function GetFilterString() As String

    End Function
    Public Overrides Function GetFilterArray() As Filter()
      Dim arr(15) As Filter
      arr(0) = New Filter("DocDateStart", IIf(Me.DocDateStart.Equals(Date.MinValue), DBNull.Value, Me.DocDateStart))
      arr(1) = New Filter("DocDateEnd", IIf(Me.DocDateEnd.Equals(Date.MinValue), DBNull.Value, Me.DocDateEnd))
      arr(2) = New Filter("SupplierCodeStart", IIf(Me.txtSupplierCodeStart.TextLength > 0, Me.txtSupplierCodeStart.Text, DBNull.Value))
      arr(3) = New Filter("SupplierCodeEnd", IIf(Me.txtSupplierCodeEnd.TextLength > 0, Me.txtSupplierCodeEnd.Text, DBNull.Value))
      arr(4) = New Filter("cc_id", Me.ValidIdOrDBNull(m_cc))
      arr(5) = New Filter("IncludeChildCC", Me.chkIncludeChildren.Checked)
      arr(6) = New Filter("WhtType", IIf(cmbWhtType.SelectedItem Is Nothing, DBNull.Value, CType(cmbWhtType.SelectedItem, IdValuePair).Id))
      arr(7) = New Filter("userRight", CType(ServiceManager.Services.GetService(GetType(SecurityService)), SecurityService).CurrentUser.Id)
      arr(8) = New Filter("SupplierGroupID", Me.ValidIdOrDBNull(m_suppliergroup))
      arr(9) = New Filter("IncludeChildSupplierGroup", Me.chkIncludeChildSupplierGroup.Checked)
      arr(10) = New Filter("PayDocDateStart", IIf(Me.PayDocDateStart.Equals(Date.MinValue), DBNull.Value, Me.PayDocDateStart))
      arr(11) = New Filter("PayDocDateEnd", IIf(Me.PayDocDateEnd.Equals(Date.MinValue), DBNull.Value, Me.PayDocDateEnd))
      arr(12) = New Filter("CodeStart", IIf(Me.txtCodeStart.TextLength > 0, Me.txtCodeStart.Text, DBNull.Value))
      arr(13) = New Filter("CodeEnd", IIf(Me.txtCodeEnd.TextLength > 0, Me.txtCodeEnd.Text, DBNull.Value))
      arr(14) = New Filter("AcctBookCodeStart", IIf(txtAcctBookStart.TextLength > 0, txtAcctBookStart.Text, DBNull.Value))
      arr(15) = New Filter("AcctBookCodeEnd", IIf(txtAcctBookEnd.TextLength > 0, txtAcctBookEnd.Text, DBNull.Value))
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

      'WhtType
      dpi = New DocPrintingItem
      dpi.Mapping = "WhtType"
      dpi.Value = Me.cmbWhtType.Text
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

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

      'Pay Docdate Start
      dpi = New DocPrintingItem
      dpi.Mapping = "PayDocdateStart"
      dpi.Value = Me.txtPayDocDateStart.Text
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      'PayDocdate End
      dpi = New DocPrintingItem
      dpi.Mapping = "PayDocdateEnd"
      dpi.Value = Me.txtPayDocDateEnd.Text
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)


      'Code Start
      dpi = New DocPrintingItem
      dpi.Mapping = "CodeStart"
      dpi.Value = Me.txtCodeStart.Text
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      'Code End
      dpi = New DocPrintingItem
      dpi.Mapping = "CodeEnd"
      dpi.Value = Me.txtCodeEnd.Text
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      'Supplier Start
      dpi = New DocPrintingItem
      dpi.Mapping = "SupplierStart"
      dpi.Value = Me.txtSupplierCodeStart.Text
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      'Supplier End
      dpi = New DocPrintingItem
      dpi.Mapping = "SupplierEnd"
      dpi.Value = Me.txtSupplierCodeEnd.Text
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

      'SupplierGroup Start
      dpi = New DocPrintingItem
      dpi.Mapping = "SupplierGroupCodeStart"
      dpi.Value = Me.txtSpgCodeStart.Text
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      'CheckBox ChildSupplierGroupInclude
      If Me.chkIncludeChildSupplierGroup.Checked Then
        dpi = New DocPrintingItem
        dpi.Mapping = "childSupplierGroupincluded"
        dpi.Value = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptIncomingWhtFilterSubPanel.childSupplierGroupincluded}")
        dpi.DataType = "System.String"
        dpiColl.Add(dpi)
      End If

      Return dpiColl
    End Function
#End Region

#Region " ChangeProperty Methods "
    Private Sub EventWiring()
      AddHandler btnSupplierStart.Click, AddressOf Me.btnSupplierFind_Click
      AddHandler btnSupplierEnd.Click, AddressOf Me.btnSupplierFind_Click

      AddHandler btnAcctBookStartFind.Click, AddressOf Me.btnAccountBookFind_Click
      AddHandler btnAcctBookEndFind.Click, AddressOf Me.btnAccountBookFind_Click

      AddHandler dtpDocDateStart.ValueChanged, AddressOf ChangeProperty
      AddHandler txtDocDateStart.Validated, AddressOf ChangeProperty

      AddHandler btnCCCodeStart.Click, AddressOf Me.btnCostcenterFind_Click
      AddHandler txtCCCodeStart.Validated, AddressOf Me.ChangeProperty

      AddHandler dtpDocDateEnd.ValueChanged, AddressOf ChangeProperty
      AddHandler txtDocDateEnd.Validated, AddressOf ChangeProperty
      AddHandler btnSpgCodeStart.Click, AddressOf Me.btnSupplierGroupFind_Click

      AddHandler dtpPayDocDateStart.ValueChanged, AddressOf ChangeProperty
      AddHandler txtPayDocDateStart.Validated, AddressOf ChangeProperty
      AddHandler dtpPayDocDateEnd.ValueChanged, AddressOf ChangeProperty
      AddHandler txtPayDocDateEnd.Validated, AddressOf ChangeProperty
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
          '------------------------------------------------------------------------------------
        Case "dtppaydocdatestart"
          If Not Me.PayDocDateStart.Equals(dtpPayDocDateStart.Value) Then
            If Not m_dateSetting Then
              Me.txtPayDocDateStart.Text = MinDateToNull(dtpPayDocDateStart.Value, Me.StringParserService.Parse("${res:Global.BlankDateText}"))
              Me.PayDocDateStart = dtpPayDocDateStart.Value
            End If
          End If
        Case "txtpaydocdatestart"
          m_dateSetting = True
          If Not Me.txtPayDocDateStart.Text.Length = 0 AndAlso Me.Validator.GetErrorMessage(Me.txtPayDocDateStart) = "" Then
            Dim theDate As Date = CDate(Me.txtPayDocDateStart.Text)
            If Not Me.PayDocDateStart.Equals(theDate) Then
              dtpPayDocDateStart.Value = theDate
              Me.PayDocDateStart = dtpPayDocDateStart.Value
            End If
          Else
            Me.dtpPayDocDateStart.Value = Date.Now
            Me.PayDocDateStart = Date.MinValue
          End If
          m_dateSetting = False

        Case "dtppaydocdateend"
          If Not Me.PayDocDateEnd.Equals(dtpPayDocDateEnd.Value) Then
            If Not m_dateSetting Then
              Me.txtPayDocDateEnd.Text = MinDateToNull(dtpPayDocDateEnd.Value, Me.StringParserService.Parse("${res:Global.BlankDateText}"))
              Me.PayDocDateEnd = dtpPayDocDateEnd.Value
            End If
          End If
        Case "txtpaydocdateend"
          m_dateSetting = True
          If Not Me.txtPayDocDateEnd.Text.Length = 0 AndAlso Me.Validator.GetErrorMessage(Me.txtPayDocDateEnd) = "" Then
            Dim theDate As Date = CDate(Me.txtPayDocDateEnd.Text)
            If Not Me.PayDocDateEnd.Equals(theDate) Then
              dtpPayDocDateEnd.Value = theDate
              Me.PayDocDateEnd = dtpPayDocDateEnd.Value
            End If
          Else
            Me.dtpPayDocDateEnd.Value = Date.Now
            Me.PayDocDateEnd = Date.MinValue
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
        If data.GetDataPresent((New Supplier).FullClassName) Then
          If Not Me.ActiveControl Is Nothing Then
            Select Case Me.ActiveControl.Name.ToLower
              Case "txtsuppliercodestart", "txtsuppliercodeend"
                Return True
            End Select
          End If
        End If
        ' Costcenter
        If data.GetDataPresent((New Costcenter).FullClassName) Then
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
      If data.GetDataPresent((New Supplier).FullClassName) Then
        Dim id As Integer = CInt(data.GetData((New Supplier).FullClassName))
        Dim entity As New Supplier(id)
        If Not Me.ActiveControl Is Nothing Then
          Select Case Me.ActiveControl.Name.ToLower
            Case "txtsuppliercodestart"
              Me.SetSupplierStartDialog(entity)

            Case "txtsuppliercodeend"
              Me.SetSupplierEndDialog(entity)

          End Select
        End If
      End If
      ' Costcenter
      If data.GetDataPresent((New Costcenter).FullClassName) Then
        Dim id As Integer = CInt(data.GetData((New Costcenter).FullClassName))
        Dim entity As New Costcenter(id)
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
    Private Sub btnAccountBookFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
      Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      Select Case CType(sender, Control).Name.ToLower
        Case "btnacctbookstartfind"
          myEntityPanelService.OpenListDialog(New AccountBook, AddressOf SetAccountBookStartDialog)

        Case "btnacctbookendfind"
          myEntityPanelService.OpenListDialog(New AccountBook, AddressOf SetAccountBookEndDialog)

      End Select
    End Sub
    Private Sub btnSupplierFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
      Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      Select Case CType(sender, Control).Name.ToLower
        Case "btnsupplierstart"
          myEntityPanelService.OpenListDialog(New Supplier, AddressOf SetSupplierStartDialog)

        Case "btnsupplierend"
          myEntityPanelService.OpenListDialog(New Supplier, AddressOf SetSupplierEndDialog)

      End Select
    End Sub
    ' Costcenter
    Private Sub btnCostcenterFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
      Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      Select Case CType(sender, Control).Name.ToLower
        Case "btncccodestart"
          myEntityPanelService.OpenTreeDialog(New CostCenter, AddressOf SetCCCodeStartDialog)
      End Select
    End Sub
    Private Sub SetSupplierStartDialog(ByVal e As ISimpleEntity)
      Me.txtSupplierCodeStart.Text = e.Code
    End Sub
    Private Sub SetSupplierEndDialog(ByVal e As ISimpleEntity)
      Me.txtSupplierCodeEnd.Text = e.Code
    End Sub
    Private Sub SetCCCodeStartDialog(ByVal e As ISimpleEntity)
      Me.txtCCCodeStart.Text = e.Code
      Costcenter.GetCostCenter(txtCCCodeStart, txtCostCenterName, m_cc, CType(ServiceManager.Services.GetService(GetType(SecurityService)), SecurityService).CurrentUser.Id)
    End Sub
    ' SupplierGroup
    Private Sub btnSupplierGroupFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
      Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      Select Case CType(sender, Control).Name.ToLower
        Case "btnspgcodestart"
          myEntityPanelService.OpenTreeDialog(New SupplierGroup, AddressOf SetSpgCodeStartDialog)
      End Select
    End Sub
    Private Sub SetSpgCodeStartDialog(ByVal e As ISimpleEntity)
      Me.txtSpgCodeStart.Text = e.Code
      SupplierGroup.GetSupplierGroup(txtSpgCodeStart, txtSupplierGroupName, m_suppliergroup, True)
    End Sub
    Private Sub SetAccountBookStartDialog(ByVal e As ISimpleEntity)
      Me.txtAcctBookStart.Text = e.Code
    End Sub
    Private Sub SetAccountBookEndDialog(ByVal e As ISimpleEntity)
      Me.txtAcctBookEnd.Text = e.Code
    End Sub
#End Region

  End Class
End Namespace

