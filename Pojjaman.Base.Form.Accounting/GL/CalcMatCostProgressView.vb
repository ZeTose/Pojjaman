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
  Public Class CalcMatCostProgressView
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
    Friend WithEvents lblToCostCenter As System.Windows.Forms.Label
    Friend WithEvents lblCode As System.Windows.Forms.Label
    Friend WithEvents btnCalculate As System.Windows.Forms.Button
    Friend WithEvents lblPercentWIPsum As System.Windows.Forms.Label
    Friend WithEvents txtPercentWip As System.Windows.Forms.TextBox
    Friend WithEvents lblMatBal As System.Windows.Forms.Label
    Friend WithEvents txtRealPercent As System.Windows.Forms.TextBox
    Friend WithEvents txtCannotCost As System.Windows.Forms.TextBox
    Friend WithEvents lblCannotCost As System.Windows.Forms.Label
    Friend WithEvents txtMoveIn As System.Windows.Forms.TextBox
    Friend WithEvents lblMoveIn As System.Windows.Forms.Label
    Friend WithEvents grpWIPSum As Longkong.Pojjaman.Gui.Components.FixedGroupBox
    Friend WithEvents lblCost As System.Windows.Forms.Label
    Friend WithEvents lblWIPSum As System.Windows.Forms.Label
    Friend WithEvents txtWIPSum As System.Windows.Forms.TextBox
    Friend WithEvents lblWIPBal As System.Windows.Forms.Label
    Friend WithEvents txtWIPBal As System.Windows.Forms.TextBox
    Friend WithEvents FlowLayoutPanel1 As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents txtCost As System.Windows.Forms.TextBox
    Friend WithEvents FlowLayoutPanel3 As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents FlowLayoutPanel2 As System.Windows.Forms.FlowLayoutPanel
    Protected Sub InitializeComponent()
      Me.components = New System.ComponentModel.Container()
      Me.txtMatBf = New System.Windows.Forms.TextBox()
      Me.lblMatBf = New System.Windows.Forms.Label()
      Me.lblMatOpenTotalAmount = New System.Windows.Forms.Label()
      Me.txtMatBuy = New System.Windows.Forms.TextBox()
      Me.grbMatSum = New Longkong.Pojjaman.Gui.Components.FixedGroupBox()
      Me.FlowLayoutPanel3 = New System.Windows.Forms.FlowLayoutPanel()
      Me.lblCannotCost = New System.Windows.Forms.Label()
      Me.txtCannotCost = New System.Windows.Forms.TextBox()
      Me.lblWIPSum = New System.Windows.Forms.Label()
      Me.FlowLayoutPanel2 = New System.Windows.Forms.FlowLayoutPanel()
      Me.lblMoveIn = New System.Windows.Forms.Label()
      Me.txtMoveIn = New System.Windows.Forms.TextBox()
      Me.txtWIPSum = New System.Windows.Forms.TextBox()
      Me.lblPercentWIPsum = New System.Windows.Forms.Label()
      Me.txtPercentWip = New System.Windows.Forms.TextBox()
      Me.lblMatBal = New System.Windows.Forms.Label()
      Me.txtRealPercent = New System.Windows.Forms.TextBox()
      Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
      Me.Validator = New Longkong.Pojjaman.Gui.Components.PJMTextboxValidator(Me.components)
      Me.txtWIPBal = New System.Windows.Forms.TextBox()
      Me.txtCost = New System.Windows.Forms.TextBox()
      Me.grbDetail = New Longkong.Pojjaman.Gui.Components.FixedGroupBox()
      Me.lblToCostCenter = New System.Windows.Forms.Label()
      Me.lblCode = New System.Windows.Forms.Label()
      Me.btnCalculate = New System.Windows.Forms.Button()
      Me.grpWIPSum = New Longkong.Pojjaman.Gui.Components.FixedGroupBox()
      Me.FlowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel()
      Me.lblWIPBal = New System.Windows.Forms.Label()
      Me.lblCost = New System.Windows.Forms.Label()
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
      Me.grbMatSum.Controls.Add(Me.lblWIPSum)
      Me.grbMatSum.Controls.Add(Me.FlowLayoutPanel2)
      Me.grbMatSum.Controls.Add(Me.txtWIPSum)
      Me.grbMatSum.Controls.Add(Me.lblPercentWIPsum)
      Me.grbMatSum.Controls.Add(Me.txtPercentWip)
      Me.grbMatSum.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.grbMatSum.Location = New System.Drawing.Point(10, 75)
      Me.grbMatSum.Name = "grbMatSum"
      Me.grbMatSum.Size = New System.Drawing.Size(266, 349)
      Me.grbMatSum.TabIndex = 165
      Me.grbMatSum.TabStop = False
      Me.grbMatSum.Text = "สรุปยอด WIP"
      '
      'FlowLayoutPanel3
      '
      Me.FlowLayoutPanel3.Controls.Add(Me.lblCannotCost)
      Me.FlowLayoutPanel3.Controls.Add(Me.txtCannotCost)
      Me.FlowLayoutPanel3.Location = New System.Drawing.Point(14, 116)
      Me.FlowLayoutPanel3.Name = "FlowLayoutPanel3"
      Me.FlowLayoutPanel3.Size = New System.Drawing.Size(238, 56)
      Me.FlowLayoutPanel3.TabIndex = 323
      '
      'lblCannotCost
      '
      Me.lblCannotCost.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblCannotCost.Location = New System.Drawing.Point(3, 0)
      Me.lblCannotCost.Name = "lblCannotCost"
      Me.lblCannotCost.Size = New System.Drawing.Size(96, 18)
      Me.lblCannotCost.TabIndex = 128
      Me.lblCannotCost.Text = "เป็นต้นทุนไม่ได้"
      Me.lblCannotCost.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'txtCannotCost
      '
      Me.txtCannotCost.BackColor = System.Drawing.SystemColors.Control
      Me.txtCannotCost.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
      Me.Validator.SetDataType(Me.txtCannotCost, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtCannotCost, "")
      Me.Validator.SetGotFocusBackColor(Me.txtCannotCost, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtCannotCost, System.Drawing.Color.Empty)
      Me.txtCannotCost.Location = New System.Drawing.Point(105, 3)
      Me.Validator.SetMinValue(Me.txtCannotCost, "")
      Me.txtCannotCost.Name = "txtCannotCost"
      Me.txtCannotCost.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtCannotCost, "")
      Me.Validator.SetRequired(Me.txtCannotCost, False)
      Me.txtCannotCost.Size = New System.Drawing.Size(128, 21)
      Me.txtCannotCost.TabIndex = 127
      Me.txtCannotCost.TabStop = False
      Me.txtCannotCost.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'lblWIPSum
      '
      Me.lblWIPSum.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblWIPSum.Location = New System.Drawing.Point(29, 238)
      Me.lblWIPSum.Name = "lblWIPSum"
      Me.lblWIPSum.Size = New System.Drawing.Size(84, 20)
      Me.lblWIPSum.TabIndex = 132
      Me.lblWIPSum.Text = "สรุปยอด WIP"
      Me.lblWIPSum.TextAlign = System.Drawing.ContentAlignment.MiddleRight
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
      'txtWIPSum
      '
      Me.txtWIPSum.BackColor = System.Drawing.SystemColors.Control
      Me.txtWIPSum.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
      Me.Validator.SetDataType(Me.txtWIPSum, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtWIPSum, "")
      Me.Validator.SetGotFocusBackColor(Me.txtWIPSum, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtWIPSum, System.Drawing.Color.Empty)
      Me.txtWIPSum.Location = New System.Drawing.Point(119, 240)
      Me.Validator.SetMinValue(Me.txtWIPSum, "")
      Me.txtWIPSum.Name = "txtWIPSum"
      Me.txtWIPSum.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtWIPSum, "")
      Me.Validator.SetRequired(Me.txtWIPSum, False)
      Me.txtWIPSum.Size = New System.Drawing.Size(128, 21)
      Me.txtWIPSum.TabIndex = 131
      Me.txtWIPSum.TabStop = False
      Me.txtWIPSum.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
      '
      'lblPercentWIPsum
      '
      Me.lblPercentWIPsum.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblPercentWIPsum.Location = New System.Drawing.Point(17, 283)
      Me.lblPercentWIPsum.Name = "lblPercentWIPsum"
      Me.lblPercentWIPsum.Size = New System.Drawing.Size(96, 18)
      Me.lblPercentWIPsum.TabIndex = 132
      Me.lblPercentWIPsum.Text = "% Cost"
      Me.lblPercentWIPsum.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'txtPercentWip
      '
      Me.txtPercentWip.BackColor = System.Drawing.SystemColors.Control
      Me.txtPercentWip.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
      Me.Validator.SetDataType(Me.txtPercentWip, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtPercentWip, "")
      Me.Validator.SetGotFocusBackColor(Me.txtPercentWip, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtPercentWip, System.Drawing.Color.Empty)
      Me.txtPercentWip.Location = New System.Drawing.Point(119, 283)
      Me.Validator.SetMinValue(Me.txtPercentWip, "")
      Me.txtPercentWip.Name = "txtPercentWip"
      Me.Validator.SetRegularExpression(Me.txtPercentWip, "")
      Me.Validator.SetRequired(Me.txtPercentWip, False)
      Me.txtPercentWip.Size = New System.Drawing.Size(128, 21)
      Me.txtPercentWip.TabIndex = 131
      Me.txtPercentWip.TabStop = False
      Me.txtPercentWip.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
      '
      'lblMatBal
      '
      Me.lblMatBal.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblMatBal.Location = New System.Drawing.Point(3, 54)
      Me.lblMatBal.Name = "lblMatBal"
      Me.lblMatBal.Size = New System.Drawing.Size(84, 18)
      Me.lblMatBal.TabIndex = 130
      Me.lblMatBal.Text = "% จริง"
      Me.lblMatBal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'txtRealPercent
      '
      Me.txtRealPercent.BackColor = System.Drawing.SystemColors.Control
      Me.txtRealPercent.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
      Me.Validator.SetDataType(Me.txtRealPercent, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtRealPercent, "")
      Me.Validator.SetGotFocusBackColor(Me.txtRealPercent, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtRealPercent, System.Drawing.Color.Empty)
      Me.txtRealPercent.Location = New System.Drawing.Point(93, 57)
      Me.Validator.SetMinValue(Me.txtRealPercent, "")
      Me.txtRealPercent.Name = "txtRealPercent"
      Me.txtRealPercent.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtRealPercent, "")
      Me.Validator.SetRequired(Me.txtRealPercent, False)
      Me.txtRealPercent.Size = New System.Drawing.Size(118, 21)
      Me.txtRealPercent.TabIndex = 129
      Me.txtRealPercent.TabStop = False
      Me.txtRealPercent.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
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
      Me.Validator.GotFocusBackColor = System.Drawing.Color.Empty
      Me.Validator.HasNewRow = False
      Me.Validator.InvalidBackColor = System.Drawing.Color.Empty
      '
      'txtWIPBal
      '
      Me.txtWIPBal.BackColor = System.Drawing.SystemColors.Control
      Me.txtWIPBal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
      Me.Validator.SetDataType(Me.txtWIPBal, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtWIPBal, "")
      Me.Validator.SetGotFocusBackColor(Me.txtWIPBal, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtWIPBal, System.Drawing.Color.Empty)
      Me.txtWIPBal.Location = New System.Drawing.Point(93, 3)
      Me.Validator.SetMinValue(Me.txtWIPBal, "")
      Me.txtWIPBal.Name = "txtWIPBal"
      Me.txtWIPBal.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtWIPBal, "")
      Me.Validator.SetRequired(Me.txtWIPBal, False)
      Me.txtWIPBal.Size = New System.Drawing.Size(119, 21)
      Me.txtWIPBal.TabIndex = 0
      Me.txtWIPBal.TabStop = False
      Me.txtWIPBal.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
      '
      'txtCost
      '
      Me.txtCost.BackColor = System.Drawing.SystemColors.Control
      Me.txtCost.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
      Me.Validator.SetDataType(Me.txtCost, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtCost, "")
      Me.Validator.SetGotFocusBackColor(Me.txtCost, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtCost, System.Drawing.Color.Empty)
      Me.txtCost.Location = New System.Drawing.Point(93, 30)
      Me.Validator.SetMinValue(Me.txtCost, "")
      Me.txtCost.Name = "txtCost"
      Me.txtCost.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtCost, "")
      Me.Validator.SetRequired(Me.txtCost, False)
      Me.txtCost.Size = New System.Drawing.Size(119, 21)
      Me.txtCost.TabIndex = 135
      Me.txtCost.TabStop = False
      Me.txtCost.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
      '
      'grbDetail
      '
      Me.grbDetail.Controls.Add(Me.lblToCostCenter)
      Me.grbDetail.Controls.Add(Me.lblCode)
      Me.grbDetail.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.grbDetail.Location = New System.Drawing.Point(8, 6)
      Me.grbDetail.Name = "grbDetail"
      Me.grbDetail.Size = New System.Drawing.Size(549, 63)
      Me.grbDetail.TabIndex = 320
      Me.grbDetail.TabStop = False
      Me.grbDetail.Text = "คิดแบบ"
      '
      'lblToCostCenter
      '
      Me.lblToCostCenter.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblToCostCenter.Location = New System.Drawing.Point(8, 34)
      Me.lblToCostCenter.Name = "lblToCostCenter"
      Me.lblToCostCenter.Size = New System.Drawing.Size(80, 18)
      Me.lblToCostCenter.TabIndex = 328
      Me.lblToCostCenter.Text = "คลัง:"
      Me.lblToCostCenter.TextAlign = System.Drawing.ContentAlignment.MiddleRight
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
      Me.grpWIPSum.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.grpWIPSum.Location = New System.Drawing.Point(291, 84)
      Me.grpWIPSum.Name = "grpWIPSum"
      Me.grpWIPSum.Size = New System.Drawing.Size(266, 340)
      Me.grpWIPSum.TabIndex = 166
      Me.grpWIPSum.TabStop = False
      Me.grpWIPSum.Text = "สรุปยอดCost & WIP ยกไป"
      '
      'FlowLayoutPanel1
      '
      Me.FlowLayoutPanel1.Controls.Add(Me.lblWIPBal)
      Me.FlowLayoutPanel1.Controls.Add(Me.txtWIPBal)
      Me.FlowLayoutPanel1.Controls.Add(Me.lblCost)
      Me.FlowLayoutPanel1.Controls.Add(Me.txtCost)
      Me.FlowLayoutPanel1.Controls.Add(Me.lblMatBal)
      Me.FlowLayoutPanel1.Controls.Add(Me.txtRealPercent)
      Me.FlowLayoutPanel1.Location = New System.Drawing.Point(17, 20)
      Me.FlowLayoutPanel1.Name = "FlowLayoutPanel1"
      Me.FlowLayoutPanel1.Size = New System.Drawing.Size(232, 114)
      Me.FlowLayoutPanel1.TabIndex = 323
      '
      'lblWIPBal
      '
      Me.lblWIPBal.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblWIPBal.Location = New System.Drawing.Point(3, 0)
      Me.lblWIPBal.Name = "lblWIPBal"
      Me.lblWIPBal.Size = New System.Drawing.Size(84, 24)
      Me.lblWIPBal.TabIndex = 124
      Me.lblWIPBal.Text = "WIP ยกไป"
      Me.lblWIPBal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblCost
      '
      Me.lblCost.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblCost.Location = New System.Drawing.Point(3, 27)
      Me.lblCost.Name = "lblCost"
      Me.lblCost.Size = New System.Drawing.Size(84, 17)
      Me.lblCost.TabIndex = 134
      Me.lblCost.Text = "Cost"
      Me.lblCost.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'CalcMatCostProgressView
      '
      Me.Controls.Add(Me.grpWIPSum)
      Me.Controls.Add(Me.btnCalculate)
      Me.Controls.Add(Me.grbDetail)
      Me.Controls.Add(Me.grbMatSum)
      Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Name = "CalcMatCostProgressView"
      Me.Size = New System.Drawing.Size(688, 433)
      Me.grbMatSum.ResumeLayout(False)
      Me.grbMatSum.PerformLayout()
      Me.FlowLayoutPanel3.ResumeLayout(False)
      Me.FlowLayoutPanel3.PerformLayout()
      Me.FlowLayoutPanel2.ResumeLayout(False)
      Me.FlowLayoutPanel2.PerformLayout()
      CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
      Me.grbDetail.ResumeLayout(False)
      Me.grpWIPSum.ResumeLayout(False)
      Me.FlowLayoutPanel1.ResumeLayout(False)
      Me.FlowLayoutPanel1.PerformLayout()
      Me.ResumeLayout(False)

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
    End Sub
    Public Overrides Sub SetLabelText()
      If Not m_entity Is Nothing Then Me.Text = Me.StringParserService.Parse(Me.m_entity.TabPageText)

      Me.lblCode.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.MatOpenningBalanceDetailView.lblCode}")


      Me.lblToCostCenter.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.MatOpenningBalanceDetailView.lblToCostCenter}")

      Me.lblMatOpenTotalAmount.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.MatOpenningBalanceDetailView.lblMatOpenTotalAmount}")
      Me.lblMatBf.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.MatOpenningBalanceDetailView.lblItemCount}")


      Me.grbMatSum.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.MatOpenningBalanceDetailView.grbSummary}")
      Me.grbDetail.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.MatOpenningBalanceDetailView.grbDetail}")

    End Sub
    Protected Overrides Sub EventWiring()

      AddHandler txtPercentWip.TextChanged, AddressOf Me.ChangeProperty
      AddHandler txtPercentWip.Validated, AddressOf Me.ChangeProperty


      'AddHandler txtStartCalcDate.Validated, AddressOf Me.ChangeProperty
      'AddHandler dtpStartCalcDate.ValueChanged, AddressOf Me.ChangeProperty



    End Sub
    Public Overrides Sub UpdateEntityProperties()
      m_isInitialized = False
      ClearDetail()
      If m_entity Is Nothing Then
        Return
      End If
      'txtCode.Text = m_entity.Code
      m_oldCode = m_entity.Code
      Me.UpdateAutogenStatus()







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


        Case "txtpercentwip"
          If IsNumeric(Me.txtPercentWip.Text) AndAlso CDec(Me.txtPercentWip.Text) <= 100 Then

            Me.m_entity.PercentWIP = CDec(Me.txtPercentWip.Text)

          End If
          dirtyFlag = True
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
      txtCannotCost.Text = "-" & Configuration.FormatToString(m_entity.CannotCostAmount, DigitConfig.Cost)


      If m_entity.RealPercentCost.HasValue Then
        txtRealPercent.Text = Configuration.FormatToString(m_entity.RealPercentCost.Value, DigitConfig.Price)
      End If
      txtCost.Text = Configuration.FormatToString(m_entity.CostAmount, DigitConfig.Cost)
      txtWIPBal.Text = Configuration.FormatToString(m_entity.WIPbalAmount, DigitConfig.Cost)
      txtPercentWip.Text = Configuration.FormatToString(m_entity.PercentWIP, DigitConfig.Price)

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
    Private Sub chkAutorun_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
      UpdateAutogenStatus()
    End Sub
    Private m_oldCode As String = ""
    Private Sub UpdateAutogenStatus()
      
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
        Return (New PO).DetailPanelIcon
      End Get
    End Property
#End Region

#Region "Event of Button controls"
   
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

      m_entity.CalculateCostandWIPBal()
      UpdateAmount(False)
    End Sub
  End Class
End Namespace

