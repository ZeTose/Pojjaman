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
  Public Class PaymentApplicationDetail
    Inherits AbstractEntityDetailPanelView
    'Inherits UserControl
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
    Friend WithEvents txtCostCenterCode As System.Windows.Forms.TextBox
    Friend WithEvents lblCustomer As System.Windows.Forms.Label
    Friend WithEvents grbDetail As FixedGroupBox
    Friend WithEvents lblInc As System.Windows.Forms.Label
    Friend WithEvents txtInc As System.Windows.Forms.TextBox
    Friend WithEvents lblDe As System.Windows.Forms.Label
    Friend WithEvents txtDe As System.Windows.Forms.TextBox
    Friend WithEvents lblTotal As System.Windows.Forms.Label
    Friend WithEvents lblItem As System.Windows.Forms.Label
    Friend WithEvents lblPenalty As System.Windows.Forms.Label
    Friend WithEvents txtPenalty As System.Windows.Forms.TextBox
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents Validator As Longkong.Pojjaman.Gui.Components.PJMTextboxValidator
    Friend WithEvents grbPaymentApplication As FixedGroupBox
    Friend WithEvents lblFinish As System.Windows.Forms.Label
    Friend WithEvents txtDuration As System.Windows.Forms.TextBox
    Friend WithEvents lblDuration As System.Windows.Forms.Label
    Friend WithEvents cmbDurationUnit As System.Windows.Forms.ComboBox
    Friend WithEvents cmbTaxType As System.Windows.Forms.ComboBox
    Friend WithEvents lblTaxType As System.Windows.Forms.Label
    Friend WithEvents cmbTaxPoint As System.Windows.Forms.ComboBox
    Friend WithEvents lblTaxPoint As System.Windows.Forms.Label
    Friend WithEvents ibtnBlank As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents ibtnDelRow As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents ibtnDistributeAdvr As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents ibtnDistributeRetention As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents txtCustomerCode As System.Windows.Forms.TextBox
    Friend WithEvents txtCustomerName As System.Windows.Forms.TextBox
    Friend WithEvents txtCostCenterName As System.Windows.Forms.TextBox
    Friend WithEvents lblPenaltyUnit As System.Windows.Forms.Label
    Friend WithEvents ibtnShowProject As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents ibtnShowProjectDialog As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents lblBudgetUnit As System.Windows.Forms.Label
    Friend WithEvents lblBudget As System.Windows.Forms.Label
    Friend WithEvents txtBudget As System.Windows.Forms.TextBox
    Friend WithEvents dtpCompletionDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpStartDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblStart As System.Windows.Forms.Label
    Friend WithEvents txtTotalAmount As System.Windows.Forms.TextBox
    Friend WithEvents lblTotalAmountUnit As System.Windows.Forms.Label
    Friend WithEvents lblDiscount As System.Windows.Forms.Label
    Friend WithEvents txtDiscountAmount As System.Windows.Forms.TextBox
    Friend WithEvents lblDiscountUnit As System.Windows.Forms.Label
    Friend WithEvents lblValueUnit As System.Windows.Forms.Label
    Friend WithEvents txtTaxRate As System.Windows.Forms.TextBox
    Friend WithEvents lblPercent As System.Windows.Forms.Label
    Friend WithEvents lblIncUnit As System.Windows.Forms.Label
    Friend WithEvents lblDeUnit As System.Windows.Forms.Label
    Friend WithEvents lblBOQ As System.Windows.Forms.Label
    Friend WithEvents txtAdvr As System.Windows.Forms.TextBox
    Friend WithEvents lblAdvr As System.Windows.Forms.Label
    Friend WithEvents lblAdvrUnit As System.Windows.Forms.Label
    Friend WithEvents lblRetention As System.Windows.Forms.Label
    Friend WithEvents txtRetention As System.Windows.Forms.TextBox
    Friend WithEvents lblRetentionUnit As System.Windows.Forms.Label
    Friend WithEvents cmbItemType As System.Windows.Forms.ComboBox
    Friend WithEvents txtItemCode As System.Windows.Forms.TextBox
    Friend WithEvents lblItemType As System.Windows.Forms.Label
    Friend WithEvents lblItemCode As System.Windows.Forms.Label
    Friend WithEvents txtItemName As System.Windows.Forms.TextBox
    Friend WithEvents lblItemName As System.Windows.Forms.Label
    Friend WithEvents txtItemRealAmount As System.Windows.Forms.TextBox
    Friend WithEvents lblItemRealAmount As System.Windows.Forms.Label
    Friend WithEvents lblItemStatus As System.Windows.Forms.Label
    Friend WithEvents txtItemAdvr As System.Windows.Forms.TextBox
    Friend WithEvents lblItemAdvr As System.Windows.Forms.Label
    Friend WithEvents txtItemRetention As System.Windows.Forms.TextBox
    Friend WithEvents lblItemRetention As System.Windows.Forms.Label
    Friend WithEvents cmbItemStatus As System.Windows.Forms.ComboBox
    Friend WithEvents txtStartDate As System.Windows.Forms.TextBox
    Friend WithEvents txtCompletionDate As System.Windows.Forms.TextBox
    Friend WithEvents ibnShowBOQDialog As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents txtBOQCode As System.Windows.Forms.TextBox
    Friend WithEvents dtpItemDocDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblItemDocDate As System.Windows.Forms.Label
    Friend WithEvents dtpItemHandedDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblItemHandedDate As System.Windows.Forms.Label
    Friend WithEvents lblItemBillIssueDate As System.Windows.Forms.Label
    Friend WithEvents dtpItemBillIssueDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtItemAmount As System.Windows.Forms.TextBox
    Friend WithEvents lblItemAmount As System.Windows.Forms.Label
    Friend WithEvents txtItemPenalty As System.Windows.Forms.TextBox
    Friend WithEvents lblItemPenalty As System.Windows.Forms.Label
    Friend WithEvents txtItemDocDate As System.Windows.Forms.TextBox
    Friend WithEvents txtItemHandedDate As System.Windows.Forms.TextBox
    Friend WithEvents txtItemBillIssueDate As System.Windows.Forms.TextBox
    Friend WithEvents txtItemNote As System.Windows.Forms.TextBox
    Friend WithEvents lblItemNote As System.Windows.Forms.Label
    Friend WithEvents grbTax As FixedGroupBox
    Friend WithEvents grbAdvrRetention As FixedGroupBox
    Friend WithEvents grbContract As FixedGroupBox
    Friend WithEvents lblContractAmount As System.Windows.Forms.Label
    Friend WithEvents txtContractAmount As System.Windows.Forms.TextBox
    Friend WithEvents tgItem As Longkong.Pojjaman.Gui.Components.TreeGrid
    Friend WithEvents imbMilestoneDetail As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents txtItemDiscount As System.Windows.Forms.TextBox
    Friend WithEvents lblItemDiscount As System.Windows.Forms.Label
    Friend WithEvents ibtnHand As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents ibtnCancelHand As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents chkAutorun As System.Windows.Forms.CheckBox
    Friend WithEvents txtAdvrPercent As System.Windows.Forms.TextBox
    Friend WithEvents txtRetentionPercent As System.Windows.Forms.TextBox
    Friend WithEvents txtItemReceiveDate As System.Windows.Forms.TextBox
    Friend WithEvents lblItemReceiveDate As System.Windows.Forms.Label
    Friend WithEvents dtpItemReceiveDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents ibtnCopyMe As Longkong.Pojjaman.Gui.Components.ImageButton
    <System.Diagnostics.DebuggerStepThrough()> Protected Sub InitializeComponent()
      Me.components = New System.ComponentModel.Container()
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(PaymentApplicationDetail))
      Me.grbDetail = New Longkong.Pojjaman.Gui.Components.FixedGroupBox()
      Me.ibtnCopyMe = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.grbContract = New Longkong.Pojjaman.Gui.Components.FixedGroupBox()
      Me.lblDe = New System.Windows.Forms.Label()
      Me.lblTotal = New System.Windows.Forms.Label()
      Me.lblBudget = New System.Windows.Forms.Label()
      Me.lblValueUnit = New System.Windows.Forms.Label()
      Me.lblBudgetUnit = New System.Windows.Forms.Label()
      Me.chkAutorun = New System.Windows.Forms.CheckBox()
      Me.txtCompletionDate = New System.Windows.Forms.TextBox()
      Me.txtStartDate = New System.Windows.Forms.TextBox()
      Me.lblDeUnit = New System.Windows.Forms.Label()
      Me.txtBudget = New System.Windows.Forms.TextBox()
      Me.txtDe = New System.Windows.Forms.TextBox()
      Me.dtpCompletionDate = New System.Windows.Forms.DateTimePicker()
      Me.lblFinish = New System.Windows.Forms.Label()
      Me.dtpStartDate = New System.Windows.Forms.DateTimePicker()
      Me.lblStart = New System.Windows.Forms.Label()
      Me.txtDuration = New System.Windows.Forms.TextBox()
      Me.lblDuration = New System.Windows.Forms.Label()
      Me.cmbDurationUnit = New System.Windows.Forms.ComboBox()
      Me.txtTotalAmount = New System.Windows.Forms.TextBox()
      Me.lblDiscount = New System.Windows.Forms.Label()
      Me.txtDiscountAmount = New System.Windows.Forms.TextBox()
      Me.lblDiscountUnit = New System.Windows.Forms.Label()
      Me.lblInc = New System.Windows.Forms.Label()
      Me.lblTotalAmountUnit = New System.Windows.Forms.Label()
      Me.lblContractAmount = New System.Windows.Forms.Label()
      Me.txtContractAmount = New System.Windows.Forms.TextBox()
      Me.lblPenalty = New System.Windows.Forms.Label()
      Me.txtPenalty = New System.Windows.Forms.TextBox()
      Me.lblPenaltyUnit = New System.Windows.Forms.Label()
      Me.lblIncUnit = New System.Windows.Forms.Label()
      Me.txtInc = New System.Windows.Forms.TextBox()
      Me.grbAdvrRetention = New Longkong.Pojjaman.Gui.Components.FixedGroupBox()
      Me.txtAdvr = New System.Windows.Forms.TextBox()
      Me.ibtnDistributeRetention = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.ibtnDistributeAdvr = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.lblAdvr = New System.Windows.Forms.Label()
      Me.lblAdvrUnit = New System.Windows.Forms.Label()
      Me.txtRetention = New System.Windows.Forms.TextBox()
      Me.lblRetentionUnit = New System.Windows.Forms.Label()
      Me.lblRetention = New System.Windows.Forms.Label()
      Me.txtAdvrPercent = New System.Windows.Forms.TextBox()
      Me.txtRetentionPercent = New System.Windows.Forms.TextBox()
      Me.grbTax = New Longkong.Pojjaman.Gui.Components.FixedGroupBox()
      Me.cmbTaxPoint = New System.Windows.Forms.ComboBox()
      Me.lblTaxPoint = New System.Windows.Forms.Label()
      Me.txtTaxRate = New System.Windows.Forms.TextBox()
      Me.lblPercent = New System.Windows.Forms.Label()
      Me.cmbTaxType = New System.Windows.Forms.ComboBox()
      Me.lblTaxType = New System.Windows.Forms.Label()
      Me.txtCustomerCode = New System.Windows.Forms.TextBox()
      Me.lblCustomer = New System.Windows.Forms.Label()
      Me.lblProject = New System.Windows.Forms.Label()
      Me.txtCostCenterCode = New System.Windows.Forms.TextBox()
      Me.txtCustomerName = New System.Windows.Forms.TextBox()
      Me.txtCostCenterName = New System.Windows.Forms.TextBox()
      Me.ibtnShowProject = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.ibtnShowProjectDialog = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.lblBOQ = New System.Windows.Forms.Label()
      Me.ibnShowBOQDialog = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.txtBOQCode = New System.Windows.Forms.TextBox()
      Me.lblItem = New System.Windows.Forms.Label()
      Me.grbPaymentApplication = New Longkong.Pojjaman.Gui.Components.FixedGroupBox()
      Me.txtItemReceiveDate = New System.Windows.Forms.TextBox()
      Me.lblItemReceiveDate = New System.Windows.Forms.Label()
      Me.dtpItemReceiveDate = New System.Windows.Forms.DateTimePicker()
      Me.txtItemDiscount = New System.Windows.Forms.TextBox()
      Me.tgItem = New Longkong.Pojjaman.Gui.Components.TreeGrid()
      Me.txtItemBillIssueDate = New System.Windows.Forms.TextBox()
      Me.txtItemHandedDate = New System.Windows.Forms.TextBox()
      Me.txtItemDocDate = New System.Windows.Forms.TextBox()
      Me.ibtnBlank = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.ibtnDelRow = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.cmbItemType = New System.Windows.Forms.ComboBox()
      Me.dtpItemDocDate = New System.Windows.Forms.DateTimePicker()
      Me.lblItemDocDate = New System.Windows.Forms.Label()
      Me.dtpItemHandedDate = New System.Windows.Forms.DateTimePicker()
      Me.lblItemHandedDate = New System.Windows.Forms.Label()
      Me.txtItemCode = New System.Windows.Forms.TextBox()
      Me.lblItemType = New System.Windows.Forms.Label()
      Me.lblItemCode = New System.Windows.Forms.Label()
      Me.txtItemName = New System.Windows.Forms.TextBox()
      Me.lblItemName = New System.Windows.Forms.Label()
      Me.txtItemRealAmount = New System.Windows.Forms.TextBox()
      Me.lblItemRealAmount = New System.Windows.Forms.Label()
      Me.lblItemStatus = New System.Windows.Forms.Label()
      Me.lblItemBillIssueDate = New System.Windows.Forms.Label()
      Me.dtpItemBillIssueDate = New System.Windows.Forms.DateTimePicker()
      Me.txtItemAdvr = New System.Windows.Forms.TextBox()
      Me.lblItemAdvr = New System.Windows.Forms.Label()
      Me.txtItemRetention = New System.Windows.Forms.TextBox()
      Me.lblItemRetention = New System.Windows.Forms.Label()
      Me.txtItemAmount = New System.Windows.Forms.TextBox()
      Me.lblItemAmount = New System.Windows.Forms.Label()
      Me.txtItemPenalty = New System.Windows.Forms.TextBox()
      Me.lblItemPenalty = New System.Windows.Forms.Label()
      Me.cmbItemStatus = New System.Windows.Forms.ComboBox()
      Me.txtItemNote = New System.Windows.Forms.TextBox()
      Me.lblItemNote = New System.Windows.Forms.Label()
      Me.imbMilestoneDetail = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.lblItemDiscount = New System.Windows.Forms.Label()
      Me.ibtnHand = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.ibtnCancelHand = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
      Me.Validator = New Longkong.Pojjaman.Gui.Components.PJMTextboxValidator(Me.components)
      Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
      Me.grbDetail.SuspendLayout()
      Me.grbContract.SuspendLayout()
      Me.grbAdvrRetention.SuspendLayout()
      Me.grbTax.SuspendLayout()
      Me.grbPaymentApplication.SuspendLayout()
      CType(Me.tgItem, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.SuspendLayout()
      '
      'grbDetail
      '
      Me.grbDetail.Controls.Add(Me.ibtnCopyMe)
      Me.grbDetail.Controls.Add(Me.grbContract)
      Me.grbDetail.Controls.Add(Me.grbAdvrRetention)
      Me.grbDetail.Controls.Add(Me.grbTax)
      Me.grbDetail.Controls.Add(Me.txtCustomerCode)
      Me.grbDetail.Controls.Add(Me.lblCustomer)
      Me.grbDetail.Controls.Add(Me.lblProject)
      Me.grbDetail.Controls.Add(Me.txtCostCenterCode)
      Me.grbDetail.Controls.Add(Me.txtCustomerName)
      Me.grbDetail.Controls.Add(Me.txtCostCenterName)
      Me.grbDetail.Controls.Add(Me.ibtnShowProject)
      Me.grbDetail.Controls.Add(Me.ibtnShowProjectDialog)
      Me.grbDetail.Controls.Add(Me.lblBOQ)
      Me.grbDetail.Controls.Add(Me.ibnShowBOQDialog)
      Me.grbDetail.Controls.Add(Me.txtBOQCode)
      Me.grbDetail.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.grbDetail.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.grbDetail.Location = New System.Drawing.Point(0, 8)
      Me.grbDetail.Name = "grbDetail"
      Me.grbDetail.Size = New System.Drawing.Size(768, 200)
      Me.grbDetail.TabIndex = 0
      Me.grbDetail.TabStop = False
      Me.grbDetail.Text = "ข้อมูลโครงการ"
      '
      'ibtnCopyMe
      '
      Me.ibtnCopyMe.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.ibtnCopyMe.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.ibtnCopyMe.ForeColor = System.Drawing.SystemColors.Control
      Me.ibtnCopyMe.Location = New System.Drawing.Point(488, 16)
      Me.ibtnCopyMe.Name = "ibtnCopyMe"
      Me.ibtnCopyMe.Size = New System.Drawing.Size(24, 23)
      Me.ibtnCopyMe.TabIndex = 14
      Me.ibtnCopyMe.TabStop = False
      Me.ibtnCopyMe.ThemedImage = CType(resources.GetObject("ibtnCopyMe.ThemedImage"), System.Drawing.Bitmap)
      '
      'grbContract
      '
      Me.grbContract.Controls.Add(Me.lblDe)
      Me.grbContract.Controls.Add(Me.lblTotal)
      Me.grbContract.Controls.Add(Me.lblBudget)
      Me.grbContract.Controls.Add(Me.lblValueUnit)
      Me.grbContract.Controls.Add(Me.lblBudgetUnit)
      Me.grbContract.Controls.Add(Me.chkAutorun)
      Me.grbContract.Controls.Add(Me.txtCompletionDate)
      Me.grbContract.Controls.Add(Me.txtStartDate)
      Me.grbContract.Controls.Add(Me.lblDeUnit)
      Me.grbContract.Controls.Add(Me.txtBudget)
      Me.grbContract.Controls.Add(Me.txtDe)
      Me.grbContract.Controls.Add(Me.dtpCompletionDate)
      Me.grbContract.Controls.Add(Me.lblFinish)
      Me.grbContract.Controls.Add(Me.dtpStartDate)
      Me.grbContract.Controls.Add(Me.lblStart)
      Me.grbContract.Controls.Add(Me.txtDuration)
      Me.grbContract.Controls.Add(Me.lblDuration)
      Me.grbContract.Controls.Add(Me.cmbDurationUnit)
      Me.grbContract.Controls.Add(Me.txtTotalAmount)
      Me.grbContract.Controls.Add(Me.lblDiscount)
      Me.grbContract.Controls.Add(Me.txtDiscountAmount)
      Me.grbContract.Controls.Add(Me.lblDiscountUnit)
      Me.grbContract.Controls.Add(Me.lblInc)
      Me.grbContract.Controls.Add(Me.lblTotalAmountUnit)
      Me.grbContract.Controls.Add(Me.lblContractAmount)
      Me.grbContract.Controls.Add(Me.txtContractAmount)
      Me.grbContract.Controls.Add(Me.lblPenalty)
      Me.grbContract.Controls.Add(Me.txtPenalty)
      Me.grbContract.Controls.Add(Me.lblPenaltyUnit)
      Me.grbContract.Controls.Add(Me.lblIncUnit)
      Me.grbContract.Controls.Add(Me.txtInc)
      Me.grbContract.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.grbContract.Location = New System.Drawing.Point(8, 64)
      Me.grbContract.Name = "grbContract"
      Me.grbContract.Size = New System.Drawing.Size(472, 128)
      Me.grbContract.TabIndex = 2
      Me.grbContract.TabStop = False
      Me.grbContract.Text = "รายละเอียดสัญญา"
      '
      'lblDe
      '
      Me.lblDe.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblDe.Location = New System.Drawing.Point(248, 81)
      Me.lblDe.Name = "lblDe"
      Me.lblDe.Size = New System.Drawing.Size(96, 16)
      Me.lblDe.TabIndex = 22
      Me.lblDe.Text = "มูลค่างานลด:"
      Me.lblDe.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblTotal
      '
      Me.lblTotal.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblTotal.Location = New System.Drawing.Point(248, 101)
      Me.lblTotal.Name = "lblTotal"
      Me.lblTotal.Size = New System.Drawing.Size(96, 18)
      Me.lblTotal.TabIndex = 27
      Me.lblTotal.Text = "มูลค่างานทั้งหมด:"
      Me.lblTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblBudget
      '
      Me.lblBudget.BackColor = System.Drawing.Color.Transparent
      Me.lblBudget.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblBudget.Location = New System.Drawing.Point(8, 77)
      Me.lblBudget.Name = "lblBudget"
      Me.lblBudget.Size = New System.Drawing.Size(96, 24)
      Me.lblBudget.TabIndex = 20
      Me.lblBudget.Text = "Forecasted Budget:"
      Me.lblBudget.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblValueUnit
      '
      Me.lblValueUnit.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblValueUnit.Location = New System.Drawing.Point(216, 101)
      Me.lblValueUnit.Name = "lblValueUnit"
      Me.lblValueUnit.Size = New System.Drawing.Size(32, 18)
      Me.lblValueUnit.TabIndex = 26
      Me.lblValueUnit.Text = "บาท"
      Me.lblValueUnit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      '
      'lblBudgetUnit
      '
      Me.lblBudgetUnit.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblBudgetUnit.Location = New System.Drawing.Point(216, 80)
      Me.lblBudgetUnit.Name = "lblBudgetUnit"
      Me.lblBudgetUnit.Size = New System.Drawing.Size(32, 18)
      Me.lblBudgetUnit.TabIndex = 21
      Me.lblBudgetUnit.Text = "บาท"
      Me.lblBudgetUnit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      '
      'chkAutorun
      '
      Me.chkAutorun.Appearance = System.Windows.Forms.Appearance.Button
      Me.chkAutorun.Image = CType(resources.GetObject("chkAutorun.Image"), System.Drawing.Image)
      Me.chkAutorun.Location = New System.Drawing.Point(192, 80)
      Me.chkAutorun.Name = "chkAutorun"
      Me.chkAutorun.Size = New System.Drawing.Size(21, 21)
      Me.chkAutorun.TabIndex = 30
      '
      'txtCompletionDate
      '
      Me.Validator.SetDataType(Me.txtCompletionDate, Longkong.Pojjaman.Gui.Components.DataTypeConstants.DateTimeType)
      Me.Validator.SetDisplayName(Me.txtCompletionDate, "")
      Me.txtCompletionDate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtCompletionDate, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtCompletionDate, System.Drawing.Color.Empty)
      Me.txtCompletionDate.Location = New System.Drawing.Point(104, 58)
      Me.Validator.SetMinValue(Me.txtCompletionDate, "")
      Me.txtCompletionDate.Name = "txtCompletionDate"
      Me.Validator.SetRegularExpression(Me.txtCompletionDate, "")
      Me.Validator.SetRequired(Me.txtCompletionDate, False)
      Me.txtCompletionDate.Size = New System.Drawing.Size(78, 21)
      Me.txtCompletionDate.TabIndex = 3
      '
      'txtStartDate
      '
      Me.Validator.SetDataType(Me.txtStartDate, Longkong.Pojjaman.Gui.Components.DataTypeConstants.DateTimeType)
      Me.Validator.SetDisplayName(Me.txtStartDate, "")
      Me.txtStartDate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtStartDate, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtStartDate, System.Drawing.Color.Empty)
      Me.txtStartDate.Location = New System.Drawing.Point(104, 16)
      Me.Validator.SetMinValue(Me.txtStartDate, "")
      Me.txtStartDate.Name = "txtStartDate"
      Me.Validator.SetRegularExpression(Me.txtStartDate, "")
      Me.Validator.SetRequired(Me.txtStartDate, False)
      Me.txtStartDate.Size = New System.Drawing.Size(78, 21)
      Me.txtStartDate.TabIndex = 0
      '
      'lblDeUnit
      '
      Me.lblDeUnit.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblDeUnit.Location = New System.Drawing.Point(432, 81)
      Me.lblDeUnit.Name = "lblDeUnit"
      Me.lblDeUnit.Size = New System.Drawing.Size(32, 16)
      Me.lblDeUnit.TabIndex = 24
      Me.lblDeUnit.Text = "บาท"
      Me.lblDeUnit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      '
      'txtBudget
      '
      Me.Validator.SetDataType(Me.txtBudget, Longkong.Pojjaman.Gui.Components.DataTypeConstants.DecimalType)
      Me.Validator.SetDisplayName(Me.txtBudget, "")
      Me.Validator.SetGotFocusBackColor(Me.txtBudget, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtBudget, System.Drawing.Color.Empty)
      Me.txtBudget.Location = New System.Drawing.Point(104, 79)
      Me.Validator.SetMinValue(Me.txtBudget, "")
      Me.txtBudget.Name = "txtBudget"
      Me.Validator.SetRegularExpression(Me.txtBudget, "")
      Me.Validator.SetRequired(Me.txtBudget, False)
      Me.txtBudget.Size = New System.Drawing.Size(88, 21)
      Me.txtBudget.TabIndex = 4
      Me.txtBudget.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'txtDe
      '
      Me.txtDe.BackColor = System.Drawing.SystemColors.Control
      Me.Validator.SetDataType(Me.txtDe, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtDe, "")
      Me.Validator.SetGotFocusBackColor(Me.txtDe, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtDe, System.Drawing.Color.Empty)
      Me.txtDe.Location = New System.Drawing.Point(344, 79)
      Me.Validator.SetMinValue(Me.txtDe, "")
      Me.txtDe.Name = "txtDe"
      Me.txtDe.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtDe, "")
      Me.Validator.SetRequired(Me.txtDe, False)
      Me.txtDe.Size = New System.Drawing.Size(88, 21)
      Me.txtDe.TabIndex = 23
      Me.txtDe.TabStop = False
      Me.txtDe.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'dtpCompletionDate
      '
      Me.dtpCompletionDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
      Me.dtpCompletionDate.Location = New System.Drawing.Point(104, 58)
      Me.dtpCompletionDate.Name = "dtpCompletionDate"
      Me.dtpCompletionDate.Size = New System.Drawing.Size(96, 21)
      Me.dtpCompletionDate.TabIndex = 19
      Me.dtpCompletionDate.TabStop = False
      '
      'lblFinish
      '
      Me.lblFinish.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblFinish.Location = New System.Drawing.Point(8, 59)
      Me.lblFinish.Name = "lblFinish"
      Me.lblFinish.Size = New System.Drawing.Size(96, 18)
      Me.lblFinish.TabIndex = 15
      Me.lblFinish.Text = "Completion Date:"
      Me.lblFinish.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'dtpStartDate
      '
      Me.dtpStartDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
      Me.dtpStartDate.Location = New System.Drawing.Point(104, 16)
      Me.dtpStartDate.Name = "dtpStartDate"
      Me.dtpStartDate.Size = New System.Drawing.Size(96, 21)
      Me.dtpStartDate.TabIndex = 7
      Me.dtpStartDate.TabStop = False
      '
      'lblStart
      '
      Me.lblStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblStart.Location = New System.Drawing.Point(8, 17)
      Me.lblStart.Name = "lblStart"
      Me.lblStart.Size = New System.Drawing.Size(96, 18)
      Me.lblStart.TabIndex = 6
      Me.lblStart.Text = "วันเริ่มต้น:"
      Me.lblStart.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'txtDuration
      '
      Me.Validator.SetDataType(Me.txtDuration, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtDuration, "")
      Me.Validator.SetGotFocusBackColor(Me.txtDuration, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtDuration, System.Drawing.Color.Empty)
      Me.txtDuration.Location = New System.Drawing.Point(104, 37)
      Me.Validator.SetMinValue(Me.txtDuration, "")
      Me.txtDuration.Name = "txtDuration"
      Me.Validator.SetRegularExpression(Me.txtDuration, "")
      Me.Validator.SetRequired(Me.txtDuration, False)
      Me.txtDuration.Size = New System.Drawing.Size(40, 21)
      Me.txtDuration.TabIndex = 1
      '
      'lblDuration
      '
      Me.lblDuration.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblDuration.Location = New System.Drawing.Point(8, 38)
      Me.lblDuration.Name = "lblDuration"
      Me.lblDuration.Size = New System.Drawing.Size(96, 18)
      Me.lblDuration.TabIndex = 11
      Me.lblDuration.Text = "ระยะเวลา:"
      Me.lblDuration.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'cmbDurationUnit
      '
      Me.cmbDurationUnit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbDurationUnit.Location = New System.Drawing.Point(144, 37)
      Me.cmbDurationUnit.Name = "cmbDurationUnit"
      Me.cmbDurationUnit.Size = New System.Drawing.Size(56, 21)
      Me.cmbDurationUnit.TabIndex = 2
      '
      'txtTotalAmount
      '
      Me.txtTotalAmount.BackColor = System.Drawing.SystemColors.Control
      Me.Validator.SetDataType(Me.txtTotalAmount, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtTotalAmount, "")
      Me.Validator.SetGotFocusBackColor(Me.txtTotalAmount, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtTotalAmount, System.Drawing.Color.Empty)
      Me.txtTotalAmount.Location = New System.Drawing.Point(344, 100)
      Me.Validator.SetMinValue(Me.txtTotalAmount, "")
      Me.txtTotalAmount.Name = "txtTotalAmount"
      Me.txtTotalAmount.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtTotalAmount, "")
      Me.Validator.SetRequired(Me.txtTotalAmount, False)
      Me.txtTotalAmount.Size = New System.Drawing.Size(88, 21)
      Me.txtTotalAmount.TabIndex = 28
      Me.txtTotalAmount.TabStop = False
      Me.txtTotalAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'lblDiscount
      '
      Me.lblDiscount.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblDiscount.Location = New System.Drawing.Point(248, 17)
      Me.lblDiscount.Name = "lblDiscount"
      Me.lblDiscount.Size = New System.Drawing.Size(96, 18)
      Me.lblDiscount.TabIndex = 8
      Me.lblDiscount.Text = "รวมส่วนลด:"
      Me.lblDiscount.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'txtDiscountAmount
      '
      Me.txtDiscountAmount.BackColor = System.Drawing.SystemColors.Control
      Me.Validator.SetDataType(Me.txtDiscountAmount, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtDiscountAmount, "")
      Me.Validator.SetGotFocusBackColor(Me.txtDiscountAmount, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtDiscountAmount, System.Drawing.Color.Empty)
      Me.txtDiscountAmount.Location = New System.Drawing.Point(344, 16)
      Me.Validator.SetMinValue(Me.txtDiscountAmount, "")
      Me.txtDiscountAmount.Name = "txtDiscountAmount"
      Me.txtDiscountAmount.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtDiscountAmount, "")
      Me.Validator.SetRequired(Me.txtDiscountAmount, False)
      Me.txtDiscountAmount.Size = New System.Drawing.Size(88, 21)
      Me.txtDiscountAmount.TabIndex = 9
      Me.txtDiscountAmount.TabStop = False
      Me.txtDiscountAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'lblDiscountUnit
      '
      Me.lblDiscountUnit.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblDiscountUnit.Location = New System.Drawing.Point(432, 17)
      Me.lblDiscountUnit.Name = "lblDiscountUnit"
      Me.lblDiscountUnit.Size = New System.Drawing.Size(32, 18)
      Me.lblDiscountUnit.TabIndex = 10
      Me.lblDiscountUnit.Text = "บาท"
      Me.lblDiscountUnit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      '
      'lblInc
      '
      Me.lblInc.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblInc.Location = New System.Drawing.Point(248, 60)
      Me.lblInc.Name = "lblInc"
      Me.lblInc.Size = New System.Drawing.Size(96, 16)
      Me.lblInc.TabIndex = 16
      Me.lblInc.Text = "มูลค่างานเพิ่ม:"
      Me.lblInc.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblTotalAmountUnit
      '
      Me.lblTotalAmountUnit.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblTotalAmountUnit.Location = New System.Drawing.Point(432, 101)
      Me.lblTotalAmountUnit.Name = "lblTotalAmountUnit"
      Me.lblTotalAmountUnit.Size = New System.Drawing.Size(32, 18)
      Me.lblTotalAmountUnit.TabIndex = 29
      Me.lblTotalAmountUnit.Text = "บาท"
      Me.lblTotalAmountUnit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      '
      'lblContractAmount
      '
      Me.lblContractAmount.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblContractAmount.Location = New System.Drawing.Point(8, 101)
      Me.lblContractAmount.Name = "lblContractAmount"
      Me.lblContractAmount.Size = New System.Drawing.Size(96, 18)
      Me.lblContractAmount.TabIndex = 25
      Me.lblContractAmount.Text = "Contract Amount:"
      Me.lblContractAmount.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'txtContractAmount
      '
      Me.Validator.SetDataType(Me.txtContractAmount, Longkong.Pojjaman.Gui.Components.DataTypeConstants.DecimalType)
      Me.Validator.SetDisplayName(Me.txtContractAmount, "")
      Me.Validator.SetGotFocusBackColor(Me.txtContractAmount, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtContractAmount, System.Drawing.Color.Empty)
      Me.txtContractAmount.Location = New System.Drawing.Point(104, 100)
      Me.Validator.SetMinValue(Me.txtContractAmount, "")
      Me.txtContractAmount.Name = "txtContractAmount"
      Me.Validator.SetRegularExpression(Me.txtContractAmount, "")
      Me.Validator.SetRequired(Me.txtContractAmount, False)
      Me.txtContractAmount.Size = New System.Drawing.Size(112, 21)
      Me.txtContractAmount.TabIndex = 5
      Me.txtContractAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'lblPenalty
      '
      Me.lblPenalty.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblPenalty.Location = New System.Drawing.Point(248, 39)
      Me.lblPenalty.Name = "lblPenalty"
      Me.lblPenalty.Size = New System.Drawing.Size(96, 16)
      Me.lblPenalty.TabIndex = 12
      Me.lblPenalty.Text = "ค่าปรับรวม:"
      Me.lblPenalty.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'txtPenalty
      '
      Me.txtPenalty.BackColor = System.Drawing.SystemColors.Control
      Me.Validator.SetDataType(Me.txtPenalty, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtPenalty, "")
      Me.Validator.SetGotFocusBackColor(Me.txtPenalty, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtPenalty, System.Drawing.Color.Empty)
      Me.txtPenalty.Location = New System.Drawing.Point(344, 37)
      Me.Validator.SetMinValue(Me.txtPenalty, "")
      Me.txtPenalty.Name = "txtPenalty"
      Me.txtPenalty.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtPenalty, "")
      Me.Validator.SetRequired(Me.txtPenalty, False)
      Me.txtPenalty.Size = New System.Drawing.Size(88, 21)
      Me.txtPenalty.TabIndex = 13
      Me.txtPenalty.TabStop = False
      Me.txtPenalty.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'lblPenaltyUnit
      '
      Me.lblPenaltyUnit.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblPenaltyUnit.Location = New System.Drawing.Point(432, 39)
      Me.lblPenaltyUnit.Name = "lblPenaltyUnit"
      Me.lblPenaltyUnit.Size = New System.Drawing.Size(32, 16)
      Me.lblPenaltyUnit.TabIndex = 14
      Me.lblPenaltyUnit.Text = "บาท"
      Me.lblPenaltyUnit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      '
      'lblIncUnit
      '
      Me.lblIncUnit.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblIncUnit.Location = New System.Drawing.Point(432, 60)
      Me.lblIncUnit.Name = "lblIncUnit"
      Me.lblIncUnit.Size = New System.Drawing.Size(32, 16)
      Me.lblIncUnit.TabIndex = 18
      Me.lblIncUnit.Text = "บาท"
      Me.lblIncUnit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      '
      'txtInc
      '
      Me.txtInc.BackColor = System.Drawing.SystemColors.Control
      Me.Validator.SetDataType(Me.txtInc, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtInc, "")
      Me.Validator.SetGotFocusBackColor(Me.txtInc, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtInc, System.Drawing.Color.Empty)
      Me.txtInc.Location = New System.Drawing.Point(344, 58)
      Me.Validator.SetMinValue(Me.txtInc, "")
      Me.txtInc.Name = "txtInc"
      Me.txtInc.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtInc, "")
      Me.Validator.SetRequired(Me.txtInc, False)
      Me.txtInc.Size = New System.Drawing.Size(88, 21)
      Me.txtInc.TabIndex = 17
      Me.txtInc.TabStop = False
      Me.txtInc.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'grbAdvrRetention
      '
      Me.grbAdvrRetention.Controls.Add(Me.txtAdvr)
      Me.grbAdvrRetention.Controls.Add(Me.ibtnDistributeRetention)
      Me.grbAdvrRetention.Controls.Add(Me.ibtnDistributeAdvr)
      Me.grbAdvrRetention.Controls.Add(Me.lblAdvr)
      Me.grbAdvrRetention.Controls.Add(Me.lblAdvrUnit)
      Me.grbAdvrRetention.Controls.Add(Me.txtRetention)
      Me.grbAdvrRetention.Controls.Add(Me.lblRetentionUnit)
      Me.grbAdvrRetention.Controls.Add(Me.lblRetention)
      Me.grbAdvrRetention.Controls.Add(Me.txtAdvrPercent)
      Me.grbAdvrRetention.Controls.Add(Me.txtRetentionPercent)
      Me.grbAdvrRetention.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.grbAdvrRetention.Location = New System.Drawing.Point(480, 120)
      Me.grbAdvrRetention.Name = "grbAdvrRetention"
      Me.grbAdvrRetention.Size = New System.Drawing.Size(280, 72)
      Me.grbAdvrRetention.TabIndex = 5
      Me.grbAdvrRetention.TabStop = False
      Me.grbAdvrRetention.Text = "จัดการมัดจำและ Retention"
      '
      'txtAdvr
      '
      Me.Validator.SetDataType(Me.txtAdvr, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtAdvr, "")
      Me.Validator.SetGotFocusBackColor(Me.txtAdvr, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtAdvr, System.Drawing.Color.Empty)
      Me.txtAdvr.Location = New System.Drawing.Point(72, 16)
      Me.Validator.SetMinValue(Me.txtAdvr, "")
      Me.txtAdvr.Name = "txtAdvr"
      Me.Validator.SetRegularExpression(Me.txtAdvr, "")
      Me.Validator.SetRequired(Me.txtAdvr, False)
      Me.txtAdvr.Size = New System.Drawing.Size(104, 21)
      Me.txtAdvr.TabIndex = 0
      Me.txtAdvr.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'ibtnDistributeRetention
      '
      Me.ibtnDistributeRetention.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.ibtnDistributeRetention.Location = New System.Drawing.Point(256, 40)
      Me.ibtnDistributeRetention.Name = "ibtnDistributeRetention"
      Me.ibtnDistributeRetention.Size = New System.Drawing.Size(21, 21)
      Me.ibtnDistributeRetention.TabIndex = 11
      Me.ibtnDistributeRetention.TabStop = False
      Me.ibtnDistributeRetention.ThemedImage = CType(resources.GetObject("ibtnDistributeRetention.ThemedImage"), System.Drawing.Bitmap)
      Me.ToolTip1.SetToolTip(Me.ibtnDistributeRetention, "กระจาย Retention เท่ากันทุกรายการ")
      '
      'ibtnDistributeAdvr
      '
      Me.ibtnDistributeAdvr.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.ibtnDistributeAdvr.Location = New System.Drawing.Point(256, 16)
      Me.ibtnDistributeAdvr.Name = "ibtnDistributeAdvr"
      Me.ibtnDistributeAdvr.Size = New System.Drawing.Size(21, 21)
      Me.ibtnDistributeAdvr.TabIndex = 10
      Me.ibtnDistributeAdvr.TabStop = False
      Me.ibtnDistributeAdvr.ThemedImage = CType(resources.GetObject("ibtnDistributeAdvr.ThemedImage"), System.Drawing.Bitmap)
      Me.ToolTip1.SetToolTip(Me.ibtnDistributeAdvr, "กระจายมัดจำเท่ากันทุกรายการ")
      '
      'lblAdvr
      '
      Me.lblAdvr.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblAdvr.Location = New System.Drawing.Point(24, 16)
      Me.lblAdvr.Name = "lblAdvr"
      Me.lblAdvr.Size = New System.Drawing.Size(48, 18)
      Me.lblAdvr.TabIndex = 2
      Me.lblAdvr.Text = "มัดจำ:"
      Me.lblAdvr.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblAdvrUnit
      '
      Me.lblAdvrUnit.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblAdvrUnit.Location = New System.Drawing.Point(176, 16)
      Me.lblAdvrUnit.Name = "lblAdvrUnit"
      Me.lblAdvrUnit.Size = New System.Drawing.Size(32, 18)
      Me.lblAdvrUnit.TabIndex = 8
      Me.lblAdvrUnit.Text = "บาท"
      Me.lblAdvrUnit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      '
      'txtRetention
      '
      Me.Validator.SetDataType(Me.txtRetention, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtRetention, "")
      Me.Validator.SetGotFocusBackColor(Me.txtRetention, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtRetention, System.Drawing.Color.Empty)
      Me.txtRetention.Location = New System.Drawing.Point(72, 40)
      Me.Validator.SetMinValue(Me.txtRetention, "")
      Me.txtRetention.Name = "txtRetention"
      Me.Validator.SetRegularExpression(Me.txtRetention, "")
      Me.Validator.SetRequired(Me.txtRetention, False)
      Me.txtRetention.Size = New System.Drawing.Size(104, 21)
      Me.txtRetention.TabIndex = 1
      Me.txtRetention.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'lblRetentionUnit
      '
      Me.lblRetentionUnit.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblRetentionUnit.Location = New System.Drawing.Point(176, 40)
      Me.lblRetentionUnit.Name = "lblRetentionUnit"
      Me.lblRetentionUnit.Size = New System.Drawing.Size(32, 18)
      Me.lblRetentionUnit.TabIndex = 9
      Me.lblRetentionUnit.Text = "บาท"
      Me.lblRetentionUnit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      '
      'lblRetention
      '
      Me.lblRetention.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblRetention.Location = New System.Drawing.Point(16, 40)
      Me.lblRetention.Name = "lblRetention"
      Me.lblRetention.Size = New System.Drawing.Size(56, 18)
      Me.lblRetention.TabIndex = 3
      Me.lblRetention.Text = "Retention:"
      Me.lblRetention.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'txtAdvrPercent
      '
      Me.txtAdvrPercent.BackColor = System.Drawing.SystemColors.Control
      Me.Validator.SetDataType(Me.txtAdvrPercent, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtAdvrPercent, "")
      Me.Validator.SetGotFocusBackColor(Me.txtAdvrPercent, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtAdvrPercent, System.Drawing.Color.Empty)
      Me.txtAdvrPercent.Location = New System.Drawing.Point(208, 16)
      Me.Validator.SetMinValue(Me.txtAdvrPercent, "")
      Me.txtAdvrPercent.Name = "txtAdvrPercent"
      Me.txtAdvrPercent.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtAdvrPercent, "")
      Me.Validator.SetRequired(Me.txtAdvrPercent, False)
      Me.txtAdvrPercent.Size = New System.Drawing.Size(48, 21)
      Me.txtAdvrPercent.TabIndex = 4
      Me.txtAdvrPercent.TabStop = False
      '
      'txtRetentionPercent
      '
      Me.txtRetentionPercent.BackColor = System.Drawing.SystemColors.Control
      Me.Validator.SetDataType(Me.txtRetentionPercent, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtRetentionPercent, "")
      Me.Validator.SetGotFocusBackColor(Me.txtRetentionPercent, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtRetentionPercent, System.Drawing.Color.Empty)
      Me.txtRetentionPercent.Location = New System.Drawing.Point(208, 40)
      Me.Validator.SetMinValue(Me.txtRetentionPercent, "")
      Me.txtRetentionPercent.Name = "txtRetentionPercent"
      Me.txtRetentionPercent.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtRetentionPercent, "")
      Me.Validator.SetRequired(Me.txtRetentionPercent, False)
      Me.txtRetentionPercent.Size = New System.Drawing.Size(48, 21)
      Me.txtRetentionPercent.TabIndex = 4
      Me.txtRetentionPercent.TabStop = False
      '
      'grbTax
      '
      Me.grbTax.Controls.Add(Me.cmbTaxPoint)
      Me.grbTax.Controls.Add(Me.lblTaxPoint)
      Me.grbTax.Controls.Add(Me.txtTaxRate)
      Me.grbTax.Controls.Add(Me.lblPercent)
      Me.grbTax.Controls.Add(Me.cmbTaxType)
      Me.grbTax.Controls.Add(Me.lblTaxType)
      Me.grbTax.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.grbTax.Location = New System.Drawing.Point(480, 40)
      Me.grbTax.Name = "grbTax"
      Me.grbTax.Size = New System.Drawing.Size(280, 72)
      Me.grbTax.TabIndex = 3
      Me.grbTax.TabStop = False
      Me.grbTax.Text = "ภาษีของงวด"
      '
      'cmbTaxPoint
      '
      Me.cmbTaxPoint.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbTaxPoint.Location = New System.Drawing.Point(72, 16)
      Me.cmbTaxPoint.Name = "cmbTaxPoint"
      Me.cmbTaxPoint.Size = New System.Drawing.Size(184, 21)
      Me.cmbTaxPoint.TabIndex = 0
      '
      'lblTaxPoint
      '
      Me.lblTaxPoint.BackColor = System.Drawing.Color.Transparent
      Me.lblTaxPoint.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblTaxPoint.Location = New System.Drawing.Point(0, 16)
      Me.lblTaxPoint.Name = "lblTaxPoint"
      Me.lblTaxPoint.Size = New System.Drawing.Size(74, 18)
      Me.lblTaxPoint.TabIndex = 2
      Me.lblTaxPoint.Text = "Tax point:"
      Me.lblTaxPoint.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'txtTaxRate
      '
      Me.txtTaxRate.BackColor = System.Drawing.SystemColors.Control
      Me.Validator.SetDataType(Me.txtTaxRate, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtTaxRate, "")
      Me.Validator.SetGotFocusBackColor(Me.txtTaxRate, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtTaxRate, System.Drawing.Color.Empty)
      Me.txtTaxRate.Location = New System.Drawing.Point(184, 40)
      Me.Validator.SetMinValue(Me.txtTaxRate, "")
      Me.txtTaxRate.Name = "txtTaxRate"
      Me.txtTaxRate.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtTaxRate, "")
      Me.Validator.SetRequired(Me.txtTaxRate, False)
      Me.txtTaxRate.Size = New System.Drawing.Size(48, 21)
      Me.txtTaxRate.TabIndex = 4
      Me.txtTaxRate.TabStop = False
      '
      'lblPercent
      '
      Me.lblPercent.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblPercent.Location = New System.Drawing.Point(232, 40)
      Me.lblPercent.Name = "lblPercent"
      Me.lblPercent.Size = New System.Drawing.Size(16, 18)
      Me.lblPercent.TabIndex = 5
      Me.lblPercent.Text = "%"
      Me.lblPercent.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      '
      'cmbTaxType
      '
      Me.cmbTaxType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbTaxType.Location = New System.Drawing.Point(72, 40)
      Me.cmbTaxType.Name = "cmbTaxType"
      Me.cmbTaxType.Size = New System.Drawing.Size(112, 21)
      Me.cmbTaxType.TabIndex = 1
      '
      'lblTaxType
      '
      Me.lblTaxType.BackColor = System.Drawing.Color.Transparent
      Me.lblTaxType.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblTaxType.Location = New System.Drawing.Point(0, 40)
      Me.lblTaxType.Name = "lblTaxType"
      Me.lblTaxType.Size = New System.Drawing.Size(74, 18)
      Me.lblTaxType.TabIndex = 3
      Me.lblTaxType.Text = "ประเภทภาษี:"
      Me.lblTaxType.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'txtCustomerCode
      '
      Me.txtCustomerCode.BackColor = System.Drawing.SystemColors.Control
      Me.Validator.SetDataType(Me.txtCustomerCode, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtCustomerCode, "")
      Me.txtCustomerCode.Enabled = False
      Me.Validator.SetGotFocusBackColor(Me.txtCustomerCode, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtCustomerCode, System.Drawing.Color.Empty)
      Me.txtCustomerCode.Location = New System.Drawing.Point(96, 40)
      Me.Validator.SetMinValue(Me.txtCustomerCode, "")
      Me.txtCustomerCode.Name = "txtCustomerCode"
      Me.txtCustomerCode.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtCustomerCode, "")
      Me.Validator.SetRequired(Me.txtCustomerCode, False)
      Me.txtCustomerCode.Size = New System.Drawing.Size(88, 21)
      Me.txtCustomerCode.TabIndex = 8
      '
      'lblCustomer
      '
      Me.lblCustomer.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblCustomer.Location = New System.Drawing.Point(8, 40)
      Me.lblCustomer.Name = "lblCustomer"
      Me.lblCustomer.Size = New System.Drawing.Size(88, 18)
      Me.lblCustomer.TabIndex = 7
      Me.lblCustomer.Text = "ลูกค้า:"
      Me.lblCustomer.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblProject
      '
      Me.lblProject.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblProject.Location = New System.Drawing.Point(8, 16)
      Me.lblProject.Name = "lblProject"
      Me.lblProject.Size = New System.Drawing.Size(88, 18)
      Me.lblProject.TabIndex = 6
      Me.lblProject.Text = "โครงการก่อสร้าง:"
      Me.lblProject.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'txtCostCenterCode
      '
      Me.Validator.SetDataType(Me.txtCostCenterCode, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtCostCenterCode, "")
      Me.Validator.SetGotFocusBackColor(Me.txtCostCenterCode, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtCostCenterCode, -15)
      Me.Validator.SetInvalidBackColor(Me.txtCostCenterCode, System.Drawing.Color.Empty)
      Me.txtCostCenterCode.Location = New System.Drawing.Point(96, 16)
      Me.Validator.SetMinValue(Me.txtCostCenterCode, "")
      Me.txtCostCenterCode.Name = "txtCostCenterCode"
      Me.Validator.SetRegularExpression(Me.txtCostCenterCode, "")
      Me.Validator.SetRequired(Me.txtCostCenterCode, True)
      Me.txtCostCenterCode.Size = New System.Drawing.Size(88, 21)
      Me.txtCostCenterCode.TabIndex = 0
      '
      'txtCustomerName
      '
      Me.txtCustomerName.BackColor = System.Drawing.SystemColors.Control
      Me.Validator.SetDataType(Me.txtCustomerName, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtCustomerName, "")
      Me.txtCustomerName.Enabled = False
      Me.Validator.SetGotFocusBackColor(Me.txtCustomerName, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtCustomerName, System.Drawing.Color.Empty)
      Me.txtCustomerName.Location = New System.Drawing.Point(184, 40)
      Me.Validator.SetMinValue(Me.txtCustomerName, "")
      Me.txtCustomerName.Name = "txtCustomerName"
      Me.txtCustomerName.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtCustomerName, "")
      Me.Validator.SetRequired(Me.txtCustomerName, False)
      Me.txtCustomerName.Size = New System.Drawing.Size(280, 21)
      Me.txtCustomerName.TabIndex = 9
      '
      'txtCostCenterName
      '
      Me.txtCostCenterName.BackColor = System.Drawing.SystemColors.Control
      Me.Validator.SetDataType(Me.txtCostCenterName, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtCostCenterName, "")
      Me.txtCostCenterName.Enabled = False
      Me.Validator.SetGotFocusBackColor(Me.txtCostCenterName, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtCostCenterName, System.Drawing.Color.Empty)
      Me.txtCostCenterName.Location = New System.Drawing.Point(184, 16)
      Me.Validator.SetMinValue(Me.txtCostCenterName, "")
      Me.txtCostCenterName.Name = "txtCostCenterName"
      Me.txtCostCenterName.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtCostCenterName, "")
      Me.Validator.SetRequired(Me.txtCostCenterName, False)
      Me.txtCostCenterName.Size = New System.Drawing.Size(256, 21)
      Me.txtCostCenterName.TabIndex = 10
      '
      'ibtnShowProject
      '
      Me.ibtnShowProject.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.ibtnShowProject.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.ibtnShowProject.Location = New System.Drawing.Point(464, 15)
      Me.ibtnShowProject.Name = "ibtnShowProject"
      Me.ibtnShowProject.Size = New System.Drawing.Size(24, 23)
      Me.ibtnShowProject.TabIndex = 12
      Me.ibtnShowProject.TabStop = False
      Me.ibtnShowProject.ThemedImage = CType(resources.GetObject("ibtnShowProject.ThemedImage"), System.Drawing.Bitmap)
      '
      'ibtnShowProjectDialog
      '
      Me.ibtnShowProjectDialog.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.ibtnShowProjectDialog.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.ibtnShowProjectDialog.ForeColor = System.Drawing.SystemColors.Control
      Me.ibtnShowProjectDialog.Location = New System.Drawing.Point(440, 15)
      Me.ibtnShowProjectDialog.Name = "ibtnShowProjectDialog"
      Me.ibtnShowProjectDialog.Size = New System.Drawing.Size(24, 23)
      Me.ibtnShowProjectDialog.TabIndex = 11
      Me.ibtnShowProjectDialog.TabStop = False
      Me.ibtnShowProjectDialog.ThemedImage = CType(resources.GetObject("ibtnShowProjectDialog.ThemedImage"), System.Drawing.Bitmap)
      '
      'lblBOQ
      '
      Me.lblBOQ.BackColor = System.Drawing.Color.Transparent
      Me.lblBOQ.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblBOQ.Location = New System.Drawing.Point(520, 17)
      Me.lblBOQ.Name = "lblBOQ"
      Me.lblBOQ.Size = New System.Drawing.Size(96, 18)
      Me.lblBOQ.TabIndex = 13
      Me.lblBOQ.Text = "Ref BOQ:"
      Me.lblBOQ.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'ibnShowBOQDialog
      '
      Me.ibnShowBOQDialog.Enabled = False
      Me.ibnShowBOQDialog.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.ibnShowBOQDialog.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.ibnShowBOQDialog.ForeColor = System.Drawing.SystemColors.Control
      Me.ibnShowBOQDialog.Location = New System.Drawing.Point(728, 16)
      Me.ibnShowBOQDialog.Name = "ibnShowBOQDialog"
      Me.ibnShowBOQDialog.Size = New System.Drawing.Size(24, 23)
      Me.ibnShowBOQDialog.TabIndex = 0
      Me.ibnShowBOQDialog.TabStop = False
      Me.ibnShowBOQDialog.ThemedImage = CType(resources.GetObject("ibnShowBOQDialog.ThemedImage"), System.Drawing.Bitmap)
      '
      'txtBOQCode
      '
      Me.Validator.SetDataType(Me.txtBOQCode, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtBOQCode, "")
      Me.Validator.SetGotFocusBackColor(Me.txtBOQCode, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtBOQCode, System.Drawing.Color.Empty)
      Me.txtBOQCode.Location = New System.Drawing.Point(616, 16)
      Me.Validator.SetMinValue(Me.txtBOQCode, "")
      Me.txtBOQCode.Name = "txtBOQCode"
      Me.txtBOQCode.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtBOQCode, "")
      Me.Validator.SetRequired(Me.txtBOQCode, False)
      Me.txtBOQCode.Size = New System.Drawing.Size(112, 21)
      Me.txtBOQCode.TabIndex = 1
      '
      'lblItem
      '
      Me.lblItem.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblItem.Location = New System.Drawing.Point(8, 16)
      Me.lblItem.Name = "lblItem"
      Me.lblItem.Size = New System.Drawing.Size(128, 18)
      Me.lblItem.TabIndex = 11
      Me.lblItem.Text = "รายการจัดการเงินงวด"
      Me.lblItem.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      '
      'grbPaymentApplication
      '
      Me.grbPaymentApplication.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                  Or System.Windows.Forms.AnchorStyles.Left) _
                  Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.grbPaymentApplication.Controls.Add(Me.txtItemReceiveDate)
      Me.grbPaymentApplication.Controls.Add(Me.lblItemReceiveDate)
      Me.grbPaymentApplication.Controls.Add(Me.dtpItemReceiveDate)
      Me.grbPaymentApplication.Controls.Add(Me.txtItemDiscount)
      Me.grbPaymentApplication.Controls.Add(Me.tgItem)
      Me.grbPaymentApplication.Controls.Add(Me.txtItemBillIssueDate)
      Me.grbPaymentApplication.Controls.Add(Me.txtItemHandedDate)
      Me.grbPaymentApplication.Controls.Add(Me.txtItemDocDate)
      Me.grbPaymentApplication.Controls.Add(Me.ibtnBlank)
      Me.grbPaymentApplication.Controls.Add(Me.ibtnDelRow)
      Me.grbPaymentApplication.Controls.Add(Me.cmbItemType)
      Me.grbPaymentApplication.Controls.Add(Me.dtpItemDocDate)
      Me.grbPaymentApplication.Controls.Add(Me.lblItemDocDate)
      Me.grbPaymentApplication.Controls.Add(Me.lblItem)
      Me.grbPaymentApplication.Controls.Add(Me.dtpItemHandedDate)
      Me.grbPaymentApplication.Controls.Add(Me.lblItemHandedDate)
      Me.grbPaymentApplication.Controls.Add(Me.txtItemCode)
      Me.grbPaymentApplication.Controls.Add(Me.lblItemType)
      Me.grbPaymentApplication.Controls.Add(Me.lblItemCode)
      Me.grbPaymentApplication.Controls.Add(Me.txtItemName)
      Me.grbPaymentApplication.Controls.Add(Me.lblItemName)
      Me.grbPaymentApplication.Controls.Add(Me.txtItemRealAmount)
      Me.grbPaymentApplication.Controls.Add(Me.lblItemRealAmount)
      Me.grbPaymentApplication.Controls.Add(Me.lblItemStatus)
      Me.grbPaymentApplication.Controls.Add(Me.lblItemBillIssueDate)
      Me.grbPaymentApplication.Controls.Add(Me.dtpItemBillIssueDate)
      Me.grbPaymentApplication.Controls.Add(Me.txtItemAdvr)
      Me.grbPaymentApplication.Controls.Add(Me.lblItemAdvr)
      Me.grbPaymentApplication.Controls.Add(Me.txtItemRetention)
      Me.grbPaymentApplication.Controls.Add(Me.lblItemRetention)
      Me.grbPaymentApplication.Controls.Add(Me.txtItemAmount)
      Me.grbPaymentApplication.Controls.Add(Me.lblItemAmount)
      Me.grbPaymentApplication.Controls.Add(Me.txtItemPenalty)
      Me.grbPaymentApplication.Controls.Add(Me.lblItemPenalty)
      Me.grbPaymentApplication.Controls.Add(Me.cmbItemStatus)
      Me.grbPaymentApplication.Controls.Add(Me.txtItemNote)
      Me.grbPaymentApplication.Controls.Add(Me.lblItemNote)
      Me.grbPaymentApplication.Controls.Add(Me.imbMilestoneDetail)
      Me.grbPaymentApplication.Controls.Add(Me.lblItemDiscount)
      Me.grbPaymentApplication.Controls.Add(Me.ibtnHand)
      Me.grbPaymentApplication.Controls.Add(Me.ibtnCancelHand)
      Me.grbPaymentApplication.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.grbPaymentApplication.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.grbPaymentApplication.Location = New System.Drawing.Point(0, 216)
      Me.grbPaymentApplication.Name = "grbPaymentApplication"
      Me.grbPaymentApplication.Size = New System.Drawing.Size(768, 304)
      Me.grbPaymentApplication.TabIndex = 1
      Me.grbPaymentApplication.TabStop = False
      Me.grbPaymentApplication.Text = "รายการเงินงวด"
      '
      'txtItemReceiveDate
      '
      Me.txtItemReceiveDate.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.txtItemReceiveDate.BackColor = System.Drawing.SystemColors.Control
      Me.Validator.SetDataType(Me.txtItemReceiveDate, Longkong.Pojjaman.Gui.Components.DataTypeConstants.DateTimeType)
      Me.Validator.SetDisplayName(Me.txtItemReceiveDate, "")
      Me.txtItemReceiveDate.Enabled = False
      Me.txtItemReceiveDate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtItemReceiveDate, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtItemReceiveDate, System.Drawing.Color.Empty)
      Me.txtItemReceiveDate.Location = New System.Drawing.Point(248, 271)
      Me.Validator.SetMinValue(Me.txtItemReceiveDate, "")
      Me.txtItemReceiveDate.Name = "txtItemReceiveDate"
      Me.txtItemReceiveDate.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtItemReceiveDate, "")
      Me.Validator.SetRequired(Me.txtItemReceiveDate, False)
      Me.txtItemReceiveDate.Size = New System.Drawing.Size(93, 21)
      Me.txtItemReceiveDate.TabIndex = 37
      Me.txtItemReceiveDate.TabStop = False
      '
      'lblItemReceiveDate
      '
      Me.lblItemReceiveDate.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.lblItemReceiveDate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblItemReceiveDate.Location = New System.Drawing.Point(184, 272)
      Me.lblItemReceiveDate.Name = "lblItemReceiveDate"
      Me.lblItemReceiveDate.Size = New System.Drawing.Size(64, 18)
      Me.lblItemReceiveDate.TabIndex = 36
      Me.lblItemReceiveDate.Text = "วันที่รับ:"
      Me.lblItemReceiveDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'dtpItemReceiveDate
      '
      Me.dtpItemReceiveDate.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.dtpItemReceiveDate.Enabled = False
      Me.dtpItemReceiveDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
      Me.dtpItemReceiveDate.Location = New System.Drawing.Point(248, 271)
      Me.dtpItemReceiveDate.Name = "dtpItemReceiveDate"
      Me.dtpItemReceiveDate.Size = New System.Drawing.Size(112, 21)
      Me.dtpItemReceiveDate.TabIndex = 38
      '
      'txtItemDiscount
      '
      Me.txtItemDiscount.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.txtItemDiscount.BackColor = System.Drawing.SystemColors.Window
      Me.Validator.SetDataType(Me.txtItemDiscount, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtItemDiscount, "")
      Me.Validator.SetGotFocusBackColor(Me.txtItemDiscount, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtItemDiscount, System.Drawing.Color.Empty)
      Me.txtItemDiscount.Location = New System.Drawing.Point(72, 251)
      Me.Validator.SetMinValue(Me.txtItemDiscount, "")
      Me.txtItemDiscount.Name = "txtItemDiscount"
      Me.Validator.SetRegularExpression(Me.txtItemDiscount, "")
      Me.Validator.SetRequired(Me.txtItemDiscount, False)
      Me.txtItemDiscount.Size = New System.Drawing.Size(112, 21)
      Me.txtItemDiscount.TabIndex = 9
      '
      'tgItem
      '
      Me.tgItem.AllowNew = False
      Me.tgItem.AllowSorting = False
      Me.tgItem.AlternatingBackColor = System.Drawing.Color.FromArgb(CType(CType(217, Byte), Integer), CType(CType(222, Byte), Integer), CType(CType(236, Byte), Integer))
      Me.tgItem.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                  Or System.Windows.Forms.AnchorStyles.Left) _
                  Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.tgItem.AutoColumnResize = True
      Me.tgItem.CaptionVisible = False
      Me.tgItem.Cellchanged = False
      Me.tgItem.DataMember = ""
      Me.tgItem.HeaderBackColor = System.Drawing.Color.Khaki
      Me.tgItem.HeaderForeColor = System.Drawing.SystemColors.ControlText
      Me.tgItem.Location = New System.Drawing.Point(8, 40)
      Me.tgItem.Name = "tgItem"
      Me.tgItem.Size = New System.Drawing.Size(752, 160)
      Me.tgItem.SortingArrowColor = System.Drawing.Color.Red
      Me.tgItem.TabIndex = 0
      Me.tgItem.TreeManager = Nothing
      '
      'txtItemBillIssueDate
      '
      Me.txtItemBillIssueDate.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.txtItemBillIssueDate.BackColor = System.Drawing.SystemColors.Control
      Me.Validator.SetDataType(Me.txtItemBillIssueDate, Longkong.Pojjaman.Gui.Components.DataTypeConstants.DateTimeType)
      Me.Validator.SetDisplayName(Me.txtItemBillIssueDate, "")
      Me.txtItemBillIssueDate.Enabled = False
      Me.txtItemBillIssueDate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtItemBillIssueDate, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtItemBillIssueDate, System.Drawing.Color.Empty)
      Me.txtItemBillIssueDate.Location = New System.Drawing.Point(608, 251)
      Me.Validator.SetMinValue(Me.txtItemBillIssueDate, "")
      Me.txtItemBillIssueDate.Name = "txtItemBillIssueDate"
      Me.txtItemBillIssueDate.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtItemBillIssueDate, "")
      Me.Validator.SetRequired(Me.txtItemBillIssueDate, False)
      Me.txtItemBillIssueDate.Size = New System.Drawing.Size(93, 21)
      Me.txtItemBillIssueDate.TabIndex = 34
      Me.txtItemBillIssueDate.TabStop = False
      '
      'txtItemHandedDate
      '
      Me.txtItemHandedDate.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.txtItemHandedDate.BackColor = System.Drawing.SystemColors.Control
      Me.Validator.SetDataType(Me.txtItemHandedDate, Longkong.Pojjaman.Gui.Components.DataTypeConstants.DateTimeType)
      Me.Validator.SetDisplayName(Me.txtItemHandedDate, "")
      Me.txtItemHandedDate.Enabled = False
      Me.txtItemHandedDate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtItemHandedDate, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtItemHandedDate, System.Drawing.Color.Empty)
      Me.txtItemHandedDate.Location = New System.Drawing.Point(432, 251)
      Me.Validator.SetMinValue(Me.txtItemHandedDate, "")
      Me.txtItemHandedDate.Name = "txtItemHandedDate"
      Me.txtItemHandedDate.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtItemHandedDate, "")
      Me.Validator.SetRequired(Me.txtItemHandedDate, False)
      Me.txtItemHandedDate.Size = New System.Drawing.Size(93, 21)
      Me.txtItemHandedDate.TabIndex = 28
      Me.txtItemHandedDate.TabStop = False
      '
      'txtItemDocDate
      '
      Me.txtItemDocDate.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.txtItemDocDate.BackColor = System.Drawing.SystemColors.Window
      Me.Validator.SetDataType(Me.txtItemDocDate, Longkong.Pojjaman.Gui.Components.DataTypeConstants.DateTimeType)
      Me.Validator.SetDisplayName(Me.txtItemDocDate, "")
      Me.txtItemDocDate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtItemDocDate, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtItemDocDate, System.Drawing.Color.Empty)
      Me.txtItemDocDate.Location = New System.Drawing.Point(432, 208)
      Me.Validator.SetMinValue(Me.txtItemDocDate, "")
      Me.txtItemDocDate.Name = "txtItemDocDate"
      Me.Validator.SetRegularExpression(Me.txtItemDocDate, "")
      Me.Validator.SetRequired(Me.txtItemDocDate, False)
      Me.txtItemDocDate.Size = New System.Drawing.Size(93, 21)
      Me.txtItemDocDate.TabIndex = 3
      '
      'ibtnBlank
      '
      Me.ibtnBlank.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.ibtnBlank.Location = New System.Drawing.Point(136, 8)
      Me.ibtnBlank.Name = "ibtnBlank"
      Me.ibtnBlank.Size = New System.Drawing.Size(24, 24)
      Me.ibtnBlank.TabIndex = 12
      Me.ibtnBlank.TabStop = False
      Me.ibtnBlank.ThemedImage = CType(resources.GetObject("ibtnBlank.ThemedImage"), System.Drawing.Bitmap)
      '
      'ibtnDelRow
      '
      Me.ibtnDelRow.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.ibtnDelRow.Location = New System.Drawing.Point(160, 8)
      Me.ibtnDelRow.Name = "ibtnDelRow"
      Me.ibtnDelRow.Size = New System.Drawing.Size(24, 24)
      Me.ibtnDelRow.TabIndex = 13
      Me.ibtnDelRow.TabStop = False
      Me.ibtnDelRow.ThemedImage = CType(resources.GetObject("ibtnDelRow.ThemedImage"), System.Drawing.Bitmap)
      '
      'cmbItemType
      '
      Me.cmbItemType.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.cmbItemType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbItemType.Location = New System.Drawing.Point(72, 208)
      Me.cmbItemType.Name = "cmbItemType"
      Me.cmbItemType.Size = New System.Drawing.Size(112, 21)
      Me.cmbItemType.TabIndex = 1
      '
      'dtpItemDocDate
      '
      Me.dtpItemDocDate.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.dtpItemDocDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
      Me.dtpItemDocDate.Location = New System.Drawing.Point(432, 208)
      Me.dtpItemDocDate.Name = "dtpItemDocDate"
      Me.dtpItemDocDate.Size = New System.Drawing.Size(112, 21)
      Me.dtpItemDocDate.TabIndex = 30
      '
      'lblItemDocDate
      '
      Me.lblItemDocDate.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.lblItemDocDate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblItemDocDate.Location = New System.Drawing.Point(368, 208)
      Me.lblItemDocDate.Name = "lblItemDocDate"
      Me.lblItemDocDate.Size = New System.Drawing.Size(64, 18)
      Me.lblItemDocDate.TabIndex = 25
      Me.lblItemDocDate.Text = "วันที่เอกสาร"
      Me.lblItemDocDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'dtpItemHandedDate
      '
      Me.dtpItemHandedDate.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.dtpItemHandedDate.Enabled = False
      Me.dtpItemHandedDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
      Me.dtpItemHandedDate.Location = New System.Drawing.Point(432, 251)
      Me.dtpItemHandedDate.Name = "dtpItemHandedDate"
      Me.dtpItemHandedDate.Size = New System.Drawing.Size(112, 21)
      Me.dtpItemHandedDate.TabIndex = 29
      '
      'lblItemHandedDate
      '
      Me.lblItemHandedDate.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.lblItemHandedDate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblItemHandedDate.Location = New System.Drawing.Point(368, 252)
      Me.lblItemHandedDate.Name = "lblItemHandedDate"
      Me.lblItemHandedDate.Size = New System.Drawing.Size(64, 18)
      Me.lblItemHandedDate.TabIndex = 27
      Me.lblItemHandedDate.Text = "วันที่ส่งงาน:"
      Me.lblItemHandedDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'txtItemCode
      '
      Me.txtItemCode.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.txtItemCode.BackColor = System.Drawing.SystemColors.Window
      Me.Validator.SetDataType(Me.txtItemCode, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtItemCode, "")
      Me.Validator.SetGotFocusBackColor(Me.txtItemCode, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtItemCode, System.Drawing.Color.Empty)
      Me.txtItemCode.Location = New System.Drawing.Point(248, 208)
      Me.Validator.SetMinValue(Me.txtItemCode, "")
      Me.txtItemCode.Name = "txtItemCode"
      Me.Validator.SetRegularExpression(Me.txtItemCode, "")
      Me.Validator.SetRequired(Me.txtItemCode, False)
      Me.txtItemCode.Size = New System.Drawing.Size(112, 21)
      Me.txtItemCode.TabIndex = 2
      '
      'lblItemType
      '
      Me.lblItemType.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.lblItemType.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblItemType.Location = New System.Drawing.Point(24, 210)
      Me.lblItemType.Name = "lblItemType"
      Me.lblItemType.Size = New System.Drawing.Size(48, 16)
      Me.lblItemType.TabIndex = 15
      Me.lblItemType.Text = "ประเภท:"
      Me.lblItemType.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblItemCode
      '
      Me.lblItemCode.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.lblItemCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblItemCode.Location = New System.Drawing.Point(200, 208)
      Me.lblItemCode.Name = "lblItemCode"
      Me.lblItemCode.Size = New System.Drawing.Size(48, 16)
      Me.lblItemCode.TabIndex = 23
      Me.lblItemCode.Text = "รหัส:"
      Me.lblItemCode.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'txtItemName
      '
      Me.txtItemName.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.txtItemName.BackColor = System.Drawing.SystemColors.Window
      Me.Validator.SetDataType(Me.txtItemName, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtItemName, "")
      Me.Validator.SetGotFocusBackColor(Me.txtItemName, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtItemName, System.Drawing.Color.Empty)
      Me.txtItemName.Location = New System.Drawing.Point(608, 208)
      Me.Validator.SetMinValue(Me.txtItemName, "")
      Me.txtItemName.Name = "txtItemName"
      Me.Validator.SetRegularExpression(Me.txtItemName, "")
      Me.Validator.SetRequired(Me.txtItemName, False)
      Me.txtItemName.Size = New System.Drawing.Size(112, 21)
      Me.txtItemName.TabIndex = 4
      '
      'lblItemName
      '
      Me.lblItemName.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.lblItemName.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblItemName.Location = New System.Drawing.Point(552, 208)
      Me.lblItemName.Name = "lblItemName"
      Me.lblItemName.Size = New System.Drawing.Size(56, 16)
      Me.lblItemName.TabIndex = 31
      Me.lblItemName.Text = "รายการ:"
      Me.lblItemName.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'txtItemRealAmount
      '
      Me.txtItemRealAmount.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.txtItemRealAmount.BackColor = System.Drawing.SystemColors.Window
      Me.Validator.SetDataType(Me.txtItemRealAmount, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtItemRealAmount, "")
      Me.Validator.SetGotFocusBackColor(Me.txtItemRealAmount, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtItemRealAmount, System.Drawing.Color.Empty)
      Me.txtItemRealAmount.Location = New System.Drawing.Point(72, 230)
      Me.Validator.SetMinValue(Me.txtItemRealAmount, "")
      Me.txtItemRealAmount.Name = "txtItemRealAmount"
      Me.Validator.SetRegularExpression(Me.txtItemRealAmount, "")
      Me.Validator.SetRequired(Me.txtItemRealAmount, False)
      Me.txtItemRealAmount.Size = New System.Drawing.Size(112, 21)
      Me.txtItemRealAmount.TabIndex = 5
      '
      'lblItemRealAmount
      '
      Me.lblItemRealAmount.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.lblItemRealAmount.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblItemRealAmount.Location = New System.Drawing.Point(8, 232)
      Me.lblItemRealAmount.Name = "lblItemRealAmount"
      Me.lblItemRealAmount.Size = New System.Drawing.Size(64, 16)
      Me.lblItemRealAmount.TabIndex = 16
      Me.lblItemRealAmount.Text = "ยอดเงิน:"
      Me.lblItemRealAmount.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblItemStatus
      '
      Me.lblItemStatus.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.lblItemStatus.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblItemStatus.Location = New System.Drawing.Point(8, 272)
      Me.lblItemStatus.Name = "lblItemStatus"
      Me.lblItemStatus.Size = New System.Drawing.Size(64, 16)
      Me.lblItemStatus.TabIndex = 18
      Me.lblItemStatus.Text = "สถานะ:"
      Me.lblItemStatus.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblItemBillIssueDate
      '
      Me.lblItemBillIssueDate.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.lblItemBillIssueDate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblItemBillIssueDate.Location = New System.Drawing.Point(544, 252)
      Me.lblItemBillIssueDate.Name = "lblItemBillIssueDate"
      Me.lblItemBillIssueDate.Size = New System.Drawing.Size(64, 18)
      Me.lblItemBillIssueDate.TabIndex = 33
      Me.lblItemBillIssueDate.Text = "วันที่วางบิล:"
      Me.lblItemBillIssueDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'dtpItemBillIssueDate
      '
      Me.dtpItemBillIssueDate.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.dtpItemBillIssueDate.Enabled = False
      Me.dtpItemBillIssueDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
      Me.dtpItemBillIssueDate.Location = New System.Drawing.Point(608, 251)
      Me.dtpItemBillIssueDate.Name = "dtpItemBillIssueDate"
      Me.dtpItemBillIssueDate.Size = New System.Drawing.Size(112, 21)
      Me.dtpItemBillIssueDate.TabIndex = 35
      '
      'txtItemAdvr
      '
      Me.txtItemAdvr.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.txtItemAdvr.BackColor = System.Drawing.SystemColors.Window
      Me.Validator.SetDataType(Me.txtItemAdvr, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtItemAdvr, "")
      Me.Validator.SetGotFocusBackColor(Me.txtItemAdvr, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtItemAdvr, System.Drawing.Color.Empty)
      Me.txtItemAdvr.Location = New System.Drawing.Point(248, 230)
      Me.Validator.SetMinValue(Me.txtItemAdvr, "")
      Me.txtItemAdvr.Name = "txtItemAdvr"
      Me.Validator.SetRegularExpression(Me.txtItemAdvr, "")
      Me.Validator.SetRequired(Me.txtItemAdvr, False)
      Me.txtItemAdvr.Size = New System.Drawing.Size(112, 21)
      Me.txtItemAdvr.TabIndex = 6
      '
      'lblItemAdvr
      '
      Me.lblItemAdvr.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.lblItemAdvr.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblItemAdvr.Location = New System.Drawing.Point(200, 232)
      Me.lblItemAdvr.Name = "lblItemAdvr"
      Me.lblItemAdvr.Size = New System.Drawing.Size(48, 16)
      Me.lblItemAdvr.TabIndex = 22
      Me.lblItemAdvr.Text = "หักมัดจำ:"
      Me.lblItemAdvr.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'txtItemRetention
      '
      Me.txtItemRetention.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.txtItemRetention.BackColor = System.Drawing.SystemColors.Window
      Me.Validator.SetDataType(Me.txtItemRetention, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtItemRetention, "")
      Me.Validator.SetGotFocusBackColor(Me.txtItemRetention, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtItemRetention, System.Drawing.Color.Empty)
      Me.txtItemRetention.Location = New System.Drawing.Point(432, 230)
      Me.Validator.SetMinValue(Me.txtItemRetention, "")
      Me.txtItemRetention.Name = "txtItemRetention"
      Me.Validator.SetRegularExpression(Me.txtItemRetention, "")
      Me.Validator.SetRequired(Me.txtItemRetention, False)
      Me.txtItemRetention.Size = New System.Drawing.Size(112, 21)
      Me.txtItemRetention.TabIndex = 7
      '
      'lblItemRetention
      '
      Me.lblItemRetention.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.lblItemRetention.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblItemRetention.Location = New System.Drawing.Point(360, 232)
      Me.lblItemRetention.Name = "lblItemRetention"
      Me.lblItemRetention.Size = New System.Drawing.Size(72, 16)
      Me.lblItemRetention.TabIndex = 26
      Me.lblItemRetention.Text = "หัก Ret.:"
      Me.lblItemRetention.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'txtItemAmount
      '
      Me.txtItemAmount.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.txtItemAmount.BackColor = System.Drawing.SystemColors.Control
      Me.Validator.SetDataType(Me.txtItemAmount, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtItemAmount, "")
      Me.Validator.SetGotFocusBackColor(Me.txtItemAmount, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtItemAmount, System.Drawing.Color.Empty)
      Me.txtItemAmount.Location = New System.Drawing.Point(248, 251)
      Me.Validator.SetMinValue(Me.txtItemAmount, "")
      Me.txtItemAmount.Name = "txtItemAmount"
      Me.txtItemAmount.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtItemAmount, "")
      Me.Validator.SetRequired(Me.txtItemAmount, False)
      Me.txtItemAmount.Size = New System.Drawing.Size(112, 21)
      Me.txtItemAmount.TabIndex = 24
      '
      'lblItemAmount
      '
      Me.lblItemAmount.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.lblItemAmount.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblItemAmount.Location = New System.Drawing.Point(176, 253)
      Me.lblItemAmount.Name = "lblItemAmount"
      Me.lblItemAmount.Size = New System.Drawing.Size(72, 16)
      Me.lblItemAmount.TabIndex = 21
      Me.lblItemAmount.Text = "เบิกได้:"
      Me.lblItemAmount.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'txtItemPenalty
      '
      Me.txtItemPenalty.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.txtItemPenalty.BackColor = System.Drawing.SystemColors.Window
      Me.Validator.SetDataType(Me.txtItemPenalty, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtItemPenalty, "")
      Me.Validator.SetGotFocusBackColor(Me.txtItemPenalty, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtItemPenalty, System.Drawing.Color.Empty)
      Me.txtItemPenalty.Location = New System.Drawing.Point(608, 230)
      Me.Validator.SetMinValue(Me.txtItemPenalty, "")
      Me.txtItemPenalty.Name = "txtItemPenalty"
      Me.Validator.SetRegularExpression(Me.txtItemPenalty, "")
      Me.Validator.SetRequired(Me.txtItemPenalty, False)
      Me.txtItemPenalty.Size = New System.Drawing.Size(112, 21)
      Me.txtItemPenalty.TabIndex = 8
      '
      'lblItemPenalty
      '
      Me.lblItemPenalty.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.lblItemPenalty.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblItemPenalty.Location = New System.Drawing.Point(536, 232)
      Me.lblItemPenalty.Name = "lblItemPenalty"
      Me.lblItemPenalty.Size = New System.Drawing.Size(72, 16)
      Me.lblItemPenalty.TabIndex = 32
      Me.lblItemPenalty.Text = "ค่าปรับ:"
      Me.lblItemPenalty.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'cmbItemStatus
      '
      Me.cmbItemStatus.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.cmbItemStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbItemStatus.Enabled = False
      Me.cmbItemStatus.Location = New System.Drawing.Point(72, 272)
      Me.cmbItemStatus.Name = "cmbItemStatus"
      Me.cmbItemStatus.Size = New System.Drawing.Size(112, 21)
      Me.cmbItemStatus.TabIndex = 19
      '
      'txtItemNote
      '
      Me.txtItemNote.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.txtItemNote.BackColor = System.Drawing.SystemColors.Window
      Me.Validator.SetDataType(Me.txtItemNote, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtItemNote, "")
      Me.Validator.SetGotFocusBackColor(Me.txtItemNote, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtItemNote, System.Drawing.Color.Empty)
      Me.txtItemNote.Location = New System.Drawing.Point(432, 272)
      Me.Validator.SetMinValue(Me.txtItemNote, "")
      Me.txtItemNote.Name = "txtItemNote"
      Me.Validator.SetRegularExpression(Me.txtItemNote, "")
      Me.Validator.SetRequired(Me.txtItemNote, False)
      Me.txtItemNote.Size = New System.Drawing.Size(288, 21)
      Me.txtItemNote.TabIndex = 10
      '
      'lblItemNote
      '
      Me.lblItemNote.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.lblItemNote.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblItemNote.Location = New System.Drawing.Point(376, 273)
      Me.lblItemNote.Name = "lblItemNote"
      Me.lblItemNote.Size = New System.Drawing.Size(56, 16)
      Me.lblItemNote.TabIndex = 20
      Me.lblItemNote.Text = "หมายเหตุ:"
      Me.lblItemNote.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'imbMilestoneDetail
      '
      Me.imbMilestoneDetail.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.imbMilestoneDetail.Location = New System.Drawing.Point(184, 8)
      Me.imbMilestoneDetail.Name = "imbMilestoneDetail"
      Me.imbMilestoneDetail.Size = New System.Drawing.Size(24, 24)
      Me.imbMilestoneDetail.TabIndex = 14
      Me.imbMilestoneDetail.TabStop = False
      Me.imbMilestoneDetail.ThemedImage = CType(resources.GetObject("imbMilestoneDetail.ThemedImage"), System.Drawing.Bitmap)
      Me.ToolTip1.SetToolTip(Me.imbMilestoneDetail, "ไปยังรายการ")
      '
      'lblItemDiscount
      '
      Me.lblItemDiscount.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.lblItemDiscount.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblItemDiscount.Location = New System.Drawing.Point(8, 253)
      Me.lblItemDiscount.Name = "lblItemDiscount"
      Me.lblItemDiscount.Size = New System.Drawing.Size(64, 16)
      Me.lblItemDiscount.TabIndex = 17
      Me.lblItemDiscount.Text = "ส่วนลด:"
      Me.lblItemDiscount.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'ibtnHand
      '
      Me.ibtnHand.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.ibtnHand.Location = New System.Drawing.Point(208, 8)
      Me.ibtnHand.Name = "ibtnHand"
      Me.ibtnHand.Size = New System.Drawing.Size(24, 24)
      Me.ibtnHand.TabIndex = 14
      Me.ibtnHand.TabStop = False
      Me.ibtnHand.ThemedImage = CType(resources.GetObject("ibtnHand.ThemedImage"), System.Drawing.Bitmap)
      Me.ToolTip1.SetToolTip(Me.ibtnHand, "ส่งงาน")
      '
      'ibtnCancelHand
      '
      Me.ibtnCancelHand.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.ibtnCancelHand.Location = New System.Drawing.Point(232, 8)
      Me.ibtnCancelHand.Name = "ibtnCancelHand"
      Me.ibtnCancelHand.Size = New System.Drawing.Size(24, 24)
      Me.ibtnCancelHand.TabIndex = 14
      Me.ibtnCancelHand.TabStop = False
      Me.ibtnCancelHand.ThemedImage = CType(resources.GetObject("ibtnCancelHand.ThemedImage"), System.Drawing.Bitmap)
      Me.ToolTip1.SetToolTip(Me.ibtnCancelHand, "ยกเลิกการส่งงาน")
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
      Me.Validator.GotFocusBackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
      Me.Validator.HasNewRow = False
      Me.Validator.InvalidBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
      '
      'PaymentApplicationDetail
      '
      Me.Controls.Add(Me.grbDetail)
      Me.Controls.Add(Me.grbPaymentApplication)
      Me.Name = "PaymentApplicationDetail"
      Me.Size = New System.Drawing.Size(776, 528)
      Me.grbDetail.ResumeLayout(False)
      Me.grbDetail.PerformLayout()
      Me.grbContract.ResumeLayout(False)
      Me.grbContract.PerformLayout()
      Me.grbAdvrRetention.ResumeLayout(False)
      Me.grbAdvrRetention.PerformLayout()
      Me.grbTax.ResumeLayout(False)
      Me.grbTax.PerformLayout()
      Me.grbPaymentApplication.ResumeLayout(False)
      Me.grbPaymentApplication.PerformLayout()
      CType(Me.tgItem, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
      Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Members"
    Private m_entity As PaymentApplication
    Private m_isInitialized As Boolean = False
    Private m_treeManager As TreeManager

    Private m_milestone As Milestone 'Selected
    Private m_tableInitialized As Boolean
#End Region

#Region "Constructors"
    Public Sub New()
      MyBase.New()
      Me.InitializeComponent()
      Me.SetLabelText()
      Initialize()

      Dim dt As TreeTable = PaymentApplication.GetSchemaTable()
      Dim dst As DataGridTableStyle = Me.CreateTableStyle()
      m_treeManager = New TreeManager(dt, tgItem)
      m_treeManager.SetTableStyle(dst)
      m_treeManager.AllowSorting = False
      m_treeManager.AllowDelete = False

      AddHandler dt.ColumnChanging, AddressOf Treetable_ColumnChanging
      AddHandler dt.ColumnChanged, AddressOf Treetable_ColumnChanged

      EventWiring()
    End Sub
#End Region

#Region "Style"
    Private Function CreateTableStyle() As DataGridTableStyle
      Dim dst As New DataGridTableStyle
      dst.MappingName = "PaymentApplication"
      Dim myStringParserService As StringParserService = CType(ServiceManager.Services.GetService(GetType(StringParserService)), StringParserService)
      ' Items
      Dim csLineNumber As New TreeTextColumn(0, False, Color.Khaki)
      csLineNumber.MappingName = "Linenumber"
      csLineNumber.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PaymentApplicationDetail.LineNumberHeaderText}")
      csLineNumber.NullText = ""
      csLineNumber.Width = 30
      csLineNumber.DataAlignment = HorizontalAlignment.Center
      csLineNumber.ReadOnly = True
      csLineNumber.TextBox.Name = "Linenumber"
      AddHandler csLineNumber.CheckCellHilighted, AddressOf Me.SetHilightValues

      Dim csType As DataGridComboColumn
      csType = New DataGridComboColumn("Type", CodeDescription.GetCodeList("milestone_type"), "code_description", "code_value")
      csType.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PaymentApplicationDetail.TypeHeaderText}")
      csType.Width = 70
      csType.NullText = String.Empty

      Dim csCode As New TreeTextColumn(2, False, Color.Khaki)
      csCode.MappingName = "Code"
      csCode.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PaymentApplicationDetail.CodeHeaderText}")
      csCode.NullText = ""
      csCode.TextBox.Name = "Code"
      AddHandler csCode.CheckCellHilighted, AddressOf Me.SetHilightValues

      Dim csName As New TreeTextColumn(3, False, Color.Khaki)
      csName.MappingName = "Name"
      csName.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PaymentApplicationDetail.NameHeaderText}")
      csName.NullText = ""
      'csCode.ReadOnly = True
      csName.TextBox.Name = "Name"
      AddHandler csName.CheckCellHilighted, AddressOf Me.SetHilightValues

      Dim csDocDate As New DataGridTimePickerColumn
      csDocDate.MappingName = "DocDate"
      csDocDate.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.VatDetail.DocDateHeaderText}")
      csDocDate.NullText = ""
      csDocDate.Width = 100

      Dim csRealAmount As New TreeTextColumn(4, False, Color.Khaki)
      csRealAmount.MappingName = "RealAmount"
      csRealAmount.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PaymentApplicationDetail.RealAmountHeaderText}")
      csRealAmount.NullText = ""
      csRealAmount.DataAlignment = HorizontalAlignment.Right
      csRealAmount.TextBox.Name = "RealAmount"
      csRealAmount.Format = "#,###.##"
      AddHandler csRealAmount.CheckCellHilighted, AddressOf Me.SetHilightValues

      Dim csAmount As New TreeTextColumn(5, False, Color.Khaki)
      csAmount.MappingName = "Amount"
      csAmount.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PaymentApplicationDetail.AmountHeaderText}")
      csAmount.NullText = ""
      csAmount.DataAlignment = HorizontalAlignment.Right
      csAmount.TextBox.Name = "Amount"
      csAmount.ReadOnly = True
      csAmount.Format = "#,###.##"
      AddHandler csAmount.CheckCellHilighted, AddressOf Me.SetHilightValues

      Dim csAdvance As New TreeTextColumn(6, False, Color.Khaki)
      csAdvance.MappingName = "Advance"
      csAdvance.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PaymentApplicationDetail.AdvanceHeaderText}")
      csAdvance.NullText = ""
      csAdvance.DataAlignment = HorizontalAlignment.Right
      csAdvance.TextBox.Name = "Advance"
      csAdvance.Format = "#,###.##"
      AddHandler csAdvance.CheckCellHilighted, AddressOf Me.SetHilightValues

      Dim csRetention As New TreeTextColumn(7, False, Color.Khaki)
      csRetention.MappingName = "Retention"
      csRetention.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PaymentApplicationDetail.RetentionHeaderText}")
      csRetention.NullText = ""
      csRetention.DataAlignment = HorizontalAlignment.Right
      csRetention.TextBox.Name = "Retention"
      csRetention.Format = "#,###.##"
      AddHandler csRetention.CheckCellHilighted, AddressOf Me.SetHilightValues

      Dim csPenalty As New TreeTextColumn(8, False, Color.Khaki)
      csPenalty.MappingName = "Penalty"
      csPenalty.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PaymentApplicationDetail.PenaltyHeaderText}")
      csPenalty.NullText = ""
      csPenalty.DataAlignment = HorizontalAlignment.Right
      csPenalty.TextBox.Name = "Penalty"
      csPenalty.Format = "#,###.##"
      AddHandler csPenalty.CheckCellHilighted, AddressOf Me.SetHilightValues

      Dim csDiscount As New TreeTextColumn(9, False, Color.Khaki)
      csDiscount.MappingName = "Discount"
      csDiscount.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PaymentApplicationDetail.DiscountHeaderText}")
      csDiscount.NullText = ""
      csDiscount.TextBox.Name = "Discount"
      AddHandler csDiscount.CheckCellHilighted, AddressOf Me.SetHilightValues

      Dim csHandedDate As New DataGridTimePickerColumn
      csHandedDate.MappingName = "HandedDate"
      csHandedDate.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PaymentApplicationDetail.HandedDateHeaderText}")
      csHandedDate.NullText = ""
      csHandedDate.Width = 100

      Dim csBillIssueDate As New DataGridTimePickerColumn
      csBillIssueDate.MappingName = "BillIssueDate"
      csBillIssueDate.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PaymentApplicationDetail.BillIssueDateHeaderText}")
      csBillIssueDate.NullText = ""
      csBillIssueDate.Width = 100

      Dim csNote As New TreeTextColumn(11, False, Color.Khaki)
      csNote.MappingName = "Note"
      csNote.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PaymentApplicationDetail.NoteHeaderText}")
      csNote.NullText = ""
      csNote.Width = 180
      csNote.TextBox.Name = "Note"
      AddHandler csNote.CheckCellHilighted, AddressOf Me.SetHilightValues

      dst.GridColumnStyles.Add(csLineNumber)
      dst.GridColumnStyles.Add(csType)
      dst.GridColumnStyles.Add(csCode)
      dst.GridColumnStyles.Add(csDocDate)
      dst.GridColumnStyles.Add(csName)
      dst.GridColumnStyles.Add(csRealAmount)
      dst.GridColumnStyles.Add(csAdvance)
      dst.GridColumnStyles.Add(csRetention)
      dst.GridColumnStyles.Add(csPenalty)
      dst.GridColumnStyles.Add(csDiscount)
      dst.GridColumnStyles.Add(csAmount)
      dst.GridColumnStyles.Add(csNote)

      Return dst
    End Function
    Public Sub SetHilightValues(ByVal sender As Object, ByVal e As DataGridHilightEventArgs)
      e.HilightValue = False
      If e.Row = 0 Then
        e.HilightValue = True
      End If
    End Sub
#End Region

#Region "Methods"
    Public Sub PopulateItemListing()
      Me.m_treeManager.Treetable.Clear()
      Me.m_tableInitialized = False
      Dim totalRow As TreeRow = Me.m_treeManager.Treetable.Childs.Add
      totalRow("Name") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PaymentApplicationDetail.TotalRowDesc}")
      totalRow("Type") = DBNull.Value
      totalRow("Advance") = Configuration.FormatToString(Me.m_entity.ItemCollection.GetAdvrAmount, DigitConfig.Price)
      totalRow("Retention") = Configuration.FormatToString(Me.m_entity.ItemCollection.GetRetentionAmount, DigitConfig.Price)
      totalRow("Penalty") = Configuration.FormatToString(Me.m_entity.ItemCollection.GetPenaltyAmount, DigitConfig.Price)
      totalRow("RealAmount") = Configuration.FormatToString(Me.m_entity.ItemCollection.GetCanGetMilestoneAmount, DigitConfig.Price)
      totalRow("Amount") = Configuration.FormatToString(Me.m_entity.Amount, DigitConfig.Price)
      totalRow.Tag = Nothing
      Dim i As Integer
      For Each item As Milestone In Me.m_entity.ItemCollection
        If item.Status.Value = 2 Then
          item.ResetReal(False)
        End If
        i += 1
        Dim row As TreeRow = Me.m_treeManager.Treetable.Childs.Add()
        row("Linenumber") = i
        row("Type") = item.Type.Value
        row("Code") = item.Code
        row("Autogen") = item.AutoGen
        row("Name") = item.Name
        row("DocDate") = item.DocDate
        row("HandedDate") = item.HandedDate
        row("BillIssueDate") = item.BillIssueDate
        Select Case item.Type.Value
          Case 75
            'ผ่าน
            row("Advance") = Configuration.FormatToString(item.Advance, DigitConfig.Price)
            row("Retention") = Configuration.FormatToString(item.Retention, DigitConfig.Price)
            row("Discount") = item.Discount.Rate
            row("Penalty") = Configuration.FormatToString(item.Penalty, DigitConfig.Price)
          Case 78       'เพิ่ม
            row("Advance") = Configuration.FormatToString(item.Advance, DigitConfig.Price)
            row("Retention") = Configuration.FormatToString(item.Retention, DigitConfig.Price)
            row("Discount") = item.Discount.Rate
            row("Penalty") = Configuration.FormatToString(item.Penalty, DigitConfig.Price)
          Case 79         'เพิ่ม /ลด
            row("Advance") = ""
            row("Retention") = ""
            row("Discount") = item.Discount.Rate
            row("Penalty") = Configuration.FormatToString(item.Penalty, DigitConfig.Price)
          Case Else
            row("Advance") = ""
            row("Retention") = ""
            row("Discount") = ""
            row("Penalty") = ""
        End Select
        row("RealAmount") = Configuration.FormatToString(item.MileStoneAmount, DigitConfig.Price)
        row("Amount") = Configuration.FormatToString(item.Amount, DigitConfig.Price)
        row("Status") = item.Status.Value
        row("Note") = item.Note
        row.Tag = item
      Next
      ValidateItemRows()
      UpdateAmount()
      Me.m_tableInitialized = True
    End Sub
    Private Sub ValidateItemRows()
      For Each row As TreeRow In Me.m_treeManager.Treetable.Childs
        ValidateItemRow(row)
      Next
    End Sub
    Private Sub ValidateItemRow(ByVal row As TreeRow)
      If Not row.Tag Is Nothing AndAlso TypeOf row.Tag Is Milestone Then
        Dim mi As Milestone = CType(row.Tag, Milestone)
        Select Case mi.Type.Value
          Case 75 'งวดงาน
            If mi.Code Is Nothing OrElse mi.Code.Length = 0 Then
              row.SetColumnError("code", Me.StringParserService.Parse("${res:Global.Error.MilestoneCodeMissing}"))
            Else
              row.SetColumnError("code", "")
            End If
            If mi.Name Is Nothing OrElse mi.Name.Length = 0 Then
              row.SetColumnError("name", Me.StringParserService.Parse("${res:Global.Error.MilestoneNameMissing}"))
            Else
              row.SetColumnError("name", "")
            End If
            If mi.DocDate.Equals(Date.MinValue) Then
              row.SetColumnError("docdate", Me.StringParserService.Parse("${res:Global.Error.MilestoneDocDateMissing}"))
            Else
              row.SetColumnError("docdate", "")
            End If
            If mi.MileStoneAmount <= 0 Then
              row.SetColumnError("realamount", Me.StringParserService.Parse("${res:Global.Error.MilestoneAmountMissing}"))
            Else
              row.SetColumnError("realamount", "")
            End If
          Case 78 'เพิ่มงาน
            If mi.Code Is Nothing OrElse mi.Code.Length = 0 Then
              row.SetColumnError("code", Me.StringParserService.Parse("${res:Global.Error.VOCodeMissing}"))
            Else
              row.SetColumnError("code", "")
            End If
            If mi.Name Is Nothing OrElse mi.Name.Length = 0 Then
              row.SetColumnError("name", Me.StringParserService.Parse("${res:Global.Error.VONameMissing}"))
            Else
              row.SetColumnError("name", "")
            End If
            If mi.DocDate.Equals(Date.MinValue) Then
              row.SetColumnError("docdate", Me.StringParserService.Parse("${res:Global.Error.VODocDateMissing}"))
            Else
              row.SetColumnError("docdate", "")
            End If
            If mi.MileStoneAmount <= 0 Then
              row.SetColumnError("realamount", Me.StringParserService.Parse("${res:Global.Error.VOAmountMissing}"))
            Else
              row.SetColumnError("realamount", "")
            End If
          Case 79 'ลดงาน
            If mi.Code Is Nothing OrElse mi.Code.Length = 0 Then
              row.SetColumnError("code", Me.StringParserService.Parse("${res:Global.Error.VOCodeMissing}"))
            Else
              row.SetColumnError("code", "")
            End If
            If mi.Name Is Nothing OrElse mi.Name.Length = 0 Then
              row.SetColumnError("name", Me.StringParserService.Parse("${res:Global.Error.VONameMissing}"))
            Else
              row.SetColumnError("name", "")
            End If
            If mi.DocDate.Equals(Date.MinValue) Then
              row.SetColumnError("docdate", Me.StringParserService.Parse("${res:Global.Error.VODocDateMissing}"))
            Else
              row.SetColumnError("docdate", "")
            End If
            If mi.MileStoneAmount = 0 Then
              row.SetColumnError("realamount", Me.StringParserService.Parse("${res:Global.Error.VOAmountMissing}"))
            Else
              row.SetColumnError("realamount", "")
            End If
          Case 86 'มัดจำ
            If mi.Code Is Nothing OrElse mi.Code.Length = 0 Then
              row.SetColumnError("code", Me.StringParserService.Parse("${res:Global.Error.AdvrCodeMissing}"))
            Else
              row.SetColumnError("code", "")
            End If
            If mi.DocDate.Equals(Date.MinValue) Then
              row.SetColumnError("docdate", Me.StringParserService.Parse("${res:Global.Error.AdvrDocDateMissing}"))
            Else
              row.SetColumnError("docdate", "")
            End If
            If mi.MileStoneAmount <= 0 Then
              row.SetColumnError("realamount", Me.StringParserService.Parse("${res:Global.Error.AdvrAmountMissing}"))
            Else
              row.SetColumnError("realamount", "")
            End If
            row.SetColumnError("name", "")
          Case 77 'Retention
            If mi.Code Is Nothing OrElse mi.Code.Length = 0 Then
              row.SetColumnError("code", Me.StringParserService.Parse("${res:Global.Error.RetentionCodeMissing}"))
            Else
              row.SetColumnError("code", "")
            End If
            If mi.DocDate.Equals(Date.MinValue) Then
              row.SetColumnError("docdate", Me.StringParserService.Parse("${res:Global.Error.RetentionDocDateMissing}"))
            Else
              row.SetColumnError("docdate", "")
            End If
            If mi.MileStoneAmount <= 0 Then
              row.SetColumnError("realamount", Me.StringParserService.Parse("${res:Global.Error.RetentionAmountMissing}"))
            Else
              row.SetColumnError("realamount", "")
            End If
            row.SetColumnError("name", "")
          Case Else
            Return
        End Select
      End If
    End Sub
#End Region

#Region "TreeTable Handlers"
    Private Sub Treetable_ColumnChanged(ByVal sender As Object, ByVal e As System.Data.DataColumnChangeEventArgs)
      If Not Me.m_tableInitialized Then
        Return
      End If
      If Me.m_milestone Is Nothing Then
        Return
      End If
      Dim index As Integer = Me.m_treeManager.Treetable.Childs.IndexOf(CType(e.Row, TreeRow))
      If ValidateRow(CType(e.Row, TreeRow)) Then
        Me.WorkbenchWindow.ViewContent.IsDirty = True
        'Me.m_treeManager.Treetable.AcceptChanges()
      End If
    End Sub
    Private Sub Treetable_ColumnChanging(ByVal sender As Object, ByVal e As System.Data.DataColumnChangeEventArgs)
      If Not Me.m_tableInitialized Then
        Return
      End If
      If Me.m_milestone Is Nothing Then
        e.ProposedValue = e.Row(e.Column)
        Return
      End If
      If Me.m_milestone.Status.Value >= 3 Then
        e.ProposedValue = e.Row(e.Column)
        Return
      End If
      Try
        Select Case e.Column.ColumnName.ToLower
          Case "code"
            SetCode(e)
          Case "name"
            SetName(e)
          Case "type"
            SetEntityType(e)
          Case "docdate"
            SetDocDate(e)
          Case "realamount"
            SetRealAmount(e)
          Case "advance"
            SetAdvance(e)
          Case "retention"
            SetRetention(e)
          Case "penalty"
            SetPenalty(e)
          Case "discount"
            SetDiscount(e)
          Case "note"
            SetNote(e)
        End Select
        ValidateRow(e)
      Catch ex As Exception
        MessageBox.Show(ex.ToString)
      End Try
    End Sub
    Public Sub ValidateRow(ByVal e As DataColumnChangeEventArgs)
      Try
        Dim code As Object = e.Row("code")
        Dim name As Object = e.Row("name")
        Dim milestone_type As Object = e.Row("type")
        Dim docdate As Object = e.Row("docdate")
        Dim realamount As Object = e.Row("realamount")

        Select Case e.Column.ColumnName.ToLower
          Case "code"
            code = e.ProposedValue
          Case "name"
            name = e.ProposedValue
          Case "type"
            milestone_type = e.ProposedValue
          Case "docdate"
            docdate = e.ProposedValue
          Case "realamount"
            realamount = e.ProposedValue
          Case Else
            Return
        End Select

        Dim isBlankRow As Boolean = False
        If IsDBNull(milestone_type) Then
          isBlankRow = True
        End If

        If Not isBlankRow Then
          Select Case CInt(milestone_type)
            Case 75 'งวดงาน
              If IsDBNull(code) OrElse code.ToString.Length = 0 Then
                e.Row.SetColumnError("code", Me.StringParserService.Parse("${res:Global.Error.MilestoneCodeMissing}"))
              Else
                e.Row.SetColumnError("code", "")
              End If
              If IsDBNull(name) OrElse name.ToString.Length = 0 Then
                e.Row.SetColumnError("name", Me.StringParserService.Parse("${res:Global.Error.MilestoneNameMissing}"))
              Else
                e.Row.SetColumnError("name", "")
              End If
              If IsDBNull(docdate) OrElse CDate(docdate).Equals(Date.MinValue) Then
                e.Row.SetColumnError("docdate", Me.StringParserService.Parse("${res:Global.Error.MilestoneDocDateMissing}"))
              Else
                e.Row.SetColumnError("docdate", "")
              End If
              If IsDBNull(realamount) OrElse CDec(realamount) <= 0 Then
                e.Row.SetColumnError("realamount", Me.StringParserService.Parse("${res:Global.Error.MilestoneAmountMissing}"))
              Else
                e.Row.SetColumnError("realamount", "")
              End If
            Case 78 'เพิ่มงาน
              If IsDBNull(code) OrElse code.ToString.Length = 0 Then
                e.Row.SetColumnError("code", Me.StringParserService.Parse("${res:Global.Error.VOCodeMissing}"))
              Else
                e.Row.SetColumnError("code", "")
              End If
              If IsDBNull(name) OrElse name.ToString.Length = 0 Then
                e.Row.SetColumnError("name", Me.StringParserService.Parse("${res:Global.Error.VONameMissing}"))
              Else
                e.Row.SetColumnError("name", "")
              End If
              If IsDBNull(docdate) OrElse CDate(docdate).Equals(Date.MinValue) Then
                e.Row.SetColumnError("docdate", Me.StringParserService.Parse("${res:Global.Error.VODocDateMissing}"))
              Else
                e.Row.SetColumnError("docdate", "")
              End If
              If IsDBNull(realamount) OrElse CDec(realamount) <= 0 Then
                e.Row.SetColumnError("realamount", Me.StringParserService.Parse("${res:Global.Error.VOAmountMissing}"))
              Else
                e.Row.SetColumnError("realamount", "")
              End If
            Case 79 'ลดงาน
              If IsDBNull(code) OrElse code.ToString.Length = 0 Then
                e.Row.SetColumnError("code", Me.StringParserService.Parse("${res:Global.Error.VOCodeMissing}"))
              Else
                e.Row.SetColumnError("code", "")
              End If
              If IsDBNull(name) OrElse name.ToString.Length = 0 Then
                e.Row.SetColumnError("name", Me.StringParserService.Parse("${res:Global.Error.VONameMissing}"))
              Else
                e.Row.SetColumnError("name", "")
              End If
              If IsDBNull(docdate) OrElse CDate(docdate).Equals(Date.MinValue) Then
                e.Row.SetColumnError("docdate", Me.StringParserService.Parse("${res:Global.Error.VODocDateMissing}"))
              Else
                e.Row.SetColumnError("docdate", "")
              End If
              If IsDBNull(realamount) OrElse CDec(realamount) = 0 Then
                e.Row.SetColumnError("realamount", Me.StringParserService.Parse("${res:Global.Error.VOAmountMissing}"))
              Else
                e.Row.SetColumnError("realamount", "")
              End If
            Case 86
              If IsDBNull(code) OrElse code.ToString.Length = 0 Then
                e.Row.SetColumnError("code", Me.StringParserService.Parse("${res:Global.Error.AdvrCodeMissing}"))
              Else
                e.Row.SetColumnError("code", "")
              End If
              If IsDBNull(docdate) OrElse CDate(docdate).Equals(Date.MinValue) Then
                e.Row.SetColumnError("docdate", Me.StringParserService.Parse("${res:Global.Error.AdvrDocDateMissing}"))
              Else
                e.Row.SetColumnError("docdate", "")
              End If
              If IsDBNull(realamount) OrElse CDec(realamount) <= 0 Then
                e.Row.SetColumnError("realamount", Me.StringParserService.Parse("${res:Global.Error.AdvrAmountMissing}"))
              Else
                e.Row.SetColumnError("realamount", "")
              End If
              e.Row.SetColumnError("name", "")
            Case 77 'Retention
              If IsDBNull(code) OrElse code.ToString.Length = 0 Then
                e.Row.SetColumnError("code", Me.StringParserService.Parse("${res:Global.Error.RetentionCodeMissing}"))
              Else
                e.Row.SetColumnError("code", "")
              End If
              If IsDBNull(docdate) OrElse CDate(docdate).Equals(Date.MinValue) Then
                e.Row.SetColumnError("docdate", Me.StringParserService.Parse("${res:Global.Error.RetentionDocDateMissing}"))
              Else
                e.Row.SetColumnError("docdate", "")
              End If
              If IsDBNull(realamount) OrElse CDec(realamount) <= 0 Then
                e.Row.SetColumnError("realamount", Me.StringParserService.Parse("${res:Global.Error.RetentionAmountMissing}"))
              Else
                e.Row.SetColumnError("realamount", "")
              End If
              e.Row.SetColumnError("name", "")
            Case Else
              Return
          End Select
        End If
      Catch ex As Exception
        'MessageBox.Show(ex.ToString)
      End Try
    End Sub
    Public Function ValidateRow(ByVal row As TreeRow) As Boolean
      If row.IsNull("type") Then
        Return False
      End If
      Return True
    End Function
    Private m_updating As Boolean = False
    Public Sub SetDiscount(ByVal e As DataColumnChangeEventArgs)
      If m_updating Then
        Return
      End If
      If IsDBNull(e.ProposedValue) Then
        e.ProposedValue = ""
      End If
      Dim oldPenalty As Decimal
      If e.Row.IsNull("penalty") OrElse CStr(e.Row("penalty")).Length = 0 Then
        oldPenalty = 0
      Else
        oldPenalty = CDec(e.Row("penalty"))
      End If
      Dim oldRealAmount As Decimal
      If e.Row.IsNull("RealAmount") OrElse CStr(e.Row("RealAmount")).Length = 0 Then
        oldRealAmount = 0
      Else
        oldRealAmount = CDec(e.Row("RealAmount"))
      End If
      Dim oldRetention As Decimal
      If e.Row.IsNull("Retention") OrElse CStr(e.Row("Retention")).Length = 0 Then
        oldRetention = 0
      Else
        oldRetention = CDec(e.Row("Retention"))
      End If
      Dim oldAdvance As Decimal
      If e.Row.IsNull("Advance") OrElse CStr(e.Row("Advance")).Length = 0 Then
        oldAdvance = 0
      Else
        oldAdvance = CDec(e.Row("Advance"))
      End If
      Dim oldDiscount As Decimal
      If e.Row.IsNull("discount") OrElse CStr(e.Row("discount")).Length = 0 Then
        oldDiscount = 0
      Else
        oldDiscount = Discount.GetFinalDiscount(e.Row("discount").ToString, oldRealAmount - oldAdvance - oldRetention)
      End If
      Dim newDiscount As Decimal
      newDiscount = Discount.GetFinalDiscount(e.ProposedValue.ToString, oldRealAmount - oldAdvance - oldRetention)
      m_updating = True
      Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
      If e.Row.IsNull("type") Then
        msgServ.ShowMessage("${res:Global.Error.NoPmaType}")
        e.ProposedValue = e.Row(e.Column)
        m_updating = False
        Return
      End If
      Select Case CInt(e.Row("type"))
        Case 75, 78  'งวดงาน/เพิ่ม/ลด
          If oldRealAmount < (newDiscount + oldRetention + oldAdvance + oldPenalty) Then
            msgServ.ShowMessage("${res:Global.Error.MilestoneRealAmountLessThanDe}")
            e.ProposedValue = e.Row(e.Column)
            m_updating = False
            Return
          Else
            Me.m_milestone.Discount.Rate = e.ProposedValue.ToString
            Me.m_milestone.ResetReal(True)
            e.Row("amount") = Configuration.FormatToString(Me.m_milestone.Amount, DigitConfig.Price)
            Me.UpdateItem()
            UpdateAmount()
            UpdateTotalRow()
          End If
          'Case 79
          'Me.m_milestone.Discount.Rate = e.ProposedValue.ToString
          'Me.m_milestone.ResetReal()
          'e.Row("amount") = Configuration.FormatToString(Me.m_milestone.Amount, DigitConfig.Price)
          'Me.UpdateItem()
          'UpdateAmount()
          'UpdateTotalRow()
        Case Else
          msgServ.ShowMessage("${res:Global.Error.PenaltyCanOnlyBeWithMilestone}")
          e.ProposedValue = e.Row(e.Column)
          m_updating = False
          Return
      End Select
      m_updating = False
    End Sub
    Public Sub SetPenalty(ByVal e As DataColumnChangeEventArgs)
      If m_updating Then
        Return
      End If
      If IsDBNull(e.ProposedValue) OrElse e.ProposedValue.ToString.Length = 0 Then
        e.ProposedValue = 0
      End If
      e.ProposedValue = Configuration.FormatToString(CDec(TextParser.Evaluate(e.ProposedValue.ToString)), DigitConfig.Price)
      Dim value As Decimal = CDec(e.ProposedValue)
      Dim oldPenalty As Decimal
      If e.Row.IsNull("penalty") OrElse CStr(e.Row("penalty")).Length = 0 Then
        oldPenalty = 0
      Else
        oldPenalty = CDec(e.Row("penalty"))
      End If
      Dim oldRealAmount As Decimal
      If e.Row.IsNull("RealAmount") OrElse CStr(e.Row("RealAmount")).Length = 0 Then
        oldRealAmount = 0
      Else
        oldRealAmount = CDec(e.Row("RealAmount"))
      End If
      Dim oldRetention As Decimal
      If e.Row.IsNull("Retention") OrElse CStr(e.Row("Retention")).Length = 0 Then
        oldRetention = 0
      Else
        oldRetention = CDec(e.Row("Retention"))
      End If
      Dim oldAdvance As Decimal
      If e.Row.IsNull("Advance") OrElse CStr(e.Row("Advance")).Length = 0 Then
        oldAdvance = 0
      Else
        oldAdvance = CDec(e.Row("Advance"))
      End If
      Dim oldDiscount As Decimal
      If e.Row.IsNull("discount") OrElse CStr(e.Row("discount")).Length = 0 Then
        oldDiscount = 0
      Else
        oldDiscount = Discount.GetFinalDiscount(e.Row("discount").ToString, oldRealAmount - oldAdvance - oldRetention)
      End If
      m_updating = True
      Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
      If e.Row.IsNull("type") Then
        msgServ.ShowMessage("${res:Global.Error.NoPmaType}")
        e.ProposedValue = e.Row(e.Column)
        m_updating = False
        Return
      End If
      Select Case CInt(e.Row("type"))
        Case 75, 78  'งวดงาน/เพิ่ม/ลด
          If oldRealAmount < (value + oldRetention + oldAdvance + oldDiscount) Then
            msgServ.ShowMessage("${res:Global.Error.MilestoneRealAmountLessThanDe}")
            e.ProposedValue = e.Row(e.Column)
            m_updating = False
            Return
          Else
            'e.Row("amount") = Configuration.FormatToString(oldRealAmount - (value + oldRetention + oldAdvance + oldDiscount), DigitConfig.Price)
            Me.m_milestone.Penalty = CDec(e.ProposedValue)
            Me.m_milestone.ResetReal(True)
            e.Row("amount") = Configuration.FormatToString(Me.m_milestone.Amount, DigitConfig.Price)
            Me.UpdateItem()
            UpdateAmount()
            UpdateTotalRow()
          End If
          'Case 79
          ''e.Row("amount") = Configuration.FormatToString(oldRealAmount + (value + oldRetention + oldAdvance + oldDiscount), DigitConfig.Price)
          'Me.m_milestone.Penalty = CDec(e.ProposedValue)
          'Me.m_milestone.ResetReal()
          'e.Row("amount") = Configuration.FormatToString(Me.m_milestone.Amount, DigitConfig.Price)
          'Me.UpdateItem()
          'UpdateAmount()
          'UpdateTotalRow()
        Case Else
          msgServ.ShowMessage("${res:Global.Error.PenaltyCanOnlyBeWithMilestone}")
          e.ProposedValue = e.Row(e.Column)
          m_updating = False
          Return
      End Select
      m_updating = False
    End Sub
    Public Sub SetAdvance(ByVal e As DataColumnChangeEventArgs)
      If m_updating Then
        Return
      End If
      If IsDBNull(e.ProposedValue) OrElse e.ProposedValue.ToString.Length = 0 Then
        e.ProposedValue = 0
      End If
      e.ProposedValue = Configuration.FormatToString(CDec(TextParser.Evaluate(e.ProposedValue.ToString)), DigitConfig.Price)
      Dim value As Decimal = CDec(e.ProposedValue)
      Dim oldPenalty As Decimal
      If e.Row.IsNull("penalty") OrElse CStr(e.Row("penalty")).Length = 0 Then
        oldPenalty = 0
      Else
        oldPenalty = CDec(e.Row("penalty"))
      End If
      Dim oldRealAmount As Decimal
      If e.Row.IsNull("RealAmount") OrElse CStr(e.Row("RealAmount")).Length = 0 Then
        oldRealAmount = 0
      Else
        oldRealAmount = CDec(e.Row("RealAmount"))
      End If
      Dim oldRetention As Decimal
      If e.Row.IsNull("Retention") OrElse CStr(e.Row("Retention")).Length = 0 Then
        oldRetention = 0
      Else
        oldRetention = CDec(e.Row("Retention"))
      End If
      Dim oldAdvance As Decimal
      If e.Row.IsNull("Advance") OrElse CStr(e.Row("Advance")).Length = 0 Then
        oldAdvance = 0
      Else
        oldAdvance = CDec(e.Row("Advance"))
      End If
      Dim oldDiscount As Decimal
      If e.Row.IsNull("discount") OrElse CStr(e.Row("discount")).Length = 0 Then
        oldDiscount = 0
      Else
        oldDiscount = Discount.GetFinalDiscount(e.Row("discount").ToString, oldRealAmount - oldAdvance - oldRetention)
      End If
      m_updating = True
      Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
      If e.Row.IsNull("type") Then
        msgServ.ShowMessage("${res:Global.Error.NoPmaType}")
        e.ProposedValue = e.Row(e.Column)
        m_updating = False
        Return
      End If
      Select Case CInt(e.Row("type"))
        Case 75, 78 'งวดงาน, งานเพิ่ม
          If oldRealAmount < (value + oldRetention + oldPenalty + oldDiscount) Then
            msgServ.ShowMessage("${res:Global.Error.MilestoneRealAmountLessThanDe}")
            e.ProposedValue = e.Row(e.Column)
            m_updating = False
            Return
          Else
            'e.Row("amount") = Configuration.FormatToString(oldRealAmount - (value + oldRetention + oldPenalty + oldDiscount), DigitConfig.Price)
            Me.m_milestone.Advance = CDec(e.ProposedValue)
            Me.m_milestone.ResetReal(True)
            e.Row("amount") = Configuration.FormatToString(Me.m_milestone.Amount, DigitConfig.Price)
            Me.UpdateItem()
            UpdateAmount()
            UpdateTotalRow()
          End If
        Case Else
          msgServ.ShowMessage("${res:Global.Error.AdvanceCanOnlyBeWithMilestone}")
          e.ProposedValue = e.Row(e.Column)
          m_updating = False
          Return
      End Select
      m_updating = False
    End Sub
    Public Sub SetRetention(ByVal e As DataColumnChangeEventArgs)
      If m_updating Then
        Return
      End If
      If IsDBNull(e.ProposedValue) OrElse e.ProposedValue.ToString.Length = 0 Then
        e.ProposedValue = 0
      End If
      e.ProposedValue = Configuration.FormatToString(CDec(TextParser.Evaluate(e.ProposedValue.ToString)), DigitConfig.Price)
      Dim value As Decimal = CDec(e.ProposedValue)
      Dim oldPenalty As Decimal
      If e.Row.IsNull("penalty") OrElse CStr(e.Row("penalty")).Length = 0 Then
        oldPenalty = 0
      Else
        oldPenalty = CDec(e.Row("penalty"))
      End If
      Dim oldRealAmount As Decimal
      If e.Row.IsNull("RealAmount") OrElse CStr(e.Row("RealAmount")).Length = 0 Then
        oldRealAmount = 0
      Else
        oldRealAmount = CDec(e.Row("RealAmount"))
      End If
      Dim oldRetention As Decimal
      If e.Row.IsNull("Retention") OrElse CStr(e.Row("Retention")).Length = 0 Then
        oldRetention = 0
      Else
        oldRetention = CDec(e.Row("Retention"))
      End If
      Dim oldAdvance As Decimal
      If e.Row.IsNull("Advance") OrElse CStr(e.Row("Advance")).Length = 0 Then
        oldAdvance = 0
      Else
        oldAdvance = CDec(e.Row("Advance"))
      End If
      Dim oldDiscount As Decimal
      If e.Row.IsNull("discount") OrElse CStr(e.Row("discount")).Length = 0 Then
        oldDiscount = 0
      Else
        oldDiscount = Discount.GetFinalDiscount(e.Row("discount").ToString, oldRealAmount - oldAdvance - oldRetention)
      End If
      m_updating = True
      Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
      If e.Row.IsNull("type") Then
        msgServ.ShowMessage("${res:Global.Error.NoPmaType}")
        e.ProposedValue = e.Row(e.Column)
        m_updating = False
        Return
      End If
      Select Case CInt(e.Row("type"))
        Case 75, 78 'งวดงาน, งานเพิ่ม
          If oldRealAmount < (value + oldAdvance + oldPenalty + oldDiscount) Then
            msgServ.ShowMessage("${res:Global.Error.MilestoneRealAmountLessThanDe}")
            e.ProposedValue = e.Row(e.Column)
            m_updating = False
            Return
          Else
            'e.Row("amount") = Configuration.FormatToString(oldRealAmount - (value + oldAdvance + oldPenalty + oldDiscount), DigitConfig.Price)
            Me.m_milestone.Retention = CDec(e.ProposedValue)
            Me.m_milestone.ResetReal(True)
            e.Row("amount") = Configuration.FormatToString(Me.m_milestone.Amount, DigitConfig.Price)
            Me.UpdateItem()
            UpdateAmount()
            UpdateTotalRow()
          End If
        Case Else
          msgServ.ShowMessage("${res:Global.Error.RetentionCanOnlyBeWithMilestone}")
          e.ProposedValue = e.Row(e.Column)
          m_updating = False
          Return
      End Select
      m_updating = False
    End Sub
    Public Sub SetRealAmount(ByVal e As DataColumnChangeEventArgs)
      If m_updating Then
        Return
      End If
      If IsDBNull(e.ProposedValue) OrElse e.ProposedValue.ToString.Length = 0 Then
        e.ProposedValue = 0
      End If
      e.ProposedValue = Configuration.FormatToString(CDec(TextParser.Evaluate(e.ProposedValue.ToString)), DigitConfig.Price)
      Dim value As Decimal = CDec(e.ProposedValue)
      Dim oldPenalty As Decimal
      If e.Row.IsNull("penalty") OrElse CStr(e.Row("penalty")).Length = 0 Then
        oldPenalty = 0
      Else
        oldPenalty = CDec(e.Row("penalty"))
      End If
      Dim oldRealAmount As Decimal
      If e.Row.IsNull("RealAmount") OrElse CStr(e.Row("RealAmount")).Length = 0 Then
        oldRealAmount = 0
      Else
        oldRealAmount = CDec(e.Row("RealAmount"))
      End If
      Dim oldRetention As Decimal
      If e.Row.IsNull("Retention") OrElse CStr(e.Row("Retention")).Length = 0 Then
        oldRetention = 0
      Else
        oldRetention = CDec(e.Row("Retention"))
      End If
      Dim oldAdvance As Decimal
      If e.Row.IsNull("Advance") OrElse CStr(e.Row("Advance")).Length = 0 Then
        oldAdvance = 0
      Else
        oldAdvance = CDec(e.Row("Advance"))
      End If
      Dim oldDiscount As Decimal
      If e.Row.IsNull("discount") OrElse CStr(e.Row("discount")).Length = 0 Then
        oldDiscount = 0
      Else
        oldDiscount = Discount.GetFinalDiscount(e.Row("discount").ToString, oldRealAmount - oldAdvance - oldRetention)
      End If
      m_updating = True
      Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
      If e.Row.IsNull("type") Then
        msgServ.ShowMessage("${res:Global.Error.NoPmaType}")
        e.ProposedValue = e.Row(e.Column)
        m_updating = False
        Return
      End If
      Select Case CInt(e.Row("type"))
        Case 75, 78 'งวดงาน/เพิ่ม
          If value < (oldAdvance + oldPenalty + oldRetention + oldDiscount) Then
            'msgServ.ShowMessage("${res:Global.Error.MilestoneRealAmountLessThanDe}")
            'e.ProposedValue = e.Row(e.Column)
            'm_updating = False
            'Return
            e.Row("Advance") = ""
            e.Row("Retention") = ""
            e.Row("Discount") = ""
            e.Row("Penalty") = ""
            m_milestone.Advance = 0
            m_milestone.Retention = 0
            m_milestone.Discount = New Discount("0")
            m_milestone.Penalty = 0
          End If
          'Else
          'e.Row("amount") = Configuration.FormatToString(value - (oldAdvance + oldPenalty + oldRetention + oldDiscount), DigitConfig.Price)
          Me.m_milestone.MileStoneAmount = CDec(e.ProposedValue)
          Me.m_milestone.ResetReal(True)
          e.Row("amount") = Configuration.FormatToString(Me.m_milestone.Amount, DigitConfig.Price)
          Me.UpdateItem()
          UpdateAmount()
          UpdateTotalRow()
          'End If
        Case 79 '/ลด
          'e.Row("amount") = Configuration.FormatToString(value + (oldAdvance + oldPenalty + oldRetention + oldDiscount), DigitConfig.Price)
          Me.m_milestone.MileStoneAmount = CDec(e.ProposedValue)
          Me.m_milestone.ResetReal(True)
          e.Row("amount") = Configuration.FormatToString(Me.m_milestone.Amount, DigitConfig.Price)
          Me.UpdateItem()
          UpdateAmount()
          UpdateTotalRow()
        Case 86
          'e.Row("amount") = value
          Me.m_milestone.MileStoneAmount = CDec(e.ProposedValue)
          Me.m_milestone.ResetReal(True)
          e.Row("amount") = Configuration.FormatToString(Me.m_milestone.Amount, DigitConfig.Price)
          Me.UpdateItem()
          UpdateAmount()
          UpdateTotalRow()
        Case 77
          'e.Row("amount") = value
          Me.m_milestone.MileStoneAmount = CDec(e.ProposedValue)
          Me.m_milestone.ResetReal(True)
          e.Row("amount") = Configuration.FormatToString(Me.m_milestone.Amount, DigitConfig.Price)
          Me.UpdateItem()
          UpdateAmount()
          UpdateTotalRow()
      End Select
      m_updating = False
    End Sub
    Public Sub SetDocDate(ByVal e As DataColumnChangeEventArgs)
      If m_updating Then
        Return
      End If
      m_updating = True
      Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
      If e.Row.IsNull("type") Then
        msgServ.ShowMessage("${res:Global.Error.NoPmaType}")
        e.ProposedValue = e.Row(e.Column)
        m_updating = False
        Return
      End If
      Select Case CInt(e.Row("type"))
        Case 75, 78, 79, 86, 77
          'ผ่าน
          Me.m_milestone.DocDate = CDate(e.ProposedValue)
          Me.UpdateItem()
          UpdateAmount()
          UpdateTotalRow()
      End Select
      m_updating = False
    End Sub
    Public Sub SetEntityType(ByVal e As DataColumnChangeEventArgs)
      If m_updating Then
        Return
      End If
      m_updating = True
      If CInt(e.ProposedValue) = CInt(e.Row(e.Column)) Then
        m_updating = False
        Return
      End If
      Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
      'Select Case CInt(e.ProposedValue)
      '    Case 77 'Retention
      '        msgServ.ShowMessage("${res:Global.Error.CannotSetTypeToRetention}")
      '        e.ProposedValue = e.Row(e.Column)
      '        m_updating = False
      '        Return
      '    Case 86 'Advance
      '        msgServ.ShowMessage("${res:Global.Error.CannotSetTypeToAdvance}")
      '        e.ProposedValue = e.Row(e.Column)
      '        m_updating = False
      '        Return
      'End Select
      Dim newMi As Milestone = m_milestone.Clone(New MilestoneType(CInt(e.ProposedValue)))
      Me.m_entity.ItemCollection(Me.m_entity.ItemCollection.IndexOf(m_milestone)) = newMi
      m_milestone = newMi
      Me.m_treeManager.SelectedRow.Tag = m_milestone

      '---------------------------------------------------------------------------------------
      Dim row As TreeRow = Me.m_treeManager.SelectedRow
      If row Is Nothing Then
        Return
      End If
      If Me.m_milestone Is Nothing Then
        Return
      End If
      Dim flag As Boolean = Me.m_tableInitialized
      Me.m_tableInitialized = False
      'row("Type") = m_milestone.Type.Value
      row("Code") = m_milestone.Code
      row("Autogen") = m_milestone.AutoGen
      row("Name") = m_milestone.Name
      row("DocDate") = m_milestone.DocDate
      row("HandedDate") = m_milestone.HandedDate
      row("BillIssueDate") = m_milestone.BillIssueDate

      Select Case m_milestone.Type.Value
        Case 75
          'ผ่าน
          AutoFillRealAmount(m_milestone)
          row("Advance") = Configuration.FormatToString(m_milestone.Advance, DigitConfig.Price)
          row("Retention") = Configuration.FormatToString(m_milestone.Retention, DigitConfig.Price)
          row("Discount") = m_milestone.Discount.Rate
          row("Penalty") = Configuration.FormatToString(m_milestone.Penalty, DigitConfig.Price)
        Case 78 'เพิ่ม
          'ผ่าน
          AutoFillRealAmount(m_milestone)
          row("Advance") = Configuration.FormatToString(m_milestone.Advance, DigitConfig.Price)
          row("Retention") = Configuration.FormatToString(m_milestone.Retention, DigitConfig.Price)
          row("Discount") = m_milestone.Discount.Rate
          row("Penalty") = Configuration.FormatToString(m_milestone.Penalty, DigitConfig.Price)
        Case 79 'ลด
          row("Advance") = ""
          m_milestone.Advance = 0
          row("Retention") = ""
          m_milestone.Retention = 0
          row("Discount") = m_milestone.Discount.Rate
          row("Penalty") = Configuration.FormatToString(m_milestone.Penalty, DigitConfig.Price)
        Case 86 'advance
          row("Advance") = ""
          row("Retention") = ""
          row("Discount") = ""
          row("Penalty") = ""
          m_milestone.SetMilestoneAdvr()
          
        Case 77 'retention
          row("Advance") = ""
          row("Retention") = ""
          row("Discount") = ""
          row("Penalty") = ""
          m_milestone.SetMilestoneRetention()
         
        Case Else
          row("Advance") = ""
          row("Retention") = ""
          row("Discount") = ""
          row("Penalty") = ""
          row("RealAmount") = Configuration.FormatToString(m_milestone.MileStoneAmount, DigitConfig.Price)
          row("Amount") = Configuration.FormatToString(m_milestone.Amount, DigitConfig.Price)
      End Select

      row("RealAmount") = Configuration.FormatToString(m_milestone.MileStoneAmount, DigitConfig.Price)
      row("Amount") = Configuration.FormatToString(m_milestone.Amount, DigitConfig.Price)
      row("Status") = m_milestone.Status.Value
      row("Note") = m_milestone.Note
      '----------------------------------------------------------------------------------------------------
      Me.UpdateItem()
      UpdateAmount()
      UpdateTotalRow()
      m_updating = False
      Me.m_tableInitialized = flag
    End Sub
    Private Function DupCode(ByVal e As DataColumnChangeEventArgs) As Boolean
      If e.Row.IsNull("type") Then
        Return False
      End If
      If IsDBNull(e.ProposedValue) Then
        Return False
      End If
      For Each row As TreeRow In Me.m_treeManager.Treetable.Childs
        If Not row Is e.Row Then
          If Not row.IsNull("type") Then
            If CInt(row("type")) = CInt(e.Row("type")) Then
              If Not row.IsNull("code") Then
                If e.ProposedValue.ToString.ToLower = row("code").ToString.ToLower Then
                  Return True
                End If
              End If
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
      m_updating = True
      Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
      If e.Row.IsNull("type") Then
        msgServ.ShowMessage("${res:Global.Error.NoPmaType}")
        e.ProposedValue = e.Row(e.Column)
        m_updating = False
        Return
      End If
      If DupCode(e) Then
        msgServ.ShowMessageFormatted("${res:Global.Error.AlreadyHasCode}", New String() {m_milestone.Type.Description, e.ProposedValue.ToString})
        e.ProposedValue = e.Row(e.Column)
        m_updating = False
        Return
      End If
      Select Case CInt(e.Row("type"))
        Case 75, 78, 79, 86, 77
          'ผ่าน
          Me.m_milestone.Code = e.ProposedValue.ToString
          Me.UpdateItem()
          UpdateAmount()
          UpdateTotalRow()
      End Select
      m_updating = False
    End Sub
    Public Sub SetName(ByVal e As DataColumnChangeEventArgs)
      If m_updating Then
        Return
      End If
      m_updating = True
      Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
      If e.Row.IsNull("type") Then
        msgServ.ShowMessage("${res:Global.Error.NoPmaType}")
        e.ProposedValue = e.Row(e.Column)
        m_updating = False
        Return
      End If
      Select Case CInt(e.Row("type"))
        Case 75, 78, 79, 86, 77
          'ผ่าน
          Me.m_milestone.Name = e.ProposedValue.ToString
          Me.UpdateItem()
          UpdateAmount()
          UpdateTotalRow()
      End Select
      m_updating = False
    End Sub
    Public Sub SetNote(ByVal e As DataColumnChangeEventArgs)
      If m_updating Then
        Return
      End If
      m_updating = True
      Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
      If e.Row.IsNull("type") Then
        msgServ.ShowMessage("${res:Global.Error.NoPmaType}")
        e.ProposedValue = e.Row(e.Column)
        m_updating = False
        Return
      End If
      Select Case CInt(e.Row("type"))
        Case 75, 78, 79, 86, 77
          'ผ่าน
          Me.m_milestone.Note = e.ProposedValue.ToString
          Me.UpdateItem()
          UpdateAmount()
          UpdateTotalRow()
      End Select
      m_updating = False
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
        Me.Enabled = False
      Else
        Me.Enabled = True
      End If
    End Sub
    Public Overrides Sub ClearDetail()
      Me.StatusBarService.SetMessage("")
      For Each crlt As Control In Me.grbDetail.Controls
        If crlt.Name.StartsWith("txt") Then
          crlt.Text = ""
        End If
      Next
      For Each crlt As Control In Me.Controls
        If crlt.Name.StartsWith("txt") Then
          crlt.Text = ""
        End If
      Next
      Me.dtpStartDate.Value = Now
      Me.dtpCompletionDate.Value = Now
      Me.dtpItemDocDate.Value = Now
      Me.dtpItemHandedDate.Value = Now
      Me.dtpItemBillIssueDate.Value = Now
      cmbTaxType.SelectedIndex = 1
      ClearItem()
    End Sub
    Public Overrides Sub SetLabelText()
      If Not m_entity Is Nothing Then Me.Text = Me.StringParserService.Parse(Me.m_entity.TabPageText)
      Me.lblProject.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PaymentApplicationDetail.lblProject}")
      Me.lblCustomer.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PaymentApplicationDetail.lblCustomer}")
      Me.grbDetail.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PaymentApplicationDetail.grbDetail}")
      Me.lblInc.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PaymentApplicationDetail.lblInc}")
      Me.lblContractAmount.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PaymentApplicationDetail.lblContractAmount}")
      Me.lblDe.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PaymentApplicationDetail.lblDe}")
      Me.lblTotal.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PaymentApplicationDetail.lblTotal}")
      Me.lblItem.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PaymentApplicationDetail.lblItem}")
      Me.lblPenalty.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PaymentApplicationDetail.lblPenalty}")
      Me.grbPaymentApplication.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PaymentApplicationDetail.grbPaymentApplication}")
      Me.lblFinish.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PaymentApplicationDetail.lblFinish}")
      Me.lblDuration.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PaymentApplicationDetail.lblDuration}")
      Me.lblTaxType.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PaymentApplicationDetail.lblTaxType}")
      Me.lblTaxPoint.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PaymentApplicationDetail.lblTaxPoint}")
      Me.lblPenaltyUnit.Text = Me.StringParserService.Parse("${res:Global.CurrencyUnit}")
      Me.lblBudgetUnit.Text = Me.StringParserService.Parse("${res:Global.CurrencyUnit}")
      Me.lblBudget.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PaymentApplicationDetail.lblBudget}")
      Me.lblStart.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PaymentApplicationDetail.lblStart}")
      Me.lblTotalAmountUnit.Text = Me.StringParserService.Parse("${res:Global.CurrencyUnit}")
      Me.lblDiscount.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PaymentApplicationDetail.lblDiscount}")
      Me.lblDiscountUnit.Text = Me.StringParserService.Parse("${res:Global.CurrencyUnit}")
      Me.lblValueUnit.Text = Me.StringParserService.Parse("${res:Global.CurrencyUnit}")
      Me.lblPercent.Text = Me.StringParserService.Parse("${res:Global.PercentText}")
      Me.lblIncUnit.Text = Me.StringParserService.Parse("${res:Global.CurrencyUnit}")
      Me.lblDeUnit.Text = Me.StringParserService.Parse("${res:Global.CurrencyUnit}")
      Me.lblBOQ.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PaymentApplicationDetail.lblBOQ}")
      Me.lblAdvr.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PaymentApplicationDetail.lblAdvr}")
      Me.lblAdvrUnit.Text = Me.StringParserService.Parse("${res:Global.CurrencyUnit}")
      Me.lblRetention.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PaymentApplicationDetail.lblRetention}")
      Me.lblRetentionUnit.Text = Me.StringParserService.Parse("${res:Global.CurrencyUnit}")
      Me.lblItemType.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PaymentApplicationDetail.lblItemType}")
      Me.lblItemCode.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PaymentApplicationDetail.lblItemCode}")
      Me.lblItemName.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PaymentApplicationDetail.lblItemName}")
      Me.lblItemDiscount.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PaymentApplicationDetail.lblItemDiscount}")
      Me.lblItemRealAmount.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PaymentApplicationDetail.lblItemRealAmount}")
      Me.lblItemStatus.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PaymentApplicationDetail.lblItemStatus}")
      Me.lblItemAdvr.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PaymentApplicationDetail.lblItemAdvr}")
      Me.lblItemRetention.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PaymentApplicationDetail.lblItemRetention}")
      Me.lblItemDocDate.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PaymentApplicationDetail.lblItemDocDate}")
      Me.lblItemHandedDate.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PaymentApplicationDetail.lblItemHandedDate}")
      Me.lblItemBillIssueDate.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PaymentApplicationDetail.lblItemBillIssueDate}")
      Me.lblItemReceiveDate.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PaymentApplicationDetail.lblItemReceiveDate}")
      Me.lblItemAmount.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PaymentApplicationDetail.lblItemAmount}")
      Me.lblItemPenalty.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PaymentApplicationDetail.lblItemPenalty}")
      Me.lblItemNote.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PaymentApplicationDetail.lblItemNote}")
      Me.grbContract.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PaymentApplicationDetail.grbContract}")
      Me.grbAdvrRetention.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PaymentApplicationDetail.grbAdvrRetention}")
    End Sub
    Protected Overrides Sub EventWiring()
      AddHandler txtCostCenterCode.Validated, AddressOf Me.ChangeProperty
      AddHandler txtBOQCode.Validated, AddressOf Me.ChangeProperty

      AddHandler txtStartDate.Validated, AddressOf Me.ChangeProperty
      AddHandler dtpStartDate.ValueChanged, AddressOf Me.ChangeProperty

      AddHandler txtCompletionDate.Validated, AddressOf Me.ChangeProperty
      AddHandler dtpCompletionDate.ValueChanged, AddressOf Me.ChangeProperty

      AddHandler txtDuration.TextChanged, AddressOf Me.ChangeProperty
      AddHandler cmbDurationUnit.SelectedIndexChanged, AddressOf Me.ChangeProperty


      AddHandler cmbTaxPoint.SelectedIndexChanged, AddressOf Me.ChangeProperty
      AddHandler cmbTaxType.SelectedIndexChanged, AddressOf Me.ChangeProperty

      AddHandler txtBudget.TextChanged, AddressOf Me.ChangeProperty
      AddHandler txtContractAmount.TextChanged, AddressOf Me.TextChangedHandler
      AddHandler txtAdvr.TextChanged, AddressOf Me.TextChangedHandler
      AddHandler txtRetention.TextChanged, AddressOf Me.TextChangedHandler

      AddHandler txtBudget.Validated, AddressOf Me.TextHandler
      AddHandler txtContractAmount.Validated, AddressOf Me.TextHandler
      AddHandler txtAdvr.Validated, AddressOf Me.TextHandler
      AddHandler txtRetention.Validated, AddressOf Me.TextHandler

      'Item Detail ------********
      AddHandler txtItemCode.TextChanged, AddressOf Me.ChangeProperty
      AddHandler cmbItemType.SelectedIndexChanged, AddressOf Me.ChangeProperty

      AddHandler txtItemDocDate.Validated, AddressOf Me.ChangeProperty
      AddHandler dtpItemDocDate.ValueChanged, AddressOf Me.ChangeProperty

      AddHandler txtItemName.TextChanged, AddressOf Me.ChangeProperty
      AddHandler cmbItemStatus.SelectedIndexChanged, AddressOf Me.ChangeProperty

      AddHandler txtItemRealAmount.TextChanged, AddressOf Me.TextChangedHandler
      AddHandler txtItemAmount.TextChanged, AddressOf Me.TextChangedHandler
      AddHandler txtItemAdvr.TextChanged, AddressOf Me.TextChangedHandler
      AddHandler txtItemRetention.TextChanged, AddressOf Me.TextChangedHandler
      AddHandler txtItemPenalty.TextChanged, AddressOf Me.TextChangedHandler
      AddHandler txtItemDiscount.TextChanged, AddressOf Me.TextChangedHandler

      AddHandler txtItemRealAmount.Validated, AddressOf Me.TextHandler
      AddHandler txtItemAmount.Validated, AddressOf Me.TextHandler
      AddHandler txtItemAdvr.Validated, AddressOf Me.TextHandler
      AddHandler txtItemRetention.Validated, AddressOf Me.TextHandler
      AddHandler txtItemPenalty.Validated, AddressOf Me.TextHandler
      AddHandler txtItemDiscount.Validated, AddressOf Me.TextHandler

      AddHandler txtItemHandedDate.Validated, AddressOf Me.ChangeProperty
      AddHandler dtpItemHandedDate.ValueChanged, AddressOf Me.ChangeProperty

      AddHandler txtItemBillIssueDate.Validated, AddressOf Me.ChangeProperty
      AddHandler dtpItemBillIssueDate.ValueChanged, AddressOf Me.ChangeProperty

      AddHandler txtItemNote.TextChanged, AddressOf Me.ChangeProperty

    End Sub
    Private Sub SetNumberTextBox(ByVal txtBox As TextBox, ByRef prop As Decimal, ByVal dgf As DigitConfig)
      Dim txt As String = txtBox.Text
      txt = txt.Replace(",", "")
      If txt.Length = 0 Then
        prop = 0
      Else
        Try
          prop = CDec(TextParser.Evaluate(txt))
        Catch ex As Exception
          prop = 0
        End Try
      End If
      txtBox.Text = Configuration.FormatToString(prop, dgf)
    End Sub
    Private Sub TextChangedHandler(ByVal sender As Object, ByVal e As EventArgs)
      If Me.m_entity Is Nothing Or Not m_isInitialized Then
        Return
      End If
      Dim dirtyFlag As Boolean = False
      Select Case CType(sender, Control).Name.ToLower
        Case "txtcontractamount"
          dirtyFlag = True
          txtContractAmountChanged = True
        Case "txtadvr"
          dirtyFlag = True
          txtAdvrChanged = True
        Case "txtretention"
          dirtyFlag = True
          txtRetentionChanged = True

          'Item
        Case "txtitemrealamount"
          txtItemRealAmountChanged = True
          If Not Me.m_milestone Is Nothing AndAlso Me.m_milestone.Status.Value < 3 AndAlso Me.m_milestone.Status.Value <> 0 Then
            dirtyFlag = True
          End If
        Case "txtitemadvr"
          txtItemAdvrChanged = True
          If Not Me.m_milestone Is Nothing AndAlso Me.m_milestone.Status.Value < 3 AndAlso Me.m_milestone.Status.Value <> 0 Then
            dirtyFlag = True
          End If
        Case "txtitemretention"
          txtItemRetentionChanged = True
          If Not Me.m_milestone Is Nothing AndAlso Me.m_milestone.Status.Value < 3 AndAlso Me.m_milestone.Status.Value <> 0 Then
            dirtyFlag = True
          End If
        Case "txtitempenalty"
          txtItemPenaltyChanged = True
          If Not Me.m_milestone Is Nothing AndAlso Me.m_milestone.Status.Value < 3 AndAlso Me.m_milestone.Status.Value <> 0 Then
            dirtyFlag = True
          End If
        Case "txtitemdiscount"
          txtItemDiscountChanged = True
          If Not Me.m_milestone Is Nothing AndAlso Me.m_milestone.Status.Value < 3 AndAlso Me.m_milestone.Status.Value <> 0 Then
            dirtyFlag = True
          End If
        Case Else
      End Select
      Me.WorkbenchWindow.ViewContent.IsDirty = Me.WorkbenchWindow.ViewContent.IsDirty Or dirtyFlag
      CheckFormEnable()
    End Sub
    Private txtContractAmountChanged As Boolean = False
    Private txtAdvrChanged As Boolean = False
    Private txtRetentionChanged As Boolean = False
    Private txtItemRealAmountChanged As Boolean = False
    Private txtItemAdvrChanged As Boolean = False
    Private txtItemRetentionChanged As Boolean = False
    Private txtItemPenaltyChanged As Boolean = False
    Private txtItemDiscountChanged As Boolean = False
    Private Sub TextHandler(ByVal sender As Object, ByVal e As EventArgs)
      If Me.m_entity Is Nothing Or Not m_isInitialized Then
        Return
      End If
      Dim row As TreeRow = Me.m_treeManager.SelectedRow
      Select Case CType(sender, Control).Name.ToLower
        Case "txtbudget"
          SetNumberTextBox(txtBudget, Me.m_entity.Budget, DigitConfig.Price)
        Case "txtcontractamount"
          If txtContractAmountChanged Then
            SetNumberTextBox(txtContractAmount, Me.m_entity.ContractAmount, DigitConfig.Price)
            Me.PopulateItemListing()
            UpdateAmount()
            txtContractAmountChanged = False
          End If
        Case "txtadvr"
          If txtAdvrChanged Then
            SetNumberTextBox(txtAdvr, Me.m_entity.Advance, DigitConfig.Price)
            Me.PopulateItemListing()
            UpdateAmount()
            txtAdvrChanged = False
          End If
        Case "txtretention"
          If txtRetentionChanged Then
            SetNumberTextBox(txtRetention, Me.m_entity.Retention, DigitConfig.Price)
            Me.PopulateItemListing()
            UpdateAmount()
            txtRetentionChanged = False
          End If

          'Item
        Case "txtitemrealamount"
          If txtItemRealAmountChanged Then
            If Not Me.m_milestone Is Nothing AndAlso Me.m_milestone.Status.Value < 3 AndAlso Me.m_milestone.Status.Value <> 0 Then
              If Me.m_milestone.Type.Value <> 77 And Me.m_milestone.Type.Value <> 86 Then
                SetNumberTextBox(txtItemRealAmount, Me.m_milestone.MileStoneAmount, DigitConfig.Price)
                Dim re As New DataColumnChangeEventArgs(row _
                , Me.m_treeManager.Treetable.Columns("realamount") _
                , Me.m_milestone.MileStoneAmount)
                ValidateRow(re)
                UpdateAmount()
                Me.UpdateItemRow()
              Else
                'มัดจำ/Retention
                txtItemRealAmount.Text = Configuration.FormatToString(Me.m_milestone.MileStoneAmount, DigitConfig.Price)
              End If
            Else
              txtItemRealAmount.Text = ""
            End If
            txtItemRealAmountChanged = False
          End If
        Case "txtitemadvr"
          If txtItemAdvrChanged Then
            If Not Me.m_milestone Is Nothing AndAlso Me.m_milestone.Status.Value < 3 AndAlso Me.m_milestone.Status.Value <> 0 Then
              If Me.m_milestone.Type.Value <> 77 And Me.m_milestone.Type.Value <> 86 Then
                SetNumberTextBox(txtItemAdvr, Me.m_milestone.Advance, DigitConfig.Price)
                Dim re As New DataColumnChangeEventArgs(row _
                , Me.m_treeManager.Treetable.Columns("advance") _
                , Me.m_milestone.Advance)
                ValidateRow(re)
                UpdateAmount()
                Me.UpdateItemRow()
              Else
                'มัดจำ/Retention
                txtItemAdvr.Text = Configuration.FormatToString(Me.m_milestone.Advance, DigitConfig.Price)
              End If
            Else
              txtItemAdvr.Text = ""
            End If
            txtItemAdvrChanged = False
          End If
        Case "txtitemretention"
          If txtItemRetentionChanged Then
            If Not Me.m_milestone Is Nothing AndAlso Me.m_milestone.Status.Value < 3 AndAlso Me.m_milestone.Status.Value <> 0 Then
              If Me.m_milestone.Type.Value <> 77 And Me.m_milestone.Type.Value <> 86 Then
                SetNumberTextBox(txtItemRetention, Me.m_milestone.Retention, DigitConfig.Price)
                Dim re As New DataColumnChangeEventArgs(row _
                , Me.m_treeManager.Treetable.Columns("retention") _
                , Me.m_milestone.Retention)
                ValidateRow(re)
                UpdateAmount()
                Me.UpdateItemRow()
              Else
                'มัดจำ/Retention
                txtItemRetention.Text = Configuration.FormatToString(Me.m_milestone.Retention, DigitConfig.Price)
              End If
            Else
              txtItemRetention.Text = ""
            End If
            txtItemRetentionChanged = False
          End If
        Case "txtitempenalty"
          If txtItemPenaltyChanged Then
            If Not Me.m_milestone Is Nothing AndAlso Me.m_milestone.Status.Value < 3 AndAlso Me.m_milestone.Status.Value <> 0 Then
              If Me.m_milestone.Type.Value <> 77 And Me.m_milestone.Type.Value <> 86 Then
                SetNumberTextBox(txtItemPenalty, Me.m_milestone.Penalty, DigitConfig.Price)
                Dim re As New DataColumnChangeEventArgs(row _
                , Me.m_treeManager.Treetable.Columns("penalty") _
                , Me.m_milestone.Penalty)
                ValidateRow(re)
                UpdateAmount()
                Me.UpdateItemRow()
              Else
                'มัดจำ/Retention
                txtItemPenalty.Text = Configuration.FormatToString(Me.m_milestone.Penalty, DigitConfig.Price)
              End If
            Else
              txtItemPenalty.Text = ""
            End If
            txtItemPenaltyChanged = False
          End If
        Case "txtitemdiscount"
          If txtItemDiscountChanged Then
            If Not Me.m_milestone Is Nothing AndAlso Me.m_milestone.Status.Value < 3 AndAlso Me.m_milestone.Status.Value <> 0 Then
              If Me.m_milestone.Type.Value <> 77 And Me.m_milestone.Type.Value <> 86 Then
                Me.m_milestone.Discount.Rate = Me.txtItemDiscount.Text
                Dim re As New DataColumnChangeEventArgs(row _
                , Me.m_treeManager.Treetable.Columns("discount") _
                , Me.m_milestone.Discount.Rate)
                ValidateRow(re)
                UpdateAmount()
                Me.UpdateItemRow()
              Else
                'มัดจำ/Retention
                txtItemDiscount.Text = Me.m_milestone.Discount.Rate
              End If
            Else
              txtItemDiscount.Text = ""
            End If
            txtItemDiscountChanged = False
          End If
      End Select
    End Sub
    Private m_oldInvoiceCode As String = ""
    Public Overrides Sub UpdateEntityProperties()
      m_isInitialized = False
      ClearDetail()
      If m_entity Is Nothing Then
        Return
      End If

      For Each item As IdValuePair In Me.cmbTaxType.Items
        If Me.m_entity.TaxType.Value = item.Id Then
          Me.cmbTaxType.SelectedItem = item
        End If
      Next
      For Each item As IdValuePair In Me.cmbTaxPoint.Items
        If Me.m_entity.TaxPoint.Value = item.Id Then
          Me.cmbTaxPoint.SelectedItem = item
        End If
      Next

      Me.txtContractAmount.Text = Configuration.FormatToString(Me.m_entity.ContractAmount, DigitConfig.Price)

      Me.chkAutorun.Checked = Not Me.m_entity.ManualBudget
      Me.UpdateAutogenStatus()

      If Not Me.m_entity.Boq Is Nothing Then
        Me.txtBOQCode.Text = Me.m_entity.Boq.Code
      Else
        Me.txtBOQCode.Text = ""
      End If

      Me.txtCompletionDate.Text = Me.MinDateToNull(Me.m_entity.CompletionDate, "")
      Me.dtpCompletionDate.Value = Me.MinDateToNow(Me.m_entity.CompletionDate)

      Me.txtDuration.Text = Configuration.FormatToString(Me.m_entity.Duration, DigitConfig.Int)
      CodeDescription.ComboSelect(cmbDurationUnit, Me.m_entity.DurationUnit)
      Me.txtCostCenterCode.Text = Me.m_entity.CostCenter.Code
      Me.txtCostCenterName.Text = Me.m_entity.CostCenter.Name
      UpdateCC()

      Me.txtStartDate.Text = Me.MinDateToNull(Me.m_entity.StartDate, "")
      Me.dtpStartDate.Value = Me.MinDateToNow(Me.m_entity.StartDate)

      Me.txtTaxRate.Text = Configuration.FormatToString(Me.m_entity.TaxRate, DigitConfig.Price)

      Me.grbTax.Enabled = True

      'Load Items**********************************************************
      Me.PopulateItemListing()
      Me.Validator.DataTable = m_treeManager.Treetable
      '********************************************************************

      RefreshBlankGrid()

      UpdateAmount()

      SetStatus()
      SetLabelText()
      CheckFormEnable()
      m_isInitialized = True
    End Sub
    Private Sub UpdateBOQ()
      Dim flag As Boolean = Me.m_isInitialized
      Me.m_isInitialized = False
      If Not Me.m_entity.Boq Is Nothing Then
        Me.txtBOQCode.Text = Me.m_entity.Boq.Code
        If Not Me.m_entity.ManualBudget Then
          Me.m_entity.Budget = Configuration.Format(Me.m_entity.Boq.TotalBudget, DigitConfig.Price)
          If Me.m_entity.ContractAmount <= 0 Then
            Me.m_entity.ContractAmount = Configuration.Format(Me.m_entity.Boq.FinalBidPrice, DigitConfig.Price)
          End If
        End If
      Else
        Me.txtBOQCode.Text = ""
      End If
      Me.txtBudget.Text = Configuration.FormatToString(Me.m_entity.Budget, DigitConfig.Price)
      Me.txtContractAmount.Text = Configuration.FormatToString(Me.m_entity.ContractAmount, DigitConfig.Price)
      Me.txtCompletionDate.Text = Me.MinDateToNull(Me.m_entity.CompletionDate, "")
      Me.dtpCompletionDate.Value = Me.MinDateToNow(Me.m_entity.CompletionDate)
      Me.txtDuration.Text = Configuration.FormatToString(Me.m_entity.Duration, DigitConfig.Int)
      CodeDescription.ComboSelect(cmbDurationUnit, Me.m_entity.DurationUnit)
      Me.m_isInitialized = flag
    End Sub
    Private m_dateSetting As Boolean = False
    Public Sub ChangeProperty(ByVal sender As Object, ByVal e As EventArgs)
      If Me.m_entity Is Nothing Or Not m_isInitialized Then
        Return
      End If
      Dim row As TreeRow = Me.m_treeManager.SelectedRow
      Dim dirtyFlag As Boolean = False
      Select Case CType(sender, Control).Name.ToLower
        Case "txtcostcentercode"
          dirtyFlag = CostCenter.GetCostCenter(txtCostCenterCode, txtCostCenterName, Me.m_entity.CostCenter, CType(ServiceManager.Services.GetService(GetType(SecurityService)), SecurityService).CurrentUser.Id)
          UpdateCC()
          UpdateAmount()
        Case "txtboqcode"
          dirtyFlag = BOQ.GetBOQ(txtBOQCode, Me.m_entity.Boq)
          UpdateAmount()
        Case "dtpstartdate"
          If Not Me.m_entity.StartDate.Equals(dtpStartDate.Value) Then
            If Not m_dateSetting Then
              Me.txtStartDate.Text = MinDateToNull(dtpStartDate.Value, Me.StringParserService.Parse("${res:Global.BlankDateText}"))
              Me.m_entity.StartDate = dtpStartDate.Value
            End If
            dirtyFlag = True
          End If
        Case "txtstartdate"
          m_dateSetting = True
          If Not Me.txtStartDate.Text.Length = 0 AndAlso Me.Validator.GetErrorMessage(Me.txtStartDate) = "" Then
            Dim theDate As Date = CDate(Me.txtStartDate.Text)
            If Not Me.m_entity.StartDate.Equals(theDate) Then
              dtpStartDate.Value = theDate
              Me.m_entity.StartDate = dtpStartDate.Value
              dirtyFlag = True
            End If
          Else
            dtpStartDate.Value = Date.Now
            Me.m_entity.StartDate = Date.MinValue
            dirtyFlag = True
          End If
          m_dateSetting = False
        Case "dtpcompletiondate"
          If Not Me.m_entity.CompletionDate.Equals(dtpCompletionDate.Value) Then
            If Not m_dateSetting Then
              Me.txtCompletionDate.Text = MinDateToNull(dtpCompletionDate.Value, Me.StringParserService.Parse("${res:Global.BlankDateText}"))
              Me.m_entity.CompletionDate = dtpCompletionDate.Value
            End If
            dirtyFlag = True
          End If
        Case "txtcompletiondate"
          m_dateSetting = True
          If Not Me.txtCompletionDate.Text.Length = 0 AndAlso Me.Validator.GetErrorMessage(Me.txtCompletionDate) = "" Then
            Dim theDate As Date = CDate(Me.txtCompletionDate.Text)
            If Not Me.m_entity.CompletionDate.Equals(theDate) Then
              dtpCompletionDate.Value = theDate
              Me.m_entity.CompletionDate = dtpCompletionDate.Value
              dirtyFlag = True
            End If
          Else
            dtpCompletionDate.Value = Date.Now
            Me.m_entity.CompletionDate = Date.MinValue
            dirtyFlag = True
          End If
          m_dateSetting = False
        Case "txtduration"
          If Me.txtDuration.TextLength > 0 AndAlso Me.Validator.GetErrorMessage(Me.txtDuration) = "" AndAlso IsNumeric(Me.txtDuration.Text) Then
            Me.m_entity.Duration = CInt(Me.txtDuration.Text)
          Else
            Me.m_entity.Duration = 0
          End If
          dirtyFlag = True
        Case "cmbdurationunit"
          Dim item As IdValuePair = CType(Me.cmbDurationUnit.SelectedItem, IdValuePair)
          Me.m_entity.DurationUnit.Value = item.Id
          dirtyFlag = True
        Case "txtbudget"
          dirtyFlag = True
        Case "txtcontractamount"
          UpdateAmount()
          dirtyFlag = True
        Case "txtadvr"
          UpdateAmount()
          dirtyFlag = True
        Case "txtretention"
          UpdateAmount()
          dirtyFlag = True
        Case "cmbtaxpoint"
          Dim item As IdValuePair = CType(Me.cmbTaxPoint.SelectedItem, IdValuePair)
          Me.m_entity.TaxPoint.Value = item.Id
          dirtyFlag = True
        Case "cmbtaxtype"
          Dim item As IdValuePair = CType(Me.cmbTaxType.SelectedItem, IdValuePair)
          Me.m_entity.TaxType.Value = item.Id
          Me.m_entity.ItemCollection.ResetReal(True)
          Me.PopulateItemListing()
          UpdateAmount()
          dirtyFlag = True

          'Item
        Case "txtitemcode"
          If Not Me.m_milestone Is Nothing AndAlso Me.m_milestone.Status.Value < 3 AndAlso Me.m_milestone.Status.Value <> 0 Then
            m_milestone.Code = txtItemCode.Text
            Me.UpdateItemRow()
            dirtyFlag = True
            Dim re As New DataColumnChangeEventArgs(row _
            , Me.m_treeManager.Treetable.Columns("code") _
            , Me.m_milestone.Code)
            ValidateRow(re)
          End If
        Case "cmbitemtype"
          If Not Me.m_milestone Is Nothing AndAlso Me.m_milestone.Status.Value < 3 AndAlso Me.m_milestone.Status.Value <> 0 Then
            Dim item As IdValuePair = CType(Me.cmbItemType.SelectedItem, IdValuePair)
            Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
            Select Case item.Id
              Case 77 'Retention
                msgServ.ShowMessage("${res:Global.Error.CannotSetTypeToRetention}")
              Case 86 'Advance
                msgServ.ShowMessage("${res:Global.Error.CannotSetTypeToAdvance}")
              Case Else
                Dim newMi As Milestone = m_milestone.Clone(New MilestoneType(item.Id))
                Me.m_entity.ItemCollection(Me.m_entity.ItemCollection.IndexOf(m_milestone)) = newMi
                m_milestone = newMi
                Me.m_treeManager.SelectedRow.Tag = m_milestone
                UpdateAmount()
                Me.UpdateItemRow()
                Dim re As New DataColumnChangeEventArgs(row _
                , Me.m_treeManager.Treetable.Columns("type") _
                , Me.m_milestone.Type.Value)
                ValidateRow(re)
                dirtyFlag = True
            End Select
          End If
        Case "txtitemdocdate"
          If Not Me.m_milestone Is Nothing AndAlso Me.m_milestone.Status.Value < 3 AndAlso Me.m_milestone.Status.Value <> 0 Then
            m_dateSetting = True
            If Not Me.txtItemDocDate.Text.Length = 0 AndAlso Me.Validator.GetErrorMessage(Me.txtItemDocDate) = "" Then
              Dim theDate As Date = CDate(Me.txtItemDocDate.Text)
              If Not Me.m_milestone.DocDate.Equals(theDate) Then
                dtpItemDocDate.Value = theDate
                Me.m_milestone.DocDate = dtpItemDocDate.Value
                dirtyFlag = True
                UpdateItemRow()
                Dim re As New DataColumnChangeEventArgs(row _
                , Me.m_treeManager.Treetable.Columns("docdate") _
                , Me.m_milestone.DocDate)
                ValidateRow(re)
              End If
            Else
              dtpItemDocDate.Value = Date.Now
              Me.m_milestone.DocDate = Date.MinValue
              dirtyFlag = True
              UpdateItemRow()
              Dim re As New DataColumnChangeEventArgs(row _
              , Me.m_treeManager.Treetable.Columns("docdate") _
              , Me.m_milestone.DocDate)
              ValidateRow(re)
            End If
            m_dateSetting = False
          End If
        Case "dtpitemdocdate"
          If Not Me.m_milestone Is Nothing AndAlso Me.m_milestone.Status.Value < 3 AndAlso Me.m_milestone.Status.Value <> 0 Then
            If Not Me.m_milestone.DocDate.Equals(dtpItemDocDate.Value) Then
              If Not m_dateSetting Then
                Me.txtItemDocDate.Text = MinDateToNull(dtpItemDocDate.Value, Me.StringParserService.Parse("${res:Global.BlankDateText}"))
                Me.m_milestone.DocDate = dtpItemDocDate.Value
              End If
              dirtyFlag = True
              UpdateItemRow()
              Dim re As New DataColumnChangeEventArgs(row _
              , Me.m_treeManager.Treetable.Columns("docdate") _
              , Me.m_milestone.DocDate)
              ValidateRow(re)
            End If
          End If
        Case "txtitemname"
          If Not Me.m_milestone Is Nothing AndAlso Me.m_milestone.Status.Value < 3 AndAlso Me.m_milestone.Status.Value <> 0 Then
            m_milestone.Name = txtItemName.Text
            Me.UpdateItemRow()
            dirtyFlag = True
            Dim re As New DataColumnChangeEventArgs(row _
            , Me.m_treeManager.Treetable.Columns("name") _
            , Me.m_milestone.Name)
            ValidateRow(re)
          End If
        Case "txtitemdiscount"
          If Not Me.m_milestone Is Nothing AndAlso Me.m_milestone.Status.Value < 3 AndAlso Me.m_milestone.Status.Value <> 0 Then
            Dim txt As String = txtItemDiscount.Text
            If txt.Length > 0 Then
              Me.m_milestone.Discount.Rate = txt
            Else
              Me.m_milestone.Discount.Rate = ""
            End If
            UpdateAmount()
            Me.UpdateItemRow()
            dirtyFlag = True
            Dim re As New DataColumnChangeEventArgs(row _
            , Me.m_treeManager.Treetable.Columns("discount") _
            , Me.m_milestone.Discount.Rate)
            ValidateRow(re)
          End If
        Case "txtitemnote"
          If Not Me.m_milestone Is Nothing AndAlso Me.m_milestone.Status.Value < 3 AndAlso Me.m_milestone.Status.Value <> 0 Then
            m_milestone.Note = txtItemNote.Text
            Me.UpdateItemRow()
            dirtyFlag = True
            Dim re As New DataColumnChangeEventArgs(row _
            , Me.m_treeManager.Treetable.Columns("note") _
            , Me.m_milestone.Note)
            ValidateRow(re)
          End If
        Case Else
      End Select
      Me.WorkbenchWindow.ViewContent.IsDirty = Me.WorkbenchWindow.ViewContent.IsDirty Or dirtyFlag
      CheckFormEnable()
    End Sub
    Private Sub UpdateAmount()
      Dim flag As Boolean = Me.m_isInitialized
      m_isInitialized = False

      Me.txtAdvr.Text = Configuration.FormatToString(Me.m_entity.Advance, DigitConfig.Price)
      Me.txtRetention.Text = Configuration.FormatToString(Me.m_entity.Retention, DigitConfig.Price)

      Dim rtpercent As Decimal = 0
      Dim advpercent As Decimal = 0
      If Me.m_entity.ContractAmount <> 0 Then
        advpercent = 100 * Me.m_entity.Advance / Me.m_entity.ContractAmount
        rtpercent = 100 * Me.m_entity.Retention / Me.m_entity.ContractAmount
      End If
      Me.txtAdvrPercent.Text = Configuration.FormatToString(advpercent, DigitConfig.Price) & " %"
      Me.txtRetentionPercent.Text = Configuration.FormatToString(rtpercent, DigitConfig.Price) & " %"

      Me.txtContractAmount.Text = Configuration.FormatToString(Me.m_entity.ContractAmount, DigitConfig.Price)
      Me.txtDe.Text = Configuration.FormatToString(Me.m_entity.VoDe, DigitConfig.Price)
      Me.txtInc.Text = Configuration.FormatToString(Me.m_entity.VoInc, DigitConfig.Price)
      Me.txtDiscountAmount.Text = Configuration.FormatToString(Me.m_entity.DiscountAmount, DigitConfig.Price)
      Me.txtPenalty.Text = Configuration.FormatToString(Me.m_entity.Penalty, DigitConfig.Price)
      Me.txtTotalAmount.Text = Configuration.FormatToString(Me.m_entity.TotalAmount, DigitConfig.Price)
      ToggleAdvrRetention()
      ToggleVatGroupBox()
      m_isInitialized = flag
    End Sub
    Private Sub ToggleVatGroupBox()
      Dim flag As Boolean = Me.grbTax.Enabled
      If Me.m_entity.ItemCollection.GetMilestoneLocked() Then
        Me.grbTax.Enabled = False
      Else
        Me.grbTax.Enabled = flag
      End If
    End Sub
    Private Sub ToggleAdvrRetention()
      If Me.m_entity Is Nothing Then
        Return
      End If
      Dim advrLocked As Boolean = Me.m_entity.ItemCollection.GetAdvanceLocked
      If Not advrLocked Then
        Me.txtAdvr.ReadOnly = False
      Else
        Me.txtAdvr.ReadOnly = True
      End If
      Dim rtnLocked As Boolean = Me.m_entity.ItemCollection.GetRetentionLocked
      If Not rtnLocked Then
        Me.txtRetention.ReadOnly = False
      Else
        Me.txtRetention.ReadOnly = True
      End If
    End Sub
    Private Sub UpdateCC()
      Dim flag As Boolean = Me.m_isInitialized
      m_isInitialized = False
      If Me.m_entity.CostCenter Is Nothing OrElse Not Me.m_entity.CostCenter.Originated Then
        Me.txtCustomerCode.Text = ""
        Me.txtCustomerName.Text = ""
      Else
        Me.txtCustomerCode.Text = Me.m_entity.Customer.Code
        Me.txtCustomerName.Text = Me.m_entity.Customer.Name
      End If
      UpdateBOQ()
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
          Me.m_entity = CType(Value, PaymentApplication)
        End If
        'Hack:
        Me.m_entity.OnTabPageTextChanged(m_entity, EventArgs.Empty)
        UpdateEntityProperties()
      End Set
    End Property
    Public Overrides Sub Initialize()
      PopulateCombo()
    End Sub
    ' 
    Private Sub PopulateCombo()

      'Select Case CInt(Configuration.GetConfig("CompanyTaxType"))
      '    Case 0 'ไม่มี Vat
      '        CodeDescription.ListCodeDescriptionInComboBox(Me.cmbTaxType, "taxType", "code_value=0")
      '    Case 1, 2
      '        CodeDescription.ListCodeDescriptionInComboBox(Me.cmbTaxType, "taxType", "code_value in (1,2)")
      'End Select
      CodeDescription.ListCodeDescriptionInComboBox(Me.cmbTaxType, "taxType")
      cmbTaxType.SelectedIndex = 0
      CodeDescription.ListCodeDescriptionInComboBox(Me.cmbDurationUnit, "DateIntervalUnit")
      cmbDurationUnit.SelectedIndex = 0
      CodeDescription.ListCodeDescriptionInComboBox(Me.cmbItemStatus, "milestone_status")
      cmbItemStatus.SelectedIndex = 0
      CodeDescription.ListCodeDescriptionInComboBox(Me.cmbItemType, "milestone_type")
      cmbItemType.SelectedIndex = 0
      CodeDescription.ListCodeDescriptionInComboBox(Me.cmbTaxPoint, "taxPoint")
      cmbTaxPoint.SelectedIndex = 0
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
        Return (New PaymentApplication).DetailPanelIcon
      End Get
    End Property
#End Region

#Region "Event of Button controls"
    '' Supplier
    'Private Sub ibtnShowSupplier_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnShowSupplier.Click
    '    Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
    '    myEntityPanelService.OpenPanel(New Supplier)
    'End Sub
    'Private Sub ibtnShowSupplierDialog_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnShowSupplierDIalog.Click
    '    Dim myEntityPanelService As IEntityPanelService = _
    '     CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
    '    myEntityPanelService.OpenListDialog(New Supplier, AddressOf SetSupplierDialog)
    'End Sub
    'Private Sub SetSupplierDialog(ByVal e As ISimpleEntity)
    '    Me.txtSupplierCode.Text = e.Code
    '    Me.WorkbenchWindow.ViewContent.IsDirty = _
    '        Me.WorkbenchWindow.ViewContent.IsDirty _
    '        Or Supplier.GetSupplier(txtSupplierCode, txtSupplierName, Me.m_entity.Supplier)
    'End Sub
    'Private Sub ibtnShowCostCenterDialog_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnShowCostCenterDialog.Click
    '    Dim myEntityPanelService As IEntityPanelService = _
    '     CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
    '    myEntityPanelService.OpenTreeDialog(New CostCenter, AddressOf SetCostCenter)
    'End Sub
    'Private Sub ibtnShowCostCenter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnShowCostCenter.Click
    '    Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
    '    myEntityPanelService.OpenPanel(New CostCenter)
    'End Sub
    Private Sub ibtnShowProjectDialog_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnShowProjectDialog.Click
      Dim myEntityPanelService As IEntityPanelService = _
      CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      Dim cc As New CostCenter
      cc.Type.Value = 2
      Dim entities As New ArrayList
      entities.Add(cc)
      Dim filters(1) As Filter
      filters(0) = New Filter("IDlist", "")
      filters(1) = New Filter("mustHavePMA", False)
      myEntityPanelService.OpenTreeDialog(cc, AddressOf SetCostCenter, filters, entities)
    End Sub
    Private Sub ibtnShowProject_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnShowProject.Click
      Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      myEntityPanelService.OpenPanel(New CostCenter)
    End Sub
    Private Sub SetCostCenter(ByVal e As ISimpleEntity)

      Me.txtCostCenterCode.Text = e.Code
      Me.WorkbenchWindow.ViewContent.IsDirty = _
      Me.WorkbenchWindow.ViewContent.IsDirty _
      Or CostCenter.GetCostCenter(txtCostCenterCode, txtCostCenterName, Me.m_entity.CostCenter, CType(ServiceManager.Services.GetService(GetType(SecurityService)), SecurityService).CurrentUser.Id)
      If Not Me.m_entity.Project Is Nothing Then
        Me.m_entity.CompletionDate = Me.m_entity.Project.CompletionDate
        Me.m_entity.Duration = Me.m_entity.Project.Duration
        Me.m_entity.DurationUnit.Value = Me.m_entity.Project.DurationUnit.Value
      End If
      UpdateCC()
      UpdateAmount()
    End Sub
#End Region

#Region "Event Handlers"

    Private Sub chkAutorun_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkAutorun.CheckedChanged
      UpdateAutogenStatus()
    End Sub
    Private Sub UpdateAutogenStatus()
      If Me.chkAutorun.Checked Then 'From BOQ
        Me.txtBudget.ReadOnly = True
        Me.m_entity.ManualBudget = False
        If Not Me.m_entity.Boq Is Nothing Then
          If Configuration.Compare(Me.m_entity.Boq.TotalBudget, Me.m_entity.Budget) <> 0 Then
            'มีการ Revise Budget
            Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
            msgServ.ShowMessage("${res:Longkong.Pojjaman.Gui.Panels.PaymentApplicationDetail.Message.BudgetRevised}")
            Me.m_entity.Budget = Configuration.Format(Me.m_entity.Boq.TotalBudget, DigitConfig.Price)
            Me.WorkbenchWindow.ViewContent.IsDirty = True
            Me.UpdateCC()
            Me.UpdateAmount()
          End If
        End If
      Else
        Me.txtBudget.ReadOnly = False
        Me.m_entity.ManualBudget = True
      End If
    End Sub
    Private m_oldRow As TreeRow
    Private Sub tgItem_CurrentCellChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tgItem.CurrentCellChanged
      Dim theRow As TreeRow = m_treeManager.SelectedRow
      If m_oldRow Is theRow Then
        Return
      End If
      m_milestone = Nothing
      ClearItem()
      If TypeOf theRow.Tag Is Milestone Then
        m_milestone = CType(theRow.Tag, Milestone)
        UpdateItem()
      End If
      m_oldRow = m_treeManager.SelectedRow
    End Sub
    Private Sub ClearItem()
      Dim flag As Boolean = Me.m_isInitialized
      Me.m_isInitialized = False
      txtItemCode.Text = ""
      cmbItemType.SelectedIndex = -1
      txtItemDocDate.Text = ""
      dtpItemDocDate.Value = Now
      txtItemName.Text = ""
      txtItemRealAmount.Text = ""
      txtItemAmount.Text = ""
      txtItemAdvr.Text = ""
      txtItemRetention.Text = ""
      txtItemPenalty.Text = ""
      cmbItemStatus.SelectedIndex = -1
      txtItemHandedDate.Text = ""
      dtpItemHandedDate.Value = Now
      txtItemBillIssueDate.Text = ""
      dtpItemBillIssueDate.Value = Now
      txtItemNote.Text = ""
      txtItemDiscount.Text = ""
      Me.m_isInitialized = flag
    End Sub
    Private Sub UpdateItem()
      Dim flag As Boolean = Me.m_isInitialized
      Me.m_isInitialized = False
      ClearItem()
      txtItemCode.Text = m_milestone.Code
      CodeDescription.ComboSelect(cmbItemType, m_milestone.Type)
      txtItemDocDate.Text = MinDateToNull(m_milestone.DocDate, "")
      dtpItemDocDate.Value = MinDateToNow(m_milestone.DocDate)
      txtItemName.Text = m_milestone.Name
      txtItemRealAmount.Text = Configuration.FormatToString(m_milestone.MileStoneAmount, DigitConfig.Price)
      txtItemAmount.Text = Configuration.FormatToString(m_milestone.Amount, DigitConfig.Price)
      txtItemAdvr.Text = Configuration.FormatToString(m_milestone.Advance, DigitConfig.Price)
      txtItemRetention.Text = Configuration.FormatToString(m_milestone.Retention, DigitConfig.Price)
      txtItemPenalty.Text = Configuration.FormatToString(m_milestone.Penalty, DigitConfig.Price)
      txtItemDiscount.Text = m_milestone.Discount.Rate
      CodeDescription.ComboSelect(cmbItemStatus, m_milestone.Status)
      txtItemHandedDate.Text = MinDateToNull(m_milestone.HandedDate, "")
      dtpItemHandedDate.Value = MinDateToNow(m_milestone.HandedDate)
      txtItemBillIssueDate.Text = MinDateToNull(m_milestone.BillIssueDate, "")
      dtpItemBillIssueDate.Value = MinDateToNow(m_milestone.BillIssueDate)
      txtItemReceiveDate.Text = MinDateToNull(m_milestone.ReceiveDate, "")
      dtpItemReceiveDate.Value = MinDateToNow(m_milestone.ReceiveDate)
      txtItemNote.Text = m_milestone.Note
      Me.m_isInitialized = flag
    End Sub
    Private Sub UpdateTotalRow()
      Dim totalRow As TreeRow = Me.m_treeManager.Treetable.Childs(0)
      totalRow("Name") = "Total" 'Todo
      totalRow("Type") = DBNull.Value
      totalRow("Advance") = Configuration.FormatToString(Me.m_entity.ItemCollection.GetAdvrAmount, DigitConfig.Price)
      totalRow("Retention") = Configuration.FormatToString(Me.m_entity.ItemCollection.GetRetentionAmount, DigitConfig.Price)
      totalRow("Penalty") = Configuration.FormatToString(Me.m_entity.ItemCollection.GetPenaltyAmount, DigitConfig.Price)
      totalRow("RealAmount") = Configuration.FormatToString(Me.m_entity.ItemCollection.GetCanGetMilestoneAmount, DigitConfig.Price)
      'totalRow("Discount") = Configuration.FormatToString(Me.m_entity.ItemCollection.GetDiscountAmount, DigitConfig.Price)
      totalRow("Amount") = Configuration.FormatToString(Me.m_entity.Amount, DigitConfig.Price)
      totalRow.Tag = Nothing
      Dim i As Integer
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
    Private Sub ibtnBlank_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnBlank.Click
      Dim index As Integer = tgItem.CurrentRowIndex
      'If index = 0 Then
      '    Return
      'End If
      Dim theItem As Milestone
      If Me.m_treeManager.Treetable.Childs.Count = 0 Or index = 0 Then
        theItem = New Milestone
        AutoFillRealAmount(theItem)
        Me.m_entity.ItemCollection.Add(theItem)
      Else
        theItem = Me.m_entity.ItemCollection.Add(index - 1) '-1 เพราะมีแถว Total
        AutoFillRealAmount(theItem)
      End If
      Me.PopulateItemListing()
      tgItem.CurrentRowIndex = index
      Me.WorkbenchWindow.ViewContent.IsDirty = True
      If Not Me.m_treeManager.SelectedRow Is Nothing Then
        ValidateItemRow(Me.m_treeManager.SelectedRow)
      End If
      Me.WorkbenchWindow.ViewContent.IsDirty = True
      UpdateAmount()
    End Sub
    Private Sub AutoFillRealAmount(ByVal myItem As Milestone)
      Dim temp As Decimal
      'If Me.m_entity.TaxType.Value = 1 Then
      '    temp = Vat.GetExcludedVatAmount(Me.m_entity.ContractAmount)
      'Else
      temp = Me.m_entity.ContractAmount
      'End If
      'temp += Me.m_entity.Advance + Me.m_entity.Retention
      If TypeOf myItem Is Milestone AndAlso myItem.Type.Value = 75 Then
        'temp += Me.m_entity.VoInc + Me.m_entity.VoDe
        temp -= Me.m_entity.ItemCollection.GetCanGetOnlyMilestoneAmount
      Else
        temp = 0
        'temp -= Me.m_entity.ItemCollection.GetCanGetMilestoneAmount
      End If
      'temp -= (Me.m_entity.Advance - m_entity.ItemCollection.GetMilestoneAdvrAmount)
      'temp -= (Me.m_entity.Retention - m_entity.ItemCollection.GetMilestoneRetention)
      temp += myItem.MileStoneAmount

      If temp < 0 Then
        temp = 0
      End If
      myItem.MileStoneAmount = temp

      Dim advr As Decimal = Me.m_entity.Advance
      advr -= m_entity.ItemCollection.GetAdvrAmount
      advr += myItem.Advance
      myItem.Advance = advr

      Dim ret As Decimal = Me.m_entity.Retention
      ret -= m_entity.ItemCollection.GetRetentionAmount
      ret += myItem.Retention
      myItem.Retention = ret
      myItem.ResetReal(True)
      If Not Me.m_milestone Is Nothing Then
        Me.m_milestone.ResetReal(True) 'TODO
      End If
    End Sub
    Private Sub ibtnDelRow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnDelRow.Click
      Dim index As Integer = Me.tgItem.CurrentRowIndex
      If Me.m_milestone Is Nothing OrElse Me.m_milestone.Status.Value >= 3 OrElse Me.m_milestone.Status.Value = 0 Then
        Return
      End If
      'If TypeOf Me.m_milestone Is AdvanceMileStone Then
      '    Return
      'End If
      'If TypeOf Me.m_milestone Is Retention Then
      '    Return
      'End If
      Me.m_entity.ItemCollection.Remove(m_milestone)
      Me.PopulateItemListing()
      If index > Me.m_treeManager.Treetable.Childs.Count - 1 Then
        Return
      End If
      Me.tgItem.CurrentRowIndex = Math.Max(0, index)
      Me.WorkbenchWindow.ViewContent.IsDirty = True
      UpdateAmount()
    End Sub
    Private Sub imbMilestoneDetail_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles imbMilestoneDetail.Click
      If Me.m_milestone Is Nothing Then
        Return
      End If
      Dim view As New MilestoneDetail
      view.Entity = m_milestone
      Dim dlg As New Longkong.Pojjaman.Gui.Dialogs.PanelDialog(view)
      dlg.ShowDialog()
      Me.UpdateItem()
      Me.UpdateItemRow()
      Dim flag As Boolean = Me.m_tableInitialized
      Me.m_tableInitialized = False
      Me.UpdateTotalRow()
      Me.m_tableInitialized = flag
    End Sub
    Private Sub ibtnDistributeAdvr_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnDistributeAdvr.Click
      Dim index As Integer = Me.tgItem.CurrentRowIndex
      Me.m_entity.DistributeAdvance()
      Me.PopulateItemListing()
      If index > Me.m_treeManager.Treetable.Childs.Count - 1 Then
        Return
      End If
      Me.tgItem.CurrentRowIndex = Math.Max(0, index)
      Me.WorkbenchWindow.ViewContent.IsDirty = True
    End Sub
    Private Sub ibtnDistributeRetention_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnDistributeRetention.Click
      Dim index As Integer = Me.tgItem.CurrentRowIndex
      Me.m_entity.DistributeRetention()
      Me.PopulateItemListing()
      If index > Me.m_treeManager.Treetable.Childs.Count - 1 Then
        Return
      End If
      Me.tgItem.CurrentRowIndex = Math.Max(0, index)
      Me.WorkbenchWindow.ViewContent.IsDirty = True
    End Sub
    Private Sub ibtnHand_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnHand.Click
      Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
      If Not Me.m_entity.Originated Then
        msgServ.ShowMessage("${res:Global.Error.PleaseSavePMABeforeHand}")
        Return
      End If
      If Me.m_milestone Is Nothing Then
        Return
      End If
      If Me.m_milestone.Status.Value >= 3 Then
        Dim view As New MilestoneDetail
        view.Entity = m_milestone
        Dim dlg As New Longkong.Pojjaman.Gui.Dialogs.PanelDialog(view)
        dlg.ShowDialog()
        Me.UpdateItem()
        Me.UpdateItemRow()
        Dim flag As Boolean = Me.m_tableInitialized
        Me.m_tableInitialized = False
        Me.UpdateTotalRow()
        Me.m_tableInitialized = flag
        Return
      End If
      If Not msgServ.AskQuestionFormatted("${res:Global.Error.HandThisMileStone}", New String() {m_milestone.DetailPanelTitle, m_milestone.Code}) Then
        Return
      End If
      If Me.m_milestone.Status.Value < 3 Then
        m_milestone.HandedDate = Now.Date
        Dim view As New MilestoneDetail
        view.Entity = m_milestone
        Dim dlg As New Longkong.Pojjaman.Gui.Dialogs.PanelDialog(view)
        dlg.ShowDialog()
        Me.UpdateItem()
        Me.UpdateItemRow()
        Dim flag As Boolean = Me.m_tableInitialized
        Me.m_tableInitialized = False
        Me.UpdateTotalRow()
        Me.m_tableInitialized = flag
      End If
      m_milestone.Status.Value = 3
      'm_milestone.HandedDate = Now.Date  'PJM-630 fixed
      Dim secSvc As SecurityService = CType(ServiceManager.Services.GetService(GetType(SecurityService)), SecurityService)
      Dim saveError As SaveErrorException = m_milestone.Save(secSvc.CurrentUser.Id)
      If Not IsNumeric(saveError.Message) Then
        msgServ.ShowMessage(saveError.Message)
      Else
        Select Case CInt(saveError.Message)
          Case -1, -2, -5
            msgServ.ShowMessage(saveError.Message)
            'Case Else
            '    Dim view As New MilestoneDetail
            '    view.Entity = m_milestone
            '    Dim dlg As New Longkong.Pojjaman.Gui.Dialogs.PanelDialog(view)
            '    dlg.ShowDialog()
            '    Me.UpdateItem()
            '    Me.UpdateItemRow()
            'Dim flag As Boolean = Me.m_tableInitialized
            'Me.m_tableInitialized = False
            'Me.UpdateTotalRow()
            'Me.m_tableInitialized = flag
        End Select
      End If
    End Sub
    Private Sub ibtnCancelHand_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnCancelHand.Click
      If Me.m_milestone Is Nothing Then
        Return
      End If
      If Me.m_milestone.Status.Value <> 3 Then
        Return
      End If
      Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
      If Not msgServ.AskQuestionFormatted("${res:Global.Error.CancelHandThisMileStone}", New String() {m_milestone.DetailPanelTitle, m_milestone.Code}) Then
        Return
      End If
      m_milestone.Status.Value = 2
      m_milestone.HandedDate = Now.Date
      Dim secSvc As SecurityService = CType(ServiceManager.Services.GetService(GetType(SecurityService)), SecurityService)
      Dim saveError As SaveErrorException = m_milestone.UnHand(secSvc.CurrentUser.Id)
      If Not IsNumeric(saveError.Message) Then
        msgServ.ShowMessage(saveError.Message)
      Else
        Select Case CInt(saveError.Message)
          Case -1, -2, -5
            msgServ.ShowMessage(saveError.Message)
          Case Else
            Dim view As New MilestoneDetail
            view.Entity = m_milestone
            Dim dlg As New Longkong.Pojjaman.Gui.Dialogs.PanelDialog(view)
            dlg.ShowDialog()
            Me.UpdateItem()
            Me.UpdateItemRow()
        End Select
      End If
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
    Private Sub RefreshBlankGrid()
      'If Me.tgItem.Height = 0 Then
      '    Return
      'End If
      'Dim dirtyFlag As Boolean = Me.WorkbenchWindow.ViewContent.IsDirty
      'Dim index As Integer = tgItem.CurrentRowIndex
      'Dim maxVisibleCount As Integer
      'Dim tgRowHeight As Integer = tgItem.PreferredRowHeight '17
      'maxVisibleCount = CInt(Math.Floor((Me.tgItem.Height - tgRowHeight) / tgRowHeight))
      'Do While Me.m_entity.ItemTable.Childs.Count < maxVisibleCount - 1
      '    'เพิ่มแถวจนเต็ม
      '    Me.m_entity.AddBlankRow(1)
      'Loop
      'If Me.m_entity.MaxRowIndex = maxVisibleCount - 2 Then
      '    If Me.m_entity.ItemTable.Childs.Count < maxVisibleCount - 1 Then
      '        'เพิ่มอีก 1 แถว ถ้ามีข้อมูลจนถึงแถวสุดท้าย
      '        Me.m_entity.AddBlankRow(1)
      '    End If
      'End If
      'Do While Me.m_entity.ItemTable.Childs.Count > maxVisibleCount - 1 And Me.m_entity.ItemTable.Childs.Count - 2 <> Me.m_entity.MaxRowIndex
      '    'ลบแถวที่ไม่จำเป็น
      '    Me.m_entity.Remove(Me.m_entity.ItemTable.Childs.Count - 1)
      'Loop
      'Me.m_entity.ItemTable.AcceptChanges()
      'tgItem.CurrentRowIndex = Math.Max(0, index)
      'Me.WorkbenchWindow.ViewContent.IsDirty = dirtyFlag
    End Sub
#End Region

    Private Sub ibtnCopyMe_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnCopyMe.Click
      Dim newEntity As ISimpleEntity = CType(Me.m_entity.GetNewEntity, ISimpleEntity)
      CType(Me.WorkbenchWindow.ViewContent, ISimpleListPanel).SelectedEntity = newEntity
      Me.Entity = newEntity
      Me.WorkbenchWindow.ViewContent.IsDirty = True
    End Sub

    'Private Sub cmbTaxType_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbTaxType.SelectedValueChanged
    '  If m_entity Is Nothing Then
    '    Return
    '  End If
    '  Me.m_entity.ItemCollection.ResetReal(True)
    '  Me.PopulateItemListing()
    '  UpdateAmount()
    '  Me.WorkbenchWindow.ViewContent.IsDirty = True
    'End Sub
  End Class
End Namespace