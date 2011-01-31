Imports Longkong.Pojjaman.BusinessLogic
Imports Longkong.Pojjaman.TextHelper
Imports Longkong.Pojjaman.Services
Imports Longkong.Pojjaman.Gui.Components
Imports Longkong.Core.Services
Imports Longkong.Pojjaman.Gui.ReportsAndDocs
Imports System.IO
Imports Longkong.Core.Properties
Imports Longkong.AdobeForm
Namespace Longkong.Pojjaman.Gui.Panels
  Public Class VATOutDetail
    Inherits AbstractEntityDetailPanelView
    Implements IValidatable, IAuxTab, ISetNothingEntity

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
    Friend WithEvents lblStatus As System.Windows.Forms.Label
    Friend WithEvents cmbDirection As System.Windows.Forms.ComboBox
    Friend WithEvents lblDirection As System.Windows.Forms.Label
    Friend WithEvents grbRefDoc As Longkong.Pojjaman.Gui.Components.FixedGroupBox
    Friend WithEvents lblTaxBase As System.Windows.Forms.Label
    Friend WithEvents txtTaxBase As System.Windows.Forms.TextBox
    Friend WithEvents lblRefTaxBase As System.Windows.Forms.Label
    Friend WithEvents txtRefTaxBase As System.Windows.Forms.TextBox
    Friend WithEvents chkAutorun As System.Windows.Forms.CheckBox
    Friend WithEvents txtDocDate As System.Windows.Forms.TextBox
    Friend WithEvents dtpDocDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblCode As System.Windows.Forms.Label
    Friend WithEvents txtCode As System.Windows.Forms.TextBox
    Friend WithEvents lblDocDate As System.Windows.Forms.Label
    Friend WithEvents lblPrintName As System.Windows.Forms.Label
    Friend WithEvents txtPrintName As System.Windows.Forms.TextBox
    Friend WithEvents lblPrintAddress As System.Windows.Forms.Label
    Friend WithEvents txtPrintAddress As System.Windows.Forms.TextBox
    Friend WithEvents txtVatRate As System.Windows.Forms.TextBox
    Friend WithEvents lblPercent As System.Windows.Forms.Label
    Friend WithEvents lblBaht3 As System.Windows.Forms.Label
    Friend WithEvents lblVateRate As System.Windows.Forms.Label
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents grbSubmit As Longkong.Pojjaman.Gui.Components.FixedGroupBox
    Friend WithEvents lblSubmitalDate As System.Windows.Forms.Label
    Friend WithEvents txtSubmitalDate As System.Windows.Forms.TextBox
    Friend WithEvents dtpSubmitalDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblVatGroup As System.Windows.Forms.Label
    Friend WithEvents txtVatGroupCode As System.Windows.Forms.TextBox
    Friend WithEvents txtVatGroupName As System.Windows.Forms.TextBox
    Friend WithEvents btnVatGroupDialog As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents btnVatGroup As Longkong.Pojjaman.Gui.Components.ImageButton
    <System.Diagnostics.DebuggerStepThrough()> Protected Sub InitializeComponent()
      Me.components = New System.ComponentModel.Container
      Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(VATOutDetail))
      Me.grbDetail = New Longkong.Pojjaman.Gui.Components.FixedGroupBox
      Me.lblTaxBase = New System.Windows.Forms.Label
      Me.txtTaxBase = New System.Windows.Forms.TextBox
      Me.lblPrintAddress = New System.Windows.Forms.Label
      Me.txtPrintAddress = New System.Windows.Forms.TextBox
      Me.lblPrintName = New System.Windows.Forms.Label
      Me.txtPrintName = New System.Windows.Forms.TextBox
      Me.chkAutorun = New System.Windows.Forms.CheckBox
      Me.txtDocDate = New System.Windows.Forms.TextBox
      Me.dtpDocDate = New System.Windows.Forms.DateTimePicker
      Me.lblCode = New System.Windows.Forms.Label
      Me.txtCode = New System.Windows.Forms.TextBox
      Me.lblDocDate = New System.Windows.Forms.Label
      Me.txtVatRate = New System.Windows.Forms.TextBox
      Me.lblPercent = New System.Windows.Forms.Label
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
      Me.lblBaht3 = New System.Windows.Forms.Label
      Me.lblStatus = New System.Windows.Forms.Label
      Me.lblNote = New System.Windows.Forms.Label
      Me.txtNote = New System.Windows.Forms.TextBox
      Me.lblAmount = New System.Windows.Forms.Label
      Me.txtAmount = New System.Windows.Forms.TextBox
      Me.lblBaht = New System.Windows.Forms.Label
      Me.lblBaht1 = New System.Windows.Forms.Label
      Me.lblVateRate = New System.Windows.Forms.Label
      Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider
      Me.Validator = New Longkong.Pojjaman.Gui.Components.PJMTextboxValidator(Me.components)
      Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
      Me.grbSubmit = New Longkong.Pojjaman.Gui.Components.FixedGroupBox
      Me.lblSubmitalDate = New System.Windows.Forms.Label
      Me.txtSubmitalDate = New System.Windows.Forms.TextBox
      Me.dtpSubmitalDate = New System.Windows.Forms.DateTimePicker
      Me.lblVatGroup = New System.Windows.Forms.Label
      Me.txtVatGroupCode = New System.Windows.Forms.TextBox
      Me.txtVatGroupName = New System.Windows.Forms.TextBox
      Me.btnVatGroupDialog = New Longkong.Pojjaman.Gui.Components.ImageButton
      Me.btnVatGroup = New Longkong.Pojjaman.Gui.Components.ImageButton
      Me.grbDetail.SuspendLayout()
      Me.grbRefDoc.SuspendLayout()
      Me.grbSubmit.SuspendLayout()
      Me.SuspendLayout()
      '
      'grbDetail
      '
      Me.grbDetail.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                  Or System.Windows.Forms.AnchorStyles.Left) _
                  Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.grbDetail.Controls.Add(Me.grbSubmit)
      Me.grbDetail.Controls.Add(Me.lblTaxBase)
      Me.grbDetail.Controls.Add(Me.txtTaxBase)
      Me.grbDetail.Controls.Add(Me.lblPrintAddress)
      Me.grbDetail.Controls.Add(Me.txtPrintAddress)
      Me.grbDetail.Controls.Add(Me.lblPrintName)
      Me.grbDetail.Controls.Add(Me.txtPrintName)
      Me.grbDetail.Controls.Add(Me.chkAutorun)
      Me.grbDetail.Controls.Add(Me.txtDocDate)
      Me.grbDetail.Controls.Add(Me.dtpDocDate)
      Me.grbDetail.Controls.Add(Me.lblCode)
      Me.grbDetail.Controls.Add(Me.txtCode)
      Me.grbDetail.Controls.Add(Me.lblDocDate)
      Me.grbDetail.Controls.Add(Me.txtVatRate)
      Me.grbDetail.Controls.Add(Me.lblPercent)
      Me.grbDetail.Controls.Add(Me.grbRefDoc)
      Me.grbDetail.Controls.Add(Me.lblStatus)
      Me.grbDetail.Controls.Add(Me.lblNote)
      Me.grbDetail.Controls.Add(Me.txtNote)
      Me.grbDetail.Controls.Add(Me.lblAmount)
      Me.grbDetail.Controls.Add(Me.txtAmount)
      Me.grbDetail.Controls.Add(Me.lblBaht)
      Me.grbDetail.Controls.Add(Me.lblBaht1)
      Me.grbDetail.Controls.Add(Me.lblVateRate)
      Me.grbDetail.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.grbDetail.Location = New System.Drawing.Point(0, 8)
      Me.grbDetail.Name = "grbDetail"
      Me.grbDetail.Size = New System.Drawing.Size(560, 408)
      Me.grbDetail.TabIndex = 198
      Me.grbDetail.TabStop = False
      Me.grbDetail.Text = "ใบกำกับภาษีมูลค่าเพิ่ม"
      '
      'lblTaxBase
      '
      Me.lblTaxBase.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblTaxBase.ForeColor = System.Drawing.Color.Black
      Me.lblTaxBase.Location = New System.Drawing.Point(8, 280)
      Me.lblTaxBase.Name = "lblTaxBase"
      Me.lblTaxBase.Size = New System.Drawing.Size(96, 24)
      Me.lblTaxBase.TabIndex = 191
      Me.lblTaxBase.Text = "Goods/Service Amount:"
      Me.lblTaxBase.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'txtTaxBase
      '
      Me.Validator.SetDataType(Me.txtTaxBase, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtTaxBase, "")
      Me.txtTaxBase.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtTaxBase, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtTaxBase, System.Drawing.Color.Empty)
      Me.txtTaxBase.Location = New System.Drawing.Point(104, 280)
      Me.Validator.SetMaxValue(Me.txtTaxBase, "")
      Me.Validator.SetMinValue(Me.txtTaxBase, "")
      Me.txtTaxBase.Name = "txtTaxBase"
      Me.Validator.SetRegularExpression(Me.txtTaxBase, "")
      Me.Validator.SetRequired(Me.txtTaxBase, False)
      Me.txtTaxBase.Size = New System.Drawing.Size(144, 21)
      Me.txtTaxBase.TabIndex = 189
      Me.txtTaxBase.TabStop = False
      Me.txtTaxBase.Text = ""
      Me.txtTaxBase.TextAlign = HorizontalAlignment.Right
      '
      'lblPrintAddress
      '
      Me.lblPrintAddress.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblPrintAddress.Location = New System.Drawing.Point(24, 232)
      Me.lblPrintAddress.Name = "lblPrintAddress"
      Me.lblPrintAddress.Size = New System.Drawing.Size(80, 18)
      Me.lblPrintAddress.TabIndex = 340
      Me.lblPrintAddress.Text = "ที่อยู่:"
      Me.lblPrintAddress.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'txtPrintAddress
      '
      Me.txtPrintAddress.BackColor = System.Drawing.SystemColors.Window
      Me.Validator.SetDataType(Me.txtPrintAddress, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtPrintAddress, "")
      Me.Validator.SetGotFocusBackColor(Me.txtPrintAddress, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtPrintAddress, System.Drawing.Color.Empty)
      Me.txtPrintAddress.Location = New System.Drawing.Point(104, 232)
      Me.txtPrintAddress.MaxLength = 250
      Me.Validator.SetMaxValue(Me.txtPrintAddress, "")
      Me.Validator.SetMinValue(Me.txtPrintAddress, "")
      Me.txtPrintAddress.Name = "txtPrintAddress"
      Me.Validator.SetRegularExpression(Me.txtPrintAddress, "")
      Me.Validator.SetRequired(Me.txtPrintAddress, True)
      Me.txtPrintAddress.Size = New System.Drawing.Size(440, 20)
      Me.txtPrintAddress.TabIndex = 339
      Me.txtPrintAddress.Text = ""
      '
      'lblPrintName
      '
      Me.lblPrintName.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblPrintName.Location = New System.Drawing.Point(24, 208)
      Me.lblPrintName.Name = "lblPrintName"
      Me.lblPrintName.Size = New System.Drawing.Size(80, 18)
      Me.lblPrintName.TabIndex = 338
      Me.lblPrintName.Text = "ชื่อ:"
      Me.lblPrintName.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'txtPrintName
      '
      Me.txtPrintName.BackColor = System.Drawing.SystemColors.Window
      Me.Validator.SetDataType(Me.txtPrintName, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtPrintName, "")
      Me.Validator.SetGotFocusBackColor(Me.txtPrintName, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtPrintName, System.Drawing.Color.Empty)
      Me.txtPrintName.Location = New System.Drawing.Point(104, 208)
      Me.txtPrintName.MaxLength = 200
      Me.Validator.SetMaxValue(Me.txtPrintName, "")
      Me.Validator.SetMinValue(Me.txtPrintName, "")
      Me.txtPrintName.Name = "txtPrintName"
      Me.Validator.SetRegularExpression(Me.txtPrintName, "")
      Me.Validator.SetRequired(Me.txtPrintName, True)
      Me.txtPrintName.Size = New System.Drawing.Size(440, 20)
      Me.txtPrintName.TabIndex = 337
      Me.txtPrintName.Text = ""
      '
      'chkAutorun
      '
      Me.chkAutorun.Appearance = System.Windows.Forms.Appearance.Button
      Me.chkAutorun.Image = CType(resources.GetObject("chkAutorun.Image"), System.Drawing.Image)
      Me.chkAutorun.Location = New System.Drawing.Point(224, 184)
      Me.chkAutorun.Name = "chkAutorun"
      Me.chkAutorun.Size = New System.Drawing.Size(21, 21)
      Me.chkAutorun.TabIndex = 336
      '
      'txtDocDate
      '
      Me.Validator.SetDataType(Me.txtDocDate, Longkong.Pojjaman.Gui.Components.DataTypeConstants.DateTimeType)
      Me.Validator.SetDisplayName(Me.txtDocDate, "")
      Me.Validator.SetGotFocusBackColor(Me.txtDocDate, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtDocDate, 15)
      Me.Validator.SetInvalidBackColor(Me.txtDocDate, System.Drawing.Color.Empty)
      Me.txtDocDate.Location = New System.Drawing.Point(312, 184)
      Me.Validator.SetMaxValue(Me.txtDocDate, "")
      Me.Validator.SetMinValue(Me.txtDocDate, "")
      Me.txtDocDate.Name = "txtDocDate"
      Me.Validator.SetRegularExpression(Me.txtDocDate, "")
      Me.Validator.SetRequired(Me.txtDocDate, True)
      Me.txtDocDate.Size = New System.Drawing.Size(126, 20)
      Me.txtDocDate.TabIndex = 332
      Me.txtDocDate.Text = ""
      '
      'dtpDocDate
      '
      Me.dtpDocDate.CustomFormat = "dd/MM/yyyy"
      Me.dtpDocDate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.dtpDocDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
      Me.dtpDocDate.Location = New System.Drawing.Point(312, 184)
      Me.dtpDocDate.Name = "dtpDocDate"
      Me.dtpDocDate.Size = New System.Drawing.Size(144, 21)
      Me.dtpDocDate.TabIndex = 335
      Me.dtpDocDate.TabStop = False
      '
      'lblCode
      '
      Me.lblCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblCode.ForeColor = System.Drawing.Color.Black
      Me.lblCode.Location = New System.Drawing.Point(24, 184)
      Me.lblCode.Name = "lblCode"
      Me.lblCode.Size = New System.Drawing.Size(80, 18)
      Me.lblCode.TabIndex = 334
      Me.lblCode.Text = "Code:"
      Me.lblCode.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'txtCode
      '
      Me.Validator.SetDataType(Me.txtCode, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtCode, "")
      Me.txtCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtCode, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtCode, System.Drawing.Color.Empty)
      Me.txtCode.Location = New System.Drawing.Point(104, 184)
      Me.txtCode.MaxLength = 20
      Me.Validator.SetMaxValue(Me.txtCode, "")
      Me.Validator.SetMinValue(Me.txtCode, "")
      Me.txtCode.Name = "txtCode"
      Me.Validator.SetRegularExpression(Me.txtCode, "")
      Me.Validator.SetRequired(Me.txtCode, True)
      Me.txtCode.Size = New System.Drawing.Size(120, 21)
      Me.txtCode.TabIndex = 331
      Me.txtCode.TabStop = False
      Me.txtCode.Text = ""
      '
      'lblDocDate
      '
      Me.lblDocDate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblDocDate.ForeColor = System.Drawing.Color.Black
      Me.lblDocDate.Location = New System.Drawing.Point(224, 184)
      Me.lblDocDate.Name = "lblDocDate"
      Me.lblDocDate.Size = New System.Drawing.Size(88, 18)
      Me.lblDocDate.TabIndex = 333
      Me.lblDocDate.Text = "วันที่:"
      Me.lblDocDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'txtVatRate
      '
      Me.Validator.SetDataType(Me.txtVatRate, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtVatRate, "")
      Me.txtVatRate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtVatRate, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtVatRate, System.Drawing.Color.Empty)
      Me.txtVatRate.Location = New System.Drawing.Point(312, 280)
      Me.Validator.SetMaxValue(Me.txtVatRate, "")
      Me.Validator.SetMinValue(Me.txtVatRate, "")
      Me.txtVatRate.Name = "txtVatRate"
      Me.txtVatRate.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtVatRate, "")
      Me.Validator.SetRequired(Me.txtVatRate, False)
      Me.txtVatRate.Size = New System.Drawing.Size(40, 21)
      Me.txtVatRate.TabIndex = 282
      Me.txtVatRate.TabStop = False
      Me.txtVatRate.Text = ""
      '
      'lblPercent
      '
      Me.lblPercent.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblPercent.ForeColor = System.Drawing.Color.Black
      Me.lblPercent.Location = New System.Drawing.Point(360, 280)
      Me.lblPercent.Name = "lblPercent"
      Me.lblPercent.Size = New System.Drawing.Size(32, 18)
      Me.lblPercent.TabIndex = 283
      Me.lblPercent.Text = "%"
      Me.lblPercent.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
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
      Me.grbRefDoc.Controls.Add(Me.lblBaht3)
      Me.grbRefDoc.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.grbRefDoc.Location = New System.Drawing.Point(16, 16)
      Me.grbRefDoc.Name = "grbRefDoc"
      Me.grbRefDoc.Size = New System.Drawing.Size(528, 72)
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
      Me.txtRefTaxBase.Location = New System.Drawing.Point(320, 39)
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
      Me.txtRefDocDate.Location = New System.Drawing.Point(320, 16)
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
      Me.lblRefTaxBase.Location = New System.Drawing.Point(192, 44)
      Me.lblRefTaxBase.Name = "lblRefTaxBase"
      Me.lblRefTaxBase.Size = New System.Drawing.Size(128, 11)
      Me.lblRefTaxBase.TabIndex = 191
      Me.lblRefTaxBase.Text = "Goods/Service Amount:"
      Me.lblRefTaxBase.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblRefDocDate
      '
      Me.lblRefDocDate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblRefDocDate.ForeColor = System.Drawing.SystemColors.WindowText
      Me.lblRefDocDate.Location = New System.Drawing.Point(256, 17)
      Me.lblRefDocDate.Name = "lblRefDocDate"
      Me.lblRefDocDate.Size = New System.Drawing.Size(64, 18)
      Me.lblRefDocDate.TabIndex = 277
      Me.lblRefDocDate.Text = "Date:"
      Me.lblRefDocDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'dtpRefDocDate
      '
      Me.dtpRefDocDate.CustomFormat = "dd/MM/yyyy"
      Me.dtpRefDocDate.Enabled = False
      Me.dtpRefDocDate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.dtpRefDocDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
      Me.dtpRefDocDate.Location = New System.Drawing.Point(320, 16)
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
      'lblBaht3
      '
      Me.lblBaht3.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblBaht3.ForeColor = System.Drawing.Color.Black
      Me.lblBaht3.Location = New System.Drawing.Point(464, 40)
      Me.lblBaht3.Name = "lblBaht3"
      Me.lblBaht3.Size = New System.Drawing.Size(32, 18)
      Me.lblBaht3.TabIndex = 190
      Me.lblBaht3.Text = "บาท"
      Me.lblBaht3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      '
      'lblStatus
      '
      Me.lblStatus.AutoSize = True
      Me.lblStatus.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblStatus.Location = New System.Drawing.Point(104, 328)
      Me.lblStatus.Name = "lblStatus"
      Me.lblStatus.Size = New System.Drawing.Size(35, 17)
      Me.lblStatus.TabIndex = 280
      Me.lblStatus.Text = "Status"
      Me.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblNote
      '
      Me.lblNote.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblNote.ForeColor = System.Drawing.Color.Black
      Me.lblNote.Location = New System.Drawing.Point(24, 256)
      Me.lblNote.Name = "lblNote"
      Me.lblNote.Size = New System.Drawing.Size(80, 18)
      Me.lblNote.TabIndex = 191
      Me.lblNote.Text = "หมายเหตุ:"
      Me.lblNote.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'txtNote
      '
      Me.Validator.SetDataType(Me.txtNote, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtNote, "")
      Me.txtNote.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtNote, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtNote, System.Drawing.Color.Empty)
      Me.txtNote.Location = New System.Drawing.Point(104, 256)
      Me.txtNote.MaxLength = 250
      Me.Validator.SetMaxValue(Me.txtNote, "")
      Me.Validator.SetMinValue(Me.txtNote, "")
      Me.txtNote.Name = "txtNote"
      Me.Validator.SetRegularExpression(Me.txtNote, "")
      Me.Validator.SetRequired(Me.txtNote, False)
      Me.txtNote.Size = New System.Drawing.Size(440, 21)
      Me.txtNote.TabIndex = 189
      Me.txtNote.TabStop = False
      Me.txtNote.Text = ""
      '
      'lblAmount
      '
      Me.lblAmount.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblAmount.ForeColor = System.Drawing.Color.Black
      Me.lblAmount.Location = New System.Drawing.Point(40, 304)
      Me.lblAmount.Name = "lblAmount"
      Me.lblAmount.Size = New System.Drawing.Size(64, 18)
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
      Me.txtAmount.Location = New System.Drawing.Point(104, 304)
      Me.Validator.SetMaxValue(Me.txtAmount, "")
      Me.Validator.SetMinValue(Me.txtAmount, "")
      Me.txtAmount.Name = "txtAmount"
      Me.Validator.SetRegularExpression(Me.txtAmount, "")
      Me.Validator.SetRequired(Me.txtAmount, False)
      Me.txtAmount.Size = New System.Drawing.Size(144, 21)
      Me.txtAmount.TabIndex = 189
      Me.txtAmount.TabStop = False
      Me.txtAmount.Text = ""
      Me.txtAmount.TextAlign = HorizontalAlignment.Right
      '
      'lblBaht
      '
      Me.lblBaht.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblBaht.ForeColor = System.Drawing.Color.Black
      Me.lblBaht.Location = New System.Drawing.Point(248, 280)
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
      Me.lblBaht1.Location = New System.Drawing.Point(248, 304)
      Me.lblBaht1.Name = "lblBaht1"
      Me.lblBaht1.Size = New System.Drawing.Size(32, 18)
      Me.lblBaht1.TabIndex = 190
      Me.lblBaht1.Text = "บาท"
      Me.lblBaht1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      '
      'lblVateRate
      '
      Me.lblVateRate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblVateRate.ForeColor = System.Drawing.Color.Black
      Me.lblVateRate.Location = New System.Drawing.Point(256, 280)
      Me.lblVateRate.Name = "lblVateRate"
      Me.lblVateRate.Size = New System.Drawing.Size(56, 18)
      Me.lblVateRate.TabIndex = 284
      Me.lblVateRate.Text = "อัตรา:"
      Me.lblVateRate.TextAlign = System.Drawing.ContentAlignment.MiddleRight
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
      Me.grbSubmit.Location = New System.Drawing.Point(16, 96)
      Me.grbSubmit.Name = "grbSubmit"
      Me.grbSubmit.Size = New System.Drawing.Size(528, 72)
      Me.grbSubmit.TabIndex = 346
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
      Me.txtVatGroupCode.Size = New System.Drawing.Size(144, 20)
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
      Me.txtVatGroupName.Location = New System.Drawing.Point(272, 40)
      Me.Validator.SetMaxValue(Me.txtVatGroupName, "")
      Me.Validator.SetMinValue(Me.txtVatGroupName, "")
      Me.txtVatGroupName.Name = "txtVatGroupName"
      Me.txtVatGroupName.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtVatGroupName, "")
      Me.Validator.SetRequired(Me.txtVatGroupName, False)
      Me.txtVatGroupName.Size = New System.Drawing.Size(184, 20)
      Me.txtVatGroupName.TabIndex = 349
      Me.txtVatGroupName.TabStop = False
      Me.txtVatGroupName.Text = ""
      '
      'btnVatGroupDialog
      '
      Me.btnVatGroupDialog.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.btnVatGroupDialog.ForeColor = System.Drawing.SystemColors.Control
      Me.btnVatGroupDialog.Image = CType(resources.GetObject("btnVatGroupDialog.Image"), System.Drawing.Image)
      Me.btnVatGroupDialog.Location = New System.Drawing.Point(456, 39)
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
      Me.btnVatGroup.Location = New System.Drawing.Point(480, 39)
      Me.btnVatGroup.Name = "btnVatGroup"
      Me.btnVatGroup.Size = New System.Drawing.Size(24, 23)
      Me.btnVatGroup.TabIndex = 348
      Me.btnVatGroup.TabStop = False
      Me.btnVatGroup.ThemedImage = CType(resources.GetObject("btnVatGroup.ThemedImage"), System.Drawing.Bitmap)
      '
      'VATOutDetail
      '
      Me.Controls.Add(Me.grbDetail)
      Me.Name = "VATOutDetail"
      Me.Size = New System.Drawing.Size(568, 424)
      Me.grbDetail.ResumeLayout(False)
      Me.grbRefDoc.ResumeLayout(False)
      Me.grbSubmit.ResumeLayout(False)
      Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Members"
    Private m_entity As ISimpleEntity
    Private m_isInitialized As Boolean = False
    Private m_vat As Vat
#End Region

#Region "Constructors"
    Public Sub New()
      MyBase.New()
      Me.InitializeComponent()
      Me.SetLabelText()
      Initialize()
      EventWiring()
    End Sub
#End Region

#Region "Properties"

#End Region

#Region "IListDetail"
    Private allowBlankInvoice As Boolean = False
    Public Overrides Sub CheckFormEnable()
      If (Not Me.m_entity Is Nothing AndAlso Me.m_entity.Status.Value >= 4) _
      OrElse (Not Me.m_entity Is Nothing AndAlso Me.m_entity.Status.Value = 0) _
      OrElse (TypeOf Me.m_entity Is IVatable _
      AndAlso CType(Me.m_entity, IVatable).NoVat) _
      Then
        For Each ctrl As Control In grbDetail.Controls
          ctrl.Enabled = False
        Next
      Else
        For Each ctrl As Control In grbDetail.Controls
          ctrl.Enabled = True
        Next
      End If

      If (TypeOf Me.m_entity Is GoodsSold) OrElse (TypeOf Me.m_entity Is SaleCN) OrElse (TypeOf Me.m_entity Is PurchaseCN) Then
        'allowBlankInvoice = True
        Me.Validator.SetRequired(Me.txtCode, False)
        Me.Validator.SetRequired(Me.txtDocDate, False)
        Me.Validator.SetRequired(Me.txtPrintName, False)
        Me.Validator.SetRequired(Me.txtPrintAddress, False)
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
      Me.grbDetail.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.VATOutDetail.grbDetail}")
      Me.lblNote.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.VATOutDetail.lblNote}")
      Me.lblAmount.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.VATOutDetail.lblAmount}")
      Me.lblBaht.Text = Me.StringParserService.Parse("${res:Global.CurrencyUnit}")
      Me.lblBaht1.Text = Me.StringParserService.Parse("${res:Global.CurrencyUnit}")
      Me.lblRefDocDate.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.VATOutDetail.lblRefDocDate}")
      Me.lblRefDoc.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.VATOutDetail.lblRefDoc}")
      Me.lblDirection.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.VATOutDetail.lblVATType}")
      Me.lblBaht3.Text = Me.StringParserService.Parse("${res:Global.CurrencyUnit}")
      Me.lblPercent.Text = Me.StringParserService.Parse("${res:Global.Percent}")
      Me.lblVateRate.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.VATOutDetail.lblVateRate}")
      Me.grbRefDoc.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.VATOutDetail.grbRefDoc}")
      Me.lblTaxBase.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.VATOutDetail.lblBase}")
      Me.lblRefTaxBase.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.VATOutDetail.lblRefTaxBase}")

      Me.lblPrintName.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.VATOutDetail.lblPrintName}")
      Me.Validator.SetDisplayName(Me.txtPrintName, Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.VATOutDetail.txtPrintNameAlert}"))

      Me.lblPrintAddress.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.VATOutDetail.lblPrintAddress}")
      Me.Validator.SetDisplayName(Me.txtPrintAddress, Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.VATOutDetail.txtPrintAddressAlert}"))

      Me.ToolTip1.SetToolTip(Me.chkAutorun, Me.StringParserService.Parse("${res:Global.chkAutorun}")) '"เลขที่อัตโนมัติ")
    End Sub
    Protected Overrides Sub EventWiring()
      AddHandler txtNote.TextChanged, AddressOf Me.ChangeProperty
      AddHandler txtCode.TextChanged, AddressOf Me.ChangeProperty
      AddHandler txtPrintAddress.TextChanged, AddressOf Me.ChangeProperty
      AddHandler txtPrintName.TextChanged, AddressOf Me.ChangeProperty
      AddHandler txtSubmitalDate.Validated, AddressOf Me.ChangeProperty
      AddHandler txtTaxBase.Validated, AddressOf Me.ChangeProperty
      AddHandler txtAmount.Validated, AddressOf Me.ChangeProperty
      AddHandler dtpSubmitalDate.ValueChanged, AddressOf Me.ChangeProperty
      AddHandler txtDocDate.Validated, AddressOf Me.ChangeProperty
      AddHandler dtpDocDate.ValueChanged, AddressOf Me.ChangeProperty
      AddHandler txtVatGroupCode.Validated, AddressOf Me.ChangeProperty
    End Sub
    ' แสดงค่าข้อมูลของลูกค้าลงใน control ที่อยู่บนฟอร์ม
    Private m_tmpsubmitalDate As Date = Now

    Public Overrides Sub UpdateEntityProperties()
      m_isInitialized = False
      ClearDetail()
      If m_vat Is Nothing Then
        Return
      End If
      Dim vi As VatItem
      If Me.m_vat.ItemCollection.Count <= 0 Then
        vi = New VatItem
        Me.m_vat.ItemCollection.Add(vi)
      End If
      vi = Me.m_vat.ItemCollection(0)
      txtCode.Text = vi.Code
      If allowBlankInvoice Then
        Me.txtDocDate.Text = IIf(vi.Code Is Nothing OrElse vi.Code.Length = 0, "", MinDateToNull(vi.DocDate, ""))
      Else
        Me.txtDocDate.Text = MinDateToNull(vi.DocDate, Me.StringParserService.Parse("${res:Global.BlankDateText}"))
      End If
      Me.txtVatGroupCode.Text = Me.m_vat.VatGroup.Code
      Me.txtVatGroupName.Text = Me.m_vat.VatGroup.Name

      Me.dtpDocDate.Value = MinDateToNow(vi.DocDate)
      m_oldCode = vi.Code
      Me.txtVatRate.Text = Configuration.FormatToString(vi.TaxRate, DigitConfig.Price)
      Me.txtPrintAddress.Text = vi.PrintAddress
      Me.txtPrintName.Text = vi.PrintName
      Me.txtNote.Text = vi.Note

      Me.chkAutorun.Checked = Me.m_vat.AutoGen
      Me.UpdateAutogenStatus()

      AddHandler Me.m_vat.PropertyChanged, AddressOf PropChanged

      UpdateAmount()
      UpdateRefDoc()
      m_tmpsubmitalDate = Me.m_vat.SubmitalDate
      txtSubmitalDate.Text = MinDateToNull(m_tmpsubmitalDate, "")
      dtpSubmitalDate.Value = MinDateToNow(m_tmpsubmitalDate)
      SetStatus()
      SetLabelText()
      CheckFormEnable()
      m_isInitialized = True
    End Sub
    Private Sub UpdateRefDoc()
      Me.txtRefDocCode.Text = Me.m_vat.RefDoc.Code
      Me.txtRefDocDate.Text = MinDateToNull(Me.m_vat.RefDoc.Date, Me.StringParserService.Parse("${res:Global.BlankDateText}"))
      Me.dtpRefDocDate.Value = MinDateToNow(Me.m_vat.RefDoc.Date)
      Me.txtRefTaxBase.Text = Configuration.FormatToString(Me.m_vat.RefDoc.GetMaximumTaxBase, DigitConfig.Price)
      For Each item As IdValuePair In Me.cmbDirection.Items
        If Me.m_vat.Direction.Value = item.Id Then
          Me.cmbDirection.SelectedItem = item
        End If
      Next
    End Sub
    Private Sub UpdateAmount()
      If allowBlankInvoice Then
        If Not Me.m_vat.ItemCollection(0).Code Is Nothing AndAlso Me.m_vat.ItemCollection(0).Code.Length > 0 Then
          Me.txtAmount.Text = Configuration.FormatToString(Me.m_vat.Amount, DigitConfig.Price)
          Me.txtTaxBase.Text = Configuration.FormatToString(Me.m_vat.TaxBase, DigitConfig.Price)
        End If
      Else
        Me.txtAmount.Text = Configuration.FormatToString(Me.m_vat.Amount, DigitConfig.Price)
        Me.txtTaxBase.Text = Configuration.FormatToString(Me.m_vat.TaxBase, DigitConfig.Price)
      End If

      If Me.m_vat.RefDoc Is Nothing OrElse Me.m_vat.RefDoc.NoVat Then
        Me.Validator.SetRequired(txtCode, False)
        Me.Validator.SetRequired(txtDocDate, False)
        Me.Validator.SetRequired(txtPrintName, False)
        Me.Validator.SetRequired(txtPrintAddress, False)
        Me.txtDocDate.Text = ""
        Me.Validator.SetDataType(txtDocDate, DataTypeConstants.StringType)
        Me.ErrorProvider1.SetError(Me.txtDocDate, "")
        Me.ErrorProvider1.SetError(Me.txtPrintName, "")
        Me.ErrorProvider1.SetError(Me.txtCode, "")
        Me.ErrorProvider1.SetError(Me.txtPrintAddress, "")
      Else
        Me.Validator.SetDataType(txtDocDate, DataTypeConstants.DateTimeType)
        Me.Validator.SetRequired(txtDocDate, True)
        Me.Validator.SetRequired(txtPrintName, True)
        Me.Validator.SetRequired(txtCode, True)
        Me.Validator.SetRequired(txtPrintAddress, True)
      End If
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
      Dim vi As VatItem
      If Me.m_vat.ItemCollection.Count <= 0 Then
        vi = New VatItem
        Me.m_vat.ItemCollection.Add(vi)
      End If
      vi = Me.m_vat.ItemCollection(0)
      Select Case CType(sender, Control).Name.ToLower
        Case "txtcode"
          vi.Code = Me.txtCode.Text
          dirtyFlag = True
        Case "txtnote"
          vi.Note = Me.txtNote.Text
          dirtyFlag = True
        Case "txtprintname"
          vi.PrintName = Me.txtPrintName.Text
          dirtyFlag = True
        Case "txtprintaddress"
          vi.PrintAddress = Me.txtPrintAddress.Text
          dirtyFlag = True
        Case "txttaxbase"
          Dim val As Decimal = 0
          If IsNumeric(Me.txtTaxBase.Text) Then
            val = CDec(Me.txtTaxBase.Text)
          End If
          vi.TaxBase = val
          vi.UseCustomTaxAmount = True
          vi.Amount = Configuration.Format(vi.TaxBase * vi.TaxRate / 100, DigitConfig.Price)
          dirtyFlag = True
          UpdateAmount()
        Case "txtamount"
          Dim val As Decimal = 0
          If IsNumeric(Me.txtAmount.Text) Then
            val = CDec(Me.txtAmount.Text)
          End If
          vi.Amount = val
          dirtyFlag = True
          UpdateAmount()
        Case "dtpdocdate"
          If Not vi.DocDate.Equals(dtpDocDate.Value) Then
            If Not m_dateSetting Then
              Me.txtDocDate.Text = MinDateToNull(dtpDocDate.Value, Me.StringParserService.Parse("${res:Global.BlankDateText}"))
              vi.DocDate = dtpDocDate.Value
            End If
            dirtyFlag = True
          End If
        Case "txtdocdate"
          m_dateSetting = True
          If Not Me.txtDocDate.Text.Length = 0 AndAlso Me.Validator.GetErrorMessage(Me.txtDocDate) = "" Then
            Dim theDate As Date = CDate(Me.txtDocDate.Text)
            If Not vi.DocDate.Equals(theDate) Then
              dtpDocDate.Value = theDate
              vi.DocDate = dtpDocDate.Value
              dirtyFlag = True
            End If
          Else
            dtpDocDate.Value = Date.Now
            vi.DocDate = Date.MinValue
            dirtyFlag = True
          End If
          m_dateSetting = False
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
        Case "txtvatgroupcode"
          dirtyFlag = VatGroup.GetVatGroup(txtVatGroupCode, txtVatGroupName, Me.m_vat.VatGroup)
          txtVatGroupCode.Text = Me.m_vat.VatGroup.Code
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
        If (TypeOf Me.m_entity Is GoodsSold) OrElse (TypeOf Me.m_entity Is SaleCN) OrElse (TypeOf Me.m_entity Is PurchaseCN) Then
          If Not Me.m_vat.ItemCollection Is Nothing Then ' AndAlso Me.m_vat.ItemCollection.Count > 0 Then
            If Not Me.m_vat.AutoGen AndAlso (Me.m_vat.ItemCollection(0).Code Is Nothing OrElse Me.m_vat.ItemCollection(0).Code.Length <= 0) Then
              allowBlankInvoice = True
            Else
              allowBlankInvoice = False
            End If
          End If
        End If
        UpdateEntityProperties()
        If m_vat.RefDoc.NoVat Then
          Me.m_vat.ItemCollection.Clear()
        End If
      End Set
    End Property

    Public Overrides Sub Initialize()
      CodeDescription.ListCodeDescriptionInComboBox(Me.cmbDirection, "vat_direction")
    End Sub
#End Region

#Region "Buttons Event"
    Private Sub chkAutorun_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkAutorun.CheckedChanged
      UpdateAutogenStatus()
      If Me.m_isInitialized Then
        Me.WorkbenchWindow.ViewContent.IsDirty = True
      End If
    End Sub
    Private m_oldCode As String = ""
    Private Sub UpdateAutogenStatus()
      If Me.m_vat Is Nothing Then
        Return
      End If
      Dim vi As VatItem
      If Me.m_vat.ItemCollection.Count <= 0 Then
        vi = New VatItem
        Me.m_vat.ItemCollection.Add(vi)
      End If
      vi = Me.m_vat.ItemCollection(0)
      If Me.chkAutorun.Checked Then
        Me.Validator.SetRequired(Me.txtCode, False)
        Me.ErrorProvider1.SetError(Me.txtCode, "")
        Me.txtCode.ReadOnly = True
        m_oldCode = Me.txtCode.Text
        Me.txtCode.Text = BusinessLogic.Entity.GetAutoCodeFormat(vi.EntityId)
        'Hack: set Code เป็น "" เอง
        vi.Code = ""
        Me.m_vat.AutoGen = True
      Else
        Me.Validator.SetRequired(Me.txtCode, True)
        Me.txtCode.Text = m_oldCode
        Me.txtCode.ReadOnly = False
        Me.m_vat.AutoGen = False
      End If
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
#End Region

#Region "IValidatable"
    Public ReadOnly Property FormValidator() As Components.PJMTextboxValidator Implements IValidatable.FormValidator
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
    Public Overrides ReadOnly Property PrintDocument() As System.Drawing.Printing.PrintDocument
      Get
        Dim myPropertyService As PropertyService = CType(ServiceManager.Services.GetService(GetType(PropertyService)), PropertyService)
        Dim FormPath As String = (myPropertyService.DataDirectory & Path.DirectorySeparatorChar & "forms" & Path.DirectorySeparatorChar & "Adobe" & Path.DirectorySeparatorChar & "documents")
        Dim ReportPath As String = (myPropertyService.DataDirectory & Path.DirectorySeparatorChar & "forms" & Path.DirectorySeparatorChar & "Adobe" & Path.DirectorySeparatorChar & "reports")
        Dim thePath As String = ""

        If Not Me.m_vat Is Nothing Then
          If TypeOf Me.m_vat Is IPrintableEntity Then
            Dim fileName As String = CType(Me.m_vat, IPrintableEntity).GetDefaultForm
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

            If File.Exists(thePath) Then
              'Dim df As New DesignerForm(thePath, CType(Me.m_vat, IPrintableEntity))
              Dim df As New DesignerForm(thePath, New SuperPrintableEntity)
              Return df.PrintDocument
            End If
          End If
        End If
      End Get
    End Property
    Public Overrides ReadOnly Property CanPrint() As Boolean
      Get
        Return True
      End Get
    End Property
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
        Return m_vat
      End Get
    End Property
#End Region

    Public Sub SetNothing() Implements ISetNothingEntity.SetNothing
      Me.m_entity = Nothing
    End Sub

  End Class
End Namespace