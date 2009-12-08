Imports Longkong.Pojjaman.BusinessLogic
Imports longkong.Pojjaman.Services
Imports Longkong.Core.Services

Namespace Longkong.Pojjaman.Gui.Panels
	Public Class RptAPGLFilterSubPanel
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
		Friend WithEvents Validator As Longkong.Pojjaman.Gui.Components.PJMTextboxValidator
		Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
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
		Friend WithEvents txtDocDateEnd As System.Windows.Forms.TextBox
		Friend WithEvents txtDocDateStart As System.Windows.Forms.TextBox
		Friend WithEvents dtpDocDateStart As System.Windows.Forms.DateTimePicker
		Friend WithEvents dtpDocDateEnd As System.Windows.Forms.DateTimePicker
		Friend WithEvents lblDocDateStart As System.Windows.Forms.Label
		Friend WithEvents lblDocDateEnd As System.Windows.Forms.Label
		Friend WithEvents txtSupplierGroupName As System.Windows.Forms.TextBox
		Friend WithEvents lblSupplierGroup As System.Windows.Forms.Label
		Friend WithEvents txtSupplierGroupStart As System.Windows.Forms.TextBox
		Friend WithEvents btnSupplierGroupStart As Longkong.Pojjaman.Gui.Components.ImageButton
		Friend WithEvents chkIncludeSGChildren As System.Windows.Forms.CheckBox
		Friend WithEvents btnAcctCodeEndFind As Longkong.Pojjaman.Gui.Components.ImageButton
		Friend WithEvents txtAcctCodeEnd As System.Windows.Forms.TextBox
		Friend WithEvents btnAcctCodeStartFind As Longkong.Pojjaman.Gui.Components.ImageButton
		Friend WithEvents txtAcctCodeStart As System.Windows.Forms.TextBox
		Friend WithEvents chkAPAcctOnly As System.Windows.Forms.CheckBox
		Friend WithEvents lblAcctEnd As System.Windows.Forms.Label
		Friend WithEvents lblAcctStart As System.Windows.Forms.Label
		<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
			Me.components = New System.ComponentModel.Container
			Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(RptAPGLFilterSubPanel))
			Me.grbMaster = New Longkong.Pojjaman.Gui.Components.FixedGroupBox
			Me.txtTemp = New System.Windows.Forms.TextBox
			Me.grbDetail = New Longkong.Pojjaman.Gui.Components.FixedGroupBox
			Me.chkAPAcctOnly = New System.Windows.Forms.CheckBox
			Me.btnAcctCodeEndFind = New Longkong.Pojjaman.Gui.Components.ImageButton
			Me.txtAcctCodeEnd = New System.Windows.Forms.TextBox
			Me.lblAcctEnd = New System.Windows.Forms.Label
			Me.btnAcctCodeStartFind = New Longkong.Pojjaman.Gui.Components.ImageButton
			Me.txtAcctCodeStart = New System.Windows.Forms.TextBox
			Me.lblAcctStart = New System.Windows.Forms.Label
			Me.txtSupplierGroupName = New System.Windows.Forms.TextBox
			Me.lblSupplierGroup = New System.Windows.Forms.Label
			Me.txtSupplierGroupStart = New System.Windows.Forms.TextBox
			Me.btnSupplierGroupStart = New Longkong.Pojjaman.Gui.Components.ImageButton
			Me.chkIncludeSGChildren = New System.Windows.Forms.CheckBox
			Me.txtDocDateEnd = New System.Windows.Forms.TextBox
			Me.txtDocDateStart = New System.Windows.Forms.TextBox
			Me.dtpDocDateStart = New System.Windows.Forms.DateTimePicker
			Me.dtpDocDateEnd = New System.Windows.Forms.DateTimePicker
			Me.lblDocDateStart = New System.Windows.Forms.Label
			Me.lblDocDateEnd = New System.Windows.Forms.Label
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
			Me.btnSearch = New System.Windows.Forms.Button
			Me.btnReset = New System.Windows.Forms.Button
			Me.Validator = New Longkong.Pojjaman.Gui.Components.PJMTextboxValidator(Me.components)
			Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider
			Me.grbMaster.SuspendLayout()
			Me.grbDetail.SuspendLayout()
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
			Me.grbMaster.FlatStyle = System.Windows.Forms.FlatStyle.System
			Me.grbMaster.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
			Me.grbMaster.Location = New System.Drawing.Point(8, 8)
			Me.grbMaster.Name = "grbMaster"
			Me.grbMaster.Size = New System.Drawing.Size(456, 288)
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
			Me.txtTemp.Location = New System.Drawing.Point(480, 32)
			Me.txtTemp.MaxLength = 255
			Me.Validator.SetMaxValue(Me.txtTemp, "")
			Me.Validator.SetMinValue(Me.txtTemp, "")
			Me.txtTemp.Name = "txtTemp"
			Me.txtTemp.ReadOnly = True
			Me.Validator.SetRegularExpression(Me.txtTemp, "")
			Me.Validator.SetRequired(Me.txtTemp, False)
			Me.txtTemp.Size = New System.Drawing.Size(104, 21)
			Me.txtTemp.TabIndex = 3
			Me.txtTemp.Text = ""
			Me.txtTemp.Visible = False
			'
			'grbDetail
			'
			Me.grbDetail.Controls.Add(Me.chkAPAcctOnly)
			Me.grbDetail.Controls.Add(Me.btnAcctCodeEndFind)
			Me.grbDetail.Controls.Add(Me.txtAcctCodeEnd)
			Me.grbDetail.Controls.Add(Me.lblAcctEnd)
			Me.grbDetail.Controls.Add(Me.btnAcctCodeStartFind)
			Me.grbDetail.Controls.Add(Me.txtAcctCodeStart)
			Me.grbDetail.Controls.Add(Me.lblAcctStart)
			Me.grbDetail.Controls.Add(Me.txtSupplierGroupName)
			Me.grbDetail.Controls.Add(Me.lblSupplierGroup)
			Me.grbDetail.Controls.Add(Me.txtSupplierGroupStart)
			Me.grbDetail.Controls.Add(Me.btnSupplierGroupStart)
			Me.grbDetail.Controls.Add(Me.chkIncludeSGChildren)
			Me.grbDetail.Controls.Add(Me.txtDocDateEnd)
			Me.grbDetail.Controls.Add(Me.txtDocDateStart)
			Me.grbDetail.Controls.Add(Me.dtpDocDateStart)
			Me.grbDetail.Controls.Add(Me.dtpDocDateEnd)
			Me.grbDetail.Controls.Add(Me.lblDocDateStart)
			Me.grbDetail.Controls.Add(Me.lblDocDateEnd)
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
			Me.grbDetail.FlatStyle = System.Windows.Forms.FlatStyle.System
			Me.grbDetail.Location = New System.Drawing.Point(16, 16)
			Me.grbDetail.Name = "grbDetail"
			Me.grbDetail.Size = New System.Drawing.Size(424, 232)
			Me.grbDetail.TabIndex = 0
			Me.grbDetail.TabStop = False
			Me.grbDetail.Text = "ข้อมูลทั่วไป"
			'
			'chkAPAcctOnly
			'
			Me.chkAPAcctOnly.FlatStyle = System.Windows.Forms.FlatStyle.System
			Me.chkAPAcctOnly.Location = New System.Drawing.Point(120, 192)
			Me.chkAPAcctOnly.Name = "chkAPAcctOnly"
			Me.chkAPAcctOnly.Size = New System.Drawing.Size(176, 24)
			Me.chkAPAcctOnly.TabIndex = 51
			Me.chkAPAcctOnly.Text = "เฉพาะผังบัญชีที่ระบุไว้กับเจ้าหนี้"
			'
			'btnAcctCodeEndFind
			'
			Me.btnAcctCodeEndFind.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
			Me.btnAcctCodeEndFind.ForeColor = System.Drawing.SystemColors.Control
			Me.btnAcctCodeEndFind.Image = CType(resources.GetObject("btnAcctCodeEndFind.Image"), System.Drawing.Image)
			Me.btnAcctCodeEndFind.Location = New System.Drawing.Point(376, 160)
			Me.btnAcctCodeEndFind.Name = "btnAcctCodeEndFind"
			Me.btnAcctCodeEndFind.Size = New System.Drawing.Size(24, 22)
			Me.btnAcctCodeEndFind.TabIndex = 50
			Me.btnAcctCodeEndFind.TabStop = False
			Me.btnAcctCodeEndFind.ThemedImage = CType(resources.GetObject("btnAcctCodeEndFind.ThemedImage"), System.Drawing.Bitmap)
			'
			'txtAcctCodeEnd
			'
			Me.Validator.SetDataType(Me.txtAcctCodeEnd, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
			Me.Validator.SetDisplayName(Me.txtAcctCodeEnd, "")
			Me.txtAcctCodeEnd.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
			Me.Validator.SetGotFocusBackColor(Me.txtAcctCodeEnd, System.Drawing.Color.Empty)
			Me.ErrorProvider1.SetIconPadding(Me.txtAcctCodeEnd, -15)
			Me.Validator.SetInvalidBackColor(Me.txtAcctCodeEnd, System.Drawing.Color.Empty)
			Me.txtAcctCodeEnd.Location = New System.Drawing.Point(280, 160)
			Me.Validator.SetMaxValue(Me.txtAcctCodeEnd, "")
			Me.Validator.SetMinValue(Me.txtAcctCodeEnd, "")
			Me.txtAcctCodeEnd.Name = "txtAcctCodeEnd"
			Me.Validator.SetRegularExpression(Me.txtAcctCodeEnd, "")
			Me.Validator.SetRequired(Me.txtAcctCodeEnd, False)
			Me.txtAcctCodeEnd.Size = New System.Drawing.Size(96, 21)
			Me.txtAcctCodeEnd.TabIndex = 49
			Me.txtAcctCodeEnd.Text = ""
			'
			'lblAcctEnd
			'
			Me.lblAcctEnd.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
			Me.lblAcctEnd.ForeColor = System.Drawing.Color.Black
			Me.lblAcctEnd.Location = New System.Drawing.Point(248, 160)
			Me.lblAcctEnd.Name = "lblAcctEnd"
			Me.lblAcctEnd.Size = New System.Drawing.Size(24, 18)
			Me.lblAcctEnd.TabIndex = 48
			Me.lblAcctEnd.Text = "ถึง"
			Me.lblAcctEnd.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
			'
			'btnAcctCodeStartFind
			'
			Me.btnAcctCodeStartFind.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
			Me.btnAcctCodeStartFind.ForeColor = System.Drawing.SystemColors.Control
			Me.btnAcctCodeStartFind.Image = CType(resources.GetObject("btnAcctCodeStartFind.Image"), System.Drawing.Image)
			Me.btnAcctCodeStartFind.Location = New System.Drawing.Point(216, 160)
			Me.btnAcctCodeStartFind.Name = "btnAcctCodeStartFind"
			Me.btnAcctCodeStartFind.Size = New System.Drawing.Size(24, 22)
			Me.btnAcctCodeStartFind.TabIndex = 47
			Me.btnAcctCodeStartFind.TabStop = False
			Me.btnAcctCodeStartFind.ThemedImage = CType(resources.GetObject("btnAcctCodeStartFind.ThemedImage"), System.Drawing.Bitmap)
			'
			'txtAcctCodeStart
			'
			Me.Validator.SetDataType(Me.txtAcctCodeStart, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
			Me.Validator.SetDisplayName(Me.txtAcctCodeStart, "")
			Me.txtAcctCodeStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
			Me.Validator.SetGotFocusBackColor(Me.txtAcctCodeStart, System.Drawing.Color.Empty)
			Me.ErrorProvider1.SetIconPadding(Me.txtAcctCodeStart, -15)
			Me.Validator.SetInvalidBackColor(Me.txtAcctCodeStart, System.Drawing.Color.Empty)
			Me.txtAcctCodeStart.Location = New System.Drawing.Point(120, 160)
			Me.Validator.SetMaxValue(Me.txtAcctCodeStart, "")
			Me.Validator.SetMinValue(Me.txtAcctCodeStart, "")
			Me.txtAcctCodeStart.Name = "txtAcctCodeStart"
			Me.Validator.SetRegularExpression(Me.txtAcctCodeStart, "")
			Me.Validator.SetRequired(Me.txtAcctCodeStart, False)
			Me.txtAcctCodeStart.Size = New System.Drawing.Size(96, 21)
			Me.txtAcctCodeStart.TabIndex = 46
			Me.txtAcctCodeStart.Text = ""
			'
			'lblAcctStart
			'
			Me.lblAcctStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
			Me.lblAcctStart.ForeColor = System.Drawing.Color.Black
			Me.lblAcctStart.Location = New System.Drawing.Point(24, 160)
			Me.lblAcctStart.Name = "lblAcctStart"
			Me.lblAcctStart.Size = New System.Drawing.Size(88, 18)
			Me.lblAcctStart.TabIndex = 45
			Me.lblAcctStart.Text = "ผังบัญชี:"
			Me.lblAcctStart.TextAlign = System.Drawing.ContentAlignment.MiddleRight
			'
			'txtSupplierGroupName
			'
			Me.Validator.SetDataType(Me.txtSupplierGroupName, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
			Me.Validator.SetDisplayName(Me.txtSupplierGroupName, "")
			Me.txtSupplierGroupName.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
			Me.Validator.SetGotFocusBackColor(Me.txtSupplierGroupName, System.Drawing.Color.Empty)
			Me.ErrorProvider1.SetIconPadding(Me.txtSupplierGroupName, -15)
			Me.Validator.SetInvalidBackColor(Me.txtSupplierGroupName, System.Drawing.Color.Empty)
			Me.txtSupplierGroupName.Location = New System.Drawing.Point(240, 40)
			Me.txtSupplierGroupName.MaxLength = 50
			Me.Validator.SetMaxValue(Me.txtSupplierGroupName, "")
			Me.Validator.SetMinValue(Me.txtSupplierGroupName, "")
			Me.txtSupplierGroupName.Name = "txtSupplierGroupName"
			Me.txtSupplierGroupName.ReadOnly = True
			Me.Validator.SetRegularExpression(Me.txtSupplierGroupName, "")
			Me.Validator.SetRequired(Me.txtSupplierGroupName, False)
			Me.txtSupplierGroupName.Size = New System.Drawing.Size(160, 21)
			Me.txtSupplierGroupName.TabIndex = 41
			Me.txtSupplierGroupName.Text = ""
			'
			'lblSupplierGroup
			'
			Me.lblSupplierGroup.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
			Me.lblSupplierGroup.ForeColor = System.Drawing.Color.Black
			Me.lblSupplierGroup.Location = New System.Drawing.Point(16, 40)
			Me.lblSupplierGroup.Name = "lblSupplierGroup"
			Me.lblSupplierGroup.Size = New System.Drawing.Size(96, 18)
			Me.lblSupplierGroup.TabIndex = 40
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
			Me.txtSupplierGroupStart.Location = New System.Drawing.Point(120, 40)
			Me.txtSupplierGroupStart.MaxLength = 50
			Me.Validator.SetMaxValue(Me.txtSupplierGroupStart, "")
			Me.Validator.SetMinValue(Me.txtSupplierGroupStart, "")
			Me.txtSupplierGroupStart.Name = "txtSupplierGroupStart"
			Me.Validator.SetRegularExpression(Me.txtSupplierGroupStart, "")
			Me.Validator.SetRequired(Me.txtSupplierGroupStart, False)
			Me.txtSupplierGroupStart.Size = New System.Drawing.Size(96, 21)
			Me.txtSupplierGroupStart.TabIndex = 42
			Me.txtSupplierGroupStart.Text = ""
			'
			'btnSupplierGroupStart
			'
			Me.btnSupplierGroupStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
			Me.btnSupplierGroupStart.ForeColor = System.Drawing.SystemColors.Control
			Me.btnSupplierGroupStart.Image = CType(resources.GetObject("btnSupplierGroupStart.Image"), System.Drawing.Image)
			Me.btnSupplierGroupStart.Location = New System.Drawing.Point(216, 40)
			Me.btnSupplierGroupStart.Name = "btnSupplierGroupStart"
			Me.btnSupplierGroupStart.Size = New System.Drawing.Size(24, 22)
			Me.btnSupplierGroupStart.TabIndex = 43
			Me.btnSupplierGroupStart.TabStop = False
			Me.btnSupplierGroupStart.ThemedImage = CType(resources.GetObject("btnSupplierGroupStart.ThemedImage"), System.Drawing.Bitmap)
			'
			'chkIncludeSGChildren
			'
			Me.chkIncludeSGChildren.FlatStyle = System.Windows.Forms.FlatStyle.System
			Me.chkIncludeSGChildren.Location = New System.Drawing.Point(120, 64)
			Me.chkIncludeSGChildren.Name = "chkIncludeSGChildren"
			Me.chkIncludeSGChildren.Size = New System.Drawing.Size(128, 24)
			Me.chkIncludeSGChildren.TabIndex = 44
			Me.chkIncludeSGChildren.Text = "รวมกลุ่มผู้ขายลูก"
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
			Me.Validator.SetMaxValue(Me.txtDocDateEnd, "")
			Me.Validator.SetMinValue(Me.txtDocDateEnd, "")
			Me.txtDocDateEnd.Name = "txtDocDateEnd"
			Me.Validator.SetRegularExpression(Me.txtDocDateEnd, "")
			Me.Validator.SetRequired(Me.txtDocDateEnd, False)
			Me.txtDocDateEnd.Size = New System.Drawing.Size(96, 21)
			Me.txtDocDateEnd.TabIndex = 33
			Me.txtDocDateEnd.Text = ""
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
			Me.Validator.SetMaxValue(Me.txtDocDateStart, "")
			Me.Validator.SetMinValue(Me.txtDocDateStart, "")
			Me.txtDocDateStart.Name = "txtDocDateStart"
			Me.Validator.SetRegularExpression(Me.txtDocDateStart, "")
			Me.Validator.SetRequired(Me.txtDocDateStart, False)
			Me.txtDocDateStart.Size = New System.Drawing.Size(96, 21)
			Me.txtDocDateStart.TabIndex = 30
			Me.txtDocDateStart.Text = ""
			'
			'dtpDocDateStart
			'
			Me.dtpDocDateStart.Format = System.Windows.Forms.DateTimePickerFormat.Short
			Me.dtpDocDateStart.Location = New System.Drawing.Point(120, 16)
			Me.dtpDocDateStart.Name = "dtpDocDateStart"
			Me.dtpDocDateStart.Size = New System.Drawing.Size(120, 21)
			Me.dtpDocDateStart.TabIndex = 31
			Me.dtpDocDateStart.TabStop = False
			'
			'dtpDocDateEnd
			'
			Me.dtpDocDateEnd.Format = System.Windows.Forms.DateTimePickerFormat.Short
			Me.dtpDocDateEnd.Location = New System.Drawing.Point(280, 16)
			Me.dtpDocDateEnd.Name = "dtpDocDateEnd"
			Me.dtpDocDateEnd.Size = New System.Drawing.Size(120, 21)
			Me.dtpDocDateEnd.TabIndex = 34
			Me.dtpDocDateEnd.TabStop = False
			'
			'lblDocDateStart
			'
			Me.lblDocDateStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
			Me.lblDocDateStart.ForeColor = System.Drawing.Color.Black
			Me.lblDocDateStart.Location = New System.Drawing.Point(24, 16)
			Me.lblDocDateStart.Name = "lblDocDateStart"
			Me.lblDocDateStart.Size = New System.Drawing.Size(88, 18)
			Me.lblDocDateStart.TabIndex = 29
			Me.lblDocDateStart.Text = "ตั้งแต่"
			Me.lblDocDateStart.TextAlign = System.Drawing.ContentAlignment.MiddleRight
			'
			'lblDocDateEnd
			'
			Me.lblDocDateEnd.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
			Me.lblDocDateEnd.ForeColor = System.Drawing.Color.Black
			Me.lblDocDateEnd.Location = New System.Drawing.Point(248, 16)
			Me.lblDocDateEnd.Name = "lblDocDateEnd"
			Me.lblDocDateEnd.Size = New System.Drawing.Size(24, 18)
			Me.lblDocDateEnd.TabIndex = 32
			Me.lblDocDateEnd.Text = "ถึง"
			Me.lblDocDateEnd.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
			'
			'chkIncludeChildren
			'
			Me.chkIncludeChildren.FlatStyle = System.Windows.Forms.FlatStyle.System
			Me.chkIncludeChildren.Location = New System.Drawing.Point(120, 136)
			Me.chkIncludeChildren.Name = "chkIncludeChildren"
			Me.chkIncludeChildren.Size = New System.Drawing.Size(128, 24)
			Me.chkIncludeChildren.TabIndex = 28
			Me.chkIncludeChildren.Text = "รวม Cost Center ลูก"
			'
			'btnCCCodeStart
			'
			Me.btnCCCodeStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
			Me.btnCCCodeStart.ForeColor = System.Drawing.SystemColors.Control
			Me.btnCCCodeStart.Image = CType(resources.GetObject("btnCCCodeStart.Image"), System.Drawing.Image)
			Me.btnCCCodeStart.Location = New System.Drawing.Point(216, 112)
			Me.btnCCCodeStart.Name = "btnCCCodeStart"
			Me.btnCCCodeStart.Size = New System.Drawing.Size(24, 22)
			Me.btnCCCodeStart.TabIndex = 27
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
			Me.txtCCCodeStart.Location = New System.Drawing.Point(120, 112)
			Me.txtCCCodeStart.MaxLength = 50
			Me.Validator.SetMaxValue(Me.txtCCCodeStart, "")
			Me.Validator.SetMinValue(Me.txtCCCodeStart, "")
			Me.txtCCCodeStart.Name = "txtCCCodeStart"
			Me.Validator.SetRegularExpression(Me.txtCCCodeStart, "")
			Me.Validator.SetRequired(Me.txtCCCodeStart, False)
			Me.txtCCCodeStart.Size = New System.Drawing.Size(96, 21)
			Me.txtCCCodeStart.TabIndex = 26
			Me.txtCCCodeStart.Text = ""
			'
			'lblCCStart
			'
			Me.lblCCStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
			Me.lblCCStart.ForeColor = System.Drawing.Color.Black
			Me.lblCCStart.Location = New System.Drawing.Point(40, 112)
			Me.lblCCStart.Name = "lblCCStart"
			Me.lblCCStart.Size = New System.Drawing.Size(72, 18)
			Me.lblCCStart.TabIndex = 24
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
			Me.txtCostCenterName.Location = New System.Drawing.Point(240, 112)
			Me.txtCostCenterName.MaxLength = 50
			Me.Validator.SetMaxValue(Me.txtCostCenterName, "")
			Me.Validator.SetMinValue(Me.txtCostCenterName, "")
			Me.txtCostCenterName.Name = "txtCostCenterName"
			Me.txtCostCenterName.ReadOnly = True
			Me.Validator.SetRegularExpression(Me.txtCostCenterName, "")
			Me.Validator.SetRequired(Me.txtCostCenterName, False)
			Me.txtCostCenterName.Size = New System.Drawing.Size(160, 21)
			Me.txtCostCenterName.TabIndex = 25
			Me.txtCostCenterName.Text = ""
			'
			'btnSuppliEndFind
			'
			Me.btnSuppliEndFind.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
			Me.btnSuppliEndFind.ForeColor = System.Drawing.SystemColors.Control
			Me.btnSuppliEndFind.Image = CType(resources.GetObject("btnSuppliEndFind.Image"), System.Drawing.Image)
			Me.btnSuppliEndFind.Location = New System.Drawing.Point(376, 88)
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
			Me.txtSuppliCodeEnd.Location = New System.Drawing.Point(280, 88)
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
			Me.lblSuppliEnd.Location = New System.Drawing.Point(248, 88)
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
			Me.btnSuppliStartFind.Location = New System.Drawing.Point(216, 88)
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
			Me.txtSuppliCodeStart.Location = New System.Drawing.Point(120, 88)
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
			Me.lblSuppliStart.Location = New System.Drawing.Point(24, 88)
			Me.lblSuppliStart.Name = "lblSuppliStart"
			Me.lblSuppliStart.Size = New System.Drawing.Size(88, 18)
			Me.lblSuppliStart.TabIndex = 6
			Me.lblSuppliStart.Text = "Supplier:"
			Me.lblSuppliStart.TextAlign = System.Drawing.ContentAlignment.MiddleRight
			'
			'btnSearch
			'
			Me.btnSearch.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
			Me.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.System
			Me.btnSearch.Location = New System.Drawing.Point(360, 256)
			Me.btnSearch.Name = "btnSearch"
			Me.btnSearch.TabIndex = 2
			Me.btnSearch.Text = "ค้นหา"
			'
			'btnReset
			'
			Me.btnReset.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
			Me.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.System
			Me.btnReset.Location = New System.Drawing.Point(280, 256)
			Me.btnReset.Name = "btnReset"
			Me.btnReset.TabIndex = 1
			Me.btnReset.TabStop = False
			Me.btnReset.Text = "เคลียร์"
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
			'RptAPGLFilterSubPanel
			'
			Me.Controls.Add(Me.grbMaster)
			Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
			Me.Name = "RptAPGLFilterSubPanel"
			Me.Size = New System.Drawing.Size(472, 304)
			Me.grbMaster.ResumeLayout(False)
			Me.grbDetail.ResumeLayout(False)
			Me.ResumeLayout(False)

		End Sub

#End Region

#Region " SetLabelText "
		Public Sub SetLabelText()
			'If Not m_entity Is Nothing Then Me.Text = Me.StringParserService.Parse(Me.m_entity.TabPageText)
			Me.lblSuppliStart.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptAPFilterSubPanel.lblSuppliStart}")
			Me.Validator.SetDisplayName(txtSuppliCodeStart, lblSuppliStart.Text)

			Me.lblDocDateStart.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptAPFilterSubPanel.lblDocDateStart}")
			Me.Validator.SetDisplayName(txtDocDateStart, lblDocDateStart.Text)

			'SupplierGroup
			Me.lblSupplierGroup.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptAPFilterSubPanel.lblSupplierGroup}")
			Me.Validator.SetDisplayName(txtSupplierGroupStart, lblSupplierGroup.Text)
			Me.chkIncludeSGChildren.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptAPFilterSubPanel.chkIncludeSGChildren}")
			Me.lblCCStart.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptAPFilterSubPanel.lblCCStart}")
			Me.Validator.SetDisplayName(txtCCCodeStart, lblCCStart.Text)


			'Account
			Me.lblAcctStart.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptAPGLFilterSubPanel.lblAcctStart}")
			Me.lblAcctEnd.Text = Me.StringParserService.Parse("${res:Global.FilterPanelTo}")

			' Global {ถึง}
			Me.lblSuppliEnd.Text = Me.StringParserService.Parse("${res:Global.FilterPanelTo}")
			Me.Validator.SetDisplayName(txtSuppliCodeEnd, lblSuppliEnd.Text)

			Me.lblDocDateEnd.Text = Me.StringParserService.Parse("${res:Global.FilterPanelTo}")
			Me.Validator.SetDisplayName(txtDocDateEnd, lblDocDateEnd.Text)
			' Button
			Me.btnSearch.Text = Me.StringParserService.Parse("${res:Global.SearchButtonText}")
			Me.btnReset.Text = Me.StringParserService.Parse("${res:Global.ResetButtonText}")

			' GroupBox
			Me.grbMaster.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptAPFilterSubPanel.grbMaster}")
			Me.grbDetail.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptAPFilterSubPanel.grbDetail}")

			'Checkbox
			Me.chkIncludeChildren.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptAPFilterSubPanel.chkIncludeChildren}")
			Me.chkAPAcctOnly.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptAPGLFilterSubPanel.chkAPAcctOnly}")
		End Sub
#End Region

#Region "Member"
		Private m_supplierstart As Supplier
		Private m_supplierend As Supplier
		Private m_sg As SupplierGroup

		Private m_acctstart As Account
		Private m_acctend As Account

		Private m_DocDateEnd As Date
		Private m_DocDateStart As Date

		Private m_cc As Costcenter
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

		Public Property AcctStart() As Account
			Get
				Return m_acctstart
			End Get
			Set(ByVal Value As Account)
				m_acctstart = Value
			End Set
		End Property
		Public Property AcctEnd() As Account
			Get
				Return m_acctend
			End Get
			Set(ByVal Value As Account)
				m_acctend = Value
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
		Public Property DocDateEnd() As Date			Get				Return m_DocDateEnd			End Get			Set(ByVal Value As Date)				m_DocDateEnd = Value			End Set		End Property		Public Property DocDateStart() As Date			Get				Return m_DocDateStart			End Get			Set(ByVal Value As Date)				m_DocDateStart = Value			End Set		End Property

		Public Property Costcenter() As Costcenter
			Get
				Return m_cc
			End Get
			Set(ByVal Value As Costcenter)
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

			Me.SupplierStart = New Supplier
			Me.SupplierEnd = New Supplier
			Me.SupplierGroup = New SupplierGroup

			Me.AcctStart = New Account
			Me.AcctEnd = New Account

			Me.Costcenter = New Costcenter

			Dim dtStart As Date = Date.Now.Subtract(New TimeSpan(7, 0, 0, 0))
			Me.DocDateStart = dtStart
			Me.txtDocDateStart.Text = MinDateToNull(Me.DocDateStart, "")
			Me.dtpDocDateStart.Value = Me.DocDateStart

			Me.DocDateEnd = Date.Now
			Me.txtDocDateEnd.Text = MinDateToNull(Me.DocDateEnd, "")
			Me.dtpDocDateEnd.Value = Me.DocDateEnd

			'Me.chkIncludeRetention.Checked = False
		End Sub
		Public Overrides Function GetFilterString() As String

		End Function
		Public Overrides Function GetFilterArray() As Filter()
			Dim arr(11) As Filter
			arr(0) = New Filter("DocDateStart", IIf(Me.DocDateStart.Equals(Date.MinValue), DBNull.Value, Me.DocDateStart))
			arr(1) = New Filter("DocDateEnd", IIf(Me.DocDateEnd.Equals(Date.MinValue), DBNull.Value, Me.DocDateEnd))
			arr(2) = New Filter("SuppliCodeStart", IIf(txtSuppliCodeStart.TextLength > 0, txtSuppliCodeStart.Text, DBNull.Value))
			arr(3) = New Filter("SuppliCodeEnd", IIf(txtSuppliCodeEnd.TextLength > 0, txtSuppliCodeEnd.Text, DBNull.Value))
			arr(4) = New Filter("sg_id", Me.ValidIdOrDBNull(m_sg))
			arr(5) = New Filter("IncludeChildSG", Me.chkIncludeSGChildren.Checked)
			arr(6) = New Filter("cc_id", Me.ValidIdOrDBNull(m_cc))
			arr(7) = New Filter("IncludeChildCC", Me.chkIncludeChildren.Checked)
			'arr(8) = New Filter("IncludeRetention", Me.chkIncludeRetention.Checked)
			arr(8) = New Filter("userRight", CType(ServiceManager.Services.GetService(GetType(SecurityService)), SecurityService).CurrentUser.Id)

			arr(9) = New Filter("AcctCodeStart", IIf(txtAcctCodeStart.TextLength > 0, txtAcctCodeStart.Text, DBNull.Value))
			arr(10) = New Filter("AcctCodeEnd", IIf(txtAcctCodeEnd.TextLength > 0, txtAcctCodeEnd.Text, DBNull.Value))
			arr(11) = New Filter("APAcctOnly", Me.chkAPAcctOnly.Checked)

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

#Region "IReportFilterSubPanel"
		Public Function GetFixValueCollection() As BusinessLogic.DocPrintingItemCollection Implements IReportFilterSubPanel.GetFixValueCollection
			Dim dpiColl As New DocPrintingItemCollection
			Dim dpi As DocPrintingItem

			'Month
			dpi = New DocPrintingItem
			dpi.Mapping = "Month"
			dpi.Value = ""		'Me.cmbMonth.Text
			dpi.DataType = "System.String"
			dpiColl.Add(dpi)

			'Year
			dpi = New DocPrintingItem
			dpi.Mapping = "Year"
			dpi.Value = ""		'Me.cmbYear.Text
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

			'AccountStart
			dpi = New DocPrintingItem
			dpi.Mapping = "AccountStart"
			dpi.Value = Me.txtAcctCodeStart.Text
			dpi.DataType = "System.String"
			dpiColl.Add(dpi)

			'AccountEnd
			dpi = New DocPrintingItem
			dpi.Mapping = "AccountEnd"
			dpi.Value = Me.txtAcctCodeEnd.Text
			dpi.DataType = "System.String"
			dpiColl.Add(dpi)

			'CheckBox APAcctOnly
			If Me.chkAPAcctOnly.Checked Then
				dpi = New DocPrintingItem
				dpi.Mapping = "APAcctOnly"
				dpi.Value = "(เฉพาะผังบัญชีที่ระบุไว้กับเจ้าหนี้)"
				dpi.DataType = "System.String"
				dpiColl.Add(dpi)
			End If

			''CheckBox IncludeRetention
			'If Me.chkIncludeRetention.Checked Then
			'    dpi = New DocPrintingItem
			'    dpi.Mapping = "includeretention"
			'    dpi.Value = "(" & Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptAPFilterSubPanel.chkIncludeRetention}") & ")"
			'    dpi.DataType = "System.String"
			'    dpiColl.Add(dpi)
			'End If

			Return dpiColl
		End Function
#End Region

#Region " ChangeProperty "
		Private Sub EventWiring()
			AddHandler btnSuppliStartFind.Click, AddressOf Me.btnSupplierFind_Click
			AddHandler btnSuppliEndFind.Click, AddressOf Me.btnSupplierFind_Click

			AddHandler btnAcctCodeStartFind.Click, AddressOf Me.btnAcctCodeFind_Click
			AddHandler btnAcctCodeEndFind.Click, AddressOf Me.btnAcctCodeFind_Click

			AddHandler btnSupplierGroupStart.Click, AddressOf Me.btnSupplierGroupFind_Click
			AddHandler txtSupplierGroupStart.Validated, AddressOf Me.ChangeProperty

			'AddHandler txtSuppliCodeStart.Validated, AddressOf Me.ChangeProperty
			'AddHandler txtSuppliCodeEnd.Validated, AddressOf Me.ChangeProperty

			AddHandler btnCCCodeStart.Click, AddressOf Me.btnCostcenterFind_Click
			AddHandler txtCCCodeStart.Validated, AddressOf Me.ChangeProperty

			AddHandler txtDocDateStart.Validated, AddressOf Me.ChangeProperty
			AddHandler txtDocDateEnd.Validated, AddressOf Me.ChangeProperty

			AddHandler dtpDocDateStart.ValueChanged, AddressOf Me.ChangeProperty
			AddHandler dtpDocDateEnd.ValueChanged, AddressOf Me.ChangeProperty
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
				If data.GetDataPresent((New Costcenter).FullClassName) Then
					If Not Me.ActiveControl Is Nothing Then
						Select Case Me.ActiveControl.Name.ToLower
							Case "txtcccodestart", "txtcccodeend"
								Return True
						End Select
					End If
				End If
				' Account
				If data.GetDataPresent((New Account).FullClassName) Then
					If Not Me.ActiveControl Is Nothing Then
						Select Case Me.ActiveControl.Name.ToLower
							Case "txtacctcodestart", "txtacctcodeend"
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
			If data.GetDataPresent((New Costcenter).FullClassName) Then
				Dim id As Integer = CInt(data.GetData((New Costcenter).FullClassName))
				Dim entity As New Costcenter(id)
				If Not Me.ActiveControl Is Nothing Then
					Select Case Me.ActiveControl.Name.ToLower
						Case "txtcccodestart"
							Me.SetCCCodeStartDialog(entity)

						Case "txtcccodeend"
							Me.SetCCCodeStartDialog(entity)

					End Select
				End If
			End If

			' Account
			If data.GetDataPresent((New Account).FullClassName) Then
				Dim id As Integer = CInt(data.GetData((New Account).FullClassName))
				Dim entity As New Account(id)
				If Not Me.ActiveControl Is Nothing Then
					Select Case Me.ActiveControl.Name.ToLower
						Case "txtacctcodestart"
							Me.SetAccountStartDialog(entity)

						Case "txtacctcodeend"
							Me.SetAccountEndDialog(entity)

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
		'Account
		Private Sub btnAcctCodeFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
			Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
			Select Case CType(sender, Control).Name.ToLower
				Case "btnacctcodestartfind"
					myEntityPanelService.OpenTreeDialog(New Account, AddressOf SetAccountStartDialog)

				Case "btnacctcodeendfind"
					myEntityPanelService.OpenTreeDialog(New Account, AddressOf SetAccountEndDialog)

			End Select
		End Sub

		' Costcenter
		Private Sub btnCostcenterFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
			Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
			Select Case CType(sender, Control).Name.ToLower
				Case "btncccodestart"
					myEntityPanelService.OpenTreeDialog(New Costcenter, AddressOf SetCCCodeStartDialog)
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

		Private Sub SetAccountStartDialog(ByVal e As ISimpleEntity)
			Me.txtAcctCodeStart.Text = e.Code
			Account.GetAccount(txtAcctCodeStart, txtTemp, Me.AcctStart)
		End Sub
		Private Sub SetAccountEndDialog(ByVal e As ISimpleEntity)
			Me.txtAcctCodeEnd.Text = e.Code
			Account.GetAccount(txtAcctCodeEnd, txtTemp, Me.AcctEnd)
		End Sub

		Private Sub SetSupplierGroupStartDialog(ByVal e As ISimpleEntity)
			Me.txtSupplierGroupStart.Text = e.Code
			SupplierGroup.GetSupplierGroup(txtSupplierGroupStart, txtSupplierGroupName, m_sg)
		End Sub
		Private Sub SetCCCodeStartDialog(ByVal e As ISimpleEntity)
			Me.txtCCCodeStart.Text = e.Code
			Costcenter.GetCostCenter(txtCCCodeStart, txtCostCenterName, m_cc, CType(ServiceManager.Services.GetService(GetType(SecurityService)), SecurityService).CurrentUser.Id)
		End Sub
#End Region

	End Class
End Namespace

