Imports Longkong.Pojjaman.BusinessLogic
Imports Longkong.Pojjaman.TextHelper
Imports Longkong.Pojjaman.Gui.Components
Imports Longkong.Core.Services
Imports System.Reflection
Imports Longkong.Pojjaman.DataAccessLayer
Imports Longkong.Pojjaman.Services
Imports System.Drawing.Printing
Imports Longkong.Pojjaman.Gui.ReportsAndDocs
Imports System.Drawing
Imports System.Drawing.Drawing2D

Namespace Longkong.Pojjaman.Gui.Panels
  Public Class EqtChangeStatusDetail
    Inherits AbstractEntityDetailPanelView
    Implements IValidatable

#Region " Windows Form Designer generated code "
    Friend WithEvents grbSummary As Longkong.Pojjaman.Gui.Components.FixedGroupBox
    Friend WithEvents lblChangeItem As System.Windows.Forms.Label
    Friend WithEvents txtItemCount As System.Windows.Forms.TextBox
    Friend WithEvents lblItemCount As System.Windows.Forms.Label
    Friend WithEvents lblItemCountUnit As System.Windows.Forms.Label
    Friend WithEvents grbStore As Longkong.Pojjaman.Gui.Components.FixedGroupBox
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents Validator As Longkong.Pojjaman.Gui.Components.PJMTextboxValidator
    Friend WithEvents lblStatus As System.Windows.Forms.Label
    Friend WithEvents txtStorepersonName As System.Windows.Forms.TextBox
    Friend WithEvents txtStoreCCName As System.Windows.Forms.TextBox
    Friend WithEvents txtStoreCCCode As System.Windows.Forms.TextBox
    Friend WithEvents lblStoreperson As System.Windows.Forms.Label
    Friend WithEvents lblStoreCC As System.Windows.Forms.Label
    Friend WithEvents txtStorepersonCode As System.Windows.Forms.TextBox
    Friend WithEvents btnStoreCCFind As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents btnStorepersonFind As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents btnStoreCCEdit As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents btnStorepersonEdit As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents ibtnBlank As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents ibtnDelRow As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents grbGeneral As Longkong.Pojjaman.Gui.Components.FixedGroupBox
    Friend WithEvents chkAutorun As System.Windows.Forms.CheckBox
    Friend WithEvents txtDocDate As System.Windows.Forms.TextBox
    Friend WithEvents txtCode As System.Windows.Forms.TextBox
    Friend WithEvents dtpDocDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblDocDate As System.Windows.Forms.Label
    Friend WithEvents lblCode As System.Windows.Forms.Label
    Friend WithEvents txtNote As System.Windows.Forms.TextBox
    Friend WithEvents lblNote As System.Windows.Forms.Label
    Friend WithEvents lblAmount As System.Windows.Forms.Label
    Friend WithEvents lblCurrency As System.Windows.Forms.Label
    Friend WithEvents cmbToStatus As System.Windows.Forms.ComboBox
    Friend WithEvents lblToStatus As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmbFromStatus As System.Windows.Forms.ComboBox
    Friend WithEvents tgItem As Longkong.Pojjaman.Gui.Components.TreeGrid
    Private Sub InitializeComponent()
      Me.components = New System.ComponentModel.Container()
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(EqtChangeStatusDetail))
      Me.txtItemCount = New System.Windows.Forms.TextBox()
      Me.lblItemCount = New System.Windows.Forms.Label()
      Me.lblItemCountUnit = New System.Windows.Forms.Label()
      Me.lblChangeItem = New System.Windows.Forms.Label()
      Me.grbSummary = New Longkong.Pojjaman.Gui.Components.FixedGroupBox()
      Me.lblAmount = New System.Windows.Forms.Label()
      Me.lblCurrency = New System.Windows.Forms.Label()
      Me.grbStore = New Longkong.Pojjaman.Gui.Components.FixedGroupBox()
      Me.Label1 = New System.Windows.Forms.Label()
      Me.cmbFromStatus = New System.Windows.Forms.ComboBox()
      Me.lblToStatus = New System.Windows.Forms.Label()
      Me.cmbToStatus = New System.Windows.Forms.ComboBox()
      Me.btnStoreCCFind = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.btnStorepersonFind = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.btnStoreCCEdit = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.btnStorepersonEdit = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.txtStorepersonName = New System.Windows.Forms.TextBox()
      Me.txtStoreCCName = New System.Windows.Forms.TextBox()
      Me.txtStoreCCCode = New System.Windows.Forms.TextBox()
      Me.lblStoreperson = New System.Windows.Forms.Label()
      Me.lblStoreCC = New System.Windows.Forms.Label()
      Me.txtStorepersonCode = New System.Windows.Forms.TextBox()
      Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
      Me.txtDocDate = New System.Windows.Forms.TextBox()
      Me.txtCode = New System.Windows.Forms.TextBox()
      Me.Validator = New Longkong.Pojjaman.Gui.Components.PJMTextboxValidator(Me.components)
      Me.txtNote = New System.Windows.Forms.TextBox()
      Me.lblStatus = New System.Windows.Forms.Label()
      Me.ibtnBlank = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.ibtnDelRow = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.grbGeneral = New Longkong.Pojjaman.Gui.Components.FixedGroupBox()
      Me.lblNote = New System.Windows.Forms.Label()
      Me.chkAutorun = New System.Windows.Forms.CheckBox()
      Me.dtpDocDate = New System.Windows.Forms.DateTimePicker()
      Me.lblDocDate = New System.Windows.Forms.Label()
      Me.lblCode = New System.Windows.Forms.Label()
      Me.tgItem = New Longkong.Pojjaman.Gui.Components.TreeGrid()
      Me.grbSummary.SuspendLayout()
      Me.grbStore.SuspendLayout()
      CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.grbGeneral.SuspendLayout()
      CType(Me.tgItem, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.SuspendLayout()
      '
      'txtItemCount
      '
      Me.txtItemCount.BackColor = System.Drawing.SystemColors.Control
      Me.txtItemCount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
      Me.Validator.SetDataType(Me.txtItemCount, Longkong.Pojjaman.Gui.Components.DataTypeConstants.Int16Type)
      Me.Validator.SetDisplayName(Me.txtItemCount, "")
      Me.Validator.SetGotFocusBackColor(Me.txtItemCount, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtItemCount, -15)
      Me.Validator.SetInvalidBackColor(Me.txtItemCount, System.Drawing.Color.Empty)
      Me.txtItemCount.Location = New System.Drawing.Point(120, 16)
      Me.Validator.SetMinValue(Me.txtItemCount, "")
      Me.txtItemCount.Name = "txtItemCount"
      Me.txtItemCount.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtItemCount, "")
      Me.Validator.SetRequired(Me.txtItemCount, False)
      Me.txtItemCount.Size = New System.Drawing.Size(64, 21)
      Me.txtItemCount.TabIndex = 1
      Me.txtItemCount.TabStop = False
      Me.txtItemCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
      '
      'lblItemCount
      '
      Me.lblItemCount.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblItemCount.Location = New System.Drawing.Point(8, 16)
      Me.lblItemCount.Name = "lblItemCount"
      Me.lblItemCount.Size = New System.Drawing.Size(104, 18)
      Me.lblItemCount.TabIndex = 0
      Me.lblItemCount.Text = "จำนวนรายการเปลี่ยน"
      Me.lblItemCount.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblItemCountUnit
      '
      Me.lblItemCountUnit.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblItemCountUnit.Location = New System.Drawing.Point(192, 16)
      Me.lblItemCountUnit.Name = "lblItemCountUnit"
      Me.lblItemCountUnit.Size = New System.Drawing.Size(40, 18)
      Me.lblItemCountUnit.TabIndex = 2
      Me.lblItemCountUnit.Text = "รายการ"
      Me.lblItemCountUnit.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblChangeItem
      '
      Me.lblChangeItem.AutoSize = True
      Me.lblChangeItem.BackColor = System.Drawing.Color.Transparent
      Me.lblChangeItem.Cursor = System.Windows.Forms.Cursors.Default
      Me.lblChangeItem.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblChangeItem.Location = New System.Drawing.Point(16, 164)
      Me.lblChangeItem.Name = "lblChangeItem"
      Me.lblChangeItem.Size = New System.Drawing.Size(137, 16)
      Me.lblChangeItem.TabIndex = 3
      Me.lblChangeItem.Text = "รายการเปลี่ยนสถานะ:"
      Me.lblChangeItem.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      '
      'grbSummary
      '
      Me.grbSummary.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.grbSummary.Controls.Add(Me.lblAmount)
      Me.grbSummary.Controls.Add(Me.lblCurrency)
      Me.grbSummary.Controls.Add(Me.txtItemCount)
      Me.grbSummary.Controls.Add(Me.lblItemCount)
      Me.grbSummary.Controls.Add(Me.lblItemCountUnit)
      Me.grbSummary.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.grbSummary.Location = New System.Drawing.Point(245, 352)
      Me.grbSummary.Name = "grbSummary"
      Me.grbSummary.Size = New System.Drawing.Size(483, 48)
      Me.grbSummary.TabIndex = 8
      Me.grbSummary.TabStop = False
      Me.grbSummary.Text = "สรุปยอดเปลี่ยน"
      '
      'lblAmount
      '
      Me.lblAmount.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblAmount.Location = New System.Drawing.Point(229, 17)
      Me.lblAmount.Name = "lblAmount"
      Me.lblAmount.Size = New System.Drawing.Size(104, 18)
      Me.lblAmount.TabIndex = 3
      Me.lblAmount.Text = "มูลค่า"
      Me.lblAmount.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblCurrency
      '
      Me.lblCurrency.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblCurrency.Location = New System.Drawing.Point(413, 17)
      Me.lblCurrency.Name = "lblCurrency"
      Me.lblCurrency.Size = New System.Drawing.Size(40, 18)
      Me.lblCurrency.TabIndex = 5
      Me.lblCurrency.Text = "บาท"
      Me.lblCurrency.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'grbStore
      '
      Me.grbStore.Controls.Add(Me.Label1)
      Me.grbStore.Controls.Add(Me.cmbFromStatus)
      Me.grbStore.Controls.Add(Me.lblToStatus)
      Me.grbStore.Controls.Add(Me.cmbToStatus)
      Me.grbStore.Controls.Add(Me.btnStoreCCFind)
      Me.grbStore.Controls.Add(Me.btnStorepersonFind)
      Me.grbStore.Controls.Add(Me.btnStoreCCEdit)
      Me.grbStore.Controls.Add(Me.btnStorepersonEdit)
      Me.grbStore.Controls.Add(Me.txtStorepersonName)
      Me.grbStore.Controls.Add(Me.txtStoreCCName)
      Me.grbStore.Controls.Add(Me.txtStoreCCCode)
      Me.grbStore.Controls.Add(Me.lblStoreperson)
      Me.grbStore.Controls.Add(Me.lblStoreCC)
      Me.grbStore.Controls.Add(Me.txtStorepersonCode)
      Me.grbStore.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.grbStore.Location = New System.Drawing.Point(8, 80)
      Me.grbStore.Name = "grbStore"
      Me.grbStore.Size = New System.Drawing.Size(720, 72)
      Me.grbStore.TabIndex = 1
      Me.grbStore.TabStop = False
      Me.grbStore.Text = "ผู้บันทึก"
      '
      'Label1
      '
      Me.Label1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Label1.Location = New System.Drawing.Point(10, 45)
      Me.Label1.Name = "Label1"
      Me.Label1.Size = New System.Drawing.Size(96, 18)
      Me.Label1.TabIndex = 13
      Me.Label1.Text = "จากสถานะ :"
      Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'cmbFromStatus
      '
      Me.cmbFromStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbFromStatus.Enabled = False
      Me.ErrorProvider1.SetIconPadding(Me.cmbFromStatus, -15)
      Me.cmbFromStatus.Location = New System.Drawing.Point(112, 45)
      Me.cmbFromStatus.Name = "cmbFromStatus"
      Me.cmbFromStatus.Size = New System.Drawing.Size(184, 21)
      Me.cmbFromStatus.TabIndex = 12
      '
      'lblToStatus
      '
      Me.lblToStatus.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblToStatus.Location = New System.Drawing.Point(365, 45)
      Me.lblToStatus.Name = "lblToStatus"
      Me.lblToStatus.Size = New System.Drawing.Size(96, 18)
      Me.lblToStatus.TabIndex = 11
      Me.lblToStatus.Text = "เปลี่ยนสถานะเป็น :"
      Me.lblToStatus.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'cmbToStatus
      '
      Me.cmbToStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbToStatus.Enabled = False
      Me.ErrorProvider1.SetIconPadding(Me.cmbToStatus, -15)
      Me.cmbToStatus.Location = New System.Drawing.Point(469, 45)
      Me.cmbToStatus.Name = "cmbToStatus"
      Me.cmbToStatus.Size = New System.Drawing.Size(184, 21)
      Me.cmbToStatus.TabIndex = 10
      '
      'btnStoreCCFind
      '
      Me.btnStoreCCFind.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnStoreCCFind.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.btnStoreCCFind.ForeColor = System.Drawing.SystemColors.Control
      Me.btnStoreCCFind.Location = New System.Drawing.Point(296, 16)
      Me.btnStoreCCFind.Name = "btnStoreCCFind"
      Me.btnStoreCCFind.Size = New System.Drawing.Size(24, 23)
      Me.btnStoreCCFind.TabIndex = 3
      Me.btnStoreCCFind.TabStop = False
      Me.btnStoreCCFind.ThemedImage = CType(resources.GetObject("btnStoreCCFind.ThemedImage"), System.Drawing.Bitmap)
      '
      'btnStorepersonFind
      '
      Me.btnStorepersonFind.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnStorepersonFind.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.btnStorepersonFind.ForeColor = System.Drawing.SystemColors.Control
      Me.btnStorepersonFind.Location = New System.Drawing.Point(653, 18)
      Me.btnStorepersonFind.Name = "btnStorepersonFind"
      Me.btnStorepersonFind.Size = New System.Drawing.Size(24, 23)
      Me.btnStorepersonFind.TabIndex = 8
      Me.btnStorepersonFind.TabStop = False
      Me.btnStorepersonFind.ThemedImage = CType(resources.GetObject("btnStorepersonFind.ThemedImage"), System.Drawing.Bitmap)
      '
      'btnStoreCCEdit
      '
      Me.btnStoreCCEdit.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnStoreCCEdit.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.btnStoreCCEdit.Location = New System.Drawing.Point(320, 16)
      Me.btnStoreCCEdit.Name = "btnStoreCCEdit"
      Me.btnStoreCCEdit.Size = New System.Drawing.Size(24, 23)
      Me.btnStoreCCEdit.TabIndex = 4
      Me.btnStoreCCEdit.TabStop = False
      Me.btnStoreCCEdit.ThemedImage = CType(resources.GetObject("btnStoreCCEdit.ThemedImage"), System.Drawing.Bitmap)
      '
      'btnStorepersonEdit
      '
      Me.btnStorepersonEdit.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnStorepersonEdit.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.btnStorepersonEdit.Location = New System.Drawing.Point(677, 18)
      Me.btnStorepersonEdit.Name = "btnStorepersonEdit"
      Me.btnStorepersonEdit.Size = New System.Drawing.Size(24, 23)
      Me.btnStorepersonEdit.TabIndex = 9
      Me.btnStorepersonEdit.TabStop = False
      Me.btnStorepersonEdit.ThemedImage = CType(resources.GetObject("btnStorepersonEdit.ThemedImage"), System.Drawing.Bitmap)
      '
      'txtStorepersonName
      '
      Me.txtStorepersonName.BackColor = System.Drawing.SystemColors.Control
      Me.Validator.SetDataType(Me.txtStorepersonName, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtStorepersonName, "")
      Me.Validator.SetGotFocusBackColor(Me.txtStorepersonName, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtStorepersonName, System.Drawing.Color.Empty)
      Me.txtStorepersonName.Location = New System.Drawing.Point(533, 18)
      Me.Validator.SetMinValue(Me.txtStorepersonName, "")
      Me.txtStorepersonName.Name = "txtStorepersonName"
      Me.txtStorepersonName.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtStorepersonName, "")
      Me.Validator.SetRequired(Me.txtStorepersonName, False)
      Me.txtStorepersonName.Size = New System.Drawing.Size(120, 21)
      Me.txtStorepersonName.TabIndex = 7
      Me.txtStorepersonName.TabStop = False
      '
      'txtStoreCCName
      '
      Me.txtStoreCCName.BackColor = System.Drawing.SystemColors.Control
      Me.Validator.SetDataType(Me.txtStoreCCName, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtStoreCCName, "")
      Me.Validator.SetGotFocusBackColor(Me.txtStoreCCName, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtStoreCCName, System.Drawing.Color.Empty)
      Me.txtStoreCCName.Location = New System.Drawing.Point(176, 16)
      Me.Validator.SetMinValue(Me.txtStoreCCName, "")
      Me.txtStoreCCName.Name = "txtStoreCCName"
      Me.txtStoreCCName.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtStoreCCName, "")
      Me.Validator.SetRequired(Me.txtStoreCCName, False)
      Me.txtStoreCCName.Size = New System.Drawing.Size(120, 21)
      Me.txtStoreCCName.TabIndex = 2
      Me.txtStoreCCName.TabStop = False
      '
      'txtStoreCCCode
      '
      Me.txtStoreCCCode.BackColor = System.Drawing.SystemColors.Window
      Me.Validator.SetDataType(Me.txtStoreCCCode, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtStoreCCCode, "")
      Me.Validator.SetGotFocusBackColor(Me.txtStoreCCCode, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtStoreCCCode, -15)
      Me.Validator.SetInvalidBackColor(Me.txtStoreCCCode, System.Drawing.Color.Empty)
      Me.txtStoreCCCode.Location = New System.Drawing.Point(112, 16)
      Me.txtStoreCCCode.MaxLength = 20
      Me.Validator.SetMinValue(Me.txtStoreCCCode, "")
      Me.txtStoreCCCode.Name = "txtStoreCCCode"
      Me.Validator.SetRegularExpression(Me.txtStoreCCCode, "")
      Me.Validator.SetRequired(Me.txtStoreCCCode, False)
      Me.txtStoreCCCode.Size = New System.Drawing.Size(64, 21)
      Me.txtStoreCCCode.TabIndex = 8
      '
      'lblStoreperson
      '
      Me.lblStoreperson.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblStoreperson.Location = New System.Drawing.Point(365, 18)
      Me.lblStoreperson.Name = "lblStoreperson"
      Me.lblStoreperson.Size = New System.Drawing.Size(96, 18)
      Me.lblStoreperson.TabIndex = 5
      Me.lblStoreperson.Text = "ผู้บันทึก:"
      Me.lblStoreperson.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblStoreCC
      '
      Me.lblStoreCC.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblStoreCC.Location = New System.Drawing.Point(8, 16)
      Me.lblStoreCC.Name = "lblStoreCC"
      Me.lblStoreCC.Size = New System.Drawing.Size(96, 18)
      Me.lblStoreCC.TabIndex = 0
      Me.lblStoreCC.Text = "Cost Center เจ้าของ:"
      Me.lblStoreCC.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'txtStorepersonCode
      '
      Me.txtStorepersonCode.BackColor = System.Drawing.SystemColors.Window
      Me.Validator.SetDataType(Me.txtStorepersonCode, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtStorepersonCode, "")
      Me.Validator.SetGotFocusBackColor(Me.txtStorepersonCode, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtStorepersonCode, -15)
      Me.Validator.SetInvalidBackColor(Me.txtStorepersonCode, System.Drawing.Color.Empty)
      Me.txtStorepersonCode.Location = New System.Drawing.Point(469, 18)
      Me.txtStorepersonCode.MaxLength = 20
      Me.Validator.SetMinValue(Me.txtStorepersonCode, "")
      Me.txtStorepersonCode.Name = "txtStorepersonCode"
      Me.Validator.SetRegularExpression(Me.txtStorepersonCode, "")
      Me.Validator.SetRequired(Me.txtStorepersonCode, False)
      Me.txtStorepersonCode.Size = New System.Drawing.Size(64, 21)
      Me.txtStorepersonCode.TabIndex = 9
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
      Me.ErrorProvider1.SetIconPadding(Me.txtDocDate, -15)
      Me.Validator.SetInvalidBackColor(Me.txtDocDate, System.Drawing.Color.Empty)
      Me.txtDocDate.Location = New System.Drawing.Point(376, 16)
      Me.Validator.SetMinValue(Me.txtDocDate, "")
      Me.txtDocDate.Name = "txtDocDate"
      Me.Validator.SetRegularExpression(Me.txtDocDate, "")
      Me.Validator.SetRequired(Me.txtDocDate, True)
      Me.txtDocDate.Size = New System.Drawing.Size(115, 21)
      Me.txtDocDate.TabIndex = 4
      '
      'txtCode
      '
      Me.Validator.SetDataType(Me.txtCode, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtCode, "")
      Me.Validator.SetGotFocusBackColor(Me.txtCode, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtCode, -15)
      Me.Validator.SetInvalidBackColor(Me.txtCode, System.Drawing.Color.Empty)
      Me.txtCode.Location = New System.Drawing.Point(112, 16)
      Me.txtCode.MaxLength = 20
      Me.Validator.SetMinValue(Me.txtCode, "")
      Me.txtCode.Name = "txtCode"
      Me.Validator.SetRegularExpression(Me.txtCode, "")
      Me.Validator.SetRequired(Me.txtCode, True)
      Me.txtCode.Size = New System.Drawing.Size(112, 21)
      Me.txtCode.TabIndex = 1
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
      'txtNote
      '
      Me.txtNote.BackColor = System.Drawing.SystemColors.Window
      Me.Validator.SetDataType(Me.txtNote, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtNote, "")
      Me.Validator.SetGotFocusBackColor(Me.txtNote, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtNote, System.Drawing.Color.Empty)
      Me.txtNote.Location = New System.Drawing.Point(112, 40)
      Me.txtNote.MaxLength = 255
      Me.Validator.SetMinValue(Me.txtNote, "")
      Me.txtNote.Name = "txtNote"
      Me.Validator.SetRegularExpression(Me.txtNote, "")
      Me.Validator.SetRequired(Me.txtNote, False)
      Me.txtNote.Size = New System.Drawing.Size(552, 21)
      Me.txtNote.TabIndex = 7
      '
      'lblStatus
      '
      Me.lblStatus.AutoSize = True
      Me.lblStatus.Location = New System.Drawing.Point(376, 160)
      Me.lblStatus.Name = "lblStatus"
      Me.lblStatus.Size = New System.Drawing.Size(48, 13)
      Me.lblStatus.TabIndex = 6
      Me.lblStatus.Text = "lblStatus"
      '
      'ibtnBlank
      '
      Me.ibtnBlank.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.ibtnBlank.Location = New System.Drawing.Point(184, 156)
      Me.ibtnBlank.Name = "ibtnBlank"
      Me.ibtnBlank.Size = New System.Drawing.Size(32, 32)
      Me.ibtnBlank.TabIndex = 4
      Me.ibtnBlank.TabStop = False
      Me.ibtnBlank.ThemedImage = CType(resources.GetObject("ibtnBlank.ThemedImage"), System.Drawing.Bitmap)
      '
      'ibtnDelRow
      '
      Me.ibtnDelRow.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.ibtnDelRow.Location = New System.Drawing.Point(216, 156)
      Me.ibtnDelRow.Name = "ibtnDelRow"
      Me.ibtnDelRow.Size = New System.Drawing.Size(32, 32)
      Me.ibtnDelRow.TabIndex = 5
      Me.ibtnDelRow.TabStop = False
      Me.ibtnDelRow.ThemedImage = CType(resources.GetObject("ibtnDelRow.ThemedImage"), System.Drawing.Bitmap)
      '
      'grbGeneral
      '
      Me.grbGeneral.Controls.Add(Me.txtNote)
      Me.grbGeneral.Controls.Add(Me.lblNote)
      Me.grbGeneral.Controls.Add(Me.chkAutorun)
      Me.grbGeneral.Controls.Add(Me.txtDocDate)
      Me.grbGeneral.Controls.Add(Me.txtCode)
      Me.grbGeneral.Controls.Add(Me.dtpDocDate)
      Me.grbGeneral.Controls.Add(Me.lblDocDate)
      Me.grbGeneral.Controls.Add(Me.lblCode)
      Me.grbGeneral.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.grbGeneral.Location = New System.Drawing.Point(8, 8)
      Me.grbGeneral.Name = "grbGeneral"
      Me.grbGeneral.Size = New System.Drawing.Size(720, 72)
      Me.grbGeneral.TabIndex = 0
      Me.grbGeneral.TabStop = False
      Me.grbGeneral.Text = "เปลี่ยนสถานะเครื่องมือเครื่องจักร"
      '
      'lblNote
      '
      Me.lblNote.BackColor = System.Drawing.Color.Transparent
      Me.lblNote.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblNote.Location = New System.Drawing.Point(8, 40)
      Me.lblNote.Name = "lblNote"
      Me.lblNote.Size = New System.Drawing.Size(96, 18)
      Me.lblNote.TabIndex = 6
      Me.lblNote.Text = "หมายเหตุ:"
      Me.lblNote.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'chkAutorun
      '
      Me.chkAutorun.Appearance = System.Windows.Forms.Appearance.Button
      Me.chkAutorun.Image = CType(resources.GetObject("chkAutorun.Image"), System.Drawing.Image)
      Me.chkAutorun.Location = New System.Drawing.Point(224, 16)
      Me.chkAutorun.Name = "chkAutorun"
      Me.chkAutorun.Size = New System.Drawing.Size(21, 21)
      Me.chkAutorun.TabIndex = 2
      Me.chkAutorun.TabStop = False
      '
      'dtpDocDate
      '
      Me.dtpDocDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
      Me.dtpDocDate.Location = New System.Drawing.Point(376, 16)
      Me.dtpDocDate.Name = "dtpDocDate"
      Me.dtpDocDate.Size = New System.Drawing.Size(136, 21)
      Me.dtpDocDate.TabIndex = 5
      Me.dtpDocDate.TabStop = False
      '
      'lblDocDate
      '
      Me.lblDocDate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblDocDate.Location = New System.Drawing.Point(256, 16)
      Me.lblDocDate.Name = "lblDocDate"
      Me.lblDocDate.Size = New System.Drawing.Size(112, 18)
      Me.lblDocDate.TabIndex = 3
      Me.lblDocDate.Text = "วันที่เอกสาร:"
      Me.lblDocDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblCode
      '
      Me.lblCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblCode.Location = New System.Drawing.Point(8, 16)
      Me.lblCode.Name = "lblCode"
      Me.lblCode.Size = New System.Drawing.Size(96, 18)
      Me.lblCode.TabIndex = 0
      Me.lblCode.Text = "เลขที่เอกสาร:"
      Me.lblCode.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'tgItem
      '
      Me.tgItem.AllowNew = True
      Me.tgItem.AllowSorting = False
      Me.tgItem.AlternatingBackColor = System.Drawing.Color.Khaki
      Me.tgItem.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                  Or System.Windows.Forms.AnchorStyles.Left) _
                  Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.tgItem.AutoColumnResize = True
      Me.tgItem.BackColor = System.Drawing.Color.LemonChiffon
      Me.tgItem.CaptionForeColor = System.Drawing.SystemColors.Window
      Me.tgItem.CaptionVisible = False
      Me.tgItem.Cellchanged = False
      Me.tgItem.DataMember = ""
      Me.tgItem.Font = New System.Drawing.Font("Tahoma", 8.25!)
      Me.tgItem.GridLineColor = System.Drawing.Color.FromArgb(CType(CType(210, Byte), Integer), CType(CType(200, Byte), Integer), CType(CType(120, Byte), Integer))
      Me.tgItem.HeaderBackColor = System.Drawing.Color.DarkGoldenrod
      Me.tgItem.HeaderForeColor = System.Drawing.Color.White
      Me.tgItem.Location = New System.Drawing.Point(8, 189)
      Me.tgItem.Name = "tgItem"
      Me.tgItem.ParentRowsBackColor = System.Drawing.SystemColors.ControlText
      Me.tgItem.SelectionBackColor = System.Drawing.Color.Sienna
      Me.tgItem.Size = New System.Drawing.Size(736, 155)
      Me.tgItem.SortingArrowColor = System.Drawing.Color.Red
      Me.tgItem.TabIndex = 7
      Me.tgItem.TreeManager = Nothing
      '
      'EqtChangeStatusDetail
      '
      Me.Controls.Add(Me.tgItem)
      Me.Controls.Add(Me.grbGeneral)
      Me.Controls.Add(Me.ibtnBlank)
      Me.Controls.Add(Me.ibtnDelRow)
      Me.Controls.Add(Me.lblStatus)
      Me.Controls.Add(Me.grbSummary)
      Me.Controls.Add(Me.grbStore)
      Me.Controls.Add(Me.lblChangeItem)
      Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Name = "EqtChangeStatusDetail"
      Me.Size = New System.Drawing.Size(752, 408)
      Me.grbSummary.ResumeLayout(False)
      Me.grbSummary.PerformLayout()
      Me.grbStore.ResumeLayout(False)
      Me.grbStore.PerformLayout()
      CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
      Me.grbGeneral.ResumeLayout(False)
      Me.grbGeneral.PerformLayout()
      CType(Me.tgItem, System.ComponentModel.ISupportInitialize).EndInit()
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

#Region " SetLabelText "
    Public Overrides Sub SetLabelText()
      If Not m_entity Is Nothing Then Me.Text = Me.StringParserService.Parse(Me.m_entity.TabPageText)
      Me.lblCode.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.EqtDetail.lblCode}")
      Me.Validator.SetDisplayName(txtCode, lblCode.Text)

      Me.lblDocDate.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.EqtDetail.lblDocDate}")
      Me.Validator.SetDisplayName(txtDocDate, lblDocDate.Text)
      'Me.Validator.SetDisplayName(txtRentalAmt, "")

      Me.lblChangeItem.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.EqtDetail.lblChangeItem}")

      Me.lblAmount.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.EqtDetail.lblAmount}")
      Me.lblItemCount.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.EqtDetail.lblItemCount}")
      Me.Validator.SetDisplayName(txtItemCount, lblItemCount.Text)

      Me.lblItemCountUnit.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.EqtDetail.lblItemCountUnit}")

      Me.lblNote.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.EqtDetail.lblNote}")
      Me.Validator.SetDisplayName(txtNote, lblNote.Text)



      Me.lblStoreperson.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.EqtDetail.lblOwnerPerson}")
      Me.Validator.SetDisplayName(txtStorepersonCode, lblStoreperson.Text)

      Me.lblStoreCC.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.EqtDetail.lblOwnerCC}")
      Me.Validator.SetDisplayName(txtStoreCCCode, lblStoreCC.Text)



      Me.grbSummary.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.EqtDetail.grbSummary}")
      Me.grbStore.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.EqtDetail.grbChange}")
      Me.grbGeneral.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.EqtDetail.grbDocGeneral}")
    End Sub
#End Region

#Region " Members "
    Private m_entity As EquipmentToolChangeStatus

    Private m_isInitialized As Boolean = False
    Private m_treeManager As TreeManager
    Private m_tableStyleEnable As Hashtable

    Private m_oldtostatus As EqtStatus
    Private m_oldfromstatus As EqtStatus
#End Region

#Region " Style "
    Protected Function CreateTableStyle() As DataGridTableStyle
      Dim dst As New DataGridTableStyle
      dst.MappingName = "EqtStockItem"
      Dim myStringParserService As StringParserService = CType(ServiceManager.Services.GetService(GetType(StringParserService)), StringParserService)

      Dim csLineNumber As New TreeTextColumn
      csLineNumber.MappingName = "Linenumber"
      csLineNumber.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.EqtDetail.LineNumberHeaderText}")
      csLineNumber.NullText = ""
      csLineNumber.Width = 20
      csLineNumber.Alignment = HorizontalAlignment.Center
      csLineNumber.DataAlignment = HorizontalAlignment.Center
      csLineNumber.ReadOnly = True
      csLineNumber.TextBox.Name = "eqtstocki_lineNumber"

      Dim csType As DataGridComboColumn
      csType = New DataGridComboColumn("Type" _
        , CodeDescription.GetCodeList("eqtstocki_entityType" _
                                      , "code_value not in (28)") _
        , "code_description", "code_value")
      csType.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PaymentDetail.TypeHeaderText}")
      csType.Width = 40
      csType.NullText = String.Empty

      Dim csCode As New TreeTextColumn
      csCode.MappingName = "Code"
      csCode.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.EqtDetail.CodeHeaderText}")
      csCode.NullText = ""
      csCode.Width = 80
      csCode.Alignment = HorizontalAlignment.Center
      csCode.DataAlignment = HorizontalAlignment.Left
      csCode.ReadOnly = False
      csCode.TextBox.Name = "Code"

      Dim csButton As New DataGridButtonColumn
      csButton.MappingName = "Button"
      csButton.HeaderText = ""
      csButton.Width = 15
      csButton.NullText = ""
      AddHandler csButton.Click, AddressOf GridButton_Clicked

      Dim csName As New TreeTextColumn
      csName.MappingName = "Name"
      csName.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.EqtDetail.NameHeaderText}")
      csName.NullText = ""
      csName.Alignment = HorizontalAlignment.Center
      csName.DataAlignment = HorizontalAlignment.Left
      csName.Width = 150
      csName.ReadOnly = True
      csName.TextBox.Name = "Name"

      Dim csToolg As New TreeTextColumn
      csToolg.MappingName = "ToolGroup"
      csToolg.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ToolReturnDetail.GroupHeaderText}")
      csToolg.NullText = ""
      csToolg.Alignment = HorizontalAlignment.Center
      csToolg.DataAlignment = HorizontalAlignment.Left
      csToolg.Width = 150
      csToolg.ReadOnly = True
      csToolg.TextBox.Name = "ToolGroup"

      Dim csUnit As New TreeTextColumn
      csUnit.MappingName = "UnitName"
      csUnit.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.EqtDetail.UnitHeaderText}")
      csUnit.NullText = ""
      csUnit.Alignment = HorizontalAlignment.Center
      csUnit.DataAlignment = HorizontalAlignment.Left
      csUnit.Width = 50
      csUnit.ReadOnly = True
      csUnit.TextBox.Name = "UnitName"

      'Dim csUnitButton As New DataGridButtonColumn
      'csUnitButton.MappingName = "UnitButton"
      'csUnitButton.HeaderText = ""
      'csUnitButton.NullText = ""
      'AddHandler csUnitButton.Click, AddressOf UnitClicked

      Dim csQty As New TreeTextColumn
      csQty.MappingName = "Qty"
      csQty.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.EqtDetail.QtyHeaderText}")
      csQty.NullText = ""
      csQty.Alignment = HorizontalAlignment.Center
      csQty.DataAlignment = HorizontalAlignment.Right
      csQty.Format = "#,##0.00"
      csQty.Width = 40
      csQty.ReadOnly = False
      csQty.TextBox.Name = "eqtstocki_qty"
      'AddHandler csQty.TextBox.TextChanged,AddressOf 

      Dim csFromStatus As New TreeTextColumn
      csFromStatus.MappingName = "FromStatus"
      csFromStatus.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.EqtDetail.FromStatusText}")
      csFromStatus.NullText = ""
      csFromStatus.Alignment = HorizontalAlignment.Center
      csFromStatus.DataAlignment = HorizontalAlignment.Left
      csFromStatus.Width = 100
      csFromStatus.ReadOnly = True
      csFromStatus.TextBox.Name = "FromStatus"

      Dim csRentalPerDay As New TreeTextColumn
      csRentalPerDay.MappingName = "RentalPerDay"
      csRentalPerDay.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.EqtDetail.Rentalperday}")
      csRentalPerDay.NullText = ""
      csRentalPerDay.Alignment = HorizontalAlignment.Center
      csRentalPerDay.DataAlignment = HorizontalAlignment.Right
      csRentalPerDay.Format = "#,##0.00"
      csRentalPerDay.Width = 100
      csRentalPerDay.ReadOnly = False
      csRentalPerDay.TextBox.Name = "RentalPerDay"

      Dim csRentalQty As New TreeTextColumn
      csRentalQty.MappingName = "RentalQty"
      csRentalQty.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.EqtDetail.RentalQty}")
      csRentalQty.NullText = ""
      csRentalQty.Alignment = HorizontalAlignment.Center
      csRentalQty.DataAlignment = HorizontalAlignment.Right
      csRentalQty.Format = "#,##0"
      csRentalQty.Width = 40
      csRentalQty.ReadOnly = False
      csRentalQty.TextBox.Name = "RentalQty"

      Dim csAmount As New TreeTextColumn
      csAmount.MappingName = "Amount"
      csAmount.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.EqtDetail.Amount}")
      csAmount.NullText = ""
      csAmount.Alignment = HorizontalAlignment.Center
      csAmount.DataAlignment = HorizontalAlignment.Right
      csAmount.Format = "#,##0.00"
      csAmount.Width = 100
      csAmount.ReadOnly = False
      csAmount.TextBox.Name = "Amount"

      Dim csNote As New TreeTextColumn
      csNote.MappingName = "Note"
      csNote.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.EqtDetail.NoteHeaderText}")
      csNote.NullText = ""
      csNote.Alignment = HorizontalAlignment.Center
      csNote.DataAlignment = HorizontalAlignment.Left
      csNote.Width = 180
      csNote.ReadOnly = False
      csNote.TextBox.Name = "eqtstocki_note"

      ' Fill Column Style 
      dst.GridColumnStyles.Add(csLineNumber)
      dst.GridColumnStyles.Add(csType)
      dst.GridColumnStyles.Add(csCode)
      dst.GridColumnStyles.Add(csButton)
      dst.GridColumnStyles.Add(csName)
      dst.GridColumnStyles.Add(csUnit)
      dst.GridColumnStyles.Add(csQty)
      'dst.GridColumnStyles.Add(csFromStatus)
      'dst.GridColumnStyles.Add(csRentalPerDay)
      'dst.GridColumnStyles.Add(csRentalQty)
      dst.GridColumnStyles.Add(csAmount)
      dst.GridColumnStyles.Add(csNote)

      m_tableStyleEnable = New Hashtable
      For Each colStyle As DataGridColumnStyle In dst.GridColumnStyles
        m_tableStyleEnable.Add(colStyle, colStyle.ReadOnly)
      Next

      Return dst
    End Function
    Protected Sub GridButton_Clicked(ByVal e As ButtonColumnEventArgs)
      If e.Column = 3 Then
        EntityButton_Click(e)
      Else
        ' กรณีอื่น ๆ ...
      End If
    End Sub
#End Region

#Region " Constructors "
    Public Sub New()
      MyBase.New()
      Me.InitializeComponent()
      Me.SetLabelText()
      Initialize()

      Dim dt As TreeTable = EquipmentToolChangeStatus.GetSchemaTable()
      Dim dst As DataGridTableStyle = Me.CreateTableStyle()
      m_treeManager = New TreeManager(dt, tgItem)
      m_treeManager.SetTableStyle(dst)
      m_treeManager.AllowSorting = False
      m_treeManager.AllowDelete = False
      tgItem.AllowNew = False

      AddHandler dt.ColumnChanging, AddressOf ItemTreetable_ColumnChanging
      AddHandler dt.ColumnChanged, AddressOf ItemTreetable_ColumnChanged

      EventWiring()
    End Sub
#End Region


#Region "Properties"
    Private ReadOnly Property CurrentItem() As EquipmentToolChangeStatusItem
      Get
        Dim row As TreeRow = Me.m_treeManager.SelectedRow
        If row Is Nothing Then
          Return Nothing
        End If
        If Not TypeOf row.Tag Is EquipmentToolChangeStatusItem Then
          Return Nothing
        End If
        Return CType(row.Tag, EquipmentToolChangeStatusItem)
      End Get
    End Property
    
#End Region
#Region " IListDetail "
    ' Check Enable 
    Public Overrides Sub CheckFormEnable()
      If Me.m_entity Is Nothing Then
        Return
      End If

      If Me.m_entity.Canceled _
      OrElse Me.m_entity.Status.Value = 0 _
      OrElse Me.m_entity.Status.Value >= 3 Then
        For Each ctrl As Control In Me.Controls
          ctrl.Enabled = False
        Next

        tgItem.Enabled = True
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
      cmbFromStatus.Enabled = True
      cmbToStatus.Enabled = True
    End Sub
    ' Clear Detail
    Public Overrides Sub ClearDetail()
      lblStatus.Text = ""
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
      PopulateCmb(True)
      Me.dtpDocDate.Value = Date.Now
    End Sub
    ' Addhandler events
    Protected Overrides Sub EventWiring()
      AddHandler txtCode.TextChanged, AddressOf Me.ChangeProperty
      AddHandler txtNote.TextChanged, AddressOf Me.ChangeProperty

      AddHandler txtDocDate.Validated, AddressOf Me.ChangeProperty
      AddHandler dtpDocDate.ValueChanged, AddressOf Me.ChangeProperty

      
      AddHandler txtStorepersonCode.Validated, AddressOf Me.ChangeProperty
      AddHandler txtStoreCCCode.Validated, AddressOf Me.ChangeProperty



      AddHandler cmbFromStatus.SelectedIndexChanged, AddressOf Me.ChangeProperty
      AddHandler cmbToStatus.SelectedIndexChanged, AddressOf Me.ChangeProperty


    End Sub
    ' แสดงค่าข้อมูลของลูกค้าลงใน control ที่อยู่บนฟอร์ม
    Public Overrides Sub UpdateEntityProperties()
      m_isInitialized = False
      ClearDetail()
      If m_entity Is Nothing Then
        Return
      End If
      txtCode.Text = Me.m_entity.Code
      txtNote.Text = Me.m_entity.Note

      'autogencode
      m_oldCode = m_entity.Code
      Me.chkAutorun.Checked = Me.m_entity.AutoGen
      Me.UpdateAutogenStatus()

      'Combobox status
      If m_entity.FromStatus IsNot Nothing AndAlso m_entity.FromStatus.Value > 0 Then
        isautoStatus = True
        Dim item As New IdValuePair(m_entity.FromStatus.Value, m_entity.FromStatus.ToString)
        cmbFromStatus.SelectedIndex = IndexOf(cmbFromStatus, item)
        isautoStatus = False
      Else
        m_entity.FromStatus = New EqtStatus(cmbFromStatus.SelectedItem.id)
      End If

      If m_entity.ToStatus IsNot Nothing AndAlso m_entity.ToStatus.Value > 0 Then
        isautoStatus = True
        Dim item As New IdValuePair(m_entity.ToStatus.Value, m_entity.ToStatus.ToString)
        cmbToStatus.SelectedIndex = IndexOf(cmbToStatus, item)
        isautoStatus = False
      Else
        m_entity.ToStatus = New EqtStatus(cmbToStatus.SelectedItem.id)
      End If


      txtDocDate.Text = MinDateToNull(Me.m_entity.DocDate, Me.StringParserService.Parse("${res:Global.BlankDateText}"))
      dtpDocDate.Value = MinDateToNow(Me.m_entity.DocDate)



      If Not Me.m_entity.Storeperson Is Nothing Then
        txtStorepersonCode.Text = Me.m_entity.Storeperson.Code
        txtStorepersonName.Text = Me.m_entity.Storeperson.Name
      End If

      If Not Me.m_entity.StoreCostcenter Is Nothing Then
        txtStoreCCCode.Text = Me.m_entity.StoreCostcenter.Code
        txtStoreCCName.Text = Me.m_entity.StoreCostcenter.Name
      End If

      'Load Items**********************************************************
      'Me.m_treeManager.Treetable = Me.m_entity.ItemTable
      'AddHandler Me.m_entity.PropertyChanged, AddressOf PropChanged
      'Me.Validator.DataTable = m_treeManager.Treetable

      Me.m_entity.ItemCollection.Populate(m_treeManager.Treetable)
      '********************************************************************
      ReIndex()
      RefreshBlankGrid()

      SetStatus()
      SetLabelText()
      SetSummaryText()
      CheckFormEnable()

      m_isInitialized = True
    End Sub
    ' Item Propchanged
    Private Sub PropChanged(ByVal sender As Object, ByVal e As PropertyChangedEventArgs)
      If e.Name = "ItemChanged" Then
        Me.WorkbenchWindow.ViewContent.IsDirty = True
      End If
      SetSummaryText()
    End Sub
    Private m_dateSetting As Boolean = False
    Private isautoStatus As Boolean = False
    Public Sub ChangeProperty(ByVal sender As Object, ByVal e As EventArgs)
      If Me.m_entity Is Nothing Or Not m_isInitialized Then
        Return
      End If
      Dim dirtyFlag As Boolean = False
      Select Case CType(sender, Control).Name.ToLower
        Case "txtcode"
          dirtyFlag = True
          Me.m_entity.Code = txtCode.Text

        Case "txtnote"
          dirtyFlag = True
          Me.m_entity.Note = txtNote.Text

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
            Me.m_entity.DocDate = Date.Now
            Me.m_entity.DocDate = Date.MinValue
            dirtyFlag = True
          End If
          m_dateSetting = False

        Case "dtpdocdate"
          If Not Me.m_entity.DocDate.Equals(dtpDocDate.Value) Then
            If Not m_dateSetting Then
              Me.txtDocDate.Text = MinDateToNull(dtpDocDate.Value, Me.StringParserService.Parse("${res:Global.BlankDateText}"))
              Me.m_entity.DocDate = dtpDocDate.Value
            End If
            dirtyFlag = True
          End If

        Case "txtstorepersoncode"
          dirtyFlag = Employee.GetEmployee(txtStorepersonCode, txtStorepersonName, Me.m_entity.Storeperson)

        Case "txtstorecccode"
          dirtyFlag = CostCenter.GetCostCenter(txtStoreCCCode, txtStoreCCName, Me.m_entity.StoreCostcenter, CType(ServiceManager.Services.GetService(GetType(SecurityService)), SecurityService).CurrentUser.Id)
          'ReturnCheckedChanged(sender)
        Case "cmbfromstatus"
          If m_entity.ItemCollection IsNot Nothing AndAlso m_entity.ItemCollection.Count > 0 AndAlso cmbFromStatus.SelectedItem.id <> m_entity.FromStatus.Value Then
            Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
            msgServ.ShowMessage("${res:Longkong.Pojjaman.Gui.Panels.EqtDetailView.Message.CannotChangeStatus}")
            m_oldfromstatus = m_entity.FromStatus
            Dim old As New IdValuePair(m_oldfromstatus.Value, m_oldfromstatus.ToString)
            isautoStatus = True
            cmbFromStatus.SelectedIndex = IndexOf(cmbFromStatus, old)
            Return
          Else
            If Not isautoStatus Then
              dirtyFlag = True
              m_oldfromstatus = m_entity.FromStatus
              m_oldtostatus = m_entity.ToStatus
              If cmbFromStatus.SelectedItem IsNot Nothing Then
                m_entity.FromStatus = New EqtStatus(cmbFromStatus.SelectedItem.id)
              Else
                m_entity.FromStatus = New EqtStatus(cmbFromStatus.Items(0).id)
              End If
              PopolateToCmb()
              Dim old As New IdValuePair(m_oldtostatus.Value, m_oldtostatus.ToString)
              isautoStatus = True
              cmbToStatus.SelectedIndex = IndexOf(cmbToStatus, old)
            Else
              isautoStatus = False
              m_entity.FromStatus.Value = cmbFromStatus.SelectedItem.id
            End If
          End If
        Case "cmbtostatus"
          If Not isautoStatus Then
            dirtyFlag = True
            m_oldfromstatus = m_entity.FromStatus
            m_oldtostatus = m_entity.ToStatus
            If cmbToStatus.SelectedItem IsNot Nothing Then
              m_entity.ToStatus = New EqtStatus(cmbToStatus.SelectedItem.id)
            Else
              m_entity.ToStatus = New EqtStatus(cmbToStatus.Items(0).id)
            End If
            PopolateFromCmb()
            Dim old As New IdValuePair(m_oldfromstatus.Value, m_oldfromstatus.ToString)
            isautoStatus = True
            cmbFromStatus.SelectedIndex = IndexOf(cmbFromStatus, old)
          Else
            isautoStatus = False
            m_entity.ToStatus.Value = cmbToStatus.SelectedItem.id
          End If

      End Select

      Me.WorkbenchWindow.ViewContent.IsDirty = Me.WorkbenchWindow.ViewContent.IsDirty Or dirtyFlag

      SetStatus()
      SetSummaryText()
      CheckFormEnable()
    End Sub

    Public Function IndexOf(ByVal cmb As ComboBox, ByVal item As IdValuePair) As Integer
      Dim ret As Integer
      isautoStatus = True
      For Each i As Object In cmb.Items
        Dim p As IdValuePair = CType(i, IdValuePair)
        If item.Id = p.Id Then
          ret = cmb.Items.IndexOf(i)
          Return ret
        End If
      Next
      Return 0
    End Function
    Public Sub SetStatus()
      If m_entity.Canceled Then
        lblStatus.Text = "ยกเลิก: " & m_entity.CancelDate.ToShortDateString & _
        " " & m_entity.CancelDate.ToShortTimeString & _
        "  โดย:" & m_entity.CancelPerson.Name
      ElseIf m_entity.Edited Then
        lblStatus.Text = "แก้ไขล่าสุด: " & m_entity.LastEditDate.ToShortDateString & _
        " " & m_entity.LastEditDate.ToShortTimeString & _
        "  โดย:" & m_entity.LastEditor.Name
      ElseIf m_entity.Originated Then
        lblStatus.Text = "เพิ่มเข้าสู่ระบบ: " & m_entity.OriginDate.ToShortDateString & _
        " " & m_entity.OriginDate.ToShortTimeString & _
        "  โดย:" & m_entity.Originator.Name
      Else
        lblStatus.Text = "ยังไม่บันทึก"
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
        Me.m_entity = CType(Value, EquipmentToolChangeStatus)
        'Hack:
        Me.m_entity.OnTabPageTextChanged(m_entity, EventArgs.Empty)
        PopolateFromCmb()
        PopolateToCmb()
        UpdateEntityProperties()
      End Set
    End Property

    Public Overrides Sub Initialize()
      PopulateCmb()
    End Sub
    Private Sub RefreshDocs()
      Me.m_isInitialized = False
      Me.m_entity.ItemCollection.Populate(m_treeManager.Treetable)
      RefreshBlankGrid()
      ReIndex()
      Me.m_treeManager.Treetable.AcceptChanges()
      Me.UpdateAmount()
      Me.m_isInitialized = True

    End Sub
    Private Sub ReIndex()
      Dim i As Integer = 0
      For Each row As DataRow In Me.m_treeManager.Treetable.Rows
        row("Linenumber") = i + 1
        i += 1
      Next
    End Sub
#End Region

#Region "ItemTreeTable Handlers"
    Private Sub ItemTreetable_ColumnChanged(ByVal sender As Object, ByVal e As System.Data.DataColumnChangeEventArgs)
      If Not m_isInitialized OrElse e.Column.ColumnName.ToLower = "selected" Then
        Return
      End If
      Dim doc As EquipmentToolChangeStatusItem = Me.CurrentItem
      If Not doc Is Nothing Then
        doc.ItemValidateRow(e.Row)
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
      Dim doc As EquipmentToolChangeStatusItem = Me.CurrentItem
      If doc Is Nothing Then
        doc = New EquipmentToolChangeStatusItem
        Me.m_entity.ItemCollection.Add(doc)
        Me.m_treeManager.SelectedRow.Tag = doc
      End If
      Try
        Select Case e.Column.ColumnName.ToLower
          Case "code"
            If IsDBNull(e.ProposedValue) OrElse e.ProposedValue Is Nothing Then
              e.ProposedValue = ""
            End If
            doc.SetItemCode(CStr(e.ProposedValue))
          Case "type"
            doc.ItemType = New EqtItemType(CInt(e.ProposedValue))
          Case "qty"
            If IsDBNull(e.ProposedValue) Then
              e.ProposedValue = ""
            ElseIf doc.ItemType.Value = 342 Then
              e.ProposedValue = "1"
            End If
            Dim value As Integer = CInt(TextParser.Evaluate(e.ProposedValue.ToString))
            doc.Qty = value
           
          Case "amount"
            If IsDBNull(e.ProposedValue) Then
              e.ProposedValue = ""
            End If
            Dim value As Decimal = CDec(TextParser.Evaluate(e.ProposedValue.ToString))
            doc.Amount = value
          Case "Note"
            If IsDBNull(e.ProposedValue) Then
              e.ProposedValue = ""
            End If
            doc.Note = e.ProposedValue.ToString
        End Select
      Catch ex As Exception
        MessageBox.Show(ex.ToString)
      End Try
    End Sub

    Private Sub tgItem_CurrentCellChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tgItem.CurrentCellChanged
      'If tgItem.CurrentRowIndex <> currentY Then
      Me.m_entity.ItemCollection.CurrentItem = Me.CurrentItem
      'RefreshWBS()
      'currentY = tgItem.CurrentRowIndex
      'End If
    End Sub
#End Region

#Region " Event Handlers "
    Private Function GenIDListFromDataTable(ByVal entityType As Integer) As String
      Dim idlist As String = ""
      Me.m_treeManager.Treetable.AcceptChanges()
      For Each row As TreeRow In Me.m_treeManager.Treetable.Rows
        If Me.m_entity.ValidateRow(row) Then
          If entityType = row("Type") Then
            idlist &= CStr(row("eqtstocki_entity")) & ","
          End If
        End If
      Next
      Return idlist
    End Function
    Public Sub EntityButton_Click(ByVal e As ButtonColumnEventArgs)
      If Me.m_entity Is Nothing Then
        Return
      End If
      Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
      If Me.m_entity.FromCC Is Nothing OrElse Not Me.m_entity.FromCC.Originated Then
        msgServ.ShowMessage("${res:Longkong.Pojjaman.Gui.Panels.EqtDetailView.Message.InputStoreCC}")
        Return
      End If
      'ต้องเลือกสถนะทั้งสองด้านแล้วเท่านั้น
      If Me.m_entity.FromStatus Is Nothing OrElse Me.m_entity.ToStatus Is Nothing Then
        msgServ.ShowMessage("${res:Longkong.Pojjaman.Gui.Panels.EqtDetailView.Message.Status}")
        Return
      End If

      Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)

      If Me.CurrentItem Is Nothing Then
        Return
      End If
      If Me.CurrentItem.ItemType.Value = 19 Then
        Dim entities As New ArrayList
        Dim entity As New ToolForSelection
        entity.CC = Me.m_entity.FromCC
        entity.FromWip = False
        entity.EqtClass = Me.m_entity.ClassName
        entities.Add(entity)
        Dim filters(2) As Filter
        filters(0) = New Filter("IDList", GenIDListFromDataTable(19))
        filters(1) = New Filter("EntityType", Me.m_entity.EntityId)
        filters(2) = New Filter("eqtstatus", m_entity.FromStatus.Value)  'ต้องการสถานะว่าง
        myEntityPanelService.OpenListDialog(entity, AddressOf SetItems, filters, entities)
      ElseIf Me.CurrentItem.ItemType.Value = 342 Then
        Dim dlg As New BasketDialog
        AddHandler dlg.EmptyBasket, AddressOf SetItems

        Dim eqi As New EqItemForSelection

        Dim filters(2) As Filter
        filters(0) = New Filter("IDList", GenIDListFromDataTable(342))
        filters(1) = New Filter("EntityType", Me.m_entity.EntityId)
        filters(2) = New Filter("eqtstatus", m_entity.FromStatus.Value)  'ต้องการสถานะว่าง

        Dim entities As New ArrayList
        eqi.Costcenter = Me.m_entity.FromCC
        eqi.entityId = Me.m_entity.EntityId
        eqi.Status = Me.m_entity.FromStatus
        entities.Add(eqi)

        Dim view As AbstractEntityPanelViewContent = New EqiSelectionView(eqi, New BasketDialog, filters, entities)
        dlg.Lists.Add(view)
        Dim myDialog As New Longkong.Pojjaman.Gui.Dialogs.PanelDockingDialog(view, dlg)
        myDialog.ShowDialog()


       
      End If

    End Sub
    Private Sub SetItems(ByVal items As BasketItemCollection)
      Dim index As Integer = tgItem.CurrentRowIndex
      For i As Integer = items.Count - 1 To 0 Step -1
        Dim item As BasketItem = CType(items(i), BasketItem)
        Dim newItem As IEqtItem
        Dim doc As New EquipmentToolChangeStatusItem
        Dim itemType As Integer
        Dim row As DataRow
        Select Case item.FullClassName.ToLower
          Case "longkong.pojjaman.businesslogic.equipmentitem"
            newItem = New EquipmentItem(item.Id)
            itemType = 342
          Case "longkong.pojjaman.businesslogic.toolforselection"
            row = CType(item.Tag, DataRow)
            newItem = New Tool(row, "")
            itemType = 19
        End Select

        If Not itemType = 0 Then
          If Not Me.CurrentItem Is Nothing Then
            doc = Me.CurrentItem
            doc.ItemType.Value = itemType
            Me.m_treeManager.SelectedRow.Tag = Nothing
          Else
            Me.m_entity.ItemCollection.Add(doc)
            doc.ItemType = New EqtItemType(itemType)
          End If
          doc.Entity = newItem
          doc.Unit = CType(newItem, IEqtItem).Unit
          doc.ToStatus = m_entity.ToStatus
          doc.FromStatus = m_entity.FromStatus
          If itemType = 19 Then
            doc.Qty = row("tool_remaining")
          Else
            doc.Qty = 1
          End If
        End If
      Next
      tgItem.CurrentRowIndex = index
      RefreshDocs()
      RefreshBlankGrid()

    End Sub
    Private Sub ibtnBlank_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnBlank.Click
      Dim index As Integer = tgItem.CurrentRowIndex
      Dim newItem As New BlankItem("")
      Dim myItem As New EquipmentToolChangeStatusItem
      'myItem.Entity = newItem

      myItem.Unit = New Unit
      'myItem. = New CostCenter

      myItem.ToStatus = m_entity.ToStatus
      'myItem.ItemType = New EqtItemType(Me.m_entity.EntityId)
      'myItem.ItemType.value = 

      myItem.Qty = 0

      'Me.m_entity.Insert(index, myItem)
      Me.m_treeManager.Treetable.Childs.InsertAt(index)
      Me.m_treeManager.Treetable.AcceptChanges()
      tgItem.CurrentRowIndex = index
      RefreshBlankGrid()
    End Sub
    Private Sub ibtnDelRow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnDelRow.Click
      'Dim index As Integer = Me.tgItem.CurrentRowIndex
      'Me.m_treeManager.Treetable.Childs.Remove(Me.tgItem.TreeManager.Treetable.Rows(index))
      'Me.tgItem.CurrentRowIndex = index

      Dim rowsCount As Integer = 0
      Dim firstRowSelected As Integer = 0
      For Each Obj As Object In Me.m_treeManager.SelectedRows
        If Not Obj Is Nothing Then
          rowsCount += 1
          Dim row As TreeRow = CType(Obj, TreeRow)
          If Not row Is Nothing Then
            If firstRowSelected = 0 Then
              firstRowSelected = row.Index
            End If
            If TypeOf row.Tag Is EquipmentToolChangeStatusItem Then
              Dim doc As EquipmentToolChangeStatusItem = CType(row.Tag, EquipmentToolChangeStatusItem)
              If Not doc Is Nothing AndAlso Me.m_entity.ItemCollection.Contains(doc) Then
                Me.m_entity.ItemCollection.Remove(doc)
              End If
            End If
          End If
        End If
      Next

      If rowsCount.Equals(0) Then
        Dim doc As EquipmentToolChangeStatusItem = Me.m_entity.ItemCollection.CurrentItem
        If doc Is Nothing Then
          Return
        End If
        Me.m_entity.ItemCollection.Remove(doc)
      End If

      Me.RefreshDocs()
      'RefreshBlankGrid()
      Me.WorkbenchWindow.ViewContent.IsDirty = True

    End Sub
#End Region

#Region " IValidatable "
    Public ReadOnly Property FormValidator() As Components.PJMTextboxValidator Implements IValidatable.FormValidator
      Get
        Return Me.Validator
      End Get
    End Property
#End Region

#Region " Overrides "
    Public Overrides Sub NotifyBeforeSave()

    End Sub

    Public Overrides ReadOnly Property TabPageIcon() As String
      Get
        Return (New EquipmentToolChangeStatus).DetailPanelIcon
      End Get
    End Property
#End Region

#Region " Event of Button controls "


    ' Store Person
    Private Sub btnStorepersonEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnStoreCCEdit.Click
      Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      myEntityPanelService.OpenPanel(New Employee)
    End Sub
    Private Sub btnStorepersonFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnStorepersonFind.Click
      Dim myEntityPanelService As IEntityPanelService = _
       CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      myEntityPanelService.OpenListDialog(New Employee, AddressOf SetStorePersonDialog)
    End Sub
    Private Sub SetStorePersonDialog(ByVal e As ISimpleEntity)
      Me.txtStorepersonCode.Text = e.Code
      Me.WorkbenchWindow.ViewContent.IsDirty = _
          Me.WorkbenchWindow.ViewContent.IsDirty _
          Or Employee.GetEmployee(txtStorepersonCode, txtStorepersonName, Me.m_entity.Storeperson)
    End Sub
    ' Store Costcenter
    Private Sub btnStoreCCEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnStoreCCEdit.Click
      Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      myEntityPanelService.OpenPanel(New CostCenter)
    End Sub
    Private Sub btnStoreCCFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnStoreCCFind.Click
      Dim myEntityPanelService As IEntityPanelService = _
                   CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      myEntityPanelService.OpenTreeDialog(New CostCenter, AddressOf SetStoreCostCenterDialog)
    End Sub
    Private Sub SetStoreCostCenterDialog(ByVal e As ISimpleEntity)
      Me.txtStoreCCCode.Text = e.Code
      Me.WorkbenchWindow.ViewContent.IsDirty = _
          Me.WorkbenchWindow.ViewContent.IsDirty _
          Or CostCenter.GetCostCenter(txtStoreCCCode, txtStoreCCName, Me.m_entity.StoreCostcenter, CType(ServiceManager.Services.GetService(GetType(SecurityService)), SecurityService).CurrentUser.Id)
      'ReturnCheckedChanged(txtStoreCCCode)
    End Sub
#End Region

#Region " IClipboardHandler Overrides "
    Public Overrides ReadOnly Property EnablePaste() As Boolean
      Get
        ' Person
        Dim data As IDataObject = Clipboard.GetDataObject
        If data.GetDataPresent((New Employee).FullClassName) Then
          If Not Me.ActiveControl Is Nothing Then
            Select Case Me.ActiveControl.Name.ToLower
              Case "txtReturnpersoncode", "txtReturnpersonname"
                Return True
              Case "txtstorepersoncode", "txtstorepersonname"
                Return True
            End Select
          End If
        End If
        ' Cost center
        If data.GetDataPresent((New CostCenter).FullClassName) Then
          If Not Me.ActiveControl Is Nothing Then
            Select Case Me.ActiveControl.Name.ToLower
              Case "txtReturncccode", "txtReturnccname"
                Return True
              Case "txtstorecccode", "txtstoreccname"
                Return True
            End Select
          End If
        End If
        Return False
      End Get
    End Property
    Public Overrides Sub Paste(ByVal sender As Object, ByVal e As System.EventArgs)
      Dim data As IDataObject = Clipboard.GetDataObject
      ' Person
      If data.GetDataPresent((New Employee).FullClassName) Then
        Dim id As Integer = CInt(data.GetData((New Employee).FullClassName))
        Dim entity As New Employee(id)
        If Not Me.ActiveControl Is Nothing Then
          Select Case Me.ActiveControl.Name.ToLower

            Case "txtstorepersoncode", "txtstorepersonname"
              Me.SetStorePersonDialog(entity)
          End Select
        End If
      End If
      ' Cost center
      If data.GetDataPresent((New CostCenter).FullClassName) Then
        Dim id As Integer = CInt(data.GetData((New CostCenter).FullClassName))
        Dim entity As New CostCenter(id)
        If Not Me.ActiveControl Is Nothing Then
          Select Case Me.ActiveControl.Name.ToLower

            Case "txtstorecccode", "txtstoreccname"
              Me.SetStoreCostCenterDialog(entity)
          End Select
        End If
      End If
    End Sub
#End Region

#Region " Grid Resizing "
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

      Do Until Me.m_treeManager.Treetable.Rows.Count > tgItem.VisibleRowCount
        'เพิ่มแถวจนเต็ม
        Me.m_treeManager.Treetable.Childs.Add()
      Loop

      'MessageBox.Show(tgItem.VisibleRowCount.ToString & ":" & Me.m_entity.ItemTable.Childs.Count.ToString)

      If Me.m_entity.ItemCollection.Count = Me.m_treeManager.Treetable.Childs.Count Then
        'เพิ่มอีก 1 แถว ถ้ามีข้อมูลจนถึงแถวสุดท้าย
        Me.m_treeManager.Treetable.Childs.Add()
      End If
      Me.m_treeManager.Treetable.AcceptChanges()
      tgItem.CurrentRowIndex = Math.Max(0, index)
      Me.WorkbenchWindow.ViewContent.IsDirty = dirtyFlag

      SetSummaryText()
    End Sub
#End Region

#Region " Private Methods "
    Private Sub SetSummaryText()
      Dim i As Integer = 0
      For Each item As TreeRow In Me.m_treeManager.Treetable.Rows
        If Me.m_entity.ValidateRow(item) Then
          i += 1
        End If
      Next
      txtItemCount.Text = i.ToString("#,###")
    End Sub
    Private Sub UpdateAmount()
      m_isInitialized = False
      'txtRentalAmt.Text = Configuration.FormatToString(m_entity.ItemCollection.Gross, DigitConfig.Price)
      m_isInitialized = True
    End Sub

    'Private Sub ReturnCheckedChanged(ByVal sender As System.Object)
    '  If TypeOf sender Is CheckBox Then
    '    If CType(sender, CheckBox).Checked AndAlso Not txtReturnCCCode.Text = txtStoreCCCode.Text Then
    '      txtReturnCCCode.Text = txtStoreCCCode.Text
    '      txtReturnCCName.Text = txtStoreCCName.Text
    '      Me.m_entity.ReturnCostcenter = Me.m_entity.StoreCostcenter
    '    End If
    '  ElseIf TypeOf sender Is TextBox Then

    '  End If

    'End Sub
#End Region

#Region " AutoGenCode "
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
#End Region

    Private Sub PopulateCmb(Optional ByVal forcepop As Boolean = False)
      If cmbFromStatus.Items.Count = 0 OrElse cmbToStatus.Items.Count = 0 OrElse Not Me.m_entity.Originated Then
        CodeDescription.ListCodeDescriptionInComboBox(cmbFromStatus, "eqtstatus", "code_value in (2,5,6,7,8)", False)
        isautoStatus = True
        cmbFromStatus.SelectedIndex = 0
        'm_entity.FromStatus = New EqtStatus(2)
        CodeDescription.ListCodeDescriptionInComboBox(cmbToStatus, "eqtstatus", "code_value in (5,6,7,8,9)", False)
        isautoStatus = True
        cmbToStatus.SelectedIndex = 0
        'm_entity.ToStatus = New EqtStatus(5)
      End If
    End Sub
    Private Sub PopolateToCmb()
      Select Case m_entity.FromStatus.Value
        Case 2 'ว่าง
          CodeDescription.ListCodeDescriptionInComboBox(cmbToStatus, "eqtstatus", "code_value in (5,6,7,8,9)", False)
        Case 5 'รอซ่อม
          CodeDescription.ListCodeDescriptionInComboBox(cmbToStatus, "eqtstatus", "code_value in (2,6,7,8,9)", False)
        Case 6 'ส่งซ่อม
          CodeDescription.ListCodeDescriptionInComboBox(cmbToStatus, "eqtstatus", "code_value in (2,5,7,8,9)", False)
        Case 7 'ชำรุดพัง
          CodeDescription.ListCodeDescriptionInComboBox(cmbToStatus, "eqtstatus", "code_value in (2,5,6,8,9)", False)
        Case 8 'หาย
          CodeDescription.ListCodeDescriptionInComboBox(cmbToStatus, "eqtstatus", "code_value in (2,5,6,7,9)", False)
      End Select
    End Sub
    Private Sub PopolateFromCmb()
      Select Case m_entity.ToStatus.Value
        Case 2 'ว่าง
          CodeDescription.ListCodeDescriptionInComboBox(cmbFromStatus, "eqtstatus", "code_value in (5,6,7,8)", False)
        Case 5 'รอซ่อม
          CodeDescription.ListCodeDescriptionInComboBox(cmbFromStatus, "eqtstatus", "code_value in (2,6,7,8)", False)
        Case 6 'ส่งซ่อม
          CodeDescription.ListCodeDescriptionInComboBox(cmbFromStatus, "eqtstatus", "code_value in (2,5,7,8)", False)
        Case 7 'ชำรุดพัง
          CodeDescription.ListCodeDescriptionInComboBox(cmbFromStatus, "eqtstatus", "code_value in (2,5,6,8)", False)
        Case 8 'หาย
          CodeDescription.ListCodeDescriptionInComboBox(cmbFromStatus, "eqtstatus", "code_value in (2,5,6,7)", False)
        Case 9 'write off
          CodeDescription.ListCodeDescriptionInComboBox(cmbFromStatus, "eqtstatus", "code_value in (2,5,6,7,8)", False)
      End Select
    End Sub

  End Class
End Namespace

