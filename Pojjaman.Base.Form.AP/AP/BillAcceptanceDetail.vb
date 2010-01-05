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

Namespace Longkong.Pojjaman.Gui.Panels
  Public Class BillAcceptanceDetail
    Inherits AbstractEntityDetailPanelView
    Implements IValidatable

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
    Friend WithEvents lblItem As System.Windows.Forms.Label
    Friend WithEvents grbSummary As Longkong.Pojjaman.Gui.Components.FixedGroupBox
    Friend WithEvents txtItemCount As System.Windows.Forms.TextBox
    Friend WithEvents lblItemCount As System.Windows.Forms.Label
    Friend WithEvents lblItemCountUnit As System.Windows.Forms.Label
    Friend WithEvents txtNote As System.Windows.Forms.TextBox
    Friend WithEvents lblNote As System.Windows.Forms.Label
    Friend WithEvents txtCreditPeriod As System.Windows.Forms.TextBox
    Friend WithEvents lblCredit As System.Windows.Forms.Label
    Friend WithEvents lblDueDate As System.Windows.Forms.Label
    Friend WithEvents lblDay As System.Windows.Forms.Label
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents Validator As Longkong.Pojjaman.Gui.Components.PJMTextboxValidator
    Friend WithEvents chkAutorun As System.Windows.Forms.CheckBox
    Friend WithEvents txtDocDate As System.Windows.Forms.TextBox
    Friend WithEvents dtpDocDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblCode As System.Windows.Forms.Label
    Friend WithEvents txtCode As System.Windows.Forms.TextBox
    Friend WithEvents lblDocDate As System.Windows.Forms.Label
    Friend WithEvents grbSupplier As Longkong.Pojjaman.Gui.Components.FixedGroupBox
    Friend WithEvents ibtnBlank As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents ibtnDelRow As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents lblSupplier As System.Windows.Forms.Label
    Friend WithEvents txtSupplierCode As System.Windows.Forms.TextBox
    Friend WithEvents lblRemaining As System.Windows.Forms.Label
    Friend WithEvents txtRemaining As System.Windows.Forms.TextBox
    Friend WithEvents lblRemainingUnit As System.Windows.Forms.Label
    Friend WithEvents lblGrossUnit As System.Windows.Forms.Label
    Friend WithEvents txtGross As System.Windows.Forms.TextBox
    Friend WithEvents lblGross As System.Windows.Forms.Label
    Friend WithEvents ibtnShowSupplier As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents txtSupplierName As System.Windows.Forms.TextBox
    Friend WithEvents ibtnShowSupplierDialog As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents dtpDueDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtBillIssueDocDate As System.Windows.Forms.TextBox
    Friend WithEvents txtBillIssueCode As System.Windows.Forms.TextBox
    Friend WithEvents lblBillIssue As System.Windows.Forms.Label
    Friend WithEvents lblBillIssueDocDate As System.Windows.Forms.Label
    Friend WithEvents dtpBillIssueDocDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents tgItem As Longkong.Pojjaman.Gui.Components.TreeGrid
    Friend WithEvents lblRetention As System.Windows.Forms.Label
    Friend WithEvents txtRetention As System.Windows.Forms.TextBox
    Friend WithEvents lblRetentionUnit As System.Windows.Forms.Label
    Friend WithEvents lblPlusRetentionUnit As System.Windows.Forms.Label
    Friend WithEvents txtPlusRetention As System.Windows.Forms.TextBox
    Friend WithEvents lblPlusRetention As System.Windows.Forms.Label
    Friend WithEvents txtDueDate As System.Windows.Forms.TextBox
    <System.Diagnostics.DebuggerStepThrough()> Protected Sub InitializeComponent()
      Me.components = New System.ComponentModel.Container
      Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(BillAcceptanceDetail))
      Me.txtCreditPeriod = New System.Windows.Forms.TextBox
      Me.lblCredit = New System.Windows.Forms.Label
      Me.lblSupplier = New System.Windows.Forms.Label
      Me.txtSupplierCode = New System.Windows.Forms.TextBox
      Me.lblDay = New System.Windows.Forms.Label
      Me.lblItem = New System.Windows.Forms.Label
      Me.lblDueDate = New System.Windows.Forms.Label
      Me.grbSummary = New Longkong.Pojjaman.Gui.Components.FixedGroupBox
      Me.lblRetention = New System.Windows.Forms.Label
      Me.txtRetention = New System.Windows.Forms.TextBox
      Me.lblRetentionUnit = New System.Windows.Forms.Label
      Me.lblPlusRetentionUnit = New System.Windows.Forms.Label
      Me.txtPlusRetention = New System.Windows.Forms.TextBox
      Me.lblPlusRetention = New System.Windows.Forms.Label
      Me.lblRemaining = New System.Windows.Forms.Label
      Me.txtRemaining = New System.Windows.Forms.TextBox
      Me.lblRemainingUnit = New System.Windows.Forms.Label
      Me.txtItemCount = New System.Windows.Forms.TextBox
      Me.lblItemCount = New System.Windows.Forms.Label
      Me.lblItemCountUnit = New System.Windows.Forms.Label
      Me.lblGrossUnit = New System.Windows.Forms.Label
      Me.txtGross = New System.Windows.Forms.TextBox
      Me.lblGross = New System.Windows.Forms.Label
      Me.txtNote = New System.Windows.Forms.TextBox
      Me.lblNote = New System.Windows.Forms.Label
      Me.ibtnShowSupplier = New Longkong.Pojjaman.Gui.Components.ImageButton
      Me.txtSupplierName = New System.Windows.Forms.TextBox
      Me.ibtnShowSupplierDialog = New Longkong.Pojjaman.Gui.Components.ImageButton
      Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider
      Me.txtDocDate = New System.Windows.Forms.TextBox
      Me.txtBillIssueDocDate = New System.Windows.Forms.TextBox
      Me.Validator = New Longkong.Pojjaman.Gui.Components.PJMTextboxValidator(Me.components)
      Me.txtCode = New System.Windows.Forms.TextBox
      Me.txtBillIssueCode = New System.Windows.Forms.TextBox
      Me.chkAutorun = New System.Windows.Forms.CheckBox
      Me.dtpDocDate = New System.Windows.Forms.DateTimePicker
      Me.lblCode = New System.Windows.Forms.Label
      Me.lblDocDate = New System.Windows.Forms.Label
      Me.lblBillIssue = New System.Windows.Forms.Label
      Me.lblBillIssueDocDate = New System.Windows.Forms.Label
      Me.dtpBillIssueDocDate = New System.Windows.Forms.DateTimePicker
      Me.dtpDueDate = New System.Windows.Forms.DateTimePicker
      Me.grbSupplier = New Longkong.Pojjaman.Gui.Components.FixedGroupBox
      Me.ibtnBlank = New Longkong.Pojjaman.Gui.Components.ImageButton
      Me.ibtnDelRow = New Longkong.Pojjaman.Gui.Components.ImageButton
      Me.tgItem = New Longkong.Pojjaman.Gui.Components.TreeGrid
      Me.txtDueDate = New System.Windows.Forms.TextBox
      Me.grbSummary.SuspendLayout()
      Me.grbSupplier.SuspendLayout()
      CType(Me.tgItem, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.SuspendLayout()
      '
      'txtCreditPeriod
      '
      Me.txtCreditPeriod.BackColor = System.Drawing.SystemColors.Window
      Me.Validator.SetDataType(Me.txtCreditPeriod, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtCreditPeriod, "")
      Me.Validator.SetGotFocusBackColor(Me.txtCreditPeriod, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtCreditPeriod, System.Drawing.Color.Empty)
      Me.txtCreditPeriod.Location = New System.Drawing.Point(88, 40)
      Me.Validator.SetMaxValue(Me.txtCreditPeriod, "")
      Me.Validator.SetMinValue(Me.txtCreditPeriod, "")
      Me.txtCreditPeriod.Name = "txtCreditPeriod"
      Me.Validator.SetRegularExpression(Me.txtCreditPeriod, "")
      Me.Validator.SetRequired(Me.txtCreditPeriod, True)
      Me.txtCreditPeriod.Size = New System.Drawing.Size(64, 20)
      Me.txtCreditPeriod.TabIndex = 5
      Me.txtCreditPeriod.Text = ""
      '
      'lblCredit
      '
      Me.lblCredit.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblCredit.Location = New System.Drawing.Point(16, 40)
      Me.lblCredit.Name = "lblCredit"
      Me.lblCredit.Size = New System.Drawing.Size(72, 18)
      Me.lblCredit.TabIndex = 3
      Me.lblCredit.Text = "ระยะเครดิต:"
      Me.lblCredit.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblSupplier
      '
      Me.lblSupplier.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblSupplier.Location = New System.Drawing.Point(16, 16)
      Me.lblSupplier.Name = "lblSupplier"
      Me.lblSupplier.Size = New System.Drawing.Size(72, 18)
      Me.lblSupplier.TabIndex = 2
      Me.lblSupplier.Text = "ผู้ขาย:"
      Me.lblSupplier.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'txtSupplierCode
      '
      Me.txtSupplierCode.BackColor = System.Drawing.SystemColors.Window
      Me.Validator.SetDataType(Me.txtSupplierCode, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtSupplierCode, "")
      Me.Validator.SetGotFocusBackColor(Me.txtSupplierCode, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtSupplierCode, System.Drawing.Color.Empty)
      Me.txtSupplierCode.Location = New System.Drawing.Point(88, 16)
      Me.Validator.SetMaxValue(Me.txtSupplierCode, "")
      Me.Validator.SetMinValue(Me.txtSupplierCode, "")
      Me.txtSupplierCode.Name = "txtSupplierCode"
      Me.Validator.SetRegularExpression(Me.txtSupplierCode, "")
      Me.Validator.SetRequired(Me.txtSupplierCode, True)
      Me.txtSupplierCode.Size = New System.Drawing.Size(64, 20)
      Me.txtSupplierCode.TabIndex = 4
      Me.txtSupplierCode.Text = ""
      '
      'lblDay
      '
      Me.lblDay.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblDay.Location = New System.Drawing.Point(152, 42)
      Me.lblDay.Name = "lblDay"
      Me.lblDay.Size = New System.Drawing.Size(32, 18)
      Me.lblDay.TabIndex = 7
      Me.lblDay.Text = "วัน"
      Me.lblDay.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      '
      'lblItem
      '
      Me.lblItem.BackColor = System.Drawing.Color.Transparent
      Me.lblItem.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblItem.Location = New System.Drawing.Point(8, 88)
      Me.lblItem.Name = "lblItem"
      Me.lblItem.Size = New System.Drawing.Size(112, 18)
      Me.lblItem.TabIndex = 14
      Me.lblItem.Text = "รายการรับวางบิล:"
      Me.lblItem.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      '
      'lblDueDate
      '
      Me.lblDueDate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblDueDate.Location = New System.Drawing.Point(176, 41)
      Me.lblDueDate.Name = "lblDueDate"
      Me.lblDueDate.Size = New System.Drawing.Size(88, 18)
      Me.lblDueDate.TabIndex = 8
      Me.lblDueDate.Text = "กำหนดชำระ:"
      Me.lblDueDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'grbSummary
      '
      Me.grbSummary.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.grbSummary.Controls.Add(Me.lblRetention)
      Me.grbSummary.Controls.Add(Me.txtRetention)
      Me.grbSummary.Controls.Add(Me.lblRetentionUnit)
      Me.grbSummary.Controls.Add(Me.lblPlusRetentionUnit)
      Me.grbSummary.Controls.Add(Me.txtPlusRetention)
      Me.grbSummary.Controls.Add(Me.lblPlusRetention)
      Me.grbSummary.Controls.Add(Me.lblRemaining)
      Me.grbSummary.Controls.Add(Me.txtRemaining)
      Me.grbSummary.Controls.Add(Me.lblRemainingUnit)
      Me.grbSummary.Controls.Add(Me.txtItemCount)
      Me.grbSummary.Controls.Add(Me.lblItemCount)
      Me.grbSummary.Controls.Add(Me.lblItemCountUnit)
      Me.grbSummary.Controls.Add(Me.lblGrossUnit)
      Me.grbSummary.Controls.Add(Me.txtGross)
      Me.grbSummary.Controls.Add(Me.lblGross)
      Me.grbSummary.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.grbSummary.Location = New System.Drawing.Point(112, 312)
      Me.grbSummary.Name = "grbSummary"
      Me.grbSummary.Size = New System.Drawing.Size(672, 72)
      Me.grbSummary.TabIndex = 18
      Me.grbSummary.TabStop = False
      Me.grbSummary.Text = "สรุปรายการรับวางบิล"
      '
      'lblRetention
      '
      Me.lblRetention.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblRetention.Location = New System.Drawing.Point(408, 40)
      Me.lblRetention.Name = "lblRetention"
      Me.lblRetention.Size = New System.Drawing.Size(104, 18)
      Me.lblRetention.TabIndex = 13
      Me.lblRetention.Text = "Retention:"
      Me.lblRetention.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'txtRetention
      '
      Me.txtRetention.BackColor = System.Drawing.SystemColors.Control
      Me.txtRetention.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
      Me.Validator.SetDataType(Me.txtRetention, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtRetention, "")
      Me.Validator.SetGotFocusBackColor(Me.txtRetention, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtRetention, System.Drawing.Color.Empty)
      Me.txtRetention.Location = New System.Drawing.Point(528, 40)
      Me.Validator.SetMaxValue(Me.txtRetention, "")
      Me.Validator.SetMinValue(Me.txtRetention, "")
      Me.txtRetention.Name = "txtRetention"
      Me.txtRetention.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtRetention, "")
      Me.Validator.SetRequired(Me.txtRetention, False)
      Me.txtRetention.Size = New System.Drawing.Size(96, 20)
      Me.txtRetention.TabIndex = 14
      Me.txtRetention.Text = ""
      Me.txtRetention.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'lblRetentionUnit
      '
      Me.lblRetentionUnit.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblRetentionUnit.Location = New System.Drawing.Point(632, 40)
      Me.lblRetentionUnit.Name = "lblRetentionUnit"
      Me.lblRetentionUnit.Size = New System.Drawing.Size(32, 18)
      Me.lblRetentionUnit.TabIndex = 9
      Me.lblRetentionUnit.Text = "บาท"
      Me.lblRetentionUnit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      '
      'lblPlusRetentionUnit
      '
      Me.lblPlusRetentionUnit.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblPlusRetentionUnit.Location = New System.Drawing.Point(384, 40)
      Me.lblPlusRetentionUnit.Name = "lblPlusRetentionUnit"
      Me.lblPlusRetentionUnit.Size = New System.Drawing.Size(32, 18)
      Me.lblPlusRetentionUnit.TabIndex = 12
      Me.lblPlusRetentionUnit.Text = "บาท"
      Me.lblPlusRetentionUnit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      '
      'txtPlusRetention
      '
      Me.txtPlusRetention.BackColor = System.Drawing.SystemColors.Control
      Me.txtPlusRetention.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
      Me.Validator.SetDataType(Me.txtPlusRetention, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtPlusRetention, "")
      Me.Validator.SetGotFocusBackColor(Me.txtPlusRetention, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtPlusRetention, System.Drawing.Color.Empty)
      Me.txtPlusRetention.Location = New System.Drawing.Point(272, 40)
      Me.Validator.SetMaxValue(Me.txtPlusRetention, "")
      Me.Validator.SetMinValue(Me.txtPlusRetention, "")
      Me.txtPlusRetention.Name = "txtPlusRetention"
      Me.txtPlusRetention.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtPlusRetention, "")
      Me.Validator.SetRequired(Me.txtPlusRetention, False)
      Me.txtPlusRetention.Size = New System.Drawing.Size(112, 20)
      Me.txtPlusRetention.TabIndex = 11
      Me.txtPlusRetention.Text = ""
      Me.txtPlusRetention.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'lblPlusRetention
      '
      Me.lblPlusRetention.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblPlusRetention.Location = New System.Drawing.Point(144, 40)
      Me.lblPlusRetention.Name = "lblPlusRetention"
      Me.lblPlusRetention.Size = New System.Drawing.Size(128, 18)
      Me.lblPlusRetention.TabIndex = 10
      Me.lblPlusRetention.Text = "Total with Retention"
      Me.lblPlusRetention.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblRemaining
      '
      Me.lblRemaining.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblRemaining.Location = New System.Drawing.Point(408, 16)
      Me.lblRemaining.Name = "lblRemaining"
      Me.lblRemaining.Size = New System.Drawing.Size(104, 18)
      Me.lblRemaining.TabIndex = 7
      Me.lblRemaining.Text = "Payment Remain:"
      Me.lblRemaining.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'txtRemaining
      '
      Me.txtRemaining.BackColor = System.Drawing.SystemColors.Control
      Me.txtRemaining.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
      Me.Validator.SetDataType(Me.txtRemaining, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtRemaining, "")
      Me.Validator.SetGotFocusBackColor(Me.txtRemaining, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtRemaining, System.Drawing.Color.Empty)
      Me.txtRemaining.Location = New System.Drawing.Point(528, 16)
      Me.Validator.SetMaxValue(Me.txtRemaining, "")
      Me.Validator.SetMinValue(Me.txtRemaining, "")
      Me.txtRemaining.Name = "txtRemaining"
      Me.txtRemaining.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtRemaining, "")
      Me.Validator.SetRequired(Me.txtRemaining, False)
      Me.txtRemaining.Size = New System.Drawing.Size(96, 20)
      Me.txtRemaining.TabIndex = 8
      Me.txtRemaining.Text = ""
      Me.txtRemaining.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'lblRemainingUnit
      '
      Me.lblRemainingUnit.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblRemainingUnit.Location = New System.Drawing.Point(632, 16)
      Me.lblRemainingUnit.Name = "lblRemainingUnit"
      Me.lblRemainingUnit.Size = New System.Drawing.Size(32, 18)
      Me.lblRemainingUnit.TabIndex = 0
      Me.lblRemainingUnit.Text = "บาท"
      Me.lblRemainingUnit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      '
      'txtItemCount
      '
      Me.txtItemCount.BackColor = System.Drawing.SystemColors.Control
      Me.txtItemCount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
      Me.Validator.SetDataType(Me.txtItemCount, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtItemCount, "")
      Me.Validator.SetGotFocusBackColor(Me.txtItemCount, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtItemCount, System.Drawing.Color.Empty)
      Me.txtItemCount.Location = New System.Drawing.Point(104, 16)
      Me.Validator.SetMaxValue(Me.txtItemCount, "")
      Me.Validator.SetMinValue(Me.txtItemCount, "")
      Me.txtItemCount.Name = "txtItemCount"
      Me.txtItemCount.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtItemCount, "")
      Me.Validator.SetRequired(Me.txtItemCount, False)
      Me.txtItemCount.Size = New System.Drawing.Size(32, 20)
      Me.txtItemCount.TabIndex = 1
      Me.txtItemCount.Text = ""
      Me.txtItemCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'lblItemCount
      '
      Me.lblItemCount.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblItemCount.Location = New System.Drawing.Point(16, 16)
      Me.lblItemCount.Name = "lblItemCount"
      Me.lblItemCount.Size = New System.Drawing.Size(80, 18)
      Me.lblItemCount.TabIndex = 0
      Me.lblItemCount.Text = "จำนวนรายการ"
      Me.lblItemCount.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblItemCountUnit
      '
      Me.lblItemCountUnit.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblItemCountUnit.Location = New System.Drawing.Point(136, 16)
      Me.lblItemCountUnit.Name = "lblItemCountUnit"
      Me.lblItemCountUnit.Size = New System.Drawing.Size(40, 18)
      Me.lblItemCountUnit.TabIndex = 2
      Me.lblItemCountUnit.Text = "Item"
      Me.lblItemCountUnit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      '
      'lblGrossUnit
      '
      Me.lblGrossUnit.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblGrossUnit.Location = New System.Drawing.Point(384, 16)
      Me.lblGrossUnit.Name = "lblGrossUnit"
      Me.lblGrossUnit.Size = New System.Drawing.Size(32, 18)
      Me.lblGrossUnit.TabIndex = 6
      Me.lblGrossUnit.Text = "บาท"
      Me.lblGrossUnit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      '
      'txtGross
      '
      Me.txtGross.BackColor = System.Drawing.SystemColors.Control
      Me.txtGross.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
      Me.Validator.SetDataType(Me.txtGross, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtGross, "")
      Me.Validator.SetGotFocusBackColor(Me.txtGross, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtGross, System.Drawing.Color.Empty)
      Me.txtGross.Location = New System.Drawing.Point(272, 16)
      Me.Validator.SetMaxValue(Me.txtGross, "")
      Me.Validator.SetMinValue(Me.txtGross, "")
      Me.txtGross.Name = "txtGross"
      Me.txtGross.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtGross, "")
      Me.Validator.SetRequired(Me.txtGross, False)
      Me.txtGross.Size = New System.Drawing.Size(112, 20)
      Me.txtGross.TabIndex = 5
      Me.txtGross.Text = ""
      Me.txtGross.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'lblGross
      '
      Me.lblGross.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblGross.Location = New System.Drawing.Point(176, 16)
      Me.lblGross.Name = "lblGross"
      Me.lblGross.Size = New System.Drawing.Size(96, 18)
      Me.lblGross.TabIndex = 4
      Me.lblGross.Text = "Total Amount"
      Me.lblGross.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'txtNote
      '
      Me.txtNote.BackColor = System.Drawing.SystemColors.Window
      Me.Validator.SetDataType(Me.txtNote, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtNote, "")
      Me.Validator.SetGotFocusBackColor(Me.txtNote, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtNote, System.Drawing.Color.Empty)
      Me.txtNote.Location = New System.Drawing.Point(336, 80)
      Me.Validator.SetMaxValue(Me.txtNote, "")
      Me.Validator.SetMinValue(Me.txtNote, "")
      Me.txtNote.Name = "txtNote"
      Me.Validator.SetRegularExpression(Me.txtNote, "")
      Me.Validator.SetRequired(Me.txtNote, False)
      Me.txtNote.Size = New System.Drawing.Size(416, 20)
      Me.txtNote.TabIndex = 7
      Me.txtNote.Text = ""
      '
      'lblNote
      '
      Me.lblNote.BackColor = System.Drawing.Color.Transparent
      Me.lblNote.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblNote.Location = New System.Drawing.Point(240, 80)
      Me.lblNote.Name = "lblNote"
      Me.lblNote.Size = New System.Drawing.Size(96, 18)
      Me.lblNote.TabIndex = 17
      Me.lblNote.Text = "หมายเหตุ:"
      Me.lblNote.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'ibtnShowSupplier
      '
      Me.ibtnShowSupplier.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.ibtnShowSupplier.Image = CType(resources.GetObject("ibtnShowSupplier.Image"), System.Drawing.Image)
      Me.ibtnShowSupplier.Location = New System.Drawing.Point(344, 16)
      Me.ibtnShowSupplier.Name = "ibtnShowSupplier"
      Me.ibtnShowSupplier.Size = New System.Drawing.Size(24, 23)
      Me.ibtnShowSupplier.TabIndex = 12
      Me.ibtnShowSupplier.TabStop = False
      Me.ibtnShowSupplier.ThemedImage = CType(resources.GetObject("ibtnShowSupplier.ThemedImage"), System.Drawing.Bitmap)
      '
      'txtSupplierName
      '
      Me.txtSupplierName.BackColor = System.Drawing.SystemColors.Control
      Me.Validator.SetDataType(Me.txtSupplierName, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtSupplierName, "")
      Me.Validator.SetGotFocusBackColor(Me.txtSupplierName, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtSupplierName, System.Drawing.Color.Empty)
      Me.txtSupplierName.Location = New System.Drawing.Point(152, 16)
      Me.Validator.SetMaxValue(Me.txtSupplierName, "")
      Me.Validator.SetMinValue(Me.txtSupplierName, "")
      Me.txtSupplierName.Name = "txtSupplierName"
      Me.txtSupplierName.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtSupplierName, "")
      Me.Validator.SetRequired(Me.txtSupplierName, False)
      Me.txtSupplierName.Size = New System.Drawing.Size(168, 20)
      Me.txtSupplierName.TabIndex = 4
      Me.txtSupplierName.TabStop = False
      Me.txtSupplierName.Text = ""
      '
      'ibtnShowSupplierDialog
      '
      Me.ibtnShowSupplierDialog.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.ibtnShowSupplierDialog.ForeColor = System.Drawing.SystemColors.Control
      Me.ibtnShowSupplierDialog.Image = CType(resources.GetObject("ibtnShowSupplierDialog.Image"), System.Drawing.Image)
      Me.ibtnShowSupplierDialog.Location = New System.Drawing.Point(320, 16)
      Me.ibtnShowSupplierDialog.Name = "ibtnShowSupplierDialog"
      Me.ibtnShowSupplierDialog.Size = New System.Drawing.Size(24, 23)
      Me.ibtnShowSupplierDialog.TabIndex = 11
      Me.ibtnShowSupplierDialog.TabStop = False
      Me.ibtnShowSupplierDialog.ThemedImage = CType(resources.GetObject("ibtnShowSupplierDialog.ThemedImage"), System.Drawing.Bitmap)
      '
      'ErrorProvider1
      '
      Me.ErrorProvider1.ContainerControl = Me
      '
      'txtDocDate
      '
      Me.Validator.SetDataType(Me.txtDocDate, Longkong.Pojjaman.Gui.Components.DataTypeConstants.DateTimeType)
      Me.Validator.SetDisplayName(Me.txtDocDate, "")
      Me.Validator.SetGotFocusBackColor(Me.txtDocDate, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtDocDate, 15)
      Me.Validator.SetInvalidBackColor(Me.txtDocDate, System.Drawing.Color.Empty)
      Me.txtDocDate.Location = New System.Drawing.Point(240, 15)
      Me.Validator.SetMaxValue(Me.txtDocDate, "")
      Me.Validator.SetMinValue(Me.txtDocDate, "")
      Me.txtDocDate.Name = "txtDocDate"
      Me.Validator.SetRegularExpression(Me.txtDocDate, "")
      Me.Validator.SetRequired(Me.txtDocDate, True)
      Me.txtDocDate.Size = New System.Drawing.Size(78, 20)
      Me.txtDocDate.TabIndex = 1
      Me.txtDocDate.Text = ""
      '
      'txtBillIssueDocDate
      '
      Me.Validator.SetDataType(Me.txtBillIssueDocDate, Longkong.Pojjaman.Gui.Components.DataTypeConstants.DateTimeType)
      Me.Validator.SetDisplayName(Me.txtBillIssueDocDate, "")
      Me.Validator.SetGotFocusBackColor(Me.txtBillIssueDocDate, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtBillIssueDocDate, 15)
      Me.Validator.SetInvalidBackColor(Me.txtBillIssueDocDate, System.Drawing.Color.Empty)
      Me.txtBillIssueDocDate.Location = New System.Drawing.Point(240, 39)
      Me.Validator.SetMaxValue(Me.txtBillIssueDocDate, "")
      Me.Validator.SetMinValue(Me.txtBillIssueDocDate, "")
      Me.txtBillIssueDocDate.Name = "txtBillIssueDocDate"
      Me.Validator.SetRegularExpression(Me.txtBillIssueDocDate, "")
      Me.Validator.SetRequired(Me.txtBillIssueDocDate, False)
      Me.txtBillIssueDocDate.Size = New System.Drawing.Size(78, 20)
      Me.txtBillIssueDocDate.TabIndex = 3
      Me.txtBillIssueDocDate.Text = ""
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
      'txtCode
      '
      Me.Validator.SetDataType(Me.txtCode, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtCode, "")
      Me.txtCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtCode, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtCode, System.Drawing.Color.Empty)
      Me.txtCode.Location = New System.Drawing.Point(96, 15)
      Me.Validator.SetMaxValue(Me.txtCode, "")
      Me.Validator.SetMinValue(Me.txtCode, "")
      Me.txtCode.Name = "txtCode"
      Me.Validator.SetRegularExpression(Me.txtCode, "")
      Me.Validator.SetRequired(Me.txtCode, True)
      Me.txtCode.Size = New System.Drawing.Size(88, 21)
      Me.txtCode.TabIndex = 0
      Me.txtCode.TabStop = False
      Me.txtCode.Text = ""
      '
      'txtBillIssueCode
      '
      Me.Validator.SetDataType(Me.txtBillIssueCode, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtBillIssueCode, "")
      Me.txtBillIssueCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtBillIssueCode, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtBillIssueCode, System.Drawing.Color.Empty)
      Me.txtBillIssueCode.Location = New System.Drawing.Point(96, 39)
      Me.Validator.SetMaxValue(Me.txtBillIssueCode, "")
      Me.Validator.SetMinValue(Me.txtBillIssueCode, "")
      Me.txtBillIssueCode.Name = "txtBillIssueCode"
      Me.Validator.SetRegularExpression(Me.txtBillIssueCode, "")
      Me.Validator.SetRequired(Me.txtBillIssueCode, False)
      Me.txtBillIssueCode.Size = New System.Drawing.Size(112, 21)
      Me.txtBillIssueCode.TabIndex = 2
      Me.txtBillIssueCode.TabStop = False
      Me.txtBillIssueCode.Text = ""
      '
      'chkAutorun
      '
      Me.chkAutorun.Appearance = System.Windows.Forms.Appearance.Button
      Me.chkAutorun.Image = CType(resources.GetObject("chkAutorun.Image"), System.Drawing.Image)
      Me.chkAutorun.Location = New System.Drawing.Point(184, 15)
      Me.chkAutorun.Name = "chkAutorun"
      Me.chkAutorun.Size = New System.Drawing.Size(21, 21)
      Me.chkAutorun.TabIndex = 8
      '
      'dtpDocDate
      '
      Me.dtpDocDate.CustomFormat = "dd/MM/yyyy"
      Me.dtpDocDate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.dtpDocDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
      Me.dtpDocDate.Location = New System.Drawing.Point(240, 15)
      Me.dtpDocDate.Name = "dtpDocDate"
      Me.dtpDocDate.Size = New System.Drawing.Size(96, 21)
      Me.dtpDocDate.TabIndex = 9
      Me.dtpDocDate.TabStop = False
      '
      'lblCode
      '
      Me.lblCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblCode.ForeColor = System.Drawing.Color.Black
      Me.lblCode.Location = New System.Drawing.Point(16, 16)
      Me.lblCode.Name = "lblCode"
      Me.lblCode.Size = New System.Drawing.Size(80, 18)
      Me.lblCode.TabIndex = 7
      Me.lblCode.Text = "Document No."
      Me.lblCode.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblDocDate
      '
      Me.lblDocDate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblDocDate.ForeColor = System.Drawing.Color.Black
      Me.lblDocDate.Location = New System.Drawing.Point(200, 16)
      Me.lblDocDate.Name = "lblDocDate"
      Me.lblDocDate.Size = New System.Drawing.Size(40, 18)
      Me.lblDocDate.TabIndex = 10
      Me.lblDocDate.Text = "วันที่:"
      Me.lblDocDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblBillIssue
      '
      Me.lblBillIssue.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblBillIssue.ForeColor = System.Drawing.Color.Black
      Me.lblBillIssue.Location = New System.Drawing.Point(8, 40)
      Me.lblBillIssue.Name = "lblBillIssue"
      Me.lblBillIssue.Size = New System.Drawing.Size(88, 18)
      Me.lblBillIssue.TabIndex = 8
      Me.lblBillIssue.Text = "Billing Note No."
      Me.lblBillIssue.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblBillIssueDocDate
      '
      Me.lblBillIssueDocDate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblBillIssueDocDate.ForeColor = System.Drawing.Color.Black
      Me.lblBillIssueDocDate.Location = New System.Drawing.Point(200, 40)
      Me.lblBillIssueDocDate.Name = "lblBillIssueDocDate"
      Me.lblBillIssueDocDate.Size = New System.Drawing.Size(40, 18)
      Me.lblBillIssueDocDate.TabIndex = 11
      Me.lblBillIssueDocDate.Text = "วันที่:"
      Me.lblBillIssueDocDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'dtpBillIssueDocDate
      '
      Me.dtpBillIssueDocDate.CustomFormat = "dd/MM/yyyy"
      Me.dtpBillIssueDocDate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.dtpBillIssueDocDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
      Me.dtpBillIssueDocDate.Location = New System.Drawing.Point(240, 39)
      Me.dtpBillIssueDocDate.Name = "dtpBillIssueDocDate"
      Me.dtpBillIssueDocDate.Size = New System.Drawing.Size(96, 21)
      Me.dtpBillIssueDocDate.TabIndex = 10
      Me.dtpBillIssueDocDate.TabStop = False
      '
      'dtpDueDate
      '
      Me.dtpDueDate.CustomFormat = "dd/MM/yyyy"
      Me.dtpDueDate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.dtpDueDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
      Me.dtpDueDate.Location = New System.Drawing.Point(272, 40)
      Me.dtpDueDate.Name = "dtpDueDate"
      Me.dtpDueDate.Size = New System.Drawing.Size(96, 21)
      Me.dtpDueDate.TabIndex = 13
      Me.dtpDueDate.TabStop = False
      '
      'grbSupplier
      '
      Me.grbSupplier.Controls.Add(Me.txtDueDate)
      Me.grbSupplier.Controls.Add(Me.lblCredit)
      Me.grbSupplier.Controls.Add(Me.lblDueDate)
      Me.grbSupplier.Controls.Add(Me.dtpDueDate)
      Me.grbSupplier.Controls.Add(Me.txtCreditPeriod)
      Me.grbSupplier.Controls.Add(Me.ibtnShowSupplier)
      Me.grbSupplier.Controls.Add(Me.txtSupplierName)
      Me.grbSupplier.Controls.Add(Me.txtSupplierCode)
      Me.grbSupplier.Controls.Add(Me.ibtnShowSupplierDialog)
      Me.grbSupplier.Controls.Add(Me.lblSupplier)
      Me.grbSupplier.Controls.Add(Me.lblDay)
      Me.grbSupplier.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.grbSupplier.Location = New System.Drawing.Point(376, 0)
      Me.grbSupplier.Name = "grbSupplier"
      Me.grbSupplier.Size = New System.Drawing.Size(384, 72)
      Me.grbSupplier.TabIndex = 4
      Me.grbSupplier.TabStop = False
      Me.grbSupplier.Text = "ผู้ขาย"
      '
      'ibtnBlank
      '
      Me.ibtnBlank.Image = CType(resources.GetObject("ibtnBlank.Image"), System.Drawing.Image)
      Me.ibtnBlank.Location = New System.Drawing.Point(120, 80)
      Me.ibtnBlank.Name = "ibtnBlank"
      Me.ibtnBlank.Size = New System.Drawing.Size(24, 24)
      Me.ibtnBlank.TabIndex = 14
      Me.ibtnBlank.TabStop = False
      Me.ibtnBlank.ThemedImage = CType(resources.GetObject("ibtnBlank.ThemedImage"), System.Drawing.Bitmap)
      '
      'ibtnDelRow
      '
      Me.ibtnDelRow.Image = CType(resources.GetObject("ibtnDelRow.Image"), System.Drawing.Image)
      Me.ibtnDelRow.Location = New System.Drawing.Point(144, 80)
      Me.ibtnDelRow.Name = "ibtnDelRow"
      Me.ibtnDelRow.Size = New System.Drawing.Size(24, 24)
      Me.ibtnDelRow.TabIndex = 15
      Me.ibtnDelRow.TabStop = False
      Me.ibtnDelRow.ThemedImage = CType(resources.GetObject("ibtnDelRow.ThemedImage"), System.Drawing.Bitmap)
      '
      'tgItem
      '
      Me.tgItem.AllowNew = False
      Me.tgItem.AllowSorting = False
      Me.tgItem.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                  Or System.Windows.Forms.AnchorStyles.Left) _
                  Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.tgItem.AutoColumnResize = True
      Me.tgItem.CaptionVisible = False
      Me.tgItem.Cellchanged = False
      Me.tgItem.DataMember = ""
      Me.tgItem.HeaderForeColor = System.Drawing.SystemColors.ControlText
      Me.tgItem.Location = New System.Drawing.Point(8, 104)
      Me.tgItem.Name = "tgItem"
      Me.tgItem.Size = New System.Drawing.Size(784, 200)
      Me.tgItem.SortingArrowColor = System.Drawing.Color.Red
      Me.tgItem.TabIndex = 16
      Me.tgItem.TreeManager = Nothing
      '
      'txtDueDate
      '
      Me.Validator.SetDataType(Me.txtDueDate, Longkong.Pojjaman.Gui.Components.DataTypeConstants.DateTimeType)
      Me.Validator.SetDisplayName(Me.txtDueDate, "")
      Me.Validator.SetGotFocusBackColor(Me.txtDueDate, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtDueDate, 15)
      Me.Validator.SetInvalidBackColor(Me.txtDueDate, System.Drawing.Color.Empty)
      Me.txtDueDate.Location = New System.Drawing.Point(272, 40)
      Me.Validator.SetMaxValue(Me.txtDueDate, "")
      Me.Validator.SetMinValue(Me.txtDueDate, "")
      Me.txtDueDate.Name = "txtDueDate"
      Me.Validator.SetRegularExpression(Me.txtDueDate, "")
      Me.Validator.SetRequired(Me.txtDueDate, True)
      Me.txtDueDate.Size = New System.Drawing.Size(78, 20)
      Me.txtDueDate.TabIndex = 6
      Me.txtDueDate.Text = ""
      '
      'BillAcceptanceDetail
      '
      Me.Controls.Add(Me.tgItem)
      Me.Controls.Add(Me.ibtnBlank)
      Me.Controls.Add(Me.ibtnDelRow)
      Me.Controls.Add(Me.grbSupplier)
      Me.Controls.Add(Me.chkAutorun)
      Me.Controls.Add(Me.txtDocDate)
      Me.Controls.Add(Me.dtpDocDate)
      Me.Controls.Add(Me.lblCode)
      Me.Controls.Add(Me.txtCode)
      Me.Controls.Add(Me.lblDocDate)
      Me.Controls.Add(Me.lblBillIssue)
      Me.Controls.Add(Me.txtBillIssueCode)
      Me.Controls.Add(Me.lblBillIssueDocDate)
      Me.Controls.Add(Me.txtBillIssueDocDate)
      Me.Controls.Add(Me.dtpBillIssueDocDate)
      Me.Controls.Add(Me.txtNote)
      Me.Controls.Add(Me.lblNote)
      Me.Controls.Add(Me.grbSummary)
      Me.Controls.Add(Me.lblItem)
      Me.Name = "BillAcceptanceDetail"
      Me.Size = New System.Drawing.Size(808, 400)
      Me.grbSummary.ResumeLayout(False)
      Me.grbSupplier.ResumeLayout(False)
      CType(Me.tgItem, System.ComponentModel.ISupportInitialize).EndInit()
      Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Members"
    Private m_entity As BillAcceptance
    Private m_isInitialized As Boolean = False
    Private m_treeManager As TreeManager

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
      Dim dt As TreeTable = BillAcceptance.GetSchemaTable()
      Dim dst As DataGridTableStyle = Me.CreateTableStyle()
      m_treeManager = New TreeManager(dt, tgItem)
      m_treeManager.SetTableStyle(dst)
      m_treeManager.AllowSorting = False
      m_treeManager.AllowDelete = False
      tgItem.AllowNew = False

      AddHandler dt.ColumnChanging, AddressOf Treetable_ColumnChanging
      AddHandler dt.ColumnChanged, AddressOf Treetable_ColumnChanged
      AddHandler dt.RowDeleted, AddressOf ItemDelete

      EventWiring()
    End Sub
    Private Sub SaveEnableState()
      m_enableState = New Hashtable
      For Each ctrl As Control In Me.grbSupplier.Controls
        m_enableState.Add(ctrl, ctrl.Enabled)
      Next
      For Each ctrl As Control In Me.grbSummary.Controls
        m_enableState.Add(ctrl, ctrl.Enabled)
      Next
      For Each ctrl As Control In Me.Controls
        m_enableState.Add(ctrl, ctrl.Enabled)
      Next
    End Sub
#End Region

#Region "Style"
    Public Function CreateTableStyle() As DataGridTableStyle
      Dim dst As New DataGridTableStyle
      dst.MappingName = "BillAcceptance"
      Dim myStringParserService As StringParserService = CType(ServiceManager.Services.GetService(GetType(StringParserService)), StringParserService)

      Dim csLineNumber As New TreeTextColumn
      csLineNumber.MappingName = "billai_linenumber"
      csLineNumber.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.BillAcceptanceDetail.LineNumberHeaderText}")
      csLineNumber.NullText = ""
      csLineNumber.Width = 30
      csLineNumber.DataAlignment = HorizontalAlignment.Center
      csLineNumber.ReadOnly = True
      csLineNumber.TextBox.Name = "billai_linenumber"

      Dim csType As DataGridComboColumn
      csType = New DataGridComboColumn("billai_entityType", CodeDescription.GetCodeList("PayableItemType", "code_value not in (47)"), "code_description", "code_value")
      csType.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.BillAcceptanceDetail.TypeHeaderText}")
      csType.Width = 70
      csType.NullText = String.Empty

      Dim csCode As New TreeTextColumn
      csCode.MappingName = "Code"
      csCode.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.BillAcceptanceDetail.CodeHeaderText}")
      csCode.NullText = ""
      csCode.TextBox.Name = "Code"

      Dim csButton As New DataGridButtonColumn
      csButton.MappingName = "Button"
      csButton.HeaderText = ""
      csButton.NullText = ""
      AddHandler csButton.Click, AddressOf ItemButtonClick

      Dim csDocDate As New DataGridTimePickerColumn
      csDocDate.MappingName = "DocDate"
      csDocDate.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.BillAcceptanceDetail.DocDateHeaderText}")
      csDocDate.NullText = ""
      'csDocDate.ReadOnly = True

      'Dim csDueDate As New DataGridTimePickerColumn
      'csDueDate.MappingName = "DueDate"
      'csDueDate.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.BillAcceptanceDetail.DueDateHeaderText}")
      'csDueDate.NullText = ""
      ''csDueDate.ReadOnly = True

      Dim csRetention As New TreeTextColumn
      csRetention.MappingName = "Retention"
      csRetention.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.BillAcceptanceDetail.RetentionHeaderText}")
      csRetention.NullText = ""
      csRetention.DataAlignment = HorizontalAlignment.Right
      csRetention.Format = "#,###.##"
      csRetention.ReadOnly = True
      csRetention.TextBox.Name = "Retention"

      Dim csPlusRetention As New TreeTextColumn
      csPlusRetention.MappingName = "PlusRetention"
      csPlusRetention.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.BillAcceptanceDetail.PlusRetentionHeaderText}")
      csPlusRetention.NullText = ""
      csPlusRetention.DataAlignment = HorizontalAlignment.Right
      csPlusRetention.Format = "#,###.##"
      csPlusRetention.ReadOnly = True
      csPlusRetention.TextBox.Name = "PlusRetention"

      Dim csRealAmount As New TreeTextColumn
      csRealAmount.MappingName = "RealAmount"
      csRealAmount.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.BillAcceptanceDetail.RealAmountHeaderText}")
      csRealAmount.NullText = ""
      csRealAmount.DataAlignment = HorizontalAlignment.Right
      csRealAmount.Format = "#,###.##"
      csRealAmount.ReadOnly = True
      csRealAmount.TextBox.Name = "RealAmount"

      Dim csUnpaidAmount As New TreeTextColumn
      csUnpaidAmount.MappingName = "UnpaidAmount"
      csUnpaidAmount.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.BillAcceptanceDetail.UnpaidAmountHeaderText}")
      csUnpaidAmount.NullText = ""
      csUnpaidAmount.DataAlignment = HorizontalAlignment.Right
      csUnpaidAmount.Format = "#,###.##"
      csUnpaidAmount.ReadOnly = True
      csUnpaidAmount.TextBox.Name = "UnpaidAmount"

      Dim csAmount As New TreeTextColumn
      csAmount.MappingName = "billai_amt"
      csAmount.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.BillAcceptanceDetail.AmountHeaderText}")
      csAmount.NullText = ""
      csAmount.DataAlignment = HorizontalAlignment.Right
      csAmount.Format = "#,###.##"
      csAmount.TextBox.Name = "billai_amt"

      Dim csNote As New TreeTextColumn
      csNote.MappingName = "billai_note"
      csNote.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.BillAcceptanceDetail.NoteHeaderText}")
      csNote.NullText = ""
      csNote.Width = 180
      csNote.TextBox.Name = "billai_note"

      dst.GridColumnStyles.Add(csLineNumber)
      dst.GridColumnStyles.Add(csType)
      dst.GridColumnStyles.Add(csCode)
      dst.GridColumnStyles.Add(csButton)
      dst.GridColumnStyles.Add(csDocDate)
      'dst.GridColumnStyles.Add(csDueDate)
      dst.GridColumnStyles.Add(csRetention)
      dst.GridColumnStyles.Add(csPlusRetention)
      dst.GridColumnStyles.Add(csRealAmount)
      dst.GridColumnStyles.Add(csUnpaidAmount)
      dst.GridColumnStyles.Add(csAmount)
      dst.GridColumnStyles.Add(csNote)

      m_tableStyleEnable = New Hashtable
      For Each colStyle As DataGridColumnStyle In dst.GridColumnStyles
        m_tableStyleEnable.Add(colStyle, colStyle.ReadOnly)
      Next
      Return dst
    End Function
#End Region

#Region "Properties"
    Private ReadOnly Property CurrentItem() As BillAcceptanceItem
      Get
        Dim row As TreeRow = Me.m_treeManager.SelectedRow
        If row Is Nothing Then
          Return Nothing
        End If
        If Not TypeOf row.Tag Is BillAcceptanceItem Then
          Return Nothing
        End If
        Return CType(row.Tag, BillAcceptanceItem)
      End Get
    End Property
#End Region

#Region "TreeTable Handlers"
    Private Sub Treetable_ColumnChanged(ByVal sender As Object, ByVal e As System.Data.DataColumnChangeEventArgs)
      If Not m_isInitialized Then
        Return
      End If
      Dim index As Integer = Me.m_treeManager.Treetable.Childs.IndexOf(CType(e.Row, TreeRow))
      If ValidateRow(CType(e.Row, TreeRow)) Then
        Me.UpdateAmount()
        Me.m_treeManager.Treetable.AcceptChanges()
      End If
      Me.WorkbenchWindow.ViewContent.IsDirty = True
    End Sub
    Private Sub Treetable_ColumnChanging(ByVal sender As Object, ByVal e As System.Data.DataColumnChangeEventArgs)
      If Not m_isInitialized Then
        Return
      End If
      If Me.m_treeManager.SelectedRow Is Nothing Then
        Return
      End If
      Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
      If Me.m_entity Is Nothing Then
        Return
      End If
      If Me.m_entity.Supplier Is Nothing OrElse Not Me.m_entity.Supplier.Originated Then
        msgServ.ShowMessage("${res:Global.Error.SpecifySupplier}")
        e.ProposedValue = e.Row(e.Column)
        Return
      End If
      If Me.CurrentItem Is Nothing Then
        Dim doc As New BillAcceptanceItem
        Me.m_entity.ItemCollection.Add(doc)
        Me.m_treeManager.SelectedRow.Tag = doc
      End If
      Try

        Select Case e.Column.ColumnName.ToLower
          Case "code"
            SetCode(e)
          Case "billai_entitytype"
            SetEntityType(e)
          Case "duedate"
            SetDueDate(e)
          Case "docdate"
            SetDate(e)
          Case "realamount"
            SetRealAmount(e)
          Case "billai_amt"
            If Not IsNumeric(e.ProposedValue.ToString) Then
              e.ProposedValue = ""
            Else
              SetAmount(e)
            End If

          Case "billai_note"
            SetNote(e)
        End Select

        ValidateRow(e)
      Catch ex As Exception
        MessageBox.Show(ex.ToString)
      End Try
    End Sub
    Public Sub ValidateRow(ByVal e As DataColumnChangeEventArgs)
      Dim code As Object = e.Row("code")
      Dim billai_entitytype As Object = e.Row("billai_entitytype")
      Dim billai_amt As Object = e.Row("billai_amt")

      Select Case e.Column.ColumnName.ToLower
        Case "code"
          code = e.ProposedValue
        Case "billai_entitytype"
          billai_entitytype = e.ProposedValue
        Case "billai_amt"
          billai_amt = e.ProposedValue
        Case Else
          Return
      End Select

      Dim isBlankRow As Boolean = False
      If IsDBNull(billai_entitytype) Then
        isBlankRow = True
      End If
      If Not isBlankRow Then
        Select Case CInt(billai_entitytype)
          Case 45, 292 'รับของ
            If IsDBNull(code) OrElse code.ToString.Length = 0 Then
              e.Row.SetColumnError("code", Me.StringParserService.Parse("${res:Global.Error.GoodsReceiptCodeMissing}"))
            Else
              e.Row.SetColumnError("code", "")
            End If
          Case 50 'รับของ
            If IsDBNull(code) OrElse code.ToString.Length = 0 Then
              e.Row.SetColumnError("code", Me.StringParserService.Parse("${res:Global.Error.EqMaintenanceCodeMissing}"))
            Else
              e.Row.SetColumnError("code", "")
            End If
          Case 46 'ลดหนี้
            If IsDBNull(code) OrElse code.ToString.Length = 0 Then
              e.Row.SetColumnError("code", Me.StringParserService.Parse("${res:Global.Error.PurchaseCNCodeMissing}"))
            Else
              e.Row.SetColumnError("code", "")
            End If
          Case 47 'เพิ่มหนี้
            If IsDBNull(code) OrElse code.ToString.Length = 0 Then
              e.Row.SetColumnError("code", Me.StringParserService.Parse("${res:Global.Error.BillAcceptanceCodeMissing}"))
            Else
              e.Row.SetColumnError("code", "")
            End If
          Case 15 'เจ้าหนี้ยกมา
            If IsDBNull(code) OrElse code.ToString.Length = 0 Then
              e.Row.SetColumnError("code", Me.StringParserService.Parse("${res:Global.Error.APOpeningBalanceCodeMissing}"))
            Else
              e.Row.SetColumnError("code", "")
            End If
          Case 292 'รับงาน
            If IsDBNull(code) OrElse code.ToString.Length = 0 Then
              e.Row.SetColumnError("code", Me.StringParserService.Parse("${res:Global.Error.PACodeMissing}"))
            Else
              e.Row.SetColumnError("code", "")
            End If
          Case Else
            Return
        End Select
        If IsDBNull(billai_amt) OrElse Not IsNumeric(billai_amt) OrElse CDec(billai_amt) <= 0 Then
          e.Row.SetColumnError("billai_amt", Me.StringParserService.Parse("${res:Global.Error.BillAcceptanceAmountMissing}"))
        Else
          e.Row.SetColumnError("billai_amt", "")
        End If
      End If
    End Sub
    Public Function ValidateRow(ByVal row As TreeRow) As Boolean
      If row.Tag Is Nothing Then
        Return False
      End If
      Return True
    End Function
    Private m_updating As Boolean = False
    Public Sub SetNote(ByVal e As DataColumnChangeEventArgs)
      If m_updating Then
        Return
      End If
      Dim doc As BillAcceptanceItem = Me.CurrentItem
      m_updating = True
      doc.Note = e.ProposedValue.ToString
      m_updating = False
    End Sub
    Public Sub SetAmount(ByVal e As DataColumnChangeEventArgs)
      If m_updating Then
        Return
      End If
      Dim doc As BillAcceptanceItem = Me.CurrentItem
      If IsDBNull(e.ProposedValue) OrElse e.ProposedValue.ToString.Length = 0 Then
        e.ProposedValue = ""
        Return
      End If
      e.ProposedValue = Configuration.FormatToString(CDec(TextParser.Evaluate(e.ProposedValue.ToString)), DigitConfig.Price)
      Dim value As Decimal = CDec(e.ProposedValue)
      'Dim remain As Decimal = doc.GetRemainingAmountWithBillAcceptance(Me.m_entity.Id)
      Dim remain As Decimal = doc.UnpaidAmount
      m_updating = True
      'If doc.UnpaidAmount <> remain Then
      'doc.UnpaidAmount = remain
      e.Row("UnpaidAmount") = Configuration.FormatToString(doc.UnpaidAmount, DigitConfig.Price)
      'End If
      Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
      If e.Row.IsNull("billai_entityType") Then
        msgServ.ShowMessage("${res:Global.Error.NoBillAcceptanceEntityType}")
        e.ProposedValue = e.Row(e.Column)
        m_updating = False
        Return
      End If
      If remain < value Then
        msgServ.ShowMessageFormatted("${res:Global.Error.BillaRemainingAmountLessThanAmount}", _
        New String() { _
        Configuration.FormatToString(remain, DigitConfig.Price) _
        , Configuration.FormatToString(value, DigitConfig.Price) _
        })

        e.ProposedValue = e.Row(e.Column)
        m_updating = False
        Return
      End If
      doc.Amount = value
      m_updating = False
    End Sub
    Public Sub SetRealAmount(ByVal e As DataColumnChangeEventArgs)
      If m_updating Then
        Return
      End If
      m_updating = True
      Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
      msgServ.ShowMessage("${res:Global.Error.CannotChangeRealAmount}")
      e.ProposedValue = e.Row(e.Column)
      m_updating = False
    End Sub
    Public Sub SetDate(ByVal e As DataColumnChangeEventArgs)
      If m_updating Then
        Return
      End If
      m_updating = True
      Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
      msgServ.ShowMessage("${res:Global.Error.CannotChangeDate}")
      e.ProposedValue = e.Row(e.Column)
      m_updating = False
    End Sub
    Public Sub SetDueDate(ByVal e As DataColumnChangeEventArgs)
      If m_updating Then
        Return
      End If
      m_updating = True
      Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
      msgServ.ShowMessage("${res:Global.Error.CannotChangeDueDate}")
      e.ProposedValue = e.Row(e.Column)
      m_updating = False
    End Sub
    Public Sub SetEntityType(ByVal e As DataColumnChangeEventArgs)
      If m_updating Then
        Return
      End If
      Dim doc As BillAcceptanceItem = Me.CurrentItem
      m_updating = True
      Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
      If e.Row.IsNull(e.Column) Then
        m_updating = False
        Return
      End If

      If CInt(e.ProposedValue) = CInt(e.Row(e.Column)) Then
        'ผ่านโลด
        m_updating = False
        Return
      End If
      If msgServ.AskQuestion("${res:Global.Question.ChangeBillAcceptanceEntityType}") Then
        e.Row("billai_entity") = DBNull.Value
        e.Row("code") = DBNull.Value
        e.Row("RealAmount") = DBNull.Value
        e.Row("billai_amt") = DBNull.Value
        e.Row("UnpaidAmount") = DBNull.Value
        e.Row("DueDate") = Date.MinValue
        e.Row("DocDate") = Date.MinValue
        doc.Clear()
        'doc.SetType(CInt(e.ProposedValue)) Undone:
      Else
        e.ProposedValue = e.Row(e.Column)
        m_updating = False
        Return
      End If
      m_updating = False
    End Sub
    Private Function DupCode(ByVal e As DataColumnChangeEventArgs) As Boolean
      If e.Row.IsNull("billai_entityType") Then
        Return False
      End If
      If IsDBNull(e.ProposedValue) Then
        Return False
      End If
      Dim doc As BillAcceptanceItem = Me.CurrentItem
      If doc Is Nothing Then
        Return False
      End If
      For Each item As BillAcceptanceItem In Me.m_entity.ItemCollection
        If Not doc Is item Then
          If item.EntityId = CInt(e.Row("billai_entityType")) Then
            If e.ProposedValue.ToString.ToLower = item.Code.ToLower Then
              Return True
            End If
          End If
        End If
      Next
      Return False
    End Function
    Public Sub SetCode(ByVal e As DataColumnChangeEventArgs)
      If m_updating Then
        Return
      End If
      Dim doc As BillAcceptanceItem = Me.CurrentItem
      If doc Is Nothing Then
        e.ProposedValue = e.Row(e.Column)
        Return
      End If
      m_updating = True
      Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
      If e.Row.IsNull("billai_entityType") Then
        msgServ.ShowMessage("${res:Global.Error.NoBillAcceptanceEntityType}")
        e.ProposedValue = e.Row(e.Column)
        m_updating = False
        Return
      End If
      If DupCode(e) Then
        msgServ.ShowMessageFormatted("${res:Global.Error.AlreadyHasCode}", New String() {BusinessLogic.Entity.GetFullClassName(doc.EntityId), e.ProposedValue.ToString})
        e.ProposedValue = e.Row(e.Column)
        m_updating = False
        Return
      End If
      Select Case CInt(e.Row("billai_entityType"))
        Case 45 'รับของ
          If e.ProposedValue.ToString.Length = 0 Then
            If e.Row(e.Column).ToString.Length <> 0 Then
              If msgServ.AskQuestionFormatted("${res:Global.Question.DeleteGoodsReceiptDetail}", New String() {e.Row(e.Column).ToString}) Then
                e.Row("billai_entity") = DBNull.Value
                e.Row("RealAmount") = DBNull.Value
                e.Row("UnpaidAmount") = DBNull.Value
                e.Row("billai_amt") = DBNull.Value
                e.Row("DueDate") = Date.MinValue
                e.Row("DocDate") = Date.MinValue
                doc.Clear()
              Else
                e.ProposedValue = e.Row(e.Column)
              End If
            End If
            m_updating = False
            Return
          End If
          Dim gr As New GoodsReceipt(e.ProposedValue.ToString)
          If Not gr.Originated Then
            msgServ.ShowMessageFormatted("${res:Global.Error.NoGoodsReceipt}", New String() {e.ProposedValue.ToString})
            e.ProposedValue = e.Row(e.Column)
            m_updating = False
            Return
          Else
            If gr.Status.Value = 0 Then
              msgServ.ShowMessageFormatted("${res:Global.Error.GoodsReceiptIsCanceled}", New String() {e.ProposedValue.ToString})
              e.ProposedValue = e.Row(e.Column)
              m_updating = False
              Return
            End If
            Dim remain As Decimal = gr.GetRemainingAmountWithBillAcceptance(Me.m_entity.Id)
            If remain <= 0 Then
              msgServ.ShowMessageFormatted("${res:Global.Error.ZeroOrLessGoodsReceiptAmount}", New String() {e.ProposedValue.ToString})
              e.ProposedValue = e.Row(e.Column)
              m_updating = False
              Return
            End If
            e.Row("billai_entity") = gr.Id
            e.ProposedValue = gr.Code
            e.Row("RealAmount") = Configuration.FormatToString(gr.Payment.Amount, DigitConfig.Price)
            e.Row("billai_amt") = Configuration.FormatToString(remain, DigitConfig.Price)
            e.Row("UnpaidAmount") = Configuration.FormatToString(remain, DigitConfig.Price)
            e.Row("DueDate") = gr.DueDate
            e.Row("DocDate") = gr.DocDate
            doc.Id = gr.Id
            doc.RealAmount = gr.Payment.Amount
            doc.UnpaidAmount = remain
            doc.Amount = remain
            doc.Code = gr.Code
            doc.Date = gr.DocDate
            doc.CreditPeriod = gr.CreditPeriod
            doc.SetType(45)
          End If
        Case 292 'รับงาน
          If e.ProposedValue.ToString.Length = 0 Then
            If e.Row(e.Column).ToString.Length <> 0 Then
              If msgServ.AskQuestionFormatted("${res:Global.Question.DeleteGoodsReceiptDetail}", New String() {e.Row(e.Column).ToString}) Then
                e.Row("billai_entity") = DBNull.Value
                e.Row("RealAmount") = DBNull.Value
                e.Row("UnpaidAmount") = DBNull.Value
                e.Row("billai_amt") = DBNull.Value
                e.Row("DueDate") = Date.MinValue
                e.Row("DocDate") = Date.MinValue
                doc.Clear()
              Else
                e.ProposedValue = e.Row(e.Column)
              End If
            End If
            m_updating = False
            Return
          End If
          Dim p As New PA(e.ProposedValue.ToString)
          If Not p.Originated Then
            msgServ.ShowMessageFormatted("${res:Global.Error.NoGoodsReceipt}", New String() {e.ProposedValue.ToString})
            e.ProposedValue = e.Row(e.Column)
            m_updating = False
            Return
          Else
            If p.Status.Value = 0 Then
              msgServ.ShowMessageFormatted("${res:Global.Error.GoodsReceiptIsCanceled}", New String() {e.ProposedValue.ToString})
              e.ProposedValue = e.Row(e.Column)
              m_updating = False
              Return
            End If
            Dim remain As Decimal = p.GetRemainingAmountWithBillAcceptance(Me.m_entity.Id)
            If remain <= 0 Then
              msgServ.ShowMessageFormatted("${res:Global.Error.ZeroOrLessGoodsReceiptAmount}", New String() {e.ProposedValue.ToString})
              e.ProposedValue = e.Row(e.Column)
              m_updating = False
              Return
            End If
            e.Row("billai_entity") = p.Id
            e.ProposedValue = p.Code
            e.Row("RealAmount") = Configuration.FormatToString(p.Payment.Amount, DigitConfig.Price)
            e.Row("billai_amt") = Configuration.FormatToString(remain, DigitConfig.Price)
            e.Row("UnpaidAmount") = Configuration.FormatToString(remain, DigitConfig.Price)
            e.Row("DueDate") = p.DueDate
            e.Row("DocDate") = p.DocDate
            doc.Id = p.Id
            doc.RealAmount = p.Payment.Amount
            doc.UnpaidAmount = remain
            doc.Amount = remain
            doc.Code = p.Code
            doc.Date = p.DocDate
            doc.CreditPeriod = p.CreditPeriod
            doc.SetType(292)
          End If
        Case 50 'ซ่อมบำรุง
          If e.ProposedValue.ToString.Length = 0 Then
            If e.Row(e.Column).ToString.Length <> 0 Then
              If msgServ.AskQuestionFormatted("${res:Global.Question.DeleteEqMaintenanceDetail}", New String() {e.Row(e.Column).ToString}) Then
                e.Row("billai_entity") = DBNull.Value
                e.Row("RealAmount") = DBNull.Value
                e.Row("UnpaidAmount") = DBNull.Value
                e.Row("billai_amt") = DBNull.Value
                e.Row("DueDate") = Date.MinValue
                e.Row("DocDate") = Date.MinValue
                doc.Clear()
              Else
                e.ProposedValue = e.Row(e.Column)
              End If
            End If
            m_updating = False
            Return
          End If
          Dim eqm As New EqMaintenance(e.ProposedValue.ToString)
          If Not eqm.Originated Then
            msgServ.ShowMessageFormatted("${res:Global.Error.NoEqMaintenance}", New String() {e.ProposedValue.ToString})
            e.ProposedValue = e.Row(e.Column)
            m_updating = False
            Return
          Else
            If eqm.Status.Value = 0 Then
              msgServ.ShowMessageFormatted("${res:Global.Error.EqMaintenanceIsCanceled}", New String() {e.ProposedValue.ToString})
              e.ProposedValue = e.Row(e.Column)
              m_updating = False
              Return
            End If
            Dim remain As Decimal = eqm.GetRemainingAmountWithBillAcceptance(Me.m_entity.Id)
            If remain <= 0 Then
              msgServ.ShowMessageFormatted("${res:Global.Error.ZeroOrLessEqMaintenanceAmount}", New String() {e.ProposedValue.ToString})
              e.ProposedValue = e.Row(e.Column)
              m_updating = False
              Return
            End If
            e.Row("billai_entity") = eqm.Id
            e.ProposedValue = eqm.Code
            e.Row("RealAmount") = Configuration.FormatToString(eqm.Payment.Amount, DigitConfig.Price)
            e.Row("billai_amt") = Configuration.FormatToString(remain, DigitConfig.Price)
            e.Row("UnpaidAmount") = Configuration.FormatToString(remain, DigitConfig.Price)
            e.Row("DueDate") = eqm.DueDate
            e.Row("DocDate") = eqm.DocDate
            doc.Id = eqm.Id
            doc.RealAmount = eqm.Payment.Amount
            doc.UnpaidAmount = remain
            doc.Amount = remain
            doc.Code = eqm.Code
            doc.Date = eqm.DocDate
            doc.CreditPeriod = eqm.CreditPeriod
            doc.SetType(50)
          End If
        Case 46 'ลดหนี้
          If e.ProposedValue.ToString.Length = 0 Then
            If e.Row(e.Column).ToString.Length <> 0 Then
              If msgServ.AskQuestionFormatted("${res:Global.Question.DeletePurchaseCNDetail}", New String() {e.Row(e.Column).ToString}) Then
                e.Row("billai_entity") = DBNull.Value
                e.Row("RealAmount") = DBNull.Value
                e.Row("UnpaidAmount") = DBNull.Value
                e.Row("billai_amt") = DBNull.Value
                e.Row("DueDate") = Date.MinValue
                e.Row("DocDate") = Date.MinValue
                doc.Clear()
              Else
                e.ProposedValue = e.Row(e.Column)
              End If
            End If
            m_updating = False
            Return
          End If
          Dim pcn As New PurchaseCN(e.ProposedValue.ToString)
          If Not pcn.Originated Then
            msgServ.ShowMessageFormatted("${res:Global.Error.NoPurchaseCN}", New String() {e.ProposedValue.ToString})
            e.ProposedValue = e.Row(e.Column)
            m_updating = False
            Return
          Else
            If pcn.Status.Value = 0 Then
              msgServ.ShowMessageFormatted("${res:Global.Error.PurchaseCNIsCanceled}", New String() {e.ProposedValue.ToString})
              e.ProposedValue = e.Row(e.Column)
              m_updating = False
              Return
            End If
            Dim remain As Decimal = pcn.GetRemainingAmountWithBillAcceptance(Me.m_entity.Id)
            If remain <= 0 Then
              msgServ.ShowMessageFormatted("${res:Global.Error.ZeroOrLessPurchaseCNAmount}", New String() {e.ProposedValue.ToString})
              e.ProposedValue = e.Row(e.Column)
              m_updating = False
              Return
            End If
            e.Row("billai_entity") = pcn.Id
            e.ProposedValue = pcn.Code
            e.Row("RealAmount") = Configuration.FormatToString(pcn.Payment.Amount, DigitConfig.Price)
            e.Row("billai_amt") = Configuration.FormatToString(remain, DigitConfig.Price)
            e.Row("UnpaidAmount") = Configuration.FormatToString(remain, DigitConfig.Price)
            e.Row("DueDate") = pcn.DueDate
            e.Row("DocDate") = pcn.DocDate
            doc.Id = pcn.Id
            doc.RealAmount = pcn.Payment.Amount
            doc.UnpaidAmount = remain
            doc.Amount = remain
            doc.Code = pcn.Code
            doc.Date = pcn.DocDate
            doc.CreditPeriod = pcn.CreditPeriod
            doc.SetType(46)
          End If
        Case 47 'เพิ่มหนี้
          If e.ProposedValue.ToString.Length = 0 Then
            If e.Row(e.Column).ToString.Length <> 0 Then
              If msgServ.AskQuestionFormatted("${res:Global.Question.DeleteBillAcceptanceDetail}", New String() {e.Row(e.Column).ToString}) Then
                e.Row("billai_entity") = DBNull.Value
                e.Row("RealAmount") = DBNull.Value
                e.Row("UnpaidAmount") = DBNull.Value
                e.Row("billai_amt") = DBNull.Value
                e.Row("DueDate") = Date.MinValue
                e.Row("DocDate") = Date.MinValue
                doc.Clear()
              Else
                e.ProposedValue = e.Row(e.Column)
              End If
            End If
            m_updating = False
            Return
          End If
          Dim pdn As New PurchaseDN(e.ProposedValue.ToString)
          If Not pdn.Originated Then
            msgServ.ShowMessageFormatted("${res:Global.Error.NoPurchaseDN}", New String() {e.ProposedValue.ToString})
            e.ProposedValue = e.Row(e.Column)
            m_updating = False
            Return
          Else
            If pdn.Status.Value = 0 Then
              msgServ.ShowMessageFormatted("${res:Global.Error.PurchaseDNIsCanceled}", New String() {e.ProposedValue.ToString})
              e.ProposedValue = e.Row(e.Column)
              m_updating = False
              Return
            End If
            Dim remain As Decimal = pdn.GetRemainingAmountWithBillAcceptance(Me.m_entity.Id)
            If remain <= 0 Then
              msgServ.ShowMessageFormatted("${res:Global.Error.ZeroOrLessPurchaseDNAmount}", New String() {e.ProposedValue.ToString})
              e.ProposedValue = e.Row(e.Column)
              m_updating = False
              Return
            End If
            e.Row("billai_entity") = pdn.Id
            e.ProposedValue = pdn.Code
            e.Row("RealAmount") = Configuration.FormatToString(pdn.Payment.Amount, DigitConfig.Price)
            e.Row("billai_amt") = Configuration.FormatToString(remain, DigitConfig.Price)
            e.Row("UnpaidAmount") = Configuration.FormatToString(remain, DigitConfig.Price)
            e.Row("DueDate") = pdn.DueDate
            e.Row("DocDate") = pdn.DocDate
            doc.Id = pdn.Id
            doc.RealAmount = pdn.Payment.Amount
            doc.UnpaidAmount = remain
            doc.Amount = remain
            doc.Code = pdn.Code
            doc.Date = pdn.DocDate
            doc.CreditPeriod = pdn.CreditPeriod
            doc.SetType(46)
          End If
        Case 15 'เจ้าหนี้ยกมา
          If e.ProposedValue.ToString.Length = 0 Then
            If e.Row(e.Column).ToString.Length <> 0 Then
              If msgServ.AskQuestionFormatted("${res:Global.Question.DeleteAPOpeningBalanceDetail}", New String() {e.Row(e.Column).ToString}) Then
                e.Row("billai_entity") = DBNull.Value
                e.Row("RealAmount") = DBNull.Value
                e.Row("billai_amt") = DBNull.Value
                e.Row("UnpaidAmount") = DBNull.Value
                e.Row("DueDate") = Date.MinValue
                e.Row("DocDate") = Date.MinValue
                doc.Clear()
              Else
                e.ProposedValue = e.Row(e.Column)
              End If
            End If
            m_updating = False
            Return
          End If
          Dim apo As New APOpeningBalance(e.ProposedValue.ToString)
          If Not apo.Originated Then
            msgServ.ShowMessageFormatted("${res:Global.Error.NoAPOpeningBalance}", New String() {e.ProposedValue.ToString})
            e.ProposedValue = e.Row(e.Column)
            m_updating = False
            Return
          Else
            If apo.Status.Value = 0 Then
              msgServ.ShowMessageFormatted("${res:Global.Error.APOpeningBalanceIsCanceled}", New String() {e.ProposedValue.ToString})
              e.ProposedValue = e.Row(e.Column)
              m_updating = False
              Return
            End If
            Dim remain As Decimal = apo.GetRemainingAmountWithBillAcceptance(Me.m_entity.Id)
            If remain <= 0 Then
              msgServ.ShowMessageFormatted("${res:Global.Error.ZeroOrLessAPOpeningBalanceAmount}", New String() {e.ProposedValue.ToString})
              e.ProposedValue = e.Row(e.Column)
              m_updating = False
              Return
            End If
            e.Row("billai_entity") = apo.Id
            e.ProposedValue = apo.Code
            e.Row("RealAmount") = Configuration.FormatToString(apo.Payment.Amount, DigitConfig.Price)
            e.Row("billai_amt") = Configuration.FormatToString(remain, DigitConfig.Price)
            e.Row("UnpaidAmount") = Configuration.FormatToString(remain, DigitConfig.Price)
            e.Row("DueDate") = apo.DueDate
            e.Row("DocDate") = apo.DocDate
            doc.Id = apo.Id
            doc.RealAmount = apo.Payment.Amount
            doc.UnpaidAmount = remain
            doc.Amount = remain
            doc.Code = apo.Code
            doc.Date = apo.DocDate
            doc.CreditPeriod = apo.CreditPeriod
            doc.SetType(46)
          End If
          '----------------------
        Case 292 'ใบรับงาน
          If e.ProposedValue.ToString.Length = 0 Then
            If e.Row(e.Column).ToString.Length <> 0 Then
              If msgServ.AskQuestionFormatted("${res:Global.Question.DeletePADetail}", New String() {e.Row(e.Column).ToString}) Then
                e.Row("billai_entity") = DBNull.Value
                e.Row("RealAmount") = DBNull.Value
                e.Row("billai_amt") = DBNull.Value
                e.Row("UnpaidAmount") = DBNull.Value
                e.Row("DueDate") = Date.MinValue
                e.Row("DocDate") = Date.MinValue
                doc.Clear()
              Else
                e.ProposedValue = e.Row(e.Column)
              End If
            End If
            m_updating = False
            Return
          End If
          Dim apo As New PA(e.ProposedValue.ToString)
          If Not apo.Originated Then
            msgServ.ShowMessageFormatted("${res:Global.Error.NoPA}", New String() {e.ProposedValue.ToString})
            e.ProposedValue = e.Row(e.Column)
            m_updating = False
            Return
          Else
            If apo.Status.Value = 0 Then
              msgServ.ShowMessageFormatted("${res:Global.Error.PAIsCanceled}", New String() {e.ProposedValue.ToString})
              e.ProposedValue = e.Row(e.Column)
              m_updating = False
              Return
            End If
            Dim remain As Decimal = apo.GetRemainingAmountWithBillAcceptance(Me.m_entity.Id)
            If remain <= 0 Then
              msgServ.ShowMessageFormatted("${res:Global.Error.ZeroOrLessPAAmount}", New String() {e.ProposedValue.ToString})
              e.ProposedValue = e.Row(e.Column)
              m_updating = False
              Return
            End If
            e.Row("billai_entity") = apo.Id
            e.ProposedValue = apo.Code
            e.Row("RealAmount") = Configuration.FormatToString(apo.Payment.Amount, DigitConfig.Price)
            e.Row("billai_amt") = Configuration.FormatToString(remain, DigitConfig.Price)
            e.Row("UnpaidAmount") = Configuration.FormatToString(remain, DigitConfig.Price)
            e.Row("DueDate") = apo.DueDate
            e.Row("DocDate") = apo.DocDate
            doc.Id = apo.Id
            doc.RealAmount = apo.Payment.Amount
            doc.UnpaidAmount = remain
            doc.Amount = remain
            doc.Code = apo.Code
            doc.Date = apo.DocDate
            doc.CreditPeriod = apo.CreditPeriod
            doc.SetType(292)
          End If
          '----------------------
        Case Else
          msgServ.ShowMessage("${res:Global.Error.NoBillAcceptanceEntityType}")
          e.ProposedValue = e.Row(e.Column)
          m_updating = False
          Return
      End Select
      m_updating = False
    End Sub
    Private Sub ItemDelete(ByVal sender As Object, ByVal e As System.Data.DataRowChangeEventArgs)
    End Sub
#End Region

#Region "IListDetail"
    Public Overrides Sub CheckFormEnable()
      If Me.m_entity Is Nothing Then
        Return
      End If
      If Me.m_entity.Status.Value = 0 _
      OrElse Me.m_entity.IsReferenced _
      Then
        Me.Enabled = False
      Else
        Me.Enabled = True
      End If
    End Sub
    Public Overrides Sub ClearDetail()
      For Each crlt As Control In Me.Controls
        If crlt.Name.StartsWith("txt") Then
          crlt.Text = ""
        End If
      Next
      For Each crlt As Control In grbSupplier.Controls
        If crlt.Name.StartsWith("txt") Then
          crlt.Text = ""
        End If
      Next
      For Each crlt As Control In grbSummary.Controls
        If crlt.Name.StartsWith("txt") Then
          crlt.Text = ""
        End If
      Next
      Me.dtpDocDate.Value = Now
    End Sub
    Public Overrides Sub SetLabelText()
      If Not m_entity Is Nothing Then Me.Text = Me.StringParserService.Parse(Me.m_entity.TabPageText)
      Me.lblDocDate.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.BillAcceptanceDetail.lblDocDate}")
      Me.lblCode.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.BillAcceptanceDetail.lblCode}")
      Me.lblItem.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.BillAcceptanceDetail.lblItem}")
      Me.grbSummary.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.BillAcceptanceDetail.grbSummary}")
      Me.lblItemCount.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.BillAcceptanceDetail.lblItemCount}")
      Me.lblItemCountUnit.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.BillAcceptanceDetail.lblItemCountUnit}")
      Me.lblNote.Text = Me.StringParserService.Parse("${res:Global.NoteText}")
      Me.lblCredit.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.BillAcceptanceDetail.lblCredit}")
      Me.lblDay.Text = Me.StringParserService.Parse("${res:Global.DayText}")
      Me.lblDueDate.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.BillAcceptanceDetail.lblDueDate}")
      Me.lblBillIssue.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.BillAcceptanceDetail.lblBillIssue}")

      Me.lblBillIssueDocDate.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.BillAcceptanceDetail.lblBillIssueDocDate}")
      Me.Validator.SetDisplayName(Me.txtBillIssueDocDate, Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.BillAcceptanceDetail.txtBillIssueDocDateAlert}"))

      Me.grbSupplier.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.BillAcceptanceDetail.grbSupplier}")

      Me.lblSupplier.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.BillAcceptanceDetail.lblSupplier}")
      Me.Validator.SetDisplayName(Me.txtSupplierCode, Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.BillAcceptanceDetail.txtSupplierCodeAlert}"))


      Me.lblRemaining.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.BillAcceptanceDetail.lblRemaining}")
      Me.lblRemainingUnit.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.BillAcceptanceDetail.lblRemainingUnit}")
      Me.lblGrossUnit.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.BillAcceptanceDetail.lblGrossUnit}")
      Me.lblGross.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.BillAcceptanceDetail.lblGross}")

      Me.lblRetention.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.BillAcceptanceDetail.lblRetention}")
      Me.lblPlusRetention.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.BillAcceptanceDetail.lblPlusRetention}")
      Me.lblRetentionUnit.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.BillAcceptanceDetail.lblRemainingUnit}")
      Me.lblPlusRetentionUnit.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.BillAcceptanceDetail.lblRemainingUnit}")
    End Sub
    Protected Overrides Sub EventWiring()
      AddHandler txtCode.TextChanged, AddressOf Me.ChangeProperty
      AddHandler txtNote.TextChanged, AddressOf Me.ChangeProperty
      AddHandler txtBillIssueCode.TextChanged, AddressOf Me.ChangeProperty

      AddHandler txtDocDate.Validated, AddressOf Me.ChangeProperty
      AddHandler dtpDocDate.ValueChanged, AddressOf Me.ChangeProperty

      AddHandler txtDueDate.Validated, AddressOf Me.ChangeProperty
      AddHandler dtpDueDate.ValueChanged, AddressOf Me.ChangeProperty

      AddHandler txtBillIssueDocDate.Validated, AddressOf Me.ChangeProperty
      AddHandler dtpBillIssueDocDate.ValueChanged, AddressOf Me.ChangeProperty

      AddHandler txtCreditPeriod.Validated, AddressOf Me.ChangeProperty
      AddHandler txtCreditPeriod.TextChanged, AddressOf Me.TextHandler

      AddHandler txtNote.TextChanged, AddressOf Me.ChangeProperty

      AddHandler txtSupplierCode.Validated, AddressOf Me.ChangeProperty
      AddHandler txtSupplierCode.TextChanged, AddressOf Me.TextHandler
    End Sub
    Private supplierCodeChanged As Boolean = False
    Private txtCreditPeriodChanged As Boolean = False
    Private Sub TextHandler(ByVal sender As Object, ByVal e As EventArgs)
      If Me.m_entity Is Nothing Or Not m_isInitialized Then
        Return
      End If
      Select Case CType(sender, Control).Name.ToLower
        Case "txtsuppliercode"
          supplierCodeChanged = True
        Case "txtcreditperiod"
          txtCreditPeriodChanged = True
      End Select
    End Sub
    ' แสดงค่าข้อมูลของลูกค้าลงใน control ที่อยู่บนฟอร์ม
    Public Overrides Sub UpdateEntityProperties()
      m_isInitialized = False
      ClearDetail()
      If m_entity Is Nothing Then
        Return
      End If
      oldSupId = Me.m_entity.Supplier.Id
      txtCode.Text = m_entity.Code
      txtNote.Text = m_entity.Note
      Me.m_oldCode = Me.m_entity.Code
      Me.chkAutorun.Checked = Me.m_entity.AutoGen
      Me.UpdateAutogenStatus()

      txtSupplierCode.Text = m_entity.Supplier.Code
      txtSupplierName.Text = m_entity.Supplier.Name

      Me.txtDueDate.Text = MinDateToNull(Me.m_entity.DueDate, "")
      Me.dtpDueDate.Value = MinDateToNow(Me.m_entity.DueDate)
      txtCreditPeriod.Text = Configuration.FormatToString(m_entity.CreditPeriod, DigitConfig.Int)

      txtDocDate.Text = MinDateToNull(Me.m_entity.DocDate, Me.StringParserService.Parse("${res:Global.BlankDateText}"))
      dtpDocDate.Value = MinDateToNow(Me.m_entity.DocDate)

      txtBillIssueDocDate.Text = MinDateToNull(Me.m_entity.BillIssueDocDate, Me.StringParserService.Parse("${res:Global.BlankDateText}"))
      dtpBillIssueDocDate.Value = MinDateToNow(Me.m_entity.BillIssueDocDate)

      Me.txtBillIssueCode.Text = Me.m_entity.BillIssueCode

      RefreshDocs()

      UpdateAmount()

      SetStatus()
      SetLabelText()
      CheckFormEnable()
      m_isInitialized = True
    End Sub
    Private Sub RefreshDocs()
      Me.m_isInitialized = False
      Me.m_entity.ItemCollection.Populate(m_treeManager.Treetable)
      RefreshBlankGrid()
      ReIndex()
      Me.m_isInitialized = True
    End Sub
    Private Sub PropChanged(ByVal sender As Object, ByVal e As PropertyChangedEventArgs)
      If e.Name = "ItemChanged" Then
        Me.WorkbenchWindow.ViewContent.IsDirty = True
      End If
    End Sub
    Private m_dateSetting As Boolean = False
    Private oldSupId As Integer
    Public Sub ChangeProperty(ByVal sender As Object, ByVal e As EventArgs)
      If Me.m_entity Is Nothing Or Not m_isInitialized Then
        Return
      End If
      Dim dirtyFlag As Boolean = False
      Select Case CType(sender, Control).Name.ToLower
        Case "txtcode"
          Me.m_entity.Code = txtCode.Text
          dirtyFlag = True
        Case "txtnote"
          Me.m_entity.Note = txtNote.Text
          dirtyFlag = True
        Case "txtbillissuecode"
          Me.m_entity.BillIssueCode = txtBillIssueCode.Text
          dirtyFlag = True
        Case "txtsuppliercode"
          If supplierCodeChanged Then
            supplierCodeChanged = False
            Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
            If Me.txtSupplierCode.TextLength <> 0 Then
              Dim oldSupplier As Supplier = Me.m_entity.Supplier
              Supplier.GetSupplier(txtSupplierCode, txtSupplierName, Me.m_entity.Supplier, False)
              Try
                If oldSupId <> Me.m_entity.Supplier.Id Then
                  If oldSupId = 0 OrElse msgServ.AskQuestion("${res:Longkong.Pojjaman.Gui.Panels.BillAcceptanceDetail.Message.ChangeSupplier}", "${res:Longkong.Pojjaman.Gui.Panels.BillAcceptanceDetail.Caption.ChangeSupplier}") Then
                    oldSupId = Me.m_entity.Supplier.Id
                    dirtyFlag = True
                    ChangeSupplier()
                  Else
                    dirtyFlag = False
                    Me.m_entity.Supplier = oldSupplier
                    Me.txtSupplierCode.Text = oldSupplier.Code
                    Me.txtSupplierName.Text = oldSupplier.Name
                    supplierCodeChanged = False
                  End If
                End If
              Catch ex As Exception

              End Try
            End If
          End If
        Case "dtpdocdate"
          If Not Me.m_entity.DocDate.Equals(dtpDocDate.Value) Then
            If Not m_dateSetting Then
              Me.txtDocDate.Text = MinDateToNull(dtpDocDate.Value, Me.StringParserService.Parse("${res:Global.BlankDateText}"))
              Me.m_entity.DocDate = dtpDocDate.Value
            End If
            dirtyFlag = True
            Me.txtDueDate.Text = MinDateToNull(Me.m_entity.DueDate, "")
            Me.dtpDueDate.Value = MinDateToNow(Me.m_entity.DueDate)
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
          Me.txtDueDate.Text = MinDateToNull(Me.m_entity.DueDate, "")
          Me.dtpDueDate.Value = MinDateToNow(Me.m_entity.DueDate)
          m_dateSetting = False

        Case "dtpduedate"
          If Not Me.m_entity.DueDate.Equals(dtpDueDate.Value) Then
            If Not m_dateSetting Then
              Me.txtDueDate.Text = MinDateToNull(dtpDueDate.Value, Me.StringParserService.Parse("${res:Global.BlankDateText}"))
              Me.m_entity.DueDate = dtpDueDate.Value
            End If
            dirtyFlag = True
            'Me.dtpDueDate.Value = MinDateToNow(Me.m_entity.DueDate)
            Me.txtCreditPeriod.Text = Me.m_entity.CreditPeriod
          End If
        Case "txtduedate"
          m_dateSetting = True
          If Not Me.txtDueDate.Text.Length = 0 AndAlso Me.Validator.GetErrorMessage(Me.txtDueDate) = "" Then
            Dim theDate As Date = CDate(Me.txtDueDate.Text)
            If Not Me.m_entity.DueDate.Equals(theDate) Then
              dtpDueDate.Value = theDate
              Me.m_entity.DueDate = dtpDueDate.Value
              dirtyFlag = True
            End If
          Else
            dtpDueDate.Value = Me.m_entity.DueDate 'Date.Now
            'Me.m_entity.DocDate = Date.MinValue
            dirtyFlag = True
          End If
          'Me.dtpDueDate.Value = MinDateToNow(Me.m_entity.DueDate)
          Me.txtCreditPeriod.Text = Me.m_entity.CreditPeriod
          m_dateSetting = False

        Case "txtbillissuedocdate"
          m_dateSetting = True
          If Not Me.txtBillIssueDocDate.Text.Length = 0 AndAlso Me.Validator.GetErrorMessage(Me.txtBillIssueDocDate) = "" Then
            Dim theDate As Date = CDate(Me.txtBillIssueDocDate.Text)
            If Not Me.m_entity.BillIssueDocDate.Equals(theDate) Then
              dtpBillIssueDocDate.Value = theDate
              Me.m_entity.BillIssueDocDate = dtpBillIssueDocDate.Value
              dirtyFlag = True
            End If
          Else
            dtpBillIssueDocDate.Value = Date.Now
            Me.m_entity.BillIssueDocDate = Date.MinValue
            dirtyFlag = True
          End If
          m_dateSetting = False
        Case "dtpbillissuedocdate"
          If Not Me.m_entity.BillIssueDocDate.Equals(dtpBillIssueDocDate.Value) Then
            If Not m_dateSetting Then
              Me.txtBillIssueDocDate.Text = MinDateToNull(dtpBillIssueDocDate.Value, Me.StringParserService.Parse("${res:Global.BlankDateText}"))
              Me.m_entity.BillIssueDocDate = dtpBillIssueDocDate.Value
            End If
            dirtyFlag = True
          End If
        Case "txtcreditperiod"
          If txtCreditPeriodChanged Then
            txtCreditPeriodChanged = False
            Dim txt As String = Me.txtCreditPeriod.Text
            If txt.Length > 0 AndAlso IsNumeric(txt) Then
              Me.m_entity.CreditPeriod = CInt(txt)
            Else
              Me.m_entity.CreditPeriod = 0
            End If
            txtCreditPeriod.Text = Configuration.FormatToString(Me.m_entity.CreditPeriod, DigitConfig.Int)
            Me.txtDueDate.Text = MinDateToNull(Me.m_entity.DueDate, "")
            Me.dtpDueDate.Value = MinDateToNow(Me.m_entity.DueDate)
            dirtyFlag = True
          End If
      End Select
      Me.WorkbenchWindow.ViewContent.IsDirty = Me.WorkbenchWindow.ViewContent.IsDirty Or dirtyFlag
      CheckFormEnable()
    End Sub
    Private Sub ChangeSupplier()
      oldSupId = Me.m_entity.Supplier.Id
      Me.m_entity.ItemCollection.Clear()
      RefreshDocs()
      UpdateAmount()
      supplierCodeChanged = False
      Me.m_entity.CreditPeriod = Me.m_entity.Supplier.CreditPeriod
      Me.txtCreditPeriod.Text = Configuration.FormatToString(Me.m_entity.CreditPeriod, DigitConfig.Int)
      Me.txtDueDate.Text = MinDateToNull(Me.m_entity.DueDate, "")
      Me.dtpDueDate.Value = MinDateToNow(Me.m_entity.DueDate)
      txtCreditPeriodChanged = False
    End Sub
    Private Sub UpdateAmount()
      m_isInitialized = False
      txtGross.Text = Configuration.FormatToString(m_entity.Gross, DigitConfig.Price)
      Me.txtItemCount.Text = Configuration.FormatToString(m_entity.ItemCount, DigitConfig.Int)
      Me.txtRemaining.Text = Configuration.FormatToString(m_entity.RemainingAmount, DigitConfig.Price)
      Me.txtRetention.Text = Configuration.FormatToString(m_entity.ItemCollection.GetRetentionDeducted, DigitConfig.Price)
      Me.txtPlusRetention.Text = Configuration.FormatToString(m_entity.ItemCollection.GetPlusRetention, DigitConfig.Price)
      m_isInitialized = True
    End Sub
    Public Sub SetStatus()
      If m_entity.Canceled Then
        Me.StatusBarService.SetMessage("ยกเลิก: " & m_entity.CancelDate.ToShortDateString & _
        " " & m_entity.CancelDate.ToShortTimeString & _
        "  โดย:" & m_entity.CancelPerson.Name)
      ElseIf m_entity.Edited Then
        Me.StatusBarService.SetMessage("แก้ไขล่าสุด: " & m_entity.LastEditDate.ToShortDateString & _
        " " & m_entity.LastEditDate.ToShortTimeString & _
        "  โดย:" & m_entity.LastEditor.Name)
      ElseIf m_entity.Originated Then
        Me.StatusBarService.SetMessage("เพิ่มเข้าสู่ระบบ: " & m_entity.OriginDate.ToShortDateString & _
        " " & m_entity.OriginDate.ToShortTimeString & _
        "  โดย:" & m_entity.Originator.Name)
      Else
        Me.StatusBarService.SetMessage("")
      End If
    End Sub
    Public Overrides Property Entity() As ISimpleEntity
      Get
        Return Me.m_entity
      End Get
      Set(ByVal Value As ISimpleEntity)
        If Not m_entity Is Nothing Then
          RemoveHandler Me.m_entity.PropertyChanged, AddressOf PropChanged
          Me.m_entity = Nothing
        End If
        Me.m_entity = CType(Value, BillAcceptance)
        'Hack:
        If Not m_entity Is Nothing Then
          Me.m_entity.OnTabPageTextChanged(m_entity, EventArgs.Empty)
        End If
        UpdateEntityProperties()
      End Set
    End Property

    Public Overrides Sub Initialize()
      'PopulateRequestor()
      'PopulateCostCenter()
    End Sub


#End Region

#Region "Event Handlers"
    Private Sub chkAutorun_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkAutorun.CheckedChanged
      UpdateAutogenStatus()
    End Sub
    Private m_oldCode As String = ""
    Private Sub UpdateAutogenStatus()
      If Me.chkAutorun.Checked Then
        Me.Validator.SetRequired(Me.txtCode, False)
        Me.ErrorProvider1.SetError(Me.txtCode, "")
        Me.txtCode.ReadOnly = True
        m_oldCode = Me.txtCode.Text
        Me.txtCode.Text = BusinessLogic.Entity.GetAutoCodeFormat(Me.m_entity.EntityId)
        'Hack: set Code เป็น "" เอง
        Me.m_entity.Code = ""
        Me.m_entity.AutoGen = True
      Else
        Me.Validator.SetRequired(Me.txtCode, True)
        Me.txtCode.Text = m_oldCode
        Me.txtCode.ReadOnly = False
        Me.m_entity.AutoGen = False
      End If
    End Sub
    Public Sub ItemButtonClick(ByVal e As ButtonColumnEventArgs)
      Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
      If Me.m_entity Is Nothing Then
        Return
      End If
      If Me.m_entity.Supplier Is Nothing OrElse Not Me.m_entity.Supplier.Originated Then
        msgServ.ShowMessage("${res:Global.Error.SpecifySupplier}")
        Return
      End If
      Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      Dim filterEntities(5) As ArrayList
      For i As Integer = 0 To 5
        filterEntities(i) = New ArrayList
        filterEntities(i).Add(Me.m_entity.Supplier)
      Next
      Dim filters(5)() As Filter
      Dim grNeedsApproval As Boolean = False
      grNeedsApproval = CBool(Configuration.GetConfig("ApproveDO"))

      Dim notRefedByBilla As Boolean = False
      notRefedByBilla = CBool(Configuration.GetConfig("GRCannotBeRefedByBillaTwice"))

      filters(0) = New Filter() {New Filter("IDList", GetItemIDList(45)) _
      , New Filter("grNeedsApproval", grNeedsApproval) _
      , New Filter("notRefedByBilla", notRefedByBilla)}
      filters(1) = New Filter() {New Filter("IDList", GetItemIDList(15))}
      filters(2) = New Filter() {New Filter("IDList", GetItemIDList(50))}
      filters(3) = New Filter() {New Filter("IDList", GetItemIDList(46))}
      filters(4) = New Filter() {New Filter("IDList", GetItemIDList(199)) _
      , New Filter("grNeedsApproval", grNeedsApproval)}

      'filters(5) = New Filter() {New Filter("IDList", GetItemIDList(292)), _
      'New Filter("remainMustValid", True), New Filter("nocancel", True) _
      ', New Filter("grNeedsApproval", grNeedsApproval)}

      filters(5) = New Filter() {New Filter("IDList", GetItemIDList(292)) _
                               , New Filter("notRefedByBilla", notRefedByBilla)}
      'New Filter("remainMustValid", True)}

      Dim entities(5) As ISimpleEntity
      entities(0) = New GoodsReceiptForBillAcceptance
      entities(1) = New APOpeningBalanceForBillAcceptance
      entities(2) = New EqMaintenanceForBillAcceptance
      entities(3) = New PurchaseCNForBillAcceptance
      entities(4) = New PurchaseRetentionForBillAcceptance
      entities(5) = New PAForBillAcceptance
      myEntityPanelService.OpenListDialog(entities, AddressOf SetItems, filters, filterEntities, 0)
    End Sub
    Private Function GetItemIDList(ByVal type As Integer) As String
      Dim ret As String = ""
      For Each item As BillAcceptanceItem In Me.m_entity.ItemCollection
        If item.Originated AndAlso item.EntityId = type Then
          ret &= item.Id.ToString & ","
        End If
      Next
      If ret.EndsWith(",") Then
        ret = ret.Substring(0, ret.Length - 1)
      End If
      Return ret
    End Function
    Private Sub SetItems(ByVal items As BasketItemCollection)
      If items.Count = 0 Then
        Return
      End If
      Me.WorkbenchWindow.ViewContent.IsDirty = True
      Dim index As Integer = tgItem.CurrentRowIndex
      Dim insertIndex As Integer
      Dim j As Integer = items.Count
      For i As Integer = items.Count - 1 To 0 Step -1

        Dim item As BasketItem = CType(items(i), BasketItem)
        Dim newItem As BillAcceptanceItem
        If TypeOf item.Tag Is DataRow Then
          'If item.FullClassName.ToLower = "longkong.pojjaman.businesslogic.pa" Then
          '  newItem = New BillAcceptanceItem(CType(item.Tag, DataRow), "", Me.m_entity)
          '  'newItem = New BillAcceptanceItem(New PA(item.Id), Me.m_entity)
          'Else
            newItem = New BillAcceptanceItem(CType(item.Tag, DataRow), "", Me.m_entity)
            'End If
        Else
          Select Case item.FullClassName.ToLower
            Case "longkong.pojjaman.businesslogic.goodsreceipt"
              newItem = New BillAcceptanceItem(New GoodsReceipt(item.Id), Me.m_entity)
              'Case "longkong.pojjaman.businesslogic.goodsreceipt"
              '  newItem = New BillAcceptanceItem(New GoodsReceipt(item.Id), Me.m_entity)
          End Select
        End If
        newItem.Amount = newItem.UnpaidAmount
        If i = items.Count - 1 Then
          'ตัวแรก -- update old item
          If Me.m_entity.ItemCollection.Count = 0 Then
            Me.m_entity.ItemCollection.Add(newItem)
          Else
            Dim theDoc As BillAcceptanceItem = Me.CurrentItem
            If Me.CurrentItem Is Nothing Then
              If index > Me.m_entity.ItemCollection.Count - 1 Then
                Me.m_entity.ItemCollection.Add(newItem)
                theDoc = newItem
                insertIndex = Me.m_entity.ItemCollection.IndexOf(newItem)
              Else
                Me.m_entity.ItemCollection.Insert(insertIndex, newItem)
                theDoc = Me.m_entity.ItemCollection(insertIndex)
              End If
            End If

            theDoc.Id = newItem.Id
            theDoc.Code = newItem.Code
            '------------------------------------------------------------>>>>>>>>>>>>


            theDoc.AfterTax = newItem.RealAmount


            theDoc.Amount = newItem.Amount

            theDoc.UnpaidAmount = newItem.UnpaidAmount
            theDoc.SetType(newItem.EntityId)
            theDoc.CreditPeriod = newItem.CreditPeriod
            theDoc.Date = newItem.Date
            'MessageBox.Show(newItem.Date)
            theDoc.BeforeTax = newItem.BeforeTax

            theDoc.TaxBase = newItem.TaxBase
            theDoc.RetentionType = newItem.RetentionType
          End If
        Else
          Me.m_entity.ItemCollection.Insert(insertIndex, newItem)
        End If
      Next
      RefreshDocs()
      tgItem.CurrentRowIndex = index
      UpdateAmount()
    End Sub
    Private Sub ibtnBlank_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnBlank.Click
      Dim index As Integer = tgItem.CurrentRowIndex
      If index > Me.m_entity.ItemCollection.Count - 1 Then
        Return
      End If
      Me.m_entity.ItemCollection.Insert(index, New BillAcceptanceItem)
      RefreshDocs()
      tgItem.CurrentRowIndex = index
      Dim re As New DataColumnChangeEventArgs(Me.m_treeManager.Treetable.Rows(index) _
  , Me.m_treeManager.Treetable.Columns("billai_amt") _
  , Me.CurrentItem.Amount)
      Me.ValidateRow(re)
      Me.WorkbenchWindow.ViewContent.IsDirty = True
    End Sub
    Private Sub ibtnDelRow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnDelRow.Click
      Dim index As Integer = Me.tgItem.CurrentRowIndex
      Dim row As TreeRow = Me.m_treeManager.SelectedRow
      If row Is Nothing Then
        Return
      End If
      Dim doc As BillAcceptanceItem = Me.CurrentItem
      If doc Is Nothing Then
        Return
      End If
      Me.WorkbenchWindow.ViewContent.IsDirty = True
      Me.m_entity.ItemCollection.Remove(doc)
      RefreshDocs()
      Me.tgItem.CurrentRowIndex = index
    End Sub
    Private Sub ReIndex()
      Dim i As Integer = 0
      For Each row As DataRow In Me.m_treeManager.Treetable.Rows
        row("billai_linenumber") = i + 1
        i += 1
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
    Public Overrides Sub NotifyBeforeSave()

    End Sub
    'Public Overrides Sub NotifyAfterSave(ByVal successful As Boolean)
    '    If Not successful Then
    '        Return
    '    End If
    '    Me.Entity = New PR(Me.Entity.Id)
    '    Dim listPanel As ISimpleListPanel = CType(Me.WorkbenchWindow.ViewContent, ISimpleListPanel)
    '    listPanel.SelectedEntity = Me.Entity
    'End Sub
    Public Overrides ReadOnly Property TabPageIcon() As String
      Get
        Return (New PR).DetailPanelIcon
      End Get
    End Property
#End Region

#Region "Event of Button controls"
    Private Sub btnSupplier_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnShowSupplier.Click
      Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      myEntityPanelService.OpenPanel(New Supplier)
    End Sub
    Private Sub btnSupplierDialog_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnShowSupplierDialog.Click
      Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
      Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      myEntityPanelService.OpenListDialog(New Supplier, AddressOf SetSupplier)
    End Sub
    Private Sub SetSupplier(ByVal e As ISimpleEntity)
      Me.txtSupplierCode.Text = e.Code
      Me.ChangeProperty(txtSupplierCode, Nothing)
    End Sub
#End Region

#Region "IClipboardHandler Overrides"
    Public Overrides ReadOnly Property EnablePaste() As Boolean
      Get
        Dim data As IDataObject = Clipboard.GetDataObject
        If data.GetDataPresent((New Supplier).FullClassName) Then
          If Not Me.ActiveControl Is Nothing Then
            Select Case Me.ActiveControl.Name.ToLower
              Case "txtsuppliercode", "txtsuppliername"
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
            Case "txtsuppliercode", "txtsuppliername"
              Me.SetSupplier(entity)
          End Select
        End If
      End If
    End Sub
#End Region

#Region "Grid Resizing"
    Private Sub tgItem_Resize(ByVal sender As System.Object, ByVal e As System.EventArgs)
      If Me.m_entity Is Nothing Then
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
      Dim maxVisibleCount As Integer
      Dim tgRowHeight As Integer = 17
      maxVisibleCount = CInt(Math.Floor((Me.tgItem.Height - tgRowHeight) / tgRowHeight))
      Do While Me.m_treeManager.Treetable.Rows.Count < maxVisibleCount - 1
        'เพิ่มแถวจนเต็ม
        Me.m_treeManager.Treetable.Childs.Add()
      Loop
      'If Me.m_entity.MaxRowIndex = maxVisibleCount - 2 Then
      '    If Me.m_treeManager.Treetable.Rows.Count < maxVisibleCount - 1 Then
      '        'เพิ่มอีก 1 แถว ถ้ามีข้อมูลจนถึงแถวสุดท้าย
      '        Me.m_treeManager.Treetable.Childs.Add()
      '    End If
      'End If
      Me.m_treeManager.Treetable.AcceptChanges()
      tgItem.CurrentRowIndex = Math.Max(0, index)
      Me.WorkbenchWindow.ViewContent.IsDirty = dirtyFlag
    End Sub
#End Region

    Private Sub lblRetention_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblRetention.Click

    End Sub
  End Class
End Namespace