Option Explicit On 
Option Strict On

Imports Longkong.Pojjaman.BusinessLogic
Imports longkong.Pojjaman.Services
Imports Longkong.Core.Services

Namespace Longkong.Pojjaman.Gui.Panels
	Public Class RptPaymentDueFilterSubPanel
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
		Friend WithEvents Validator As Longkong.Pojjaman.Gui.Components.PJMTextboxValidator
		Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
		Friend WithEvents txtDocDateStart As System.Windows.Forms.TextBox
		Friend WithEvents dtpDocDateStart As System.Windows.Forms.DateTimePicker
		Friend WithEvents grbDetail As Longkong.Pojjaman.Gui.Components.FixedGroupBox
		Friend WithEvents txtSuppliCodeStart As System.Windows.Forms.TextBox
		Friend WithEvents lblSuppliStart As System.Windows.Forms.Label
		Friend WithEvents btnSuppliStartFind As Longkong.Pojjaman.Gui.Components.ImageButton
		Friend WithEvents lblSuppliEnd As System.Windows.Forms.Label
		Friend WithEvents btnSuppliEndFind As Longkong.Pojjaman.Gui.Components.ImageButton
		Friend WithEvents txtSuppliCodeEnd As System.Windows.Forms.TextBox
		Friend WithEvents txtTemp As System.Windows.Forms.TextBox
		Friend WithEvents chkIncludeChildren As System.Windows.Forms.CheckBox
		Friend WithEvents btnCCCodeStart As Longkong.Pojjaman.Gui.Components.ImageButton
		Friend WithEvents txtCCCodeStart As System.Windows.Forms.TextBox
		Friend WithEvents lblCCStart As System.Windows.Forms.Label
		Friend WithEvents txtCostCenterName As System.Windows.Forms.TextBox
		Friend WithEvents grbDisplay As Longkong.Pojjaman.Gui.Components.FixedGroupBox
		Friend WithEvents lblTerm As System.Windows.Forms.Label
		Friend WithEvents cmbShowPeriod As System.Windows.Forms.ComboBox
		Friend WithEvents txtSupplierGroupName As System.Windows.Forms.TextBox
		Friend WithEvents lblSupplierGroup As System.Windows.Forms.Label
		Friend WithEvents txtSupplierGroupStart As System.Windows.Forms.TextBox
		Friend WithEvents btnSupplierGroupStart As Longkong.Pojjaman.Gui.Components.ImageButton
		Friend WithEvents chkIncludeSGChildren As System.Windows.Forms.CheckBox
		Friend WithEvents cmbDueDateType As System.Windows.Forms.ComboBox
		Friend WithEvents lblDueDate As System.Windows.Forms.Label
		Friend WithEvents chkDetail As System.Windows.Forms.CheckBox
		Friend WithEvents btnAccountEndFind As Longkong.Pojjaman.Gui.Components.ImageButton
		Friend WithEvents txtAccountCodeEnd As System.Windows.Forms.TextBox
		Friend WithEvents lblAccountEnd As System.Windows.Forms.Label
		Friend WithEvents btnAccountStartFind As Longkong.Pojjaman.Gui.Components.ImageButton
		Friend WithEvents txtAccountCodeStart As System.Windows.Forms.TextBox
		Friend WithEvents lblAccountStart As System.Windows.Forms.Label
		<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
			Me.components = New System.ComponentModel.Container
			Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(RptPaymentDueFilterSubPanel))
			Me.grbMaster = New Longkong.Pojjaman.Gui.Components.FixedGroupBox
			Me.txtTemp = New System.Windows.Forms.TextBox
			Me.grbDetail = New Longkong.Pojjaman.Gui.Components.FixedGroupBox
			Me.btnAccountEndFind = New Longkong.Pojjaman.Gui.Components.ImageButton
			Me.txtAccountCodeEnd = New System.Windows.Forms.TextBox
			Me.lblAccountEnd = New System.Windows.Forms.Label
			Me.btnAccountStartFind = New Longkong.Pojjaman.Gui.Components.ImageButton
			Me.txtAccountCodeStart = New System.Windows.Forms.TextBox
			Me.lblAccountStart = New System.Windows.Forms.Label
			Me.txtSupplierGroupName = New System.Windows.Forms.TextBox
			Me.lblSupplierGroup = New System.Windows.Forms.Label
			Me.txtSupplierGroupStart = New System.Windows.Forms.TextBox
			Me.btnSupplierGroupStart = New Longkong.Pojjaman.Gui.Components.ImageButton
			Me.chkIncludeSGChildren = New System.Windows.Forms.CheckBox
			Me.chkIncludeChildren = New System.Windows.Forms.CheckBox
			Me.btnCCCodeStart = New Longkong.Pojjaman.Gui.Components.ImageButton
			Me.txtCCCodeStart = New System.Windows.Forms.TextBox
			Me.lblCCStart = New System.Windows.Forms.Label
			Me.txtCostCenterName = New System.Windows.Forms.TextBox
			Me.btnSuppliEndFind = New Longkong.Pojjaman.Gui.Components.ImageButton
			Me.txtSuppliCodeEnd = New System.Windows.Forms.TextBox
			Me.lblSuppliEnd = New System.Windows.Forms.Label
			Me.btnSuppliStartFind = New Longkong.Pojjaman.Gui.Components.ImageButton
			Me.txtSuppliCodeStart = New System.Windows.Forms.TextBox
			Me.lblSuppliStart = New System.Windows.Forms.Label
			Me.txtDocDateStart = New System.Windows.Forms.TextBox
			Me.dtpDocDateStart = New System.Windows.Forms.DateTimePicker
			Me.lblDocDateStart = New System.Windows.Forms.Label
			Me.btnSearch = New System.Windows.Forms.Button
			Me.btnReset = New System.Windows.Forms.Button
			Me.grbDisplay = New Longkong.Pojjaman.Gui.Components.FixedGroupBox
			Me.chkDetail = New System.Windows.Forms.CheckBox
			Me.cmbDueDateType = New System.Windows.Forms.ComboBox
			Me.lblDueDate = New System.Windows.Forms.Label
			Me.cmbShowPeriod = New System.Windows.Forms.ComboBox
			Me.lblTerm = New System.Windows.Forms.Label
			Me.Validator = New Longkong.Pojjaman.Gui.Components.PJMTextboxValidator(Me.components)
			Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider
			Me.grbMaster.SuspendLayout()
			Me.grbDetail.SuspendLayout()
			Me.grbDisplay.SuspendLayout()
			Me.SuspendLayout()
			'
			'grbMaster
			'
			Me.grbMaster.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
									Or System.Windows.Forms.AnchorStyles.Left) _
									Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
			Me.grbMaster.Controls.Add(Me.txtTemp)
			Me.grbMaster.Controls.Add(Me.grbDetail)
			Me.grbMaster.Controls.Add(Me.btnSearch)
			Me.grbMaster.Controls.Add(Me.btnReset)
			Me.grbMaster.Controls.Add(Me.grbDisplay)
			Me.grbMaster.FlatStyle = System.Windows.Forms.FlatStyle.System
			Me.grbMaster.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
			Me.grbMaster.Location = New System.Drawing.Point(8, 8)
			Me.grbMaster.Name = "grbMaster"
			Me.grbMaster.Size = New System.Drawing.Size(704, 232)
			Me.grbMaster.TabIndex = 0
			Me.grbMaster.TabStop = False
			Me.grbMaster.Text = "เช็ครับ"
			'
			'txtTemp
			'
			Me.Validator.SetDataType(Me.txtTemp, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
			Me.Validator.SetDisplayName(Me.txtTemp, "")
			Me.Validator.SetGotFocusBackColor(Me.txtTemp, System.Drawing.Color.Empty)
			Me.Validator.SetInvalidBackColor(Me.txtTemp, System.Drawing.Color.Empty)
			Me.txtTemp.Location = New System.Drawing.Point(704, 32)
			Me.txtTemp.MaxLength = 255
			Me.Validator.SetMaxValue(Me.txtTemp, "")
			Me.Validator.SetMinValue(Me.txtTemp, "")
			Me.txtTemp.Name = "txtTemp"
			Me.txtTemp.ReadOnly = True
			Me.Validator.SetRegularExpression(Me.txtTemp, "")
			Me.Validator.SetRequired(Me.txtTemp, False)
			Me.txtTemp.Size = New System.Drawing.Size(96, 21)
			Me.txtTemp.TabIndex = 3
			Me.txtTemp.Text = ""
			Me.txtTemp.Visible = False
			'
			'grbDetail
			'
			Me.grbDetail.Controls.Add(Me.btnAccountEndFind)
			Me.grbDetail.Controls.Add(Me.txtAccountCodeEnd)
			Me.grbDetail.Controls.Add(Me.lblAccountEnd)
			Me.grbDetail.Controls.Add(Me.btnAccountStartFind)
			Me.grbDetail.Controls.Add(Me.txtAccountCodeStart)
			Me.grbDetail.Controls.Add(Me.lblAccountStart)
			Me.grbDetail.Controls.Add(Me.txtSupplierGroupName)
			Me.grbDetail.Controls.Add(Me.lblSupplierGroup)
			Me.grbDetail.Controls.Add(Me.txtSupplierGroupStart)
			Me.grbDetail.Controls.Add(Me.btnSupplierGroupStart)
			Me.grbDetail.Controls.Add(Me.chkIncludeSGChildren)
			Me.grbDetail.Controls.Add(Me.chkIncludeChildren)
			Me.grbDetail.Controls.Add(Me.btnCCCodeStart)
			Me.grbDetail.Controls.Add(Me.txtCCCodeStart)
			Me.grbDetail.Controls.Add(Me.lblCCStart)
			Me.grbDetail.Controls.Add(Me.txtCostCenterName)
			Me.grbDetail.Controls.Add(Me.btnSuppliEndFind)
			Me.grbDetail.Controls.Add(Me.txtSuppliCodeEnd)
			Me.grbDetail.Controls.Add(Me.lblSuppliEnd)
			Me.grbDetail.Controls.Add(Me.btnSuppliStartFind)
			Me.grbDetail.Controls.Add(Me.txtSuppliCodeStart)
			Me.grbDetail.Controls.Add(Me.lblSuppliStart)
			Me.grbDetail.Controls.Add(Me.txtDocDateStart)
			Me.grbDetail.Controls.Add(Me.dtpDocDateStart)
			Me.grbDetail.Controls.Add(Me.lblDocDateStart)
			Me.grbDetail.FlatStyle = System.Windows.Forms.FlatStyle.System
			Me.grbDetail.Location = New System.Drawing.Point(8, 16)
			Me.grbDetail.Name = "grbDetail"
			Me.grbDetail.Size = New System.Drawing.Size(400, 200)
			Me.grbDetail.TabIndex = 0
			Me.grbDetail.TabStop = False
			Me.grbDetail.Text = "ข้อมูลทั่วไป"
			'
			'btnAccountEndFind
			'
			Me.btnAccountEndFind.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
			Me.btnAccountEndFind.ForeColor = System.Drawing.SystemColors.Control
			Me.btnAccountEndFind.Image = CType(resources.GetObject("btnAccountEndFind.Image"), System.Drawing.Image)
			Me.btnAccountEndFind.Location = New System.Drawing.Point(360, 160)
			Me.btnAccountEndFind.Name = "btnAccountEndFind"
			Me.btnAccountEndFind.Size = New System.Drawing.Size(24, 22)
			Me.btnAccountEndFind.TabIndex = 60
			Me.btnAccountEndFind.TabStop = False
			Me.btnAccountEndFind.ThemedImage = CType(resources.GetObject("btnAccountEndFind.ThemedImage"), System.Drawing.Bitmap)
			'
			'txtAccountCodeEnd
			'
			Me.Validator.SetDataType(Me.txtAccountCodeEnd, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
			Me.Validator.SetDisplayName(Me.txtAccountCodeEnd, "")
			Me.txtAccountCodeEnd.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
			Me.Validator.SetGotFocusBackColor(Me.txtAccountCodeEnd, System.Drawing.Color.Empty)
			Me.ErrorProvider1.SetIconPadding(Me.txtAccountCodeEnd, -15)
			Me.Validator.SetInvalidBackColor(Me.txtAccountCodeEnd, System.Drawing.Color.Empty)
			Me.txtAccountCodeEnd.Location = New System.Drawing.Point(264, 160)
			Me.Validator.SetMaxValue(Me.txtAccountCodeEnd, "")
			Me.Validator.SetMinValue(Me.txtAccountCodeEnd, "")
			Me.txtAccountCodeEnd.Name = "txtAccountCodeEnd"
			Me.Validator.SetRegularExpression(Me.txtAccountCodeEnd, "")
			Me.Validator.SetRequired(Me.txtAccountCodeEnd, False)
			Me.txtAccountCodeEnd.Size = New System.Drawing.Size(96, 21)
			Me.txtAccountCodeEnd.TabIndex = 59
			Me.txtAccountCodeEnd.Text = ""
			'
			'lblAccountEnd
			'
			Me.lblAccountEnd.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
			Me.lblAccountEnd.ForeColor = System.Drawing.Color.Black
			Me.lblAccountEnd.Location = New System.Drawing.Point(232, 160)
			Me.lblAccountEnd.Name = "lblAccountEnd"
			Me.lblAccountEnd.Size = New System.Drawing.Size(24, 18)
			Me.lblAccountEnd.TabIndex = 58
			Me.lblAccountEnd.Text = "ถึง"
			Me.lblAccountEnd.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
			'
			'btnAccountStartFind
			'
			Me.btnAccountStartFind.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
			Me.btnAccountStartFind.ForeColor = System.Drawing.SystemColors.Control
			Me.btnAccountStartFind.Image = CType(resources.GetObject("btnAccountStartFind.Image"), System.Drawing.Image)
			Me.btnAccountStartFind.Location = New System.Drawing.Point(200, 160)
			Me.btnAccountStartFind.Name = "btnAccountStartFind"
			Me.btnAccountStartFind.Size = New System.Drawing.Size(24, 22)
			Me.btnAccountStartFind.TabIndex = 57
			Me.btnAccountStartFind.TabStop = False
			Me.btnAccountStartFind.ThemedImage = CType(resources.GetObject("btnAccountStartFind.ThemedImage"), System.Drawing.Bitmap)
			'
			'txtAccountCodeStart
			'
			Me.Validator.SetDataType(Me.txtAccountCodeStart, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
			Me.Validator.SetDisplayName(Me.txtAccountCodeStart, "")
			Me.txtAccountCodeStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
			Me.Validator.SetGotFocusBackColor(Me.txtAccountCodeStart, System.Drawing.Color.Empty)
			Me.ErrorProvider1.SetIconPadding(Me.txtAccountCodeStart, -15)
			Me.Validator.SetInvalidBackColor(Me.txtAccountCodeStart, System.Drawing.Color.Empty)
			Me.txtAccountCodeStart.Location = New System.Drawing.Point(104, 160)
			Me.Validator.SetMaxValue(Me.txtAccountCodeStart, "")
			Me.Validator.SetMinValue(Me.txtAccountCodeStart, "")
			Me.txtAccountCodeStart.Name = "txtAccountCodeStart"
			Me.Validator.SetRegularExpression(Me.txtAccountCodeStart, "")
			Me.Validator.SetRequired(Me.txtAccountCodeStart, False)
			Me.txtAccountCodeStart.Size = New System.Drawing.Size(96, 21)
			Me.txtAccountCodeStart.TabIndex = 56
			Me.txtAccountCodeStart.Text = ""
			'
			'lblAccountStart
			'
			Me.lblAccountStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
			Me.lblAccountStart.ForeColor = System.Drawing.Color.Black
			Me.lblAccountStart.Location = New System.Drawing.Point(8, 160)
			Me.lblAccountStart.Name = "lblAccountStart"
			Me.lblAccountStart.Size = New System.Drawing.Size(88, 18)
			Me.lblAccountStart.TabIndex = 55
			Me.lblAccountStart.Text = "ตั้งแต่สมุดรายวัน"
			Me.lblAccountStart.TextAlign = System.Drawing.ContentAlignment.MiddleRight
			'
			'txtSupplierGroupName
			'
			Me.Validator.SetDataType(Me.txtSupplierGroupName, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
			Me.Validator.SetDisplayName(Me.txtSupplierGroupName, "")
			Me.txtSupplierGroupName.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
			Me.Validator.SetGotFocusBackColor(Me.txtSupplierGroupName, System.Drawing.Color.Empty)
			Me.ErrorProvider1.SetIconPadding(Me.txtSupplierGroupName, -15)
			Me.Validator.SetInvalidBackColor(Me.txtSupplierGroupName, System.Drawing.Color.Empty)
			Me.txtSupplierGroupName.Location = New System.Drawing.Point(224, 40)
			Me.txtSupplierGroupName.MaxLength = 50
			Me.Validator.SetMaxValue(Me.txtSupplierGroupName, "")
			Me.Validator.SetMinValue(Me.txtSupplierGroupName, "")
			Me.txtSupplierGroupName.Name = "txtSupplierGroupName"
			Me.txtSupplierGroupName.ReadOnly = True
			Me.Validator.SetRegularExpression(Me.txtSupplierGroupName, "")
			Me.Validator.SetRequired(Me.txtSupplierGroupName, False)
			Me.txtSupplierGroupName.Size = New System.Drawing.Size(160, 21)
			Me.txtSupplierGroupName.TabIndex = 51
			Me.txtSupplierGroupName.Text = ""
			'
			'lblSupplierGroup
			'
			Me.lblSupplierGroup.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
			Me.lblSupplierGroup.ForeColor = System.Drawing.Color.Black
			Me.lblSupplierGroup.Location = New System.Drawing.Point(8, 40)
			Me.lblSupplierGroup.Name = "lblSupplierGroup"
			Me.lblSupplierGroup.Size = New System.Drawing.Size(88, 18)
			Me.lblSupplierGroup.TabIndex = 50
			Me.lblSupplierGroup.Text = "กลุ่มผู้ขาย:"
			Me.lblSupplierGroup.TextAlign = System.Drawing.ContentAlignment.MiddleRight
			'
			'txtSupplierGroupStart
			'
			Me.Validator.SetDataType(Me.txtSupplierGroupStart, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
			Me.Validator.SetDisplayName(Me.txtSupplierGroupStart, "")
			Me.txtSupplierGroupStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
			Me.Validator.SetGotFocusBackColor(Me.txtSupplierGroupStart, System.Drawing.Color.Empty)
			Me.ErrorProvider1.SetIconPadding(Me.txtSupplierGroupStart, -15)
			Me.Validator.SetInvalidBackColor(Me.txtSupplierGroupStart, System.Drawing.Color.Empty)
			Me.txtSupplierGroupStart.Location = New System.Drawing.Point(104, 40)
			Me.txtSupplierGroupStart.MaxLength = 50
			Me.Validator.SetMaxValue(Me.txtSupplierGroupStart, "")
			Me.Validator.SetMinValue(Me.txtSupplierGroupStart, "")
			Me.txtSupplierGroupStart.Name = "txtSupplierGroupStart"
			Me.Validator.SetRegularExpression(Me.txtSupplierGroupStart, "")
			Me.Validator.SetRequired(Me.txtSupplierGroupStart, False)
			Me.txtSupplierGroupStart.Size = New System.Drawing.Size(96, 21)
			Me.txtSupplierGroupStart.TabIndex = 52
			Me.txtSupplierGroupStart.Text = ""
			'
			'btnSupplierGroupStart
			'
			Me.btnSupplierGroupStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
			Me.btnSupplierGroupStart.ForeColor = System.Drawing.SystemColors.Control
			Me.btnSupplierGroupStart.Image = CType(resources.GetObject("btnSupplierGroupStart.Image"), System.Drawing.Image)
			Me.btnSupplierGroupStart.Location = New System.Drawing.Point(200, 40)
			Me.btnSupplierGroupStart.Name = "btnSupplierGroupStart"
			Me.btnSupplierGroupStart.Size = New System.Drawing.Size(24, 22)
			Me.btnSupplierGroupStart.TabIndex = 53
			Me.btnSupplierGroupStart.TabStop = False
			Me.btnSupplierGroupStart.ThemedImage = CType(resources.GetObject("btnSupplierGroupStart.ThemedImage"), System.Drawing.Bitmap)
			'
			'chkIncludeSGChildren
			'
			Me.chkIncludeSGChildren.FlatStyle = System.Windows.Forms.FlatStyle.System
			Me.chkIncludeSGChildren.Location = New System.Drawing.Point(104, 64)
			Me.chkIncludeSGChildren.Name = "chkIncludeSGChildren"
			Me.chkIncludeSGChildren.Size = New System.Drawing.Size(128, 24)
			Me.chkIncludeSGChildren.TabIndex = 54
			Me.chkIncludeSGChildren.Text = "รวมกลุ่มผู้ขายลูก"
			'
			'chkIncludeChildren
			'
			Me.chkIncludeChildren.FlatStyle = System.Windows.Forms.FlatStyle.System
			Me.chkIncludeChildren.Location = New System.Drawing.Point(104, 136)
			Me.chkIncludeChildren.Name = "chkIncludeChildren"
			Me.chkIncludeChildren.Size = New System.Drawing.Size(128, 24)
			Me.chkIncludeChildren.TabIndex = 33
			Me.chkIncludeChildren.Text = "รวม Cost Center ลูก"
			'
			'btnCCCodeStart
			'
			Me.btnCCCodeStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
			Me.btnCCCodeStart.ForeColor = System.Drawing.SystemColors.Control
			Me.btnCCCodeStart.Image = CType(resources.GetObject("btnCCCodeStart.Image"), System.Drawing.Image)
			Me.btnCCCodeStart.Location = New System.Drawing.Point(200, 112)
			Me.btnCCCodeStart.Name = "btnCCCodeStart"
			Me.btnCCCodeStart.Size = New System.Drawing.Size(24, 22)
			Me.btnCCCodeStart.TabIndex = 32
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
			Me.txtCCCodeStart.Location = New System.Drawing.Point(104, 112)
			Me.txtCCCodeStart.MaxLength = 50
			Me.Validator.SetMaxValue(Me.txtCCCodeStart, "")
			Me.Validator.SetMinValue(Me.txtCCCodeStart, "")
			Me.txtCCCodeStart.Name = "txtCCCodeStart"
			Me.Validator.SetRegularExpression(Me.txtCCCodeStart, "")
			Me.Validator.SetRequired(Me.txtCCCodeStart, False)
			Me.txtCCCodeStart.Size = New System.Drawing.Size(96, 21)
			Me.txtCCCodeStart.TabIndex = 31
			Me.txtCCCodeStart.Text = ""
			'
			'lblCCStart
			'
			Me.lblCCStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
			Me.lblCCStart.ForeColor = System.Drawing.Color.Black
			Me.lblCCStart.Location = New System.Drawing.Point(24, 112)
			Me.lblCCStart.Name = "lblCCStart"
			Me.lblCCStart.Size = New System.Drawing.Size(72, 18)
			Me.lblCCStart.TabIndex = 29
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
			Me.txtCostCenterName.Location = New System.Drawing.Point(224, 112)
			Me.txtCostCenterName.MaxLength = 50
			Me.Validator.SetMaxValue(Me.txtCostCenterName, "")
			Me.Validator.SetMinValue(Me.txtCostCenterName, "")
			Me.txtCostCenterName.Name = "txtCostCenterName"
			Me.txtCostCenterName.ReadOnly = True
			Me.Validator.SetRegularExpression(Me.txtCostCenterName, "")
			Me.Validator.SetRequired(Me.txtCostCenterName, False)
			Me.txtCostCenterName.Size = New System.Drawing.Size(160, 21)
			Me.txtCostCenterName.TabIndex = 30
			Me.txtCostCenterName.Text = ""
			'
			'btnSuppliEndFind
			'
			Me.btnSuppliEndFind.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
			Me.btnSuppliEndFind.ForeColor = System.Drawing.SystemColors.Control
			Me.btnSuppliEndFind.Image = CType(resources.GetObject("btnSuppliEndFind.Image"), System.Drawing.Image)
			Me.btnSuppliEndFind.Location = New System.Drawing.Point(360, 88)
			Me.btnSuppliEndFind.Name = "btnSuppliEndFind"
			Me.btnSuppliEndFind.Size = New System.Drawing.Size(24, 22)
			Me.btnSuppliEndFind.TabIndex = 11
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
			Me.txtSuppliCodeEnd.Location = New System.Drawing.Point(264, 88)
			Me.Validator.SetMaxValue(Me.txtSuppliCodeEnd, "")
			Me.Validator.SetMinValue(Me.txtSuppliCodeEnd, "")
			Me.txtSuppliCodeEnd.Name = "txtSuppliCodeEnd"
			Me.Validator.SetRegularExpression(Me.txtSuppliCodeEnd, "")
			Me.Validator.SetRequired(Me.txtSuppliCodeEnd, False)
			Me.txtSuppliCodeEnd.Size = New System.Drawing.Size(96, 21)
			Me.txtSuppliCodeEnd.TabIndex = 10
			Me.txtSuppliCodeEnd.Text = ""
			'
			'lblSuppliEnd
			'
			Me.lblSuppliEnd.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
			Me.lblSuppliEnd.ForeColor = System.Drawing.Color.Black
			Me.lblSuppliEnd.Location = New System.Drawing.Point(232, 88)
			Me.lblSuppliEnd.Name = "lblSuppliEnd"
			Me.lblSuppliEnd.Size = New System.Drawing.Size(24, 18)
			Me.lblSuppliEnd.TabIndex = 9
			Me.lblSuppliEnd.Text = "ถึง"
			Me.lblSuppliEnd.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
			'
			'btnSuppliStartFind
			'
			Me.btnSuppliStartFind.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
			Me.btnSuppliStartFind.ForeColor = System.Drawing.SystemColors.Control
			Me.btnSuppliStartFind.Image = CType(resources.GetObject("btnSuppliStartFind.Image"), System.Drawing.Image)
			Me.btnSuppliStartFind.Location = New System.Drawing.Point(200, 88)
			Me.btnSuppliStartFind.Name = "btnSuppliStartFind"
			Me.btnSuppliStartFind.Size = New System.Drawing.Size(24, 22)
			Me.btnSuppliStartFind.TabIndex = 8
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
			Me.txtSuppliCodeStart.Location = New System.Drawing.Point(104, 88)
			Me.Validator.SetMaxValue(Me.txtSuppliCodeStart, "")
			Me.Validator.SetMinValue(Me.txtSuppliCodeStart, "")
			Me.txtSuppliCodeStart.Name = "txtSuppliCodeStart"
			Me.Validator.SetRegularExpression(Me.txtSuppliCodeStart, "")
			Me.Validator.SetRequired(Me.txtSuppliCodeStart, False)
			Me.txtSuppliCodeStart.Size = New System.Drawing.Size(96, 21)
			Me.txtSuppliCodeStart.TabIndex = 7
			Me.txtSuppliCodeStart.Text = ""
			'
			'lblSuppliStart
			'
			Me.lblSuppliStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
			Me.lblSuppliStart.ForeColor = System.Drawing.Color.Black
			Me.lblSuppliStart.Location = New System.Drawing.Point(8, 88)
			Me.lblSuppliStart.Name = "lblSuppliStart"
			Me.lblSuppliStart.Size = New System.Drawing.Size(88, 18)
			Me.lblSuppliStart.TabIndex = 6
			Me.lblSuppliStart.Text = "Supplier:"
			Me.lblSuppliStart.TextAlign = System.Drawing.ContentAlignment.MiddleRight
			'
			'txtDocDateStart
			'
			Me.Validator.SetDataType(Me.txtDocDateStart, Longkong.Pojjaman.Gui.Components.DataTypeConstants.DateTimeType)
			Me.Validator.SetDisplayName(Me.txtDocDateStart, "")
			Me.Validator.SetGotFocusBackColor(Me.txtDocDateStart, System.Drawing.Color.Empty)
			Me.ErrorProvider1.SetIconPadding(Me.txtDocDateStart, -15)
			Me.Validator.SetInvalidBackColor(Me.txtDocDateStart, System.Drawing.Color.Empty)
			Me.txtDocDateStart.Location = New System.Drawing.Point(104, 16)
			Me.txtDocDateStart.MaxLength = 10
			Me.Validator.SetMaxValue(Me.txtDocDateStart, "")
			Me.Validator.SetMinValue(Me.txtDocDateStart, "")
			Me.txtDocDateStart.Name = "txtDocDateStart"
			Me.Validator.SetRegularExpression(Me.txtDocDateStart, "")
			Me.Validator.SetRequired(Me.txtDocDateStart, False)
			Me.txtDocDateStart.Size = New System.Drawing.Size(99, 21)
			Me.txtDocDateStart.TabIndex = 1
			Me.txtDocDateStart.Text = ""
			'
			'dtpDocDateStart
			'
			Me.dtpDocDateStart.Format = System.Windows.Forms.DateTimePickerFormat.Short
			Me.dtpDocDateStart.Location = New System.Drawing.Point(104, 16)
			Me.dtpDocDateStart.Name = "dtpDocDateStart"
			Me.dtpDocDateStart.Size = New System.Drawing.Size(120, 21)
			Me.dtpDocDateStart.TabIndex = 2
			Me.dtpDocDateStart.TabStop = False
			'
			'lblDocDateStart
			'
			Me.lblDocDateStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
			Me.lblDocDateStart.ForeColor = System.Drawing.Color.Black
			Me.lblDocDateStart.Location = New System.Drawing.Point(8, 16)
			Me.lblDocDateStart.Name = "lblDocDateStart"
			Me.lblDocDateStart.Size = New System.Drawing.Size(88, 18)
			Me.lblDocDateStart.TabIndex = 0
			Me.lblDocDateStart.Text = "ตั้งแต่"
			Me.lblDocDateStart.TextAlign = System.Drawing.ContentAlignment.MiddleRight
			'
			'btnSearch
			'
			Me.btnSearch.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
			Me.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.System
			Me.btnSearch.Location = New System.Drawing.Point(616, 200)
			Me.btnSearch.Name = "btnSearch"
			Me.btnSearch.TabIndex = 2
			Me.btnSearch.Text = "ค้นหา"
			'
			'btnReset
			'
			Me.btnReset.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
			Me.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.System
			Me.btnReset.Location = New System.Drawing.Point(536, 200)
			Me.btnReset.Name = "btnReset"
			Me.btnReset.TabIndex = 1
			Me.btnReset.TabStop = False
			Me.btnReset.Text = "เคลียร์"
			'
			'grbDisplay
			'
			Me.grbDisplay.Controls.Add(Me.chkDetail)
			Me.grbDisplay.Controls.Add(Me.cmbDueDateType)
			Me.grbDisplay.Controls.Add(Me.lblDueDate)
			Me.grbDisplay.Controls.Add(Me.cmbShowPeriod)
			Me.grbDisplay.Controls.Add(Me.lblTerm)
			Me.grbDisplay.FlatStyle = System.Windows.Forms.FlatStyle.System
			Me.grbDisplay.Location = New System.Drawing.Point(416, 16)
			Me.grbDisplay.Name = "grbDisplay"
			Me.grbDisplay.Size = New System.Drawing.Size(280, 120)
			Me.grbDisplay.TabIndex = 0
			Me.grbDisplay.TabStop = False
			Me.grbDisplay.Text = "รูปแบบการแสดงผล"
			'
			'chkDetail
			'
			Me.chkDetail.FlatStyle = System.Windows.Forms.FlatStyle.System
			Me.chkDetail.Location = New System.Drawing.Point(136, 64)
			Me.chkDetail.Name = "chkDetail"
			Me.chkDetail.Size = New System.Drawing.Size(128, 24)
			Me.chkDetail.TabIndex = 34
			Me.chkDetail.Text = "แสดงรายละเอียด"
			'
			'cmbDueDateType
			'
			Me.cmbDueDateType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
			Me.cmbDueDateType.Location = New System.Drawing.Point(136, 40)
			Me.cmbDueDateType.Name = "cmbDueDateType"
			Me.cmbDueDateType.Size = New System.Drawing.Size(136, 21)
			Me.cmbDueDateType.TabIndex = 3
			'
			'lblDueDate
			'
			Me.lblDueDate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
			Me.lblDueDate.ForeColor = System.Drawing.Color.Black
			Me.lblDueDate.Location = New System.Drawing.Point(8, 40)
			Me.lblDueDate.Name = "lblDueDate"
			Me.lblDueDate.Size = New System.Drawing.Size(120, 18)
			Me.lblDueDate.TabIndex = 2
			Me.lblDueDate.Text = "วันที่กำหนดชำระตาม"
			Me.lblDueDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight
			'
			'cmbShowPeriod
			'
			Me.cmbShowPeriod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
			Me.cmbShowPeriod.Location = New System.Drawing.Point(136, 16)
			Me.cmbShowPeriod.Name = "cmbShowPeriod"
			Me.cmbShowPeriod.Size = New System.Drawing.Size(136, 21)
			Me.cmbShowPeriod.TabIndex = 1
			'
			'lblTerm
			'
			Me.lblTerm.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
			Me.lblTerm.ForeColor = System.Drawing.Color.Black
			Me.lblTerm.Location = New System.Drawing.Point(48, 16)
			Me.lblTerm.Name = "lblTerm"
			Me.lblTerm.Size = New System.Drawing.Size(80, 18)
			Me.lblTerm.TabIndex = 0
			Me.lblTerm.Text = "ช่วงการแสดง"
			Me.lblTerm.TextAlign = System.Drawing.ContentAlignment.MiddleRight
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
			'RptPaymentDueFilterSubPanel
			'
			Me.Controls.Add(Me.grbMaster)
			Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
			Me.Name = "RptPaymentDueFilterSubPanel"
			Me.Size = New System.Drawing.Size(720, 248)
			Me.grbMaster.ResumeLayout(False)
			Me.grbDetail.ResumeLayout(False)
			Me.grbDisplay.ResumeLayout(False)
			Me.ResumeLayout(False)

		End Sub

#End Region

#Region " SetLabelText "
		Public Sub SetLabelText()
			'If Not m_entity Is Nothing Then Me.Text = Me.StringParserService.Parse(Me.m_entity.TabPageText)
			Me.lblSuppliStart.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptPaymentDueFilterSubPanel.lblSuppliStart}")
			Me.Validator.SetDisplayName(txtSuppliCodeStart, lblSuppliStart.Text)

			'SupplierGroup
			Me.lblSupplierGroup.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptPaymentDueFilterSubPanel.lblSupplierGroup}")
			Me.Validator.SetDisplayName(txtSupplierGroupStart, lblSupplierGroup.Text)
			Me.chkIncludeSGChildren.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptPaymentDueFilterSubPanel.chkIncludeSGChildren}")

			Me.lblDocDateStart.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptPaymentDueFilterSubPanel.lblDocDateStart}")
			Me.Validator.SetDisplayName(txtDocDateStart, lblDocDateStart.Text)

			Me.lblCCStart.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptPaymentDueFilterSubPanel.lblCCStart}")
			Me.Validator.SetDisplayName(txtCCCodeStart, lblCCStart.Text)

			' Global {ถึง}
			Me.lblSuppliEnd.Text = Me.StringParserService.Parse("${res:Global.FilterPanelTo}")
			Me.Validator.SetDisplayName(txtSuppliCodeEnd, lblSuppliEnd.Text)

			' Button
			Me.btnSearch.Text = Me.StringParserService.Parse("${res:Global.SearchButtonText}")
			Me.btnReset.Text = Me.StringParserService.Parse("${res:Global.ResetButtonText}")

			' GroupBox
			Me.grbMaster.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptPaymentDueFilterSubPanel.grbMaster}")
			Me.grbDetail.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptPaymentDueFilterSubPanel.grbDetail}")

			'Checkbox
			Me.chkIncludeChildren.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptPaymentDueFilterSubPanel.chkIncludeChildren}")

			Me.cmbShowPeriod.Items.Add(Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptPaymentDueFilterSubPanel.cmbShowPeriod_Month}"))
			Me.cmbShowPeriod.Items.Add(Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptPaymentDueFilterSubPanel.cmbShowPeriod_6Month}"))
			Me.cmbShowPeriod.Items.Add(Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptPaymentDueFilterSubPanel.cmbShowPeriod_Year}"))
			Me.cmbShowPeriod.SelectedIndex = 0

			Me.cmbDueDateType.Items.Add(Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptPaymentDueFilterSubPanel.NotSpecialize}"))			'ไม่ระบุ
			Me.cmbDueDateType.Items.Add(Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptPaymentDueFilterSubPanel.cmbDuebyPUR}"))			'ใบซื้อสินค้าบริการ/รับของ
			Me.cmbDueDateType.Items.Add(Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptPaymentDueFilterSubPanel.cmbDuebyBA}"))			'ใบวางบิล
			Me.cmbDueDateType.SelectedIndex = 0

			Me.lblDueDate.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptPaymentDueFilterSubPanel.lblDueDate}")
			Me.chkDetail.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptPaymentDueFilterSubPanel.chkDetail}")

			Me.lblAccountStart.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptPaymentDueFilterSubPanel.lblAccountStart}")
			Me.Validator.SetDisplayName(txtAccountCodeStart, lblAccountStart.Text)

			Me.lblAccountEnd.Text = Me.StringParserService.Parse("${res:Global.FilterPanelTo}")
            Me.Validator.SetDisplayName(txtAccountCodeEnd, lblAccountEnd.Text)

            Me.grbDisplay.Text = Me.StringParserService.Parse("${res:Global.grbDisplay}")
            Me.lblTerm.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptPaymentDueFilterSubPanel.lblTerm}")
        End Sub
#End Region

#Region "Member"
        Private m_supplierstart As Supplier
        Private m_supplierend As Supplier
        Private m_sg As SupplierGroup

        Private m_DocDateStart As Date
        Private m_cc As CostCenter
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
        Public Property SupplierGroup() As SupplierGroup
            Get
                Return m_sg
            End Get
            Set(ByVal Value As SupplierGroup)
                m_sg = Value
            End Set
        End Property
        Public Property DocDateStart() As Date            Get                Return m_DocDateStart            End Get            Set(ByVal Value As Date)                m_DocDateStart = Value            End Set        End Property
        Public Property Costcenter() As CostCenter
            Get
                Return m_cc
            End Get
            Set(ByVal Value As CostCenter)
                m_cc = Value
            End Set
        End Property
#End Region

#Region "Methods"

        Private Sub Initialize()
            ClearCriterias()
        End Sub

        Private Sub ClearCriterias()
            For Each grbCtrl As Control In grbMaster.Controls
                If TypeOf grbCtrl Is Longkong.Pojjaman.Gui.Components.FixedGroupBox Then
                    For Each Ctrl As Control In grbCtrl.Controls
                        If TypeOf Ctrl Is TextBox Then
                            Ctrl.Text = ""
                        End If
                    Next
                End If
            Next

            Me.Costcenter = New CostCenter

            Me.SupplierGroup = New SupplierGroup
            Me.SupplierStart = New Supplier
            Me.SupplierEnd = New Supplier

            Dim dtStart As Date = Date.Now
            Me.DocDateStart = dtStart
            Me.txtDocDateStart.Text = MinDateToNull(Me.DocDateStart, "")
            Me.dtpDocDateStart.Value = Me.DocDateStart

            If Me.cmbShowPeriod.Items.Count > 0 Then
                Me.cmbShowPeriod.SelectedIndex = 0
            End If
            If Me.cmbDueDateType.Items.Count > 0 Then
                Me.cmbDueDateType.SelectedIndex = 0
            End If
            Me.chkDetail.Checked = False

        End Sub
        Public Overrides Function GetFilterString() As String

        End Function
        Public Overrides Function GetFilterArray() As Filter()
            Dim arr(12) As Filter
            arr(0) = New Filter("DocDateStart", IIf(Me.DocDateStart.Equals(Date.MinValue), DBNull.Value, Me.DocDateStart))
            arr(1) = New Filter("SuppliCodeStart", IIf(txtSuppliCodeStart.TextLength > 0, txtSuppliCodeStart.Text, DBNull.Value))
            arr(2) = New Filter("SuppliCodeEnd", IIf(txtSuppliCodeEnd.TextLength > 0, txtSuppliCodeEnd.Text, DBNull.Value))
            arr(3) = New Filter("sg_id", Me.ValidIdOrDBNull(m_sg))
            arr(4) = New Filter("IncludeChildSG", Me.chkIncludeSGChildren.Checked)
            arr(5) = New Filter("cc_id", Me.ValidIdOrDBNull(m_cc))
            arr(6) = New Filter("IncludeChildCC", Me.chkIncludeChildren.Checked)
            arr(7) = New Filter("ShowPeriod", Me.cmbShowPeriod.SelectedIndex)
            arr(8) = New Filter("userRight", CType(ServiceManager.Services.GetService(GetType(SecurityService)), SecurityService).CurrentUser.Id)
            arr(9) = New Filter("DueDateBy", Me.cmbDueDateType.SelectedIndex)
            arr(10) = New Filter("ShowDetail", IIf(Me.chkDetail.Checked, 1, 0))
            arr(11) = New Filter("AcctBookCodeStart", IIf(txtAccountCodeStart.TextLength > 0, txtAccountCodeStart.Text, DBNull.Value))
            arr(12) = New Filter("AcctBookCodeEnd", IIf(txtAccountCodeEnd.TextLength > 0, txtAccountCodeEnd.Text, DBNull.Value))
            Return arr
        End Function
        Public Overrides ReadOnly Property SearchButton() As System.Windows.Forms.Button
            Get
                Return Me.btnSearch
            End Get
        End Property

        Private Sub btnReset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReset.Click
            ClearCriterias()
            'Me.btnSearch.PerformClick()
        End Sub
#End Region

#Region "IReportFilterSubPanel"
        Public Function GetFixValueCollection() As BusinessLogic.DocPrintingItemCollection Implements IReportFilterSubPanel.GetFixValueCollection
            Dim dpiColl As New DocPrintingItemCollection
            Dim dpi As DocPrintingItem

            'Month
            dpi = New DocPrintingItem
            dpi.Mapping = "Month"
            dpi.Value = ""          'Me.cmbMonth.Text
            dpi.DataType = "System.String"
            dpiColl.Add(dpi)

            'Year
            dpi = New DocPrintingItem
            dpi.Mapping = "Year"
            dpi.Value = ""          'Me.cmbYear.Text
            dpi.DataType = "System.String"
            dpiColl.Add(dpi)

            'Docdate Start
            dpi = New DocPrintingItem
            dpi.Mapping = "DocdateStart"
            dpi.Value = Me.txtDocDateStart.Text
            dpi.DataType = "System.String"
            dpiColl.Add(dpi)

            'Supplier Start
            dpi = New DocPrintingItem
            dpi.Mapping = "SupplierStart"
            dpi.Value = Me.txtSuppliCodeStart.Text
            dpi.DataType = "System.String"
            dpiColl.Add(dpi)

            'Supplier End
            dpi = New DocPrintingItem
            dpi.Mapping = "SupplierEnd"
            dpi.Value = Me.txtSuppliCodeEnd.Text
            dpi.DataType = "System.String"
            dpiColl.Add(dpi)

            'SupplierGroup
            dpi = New DocPrintingItem
            dpi.Mapping = "SupplierGroup"
            dpi.Value = Me.txtSupplierGroupName.Text
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

            'DueDateBy
            dpi = New DocPrintingItem
            dpi.Mapping = "DueDateBy"
            dpi.Value = Me.cmbDueDateType.Text
            dpi.DataType = "System.String"
            dpiColl.Add(dpi)

            If Me.chkDetail.Checked Then
                'Show Detail
                dpi = New DocPrintingItem
                dpi.Mapping = "ShowDetail"
                dpi.Value = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptPaymentDue.ShowDetail}")              '"แสดงละเอียด"
                dpi.DataType = "System.String"
                dpiColl.Add(dpi)
            End If

            'account start
            dpi = New DocPrintingItem
            dpi.Mapping = "accountstart"
            dpi.Value = Me.txtAccountCodeStart.Text
            dpi.DataType = "System.String"
            dpiColl.Add(dpi)

            'account end
            dpi = New DocPrintingItem
            dpi.Mapping = "accountend"
            dpi.Value = Me.txtAccountCodeEnd.Text
            dpi.DataType = "System.String"
            dpiColl.Add(dpi)

            Return dpiColl
        End Function
#End Region

#Region " ChangeProperty "
        Private Sub EventWiring()
            AddHandler btnSuppliStartFind.Click, AddressOf Me.btnSupplierFind_Click
            AddHandler btnSuppliEndFind.Click, AddressOf Me.btnSupplierFind_Click

            AddHandler btnSupplierGroupStart.Click, AddressOf Me.btnSupplierGroupFind_Click
            AddHandler txtSupplierGroupStart.Validated, AddressOf Me.ChangeProperty

            AddHandler btnCCCodeStart.Click, AddressOf Me.btnCostcenterFind_Click
            AddHandler txtCCCodeStart.Validated, AddressOf Me.ChangeProperty

            AddHandler txtDocDateStart.Validated, AddressOf Me.ChangeProperty
            AddHandler dtpDocDateStart.ValueChanged, AddressOf Me.ChangeProperty

            AddHandler btnAccountStartFind.Click, AddressOf Me.btnAccountFind_Click
            AddHandler btnAccountEndFind.Click, AddressOf Me.btnAccountFind_Click

        End Sub

        Private m_dateSetting As Boolean
        Private Sub ChangeProperty(ByVal sender As Object, ByVal e As EventArgs)

            Select Case CType(sender, Control).Name.ToLower
                Case "txtcccodestart"
                    Costcenter.GetCostCenter(txtCCCodeStart, Me.txtCostCenterName, m_cc, CType(ServiceManager.Services.GetService(GetType(SecurityService)), SecurityService).CurrentUser.Id)

                Case "txtsuppliergroupstart"
                    SupplierGroup.GetSupplierGroup(txtSupplierGroupStart, Me.txtSupplierGroupName, m_sg)

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

                    'Case "dtpdocdateend"
                    '    If Not Me.DocDateEnd.Equals(dtpDocDateEnd.Value) Then
                    '        If Not m_dateSetting Then
                    '            Me.txtDocDateEnd.Text = MinDateToNull(dtpDocDateEnd.Value, Me.StringParserService.Parse("${res:Global.BlankDateText}"))
                    '            Me.DocDateEnd = dtpDocDateEnd.Value
                    '        End If
                    '    End If
                    'Case "txtdocdateend"
                    '    m_dateSetting = True
                    '    If Not Me.txtDocDateEnd.Text.Length = 0 AndAlso Me.Validator.GetErrorMessage(Me.txtDocDateEnd) = "" Then
                    '        Dim theDate As Date = CDate(Me.txtDocDateEnd.Text)
                    '        If Not Me.DocDateEnd.Equals(theDate) Then
                    '            dtpDocDateEnd.Value = theDate
                    '            Me.DocDateEnd = dtpDocDateEnd.Value
                    '        End If
                    '    Else
                    '        Me.dtpDocDateEnd.Value = Date.Now
                    '        Me.DocDateEnd = Date.MinValue
                    '    End If
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
                            Case "txtsupplicodestart", "txtsupplicodeend"
                                Return True
                        End Select
                    End If
                End If
                ' Costcenter
                If data.GetDataPresent((New CostCenter).FullClassName) Then
                    If Not Me.ActiveControl Is Nothing Then
                        Select Case Me.ActiveControl.Name.ToLower
                            Case "txtcccodestart", "txtcccodeend"
                                Return True
                        End Select
                    End If
                End If
                If data.GetDataPresent((New AccountBook).FullClassName) Then
                    If Not Me.ActiveControl Is Nothing Then
                        Select Case Me.ActiveControl.Name.ToLower
                            Case "txtaccountcodestart", "txtaccountcodeend"
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
                        Case "txtsupplicodestart"
                            Me.SetSupplierStartDialog(entity)

                        Case "txtsupplicodeend"
                            Me.SetSupplierEndDialog(entity)

                    End Select
                End If
            End If
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
            If data.GetDataPresent((New AccountBook).FullClassName) Then
                Dim id As Integer = CInt(data.GetData((New AccountBook).FullClassName))
                Dim entity As New AccountBook(id)
                If Not Me.ActiveControl Is Nothing Then
                    Select Case Me.ActiveControl.Name.ToLower
                        Case "txtaccountcodestart"
                            Me.SetAcctBookStartDialog(entity)

                        Case "txtaccountcodeend"
                            Me.SetAcctBookEndDialog(entity)

                    End Select
                End If
            End If
        End Sub
#End Region

#Region " Event Handlers "
        Private Sub btnSupplierFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
            Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
            Select Case CType(sender, Control).Name.ToLower
                Case "btnsupplistartfind"
                    myEntityPanelService.OpenListDialog(New Supplier, AddressOf SetSupplierStartDialog)

                Case "btnsuppliendfind"
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
        Private Sub btnSupplierGroupFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
            Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
            Select Case CType(sender, Control).Name.ToLower
                Case "btnsuppliergroupstart"
                    myEntityPanelService.OpenTreeDialog(New SupplierGroup, AddressOf SetSupplierGroupStartDialog)
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
        Private Sub SetSupplierGroupStartDialog(ByVal e As ISimpleEntity)
            Me.txtSupplierGroupStart.Text = e.Code
            SupplierGroup.GetSupplierGroup(txtSupplierGroupStart, txtSupplierGroupName, m_sg)
        End Sub
        Private Sub SetCCCodeStartDialog(ByVal e As ISimpleEntity)
            Me.txtCCCodeStart.Text = e.Code
            Costcenter.GetCostCenter(txtCCCodeStart, txtCostCenterName, m_cc, CType(ServiceManager.Services.GetService(GetType(SecurityService)), SecurityService).CurrentUser.Id)
        End Sub
        Private Sub btnAccountFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
            Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
            Select Case CType(sender, Control).Name.ToLower
                Case "btnaccountstartfind"
                    myEntityPanelService.OpenListDialog(New AccountBook, AddressOf SetAcctBookStartDialog)

                Case "btnaccountendfind"
                    myEntityPanelService.OpenListDialog(New AccountBook, AddressOf SetAcctBookEndDialog)

            End Select
        End Sub
        Private Sub SetAcctBookStartDialog(ByVal e As ISimpleEntity)
            Me.txtAccountCodeStart.Text = e.Code
        End Sub
        Private Sub SetAcctBookEndDialog(ByVal e As ISimpleEntity)
            Me.txtAccountCodeEnd.Text = e.Code
        End Sub

#End Region

    End Class
End Namespace

