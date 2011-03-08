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
  Public Class EqtWithdrawDetail
    Inherits AbstractEntityDetailPanelView
    Implements IValidatable

#Region " Windows Form Designer generated code "
    Friend WithEvents grbSummary As Longkong.Pojjaman.Gui.Components.FixedGroupBox
    Friend WithEvents lblItem As System.Windows.Forms.Label
    Friend WithEvents grbReceive As Longkong.Pojjaman.Gui.Components.FixedGroupBox
    Friend WithEvents ImageButton3 As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents ImageButton4 As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents Validator As Longkong.Pojjaman.Gui.Components.PJMTextboxValidator
    Friend WithEvents lblRequestPerson As System.Windows.Forms.Label
    Friend WithEvents grbRequest As Longkong.Pojjaman.Gui.Components.FixedGroupBox
    Friend WithEvents txtWithdrawPersonName As System.Windows.Forms.TextBox
    Friend WithEvents txtWithdrawPersonCode As System.Windows.Forms.TextBox
    Friend WithEvents txtStorepersonName As System.Windows.Forms.TextBox
    Friend WithEvents txtStoreCCName As System.Windows.Forms.TextBox
    Friend WithEvents txtStoreCCCode As System.Windows.Forms.TextBox
    Friend WithEvents lblStoreperson As System.Windows.Forms.Label
    Friend WithEvents lblStoreCC As System.Windows.Forms.Label
    Friend WithEvents txtStorepersonCode As System.Windows.Forms.TextBox
    Friend WithEvents txtWithdrawCCName As System.Windows.Forms.TextBox
    Friend WithEvents lblWithdrawCC As System.Windows.Forms.Label
    Friend WithEvents txtWithdrawCCCode As System.Windows.Forms.TextBox
    Friend WithEvents btnStoreCCFind As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents btnStorepersonFind As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents btnStoreCCEdit As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents btnStorepersonEdit As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents btnWithdrawCCFind As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents btnWithdrawPersonFind As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents btnWithdrawCCEdit As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents btnWithdrawPersonEdit As Longkong.Pojjaman.Gui.Components.ImageButton
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
    Friend WithEvents txtItemCount As System.Windows.Forms.TextBox
    Friend WithEvents lblItemCount As System.Windows.Forms.Label
    Friend WithEvents lblItemCountUnit As System.Windows.Forms.Label
    Friend WithEvents ibtnShowPR As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents tgItem As Longkong.Pojjaman.Gui.Components.TreeGrid
    Private Sub InitializeComponent()
      Me.components = New System.ComponentModel.Container()
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(EqtWithdrawDetail))
      Me.lblItem = New System.Windows.Forms.Label()
      Me.grbSummary = New Longkong.Pojjaman.Gui.Components.FixedGroupBox()
      Me.txtItemCount = New System.Windows.Forms.TextBox()
      Me.lblItemCount = New System.Windows.Forms.Label()
      Me.lblItemCountUnit = New System.Windows.Forms.Label()
      Me.grbReceive = New Longkong.Pojjaman.Gui.Components.FixedGroupBox()
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
      Me.grbRequest = New Longkong.Pojjaman.Gui.Components.FixedGroupBox()
      Me.btnWithdrawCCFind = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.btnWithdrawPersonFind = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.btnWithdrawCCEdit = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.btnWithdrawPersonEdit = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.ImageButton3 = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.ImageButton4 = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.txtWithdrawCCName = New System.Windows.Forms.TextBox()
      Me.txtWithdrawPersonName = New System.Windows.Forms.TextBox()
      Me.txtWithdrawPersonCode = New System.Windows.Forms.TextBox()
      Me.lblRequestPerson = New System.Windows.Forms.Label()
      Me.lblWithdrawCC = New System.Windows.Forms.Label()
      Me.txtWithdrawCCCode = New System.Windows.Forms.TextBox()
      Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
      Me.txtDocDate = New System.Windows.Forms.TextBox()
      Me.txtCode = New System.Windows.Forms.TextBox()
      Me.Validator = New Longkong.Pojjaman.Gui.Components.PJMTextboxValidator(Me.components)
      Me.txtNote = New System.Windows.Forms.TextBox()
      Me.ibtnBlank = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.ibtnDelRow = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.grbGeneral = New Longkong.Pojjaman.Gui.Components.FixedGroupBox()
      Me.lblNote = New System.Windows.Forms.Label()
      Me.chkAutorun = New System.Windows.Forms.CheckBox()
      Me.dtpDocDate = New System.Windows.Forms.DateTimePicker()
      Me.lblDocDate = New System.Windows.Forms.Label()
      Me.lblCode = New System.Windows.Forms.Label()
      Me.tgItem = New Longkong.Pojjaman.Gui.Components.TreeGrid()
      Me.ibtnShowPR = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.grbSummary.SuspendLayout()
      Me.grbReceive.SuspendLayout()
      Me.grbRequest.SuspendLayout()
      CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.grbGeneral.SuspendLayout()
      CType(Me.tgItem, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.SuspendLayout()
      '
      'lblItem
      '
      Me.lblItem.AutoSize = True
      Me.lblItem.BackColor = System.Drawing.Color.Transparent
      Me.lblItem.Cursor = System.Windows.Forms.Cursors.Default
      Me.lblItem.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblItem.Location = New System.Drawing.Point(16, 152)
      Me.lblItem.Name = "lblItem"
      Me.lblItem.Size = New System.Drawing.Size(81, 16)
      Me.lblItem.TabIndex = 3
      Me.lblItem.Text = "รายการเบิก:"
      Me.lblItem.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      '
      'grbSummary
      '
      Me.grbSummary.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.grbSummary.Controls.Add(Me.txtItemCount)
      Me.grbSummary.Controls.Add(Me.lblItemCount)
      Me.grbSummary.Controls.Add(Me.lblItemCountUnit)
      Me.grbSummary.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.grbSummary.Location = New System.Drawing.Point(514, 360)
      Me.grbSummary.Name = "grbSummary"
      Me.grbSummary.Size = New System.Drawing.Size(250, 45)
      Me.grbSummary.TabIndex = 8
      Me.grbSummary.TabStop = False
      Me.grbSummary.Text = "สรุปยอดเบิก"
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
      Me.txtItemCount.Location = New System.Drawing.Point(120, 15)
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
      Me.lblItemCount.Location = New System.Drawing.Point(8, 15)
      Me.lblItemCount.Name = "lblItemCount"
      Me.lblItemCount.Size = New System.Drawing.Size(104, 18)
      Me.lblItemCount.TabIndex = 0
      Me.lblItemCount.Text = "จำนวนรายการเบิก"
      Me.lblItemCount.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblItemCountUnit
      '
      Me.lblItemCountUnit.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblItemCountUnit.Location = New System.Drawing.Point(192, 15)
      Me.lblItemCountUnit.Name = "lblItemCountUnit"
      Me.lblItemCountUnit.Size = New System.Drawing.Size(40, 18)
      Me.lblItemCountUnit.TabIndex = 2
      Me.lblItemCountUnit.Text = "รายการ"
      Me.lblItemCountUnit.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'grbReceive
      '
      Me.grbReceive.Controls.Add(Me.btnStoreCCFind)
      Me.grbReceive.Controls.Add(Me.btnStorepersonFind)
      Me.grbReceive.Controls.Add(Me.btnStoreCCEdit)
      Me.grbReceive.Controls.Add(Me.btnStorepersonEdit)
      Me.grbReceive.Controls.Add(Me.txtStorepersonName)
      Me.grbReceive.Controls.Add(Me.txtStoreCCName)
      Me.grbReceive.Controls.Add(Me.txtStoreCCCode)
      Me.grbReceive.Controls.Add(Me.lblStoreperson)
      Me.grbReceive.Controls.Add(Me.lblStoreCC)
      Me.grbReceive.Controls.Add(Me.txtStorepersonCode)
      Me.grbReceive.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.grbReceive.Location = New System.Drawing.Point(8, 74)
      Me.grbReceive.Name = "grbReceive"
      Me.grbReceive.Size = New System.Drawing.Size(370, 72)
      Me.grbReceive.TabIndex = 1
      Me.grbReceive.TabStop = False
      Me.grbReceive.Text = "ผู้ให้เบิก"
      '
      'btnStoreCCFind
      '
      Me.btnStoreCCFind.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnStoreCCFind.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.btnStoreCCFind.ForeColor = System.Drawing.SystemColors.Control
      Me.btnStoreCCFind.Location = New System.Drawing.Point(316, 16)
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
      Me.btnStorepersonFind.Location = New System.Drawing.Point(316, 40)
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
      Me.btnStoreCCEdit.Location = New System.Drawing.Point(340, 16)
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
      Me.btnStorepersonEdit.Location = New System.Drawing.Point(340, 40)
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
      Me.txtStorepersonName.Location = New System.Drawing.Point(191, 40)
      Me.Validator.SetMinValue(Me.txtStorepersonName, "")
      Me.txtStorepersonName.Name = "txtStorepersonName"
      Me.txtStorepersonName.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtStorepersonName, "")
      Me.Validator.SetRequired(Me.txtStorepersonName, False)
      Me.txtStorepersonName.Size = New System.Drawing.Size(127, 21)
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
      Me.txtStoreCCName.Location = New System.Drawing.Point(191, 16)
      Me.Validator.SetMinValue(Me.txtStoreCCName, "")
      Me.txtStoreCCName.Name = "txtStoreCCName"
      Me.txtStoreCCName.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtStoreCCName, "")
      Me.Validator.SetRequired(Me.txtStoreCCName, False)
      Me.txtStoreCCName.Size = New System.Drawing.Size(127, 21)
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
      Me.txtStoreCCCode.Location = New System.Drawing.Point(104, 16)
      Me.txtStoreCCCode.MaxLength = 20
      Me.Validator.SetMinValue(Me.txtStoreCCCode, "")
      Me.txtStoreCCCode.Name = "txtStoreCCCode"
      Me.Validator.SetRegularExpression(Me.txtStoreCCCode, "")
      Me.Validator.SetRequired(Me.txtStoreCCCode, False)
      Me.txtStoreCCCode.Size = New System.Drawing.Size(88, 21)
      Me.txtStoreCCCode.TabIndex = 1
      '
      'lblStoreperson
      '
      Me.lblStoreperson.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblStoreperson.Location = New System.Drawing.Point(8, 40)
      Me.lblStoreperson.Name = "lblStoreperson"
      Me.lblStoreperson.Size = New System.Drawing.Size(96, 18)
      Me.lblStoreperson.TabIndex = 5
      Me.lblStoreperson.Text = "ผู้ให้เบิก:"
      Me.lblStoreperson.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblStoreCC
      '
      Me.lblStoreCC.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblStoreCC.Location = New System.Drawing.Point(8, 16)
      Me.lblStoreCC.Name = "lblStoreCC"
      Me.lblStoreCC.Size = New System.Drawing.Size(96, 18)
      Me.lblStoreCC.TabIndex = 0
      Me.lblStoreCC.Text = "จาก Cost Center:"
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
      Me.txtStorepersonCode.Location = New System.Drawing.Point(104, 40)
      Me.txtStorepersonCode.MaxLength = 20
      Me.Validator.SetMinValue(Me.txtStorepersonCode, "")
      Me.txtStorepersonCode.Name = "txtStorepersonCode"
      Me.Validator.SetRegularExpression(Me.txtStorepersonCode, "")
      Me.Validator.SetRequired(Me.txtStorepersonCode, False)
      Me.txtStorepersonCode.Size = New System.Drawing.Size(88, 21)
      Me.txtStorepersonCode.TabIndex = 2
      '
      'grbRequest
      '
      Me.grbRequest.Controls.Add(Me.btnWithdrawCCFind)
      Me.grbRequest.Controls.Add(Me.btnWithdrawPersonFind)
      Me.grbRequest.Controls.Add(Me.btnWithdrawCCEdit)
      Me.grbRequest.Controls.Add(Me.btnWithdrawPersonEdit)
      Me.grbRequest.Controls.Add(Me.ImageButton3)
      Me.grbRequest.Controls.Add(Me.ImageButton4)
      Me.grbRequest.Controls.Add(Me.txtWithdrawCCName)
      Me.grbRequest.Controls.Add(Me.txtWithdrawPersonName)
      Me.grbRequest.Controls.Add(Me.txtWithdrawPersonCode)
      Me.grbRequest.Controls.Add(Me.lblRequestPerson)
      Me.grbRequest.Controls.Add(Me.lblWithdrawCC)
      Me.grbRequest.Controls.Add(Me.txtWithdrawCCCode)
      Me.grbRequest.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.grbRequest.Location = New System.Drawing.Point(384, 74)
      Me.grbRequest.Name = "grbRequest"
      Me.grbRequest.Size = New System.Drawing.Size(380, 72)
      Me.grbRequest.TabIndex = 2
      Me.grbRequest.TabStop = False
      Me.grbRequest.Text = "ผู้ขอเบิก"
      '
      'btnWithdrawCCFind
      '
      Me.btnWithdrawCCFind.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnWithdrawCCFind.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.btnWithdrawCCFind.ForeColor = System.Drawing.SystemColors.Control
      Me.btnWithdrawCCFind.Location = New System.Drawing.Point(312, 18)
      Me.btnWithdrawCCFind.Name = "btnWithdrawCCFind"
      Me.btnWithdrawCCFind.Size = New System.Drawing.Size(34, 23)
      Me.btnWithdrawCCFind.TabIndex = 3
      Me.btnWithdrawCCFind.TabStop = False
      Me.btnWithdrawCCFind.ThemedImage = CType(resources.GetObject("btnWithdrawCCFind.ThemedImage"), System.Drawing.Bitmap)
      '
      'btnWithdrawPersonFind
      '
      Me.btnWithdrawPersonFind.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnWithdrawPersonFind.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.btnWithdrawPersonFind.ForeColor = System.Drawing.SystemColors.Control
      Me.btnWithdrawPersonFind.Location = New System.Drawing.Point(312, 42)
      Me.btnWithdrawPersonFind.Name = "btnWithdrawPersonFind"
      Me.btnWithdrawPersonFind.Size = New System.Drawing.Size(34, 23)
      Me.btnWithdrawPersonFind.TabIndex = 8
      Me.btnWithdrawPersonFind.TabStop = False
      Me.btnWithdrawPersonFind.ThemedImage = CType(resources.GetObject("btnWithdrawPersonFind.ThemedImage"), System.Drawing.Bitmap)
      '
      'btnWithdrawCCEdit
      '
      Me.btnWithdrawCCEdit.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnWithdrawCCEdit.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.btnWithdrawCCEdit.Location = New System.Drawing.Point(336, 18)
      Me.btnWithdrawCCEdit.Name = "btnWithdrawCCEdit"
      Me.btnWithdrawCCEdit.Size = New System.Drawing.Size(34, 23)
      Me.btnWithdrawCCEdit.TabIndex = 4
      Me.btnWithdrawCCEdit.TabStop = False
      Me.btnWithdrawCCEdit.ThemedImage = CType(resources.GetObject("btnWithdrawCCEdit.ThemedImage"), System.Drawing.Bitmap)
      '
      'btnWithdrawPersonEdit
      '
      Me.btnWithdrawPersonEdit.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnWithdrawPersonEdit.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.btnWithdrawPersonEdit.Location = New System.Drawing.Point(336, 42)
      Me.btnWithdrawPersonEdit.Name = "btnWithdrawPersonEdit"
      Me.btnWithdrawPersonEdit.Size = New System.Drawing.Size(34, 23)
      Me.btnWithdrawPersonEdit.TabIndex = 9
      Me.btnWithdrawPersonEdit.TabStop = False
      Me.btnWithdrawPersonEdit.ThemedImage = CType(resources.GetObject("btnWithdrawPersonEdit.ThemedImage"), System.Drawing.Bitmap)
      '
      'ImageButton3
      '
      Me.ImageButton3.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.ImageButton3.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.ImageButton3.ForeColor = System.Drawing.SystemColors.Control
      Me.ImageButton3.Location = New System.Drawing.Point(524, 144)
      Me.ImageButton3.Name = "ImageButton3"
      Me.ImageButton3.Size = New System.Drawing.Size(24, 23)
      Me.ImageButton3.TabIndex = 256
      Me.ImageButton3.TabStop = False
      Me.ImageButton3.ThemedImage = CType(resources.GetObject("ImageButton3.ThemedImage"), System.Drawing.Bitmap)
      '
      'ImageButton4
      '
      Me.ImageButton4.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.ImageButton4.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.ImageButton4.ForeColor = System.Drawing.SystemColors.Control
      Me.ImageButton4.Location = New System.Drawing.Point(524, 120)
      Me.ImageButton4.Name = "ImageButton4"
      Me.ImageButton4.Size = New System.Drawing.Size(24, 23)
      Me.ImageButton4.TabIndex = 1
      Me.ImageButton4.TabStop = False
      Me.ImageButton4.ThemedImage = CType(resources.GetObject("ImageButton4.ThemedImage"), System.Drawing.Bitmap)
      '
      'txtWithdrawCCName
      '
      Me.txtWithdrawCCName.BackColor = System.Drawing.SystemColors.Control
      Me.Validator.SetDataType(Me.txtWithdrawCCName, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtWithdrawCCName, "")
      Me.Validator.SetGotFocusBackColor(Me.txtWithdrawCCName, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtWithdrawCCName, System.Drawing.Color.Empty)
      Me.txtWithdrawCCName.Location = New System.Drawing.Point(193, 18)
      Me.Validator.SetMinValue(Me.txtWithdrawCCName, "")
      Me.txtWithdrawCCName.Name = "txtWithdrawCCName"
      Me.txtWithdrawCCName.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtWithdrawCCName, "")
      Me.Validator.SetRequired(Me.txtWithdrawCCName, False)
      Me.txtWithdrawCCName.Size = New System.Drawing.Size(133, 21)
      Me.txtWithdrawCCName.TabIndex = 2
      Me.txtWithdrawCCName.TabStop = False
      '
      'txtWithdrawPersonName
      '
      Me.txtWithdrawPersonName.BackColor = System.Drawing.SystemColors.Control
      Me.Validator.SetDataType(Me.txtWithdrawPersonName, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtWithdrawPersonName, "")
      Me.Validator.SetGotFocusBackColor(Me.txtWithdrawPersonName, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtWithdrawPersonName, System.Drawing.Color.Empty)
      Me.txtWithdrawPersonName.Location = New System.Drawing.Point(193, 42)
      Me.Validator.SetMinValue(Me.txtWithdrawPersonName, "")
      Me.txtWithdrawPersonName.Name = "txtWithdrawPersonName"
      Me.txtWithdrawPersonName.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtWithdrawPersonName, "")
      Me.Validator.SetRequired(Me.txtWithdrawPersonName, False)
      Me.txtWithdrawPersonName.Size = New System.Drawing.Size(133, 21)
      Me.txtWithdrawPersonName.TabIndex = 7
      Me.txtWithdrawPersonName.TabStop = False
      '
      'txtWithdrawPersonCode
      '
      Me.txtWithdrawPersonCode.BackColor = System.Drawing.SystemColors.Window
      Me.Validator.SetDataType(Me.txtWithdrawPersonCode, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtWithdrawPersonCode, "")
      Me.Validator.SetGotFocusBackColor(Me.txtWithdrawPersonCode, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtWithdrawPersonCode, -15)
      Me.Validator.SetInvalidBackColor(Me.txtWithdrawPersonCode, System.Drawing.Color.Empty)
      Me.txtWithdrawPersonCode.Location = New System.Drawing.Point(116, 42)
      Me.txtWithdrawPersonCode.MaxLength = 20
      Me.Validator.SetMinValue(Me.txtWithdrawPersonCode, "")
      Me.txtWithdrawPersonCode.Name = "txtWithdrawPersonCode"
      Me.Validator.SetRegularExpression(Me.txtWithdrawPersonCode, "")
      Me.Validator.SetRequired(Me.txtWithdrawPersonCode, True)
      Me.txtWithdrawPersonCode.Size = New System.Drawing.Size(88, 21)
      Me.txtWithdrawPersonCode.TabIndex = 2
      '
      'lblRequestPerson
      '
      Me.lblRequestPerson.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblRequestPerson.Location = New System.Drawing.Point(19, 42)
      Me.lblRequestPerson.Name = "lblRequestPerson"
      Me.lblRequestPerson.Size = New System.Drawing.Size(96, 18)
      Me.lblRequestPerson.TabIndex = 5
      Me.lblRequestPerson.Text = "ผู้เบิก:"
      Me.lblRequestPerson.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblWithdrawCC
      '
      Me.lblWithdrawCC.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblWithdrawCC.Location = New System.Drawing.Point(6, 16)
      Me.lblWithdrawCC.Name = "lblWithdrawCC"
      Me.lblWithdrawCC.Size = New System.Drawing.Size(109, 22)
      Me.lblWithdrawCC.TabIndex = 0
      Me.lblWithdrawCC.Text = "เข้า Cost Center:"
      Me.lblWithdrawCC.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'txtWithdrawCCCode
      '
      Me.txtWithdrawCCCode.BackColor = System.Drawing.SystemColors.Window
      Me.Validator.SetDataType(Me.txtWithdrawCCCode, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtWithdrawCCCode, "")
      Me.Validator.SetGotFocusBackColor(Me.txtWithdrawCCCode, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtWithdrawCCCode, -15)
      Me.Validator.SetInvalidBackColor(Me.txtWithdrawCCCode, System.Drawing.Color.Empty)
      Me.txtWithdrawCCCode.Location = New System.Drawing.Point(116, 18)
      Me.txtWithdrawCCCode.MaxLength = 20
      Me.Validator.SetMinValue(Me.txtWithdrawCCCode, "")
      Me.txtWithdrawCCCode.Name = "txtWithdrawCCCode"
      Me.Validator.SetRegularExpression(Me.txtWithdrawCCCode, "")
      Me.Validator.SetRequired(Me.txtWithdrawCCCode, False)
      Me.txtWithdrawCCCode.Size = New System.Drawing.Size(88, 21)
      Me.txtWithdrawCCCode.TabIndex = 1
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
      Me.txtDocDate.Location = New System.Drawing.Point(368, 16)
      Me.Validator.SetMinValue(Me.txtDocDate, "")
      Me.txtDocDate.Name = "txtDocDate"
      Me.Validator.SetRegularExpression(Me.txtDocDate, "")
      Me.Validator.SetRequired(Me.txtDocDate, True)
      Me.txtDocDate.Size = New System.Drawing.Size(82, 21)
      Me.txtDocDate.TabIndex = 2
      '
      'txtCode
      '
      Me.Validator.SetDataType(Me.txtCode, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtCode, "")
      Me.Validator.SetGotFocusBackColor(Me.txtCode, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtCode, -15)
      Me.Validator.SetInvalidBackColor(Me.txtCode, System.Drawing.Color.Empty)
      Me.txtCode.Location = New System.Drawing.Point(104, 16)
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
      Me.txtNote.Location = New System.Drawing.Point(104, 40)
      Me.txtNote.MaxLength = 255
      Me.Validator.SetMinValue(Me.txtNote, "")
      Me.txtNote.Name = "txtNote"
      Me.Validator.SetRegularExpression(Me.txtNote, "")
      Me.Validator.SetRequired(Me.txtNote, False)
      Me.txtNote.Size = New System.Drawing.Size(552, 21)
      Me.txtNote.TabIndex = 3
      '
      'ibtnBlank
      '
      Me.ibtnBlank.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.ibtnBlank.Location = New System.Drawing.Point(158, 147)
      Me.ibtnBlank.Name = "ibtnBlank"
      Me.ibtnBlank.Size = New System.Drawing.Size(24, 24)
      Me.ibtnBlank.TabIndex = 4
      Me.ibtnBlank.TabStop = False
      Me.ibtnBlank.ThemedImage = CType(resources.GetObject("ibtnBlank.ThemedImage"), System.Drawing.Bitmap)
      Me.ibtnBlank.Visible = False
      '
      'ibtnDelRow
      '
      Me.ibtnDelRow.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.ibtnDelRow.Location = New System.Drawing.Point(183, 147)
      Me.ibtnDelRow.Name = "ibtnDelRow"
      Me.ibtnDelRow.Size = New System.Drawing.Size(24, 24)
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
      Me.grbGeneral.Location = New System.Drawing.Point(8, 2)
      Me.grbGeneral.Name = "grbGeneral"
      Me.grbGeneral.Size = New System.Drawing.Size(756, 72)
      Me.grbGeneral.TabIndex = 0
      Me.grbGeneral.TabStop = False
      Me.grbGeneral.Text = "ผู้ให้เบิก"
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
      Me.chkAutorun.Location = New System.Drawing.Point(216, 16)
      Me.chkAutorun.Name = "chkAutorun"
      Me.chkAutorun.Size = New System.Drawing.Size(21, 21)
      Me.chkAutorun.TabIndex = 2
      Me.chkAutorun.TabStop = False
      '
      'dtpDocDate
      '
      Me.dtpDocDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
      Me.dtpDocDate.Location = New System.Drawing.Point(368, 16)
      Me.dtpDocDate.Name = "dtpDocDate"
      Me.dtpDocDate.Size = New System.Drawing.Size(103, 21)
      Me.dtpDocDate.TabIndex = 5
      Me.dtpDocDate.TabStop = False
      '
      'lblDocDate
      '
      Me.lblDocDate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblDocDate.Location = New System.Drawing.Point(248, 16)
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
      Me.tgItem.GridLineColor = System.Drawing.Color.FromArgb(CType(CType(210, Byte), Integer), CType(CType(200, Byte), Integer), CType(CType(120, Byte), Integer))
      Me.tgItem.HeaderBackColor = System.Drawing.Color.DarkGoldenrod
      Me.tgItem.HeaderForeColor = System.Drawing.Color.White
      Me.tgItem.Location = New System.Drawing.Point(8, 173)
      Me.tgItem.Name = "tgItem"
      Me.tgItem.ParentRowsBackColor = System.Drawing.SystemColors.ControlText
      Me.tgItem.SelectionBackColor = System.Drawing.Color.Sienna
      Me.tgItem.Size = New System.Drawing.Size(756, 184)
      Me.tgItem.SortingArrowColor = System.Drawing.Color.Red
      Me.tgItem.TabIndex = 7
      Me.tgItem.TreeManager = Nothing
      '
      'ibtnShowPR
      '
      Me.ibtnShowPR.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.ibtnShowPR.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
      Me.ibtnShowPR.Location = New System.Drawing.Point(112, 147)
      Me.ibtnShowPR.Name = "ibtnShowPR"
      Me.ibtnShowPR.Size = New System.Drawing.Size(40, 24)
      Me.ibtnShowPR.TabIndex = 44
      Me.ibtnShowPR.TabStop = False
      Me.ibtnShowPR.Text = "PR"
      Me.ibtnShowPR.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      Me.ibtnShowPR.ThemedImage = CType(resources.GetObject("ibtnShowPR.ThemedImage"), System.Drawing.Bitmap)
      Me.ibtnShowPR.Visible = False
      '
      'EqtWithdrawDetail
      '
      Me.Controls.Add(Me.ibtnShowPR)
      Me.Controls.Add(Me.tgItem)
      Me.Controls.Add(Me.grbGeneral)
      Me.Controls.Add(Me.ibtnBlank)
      Me.Controls.Add(Me.ibtnDelRow)
      Me.Controls.Add(Me.grbSummary)
      Me.Controls.Add(Me.grbReceive)
      Me.Controls.Add(Me.grbRequest)
      Me.Controls.Add(Me.lblItem)
      Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Name = "EqtWithdrawDetail"
      Me.Size = New System.Drawing.Size(772, 408)
      Me.grbSummary.ResumeLayout(False)
      Me.grbSummary.PerformLayout()
      Me.grbReceive.ResumeLayout(False)
      Me.grbReceive.PerformLayout()
      Me.grbRequest.ResumeLayout(False)
      Me.grbRequest.PerformLayout()
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
      Me.lblCode.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ToolWithdrawDetail.lblCode}")
      Me.Validator.SetDisplayName(txtCode, lblCode.Text)

      Me.lblDocDate.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ToolWithdrawDetail.lblDocDate}")
      Me.Validator.SetDisplayName(txtDocDate, lblDocDate.Text)

      Me.lblItem.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ToolWithdrawDetail.lblItem}")

      Me.lblItemCount.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ToolWithdrawDetail.lblItemCount}")
      Me.Validator.SetDisplayName(txtItemCount, lblItemCount.Text)

      Me.lblItemCountUnit.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ToolWithdrawDetail.lblItemCountUnit}")

      Me.lblNote.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ToolWithdrawDetail.lblNote}")
      Me.Validator.SetDisplayName(txtNote, lblNote.Text)

      Me.lblRequestPerson.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ToolWithdrawDetail.lblRequestPerson}")
      Me.Validator.SetDisplayName(txtWithdrawPersonCode, lblRequestPerson.Text)

      Me.lblStoreperson.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ToolWithdrawDetail.lblStoreperson}")
      Me.Validator.SetDisplayName(txtStorepersonCode, lblStoreperson.Text)

      Me.lblStoreCC.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ToolWithdrawDetail.lblStoreCC}")
      Me.Validator.SetDisplayName(txtStoreCCCode, lblStoreCC.Text)

      Me.lblWithdrawCC.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ToolWithdrawDetail.lblWithdrawCC}")
      Me.Validator.SetDisplayName(txtWithdrawCCCode, lblWithdrawCC.Text)

      Me.grbSummary.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ToolWithdrawDetail.grbSummary}")
      Me.grbReceive.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ToolWithdrawDetail.grbReceive}")
      Me.grbRequest.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ToolWithdrawDetail.grbRequest}")
      Me.grbGeneral.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ToolWithdrawDetail.grbGeneral}")
    End Sub
#End Region

#Region " Members "
    Private m_entity As EquipmentToolWithdraw

    Private m_isInitialized As Boolean = False
    Private m_treeManager As TreeManager
    Private m_tableStyleEnable As Hashtable
#End Region

#Region " Style "
    Protected Function CreateTableStyle() As DataGridTableStyle
      Dim dst As New DataGridTableStyle
      dst.MappingName = "EqtStockItem"
      Dim myStringParserService As StringParserService = CType(ServiceManager.Services.GetService(GetType(StringParserService)), StringParserService)

      Dim csLineNumber As New TreeTextColumn
      csLineNumber.MappingName = "Linenumber"
      csLineNumber.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ToolWithdrawDetail.LineNumberHeaderText}")
      csLineNumber.NullText = ""
      csLineNumber.Width = 20
      csLineNumber.Alignment = HorizontalAlignment.Center
      csLineNumber.DataAlignment = HorizontalAlignment.Center
      csLineNumber.ReadOnly = True
      csLineNumber.TextBox.Name = "eqtstocki_lineNumber"

      Dim csType As DataGridComboColumn
      'เอาเครื่องจักรออกก่อน ลดความซ้ำซ้อน
      'csType = New DataGridComboColumn("Type" _
      '  , CodeDescription.GetCodeList("eqtstocki_entityType" _
      '                                , "code_value not in (28,348)") _
      '  , "code_description", "code_value")
      csType = New DataGridComboColumn("Type" _
       , CodeDescription.GetCodeList("eqtstocki_entityType" _
                                     , "code_value not in (28,348,346)") _
       , "code_description", "code_value")
      csType.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PaymentDetail.TypeHeaderText}")
      csType.Width = 40
      csType.NullText = String.Empty

      Dim csCode As New TreeTextColumn
      csCode.MappingName = "Code"
      csCode.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ToolWithdrawDetail.CodeHeaderText}")
      csCode.NullText = ""
      csCode.Width = 80
      csCode.Alignment = HorizontalAlignment.Center
      csCode.DataAlignment = HorizontalAlignment.Left
      csCode.ReadOnly = False
      csCode.TextBox.Name = "Code"

      Dim csButton As New DataGridButtonColumn
      csButton.MappingName = "Button"
      csButton.HeaderText = ""
      csButton.NullText = ""
      AddHandler csButton.Click, AddressOf GridButton_Clicked

      Dim csName As New TreeTextColumn
      csName.MappingName = "Name"
      csName.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ToolWithdrawDetail.NameHeaderText}")
      csName.NullText = ""
      csName.Alignment = HorizontalAlignment.Center
      csName.DataAlignment = HorizontalAlignment.Left
      csName.Width = 150
      csName.ReadOnly = True
      csName.TextBox.Name = "Name"

      Dim csToolg As New TreeTextColumn
      csToolg.MappingName = "ToolGroup"
      csToolg.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ToolWithdrawDetail.GroupHeaderText}")
      csToolg.NullText = ""
      csToolg.Alignment = HorizontalAlignment.Center
      csToolg.DataAlignment = HorizontalAlignment.Left
      csToolg.Width = 150
      csToolg.ReadOnly = True
      csToolg.TextBox.Name = "ToolGroup"

      Dim csUnit As New TreeTextColumn
      csUnit.MappingName = "UnitName"
      csUnit.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ToolWithdrawDetail.UnitHeaderText}")
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
      Dim csRentalRate As New TreeTextColumn
      csRentalRate.MappingName = "RentalRate"
      csRentalRate.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ToolWithdrawDetail.RentalRate}")
      csRentalRate.NullText = ""
      csRentalRate.Alignment = HorizontalAlignment.Center
      csRentalRate.DataAlignment = HorizontalAlignment.Right
      csRentalRate.Format = "#,##0.00"
      csRentalRate.Width = 100
      csRentalRate.ReadOnly = True
      csRentalRate.TextBox.Name = "RentalRate"

      Dim csQty As New TreeTextColumn
      csQty.MappingName = "Qty"
      csQty.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ToolWithdrawDetail.QtyHeaderText}")
      csQty.NullText = ""
      csQty.Alignment = HorizontalAlignment.Center
      csQty.DataAlignment = HorizontalAlignment.Right
      csQty.Format = "#,##0.00"
      csQty.Width = 60
      csQty.ReadOnly = False
      csQty.TextBox.Name = "eqtstocki_qty"
      'AddHandler csQty.TextBox.TextChanged,AddressOf 

      Dim csRentalPerDay As New TreeTextColumn
      csRentalPerDay.MappingName = "RentalPerDay"
      csRentalPerDay.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ToolWithdrawDetail.Rentalperday}")
      csRentalPerDay.NullText = ""
      csRentalPerDay.Alignment = HorizontalAlignment.Center
      csRentalPerDay.DataAlignment = HorizontalAlignment.Right
      csRentalPerDay.Format = "#,##0.00"
      csRentalPerDay.Width = 100
      csRentalPerDay.ReadOnly = True
      csRentalPerDay.TextBox.Name = "RentalPerDay"


      Dim csNote As New TreeTextColumn
      csNote.MappingName = "Note"
      csNote.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ToolWithdrawDetail.NoteHeaderText}")
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
      dst.GridColumnStyles.Add(csRentalRate)
      dst.GridColumnStyles.Add(csQty)
      dst.GridColumnStyles.Add(csRentalPerDay)
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

      Dim dt As TreeTable = EquipmentToolWithdraw.GetSchemaTable()
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
    Private ReadOnly Property CurrentItem() As EquipmentToolWithdrawItem
      Get
        Dim row As TreeRow = Me.m_treeManager.SelectedRow
        If row Is Nothing Then
          Return Nothing
        End If
        If Not TypeOf row.Tag Is EquipmentToolWithdrawItem Then
          Return Nothing
        End If
        Return CType(row.Tag, EquipmentToolWithdrawItem)
      End Get
    End Property
    'Private Property ComboCodeIndex() As Integer
    '  Get
    '    If m_combocodeindex = -1 Then
    '      If cmbCode.Items.Count > 0 Then
    '        m_combocodeindex = 0
    '      End If
    '    End If
    '    Return m_combocodeindex
    '  End Get
    '  Set(ByVal Value As Integer)
    '    m_combocodeindex = Value
    '  End Set
    'End Property
#End Region

#Region " IListDetail "
    ' Check Enable 
    Public Overrides Sub CheckFormEnable()
      If Me.m_entity Is Nothing Then
        Return
      End If

      If Me.m_entity.Canceled _
      OrElse Me.m_entity.Status.Value = 0 _
      OrElse Me.m_entity.Status.Value >= 3 _
      OrElse Me.m_entity.IsReferenced Then
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
          'If ctrl.Text = "สรุปยอดเบิกเครื่องมือ" AndAlso TypeOf ctrl Is FixedGroupBox Then
          '  For Each cr As Control In ctrl.Controls
          '    If TypeOf cr Is TextBox Then
          '      Trace.WriteLine(cr.Name + " : " + cr.Text)
          '    End If
          '  Next
          'End If
        Next
        For Each colStyle As DataGridColumnStyle In Me.m_treeManager.GridTableStyle.GridColumnStyles
          colStyle.ReadOnly = CBool(m_tableStyleEnable(colStyle))
        Next
      End If
    End Sub
    ' Clear Detail
    Public Overrides Sub ClearDetail()
      'lblStatus.Text = ""
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

      Me.dtpDocDate.Value = Date.Now
    End Sub
    ' Addhandler events
    Protected Overrides Sub EventWiring()
      AddHandler txtCode.TextChanged, AddressOf Me.ChangeProperty
      AddHandler txtNote.TextChanged, AddressOf Me.ChangeProperty

      AddHandler txtDocDate.Validated, AddressOf Me.ChangeProperty
      AddHandler dtpDocDate.ValueChanged, AddressOf Me.ChangeProperty

      AddHandler txtWithdrawPersonCode.Validated, AddressOf Me.ChangeProperty
      AddHandler txtWithdrawCCCode.Validated, AddressOf Me.ChangeProperty

      AddHandler txtStorepersonCode.Validated, AddressOf Me.ChangeProperty
      AddHandler txtStoreCCCode.Validated, AddressOf Me.ChangeProperty

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

      txtDocDate.Text = MinDateToNull(Me.m_entity.DocDate, Me.StringParserService.Parse("${res:Global.BlankDateText}"))
      dtpDocDate.Value = MinDateToNow(Me.m_entity.DocDate)

      If Not Me.m_entity.Withdrawperson Is Nothing Then
        txtWithdrawPersonCode.Text = Me.m_entity.Withdrawperson.Code
        txtWithdrawPersonName.Text = Me.m_entity.Withdrawperson.Name
      End If

      If Not Me.m_entity.WithdrawCostcenter Is Nothing Then
        txtWithdrawCCCode.Text = Me.m_entity.WithdrawCostcenter.Code
        txtWithdrawCCName.Text = Me.m_entity.WithdrawCostcenter.Name
      End If

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

      'Me.m_entity.ItemCollection.Populate(m_treeManager.Treetable, tgItem)
      '********************************************************************

      RefreshDocs()
      'ReIndex()
      RefreshBlankGrid()

      SetStatus()
      SetLabelText()
      'SetSummaryText()
      CheckFormEnable()

      m_isInitialized = True
    End Sub
    ' Item Propchanged
    Private Sub PropChanged(ByVal sender As Object, ByVal e As PropertyChangedEventArgs)
      If e.Name = "ItemChanged" Then
        Me.WorkbenchWindow.ViewContent.IsDirty = True
      End If
      'SetSummaryText()
    End Sub
    Private m_dateSetting As Boolean = False
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

        Case "chkwithdraw"
          dirtyFlag = True
          WithdrawCheckedChanged(sender)

        Case "txtwithdrawpersoncode"
          dirtyFlag = Employee.GetEmployee(txtWithdrawPersonCode, txtWithdrawPersonName, Me.m_entity.Withdrawperson)

        Case "txtwithdrawcccode"
          dirtyFlag = CostCenter.GetCostCenterWithoutRight(txtWithdrawCCCode, txtWithdrawCCName, Me.m_entity.WithdrawCostcenter)
          WithdrawCheckedChanged(sender)

        Case "txtstorepersoncode"
          dirtyFlag = Employee.GetEmployee(txtStorepersonCode, txtStorepersonName, Me.m_entity.Storeperson)

        Case "txtstorecccode"
          dirtyFlag = CostCenter.GetCostCenter(txtStoreCCCode, txtStoreCCName, Me.m_entity.StoreCostcenter, CType(ServiceManager.Services.GetService(GetType(SecurityService)), SecurityService).CurrentUser.Id)
          WithdrawCheckedChanged(sender)
      End Select

      Me.WorkbenchWindow.ViewContent.IsDirty = Me.WorkbenchWindow.ViewContent.IsDirty Or dirtyFlag

      SetStatus()
      'SetSummaryText()
      CheckFormEnable()
    End Sub
    Public Sub SetStatus()
        MyBase.SetStatusBarMessage()
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
        Me.m_entity = CType(Value, EquipmentToolWithdraw)
        'Hack:
        Me.m_entity.OnTabPageTextChanged(m_entity, EventArgs.Empty)
        UpdateEntityProperties()
      End Set
    End Property

    Public Overrides Sub Initialize()

    End Sub
    Private Sub RefreshDocs()
      Me.m_isInitialized = False
      Me.m_entity.ItemCollection.Populate(m_treeManager.Treetable, tgItem)
      RefreshBlankGrid()
      'ReIndex()
      Me.m_treeManager.Treetable.AcceptChanges()
      Me.UpdateAmount()
      Me.m_isInitialized = True

    End Sub
    Private Sub ReIndex()
      Dim i As Integer = 0
      'For Each row As DataRow In Me.m_treeManager.Treetable.Rows
      '  Dim tr As TreeRow = Me.m_treeManager.Treetable.Rows(0)
      '  row("Linenumber") = i + 1
      '  i += 1
      'Next
      For Each row As TreeRow In Me.m_treeManager.Treetable.Rows
        If TypeOf row.Tag Is EquipmentToolWithdrawItem Then
          row("Linenumber") = i + 1
          i += 1
        End If
      Next
    End Sub
#End Region

#Region "ItemTreeTable Handlers"
    Private Sub ItemTreetable_ColumnChanged(ByVal sender As Object, ByVal e As System.Data.DataColumnChangeEventArgs)
      If Not m_isInitialized OrElse e.Column.ColumnName.ToLower = "selected" Then
        Return
      End If
      Dim doc As EquipmentToolWithdrawItem = Me.CurrentItem
      If Not doc Is Nothing Then
        doc.ItemValidateRow(e.Row)
      End If
      Me.WorkbenchWindow.ViewContent.IsDirty = True
      Dim index As Integer = Me.tgItem.CurrentRowIndex
      RefreshDocs()
      tgItem.CurrentRowIndex = index
    End Sub
    Private Sub ItemTreetable_ColumnChanging(ByVal sender As Object, ByVal e As System.Data.DataColumnChangeEventArgs)
      If Not m_isInitialized OrElse e.Column.ColumnName.ToLower = "selected" _
        OrElse e.Column.ColumnName.ToLower = "linenumber" Then
        Return
      End If
      If Me.m_treeManager.SelectedRow Is Nothing Then
        Return
      End If
      Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
      If Me.m_entity Is Nothing Then
        Return
      End If
      Dim doc As EquipmentToolWithdrawItem = Me.CurrentItem
      If doc Is Nothing Then
        doc = New EquipmentToolWithdrawItem
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
          Case "rentalperday"
            If IsDBNull(e.ProposedValue) Then
              e.ProposedValue = ""
            End If
            Dim value As Decimal = CDec(TextParser.Evaluate(e.ProposedValue.ToString))
            doc.RentalPerDay = value
          Case "note"
            If IsDBNull(e.ProposedValue) Then
              e.ProposedValue = ""
            End If
            doc.Note = e.ProposedValue.ToString
        End Select
      Catch ex As Exception
        MessageBox.Show(ex.ToString)
      End Try
    End Sub
    Dim currentY As Integer = -1
    Private Sub tgItem_CurrentCellChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tgItem.CurrentCellChanged
      If tgItem.CurrentRowIndex <> currentY Then
        Me.m_entity.ItemCollection.CurrentItem = Me.CurrentItem
        'RefreshWBS()
        currentY = tgItem.CurrentRowIndex
      End If
    End Sub
#End Region

#Region " Event Handlers "
    Private Function GetItemIDList(ByVal type As Integer) As String
      Dim arr As New ArrayList
      For Each item As EquipmentToolWithdrawItem In Me.m_entity.ItemCollection
        If item.Entity.Id > 0 AndAlso item.ItemType.Value = type Then
          arr.Add(item.Entity.Id)
        End If
      Next
      Return String.Join(",", arr.ToArray)
    End Function
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
        msgServ.ShowMessage("${res:Longkong.Pojjaman.Gui.Panels.ToolWithdrawDetailView.Message.InputFromCC}")
        Return
      End If
      Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)

      If Me.CurrentItem Is Nothing Then
        Return
      End If

      Dim activeIndex As Integer = 0

      If Me.CurrentItem.ItemType.Value = 19 Then
        activeIndex = 0
      Else
        activeIndex = 1
      End If

      Dim filters(0)() As Filter
      filters(0) = New Filter() {New Filter("IDList", GetItemIDList(19))}
      'filters(1) = New Filter() {New Filter("IDList", GetItemIDList(346))}

      Dim filterEntities(5) As ArrayList
      For i As Integer = 0 To 0
        filterEntities(i) = New ArrayList
        filterEntities(i).Add(Me.m_entity.FromCC)
      Next

      Dim entities(0) As ISimpleEntity
      entities(0) = New ToolForSelection
      'entities(1) = New EqItemForSelection

      myEntityPanelService.OpenListDialog(entities, AddressOf SetItems, filters, filterEntities, activeIndex)

      'Return

      'If Me.CurrentItem.ItemType.Value = 19 Then
      '  Dim entities As New ArrayList
      '  Dim entity As New ToolForSelection
      '  entity.CC = Me.m_entity.FromCC
      '  entity.FromWip = False
      '  entity.EqtClass = Me.m_entity.ClassName
      '  entities.Add(entity)
      '  Dim filters(2) As Filter
      '  filters(0) = New Filter("IDList", GenIDListFromDataTable(19))
      '  filters(1) = New Filter("EntityType", Me.m_entity.EntityId)
      '  filters(2) = New Filter("eqtstatus", 2)  'ต้องการสถานะว่าง
      '  myEntityPanelService.OpenListDialog(entity, AddressOf SetItems, filters, entities)

      'ElseIf Me.CurrentItem.ItemType.Value = 342 Then
      '  Dim dlg As New BasketDialog
      '  AddHandler dlg.EmptyBasket, AddressOf SetItems

      '  Dim eqi As New EqItemForSelection

      '  Dim filters(1) As Filter
      '  filters(0) = New Filter("IDList", GenIDListFromDataTable(342))
      '  filters(1) = New Filter("EntityType", Me.m_entity.EntityId)
      '  'filters(2) = New Filter("eqtstatus", 2)  'ต้องการสถานะว่าง

      '  Dim entities As New ArrayList
      '  eqi.Costcenter = Me.m_entity.FromCC
      '  eqi.entityId = Me.m_entity.EntityId
      '  eqi.Status = Me.m_entity.FromStatus
      '  entities.Add(eqi)

      '  Dim view As AbstractEntityPanelViewContent = New EqiSelectionView(eqi, New BasketDialog, filters, entities)
      '  dlg.Lists.Add(view)
      '  Dim myDialog As New Longkong.Pojjaman.Gui.Dialogs.PanelDockingDialog(view, dlg)
      '  myDialog.ShowDialog()


      '  'Dim entities As New ArrayList
      '  'Dim eqi As New EqItemForSelection
      '  'eqi.Costcenter = Me.m_entity.FromCC
      '  'eqi.entityId = Me.m_entity.EntityId
      '  'entities.Add(eqi)
      '  'Dim filters(1) As Filter
      '  'filters(0) = New Filter("IDList", GenIDListFromDataTable(342))
      '  'filters(1) = New Filter("EntityType", Me.m_entity.EntityId)
      '  'myEntityPanelService.OpenListDialog(eqi, AddressOf SetItems, filters, entities)
      'End If

    End Sub
    Private Function GetPRExcludeList() As String
      Dim ret As String = ""
      For Each item As EquipmentToolWithdrawItem In Me.m_entity.ItemCollection
        If Not item.PRItem Is Nothing Then
          ret &= "|" & item.PRItem.Pr.Id.ToString & ":" & item.PRItem.LineNumber.ToString & "|"
        End If
      Next
      Return ret
    End Function
    Private Sub SetItems(ByVal items As BasketItemCollection)
      Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
      Dim index As Integer = tgItem.CurrentRowIndex
      For i As Integer = items.Count - 1 To 0 Step -1
        If TypeOf items(i) Is StockBasketItem Then

          Dim item As StockBasketItem = CType(items(i), StockBasketItem)
          If item.Qty = 0 Then
            'ไม่มีเครื่องมือเ/ครื่องจักร ที่ว่างในคลัง 
            msgServ.ShowMessage("${res:Global.Error.NoteCannotHaveQty}")
          Else
            'Dim newItem As IEqtItem
            Dim doc As New EquipmentToolWithdrawItem
            Dim itemType As Integer
            If TypeOf item.Tag Is PRItem Then
              Dim prItem As PRItem = CType(item.Tag, PRItem)
              itemType = prItem.ItemType.Value
              If itemType = 28 Then
                itemType = 346
              End If

              If Not Me.CurrentItem Is Nothing Then
                doc = Me.CurrentItem
                doc.ItemType.Value = itemType
                Me.m_treeManager.SelectedRow.Tag = Nothing
              Else
                Me.m_entity.ItemCollection.Add(doc)
                doc.ItemType = New EqtItemType(itemType)
              End If
              doc.Entity = New BlankEqItem
              doc.Entity.Id = prItem.Entity.Id
              doc.Entity.Code = prItem.Entity.Code
              doc.Entity.Name = prItem.Entity.Name

              doc.Unit = prItem.Unit
              doc.ToStatus = New EqtStatus(3)

              doc.LimitQty = item.Qty
              doc.Qty = item.Qty
              doc.RentalPerDay = prItem.UnitPrice * doc.Qty

              doc.PRItem = prItem
            End If
          End If
          'Select Case item.FullClassName.ToLower
          '  Case "longkong.pojjaman.businesslogic.equipmentitem"
          '    newItem = New EquipmentItem(item.Id)
          '    itemType = 342
          '  Case "longkong.pojjaman.businesslogic.tool"
          '    newItem = New Tool(item.Id)
          '    itemType = 19
          'End Select

        Else
          Dim item As BasketItem = CType(items(i), BasketItem)
          Dim newItem As IEqtItem
          Dim doc As New EquipmentToolWithdrawItem
          Dim itemType As Integer
          Select Case item.FullClassName.ToLower
            Case "longkong.pojjaman.businesslogic.eqitemforselection"
              newItem = New EquipmentItem(item.Id)
              itemType = 346
            Case "longkong.pojjaman.businesslogic.toolforselection"
              newItem = New Tool(item.Id)
              itemType = 19
          End Select
          If Not itemType = 0 Then
            'Dim doc As New EquipmentToolWithdrawItem
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
            doc.ToStatus = New EqtStatus(3)
            If itemType = 19 Then
              If TypeOf item.Tag Is DataRow Then
                Dim dr As DataRow = CType(item.Tag, DataRow)
                doc.LimitQty = CInt(dr("tool_remaining"))
                doc.Qty = CInt(dr("tool_remaining"))
              End If
              doc.RentalPerDay = CType(newItem, IEqtItem).RentalRate * doc.Qty
            Else
              doc.LimitQty = 1
              doc.Qty = 1
              doc.RentalPerDay = CType(newItem, IEqtItem).RentalRate
            End If
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
      Dim myItem As New EquipmentToolWithdrawItem
      'myItem.Entity = newItem

      myItem.Unit = New Unit
      'myItem. = New CostCenter

      myItem.ToStatus = New EqtStatus(1)
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
            If TypeOf row.Tag Is EquipmentToolWithdrawItem Then
              Dim doc As EquipmentToolWithdrawItem = CType(row.Tag, EquipmentToolWithdrawItem)
              If Not doc Is Nothing AndAlso Me.m_entity.ItemCollection.Contains(doc) Then
                Me.m_entity.ItemCollection.Remove(doc)
              End If
            End If
          End If
        End If
      Next

      If rowsCount.Equals(0) Then
        Dim doc As EquipmentToolWithdrawItem = Me.m_entity.ItemCollection.CurrentItem
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
    Public ReadOnly Property FormValidator() As components.PJMTextboxValidator Implements IValidatable.FormValidator
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
        Return (New EquipmentToolWithdraw).DetailPanelIcon
      End Get
    End Property
#End Region

#Region " Event of Button controls "
    Private Sub ibtnShowPR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnShowPR.Click
      If Me.m_entity.WithdrawCostcenter Is Nothing OrElse Not Me.m_entity.WithdrawCostcenter.Originated _
        OrElse Me.m_entity.StoreCostcenter Is Nothing OrElse Not Me.m_entity.StoreCostcenter.Originated Then
        Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
        Dim myPars As StringParserService = CType(ServiceManager.Services.GetService(GetType(StringParserService)), StringParserService)
        msgServ.ShowMessage(myPars.Parse("${res:Longkong.Pojjaman.Gui.Panels.MatTransferDetailView.SpecifiCCFromANDCCTOFirst}"))
        Return
      End If
      Dim dlg As New BasketDialog
      AddHandler dlg.EmptyBasket, AddressOf SetItems

      Dim filters(4) As Filter
      Dim excludeList As Object = ""
      excludeList = GetPRExcludeList()
      If excludeList.ToString.Length = 0 Then
        excludeList = DBNull.Value
      End If
      Dim prNeedsApproval As Boolean = False
      Dim prNeedsStoreApproval As Boolean = False

      'Dim tmp As Object
      'Dim tmp2 As Object
      'tmp = Configuration.GetConfig("MWPRFull")
      'tmp2 = Configuration.GetConfig("MWPRremainPO")

      prNeedsApproval = CBool(Configuration.GetConfig("ApprovePR"))
      prNeedsStoreApproval = CBool(Configuration.GetConfig("PRNeedStoreApprove"))

      filters(0) = New Filter("excludeList", excludeList)
      filters(1) = New Filter("prNeedsApproval", prNeedsApproval)
      'filters(2) = New Filter("excludeCanceled", True)
      filters(2) = New Filter("PRNeedStoreApprove", prNeedsStoreApproval)
      filters(3) = New Filter("formEntity", Me.m_entity.EntityId)
      'If CBool(tmp) Then
      '  filters(5) = New Filter("MWPRMode", 1)
      'ElseIf CBool(tmp2) Then
      '  filters(5) = New Filter("MWPRMode", 2)
      'Else
      '  filters(5) = New Filter("MWPRMode", 0)
      'End If
      filters(4) = New Filter("stock_id", Me.m_entity.Id)
      Dim Entities As New ArrayList
      If Not Me.m_entity.WithdrawCostcenter Is Nothing AndAlso Me.m_entity.WithdrawCostcenter.Originated Then
        Dim requestCostCenter As New RequestCostCenter(Me.m_entity.WithdrawCostcenter.Id)
        Entities.Add(requestCostCenter)
      End If
      If Not Me.m_entity.StoreCostcenter Is Nothing AndAlso Me.m_entity.StoreCostcenter.Originated Then
        Dim storeCostCenter As New StoreCostCenter(Me.m_entity.StoreCostcenter.Id)
        Entities.Add(storeCostCenter)
      End If

      Dim view As AbstractEntityPanelViewContent = New PRSelectionView(New PRForEqToolTransfer, New BasketDialog, filters, Entities)
      dlg.Lists.Add(view)
      Dim myDialog As New Longkong.Pojjaman.Gui.Dialogs.PanelDockingDialog(view, dlg)
      myDialog.ShowDialog()
    End Sub
    ' Withdraw Person
    Private Sub btnWithdrawPersonEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnWithdrawPersonEdit.Click
      Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      myEntityPanelService.OpenPanel(New Employee)
    End Sub
    Private Sub btnWithdrawPersonFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnWithdrawPersonFind.Click
      Dim myEntityPanelService As IEntityPanelService = _
       CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      myEntityPanelService.OpenListDialog(New Employee, AddressOf SetWithdrawPersonDialog)
    End Sub

    Private Sub SetWithdrawPersonDialog(ByVal e As ISimpleEntity)
      Me.txtWithdrawPersonCode.Text = e.Code
      Me.WorkbenchWindow.ViewContent.IsDirty = _
          Me.WorkbenchWindow.ViewContent.IsDirty _
          Or Employee.GetEmployee(txtWithdrawPersonCode, txtWithdrawPersonName, Me.m_entity.Withdrawperson)
    End Sub
    ' Withdraw Costcenter
    Private Sub btnWithdrawCCEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnWithdrawCCEdit.Click
      Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      myEntityPanelService.OpenPanel(New CostCenter)
    End Sub
    Private Sub btnWithdrawCCFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnWithdrawCCFind.Click
      Dim myEntityPanelService As IEntityPanelService = _
                   CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      myEntityPanelService.OpenTreeDialog(New CostCenter, AddressOf SetWithdrawCostCenterDialog, New Filter() {New Filter("checkright", False)})
    End Sub
    Private Sub SetWithdrawCostCenterDialog(ByVal e As ISimpleEntity)
      Me.txtWithdrawCCCode.Text = e.Code
      Me.WorkbenchWindow.ViewContent.IsDirty = _
          Me.WorkbenchWindow.ViewContent.IsDirty _
          Or CostCenter.GetCostCenterWithoutRight(txtWithdrawCCCode, txtWithdrawCCName, Me.m_entity.WithdrawCostcenter)
      WithdrawCheckedChanged(txtWithdrawCCCode)
    End Sub

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
      WithdrawCheckedChanged(txtStoreCCCode)
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
              Case "txtwithdrawpersoncode", "txtwithdrawpersonname"
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
              Case "txtwithdrawcccode", "txtwithdrawccname"
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
            Case "txtwithdrawpersoncode", "txtwithdrawpersonname"
              Me.SetWithdrawPersonDialog(entity)
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
            Case "txtwithdrawcccode", "txtwithdrawccname"
              Me.SetWithdrawCostCenterDialog(entity)
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
      'If Me.tgItem.Height = 0 Then
      '  Return
      'End If
      'Dim dirtyFlag As Boolean = Me.WorkbenchWindow.ViewContent.IsDirty
      'Dim index As Integer = tgItem.CurrentRowIndex

      'Do Until Me.m_treeManager.Treetable.Rows.Count > tgItem.VisibleRowCount
      '  'เพิ่มแถวจนเต็ม
      '  Me.m_treeManager.Treetable.Childs.Add()
      'Loop

      ''MessageBox.Show(tgItem.VisibleRowCount.ToString & ":" & Me.m_entity.ItemTable.Childs.Count.ToString)

      'If Me.m_entity.ItemCollection.Count = Me.m_treeManager.Treetable.Childs.Count Then
      '  'เพิ่มอีก 1 แถว ถ้ามีข้อมูลจนถึงแถวสุดท้าย
      '  Me.m_treeManager.Treetable.Childs.Add()
      'End If
      'Me.m_treeManager.Treetable.AcceptChanges()
      'tgItem.CurrentRowIndex = Math.Max(0, index)
      'Me.WorkbenchWindow.ViewContent.IsDirty = dirtyFlag

      'SetSummaryText()
    End Sub
#End Region

#Region " Private Methods "
    'Private Sub SetSummaryText()
    '  Dim i As Integer = 0
    '  For Each item As TreeRow In Me.m_treeManager.Treetable.Rows
    '    If Me.m_entity.ValidateRow(item) Then
    '      i += 1
    '    End If
    '  Next
    '  txtItemCount.Text = i.ToString("#,###")
    'End Sub
    Private Sub UpdateAmount()
      If Not Me.m_entity Is Nothing Then
        Me.txtItemCount.Text = Configuration.FormatToString(Me.m_entity.ItemCollection.Count, DigitConfig.Int)
      End If
    End Sub

    Private Sub WithdrawCheckedChanged(ByVal sender As System.Object)
      If TypeOf sender Is CheckBox Then
        If CType(sender, CheckBox).Checked AndAlso Not txtWithdrawCCCode.Text = txtStoreCCCode.Text Then
          txtWithdrawCCCode.Text = txtStoreCCCode.Text
          txtWithdrawCCName.Text = txtStoreCCName.Text
          Me.m_entity.WithdrawCostcenter = Me.m_entity.StoreCostcenter
        End If
      ElseIf TypeOf sender Is TextBox Then

      End If

    End Sub
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


  End Class
End Namespace

