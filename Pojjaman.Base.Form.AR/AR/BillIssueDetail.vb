Imports Longkong.Pojjaman.Services
Imports Longkong.Core.Services

Imports Longkong.Pojjaman.Gui
Imports Longkong.Pojjaman.BusinessLogic
Imports System.Drawing.Printing
Imports Longkong.Pojjaman.Gui.Components
Imports System.Globalization
Imports System.Reflection
Imports Longkong.Pojjaman.TextHelper
Namespace Longkong.Pojjaman.Gui.Panels
  Public Class BillIssueDetail
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
    Friend WithEvents lblDocDate As System.Windows.Forms.Label
    Friend WithEvents lblCode As System.Windows.Forms.Label
    Friend WithEvents lblItem As System.Windows.Forms.Label
    Friend WithEvents grbSummary As Longkong.Pojjaman.Gui.Components.FixedGroupBox
    Friend WithEvents txtItemCount As System.Windows.Forms.TextBox
    Friend WithEvents lblItemCount As System.Windows.Forms.Label
    Friend WithEvents lblItemCountUnit As System.Windows.Forms.Label
    Friend WithEvents lblBaht As System.Windows.Forms.Label
    Friend WithEvents txtTotalAmount As System.Windows.Forms.TextBox
    Friend WithEvents txtNote As System.Windows.Forms.TextBox
    Friend WithEvents lblNote As System.Windows.Forms.Label
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents Validator As Longkong.Pojjaman.Gui.Components.PJMTextboxValidator
    Friend WithEvents chkShowDetail As System.Windows.Forms.CheckBox
    Friend WithEvents chkAutorun As System.Windows.Forms.CheckBox
    Friend WithEvents lblTotalReceivable As System.Windows.Forms.Label
    Friend WithEvents txtDocDate As System.Windows.Forms.TextBox
    Friend WithEvents dtpDocDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents ibtnDelRow As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents imbMilestoneDetail As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents SecurityValidator As Longkong.Pojjaman.Gui.Components.SecurityValidator
    Friend WithEvents grbCustomer As Longkong.Pojjaman.Gui.Components.FixedGroupBox
    Friend WithEvents txtCustomerName As System.Windows.Forms.TextBox
    Friend WithEvents txtCustomerCode As System.Windows.Forms.TextBox
    Friend WithEvents lblCustomer As System.Windows.Forms.Label
    Friend WithEvents ibtnShowEmployee As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents txtEmployeeName As System.Windows.Forms.TextBox
    Friend WithEvents txtEmployeeCode As System.Windows.Forms.TextBox
    Friend WithEvents ibtnShowEmployeeDialog As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents lblEmployee As System.Windows.Forms.Label
    Friend WithEvents tgItem As Longkong.Pojjaman.Gui.Components.TreeGrid
    Friend WithEvents lblCredit As System.Windows.Forms.Label
    Friend WithEvents lblDueDate As System.Windows.Forms.Label
    Friend WithEvents dtpDueDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtCreditPeriod As System.Windows.Forms.TextBox
    Friend WithEvents lblDay As System.Windows.Forms.Label
    Friend WithEvents chkSingleVat As System.Windows.Forms.CheckBox
    Friend WithEvents ibtnShowCustomerDialog As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents ibtnShowMilestone As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtTotalReceivable As System.Windows.Forms.TextBox
    Friend WithEvents lblTotalAmount As System.Windows.Forms.Label
    Friend WithEvents cmbCode As System.Windows.Forms.ComboBox
    <System.Diagnostics.DebuggerStepThrough()> Protected Sub InitializeComponent()
      Me.components = New System.ComponentModel.Container()
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(BillIssueDetail))
      Me.lblDocDate = New System.Windows.Forms.Label()
      Me.lblCode = New System.Windows.Forms.Label()
      Me.tgItem = New Longkong.Pojjaman.Gui.Components.TreeGrid()
      Me.lblItem = New System.Windows.Forms.Label()
      Me.grbSummary = New Longkong.Pojjaman.Gui.Components.FixedGroupBox()
      Me.Label1 = New System.Windows.Forms.Label()
      Me.txtTotalReceivable = New System.Windows.Forms.TextBox()
      Me.lblTotalAmount = New System.Windows.Forms.Label()
      Me.txtItemCount = New System.Windows.Forms.TextBox()
      Me.lblItemCount = New System.Windows.Forms.Label()
      Me.lblItemCountUnit = New System.Windows.Forms.Label()
      Me.lblBaht = New System.Windows.Forms.Label()
      Me.txtTotalAmount = New System.Windows.Forms.TextBox()
      Me.lblTotalReceivable = New System.Windows.Forms.Label()
      Me.txtNote = New System.Windows.Forms.TextBox()
      Me.lblNote = New System.Windows.Forms.Label()
      Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
      Me.txtDocDate = New System.Windows.Forms.TextBox()
      Me.Validator = New Longkong.Pojjaman.Gui.Components.PJMTextboxValidator(Me.components)
      Me.txtCreditPeriod = New System.Windows.Forms.TextBox()
      Me.txtCustomerName = New System.Windows.Forms.TextBox()
      Me.txtCustomerCode = New System.Windows.Forms.TextBox()
      Me.txtEmployeeName = New System.Windows.Forms.TextBox()
      Me.txtEmployeeCode = New System.Windows.Forms.TextBox()
      Me.ibtnShowCustomerDialog = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.chkShowDetail = New System.Windows.Forms.CheckBox()
      Me.chkAutorun = New System.Windows.Forms.CheckBox()
      Me.dtpDocDate = New System.Windows.Forms.DateTimePicker()
      Me.ibtnDelRow = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.imbMilestoneDetail = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.SecurityValidator = New Longkong.Pojjaman.Gui.Components.SecurityValidator(Me.components)
      Me.grbCustomer = New Longkong.Pojjaman.Gui.Components.FixedGroupBox()
      Me.lblCredit = New System.Windows.Forms.Label()
      Me.lblDueDate = New System.Windows.Forms.Label()
      Me.dtpDueDate = New System.Windows.Forms.DateTimePicker()
      Me.lblCustomer = New System.Windows.Forms.Label()
      Me.lblDay = New System.Windows.Forms.Label()
      Me.ibtnShowEmployee = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.ibtnShowEmployeeDialog = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.lblEmployee = New System.Windows.Forms.Label()
      Me.chkSingleVat = New System.Windows.Forms.CheckBox()
      Me.ibtnShowMilestone = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.cmbCode = New System.Windows.Forms.ComboBox()
      CType(Me.tgItem, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.grbSummary.SuspendLayout()
      CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.grbCustomer.SuspendLayout()
      Me.SuspendLayout()
      '
      'lblDocDate
      '
      Me.SecurityValidator.SetAccessId(Me.lblDocDate, 0)
      Me.SecurityValidator.SetFailAction(Me.lblDocDate, Longkong.Pojjaman.Gui.Components.FailAction.None)
      Me.lblDocDate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblDocDate.Location = New System.Drawing.Point(8, 32)
      Me.lblDocDate.Name = "lblDocDate"
      Me.SecurityValidator.SetRequiredLevel(Me.lblDocDate, 0)
      Me.lblDocDate.Size = New System.Drawing.Size(88, 18)
      Me.lblDocDate.TabIndex = 16
      Me.lblDocDate.Text = "Document Date:"
      Me.lblDocDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblCode
      '
      Me.SecurityValidator.SetAccessId(Me.lblCode, 0)
      Me.SecurityValidator.SetFailAction(Me.lblCode, Longkong.Pojjaman.Gui.Components.FailAction.None)
      Me.lblCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblCode.Location = New System.Drawing.Point(8, 8)
      Me.lblCode.Name = "lblCode"
      Me.SecurityValidator.SetRequiredLevel(Me.lblCode, 0)
      Me.lblCode.Size = New System.Drawing.Size(88, 18)
      Me.lblCode.TabIndex = 14
      Me.lblCode.Text = "Billing Note No.:"
      Me.lblCode.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'tgItem
      '
      Me.SecurityValidator.SetAccessId(Me.tgItem, 0)
      Me.tgItem.AllowNew = False
      Me.tgItem.AllowSorting = False
      Me.tgItem.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
              Or System.Windows.Forms.AnchorStyles.Left) _
              Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.tgItem.AutoColumnResize = True
      Me.tgItem.CaptionVisible = False
      Me.tgItem.Cellchanged = False
      Me.tgItem.DataMember = ""
      Me.SecurityValidator.SetFailAction(Me.tgItem, Longkong.Pojjaman.Gui.Components.FailAction.None)
      Me.tgItem.HeaderForeColor = System.Drawing.SystemColors.ControlText
      Me.tgItem.Location = New System.Drawing.Point(10, 120)
      Me.tgItem.Name = "tgItem"
      Me.SecurityValidator.SetRequiredLevel(Me.tgItem, 0)
      Me.tgItem.Size = New System.Drawing.Size(788, 224)
      Me.tgItem.SortingArrowColor = System.Drawing.Color.Red
      Me.tgItem.TabIndex = 10
      Me.tgItem.TreeManager = Nothing
      '
      'lblItem
      '
      Me.SecurityValidator.SetAccessId(Me.lblItem, 0)
      Me.lblItem.BackColor = System.Drawing.Color.Transparent
      Me.SecurityValidator.SetFailAction(Me.lblItem, Longkong.Pojjaman.Gui.Components.FailAction.None)
      Me.lblItem.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold)
      Me.lblItem.Location = New System.Drawing.Point(8, 96)
      Me.lblItem.Name = "lblItem"
      Me.SecurityValidator.SetRequiredLevel(Me.lblItem, 0)
      Me.lblItem.Size = New System.Drawing.Size(96, 18)
      Me.lblItem.TabIndex = 9
      Me.lblItem.Text = "Sale Bill Issue:"
      Me.lblItem.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      '
      'grbSummary
      '
      Me.SecurityValidator.SetAccessId(Me.grbSummary, 0)
      Me.grbSummary.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.grbSummary.Controls.Add(Me.Label1)
      Me.grbSummary.Controls.Add(Me.txtTotalReceivable)
      Me.grbSummary.Controls.Add(Me.lblTotalAmount)
      Me.grbSummary.Controls.Add(Me.txtItemCount)
      Me.grbSummary.Controls.Add(Me.lblItemCount)
      Me.grbSummary.Controls.Add(Me.lblItemCountUnit)
      Me.grbSummary.Controls.Add(Me.lblBaht)
      Me.grbSummary.Controls.Add(Me.txtTotalAmount)
      Me.grbSummary.Controls.Add(Me.lblTotalReceivable)
      Me.SecurityValidator.SetFailAction(Me.grbSummary, Longkong.Pojjaman.Gui.Components.FailAction.None)
      Me.grbSummary.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.grbSummary.Location = New System.Drawing.Point(24, 396)
      Me.grbSummary.Name = "grbSummary"
      Me.SecurityValidator.SetRequiredLevel(Me.grbSummary, 0)
      Me.grbSummary.Size = New System.Drawing.Size(774, 45)
      Me.grbSummary.TabIndex = 13
      Me.grbSummary.TabStop = False
      Me.grbSummary.Text = "สรุปรายการวางบิล"
      '
      'Label1
      '
      Me.SecurityValidator.SetAccessId(Me.Label1, 0)
      Me.SecurityValidator.SetFailAction(Me.Label1, Longkong.Pojjaman.Gui.Components.FailAction.None)
      Me.Label1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Label1.Location = New System.Drawing.Point(736, 17)
      Me.Label1.Name = "Label1"
      Me.SecurityValidator.SetRequiredLevel(Me.Label1, 0)
      Me.Label1.Size = New System.Drawing.Size(32, 18)
      Me.Label1.TabIndex = 8
      Me.Label1.Text = "บาท"
      Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      '
      'txtTotalReceivable
      '
      Me.SecurityValidator.SetAccessId(Me.txtTotalReceivable, 0)
      Me.txtTotalReceivable.BackColor = System.Drawing.SystemColors.Control
      Me.txtTotalReceivable.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
      Me.Validator.SetDataType(Me.txtTotalReceivable, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtTotalReceivable, "")
      Me.SecurityValidator.SetFailAction(Me.txtTotalReceivable, Longkong.Pojjaman.Gui.Components.FailAction.None)
      Me.Validator.SetGotFocusBackColor(Me.txtTotalReceivable, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtTotalReceivable, System.Drawing.Color.Empty)
      Me.txtTotalReceivable.Location = New System.Drawing.Point(593, 17)
      Me.Validator.SetMaxValue(Me.txtTotalReceivable, "")
      Me.Validator.SetMinValue(Me.txtTotalReceivable, "")
      Me.txtTotalReceivable.Name = "txtTotalReceivable"
      Me.txtTotalReceivable.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtTotalReceivable, "")
      Me.Validator.SetRequired(Me.txtTotalReceivable, False)
      Me.SecurityValidator.SetRequiredLevel(Me.txtTotalReceivable, 0)
      Me.txtTotalReceivable.Size = New System.Drawing.Size(143, 20)
      Me.txtTotalReceivable.TabIndex = 7
      Me.txtTotalReceivable.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'lblTotalAmount
      '
      Me.SecurityValidator.SetAccessId(Me.lblTotalAmount, 0)
      Me.SecurityValidator.SetFailAction(Me.lblTotalAmount, Longkong.Pojjaman.Gui.Components.FailAction.None)
      Me.lblTotalAmount.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblTotalAmount.Location = New System.Drawing.Point(222, 17)
      Me.lblTotalAmount.Name = "lblTotalAmount"
      Me.SecurityValidator.SetRequiredLevel(Me.lblTotalAmount, 0)
      Me.lblTotalAmount.Size = New System.Drawing.Size(96, 18)
      Me.lblTotalAmount.TabIndex = 6
      Me.lblTotalAmount.Text = "รวมยอดรับเงินสุทธิ"
      Me.lblTotalAmount.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'txtItemCount
      '
      Me.SecurityValidator.SetAccessId(Me.txtItemCount, 0)
      Me.txtItemCount.BackColor = System.Drawing.SystemColors.Control
      Me.txtItemCount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
      Me.Validator.SetDataType(Me.txtItemCount, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtItemCount, "")
      Me.SecurityValidator.SetFailAction(Me.txtItemCount, Longkong.Pojjaman.Gui.Components.FailAction.None)
      Me.Validator.SetGotFocusBackColor(Me.txtItemCount, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtItemCount, System.Drawing.Color.Empty)
      Me.txtItemCount.Location = New System.Drawing.Point(119, 16)
      Me.Validator.SetMaxValue(Me.txtItemCount, "")
      Me.Validator.SetMinValue(Me.txtItemCount, "")
      Me.txtItemCount.Name = "txtItemCount"
      Me.txtItemCount.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtItemCount, "")
      Me.Validator.SetRequired(Me.txtItemCount, False)
      Me.SecurityValidator.SetRequiredLevel(Me.txtItemCount, 0)
      Me.txtItemCount.Size = New System.Drawing.Size(53, 20)
      Me.txtItemCount.TabIndex = 1
      Me.txtItemCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'lblItemCount
      '
      Me.SecurityValidator.SetAccessId(Me.lblItemCount, 0)
      Me.SecurityValidator.SetFailAction(Me.lblItemCount, Longkong.Pojjaman.Gui.Components.FailAction.None)
      Me.lblItemCount.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblItemCount.Location = New System.Drawing.Point(33, 16)
      Me.lblItemCount.Name = "lblItemCount"
      Me.SecurityValidator.SetRequiredLevel(Me.lblItemCount, 0)
      Me.lblItemCount.Size = New System.Drawing.Size(80, 18)
      Me.lblItemCount.TabIndex = 0
      Me.lblItemCount.Text = "จำนวนรายการ"
      Me.lblItemCount.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblItemCountUnit
      '
      Me.SecurityValidator.SetAccessId(Me.lblItemCountUnit, 0)
      Me.SecurityValidator.SetFailAction(Me.lblItemCountUnit, Longkong.Pojjaman.Gui.Components.FailAction.None)
      Me.lblItemCountUnit.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblItemCountUnit.Location = New System.Drawing.Point(172, 16)
      Me.lblItemCountUnit.Name = "lblItemCountUnit"
      Me.SecurityValidator.SetRequiredLevel(Me.lblItemCountUnit, 0)
      Me.lblItemCountUnit.Size = New System.Drawing.Size(40, 18)
      Me.lblItemCountUnit.TabIndex = 2
      Me.lblItemCountUnit.Text = "รายการ"
      Me.lblItemCountUnit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      '
      'lblBaht
      '
      Me.SecurityValidator.SetAccessId(Me.lblBaht, 0)
      Me.SecurityValidator.SetFailAction(Me.lblBaht, Longkong.Pojjaman.Gui.Components.FailAction.None)
      Me.lblBaht.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblBaht.Location = New System.Drawing.Point(465, 16)
      Me.lblBaht.Name = "lblBaht"
      Me.SecurityValidator.SetRequiredLevel(Me.lblBaht, 0)
      Me.lblBaht.Size = New System.Drawing.Size(32, 18)
      Me.lblBaht.TabIndex = 5
      Me.lblBaht.Text = "บาท"
      Me.lblBaht.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      '
      'txtTotalAmount
      '
      Me.SecurityValidator.SetAccessId(Me.txtTotalAmount, 0)
      Me.txtTotalAmount.BackColor = System.Drawing.SystemColors.Control
      Me.txtTotalAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
      Me.Validator.SetDataType(Me.txtTotalAmount, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtTotalAmount, "")
      Me.SecurityValidator.SetFailAction(Me.txtTotalAmount, Longkong.Pojjaman.Gui.Components.FailAction.None)
      Me.Validator.SetGotFocusBackColor(Me.txtTotalAmount, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtTotalAmount, System.Drawing.Color.Empty)
      Me.txtTotalAmount.Location = New System.Drawing.Point(321, 16)
      Me.Validator.SetMaxValue(Me.txtTotalAmount, "")
      Me.Validator.SetMinValue(Me.txtTotalAmount, "")
      Me.txtTotalAmount.Name = "txtTotalAmount"
      Me.txtTotalAmount.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtTotalAmount, "")
      Me.Validator.SetRequired(Me.txtTotalAmount, False)
      Me.SecurityValidator.SetRequiredLevel(Me.txtTotalAmount, 0)
      Me.txtTotalAmount.Size = New System.Drawing.Size(143, 20)
      Me.txtTotalAmount.TabIndex = 4
      Me.txtTotalAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'lblTotalReceivable
      '
      Me.SecurityValidator.SetAccessId(Me.lblTotalReceivable, 0)
      Me.SecurityValidator.SetFailAction(Me.lblTotalReceivable, Longkong.Pojjaman.Gui.Components.FailAction.None)
      Me.lblTotalReceivable.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblTotalReceivable.Location = New System.Drawing.Point(491, 16)
      Me.lblTotalReceivable.Name = "lblTotalReceivable"
      Me.SecurityValidator.SetRequiredLevel(Me.lblTotalReceivable, 0)
      Me.lblTotalReceivable.Size = New System.Drawing.Size(96, 18)
      Me.lblTotalReceivable.TabIndex = 3
      Me.lblTotalReceivable.Text = "รวมมูลค่าวางบิล"
      Me.lblTotalReceivable.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'txtNote
      '
      Me.SecurityValidator.SetAccessId(Me.txtNote, 0)
      Me.txtNote.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.txtNote.BackColor = System.Drawing.SystemColors.Window
      Me.Validator.SetDataType(Me.txtNote, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtNote, "")
      Me.SecurityValidator.SetFailAction(Me.txtNote, Longkong.Pojjaman.Gui.Components.FailAction.None)
      Me.Validator.SetGotFocusBackColor(Me.txtNote, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtNote, System.Drawing.Color.Empty)
      Me.txtNote.Location = New System.Drawing.Point(80, 349)
      Me.Validator.SetMaxValue(Me.txtNote, "")
      Me.Validator.SetMinValue(Me.txtNote, "")
      Me.txtNote.Multiline = True
      Me.txtNote.Name = "txtNote"
      Me.Validator.SetRegularExpression(Me.txtNote, "")
      Me.Validator.SetRequired(Me.txtNote, False)
      Me.SecurityValidator.SetRequiredLevel(Me.txtNote, 0)
      Me.txtNote.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
      Me.txtNote.Size = New System.Drawing.Size(496, 42)
      Me.txtNote.TabIndex = 11
      '
      'lblNote
      '
      Me.SecurityValidator.SetAccessId(Me.lblNote, 0)
      Me.lblNote.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.lblNote.BackColor = System.Drawing.Color.Transparent
      Me.SecurityValidator.SetFailAction(Me.lblNote, Longkong.Pojjaman.Gui.Components.FailAction.None)
      Me.lblNote.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblNote.Location = New System.Drawing.Point(8, 346)
      Me.lblNote.Name = "lblNote"
      Me.SecurityValidator.SetRequiredLevel(Me.lblNote, 0)
      Me.lblNote.Size = New System.Drawing.Size(72, 18)
      Me.lblNote.TabIndex = 12
      Me.lblNote.Text = "หมายเหตุ:"
      Me.lblNote.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'ErrorProvider1
      '
      Me.ErrorProvider1.ContainerControl = Me
      '
      'txtDocDate
      '
      Me.SecurityValidator.SetAccessId(Me.txtDocDate, 0)
      Me.Validator.SetDataType(Me.txtDocDate, Longkong.Pojjaman.Gui.Components.DataTypeConstants.DateTimeType)
      Me.Validator.SetDisplayName(Me.txtDocDate, "")
      Me.SecurityValidator.SetFailAction(Me.txtDocDate, Longkong.Pojjaman.Gui.Components.FailAction.None)
      Me.Validator.SetGotFocusBackColor(Me.txtDocDate, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtDocDate, 15)
      Me.Validator.SetInvalidBackColor(Me.txtDocDate, System.Drawing.Color.Empty)
      Me.txtDocDate.Location = New System.Drawing.Point(96, 32)
      Me.Validator.SetMaxValue(Me.txtDocDate, "")
      Me.Validator.SetMinValue(Me.txtDocDate, "")
      Me.txtDocDate.Name = "txtDocDate"
      Me.Validator.SetRegularExpression(Me.txtDocDate, "")
      Me.Validator.SetRequired(Me.txtDocDate, True)
      Me.SecurityValidator.SetRequiredLevel(Me.txtDocDate, 0)
      Me.txtDocDate.Size = New System.Drawing.Size(78, 20)
      Me.txtDocDate.TabIndex = 1
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
      'txtCreditPeriod
      '
      Me.SecurityValidator.SetAccessId(Me.txtCreditPeriod, 0)
      Me.txtCreditPeriod.BackColor = System.Drawing.SystemColors.Window
      Me.Validator.SetDataType(Me.txtCreditPeriod, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtCreditPeriod, "")
      Me.SecurityValidator.SetFailAction(Me.txtCreditPeriod, Longkong.Pojjaman.Gui.Components.FailAction.None)
      Me.Validator.SetGotFocusBackColor(Me.txtCreditPeriod, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtCreditPeriod, System.Drawing.Color.Empty)
      Me.txtCreditPeriod.Location = New System.Drawing.Point(88, 64)
      Me.Validator.SetMaxValue(Me.txtCreditPeriod, "")
      Me.Validator.SetMinValue(Me.txtCreditPeriod, "")
      Me.txtCreditPeriod.Name = "txtCreditPeriod"
      Me.Validator.SetRegularExpression(Me.txtCreditPeriod, "")
      Me.Validator.SetRequired(Me.txtCreditPeriod, True)
      Me.SecurityValidator.SetRequiredLevel(Me.txtCreditPeriod, 0)
      Me.txtCreditPeriod.Size = New System.Drawing.Size(64, 20)
      Me.txtCreditPeriod.TabIndex = 3
      '
      'txtCustomerName
      '
      Me.SecurityValidator.SetAccessId(Me.txtCustomerName, 0)
      Me.txtCustomerName.BackColor = System.Drawing.SystemColors.Control
      Me.Validator.SetDataType(Me.txtCustomerName, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtCustomerName, "")
      Me.SecurityValidator.SetFailAction(Me.txtCustomerName, Longkong.Pojjaman.Gui.Components.FailAction.None)
      Me.Validator.SetGotFocusBackColor(Me.txtCustomerName, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtCustomerName, System.Drawing.Color.Empty)
      Me.txtCustomerName.Location = New System.Drawing.Point(221, 16)
      Me.Validator.SetMaxValue(Me.txtCustomerName, "")
      Me.Validator.SetMinValue(Me.txtCustomerName, "")
      Me.txtCustomerName.Name = "txtCustomerName"
      Me.txtCustomerName.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtCustomerName, "")
      Me.Validator.SetRequired(Me.txtCustomerName, False)
      Me.SecurityValidator.SetRequiredLevel(Me.txtCustomerName, 0)
      Me.txtCustomerName.Size = New System.Drawing.Size(250, 20)
      Me.txtCustomerName.TabIndex = 9
      Me.txtCustomerName.TabStop = False
      '
      'txtCustomerCode
      '
      Me.SecurityValidator.SetAccessId(Me.txtCustomerCode, 0)
      Me.Validator.SetDataType(Me.txtCustomerCode, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtCustomerCode, "")
      Me.SecurityValidator.SetFailAction(Me.txtCustomerCode, Longkong.Pojjaman.Gui.Components.FailAction.None)
      Me.Validator.SetGotFocusBackColor(Me.txtCustomerCode, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtCustomerCode, System.Drawing.Color.Empty)
      Me.txtCustomerCode.Location = New System.Drawing.Point(88, 16)
      Me.Validator.SetMaxValue(Me.txtCustomerCode, "")
      Me.Validator.SetMinValue(Me.txtCustomerCode, "")
      Me.txtCustomerCode.Name = "txtCustomerCode"
      Me.Validator.SetRegularExpression(Me.txtCustomerCode, "")
      Me.Validator.SetRequired(Me.txtCustomerCode, True)
      Me.SecurityValidator.SetRequiredLevel(Me.txtCustomerCode, 0)
      Me.txtCustomerCode.Size = New System.Drawing.Size(132, 20)
      Me.txtCustomerCode.TabIndex = 1
      '
      'txtEmployeeName
      '
      Me.SecurityValidator.SetAccessId(Me.txtEmployeeName, 0)
      Me.txtEmployeeName.BackColor = System.Drawing.SystemColors.Control
      Me.Validator.SetDataType(Me.txtEmployeeName, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtEmployeeName, "")
      Me.SecurityValidator.SetFailAction(Me.txtEmployeeName, Longkong.Pojjaman.Gui.Components.FailAction.None)
      Me.Validator.SetGotFocusBackColor(Me.txtEmployeeName, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtEmployeeName, System.Drawing.Color.Empty)
      Me.txtEmployeeName.Location = New System.Drawing.Point(221, 40)
      Me.Validator.SetMaxValue(Me.txtEmployeeName, "")
      Me.Validator.SetMinValue(Me.txtEmployeeName, "")
      Me.txtEmployeeName.Name = "txtEmployeeName"
      Me.txtEmployeeName.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtEmployeeName, "")
      Me.Validator.SetRequired(Me.txtEmployeeName, False)
      Me.SecurityValidator.SetRequiredLevel(Me.txtEmployeeName, 0)
      Me.txtEmployeeName.Size = New System.Drawing.Size(226, 20)
      Me.txtEmployeeName.TabIndex = 10
      Me.txtEmployeeName.TabStop = False
      '
      'txtEmployeeCode
      '
      Me.SecurityValidator.SetAccessId(Me.txtEmployeeCode, 0)
      Me.txtEmployeeCode.BackColor = System.Drawing.SystemColors.Window
      Me.Validator.SetDataType(Me.txtEmployeeCode, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtEmployeeCode, "")
      Me.SecurityValidator.SetFailAction(Me.txtEmployeeCode, Longkong.Pojjaman.Gui.Components.FailAction.None)
      Me.Validator.SetGotFocusBackColor(Me.txtEmployeeCode, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtEmployeeCode, System.Drawing.Color.Empty)
      Me.txtEmployeeCode.Location = New System.Drawing.Point(88, 40)
      Me.Validator.SetMaxValue(Me.txtEmployeeCode, "")
      Me.Validator.SetMinValue(Me.txtEmployeeCode, "")
      Me.txtEmployeeCode.Name = "txtEmployeeCode"
      Me.Validator.SetRegularExpression(Me.txtEmployeeCode, "")
      Me.Validator.SetRequired(Me.txtEmployeeCode, True)
      Me.SecurityValidator.SetRequiredLevel(Me.txtEmployeeCode, 0)
      Me.txtEmployeeCode.Size = New System.Drawing.Size(132, 20)
      Me.txtEmployeeCode.TabIndex = 2
      '
      'ibtnShowCustomerDialog
      '
      Me.SecurityValidator.SetAccessId(Me.ibtnShowCustomerDialog, 0)
      Me.SecurityValidator.SetFailAction(Me.ibtnShowCustomerDialog, Longkong.Pojjaman.Gui.Components.FailAction.None)
      Me.ibtnShowCustomerDialog.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.ibtnShowCustomerDialog.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.ibtnShowCustomerDialog.ForeColor = System.Drawing.SystemColors.Control
      Me.ibtnShowCustomerDialog.Location = New System.Drawing.Point(471, 16)
      Me.ibtnShowCustomerDialog.Name = "ibtnShowCustomerDialog"
      Me.SecurityValidator.SetRequiredLevel(Me.ibtnShowCustomerDialog, 0)
      Me.ibtnShowCustomerDialog.Size = New System.Drawing.Size(24, 23)
      Me.ibtnShowCustomerDialog.TabIndex = 16
      Me.ibtnShowCustomerDialog.TabStop = False
      Me.ibtnShowCustomerDialog.ThemedImage = CType(resources.GetObject("ibtnShowCustomerDialog.ThemedImage"), System.Drawing.Bitmap)
      '
      'chkShowDetail
      '
      Me.SecurityValidator.SetAccessId(Me.chkShowDetail, 0)
      Me.SecurityValidator.SetFailAction(Me.chkShowDetail, Longkong.Pojjaman.Gui.Components.FailAction.None)
      Me.chkShowDetail.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.chkShowDetail.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.chkShowDetail.Location = New System.Drawing.Point(200, 96)
      Me.chkShowDetail.Name = "chkShowDetail"
      Me.SecurityValidator.SetRequiredLevel(Me.chkShowDetail, 0)
      Me.chkShowDetail.Size = New System.Drawing.Size(160, 24)
      Me.chkShowDetail.TabIndex = 4
      Me.chkShowDetail.Text = "Show Milestone Detail"
      '
      'chkAutorun
      '
      Me.SecurityValidator.SetAccessId(Me.chkAutorun, 0)
      Me.chkAutorun.Appearance = System.Windows.Forms.Appearance.Button
      Me.SecurityValidator.SetFailAction(Me.chkAutorun, Longkong.Pojjaman.Gui.Components.FailAction.None)
      Me.chkAutorun.Image = CType(resources.GetObject("chkAutorun.Image"), System.Drawing.Image)
      Me.chkAutorun.Location = New System.Drawing.Point(237, 7)
      Me.chkAutorun.Name = "chkAutorun"
      Me.SecurityValidator.SetRequiredLevel(Me.chkAutorun, 0)
      Me.chkAutorun.Size = New System.Drawing.Size(21, 21)
      Me.chkAutorun.TabIndex = 15
      '
      'dtpDocDate
      '
      Me.SecurityValidator.SetAccessId(Me.dtpDocDate, 0)
      Me.dtpDocDate.CustomFormat = "dd/MM/yyyy"
      Me.SecurityValidator.SetFailAction(Me.dtpDocDate, Longkong.Pojjaman.Gui.Components.FailAction.None)
      Me.dtpDocDate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.dtpDocDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
      Me.dtpDocDate.Location = New System.Drawing.Point(96, 32)
      Me.dtpDocDate.Name = "dtpDocDate"
      Me.SecurityValidator.SetRequiredLevel(Me.dtpDocDate, 0)
      Me.dtpDocDate.Size = New System.Drawing.Size(113, 21)
      Me.dtpDocDate.TabIndex = 17
      Me.dtpDocDate.TabStop = False
      '
      'ibtnDelRow
      '
      Me.SecurityValidator.SetAccessId(Me.ibtnDelRow, 0)
      Me.SecurityValidator.SetFailAction(Me.ibtnDelRow, Longkong.Pojjaman.Gui.Components.FailAction.None)
      Me.ibtnDelRow.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.ibtnDelRow.Location = New System.Drawing.Point(128, 95)
      Me.ibtnDelRow.Name = "ibtnDelRow"
      Me.SecurityValidator.SetRequiredLevel(Me.ibtnDelRow, 0)
      Me.ibtnDelRow.Size = New System.Drawing.Size(24, 24)
      Me.ibtnDelRow.TabIndex = 7
      Me.ibtnDelRow.TabStop = False
      Me.ibtnDelRow.ThemedImage = CType(resources.GetObject("ibtnDelRow.ThemedImage"), System.Drawing.Bitmap)
      '
      'imbMilestoneDetail
      '
      Me.SecurityValidator.SetAccessId(Me.imbMilestoneDetail, 0)
      Me.SecurityValidator.SetFailAction(Me.imbMilestoneDetail, Longkong.Pojjaman.Gui.Components.FailAction.None)
      Me.imbMilestoneDetail.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.imbMilestoneDetail.Location = New System.Drawing.Point(152, 95)
      Me.imbMilestoneDetail.Name = "imbMilestoneDetail"
      Me.SecurityValidator.SetRequiredLevel(Me.imbMilestoneDetail, 0)
      Me.imbMilestoneDetail.Size = New System.Drawing.Size(24, 24)
      Me.imbMilestoneDetail.TabIndex = 8
      Me.imbMilestoneDetail.TabStop = False
      Me.imbMilestoneDetail.ThemedImage = CType(resources.GetObject("imbMilestoneDetail.ThemedImage"), System.Drawing.Bitmap)
      '
      'grbCustomer
      '
      Me.SecurityValidator.SetAccessId(Me.grbCustomer, 0)
      Me.grbCustomer.Controls.Add(Me.lblCredit)
      Me.grbCustomer.Controls.Add(Me.lblDueDate)
      Me.grbCustomer.Controls.Add(Me.dtpDueDate)
      Me.grbCustomer.Controls.Add(Me.txtCreditPeriod)
      Me.grbCustomer.Controls.Add(Me.txtCustomerName)
      Me.grbCustomer.Controls.Add(Me.txtCustomerCode)
      Me.grbCustomer.Controls.Add(Me.lblCustomer)
      Me.grbCustomer.Controls.Add(Me.lblDay)
      Me.grbCustomer.Controls.Add(Me.ibtnShowCustomerDialog)
      Me.grbCustomer.Controls.Add(Me.ibtnShowEmployee)
      Me.grbCustomer.Controls.Add(Me.ibtnShowEmployeeDialog)
      Me.grbCustomer.Controls.Add(Me.txtEmployeeName)
      Me.grbCustomer.Controls.Add(Me.lblEmployee)
      Me.grbCustomer.Controls.Add(Me.txtEmployeeCode)
      Me.SecurityValidator.SetFailAction(Me.grbCustomer, Longkong.Pojjaman.Gui.Components.FailAction.None)
      Me.grbCustomer.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.grbCustomer.Location = New System.Drawing.Point(264, 0)
      Me.grbCustomer.Name = "grbCustomer"
      Me.SecurityValidator.SetRequiredLevel(Me.grbCustomer, 0)
      Me.grbCustomer.Size = New System.Drawing.Size(507, 96)
      Me.grbCustomer.TabIndex = 2
      Me.grbCustomer.TabStop = False
      Me.grbCustomer.Text = "Custumer"
      '
      'lblCredit
      '
      Me.SecurityValidator.SetAccessId(Me.lblCredit, 0)
      Me.SecurityValidator.SetFailAction(Me.lblCredit, Longkong.Pojjaman.Gui.Components.FailAction.None)
      Me.lblCredit.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblCredit.Location = New System.Drawing.Point(16, 64)
      Me.lblCredit.Name = "lblCredit"
      Me.SecurityValidator.SetRequiredLevel(Me.lblCredit, 0)
      Me.lblCredit.Size = New System.Drawing.Size(72, 18)
      Me.lblCredit.TabIndex = 7
      Me.lblCredit.Text = "Credit:"
      Me.lblCredit.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblDueDate
      '
      Me.SecurityValidator.SetAccessId(Me.lblDueDate, 0)
      Me.SecurityValidator.SetFailAction(Me.lblDueDate, Longkong.Pojjaman.Gui.Components.FailAction.None)
      Me.lblDueDate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblDueDate.Location = New System.Drawing.Point(176, 64)
      Me.lblDueDate.Name = "lblDueDate"
      Me.SecurityValidator.SetRequiredLevel(Me.lblDueDate, 0)
      Me.lblDueDate.Size = New System.Drawing.Size(88, 18)
      Me.lblDueDate.TabIndex = 12
      Me.lblDueDate.Text = "Due Date:"
      Me.lblDueDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'dtpDueDate
      '
      Me.SecurityValidator.SetAccessId(Me.dtpDueDate, 0)
      Me.dtpDueDate.CustomFormat = "dd/MM/yyyy"
      Me.dtpDueDate.Enabled = False
      Me.SecurityValidator.SetFailAction(Me.dtpDueDate, Longkong.Pojjaman.Gui.Components.FailAction.None)
      Me.dtpDueDate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.dtpDueDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
      Me.dtpDueDate.Location = New System.Drawing.Point(272, 64)
      Me.dtpDueDate.Name = "dtpDueDate"
      Me.SecurityValidator.SetRequiredLevel(Me.dtpDueDate, 0)
      Me.dtpDueDate.Size = New System.Drawing.Size(108, 21)
      Me.dtpDueDate.TabIndex = 13
      Me.dtpDueDate.TabStop = False
      '
      'lblCustomer
      '
      Me.SecurityValidator.SetAccessId(Me.lblCustomer, 0)
      Me.SecurityValidator.SetFailAction(Me.lblCustomer, Longkong.Pojjaman.Gui.Components.FailAction.None)
      Me.lblCustomer.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblCustomer.Location = New System.Drawing.Point(16, 16)
      Me.lblCustomer.Name = "lblCustomer"
      Me.SecurityValidator.SetRequiredLevel(Me.lblCustomer, 0)
      Me.lblCustomer.Size = New System.Drawing.Size(72, 18)
      Me.lblCustomer.TabIndex = 5
      Me.lblCustomer.Text = "Custumer:"
      Me.lblCustomer.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblDay
      '
      Me.SecurityValidator.SetAccessId(Me.lblDay, 0)
      Me.SecurityValidator.SetFailAction(Me.lblDay, Longkong.Pojjaman.Gui.Components.FailAction.None)
      Me.lblDay.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblDay.Location = New System.Drawing.Point(152, 64)
      Me.lblDay.Name = "lblDay"
      Me.SecurityValidator.SetRequiredLevel(Me.lblDay, 0)
      Me.lblDay.Size = New System.Drawing.Size(32, 18)
      Me.lblDay.TabIndex = 11
      Me.lblDay.Text = "Day"
      Me.lblDay.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      '
      'ibtnShowEmployee
      '
      Me.SecurityValidator.SetAccessId(Me.ibtnShowEmployee, 0)
      Me.SecurityValidator.SetFailAction(Me.ibtnShowEmployee, Longkong.Pojjaman.Gui.Components.FailAction.None)
      Me.ibtnShowEmployee.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.ibtnShowEmployee.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.ibtnShowEmployee.Location = New System.Drawing.Point(471, 40)
      Me.ibtnShowEmployee.Name = "ibtnShowEmployee"
      Me.SecurityValidator.SetRequiredLevel(Me.ibtnShowEmployee, 0)
      Me.ibtnShowEmployee.Size = New System.Drawing.Size(24, 23)
      Me.ibtnShowEmployee.TabIndex = 15
      Me.ibtnShowEmployee.TabStop = False
      Me.ibtnShowEmployee.ThemedImage = CType(resources.GetObject("ibtnShowEmployee.ThemedImage"), System.Drawing.Bitmap)
      '
      'ibtnShowEmployeeDialog
      '
      Me.SecurityValidator.SetAccessId(Me.ibtnShowEmployeeDialog, 0)
      Me.SecurityValidator.SetFailAction(Me.ibtnShowEmployeeDialog, Longkong.Pojjaman.Gui.Components.FailAction.None)
      Me.ibtnShowEmployeeDialog.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.ibtnShowEmployeeDialog.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.ibtnShowEmployeeDialog.ForeColor = System.Drawing.SystemColors.Control
      Me.ibtnShowEmployeeDialog.Location = New System.Drawing.Point(447, 40)
      Me.ibtnShowEmployeeDialog.Name = "ibtnShowEmployeeDialog"
      Me.SecurityValidator.SetRequiredLevel(Me.ibtnShowEmployeeDialog, 0)
      Me.ibtnShowEmployeeDialog.Size = New System.Drawing.Size(24, 23)
      Me.ibtnShowEmployeeDialog.TabIndex = 14
      Me.ibtnShowEmployeeDialog.TabStop = False
      Me.ibtnShowEmployeeDialog.ThemedImage = CType(resources.GetObject("ibtnShowEmployeeDialog.ThemedImage"), System.Drawing.Bitmap)
      '
      'lblEmployee
      '
      Me.SecurityValidator.SetAccessId(Me.lblEmployee, 0)
      Me.SecurityValidator.SetFailAction(Me.lblEmployee, Longkong.Pojjaman.Gui.Components.FailAction.None)
      Me.lblEmployee.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblEmployee.Location = New System.Drawing.Point(16, 40)
      Me.lblEmployee.Name = "lblEmployee"
      Me.SecurityValidator.SetRequiredLevel(Me.lblEmployee, 0)
      Me.lblEmployee.Size = New System.Drawing.Size(72, 18)
      Me.lblEmployee.TabIndex = 6
      Me.lblEmployee.Text = "Employee:"
      Me.lblEmployee.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'chkSingleVat
      '
      Me.SecurityValidator.SetAccessId(Me.chkSingleVat, 0)
      Me.SecurityValidator.SetFailAction(Me.chkSingleVat, Longkong.Pojjaman.Gui.Components.FailAction.None)
      Me.chkSingleVat.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.chkSingleVat.Location = New System.Drawing.Point(368, 96)
      Me.chkSingleVat.Name = "chkSingleVat"
      Me.SecurityValidator.SetRequiredLevel(Me.chkSingleVat, 0)
      Me.chkSingleVat.Size = New System.Drawing.Size(176, 24)
      Me.chkSingleVat.TabIndex = 5
      Me.chkSingleVat.Text = "Only Bill Issue"
      '
      'ibtnShowMilestone
      '
      Me.SecurityValidator.SetAccessId(Me.ibtnShowMilestone, 0)
      Me.SecurityValidator.SetFailAction(Me.ibtnShowMilestone, Longkong.Pojjaman.Gui.Components.FailAction.None)
      Me.ibtnShowMilestone.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.ibtnShowMilestone.Location = New System.Drawing.Point(104, 95)
      Me.ibtnShowMilestone.Name = "ibtnShowMilestone"
      Me.SecurityValidator.SetRequiredLevel(Me.ibtnShowMilestone, 0)
      Me.ibtnShowMilestone.Size = New System.Drawing.Size(24, 24)
      Me.ibtnShowMilestone.TabIndex = 23
      Me.ibtnShowMilestone.TabStop = False
      Me.ibtnShowMilestone.ThemedImage = CType(resources.GetObject("ibtnShowMilestone.ThemedImage"), System.Drawing.Bitmap)
      '
      'cmbCode
      '
      Me.SecurityValidator.SetAccessId(Me.cmbCode, 0)
      Me.SecurityValidator.SetFailAction(Me.cmbCode, Longkong.Pojjaman.Gui.Components.FailAction.None)
      Me.cmbCode.Location = New System.Drawing.Point(96, 8)
      Me.cmbCode.Name = "cmbCode"
      Me.SecurityValidator.SetRequiredLevel(Me.cmbCode, 0)
      Me.cmbCode.Size = New System.Drawing.Size(140, 21)
      Me.cmbCode.TabIndex = 24
      '
      'BillIssueDetail
      '
      Me.SecurityValidator.SetAccessId(Me, 0)
      Me.Controls.Add(Me.cmbCode)
      Me.Controls.Add(Me.ibtnShowMilestone)
      Me.Controls.Add(Me.grbCustomer)
      Me.Controls.Add(Me.imbMilestoneDetail)
      Me.Controls.Add(Me.ibtnDelRow)
      Me.Controls.Add(Me.txtDocDate)
      Me.Controls.Add(Me.dtpDocDate)
      Me.Controls.Add(Me.chkAutorun)
      Me.Controls.Add(Me.txtNote)
      Me.Controls.Add(Me.lblNote)
      Me.Controls.Add(Me.grbSummary)
      Me.Controls.Add(Me.tgItem)
      Me.Controls.Add(Me.lblItem)
      Me.Controls.Add(Me.lblDocDate)
      Me.Controls.Add(Me.lblCode)
      Me.Controls.Add(Me.chkShowDetail)
      Me.Controls.Add(Me.chkSingleVat)
      Me.SecurityValidator.SetFailAction(Me, Longkong.Pojjaman.Gui.Components.FailAction.None)
      Me.Name = "BillIssueDetail"
      Me.SecurityValidator.SetRequiredLevel(Me, 0)
      Me.Size = New System.Drawing.Size(808, 448)
      CType(Me.tgItem, System.ComponentModel.ISupportInitialize).EndInit()
      Me.grbSummary.ResumeLayout(False)
      Me.grbSummary.PerformLayout()
      CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
      Me.grbCustomer.ResumeLayout(False)
      Me.grbCustomer.PerformLayout()
      Me.ResumeLayout(False)
      Me.PerformLayout()

    End Sub

#End Region

#Region "Members"
    Private m_entity As BillIssue
    Private m_isInitialized As Boolean = False
    Private m_treeManager As TreeManager

    Private m_milestone As Milestone 'Selected
    Private m_tableInitialized As Boolean

    Private m_billableMilestones As MilestoneCollection

    Private m_tableStyleEnable As Hashtable
#End Region

#Region "Constructors"
    Public Sub New()
      MyBase.New()
      Me.InitializeComponent()
      Me.SetLabelText()
      Initialize()

      Dim dt As TreeTable = BillIssue.GetSchemaTable()
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
      dst.MappingName = "BillIssue"
      Dim myStringParserService As StringParserService = CType(ServiceManager.Services.GetService(GetType(StringParserService)), StringParserService)
      ' Items
      Dim csLineNumber As New TreeTextColumn
      csLineNumber.MappingName = "Linenumber"
      csLineNumber.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.BillIssueDetail.LineNumberHeaderText}")
      csLineNumber.NullText = ""
      csLineNumber.Width = 30
      csLineNumber.DataAlignment = HorizontalAlignment.Center
      csLineNumber.ReadOnly = True
      csLineNumber.TextBox.Name = "Linenumber"

      Dim csMileStone As New TreeTextColumn
      csMileStone.MappingName = "billii_milestone"
      csMileStone.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.BillIssueDetail.NameHeaderText}")
      csMileStone.NullText = ""
      csMileStone.Width = 200
      csMileStone.NullText = ""

      Dim csType As New TreeTextColumn
      csType.MappingName = "Type"
      csType.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.BillIssueDetail.TypeHeaderText}")
      csType.Width = 70
      csType.TextBox.Name = "Type"
      csType.ReadOnly = True
      csType.NullText = ""

      Dim csRealAmount As New TreeTextColumn
      csRealAmount.MappingName = "RealAmount"
      csRealAmount.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.BillIssueDetail.RealAmountHeaderText}")
      csRealAmount.NullText = ""
      csRealAmount.TextBox.Name = "RealAmount"
      csRealAmount.Format = "#,###.##"
      'csRealAmount.Alignment = HorizontalAlignment.Right
      csRealAmount.DataAlignment = HorizontalAlignment.Right
      csRealAmount.ReadOnly = True

      Dim csAdvancePayment As New TreeTextColumn
      csAdvancePayment.MappingName = "AdvancePayment"
      csAdvancePayment.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.BillIssueDetail.AdvancePaymentHeaderText}")
      csAdvancePayment.NullText = ""
      csAdvancePayment.TextBox.Name = "AdvancePayment"
      csAdvancePayment.Format = "#,###.##"
      'csAdvancePayment.Alignment = HorizontalAlignment.Right
      csAdvancePayment.DataAlignment = HorizontalAlignment.Right
      csAdvancePayment.ReadOnly = True

      Dim csDiscount As New TreeTextColumn
      csDiscount.MappingName = "Discount"
      csDiscount.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.BillIssueDetail.Discount}")
      csDiscount.NullText = ""
      csDiscount.TextBox.Name = "Discount"
      csDiscount.Format = "#,###.##"
      csDiscount.DataAlignment = HorizontalAlignment.Right
      csDiscount.ReadOnly = True

      Dim csRetention As New TreeTextColumn
      csRetention.MappingName = "Retention"
      csRetention.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.BillIssueDetail.RetentionHeaderText}")
      csRetention.NullText = ""
      csRetention.TextBox.Name = "Retention"
      csRetention.Format = "#,###.##"
      csRetention.DataAlignment = HorizontalAlignment.Right
      csRetention.ReadOnly = True

      Dim csPenalty As New TreeTextColumn
      csPenalty.MappingName = "Penalty"
      csPenalty.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.BillIssueDetail.PenaltyHeaderText}")
      csPenalty.NullText = ""
      csPenalty.TextBox.Name = "Penalty"
      csPenalty.Format = "#,###.##"
      csPenalty.DataAlignment = HorizontalAlignment.Right
      csPenalty.ReadOnly = True

      Dim csExcVATAmount As New TreeTextColumn
      csExcVATAmount.MappingName = "ExcVATAmount"
      csExcVATAmount.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.BillIssueDetail.ExcVATAmountHeaderText}")
      csExcVATAmount.NullText = ""
      csExcVATAmount.TextBox.Name = "ExcVATAmount"
      csExcVATAmount.Format = "#,###.##"
      csExcVATAmount.DataAlignment = HorizontalAlignment.Right
      csExcVATAmount.ReadOnly = True

      Dim csTaxBase As New TreeTextColumn
      csTaxBase.MappingName = "TaxBase"
      csTaxBase.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.BillIssueDetail.TaxBaseHeaderText}")
      csTaxBase.NullText = ""
      csTaxBase.TextBox.Name = "TaxBase"
      csTaxBase.Format = "#,###.##"
      csTaxBase.DataAlignment = HorizontalAlignment.Right
      csTaxBase.ReadOnly = True

      Dim csAmount As New TreeTextColumn
      csAmount.MappingName = "Amount"
      csAmount.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.BillIssueDetail.AmountHeaderText}")
      csAmount.NullText = ""
      csAmount.TextBox.Name = "Amount"
      csAmount.ReadOnly = True
      csAmount.DataAlignment = HorizontalAlignment.Right
      csAmount.Format = "#,###.##"

      dst.GridColumnStyles.Add(csLineNumber)
      dst.GridColumnStyles.Add(csMileStone)
      dst.GridColumnStyles.Add(csType)
      dst.GridColumnStyles.Add(csRealAmount)
      dst.GridColumnStyles.Add(csAdvancePayment)
      dst.GridColumnStyles.Add(csDiscount)
      dst.GridColumnStyles.Add(csRetention)
      dst.GridColumnStyles.Add(csPenalty)
      dst.GridColumnStyles.Add(csExcVATAmount)
      dst.GridColumnStyles.Add(csTaxBase)
      dst.GridColumnStyles.Add(csAmount)

      m_tableStyleEnable = New Hashtable
      For Each colStyle As DataGridColumnStyle In dst.GridColumnStyles
        m_tableStyleEnable.Add(colStyle, colStyle.ReadOnly)
      Next

      Return dst
    End Function
#End Region

#Region "Methods"
    Public Sub PopulateItemListing()
      Dim flag As Boolean = Me.m_tableInitialized
      Me.m_tableInitialized = False
      Me.m_entity.PopulateItemListing(Me.m_treeManager.Treetable, Me.chkShowDetail.Checked)
      RefreshBlankGrid()
      Me.m_tableInitialized = flag
      UpdateAmount()
    End Sub
#End Region

#Region "IListDetail"
    Public Overrides Sub CheckFormEnable()
      If Me.m_entity Is Nothing Then
        Return
      End If
      If Me.m_entity.Status.Value = 0 _
      OrElse Me.m_entity.Status.Value >= 3 _
      Then
        For Each ctrl As Control In Me.Controls
          ctrl.Enabled = False
        Next
        For Each colStyle As DataGridColumnStyle In Me.m_treeManager.GridTableStyle.GridColumnStyles
          colStyle.ReadOnly = True
        Next
      Else
        For Each ctrl As Control In Me.Controls
          ctrl.Enabled = True
        Next
        For Each colStyle As DataGridColumnStyle In Me.m_treeManager.GridTableStyle.GridColumnStyles
          colStyle.ReadOnly = CBool(m_tableStyleEnable(colStyle))
        Next
      End If
      tgItem.Enabled = True
      Me.chkShowDetail.Enabled = True
      Me.imbMilestoneDetail.Enabled = True
    End Sub
    Public Overrides Sub ClearDetail()
      Me.StatusBarService.SetMessage("")
      For Each crlt As Control In Me.grbSummary.Controls
        If crlt.Name.StartsWith("txt") Then
          crlt.Text = ""
        End If
      Next
      For Each crlt As Control In Me.grbCustomer.Controls
        If crlt.Name.StartsWith("txt") Then
          crlt.Text = ""
        End If
      Next
      For Each crlt As Control In Me.Controls
        If crlt.Name.StartsWith("txt") Then
          crlt.Text = ""
        End If
      Next
      Me.dtpDocDate.Value = Now
      Me.dtpDueDate.Value = Now
      Me.chkShowDetail.Checked = Me.m_entity.ShowDetail
    End Sub
    Public Overrides Sub SetLabelText()
      If Not m_entity Is Nothing Then Me.Text = Me.StringParserService.Parse(Me.m_entity.TabPageText)
      Me.lblDocDate.Text = Me.StringParserService.Parse("${res:Global.DocDateText}")

      Me.lblCode.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.BillIssueDetail.lblCode}")
      Me.Validator.SetDisplayName(Me.cmbCode, Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.BillIssueDetail.txtCodeAlert}"))

      Me.lblCustomer.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.BillIssueDetail.lblCustomer}")
      Me.Validator.SetDisplayName(Me.txtCustomerCode, Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.BillIssueDetail.txtCustomerCodeAlert}"))


      Me.lblItem.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.BillIssueDetail.lblItem}")
      Me.grbSummary.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.BillIssueDetail.grbSummary}")
      Me.lblItemCount.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.BillIssueDetail.lblItemCount}")
      Me.lblItemCountUnit.Text = Me.StringParserService.Parse("${res:Global.ItemCountUnitText}")
      Me.lblBaht.Text = Me.StringParserService.Parse("${res:Global.BahtText}")
      Me.lblTotalAmount.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.BillIssueDetail.lblTotalAmount}")
      Me.lblTotalReceivable.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.BillIssueDetail.lblTotalReceivable}")
      Me.lblNote.Text = Me.StringParserService.Parse("${res:Global.NoteText}")
      Me.lblCredit.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.BillIssueDetail.lblCredit}")

      Me.lblEmployee.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.BillIssueDetail.lblEmployee}")
      Me.Validator.SetDisplayName(Me.txtEmployeeCode, Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.BillIssueDetail.txtEmployeeCodeAlert}"))


      Me.chkSingleVat.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.BillIssueDetail.chkSingleVat}")
      Me.lblDueDate.Text = Me.StringParserService.Parse("${res:Global.DueDateText}")
      Me.lblDay.Text = Me.StringParserService.Parse("${res:Global.DayText}")
    End Sub
    Protected Overrides Sub EventWiring()

      AddHandler cmbCode.TextChanged, AddressOf Me.ChangeProperty
      AddHandler cmbCode.SelectedIndexChanged, AddressOf Me.ChangeProperty

      AddHandler txtNote.TextChanged, AddressOf Me.ChangeProperty

      AddHandler txtEmployeeCode.Validated, AddressOf Me.ChangeProperty

      AddHandler txtDocDate.Validated, AddressOf Me.ChangeProperty
      AddHandler dtpDocDate.ValueChanged, AddressOf Me.ChangeProperty

      AddHandler txtCreditPeriod.TextChanged, AddressOf Me.TextHandler
      AddHandler txtCreditPeriod.Validated, AddressOf Me.ChangeProperty

      AddHandler txtCustomerCode.Validated, AddressOf ChangeProperty

      AddHandler chkSingleVat.CheckedChanged, AddressOf Me.ChangeProperty

      RemoveHandler tgItem.DoubleClick, AddressOf CellDblClick
      AddHandler tgItem.DoubleClick, AddressOf CellDblClick
    End Sub
    Private txtCreditPeriodChanged As Boolean = False
    Private Sub TextHandler(ByVal sender As Object, ByVal e As EventArgs)
      If Me.m_entity Is Nothing Or Not m_isInitialized Then
        Return
      End If
      Select Case CType(sender, Control).Name.ToLower
        Case "txtcreditperiod"
          txtCreditPeriodChanged = True
      End Select
    End Sub
    Private m_oldInvoiceCode As String = ""
    Public Overrides Sub UpdateEntityProperties()
      m_isInitialized = False
      ClearDetail()
      If m_entity Is Nothing Then
        Return
      End If
      '------------------- CMBCode---------------
      cmbCode.Items.Clear()
      cmbCode.DropDownStyle = ComboBoxStyle.Simple
      cmbCode.Text = m_entity.Code
      '---------------cmcCode ---------------
      'txtCode.Text = m_entity.Code
      txtCreditPeriod.Text = Configuration.FormatToString(m_entity.CreditPeriod, DigitConfig.Int)
      txtNote.Text = m_entity.Note
      m_oldCode = m_entity.Code
      Me.chkAutorun.Checked = Me.m_entity.AutoGen
      Me.UpdateAutogenStatus()

      txtDocDate.Text = MinDateToNull(Me.m_entity.DocDate, Me.StringParserService.Parse("${res:Global.BlankDateText}"))
      dtpDocDate.Value = MinDateToNow(Me.m_entity.DocDate)

      Me.dtpDueDate.Value = MinDateToNow(Me.m_entity.DueDate)

      Me.txtEmployeeCode.Text = Me.m_entity.Employee.Code
      Me.txtEmployeeName.Text = Me.m_entity.Employee.Name

      Me.txtCustomerCode.Text = Me.m_entity.Customer.Code
      Me.txtCustomerName.Text = Me.m_entity.Customer.Name

      UpdateVat()

      'Load Items**********************************************************
      Me.PopulateItemListing()
      Me.Validator.DataTable = m_treeManager.Treetable
      '********************************************************************


      UpdateAmount()

      SetStatus()
      SetLabelText()
      CheckFormEnable()
      m_isInitialized = True
    End Sub
    Private Sub UpdateVat()
      'Vat
      If Configuration.Compare(Me.m_entity.Vat.TaxBase, Me.m_entity.GetMaximumTaxBase, DigitConfig.Price) <> 0 Then
        If Me.m_entity.SingleVat Then
          Me.m_entity.GenSingleVatItem()
        Else
          Me.m_entity.GenVatItems()
        End If
      Else
        If Me.m_entity.ItemCollection.Count = 1 AndAlso TypeOf Me.m_entity.ItemCollection(0) Is Milestone _
           AndAlso Me.m_entity.ItemCollection.GetAmount = 0 Then
          If Me.m_entity.Vat.ItemCollection.Count = 0 Then
            Me.m_entity.GenVatItems()
          End If
        End If
      End If
      Dim flag As Boolean = Me.WorkbenchWindow.ViewContent.IsDirty
      Me.WorkbenchWindow.ViewContent.IsDirty = False
      If Me.m_entity.NoVat Then
        Me.chkSingleVat.Enabled = False
        Me.m_entity.Vat.ItemCollection.Clear()
      Else
        Me.chkSingleVat.Enabled = True
        Me.chkSingleVat.Checked = Me.m_entity.SingleVat
      End If
      Me.WorkbenchWindow.ViewContent.IsDirty = flag
    End Sub
    Private m_dateSetting As Boolean = False
    Public Sub ChangeProperty(ByVal sender As Object, ByVal e As EventArgs)
      If Me.m_entity Is Nothing Or Not m_isInitialized Then
        Return
      End If
      Dim dirtyFlag As Boolean = False
      Select Case CType(sender, Control).Name.ToLower
        Case "chksinglevat"
          If Not Me.m_entity.NoVat Then
            If chkSingleVat.Checked Then
              Me.m_entity.GenSingleVatItem()
            Else
              Me.m_entity.GenVatItems()
            End If
            Me.m_entity.SingleVat = Me.chkSingleVat.Checked
            'UpdateVat()
          End If
          dirtyFlag = True
          'Case "txtcode"
          '  Me.m_entity.Code = txtCode.Text
          '  dirtyFlag = True
        Case "cmbcode"
          If m_entity.AutoGen Then
            'เพิ่ม AutoCode
            If TypeOf cmbCode.SelectedItem Is AutoCodeFormat Then
              Me.m_entity.AutoCodeFormat = CType(cmbCode.SelectedItem, AutoCodeFormat)
              Me.m_entity.Code = m_entity.AutoCodeFormat.Format
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
            Me.dtpDueDate.Value = MinDateToNow(Me.m_entity.DueDate)
            dirtyFlag = True
          End If
        Case "txtcustomercode"
          Customer.GetCustomer(txtCustomerCode, txtCustomerName, Me.m_entity.Customer)
          dirtyFlag = True
        Case "txtemployeecode"
          Employee.GetEmployee(txtEmployeeCode, txtEmployeeName, Me.m_entity.Employee)
          dirtyFlag = True
        Case Else
      End Select
      Me.WorkbenchWindow.ViewContent.IsDirty = Me.WorkbenchWindow.ViewContent.IsDirty Or dirtyFlag
      CheckFormEnable()
    End Sub
    Private Sub UpdateAmount()
      Dim flag As Boolean = Me.m_isInitialized
      m_isInitialized = False
      Me.txtTotalReceivable.Text = Configuration.FormatToString(Me.m_entity.RealBillIssueAmount, DigitConfig.Price)
      Me.txtTotalAmount.Text = Configuration.FormatToString(Me.m_entity.BillIssueAmount, DigitConfig.Price)
      Me.txtItemCount.Text = Configuration.FormatToString(Me.m_entity.ItemCollection.Count, DigitConfig.Int)
      m_isInitialized = flag
    End Sub
    Public Sub SetStatus()
       MyBase.SetStatusBarMessage()
    End Sub
    Public Overrides Property Entity() As BusinessLogic.ISimpleEntity
      Get
        Return Me.m_entity
      End Get
      Set(ByVal Value As BusinessLogic.ISimpleEntity)
        If Not Object.ReferenceEquals(Me.m_entity, Value) Then
          Me.m_entity = Nothing
          Me.m_entity = CType(Value, BillIssue)
        End If
        'Hack:
        If Not m_entity Is Nothing Then
          Me.m_entity.OnTabPageTextChanged(m_entity, EventArgs.Empty)
        End If
        UpdateEntityProperties()
      End Set
    End Property
    Public Overrides Sub Initialize()
      PopulateCombo()
    End Sub
    ' 
    Private Sub PopulateCombo()

    End Sub
#End Region

#Region "IValidatable"
    Public ReadOnly Property FormValidator() As components.PJMTextboxValidator Implements IValidatable.FormValidator
      Get
        Return Me.Validator
      End Get
    End Property
#End Region

#Region "ISecurityValidatable"
    Public Overrides ReadOnly Property FormSecurityValidator() As SecurityValidator
      Get
        Return Me.SecurityValidator
      End Get
    End Property
#End Region

#Region "Overrides"
    Public Overrides ReadOnly Property TabPageIcon() As String
      Get
        Return (New BillIssue).DetailPanelIcon
      End Get
    End Property
#End Region

    Private ReadOnly Property CurrentItem() As Milestone
      Get
        Dim row As TreeRow = Me.m_treeManager.SelectedRow
        If row Is Nothing Then
          Return Nothing
        End If
        If Not TypeOf row.Tag Is Milestone Then
          If TypeOf row.Tag Is Integer Then
            Dim mi As New Milestone
            mi.PMAId = CType(row.Tag, Integer)
            Return mi
          End If
          Return Nothing
        End If
        Return CType(row.Tag, Milestone)
      End Get
    End Property

#Region "Event of Button controls"
    Private Sub ibtnShowMilestone_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ibtnShowMilestone.Click
      Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
      If Me.m_entity Is Nothing Then
        Return
      End If
      If Me.m_entity.Customer Is Nothing OrElse Not Me.m_entity.Customer.Originated Then
        msgServ.ShowMessage("${res:Global.Error.SpecifyCustomer}")
        Return
      End If
      Dim dlg As New BasketDialog
      AddHandler dlg.EmptyBasket, AddressOf SetItems
      Dim filters() As Filter
      filters = New Filter() {New Filter("IDList", GetItemIDList) _
      , New Filter("mistatus", 3)}
      Dim entities As New ArrayList
      entities.Add(Me.m_entity.Customer)
      Dim view As New MilestoneSelectionView(Me.m_entity.Customer, New BasketDialog, filters, entities)
      dlg.Lists.Add(view)
      Dim myDialog As New Longkong.Pojjaman.Gui.Dialogs.PanelDockingDialog(view, dlg)
      myDialog.ShowDialog()
    End Sub
    Private Function GetItemIDList() As String
      Dim ret As String = ""
      For Each item As Milestone In Me.m_entity.ItemCollection
        ret &= item.Id.ToString & ","
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
      For i As Integer = items.Count - 1 To 0 Step -1
        Dim newItem As Milestone
        If TypeOf items(i) Is StockBasketItem Then
          Dim item As StockBasketItem = CType(items(i), StockBasketItem)
          Select Case item.FullClassName.ToLower
            Case "longkong.pojjaman.businesslogic.milestone"
              'เลือกมาจากใบวางบิลงวด
              newItem = CType(item.Tag, Milestone)
          End Select
        End If
        If Not newItem Is Nothing Then
          If i = items.Count - 1 Then
            'ตัวแรก -- update old item
            If Me.m_entity.ItemCollection.Count = 0 Then
              Me.m_entity.ItemCollection.Add(newItem)
            Else
              Dim mi As Milestone = Me.CurrentItem
              If Me.CurrentItem Is Nothing Then
                If index > Me.m_entity.ItemCollection.Count - 1 Then
                  Me.m_entity.ItemCollection.Add(newItem)
                  mi = newItem
                  insertIndex = Me.m_entity.ItemCollection.IndexOf(newItem)
                Else
                  Me.m_entity.ItemCollection.Insert(insertIndex, newItem)
                  mi = Me.m_entity.ItemCollection(insertIndex)
                End If
              End If
              mi.Id = newItem.Id
              mi.Code = newItem.Code
              mi.Amount = newItem.Amount
              mi.Date = newItem.Date
            End If
          Else
            Me.m_entity.ItemCollection.Insert(insertIndex, newItem)
          End If
        End If
      Next
      PopulateItemListing()
      tgItem.CurrentRowIndex = index
      UpdateAmount()
      UpdateVat()
    End Sub
    Private Sub ibtnShowCustomerDialog_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ibtnShowCustomerDialog.Click
      Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      myEntityPanelService.OpenListDialog(New Customer, AddressOf SetCustomer)
    End Sub
    Private Sub SetCustomer(ByVal e As ISimpleEntity)
      Me.txtCustomerCode.Text = e.Code
      Me.WorkbenchWindow.ViewContent.IsDirty = Me.WorkbenchWindow.ViewContent.IsDirty _
      Or Customer.GetCustomer(txtCustomerCode, txtCustomerName, Me.m_entity.Customer)
      Me.PopulateItemListing()
      UpdateVat()
    End Sub
    Private Sub ShowEmployee(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnShowEmployee.Click
      Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      myEntityPanelService.OpenPanel(New Employee)
    End Sub
    Private Sub ibtnShowEmployeeDialog_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnShowEmployeeDialog.Click
      Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      myEntityPanelService.OpenListDialog(New Employee, AddressOf SetEmployee)
    End Sub
    Private Sub SetEmployee(ByVal e As ISimpleEntity)
      Me.txtEmployeeCode.Text = e.Code
      Me.WorkbenchWindow.ViewContent.IsDirty = Me.WorkbenchWindow.ViewContent.IsDirty Or Employee.GetEmployee(txtEmployeeCode, txtEmployeeName, Me.m_entity.Employee)
    End Sub
#End Region

#Region "Event Handlers"
    Private Sub CellDblClick(ByVal sender As Object, ByVal e As System.EventArgs)

      Dim doc As Milestone = Me.CurrentItem

      'Dim dpar As IHasIBillablePerson = Me.CurrentParItem

      Dim docId As Integer = doc.PMAId
      Dim docType As Integer = 76

      'If doc Is Nothing AndAlso dpar Is Nothing Then
      '  Return
      'ElseIf Not dpar Is Nothing Then
      '  If TypeOf dpar Is SaleBillIssue Then
      '    docId = CType(dpar, SaleBillIssue).Id
      '    docType = 125
      '  ElseIf TypeOf dpar Is BillIssue Then
      '    docId = CType(dpar, BillIssue).Id
      '    docType = 81
      '  End If
      'Else
      '  docId = doc.Id
      '  docType = doc.EntityId
      'End If

      'If docType = 75 OrElse docType = 77 OrElse docType = 78 OrElse docType = 79 OrElse docType = 86 Then 'รับวางบิล Retention
      'Dim mi As New Milestone(docId)
      'docId = mi.PMAId
      'docType = 76
      'End If

      If docId > 0 AndAlso docType > 0 Then
        Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
        Dim en As SimpleBusinessEntityBase = SimpleBusinessEntityBase.GetEntity(Longkong.Pojjaman.BusinessLogic.Entity.GetFullClassName(docType), docId)
        myEntityPanelService.OpenDetailPanel(en)
      End If

    End Sub
    Private Sub chkAutorun_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkAutorun.CheckedChanged
      UpdateAutogenStatus()
    End Sub
    Private m_oldCode As String = ""
    Private Sub UpdateAutogenStatus()
      If Me.chkAutorun.Checked Then
        '--------------- cmb
        Me.cmbCode.DropDownStyle = ComboBoxStyle.DropDown
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
        Me.m_entity.Code = m_oldCode
        '------------------------- cmb
        'Me.Validator.SetRequired(Me.txtCode, False)
        'Me.ErrorProvider1.SetError(Me.txtCode, "")
        'Me.txtCode.ReadOnly = True
        'm_oldCode = Me.txtCode.Text
        'Me.txtCode.Text = BusinessLogic.Entity.GetAutoCodeFormat(Me.m_entity.EntityId)
        'Hack: set Code เป็น "" เอง
        'Me.m_entity.Code = ""
        Me.m_entity.AutoGen = True
      Else
        Me.cmbCode.DropDownStyle = ComboBoxStyle.Simple
        Me.cmbCode.Items.Clear()
        Me.cmbCode.Text = m_oldCode
        Me.m_entity.AutoGen = False

        'Me.Validator.SetRequired(Me.txtCode, True)
        'Me.txtCode.Text = m_oldCode
        'Me.txtCode.ReadOnly = False
        'Me.m_entity.AutoGen = False
      End If
    End Sub
    Private m_oldRow As TreeRow
    Private Sub tgItem_CurrentCellChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tgItem.CurrentCellChanged
      SetCurrentMileStone()
    End Sub
    Private Sub SetCurrentMileStone()
      Try
        Dim theRow As TreeRow = m_treeManager.SelectedRow
        If m_oldRow Is theRow Then
          Return
        End If
        m_milestone = Nothing
        If TypeOf theRow.Tag Is Milestone Then
          m_milestone = CType(theRow.Tag, Milestone)
        End If
        m_oldRow = m_treeManager.SelectedRow
      Catch ex As Exception
        'MessageBox.Show(ex.ToString)
      End Try
    End Sub
    Private Sub UpdateItemRow()
      Dim row As TreeRow = Me.m_treeManager.SelectedRow
      If row Is Nothing Then
        Return
      End If
      If Me.m_milestone Is Nothing Then
        Return
      End If
      Me.m_tableInitialized = False
      row("Type") = m_milestone.Type.Value
      row("Code") = m_milestone.Code
      row("Autogen") = m_milestone.AutoGen
      row("Name") = m_milestone.Name
      row("DocDate") = m_milestone.DocDate
      row("HandedDate") = m_milestone.HandedDate
      row("BillIssueDate") = m_milestone.BillIssueDate

      Select Case m_milestone.Type.Value
        Case 75
          'ผ่าน
          row("Advance") = Configuration.FormatToString(m_milestone.Advance, DigitConfig.Price)
          row("Retention") = Configuration.FormatToString(m_milestone.Retention, DigitConfig.Price)
          row("Discount") = m_milestone.Discount.Rate
          row("Penalty") = Configuration.FormatToString(m_milestone.Penalty, DigitConfig.Price)
        Case 78, 79 'เพิ่ม /ลด
          row("Advance") = ""
          row("Retention") = ""
          row("Discount") = m_milestone.Discount.Rate
          row("Penalty") = Configuration.FormatToString(m_milestone.Penalty, DigitConfig.Price)
        Case Else
          row("Advance") = ""
          row("Retention") = ""
          row("Discount") = ""
          row("Penalty") = ""
      End Select

      row("RealAmount") = Configuration.FormatToString(m_milestone.MileStoneAmount, DigitConfig.Price)
      row("Amount") = Configuration.FormatToString(m_milestone.Amount, DigitConfig.Price)
      row("Status") = m_milestone.Status.Value
      row("Note") = m_milestone.Note
      Me.m_tableInitialized = True
    End Sub
    Private Sub ibtnDelRow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnDelRow.Click
      Dim index As Integer = Me.tgItem.CurrentRowIndex
      If Me.m_milestone Is Nothing Then
        Return
      End If
      Me.m_entity.ItemCollection.Remove(m_milestone)
      Dim pma As PaymentApplication '= Me.m_entity.PaymentApplication
      If Not pma Is Nothing Then
        For Each item As Milestone In pma.ItemCollection
          If m_milestone.Originated And m_milestone.Id = item.Id Then
            If item.Status.Value = 4 Then
              item.Status.Value = 3
            End If
          End If
        Next
      End If
      Me.PopulateItemListing()
      Me.WorkbenchWindow.ViewContent.IsDirty = True
      Me.tgItem.CurrentRowIndex = Math.Min(Math.Max(0, index), Me.m_treeManager.Treetable.Childs.Count - 1)

      SetCurrentMileStone()
    End Sub
    Private Sub chkShowDetail_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkShowDetail.CheckedChanged
      Me.m_entity.ShowDetail = chkShowDetail.Checked
      PopulateItemListing()
    End Sub
    Private Sub imbMilestoneDetail_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles imbMilestoneDetail.Click
      If Me.m_milestone Is Nothing Then
        Return
      End If
      Dim view As New MilestoneDetail
      view.Entity = m_milestone
      Dim dlg As New Longkong.Pojjaman.Gui.Dialogs.PanelDialog(view)
      dlg.ShowDialog()
      'Me.UpdateItemRow()
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
              'Me.SetSupplierDialog(entity)
          End Select
        End If
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
    'Private Sub AddBlankRow(ByVal number As Integer)
    '    For i As Integer = 0 To number - 1
    '        Me.m_treeManager.Treetable.Childs.Add()
    '    Next
    'End Sub
    Private Sub RefreshBlankGrid()
      If Me.tgItem.Height = 0 Then
        Return
      End If
      Dim dirtyFlag As Boolean = Me.WorkbenchWindow.ViewContent.IsDirty
      Dim index As Integer = tgItem.CurrentRowIndex
      Dim maxVisibleCount As Integer
      Dim tgRowHeight As Integer = tgItem.PreferredRowHeight '17
      maxVisibleCount = CInt(Math.Floor((Me.tgItem.Height - tgRowHeight) / tgRowHeight))
      Do While Me.m_treeManager.Treetable.Rows.Count < maxVisibleCount - 1
        'เพิ่มแถวจนเต็ม
        Me.m_treeManager.Treetable.Childs.Add()
      Loop
      Me.m_treeManager.Treetable.AcceptChanges()
      If Me.m_treeManager.Treetable.Rows.Count > 0 Then
        tgItem.CurrentRowIndex = Math.Max(0, index)
      End If
      Me.WorkbenchWindow.ViewContent.IsDirty = dirtyFlag
    End Sub
#End Region

	End Class
End Namespace