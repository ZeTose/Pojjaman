Imports Longkong.Pojjaman.BusinessLogic
Imports longkong.Pojjaman.Services
Imports Longkong.Core.Services

Namespace Longkong.Pojjaman.Gui.Panels
    Public Class RptSCMovementFilterSubPanel
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
    Friend WithEvents grbMaster As Longkong.Pojjaman.Gui.Components.FixedGroupBox
    Friend WithEvents btnSearch As System.Windows.Forms.Button
    Friend WithEvents btnReset As System.Windows.Forms.Button
    Friend WithEvents lblDocDateStart As System.Windows.Forms.Label
    Friend WithEvents lblDocDateEnd As System.Windows.Forms.Label
    Friend WithEvents Validator As Longkong.Pojjaman.Gui.Components.PJMTextboxValidator
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents txtDocDateEnd As System.Windows.Forms.TextBox
    Friend WithEvents txtDocDateStart As System.Windows.Forms.TextBox
    Friend WithEvents dtpDocDateStart As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpDocDateEnd As System.Windows.Forms.DateTimePicker
    Friend WithEvents grbDetail As Longkong.Pojjaman.Gui.Components.FixedGroupBox
    Friend WithEvents txtTemp As System.Windows.Forms.TextBox
    Friend WithEvents btnCCCodeStart As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents txtCCStart As System.Windows.Forms.TextBox
    Friend WithEvents lblCCStart As System.Windows.Forms.Label
    Friend WithEvents btnSuppliEndFind As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents txtSuppliCodeEnd As System.Windows.Forms.TextBox
    Friend WithEvents lblSuppliEnd As System.Windows.Forms.Label
    Friend WithEvents btnSuppliStartFind As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents txtSuppliCodeStart As System.Windows.Forms.TextBox
    Friend WithEvents lblSuppliStart As System.Windows.Forms.Label
    Friend WithEvents chkIncludeChildSupplierGroup As System.Windows.Forms.CheckBox
    Friend WithEvents btnSpgCodeStart As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents txtSpgCodeStart As System.Windows.Forms.TextBox
    Friend WithEvents lblSpgStart As System.Windows.Forms.Label
    Friend WithEvents txtSupplierGroupName As System.Windows.Forms.TextBox
    Friend WithEvents lblSCCode As System.Windows.Forms.Label
    Friend WithEvents txtSCStart As System.Windows.Forms.TextBox
    Friend WithEvents btnFindSCStart As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents btnCCCodeEnd As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents txtCCEnd As System.Windows.Forms.TextBox
    Friend WithEvents lblCCTo As System.Windows.Forms.Label
    Friend WithEvents lblSCTo As System.Windows.Forms.Label
    Friend WithEvents txtSCEnd As System.Windows.Forms.TextBox
    Friend WithEvents btnFindSCEnd As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents chkIsSum As System.Windows.Forms.CheckBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
      Me.components = New System.ComponentModel.Container()
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(RptSCMovementFilterSubPanel))
      Me.grbMaster = New Longkong.Pojjaman.Gui.Components.FixedGroupBox()
      Me.grbDetail = New Longkong.Pojjaman.Gui.Components.FixedGroupBox()
      Me.chkIsSum = New System.Windows.Forms.CheckBox()
      Me.chkIncludeChildSupplierGroup = New System.Windows.Forms.CheckBox()
      Me.btnSpgCodeStart = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.txtSpgCodeStart = New System.Windows.Forms.TextBox()
      Me.lblSpgStart = New System.Windows.Forms.Label()
      Me.txtSupplierGroupName = New System.Windows.Forms.TextBox()
      Me.btnSuppliEndFind = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.txtSuppliCodeEnd = New System.Windows.Forms.TextBox()
      Me.lblSuppliEnd = New System.Windows.Forms.Label()
      Me.btnSuppliStartFind = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.txtSuppliCodeStart = New System.Windows.Forms.TextBox()
      Me.lblSuppliStart = New System.Windows.Forms.Label()
      Me.btnCCCodeEnd = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.btnCCCodeStart = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.txtCCEnd = New System.Windows.Forms.TextBox()
      Me.txtCCStart = New System.Windows.Forms.TextBox()
      Me.lblCCStart = New System.Windows.Forms.Label()
      Me.txtDocDateEnd = New System.Windows.Forms.TextBox()
      Me.txtDocDateStart = New System.Windows.Forms.TextBox()
      Me.dtpDocDateStart = New System.Windows.Forms.DateTimePicker()
      Me.dtpDocDateEnd = New System.Windows.Forms.DateTimePicker()
      Me.lblDocDateStart = New System.Windows.Forms.Label()
      Me.lblCCTo = New System.Windows.Forms.Label()
      Me.lblSCTo = New System.Windows.Forms.Label()
      Me.lblDocDateEnd = New System.Windows.Forms.Label()
      Me.txtSCEnd = New System.Windows.Forms.TextBox()
      Me.btnFindSCEnd = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.txtSCStart = New System.Windows.Forms.TextBox()
      Me.btnFindSCStart = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.lblSCCode = New System.Windows.Forms.Label()
      Me.btnSearch = New System.Windows.Forms.Button()
      Me.btnReset = New System.Windows.Forms.Button()
      Me.txtTemp = New System.Windows.Forms.TextBox()
      Me.Validator = New Longkong.Pojjaman.Gui.Components.PJMTextboxValidator()
      Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider()
      Me.grbMaster.SuspendLayout()
      Me.grbDetail.SuspendLayout()
      Me.SuspendLayout()
      '
      'grbMaster
      '
      Me.grbMaster.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                  Or System.Windows.Forms.AnchorStyles.Left) _
                  Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.grbMaster.Controls.Add(Me.grbDetail)
      Me.grbMaster.Controls.Add(Me.btnSearch)
      Me.grbMaster.Controls.Add(Me.btnReset)
      Me.grbMaster.Controls.Add(Me.txtTemp)
      Me.grbMaster.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.grbMaster.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.grbMaster.Location = New System.Drawing.Point(8, 0)
      Me.grbMaster.Name = "grbMaster"
      Me.grbMaster.Size = New System.Drawing.Size(461, 242)
      Me.grbMaster.TabIndex = 0
      Me.grbMaster.TabStop = False
      Me.grbMaster.Text = "ใบสั่งจ้าง"
      '
      'grbDetail
      '
      Me.grbDetail.Controls.Add(Me.chkIsSum)
      Me.grbDetail.Controls.Add(Me.chkIncludeChildSupplierGroup)
      Me.grbDetail.Controls.Add(Me.btnSpgCodeStart)
      Me.grbDetail.Controls.Add(Me.txtSpgCodeStart)
      Me.grbDetail.Controls.Add(Me.lblSpgStart)
      Me.grbDetail.Controls.Add(Me.txtSupplierGroupName)
      Me.grbDetail.Controls.Add(Me.btnSuppliEndFind)
      Me.grbDetail.Controls.Add(Me.txtSuppliCodeEnd)
      Me.grbDetail.Controls.Add(Me.lblSuppliEnd)
      Me.grbDetail.Controls.Add(Me.btnSuppliStartFind)
      Me.grbDetail.Controls.Add(Me.txtSuppliCodeStart)
      Me.grbDetail.Controls.Add(Me.lblSuppliStart)
      Me.grbDetail.Controls.Add(Me.btnCCCodeEnd)
      Me.grbDetail.Controls.Add(Me.btnCCCodeStart)
      Me.grbDetail.Controls.Add(Me.txtCCEnd)
      Me.grbDetail.Controls.Add(Me.txtCCStart)
      Me.grbDetail.Controls.Add(Me.lblCCStart)
      Me.grbDetail.Controls.Add(Me.txtDocDateEnd)
      Me.grbDetail.Controls.Add(Me.txtDocDateStart)
      Me.grbDetail.Controls.Add(Me.dtpDocDateStart)
      Me.grbDetail.Controls.Add(Me.dtpDocDateEnd)
      Me.grbDetail.Controls.Add(Me.lblDocDateStart)
      Me.grbDetail.Controls.Add(Me.lblCCTo)
      Me.grbDetail.Controls.Add(Me.lblSCTo)
      Me.grbDetail.Controls.Add(Me.lblDocDateEnd)
      Me.grbDetail.Controls.Add(Me.txtSCEnd)
      Me.grbDetail.Controls.Add(Me.btnFindSCEnd)
      Me.grbDetail.Controls.Add(Me.txtSCStart)
      Me.grbDetail.Controls.Add(Me.btnFindSCStart)
      Me.grbDetail.Controls.Add(Me.lblSCCode)
      Me.grbDetail.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.grbDetail.Location = New System.Drawing.Point(8, 16)
      Me.grbDetail.Name = "grbDetail"
      Me.grbDetail.Size = New System.Drawing.Size(442, 191)
      Me.grbDetail.TabIndex = 1
      Me.grbDetail.TabStop = False
      Me.grbDetail.Text = "ข้อมูลทั่วไป"
      '
      'chkIsSum
      '
      Me.chkIsSum.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.chkIsSum.Location = New System.Drawing.Point(120, 165)
      Me.chkIsSum.Name = "chkIsSum"
      Me.chkIsSum.Size = New System.Drawing.Size(281, 24)
      Me.chkIsSum.TabIndex = 39
      Me.chkIsSum.Text = "แสดงยอดรวมท้าย SC"
      '
      'chkIncludeChildSupplierGroup
      '
      Me.chkIncludeChildSupplierGroup.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.chkIncludeChildSupplierGroup.Location = New System.Drawing.Point(120, 113)
      Me.chkIncludeChildSupplierGroup.Name = "chkIncludeChildSupplierGroup"
      Me.chkIncludeChildSupplierGroup.Size = New System.Drawing.Size(128, 24)
      Me.chkIncludeChildSupplierGroup.TabIndex = 7
      Me.chkIncludeChildSupplierGroup.Text = "รวมกลุ่มผู้รับเหมาลูก"
      '
      'btnSpgCodeStart
      '
      Me.btnSpgCodeStart.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnSpgCodeStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.btnSpgCodeStart.ForeColor = System.Drawing.SystemColors.Control
      Me.btnSpgCodeStart.Location = New System.Drawing.Point(217, 91)
      Me.btnSpgCodeStart.Name = "btnSpgCodeStart"
      Me.btnSpgCodeStart.Size = New System.Drawing.Size(24, 22)
      Me.btnSpgCodeStart.TabIndex = 19
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
      Me.txtSpgCodeStart.Location = New System.Drawing.Point(121, 91)
      Me.txtSpgCodeStart.MaxLength = 50
      Me.Validator.SetMinValue(Me.txtSpgCodeStart, "")
      Me.txtSpgCodeStart.Name = "txtSpgCodeStart"
      Me.Validator.SetRegularExpression(Me.txtSpgCodeStart, "")
      Me.Validator.SetRequired(Me.txtSpgCodeStart, False)
      Me.txtSpgCodeStart.Size = New System.Drawing.Size(96, 21)
      Me.txtSpgCodeStart.TabIndex = 3
      '
      'lblSpgStart
      '
      Me.lblSpgStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblSpgStart.ForeColor = System.Drawing.Color.Black
      Me.lblSpgStart.Location = New System.Drawing.Point(25, 91)
      Me.lblSpgStart.Name = "lblSpgStart"
      Me.lblSpgStart.Size = New System.Drawing.Size(88, 18)
      Me.lblSpgStart.TabIndex = 35
      Me.lblSpgStart.Text = "กลุ่มผู้รับเหมา"
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
      Me.txtSupplierGroupName.Location = New System.Drawing.Point(241, 91)
      Me.txtSupplierGroupName.MaxLength = 50
      Me.Validator.SetMinValue(Me.txtSupplierGroupName, "")
      Me.txtSupplierGroupName.Name = "txtSupplierGroupName"
      Me.txtSupplierGroupName.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtSupplierGroupName, "")
      Me.Validator.SetRequired(Me.txtSupplierGroupName, False)
      Me.txtSupplierGroupName.Size = New System.Drawing.Size(160, 21)
      Me.txtSupplierGroupName.TabIndex = 36
      '
      'btnSuppliEndFind
      '
      Me.btnSuppliEndFind.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnSuppliEndFind.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.btnSuppliEndFind.ForeColor = System.Drawing.SystemColors.Control
      Me.btnSuppliEndFind.Location = New System.Drawing.Point(376, 137)
      Me.btnSuppliEndFind.Name = "btnSuppliEndFind"
      Me.btnSuppliEndFind.Size = New System.Drawing.Size(24, 22)
      Me.btnSuppliEndFind.TabIndex = 21
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
      Me.txtSuppliCodeEnd.Location = New System.Drawing.Point(280, 137)
      Me.Validator.SetMinValue(Me.txtSuppliCodeEnd, "")
      Me.txtSuppliCodeEnd.Name = "txtSuppliCodeEnd"
      Me.Validator.SetRegularExpression(Me.txtSuppliCodeEnd, "")
      Me.Validator.SetRequired(Me.txtSuppliCodeEnd, False)
      Me.txtSuppliCodeEnd.Size = New System.Drawing.Size(96, 21)
      Me.txtSuppliCodeEnd.TabIndex = 5
      '
      'lblSuppliEnd
      '
      Me.lblSuppliEnd.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblSuppliEnd.ForeColor = System.Drawing.Color.Black
      Me.lblSuppliEnd.Location = New System.Drawing.Point(248, 137)
      Me.lblSuppliEnd.Name = "lblSuppliEnd"
      Me.lblSuppliEnd.Size = New System.Drawing.Size(24, 18)
      Me.lblSuppliEnd.TabIndex = 22
      Me.lblSuppliEnd.Text = "ถึง"
      Me.lblSuppliEnd.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
      '
      'btnSuppliStartFind
      '
      Me.btnSuppliStartFind.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnSuppliStartFind.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.btnSuppliStartFind.ForeColor = System.Drawing.SystemColors.Control
      Me.btnSuppliStartFind.Location = New System.Drawing.Point(216, 137)
      Me.btnSuppliStartFind.Name = "btnSuppliStartFind"
      Me.btnSuppliStartFind.Size = New System.Drawing.Size(24, 22)
      Me.btnSuppliStartFind.TabIndex = 9
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
      Me.txtSuppliCodeStart.Location = New System.Drawing.Point(120, 137)
      Me.Validator.SetMinValue(Me.txtSuppliCodeStart, "")
      Me.txtSuppliCodeStart.Name = "txtSuppliCodeStart"
      Me.Validator.SetRegularExpression(Me.txtSuppliCodeStart, "")
      Me.Validator.SetRequired(Me.txtSuppliCodeStart, False)
      Me.txtSuppliCodeStart.Size = New System.Drawing.Size(96, 21)
      Me.txtSuppliCodeStart.TabIndex = 4
      '
      'lblSuppliStart
      '
      Me.lblSuppliStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblSuppliStart.ForeColor = System.Drawing.Color.Black
      Me.lblSuppliStart.Location = New System.Drawing.Point(30, 137)
      Me.lblSuppliStart.Name = "lblSuppliStart"
      Me.lblSuppliStart.Size = New System.Drawing.Size(82, 18)
      Me.lblSuppliStart.TabIndex = 19
      Me.lblSuppliStart.Text = "ผู้รับเหมา"
      Me.lblSuppliStart.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'btnCCCodeEnd
      '
      Me.btnCCCodeEnd.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnCCCodeEnd.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.btnCCCodeEnd.ForeColor = System.Drawing.SystemColors.Control
      Me.btnCCCodeEnd.Location = New System.Drawing.Point(376, 66)
      Me.btnCCCodeEnd.Name = "btnCCCodeEnd"
      Me.btnCCCodeEnd.Size = New System.Drawing.Size(24, 22)
      Me.btnCCCodeEnd.TabIndex = 22
      Me.btnCCCodeEnd.TabStop = False
      Me.btnCCCodeEnd.ThemedImage = CType(resources.GetObject("btnCCCodeEnd.ThemedImage"), System.Drawing.Bitmap)
      '
      'btnCCCodeStart
      '
      Me.btnCCCodeStart.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnCCCodeStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.btnCCCodeStart.ForeColor = System.Drawing.SystemColors.Control
      Me.btnCCCodeStart.Location = New System.Drawing.Point(217, 66)
      Me.btnCCCodeStart.Name = "btnCCCodeStart"
      Me.btnCCCodeStart.Size = New System.Drawing.Size(24, 22)
      Me.btnCCCodeStart.TabIndex = 22
      Me.btnCCCodeStart.TabStop = False
      Me.btnCCCodeStart.ThemedImage = CType(resources.GetObject("btnCCCodeStart.ThemedImage"), System.Drawing.Bitmap)
      '
      'txtCCEnd
      '
      Me.Validator.SetDataType(Me.txtCCEnd, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtCCEnd, "")
      Me.txtCCEnd.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtCCEnd, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtCCEnd, System.Drawing.Color.Empty)
      Me.txtCCEnd.Location = New System.Drawing.Point(280, 66)
      Me.txtCCEnd.MaxLength = 50
      Me.Validator.SetMinValue(Me.txtCCEnd, "")
      Me.txtCCEnd.Name = "txtCCEnd"
      Me.Validator.SetRegularExpression(Me.txtCCEnd, "")
      Me.Validator.SetRequired(Me.txtCCEnd, False)
      Me.txtCCEnd.Size = New System.Drawing.Size(96, 21)
      Me.txtCCEnd.TabIndex = 7
      '
      'txtCCStart
      '
      Me.Validator.SetDataType(Me.txtCCStart, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtCCStart, "")
      Me.txtCCStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtCCStart, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtCCStart, -15)
      Me.Validator.SetInvalidBackColor(Me.txtCCStart, System.Drawing.Color.Empty)
      Me.txtCCStart.Location = New System.Drawing.Point(121, 66)
      Me.txtCCStart.MaxLength = 50
      Me.Validator.SetMinValue(Me.txtCCStart, "")
      Me.txtCCStart.Name = "txtCCStart"
      Me.Validator.SetRegularExpression(Me.txtCCStart, "")
      Me.Validator.SetRequired(Me.txtCCStart, False)
      Me.txtCCStart.Size = New System.Drawing.Size(96, 21)
      Me.txtCCStart.TabIndex = 7
      '
      'lblCCStart
      '
      Me.lblCCStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblCCStart.ForeColor = System.Drawing.Color.Black
      Me.lblCCStart.Location = New System.Drawing.Point(9, 66)
      Me.lblCCStart.Name = "lblCCStart"
      Me.lblCCStart.Size = New System.Drawing.Size(104, 18)
      Me.lblCCStart.TabIndex = 14
      Me.lblCCStart.Text = "Cost Center"
      Me.lblCCStart.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'txtDocDateEnd
      '
      Me.Validator.SetDataType(Me.txtDocDateEnd, Longkong.Pojjaman.Gui.Components.DataTypeConstants.DateTimeType)
      Me.Validator.SetDisplayName(Me.txtDocDateEnd, "")
      Me.Validator.SetGotFocusBackColor(Me.txtDocDateEnd, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtDocDateEnd, -15)
      Me.Validator.SetInvalidBackColor(Me.txtDocDateEnd, System.Drawing.Color.Empty)
      Me.txtDocDateEnd.Location = New System.Drawing.Point(280, 16)
      Me.txtDocDateEnd.MaxLength = 10
      Me.Validator.SetMinValue(Me.txtDocDateEnd, "")
      Me.txtDocDateEnd.Name = "txtDocDateEnd"
      Me.Validator.SetRegularExpression(Me.txtDocDateEnd, "")
      Me.Validator.SetRequired(Me.txtDocDateEnd, False)
      Me.txtDocDateEnd.Size = New System.Drawing.Size(99, 21)
      Me.txtDocDateEnd.TabIndex = 2
      '
      'txtDocDateStart
      '
      Me.Validator.SetDataType(Me.txtDocDateStart, Longkong.Pojjaman.Gui.Components.DataTypeConstants.DateTimeType)
      Me.Validator.SetDisplayName(Me.txtDocDateStart, "")
      Me.Validator.SetGotFocusBackColor(Me.txtDocDateStart, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtDocDateStart, -15)
      Me.Validator.SetInvalidBackColor(Me.txtDocDateStart, System.Drawing.Color.Empty)
      Me.txtDocDateStart.Location = New System.Drawing.Point(120, 16)
      Me.txtDocDateStart.MaxLength = 10
      Me.Validator.SetMinValue(Me.txtDocDateStart, "")
      Me.txtDocDateStart.Name = "txtDocDateStart"
      Me.Validator.SetRegularExpression(Me.txtDocDateStart, "")
      Me.Validator.SetRequired(Me.txtDocDateStart, False)
      Me.txtDocDateStart.Size = New System.Drawing.Size(99, 21)
      Me.txtDocDateStart.TabIndex = 1
      '
      'dtpDocDateStart
      '
      Me.dtpDocDateStart.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
      Me.dtpDocDateStart.Location = New System.Drawing.Point(120, 16)
      Me.dtpDocDateStart.Name = "dtpDocDateStart"
      Me.dtpDocDateStart.Size = New System.Drawing.Size(120, 21)
      Me.dtpDocDateStart.TabIndex = 2
      Me.dtpDocDateStart.TabStop = False
      '
      'dtpDocDateEnd
      '
      Me.dtpDocDateEnd.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
      Me.dtpDocDateEnd.Location = New System.Drawing.Point(280, 16)
      Me.dtpDocDateEnd.Name = "dtpDocDateEnd"
      Me.dtpDocDateEnd.Size = New System.Drawing.Size(120, 21)
      Me.dtpDocDateEnd.TabIndex = 5
      Me.dtpDocDateEnd.TabStop = False
      '
      'lblDocDateStart
      '
      Me.lblDocDateStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblDocDateStart.ForeColor = System.Drawing.Color.Black
      Me.lblDocDateStart.Location = New System.Drawing.Point(16, 16)
      Me.lblDocDateStart.Name = "lblDocDateStart"
      Me.lblDocDateStart.Size = New System.Drawing.Size(96, 18)
      Me.lblDocDateStart.TabIndex = 0
      Me.lblDocDateStart.Text = "ตั้งแต่วันที่"
      Me.lblDocDateStart.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblCCTo
      '
      Me.lblCCTo.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblCCTo.ForeColor = System.Drawing.Color.Black
      Me.lblCCTo.Location = New System.Drawing.Point(248, 68)
      Me.lblCCTo.Name = "lblCCTo"
      Me.lblCCTo.Size = New System.Drawing.Size(24, 18)
      Me.lblCCTo.TabIndex = 3
      Me.lblCCTo.Text = "ถึง"
      Me.lblCCTo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
      '
      'lblSCTo
      '
      Me.lblSCTo.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblSCTo.ForeColor = System.Drawing.Color.Black
      Me.lblSCTo.Location = New System.Drawing.Point(248, 44)
      Me.lblSCTo.Name = "lblSCTo"
      Me.lblSCTo.Size = New System.Drawing.Size(24, 18)
      Me.lblSCTo.TabIndex = 3
      Me.lblSCTo.Text = "ถึง"
      Me.lblSCTo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
      '
      'lblDocDateEnd
      '
      Me.lblDocDateEnd.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblDocDateEnd.ForeColor = System.Drawing.Color.Black
      Me.lblDocDateEnd.Location = New System.Drawing.Point(248, 16)
      Me.lblDocDateEnd.Name = "lblDocDateEnd"
      Me.lblDocDateEnd.Size = New System.Drawing.Size(24, 18)
      Me.lblDocDateEnd.TabIndex = 3
      Me.lblDocDateEnd.Text = "ถึง"
      Me.lblDocDateEnd.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
      '
      'txtSCEnd
      '
      Me.Validator.SetDataType(Me.txtSCEnd, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtSCEnd, "")
      Me.txtSCEnd.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtSCEnd, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtSCEnd, System.Drawing.Color.Empty)
      Me.txtSCEnd.Location = New System.Drawing.Point(280, 41)
      Me.txtSCEnd.MaxLength = 50
      Me.Validator.SetMinValue(Me.txtSCEnd, "")
      Me.txtSCEnd.Name = "txtSCEnd"
      Me.Validator.SetRegularExpression(Me.txtSCEnd, "")
      Me.Validator.SetRequired(Me.txtSCEnd, False)
      Me.txtSCEnd.Size = New System.Drawing.Size(96, 21)
      Me.txtSCEnd.TabIndex = 8
      '
      'btnFindSCEnd
      '
      Me.btnFindSCEnd.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnFindSCEnd.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.btnFindSCEnd.ForeColor = System.Drawing.SystemColors.Control
      Me.btnFindSCEnd.Location = New System.Drawing.Point(376, 41)
      Me.btnFindSCEnd.Name = "btnFindSCEnd"
      Me.btnFindSCEnd.Size = New System.Drawing.Size(24, 22)
      Me.btnFindSCEnd.TabIndex = 19
      Me.btnFindSCEnd.TabStop = False
      Me.btnFindSCEnd.ThemedImage = CType(resources.GetObject("btnFindSCEnd.ThemedImage"), System.Drawing.Bitmap)
      '
      'txtSCStart
      '
      Me.Validator.SetDataType(Me.txtSCStart, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtSCStart, "")
      Me.txtSCStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtSCStart, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtSCStart, -15)
      Me.Validator.SetInvalidBackColor(Me.txtSCStart, System.Drawing.Color.Empty)
      Me.txtSCStart.Location = New System.Drawing.Point(120, 41)
      Me.txtSCStart.MaxLength = 50
      Me.Validator.SetMinValue(Me.txtSCStart, "")
      Me.txtSCStart.Name = "txtSCStart"
      Me.Validator.SetRegularExpression(Me.txtSCStart, "")
      Me.Validator.SetRequired(Me.txtSCStart, False)
      Me.txtSCStart.Size = New System.Drawing.Size(96, 21)
      Me.txtSCStart.TabIndex = 8
      '
      'btnFindSCStart
      '
      Me.btnFindSCStart.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnFindSCStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.btnFindSCStart.ForeColor = System.Drawing.SystemColors.Control
      Me.btnFindSCStart.Location = New System.Drawing.Point(216, 41)
      Me.btnFindSCStart.Name = "btnFindSCStart"
      Me.btnFindSCStart.Size = New System.Drawing.Size(24, 22)
      Me.btnFindSCStart.TabIndex = 19
      Me.btnFindSCStart.TabStop = False
      Me.btnFindSCStart.ThemedImage = CType(resources.GetObject("btnFindSCStart.ThemedImage"), System.Drawing.Bitmap)
      '
      'lblSCCode
      '
      Me.lblSCCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblSCCode.ForeColor = System.Drawing.Color.Black
      Me.lblSCCode.Location = New System.Drawing.Point(32, 41)
      Me.lblSCCode.Name = "lblSCCode"
      Me.lblSCCode.Size = New System.Drawing.Size(80, 18)
      Me.lblSCCode.TabIndex = 35
      Me.lblSCCode.Text = "เลขที่ใบสั่งจ้าง"
      Me.lblSCCode.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'btnSearch
      '
      Me.btnSearch.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnSearch.Location = New System.Drawing.Point(369, 211)
      Me.btnSearch.Name = "btnSearch"
      Me.btnSearch.Size = New System.Drawing.Size(75, 23)
      Me.btnSearch.TabIndex = 3
      Me.btnSearch.Text = "ค้นหา"
      '
      'btnReset
      '
      Me.btnReset.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnReset.ForeColor = System.Drawing.SystemColors.ControlText
      Me.btnReset.Location = New System.Drawing.Point(289, 211)
      Me.btnReset.Name = "btnReset"
      Me.btnReset.Size = New System.Drawing.Size(75, 23)
      Me.btnReset.TabIndex = 2
      Me.btnReset.TabStop = False
      Me.btnReset.Text = "เคลียร์"
      '
      'txtTemp
      '
      Me.Validator.SetDataType(Me.txtTemp, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtTemp, "")
      Me.Validator.SetGotFocusBackColor(Me.txtTemp, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtTemp, System.Drawing.Color.Empty)
      Me.txtTemp.Location = New System.Drawing.Point(808, 32)
      Me.txtTemp.MaxLength = 255
      Me.Validator.SetMinValue(Me.txtTemp, "")
      Me.txtTemp.Name = "txtTemp"
      Me.txtTemp.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtTemp, "")
      Me.Validator.SetRequired(Me.txtTemp, False)
      Me.txtTemp.Size = New System.Drawing.Size(104, 21)
      Me.txtTemp.TabIndex = 3
      Me.txtTemp.Visible = False
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
      'RptSCMovementFilterSubPanel
      '
      Me.Controls.Add(Me.grbMaster)
      Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Name = "RptSCMovementFilterSubPanel"
      Me.Size = New System.Drawing.Size(485, 252)
      Me.grbMaster.ResumeLayout(False)
      Me.grbMaster.PerformLayout()
      Me.grbDetail.ResumeLayout(False)
      Me.grbDetail.PerformLayout()
      Me.ResumeLayout(False)

    End Sub

#End Region

#Region " SetLabelText "
    Public Sub SetLabelText()
      'If Not m_entity Is Nothing Then Me.Text = Me.StringParserService.Parse(Me.m_entity.TabPageText)
      Me.grbMaster.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptSCMovementFilterSubPanel.grbMaster}")
      Me.grbDetail.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptSCMovementFilterSubPanel.grbDetail}")
      Me.lblDocDateStart.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptSCMovementFilterSubPanel.lblDocDateStart}")
      Me.lblDocDateEnd.Text = Me.StringParserService.Parse("${res:Global.FilterPanelTo}")
      Me.lblSCCode.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptSCMovementFilterSubPanel.lblSCCode}")
      Me.lblSCTo.Text = Me.StringParserService.Parse("${res:Global.FilterPanelTo}")
      Me.lblCCStart.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptSCMovementFilterSubPanel.lblCCStart}")
      Me.lblCCTo.Text = Me.StringParserService.Parse("${res:Global.FilterPanelTo}")
      Me.lblSpgStart.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptSCMovementFilterSubPanel.lblSpgStart}")
      Me.chkIncludeChildSupplierGroup.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptSCMovementFilterSubPanel.chkIncludeChildSupplierGroup}")
      Me.lblSuppliStart.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptSCMovementFilterSubPanel.lblSuppliStart}")
      Me.lblSuppliEnd.Text = Me.StringParserService.Parse("${res:Global.FilterPanelTo}")
      Me.chkIsSum.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptSCMovementFilterSubPanel.chkIsSum}")

      'Me.Validator.SetDisplayName(txtCCCodeStart, lblCCStart.Text)

      'Me.lblSuppliStart.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptSCMovementFilterSubPanel.lblSuppliStart}")
      'Me.Validator.SetDisplayName(txtSuppliCodeStart, lblSuppliStart.Text)

      'Me.lblDocDateStart.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptSCMovementFilterSubPanel.lblDocDateStart}")
      'Me.Validator.SetDisplayName(txtDocDateStart, lblDocDateStart.Text)

      'Me.lblDocDateEnd.Text = Me.StringParserService.Parse("${res:Global.FilterPanelTo}")
      'Me.Validator.SetDisplayName(txtDocDateEnd, lblDocDateEnd.Text)

      'Me.lblEmployee.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptSCMovementFilterSubPanel.lblEmployee}")

      ' Button
      Me.btnSearch.Text = Me.StringParserService.Parse("${res:Global.SearchButtonText}")
      Me.btnReset.Text = Me.StringParserService.Parse("${res:Global.ResetButtonText}")

      '' GroupBox
      'Me.grbMaster.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptSCMovementFilterSubPanel.grbMaster}")
      'Me.grbDetail.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptSCMovementFilterSubPanel.grbDetail}")

      'Me.lblDocStatus.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptSCMovementFilterSubPanel.lblDocStatus}")

      'Me.lblSpgStart.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptSCMovementFilterSubPanel.lblSpgStart}")
      'Me.chkIncludeChildSupplierGroup.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptSCMovementFilterSubPanel.chkIncludeChildSupplierGroup}")

      'Me.cmbDocStatus.Items.Add(Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptSCMovementFilterSubPanel.cbAll}"))
      'Me.cmbDocStatus.Items.Add(Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptSCMovementFilterSubPanel.cbCancel}"))
      'Me.cmbDocStatus.Items.Add(Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptSCMovementFilterSubPanel.cbSave}")) 'บันทึกแล้ว
      'Me.cmbDocStatus.Items.Add(Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptSCMovementFilterSubPanel.cbClose}")) 'ปิดแล้ว
      'Me.cmbDocStatus.SelectedIndex = 0

      'สถานะรูปแบบการแสดงผล
      'Me.lblDocStatus.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptSCMovementFilterSubPanel.lblDocStatus}")
      'Me.cmbStatus.Items.Add(Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptSCMovementFilterSubPanel.cmbDocAll}")) 'เอกสารสั่งซื้อทั้งหมด
      'Me.cmbStatus.Items.Add(Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptSCMovementFilterSubPanel.cmbDocApprove}")) 'เอกสารสั่งซื้อที่อนุมัติแล้ว
      'Me.cmbStatus.Items.Add(Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptSCMovementFilterSubPanel.cmbDocNoApprove}")) 'เอกสารสั่งซื้อที่ยังไม่อนุมัติ
      'Me.cmbStatus.SelectedIndex = 0
    End Sub
#End Region

#Region "Member"
    Private m_DocDateEnd As Date
    Private m_DocDateStart As Date
    Private m_scStart As SC
    Private m_scEnd As SC
    Private m_ccStart As CostCenter
    Private m_ccEnd As CostCenter
    Private m_subcontractorgroup As SupplierGroup
    Private m_isIncludeChildSubGroup As Boolean = False
    Private m_subcontractorStart As Supplier
    Private m_subcontractorEnd As Supplier
    Private m_status As Integer
    Private m_isPreviewSummary As Boolean = False

#End Region

#Region "Constructors"
    Public Sub New()
      MyBase.New()
      InitializeComponent()
      EventWiring()
      Initialize()

      SetLabelText()
      LoopControl(Me)
    End Sub
#End Region

#Region "Properties"
    Public Property DocDateEnd() As Date      Get        Return m_DocDateEnd      End Get      Set(ByVal Value As Date)        m_DocDateEnd = Value      End Set    End Property    Public Property DocDateStart() As Date      Get        Return m_DocDateStart      End Get      Set(ByVal Value As Date)        m_DocDateStart = Value      End Set    End Property
    Private Property SCStart As SC
      Get
        Return m_scStart
      End Get
      Set(ByVal value As SC)
        m_scStart = value
      End Set
    End Property
    Private Property SCEnd As SC
      Get
        Return m_scEnd
      End Get
      Set(ByVal value As SC)
        m_scEnd = value
      End Set
    End Property
    Public Property CostcenterStart() As CostCenter
      Get
        Return m_ccStart
      End Get
      Set(ByVal Value As CostCenter)
        m_ccStart = Value
      End Set
    End Property
    Public Property CostcenterEnd() As CostCenter
      Get
        Return m_ccEnd
      End Get
      Set(ByVal Value As CostCenter)
        m_ccEnd = Value
      End Set
    End Property
    Public Property SubcontractorGroup() As SupplierGroup
      Get
        Return m_subcontractorgroup
      End Get
      Set(ByVal Value As SupplierGroup)
        m_subcontractorgroup = Value
      End Set
    End Property
    Public Property IsIncludeChildSupplierGroup As Boolean
      Get
        Return m_isIncludeChildSubGroup
      End Get
      Set(ByVal value As Boolean)
        m_isIncludeChildSubGroup = value
      End Set
    End Property
    Public Property SubContractorStart As Supplier
      Get
        Return m_subcontractorStart
      End Get
      Set(ByVal value As Supplier)
        m_subcontractorStart = value
      End Set
    End Property
    Public Property SubContractorEnd As Supplier
      Get
        Return m_subcontractorEnd
      End Get
      Set(ByVal value As Supplier)
        m_subcontractorEnd = value
      End Set
    End Property
    Public Property Status As Integer      Get        Return m_status
      End Get
      Set(ByVal value As Integer)
        m_status = value
      End Set
    End Property    Public Property IsPreveiewSummary As Boolean      Set(ByVal value As Boolean)
        m_isPreviewSummary = value
      End Set
      Get
        Return m_isPreviewSummary
      End Get
    End Property#End Region

#Region "Methods"
    'Private Sub RegisterDropdown()
    'CodeDescription.ListCodeDescriptionInComboBox(Me.cmbDocStatus, "sc_status", True)
    'cmbDocStatus.SelectedIndex = 0
    'End Sub
    Private Sub Initialize()
      'RegisterDropdown()
      ClearCriterias()
    End Sub

    Private Sub ClearCriterias()
      For Each grbCtrl As Control In grbMaster.Controls
        If TypeOf grbCtrl Is Longkong.Pojjaman.Gui.Components.FixedGroupBox Then
          For Each Ctrl As Control In grbCtrl.Controls
            If TypeOf Ctrl Is TextBox Then
              Ctrl.Text = ""
            ElseIf TypeOf Ctrl Is CheckBox Then
              CType(Ctrl, CheckBox).Checked = False
            ElseIf TypeOf Ctrl Is ComboBox Then
              CType(Ctrl, ComboBox).SelectedIndex = -1
            End If
          Next
        End If
      Next

      Dim dtStart As Date = Date.Now.Subtract(New TimeSpan(7, 0, 0, 0))

      Me.DocDateStart = dtStart
      Me.txtDocDateStart.Text = MinDateToNull(Me.DocDateStart, "")
      Me.dtpDocDateStart.Value = Me.DocDateStart

      Me.DocDateEnd = Date.Now
      Me.txtDocDateEnd.Text = MinDateToNull(Me.DocDateEnd, "")
      Me.dtpDocDateEnd.Value = Me.DocDateEnd

      Me.SCStart = New SC
      Me.SCEnd = New SC

      Me.CostcenterStart = New CostCenter
      Me.CostcenterEnd = New CostCenter

      Me.SubcontractorGroup = New SupplierGroup

      'Me.chkIncludeChildSupplierGroup.Checked = False

      Me.IsIncludeChildSupplierGroup = False

      Me.SubContractorStart = New Supplier
      Me.SubContractorEnd = New Supplier

      Me.Status = False

      Me.IsPreveiewSummary = False

      'If cmbDocStatus.Items.Count > 0 Then
      'cmbDocStatus.SelectedIndex = 0
      'End If
    End Sub
    Public Overrides Function GetFilterString() As String

    End Function
    Public Overrides Function GetFilterArray() As Filter()
      Dim arr(11) As Filter
      arr(0) = New Filter("DocDateStart", Me.ValidDateOrDBNull(Me.DocDateStart))
      arr(1) = New Filter("DocDateEnd", Me.ValidDateOrDBNull(Me.DocDateEnd))

      arr(2) = New Filter("SCCodeStart", Me.ValidCodeOrDBNull(Me.SCStart))
      arr(3) = New Filter("SCCodeEnd", Me.ValidCodeOrDBNull(Me.SCEnd))

      arr(4) = New Filter("CostcenterStart", Me.ValidCodeOrDBNull(Me.CostcenterStart))
      arr(5) = New Filter("CostcenterEnd", Me.ValidCodeOrDBNull(Me.CostcenterEnd))

      arr(6) = New Filter("SubcontractorGroup", Me.ValidCodeOrDBNull(Me.SubcontractorGroup))

      arr(7) = New Filter("IsIncludeChildSupplierGroup", Cbit(IsIncludeChildSupplierGroup))

      arr(8) = New Filter("SubContractorStart", Me.ValidCodeOrDBNull(Me.SubContractorStart))
      arr(9) = New Filter("SubContractorEnd", Me.ValidCodeOrDBNull(Me.SubContractorEnd))

      arr(10) = New Filter("IsPreveiewSummary", Cbit(IsPreveiewSummary))

      arr(11) = New Filter("userRight", CType(ServiceManager.Services.GetService(GetType(SecurityService)), SecurityService).CurrentUser.Id)

      Return arr
    End Function
    Private Function Cbit(ByVal obj As Boolean) As Integer
      If obj Then
        Return 1
      End If
      Return 0
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

#Region "IReportFilterSubPanel"
    Public Function GetFixValueCollection() As BusinessLogic.DocPrintingItemCollection Implements IReportFilterSubPanel.GetFixValueCollection
      Dim dpiColl As New DocPrintingItemCollection
      Dim dpi As DocPrintingItem

      'Month
      dpi = New DocPrintingItem
      dpi.Mapping = "Month"
      dpi.Value = "" 'Me.cmbMonth.Text
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      'Year
      dpi = New DocPrintingItem
      dpi.Mapping = "Year"
      dpi.Value = "" 'Me.cmbYear.Text
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

      'SupplierStart Group
      dpi = New DocPrintingItem
      dpi.Mapping = "SupplierStartGroup"
      dpi.Value = Me.txtSpgCodeStart.Text
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      'Include ChildSupplierGroup
      If Me.chkIncludeChildSupplierGroup.Checked Then
        dpi = New DocPrintingItem
        dpi.Mapping = "IncludeChildSupplierGroup"
        dpi.Value = "(รวมในสังกัดกลุ่มผู้ขาย)"
        dpi.DataType = "System.String"
        dpiColl.Add(dpi)
      End If

      'SupplierStart
      dpi = New DocPrintingItem
      dpi.Mapping = "SupplierStart"
      dpi.Value = Me.txtSuppliCodeStart.Text
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      'SupplierEnd
      dpi = New DocPrintingItem
      dpi.Mapping = "SupplierEnd"
      dpi.Value = Me.txtSuppliCodeEnd.Text
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)


      ''DocStatus
      'dpi = New DocPrintingItem
      'dpi.Mapping = "DocStatus"
      'dpi.Value = Me.cmbDocStatus.Text
      'dpi.DataType = "System.String"
      'dpiColl.Add(dpi)


      'CostCenter Start
      dpi = New DocPrintingItem
      dpi.Mapping = "CostcenterStart"
      dpi.Value = Me.txtCCStart.Text
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      ''Include CCChildren
      'If Me.chkIncludeChildren.Checked Then
      'dpi = New DocPrintingItem
      'dpi.Mapping = "IncludeCCChildren"
      'dpi.Value = "(รวมในสังกัด)"
      'dpi.DataType = "System.String"
      'dpiColl.Add(dpi)
      'End If

      'Employee
      dpi = New DocPrintingItem
      dpi.Mapping = "Employee"
      dpi.Value = Me.txtSCStart.Text
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      ''Status
      'dpi = New DocPrintingItem
      'dpi.Mapping = "Status"
      'dpi.Value = Me.cmbStatus.Text
      'dpi.DataType = "System.String"
      'dpiColl.Add(dpi)


      Return dpiColl
    End Function
#End Region

#Region " ChangeProperty "
    Private Sub EventWiring()
      AddHandler txtDocDateStart.Validated, AddressOf Me.ChangeProperty
      AddHandler txtDocDateEnd.Validated, AddressOf Me.ChangeProperty

      AddHandler dtpDocDateStart.ValueChanged, AddressOf Me.ChangeProperty
      AddHandler dtpDocDateEnd.ValueChanged, AddressOf Me.ChangeProperty

      AddHandler btnFindSCStart.Click, AddressOf Me.btnFind_Click
      AddHandler txtSCStart.Validated, AddressOf Me.ChangeProperty

      AddHandler btnFindSCEnd.Click, AddressOf Me.btnFind_Click
      AddHandler txtSCEnd.Validated, AddressOf Me.ChangeProperty

      AddHandler btnCCCodeStart.Click, AddressOf Me.btnFind_Click
      AddHandler txtCCStart.Validated, AddressOf Me.ChangeProperty

      AddHandler btnCCCodeEnd.Click, AddressOf Me.btnFind_Click
      AddHandler txtCCEnd.Validated, AddressOf Me.ChangeProperty

      AddHandler btnSpgCodeStart.Click, AddressOf Me.btnFind_Click
      AddHandler txtSpgCodeStart.Validated, AddressOf Me.ChangeProperty

      AddHandler btnSuppliStartFind.Click, AddressOf Me.btnFind_Click
      AddHandler txtSuppliCodeStart.Validated, AddressOf Me.ChangeProperty

      AddHandler btnSuppliEndFind.Click, AddressOf Me.btnFind_Click
      AddHandler txtSuppliCodeEnd.Validated, AddressOf Me.ChangeProperty

      'AddHandler cmbDocStatus.SelectedIndexChanged, AddressOf Me.ChangeProperty
      AddHandler chkIsSum.CheckedChanged, AddressOf Me.ChangeProperty
      AddHandler chkIncludeChildSupplierGroup.CheckedChanged, AddressOf Me.ChangeProperty

      'AddHandler btnCCCodeStart.Click, AddressOf Me.btnCostcenterFind_Click
      'AddHandler txtCCStart.Validated, AddressOf Me.ChangeProperty

      ''AddHandler txtSCStart.Validated, AddressOf Me.ChangeProperty
      ''AddHandler btnFindSCStart.Click, AddressOf Me.btnEmployee_Click

      'AddHandler btnSpgCodeStart.Click, AddressOf Me.btnSupplierGroupFind_Click
      'AddHandler txtSpgCodeStart.Validated, AddressOf Me.ChangeProperty
    End Sub

    Private m_dateSetting As Boolean
    Private Sub ChangeProperty(ByVal sender As Object, ByVal e As EventArgs)

      Select Case CType(sender, Control).Name.ToLower
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

        Case "txtscstart"
          SC.GetSC(txtSCStart, Me.SCStart)
        Case "txtscend"
          SC.GetSC(txtSCEnd, Me.SCEnd)
        Case "txtcccodestart"
          Dim txtName As New TextBox
          CostCenter.GetCostCenter(Me.txtCCStart, txtName, m_ccStart, CType(ServiceManager.Services.GetService(GetType(SecurityService)), SecurityService).CurrentUser.Id)
        Case "txtcccodeend"
          Dim txtName As New TextBox
          CostCenter.GetCostCenter(Me.txtCCEnd, txtName, m_ccEnd, CType(ServiceManager.Services.GetService(GetType(SecurityService)), SecurityService).CurrentUser.Id)
        Case "txtsupplicodestart"
          Dim txtName As New TextBox
          Supplier.GetSupplier(txtSuppliCodeStart, txtName, SubContractorStart)
        Case "txtsupplicodeend"
          Dim txtName As New TextBox
          Supplier.GetSupplier(txtSuppliCodeEnd, txtName, SubContractorEnd)
        Case "txtspgcodestart"
          SupplierGroup.GetSupplierGroup(txtSpgCodeStart, Me.txtSupplierGroupName, m_subcontractorgroup)
          'Case "cmbdocstatus"
          'If Not Me.cmbDocStatus.SelectedItem Is Nothing Then
          'Me.Status = CType(cmbDocStatus.SelectedItem, IdValuePair).Id
          'End If
        Case "chkissum"
          If Me.chkIsSum.Checked Then
            Me.IsPreveiewSummary = True
          Else
            Me.IsPreveiewSummary = False
          End If
        Case "chkincludechildsuppliergroup"
          If Me.chkIncludeChildSupplierGroup.Checked Then
            Me.IsIncludeChildSupplierGroup = True
          Else
            Me.IsIncludeChildSupplierGroup = False
          End If
      End Select
    End Sub
#End Region

#Region "IClipboardHandler Overrides"
    Public Overrides ReadOnly Property EnablePaste() As Boolean
      Get
        Dim data As IDataObject = Clipboard.GetDataObject
        ' Supplier
        If data.GetDataPresent((New Supplier).FullClassName) Then
          If Not Me.ActiveControl Is Nothing Then
            Select Case Me.ActiveControl.Name.ToLower
              Case "txtsupplicodestart", "txtsupplicodeend"
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
      ' Supplier
      If data.GetDataPresent((New Supplier).FullClassName) Then
        Dim id As Integer = CInt(data.GetData((New Supplier).FullClassName))
        Dim entity As New Supplier(id)
        If Not Me.ActiveControl Is Nothing Then
          Select Case Me.ActiveControl.Name.ToLower
            Case "txtsupplicodestart"
              Me.SetSupplierStartDialog(entity)

            Case "txtsupplicodeend"
              Me.SetSupplierEndDialog(entity)

          End Select
        End If
      End If
      ' Costcenter
      'If data.GetDataPresent((New Costcenter).FullClassName) Then
      'Dim id As Integer = CInt(data.GetData((New Costcenter).FullClassName))
      'Dim entity As New Costcenter(id)
      'If Not Me.ActiveControl Is Nothing Then
      'Select Case Me.ActiveControl.Name.ToLower
      'Case "txtcostcentercodestart"
      'Me.SetCCCodeStartDialog(entity)

      'Case "txtcostcentercodeend"
      'Me.SetCCCodeStartDialog(entity)

      'End Select
      'End If
      'End If
    End Sub
#End Region

#Region " Event Handlers "
    ' Supplier
    Private Sub btnFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
      Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      Select Case CType(sender, Control).Name.ToLower
        Case "btnsupplistartfind"
          myEntityPanelService.OpenListDialog(New Supplier, AddressOf SetSupplierStartDialog)

        Case "btnsuppliendfind"
          myEntityPanelService.OpenListDialog(New Supplier, AddressOf SetSupplierEndDialog)

        Case "btnfindscstart"
          myEntityPanelService.OpenListDialog(New SC, AddressOf SetSCStartDialog)

        Case "btnfindscend"
          myEntityPanelService.OpenListDialog(New SC, AddressOf SetSCEndDialog)

        Case "btncccodestart"
          myEntityPanelService.OpenListDialog(New CostCenter, AddressOf SetCCCodeStartDialog)

        Case "btncccodeend"
          myEntityPanelService.OpenListDialog(New SC, AddressOf SetCCCodeEndDialog)

        Case "btnspgcodestart"
          myEntityPanelService.OpenListDialog(New SupplierGroup, AddressOf SetSupplierGroupDialog)


      End Select
    End Sub
    Private Sub SetSupplierStartDialog(ByVal e As ISimpleEntity)
      Me.txtSuppliCodeStart.Text = e.Code
      Supplier.GetSupplier(txtSuppliCodeStart, txtTemp, Me.SubContractorStart)
    End Sub
    Private Sub SetSupplierEndDialog(ByVal e As ISimpleEntity)
      Me.txtSuppliCodeEnd.Text = e.Code
      Supplier.GetSupplier(txtSuppliCodeEnd, txtTemp, Me.SubContractorEnd)
    End Sub
    'SC
    Private Sub SetSCStartDialog(ByVal e As ISimpleEntity)
      Me.txtSCStart.Text = e.Code
      SC.GetSC(txtSCStart, Me.SCStart)
    End Sub
    Private Sub SetSCEndDialog(ByVal e As ISimpleEntity)
      Me.txtSCEnd.Text = e.Code
      SC.GetSC(txtSCEnd, Me.SCEnd)
    End Sub

    ''Employee 
    'Private Sub btnEmployee_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    'Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
    'Select Case CType(sender, Control).Name.ToLower
    'Case "btnemployee"
    'myEntityPanelService.OpenListDialog(New Employee, AddressOf SetEmployeeDialog)

    'End Select
    'End Sub
    'Private Sub SetEmployeeDialog(ByVal e As ISimpleEntity)
    'Me.txtSCStart.Text = e.Code
    'Employee.GetEmployee(txtEmployee, txtEmployeeName, Me.Director)
    'End Sub
    ' Costcenter
    'Private Sub btnCostcenterFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    'Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
    'Select Case CType(sender, Control).Name.ToLower
    'Case "btncccodestart"
    'myEntityPanelService.OpenTreeDialog(New Costcenter, AddressOf SetCCCodeStartDialog)
    'End Select
    'End Sub
    Private Sub SetCCCodeStartDialog(ByVal e As ISimpleEntity)
      Me.txtCCStart.Text = e.Code
      Dim txtName As New TextBox
      CostCenter.GetCostCenter(Me.txtCCStart, txtName, m_ccStart, CType(ServiceManager.Services.GetService(GetType(SecurityService)), SecurityService).CurrentUser.Id)
    End Sub
    Private Sub SetCCCodeEndDialog(ByVal e As ISimpleEntity)
      Me.txtCCEnd.Text = e.Code
      Dim txtName As New TextBox
      CostCenter.GetCostCenter(Me.txtCCEnd, txtName, m_ccEnd, CType(ServiceManager.Services.GetService(GetType(SecurityService)), SecurityService).CurrentUser.Id)
    End Sub
    'SupplierGroup
    'Private Sub btnSupplierGroupFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    'Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
    'Select Case CType(sender, Control).Name.ToLower
    'Case "btnspgcodestart"
    'myEntityPanelService.OpenTreeDialog(New SupplierGroup, AddressOf SetSpgCodeStartDialog)
    'End Select
    'End Sub
    Private Sub SetSupplierGroupDialog(ByVal e As ISimpleEntity)
      Me.txtSpgCodeStart.Text = e.Code
      SupplierGroup.GetSupplierGroup(txtSpgCodeStart, txtSupplierGroupName, m_subcontractorgroup, True)
    End Sub
#End Region

    End Class
End Namespace

