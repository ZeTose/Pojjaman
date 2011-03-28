Imports Longkong.Pojjaman.BusinessLogic
Imports Longkong.Pojjaman.TextHelper
Imports Longkong.Pojjaman.Services
Imports Longkong.Pojjaman.Gui.Components
Imports Longkong.Core.Services
Imports System.Drawing.Printing
Imports Longkong.Pojjaman.Gui.ReportsAndDocs
Imports System.IO
Imports Longkong.Core.Properties
Imports Longkong.AdobeForm
Namespace Longkong.Pojjaman.Gui.Panels
	Public Class VATDetail
		Inherits AbstractEntityDetailPanelView
    Implements IValidatable, IAuxTab, IAuxTabItem

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
		Friend WithEvents lblNote As System.Windows.Forms.Label
		Friend WithEvents txtNote As System.Windows.Forms.TextBox
		Friend WithEvents lblAmount As System.Windows.Forms.Label
		Friend WithEvents txtAmount As System.Windows.Forms.TextBox
		Friend WithEvents lblBaht As System.Windows.Forms.Label
		Friend WithEvents lblBaht1 As System.Windows.Forms.Label
		Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
		Friend WithEvents Validator As Longkong.Pojjaman.Gui.Components.PJMTextboxValidator
		Friend WithEvents txtRefDocDate As System.Windows.Forms.TextBox
		Friend WithEvents lblRefDocDate As System.Windows.Forms.Label
		Friend WithEvents dtpRefDocDate As System.Windows.Forms.DateTimePicker
		Friend WithEvents lblRefDoc As System.Windows.Forms.Label
		Friend WithEvents txtRefDocCode As System.Windows.Forms.TextBox
		Friend WithEvents tgItem As Longkong.Pojjaman.Gui.Components.TreeGrid
		Friend WithEvents lblRefVAT As System.Windows.Forms.Label
		Friend WithEvents ibtnBlank As Longkong.Pojjaman.Gui.Components.ImageButton
		Friend WithEvents ibtnDelRow As Longkong.Pojjaman.Gui.Components.ImageButton
		Friend WithEvents lblStatus As System.Windows.Forms.Label
		Friend WithEvents cmbDirection As System.Windows.Forms.ComboBox
		Friend WithEvents lblDirection As System.Windows.Forms.Label
		Friend WithEvents Label2 As System.Windows.Forms.Label
		Friend WithEvents grbRefDoc As Longkong.Pojjaman.Gui.Components.FixedGroupBox
		Friend WithEvents lblTaxBase As System.Windows.Forms.Label
		Friend WithEvents txtTaxBase As System.Windows.Forms.TextBox
		Friend WithEvents lblRefTaxBase As System.Windows.Forms.Label
		Friend WithEvents txtRefTaxBase As System.Windows.Forms.TextBox
		Friend WithEvents grbSubmit As Longkong.Pojjaman.Gui.Components.FixedGroupBox
		Friend WithEvents lblSubmitalDate As System.Windows.Forms.Label
		Friend WithEvents lblVatGroup As System.Windows.Forms.Label
		Friend WithEvents txtVatGroupCode As System.Windows.Forms.TextBox
		Friend WithEvents txtVatGroupName As System.Windows.Forms.TextBox
		Friend WithEvents btnVatGroupDialog As Longkong.Pojjaman.Gui.Components.ImageButton
		Friend WithEvents btnVatGroup As Longkong.Pojjaman.Gui.Components.ImageButton
		Friend WithEvents txtSubmitalDate As System.Windows.Forms.TextBox
		Friend WithEvents dtpSubmitalDate As System.Windows.Forms.DateTimePicker
		Friend WithEvents btnSelectAll As System.Windows.Forms.Button
		<System.Diagnostics.DebuggerStepThrough()> Protected Sub InitializeComponent()
			Me.components = New System.ComponentModel.Container
			Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(VATDetail))
			Me.grbDetail = New Longkong.Pojjaman.Gui.Components.FixedGroupBox
			Me.btnSelectAll = New System.Windows.Forms.Button
			Me.grbSubmit = New Longkong.Pojjaman.Gui.Components.FixedGroupBox
			Me.lblSubmitalDate = New System.Windows.Forms.Label
			Me.txtSubmitalDate = New System.Windows.Forms.TextBox
			Me.dtpSubmitalDate = New System.Windows.Forms.DateTimePicker
			Me.lblVatGroup = New System.Windows.Forms.Label
			Me.txtVatGroupCode = New System.Windows.Forms.TextBox
			Me.txtVatGroupName = New System.Windows.Forms.TextBox
			Me.btnVatGroupDialog = New Longkong.Pojjaman.Gui.Components.ImageButton
			Me.btnVatGroup = New Longkong.Pojjaman.Gui.Components.ImageButton
			Me.grbRefDoc = New Longkong.Pojjaman.Gui.Components.FixedGroupBox
			Me.txtRefTaxBase = New System.Windows.Forms.TextBox
			Me.txtRefDocDate = New System.Windows.Forms.TextBox
			Me.lblDirection = New System.Windows.Forms.Label
			Me.lblRefTaxBase = New System.Windows.Forms.Label
			Me.lblRefDocDate = New System.Windows.Forms.Label
			Me.dtpRefDocDate = New System.Windows.Forms.DateTimePicker
			Me.txtRefDocCode = New System.Windows.Forms.TextBox
			Me.lblRefDoc = New System.Windows.Forms.Label
			Me.cmbDirection = New System.Windows.Forms.ComboBox
			Me.Label2 = New System.Windows.Forms.Label
			Me.lblStatus = New System.Windows.Forms.Label
			Me.ibtnBlank = New Longkong.Pojjaman.Gui.Components.ImageButton
			Me.ibtnDelRow = New Longkong.Pojjaman.Gui.Components.ImageButton
			Me.lblNote = New System.Windows.Forms.Label
			Me.txtNote = New System.Windows.Forms.TextBox
			Me.lblTaxBase = New System.Windows.Forms.Label
			Me.txtTaxBase = New System.Windows.Forms.TextBox
			Me.lblAmount = New System.Windows.Forms.Label
			Me.txtAmount = New System.Windows.Forms.TextBox
			Me.lblBaht = New System.Windows.Forms.Label
			Me.lblBaht1 = New System.Windows.Forms.Label
			Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider
			Me.Validator = New Longkong.Pojjaman.Gui.Components.PJMTextboxValidator(Me.components)
			Me.tgItem = New Longkong.Pojjaman.Gui.Components.TreeGrid
			Me.lblRefVAT = New System.Windows.Forms.Label
			Me.grbDetail.SuspendLayout()
			Me.grbSubmit.SuspendLayout()
			Me.grbRefDoc.SuspendLayout()
			CType(Me.tgItem, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.SuspendLayout()
			'
			'grbDetail
			'
			Me.grbDetail.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
									Or System.Windows.Forms.AnchorStyles.Left) _
									Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
			Me.grbDetail.Controls.Add(Me.btnSelectAll)
			Me.grbDetail.Controls.Add(Me.grbSubmit)
			Me.grbDetail.Controls.Add(Me.grbRefDoc)
			Me.grbDetail.Controls.Add(Me.lblStatus)
			Me.grbDetail.Controls.Add(Me.ibtnBlank)
			Me.grbDetail.Controls.Add(Me.ibtnDelRow)
			Me.grbDetail.Controls.Add(Me.lblNote)
			Me.grbDetail.Controls.Add(Me.txtNote)
			Me.grbDetail.Controls.Add(Me.lblTaxBase)
			Me.grbDetail.Controls.Add(Me.txtTaxBase)
			Me.grbDetail.Controls.Add(Me.lblAmount)
			Me.grbDetail.Controls.Add(Me.txtAmount)
			Me.grbDetail.Controls.Add(Me.lblBaht)
			Me.grbDetail.Controls.Add(Me.lblBaht1)
			Me.grbDetail.FlatStyle = System.Windows.Forms.FlatStyle.System
			Me.grbDetail.Location = New System.Drawing.Point(0, 8)
			Me.grbDetail.Name = "grbDetail"
			Me.grbDetail.Size = New System.Drawing.Size(664, 496)
			Me.grbDetail.TabIndex = 198
			Me.grbDetail.TabStop = False
			Me.grbDetail.Text = "ใบกำกับภาษีมูลค่าเพิ่ม"
			'
			'btnSelectAll
			'
			Me.btnSelectAll.FlatStyle = System.Windows.Forms.FlatStyle.System
			Me.btnSelectAll.Location = New System.Drawing.Point(192, 192)
			Me.btnSelectAll.Name = "btnSelectAll"
			Me.btnSelectAll.Size = New System.Drawing.Size(120, 23)
			Me.btnSelectAll.TabIndex = 346
			Me.btnSelectAll.Text = "เลือก/ไม่เลือกทั้งหมด"
			'
			'grbSubmit
			'
			Me.grbSubmit.Controls.Add(Me.lblSubmitalDate)
			Me.grbSubmit.Controls.Add(Me.txtSubmitalDate)
			Me.grbSubmit.Controls.Add(Me.dtpSubmitalDate)
			Me.grbSubmit.Controls.Add(Me.lblVatGroup)
			Me.grbSubmit.Controls.Add(Me.txtVatGroupCode)
			Me.grbSubmit.Controls.Add(Me.txtVatGroupName)
			Me.grbSubmit.Controls.Add(Me.btnVatGroupDialog)
			Me.grbSubmit.Controls.Add(Me.btnVatGroup)
			Me.grbSubmit.FlatStyle = System.Windows.Forms.FlatStyle.System
			Me.grbSubmit.Location = New System.Drawing.Point(16, 88)
			Me.grbSubmit.Name = "grbSubmit"
			Me.grbSubmit.Size = New System.Drawing.Size(376, 72)
			Me.grbSubmit.TabIndex = 345
			Me.grbSubmit.TabStop = False
			Me.grbSubmit.Text = "การยื่นภาษี"
			'
			'lblSubmitalDate
			'
			Me.lblSubmitalDate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
			Me.lblSubmitalDate.ForeColor = System.Drawing.Color.Black
			Me.lblSubmitalDate.Location = New System.Drawing.Point(16, 16)
			Me.lblSubmitalDate.Name = "lblSubmitalDate"
			Me.lblSubmitalDate.Size = New System.Drawing.Size(104, 18)
			Me.lblSubmitalDate.TabIndex = 342
			Me.lblSubmitalDate.Text = "วันที่ยื่น:"
			Me.lblSubmitalDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight
			'
			'txtSubmitalDate
			'
			Me.Validator.SetDataType(Me.txtSubmitalDate, Longkong.Pojjaman.Gui.Components.DataTypeConstants.DateTimeType)
			Me.Validator.SetDisplayName(Me.txtSubmitalDate, "")
			Me.Validator.SetGotFocusBackColor(Me.txtSubmitalDate, System.Drawing.Color.Empty)
			Me.ErrorProvider1.SetIconPadding(Me.txtSubmitalDate, 23)
			Me.Validator.SetInvalidBackColor(Me.txtSubmitalDate, System.Drawing.Color.Empty)
			Me.txtSubmitalDate.Location = New System.Drawing.Point(128, 16)
			Me.Validator.SetMaxValue(Me.txtSubmitalDate, "")
			Me.Validator.SetMinValue(Me.txtSubmitalDate, "")
			Me.txtSubmitalDate.Name = "txtSubmitalDate"
			Me.Validator.SetRegularExpression(Me.txtSubmitalDate, "")
			Me.Validator.SetRequired(Me.txtSubmitalDate, False)
			Me.txtSubmitalDate.Size = New System.Drawing.Size(124, 20)
			Me.txtSubmitalDate.TabIndex = 341
			Me.txtSubmitalDate.Text = ""
			'
			'dtpSubmitalDate
			'
			Me.dtpSubmitalDate.CustomFormat = "dd/MM/yyyy"
			Me.dtpSubmitalDate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
			Me.dtpSubmitalDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
			Me.dtpSubmitalDate.Location = New System.Drawing.Point(128, 16)
			Me.dtpSubmitalDate.Name = "dtpSubmitalDate"
			Me.dtpSubmitalDate.Size = New System.Drawing.Size(144, 21)
			Me.dtpSubmitalDate.TabIndex = 343
			Me.dtpSubmitalDate.TabStop = False
			'
			'lblVatGroup
			'
			Me.lblVatGroup.BackColor = System.Drawing.Color.Transparent
			Me.lblVatGroup.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
			Me.lblVatGroup.Location = New System.Drawing.Point(0, 40)
			Me.lblVatGroup.Name = "lblVatGroup"
			Me.lblVatGroup.Size = New System.Drawing.Size(120, 18)
			Me.lblVatGroup.TabIndex = 346
			Me.lblVatGroup.Text = "กลุ่มภาษี:"
			Me.lblVatGroup.TextAlign = System.Drawing.ContentAlignment.MiddleRight
			'
			'txtVatGroupCode
			'
			Me.txtVatGroupCode.BackColor = System.Drawing.SystemColors.Window
			Me.Validator.SetDataType(Me.txtVatGroupCode, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
			Me.Validator.SetDisplayName(Me.txtVatGroupCode, "")
			Me.Validator.SetGotFocusBackColor(Me.txtVatGroupCode, System.Drawing.Color.Empty)
			Me.Validator.SetInvalidBackColor(Me.txtVatGroupCode, System.Drawing.Color.Empty)
			Me.txtVatGroupCode.Location = New System.Drawing.Point(128, 40)
			Me.txtVatGroupCode.MaxLength = 20
			Me.Validator.SetMaxValue(Me.txtVatGroupCode, "")
			Me.Validator.SetMinValue(Me.txtVatGroupCode, "")
			Me.txtVatGroupCode.Name = "txtVatGroupCode"
			Me.Validator.SetRegularExpression(Me.txtVatGroupCode, "")
			Me.Validator.SetRequired(Me.txtVatGroupCode, False)
			Me.txtVatGroupCode.Size = New System.Drawing.Size(68, 20)
			Me.txtVatGroupCode.TabIndex = 345
			Me.txtVatGroupCode.Text = ""
			'
			'txtVatGroupName
			'
			Me.txtVatGroupName.BackColor = System.Drawing.SystemColors.Control
			Me.Validator.SetDataType(Me.txtVatGroupName, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
			Me.Validator.SetDisplayName(Me.txtVatGroupName, "")
			Me.Validator.SetGotFocusBackColor(Me.txtVatGroupName, System.Drawing.Color.Empty)
			Me.Validator.SetInvalidBackColor(Me.txtVatGroupName, System.Drawing.Color.Empty)
			Me.txtVatGroupName.Location = New System.Drawing.Point(192, 40)
			Me.Validator.SetMaxValue(Me.txtVatGroupName, "")
			Me.Validator.SetMinValue(Me.txtVatGroupName, "")
			Me.txtVatGroupName.Name = "txtVatGroupName"
			Me.txtVatGroupName.ReadOnly = True
			Me.Validator.SetRegularExpression(Me.txtVatGroupName, "")
			Me.Validator.SetRequired(Me.txtVatGroupName, False)
			Me.txtVatGroupName.Size = New System.Drawing.Size(125, 20)
			Me.txtVatGroupName.TabIndex = 349
			Me.txtVatGroupName.TabStop = False
			Me.txtVatGroupName.Text = ""
			'
			'btnVatGroupDialog
			'
			Me.btnVatGroupDialog.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
			Me.btnVatGroupDialog.ForeColor = System.Drawing.SystemColors.Control
			Me.btnVatGroupDialog.Image = CType(resources.GetObject("btnVatGroupDialog.Image"), System.Drawing.Image)
			Me.btnVatGroupDialog.Location = New System.Drawing.Point(320, 39)
			Me.btnVatGroupDialog.Name = "btnVatGroupDialog"
			Me.btnVatGroupDialog.Size = New System.Drawing.Size(24, 23)
			Me.btnVatGroupDialog.TabIndex = 347
			Me.btnVatGroupDialog.TabStop = False
			Me.btnVatGroupDialog.ThemedImage = CType(resources.GetObject("btnVatGroupDialog.ThemedImage"), System.Drawing.Bitmap)
			'
			'btnVatGroup
			'
			Me.btnVatGroup.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
			Me.btnVatGroup.ForeColor = System.Drawing.SystemColors.Control
			Me.btnVatGroup.Image = CType(resources.GetObject("btnVatGroup.Image"), System.Drawing.Image)
			Me.btnVatGroup.Location = New System.Drawing.Point(344, 39)
			Me.btnVatGroup.Name = "btnVatGroup"
			Me.btnVatGroup.Size = New System.Drawing.Size(24, 23)
			Me.btnVatGroup.TabIndex = 348
			Me.btnVatGroup.TabStop = False
			Me.btnVatGroup.ThemedImage = CType(resources.GetObject("btnVatGroup.ThemedImage"), System.Drawing.Bitmap)
			'
			'grbRefDoc
			'
			Me.grbRefDoc.Controls.Add(Me.txtRefTaxBase)
			Me.grbRefDoc.Controls.Add(Me.txtRefDocDate)
			Me.grbRefDoc.Controls.Add(Me.lblDirection)
			Me.grbRefDoc.Controls.Add(Me.lblRefTaxBase)
			Me.grbRefDoc.Controls.Add(Me.lblRefDocDate)
			Me.grbRefDoc.Controls.Add(Me.dtpRefDocDate)
			Me.grbRefDoc.Controls.Add(Me.txtRefDocCode)
			Me.grbRefDoc.Controls.Add(Me.lblRefDoc)
			Me.grbRefDoc.Controls.Add(Me.cmbDirection)
			Me.grbRefDoc.Controls.Add(Me.Label2)
			Me.grbRefDoc.FlatStyle = System.Windows.Forms.FlatStyle.System
			Me.grbRefDoc.Location = New System.Drawing.Point(16, 16)
			Me.grbRefDoc.Name = "grbRefDoc"
			Me.grbRefDoc.Size = New System.Drawing.Size(576, 72)
			Me.grbRefDoc.TabIndex = 281
			Me.grbRefDoc.TabStop = False
			Me.grbRefDoc.Text = "เอกสารอ้างอิง"
			'
			'txtRefTaxBase
			'
			Me.txtRefTaxBase.BackColor = System.Drawing.SystemColors.Control
			Me.Validator.SetDataType(Me.txtRefTaxBase, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
			Me.Validator.SetDisplayName(Me.txtRefTaxBase, "")
			Me.txtRefTaxBase.Enabled = False
			Me.txtRefTaxBase.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
			Me.Validator.SetGotFocusBackColor(Me.txtRefTaxBase, System.Drawing.Color.Empty)
			Me.Validator.SetInvalidBackColor(Me.txtRefTaxBase, System.Drawing.Color.Empty)
			Me.txtRefTaxBase.Location = New System.Drawing.Point(384, 39)
			Me.Validator.SetMaxValue(Me.txtRefTaxBase, "")
			Me.Validator.SetMinValue(Me.txtRefTaxBase, "")
			Me.txtRefTaxBase.Name = "txtRefTaxBase"
			Me.Validator.SetRegularExpression(Me.txtRefTaxBase, "")
			Me.Validator.SetRequired(Me.txtRefTaxBase, False)
			Me.txtRefTaxBase.Size = New System.Drawing.Size(144, 21)
			Me.txtRefTaxBase.TabIndex = 189
			Me.txtRefTaxBase.TabStop = False
			Me.txtRefTaxBase.Text = ""
			'
			'txtRefDocDate
			'
			Me.txtRefDocDate.BackColor = System.Drawing.SystemColors.Control
			Me.Validator.SetDataType(Me.txtRefDocDate, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
			Me.Validator.SetDisplayName(Me.txtRefDocDate, "")
			Me.txtRefDocDate.Enabled = False
			Me.Validator.SetGotFocusBackColor(Me.txtRefDocDate, System.Drawing.Color.Empty)
			Me.ErrorProvider1.SetIconPadding(Me.txtRefDocDate, 15)
			Me.Validator.SetInvalidBackColor(Me.txtRefDocDate, System.Drawing.Color.Empty)
			Me.txtRefDocDate.Location = New System.Drawing.Point(384, 16)
			Me.Validator.SetMaxValue(Me.txtRefDocDate, "")
			Me.Validator.SetMinValue(Me.txtRefDocDate, "")
			Me.txtRefDocDate.Name = "txtRefDocDate"
			Me.Validator.SetRegularExpression(Me.txtRefDocDate, "")
			Me.Validator.SetRequired(Me.txtRefDocDate, False)
			Me.txtRefDocDate.Size = New System.Drawing.Size(124, 20)
			Me.txtRefDocDate.TabIndex = 275
			Me.txtRefDocDate.TabStop = False
			Me.txtRefDocDate.Text = ""
			'
			'lblDirection
			'
			Me.lblDirection.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
			Me.lblDirection.ForeColor = System.Drawing.Color.Black
			Me.lblDirection.Location = New System.Drawing.Point(24, 40)
			Me.lblDirection.Name = "lblDirection"
			Me.lblDirection.Size = New System.Drawing.Size(88, 18)
			Me.lblDirection.TabIndex = 190
			Me.lblDirection.Text = "ประเภทภาษี:"
			Me.lblDirection.TextAlign = System.Drawing.ContentAlignment.MiddleRight
			'
			'lblRefTaxBase
			'
			Me.lblRefTaxBase.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
			Me.lblRefTaxBase.ForeColor = System.Drawing.Color.Black
			Me.lblRefTaxBase.Location = New System.Drawing.Point(200, 40)
			Me.lblRefTaxBase.Name = "lblRefTaxBase"
			Me.lblRefTaxBase.Size = New System.Drawing.Size(176, 18)
			Me.lblRefTaxBase.TabIndex = 191
			Me.lblRefTaxBase.Text = "มูลค่าสินค้า/บริการ:"
			Me.lblRefTaxBase.TextAlign = System.Drawing.ContentAlignment.MiddleRight
			'
			'lblRefDocDate
			'
			Me.lblRefDocDate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
			Me.lblRefDocDate.ForeColor = System.Drawing.SystemColors.WindowText
			Me.lblRefDocDate.Location = New System.Drawing.Point(256, 17)
			Me.lblRefDocDate.Name = "lblRefDocDate"
			Me.lblRefDocDate.Size = New System.Drawing.Size(120, 18)
			Me.lblRefDocDate.TabIndex = 277
			Me.lblRefDocDate.Text = "วันที่:"
			Me.lblRefDocDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight
			'
			'dtpRefDocDate
			'
			Me.dtpRefDocDate.CustomFormat = "dd/MM/yyyy"
			Me.dtpRefDocDate.Enabled = False
			Me.dtpRefDocDate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
			Me.dtpRefDocDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
			Me.dtpRefDocDate.Location = New System.Drawing.Point(384, 16)
			Me.dtpRefDocDate.Name = "dtpRefDocDate"
			Me.dtpRefDocDate.Size = New System.Drawing.Size(144, 21)
			Me.dtpRefDocDate.TabIndex = 276
			Me.dtpRefDocDate.TabStop = False
			'
			'txtRefDocCode
			'
			Me.txtRefDocCode.BackColor = System.Drawing.SystemColors.Control
			Me.Validator.SetDataType(Me.txtRefDocCode, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
			Me.Validator.SetDisplayName(Me.txtRefDocCode, "")
			Me.txtRefDocCode.Enabled = False
			Me.Validator.SetGotFocusBackColor(Me.txtRefDocCode, System.Drawing.Color.Empty)
			Me.Validator.SetInvalidBackColor(Me.txtRefDocCode, System.Drawing.Color.Empty)
			Me.txtRefDocCode.Location = New System.Drawing.Point(112, 16)
			Me.Validator.SetMaxValue(Me.txtRefDocCode, "")
			Me.Validator.SetMinValue(Me.txtRefDocCode, "")
			Me.txtRefDocCode.Name = "txtRefDocCode"
			Me.Validator.SetRegularExpression(Me.txtRefDocCode, "")
			Me.Validator.SetRequired(Me.txtRefDocCode, False)
			Me.txtRefDocCode.Size = New System.Drawing.Size(144, 20)
			Me.txtRefDocCode.TabIndex = 273
			Me.txtRefDocCode.TabStop = False
			Me.txtRefDocCode.Text = ""
			'
			'lblRefDoc
			'
			Me.lblRefDoc.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
			Me.lblRefDoc.Location = New System.Drawing.Point(8, 17)
			Me.lblRefDoc.Name = "lblRefDoc"
			Me.lblRefDoc.Size = New System.Drawing.Size(104, 18)
			Me.lblRefDoc.TabIndex = 274
			Me.lblRefDoc.Text = "เลขที่เอกสารอ้างอิง:"
			Me.lblRefDoc.TextAlign = System.Drawing.ContentAlignment.MiddleRight
			'
			'cmbDirection
			'
			Me.cmbDirection.BackColor = System.Drawing.SystemColors.Control
			Me.cmbDirection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
			Me.cmbDirection.Enabled = False
			Me.cmbDirection.Location = New System.Drawing.Point(112, 39)
			Me.cmbDirection.Name = "cmbDirection"
			Me.cmbDirection.Size = New System.Drawing.Size(80, 21)
			Me.cmbDirection.TabIndex = 194
			Me.cmbDirection.TabStop = False
			'
			'Label2
			'
			Me.Label2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
			Me.Label2.ForeColor = System.Drawing.Color.Black
			Me.Label2.Location = New System.Drawing.Point(528, 40)
			Me.Label2.Name = "Label2"
			Me.Label2.Size = New System.Drawing.Size(32, 18)
			Me.Label2.TabIndex = 190
			Me.Label2.Text = "บาท"
			Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
			'
			'lblStatus
			'
			Me.lblStatus.AutoSize = True
			Me.lblStatus.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
			Me.lblStatus.Location = New System.Drawing.Point(24, 168)
			Me.lblStatus.Name = "lblStatus"
			Me.lblStatus.Size = New System.Drawing.Size(35, 17)
			Me.lblStatus.TabIndex = 280
			Me.lblStatus.Text = "Status"
			Me.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleRight
			'
			'ibtnBlank
			'
			Me.ibtnBlank.Image = CType(resources.GetObject("ibtnBlank.Image"), System.Drawing.Image)
			Me.ibtnBlank.Location = New System.Drawing.Point(136, 192)
			Me.ibtnBlank.Name = "ibtnBlank"
			Me.ibtnBlank.Size = New System.Drawing.Size(24, 24)
			Me.ibtnBlank.TabIndex = 279
			Me.ibtnBlank.TabStop = False
			Me.ibtnBlank.ThemedImage = CType(resources.GetObject("ibtnBlank.ThemedImage"), System.Drawing.Bitmap)
			'
			'ibtnDelRow
			'
			Me.ibtnDelRow.Image = CType(resources.GetObject("ibtnDelRow.Image"), System.Drawing.Image)
			Me.ibtnDelRow.Location = New System.Drawing.Point(160, 192)
			Me.ibtnDelRow.Name = "ibtnDelRow"
			Me.ibtnDelRow.Size = New System.Drawing.Size(24, 24)
			Me.ibtnDelRow.TabIndex = 278
			Me.ibtnDelRow.TabStop = False
			Me.ibtnDelRow.ThemedImage = CType(resources.GetObject("ibtnDelRow.ThemedImage"), System.Drawing.Bitmap)
			'
			'lblNote
			'
			Me.lblNote.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
			Me.lblNote.ForeColor = System.Drawing.Color.Black
			Me.lblNote.Location = New System.Drawing.Point(400, 96)
			Me.lblNote.Name = "lblNote"
			Me.lblNote.Size = New System.Drawing.Size(80, 18)
			Me.lblNote.TabIndex = 191
			Me.lblNote.Text = "หมายเหตุ:"
			Me.lblNote.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
			'
			'txtNote
			'
			Me.Validator.SetDataType(Me.txtNote, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
			Me.Validator.SetDisplayName(Me.txtNote, "")
			Me.txtNote.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
			Me.Validator.SetGotFocusBackColor(Me.txtNote, System.Drawing.Color.Empty)
			Me.Validator.SetInvalidBackColor(Me.txtNote, System.Drawing.Color.Empty)
			Me.txtNote.Location = New System.Drawing.Point(400, 120)
			Me.Validator.SetMaxValue(Me.txtNote, "")
			Me.Validator.SetMinValue(Me.txtNote, "")
			Me.txtNote.Multiline = True
			Me.txtNote.Name = "txtNote"
			Me.Validator.SetRegularExpression(Me.txtNote, "")
			Me.Validator.SetRequired(Me.txtNote, False)
			Me.txtNote.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
			Me.txtNote.Size = New System.Drawing.Size(256, 42)
			Me.txtNote.TabIndex = 189
			Me.txtNote.TabStop = False
			Me.txtNote.Text = ""
			'
			'lblTaxBase
			'
			Me.lblTaxBase.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
			Me.lblTaxBase.ForeColor = System.Drawing.Color.Black
			Me.lblTaxBase.Location = New System.Drawing.Point(408, 169)
			Me.lblTaxBase.Name = "lblTaxBase"
			Me.lblTaxBase.Size = New System.Drawing.Size(104, 18)
			Me.lblTaxBase.TabIndex = 191
			Me.lblTaxBase.Text = "มูลค่าสินค้า/บริการ:"
			Me.lblTaxBase.TextAlign = System.Drawing.ContentAlignment.MiddleRight
			'
			'txtTaxBase
			'
			Me.Validator.SetDataType(Me.txtTaxBase, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
			Me.Validator.SetDisplayName(Me.txtTaxBase, "")
			Me.txtTaxBase.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
			Me.Validator.SetGotFocusBackColor(Me.txtTaxBase, System.Drawing.Color.Empty)
			Me.Validator.SetInvalidBackColor(Me.txtTaxBase, System.Drawing.Color.Empty)
			Me.txtTaxBase.Location = New System.Drawing.Point(512, 168)
			Me.Validator.SetMaxValue(Me.txtTaxBase, "")
			Me.Validator.SetMinValue(Me.txtTaxBase, "")
			Me.txtTaxBase.Name = "txtTaxBase"
			Me.txtTaxBase.ReadOnly = True
			Me.Validator.SetRegularExpression(Me.txtTaxBase, "")
			Me.Validator.SetRequired(Me.txtTaxBase, False)
			Me.txtTaxBase.Size = New System.Drawing.Size(104, 21)
			Me.txtTaxBase.TabIndex = 189
			Me.txtTaxBase.TabStop = False
			Me.txtTaxBase.Text = ""
			'
			'lblAmount
			'
			Me.lblAmount.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
			Me.lblAmount.ForeColor = System.Drawing.Color.Black
			Me.lblAmount.Location = New System.Drawing.Point(408, 192)
			Me.lblAmount.Name = "lblAmount"
			Me.lblAmount.Size = New System.Drawing.Size(104, 18)
			Me.lblAmount.TabIndex = 191
			Me.lblAmount.Text = "เงินภาษี:"
			Me.lblAmount.TextAlign = System.Drawing.ContentAlignment.MiddleRight
			'
			'txtAmount
			'
			Me.Validator.SetDataType(Me.txtAmount, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
			Me.Validator.SetDisplayName(Me.txtAmount, "")
			Me.txtAmount.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
			Me.Validator.SetGotFocusBackColor(Me.txtAmount, System.Drawing.Color.Empty)
			Me.Validator.SetInvalidBackColor(Me.txtAmount, System.Drawing.Color.Empty)
			Me.txtAmount.Location = New System.Drawing.Point(512, 192)
			Me.Validator.SetMaxValue(Me.txtAmount, "")
			Me.Validator.SetMinValue(Me.txtAmount, "")
			Me.txtAmount.Name = "txtAmount"
			Me.txtAmount.ReadOnly = True
			Me.Validator.SetRegularExpression(Me.txtAmount, "")
			Me.Validator.SetRequired(Me.txtAmount, False)
			Me.txtAmount.Size = New System.Drawing.Size(104, 21)
			Me.txtAmount.TabIndex = 189
			Me.txtAmount.TabStop = False
			Me.txtAmount.Text = ""
			'
			'lblBaht
			'
			Me.lblBaht.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
			Me.lblBaht.ForeColor = System.Drawing.Color.Black
			Me.lblBaht.Location = New System.Drawing.Point(624, 169)
			Me.lblBaht.Name = "lblBaht"
			Me.lblBaht.Size = New System.Drawing.Size(32, 18)
			Me.lblBaht.TabIndex = 190
			Me.lblBaht.Text = "บาท"
			Me.lblBaht.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
			'
			'lblBaht1
			'
			Me.lblBaht1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
			Me.lblBaht1.ForeColor = System.Drawing.Color.Black
			Me.lblBaht1.Location = New System.Drawing.Point(624, 192)
			Me.lblBaht1.Name = "lblBaht1"
			Me.lblBaht1.Size = New System.Drawing.Size(32, 18)
			Me.lblBaht1.TabIndex = 190
			Me.lblBaht1.Text = "บาท"
			Me.lblBaht1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
			'
			'ErrorProvider1
			'
			Me.ErrorProvider1.ContainerControl = Me
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
			'tgItem
			'
			Me.tgItem.AllowNew = False
			Me.tgItem.AllowSorting = False
			Me.tgItem.AlternatingBackColor = System.Drawing.SystemColors.Info
			Me.tgItem.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
									Or System.Windows.Forms.AnchorStyles.Left) _
									Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
			Me.tgItem.AutoColumnResize = True
			Me.tgItem.CaptionVisible = False
			Me.tgItem.Cellchanged = False
			Me.tgItem.DataMember = ""
			Me.tgItem.HeaderForeColor = System.Drawing.SystemColors.ControlText
			Me.tgItem.Location = New System.Drawing.Point(8, 224)
			Me.tgItem.Name = "tgItem"
			Me.tgItem.Size = New System.Drawing.Size(648, 272)
			Me.tgItem.SortingArrowColor = System.Drawing.Color.Red
			Me.tgItem.TabIndex = 261
			Me.tgItem.TreeManager = Nothing
			'
			'lblRefVAT
			'
			Me.lblRefVAT.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
			Me.lblRefVAT.Location = New System.Drawing.Point(8, 208)
			Me.lblRefVAT.Name = "lblRefVAT"
			Me.lblRefVAT.Size = New System.Drawing.Size(128, 18)
			Me.lblRefVAT.TabIndex = 260
			Me.lblRefVAT.Text = "รายการใบกำกับภาษี"
			Me.lblRefVAT.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
			'
			'VATDetail
			'
			Me.Controls.Add(Me.tgItem)
			Me.Controls.Add(Me.lblRefVAT)
			Me.Controls.Add(Me.grbDetail)
			Me.Name = "VATDetail"
			Me.Size = New System.Drawing.Size(672, 512)
			Me.grbDetail.ResumeLayout(False)
			Me.grbSubmit.ResumeLayout(False)
			Me.grbRefDoc.ResumeLayout(False)
			CType(Me.tgItem, System.ComponentModel.ISupportInitialize).EndInit()
			Me.ResumeLayout(False)

		End Sub

#End Region

#Region "Members"
		Private m_entity As ISimpleEntity
		Private m_isInitialized As Boolean = False
		Private m_treeManager As TreeManager
		Private m_vat As Vat

		Private m_tableStyleEnable As Hashtable

		Private m_enableState As Hashtable
#End Region

#Region "Constructors"
		Public Sub New()
			MyBase.New()
			Me.InitializeComponent()
			Me.SetLabelText()
			Initialize()

			SaveEnableState()
			m_tableStyleEnable = New Hashtable

			Dim dt As TreeTable = Vat.GetSchemaTable()
			Dim dst As DataGridTableStyle = Me.CreateTableStyle()
			m_treeManager = New TreeManager(dt, tgItem)
			m_treeManager.SetTableStyle(dst)
			m_treeManager.AllowSorting = False
			m_treeManager.AllowDelete = False
			tgItem.AllowNew = False

			AddHandler dt.ColumnChanging, AddressOf ItemTreetable_ColumnChanging
			AddHandler dt.ColumnChanged, AddressOf ItemTreetable_ColumnChanged
			AddHandler dt.RowDeleted, AddressOf VatItemDelete

			EventWiring()

		End Sub
		Private Sub SaveEnableState()
			m_enableState = New Hashtable
			For Each ctrl As Control In Me.grbDetail.Controls
				m_enableState.Add(ctrl, ctrl.Enabled)
			Next
		End Sub
#End Region

#Region "Style"
		Public Function CreateTableStyle() As DataGridTableStyle
			Dim dst As New DataGridTableStyle
			dst.MappingName = "Vat"
			Dim myStringParserService As StringParserService = CType(ServiceManager.Services.GetService(GetType(StringParserService)), StringParserService)

			Dim csSelected As New DataGridCheckBoxColumn
			csSelected.MappingName = "Selected"
			csSelected.HeaderText = ""
			'AddHandler csSelected.Click, AddressOf RowIcon_Click

			Dim csLineNumber As New TreeTextColumn
			csLineNumber.MappingName = "vati_linenumber"
			csLineNumber.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.VatDetail.LineNumberHeaderText}")
			csLineNumber.NullText = ""
			csLineNumber.Width = 30
			csLineNumber.DataAlignment = HorizontalAlignment.Center
			csLineNumber.ReadOnly = True
			csLineNumber.TextBox.Name = "vati_linenumber"

			Dim csRunNumber As New TreeTextColumn
			csRunNumber.MappingName = "vati_runnumber"
			csRunNumber.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.VatDetail.RunHeaderText}")
			csRunNumber.NullText = ""
			csRunNumber.Width = 60
			csRunNumber.TextBox.Name = "vati_runnumber"
			'csRunNumber.ReadOnly = True

			Dim csCode As New TreeTextColumn
			csCode.MappingName = "vati_code"
			csCode.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.VatDetail.CodeHeaderText}")
			csCode.NullText = ""
			csCode.Width = 60
			csCode.TextBox.Name = "vati_code"

			Dim csDocDate As New DataGridTimePickerColumn
			csDocDate.MappingName = "vati_docdate"
			csDocDate.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.VatDetail.DocDateHeaderText}")
			csDocDate.NullText = ""
			csDocDate.Width = 100

			Dim csSupplierButton As New DataGridButtonColumn
			csSupplierButton.MappingName = "SupplierButton"
			csSupplierButton.HeaderText = ""
			csSupplierButton.NullText = ""
			AddHandler csSupplierButton.Click, AddressOf SupplierButtonClick

			Dim csPrintName As New TreeTextColumn
			csPrintName.MappingName = "vati_printname"
			csPrintName.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.VatDetail.PrintNameHeaderText}")
			csPrintName.NullText = ""
			csPrintName.Width = 100
			csPrintName.TextBox.Name = "vati_printname"

			Dim csPrintAddress As New TreeTextColumn
			csPrintAddress.MappingName = "vati_printaddress"
			csPrintAddress.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.VatDetail.PrintAddressHeaderText}")
			csPrintAddress.NullText = ""
			csPrintAddress.Width = 180
			csPrintAddress.TextBox.Name = "vati_printaddress"

			Dim csTaxBase As New TreeTextColumn
			csTaxBase.MappingName = "vati_taxbase"
			csTaxBase.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.VatDetail.TaxBaseHeaderText}")
			csTaxBase.NullText = ""
			csTaxBase.DataAlignment = HorizontalAlignment.Right
			csTaxBase.Format = "#,###.##"
			csTaxBase.TextBox.Name = "vati_taxbase"
			csTaxBase.Width = 60

			Dim csTaxRate As New TreeTextColumn
			csTaxRate.MappingName = "vati_taxrate"
			csTaxRate.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.VatDetail.TaxRateHeaderText}")
			csTaxRate.NullText = ""
			csTaxRate.DataAlignment = HorizontalAlignment.Right
			csTaxRate.Format = "#,###.##"
			csTaxRate.TextBox.Name = "vati_taxrate"
			csTaxRate.Width = 60
			csTaxRate.ReadOnly = True


			Dim csAmount As New TreeTextColumn
			csAmount.MappingName = "Amount"
			csAmount.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.VatDetail.AmountHeaderText}")
			csAmount.NullText = ""
			csAmount.DataAlignment = HorizontalAlignment.Right
			csAmount.Format = "#,###.##"
			csAmount.TextBox.Name = "Amount"
			csAmount.Width = 60

			Dim csNote As New TreeTextColumn
			csNote.MappingName = "vati_note"
			csNote.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.VatDetail.NoteHeaderText}")
			csNote.NullText = ""
			csNote.Width = 100
			csNote.TextBox.Name = "vati_note"

			dst.GridColumnStyles.Add(csLineNumber)
			dst.GridColumnStyles.Add(csSelected)
			dst.GridColumnStyles.Add(csRunNumber)
			dst.GridColumnStyles.Add(csCode)
			dst.GridColumnStyles.Add(csDocDate)
			dst.GridColumnStyles.Add(csSupplierButton)
			dst.GridColumnStyles.Add(csPrintName)
			dst.GridColumnStyles.Add(csPrintAddress)
			dst.GridColumnStyles.Add(csTaxBase)
			dst.GridColumnStyles.Add(csTaxRate)
			dst.GridColumnStyles.Add(csAmount)
			dst.GridColumnStyles.Add(csNote)

			For Each colStyle As DataGridColumnStyle In dst.GridColumnStyles
				m_tableStyleEnable.Add(colStyle, colStyle.ReadOnly)
			Next
			Return dst
		End Function
		Private Sub RowIcon_Click(ByVal e As ButtonColumnEventArgs)
			Dim myTable As TreeTable = Me.m_treeManager.Treetable
			'******************************************************************************
			Dim clickedRow As TreeRow = CType(myTable.Rows(e.Row), TreeRow)
			If CBool(clickedRow("Selected")) Then
				TreeRow.TraverseRow(clickedRow, AddressOf CheckRow)
			Else
				TreeRow.TraverseRow(clickedRow, AddressOf UnCheckRow)
			End If
			'***************ถ้าไม่ AccepChanges จะเพี้ยน*************
			Me.m_treeManager.Treetable.AcceptChanges()
			'Me.tgItem.RefreshHeights()
			'******************************************************************************
		End Sub
		Private Sub CheckRow(ByVal tr As TreeRow)
			tr("Selected") = True
		End Sub
		Private Sub UnCheckRow(ByVal tr As TreeRow)
			tr("Selected") = False
		End Sub
		Private m_allSelected As Boolean = False
		Private Sub btnSelectAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSelectAll.Click
			m_allSelected = Not m_allSelected
			For i As Integer = 0 To Me.m_vat.ItemCollection.Count - 1
				m_treeManager.Treetable.Rows(i)("Selected") = m_allSelected
			Next
		End Sub

#End Region

#Region "Properties"
		Private ReadOnly Property CurrentItem() As VatItem
			Get
				Dim row As TreeRow = Me.m_treeManager.SelectedRow
				If row Is Nothing Then
					Return Nothing
				End If
				If Not TypeOf row.Tag Is VatItem Then
					Return Nothing
				End If
				Return CType(row.Tag, VatItem)
			End Get
		End Property
#End Region

#Region "ItemTreeTable Handlers"
		Private Sub ItemTreetable_ColumnChanged(ByVal sender As Object, ByVal e As System.Data.DataColumnChangeEventArgs)
			If Not m_isInitialized OrElse e.Column.ColumnName.ToLower = "selected" Then
				Return
			End If
			Me.WorkbenchWindow.ViewContent.IsDirty = True
			Dim index As Integer = Me.tgItem.CurrentRowIndex
			RefreshDocs()
			tgItem.CurrentRowIndex = index
		End Sub
		Private Sub ItemTreetable_ColumnChanging(ByVal sender As Object, ByVal e As System.Data.DataColumnChangeEventArgs)
			If Not m_isInitialized OrElse e.Column.ColumnName.ToLower = "selected" Then
				Return
			End If
			If Me.m_treeManager.SelectedRow Is Nothing Then
				Return
			End If
			Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
			If Me.m_entity Is Nothing Then
				Return
			End If

			Dim doc As VatItem = Me.CurrentItem

			If TypeOf m_entity Is ReceiveSelection Then

				If doc Is Nothing Then
					doc = New VatItem

					If Me.m_vat.ItemCollection.Count.Equals(0) Then
						If Me.m_vat.RefDoc.GetMaximumTaxBase - Me.m_vat.RefDoc.TaxBase > 0 Then
							doc.TaxBase = Me.m_vat.RefDoc.GetMaximumTaxBase - Me.m_vat.RefDoc.TaxBase
							Me.m_vat.ItemCollection.Add(doc)
						Else
							msgServ.ShowMessage("${res:Global.Error.MaximumTaxBase}")
							Return
						End If
					Else
						Dim mVat As Decimal = 0
						For Each row As TreeRow In Me.m_treeManager.Treetable.Rows
							If IsNumeric(row("vati_taxbase")) Then
								mVat += CDec(row("vati_taxbase"))
							End If
						Next
						If Me.m_vat.VatTaxBase - mVat > 0 Then
							doc.TaxBase = Me.m_vat.VatTaxBase - mVat
							Me.m_vat.ItemCollection.Add(doc)
						Else
							msgServ.ShowMessageFormatted("${res:Global.Error.OverTaxBase}", New String() {Configuration.FormatToString(Me.m_vat.VatTaxBase, DigitConfig.Price)})
							Return
						End If

					End If

					Me.m_treeManager.SelectedRow.Tag = doc
				End If
			Else
				If doc Is Nothing Then
					doc = New VatItem
					Me.m_vat.ItemCollection.Add(doc)
					Me.m_treeManager.SelectedRow.Tag = doc
				End If
			End If

			Try
				Select Case e.Column.ColumnName.ToLower
					Case "vati_runnumber"
						If IsDBNull(e.ProposedValue) OrElse e.ProposedValue Is Nothing Then
							e.ProposedValue = ""
            End If
            If TypeOf Me.Entity Is SimpleBusinessEntityBase Then
              CType(Entity, SimpleBusinessEntityBase).OnGlChanged()
            End If
						doc.Runnumber = CStr(e.ProposedValue)
					Case "vati_code"
						If IsDBNull(e.ProposedValue) OrElse e.ProposedValue Is Nothing Then
							e.ProposedValue = ""
            End If
            If TypeOf Me.Entity Is SimpleBusinessEntityBase Then
              CType(Entity, SimpleBusinessEntityBase).OnGlChanged()
            End If
            Dim oldcode As String = doc.Code
            doc.Code = CStr(e.ProposedValue)
            If oldcode Is Nothing OrElse oldcode.Length = 0 Then
              doc.SetVatAmount()
            End If
					Case "vati_printname"
						If IsDBNull(e.ProposedValue) OrElse e.ProposedValue Is Nothing Then
							e.ProposedValue = ""
            End If
            If TypeOf Me.Entity Is SimpleBusinessEntityBase Then
              CType(Entity, SimpleBusinessEntityBase).OnGlChanged()
            End If
						doc.PrintName = CStr(e.ProposedValue)
					Case "vati_docdate"
						If IsDate(e.ProposedValue) Then
							doc.DocDate = CDate(e.ProposedValue)
						Else
							doc.DocDate = Date.MinValue
            End If
					Case "vati_printaddress"
						If IsDBNull(e.ProposedValue) OrElse e.ProposedValue Is Nothing Then
							e.ProposedValue = ""
						End If
						doc.PrintAddress = CStr(e.ProposedValue)
					Case "vati_taxbase"
						If IsDBNull(e.ProposedValue) Then
							e.ProposedValue = ""
							Return
						End If
            If TypeOf Me.Entity Is SimpleBusinessEntityBase Then
              CType(Entity, SimpleBusinessEntityBase).OnGlChanged()
            End If
						Dim value As Decimal = 0
						If IsNumeric(e.ProposedValue) Then
							value = CDec(TextParser.Evaluate(e.ProposedValue.ToString))
						End If

						If TypeOf m_entity Is ReceiveSelection Then
							Dim oldvalue As Decimal = 0
							If Not e.Row.IsNull(e.Column) Then
								If IsNumeric(e.Row(e.Column)) Then
									oldvalue = CDec(e.Row(e.Column))
								End If
							End If
							Dim viTaxBase2 As Decimal = 0
							For Each row As TreeRow In Me.m_treeManager.Treetable.Rows
								If IsNumeric(row("vati_taxbase")) Then
									viTaxBase2 += CDec(row("vati_taxbase"))
								End If
              Next
              Dim obj As Object = Configuration.GetConfig("VatAcceptDiffAmount")
              Dim tmpTaxbase As Decimal = (viTaxBase2 - oldvalue + value)
              If tmpTaxbase > Me.m_vat.VatTaxBase Then
                If tmpTaxbase - Me.m_vat.VatTaxBase < CDec(obj) Then
                  If Not msgServ.AskQuestionFormatted(StringParserService.Parse("${res:Global.Error.ReceiveSelectionDiffTaxBaseAndVatTaxBase}"), _
                                         New String() {Configuration.FormatToString(Me.m_vat.VatTaxBase, DigitConfig.Price), _
                                                       Configuration.FormatToString(tmpTaxbase, DigitConfig.Price)}) Then
                    Return
                  End If
                Else
                  msgServ.ShowMessageFormatted("${res:Global.Error.OverTaxBase}", _
                                New String() {Configuration.FormatToString(Me.m_vat.VatTaxBase, DigitConfig.Price)})
                  e.ProposedValue = e.Row(e.Column)
                  Return
                End If
              End If
						End If

						doc.TaxBase = value
					Case "vati_taxrate"
						If IsDBNull(e.ProposedValue) Then
							e.ProposedValue = ""
						End If
            Dim value As Decimal = CDec(TextParser.Evaluate(e.ProposedValue.ToString))
            If TypeOf Me.Entity Is SimpleBusinessEntityBase Then
              CType(Entity, SimpleBusinessEntityBase).OnGlChanged()
            End If
						doc.TaxRate = value
					Case "amount"
						If IsDBNull(e.ProposedValue) Then
							e.ProposedValue = ""
            End If
            If TypeOf Me.Entity Is SimpleBusinessEntityBase Then
              CType(Entity, SimpleBusinessEntityBase).OnGlChanged()
            End If
						Dim value As Decimal = CDec(TextParser.Evaluate(e.ProposedValue.ToString))
						doc.Amount = value
					Case "vati_note"
						If IsDBNull(e.ProposedValue) Then
							e.ProposedValue = ""
						End If
						doc.Note = e.ProposedValue.ToString
				End Select
				doc.AutoGen = True
			Catch ex As Exception
				MessageBox.Show(ex.ToString)
			End Try
		End Sub
		Private Sub VatItemDelete(ByVal sender As Object, ByVal e As System.Data.DataRowChangeEventArgs)
		End Sub
#End Region

#Region "IListDetail"
		Public Overrides Sub CheckFormEnable()
			Dim enableForm As Boolean = False
			If (Not Me.m_entity Is Nothing AndAlso Me.m_entity.Status.Value >= 4) _
			OrElse (Not Me.m_entity Is Nothing AndAlso Me.m_entity.Status.Value = 0) _
			Then
				enableForm = False
			Else
				enableForm = True
			End If
			If TypeOf Me.m_entity Is IVatable AndAlso CType(Me.m_entity, IVatable).NoVat Then
				enableForm = False
			End If
			If Not enableForm Then
				For Each ctrl As Control In grbDetail.Controls
					ctrl.Enabled = False
				Next
				tgItem.Enabled = True
				For Each colStyle As DataGridColumnStyle In Me.m_treeManager.GridTableStyle.GridColumnStyles
					If colstyle.MappingName.ToLower <> "selected" Then
						colStyle.ReadOnly = True
					End If
				Next
			Else
				For Each ctrl As Control In Me.grbDetail.Controls
					ctrl.Enabled = CBool(m_enableState(ctrl))
				Next
				For Each colStyle As DataGridColumnStyle In Me.m_treeManager.GridTableStyle.GridColumnStyles
					colStyle.ReadOnly = CBool(m_tableStyleEnable(colStyle))
				Next
			End If
		End Sub

		Public Overrides Sub ClearDetail()
			lblStatus.Text = ""
			For Each crlt As Control In grbDetail.Controls
				If crlt.Name.StartsWith("txt") Then
					crlt.Text = ""
				End If
			Next
		End Sub
		Public Overrides Sub SetLabelText()
			If Not m_entity Is Nothing Then Me.Text = Me.StringParserService.Parse(Me.m_entity.TabPageText)
			Me.grbDetail.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.VATDetail.grbDetail}")
			Me.lblNote.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.VATDetail.lblNote}")
			Me.lblAmount.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.VATDetail.lblAmount}")
			Me.lblBaht.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.VATDetail.lblBaht}")
			Me.lblBaht1.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.VATDetail.lblBaht1}")
			Me.lblRefDocDate.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.VATDetail.lblRefDocDate}")
			Me.lblRefDoc.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.VATDetail.lblRefDoc}")
			Me.lblRefVAT.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.VATDetail.lblRefVAT}")
			Me.lblDirection.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.VATDetail.lblVATType}")
			Me.Label2.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.VATDetail.Label2}")
			Me.grbRefDoc.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.VATDetail.grbRefDoc}")
			Me.lblTaxBase.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.VATDetail.lblBase}")
			Me.lblRefTaxBase.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.VATDetail.lblRefTaxBase}")

			Me.grbSubmit.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.VATDetail.grbSubmit}")
			Me.lblVatGroup.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.VATDetail.lblVatGroup}")
			Me.lblSubmitalDate.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.VATDetail.lblSubmitalDate}")

		End Sub
		Protected Overrides Sub EventWiring()
			AddHandler txtNote.TextChanged, AddressOf Me.ChangeProperty

			AddHandler txtVatGroupCode.Validated, AddressOf Me.ChangeProperty

			AddHandler txtSubmitalDate.Validated, AddressOf Me.ChangeProperty
			AddHandler dtpSubmitalDate.ValueChanged, AddressOf Me.ChangeProperty
		End Sub
		' แสดงค่าข้อมูลของลูกค้าลงใน control ที่อยู่บนฟอร์ม
		Private m_tmpsubmitalDate As Date = Now
		Public Overrides Sub UpdateEntityProperties()
			m_isInitialized = False
			ClearDetail()
			If m_vat Is Nothing Then
				Return
			End If

			RefreshDocs()

      If Not Me.m_vat.Originated Then
        Dim Config As Object = Configuration.GetConfig("TabDetailNoteToOtherTab")
        If CBool(Config) Then
          If Me.m_vat.Note Is Nothing OrElse Me.m_vat.Note.Length = 0 Then
            If TypeOf Me.m_vat.RefDoc Is IPayable Then
              Me.m_vat.Note = CType(m_vat.RefDoc, IPayable).Note
            End If
            If TypeOf Me.m_vat.RefDoc Is IReceivable Then
              Me.m_vat.Note = CType(m_vat.RefDoc, IReceivable).Note
            End If
          End If
        End If
      End If

      Me.txtNote.Text = Me.m_vat.Note

      'Me.m_vat.RefDoc.Date
      m_tmpsubmitalDate = Me.m_vat.SubmitalDate
      txtSubmitalDate.Text = MinDateToNull(m_tmpsubmitalDate, "")
      dtpSubmitalDate.Value = MinDateToNow(m_tmpsubmitalDate)

      txtVatGroupCode.Text = Me.m_vat.VatGroup.Code
      txtVatGroupName.Text = Me.m_vat.VatGroup.Name

      Me.m_vat.RefreshVatTaxBase()

      UpdateRefDoc()

			SetStatus()
			SetLabelText()
			CheckFormEnable()
			m_isInitialized = True
		End Sub
		Private Sub RefreshDocs()
			Dim ini As Boolean
			If Me.m_isInitialized Then
				Me.m_isInitialized = False
				ini = True
			Else
				ini = False
			End If
			Me.m_vat.ItemCollection.Populate(m_treeManager.Treetable)
			RefreshBlankGrid()
			ReIndex()
			Me.m_treeManager.Treetable.AcceptChanges()
			Me.UpdateAmount()
			Me.m_isInitialized = ini
		End Sub
		Private Sub UpdateRefDoc()
			Me.txtRefDocCode.Text = Me.m_vat.RefDoc.Code
			Me.txtRefDocDate.Text = MinDateToNull(Me.m_vat.RefDoc.Date, Me.StringParserService.Parse("${res:Global.BlankDateText}"))
			Me.dtpRefDocDate.Value = MinDateToNow(Me.m_vat.RefDoc.Date)
			'Me.txtRefTaxBase.Text = Configuration.FormatToString(Me.m_vat.RefDoc.GetMaximumTaxBase, DigitConfig.Price)
			Me.txtRefTaxBase.Text = Configuration.FormatToString(Me.m_vat.VatTaxBase, DigitConfig.Price)

			For Each item As IdValuePair In Me.cmbDirection.Items
				If Me.m_vat.Direction.Value = item.Id Then
					Me.cmbDirection.SelectedItem = item
				End If
			Next
		End Sub
		Private Sub UpdateAmount()
			Dim viTaxBase As Decimal = 0
			For Each vi As VatItem In Me.m_vat.ItemCollection
				viTaxBase += vi.TaxBase
			Next
			Me.txtAmount.Text = Configuration.FormatToString(Me.m_vat.Amount, DigitConfig.Price)
			'Me.txtTaxBase.Text = Configuration.FormatToString(Me.m_vat.TaxBase, DigitConfig.Price)
			Me.txtTaxBase.Text = Configuration.FormatToString(viTaxBase, DigitConfig.Price)
		End Sub
		Private Sub PropChanged(ByVal sender As Object, ByVal e As PropertyChangedEventArgs)
			If e.Name = "ItemChanged" Then
				UpdateAmount()
				Me.WorkbenchWindow.ViewContent.IsDirty = True
			End If
		End Sub
		Private m_dateSetting As Boolean = False
		Public Sub ChangeProperty(ByVal sender As Object, ByVal e As EventArgs)
			If Me.m_vat Is Nothing Or Not m_isInitialized Then
				Return
			End If
			Dim dirtyFlag As Boolean = False
			Select Case CType(sender, Control).Name.ToLower
				Case "txtnote"
					Me.m_vat.Note = Me.txtNote.Text
					dirtyFlag = True
				Case "txtvatgroupcode"
          dirtyFlag = VatGroup.GetVatGroup(txtVatGroupCode, txtVatGroupName, Me.m_vat.VatGroup)
          txtVatGroupCode.Text = Me.m_vat.VatGroup.Code
				Case "dtpsubmitaldate"
					If Not Me.m_tmpsubmitalDate.Date.Equals(dtpSubmitalDate.Value.Date) Then
						If Not m_dateSetting Then
							Me.txtSubmitalDate.Text = MinDateToNull(dtpSubmitalDate.Value, Me.StringParserService.Parse("${res:Global.BlankDateText}"))
							m_tmpsubmitalDate = dtpSubmitalDate.Value
							Me.m_vat.SubmitalDate = m_tmpsubmitalDate
						End If
						dirtyFlag = True
					End If
				Case "txtsubmitaldate"
					m_dateSetting = True
					If Not Me.txtSubmitalDate.Text.Length = 0 AndAlso Me.Validator.GetErrorMessage(Me.txtSubmitalDate) = "" Then
						Dim theDate As Date = CDate(Me.txtSubmitalDate.Text)
						If Not Me.m_tmpsubmitalDate.Date.Equals(theDate.Date) Then
							dtpSubmitalDate.Value = theDate
							m_tmpsubmitalDate = dtpSubmitalDate.Value
							Me.m_vat.SubmitalDate = m_tmpsubmitalDate
							dirtyFlag = True
						End If
					Else
						Me.dtpSubmitalDate.Value = Date.Now
						m_tmpsubmitalDate = Date.MinValue
						Me.m_vat.SubmitalDate = m_tmpsubmitalDate
						dirtyFlag = True
					End If
					m_dateSetting = False
			End Select
			Me.WorkbenchWindow.ViewContent.IsDirty = Me.WorkbenchWindow.ViewContent.IsDirty Or dirtyFlag
			CheckFormEnable()
		End Sub
		Public Sub SetStatus()
			If Not IsNothing(m_entity.CancelDate) And Not m_entity.CancelDate.Equals(Date.MinValue) Then
				lblStatus.Text = "ยกเลิก: " & m_entity.CancelDate.ToShortDateString & _
				" " & m_entity.CancelDate.ToShortTimeString & _
				"  โดย:" & m_entity.CancelPerson.Name
			ElseIf Not IsNothing(m_entity.LastEditDate) And Not m_entity.LastEditDate.Equals(Date.MinValue) Then
				lblStatus.Text = "แก้ไขล่าสุด: " & m_entity.LastEditDate.ToShortDateString & _
				" " & m_entity.LastEditDate.ToShortTimeString & _
				"  โดย:" & m_entity.LastEditor.Name
			ElseIf Not IsNothing(m_entity.OriginDate) And Not m_entity.OriginDate.Equals(Date.MinValue) Then
				lblStatus.Text = "เพิ่มเข้าสู่ระบบ: " & m_entity.OriginDate.ToShortDateString & _
				" " & m_entity.OriginDate.ToShortTimeString & _
				"  โดย:" & m_entity.Originator.Name
			Else
				lblStatus.Text = ""
			End If
		End Sub
		Public Overrides Property Entity() As ISimpleEntity
			Get
				Return Me.m_entity
			End Get
			Set(ByVal Value As ISimpleEntity)
				If Not Object.ReferenceEquals(Me.m_entity, Value) Then
					Me.m_entity = Nothing
					Me.m_entity = Value
					If Not m_vat Is Nothing Then
						RemoveHandler Me.m_vat.PropertyChanged, AddressOf PropChanged
						Me.m_vat = Nothing
					End If
					If TypeOf m_entity Is IVatable Then
						Dim vatRefDoc As IVatable = CType(m_entity, IVatable)
						m_vat = vatRefDoc.Vat
						If m_vat Is Nothing Then
							m_vat = New Vat
							m_vat.RefDoc.Vat = m_vat
						End If
						m_vat.RefDoc = vatRefDoc
						m_vat.Entity = vatRefDoc.Person
					End If
				End If
				If Not Me.m_vat Is Nothing Then
					Me.m_vat.OnTabPageTextChanged(m_entity, EventArgs.Empty)
				End If
				UpdateEntityProperties()
			End Set
		End Property

		Public Overrides Sub Initialize()
			CodeDescription.ListCodeDescriptionInComboBox(Me.cmbDirection, "vat_direction")
		End Sub
#End Region

#Region "Buttons Event"
		Private Sub ibtnBlank_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnBlank.Click
			Dim index As Integer = tgItem.CurrentRowIndex
			If index > Me.m_vat.ItemCollection.Count - 1 Then
				Return
			End If
			Dim vItem As New VatItem
			vItem.AutoGen = True
			Me.m_vat.ItemCollection.Insert(index, vItem)
			RefreshDocs()
			tgItem.CurrentRowIndex = index
		End Sub
		Private Sub ibtnDelRow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnDelRow.Click
			Dim index As Integer = Me.tgItem.CurrentRowIndex
			If index > Me.m_vat.ItemCollection.Count - 1 Then
				Return
			End If
			Me.m_vat.ItemCollection.Remove(index)
			Me.tgItem.CurrentRowIndex = index
			RefreshDocs()
			Me.WorkbenchWindow.ViewContent.IsDirty = True
		End Sub
		Private Sub ReIndex()
			Dim i As Integer = 0
			For Each row As DataRow In Me.m_treeManager.Treetable.Rows
				row("vati_linenumber") = i + 1
				If row.IsNull("Selected") Then
					row("Selected") = False
				End If
				i += 1
			Next
		End Sub

		' VatGroup
		Private Sub btnVatGroup_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnVatGroup.Click
			Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
			myEntityPanelService.OpenPanel(New VatGroup)
		End Sub
		Private Sub btnVatGroupFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnVatGroupDialog.Click
			Dim myEntityPanelService As IEntityPanelService = _
			CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
			myEntityPanelService.OpenTreeDialog(New VatGroup, AddressOf SetVatGroupDialog)
		End Sub
		Private Sub SetVatGroupDialog(ByVal e As ISimpleEntity)
			Me.txtVatGroupCode.Text = e.Code
			Me.WorkbenchWindow.ViewContent.IsDirty = _
				Me.WorkbenchWindow.ViewContent.IsDirty _
				Or VatGroup.GetVatGroup(txtVatGroupCode, txtVatGroupName, Me.m_vat.VatGroup)
		End Sub
		'SupplierButton
		Public Sub SupplierButtonClick(ByVal e As ButtonColumnEventArgs)
            Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
            If Not m_vat.Entity Is Nothing Then
                If TypeOf m_vat.Entity Is Supplier Then
                    myEntityPanelService.OpenListDialog(New Supplier, AddressOf SetSupplier)
                Else
                    myEntityPanelService.OpenListDialog(New Customer, AddressOf SetCustomer)
                End If
            End If

        End Sub
        Private Sub SetSupplier(ByVal supplier As ISimpleEntity)
            Me.m_treeManager.SelectedRow("vati_printname") = CType(supplier, supplier).Name
            Me.m_treeManager.SelectedRow("vati_printaddress") = CType(supplier, supplier).BillingAddress
        End Sub
        Private Sub SetCustomer(ByVal customer As ISimpleEntity)
            Me.m_treeManager.SelectedRow("vati_printname") = CType(customer, customer).Name
            Me.m_treeManager.SelectedRow("vati_printaddress") = CType(customer, customer).BillingAddress
        End Sub
        Private Sub btnAutorun_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
            'm_allSelected = Not m_allSelected
            Dim i As Integer = 0
            For Each item As VatItem In Me.m_vat.ItemCollection
                i = i + 1
                If CBool(m_treeManager.Treetable.Rows(i)("Selected")) Then
                    If item.AutoGen Then
                        item.AutoGen = False
                    Else
                        item.AutoGen = True
                    End If
                End If
            Next
        End Sub
#End Region

#Region "IValidatable"
		Public ReadOnly Property FormValidator() As components.PJMTextboxValidator Implements IValidatable.FormValidator
			Get
				Return Me.Validator
			End Get
		End Property
#End Region

#Region "Overrides"
		Public Overrides ReadOnly Property TabPageIcon() As String
			Get
				Return (New Vat).DetailPanelIcon
			End Get
		End Property
#End Region

#Region "IPrintable"

		Public Overrides ReadOnly Property PrintDocuments() As ArrayList
			Get
				Dim myPropertyService As PropertyService = CType(ServiceManager.Services.GetService(GetType(PropertyService)), PropertyService)
				Dim FormPath As String = (myPropertyService.DataDirectory & Path.DirectorySeparatorChar & "forms" & Path.DirectorySeparatorChar & "Adobe" & Path.DirectorySeparatorChar & "documents")
				Dim ReportPath As String = (myPropertyService.DataDirectory & Path.DirectorySeparatorChar & "forms" & Path.DirectorySeparatorChar & "Adobe" & Path.DirectorySeparatorChar & "reports")
				Dim thePath As String = ""
				Dim fileName As String = (New VatItem).GetDefaultForm
				If fileName Is Nothing OrElse fileName.Length = 0 Then
					fileName = m_vat.ClassName
				End If
				thePath = FormPath & Path.DirectorySeparatorChar & fileName & ".xml"

				Dim paths As FormPaths
				Dim nameForPath As String
				nameForPath = m_vat.FullClassName & ".Documents"
				Dim myProperties As PropertyService = CType(ServiceManager.Services.GetService(GetType(PropertyService)), PropertyService)
				paths = CType(myProperties.GetProperty(nameForPath, New FormPaths(nameForPath, m_vat.ClassName, thePath)), FormPaths)
				Dim dlg As New Longkong.Pojjaman.Gui.Dialogs.SelectFormsDialog(paths)
				If dlg.ShowDialog() = DialogResult.OK Then
					thePath = dlg.KeyValuePair.Value
				Else
					Return Nothing
				End If
				If Not Me.m_vat Is Nothing Then
					Dim arr As New ArrayList
					For i As Integer = 0 To Me.m_vat.ItemCollection.Count - 1
						If Not m_treeManager.Treetable.Rows(i).IsNull("Selected") Then
							If CBool(m_treeManager.Treetable.Rows(i)("Selected")) Then
								Dim item As VatItem = Me.m_vat.ItemCollection(i)
                If File.Exists(thePath) Then
                  Dim newItem As New VatItemWithCustomNote(item)
                  Dim df As New DesignerForm(thePath, newItem)
                  arr.Add(df.PrintDocument)
                End If
							End If
						End If
					Next
					Return arr
				End If
			End Get
		End Property
		Public Overrides ReadOnly Property PrintDocument() As System.Drawing.Printing.PrintDocument
			Get
				Return Nothing
			End Get
		End Property
		Public Overrides ReadOnly Property CanPrint() As Boolean
			Get
				Return True
			End Get
		End Property
#End Region

#Region "Grid Resizing"
		Private Sub tgItem_Resize(ByVal sender As System.Object, ByVal e As System.EventArgs)
			If Me.m_vat Is Nothing Then
				Return
			End If
			RefreshBlankGrid()
		End Sub
		Private Sub RefreshBlankGrid()
			If Me.tgItem.Height = 0 Then
				Return
			End If
			Dim dirtyFlag As Boolean = Me.WorkbenchWindow.ViewContent.IsDirty
			Dim index As Integer = tgItem.CurrentRowIndex
			Do Until Me.m_treeManager.Treetable.Rows.Count > tgItem.VisibleRowCount
				'เพิ่มแถวจนเต็ม
				Me.m_treeManager.Treetable.Childs.Add()
			Loop

			If Me.m_vat.ItemCollection.Count = Me.m_treeManager.Treetable.Childs.Count Then
				'เพิ่มอีก 1 แถว ถ้ามีข้อมูลจนถึงแถวสุดท้าย
				Me.m_treeManager.Treetable.Childs.Add()
			End If

			Me.m_treeManager.Treetable.AcceptChanges()
			tgItem.CurrentRowIndex = Math.Max(0, index)
			Me.WorkbenchWindow.ViewContent.IsDirty = dirtyFlag
		End Sub
#End Region

#Region "After the main entity has been saved"
		Public Overrides Sub NotifyAfterSave(ByVal successful As Boolean)
			If Not successful Then
				Return
			End If
			Me.Entity = CType(Me.WorkbenchWindow.SubViewContents(1), ISimpleEntityPanel).Entity
			'MyBase.NotifyAfterSave(flag)
		End Sub
		Public Overrides Sub NotifyBeforeSave()
			MyBase.NotifyBeforeSave()
			Me.Entity = CType(Me.WorkbenchWindow.SubViewContents(1), ISimpleEntityPanel).Entity
		End Sub
#End Region

#Region "IAuxTab"
    Public ReadOnly Property AuxEntity() As IDirtyAble Implements IAuxTab.AuxEntity
      Get
        If Me.m_vat Is Nothing OrElse Me.m_vat.ItemCollection Is Nothing Then
          Return Nothing
        End If
        For i As Integer = 0 To Me.m_vat.ItemCollection.Count - 1
          If Not m_treeManager.Treetable.Rows(i).IsNull("Selected") Then
            If CBool(m_treeManager.Treetable.Rows(i)("Selected")) Then
              Dim item As VatItem = Me.m_vat.ItemCollection(i)
              Return Nothing
            End If
          End If
        Next
        Return m_vat
      End Get
    End Property
#End Region
#Region "IAuxTabItem"
    Public ReadOnly Property AuxEntityItem() As Object Implements IAuxTabItem.AuxEntityItem
      Get
        For i As Integer = 0 To Me.m_vat.ItemCollection.Count - 1
          If Not m_treeManager.Treetable.Rows(i).IsNull("Selected") Then
            If CBool(m_treeManager.Treetable.Rows(i)("Selected")) Then
              Dim item As VatItem = Me.m_vat.ItemCollection(i)
              Return item
            End If
          End If
        Next
        Return m_vat
      End Get
    End Property
#End Region


	End Class
End Namespace