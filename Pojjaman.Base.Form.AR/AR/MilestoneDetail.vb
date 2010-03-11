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
    Public Class MilestoneDetail
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
        Friend WithEvents lblProject As System.Windows.Forms.Label
        Friend WithEvents txtProjectCode As System.Windows.Forms.TextBox
        Friend WithEvents lblCustomer As System.Windows.Forms.Label
        Friend WithEvents lblDiscountAmount As System.Windows.Forms.Label
        Friend WithEvents txtDiscountAmount As System.Windows.Forms.TextBox
        Friend WithEvents lblBeforeTax As System.Windows.Forms.Label
        Friend WithEvents txtBeforeTax As System.Windows.Forms.TextBox
        Friend WithEvents txtTaxAmount As System.Windows.Forms.TextBox
        Friend WithEvents txtAfterTax As System.Windows.Forms.TextBox
        Friend WithEvents txtDiscountRate As System.Windows.Forms.TextBox
        Friend WithEvents cmbTaxType As System.Windows.Forms.ComboBox
        Friend WithEvents lblTaxType As System.Windows.Forms.Label
        Friend WithEvents txtTaxRate As System.Windows.Forms.TextBox
        Friend WithEvents lblTaxRate As System.Windows.Forms.Label
        Friend WithEvents txtTaxBase As System.Windows.Forms.TextBox
        Friend WithEvents lblTaxBase As System.Windows.Forms.Label
    Friend WithEvents lblAmount As System.Windows.Forms.Label
    Friend WithEvents tgItem As Longkong.Pojjaman.Gui.Components.TreeGrid
    Friend WithEvents lblItem As System.Windows.Forms.Label
    Friend WithEvents grbMilestone As Longkong.Pojjaman.Gui.Components.FixedGroupBox
    Friend WithEvents txtProjectName As System.Windows.Forms.TextBox
    Friend WithEvents txtCustomerCode As System.Windows.Forms.TextBox
    Friend WithEvents txtCustomerName As System.Windows.Forms.TextBox
    Friend WithEvents txtCode As System.Windows.Forms.TextBox
    Friend WithEvents txtName As System.Windows.Forms.TextBox
    Friend WithEvents lblName As System.Windows.Forms.Label
    Friend WithEvents lblGross As System.Windows.Forms.Label
    Friend WithEvents txtAdvance As System.Windows.Forms.TextBox
    Friend WithEvents lblAdvance As System.Windows.Forms.Label
    Friend WithEvents lblRetention As System.Windows.Forms.Label
    Friend WithEvents txtRetention As System.Windows.Forms.TextBox
    Friend WithEvents lblTax As System.Windows.Forms.Label
    Friend WithEvents txtAdvrRetention As System.Windows.Forms.TextBox
    Friend WithEvents lblCode As System.Windows.Forms.Label
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents Validator As Longkong.Pojjaman.Gui.Components.PJMTextboxValidator
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents lblNote As System.Windows.Forms.Label
    Friend WithEvents txtNote As System.Windows.Forms.TextBox
    Friend WithEvents ibtnBlank As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents ibtnDelRow As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents txtMilestoneAmount As System.Windows.Forms.TextBox
    Friend WithEvents txtGross As System.Windows.Forms.TextBox
    Friend WithEvents lblMilestoneAmount As System.Windows.Forms.Label
    Friend WithEvents cmbType As System.Windows.Forms.ComboBox
    Friend WithEvents txtPenalty As System.Windows.Forms.TextBox
    Friend WithEvents lblPenalty As System.Windows.Forms.Label
    Friend WithEvents txtDocDate As System.Windows.Forms.TextBox
    Friend WithEvents dtpDocDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblDocDate As System.Windows.Forms.Label
    Friend WithEvents txtHandedDate As System.Windows.Forms.TextBox
    Friend WithEvents dtpHandedDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblHandedDate As System.Windows.Forms.Label
    Friend WithEvents ibtnPrint As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents ibtnPrintPreview As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents ibtnResetGross As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents txtRealTaxBase As System.Windows.Forms.TextBox
    Friend WithEvents ibtnResetTaxBase As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents txtRealTaxAmount As System.Windows.Forms.TextBox
    Friend WithEvents ibtnResetTaxAmount As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents lblAftertax As System.Windows.Forms.Label
    Friend WithEvents txtAmount As System.Windows.Forms.TextBox
    Friend WithEvents txtRealMilestoneAmount As System.Windows.Forms.TextBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
      Me.components = New System.ComponentModel.Container()
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MilestoneDetail))
      Me.lblProject = New System.Windows.Forms.Label()
      Me.txtProjectCode = New System.Windows.Forms.TextBox()
      Me.txtProjectName = New System.Windows.Forms.TextBox()
      Me.txtCustomerCode = New System.Windows.Forms.TextBox()
      Me.lblCustomer = New System.Windows.Forms.Label()
      Me.txtCustomerName = New System.Windows.Forms.TextBox()
      Me.grbMilestone = New Longkong.Pojjaman.Gui.Components.FixedGroupBox()
      Me.txtHandedDate = New System.Windows.Forms.TextBox()
      Me.dtpHandedDate = New System.Windows.Forms.DateTimePicker()
      Me.lblHandedDate = New System.Windows.Forms.Label()
      Me.txtDocDate = New System.Windows.Forms.TextBox()
      Me.dtpDocDate = New System.Windows.Forms.DateTimePicker()
      Me.lblDocDate = New System.Windows.Forms.Label()
      Me.lblCode = New System.Windows.Forms.Label()
      Me.txtCode = New System.Windows.Forms.TextBox()
      Me.txtName = New System.Windows.Forms.TextBox()
      Me.lblName = New System.Windows.Forms.Label()
      Me.cmbType = New System.Windows.Forms.ComboBox()
      Me.txtMilestoneAmount = New System.Windows.Forms.TextBox()
      Me.lblGross = New System.Windows.Forms.Label()
      Me.txtAdvance = New System.Windows.Forms.TextBox()
      Me.lblAdvance = New System.Windows.Forms.Label()
      Me.lblRetention = New System.Windows.Forms.Label()
      Me.txtRetention = New System.Windows.Forms.TextBox()
      Me.lblDiscountAmount = New System.Windows.Forms.Label()
      Me.txtDiscountAmount = New System.Windows.Forms.TextBox()
      Me.lblBeforeTax = New System.Windows.Forms.Label()
      Me.txtBeforeTax = New System.Windows.Forms.TextBox()
      Me.lblTax = New System.Windows.Forms.Label()
      Me.txtTaxAmount = New System.Windows.Forms.TextBox()
      Me.txtAfterTax = New System.Windows.Forms.TextBox()
      Me.txtDiscountRate = New System.Windows.Forms.TextBox()
      Me.cmbTaxType = New System.Windows.Forms.ComboBox()
      Me.lblTaxType = New System.Windows.Forms.Label()
      Me.txtTaxRate = New System.Windows.Forms.TextBox()
      Me.lblTaxRate = New System.Windows.Forms.Label()
      Me.txtTaxBase = New System.Windows.Forms.TextBox()
      Me.lblTaxBase = New System.Windows.Forms.Label()
      Me.lblAmount = New System.Windows.Forms.Label()
      Me.tgItem = New Longkong.Pojjaman.Gui.Components.TreeGrid()
      Me.lblItem = New System.Windows.Forms.Label()
      Me.txtAdvrRetention = New System.Windows.Forms.TextBox()
      Me.ToolTip1 = New System.Windows.Forms.ToolTip()
      Me.ibtnBlank = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.ibtnDelRow = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.ibtnPrint = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.ibtnPrintPreview = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.Validator = New Longkong.Pojjaman.Gui.Components.PJMTextboxValidator()
      Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider()
      Me.txtNote = New System.Windows.Forms.TextBox()
      Me.txtGross = New System.Windows.Forms.TextBox()
      Me.txtPenalty = New System.Windows.Forms.TextBox()
      Me.txtRealMilestoneAmount = New System.Windows.Forms.TextBox()
      Me.txtRealTaxBase = New System.Windows.Forms.TextBox()
      Me.txtRealTaxAmount = New System.Windows.Forms.TextBox()
      Me.txtAmount = New System.Windows.Forms.TextBox()
      Me.lblNote = New System.Windows.Forms.Label()
      Me.lblMilestoneAmount = New System.Windows.Forms.Label()
      Me.lblPenalty = New System.Windows.Forms.Label()
      Me.ibtnResetGross = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.ibtnResetTaxBase = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.ibtnResetTaxAmount = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.lblAftertax = New System.Windows.Forms.Label()
      Me.grbMilestone.SuspendLayout()
      Me.SuspendLayout()
      '
      'lblProject
      '
      Me.lblProject.BackColor = System.Drawing.Color.Transparent
      Me.lblProject.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblProject.Location = New System.Drawing.Point(8, 65)
      Me.lblProject.Name = "lblProject"
      Me.lblProject.Size = New System.Drawing.Size(88, 18)
      Me.lblProject.TabIndex = 11
      Me.lblProject.Text = "โครงการ:"
      Me.lblProject.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'txtProjectCode
      '
      Me.txtProjectCode.BackColor = System.Drawing.SystemColors.Control
      Me.Validator.SetDataType(Me.txtProjectCode, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtProjectCode, "")
      Me.Validator.SetGotFocusBackColor(Me.txtProjectCode, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtProjectCode, System.Drawing.Color.Empty)
      Me.txtProjectCode.Location = New System.Drawing.Point(96, 64)
      Me.Validator.SetMinValue(Me.txtProjectCode, "")
      Me.txtProjectCode.Name = "txtProjectCode"
      Me.txtProjectCode.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtProjectCode, "")
      Me.Validator.SetRequired(Me.txtProjectCode, False)
      Me.txtProjectCode.Size = New System.Drawing.Size(88, 20)
      Me.txtProjectCode.TabIndex = 12
      Me.txtProjectCode.TabStop = False
      '
      'txtProjectName
      '
      Me.txtProjectName.BackColor = System.Drawing.SystemColors.Control
      Me.Validator.SetDataType(Me.txtProjectName, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtProjectName, "")
      Me.Validator.SetGotFocusBackColor(Me.txtProjectName, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtProjectName, System.Drawing.Color.Empty)
      Me.txtProjectName.Location = New System.Drawing.Point(184, 64)
      Me.Validator.SetMinValue(Me.txtProjectName, "")
      Me.txtProjectName.Name = "txtProjectName"
      Me.txtProjectName.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtProjectName, "")
      Me.Validator.SetRequired(Me.txtProjectName, False)
      Me.txtProjectName.Size = New System.Drawing.Size(424, 20)
      Me.txtProjectName.TabIndex = 13
      Me.txtProjectName.TabStop = False
      '
      'txtCustomerCode
      '
      Me.txtCustomerCode.BackColor = System.Drawing.SystemColors.Control
      Me.Validator.SetDataType(Me.txtCustomerCode, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtCustomerCode, "")
      Me.Validator.SetGotFocusBackColor(Me.txtCustomerCode, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtCustomerCode, System.Drawing.Color.Empty)
      Me.txtCustomerCode.Location = New System.Drawing.Point(96, 84)
      Me.Validator.SetMinValue(Me.txtCustomerCode, "")
      Me.txtCustomerCode.Name = "txtCustomerCode"
      Me.txtCustomerCode.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtCustomerCode, "")
      Me.Validator.SetRequired(Me.txtCustomerCode, False)
      Me.txtCustomerCode.Size = New System.Drawing.Size(88, 20)
      Me.txtCustomerCode.TabIndex = 15
      Me.txtCustomerCode.TabStop = False
      '
      'lblCustomer
      '
      Me.lblCustomer.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblCustomer.Location = New System.Drawing.Point(16, 85)
      Me.lblCustomer.Name = "lblCustomer"
      Me.lblCustomer.Size = New System.Drawing.Size(80, 18)
      Me.lblCustomer.TabIndex = 14
      Me.lblCustomer.Text = "ลูกค้า:"
      Me.lblCustomer.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'txtCustomerName
      '
      Me.txtCustomerName.BackColor = System.Drawing.SystemColors.Control
      Me.Validator.SetDataType(Me.txtCustomerName, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtCustomerName, "")
      Me.Validator.SetGotFocusBackColor(Me.txtCustomerName, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtCustomerName, System.Drawing.Color.Empty)
      Me.txtCustomerName.Location = New System.Drawing.Point(184, 84)
      Me.Validator.SetMinValue(Me.txtCustomerName, "")
      Me.txtCustomerName.Name = "txtCustomerName"
      Me.txtCustomerName.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtCustomerName, "")
      Me.Validator.SetRequired(Me.txtCustomerName, False)
      Me.txtCustomerName.Size = New System.Drawing.Size(424, 20)
      Me.txtCustomerName.TabIndex = 16
      Me.txtCustomerName.TabStop = False
      '
      'grbMilestone
      '
      Me.grbMilestone.Controls.Add(Me.txtHandedDate)
      Me.grbMilestone.Controls.Add(Me.dtpHandedDate)
      Me.grbMilestone.Controls.Add(Me.lblHandedDate)
      Me.grbMilestone.Controls.Add(Me.txtDocDate)
      Me.grbMilestone.Controls.Add(Me.dtpDocDate)
      Me.grbMilestone.Controls.Add(Me.lblDocDate)
      Me.grbMilestone.Controls.Add(Me.txtProjectCode)
      Me.grbMilestone.Controls.Add(Me.txtCustomerName)
      Me.grbMilestone.Controls.Add(Me.txtProjectName)
      Me.grbMilestone.Controls.Add(Me.lblProject)
      Me.grbMilestone.Controls.Add(Me.txtCustomerCode)
      Me.grbMilestone.Controls.Add(Me.lblCustomer)
      Me.grbMilestone.Controls.Add(Me.lblCode)
      Me.grbMilestone.Controls.Add(Me.txtCode)
      Me.grbMilestone.Controls.Add(Me.txtName)
      Me.grbMilestone.Controls.Add(Me.lblName)
      Me.grbMilestone.Controls.Add(Me.cmbType)
      Me.grbMilestone.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.grbMilestone.Location = New System.Drawing.Point(8, 8)
      Me.grbMilestone.Name = "grbMilestone"
      Me.grbMilestone.Size = New System.Drawing.Size(640, 112)
      Me.grbMilestone.TabIndex = 0
      Me.grbMilestone.TabStop = False
      Me.grbMilestone.Text = "งวดงาน"
      '
      'txtHandedDate
      '
      Me.txtHandedDate.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.txtHandedDate.BackColor = System.Drawing.SystemColors.Window
      Me.Validator.SetDataType(Me.txtHandedDate, Longkong.Pojjaman.Gui.Components.DataTypeConstants.DateTimeType)
      Me.Validator.SetDisplayName(Me.txtHandedDate, "")
      Me.txtHandedDate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtHandedDate, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtHandedDate, System.Drawing.Color.Empty)
      Me.txtHandedDate.Location = New System.Drawing.Point(288, 40)
      Me.Validator.SetMinValue(Me.txtHandedDate, "")
      Me.txtHandedDate.Name = "txtHandedDate"
      Me.Validator.SetRegularExpression(Me.txtHandedDate, "")
      Me.Validator.SetRequired(Me.txtHandedDate, False)
      Me.txtHandedDate.Size = New System.Drawing.Size(86, 21)
      Me.txtHandedDate.TabIndex = 4
      '
      'dtpHandedDate
      '
      Me.dtpHandedDate.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.dtpHandedDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
      Me.dtpHandedDate.Location = New System.Drawing.Point(288, 40)
      Me.dtpHandedDate.Name = "dtpHandedDate"
      Me.dtpHandedDate.Size = New System.Drawing.Size(104, 20)
      Me.dtpHandedDate.TabIndex = 10
      Me.dtpHandedDate.TabStop = False
      '
      'lblHandedDate
      '
      Me.lblHandedDate.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.lblHandedDate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblHandedDate.Location = New System.Drawing.Point(200, 40)
      Me.lblHandedDate.Name = "lblHandedDate"
      Me.lblHandedDate.Size = New System.Drawing.Size(88, 18)
      Me.lblHandedDate.TabIndex = 9
      Me.lblHandedDate.Text = "วันที่ส่งงาน:"
      Me.lblHandedDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'txtDocDate
      '
      Me.txtDocDate.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.txtDocDate.BackColor = System.Drawing.SystemColors.Window
      Me.Validator.SetDataType(Me.txtDocDate, Longkong.Pojjaman.Gui.Components.DataTypeConstants.DateTimeType)
      Me.Validator.SetDisplayName(Me.txtDocDate, "")
      Me.txtDocDate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtDocDate, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtDocDate, System.Drawing.Color.Empty)
      Me.txtDocDate.Location = New System.Drawing.Point(96, 40)
      Me.Validator.SetMinValue(Me.txtDocDate, "")
      Me.txtDocDate.Name = "txtDocDate"
      Me.Validator.SetRegularExpression(Me.txtDocDate, "")
      Me.Validator.SetRequired(Me.txtDocDate, True)
      Me.txtDocDate.Size = New System.Drawing.Size(86, 21)
      Me.txtDocDate.TabIndex = 3
      '
      'dtpDocDate
      '
      Me.dtpDocDate.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.dtpDocDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
      Me.dtpDocDate.Location = New System.Drawing.Point(96, 40)
      Me.dtpDocDate.Name = "dtpDocDate"
      Me.dtpDocDate.Size = New System.Drawing.Size(104, 20)
      Me.dtpDocDate.TabIndex = 8
      Me.dtpDocDate.TabStop = False
      '
      'lblDocDate
      '
      Me.lblDocDate.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.lblDocDate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblDocDate.Location = New System.Drawing.Point(16, 40)
      Me.lblDocDate.Name = "lblDocDate"
      Me.lblDocDate.Size = New System.Drawing.Size(80, 18)
      Me.lblDocDate.TabIndex = 7
      Me.lblDocDate.Text = "วันที่เอกสาร:"
      Me.lblDocDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblCode
      '
      Me.lblCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblCode.Location = New System.Drawing.Point(24, 16)
      Me.lblCode.Name = "lblCode"
      Me.lblCode.Size = New System.Drawing.Size(72, 18)
      Me.lblCode.TabIndex = 5
      Me.lblCode.Text = "รหัสงวดงาน:"
      Me.lblCode.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'txtCode
      '
      Me.txtCode.BackColor = System.Drawing.SystemColors.Window
      Me.Validator.SetDataType(Me.txtCode, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtCode, "")
      Me.Validator.SetGotFocusBackColor(Me.txtCode, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtCode, System.Drawing.Color.Empty)
      Me.txtCode.Location = New System.Drawing.Point(96, 16)
      Me.Validator.SetMinValue(Me.txtCode, "")
      Me.txtCode.Name = "txtCode"
      Me.Validator.SetRegularExpression(Me.txtCode, "")
      Me.Validator.SetRequired(Me.txtCode, True)
      Me.txtCode.Size = New System.Drawing.Size(88, 20)
      Me.txtCode.TabIndex = 0
      '
      'txtName
      '
      Me.txtName.BackColor = System.Drawing.SystemColors.Window
      Me.Validator.SetDataType(Me.txtName, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtName, "")
      Me.Validator.SetGotFocusBackColor(Me.txtName, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtName, System.Drawing.Color.Empty)
      Me.txtName.Location = New System.Drawing.Point(224, 16)
      Me.Validator.SetMinValue(Me.txtName, "")
      Me.txtName.Name = "txtName"
      Me.Validator.SetRegularExpression(Me.txtName, "")
      Me.Validator.SetRequired(Me.txtName, True)
      Me.txtName.Size = New System.Drawing.Size(320, 20)
      Me.txtName.TabIndex = 1
      '
      'lblName
      '
      Me.lblName.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblName.Location = New System.Drawing.Point(192, 17)
      Me.lblName.Name = "lblName"
      Me.lblName.Size = New System.Drawing.Size(32, 18)
      Me.lblName.TabIndex = 6
      Me.lblName.Text = "ชื่อ:"
      Me.lblName.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'cmbType
      '
      Me.cmbType.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.cmbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbType.Enabled = False
      Me.cmbType.Location = New System.Drawing.Point(544, 16)
      Me.cmbType.Name = "cmbType"
      Me.cmbType.Size = New System.Drawing.Size(64, 21)
      Me.cmbType.TabIndex = 2
      '
      'txtMilestoneAmount
      '
      Me.txtMilestoneAmount.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.txtMilestoneAmount.BackColor = System.Drawing.SystemColors.Control
      Me.Validator.SetDataType(Me.txtMilestoneAmount, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtMilestoneAmount, "")
      Me.Validator.SetGotFocusBackColor(Me.txtMilestoneAmount, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtMilestoneAmount, System.Drawing.Color.Empty)
      Me.txtMilestoneAmount.Location = New System.Drawing.Point(190, 383)
      Me.Validator.SetMinValue(Me.txtMilestoneAmount, "")
      Me.txtMilestoneAmount.Name = "txtMilestoneAmount"
      Me.txtMilestoneAmount.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtMilestoneAmount, "")
      Me.Validator.SetRequired(Me.txtMilestoneAmount, True)
      Me.txtMilestoneAmount.Size = New System.Drawing.Size(80, 20)
      Me.txtMilestoneAmount.TabIndex = 3
      Me.txtMilestoneAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'lblGross
      '
      Me.lblGross.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.lblGross.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblGross.Location = New System.Drawing.Point(464, 129)
      Me.lblGross.Name = "lblGross"
      Me.lblGross.Size = New System.Drawing.Size(88, 18)
      Me.lblGross.TabIndex = 11
      Me.lblGross.Text = "มูลค่าเงินงวด:"
      Me.lblGross.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'txtAdvance
      '
      Me.txtAdvance.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.txtAdvance.BackColor = System.Drawing.SystemColors.Window
      Me.Validator.SetDataType(Me.txtAdvance, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtAdvance, "")
      Me.Validator.SetGotFocusBackColor(Me.txtAdvance, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtAdvance, System.Drawing.Color.Empty)
      Me.txtAdvance.Location = New System.Drawing.Point(190, 404)
      Me.Validator.SetMinValue(Me.txtAdvance, "")
      Me.txtAdvance.Name = "txtAdvance"
      Me.Validator.SetRegularExpression(Me.txtAdvance, "")
      Me.Validator.SetRequired(Me.txtAdvance, False)
      Me.txtAdvance.Size = New System.Drawing.Size(184, 20)
      Me.txtAdvance.TabIndex = 4
      Me.txtAdvance.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'lblAdvance
      '
      Me.lblAdvance.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.lblAdvance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblAdvance.Location = New System.Drawing.Point(102, 406)
      Me.lblAdvance.Name = "lblAdvance"
      Me.lblAdvance.Size = New System.Drawing.Size(88, 18)
      Me.lblAdvance.TabIndex = 15
      Me.lblAdvance.Text = "หักAdv.Payment:"
      Me.lblAdvance.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblRetention
      '
      Me.lblRetention.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.lblRetention.BackColor = System.Drawing.Color.Transparent
      Me.lblRetention.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblRetention.Location = New System.Drawing.Point(415, 406)
      Me.lblRetention.Name = "lblRetention"
      Me.lblRetention.Size = New System.Drawing.Size(80, 18)
      Me.lblRetention.TabIndex = 17
      Me.lblRetention.Text = "หักRetention:"
      Me.lblRetention.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'txtRetention
      '
      Me.txtRetention.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.txtRetention.BackColor = System.Drawing.SystemColors.Window
      Me.Validator.SetDataType(Me.txtRetention, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtRetention, "")
      Me.Validator.SetGotFocusBackColor(Me.txtRetention, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtRetention, System.Drawing.Color.Empty)
      Me.txtRetention.Location = New System.Drawing.Point(495, 405)
      Me.Validator.SetMinValue(Me.txtRetention, "")
      Me.txtRetention.Name = "txtRetention"
      Me.Validator.SetRegularExpression(Me.txtRetention, "")
      Me.Validator.SetRequired(Me.txtRetention, False)
      Me.txtRetention.Size = New System.Drawing.Size(185, 20)
      Me.txtRetention.TabIndex = 5
      Me.txtRetention.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'lblDiscountAmount
      '
      Me.lblDiscountAmount.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.lblDiscountAmount.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblDiscountAmount.Location = New System.Drawing.Point(142, 428)
      Me.lblDiscountAmount.Name = "lblDiscountAmount"
      Me.lblDiscountAmount.Size = New System.Drawing.Size(48, 18)
      Me.lblDiscountAmount.TabIndex = 18
      Me.lblDiscountAmount.Text = "ส่วนลด:"
      Me.lblDiscountAmount.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'txtDiscountAmount
      '
      Me.txtDiscountAmount.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.txtDiscountAmount.BackColor = System.Drawing.SystemColors.Control
      Me.Validator.SetDataType(Me.txtDiscountAmount, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtDiscountAmount, "")
      Me.Validator.SetGotFocusBackColor(Me.txtDiscountAmount, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtDiscountAmount, System.Drawing.Color.Empty)
      Me.txtDiscountAmount.Location = New System.Drawing.Point(281, 427)
      Me.Validator.SetMinValue(Me.txtDiscountAmount, "")
      Me.txtDiscountAmount.Name = "txtDiscountAmount"
      Me.txtDiscountAmount.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtDiscountAmount, "")
      Me.Validator.SetRequired(Me.txtDiscountAmount, False)
      Me.txtDiscountAmount.Size = New System.Drawing.Size(93, 20)
      Me.txtDiscountAmount.TabIndex = 20
      Me.txtDiscountAmount.TabStop = False
      Me.txtDiscountAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'lblBeforeTax
      '
      Me.lblBeforeTax.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.lblBeforeTax.BackColor = System.Drawing.Color.Transparent
      Me.lblBeforeTax.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblBeforeTax.Location = New System.Drawing.Point(376, 450)
      Me.lblBeforeTax.Name = "lblBeforeTax"
      Me.lblBeforeTax.Size = New System.Drawing.Size(120, 18)
      Me.lblBeforeTax.TabIndex = 22
      Me.lblBeforeTax.Text = "ยอดเงินไม่รวมภาษี:"
      Me.lblBeforeTax.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'txtBeforeTax
      '
      Me.txtBeforeTax.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.txtBeforeTax.BackColor = System.Drawing.SystemColors.Control
      Me.Validator.SetDataType(Me.txtBeforeTax, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtBeforeTax, "")
      Me.Validator.SetGotFocusBackColor(Me.txtBeforeTax, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtBeforeTax, System.Drawing.Color.Empty)
      Me.txtBeforeTax.Location = New System.Drawing.Point(496, 449)
      Me.Validator.SetMinValue(Me.txtBeforeTax, "")
      Me.txtBeforeTax.Name = "txtBeforeTax"
      Me.txtBeforeTax.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtBeforeTax, "")
      Me.Validator.SetRequired(Me.txtBeforeTax, False)
      Me.txtBeforeTax.Size = New System.Drawing.Size(184, 20)
      Me.txtBeforeTax.TabIndex = 23
      Me.txtBeforeTax.TabStop = False
      Me.txtBeforeTax.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'lblTax
      '
      Me.lblTax.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.lblTax.BackColor = System.Drawing.Color.Transparent
      Me.lblTax.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblTax.Location = New System.Drawing.Point(99, 490)
      Me.lblTax.Name = "lblTax"
      Me.lblTax.Size = New System.Drawing.Size(91, 18)
      Me.lblTax.TabIndex = 29
      Me.lblTax.Text = "ภาษี:"
      Me.lblTax.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'txtTaxAmount
      '
      Me.txtTaxAmount.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.txtTaxAmount.BackColor = System.Drawing.SystemColors.Control
      Me.Validator.SetDataType(Me.txtTaxAmount, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtTaxAmount, "")
      Me.Validator.SetGotFocusBackColor(Me.txtTaxAmount, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtTaxAmount, System.Drawing.Color.Empty)
      Me.txtTaxAmount.Location = New System.Drawing.Point(190, 491)
      Me.Validator.SetMinValue(Me.txtTaxAmount, "")
      Me.txtTaxAmount.Name = "txtTaxAmount"
      Me.txtTaxAmount.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtTaxAmount, "")
      Me.Validator.SetRequired(Me.txtTaxAmount, False)
      Me.txtTaxAmount.Size = New System.Drawing.Size(80, 20)
      Me.txtTaxAmount.TabIndex = 30
      Me.txtTaxAmount.TabStop = False
      Me.txtTaxAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'txtAfterTax
      '
      Me.txtAfterTax.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.txtAfterTax.BackColor = System.Drawing.SystemColors.Control
      Me.Validator.SetDataType(Me.txtAfterTax, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtAfterTax, "")
      Me.txtAfterTax.ForeColor = System.Drawing.Color.Blue
      Me.Validator.SetGotFocusBackColor(Me.txtAfterTax, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtAfterTax, System.Drawing.Color.Empty)
      Me.txtAfterTax.Location = New System.Drawing.Point(495, 383)
      Me.Validator.SetMinValue(Me.txtAfterTax, "")
      Me.txtAfterTax.Name = "txtAfterTax"
      Me.txtAfterTax.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtAfterTax, "")
      Me.Validator.SetRequired(Me.txtAfterTax, False)
      Me.txtAfterTax.Size = New System.Drawing.Size(185, 20)
      Me.txtAfterTax.TabIndex = 32
      Me.txtAfterTax.TabStop = False
      Me.txtAfterTax.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'txtDiscountRate
      '
      Me.txtDiscountRate.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.txtDiscountRate.BackColor = System.Drawing.SystemColors.Window
      Me.Validator.SetDataType(Me.txtDiscountRate, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtDiscountRate, "")
      Me.Validator.SetGotFocusBackColor(Me.txtDiscountRate, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtDiscountRate, System.Drawing.Color.Empty)
      Me.txtDiscountRate.Location = New System.Drawing.Point(190, 427)
      Me.Validator.SetMinValue(Me.txtDiscountRate, "")
      Me.txtDiscountRate.Name = "txtDiscountRate"
      Me.Validator.SetRegularExpression(Me.txtDiscountRate, "")
      Me.Validator.SetRequired(Me.txtDiscountRate, False)
      Me.txtDiscountRate.Size = New System.Drawing.Size(88, 20)
      Me.txtDiscountRate.TabIndex = 6
      Me.txtDiscountRate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'cmbTaxType
      '
      Me.cmbTaxType.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.cmbTaxType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbTaxType.Enabled = False
      Me.cmbTaxType.Location = New System.Drawing.Point(190, 449)
      Me.cmbTaxType.Name = "cmbTaxType"
      Me.cmbTaxType.Size = New System.Drawing.Size(64, 21)
      Me.cmbTaxType.TabIndex = 8
      '
      'lblTaxType
      '
      Me.lblTaxType.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.lblTaxType.BackColor = System.Drawing.Color.Transparent
      Me.lblTaxType.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblTaxType.Location = New System.Drawing.Point(116, 450)
      Me.lblTaxType.Name = "lblTaxType"
      Me.lblTaxType.Size = New System.Drawing.Size(74, 18)
      Me.lblTaxType.TabIndex = 26
      Me.lblTaxType.Text = "ประเภทภาษี:"
      Me.lblTaxType.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'txtTaxRate
      '
      Me.txtTaxRate.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.txtTaxRate.BackColor = System.Drawing.SystemColors.Control
      Me.Validator.SetDataType(Me.txtTaxRate, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtTaxRate, "")
      Me.Validator.SetGotFocusBackColor(Me.txtTaxRate, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtTaxRate, System.Drawing.Color.Empty)
      Me.txtTaxRate.Location = New System.Drawing.Point(319, 449)
      Me.Validator.SetMinValue(Me.txtTaxRate, "")
      Me.txtTaxRate.Name = "txtTaxRate"
      Me.txtTaxRate.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtTaxRate, "")
      Me.Validator.SetRequired(Me.txtTaxRate, False)
      Me.txtTaxRate.Size = New System.Drawing.Size(55, 20)
      Me.txtTaxRate.TabIndex = 28
      Me.txtTaxRate.TabStop = False
      Me.txtTaxRate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'lblTaxRate
      '
      Me.lblTaxRate.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.lblTaxRate.BackColor = System.Drawing.Color.Transparent
      Me.lblTaxRate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblTaxRate.Location = New System.Drawing.Point(259, 449)
      Me.lblTaxRate.Name = "lblTaxRate"
      Me.lblTaxRate.Size = New System.Drawing.Size(61, 18)
      Me.lblTaxRate.TabIndex = 27
      Me.lblTaxRate.Text = "อัตราภาษี:"
      Me.lblTaxRate.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'txtTaxBase
      '
      Me.txtTaxBase.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.txtTaxBase.BackColor = System.Drawing.SystemColors.Control
      Me.Validator.SetDataType(Me.txtTaxBase, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtTaxBase, "")
      Me.Validator.SetGotFocusBackColor(Me.txtTaxBase, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtTaxBase, System.Drawing.Color.Empty)
      Me.txtTaxBase.Location = New System.Drawing.Point(190, 472)
      Me.Validator.SetMinValue(Me.txtTaxBase, "")
      Me.txtTaxBase.Name = "txtTaxBase"
      Me.txtTaxBase.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtTaxBase, "")
      Me.Validator.SetRequired(Me.txtTaxBase, False)
      Me.txtTaxBase.Size = New System.Drawing.Size(80, 20)
      Me.txtTaxBase.TabIndex = 25
      Me.txtTaxBase.TabStop = False
      Me.txtTaxBase.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'lblTaxBase
      '
      Me.lblTaxBase.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.lblTaxBase.BackColor = System.Drawing.Color.Transparent
      Me.lblTaxBase.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblTaxBase.Location = New System.Drawing.Point(94, 470)
      Me.lblTaxBase.Name = "lblTaxBase"
      Me.lblTaxBase.Size = New System.Drawing.Size(96, 18)
      Me.lblTaxBase.TabIndex = 24
      Me.lblTaxBase.Text = "ฐานภาษี:"
      Me.lblTaxBase.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblAmount
      '
      Me.lblAmount.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.lblAmount.BackColor = System.Drawing.Color.Transparent
      Me.lblAmount.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblAmount.Location = New System.Drawing.Point(400, 471)
      Me.lblAmount.Name = "lblAmount"
      Me.lblAmount.Size = New System.Drawing.Size(96, 18)
      Me.lblAmount.TabIndex = 31
      Me.lblAmount.Text = "ยอดเบิกได้สุทธิ:"
      Me.lblAmount.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'tgItem
      '
      Me.tgItem.AllowDrop = True
      Me.tgItem.AllowNew = False
      Me.tgItem.AllowSorting = False
      Me.tgItem.AlternatingBackColor = System.Drawing.SystemColors.InactiveCaptionText
      Me.tgItem.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                  Or System.Windows.Forms.AnchorStyles.Left) _
                  Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.tgItem.AutoColumnResize = True
      Me.tgItem.CaptionVisible = False
      Me.tgItem.Cellchanged = False
      Me.tgItem.DataMember = ""
      Me.tgItem.HeaderBackColor = System.Drawing.Color.Khaki
      Me.tgItem.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.tgItem.HeaderForeColor = System.Drawing.SystemColors.ControlText
      Me.tgItem.Location = New System.Drawing.Point(8, 176)
      Me.tgItem.Name = "tgItem"
      Me.tgItem.Size = New System.Drawing.Size(672, 191)
      Me.tgItem.SortingArrowColor = System.Drawing.Color.Red
      Me.tgItem.TabIndex = 2
      Me.tgItem.TreeManager = Nothing
      '
      'lblItem
      '
      Me.lblItem.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblItem.Location = New System.Drawing.Point(8, 160)
      Me.lblItem.Name = "lblItem"
      Me.lblItem.Size = New System.Drawing.Size(88, 18)
      Me.lblItem.TabIndex = 9
      Me.lblItem.Text = "รายการย่อย"
      Me.lblItem.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      '
      'txtAdvrRetention
      '
      Me.txtAdvrRetention.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.txtAdvrRetention.BackColor = System.Drawing.SystemColors.Control
      Me.Validator.SetDataType(Me.txtAdvrRetention, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtAdvrRetention, "")
      Me.Validator.SetGotFocusBackColor(Me.txtAdvrRetention, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtAdvrRetention, System.Drawing.Color.Empty)
      Me.txtAdvrRetention.Location = New System.Drawing.Point(16, 498)
      Me.Validator.SetMinValue(Me.txtAdvrRetention, "")
      Me.txtAdvrRetention.Name = "txtAdvrRetention"
      Me.txtAdvrRetention.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtAdvrRetention, "")
      Me.Validator.SetRequired(Me.txtAdvrRetention, False)
      Me.txtAdvrRetention.Size = New System.Drawing.Size(184, 20)
      Me.txtAdvrRetention.TabIndex = 19
      Me.txtAdvrRetention.TabStop = False
      Me.txtAdvrRetention.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      Me.txtAdvrRetention.Visible = False
      '
      'ibtnBlank
      '
      Me.ibtnBlank.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.ibtnBlank.Location = New System.Drawing.Point(88, 152)
      Me.ibtnBlank.Name = "ibtnBlank"
      Me.ibtnBlank.Size = New System.Drawing.Size(24, 24)
      Me.ibtnBlank.TabIndex = 13
      Me.ibtnBlank.TabStop = False
      Me.ibtnBlank.ThemedImage = CType(resources.GetObject("ibtnBlank.ThemedImage"), System.Drawing.Bitmap)
      Me.ToolTip1.SetToolTip(Me.ibtnBlank, "Blank")
      '
      'ibtnDelRow
      '
      Me.ibtnDelRow.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.ibtnDelRow.Location = New System.Drawing.Point(112, 152)
      Me.ibtnDelRow.Name = "ibtnDelRow"
      Me.ibtnDelRow.Size = New System.Drawing.Size(24, 24)
      Me.ibtnDelRow.TabIndex = 14
      Me.ibtnDelRow.TabStop = False
      Me.ibtnDelRow.ThemedImage = CType(resources.GetObject("ibtnDelRow.ThemedImage"), System.Drawing.Bitmap)
      Me.ToolTip1.SetToolTip(Me.ibtnDelRow, "Delete")
      '
      'ibtnPrint
      '
      Me.ibtnPrint.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.ibtnPrint.Location = New System.Drawing.Point(152, 152)
      Me.ibtnPrint.Name = "ibtnPrint"
      Me.ibtnPrint.Size = New System.Drawing.Size(24, 24)
      Me.ibtnPrint.TabIndex = 13
      Me.ibtnPrint.TabStop = False
      Me.ibtnPrint.ThemedImage = CType(resources.GetObject("ibtnPrint.ThemedImage"), System.Drawing.Bitmap)
      Me.ToolTip1.SetToolTip(Me.ibtnPrint, "พิมพ์")
      '
      'ibtnPrintPreview
      '
      Me.ibtnPrintPreview.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.ibtnPrintPreview.Location = New System.Drawing.Point(176, 152)
      Me.ibtnPrintPreview.Name = "ibtnPrintPreview"
      Me.ibtnPrintPreview.Size = New System.Drawing.Size(24, 24)
      Me.ibtnPrintPreview.TabIndex = 14
      Me.ibtnPrintPreview.TabStop = False
      Me.ibtnPrintPreview.ThemedImage = CType(resources.GetObject("ibtnPrintPreview.ThemedImage"), System.Drawing.Bitmap)
      Me.ToolTip1.SetToolTip(Me.ibtnPrintPreview, "ตัวอย่างก่อนพิมพ์")
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
      'txtNote
      '
      Me.txtNote.BackColor = System.Drawing.SystemColors.Window
      Me.Validator.SetDataType(Me.txtNote, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtNote, "")
      Me.Validator.SetGotFocusBackColor(Me.txtNote, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtNote, System.Drawing.Color.Empty)
      Me.txtNote.Location = New System.Drawing.Point(88, 128)
      Me.Validator.SetMinValue(Me.txtNote, "")
      Me.txtNote.Name = "txtNote"
      Me.Validator.SetRegularExpression(Me.txtNote, "")
      Me.Validator.SetRequired(Me.txtNote, False)
      Me.txtNote.Size = New System.Drawing.Size(392, 20)
      Me.txtNote.TabIndex = 1
      '
      'txtGross
      '
      Me.txtGross.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.txtGross.BackColor = System.Drawing.SystemColors.Control
      Me.Validator.SetDataType(Me.txtGross, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtGross, "")
      Me.Validator.SetGotFocusBackColor(Me.txtGross, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtGross, System.Drawing.Color.Empty)
      Me.txtGross.Location = New System.Drawing.Point(552, 128)
      Me.Validator.SetMinValue(Me.txtGross, "")
      Me.txtGross.Name = "txtGross"
      Me.txtGross.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtGross, "")
      Me.Validator.SetRequired(Me.txtGross, False)
      Me.txtGross.Size = New System.Drawing.Size(112, 20)
      Me.txtGross.TabIndex = 12
      Me.txtGross.TabStop = False
      Me.txtGross.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'txtPenalty
      '
      Me.txtPenalty.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.txtPenalty.BackColor = System.Drawing.SystemColors.Window
      Me.Validator.SetDataType(Me.txtPenalty, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtPenalty, "")
      Me.Validator.SetGotFocusBackColor(Me.txtPenalty, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtPenalty, System.Drawing.Color.Empty)
      Me.txtPenalty.Location = New System.Drawing.Point(495, 428)
      Me.Validator.SetMinValue(Me.txtPenalty, "")
      Me.txtPenalty.Name = "txtPenalty"
      Me.Validator.SetRegularExpression(Me.txtPenalty, "")
      Me.Validator.SetRequired(Me.txtPenalty, False)
      Me.txtPenalty.Size = New System.Drawing.Size(184, 20)
      Me.txtPenalty.TabIndex = 7
      Me.txtPenalty.TabStop = False
      Me.txtPenalty.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'txtRealMilestoneAmount
      '
      Me.txtRealMilestoneAmount.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.Validator.SetDataType(Me.txtRealMilestoneAmount, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtRealMilestoneAmount, "")
      Me.Validator.SetGotFocusBackColor(Me.txtRealMilestoneAmount, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtRealMilestoneAmount, System.Drawing.Color.Empty)
      Me.txtRealMilestoneAmount.Location = New System.Drawing.Point(294, 383)
      Me.Validator.SetMinValue(Me.txtRealMilestoneAmount, "")
      Me.txtRealMilestoneAmount.Name = "txtRealMilestoneAmount"
      Me.Validator.SetRegularExpression(Me.txtRealMilestoneAmount, "")
      Me.Validator.SetRequired(Me.txtRealMilestoneAmount, False)
      Me.txtRealMilestoneAmount.Size = New System.Drawing.Size(80, 20)
      Me.txtRealMilestoneAmount.TabIndex = 33
      Me.txtRealMilestoneAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'txtRealTaxBase
      '
      Me.txtRealTaxBase.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.Validator.SetDataType(Me.txtRealTaxBase, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtRealTaxBase, "")
      Me.Validator.SetGotFocusBackColor(Me.txtRealTaxBase, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtRealTaxBase, System.Drawing.Color.Empty)
      Me.txtRealTaxBase.Location = New System.Drawing.Point(294, 471)
      Me.Validator.SetMinValue(Me.txtRealTaxBase, "")
      Me.txtRealTaxBase.Name = "txtRealTaxBase"
      Me.Validator.SetRegularExpression(Me.txtRealTaxBase, "")
      Me.Validator.SetRequired(Me.txtRealTaxBase, False)
      Me.txtRealTaxBase.Size = New System.Drawing.Size(81, 20)
      Me.txtRealTaxBase.TabIndex = 35
      Me.txtRealTaxBase.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'txtRealTaxAmount
      '
      Me.txtRealTaxAmount.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.Validator.SetDataType(Me.txtRealTaxAmount, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtRealTaxAmount, "")
      Me.Validator.SetGotFocusBackColor(Me.txtRealTaxAmount, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtRealTaxAmount, System.Drawing.Color.Empty)
      Me.txtRealTaxAmount.Location = New System.Drawing.Point(294, 491)
      Me.Validator.SetMinValue(Me.txtRealTaxAmount, "")
      Me.txtRealTaxAmount.Name = "txtRealTaxAmount"
      Me.Validator.SetRegularExpression(Me.txtRealTaxAmount, "")
      Me.Validator.SetRequired(Me.txtRealTaxAmount, False)
      Me.txtRealTaxAmount.Size = New System.Drawing.Size(81, 20)
      Me.txtRealTaxAmount.TabIndex = 38
      Me.txtRealTaxAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'txtAmount
      '
      Me.txtAmount.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.txtAmount.BackColor = System.Drawing.SystemColors.Control
      Me.Validator.SetDataType(Me.txtAmount, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtAmount, "")
      Me.Validator.SetGotFocusBackColor(Me.txtAmount, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtAmount, System.Drawing.Color.Empty)
      Me.txtAmount.Location = New System.Drawing.Point(496, 471)
      Me.Validator.SetMinValue(Me.txtAmount, "")
      Me.txtAmount.Name = "txtAmount"
      Me.txtAmount.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtAmount, "")
      Me.Validator.SetRequired(Me.txtAmount, False)
      Me.txtAmount.Size = New System.Drawing.Size(184, 20)
      Me.txtAmount.TabIndex = 40
      Me.txtAmount.TabStop = False
      Me.txtAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'lblNote
      '
      Me.lblNote.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblNote.Location = New System.Drawing.Point(16, 129)
      Me.lblNote.Name = "lblNote"
      Me.lblNote.Size = New System.Drawing.Size(72, 18)
      Me.lblNote.TabIndex = 10
      Me.lblNote.Text = "หมายเหตุ:"
      Me.lblNote.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblMilestoneAmount
      '
      Me.lblMilestoneAmount.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.lblMilestoneAmount.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblMilestoneAmount.Location = New System.Drawing.Point(102, 384)
      Me.lblMilestoneAmount.Name = "lblMilestoneAmount"
      Me.lblMilestoneAmount.Size = New System.Drawing.Size(88, 18)
      Me.lblMilestoneAmount.TabIndex = 16
      Me.lblMilestoneAmount.Text = "มูลค่าเงินงวด:"
      Me.lblMilestoneAmount.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblPenalty
      '
      Me.lblPenalty.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.lblPenalty.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblPenalty.Location = New System.Drawing.Point(375, 429)
      Me.lblPenalty.Name = "lblPenalty"
      Me.lblPenalty.Size = New System.Drawing.Size(120, 18)
      Me.lblPenalty.TabIndex = 21
      Me.lblPenalty.Text = "ค่าปรับ:"
      Me.lblPenalty.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'ibtnResetGross
      '
      Me.ibtnResetGross.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.ibtnResetGross.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.ibtnResetGross.Location = New System.Drawing.Point(270, 383)
      Me.ibtnResetGross.Name = "ibtnResetGross"
      Me.ibtnResetGross.Size = New System.Drawing.Size(24, 20)
      Me.ibtnResetGross.TabIndex = 34
      Me.ibtnResetGross.TabStop = False
      Me.ibtnResetGross.ThemedImage = CType(resources.GetObject("ibtnResetGross.ThemedImage"), System.Drawing.Bitmap)
      '
      'ibtnResetTaxBase
      '
      Me.ibtnResetTaxBase.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.ibtnResetTaxBase.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.ibtnResetTaxBase.Location = New System.Drawing.Point(270, 472)
      Me.ibtnResetTaxBase.Name = "ibtnResetTaxBase"
      Me.ibtnResetTaxBase.Size = New System.Drawing.Size(24, 20)
      Me.ibtnResetTaxBase.TabIndex = 36
      Me.ibtnResetTaxBase.TabStop = False
      Me.ibtnResetTaxBase.ThemedImage = CType(resources.GetObject("ibtnResetTaxBase.ThemedImage"), System.Drawing.Bitmap)
      '
      'ibtnResetTaxAmount
      '
      Me.ibtnResetTaxAmount.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.ibtnResetTaxAmount.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.ibtnResetTaxAmount.Location = New System.Drawing.Point(270, 491)
      Me.ibtnResetTaxAmount.Name = "ibtnResetTaxAmount"
      Me.ibtnResetTaxAmount.Size = New System.Drawing.Size(24, 20)
      Me.ibtnResetTaxAmount.TabIndex = 37
      Me.ibtnResetTaxAmount.TabStop = False
      Me.ibtnResetTaxAmount.ThemedImage = CType(resources.GetObject("ibtnResetTaxAmount.ThemedImage"), System.Drawing.Bitmap)
      '
      'lblAftertax
      '
      Me.lblAftertax.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.lblAftertax.BackColor = System.Drawing.Color.Transparent
      Me.lblAftertax.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblAftertax.Location = New System.Drawing.Point(380, 383)
      Me.lblAftertax.Name = "lblAftertax"
      Me.lblAftertax.Size = New System.Drawing.Size(115, 18)
      Me.lblAftertax.TabIndex = 39
      Me.lblAftertax.Text = "ยอดรวมภาษี:"
      Me.lblAftertax.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'MilestoneDetail
      '
      Me.Controls.Add(Me.lblAftertax)
      Me.Controls.Add(Me.txtAmount)
      Me.Controls.Add(Me.txtRealTaxAmount)
      Me.Controls.Add(Me.ibtnResetTaxAmount)
      Me.Controls.Add(Me.txtRealTaxBase)
      Me.Controls.Add(Me.ibtnResetTaxBase)
      Me.Controls.Add(Me.txtRealMilestoneAmount)
      Me.Controls.Add(Me.ibtnResetGross)
      Me.Controls.Add(Me.ibtnBlank)
      Me.Controls.Add(Me.ibtnDelRow)
      Me.Controls.Add(Me.tgItem)
      Me.Controls.Add(Me.lblDiscountAmount)
      Me.Controls.Add(Me.txtDiscountAmount)
      Me.Controls.Add(Me.lblBeforeTax)
      Me.Controls.Add(Me.txtBeforeTax)
      Me.Controls.Add(Me.lblTax)
      Me.Controls.Add(Me.txtTaxAmount)
      Me.Controls.Add(Me.txtAfterTax)
      Me.Controls.Add(Me.txtDiscountRate)
      Me.Controls.Add(Me.cmbTaxType)
      Me.Controls.Add(Me.lblTaxType)
      Me.Controls.Add(Me.txtTaxRate)
      Me.Controls.Add(Me.lblTaxRate)
      Me.Controls.Add(Me.txtTaxBase)
      Me.Controls.Add(Me.lblTaxBase)
      Me.Controls.Add(Me.lblAmount)
      Me.Controls.Add(Me.grbMilestone)
      Me.Controls.Add(Me.txtMilestoneAmount)
      Me.Controls.Add(Me.txtAdvance)
      Me.Controls.Add(Me.txtRetention)
      Me.Controls.Add(Me.lblAdvance)
      Me.Controls.Add(Me.lblRetention)
      Me.Controls.Add(Me.txtAdvrRetention)
      Me.Controls.Add(Me.lblItem)
      Me.Controls.Add(Me.lblNote)
      Me.Controls.Add(Me.txtNote)
      Me.Controls.Add(Me.txtGross)
      Me.Controls.Add(Me.lblMilestoneAmount)
      Me.Controls.Add(Me.txtPenalty)
      Me.Controls.Add(Me.lblPenalty)
      Me.Controls.Add(Me.lblGross)
      Me.Controls.Add(Me.ibtnPrint)
      Me.Controls.Add(Me.ibtnPrintPreview)
      Me.Name = "MilestoneDetail"
      Me.Size = New System.Drawing.Size(688, 538)
      Me.grbMilestone.ResumeLayout(False)
      Me.grbMilestone.PerformLayout()
      Me.ResumeLayout(False)
      Me.PerformLayout()

    End Sub

#End Region

#Region "Members"
    Private m_entity As Milestone
    Private m_isInitialized As Boolean = False
    Private m_treeManager As TreeManager
#End Region

#Region "Constructors"
    Public Sub New()
      MyBase.New()
      Me.InitializeComponent()
      Me.SetLabelText()
      Initialize()

      Dim dt As TreeTable = Milestone.GetSchemaTable()
      Dim dst As DataGridTableStyle = Me.CreateTableStyle()
      m_treeManager = New TreeManager(dt, tgItem)
      m_treeManager.SetTableStyle(dst)
      m_treeManager.AllowSorting = False
      m_treeManager.AllowDelete = False
      EventWiring()
    End Sub
#End Region

#Region "Style"
    Private Function CreateTableStyle() As DataGridTableStyle
      Dim dst As New DataGridTableStyle
      dst.MappingName = "Milestone"
      Dim csLineNumber As New TreeTextColumn
      csLineNumber.MappingName = "milestonei_linenumber"
      csLineNumber.HeaderText = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.MilestoneDetail.LineNumberHeaderText}")
      csLineNumber.NullText = ""
      csLineNumber.Width = 30
      csLineNumber.DataAlignment = HorizontalAlignment.Center
      csLineNumber.ReadOnly = True
      csLineNumber.TextBox.Name = "milestonei_linenumber"

      Dim csName As New TreeTextColumn
      csName.MappingName = "milestonei_desc"
      csName.HeaderText = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.MilestoneDetail.DescriptionHeaderText}")
      csName.NullText = ""
      csName.Width = 180
      csName.TextBox.Name = "Description"
      'AddHandler csDescription.TextBox.TextChanged, AddressOf ChangeProperty
      'csDescription.ReadOnly = True

      Dim csUnit As New TreeTextColumn
      csUnit.MappingName = "Unit"
      csUnit.HeaderText = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.MilestoneDetail.UnitHeaderText}")
      csUnit.NullText = ""
      csUnit.TextBox.Name = "Unit"
      'AddHandler csUnit.TextBox.TextChanged, AddressOf ChangeProperty
      'csUnit.DataAlignment = HorizontalAlignment.Center

      Dim csUnitButton As New DataGridButtonColumn
      csUnitButton.MappingName = "UnitButton"
      csUnitButton.HeaderText = ""
      csUnitButton.NullText = ""
      AddHandler csUnitButton.Click, AddressOf ButtonClicked

      Dim csQty As New TreeTextColumn
      csQty.MappingName = "milestonei_qty"
      csQty.HeaderText = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.MilestoneDetail.QtyHeaderText}")
      csQty.NullText = ""
      csQty.DataAlignment = HorizontalAlignment.Right
      csQty.Format = "#,###.##"
      csQty.TextBox.Name = "Qty"
      'AddHandler csQty.TextBox.TextChanged, AddressOf ChangeProperty

      Dim csUnitPRice As New TreeTextColumn
      csUnitPRice.MappingName = "milestonei_unitprice"
      csUnitPRice.HeaderText = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.MilestoneDetail.milestonei_unitpriceHeaderText}")
      csUnitPRice.NullText = ""
      csUnitPRice.TextBox.Name = "milestonei_unitprice"
      'AddHandler csUnit.TextBox.TextChanged, AddressOf ChangeProperty
      'csUnit.DataAlignment = HorizontalAlignment.Center


      Dim csAmount As New TreeTextColumn
      csAmount.MappingName = "milestonei_amt"
      csAmount.HeaderText = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.MilestoneDetail.AmountHeaderText}")
      csAmount.NullText = ""
      csAmount.TextBox.Name = "milestonei_amt"
      csAmount.ReadOnly = True
      'AddHandler csUnit.TextBox.TextChanged, AddressOf ChangeProperty
      'csUnit.DataAlignment = HorizontalAlignment.Center

      Dim csNote As New TreeTextColumn
      csNote.MappingName = "milestonei_note"
      csNote.HeaderText = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.MilestoneDetail.NoteHeaderText}")
      csNote.NullText = ""
      csNote.Width = 180
      csNote.TextBox.Name = "milestonei_note"


      dst.GridColumnStyles.Add(csLineNumber)
      dst.GridColumnStyles.Add(csName)
      dst.GridColumnStyles.Add(csUnit)
      dst.GridColumnStyles.Add(csUnitButton)
      dst.GridColumnStyles.Add(csQty)
      dst.GridColumnStyles.Add(csUnitPRice)
      dst.GridColumnStyles.Add(csAmount)
      dst.GridColumnStyles.Add(csNote)
      Return dst
    End Function
    Private Sub ButtonClicked(ByVal e As ButtonColumnEventArgs)
      Me.UnitButtonClick(e)
    End Sub
#End Region

#Region "IListDetail"
    Public Overrides Sub CheckFormEnable()
      If Me.m_entity Is Nothing Then
        Return
      End If
      If Me.m_entity.Status.Value = 0 Or Me.m_entity.Status.Value >= 3 Then
        For Each ctrl As Control In Me.Controls
          ctrl.Enabled = False
        Next
      Else
        For Each ctrl As Control In Me.Controls
          ctrl.Enabled = True
        Next
      End If
      Me.ibtnPrint.Enabled = True
      Me.ibtnPrintPreview.Enabled = True
    End Sub
    Public Overrides Sub ClearDetail()
      For Each crlt As Control In Me.Controls
        If crlt.Name.StartsWith("txt") Then
          crlt.Text = ""
        End If
      Next
    End Sub
    Public Overrides Sub SetLabelText()
      If Not m_entity Is Nothing Then Me.Text = Me.StringParserService.Parse(Me.m_entity.TabPageText)

      Me.lblCode.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.MilestoneDetail.lblCode}")
      Me.Validator.SetDisplayName(Me.txtCode, StringHelper.GetRidOfAtEnd(Me.lblCode.Text, ":"))

      Me.lblDocDate.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.MilestoneDetail.lblDocDate}")
      Me.lblHandedDate.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.MilestoneDetail.lblHandedDate}")
      Me.lblPenalty.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.MilestoneDetail.lblPenalty}")

      Me.lblGross.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.MilestoneDetail.lblGross}")

      Me.lblMilestoneAmount.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.MilestoneDetail.lblMilestoneAmount}")

      Me.lblDiscountAmount.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.MilestoneDetail.lblDiscountAmount}")
      Me.lblBeforeTax.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.MilestoneDetail.lblBeforeTax}")
      Me.lblTax.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.MilestoneDetail.lblTax}")
      Me.lblAmount.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.MilestoneDetail.lblAmount}")
      Me.lblAftertax.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.MilestoneDetail.lblAfterTax}")
      Me.lblTaxType.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.MilestoneDetail.lblTaxType}")
      Me.lblTaxRate.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.MilestoneDetail.lblTaxRate}")

      Me.lblCustomer.Text = Me.StringParserService.Parse("${res:Global.lblCustomer}")
      Me.lblRetention.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.MilestoneDetail.lblRetention}")
      Me.lblAdvance.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.MilestoneDetail.lblAdvance}")
      Me.lblNote.Text = Me.StringParserService.Parse("${res:Global.NoteText}")
      Me.lblItem.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.MilestoneDetail.lblItem}")
      Me.lblTaxBase.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.MilestoneDetail.lblTaxBase}")
      Me.lblName.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.MilestoneDetail.lblName}")
      Me.lblProject.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.MilestoneDetail.lblProject}")
    End Sub
    Protected Overrides Sub EventWiring()
      AddHandler txtCode.TextChanged, AddressOf Me.ChangeProperty
      AddHandler txtName.TextChanged, AddressOf Me.ChangeProperty
      AddHandler txtNote.TextChanged, AddressOf Me.ChangeProperty

      AddHandler txtMilestoneAmount.TextChanged, AddressOf Me.ChangeProperty
      AddHandler txtRetention.TextChanged, AddressOf Me.ChangeProperty
      AddHandler txtAdvance.TextChanged, AddressOf Me.ChangeProperty
      AddHandler txtPenalty.TextChanged, AddressOf Me.ChangeProperty

      AddHandler txtMilestoneAmount.Validated, AddressOf Me.TextHandler
      AddHandler txtRetention.Validated, AddressOf Me.TextHandler
      AddHandler txtAdvance.Validated, AddressOf Me.TextHandler
      AddHandler txtPenalty.Validated, AddressOf Me.TextHandler

      AddHandler txtDocDate.Validated, AddressOf Me.ChangeProperty
      AddHandler dtpDocDate.ValueChanged, AddressOf Me.ChangeProperty

      AddHandler txtHandedDate.Validated, AddressOf Me.ChangeProperty
      AddHandler dtpHandedDate.ValueChanged, AddressOf Me.ChangeProperty

      AddHandler txtTaxBase.TextChanged, AddressOf Me.ChangeProperty 'Todo: .... จะแก้ได้หรือปล่าว แก้โลด
      AddHandler txtDiscountRate.TextChanged, AddressOf Me.ChangeProperty

      AddHandler cmbTaxType.SelectedIndexChanged, AddressOf Me.ChangeProperty
      AddHandler cmbType.SelectedIndexChanged, AddressOf Me.ChangeProperty

      AddHandler txtRealTaxBase.TextChanged, AddressOf Me.ChangeProperty
      AddHandler txtRealTaxBase.Validated, AddressOf Me.TextHandler

      AddHandler txtRealTaxAmount.TextChanged, AddressOf Me.ChangeProperty
      AddHandler txtRealTaxAmount.Validated, AddressOf Me.TextHandler

      AddHandler txtRealMilestoneAmount.TextChanged, AddressOf Me.ChangeProperty
      AddHandler txtRealMilestoneAmount.Validated, AddressOf Me.TextHandler
    End Sub
    Private Sub TextHandler(ByVal sender As Object, ByVal e As EventArgs)
      If Me.m_entity Is Nothing Or Not m_isInitialized Then
        Return
      End If
      Select Case CType(sender, Control).Name.ToLower
        Case "txtmilestoneamount"
          Dim txt As String = txtMilestoneAmount.Text
          If txt.Length > 0 AndAlso IsNumeric(txt) Then
            Me.m_entity.MileStoneAmount = CDec(txt)
          Else
            Me.m_entity.MileStoneAmount = 0
          End If
          txtMilestoneAmount.Text = Configuration.FormatToString(Me.m_entity.MileStoneAmount, DigitConfig.Price)
          forceUpdateTaxBase = True
          forceUpdateTaxAmount = True
          UpdateAmount(True)
        Case "txtretention"
          Dim txt As String = txtRetention.Text
          If txt.Length > 0 AndAlso IsNumeric(txt) Then
            Me.m_entity.Retention = CDec(txt)
          Else
            Me.m_entity.Retention = 0
          End If
          txtRetention.Text = Configuration.FormatToString(Me.m_entity.Retention, DigitConfig.Price)
          UpdateAmount(True)
        Case "txtadvance"
          Dim txt As String = txtAdvance.Text
          If txt.Length > 0 AndAlso IsNumeric(txt) Then
            Me.m_entity.Advance = CDec(txt)
          Else
            Me.m_entity.Advance = 0
          End If
          txtAdvance.Text = Configuration.FormatToString(Me.m_entity.Advance, DigitConfig.Price)
          forceUpdateTaxBase = True
          forceUpdateTaxAmount = True
          UpdateAmount(True)
        Case "txtpenalty"
          Dim txt As String = txtPenalty.Text
          If txt.Length > 0 AndAlso IsNumeric(txt) Then
            Me.m_entity.Penalty = CDec(txt)
          Else
            Me.m_entity.Penalty = 0
          End If
          txtPenalty.Text = Configuration.FormatToString(Me.m_entity.Penalty, DigitConfig.Price)
          UpdateAmount(True)
        Case "txtrealtaxbase"
          Dim txt As String = Me.txtRealTaxBase.Text
          txt = txt.Replace(",", "")
          If txt.Length = 0 Then
            Me.m_entity.RealTaxBase = 0
          Else
            Try
              Me.m_entity.RealTaxBase = CDec(TextParser.Evaluate(txt))
            Catch ex As Exception
              Me.m_entity.RealTaxBase = 0
            End Try
          End If
          forceUpdateTaxAmount = True
          UpdateAmount(True)
        Case "txtrealmilestoneamount"
          Dim txt As String = Me.txtRealMilestoneAmount.Text
          txt = txt.Replace(",", "")
          If txt.Length = 0 Then
            Me.m_entity.RealMileStoneAmount = 0
          Else
            Try
              Me.m_entity.RealMileStoneAmount = CDec(TextParser.Evaluate(txt))
            Catch ex As Exception
              Me.m_entity.RealMileStoneAmount = 0
            End Try
          End If
          forceUpdateTaxBase = True
          forceUpdateTaxAmount = True
          UpdateAmount(True)
        Case "txtrealtaxamount"
          Dim txt As String = Me.txtRealTaxAmount.Text
          txt = txt.Replace(",", "")
          If txt.Length = 0 Then
            Me.m_entity.RealTaxAmount = 0
          Else
            Try
              Me.m_entity.RealTaxAmount = CDec(TextParser.Evaluate(txt))
            Catch ex As Exception
              Me.m_entity.RealTaxAmount = 0
            End Try
          End If
          UpdateAmount(True)
      End Select
    End Sub
    Public Overrides Sub UpdateEntityProperties()
      m_isInitialized = False
      ClearDetail()
      If m_entity Is Nothing Then
        Return
      End If
      txtCode.Text = m_entity.Code
      txtName.Text = m_entity.Name

      txtCustomerCode.Text = m_entity.Customer.Code
      txtCustomerName.Text = m_entity.Customer.Name

      txtNote.Text = m_entity.Note

      If Not Me.m_entity.CostCenter Is Nothing AndAlso Me.m_entity.CostCenter.Originated Then
        txtProjectCode.Text = m_entity.CostCenter.Code
        txtProjectName.Text = m_entity.CostCenter.Name
        Me.txtCustomerCode.Text = Me.m_entity.Customer.Code
        Me.txtCustomerName.Text = Me.m_entity.Customer.Name
      End If

      CodeDescription.ComboSelect(Me.cmbType, Me.m_entity.Type)
      CodeDescription.ComboSelect(Me.cmbTaxType, Me.m_entity.TaxType)

      Me.txtDocDate.Text = Me.MinDateToNull(Me.m_entity.DocDate, "")
      Me.dtpDocDate.Value = Me.MinDateToNow(Me.m_entity.DocDate)

      Me.txtHandedDate.Text = Me.MinDateToNull(Me.m_entity.HandedDate, "")
      Me.dtpHandedDate.Value = Me.MinDateToNow(Me.m_entity.HandedDate)

      'Load Items**********************************************************
      Me.m_treeManager.Treetable = Me.m_entity.ItemTable
      AddHandler Me.m_entity.PropertyChanged, AddressOf PropChanged
      Me.Validator.DataTable = m_treeManager.Treetable
      '********************************************************************

      Me.txtMilestoneAmount.Text = Configuration.FormatToString(m_entity.MileStoneAmount, DigitConfig.Price)
      Me.txtRetention.Text = Configuration.FormatToString(m_entity.Retention, DigitConfig.Price)
      Me.txtAdvance.Text = Configuration.FormatToString(m_entity.Advance, DigitConfig.Price)
      Me.txtPenalty.Text = Configuration.FormatToString(m_entity.Penalty, DigitConfig.Price)

      UpdateAmount(True)

      RefreshBlankGrid()

      SetStatus()
      SetLabelText()
      CheckFormEnable()
      m_isInitialized = True
    End Sub
    Private Sub PropChanged(ByVal sender As Object, ByVal e As PropertyChangedEventArgs)
      If e.Name = "ItemChanged" Then
        Me.UpdateAmount(False)
        WorkbenchSingleton.Workbench.ActiveWorkbenchWindow.ViewContent.IsDirty = True
      End If
    End Sub
    Private m_dateSetting As Boolean = False
    Public Sub ChangeProperty(ByVal sender As Object, ByVal e As EventArgs)
      If Me.m_entity Is Nothing Or Not m_isInitialized Then
        Return
      End If
      Dim dirtyFlag As Boolean = False
      Select Case CType(sender, Control).Name.ToLower
        Case "txtrealtaxbase"
          dirtyFlag = True
        Case "txtrealtaxamount"
          dirtyFlag = True
        Case "txtrealmilestoneamount"
          dirtyFlag = True
        Case "txtcode"
          Me.m_entity.Code = txtCode.Text
          dirtyFlag = True
        Case "txtname"
          Me.m_entity.Name = txtName.Text
          dirtyFlag = True
        Case "txtmilestoneamount"
          UpdateAmount(True)
          dirtyFlag = True
        Case "txtretention"
          UpdateAmount(True)
          dirtyFlag = True
        Case "txtadvance"
          UpdateAmount(True)
          dirtyFlag = True
        Case "txtpenalty"
          UpdateAmount(True)
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
        Case "dtphandeddate"
          If Not Me.m_entity.HandedDate.Equals(dtpHandedDate.Value) Then
            If Not m_dateSetting Then
              Me.txtHandedDate.Text = MinDateToNull(dtpHandedDate.Value, Me.StringParserService.Parse("${res:Global.BlankDateText}"))
              Me.m_entity.HandedDate = dtpHandedDate.Value
            End If
            dirtyFlag = True
          End If
        Case "txthandeddate"
          m_dateSetting = True
          If Not Me.txtHandedDate.Text.Length = 0 AndAlso Me.Validator.GetErrorMessage(Me.txtHandedDate) = "" Then
            Dim theDate As Date = CDate(Me.txtHandedDate.Text)
            If Not Me.m_entity.HandedDate.Equals(theDate) Then
              dtpHandedDate.Value = theDate
              Me.m_entity.HandedDate = dtpHandedDate.Value
              dirtyFlag = True
            End If
          Else
            dtpHandedDate.Value = Date.Now
            Me.m_entity.HandedDate = Date.MinValue
            dirtyFlag = True
          End If
          m_dateSetting = False
        Case "txttaxbase"
          'Todo
        Case "txtdiscountrate"
          Me.m_entity.Discount.Rate = txtDiscountRate.Text
          UpdateAmount(True)
          dirtyFlag = True
        Case "cmbtaxtype"
          Dim item As IdValuePair = CType(Me.cmbTaxType.SelectedItem, IdValuePair)
          Me.m_entity.TaxType.Value = item.Id
          forceUpdateTaxBase = True
          UpdateAmount(True)
          dirtyFlag = True
        Case "cmbtype"
          'Do Nothing
        Case Else
      End Select
      WorkbenchSingleton.Workbench.ActiveWorkbenchWindow.ViewContent.IsDirty = WorkbenchSingleton.Workbench.ActiveWorkbenchWindow.ViewContent.IsDirty Or dirtyFlag
      CheckFormEnable()
    End Sub
    Private Sub ibtnResetGross_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnResetGross.Click
      If Me.m_entity.RealMileStoneAmount <> Me.m_entity.MileStoneAmount Then
        WorkbenchSingleton.Workbench.ActiveWorkbenchWindow.ViewContent.IsDirty = True
      End If
      Me.m_entity.RealMileStoneAmount = Me.m_entity.MileStoneAmount
      UpdateAmount(True)
    End Sub
    Private Sub ibtnResetTaxBase_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnResetTaxBase.Click
      If Me.m_entity.RealTaxBase <> Me.m_entity.TaxBase Then
        WorkbenchSingleton.Workbench.ActiveWorkbenchWindow.ViewContent.IsDirty = True
      End If
      Me.m_entity.RealTaxBase = Me.m_entity.TaxBase
      UpdateAmount(True)
    End Sub
    Private Sub ibtnResetTaxAmount_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnResetTaxAmount.Click
      If Me.m_entity.RealTaxAmount <> Me.m_entity.TaxAmount Then
        WorkbenchSingleton.Workbench.ActiveWorkbenchWindow.ViewContent.IsDirty = True
      End If
      Me.m_entity.RealTaxAmount = Me.m_entity.TaxAmount
      UpdateAmount(True)
    End Sub
    Private forceUpdateTaxBase As Boolean = False
    Private forceUpdateMileStoneAmount As Boolean = False
    Private forceUpdateTaxAmount As Boolean = False
    Private Sub UpdateAmount(ByVal refresh As Boolean)
      m_isInitialized = False
      If refresh Then
        Me.m_entity.RefreshGross()
      End If

      'HACK: forceUpdateGross ต้องอยู่อันแรกนะจ๊ะ
      If forceUpdateMileStoneAmount OrElse (Not Me.m_entity.Originated AndAlso Me.m_entity.RealTaxBase <> Me.m_entity.TaxBase) Then
        Me.m_entity.RealMileStoneAmount = Me.m_entity.MileStoneAmount
        forceUpdateTaxBase = True
        forceUpdateMileStoneAmount = False
      End If
      If forceUpdateTaxBase OrElse (Not Me.m_entity.Originated AndAlso Me.m_entity.RealTaxBase <> Me.m_entity.TaxBase) Then
        Me.m_entity.RealTaxBase = Me.m_entity.TaxBase
        forceUpdateTaxAmount = True
        forceUpdateTaxBase = False
      End If
      If forceUpdateTaxAmount OrElse (Not Me.m_entity.Originated AndAlso Me.m_entity.RealTaxAmount <> Me.m_entity.TaxAmount) Then
        Me.m_entity.RealTaxAmount = Me.m_entity.TaxAmount
        forceUpdateTaxAmount = False
      End If

      txtGross.Text = Configuration.FormatToString(m_entity.Gross, DigitConfig.Price)
      Me.txtAdvrRetention.Text = Configuration.FormatToString(m_entity.AdvancePlusRetention, DigitConfig.Price)
      txtDiscountAmount.Text = Configuration.FormatToString(m_entity.DiscountAmount, DigitConfig.Price)
      txtBeforeTax.Text = Configuration.FormatToString(m_entity.BeforeTax, DigitConfig.Price)
      txtAmount.Text = Configuration.FormatToString(m_entity.Amount, DigitConfig.Price)
      txtTaxAmount.Text = Configuration.FormatToString(m_entity.TaxAmount, DigitConfig.Price)
      txtDiscountRate.Text = m_entity.Discount.Rate
      txtTaxRate.Text = Configuration.FormatToString(m_entity.TaxRate, DigitConfig.Price)
      txtTaxBase.Text = Configuration.FormatToString(m_entity.TaxBase, DigitConfig.Price)

      txtRealMilestoneAmount.Text = Configuration.FormatToString(m_entity.RealMileStoneAmount, DigitConfig.Price)
      txtRealTaxAmount.Text = Configuration.FormatToString(m_entity.RealTaxAmount, DigitConfig.Price)
      txtRealTaxBase.Text = Configuration.FormatToString(m_entity.RealTaxBase, DigitConfig.Price)
      If m_entity.TaxPoint.Value <> 0 Then
        txtAfterTax.Text = Configuration.FormatToString(m_entity.RealAfterTax, DigitConfig.Price)
      Else
        txtAfterTax.Text = Configuration.FormatToString(m_entity.AfterTax, DigitConfig.Price)
      End If

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
      ElseIf Me.m_entity.Originated Then
        Me.StatusBarService.SetMessage("เพิ่มเข้าสู่ระบบ: " & m_entity.OriginDate.ToShortDateString & _
        " " & m_entity.OriginDate.ToShortTimeString & _
        "  โดย:" & m_entity.Originator.Name)
      Else
        Me.StatusBarService.SetMessage("")
      End If
    End Sub
    Public Overrides Property Entity() As BusinessLogic.ISimpleEntity
      Get
        Return Me.m_entity
      End Get
      Set(ByVal Value As BusinessLogic.ISimpleEntity)
        If Not m_entity Is Nothing Then
          RemoveHandler Me.m_entity.PropertyChanged, AddressOf PropChanged
          Me.m_entity = Nothing
        End If
        Me.m_entity = CType(Value, Milestone)
        'Hack:
        Me.m_entity.OnTabPageTextChanged(m_entity, EventArgs.Empty)
        UpdateEntityProperties()
      End Set
    End Property
    Public Overrides Sub Initialize()
      SetTaxTypeComboBox()
      SetTypeCombo()
    End Sub
    ' 
    Private Sub SetTaxTypeComboBox()
      CodeDescription.ListCodeDescriptionInComboBox(Me.cmbTaxType, "taxType")
    End Sub
    Private Sub SetTypeCombo()
      CodeDescription.ListCodeDescriptionInComboBox(Me.cmbType, "milestone_type")
    End Sub
#End Region

#Region "Event Handler"
        Public Sub UnitButtonClick(ByVal e As ButtonColumnEventArgs)
            Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
            myEntityPanelService.OpenListDialog(New Unit, AddressOf SetUnit)
        End Sub
        Private Sub SetUnit(ByVal unit As ISimpleEntity)
            Me.m_treeManager.SelectedRow("Unit") = unit.Code
        End Sub
        Private Sub ibtnBlank_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnBlank.Click
            Dim index As Integer = tgItem.CurrentRowIndex
            If index > Me.m_entity.MaxRowIndex Then
                Return
            End If
            Dim theItem As New MilestoneItem
            Me.m_entity.Insert(index, theItem)
            Me.m_entity.ItemTable.AcceptChanges()
            tgItem.CurrentRowIndex = index
            RefreshBlankGrid()
        End Sub
        Private Sub ibtnDelRow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnDelRow.Click
            Dim index As Integer = Me.tgItem.CurrentRowIndex
            If index > Me.m_entity.MaxRowIndex Then
                Return
            End If
            Me.m_entity.Remove(index)
            Me.tgItem.CurrentRowIndex = index
            RefreshBlankGrid()
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
                Return (New Milestone).DetailPanelIcon
            End Get
        End Property
#End Region

#Region "Event of Button controls"

#End Region

#Region "IClipboardHandler Overrides"
        Public Overrides ReadOnly Property EnablePaste() As Boolean
            Get
                'Dim data As IDataObject = Clipboard.GetDataObject
                'If data.GetDataPresent((New Supplier).FullClassName) Then
                '    If Not Me.ActiveControl Is Nothing Then
                '        Select Case Me.ActiveControl.Name.ToLower
                '            Case "txtsuppliercode", "txtsuppliername"
                '                Return True
                '        End Select
                '    End If
                'End If
                Return False
            End Get
        End Property
        Public Overrides Sub Paste(ByVal sender As Object, ByVal e As System.EventArgs)
            'Dim data As IDataObject = Clipboard.GetDataObject
            'If data.GetDataPresent((New Supplier).FullClassName) Then
            '    Dim id As Integer = CInt(data.GetData((New Supplier).FullClassName))
            '    Dim entity As New Supplier(id)
            '    If Not Me.ActiveControl Is Nothing Then
            '        Select Case Me.ActiveControl.Name.ToLower
            '            Case "txtsuppliercode", "txtsuppliername"
            '                Me.SetSupplierDialog(entity)
            '        End Select
            '    End If
            'End If
        End Sub
#End Region

#Region "IPrintable"
        Private Sub ibtnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnPrint.Click
            Dim document As PrintDocument = Me.PrintDocument
            If (Not document Is Nothing) Then
                Dim dialog As PrintDialog = New PrintDialog
                dialog.Document = document
                dialog.AllowSomePages = True
                If (dialog.ShowDialog = DialogResult.OK) Then
                    document.Print()
                End If
                Return
            End If
        End Sub
        Private Sub ibtnPrintPreview_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnPrintPreview.Click
            Dim document As PrintDocument = Me.PrintDocument
            If (Not document Is Nothing) Then
                Dim dialog As New PrintPreviewDialog
                dialog.Owner = CType(WorkbenchSingleton.Workbench, Form)
                dialog.TopMost = True
                dialog.Document = document
                dialog.Show()
            Else
                'myMessageService.ShowError("${res:Longkong.Pojjaman.Commands.Print.CreatePrintDocumentError}")
            End If
        End Sub
#End Region

#Region "Grid Resizing"
        Private Sub tgItem_Resize(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tgItem.Resize
            If Me.m_entity Is Nothing Then
                Return
            End If
            RefreshBlankGrid()
        End Sub
        Private Sub RefreshBlankGrid()
            If Me.tgItem.Height = 0 Then
                Return
            End If
            Dim dirtyFlag As Boolean = WorkbenchSingleton.Workbench.ActiveWorkbenchWindow.ViewContent.IsDirty
            Dim index As Integer = tgItem.CurrentRowIndex
            Dim maxVisibleCount As Integer
            Dim tgRowHeight As Integer = 17
            maxVisibleCount = CInt(Math.Floor((Me.tgItem.Height - tgRowHeight) / tgRowHeight))
            Do While Me.m_entity.ItemTable.Rows.Count < maxVisibleCount - 1
                'เพิ่มแถวจนเต็ม
                Me.m_entity.AddBlankRow(1)
            Loop
            If Me.m_entity.MaxRowIndex = maxVisibleCount - 2 Then
                If Me.m_entity.ItemTable.Rows.Count < maxVisibleCount - 1 Then
                    'เพิ่มอีก 1 แถว ถ้ามีข้อมูลจนถึงแถวสุดท้าย
                    Me.m_entity.AddBlankRow(2)
                End If
            End If
            'Do While Me.m_entity.ItemTable.Rows.Count > maxVisibleCount - 1 And Me.m_entity.ItemTable.Rows.Count - 2 <> Me.m_entity.MaxRowIndex
            '    'ลบแถวที่ไม่จำเป็น
            '    Me.m_entity.Remove(Me.m_entity.ItemTable.Rows.Count - 1)
            'Loop
            Me.m_entity.ItemTable.AcceptChanges()
            tgItem.CurrentRowIndex = Math.Max(0, index)
            WorkbenchSingleton.Workbench.ActiveWorkbenchWindow.ViewContent.IsDirty = dirtyFlag
        End Sub
#End Region


    End Class

End Namespace

