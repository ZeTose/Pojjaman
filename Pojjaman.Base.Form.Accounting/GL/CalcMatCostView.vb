Imports Longkong.Pojjaman.Services
Imports Longkong.Core.Services

Imports Longkong.Pojjaman.Gui
Imports Longkong.Pojjaman.BusinessLogic
Imports System.Drawing.Printing
Imports Longkong.Pojjaman.Gui.Components
Imports System.Globalization
Imports System.Reflection
Imports Longkong.Pojjaman.TextHelper
Imports Longkong.Pojjaman.Gui.ReportsAndDocs
Imports System.IO
Imports Longkong.Core.Properties
Imports Longkong.AdobeForm
Namespace Longkong.Pojjaman.Gui.Panels
  Public Class CalcMatCostView
    Inherits AbstractEntityDetailPanelView
    Implements IValidatable

#Region " Windows Form Designer generated code "
    Friend WithEvents txtMatBf As System.Windows.Forms.TextBox
    Friend WithEvents lblMatOpenTotalAmount As System.Windows.Forms.Label
    Friend WithEvents txtMatBuy As System.Windows.Forms.TextBox
    Friend WithEvents grbMatSum As Longkong.Pojjaman.Gui.Components.FixedGroupBox
    Friend WithEvents lblMatBf As System.Windows.Forms.Label
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents Validator As Longkong.Pojjaman.Gui.Components.PJMTextboxValidator
    Friend WithEvents grbDetail As Longkong.Pojjaman.Gui.Components.FixedGroupBox
    Friend WithEvents chkAutorun As System.Windows.Forms.CheckBox
    Friend WithEvents txtToCostCenterName As System.Windows.Forms.TextBox
    Friend WithEvents ibtnShowToCostCenterDialog As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents txtToCostCenterCode As System.Windows.Forms.TextBox
    Friend WithEvents lblToCostCenter As System.Windows.Forms.Label
    Friend WithEvents txtNote As System.Windows.Forms.TextBox
    Friend WithEvents lblNote As System.Windows.Forms.Label
    Friend WithEvents txtDocDate As System.Windows.Forms.TextBox
    Friend WithEvents dtpDocDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblDocDate As System.Windows.Forms.Label
    Friend WithEvents lblCode As System.Windows.Forms.Label
    Friend WithEvents cmbCode As System.Windows.Forms.ComboBox
    Friend WithEvents lblCalcNumber As System.Windows.Forms.Label
    Friend WithEvents btnCalculate As System.Windows.Forms.Button
    Friend WithEvents lblMatSum As System.Windows.Forms.Label
    Friend WithEvents txtMatSum As System.Windows.Forms.TextBox
    Friend WithEvents lblMatBal As System.Windows.Forms.Label
    Friend WithEvents txtMatBal As System.Windows.Forms.TextBox
    Friend WithEvents txtMoveOut As System.Windows.Forms.TextBox
    Friend WithEvents lblMoveOut As System.Windows.Forms.Label
    Friend WithEvents txtMoveIn As System.Windows.Forms.TextBox
    Friend WithEvents lblMoveIn As System.Windows.Forms.Label
    Friend WithEvents grpWIPSum As Longkong.Pojjaman.Gui.Components.FixedGroupBox
    Friend WithEvents lblMatSum2 As System.Windows.Forms.Label
    Friend WithEvents lblWIPSum As System.Windows.Forms.Label
    Friend WithEvents txtWIPOut As System.Windows.Forms.TextBox
    Friend WithEvents txtWIPSum As System.Windows.Forms.TextBox
    Friend WithEvents txtBuyOther As System.Windows.Forms.TextBox
    Friend WithEvents lblWIPMoveOut As System.Windows.Forms.Label
    Friend WithEvents lblWIPBF As System.Windows.Forms.Label
    Friend WithEvents txtWIPBF As System.Windows.Forms.TextBox
    Friend WithEvents txtEndCalcDate As System.Windows.Forms.TextBox
    Friend WithEvents dtpEndCalcDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtStartCalcDate As System.Windows.Forms.TextBox
    Friend WithEvents dtpStartCalcDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents FlowLayoutPanel1 As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents txtMatSum2 As System.Windows.Forms.TextBox
    Friend WithEvents FlowLayoutPanel3 As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents FlowLayoutPanel2 As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents lblStatus As System.Windows.Forms.Label
    Protected Sub InitializeComponent()
      Me.components = New System.ComponentModel.Container()
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CalcMatCostView))
      Me.txtMatBf = New System.Windows.Forms.TextBox()
      Me.lblMatBf = New System.Windows.Forms.Label()
      Me.lblMatOpenTotalAmount = New System.Windows.Forms.Label()
      Me.txtMatBuy = New System.Windows.Forms.TextBox()
      Me.grbMatSum = New Longkong.Pojjaman.Gui.Components.FixedGroupBox()
      Me.FlowLayoutPanel3 = New System.Windows.Forms.FlowLayoutPanel()
      Me.lblMoveOut = New System.Windows.Forms.Label()
      Me.txtMoveOut = New System.Windows.Forms.TextBox()
      Me.lblMatBal = New System.Windows.Forms.Label()
      Me.txtMatBal = New System.Windows.Forms.TextBox()
      Me.FlowLayoutPanel2 = New System.Windows.Forms.FlowLayoutPanel()
      Me.lblMoveIn = New System.Windows.Forms.Label()
      Me.txtMoveIn = New System.Windows.Forms.TextBox()
      Me.lblMatSum = New System.Windows.Forms.Label()
      Me.txtMatSum = New System.Windows.Forms.TextBox()
      Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
      Me.txtDocDate = New System.Windows.Forms.TextBox()
      Me.cmbCode = New System.Windows.Forms.ComboBox()
      Me.txtStartCalcDate = New System.Windows.Forms.TextBox()
      Me.txtEndCalcDate = New System.Windows.Forms.TextBox()
      Me.Validator = New Longkong.Pojjaman.Gui.Components.PJMTextboxValidator(Me.components)
      Me.txtToCostCenterName = New System.Windows.Forms.TextBox()
      Me.txtToCostCenterCode = New System.Windows.Forms.TextBox()
      Me.txtNote = New System.Windows.Forms.TextBox()
      Me.txtWIPSum = New System.Windows.Forms.TextBox()
      Me.txtBuyOther = New System.Windows.Forms.TextBox()
      Me.txtWIPBF = New System.Windows.Forms.TextBox()
      Me.txtWIPOut = New System.Windows.Forms.TextBox()
      Me.txtMatSum2 = New System.Windows.Forms.TextBox()
      Me.grbDetail = New Longkong.Pojjaman.Gui.Components.FixedGroupBox()
      Me.dtpEndCalcDate = New System.Windows.Forms.DateTimePicker()
      Me.Label2 = New System.Windows.Forms.Label()
      Me.dtpStartCalcDate = New System.Windows.Forms.DateTimePicker()
      Me.Label1 = New System.Windows.Forms.Label()
      Me.lblCalcNumber = New System.Windows.Forms.Label()
      Me.chkAutorun = New System.Windows.Forms.CheckBox()
      Me.ibtnShowToCostCenterDialog = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.lblToCostCenter = New System.Windows.Forms.Label()
      Me.lblNote = New System.Windows.Forms.Label()
      Me.dtpDocDate = New System.Windows.Forms.DateTimePicker()
      Me.lblDocDate = New System.Windows.Forms.Label()
      Me.lblCode = New System.Windows.Forms.Label()
      Me.lblStatus = New System.Windows.Forms.Label()
      Me.btnCalculate = New System.Windows.Forms.Button()
      Me.grpWIPSum = New Longkong.Pojjaman.Gui.Components.FixedGroupBox()
      Me.FlowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel()
      Me.lblWIPBF = New System.Windows.Forms.Label()
      Me.lblMatSum2 = New System.Windows.Forms.Label()
      Me.lblWIPMoveOut = New System.Windows.Forms.Label()
      Me.Label4 = New System.Windows.Forms.Label()
      Me.lblWIPSum = New System.Windows.Forms.Label()
      Me.grbMatSum.SuspendLayout()
      Me.FlowLayoutPanel3.SuspendLayout()
      Me.FlowLayoutPanel2.SuspendLayout()
      CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.grbDetail.SuspendLayout()
      Me.grpWIPSum.SuspendLayout()
      Me.FlowLayoutPanel1.SuspendLayout()
      Me.SuspendLayout()
      '
      'txtMatBf
      '
      Me.txtMatBf.BackColor = System.Drawing.SystemColors.Control
      Me.txtMatBf.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
      Me.Validator.SetDataType(Me.txtMatBf, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtMatBf, "")
      Me.Validator.SetGotFocusBackColor(Me.txtMatBf, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtMatBf, System.Drawing.Color.Empty)
      Me.txtMatBf.Location = New System.Drawing.Point(105, 3)
      Me.Validator.SetMinValue(Me.txtMatBf, "")
      Me.txtMatBf.Name = "txtMatBf"
      Me.txtMatBf.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtMatBf, "")
      Me.Validator.SetRequired(Me.txtMatBf, False)
      Me.txtMatBf.Size = New System.Drawing.Size(128, 21)
      Me.txtMatBf.TabIndex = 0
      Me.txtMatBf.TabStop = False
      Me.txtMatBf.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
      '
      'lblMatBf
      '
      Me.lblMatBf.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblMatBf.Location = New System.Drawing.Point(3, 0)
      Me.lblMatBf.Name = "lblMatBf"
      Me.lblMatBf.Size = New System.Drawing.Size(96, 18)
      Me.lblMatBf.TabIndex = 124
      Me.lblMatBf.Text = "วัสดุยกมา"
      Me.lblMatBf.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblMatOpenTotalAmount
      '
      Me.lblMatOpenTotalAmount.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblMatOpenTotalAmount.Location = New System.Drawing.Point(3, 27)
      Me.lblMatOpenTotalAmount.Name = "lblMatOpenTotalAmount"
      Me.lblMatOpenTotalAmount.Size = New System.Drawing.Size(96, 18)
      Me.lblMatOpenTotalAmount.TabIndex = 124
      Me.lblMatOpenTotalAmount.Text = "ซื้อวัสดุ"
      Me.lblMatOpenTotalAmount.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'txtMatBuy
      '
      Me.txtMatBuy.BackColor = System.Drawing.SystemColors.Control
      Me.txtMatBuy.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
      Me.Validator.SetDataType(Me.txtMatBuy, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtMatBuy, "")
      Me.Validator.SetGotFocusBackColor(Me.txtMatBuy, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtMatBuy, System.Drawing.Color.Empty)
      Me.txtMatBuy.Location = New System.Drawing.Point(105, 30)
      Me.Validator.SetMinValue(Me.txtMatBuy, "")
      Me.txtMatBuy.Name = "txtMatBuy"
      Me.txtMatBuy.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtMatBuy, "")
      Me.Validator.SetRequired(Me.txtMatBuy, False)
      Me.txtMatBuy.Size = New System.Drawing.Size(128, 21)
      Me.txtMatBuy.TabIndex = 0
      Me.txtMatBuy.TabStop = False
      Me.txtMatBuy.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'grbMatSum
      '
      Me.grbMatSum.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                  Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.grbMatSum.Controls.Add(Me.FlowLayoutPanel3)
      Me.grbMatSum.Controls.Add(Me.FlowLayoutPanel2)
      Me.grbMatSum.Controls.Add(Me.lblMatSum)
      Me.grbMatSum.Controls.Add(Me.txtMatSum)
      Me.grbMatSum.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.grbMatSum.Location = New System.Drawing.Point(10, 136)
      Me.grbMatSum.Name = "grbMatSum"
      Me.grbMatSum.Size = New System.Drawing.Size(266, 288)
      Me.grbMatSum.TabIndex = 165
      Me.grbMatSum.TabStop = False
      Me.grbMatSum.Text = "สรุปยอดวัสดุ"
      '
      'FlowLayoutPanel3
      '
      Me.FlowLayoutPanel3.Controls.Add(Me.lblMoveOut)
      Me.FlowLayoutPanel3.Controls.Add(Me.txtMoveOut)
      Me.FlowLayoutPanel3.Controls.Add(Me.lblMatBal)
      Me.FlowLayoutPanel3.Controls.Add(Me.txtMatBal)
      Me.FlowLayoutPanel3.Location = New System.Drawing.Point(14, 116)
      Me.FlowLayoutPanel3.Name = "FlowLayoutPanel3"
      Me.FlowLayoutPanel3.Size = New System.Drawing.Size(238, 56)
      Me.FlowLayoutPanel3.TabIndex = 323
      '
      'lblMoveOut
      '
      Me.lblMoveOut.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblMoveOut.Location = New System.Drawing.Point(3, 0)
      Me.lblMoveOut.Name = "lblMoveOut"
      Me.lblMoveOut.Size = New System.Drawing.Size(96, 18)
      Me.lblMoveOut.TabIndex = 128
      Me.lblMoveOut.Text = "โอนจ่าย"
      Me.lblMoveOut.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'txtMoveOut
      '
      Me.txtMoveOut.BackColor = System.Drawing.SystemColors.Control
      Me.txtMoveOut.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
      Me.Validator.SetDataType(Me.txtMoveOut, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtMoveOut, "")
      Me.Validator.SetGotFocusBackColor(Me.txtMoveOut, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtMoveOut, System.Drawing.Color.Empty)
      Me.txtMoveOut.Location = New System.Drawing.Point(105, 3)
      Me.Validator.SetMinValue(Me.txtMoveOut, "")
      Me.txtMoveOut.Name = "txtMoveOut"
      Me.txtMoveOut.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtMoveOut, "")
      Me.Validator.SetRequired(Me.txtMoveOut, False)
      Me.txtMoveOut.Size = New System.Drawing.Size(128, 21)
      Me.txtMoveOut.TabIndex = 127
      Me.txtMoveOut.TabStop = False
      Me.txtMoveOut.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'lblMatBal
      '
      Me.lblMatBal.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblMatBal.Location = New System.Drawing.Point(3, 27)
      Me.lblMatBal.Name = "lblMatBal"
      Me.lblMatBal.Size = New System.Drawing.Size(96, 18)
      Me.lblMatBal.TabIndex = 130
      Me.lblMatBal.Text = "วัสดุคงเหลือยกไป"
      Me.lblMatBal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'txtMatBal
      '
      Me.txtMatBal.BackColor = System.Drawing.SystemColors.Control
      Me.txtMatBal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
      Me.Validator.SetDataType(Me.txtMatBal, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtMatBal, "")
      Me.Validator.SetGotFocusBackColor(Me.txtMatBal, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtMatBal, System.Drawing.Color.Empty)
      Me.txtMatBal.Location = New System.Drawing.Point(105, 30)
      Me.Validator.SetMinValue(Me.txtMatBal, "")
      Me.txtMatBal.Name = "txtMatBal"
      Me.txtMatBal.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtMatBal, "")
      Me.Validator.SetRequired(Me.txtMatBal, False)
      Me.txtMatBal.Size = New System.Drawing.Size(128, 21)
      Me.txtMatBal.TabIndex = 129
      Me.txtMatBal.TabStop = False
      Me.txtMatBal.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
      '
      'FlowLayoutPanel2
      '
      Me.FlowLayoutPanel2.Controls.Add(Me.lblMatBf)
      Me.FlowLayoutPanel2.Controls.Add(Me.txtMatBf)
      Me.FlowLayoutPanel2.Controls.Add(Me.lblMatOpenTotalAmount)
      Me.FlowLayoutPanel2.Controls.Add(Me.txtMatBuy)
      Me.FlowLayoutPanel2.Controls.Add(Me.lblMoveIn)
      Me.FlowLayoutPanel2.Controls.Add(Me.txtMoveIn)
      Me.FlowLayoutPanel2.Location = New System.Drawing.Point(14, 20)
      Me.FlowLayoutPanel2.Name = "FlowLayoutPanel2"
      Me.FlowLayoutPanel2.Size = New System.Drawing.Size(242, 90)
      Me.FlowLayoutPanel2.TabIndex = 323
      '
      'lblMoveIn
      '
      Me.lblMoveIn.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblMoveIn.Location = New System.Drawing.Point(3, 54)
      Me.lblMoveIn.Name = "lblMoveIn"
      Me.lblMoveIn.Size = New System.Drawing.Size(96, 18)
      Me.lblMoveIn.TabIndex = 126
      Me.lblMoveIn.Text = "โอนรับ"
      Me.lblMoveIn.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'txtMoveIn
      '
      Me.txtMoveIn.BackColor = System.Drawing.SystemColors.Control
      Me.txtMoveIn.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
      Me.Validator.SetDataType(Me.txtMoveIn, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtMoveIn, "")
      Me.Validator.SetGotFocusBackColor(Me.txtMoveIn, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtMoveIn, System.Drawing.Color.Empty)
      Me.txtMoveIn.Location = New System.Drawing.Point(105, 57)
      Me.Validator.SetMinValue(Me.txtMoveIn, "")
      Me.txtMoveIn.Name = "txtMoveIn"
      Me.txtMoveIn.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtMoveIn, "")
      Me.Validator.SetRequired(Me.txtMoveIn, False)
      Me.txtMoveIn.Size = New System.Drawing.Size(128, 21)
      Me.txtMoveIn.TabIndex = 125
      Me.txtMoveIn.TabStop = False
      Me.txtMoveIn.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'lblMatSum
      '
      Me.lblMatSum.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblMatSum.Location = New System.Drawing.Point(7, 186)
      Me.lblMatSum.Name = "lblMatSum"
      Me.lblMatSum.Size = New System.Drawing.Size(96, 18)
      Me.lblMatSum.TabIndex = 132
      Me.lblMatSum.Text = "วัสดุระหว่างงวด"
      Me.lblMatSum.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'txtMatSum
      '
      Me.txtMatSum.BackColor = System.Drawing.SystemColors.Control
      Me.txtMatSum.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
      Me.Validator.SetDataType(Me.txtMatSum, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtMatSum, "")
      Me.Validator.SetGotFocusBackColor(Me.txtMatSum, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtMatSum, System.Drawing.Color.Empty)
      Me.txtMatSum.Location = New System.Drawing.Point(119, 187)
      Me.Validator.SetMinValue(Me.txtMatSum, "")
      Me.txtMatSum.Name = "txtMatSum"
      Me.txtMatSum.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtMatSum, "")
      Me.Validator.SetRequired(Me.txtMatSum, False)
      Me.txtMatSum.Size = New System.Drawing.Size(128, 21)
      Me.txtMatSum.TabIndex = 131
      Me.txtMatSum.TabStop = False
      Me.txtMatSum.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
      '
      'ErrorProvider1
      '
      Me.ErrorProvider1.ContainerControl = Me
      '
      'txtDocDate
      '
      Me.Validator.SetDataType(Me.txtDocDate, Longkong.Pojjaman.Gui.Components.DataTypeConstants.DateTimeType)
      Me.Validator.SetDisplayName(Me.txtDocDate, "")
      Me.txtDocDate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtDocDate, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtDocDate, 15)
      Me.Validator.SetInvalidBackColor(Me.txtDocDate, System.Drawing.Color.Empty)
      Me.txtDocDate.Location = New System.Drawing.Point(344, 16)
      Me.Validator.SetMinValue(Me.txtDocDate, "")
      Me.txtDocDate.Name = "txtDocDate"
      Me.Validator.SetRegularExpression(Me.txtDocDate, "")
      Me.Validator.SetRequired(Me.txtDocDate, True)
      Me.txtDocDate.Size = New System.Drawing.Size(108, 21)
      Me.txtDocDate.TabIndex = 321
      '
      'cmbCode
      '
      Me.cmbCode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.ErrorProvider1.SetIconPadding(Me.cmbCode, -15)
      Me.cmbCode.Location = New System.Drawing.Point(96, 16)
      Me.cmbCode.Name = "cmbCode"
      Me.cmbCode.Size = New System.Drawing.Size(120, 21)
      Me.cmbCode.TabIndex = 333
      '
      'txtStartCalcDate
      '
      Me.Validator.SetDataType(Me.txtStartCalcDate, Longkong.Pojjaman.Gui.Components.DataTypeConstants.DateTimeType)
      Me.Validator.SetDisplayName(Me.txtStartCalcDate, "")
      Me.txtStartCalcDate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtStartCalcDate, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtStartCalcDate, 15)
      Me.Validator.SetInvalidBackColor(Me.txtStartCalcDate, System.Drawing.Color.Empty)
      Me.txtStartCalcDate.Location = New System.Drawing.Point(96, 43)
      Me.Validator.SetMinValue(Me.txtStartCalcDate, "")
      Me.txtStartCalcDate.Name = "txtStartCalcDate"
      Me.txtStartCalcDate.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtStartCalcDate, "")
      Me.Validator.SetRequired(Me.txtStartCalcDate, False)
      Me.txtStartCalcDate.Size = New System.Drawing.Size(108, 21)
      Me.txtStartCalcDate.TabIndex = 335
      '
      'txtEndCalcDate
      '
      Me.Validator.SetDataType(Me.txtEndCalcDate, Longkong.Pojjaman.Gui.Components.DataTypeConstants.DateTimeType)
      Me.Validator.SetDisplayName(Me.txtEndCalcDate, "")
      Me.txtEndCalcDate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtEndCalcDate, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtEndCalcDate, 15)
      Me.Validator.SetInvalidBackColor(Me.txtEndCalcDate, System.Drawing.Color.Empty)
      Me.txtEndCalcDate.Location = New System.Drawing.Point(344, 43)
      Me.Validator.SetMinValue(Me.txtEndCalcDate, "")
      Me.txtEndCalcDate.Name = "txtEndCalcDate"
      Me.Validator.SetRegularExpression(Me.txtEndCalcDate, "")
      Me.Validator.SetRequired(Me.txtEndCalcDate, True)
      Me.txtEndCalcDate.Size = New System.Drawing.Size(108, 21)
      Me.txtEndCalcDate.TabIndex = 338
      '
      'Validator
      '
      Me.Validator.BackcolorChanging = False
      Me.Validator.DataTable = Nothing
      Me.Validator.ErrorProvider = Me.ErrorProvider1
      Me.Validator.GotFocusBackColor = System.Drawing.Color.Empty
      Me.Validator.HasNewRow = False
      Me.Validator.InvalidBackColor = System.Drawing.Color.Empty
      '
      'txtToCostCenterName
      '
      Me.txtToCostCenterName.BackColor = System.Drawing.SystemColors.Control
      Me.Validator.SetDataType(Me.txtToCostCenterName, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtToCostCenterName, "")
      Me.txtToCostCenterName.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtToCostCenterName, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtToCostCenterName, System.Drawing.Color.Empty)
      Me.txtToCostCenterName.Location = New System.Drawing.Point(182, 70)
      Me.Validator.SetMinValue(Me.txtToCostCenterName, "")
      Me.txtToCostCenterName.Name = "txtToCostCenterName"
      Me.txtToCostCenterName.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtToCostCenterName, "")
      Me.Validator.SetRequired(Me.txtToCostCenterName, False)
      Me.txtToCostCenterName.Size = New System.Drawing.Size(124, 21)
      Me.txtToCostCenterName.TabIndex = 331
      Me.txtToCostCenterName.TabStop = False
      '
      'txtToCostCenterCode
      '
      Me.txtToCostCenterCode.BackColor = System.Drawing.SystemColors.Window
      Me.Validator.SetDataType(Me.txtToCostCenterCode, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtToCostCenterCode, "")
      Me.txtToCostCenterCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtToCostCenterCode, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtToCostCenterCode, System.Drawing.Color.Empty)
      Me.txtToCostCenterCode.Location = New System.Drawing.Point(94, 70)
      Me.Validator.SetMinValue(Me.txtToCostCenterCode, "")
      Me.txtToCostCenterCode.Name = "txtToCostCenterCode"
      Me.Validator.SetRegularExpression(Me.txtToCostCenterCode, "")
      Me.Validator.SetRequired(Me.txtToCostCenterCode, True)
      Me.txtToCostCenterCode.Size = New System.Drawing.Size(88, 21)
      Me.txtToCostCenterCode.TabIndex = 322
      '
      'txtNote
      '
      Me.txtNote.BackColor = System.Drawing.SystemColors.Window
      Me.Validator.SetDataType(Me.txtNote, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtNote, "")
      Me.txtNote.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtNote, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtNote, System.Drawing.Color.Empty)
      Me.txtNote.Location = New System.Drawing.Point(96, 97)
      Me.Validator.SetMinValue(Me.txtNote, "")
      Me.txtNote.Name = "txtNote"
      Me.Validator.SetRegularExpression(Me.txtNote, "")
      Me.Validator.SetRequired(Me.txtNote, False)
      Me.txtNote.Size = New System.Drawing.Size(376, 21)
      Me.txtNote.TabIndex = 323
      '
      'txtWIPSum
      '
      Me.txtWIPSum.BackColor = System.Drawing.SystemColors.Control
      Me.txtWIPSum.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
      Me.Validator.SetDataType(Me.txtWIPSum, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtWIPSum, "")
      Me.Validator.SetGotFocusBackColor(Me.txtWIPSum, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtWIPSum, System.Drawing.Color.Empty)
      Me.txtWIPSum.Location = New System.Drawing.Point(110, 187)
      Me.Validator.SetMinValue(Me.txtWIPSum, "")
      Me.txtWIPSum.Name = "txtWIPSum"
      Me.txtWIPSum.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtWIPSum, "")
      Me.Validator.SetRequired(Me.txtWIPSum, False)
      Me.txtWIPSum.Size = New System.Drawing.Size(119, 21)
      Me.txtWIPSum.TabIndex = 131
      Me.txtWIPSum.TabStop = False
      Me.txtWIPSum.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
      '
      'txtBuyOther
      '
      Me.txtBuyOther.BackColor = System.Drawing.SystemColors.Control
      Me.txtBuyOther.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
      Me.Validator.SetDataType(Me.txtBuyOther, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtBuyOther, "")
      Me.Validator.SetGotFocusBackColor(Me.txtBuyOther, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtBuyOther, System.Drawing.Color.Empty)
      Me.txtBuyOther.Location = New System.Drawing.Point(93, 84)
      Me.Validator.SetMinValue(Me.txtBuyOther, "")
      Me.txtBuyOther.Name = "txtBuyOther"
      Me.txtBuyOther.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtBuyOther, "")
      Me.Validator.SetRequired(Me.txtBuyOther, False)
      Me.txtBuyOther.Size = New System.Drawing.Size(119, 21)
      Me.txtBuyOther.TabIndex = 0
      Me.txtBuyOther.TabStop = False
      Me.txtBuyOther.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'txtWIPBF
      '
      Me.txtWIPBF.BackColor = System.Drawing.SystemColors.Control
      Me.txtWIPBF.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
      Me.Validator.SetDataType(Me.txtWIPBF, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtWIPBF, "")
      Me.Validator.SetGotFocusBackColor(Me.txtWIPBF, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtWIPBF, System.Drawing.Color.Empty)
      Me.txtWIPBF.Location = New System.Drawing.Point(93, 3)
      Me.Validator.SetMinValue(Me.txtWIPBF, "")
      Me.txtWIPBF.Name = "txtWIPBF"
      Me.txtWIPBF.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtWIPBF, "")
      Me.Validator.SetRequired(Me.txtWIPBF, False)
      Me.txtWIPBF.Size = New System.Drawing.Size(119, 21)
      Me.txtWIPBF.TabIndex = 0
      Me.txtWIPBF.TabStop = False
      Me.txtWIPBF.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
      '
      'txtWIPOut
      '
      Me.txtWIPOut.BackColor = System.Drawing.SystemColors.Control
      Me.txtWIPOut.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
      Me.Validator.SetDataType(Me.txtWIPOut, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtWIPOut, "")
      Me.Validator.SetGotFocusBackColor(Me.txtWIPOut, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtWIPOut, System.Drawing.Color.Empty)
      Me.txtWIPOut.Location = New System.Drawing.Point(93, 57)
      Me.Validator.SetMinValue(Me.txtWIPOut, "")
      Me.txtWIPOut.Name = "txtWIPOut"
      Me.txtWIPOut.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtWIPOut, "")
      Me.Validator.SetRequired(Me.txtWIPOut, False)
      Me.txtWIPOut.Size = New System.Drawing.Size(119, 21)
      Me.txtWIPOut.TabIndex = 133
      Me.txtWIPOut.TabStop = False
      Me.txtWIPOut.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
      '
      'txtMatSum2
      '
      Me.txtMatSum2.BackColor = System.Drawing.SystemColors.Control
      Me.txtMatSum2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
      Me.Validator.SetDataType(Me.txtMatSum2, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtMatSum2, "")
      Me.Validator.SetGotFocusBackColor(Me.txtMatSum2, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtMatSum2, System.Drawing.Color.Empty)
      Me.txtMatSum2.Location = New System.Drawing.Point(93, 30)
      Me.Validator.SetMinValue(Me.txtMatSum2, "")
      Me.txtMatSum2.Name = "txtMatSum2"
      Me.txtMatSum2.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtMatSum2, "")
      Me.Validator.SetRequired(Me.txtMatSum2, False)
      Me.txtMatSum2.Size = New System.Drawing.Size(119, 21)
      Me.txtMatSum2.TabIndex = 135
      Me.txtMatSum2.TabStop = False
      Me.txtMatSum2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
      '
      'grbDetail
      '
      Me.grbDetail.Controls.Add(Me.txtEndCalcDate)
      Me.grbDetail.Controls.Add(Me.dtpEndCalcDate)
      Me.grbDetail.Controls.Add(Me.Label2)
      Me.grbDetail.Controls.Add(Me.txtStartCalcDate)
      Me.grbDetail.Controls.Add(Me.dtpStartCalcDate)
      Me.grbDetail.Controls.Add(Me.Label1)
      Me.grbDetail.Controls.Add(Me.lblCalcNumber)
      Me.grbDetail.Controls.Add(Me.cmbCode)
      Me.grbDetail.Controls.Add(Me.chkAutorun)
      Me.grbDetail.Controls.Add(Me.txtToCostCenterName)
      Me.grbDetail.Controls.Add(Me.ibtnShowToCostCenterDialog)
      Me.grbDetail.Controls.Add(Me.txtToCostCenterCode)
      Me.grbDetail.Controls.Add(Me.lblToCostCenter)
      Me.grbDetail.Controls.Add(Me.txtNote)
      Me.grbDetail.Controls.Add(Me.lblNote)
      Me.grbDetail.Controls.Add(Me.txtDocDate)
      Me.grbDetail.Controls.Add(Me.dtpDocDate)
      Me.grbDetail.Controls.Add(Me.lblDocDate)
      Me.grbDetail.Controls.Add(Me.lblCode)
      Me.grbDetail.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.grbDetail.Location = New System.Drawing.Point(8, 6)
      Me.grbDetail.Name = "grbDetail"
      Me.grbDetail.Size = New System.Drawing.Size(478, 124)
      Me.grbDetail.TabIndex = 320
      Me.grbDetail.TabStop = False
      Me.grbDetail.Text = "คิดแบบ"
      '
      'dtpEndCalcDate
      '
      Me.dtpEndCalcDate.CustomFormat = "dd/MM/yyyy"
      Me.dtpEndCalcDate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.dtpEndCalcDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
      Me.dtpEndCalcDate.Location = New System.Drawing.Point(344, 43)
      Me.dtpEndCalcDate.Name = "dtpEndCalcDate"
      Me.dtpEndCalcDate.Size = New System.Drawing.Size(130, 21)
      Me.dtpEndCalcDate.TabIndex = 340
      Me.dtpEndCalcDate.TabStop = False
      Me.dtpEndCalcDate.Value = New Date(2006, 6, 19, 9, 18, 42, 500)
      '
      'Label2
      '
      Me.Label2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Label2.ForeColor = System.Drawing.Color.Black
      Me.Label2.Location = New System.Drawing.Point(248, 43)
      Me.Label2.Name = "Label2"
      Me.Label2.Size = New System.Drawing.Size(92, 18)
      Me.Label2.TabIndex = 339
      Me.Label2.Text = "สิ้นสุด:"
      Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'dtpStartCalcDate
      '
      Me.dtpStartCalcDate.CustomFormat = "dd/MM/yyyy"
      Me.dtpStartCalcDate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.dtpStartCalcDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
      Me.dtpStartCalcDate.Location = New System.Drawing.Point(96, 43)
      Me.dtpStartCalcDate.Name = "dtpStartCalcDate"
      Me.dtpStartCalcDate.Size = New System.Drawing.Size(130, 21)
      Me.dtpStartCalcDate.TabIndex = 337
      Me.dtpStartCalcDate.TabStop = False
      Me.dtpStartCalcDate.Value = New Date(2006, 6, 19, 9, 18, 42, 500)
      '
      'Label1
      '
      Me.Label1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Label1.ForeColor = System.Drawing.Color.Black
      Me.Label1.Location = New System.Drawing.Point(11, 43)
      Me.Label1.Name = "Label1"
      Me.Label1.Size = New System.Drawing.Size(81, 18)
      Me.Label1.TabIndex = 336
      Me.Label1.Text = "เริ่มคำนวณ:"
      Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblCalcNumber
      '
      Me.lblCalcNumber.AutoSize = True
      Me.lblCalcNumber.Location = New System.Drawing.Point(337, 74)
      Me.lblCalcNumber.Name = "lblCalcNumber"
      Me.lblCalcNumber.Size = New System.Drawing.Size(38, 13)
      Me.lblCalcNumber.TabIndex = 334
      Me.lblCalcNumber.Text = "Label1"
      '
      'chkAutorun
      '
      Me.chkAutorun.Appearance = System.Windows.Forms.Appearance.Button
      Me.chkAutorun.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.chkAutorun.Image = CType(resources.GetObject("chkAutorun.Image"), System.Drawing.Image)
      Me.chkAutorun.Location = New System.Drawing.Point(215, 16)
      Me.chkAutorun.Name = "chkAutorun"
      Me.chkAutorun.Size = New System.Drawing.Size(21, 21)
      Me.chkAutorun.TabIndex = 332
      '
      'ibtnShowToCostCenterDialog
      '
      Me.ibtnShowToCostCenterDialog.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.ibtnShowToCostCenterDialog.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.ibtnShowToCostCenterDialog.ForeColor = System.Drawing.SystemColors.Control
      Me.ibtnShowToCostCenterDialog.Location = New System.Drawing.Point(306, 68)
      Me.ibtnShowToCostCenterDialog.Name = "ibtnShowToCostCenterDialog"
      Me.ibtnShowToCostCenterDialog.Size = New System.Drawing.Size(24, 23)
      Me.ibtnShowToCostCenterDialog.TabIndex = 329
      Me.ibtnShowToCostCenterDialog.TabStop = False
      Me.ibtnShowToCostCenterDialog.ThemedImage = CType(resources.GetObject("ibtnShowToCostCenterDialog.ThemedImage"), System.Drawing.Bitmap)
      '
      'lblToCostCenter
      '
      Me.lblToCostCenter.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblToCostCenter.Location = New System.Drawing.Point(6, 70)
      Me.lblToCostCenter.Name = "lblToCostCenter"
      Me.lblToCostCenter.Size = New System.Drawing.Size(80, 18)
      Me.lblToCostCenter.TabIndex = 328
      Me.lblToCostCenter.Text = "คลัง:"
      Me.lblToCostCenter.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblNote
      '
      Me.lblNote.BackColor = System.Drawing.Color.Transparent
      Me.lblNote.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblNote.Location = New System.Drawing.Point(8, 97)
      Me.lblNote.Name = "lblNote"
      Me.lblNote.Size = New System.Drawing.Size(80, 18)
      Me.lblNote.TabIndex = 327
      Me.lblNote.Text = "หมายเหตุ:"
      Me.lblNote.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'dtpDocDate
      '
      Me.dtpDocDate.CustomFormat = "dd/MM/yyyy"
      Me.dtpDocDate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.dtpDocDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
      Me.dtpDocDate.Location = New System.Drawing.Point(344, 16)
      Me.dtpDocDate.Name = "dtpDocDate"
      Me.dtpDocDate.Size = New System.Drawing.Size(130, 21)
      Me.dtpDocDate.TabIndex = 326
      Me.dtpDocDate.TabStop = False
      Me.dtpDocDate.Value = New Date(2006, 6, 19, 9, 18, 42, 500)
      '
      'lblDocDate
      '
      Me.lblDocDate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblDocDate.ForeColor = System.Drawing.Color.Black
      Me.lblDocDate.Location = New System.Drawing.Point(248, 16)
      Me.lblDocDate.Name = "lblDocDate"
      Me.lblDocDate.Size = New System.Drawing.Size(92, 18)
      Me.lblDocDate.TabIndex = 325
      Me.lblDocDate.Text = "วันที่เอกสาร:"
      Me.lblDocDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblCode
      '
      Me.lblCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblCode.Location = New System.Drawing.Point(8, 16)
      Me.lblCode.Name = "lblCode"
      Me.lblCode.Size = New System.Drawing.Size(80, 18)
      Me.lblCode.TabIndex = 324
      Me.lblCode.Text = "เลขที่เอกสาร"
      Me.lblCode.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblStatus
      '
      Me.lblStatus.AutoSize = True
      Me.lblStatus.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblStatus.Location = New System.Drawing.Point(507, 108)
      Me.lblStatus.Name = "lblStatus"
      Me.lblStatus.Size = New System.Drawing.Size(48, 13)
      Me.lblStatus.TabIndex = 321
      Me.lblStatus.Text = "lblStatus"
      Me.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'btnCalculate
      '
      Me.btnCalculate.Location = New System.Drawing.Point(583, 103)
      Me.btnCalculate.Name = "btnCalculate"
      Me.btnCalculate.Size = New System.Drawing.Size(75, 23)
      Me.btnCalculate.TabIndex = 322
      Me.btnCalculate.Text = "Calculate"
      Me.btnCalculate.UseVisualStyleBackColor = True
      '
      'grpWIPSum
      '
      Me.grpWIPSum.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                  Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.grpWIPSum.Controls.Add(Me.FlowLayoutPanel1)
      Me.grpWIPSum.Controls.Add(Me.lblWIPSum)
      Me.grpWIPSum.Controls.Add(Me.txtWIPSum)
      Me.grpWIPSum.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.grpWIPSum.Location = New System.Drawing.Point(291, 136)
      Me.grpWIPSum.Name = "grpWIPSum"
      Me.grpWIPSum.Size = New System.Drawing.Size(266, 288)
      Me.grpWIPSum.TabIndex = 166
      Me.grpWIPSum.TabStop = False
      Me.grpWIPSum.Text = "สรุปยอดวัสดุงานระหว่างทำ"
      '
      'FlowLayoutPanel1
      '
      Me.FlowLayoutPanel1.Controls.Add(Me.lblWIPBF)
      Me.FlowLayoutPanel1.Controls.Add(Me.txtWIPBF)
      Me.FlowLayoutPanel1.Controls.Add(Me.lblMatSum2)
      Me.FlowLayoutPanel1.Controls.Add(Me.txtMatSum2)
      Me.FlowLayoutPanel1.Controls.Add(Me.lblWIPMoveOut)
      Me.FlowLayoutPanel1.Controls.Add(Me.txtWIPOut)
      Me.FlowLayoutPanel1.Controls.Add(Me.Label4)
      Me.FlowLayoutPanel1.Controls.Add(Me.txtBuyOther)
      Me.FlowLayoutPanel1.Location = New System.Drawing.Point(17, 20)
      Me.FlowLayoutPanel1.Name = "FlowLayoutPanel1"
      Me.FlowLayoutPanel1.Size = New System.Drawing.Size(232, 114)
      Me.FlowLayoutPanel1.TabIndex = 323
      '
      'lblWIPBF
      '
      Me.lblWIPBF.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblWIPBF.Location = New System.Drawing.Point(3, 0)
      Me.lblWIPBF.Name = "lblWIPBF"
      Me.lblWIPBF.Size = New System.Drawing.Size(84, 24)
      Me.lblWIPBF.TabIndex = 124
      Me.lblWIPBF.Text = "WIP ยกมา"
      Me.lblWIPBF.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblMatSum2
      '
      Me.lblMatSum2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblMatSum2.Location = New System.Drawing.Point(3, 27)
      Me.lblMatSum2.Name = "lblMatSum2"
      Me.lblMatSum2.Size = New System.Drawing.Size(84, 17)
      Me.lblMatSum2.TabIndex = 134
      Me.lblMatSum2.Text = "วัสดุระหว่างงวด"
      Me.lblMatSum2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblWIPMoveOut
      '
      Me.lblWIPMoveOut.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblWIPMoveOut.Location = New System.Drawing.Point(3, 54)
      Me.lblWIPMoveOut.Name = "lblWIPMoveOut"
      Me.lblWIPMoveOut.Size = New System.Drawing.Size(84, 20)
      Me.lblWIPMoveOut.TabIndex = 124
      Me.lblWIPMoveOut.Text = "คืน WIP"
      Me.lblWIPMoveOut.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'Label4
      '
      Me.Label4.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Label4.Location = New System.Drawing.Point(3, 81)
      Me.Label4.Name = "Label4"
      Me.Label4.Size = New System.Drawing.Size(84, 17)
      Me.Label4.TabIndex = 138
      Me.Label4.Text = "อื่นๆ ระหว่างงวด"
      Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblWIPSum
      '
      Me.lblWIPSum.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblWIPSum.Location = New System.Drawing.Point(20, 185)
      Me.lblWIPSum.Name = "lblWIPSum"
      Me.lblWIPSum.Size = New System.Drawing.Size(84, 20)
      Me.lblWIPSum.TabIndex = 132
      Me.lblWIPSum.Text = "สรุปยอด WIP"
      Me.lblWIPSum.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'CalcMatCostView
      '
      Me.Controls.Add(Me.grpWIPSum)
      Me.Controls.Add(Me.btnCalculate)
      Me.Controls.Add(Me.lblStatus)
      Me.Controls.Add(Me.grbDetail)
      Me.Controls.Add(Me.grbMatSum)
      Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Name = "CalcMatCostView"
      Me.Size = New System.Drawing.Size(688, 433)
      Me.grbMatSum.ResumeLayout(False)
      Me.grbMatSum.PerformLayout()
      Me.FlowLayoutPanel3.ResumeLayout(False)
      Me.FlowLayoutPanel3.PerformLayout()
      Me.FlowLayoutPanel2.ResumeLayout(False)
      Me.FlowLayoutPanel2.PerformLayout()
      CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
      Me.grbDetail.ResumeLayout(False)
      Me.grbDetail.PerformLayout()
      Me.grpWIPSum.ResumeLayout(False)
      Me.grpWIPSum.PerformLayout()
      Me.FlowLayoutPanel1.ResumeLayout(False)
      Me.FlowLayoutPanel1.PerformLayout()
      Me.ResumeLayout(False)
      Me.PerformLayout()

    End Sub
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
#End Region

#Region "Members"
    Private m_entity As CalculateCost
    Private m_isInitialized As Boolean = False
    'Private m_treeManager As TreeManager
    'Private m_tableStyleEnable As Hashtable
    'Private m_entityRefed As Integer
#End Region

#Region "Constructors"
    Public Sub New()
      MyBase.New()
      Me.InitializeComponent()
      Me.SetLabelText()
      Initialize()

      'Dim dt As TreeTable = MatOpenningBalance.GetSchemaTable()
      'Dim dst As DataGridTableStyle = Me.CreateTableStyle()
      'm_treeManager = New TreeManager(dt, tgItem)
      'm_treeManager.SetTableStyle(dst)
      'm_treeManager.AllowSorting = False
      'm_treeManager.AllowDelete = False

      EventWiring()
    End Sub
#End Region

#Region " Style "
    '    Protected Function CreateTableStyle() As DataGridTableStyle
    '      Dim dst As New DataGridTableStyle
    '      dst.MappingName = "MatOpenningBalance"
    '      Dim myStringParserService As StringParserService = CType(ServiceManager.Services.GetService(GetType(StringParserService)), StringParserService)

    '      'Stock Items
    '      Dim csLineNumber As New TreeTextColumn
    '      csLineNumber.MappingName = "stocki_linenumber"
    '      csLineNumber.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.MatOpenningBalanceDetail.LineNumberHeaderText}")
    '      csLineNumber.NullText = ""
    '      csLineNumber.Width = 30
    '      csLineNumber.DataAlignment = HorizontalAlignment.Center
    '      csLineNumber.ReadOnly = True
    '      csLineNumber.TextBox.Name = "stocki_linenumber"

    '      Dim csCode As New TreeTextColumn
    '      csCode.MappingName = "Code"
    '      csCode.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.MatOpenningBalanceDetail.CodeHeaderText}")
    '      csCode.NullText = ""
    '      'csCode.ReadOnly = True
    '      csCode.TextBox.Name = "Code"

    '      Dim csButton As New DataGridButtonColumn
    '      csButton.MappingName = "Button"
    '      csButton.HeaderText = ""
    '      csButton.NullText = ""

    '      Dim csName As New TreeTextColumn
    '      csName.MappingName = "stocki_itemName"
    '      csName.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.MatOpenningBalanceDetail.DescriptionHeaderText}")
    '      csName.NullText = ""
    '      csName.Width = 180
    '      csName.TextBox.Name = "Description"
    '      csName.ReadOnly = True
    '      'AddHandler csDescription.TextBox.TextChanged, AddressOf ChangeProperty
    '      'csDescription.ReadOnly = True

    '      Dim csUnit As New TreeTextColumn
    '      csUnit.MappingName = "Unit"
    '      csUnit.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.MatOpenningBalanceDetail.UnitHeaderText}")
    '      csUnit.NullText = ""
    '      csUnit.TextBox.Name = "Unit"
    '      'AddHandler csUnit.TextBox.TextChanged, AddressOf ChangeProperty
    '      'csUnit.DataAlignment = HorizontalAlignment.Center

    '      Dim csUnitButton As New DataGridButtonColumn
    '      csUnitButton.MappingName = "UnitButton"
    '      csUnitButton.HeaderText = ""
    '      csUnitButton.NullText = ""
    '      AddHandler csUnitButton.Click, AddressOf UnitClicked

    '      Dim csQty As New TreeTextColumn
    '      csQty.MappingName = "stocki_qty"
    '      csQty.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.MatOpenningBalanceDetail.QtyHeaderText}")
    '      csQty.NullText = ""
    '      csQty.DataAlignment = HorizontalAlignment.Right
    '      csQty.Format = "#,###.##"
    '      csQty.TextBox.Name = "Qty"
    '      'AddHandler csQty.TextBox.TextChanged, AddressOf ChangeProperty

    '      Dim csStockQty As New TreeTextColumn
    '      csStockQty.MappingName = "StockQty"
    '      csStockQty.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.MatOpenningBalanceDetail.StockQtyHeaderText}")
    '      csStockQty.NullText = ""
    '      csStockQty.DataAlignment = HorizontalAlignment.Right
    '      csStockQty.Format = "#,###.##"
    '      csStockQty.ReadOnly = True

    '      Dim csUnitPRice As New TreeTextColumn
    '      csUnitPRice.MappingName = "stocki_unitprice"
    '      csUnitPRice.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.MatOpenningBalanceDetail.UnitpriceHeaderText}")
    '      csUnitPRice.NullText = ""
    '      csUnitPRice.DataAlignment = HorizontalAlignment.Right
    '      csUnitPRice.TextBox.Name = "stocki_unitprice"
    '      'AddHandler csUnit.TextBox.TextChanged, AddressOf ChangeProperty
    '      'csUnit.DataAlignment = HorizontalAlignment.Center

    '      Dim csAmount As New TreeTextColumn
    '      csAmount.MappingName = "Amount"
    '      csAmount.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.MatOpenningBalanceDetail.AmountHeaderText}")
    '      csAmount.NullText = ""
    '      csAmount.TextBox.Name = "Amount"
    '      csAmount.ReadOnly = True
    '      csAmount.DataAlignment = HorizontalAlignment.Right
    '      csAmount.Format = "#,###.##"
    '      'AddHandler csUnit.TextBox.TextChanged, AddressOf ChangeProperty
    '      'csUnit.DataAlignment = HorizontalAlignment.Center

    '      Dim csNote As New TreeTextColumn
    '      csNote.MappingName = "stocki_note"
    '      csNote.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.MatOpenningBalanceDetail.NoteHeaderText}")
    '      csNote.NullText = ""
    '      csNote.Width = 180
    '      csNote.TextBox.Name = "stocki_note"

    '      'Dim csSequence As New TreeTextColumn
    '      'csSequence.MappingName = "stocki_sequence"
    '      'csSequence.HeaderText = "" 'myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.MatOpenningBalanceDetail.UnitpriceHeaderText}")
    '      'csSequence.NullText = ""
    '      'csSequence.Width = 0
    '      'csSequence.TextBox.Name = "stocki_sequence"

    '      dst.GridColumnStyles.Add(csLineNumber)
    '      dst.GridColumnStyles.Add(csCode)
    '      dst.GridColumnStyles.Add(csButton)
    '      dst.GridColumnStyles.Add(csName)
    '      dst.GridColumnStyles.Add(csUnit)
    '      dst.GridColumnStyles.Add(csUnitButton)
    '      dst.GridColumnStyles.Add(csQty)
    '      dst.GridColumnStyles.Add(csStockQty)
    '      dst.GridColumnStyles.Add(csUnitPRice)
    '      dst.GridColumnStyles.Add(csAmount)
    '      dst.GridColumnStyles.Add(csNote)
    '      'dst.GridColumnStyles.Add(csSequence)

    '      m_tableStyleEnable = New Hashtable
    '      For Each colStyle As DataGridColumnStyle In dst.GridColumnStyles
    '        m_tableStyleEnable.Add(colStyle, colStyle.ReadOnly)
    '      Next

    '      Return dst
    '    End Function


#End Region

#Region "IListDetail"
    Public Overrides Sub CheckFormEnable()
      'If Me.m_entity.Canceled _
      'OrElse Me.m_entity.Status.Value = 0 _
      'OrElse Me.m_entity.Status.Value >= 3 _
      'OrElse m_entityRefed = 1 Then
      '  For Each ctrl As Control In Me.Controls
      '    ctrl.Enabled = False
      '  Next

      '  tgItem.Enabled = True
      '  For Each colStyle As DataGridColumnStyle In Me.m_treeManager.GridTableStyle.GridColumnStyles
      '    colStyle.ReadOnly = True
      '  Next
      'Else
      '  For Each ctrl As Control In Me.Controls
      '    ctrl.Enabled = True
      '  Next

      '  For Each colStyle As DataGridColumnStyle In Me.m_treeManager.GridTableStyle.GridColumnStyles
      '    colStyle.ReadOnly = CBool(m_tableStyleEnable(colStyle))
      '  Next
      'End If
    End Sub
    Public Overrides Sub ClearDetail()
      For Each crlt As Control In Me.Controls
        If TypeOf crlt Is TextBox Then
          crlt.Text = ""
        ElseIf TypeOf crlt Is FixedGroupBox Then
          For Each ingrb As Control In crlt.Controls
            If TypeOf ingrb Is TextBox Then
              ingrb.Text = ""
            End If
          Next
        End If
      Next
      Me.dtpDocDate.Value = Now
    End Sub
    Public Overrides Sub SetLabelText()
      If Not m_entity Is Nothing Then Me.Text = Me.StringParserService.Parse(Me.m_entity.TabPageText)

      Me.lblCode.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.MatOpenningBalanceDetailView.lblCode}")
      Me.Validator.SetDisplayName(Me.cmbCode, StringHelper.GetRidOfAtEnd(Me.lblCode.Text, ":"))

      Me.lblDocDate.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.MatOpenningBalanceDetailView.lblDocDate}")
      Me.Validator.SetDisplayName(Me.txtDocDate, StringHelper.GetRidOfAtEnd(Me.lblDocDate.Text, ":"))

      Me.lblToCostCenter.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.MatOpenningBalanceDetailView.lblToCostCenter}")
      Me.Validator.SetDisplayName(Me.txtToCostCenterCode, StringHelper.GetRidOfAtEnd(Me.lblToCostCenter.Text, ":"))

      Me.lblMatOpenTotalAmount.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.MatOpenningBalanceDetailView.lblMatOpenTotalAmount}")
      Me.lblMatBf.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.MatOpenningBalanceDetailView.lblItemCount}")

      Me.lblNote.Text = Me.StringParserService.Parse("${res:Global.NoteText}")

      Me.grbMatSum.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.MatOpenningBalanceDetailView.grbSummary}")
      Me.grbDetail.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.MatOpenningBalanceDetailView.grbDetail}")

    End Sub
    Protected Overrides Sub EventWiring()
      AddHandler cmbCode.TextChanged, AddressOf Me.ChangeProperty
      AddHandler cmbCode.SelectedIndexChanged, AddressOf Me.ChangeProperty

      AddHandler txtNote.TextChanged, AddressOf Me.ChangeProperty

      AddHandler txtDocDate.Validated, AddressOf Me.ChangeProperty
      AddHandler dtpDocDate.ValueChanged, AddressOf Me.ChangeProperty

      'AddHandler txtStartCalcDate.Validated, AddressOf Me.ChangeProperty
      'AddHandler dtpStartCalcDate.ValueChanged, AddressOf Me.ChangeProperty

      AddHandler txtEndCalcDate.Validated, AddressOf Me.ChangeProperty
      AddHandler dtpEndCalcDate.ValueChanged, AddressOf Me.ChangeProperty

      AddHandler txtToCostCenterCode.Validated, AddressOf Me.ChangeProperty

    End Sub
    Public Overrides Sub UpdateEntityProperties()
      m_isInitialized = False
      ClearDetail()
      If m_entity Is Nothing Then
        Return
      End If
      'txtCode.Text = m_entity.Code
      m_oldCode = m_entity.Code
      Me.chkAutorun.Checked = Me.m_entity.AutoGen
      Me.UpdateAutogenStatus()

      txtDocDate.Text = MinDateToNull(Me.m_entity.DocDate, Me.StringParserService.Parse("${res:Global.BlankDateText}"))
      dtpDocDate.Value = MinDateToNow(Me.m_entity.DocDate)

      txtStartCalcDate.Text = MinDateToNull(Me.m_entity.StartCalcDate, Me.StringParserService.Parse("${res:Global.BlankDateText}"))
      dtpStartCalcDate.Value = MinDateToNow(Me.m_entity.StartCalcDate)

      txtEndCalcDate.Text = MinDateToNull(Me.m_entity.EndCalcDate, Me.StringParserService.Parse("${res:Global.BlankDateText}"))
      dtpEndCalcDate.Value = MinDateToNow(Me.m_entity.EndCalcDate)

      txtNote.Text = m_entity.Note

      txtToCostCenterCode.Text = m_entity.CostCenter.Code
      txtToCostCenterName.Text = m_entity.CostCenter.Name


      ''Load Items**********************************************************
      'Me.m_treeManager.Treetable = Me.m_entity.ItemTable
      'AddHandler Me.m_entity.PropertyChanged, AddressOf PropChanged
      'Me.Validator.DataTable = m_treeManager.Treetable
      '********************************************************************

      UpdateAmount(True)


      SetStatus()
      SetLabelText()
      CheckFormEnable()
      m_isInitialized = True
    End Sub

    Private m_dateSetting As Boolean = False
    Public Sub ChangeProperty(ByVal sender As Object, ByVal e As EventArgs)
      If Me.m_entity Is Nothing Or Not m_isInitialized Then
        Return
      End If
      Dim dirtyFlag As Boolean = False
      Select Case CType(sender, Control).Name.ToLower
        Case "cmbcode"
          If m_entity.AutoGen Then
            'เพิ่ม AutoCode
            If TypeOf cmbCode.SelectedItem Is AutoCodeFormat Then
              Me.m_entity.AutoCodeFormat = CType(cmbCode.SelectedItem, AutoCodeFormat)
              Me.m_entity.Code = m_entity.AutoCodeFormat.Format
              Me.m_entity.OnGlChanged()
            End If
          Else
            Me.m_entity.Code = cmbCode.Text
          End If
          dirtyFlag = True
        Case "txtnote"
          Me.m_entity.Note = txtNote.Text
          dirtyFlag = True
        Case "dtpdocdate"
          If Not Me.m_entity.DocDate.Equals(dtpDocDate.Value) Then
            If Not m_dateSetting Then
              Me.txtDocDate.Text = MinDateToNull(dtpDocDate.Value, Me.StringParserService.Parse("${res:Global.BlankDateText}"))
              Me.m_entity.DocDate = dtpDocDate.Value
            End If
            dirtyFlag = True
          End If
        Case "txtdocdate"
          m_dateSetting = True
          If Not Me.txtDocDate.Text.Length = 0 AndAlso Me.Validator.GetErrorMessage(Me.txtDocDate) = "" Then
            Dim theDate As Date = CDate(Me.txtDocDate.Text)
            If Not Me.m_entity.DocDate.Equals(theDate) Then
              dtpDocDate.Value = theDate
              Me.m_entity.DocDate = dtpDocDate.Value
              dirtyFlag = True
            End If
          Else
            dtpDocDate.Value = Date.Now
            Me.m_entity.DocDate = Date.MinValue
            dirtyFlag = True
          End If
          m_dateSetting = False
        Case "dtpstartcalcdate"
          If Not Me.m_entity.StartCalcDate.Equals(dtpStartCalcDate.Value) Then
            If Not m_dateSetting Then
              Me.txtStartCalcDate.Text = MinDateToNull(dtpStartCalcDate.Value, Me.StringParserService.Parse("${res:Global.BlankDateText}"))
              Me.m_entity.StartCalcDate = dtpStartCalcDate.Value
            End If
            dirtyFlag = True
          End If
        Case "txtstartcalcdate"
          m_dateSetting = True
          If Not Me.txtStartCalcDate.Text.Length = 0 AndAlso Me.Validator.GetErrorMessage(Me.txtStartCalcDate) = "" Then
            Dim theDate As Date = CDate(Me.txtStartCalcDate.Text)
            If Not Me.m_entity.StartCalcDate.Equals(theDate) Then
              dtpStartCalcDate.Value = theDate
              Me.m_entity.StartCalcDate = dtpStartCalcDate.Value
              dirtyFlag = True
            End If
          Else
            dtpStartCalcDate.Value = Date.Now
            Me.m_entity.StartCalcDate = Date.MinValue
            dirtyFlag = True
          End If
          m_dateSetting = False
        Case "dtpendcalcdate"
          If Not Me.m_entity.EndCalcDate.Equals(dtpEndCalcDate.Value) Then
            If Not m_dateSetting Then
              Me.txtEndCalcDate.Text = MinDateToNull(dtpEndCalcDate.Value, Me.StringParserService.Parse("${res:Global.BlankDateText}"))
              Me.m_entity.EndCalcDate = dtpEndCalcDate.Value
            End If
            dirtyFlag = True
          End If
        Case "txtendcalcdate"
          m_dateSetting = True
          If Not Me.txtEndCalcDate.Text.Length = 0 AndAlso Me.Validator.GetErrorMessage(Me.txtEndCalcDate) = "" Then
            Dim theDate As Date = CDate(Me.txtEndCalcDate.Text)
            If Not Me.m_entity.EndCalcDate.Equals(theDate) Then
              dtpEndCalcDate.Value = theDate
              Me.m_entity.EndCalcDate = dtpEndCalcDate.Value
              dirtyFlag = True
            End If
          Else
            dtpEndCalcDate.Value = Date.Now
            Me.m_entity.EndCalcDate = Date.MinValue
            dirtyFlag = True
          End If
          m_dateSetting = False
        Case "txttocostcentercode"
          dirtyFlag = CostCenter.GetCostCenter(txtToCostCenterCode, txtToCostCenterName, Me.m_entity.CostCenter, CType(ServiceManager.Services.GetService(GetType(SecurityService)), SecurityService).CurrentUser.Id)
          UpdateEntityProperties()
        Case Else
      End Select
      Me.WorkbenchWindow.ViewContent.IsDirty = Me.WorkbenchWindow.ViewContent.IsDirty Or dirtyFlag
      CheckFormEnable()
    End Sub
    Private Sub UpdateAmount(ByVal refresh As Boolean)
      m_isInitialized = False
      If refresh Then
        'Me.m_entity.RefreshGross()
      End If
      m_isInitialized = False
      txtMatBf.Text = Configuration.FormatToString(m_entity.MatBFAmount, DigitConfig.Cost)
      txtMatBuy.Text = Configuration.FormatToString(m_entity.MatBuyAmount, DigitConfig.Cost)
      txtMoveIn.Text = Configuration.FormatToString(m_entity.MatMoveInAmount, DigitConfig.Cost)
      txtMoveOut.Text = "-" & Configuration.FormatToString(m_entity.MatMoveOutAmount, DigitConfig.Cost)
      txtMoveOut.ForeColor = Color.Red
      txtMatBal.Text = "-" & Configuration.FormatToString(m_entity.MatBalAmount, DigitConfig.Cost)
      txtMatBal.ForeColor = Color.Red

      txtMatSum.Text = Configuration.FormatToString(m_entity.MatSumAmount, DigitConfig.Cost)
      txtMatSum2.Text = Configuration.FormatToString(m_entity.MatSumAmount, DigitConfig.Cost)

      txtWIPBF.Text = Configuration.FormatToString(m_entity.WIPBFAmount, DigitConfig.Cost)
      txtWIPOut.Text = "-" & Configuration.FormatToString(m_entity.WIPOutAmount, DigitConfig.Cost)
      txtWIPOut.ForeColor = Color.Red

      txtBuyOther.Text = Configuration.FormatToString(m_entity.BuyOtherAmount, DigitConfig.Cost)
      txtWIPSum.Text = Configuration.FormatToString(m_entity.WIPSumAmount, DigitConfig.Cost)

      m_isInitialized = True
    End Sub
    Public Sub SetStatus()
      MyBase.SetStatusBarMessage()
    End Sub
    Public Overrides Property Entity() As BusinessLogic.ISimpleEntity
      Get
        Return Me.m_entity
      End Get
      Set(ByVal Value As BusinessLogic.ISimpleEntity)
        If Not m_entity Is Nothing Then
          'RemoveHandler Me.m_entity.PropertyChanged, AddressOf PropChanged
        End If
        If Not Object.ReferenceEquals(Me.m_entity, Value) Then
          Me.m_entity = Nothing
          Me.m_entity = CType(Value, CalculateCost)
        End If
        'If Not Me.m_entity Is Nothing Then
        '  If Me.m_entity.IsReferenced Then
        '    m_entityRefed = 1
        '  Else
        '    m_entityRefed = 0
        '  End If
        'Else
        'End If
        'Hack:
        Me.m_entity.OnTabPageTextChanged(m_entity, EventArgs.Empty)
        UpdateEntityProperties()
      End Set
    End Property
    Public Overrides Sub Initialize()
    End Sub
#End Region

#Region "Event Handler"
    Private Sub chkAutorun_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkAutorun.CheckedChanged
      UpdateAutogenStatus()
    End Sub
    Private m_oldCode As String = ""
    Private Sub UpdateAutogenStatus()
      If Me.chkAutorun.Checked Then
        'Me.Validator.SetRequired(Me.txtCode, False)
        'Me.ErrorProvider1.SetError(Me.txtCode, "")
        'Me.txtCode.ReadOnly = True
        Me.cmbCode.DropDownStyle = ComboBoxStyle.DropDownList 'ComboBoxStyle.DropDown
        Dim currentUserId As Integer = Me.SecurityService.CurrentUser.Id
        BusinessLogic.Entity.NewPopulateCodeCombo(Me.cmbCode, Me.m_entity.EntityId, currentUserId)
        If Me.m_entity.Code Is Nothing OrElse Me.m_entity.Code.Length = 0 Then
          If Me.cmbCode.Items.Count > 0 Then
            Me.m_entity.Code = CType(Me.cmbCode.Items(0), AutoCodeFormat).Format
            Me.cmbCode.SelectedIndex = 0
            Me.m_entity.AutoCodeFormat = CType(Me.cmbCode.Items(0), AutoCodeFormat)
          End If
        Else
          Me.cmbCode.SelectedIndex = Me.cmbCode.FindStringExact(Me.m_entity.Code)
          If TypeOf Me.cmbCode.SelectedItem Is AutoCodeFormat Then
            Me.m_entity.AutoCodeFormat = CType(Me.cmbCode.SelectedItem, AutoCodeFormat)
          End If
        End If
        m_oldCode = Me.cmbCode.Text
        'Me.txtCode.Text = BusinessLogic.Entity.GetAutoCodeFormat(Me.m_entity.EntityId)
        'Hack: set Code เป็น "" เอง
        'Me.m_entity.Code = ""
        Me.m_entity.Code = m_oldCode
        Me.m_entity.AutoGen = True
      Else
        ' Me.Validator.SetRequired(Me.txtCode, True)
        Me.cmbCode.DropDownStyle = ComboBoxStyle.Simple
        Me.cmbCode.Text = m_oldCode
        'Me.txtCode.ReadOnly = False
        Me.m_entity.AutoGen = False
      End If
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
        Return (New CalculateCost).DetailPanelIcon
      End Get
    End Property
#End Region

#Region "Event of Button controls"
    Private Sub ibtnShowToCostCenterDialog_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnShowToCostCenterDialog.Click
      Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      myEntityPanelService.OpenTreeDialog(New CostCenter, AddressOf SetToCostCenter)
    End Sub
    Private Sub ibtShowToCostCenter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
      Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      myEntityPanelService.OpenPanel(New CostCenter)
    End Sub
    Private Sub SetToCostCenter(ByVal e As ISimpleEntity)
      Me.txtToCostCenterCode.Text = e.Code
      Me.WorkbenchWindow.ViewContent.IsDirty = Me.WorkbenchWindow.ViewContent.IsDirty _
      Or CostCenter.GetCostCenter(txtToCostCenterCode, txtToCostCenterName, Me.m_entity.CostCenter, CType(ServiceManager.Services.GetService(GetType(SecurityService)), SecurityService).CurrentUser.Id)
      UpdateEntityProperties()
    End Sub
#End Region

#Region "IClipboardHandler Overrides"
    Public Overrides ReadOnly Property EnablePaste() As Boolean
      Get
        Dim data As IDataObject = Clipboard.GetDataObject
        If data.GetDataPresent((New Supplier).FullClassName) Then
          If Not Me.ActiveControl Is Nothing Then
            Select Case Me.ActiveControl.Name.ToLower
              Case "txttocostcentercode", "txttocostcentername"
                Return True
            End Select
          End If
        End If
        Return False
      End Get
    End Property
    Public Overrides Sub Paste(ByVal sender As Object, ByVal e As System.EventArgs)
      Dim data As IDataObject = Clipboard.GetDataObject
      If data.GetDataPresent((New Supplier).FullClassName) Then
        Dim id As Integer = CInt(data.GetData((New Supplier).FullClassName))
        Dim entity As New Supplier(id)
        If Not Me.ActiveControl Is Nothing Then
          Select Case Me.ActiveControl.Name.ToLower
            Case "txttocostcentercode", "txttocostcentername"
              '
          End Select
        End If
      End If
    End Sub
#End Region



#Region "IPrintable"
    Public Overrides ReadOnly Property PrintDocument() As System.Drawing.Printing.PrintDocument
      Get
        Dim myPropertyService As PropertyService = CType(ServiceManager.Services.GetService(GetType(PropertyService)), PropertyService)
        Dim FormPath As String = (myPropertyService.DataDirectory & Path.DirectorySeparatorChar & "forms" & Path.DirectorySeparatorChar & "Adobe" & Path.DirectorySeparatorChar & "documents")
        Dim ReportPath As String = (myPropertyService.DataDirectory & Path.DirectorySeparatorChar & "forms" & Path.DirectorySeparatorChar & "Adobe" & Path.DirectorySeparatorChar & "reports")
        Dim thePath As String = ""

        If Not Me.m_entity Is Nothing Then
          If TypeOf Me.m_entity Is IPrintableEntity Then
            'thePath = Microsoft.VisualBasic.InputBox("เลือกฟอร์ม", "เลือกฟอร์ม", thePath)
            Dim fileName As String = CType(Me.m_entity, IPrintableEntity).GetDefaultForm
            If fileName Is Nothing OrElse fileName.Length = 0 Then
              fileName = Me.m_entity.ClassName
            End If
            thePath = FormPath & Path.DirectorySeparatorChar & fileName & ".xml"

            Dim paths As FormPaths
            Dim nameForPath As String
            nameForPath = Me.m_entity.FullClassName & ".Documents"
            Dim myProperties As PropertyService = CType(ServiceManager.Services.GetService(GetType(PropertyService)), PropertyService)
            paths = CType(myProperties.GetProperty(nameForPath, New FormPaths(nameForPath, Me.m_entity.ClassName, thePath)), FormPaths)
            Dim dlg As New Longkong.Pojjaman.Gui.Dialogs.SelectFormsDialog(paths)
            If dlg.ShowDialog() = DialogResult.OK Then
              thePath = dlg.KeyValuePair.Value
            Else
              Return Nothing
            End If

            If File.Exists(thePath) Then
              'Dim df As New DesignerForm(thePath, CType(Me.m_entity, IPrintableEntity))
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


    Private Sub btnCalculate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCalculate.Click
      If m_entity Is Nothing Then
        Return
      End If

      m_entity.CalculateMatForWIPSum()
      UpdateAmount(False)
    End Sub
  End Class
End Namespace

