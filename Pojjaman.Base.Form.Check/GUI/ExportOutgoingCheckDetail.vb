Imports Longkong.Pojjaman.BusinessLogic
Imports Longkong.Pojjaman.TextHelper
Imports Longkong.Pojjaman.Gui.Components
Imports Longkong.Core.Services
Imports Longkong.Pojjaman.Services
Imports System.IO
Imports System.Globalization
Imports Longkong.Core.AddIns

Namespace Longkong.Pojjaman.Gui.Panels
  Public Class ExportOutgoingCheckDetail
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
    Friend WithEvents lblSumCheckUnit As System.Windows.Forms.Label
    Friend WithEvents lblItem As System.Windows.Forms.Label
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents Validator As Longkong.Pojjaman.Gui.Components.PJMTextboxValidator
    Friend WithEvents grbMaster As Longkong.Pojjaman.Gui.Components.FixedGroupBox
    Friend WithEvents txtIssueDate As System.Windows.Forms.TextBox
    Friend WithEvents dtpIssueDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents tgItem As Longkong.Pojjaman.Gui.Components.TreeGrid
    Friend WithEvents ibtnBlank As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents ibtnDelRow As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents txtCode As System.Windows.Forms.TextBox
    Friend WithEvents lblCode As System.Windows.Forms.Label
    Friend WithEvents chkAutorun As System.Windows.Forms.CheckBox
    Friend WithEvents lblIssueDate As System.Windows.Forms.Label
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents btnBankAccountFind As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents lblBankAccount As System.Windows.Forms.Label
    Friend WithEvents btnBankAccountEdit As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents txtBankAccountCode As System.Windows.Forms.TextBox
    Friend WithEvents txtBankAccountName As System.Windows.Forms.TextBox
    Friend WithEvents dtpPickupDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblPickupDate As System.Windows.Forms.Label
    Friend WithEvents txtPickupDate As System.Windows.Forms.TextBox
    Friend WithEvents txtEffectiveDate As System.Windows.Forms.TextBox
    Friend WithEvents lblEffectiveDate As System.Windows.Forms.Label
    Friend WithEvents dtpEffectiveDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblChargee As System.Windows.Forms.Label
    Friend WithEvents cmbChargee As System.Windows.Forms.ComboBox
    Friend WithEvents tgTax As Longkong.Pojjaman.Gui.Components.TreeGrid
    Friend WithEvents lblTax As System.Windows.Forms.Label
    Friend WithEvents btnExport As System.Windows.Forms.Button
    Friend WithEvents lblSumTotal As System.Windows.Forms.Label
    Friend WithEvents txtSumTotal As System.Windows.Forms.TextBox
    Friend WithEvents lblCheckCount As System.Windows.Forms.Label
    Friend WithEvents txtCheckCount As System.Windows.Forms.TextBox
    Friend WithEvents lblBank As System.Windows.Forms.Label
    Friend WithEvents txtbankbranch As System.Windows.Forms.TextBox
    Friend WithEvents lblCurrency As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Protected Sub InitializeComponent()
      Me.components = New System.ComponentModel.Container()
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ExportOutgoingCheckDetail))
      Me.grbMaster = New Longkong.Pojjaman.Gui.Components.FixedGroupBox()
      Me.lblBank = New System.Windows.Forms.Label()
      Me.txtbankbranch = New System.Windows.Forms.TextBox()
      Me.btnExport = New System.Windows.Forms.Button()
      Me.txtPickupDate = New System.Windows.Forms.TextBox()
      Me.btnBankAccountFind = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.lblBankAccount = New System.Windows.Forms.Label()
      Me.btnBankAccountEdit = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.txtBankAccountCode = New System.Windows.Forms.TextBox()
      Me.txtBankAccountName = New System.Windows.Forms.TextBox()
      Me.chkAutorun = New System.Windows.Forms.CheckBox()
      Me.txtCode = New System.Windows.Forms.TextBox()
      Me.ibtnBlank = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.ibtnDelRow = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.lblCode = New System.Windows.Forms.Label()
      Me.txtIssueDate = New System.Windows.Forms.TextBox()
      Me.cmbChargee = New System.Windows.Forms.ComboBox()
      Me.dtpIssueDate = New System.Windows.Forms.DateTimePicker()
      Me.lblIssueDate = New System.Windows.Forms.Label()
      Me.lblChargee = New System.Windows.Forms.Label()
      Me.tgItem = New Longkong.Pojjaman.Gui.Components.TreeGrid()
      Me.lblItem = New System.Windows.Forms.Label()
      Me.dtpPickupDate = New System.Windows.Forms.DateTimePicker()
      Me.lblPickupDate = New System.Windows.Forms.Label()
      Me.txtEffectiveDate = New System.Windows.Forms.TextBox()
      Me.lblEffectiveDate = New System.Windows.Forms.Label()
      Me.dtpEffectiveDate = New System.Windows.Forms.DateTimePicker()
      Me.lblCurrency = New System.Windows.Forms.Label()
      Me.lblCheckCount = New System.Windows.Forms.Label()
      Me.txtSumTotal = New System.Windows.Forms.TextBox()
      Me.txtCheckCount = New System.Windows.Forms.TextBox()
      Me.lblSumCheckUnit = New System.Windows.Forms.Label()
      Me.lblSumTotal = New System.Windows.Forms.Label()
      Me.tgTax = New Longkong.Pojjaman.Gui.Components.TreeGrid()
      Me.lblTax = New System.Windows.Forms.Label()
      Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
      Me.Validator = New Longkong.Pojjaman.Gui.Components.PJMTextboxValidator(Me.components)
      Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
      Me.grbMaster.SuspendLayout()
      CType(Me.tgItem, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me.tgTax, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.SuspendLayout()
      '
      'grbMaster
      '
      Me.grbMaster.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                  Or System.Windows.Forms.AnchorStyles.Left) _
                  Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.grbMaster.Controls.Add(Me.lblBank)
      Me.grbMaster.Controls.Add(Me.txtbankbranch)
      Me.grbMaster.Controls.Add(Me.btnExport)
      Me.grbMaster.Controls.Add(Me.txtPickupDate)
      Me.grbMaster.Controls.Add(Me.btnBankAccountFind)
      Me.grbMaster.Controls.Add(Me.lblBankAccount)
      Me.grbMaster.Controls.Add(Me.btnBankAccountEdit)
      Me.grbMaster.Controls.Add(Me.txtBankAccountCode)
      Me.grbMaster.Controls.Add(Me.txtBankAccountName)
      Me.grbMaster.Controls.Add(Me.chkAutorun)
      Me.grbMaster.Controls.Add(Me.txtCode)
      Me.grbMaster.Controls.Add(Me.ibtnBlank)
      Me.grbMaster.Controls.Add(Me.ibtnDelRow)
      Me.grbMaster.Controls.Add(Me.lblCode)
      Me.grbMaster.Controls.Add(Me.txtIssueDate)
      Me.grbMaster.Controls.Add(Me.cmbChargee)
      Me.grbMaster.Controls.Add(Me.dtpIssueDate)
      Me.grbMaster.Controls.Add(Me.lblIssueDate)
      Me.grbMaster.Controls.Add(Me.lblChargee)
      Me.grbMaster.Controls.Add(Me.tgItem)
      Me.grbMaster.Controls.Add(Me.lblItem)
      Me.grbMaster.Controls.Add(Me.dtpPickupDate)
      Me.grbMaster.Controls.Add(Me.lblPickupDate)
      Me.grbMaster.Controls.Add(Me.txtEffectiveDate)
      Me.grbMaster.Controls.Add(Me.lblEffectiveDate)
      Me.grbMaster.Controls.Add(Me.dtpEffectiveDate)
      Me.grbMaster.Controls.Add(Me.lblCurrency)
      Me.grbMaster.Controls.Add(Me.lblCheckCount)
      Me.grbMaster.Controls.Add(Me.txtSumTotal)
      Me.grbMaster.Controls.Add(Me.txtCheckCount)
      Me.grbMaster.Controls.Add(Me.lblSumCheckUnit)
      Me.grbMaster.Controls.Add(Me.lblSumTotal)
      Me.grbMaster.Controls.Add(Me.tgTax)
      Me.grbMaster.Controls.Add(Me.lblTax)
      Me.grbMaster.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.grbMaster.Location = New System.Drawing.Point(8, 8)
      Me.grbMaster.Name = "grbMaster"
      Me.grbMaster.Size = New System.Drawing.Size(714, 496)
      Me.grbMaster.TabIndex = 0
      Me.grbMaster.TabStop = False
      Me.grbMaster.Text = "Export Text File : "
      '
      'lblBank
      '
      Me.lblBank.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblBank.ForeColor = System.Drawing.Color.Black
      Me.lblBank.Location = New System.Drawing.Point(8, 96)
      Me.lblBank.Name = "lblBank"
      Me.lblBank.Size = New System.Drawing.Size(128, 18)
      Me.lblBank.TabIndex = 29
      Me.lblBank.Text = "ธนาคาร/สาขา:"
      Me.lblBank.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'txtbankbranch
      '
      Me.Validator.SetDataType(Me.txtbankbranch, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtbankbranch, "")
      Me.txtbankbranch.Enabled = False
      Me.txtbankbranch.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtbankbranch, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtbankbranch, -15)
      Me.Validator.SetInvalidBackColor(Me.txtbankbranch, System.Drawing.Color.Empty)
      Me.txtbankbranch.Location = New System.Drawing.Point(144, 96)
      Me.Validator.SetMinValue(Me.txtbankbranch, "")
      Me.txtbankbranch.Name = "txtbankbranch"
      Me.txtbankbranch.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtbankbranch, "")
      Me.Validator.SetRequired(Me.txtbankbranch, False)
      Me.txtbankbranch.Size = New System.Drawing.Size(432, 21)
      Me.txtbankbranch.TabIndex = 30
      Me.txtbankbranch.TabStop = False
      '
      'btnExport
      '
      Me.btnExport.Location = New System.Drawing.Point(592, 24)
      Me.btnExport.Name = "btnExport"
      Me.btnExport.Size = New System.Drawing.Size(88, 24)
      Me.btnExport.TabIndex = 6
      Me.btnExport.Text = "Export"
      '
      'txtPickupDate
      '
      Me.Validator.SetDataType(Me.txtPickupDate, Longkong.Pojjaman.Gui.Components.DataTypeConstants.DateTimeType)
      Me.Validator.SetDisplayName(Me.txtPickupDate, "")
      Me.Validator.SetGotFocusBackColor(Me.txtPickupDate, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtPickupDate, -15)
      Me.Validator.SetInvalidBackColor(Me.txtPickupDate, System.Drawing.Color.Empty)
      Me.txtPickupDate.Location = New System.Drawing.Point(432, 48)
      Me.Validator.SetMinValue(Me.txtPickupDate, "")
      Me.txtPickupDate.Name = "txtPickupDate"
      Me.Validator.SetRegularExpression(Me.txtPickupDate, "")
      Me.Validator.SetRequired(Me.txtPickupDate, True)
      Me.txtPickupDate.Size = New System.Drawing.Size(125, 20)
      Me.txtPickupDate.TabIndex = 3
      '
      'btnBankAccountFind
      '
      Me.btnBankAccountFind.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnBankAccountFind.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.btnBankAccountFind.ForeColor = System.Drawing.SystemColors.Control
      Me.btnBankAccountFind.Location = New System.Drawing.Point(528, 72)
      Me.btnBankAccountFind.Name = "btnBankAccountFind"
      Me.btnBankAccountFind.Size = New System.Drawing.Size(24, 23)
      Me.btnBankAccountFind.TabIndex = 26
      Me.btnBankAccountFind.TabStop = False
      Me.btnBankAccountFind.ThemedImage = CType(resources.GetObject("btnBankAccountFind.ThemedImage"), System.Drawing.Bitmap)
      '
      'lblBankAccount
      '
      Me.lblBankAccount.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblBankAccount.ForeColor = System.Drawing.Color.Black
      Me.lblBankAccount.Location = New System.Drawing.Point(8, 72)
      Me.lblBankAccount.Name = "lblBankAccount"
      Me.lblBankAccount.Size = New System.Drawing.Size(128, 18)
      Me.lblBankAccount.TabIndex = 23
      Me.lblBankAccount.Text = "สมุดเงินฝากตัดจ่าย:"
      Me.lblBankAccount.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'btnBankAccountEdit
      '
      Me.btnBankAccountEdit.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnBankAccountEdit.Location = New System.Drawing.Point(552, 72)
      Me.btnBankAccountEdit.Name = "btnBankAccountEdit"
      Me.btnBankAccountEdit.Size = New System.Drawing.Size(24, 23)
      Me.btnBankAccountEdit.TabIndex = 27
      Me.btnBankAccountEdit.TabStop = False
      Me.btnBankAccountEdit.ThemedImage = CType(resources.GetObject("btnBankAccountEdit.ThemedImage"), System.Drawing.Bitmap)
      '
      'txtBankAccountCode
      '
      Me.txtBankAccountCode.BackColor = System.Drawing.SystemColors.Window
      Me.Validator.SetDataType(Me.txtBankAccountCode, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtBankAccountCode, "")
      Me.Validator.SetGotFocusBackColor(Me.txtBankAccountCode, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtBankAccountCode, -15)
      Me.Validator.SetInvalidBackColor(Me.txtBankAccountCode, System.Drawing.Color.Empty)
      Me.txtBankAccountCode.Location = New System.Drawing.Point(144, 72)
      Me.Validator.SetMinValue(Me.txtBankAccountCode, "")
      Me.txtBankAccountCode.Name = "txtBankAccountCode"
      Me.Validator.SetRegularExpression(Me.txtBankAccountCode, "")
      Me.Validator.SetRequired(Me.txtBankAccountCode, True)
      Me.txtBankAccountCode.Size = New System.Drawing.Size(128, 20)
      Me.txtBankAccountCode.TabIndex = 4
      '
      'txtBankAccountName
      '
      Me.txtBankAccountName.BackColor = System.Drawing.SystemColors.Control
      Me.Validator.SetDataType(Me.txtBankAccountName, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtBankAccountName, "")
      Me.txtBankAccountName.Enabled = False
      Me.Validator.SetGotFocusBackColor(Me.txtBankAccountName, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtBankAccountName, -15)
      Me.Validator.SetInvalidBackColor(Me.txtBankAccountName, System.Drawing.Color.Empty)
      Me.txtBankAccountName.Location = New System.Drawing.Point(272, 72)
      Me.Validator.SetMinValue(Me.txtBankAccountName, "")
      Me.txtBankAccountName.Name = "txtBankAccountName"
      Me.txtBankAccountName.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtBankAccountName, "")
      Me.Validator.SetRequired(Me.txtBankAccountName, False)
      Me.txtBankAccountName.Size = New System.Drawing.Size(256, 20)
      Me.txtBankAccountName.TabIndex = 25
      Me.txtBankAccountName.TabStop = False
      '
      'chkAutorun
      '
      Me.chkAutorun.Appearance = System.Windows.Forms.Appearance.Button
      Me.chkAutorun.Image = CType(resources.GetObject("chkAutorun.Image"), System.Drawing.Image)
      Me.chkAutorun.Location = New System.Drawing.Point(272, 24)
      Me.chkAutorun.Name = "chkAutorun"
      Me.chkAutorun.Size = New System.Drawing.Size(21, 21)
      Me.chkAutorun.TabIndex = 2
      Me.chkAutorun.TabStop = False
      '
      'txtCode
      '
      Me.Validator.SetDataType(Me.txtCode, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtCode, "")
      Me.txtCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtCode, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtCode, -15)
      Me.Validator.SetInvalidBackColor(Me.txtCode, System.Drawing.Color.Empty)
      Me.txtCode.Location = New System.Drawing.Point(144, 24)
      Me.txtCode.MaxLength = 20
      Me.Validator.SetMinValue(Me.txtCode, "")
      Me.txtCode.Name = "txtCode"
      Me.Validator.SetRegularExpression(Me.txtCode, "")
      Me.Validator.SetRequired(Me.txtCode, True)
      Me.txtCode.Size = New System.Drawing.Size(128, 21)
      Me.txtCode.TabIndex = 0
      '
      'ibtnBlank
      '
      Me.ibtnBlank.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.ibtnBlank.Location = New System.Drawing.Point(232, 176)
      Me.ibtnBlank.Name = "ibtnBlank"
      Me.ibtnBlank.Size = New System.Drawing.Size(24, 24)
      Me.ibtnBlank.TabIndex = 12
      Me.ibtnBlank.TabStop = False
      Me.ibtnBlank.ThemedImage = CType(resources.GetObject("ibtnBlank.ThemedImage"), System.Drawing.Bitmap)
      '
      'ibtnDelRow
      '
      Me.ibtnDelRow.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.ibtnDelRow.Location = New System.Drawing.Point(256, 176)
      Me.ibtnDelRow.Name = "ibtnDelRow"
      Me.ibtnDelRow.Size = New System.Drawing.Size(24, 24)
      Me.ibtnDelRow.TabIndex = 13
      Me.ibtnDelRow.TabStop = False
      Me.ibtnDelRow.ThemedImage = CType(resources.GetObject("ibtnDelRow.ThemedImage"), System.Drawing.Bitmap)
      '
      'lblCode
      '
      Me.lblCode.Cursor = System.Windows.Forms.Cursors.Default
      Me.lblCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblCode.ForeColor = System.Drawing.Color.Black
      Me.lblCode.Location = New System.Drawing.Point(8, 24)
      Me.lblCode.Name = "lblCode"
      Me.lblCode.Size = New System.Drawing.Size(128, 16)
      Me.lblCode.TabIndex = 0
      Me.lblCode.Text = "เลขที่เอกสาร:"
      Me.lblCode.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'txtIssueDate
      '
      Me.Validator.SetDataType(Me.txtIssueDate, Longkong.Pojjaman.Gui.Components.DataTypeConstants.DateTimeType)
      Me.Validator.SetDisplayName(Me.txtIssueDate, "")
      Me.Validator.SetGotFocusBackColor(Me.txtIssueDate, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtIssueDate, -15)
      Me.Validator.SetInvalidBackColor(Me.txtIssueDate, System.Drawing.Color.Empty)
      Me.txtIssueDate.Location = New System.Drawing.Point(432, 24)
      Me.Validator.SetMinValue(Me.txtIssueDate, "")
      Me.txtIssueDate.Name = "txtIssueDate"
      Me.Validator.SetRegularExpression(Me.txtIssueDate, "")
      Me.Validator.SetRequired(Me.txtIssueDate, True)
      Me.txtIssueDate.Size = New System.Drawing.Size(125, 20)
      Me.txtIssueDate.TabIndex = 1
      '
      'cmbChargee
      '
      Me.cmbChargee.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.ErrorProvider1.SetIconPadding(Me.cmbChargee, -15)
      Me.cmbChargee.Location = New System.Drawing.Point(144, 120)
      Me.cmbChargee.Name = "cmbChargee"
      Me.cmbChargee.Size = New System.Drawing.Size(208, 21)
      Me.cmbChargee.TabIndex = 5
      '
      'dtpIssueDate
      '
      Me.dtpIssueDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
      Me.dtpIssueDate.Location = New System.Drawing.Point(432, 24)
      Me.dtpIssueDate.Name = "dtpIssueDate"
      Me.dtpIssueDate.Size = New System.Drawing.Size(144, 20)
      Me.dtpIssueDate.TabIndex = 5
      Me.dtpIssueDate.TabStop = False
      '
      'lblIssueDate
      '
      Me.lblIssueDate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblIssueDate.ForeColor = System.Drawing.Color.Black
      Me.lblIssueDate.Location = New System.Drawing.Point(312, 24)
      Me.lblIssueDate.Name = "lblIssueDate"
      Me.lblIssueDate.Size = New System.Drawing.Size(112, 18)
      Me.lblIssueDate.TabIndex = 3
      Me.lblIssueDate.Text = "วันที่เอกสาร:"
      Me.lblIssueDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblChargee
      '
      Me.lblChargee.Cursor = System.Windows.Forms.Cursors.Default
      Me.lblChargee.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblChargee.ForeColor = System.Drawing.Color.Black
      Me.lblChargee.Location = New System.Drawing.Point(16, 120)
      Me.lblChargee.Name = "lblChargee"
      Me.lblChargee.Size = New System.Drawing.Size(120, 16)
      Me.lblChargee.TabIndex = 6
      Me.lblChargee.Text = "จัดเก็บค่าธรรมเนียม:"
      Me.lblChargee.TextAlign = System.Drawing.ContentAlignment.MiddleRight
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
      Me.tgItem.Location = New System.Drawing.Point(8, 200)
      Me.tgItem.Name = "tgItem"
      Me.tgItem.Size = New System.Drawing.Size(698, 144)
      Me.tgItem.SortingArrowColor = System.Drawing.Color.Red
      Me.tgItem.TabIndex = 11
      Me.tgItem.TreeManager = Nothing
      '
      'lblItem
      '
      Me.lblItem.AutoSize = True
      Me.lblItem.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblItem.ForeColor = System.Drawing.Color.Black
      Me.lblItem.Location = New System.Drawing.Point(16, 180)
      Me.lblItem.Name = "lblItem"
      Me.lblItem.Size = New System.Drawing.Size(210, 16)
      Me.lblItem.TabIndex = 10
      Me.lblItem.Text = "รายการเช็คที่ต้องการส่งให้ธนาคาร"
      Me.lblItem.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      '
      'dtpPickupDate
      '
      Me.dtpPickupDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
      Me.dtpPickupDate.Location = New System.Drawing.Point(432, 48)
      Me.dtpPickupDate.Name = "dtpPickupDate"
      Me.dtpPickupDate.Size = New System.Drawing.Size(144, 20)
      Me.dtpPickupDate.TabIndex = 5
      Me.dtpPickupDate.TabStop = False
      '
      'lblPickupDate
      '
      Me.lblPickupDate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblPickupDate.ForeColor = System.Drawing.Color.Black
      Me.lblPickupDate.Location = New System.Drawing.Point(312, 48)
      Me.lblPickupDate.Name = "lblPickupDate"
      Me.lblPickupDate.Size = New System.Drawing.Size(112, 18)
      Me.lblPickupDate.TabIndex = 3
      Me.lblPickupDate.Text = "วันที่ให้ผู้รับมารับเช็ค:"
      Me.lblPickupDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'txtEffectiveDate
      '
      Me.Validator.SetDataType(Me.txtEffectiveDate, Longkong.Pojjaman.Gui.Components.DataTypeConstants.DateTimeType)
      Me.Validator.SetDisplayName(Me.txtEffectiveDate, "")
      Me.Validator.SetGotFocusBackColor(Me.txtEffectiveDate, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtEffectiveDate, -15)
      Me.Validator.SetInvalidBackColor(Me.txtEffectiveDate, System.Drawing.Color.Empty)
      Me.txtEffectiveDate.Location = New System.Drawing.Point(144, 48)
      Me.Validator.SetMinValue(Me.txtEffectiveDate, "")
      Me.txtEffectiveDate.Name = "txtEffectiveDate"
      Me.Validator.SetRegularExpression(Me.txtEffectiveDate, "")
      Me.Validator.SetRequired(Me.txtEffectiveDate, True)
      Me.txtEffectiveDate.Size = New System.Drawing.Size(128, 20)
      Me.txtEffectiveDate.TabIndex = 2
      '
      'lblEffectiveDate
      '
      Me.lblEffectiveDate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblEffectiveDate.ForeColor = System.Drawing.Color.Black
      Me.lblEffectiveDate.Location = New System.Drawing.Point(24, 48)
      Me.lblEffectiveDate.Name = "lblEffectiveDate"
      Me.lblEffectiveDate.Size = New System.Drawing.Size(112, 18)
      Me.lblEffectiveDate.TabIndex = 3
      Me.lblEffectiveDate.Text = "วันที่ต้องการให้มีผล:"
      Me.lblEffectiveDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'dtpEffectiveDate
      '
      Me.dtpEffectiveDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
      Me.dtpEffectiveDate.Location = New System.Drawing.Point(144, 48)
      Me.dtpEffectiveDate.Name = "dtpEffectiveDate"
      Me.dtpEffectiveDate.Size = New System.Drawing.Size(152, 20)
      Me.dtpEffectiveDate.TabIndex = 5
      Me.dtpEffectiveDate.TabStop = False
      '
      'lblCurrency
      '
      Me.lblCurrency.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.lblCurrency.AutoSize = True
      Me.lblCurrency.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblCurrency.ForeColor = System.Drawing.Color.Black
      Me.lblCurrency.Location = New System.Drawing.Point(666, 176)
      Me.lblCurrency.Name = "lblCurrency"
      Me.lblCurrency.Size = New System.Drawing.Size(27, 13)
      Me.lblCurrency.TabIndex = 11
      Me.lblCurrency.Text = "บาท"
      Me.lblCurrency.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblCheckCount
      '
      Me.lblCheckCount.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.lblCheckCount.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblCheckCount.ForeColor = System.Drawing.Color.Black
      Me.lblCheckCount.Location = New System.Drawing.Point(410, 152)
      Me.lblCheckCount.Name = "lblCheckCount"
      Me.lblCheckCount.Size = New System.Drawing.Size(144, 16)
      Me.lblCheckCount.TabIndex = 9
      Me.lblCheckCount.Text = "จำนวนรายการรวม:"
      Me.lblCheckCount.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'txtSumTotal
      '
      Me.txtSumTotal.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.Validator.SetDataType(Me.txtSumTotal, Longkong.Pojjaman.Gui.Components.DataTypeConstants.DecimalType)
      Me.Validator.SetDisplayName(Me.txtSumTotal, "")
      Me.txtSumTotal.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtSumTotal, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtSumTotal, -15)
      Me.Validator.SetInvalidBackColor(Me.txtSumTotal, System.Drawing.Color.Empty)
      Me.txtSumTotal.Location = New System.Drawing.Point(562, 176)
      Me.Validator.SetMinValue(Me.txtSumTotal, "")
      Me.txtSumTotal.Name = "txtSumTotal"
      Me.txtSumTotal.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtSumTotal, "")
      Me.Validator.SetRequired(Me.txtSumTotal, False)
      Me.txtSumTotal.Size = New System.Drawing.Size(104, 21)
      Me.txtSumTotal.TabIndex = 10
      Me.txtSumTotal.TabStop = False
      Me.txtSumTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
      '
      'txtCheckCount
      '
      Me.txtCheckCount.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.Validator.SetDataType(Me.txtCheckCount, Longkong.Pojjaman.Gui.Components.DataTypeConstants.Int64Type)
      Me.Validator.SetDisplayName(Me.txtCheckCount, "")
      Me.txtCheckCount.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtCheckCount, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtCheckCount, -15)
      Me.Validator.SetInvalidBackColor(Me.txtCheckCount, System.Drawing.Color.Empty)
      Me.txtCheckCount.Location = New System.Drawing.Point(562, 152)
      Me.Validator.SetMinValue(Me.txtCheckCount, "")
      Me.txtCheckCount.Name = "txtCheckCount"
      Me.txtCheckCount.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtCheckCount, "")
      Me.Validator.SetRequired(Me.txtCheckCount, False)
      Me.txtCheckCount.Size = New System.Drawing.Size(104, 21)
      Me.txtCheckCount.TabIndex = 7
      Me.txtCheckCount.TabStop = False
      Me.txtCheckCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
      '
      'lblSumCheckUnit
      '
      Me.lblSumCheckUnit.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.lblSumCheckUnit.AutoSize = True
      Me.lblSumCheckUnit.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblSumCheckUnit.ForeColor = System.Drawing.Color.Black
      Me.lblSumCheckUnit.Location = New System.Drawing.Point(666, 152)
      Me.lblSumCheckUnit.Name = "lblSumCheckUnit"
      Me.lblSumCheckUnit.Size = New System.Drawing.Size(40, 13)
      Me.lblSumCheckUnit.TabIndex = 8
      Me.lblSumCheckUnit.Text = "รายการ"
      Me.lblSumCheckUnit.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblSumTotal
      '
      Me.lblSumTotal.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.lblSumTotal.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblSumTotal.ForeColor = System.Drawing.Color.Black
      Me.lblSumTotal.Location = New System.Drawing.Point(410, 176)
      Me.lblSumTotal.Name = "lblSumTotal"
      Me.lblSumTotal.Size = New System.Drawing.Size(144, 16)
      Me.lblSumTotal.TabIndex = 6
      Me.lblSumTotal.Text = "จำนวนเงินตัดจ่ายรวม:"
      Me.lblSumTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'tgTax
      '
      Me.tgTax.AllowNew = False
      Me.tgTax.AllowSorting = False
      Me.tgTax.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                  Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.tgTax.AutoColumnResize = True
      Me.tgTax.CaptionVisible = False
      Me.tgTax.Cellchanged = False
      Me.tgTax.DataMember = ""
      Me.tgTax.HeaderForeColor = System.Drawing.SystemColors.ControlText
      Me.tgTax.Location = New System.Drawing.Point(8, 372)
      Me.tgTax.Name = "tgTax"
      Me.tgTax.Size = New System.Drawing.Size(698, 118)
      Me.tgTax.SortingArrowColor = System.Drawing.Color.Red
      Me.tgTax.TabIndex = 11
      Me.tgTax.TreeManager = Nothing
      '
      'lblTax
      '
      Me.lblTax.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.lblTax.AutoSize = True
      Me.lblTax.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblTax.ForeColor = System.Drawing.Color.Black
      Me.lblTax.Location = New System.Drawing.Point(16, 352)
      Me.lblTax.Name = "lblTax"
      Me.lblTax.Size = New System.Drawing.Size(113, 16)
      Me.lblTax.TabIndex = 10
      Me.lblTax.Text = "รายการข้อมูลภาษี"
      Me.lblTax.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
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
      'ExportOutgoingCheckDetail
      '
      Me.Controls.Add(Me.grbMaster)
      Me.Name = "ExportOutgoingCheckDetail"
      Me.Size = New System.Drawing.Size(728, 512)
      Me.grbMaster.ResumeLayout(False)
      Me.grbMaster.PerformLayout()
      CType(Me.tgItem, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me.tgTax, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
      Me.ResumeLayout(False)

    End Sub

#End Region

#Region " SetLabelText "
    Public Overrides Sub SetLabelText()
      If Not m_entity Is Nothing Then Me.Text = Me.StringParserService.Parse(Me.m_entity.TabPageText)
      Me.lblCode.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ExportOutgoingCheckDetail.lblCode}")
      Me.Validator.SetDisplayName(txtCode, lblCode.Text)

      Me.lblIssueDate.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ExportOutgoingCheckDetail.lblIssueDate}")
      Me.Validator.SetDisplayName(txtIssueDate, lblIssueDate.Text)

      Me.lblEffectiveDate.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ExportOutgoingCheckDetail.lblEffectiveDate}")
      Me.Validator.SetDisplayName(txtEffectiveDate, lblEffectiveDate.Text)

      Me.lblPickupDate.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ExportOutgoingCheckDetail.lblPickupDate}")
      Me.Validator.SetDisplayName(txtPickupDate, lblPickupDate.Text)

      Me.lblBankAccount.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ExportOutgoingCheckDetail.lblBankAccount}")
      Me.Validator.SetDisplayName(txtBankAccountCode, lblBankAccount.Text)

      Me.lblBank.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ExportOutgoingCheckDetail.lblBank}")

      Me.lblChargee.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ExportOutgoingCheckDetail.lblChargee}")

      Me.lblCheckCount.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ExportOutgoingCheckDetail.lblCheckCount}")
      Me.Validator.SetDisplayName(txtCheckCount, lblCheckCount.Text)

      Me.lblSumTotal.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ExportOutgoingCheckDetail.lblSumTotal}")
      Me.Validator.SetDisplayName(txtSumTotal, lblSumTotal.Text)

      Me.lblItem.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ExportOutgoingCheckDetail.lblItem}")
      Me.lblTax.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ExportOutgoingCheckDetail.lblTax}")
      Me.lblSumCheckUnit.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ExportOutgoingCheckDetail.lblSumCheckUnit}")
      Me.lblCurrency.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ExportOutgoingCheckDetail.lblCurrency}")

      Me.grbMaster.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ExportOutgoingCheckDetail.grbMaster}")

      Me.ToolTip1.SetToolTip(Me.chkAutorun, Me.StringParserService.Parse("${res:Global.chkAutorun}")) '"เลขที่อัตโนมัติ")
    End Sub

    Public Sub CreateChargeeMember()
      Dim myList As New Hashtable
      myList.Add("Y", Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ExportOutgoingCheckDetail.ChargeeY}")) 'เก็บค่าธรรมเนียมจากผู้รับเงิน (Beneficiary)
      myList.Add("N", Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ExportOutgoingCheckDetail.ChargeeN}")) 'เก็บค่าธรรมเนียมจากผู้สั่งจ่าย (Client)

      Dim ChargeeTable As New DataTable
      ChargeeTable.Columns.Add(New DataColumn("display"))
      ChargeeTable.Columns.Add(New DataColumn("value"))
      Dim ChargeeRow As DataRow
      For Each myKey As DictionaryEntry In myList
        ChargeeRow = ChargeeTable.NewRow
        ChargeeRow.Item("display") = myKey.Value
        ChargeeRow.Item("value") = myKey.Key
        ChargeeTable.Rows.Add(ChargeeRow)
      Next

      cmbChargee.DataSource = ChargeeTable
      cmbChargee.DisplayMember = "display"
      cmbChargee.ValueMember = "value"
    End Sub
#End Region

#Region "Member"
    Private m_entity As ExportOutgoingCheck

    Private m_treeManager As TreeManager
    Private m_treeManager2 As TreeManager
    Private m_isInitialized As Boolean = False
#End Region

#Region "Constructors"
    Public Sub New()
      MyBase.New()
      Me.InitializeComponent()
      Me.Initialize()
      Me.CreateChargeeMember()
      Me.SetLabelText()
      Me.CreateComboColumnMember()

      Dim dt As TreeTable = ExportOutgoingCheck.GetSchemaTable()
      Dim dst As DataGridTableStyle = Me.CreateTableStyle()
      m_treeManager = New TreeManager(dt, tgItem)
      m_treeManager.SetTableStyle(dst)
      m_treeManager.AllowSorting = False
      m_treeManager.AllowDelete = False
      tgItem.AllowNew = False
      Me.Validator.DataTable = m_treeManager.Treetable

      AddHandler dt.ColumnChanging, AddressOf Treetable_ColumnChanging
      AddHandler dt.ColumnChanged, AddressOf Treetable_ColumnChanged
      'AddHandler dt.RowDeleted, AddressOf GRItemDelete

      Dim dt2 As TreeTable = WitholdingTax.GetSchemaTable2()
      Dim dst2 As DataGridTableStyle = WitholdingTax.CreateTableStyle2()
      m_treeManager2 = New TreeManager(dt2, tgTax)
      m_treeManager2.SetTableStyle(dst2)
      m_treeManager2.AllowSorting = False
      m_treeManager2.AllowDelete = False
      tgTax.AllowNew = False

      EventWiring()
    End Sub
#End Region

#Region "Method"
    Private Sub SetBankBranch(Optional ByVal changedBank As Boolean = False)
      Dim oldstatus As Boolean = Me.m_isInitialized
      Me.m_isInitialized = False
      If m_entity.BankAccount Is Nothing _
      OrElse Not Me.m_entity.BankAccount.Originated Then
        txtbankbranch.Text = ""
      Else
        txtbankbranch.Text = Me.m_entity.BankAccount.BankBranch.Bank.Name & " : " & Me.m_entity.BankAccount.BankBranch.Name
      End If
      Me.m_isInitialized = oldstatus

      'ถ้าเปลี่ยนบัญชีธนาคาร ให้ล้างรายการออกให้หมด
      If changedBank Then
        Me.m_entity.ItemCollection.Clear()
        RefreshDocs()
      End If
    End Sub
#End Region

#Region " Style "
    Private DeliveryDataTable As DataTable
    Private PickUpDataTable As DataTable
    Public Function CreateTableStyle() As DataGridTableStyle
      Dim dst As New DataGridTableStyle
      dst.MappingName = "ExportOutGoingCheck"
      Dim myStringParserService As StringParserService = CType(ServiceManager.Services.GetService(GetType(StringParserService)), StringParserService)
      ' line number ...
      Dim csLineNumber As New TreeTextColumn
      csLineNumber.MappingName = "eocheck_linenumber"
      csLineNumber.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ExportOutgoingCheckDetail.LineNumberHeaderText}")
      csLineNumber.NullText = ""
      csLineNumber.Width = 30
      csLineNumber.Alignment = HorizontalAlignment.Center
      csLineNumber.DataAlignment = HorizontalAlignment.Center
      csLineNumber.ReadOnly = True
      csLineNumber.TextBox.Name = "eocheck_linenumber"
      ' document code ...
      Dim csCode As New TreeTextColumn
      csCode.MappingName = "code"
      csCode.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ExportOutgoingCheckDetail.CodeHeaderText}")
      csCode.NullText = ""
      csCode.Width = 80
      csCode.Alignment = HorizontalAlignment.Center
      csCode.DataAlignment = HorizontalAlignment.Left
      csCode.ReadOnly = False
      csCode.TextBox.Name = "code"
      ' Check Find button ...
      Dim csButton As New DataGridButtonColumn
      csButton.MappingName = "button"
      csButton.HeaderText = ""
      csButton.NullText = ""
      AddHandler csButton.Click, AddressOf CheckButtonClick
      ' SupplierCode ...
      Dim csSuppliercode As New TreeTextColumn
      csSuppliercode.MappingName = "suppliercode"
      csSuppliercode.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ExportOutgoingCheckDetail.SupplierCodeHeaderText}")
      csSuppliercode.NullText = ""
      csSuppliercode.Width = 80
      csSuppliercode.Alignment = HorizontalAlignment.Center
      csSuppliercode.DataAlignment = HorizontalAlignment.Left
      csSuppliercode.ReadOnly = True
      csSuppliercode.TextBox.Name = "suppliercode"
      ' SupplierName ...
      Dim csSupplierName As New TreeTextColumn
      csSupplierName.MappingName = "suppliername"
      csSupplierName.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ExportOutgoingCheckDetail.SupplierNameHeaderText}")
      csSupplierName.NullText = ""
      csSupplierName.Alignment = HorizontalAlignment.Center
      csSupplierName.DataAlignment = HorizontalAlignment.Left
      csSupplierName.Width = 150
      csSupplierName.ReadOnly = True
      csSupplierName.TextBox.Name = "suppliername"
      ' Receiver ...
      Dim csReceiver As New TreeTextColumn
      csReceiver.MappingName = "receiver"
      csReceiver.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ExportOutgoingCheckDetail.ReceiverHeaderText}")
      csReceiver.NullText = ""
      csReceiver.Alignment = HorizontalAlignment.Center
      csReceiver.DataAlignment = HorizontalAlignment.Left
      csReceiver.Width = 150
      csReceiver.ReadOnly = True
      csReceiver.TextBox.Name = "receiver"
      ' Detail ...
      Dim csDetail As New TreeTextColumn
      csDetail.MappingName = "detail"
      csDetail.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ExportOutgoingCheckDetail.DetailHeaderText}")
      csDetail.NullText = ""
      csDetail.Alignment = HorizontalAlignment.Center
      csDetail.DataAlignment = HorizontalAlignment.Left
      csDetail.Width = 180
      csDetail.ReadOnly = False
      csDetail.TextBox.Name = "detail"

      ' DeliveryMethod
      Dim csDelivery As DataGridComboColumn
      csDelivery = New DataGridComboColumn("deliverymethod", DeliveryDataTable, "code_description", "code_tag")
      csDelivery.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ExportOutgoingCheckDetail.DeliveryMethodHeaderText}")
      csDelivery.NullText = String.Empty
      csDelivery.Width = 180
      csDelivery.ReadOnly = False
      ' PickupCode ...
      Dim csPickupCode As DataGridComboColumn
      csPickupCode = New DataGridComboColumn("pickuplocationcode", PickUpDataTable, "code_description", "code_tag")
      csPickupCode.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ExportOutgoingCheckDetail.PickupCodeHeaderText}")
      csPickupCode.NullText = String.Empty
      csPickupCode.Width = 120
      csPickupCode.ReadOnly = False
      ' DocumentForPickup ...
      Dim csDocumentForPickup As New TreeTextColumn
      csDocumentForPickup.MappingName = "documentforpickup"
      csDocumentForPickup.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ExportOutgoingCheckDetail.DocumentForPickupHeaderText}")
      csDocumentForPickup.NullText = ""
      csDocumentForPickup.Alignment = HorizontalAlignment.Center
      csDocumentForPickup.DataAlignment = HorizontalAlignment.Left
      csDocumentForPickup.Width = 100
      csDocumentForPickup.ReadOnly = True
      csDocumentForPickup.TextBox.Name = "documentforpickup"
      'Doc Button
      Dim csDocumentForPickupButton As New DataGridButtonColumn
      csDocumentForPickupButton.MappingName = "docbutton"
      csDocumentForPickupButton.HeaderText = ""
      csDocumentForPickupButton.NullText = ""
      ' PVCode ...
      Dim csPVCode As New TreeTextColumn
      csPVCode.MappingName = "pvcode"
      csPVCode.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ExportOutgoingCheckDetail.PVCodeHeaderText}")
      csPVCode.NullText = ""
      csPVCode.Alignment = HorizontalAlignment.Center
      csPVCode.DataAlignment = HorizontalAlignment.Left
      csPVCode.Width = 120
      csPVCode.ReadOnly = True
      csPVCode.TextBox.Name = "pvcode"
      ' AmountOnCheck ...
      Dim csAmountOnCheck As New TreeTextColumn
      csAmountOnCheck.MappingName = "amountoncheck"
      csAmountOnCheck.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ExportOutgoingCheckDetail.AmountOnCheckHeaderText}")
      csAmountOnCheck.NullText = ""
      csAmountOnCheck.Width = 100
      csAmountOnCheck.Alignment = HorizontalAlignment.Center
      csAmountOnCheck.DataAlignment = HorizontalAlignment.Right
      csAmountOnCheck.ReadOnly = True
      csAmountOnCheck.Format = "#,##0.00"
      csAmountOnCheck.TextBox.Name = "amountoncheck"
      ' AmountBeforeVat ...
      Dim csAmountBeforeVat As New TreeTextColumn
      csAmountBeforeVat.MappingName = "amountbeforevat"
      csAmountBeforeVat.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ExportOutgoingCheckDetail.AmountBeforeVatHeaderText}")
      csAmountBeforeVat.NullText = ""
      csAmountBeforeVat.Width = 100
      csAmountBeforeVat.Alignment = HorizontalAlignment.Center
      csAmountBeforeVat.DataAlignment = HorizontalAlignment.Right
      csAmountBeforeVat.ReadOnly = True
      csAmountBeforeVat.Format = "#,##0.00"
      csAmountBeforeVat.TextBox.Name = "amountbeforevat"
      ' AmountWHT ...
      Dim csWht As New TreeTextColumn
      csWht.MappingName = "amountwht"
      csWht.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ExportOutgoingCheckDetail.AmountWHTHeaderText}")
      csWht.NullText = ""
      csWht.Width = 80
      csWht.Alignment = HorizontalAlignment.Center
      csWht.DataAlignment = HorizontalAlignment.Right
      csWht.ReadOnly = True
      csWht.Format = "#,##0.00"
      csWht.TextBox.Name = "amountwht"
      ' AmountAfterVat ...
      Dim csAmountAfterVat As New TreeTextColumn
      csAmountAfterVat.MappingName = "amountaftervat"
      csAmountAfterVat.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ExportOutgoingCheckDetail.AmountAfterVatHeaderText}")
      csAmountAfterVat.NullText = ""
      csAmountAfterVat.Width = 100
      csAmountAfterVat.Alignment = HorizontalAlignment.Center
      csAmountAfterVat.DataAlignment = HorizontalAlignment.Right
      csAmountAfterVat.ReadOnly = True
      csAmountAfterVat.Format = "#,##0.00"
      csAmountAfterVat.TextBox.Name = "amountaftervat"
      ' TaxCount ...
      Dim csTaxCount As New TreeTextColumn
      csTaxCount.MappingName = "taxcount"
      csTaxCount.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ExportOutgoingCheckDetail.TaxCountHeaderText}")
      csTaxCount.NullText = ""
      csTaxCount.Alignment = HorizontalAlignment.Center
      csTaxCount.DataAlignment = HorizontalAlignment.Left
      csTaxCount.Width = 100
      csTaxCount.ReadOnly = True
      csTaxCount.TextBox.Name = "taxcount"


      ' Add column style ...
      dst.GridColumnStyles.Add(csLineNumber)
      dst.GridColumnStyles.Add(csCode)
      dst.GridColumnStyles.Add(csButton)
      dst.GridColumnStyles.Add(csSuppliercode)
      dst.GridColumnStyles.Add(csSupplierName)
      dst.GridColumnStyles.Add(csReceiver)
      dst.GridColumnStyles.Add(csDetail)
      dst.GridColumnStyles.Add(csDelivery)
      dst.GridColumnStyles.Add(csPickupCode)
      dst.GridColumnStyles.Add(csDocumentForPickup)
      dst.GridColumnStyles.Add(csDocumentForPickupButton)
      dst.GridColumnStyles.Add(csPVCode)
      dst.GridColumnStyles.Add(csAmountOnCheck)
      dst.GridColumnStyles.Add(csAmountBeforeVat)
      dst.GridColumnStyles.Add(csWht)
      dst.GridColumnStyles.Add(csAmountAfterVat)
      dst.GridColumnStyles.Add(csTaxCount)

      Return dst
    End Function

    Public Sub CreateComboColumnMember()
      Dim dt0 As DataTable = CodeDescription.GetCodeList("DeliveryMethod")
      Dim dt1 As DataTable = CodeDescription.GetCodeList("PickupLocationCode")

      DeliveryDataTable = New DataTable
      PickUpDataTable = New DataTable
      For Each col As DataColumn In dt0.Columns
        DeliveryDataTable.Columns.Add(New DataColumn(col.ColumnName))
      Next
      For Each col As DataColumn In dt1.Columns
        PickUpDataTable.Columns.Add(New DataColumn(col.ColumnName))
      Next

      For Each row As DataRow In dt0.Select("", "code_tag")
        Dim dr As DataRow = DeliveryDataTable.NewRow()
        For Each col As DataColumn In dt0.Columns
          dr(col.ColumnName) = row(col.ColumnName)
        Next
        DeliveryDataTable.Rows.Add(dr)
      Next
      For Each row As DataRow In dt1.Select("", "code_tag")
        Dim dr As DataRow = PickUpDataTable.NewRow()
        For Each col As DataColumn In dt1.Columns
          dr(col.ColumnName) = row(col.ColumnName)
        Next
        PickUpDataTable.Rows.Add(dr)
      Next
      'DeliveryDataTable = CodeDescription.GetCodeList("DeliveryMethod")
      'PickUpDataTable = CodeDescription.GetCodeList("PickupLocationCode")

      ''Delivery
      'Dim myList1 As New SortedList
      'myList1.Add("CC", Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ExportOutgoingCheckDetail.DMCC}")) 'จ่ายเช็คที่เคาน์เตอร์โดยไม่มีการเก็บหลักฐานทางการเงิน
      'myList1.Add("CR", Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ExportOutgoingCheckDetail.DMCR}")) 'จ่ายเช็คที่เคาน์เตอร์โดยมีการเก็บหลักฐานทางการเงิน
      'myList1.Add("MR", Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ExportOutgoingCheckDetail.DMMR}")) 'ส่งไปรษณีย์ลงทะเบียนให้กับผู้รับเช็ค
      'myList1.Add("RC", Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ExportOutgoingCheckDetail.DMRC}")) 'ส่งคืนบริษัทเพื่อแจกจ่ายให้คู่ค้า

      'DeliveryDataTable = New DataTable
      'DeliveryDataTable.Columns.Add(New DataColumn("display"))
      'DeliveryDataTable.Columns.Add(New DataColumn("value"))
      'Dim MyDataRow As DataRow
      'For Each myKey As DictionaryEntry In myList1
      '  MyDataRow = DeliveryDataTable.NewRow
      '  MyDataRow.Item("display") = myKey.Value
      '  MyDataRow.Item("value") = myKey.Key
      '  DeliveryDataTable.Rows.Add(MyDataRow)
      'Next

      ''Pickup
      'myList1.Clear()
      'myList1.Add("01", Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ExportOutgoingCheckDetail.Pick01}")) 'Phaholyothin
      'myList1.Add("02", Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ExportOutgoingCheckDetail.Pick02}")) 'Navanakorn
      'myList1.Add("03", Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ExportOutgoingCheckDetail.Pick03}")) 'Lamchabang (CL Chonburi)
      'myList1.Add("04", Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ExportOutgoingCheckDetail.Pick04}")) 'Lamchabang (Express)
      'myList1.Add("05", Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ExportOutgoingCheckDetail.Pick05}")) 'Mabtapud (CL Rayong)
      'myList1.Add("06", Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ExportOutgoingCheckDetail.Pick06}")) 'Klongtoey (Express)
      'myList1.Add("07", Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ExportOutgoingCheckDetail.Pick07}")) 'Donmuang (Express)
      'myList1.Add("EXP1", Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ExportOutgoingCheckDetail.PickEXP1}")) 'Silom (Express)
      'myList1.Add("M", Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ExportOutgoingCheckDetail.PickM}")) 'Mail
      'myList1.Add("RET", Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ExportOutgoingCheckDetail.PickRET}")) 'Return

      'PickUpDataTable = New DataTable
      'PickUpDataTable.Columns.Add(New DataColumn("display"))
      'PickUpDataTable.Columns.Add(New DataColumn("value"))
      'For Each myKey As DictionaryEntry In myList1
      '  MyDataRow = PickUpDataTable.NewRow
      '  MyDataRow.Item("display") = myKey.Value
      '  MyDataRow.Item("value") = myKey.Key
      '  PickUpDataTable.Rows.Add(MyDataRow)
      'Next
    End Sub
#End Region

#Region "Properties"
    Private ReadOnly Property CurrentItem() As ExportOutgoingCheckItem
      Get
        Dim row As TreeRow = Me.m_treeManager.SelectedRow
        If row Is Nothing Then
          Return Nothing
        End If
        If Not TypeOf row.Tag Is ExportOutgoingCheckItem Then
          Return Nothing
        End If
        Return CType(row.Tag, ExportOutgoingCheckItem)
      End Get
    End Property
#End Region

#Region "TreeTable Handlers"
    Private Sub Treetable_ColumnChanged(ByVal sender As Object, ByVal e As System.Data.DataColumnChangeEventArgs)
      If Not m_isInitialized Then
        Return
      End If
      Me.WorkbenchWindow.ViewContent.IsDirty = True
      Dim index As Integer = Me.tgItem.CurrentRowIndex
      RefreshDocs()
      tgItem.CurrentRowIndex = index
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
      Dim doc As ExportOutgoingCheckItem = Me.CurrentItem
      If doc Is Nothing Then
        doc = New ExportOutgoingCheckItem
        Me.m_entity.ItemCollection.Add(doc)
        Me.m_treeManager.SelectedRow.Tag = doc
      End If
      Try
        Select Case e.Column.ColumnName.ToLower
          Case "code"
            If IsDBNull(e.ProposedValue) OrElse e.ProposedValue Is Nothing Then
              e.ProposedValue = ""
            End If
            SetItemsCode(CStr(e.ProposedValue))
          Case "detail"
            If IsDBNull(e.ProposedValue) OrElse e.ProposedValue Is Nothing Then
              e.ProposedValue = ""
            End If
            If Not doc.Entity Is Nothing Then
              doc.Detail = CStr(e.ProposedValue)
            End If
          Case "deliverymethod"
            If IsDBNull(e.ProposedValue) OrElse e.ProposedValue Is Nothing Then
              e.ProposedValue = ""
            End If
            If Not doc.Entity Is Nothing Then
              doc.DeliveryMethod = CStr(e.ProposedValue)
            End If
          Case "pickupcode"
            If IsDBNull(e.ProposedValue) OrElse e.ProposedValue Is Nothing Then
              e.ProposedValue = ""
            End If
            If Not doc.Entity Is Nothing Then
              doc.PickupCode = CStr(e.ProposedValue)
            End If
          Case "documentforpickup"
            If IsDBNull(e.ProposedValue) OrElse e.ProposedValue Is Nothing Then
              e.ProposedValue = ""
            End If
            If Not doc.Entity.Code Is Nothing Then
              doc.DocumentForPickup = CStr(e.ProposedValue)
            End If
        End Select
      Catch ex As Exception
        MessageBox.Show(ex.ToString)
      End Try
    End Sub
    Private Sub GRItemDelete(ByVal sender As Object, ByVal e As System.Data.DataRowChangeEventArgs)
    End Sub
#End Region

#Region "IListDetail"
    Public Overrides Sub ClearDetail()
      'lblStatus.Text = ""
      For Each grb As Control In Me.Controls
        If TypeOf grb Is FixedGroupBox Then
          For Each crlt As Control In grb.Controls
            If TypeOf crlt Is TextBox Then
              crlt.Text = ""
            End If
          Next
        End If
      Next

      Me.dtpIssueDate.Value = Now
      Me.txtIssueDate.Text = Me.StringParserService.Parse("${res:Global.BlankDateText}")

      Me.dtpEffectiveDate.Value = Now
      Me.txtEffectiveDate.Text = Me.StringParserService.Parse("${res:Global.BlankDateText}")

      Me.dtpPickupDate.Value = Now
      Me.txtPickupDate.Text = Me.StringParserService.Parse("${res:Global.BlankDateText}")

      Me.cmbChargee.SelectedValue = Me.m_entity.Chargee
    End Sub

    Protected Overrides Sub EventWiring()

      AddHandler txtCode.TextChanged, AddressOf Me.ChangeProperty

      AddHandler txtIssueDate.Validated, AddressOf Me.ChangeProperty
      AddHandler dtpIssueDate.ValueChanged, AddressOf Me.ChangeProperty

      AddHandler txtEffectiveDate.Validated, AddressOf Me.ChangeProperty
      AddHandler dtpEffectiveDate.ValueChanged, AddressOf Me.ChangeProperty

      AddHandler txtPickupDate.Validated, AddressOf Me.ChangeProperty
      AddHandler dtpPickupDate.ValueChanged, AddressOf Me.ChangeProperty

      AddHandler txtBankAccountCode.TextChanged, AddressOf Me.ChangeProperty
      AddHandler cmbChargee.SelectedIndexChanged, AddressOf Me.ChangeProperty
    End Sub
    ' แสดงค่าข้อมูลของลูกค้าลงใน control ที่อยู่บนฟอร์ม
    Public Overrides Sub UpdateEntityProperties()
      m_isInitialized = False
      ClearDetail()
      If m_entity Is Nothing Then
        Return
      End If

      txtCode.Text = m_entity.Code
      'autogencode
      Me.m_oldCode = Me.m_entity.Code
      Me.chkAutorun.Checked = Me.m_entity.AutoGen
      Me.UpdateAutogenStatus()

      txtIssueDate.Text = MinDateToNull(Me.m_entity.IssueDate, Me.StringParserService.Parse("${res:Global.BlankDateText}"))
      dtpIssueDate.Value = MinDateToNow(Me.m_entity.IssueDate)

      txtEffectiveDate.Text = MinDateToNull(Me.m_entity.EffectiveDate, Me.StringParserService.Parse("${res:Global.BlankDateText}"))
      dtpEffectiveDate.Value = MinDateToNow(Me.m_entity.EffectiveDate)

      txtPickupDate.Text = MinDateToNull(Me.m_entity.PickUpDate, Me.StringParserService.Parse("${res:Global.BlankDateText}"))
      dtpPickupDate.Value = MinDateToNow(Me.m_entity.PickUpDate)

      If Not Me.m_entity.BankAccount Is Nothing Then
        txtBankAccountCode.Text = Me.m_entity.BankAccount.Code
        txtBankAccountName.Text = Me.m_entity.BankAccount.Name
      End If
      SetBankBranch()

      cmbChargee.SelectedValue = Me.m_entity.Chargee

      RefreshDocs()
      CheckFormEnable()
      SetStatus()
      SetLabelText()

      m_isInitialized = True
    End Sub
    Private Sub RefreshDocs()
      Me.m_isInitialized = False
      Me.m_entity.ItemCollection.Populate(m_treeManager.Treetable)
      RefreshBlankGrid()
      ReIndex()
      RefreshWHT()
      ReIndex2()
      Me.m_treeManager.Treetable.AcceptChanges()
      Me.SetSummaryText()
      Me.m_isInitialized = True
    End Sub
    Private Sub PropChanged(ByVal sender As Object, ByVal e As PropertyChangedEventArgs)
      If e.Name = "ItemChanged" Then
        Me.WorkbenchWindow.ViewContent.IsDirty = True
      End If
    End Sub

    Private m_dateSetting As Boolean = False
    Public Sub ChangeProperty(ByVal sender As Object, ByVal e As EventArgs)
      If Me.m_entity Is Nothing Or Not m_isInitialized Then
        Return
      End If
      Dim dirtyFlag As Boolean = False
      Select Case CType(sender, Control).Name.ToLower
        Case "txtcode"
          Me.m_entity.Code = txtCode.Text
          dirtyFlag = True

        Case "dtpissuedate"
          txtIssueDate.Text = MinDateToNull(dtpIssueDate.Value, "")
          Me.m_entity.IssueDate = dtpIssueDate.Value
          dirtyFlag = True

        Case "txtissuedate"
          Dim dt As Date = StringToDate(txtIssueDate, dtpIssueDate)
          Me.m_entity.IssueDate = dt
          dirtyFlag = True

        Case "dtpeffectivedate"
          txtEffectiveDate.Text = MinDateToNull(dtpEffectiveDate.Value, "")
          Me.m_entity.EffectiveDate = dtpEffectiveDate.Value
          dirtyFlag = True

        Case "txteffectivedate"
          Dim dt As Date = StringToDate(txtEffectiveDate, dtpEffectiveDate)
          Me.m_entity.EffectiveDate = dt
          dirtyFlag = True

        Case "dtppickupdate"
          txtPickupDate.Text = MinDateToNull(dtpPickupDate.Value, "")
          Me.m_entity.PickUpDate = dtpPickupDate.Value
          dirtyFlag = True

        Case "txtpickupdate"
          Dim dt As Date = StringToDate(txtPickupDate, dtpPickupDate)
          Me.m_entity.PickUpDate = dt
          dirtyFlag = True

        Case "txtbankaccountcode"
          dirtyFlag = BankAccount.GetBankAccount(txtBankAccountCode, txtBankAccountName, Me.m_entity.BankAccount)
          SetBankBranch(True)

        Case "cmbchargee"
          Me.m_entity.Chargee = cmbChargee.SelectedValue
          dirtyFlag = True
      End Select

      Me.WorkbenchWindow.ViewContent.IsDirty = Me.WorkbenchWindow.ViewContent.IsDirty Or dirtyFlag

      CheckFormEnable()
      SetStatus()

    End Sub
    Public Sub SetStatus()
      Me.StatusDescription = ""
      If m_entity.Canceled Then
        Me.StatusDescription = "ยกเลิก: " & m_entity.CancelDate.ToShortDateString & _
        " " & m_entity.CancelDate.ToShortTimeString & _
        "  โดย:" & m_entity.CancelPerson.Name
      ElseIf m_entity.Edited Then
        Me.StatusDescription = "เพิ่มเข้าสู่ระบบ: " & m_entity.OriginDate.ToShortDateString & _
        " " & m_entity.OriginDate.ToShortTimeString & _
        "  โดย:" & m_entity.Originator.Name
        Me.StatusDescription &= ",แก้ไขล่าสุด: " & m_entity.LastEditDate.ToShortDateString & _
        " " & m_entity.LastEditDate.ToShortTimeString & _
        "  โดย:" & m_entity.LastEditor.Name
      ElseIf Me.m_entity.Originated Then
        Me.StatusDescription = "เพิ่มเข้าสู่ระบบ: " & m_entity.OriginDate.ToShortDateString & _
        " " & m_entity.OriginDate.ToShortTimeString & _
        "  โดย:" & m_entity.Originator.Name
      Else
        Me.StatusDescription = ""
      End If
      Me.StatusBarService.SetMessage(Me.StatusDescription)
    End Sub
    Public Overrides Property Entity() As ISimpleEntity
      Get
        Return Me.m_entity
      End Get
      Set(ByVal Value As ISimpleEntity)
        If Not Me.m_entity Is Nothing Then
          RemoveHandler Me.m_entity.PropertyChanged, AddressOf PropChanged
          Me.m_entity = Nothing
        End If
        Me.m_entity = CType(Value, ExportOutgoingCheck)
        'Hack:
        Me.m_entity.OnTabPageTextChanged(m_entity, EventArgs.Empty)
        UpdateEntityProperties()
      End Set
    End Property

#End Region

#Region "Event Handlers"
    Public Sub CheckButtonClick(ByVal e As ButtonColumnEventArgs)
      If e.Column = 2 Then
        Dim myMessageService As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
        Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)

        If Me.txtBankAccountCode.TextLength = 0 Then
          myMessageService.ShowWarningFormatted("${res:Global.MustDefine}", lblBankAccount.Text)
          txtBankAccountCode.Focus()
          Return
        End If

        Dim entities As New ArrayList
        Dim obj As New OutgoingCheck
        obj.Bankacct = Me.m_entity.BankAccount
        obj.DocStatus = New OutgoingCheckDocStatus(1)  ' แสดง ในมือ เท่านั้น ...
        entities.Add(obj)

        Dim IDList As String = ""
        For Each row As ExportOutgoingCheckItem In Me.m_entity.ItemCollection
          IDList &= CStr(row.Entity.Id) & ","
        Next

        '==Checking for addin
        Dim ReceiptCheckAtBank As Boolean = False
        For Each a As AddIn In AddInTreeSingleton.AddInTree.AddIns
          If a.FileName.ToLower.Contains("textexport") Then
            ReceiptCheckAtBank = True
          End If
        Next

        Dim filters(2) As Filter
        filters(0) = New Filter("IDList", IDList)
        filters(1) = New Filter("onlyEmptyCode", "1")
        filters(2) = New Filter("ReceiptAtBank", ReceiptCheckAtBank)

        myEntityPanelService.OpenListDialog(New OutgoingCheck, AddressOf SetCheckItems, filters, entities)
      ElseIf e.Column = 10 Then
        Dim doc As ExportOutgoingCheckItem = Me.CurrentItem
        If doc Is Nothing Then
          Return
        End If
        Dim dlg As New DocPickupList(Me.m_entity)
        dlg.ShowDialog()
        doc.DocumentForPickup = Me.m_entity.DocumentPickingList
        RefreshDocs()
        Me.WorkbenchWindow.ViewContent.IsDirty = True
      End If
    End Sub
    Private Sub SetCheckItems(ByVal items As BasketItemCollection)
      Dim index As Integer = tgItem.CurrentRowIndex

      For i As Integer = items.Count - 1 To 0 Step -1
        Dim newItem As New OutgoingCheck(CType(items(i), BasketItem).Id)
        Dim doc As New ExportOutgoingCheckItem
        If Not Me.CurrentItem Is Nothing Then
          doc = Me.CurrentItem
          Me.m_treeManager.SelectedRow.Tag = Nothing
        Else
          If Me.m_entity.ItemCollection.Count > 0 Then
            Me.m_entity.ItemCollection.Insert(index, doc)
          Else
            Me.m_entity.ItemCollection.Add(doc)
          End If
        End If
        doc.Entity = newItem
      Next

      RefreshDocs()
      tgItem.CurrentRowIndex = index
      Me.WorkbenchWindow.ViewContent.IsDirty = True
    End Sub
    Private Sub SetItemsCode(ByVal items As String)
      Dim index As Integer = tgItem.CurrentRowIndex

      Dim newItem As New OutgoingCheck(items)
      Dim doc As New ExportOutgoingCheckItem
      If Not Me.CurrentItem Is Nothing Then
        If items.Length = 0 Then
          Me.m_entity.ItemCollection.Remove(Me.CurrentItem)
        End If
        doc = Me.CurrentItem
        Me.m_treeManager.SelectedRow.Tag = Nothing
      Else
        If Me.m_entity.ItemCollection.Count > 0 Then
          Me.m_entity.ItemCollection.Insert(index, doc)
        Else
          Me.m_entity.ItemCollection.Add(doc)
        End If
      End If
      doc.Entity = newItem

      RefreshDocs()
      tgItem.CurrentRowIndex = index
      Me.WorkbenchWindow.ViewContent.IsDirty = True
    End Sub
    Private Sub ReIndex()
      Dim i As Integer = 0
      For Each row As DataRow In Me.m_treeManager.Treetable.Rows
        row("eocheck_linenumber") = i + 1
        i += 1
      Next
    End Sub
    Private Sub ReIndex2()
      Dim i As Integer = 0
      For Each row As DataRow In Me.m_treeManager2.Treetable.Rows
        row("whti_linenumber") = i + 1
        i += 1
      Next
    End Sub

    '        Private Sub PRPanelView_WorkbenchWindowChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.WorkbenchWindowChanged
    '            AddHandler Me.WorkbenchWindow.ViewContent.Saved, AddressOf EntitySaved
    '        End Sub
    '        Private Sub EntitySaved(ByVal sender As Object, ByVal e As SaveEventArgs)

    'End Sub
    Private Sub tgItem_CurrentCellChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tgItem.CurrentCellChanged
      RefreshWHT()
      ReIndex2()
    End Sub
    Private Sub RefreshWHT()
      Dim dt As TreeTable = Me.m_treeManager2.Treetable
      dt.Clear()
      If Me.CurrentItem Is Nothing Then
        Return
      End If
      Dim item As ExportOutgoingCheckItem = Me.CurrentItem
      If item.WHTCollection Is Nothing OrElse item.WHTCollection.Count = 0 Then
        Return
      End If

      Dim j As Integer = 0
      For j = 0 To item.WHTCollection.Count - 1
        item.WHTCollection(j).ReLoadItems2(dt)
      Next
    End Sub
#End Region

#Region " Event of Button controls "
    Private Sub btnBankAccountFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBankAccountFind.Click
      Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      myEntityPanelService.OpenListDialog(New BankAccount, AddressOf SetBankAccountDialog)
    End Sub

    Private Sub SetBankAccountDialog(ByVal e As ISimpleEntity)
      Me.txtBankAccountCode.Text = e.Code
      Me.WorkbenchWindow.ViewContent.IsDirty = _
          Me.WorkbenchWindow.ViewContent.IsDirty Or _
          BankAccount.GetBankAccount(txtBankAccountCode, txtBankAccountName, Me.m_entity.BankAccount)
      SetBankBranch(True)
    End Sub

    Private Sub btnBankAccountEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBankAccountEdit.Click
      Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      myEntityPanelService.OpenPanel(New BankAccount)
    End Sub
    Private Sub btnExport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExport.Click
      If Me.m_entity.Originated Then
        Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
        If Not Validator.ValidationSummary Is Nothing AndAlso Validator.ValidationSummary.Length > 0 Then
          msgServ.ShowMessage(Validator.ValidationSummary)
          Return
        End If

        Dim myOpb As New SaveFileDialog
        myOpb.Filter = "All Files|*.*|Text File (*.txt)|*.txt"
        myOpb.FilterIndex = 2
        'myOpb.FileName = "String" & Replace(ComboBox1.SelectedValue, "_", "s.") & ".resources"
        If myOpb.ShowDialog() = DialogResult.OK Then
          Dim fileName As String = Path.GetDirectoryName(myOpb.FileName) & Path.DirectorySeparatorChar & Path.GetFileName(myOpb.FileName)
          Dim writer As New IO.StreamWriter(fileName, False, System.Text.Encoding.Default)

          Try
            Exporter.Export(m_entity, writer)
            MessageBox.Show(Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ExportOutgoingCheckDetail.ExportCompleted}"))
          Catch ex As Exception
            MessageBox.Show("Error:" & ex.ToString)
          Finally
            writer.Close()
          End Try

          'Dim culture = New CultureInfo("en-US", True)

          'Dim myBankCode As String = Me.m_entity.BankAccount.BankCode
          'If Not myBankCode Is Nothing Then
          '    If myBankCode.Length > 10 Then
          '        myBankCode = myBankCode.Substring(0, 10)
          '    End If
          'End If
          'writer.WriteLine("HCOC{1,-10}{0,16}{2,10}{3,10}{0,5}{4,18}{5,18}{6,1}", "", myBankCode, Me.m_entity.EffectiveDate.ToString("dd-MM-yyyy", culture), Me.m_entity.PickUpDate.ToString("dd-MM-yyyy", culture), Format(Me.m_entity.CheckCount, "000000000000000000"), Format(Me.m_entity.TotalAmount, "000000000000000.00"), Me.m_entity.Chargee)
          'Dim i As Integer = 0
          'Dim j As Integer = 0
          'For i = 0 To Me.m_entity.CheckCount - 1
          '    Dim myEOCItem As ExportOutgoingCheckItem = Me.m_entity.ItemCollection(i)
          '    Dim myPVCode As String = myEOCItem.PVCode
          '    If Not myPVCode Is Nothing Then
          '        If myPVCode.Length > 10 Then
          '            myPVCode = myPVCode.Substring(0, 10)
          '        End If
          '    End If
          '    writer.Write("D{1,-10}{2,13}{3,-120}{0,30}{0,30}{0,30}{0,30}{0,10}{0,13}", "", myPVCode, Format(myEOCItem.Entity.Amount, "0000000000.00"), myEOCItem.Entity.Recipient)
          '    writer.Write("{1,-16}{2,-255}", "", i + 1, myEOCItem.Detail)
          '    writer.Write("{1,2}{2,-4}{3,-24}{0,50}{4,1}{5,-50}{0,50}", "", myEOCItem.DeliveryMethod, myEOCItem.PickupCode, myEOCItem.DocumentForPickup, IIf(Not myEOCItem.Entity.Supplier.Fax Is Nothing AndAlso myEOCItem.Entity.Supplier.Fax.Length > 1, "F", ""), myEOCItem.Entity.Supplier.Fax)
          '    writer.WriteLine("{1,13}{2,13}{3,13}{4,3}", "", Format(Me.m_entity.ItemCollection(i).AmountBeforeVat, "0000000000.00"), Format(Me.m_entity.ItemCollection(i).AmountWHT, "0000000000.00"), Format(Me.m_entity.ItemCollection(i).AmountAfterVat, "0000000000.00"), Format(Me.m_entity.ItemCollection(i).TaxCount, "000"))

          '    If Not myEOCItem.WHTCollection Is Nothing Then
          '        For k As Integer = 0 To myEOCItem.WHTCollection.Count - 1
          '            myEOCItem.WHTCollection(k).ReLoadItems2()
          '            For l As Integer = 0 To myEOCItem.WHTCollection(k).ItemTable2.Childs.Count - 1
          '                j += 1
          '                Dim myRow As TreeRow = myEOCItem.WHTCollection(k).ItemTable2.Childs(l)
          '                writer.Write("T{1,2}{2,-10}{3,6}{4,-40}", "", Format(CDec(myRow.Item("wht_type_id")), "00"), j, Format(CDec(myRow.Item("whti_taxrate")), "000.00"), myRow.Item("whti_description"))
          '                writer.WriteLine("{0,13}{1,13}{2,13}{3,1}", Format(CDec(myRow.Item("whti_taxbase")), "0000000000.00"), Format(CDec(myRow.Item("Amount")), "0000000000.00"), Format(0, "0000000000.00"), CDec(myRow.Item("wht_paymenttype_id")))
          '            Next
          '        Next
          '    End If
          'Next

          'writer.Close()
          'MessageBox.Show(Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ExportOutgoingCheckDetail.ExportCompleted}"))
        End If
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
    '        Public Overrides ReadOnly Property TabPageIcon() As String
    '            Get
    '                Return (New UpdateCheckReceive).DetailPanelIcon
    '            End Get
    '        End Property
    '#End Region

    '#Region "Rows Manager Button"
    '        ' Add Item ...
    '        Private Sub ibtnBlank_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnBlank.Click
    '            Dim index As Integer = tgItem.CurrentRowIndex
    '            Dim newItem As New BlankItem("")
    '            Dim checkItem As New UpdateCheckReceiveItem

    '            'checkItem.Entity = CType(newItem, ISimpleEntity)

    '            Me.m_entity.Insert(index, checkItem)
    '            Me.m_entity.ItemTable.AcceptChanges()
    '            tgItem.CurrentRowIndex = index
    '            RefreshBlankGrid()
    '        End Sub
    ' Delete Item ...
    Private Sub ibtnDelRow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnDelRow.Click
      Dim index As Integer = Me.tgItem.CurrentRowIndex
      If Not Me.CurrentItem Is Nothing Then
        Me.m_entity.ItemCollection.Remove(index)
      End If
      Me.tgItem.CurrentRowIndex = index
      RefreshDocs()
      Me.WorkbenchWindow.ViewContent.IsDirty = True
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
      Dim dirtyFlag As Boolean = Me.WorkbenchWindow.ViewContent.IsDirty
      Dim index As Integer = tgItem.CurrentRowIndex

      Do Until Me.m_treeManager.Treetable.Rows.Count > tgItem.VisibleRowCount
        'เพิ่มแถวจนเต็ม
        Me.m_treeManager.Treetable.Childs.Add()
      Loop

      If Me.m_entity.ItemCollection.Count = Me.m_treeManager.Treetable.Childs.Count Then
        'เพิ่มอีก 1 แถว ถ้ามีข้อมูลจนถึงแถวสุดท้าย
        Me.m_treeManager.Treetable.Childs.Add()
      End If

      Me.m_treeManager.Treetable.AcceptChanges()
      tgItem.CurrentRowIndex = Math.Max(0, index)
      Me.WorkbenchWindow.ViewContent.IsDirty = dirtyFlag
    End Sub
#End Region

#Region "Private Methods"
    Private Sub SetSummaryText()
      Me.m_entity.CheckCount = Me.m_entity.ItemCollection.Count
      Me.m_entity.TotalAmount = Me.m_entity.ItemCollection.Amount

      txtCheckCount.Text = Configuration.FormatToString(Me.m_entity.CheckCount, DigitConfig.Int)
      txtSumTotal.Text = Configuration.FormatToString(Me.m_entity.TotalAmount, DigitConfig.Price)
    End Sub
#End Region

#Region " Autogencode "
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
        'Hack: set Code ???? "" ??
        Me.m_entity.Code = ""
        Me.m_entity.AutoGen = True
      Else
        Me.Validator.SetRequired(Me.txtCode, True)
        Me.txtCode.Text = m_oldCode
        Me.txtCode.ReadOnly = False
        Me.m_entity.AutoGen = False
      End If
    End Sub
#End Region

  End Class

End Namespace
