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
    Public Class AssetWithdrawDetail
        Inherits AbstractEntityDetailPanelView
        Implements IValidatable

#Region " Windows Form Designer generated code "
        Friend WithEvents lblItem As System.Windows.Forms.Label
        Friend WithEvents grbReceive As Longkong.Pojjaman.Gui.Components.FixedGroupBox
        Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
        Friend WithEvents Validator As Longkong.Pojjaman.Gui.Components.PJMTextboxValidator
        Friend WithEvents lblRequestPerson As System.Windows.Forms.Label
        Friend WithEvents grbRequest As Longkong.Pojjaman.Gui.Components.FixedGroupBox
        Friend WithEvents ibtnBlank As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents ibtnDelRow As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents lblStatus As System.Windows.Forms.Label
        Friend WithEvents txtWithdrawPersonName As System.Windows.Forms.TextBox
        Friend WithEvents btnWithdrawPersonFind As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents txtWithdrawPersonCode As System.Windows.Forms.TextBox
        Friend WithEvents btnWithdrawPersonEdit As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents txtStorepersonName As System.Windows.Forms.TextBox
        Friend WithEvents txtStoreCCName As System.Windows.Forms.TextBox
        Friend WithEvents btnStoreCCFind As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents btnStorepersonFind As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents txtStoreCCCode As System.Windows.Forms.TextBox
        Friend WithEvents lblStoreperson As System.Windows.Forms.Label
        Friend WithEvents btnStoreCCEdit As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents lblStoreCC As System.Windows.Forms.Label
        Friend WithEvents txtStorepersonCode As System.Windows.Forms.TextBox
        Friend WithEvents btnStorepersonEdit As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents txtWithdrawCCName As System.Windows.Forms.TextBox
        Friend WithEvents lblWithdraw As System.Windows.Forms.Label
        Friend WithEvents txtWithdrawCCCode As System.Windows.Forms.TextBox
        Friend WithEvents btnWithdrawCCFind As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents btnWithdrawCCEdit As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents chkExternal As System.Windows.Forms.CheckBox
        Friend WithEvents chkAutorun As System.Windows.Forms.CheckBox
        Friend WithEvents txtDocDate As System.Windows.Forms.TextBox
        Friend WithEvents txtCode As System.Windows.Forms.TextBox
        Friend WithEvents dtpDocDate As System.Windows.Forms.DateTimePicker
        Friend WithEvents lblDocDate As System.Windows.Forms.Label
        Friend WithEvents lblCode As System.Windows.Forms.Label
        Friend WithEvents txtNote As System.Windows.Forms.TextBox
        Friend WithEvents lblNote As System.Windows.Forms.Label
        Friend WithEvents grbGeneral As Longkong.Pojjaman.Gui.Components.FixedGroupBox
        Friend WithEvents tgItem As Longkong.Pojjaman.Gui.Components.TreeGrid
        Friend WithEvents ibtnAddWBS As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents ibtnDelWBS As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents lblWBS As System.Windows.Forms.Label
        Friend WithEvents tgWBS As Longkong.Pojjaman.Gui.Components.TreeGrid
        Friend WithEvents btnCustomerPanel As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents txtCustomerCode As System.Windows.Forms.TextBox
        Friend WithEvents txtCustomerName As System.Windows.Forms.TextBox
        Friend WithEvents btnCustomerDialog As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents lblCustomer As System.Windows.Forms.Label
        Friend WithEvents grbRequest2 As Longkong.Pojjaman.Gui.Components.FixedGroupBox
        Private Sub InitializeComponent()
            Me.components = New System.ComponentModel.Container
            Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(AssetWithdrawDetail))
            Me.lblItem = New System.Windows.Forms.Label
            Me.grbReceive = New Longkong.Pojjaman.Gui.Components.FixedGroupBox
            Me.txtStorepersonName = New System.Windows.Forms.TextBox
            Me.txtStoreCCName = New System.Windows.Forms.TextBox
            Me.btnStoreCCFind = New Longkong.Pojjaman.Gui.Components.ImageButton
            Me.btnStorepersonFind = New Longkong.Pojjaman.Gui.Components.ImageButton
            Me.txtStoreCCCode = New System.Windows.Forms.TextBox
            Me.lblStoreperson = New System.Windows.Forms.Label
            Me.btnStoreCCEdit = New Longkong.Pojjaman.Gui.Components.ImageButton
            Me.lblStoreCC = New System.Windows.Forms.Label
            Me.txtStorepersonCode = New System.Windows.Forms.TextBox
            Me.btnStorepersonEdit = New Longkong.Pojjaman.Gui.Components.ImageButton
            Me.chkExternal = New System.Windows.Forms.CheckBox
            Me.grbRequest = New Longkong.Pojjaman.Gui.Components.FixedGroupBox
            Me.txtWithdrawCCName = New System.Windows.Forms.TextBox
            Me.btnWithdrawCCFind = New Longkong.Pojjaman.Gui.Components.ImageButton
            Me.txtWithdrawPersonName = New System.Windows.Forms.TextBox
            Me.btnWithdrawPersonFind = New Longkong.Pojjaman.Gui.Components.ImageButton
            Me.txtWithdrawPersonCode = New System.Windows.Forms.TextBox
            Me.lblRequestPerson = New System.Windows.Forms.Label
            Me.lblWithdraw = New System.Windows.Forms.Label
            Me.btnWithdrawCCEdit = New Longkong.Pojjaman.Gui.Components.ImageButton
            Me.txtWithdrawCCCode = New System.Windows.Forms.TextBox
            Me.btnWithdrawPersonEdit = New Longkong.Pojjaman.Gui.Components.ImageButton
            Me.btnCustomerPanel = New Longkong.Pojjaman.Gui.Components.ImageButton
            Me.txtCustomerCode = New System.Windows.Forms.TextBox
            Me.txtCustomerName = New System.Windows.Forms.TextBox
            Me.btnCustomerDialog = New Longkong.Pojjaman.Gui.Components.ImageButton
            Me.lblCustomer = New System.Windows.Forms.Label
            Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider
            Me.txtDocDate = New System.Windows.Forms.TextBox
            Me.txtCode = New System.Windows.Forms.TextBox
            Me.Validator = New Longkong.Pojjaman.Gui.Components.PJMTextboxValidator(Me.components)
            Me.txtNote = New System.Windows.Forms.TextBox
            Me.ibtnBlank = New Longkong.Pojjaman.Gui.Components.ImageButton
            Me.ibtnDelRow = New Longkong.Pojjaman.Gui.Components.ImageButton
            Me.lblStatus = New System.Windows.Forms.Label
            Me.grbGeneral = New Longkong.Pojjaman.Gui.Components.FixedGroupBox
            Me.lblNote = New System.Windows.Forms.Label
            Me.chkAutorun = New System.Windows.Forms.CheckBox
            Me.dtpDocDate = New System.Windows.Forms.DateTimePicker
            Me.lblDocDate = New System.Windows.Forms.Label
            Me.lblCode = New System.Windows.Forms.Label
            Me.tgItem = New Longkong.Pojjaman.Gui.Components.TreeGrid
            Me.ibtnAddWBS = New Longkong.Pojjaman.Gui.Components.ImageButton
            Me.ibtnDelWBS = New Longkong.Pojjaman.Gui.Components.ImageButton
            Me.lblWBS = New System.Windows.Forms.Label
            Me.tgWBS = New Longkong.Pojjaman.Gui.Components.TreeGrid
            Me.grbRequest2 = New Longkong.Pojjaman.Gui.Components.FixedGroupBox
            Me.grbReceive.SuspendLayout()
            Me.grbRequest.SuspendLayout()
            Me.grbGeneral.SuspendLayout()
            CType(Me.tgItem, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.tgWBS, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.grbRequest2.SuspendLayout()
            Me.SuspendLayout()
            '
            'lblItem
            '
            Me.lblItem.AutoSize = True
            Me.lblItem.BackColor = System.Drawing.Color.Transparent
            Me.lblItem.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblItem.Location = New System.Drawing.Point(16, 240)
            Me.lblItem.Name = "lblItem"
            Me.lblItem.Size = New System.Drawing.Size(140, 19)
            Me.lblItem.TabIndex = 4
            Me.lblItem.Text = "รายการเบิกเครื่องจักร:"
            Me.lblItem.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'grbReceive
            '
            Me.grbReceive.Controls.Add(Me.txtStorepersonName)
            Me.grbReceive.Controls.Add(Me.txtStoreCCName)
            Me.grbReceive.Controls.Add(Me.btnStoreCCFind)
            Me.grbReceive.Controls.Add(Me.btnStorepersonFind)
            Me.grbReceive.Controls.Add(Me.txtStoreCCCode)
            Me.grbReceive.Controls.Add(Me.lblStoreperson)
            Me.grbReceive.Controls.Add(Me.btnStoreCCEdit)
            Me.grbReceive.Controls.Add(Me.lblStoreCC)
            Me.grbReceive.Controls.Add(Me.txtStorepersonCode)
            Me.grbReceive.Controls.Add(Me.btnStorepersonEdit)
            Me.grbReceive.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.grbReceive.Location = New System.Drawing.Point(8, 120)
            Me.grbReceive.Name = "grbReceive"
            Me.grbReceive.Size = New System.Drawing.Size(376, 72)
            Me.grbReceive.TabIndex = 3
            Me.grbReceive.TabStop = False
            Me.grbReceive.Text = "ผู้ให้เบิก"
            '
            'txtStorepersonName
            '
            Me.txtStorepersonName.BackColor = System.Drawing.SystemColors.Control
            Me.Validator.SetDataType(Me.txtStorepersonName, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtStorepersonName, "")
            Me.Validator.SetGotFocusBackColor(Me.txtStorepersonName, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtStorepersonName, System.Drawing.Color.Empty)
            Me.txtStorepersonName.Location = New System.Drawing.Point(200, 40)
            Me.Validator.SetMaxValue(Me.txtStorepersonName, "")
            Me.Validator.SetMinValue(Me.txtStorepersonName, "")
            Me.txtStorepersonName.Name = "txtStorepersonName"
            Me.txtStorepersonName.ReadOnly = True
            Me.Validator.SetRegularExpression(Me.txtStorepersonName, "")
            Me.Validator.SetRequired(Me.txtStorepersonName, False)
            Me.txtStorepersonName.Size = New System.Drawing.Size(120, 21)
            Me.txtStorepersonName.TabIndex = 7
            Me.txtStorepersonName.TabStop = False
            Me.txtStorepersonName.Text = ""
            '
            'txtStoreCCName
            '
            Me.txtStoreCCName.BackColor = System.Drawing.SystemColors.Control
            Me.Validator.SetDataType(Me.txtStoreCCName, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtStoreCCName, "")
            Me.Validator.SetGotFocusBackColor(Me.txtStoreCCName, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtStoreCCName, System.Drawing.Color.Empty)
            Me.txtStoreCCName.Location = New System.Drawing.Point(200, 16)
            Me.Validator.SetMaxValue(Me.txtStoreCCName, "")
            Me.Validator.SetMinValue(Me.txtStoreCCName, "")
            Me.txtStoreCCName.Name = "txtStoreCCName"
            Me.txtStoreCCName.ReadOnly = True
            Me.Validator.SetRegularExpression(Me.txtStoreCCName, "")
            Me.Validator.SetRequired(Me.txtStoreCCName, False)
            Me.txtStoreCCName.Size = New System.Drawing.Size(120, 21)
            Me.txtStoreCCName.TabIndex = 2
            Me.txtStoreCCName.TabStop = False
            Me.txtStoreCCName.Text = ""
            '
            'btnStoreCCFind
            '
            Me.btnStoreCCFind.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.btnStoreCCFind.ForeColor = System.Drawing.SystemColors.Control
            Me.btnStoreCCFind.Image = CType(resources.GetObject("btnStoreCCFind.Image"), System.Drawing.Image)
            Me.btnStoreCCFind.Location = New System.Drawing.Point(320, 16)
            Me.btnStoreCCFind.Name = "btnStoreCCFind"
            Me.btnStoreCCFind.Size = New System.Drawing.Size(24, 23)
            Me.btnStoreCCFind.TabIndex = 3
            Me.btnStoreCCFind.TabStop = False
            Me.btnStoreCCFind.ThemedImage = CType(resources.GetObject("btnStoreCCFind.ThemedImage"), System.Drawing.Bitmap)
            '
            'btnStorepersonFind
            '
            Me.btnStorepersonFind.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.btnStorepersonFind.ForeColor = System.Drawing.SystemColors.Control
            Me.btnStorepersonFind.Image = CType(resources.GetObject("btnStorepersonFind.Image"), System.Drawing.Image)
            Me.btnStorepersonFind.Location = New System.Drawing.Point(320, 40)
            Me.btnStorepersonFind.Name = "btnStorepersonFind"
            Me.btnStorepersonFind.Size = New System.Drawing.Size(24, 23)
            Me.btnStorepersonFind.TabIndex = 8
            Me.btnStorepersonFind.TabStop = False
            Me.btnStorepersonFind.ThemedImage = CType(resources.GetObject("btnStorepersonFind.ThemedImage"), System.Drawing.Bitmap)
            '
            'txtStoreCCCode
            '
            Me.txtStoreCCCode.BackColor = System.Drawing.SystemColors.Window
            Me.Validator.SetDataType(Me.txtStoreCCCode, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtStoreCCCode, "")
            Me.Validator.SetGotFocusBackColor(Me.txtStoreCCCode, System.Drawing.Color.Empty)
            Me.ErrorProvider1.SetIconPadding(Me.txtStoreCCCode, -15)
            Me.Validator.SetInvalidBackColor(Me.txtStoreCCCode, System.Drawing.Color.Empty)
            Me.txtStoreCCCode.Location = New System.Drawing.Point(136, 16)
            Me.txtStoreCCCode.MaxLength = 20
            Me.Validator.SetMaxValue(Me.txtStoreCCCode, "")
            Me.Validator.SetMinValue(Me.txtStoreCCCode, "")
            Me.txtStoreCCCode.Name = "txtStoreCCCode"
            Me.Validator.SetRegularExpression(Me.txtStoreCCCode, "")
            Me.Validator.SetRequired(Me.txtStoreCCCode, False)
            Me.txtStoreCCCode.Size = New System.Drawing.Size(64, 21)
            Me.txtStoreCCCode.TabIndex = 10
            Me.txtStoreCCCode.Text = ""
            '
            'lblStoreperson
            '
            Me.lblStoreperson.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblStoreperson.Location = New System.Drawing.Point(8, 40)
            Me.lblStoreperson.Name = "lblStoreperson"
            Me.lblStoreperson.Size = New System.Drawing.Size(120, 18)
            Me.lblStoreperson.TabIndex = 5
            Me.lblStoreperson.Text = "ผู้ให้เบิก:"
            Me.lblStoreperson.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'btnStoreCCEdit
            '
            Me.btnStoreCCEdit.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.btnStoreCCEdit.Image = CType(resources.GetObject("btnStoreCCEdit.Image"), System.Drawing.Image)
            Me.btnStoreCCEdit.Location = New System.Drawing.Point(344, 16)
            Me.btnStoreCCEdit.Name = "btnStoreCCEdit"
            Me.btnStoreCCEdit.Size = New System.Drawing.Size(24, 23)
            Me.btnStoreCCEdit.TabIndex = 4
            Me.btnStoreCCEdit.TabStop = False
            Me.btnStoreCCEdit.ThemedImage = CType(resources.GetObject("btnStoreCCEdit.ThemedImage"), System.Drawing.Bitmap)
            '
            'lblStoreCC
            '
            Me.lblStoreCC.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblStoreCC.Location = New System.Drawing.Point(8, 16)
            Me.lblStoreCC.Name = "lblStoreCC"
            Me.lblStoreCC.Size = New System.Drawing.Size(120, 18)
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
            Me.txtStorepersonCode.Location = New System.Drawing.Point(136, 40)
            Me.txtStorepersonCode.MaxLength = 20
            Me.Validator.SetMaxValue(Me.txtStorepersonCode, "")
            Me.Validator.SetMinValue(Me.txtStorepersonCode, "")
            Me.txtStorepersonCode.Name = "txtStorepersonCode"
            Me.Validator.SetRegularExpression(Me.txtStorepersonCode, "")
            Me.Validator.SetRequired(Me.txtStorepersonCode, False)
            Me.txtStorepersonCode.Size = New System.Drawing.Size(64, 21)
            Me.txtStorepersonCode.TabIndex = 11
            Me.txtStorepersonCode.Text = ""
            '
            'btnStorepersonEdit
            '
            Me.btnStorepersonEdit.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.btnStorepersonEdit.Image = CType(resources.GetObject("btnStorepersonEdit.Image"), System.Drawing.Image)
            Me.btnStorepersonEdit.Location = New System.Drawing.Point(344, 40)
            Me.btnStorepersonEdit.Name = "btnStorepersonEdit"
            Me.btnStorepersonEdit.Size = New System.Drawing.Size(24, 23)
            Me.btnStorepersonEdit.TabIndex = 9
            Me.btnStorepersonEdit.TabStop = False
            Me.btnStorepersonEdit.ThemedImage = CType(resources.GetObject("btnStorepersonEdit.ThemedImage"), System.Drawing.Bitmap)
            '
            'chkExternal
            '
            Me.chkExternal.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.chkExternal.Location = New System.Drawing.Point(400, 96)
            Me.chkExternal.Name = "chkExternal"
            Me.chkExternal.Size = New System.Drawing.Size(144, 16)
            Me.chkExternal.TabIndex = 8
            Me.chkExternal.Text = "เบิกไปใช้โครงการนอก"
            '
            'grbRequest
            '
            Me.grbRequest.Controls.Add(Me.txtWithdrawCCName)
            Me.grbRequest.Controls.Add(Me.btnWithdrawCCFind)
            Me.grbRequest.Controls.Add(Me.txtWithdrawPersonName)
            Me.grbRequest.Controls.Add(Me.btnWithdrawPersonFind)
            Me.grbRequest.Controls.Add(Me.txtWithdrawPersonCode)
            Me.grbRequest.Controls.Add(Me.lblRequestPerson)
            Me.grbRequest.Controls.Add(Me.lblWithdraw)
            Me.grbRequest.Controls.Add(Me.btnWithdrawCCEdit)
            Me.grbRequest.Controls.Add(Me.txtWithdrawCCCode)
            Me.grbRequest.Controls.Add(Me.btnWithdrawPersonEdit)
            Me.grbRequest.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.grbRequest.Location = New System.Drawing.Point(392, 120)
            Me.grbRequest.Name = "grbRequest"
            Me.grbRequest.Size = New System.Drawing.Size(392, 72)
            Me.grbRequest.TabIndex = 2
            Me.grbRequest.TabStop = False
            Me.grbRequest.Text = "ผู้ขอเบิก"
            '
            'txtWithdrawCCName
            '
            Me.txtWithdrawCCName.BackColor = System.Drawing.SystemColors.Control
            Me.Validator.SetDataType(Me.txtWithdrawCCName, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtWithdrawCCName, "")
            Me.Validator.SetGotFocusBackColor(Me.txtWithdrawCCName, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtWithdrawCCName, System.Drawing.Color.Empty)
            Me.txtWithdrawCCName.Location = New System.Drawing.Point(216, 16)
            Me.Validator.SetMaxValue(Me.txtWithdrawCCName, "")
            Me.Validator.SetMinValue(Me.txtWithdrawCCName, "")
            Me.txtWithdrawCCName.Name = "txtWithdrawCCName"
            Me.txtWithdrawCCName.ReadOnly = True
            Me.Validator.SetRegularExpression(Me.txtWithdrawCCName, "")
            Me.Validator.SetRequired(Me.txtWithdrawCCName, False)
            Me.txtWithdrawCCName.Size = New System.Drawing.Size(120, 21)
            Me.txtWithdrawCCName.TabIndex = 2
            Me.txtWithdrawCCName.TabStop = False
            Me.txtWithdrawCCName.Text = ""
            '
            'btnWithdrawCCFind
            '
            Me.btnWithdrawCCFind.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.btnWithdrawCCFind.ForeColor = System.Drawing.SystemColors.Control
            Me.btnWithdrawCCFind.Image = CType(resources.GetObject("btnWithdrawCCFind.Image"), System.Drawing.Image)
            Me.btnWithdrawCCFind.Location = New System.Drawing.Point(336, 16)
            Me.btnWithdrawCCFind.Name = "btnWithdrawCCFind"
            Me.btnWithdrawCCFind.Size = New System.Drawing.Size(24, 23)
            Me.btnWithdrawCCFind.TabIndex = 3
            Me.btnWithdrawCCFind.TabStop = False
            Me.btnWithdrawCCFind.ThemedImage = CType(resources.GetObject("btnWithdrawCCFind.ThemedImage"), System.Drawing.Bitmap)
            '
            'txtWithdrawPersonName
            '
            Me.txtWithdrawPersonName.BackColor = System.Drawing.SystemColors.Control
            Me.Validator.SetDataType(Me.txtWithdrawPersonName, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtWithdrawPersonName, "")
            Me.Validator.SetGotFocusBackColor(Me.txtWithdrawPersonName, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtWithdrawPersonName, System.Drawing.Color.Empty)
            Me.txtWithdrawPersonName.Location = New System.Drawing.Point(216, 40)
            Me.Validator.SetMaxValue(Me.txtWithdrawPersonName, "")
            Me.Validator.SetMinValue(Me.txtWithdrawPersonName, "")
            Me.txtWithdrawPersonName.Name = "txtWithdrawPersonName"
            Me.txtWithdrawPersonName.ReadOnly = True
            Me.Validator.SetRegularExpression(Me.txtWithdrawPersonName, "")
            Me.Validator.SetRequired(Me.txtWithdrawPersonName, False)
            Me.txtWithdrawPersonName.Size = New System.Drawing.Size(120, 21)
            Me.txtWithdrawPersonName.TabIndex = 7
            Me.txtWithdrawPersonName.TabStop = False
            Me.txtWithdrawPersonName.Text = ""
            '
            'btnWithdrawPersonFind
            '
            Me.btnWithdrawPersonFind.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.btnWithdrawPersonFind.ForeColor = System.Drawing.SystemColors.Control
            Me.btnWithdrawPersonFind.Image = CType(resources.GetObject("btnWithdrawPersonFind.Image"), System.Drawing.Image)
            Me.btnWithdrawPersonFind.Location = New System.Drawing.Point(336, 40)
            Me.btnWithdrawPersonFind.Name = "btnWithdrawPersonFind"
            Me.btnWithdrawPersonFind.Size = New System.Drawing.Size(24, 23)
            Me.btnWithdrawPersonFind.TabIndex = 8
            Me.btnWithdrawPersonFind.TabStop = False
            Me.btnWithdrawPersonFind.ThemedImage = CType(resources.GetObject("btnWithdrawPersonFind.ThemedImage"), System.Drawing.Bitmap)
            '
            'txtWithdrawPersonCode
            '
            Me.Validator.SetDataType(Me.txtWithdrawPersonCode, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtWithdrawPersonCode, "")
            Me.Validator.SetGotFocusBackColor(Me.txtWithdrawPersonCode, System.Drawing.Color.Empty)
            Me.ErrorProvider1.SetIconPadding(Me.txtWithdrawPersonCode, -15)
            Me.Validator.SetInvalidBackColor(Me.txtWithdrawPersonCode, System.Drawing.Color.Empty)
            Me.txtWithdrawPersonCode.Location = New System.Drawing.Point(152, 40)
            Me.txtWithdrawPersonCode.MaxLength = 20
            Me.Validator.SetMaxValue(Me.txtWithdrawPersonCode, "")
            Me.Validator.SetMinValue(Me.txtWithdrawPersonCode, "")
            Me.txtWithdrawPersonCode.Name = "txtWithdrawPersonCode"
            Me.Validator.SetRegularExpression(Me.txtWithdrawPersonCode, "")
            Me.Validator.SetRequired(Me.txtWithdrawPersonCode, False)
            Me.txtWithdrawPersonCode.Size = New System.Drawing.Size(64, 21)
            Me.txtWithdrawPersonCode.TabIndex = 14
            Me.txtWithdrawPersonCode.Text = ""
            '
            'lblRequestPerson
            '
            Me.lblRequestPerson.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblRequestPerson.Location = New System.Drawing.Point(16, 40)
            Me.lblRequestPerson.Name = "lblRequestPerson"
            Me.lblRequestPerson.Size = New System.Drawing.Size(136, 18)
            Me.lblRequestPerson.TabIndex = 5
            Me.lblRequestPerson.Text = "ผู้เบิก:"
            Me.lblRequestPerson.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblWithdraw
            '
            Me.lblWithdraw.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblWithdraw.Location = New System.Drawing.Point(16, 16)
            Me.lblWithdraw.Name = "lblWithdraw"
            Me.lblWithdraw.Size = New System.Drawing.Size(136, 18)
            Me.lblWithdraw.TabIndex = 0
            Me.lblWithdraw.Text = "เบิกเข้า Cost Center:"
            Me.lblWithdraw.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'btnWithdrawCCEdit
            '
            Me.btnWithdrawCCEdit.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.btnWithdrawCCEdit.Image = CType(resources.GetObject("btnWithdrawCCEdit.Image"), System.Drawing.Image)
            Me.btnWithdrawCCEdit.Location = New System.Drawing.Point(360, 16)
            Me.btnWithdrawCCEdit.Name = "btnWithdrawCCEdit"
            Me.btnWithdrawCCEdit.Size = New System.Drawing.Size(24, 23)
            Me.btnWithdrawCCEdit.TabIndex = 4
            Me.btnWithdrawCCEdit.TabStop = False
            Me.btnWithdrawCCEdit.ThemedImage = CType(resources.GetObject("btnWithdrawCCEdit.ThemedImage"), System.Drawing.Bitmap)
            '
            'txtWithdrawCCCode
            '
            Me.Validator.SetDataType(Me.txtWithdrawCCCode, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtWithdrawCCCode, "")
            Me.Validator.SetGotFocusBackColor(Me.txtWithdrawCCCode, System.Drawing.Color.Empty)
            Me.ErrorProvider1.SetIconPadding(Me.txtWithdrawCCCode, -15)
            Me.Validator.SetInvalidBackColor(Me.txtWithdrawCCCode, System.Drawing.Color.Empty)
            Me.txtWithdrawCCCode.Location = New System.Drawing.Point(152, 16)
            Me.txtWithdrawCCCode.MaxLength = 20
            Me.Validator.SetMaxValue(Me.txtWithdrawCCCode, "")
            Me.Validator.SetMinValue(Me.txtWithdrawCCCode, "")
            Me.txtWithdrawCCCode.Name = "txtWithdrawCCCode"
            Me.Validator.SetRegularExpression(Me.txtWithdrawCCCode, "")
            Me.Validator.SetRequired(Me.txtWithdrawCCCode, False)
            Me.txtWithdrawCCCode.Size = New System.Drawing.Size(64, 21)
            Me.txtWithdrawCCCode.TabIndex = 13
            Me.txtWithdrawCCCode.Text = ""
            '
            'btnWithdrawPersonEdit
            '
            Me.btnWithdrawPersonEdit.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.btnWithdrawPersonEdit.Image = CType(resources.GetObject("btnWithdrawPersonEdit.Image"), System.Drawing.Image)
            Me.btnWithdrawPersonEdit.Location = New System.Drawing.Point(360, 40)
            Me.btnWithdrawPersonEdit.Name = "btnWithdrawPersonEdit"
            Me.btnWithdrawPersonEdit.Size = New System.Drawing.Size(24, 23)
            Me.btnWithdrawPersonEdit.TabIndex = 9
            Me.btnWithdrawPersonEdit.TabStop = False
            Me.btnWithdrawPersonEdit.ThemedImage = CType(resources.GetObject("btnWithdrawPersonEdit.ThemedImage"), System.Drawing.Bitmap)
            '
            'btnCustomerPanel
            '
            Me.btnCustomerPanel.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.btnCustomerPanel.Image = CType(resources.GetObject("btnCustomerPanel.Image"), System.Drawing.Image)
            Me.btnCustomerPanel.Location = New System.Drawing.Point(360, 16)
            Me.btnCustomerPanel.Name = "btnCustomerPanel"
            Me.btnCustomerPanel.Size = New System.Drawing.Size(24, 23)
            Me.btnCustomerPanel.TabIndex = 216
            Me.btnCustomerPanel.TabStop = False
            Me.btnCustomerPanel.ThemedImage = CType(resources.GetObject("btnCustomerPanel.ThemedImage"), System.Drawing.Bitmap)
            '
            'txtCustomerCode
            '
            Me.Validator.SetDataType(Me.txtCustomerCode, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtCustomerCode, "")
            Me.Validator.SetGotFocusBackColor(Me.txtCustomerCode, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtCustomerCode, System.Drawing.Color.Empty)
            Me.txtCustomerCode.Location = New System.Drawing.Point(152, 16)
            Me.Validator.SetMaxValue(Me.txtCustomerCode, "")
            Me.Validator.SetMinValue(Me.txtCustomerCode, "")
            Me.txtCustomerCode.Name = "txtCustomerCode"
            Me.Validator.SetRegularExpression(Me.txtCustomerCode, "")
            Me.Validator.SetRequired(Me.txtCustomerCode, False)
            Me.txtCustomerCode.Size = New System.Drawing.Size(64, 21)
            Me.txtCustomerCode.TabIndex = 213
            Me.txtCustomerCode.Text = ""
            '
            'txtCustomerName
            '
            Me.Validator.SetDataType(Me.txtCustomerName, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtCustomerName, "")
            Me.Validator.SetGotFocusBackColor(Me.txtCustomerName, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtCustomerName, System.Drawing.Color.Empty)
            Me.txtCustomerName.Location = New System.Drawing.Point(216, 16)
            Me.Validator.SetMaxValue(Me.txtCustomerName, "")
            Me.Validator.SetMinValue(Me.txtCustomerName, "")
            Me.txtCustomerName.Name = "txtCustomerName"
            Me.txtCustomerName.ReadOnly = True
            Me.Validator.SetRegularExpression(Me.txtCustomerName, "")
            Me.Validator.SetRequired(Me.txtCustomerName, False)
            Me.txtCustomerName.Size = New System.Drawing.Size(120, 21)
            Me.txtCustomerName.TabIndex = 215
            Me.txtCustomerName.TabStop = False
            Me.txtCustomerName.Text = ""
            '
            'btnCustomerDialog
            '
            Me.btnCustomerDialog.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.btnCustomerDialog.ForeColor = System.Drawing.SystemColors.Control
            Me.btnCustomerDialog.Image = CType(resources.GetObject("btnCustomerDialog.Image"), System.Drawing.Image)
            Me.btnCustomerDialog.Location = New System.Drawing.Point(336, 16)
            Me.btnCustomerDialog.Name = "btnCustomerDialog"
            Me.btnCustomerDialog.Size = New System.Drawing.Size(24, 23)
            Me.btnCustomerDialog.TabIndex = 217
            Me.btnCustomerDialog.TabStop = False
            Me.btnCustomerDialog.ThemedImage = CType(resources.GetObject("btnCustomerDialog.ThemedImage"), System.Drawing.Bitmap)
            '
            'lblCustomer
            '
            Me.lblCustomer.BackColor = System.Drawing.Color.Transparent
            Me.lblCustomer.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblCustomer.ForeColor = System.Drawing.SystemColors.WindowText
            Me.lblCustomer.Location = New System.Drawing.Point(48, 16)
            Me.lblCustomer.Name = "lblCustomer"
            Me.lblCustomer.Size = New System.Drawing.Size(104, 18)
            Me.lblCustomer.TabIndex = 214
            Me.lblCustomer.Text = "ลูกค้า:"
            Me.lblCustomer.TextAlign = System.Drawing.ContentAlignment.MiddleRight
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
            Me.Validator.SetMaxValue(Me.txtDocDate, "")
            Me.Validator.SetMinValue(Me.txtDocDate, "")
            Me.txtDocDate.Name = "txtDocDate"
            Me.Validator.SetRegularExpression(Me.txtDocDate, "")
            Me.Validator.SetRequired(Me.txtDocDate, True)
            Me.txtDocDate.Size = New System.Drawing.Size(115, 21)
            Me.txtDocDate.TabIndex = 4
            Me.txtDocDate.Text = ""
            '
            'txtCode
            '
            Me.Validator.SetDataType(Me.txtCode, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtCode, "")
            Me.Validator.SetGotFocusBackColor(Me.txtCode, System.Drawing.Color.Empty)
            Me.ErrorProvider1.SetIconPadding(Me.txtCode, -15)
            Me.Validator.SetInvalidBackColor(Me.txtCode, System.Drawing.Color.Empty)
            Me.txtCode.Location = New System.Drawing.Point(120, 16)
            Me.txtCode.MaxLength = 20
            Me.Validator.SetMaxValue(Me.txtCode, "")
            Me.Validator.SetMinValue(Me.txtCode, "")
            Me.txtCode.Name = "txtCode"
            Me.Validator.SetRegularExpression(Me.txtCode, "")
            Me.Validator.SetRequired(Me.txtCode, True)
            Me.txtCode.Size = New System.Drawing.Size(120, 21)
            Me.txtCode.TabIndex = 1
            Me.txtCode.Text = ""
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
            'txtNote
            '
            Me.txtNote.BackColor = System.Drawing.SystemColors.Window
            Me.Validator.SetDataType(Me.txtNote, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtNote, "")
            Me.Validator.SetGotFocusBackColor(Me.txtNote, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtNote, System.Drawing.Color.Empty)
            Me.txtNote.Location = New System.Drawing.Point(120, 40)
            Me.txtNote.MaxLength = 255
            Me.Validator.SetMaxValue(Me.txtNote, "")
            Me.Validator.SetMinValue(Me.txtNote, "")
            Me.txtNote.Name = "txtNote"
            Me.Validator.SetRegularExpression(Me.txtNote, "")
            Me.Validator.SetRequired(Me.txtNote, False)
            Me.txtNote.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal
            Me.txtNote.Size = New System.Drawing.Size(552, 21)
            Me.txtNote.TabIndex = 7
            Me.txtNote.Text = ""
            '
            'ibtnBlank
            '
            Me.ibtnBlank.Image = CType(resources.GetObject("ibtnBlank.Image"), System.Drawing.Image)
            Me.ibtnBlank.Location = New System.Drawing.Point(192, 232)
            Me.ibtnBlank.Name = "ibtnBlank"
            Me.ibtnBlank.Size = New System.Drawing.Size(24, 24)
            Me.ibtnBlank.TabIndex = 5
            Me.ibtnBlank.TabStop = False
            Me.ibtnBlank.ThemedImage = CType(resources.GetObject("ibtnBlank.ThemedImage"), System.Drawing.Bitmap)
            '
            'ibtnDelRow
            '
            Me.ibtnDelRow.Image = CType(resources.GetObject("ibtnDelRow.Image"), System.Drawing.Image)
            Me.ibtnDelRow.Location = New System.Drawing.Point(216, 232)
            Me.ibtnDelRow.Name = "ibtnDelRow"
            Me.ibtnDelRow.Size = New System.Drawing.Size(24, 24)
            Me.ibtnDelRow.TabIndex = 6
            Me.ibtnDelRow.TabStop = False
            Me.ibtnDelRow.ThemedImage = CType(resources.GetObject("ibtnDelRow.ThemedImage"), System.Drawing.Bitmap)
            '
            'lblStatus
            '
            Me.lblStatus.AutoSize = True
            Me.lblStatus.Location = New System.Drawing.Point(304, 344)
            Me.lblStatus.Name = "lblStatus"
            Me.lblStatus.Size = New System.Drawing.Size(47, 17)
            Me.lblStatus.TabIndex = 7
            Me.lblStatus.Text = "lblStatus"
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
            Me.grbGeneral.Size = New System.Drawing.Size(776, 72)
            Me.grbGeneral.TabIndex = 0
            Me.grbGeneral.TabStop = False
            Me.grbGeneral.Text = "ผู้ขอเบิก"
            '
            'lblNote
            '
            Me.lblNote.BackColor = System.Drawing.Color.Transparent
            Me.lblNote.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblNote.Location = New System.Drawing.Point(8, 40)
            Me.lblNote.Name = "lblNote"
            Me.lblNote.Size = New System.Drawing.Size(105, 18)
            Me.lblNote.TabIndex = 6
            Me.lblNote.Text = "หมายเหตุ:"
            Me.lblNote.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'chkAutorun
            '
            Me.chkAutorun.Appearance = System.Windows.Forms.Appearance.Button
            Me.chkAutorun.Image = CType(resources.GetObject("chkAutorun.Image"), System.Drawing.Image)
            Me.chkAutorun.Location = New System.Drawing.Point(240, 16)
            Me.chkAutorun.Name = "chkAutorun"
            Me.chkAutorun.Size = New System.Drawing.Size(21, 21)
            Me.chkAutorun.TabIndex = 2
            Me.chkAutorun.TabStop = False
            '
            'dtpDocDate
            '
            Me.dtpDocDate.Format = System.Windows.Forms.DateTimePickerFormat.Short
            Me.dtpDocDate.Location = New System.Drawing.Point(376, 16)
            Me.dtpDocDate.Name = "dtpDocDate"
            Me.dtpDocDate.Size = New System.Drawing.Size(136, 21)
            Me.dtpDocDate.TabIndex = 5
            Me.dtpDocDate.TabStop = False
            '
            'lblDocDate
            '
            Me.lblDocDate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblDocDate.Location = New System.Drawing.Point(280, 16)
            Me.lblDocDate.Name = "lblDocDate"
            Me.lblDocDate.Size = New System.Drawing.Size(88, 18)
            Me.lblDocDate.TabIndex = 3
            Me.lblDocDate.Text = "วันที่เอกสาร:"
            Me.lblDocDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblCode
            '
            Me.lblCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblCode.Location = New System.Drawing.Point(8, 16)
            Me.lblCode.Name = "lblCode"
            Me.lblCode.Size = New System.Drawing.Size(105, 18)
            Me.lblCode.TabIndex = 0
            Me.lblCode.Text = "เลขที่เอกสาร:"
            Me.lblCode.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'tgItem
            '
            Me.tgItem.AllowNew = False
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
            Me.tgItem.GridLineColor = System.Drawing.Color.FromArgb(CType(210, Byte), CType(200, Byte), CType(120, Byte))
            Me.tgItem.HeaderBackColor = System.Drawing.Color.DarkGoldenrod
            Me.tgItem.HeaderForeColor = System.Drawing.Color.White
            Me.tgItem.Location = New System.Drawing.Point(16, 256)
            Me.tgItem.Name = "tgItem"
            Me.tgItem.ParentRowsBackColor = System.Drawing.SystemColors.ControlText
            Me.tgItem.SelectionBackColor = System.Drawing.Color.Sienna
            Me.tgItem.Size = New System.Drawing.Size(776, 80)
            Me.tgItem.SortingArrowColor = System.Drawing.Color.Red
            Me.tgItem.TabIndex = 15
            Me.tgItem.TreeManager = Nothing
            '
            'ibtnAddWBS
            '
            Me.ibtnAddWBS.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ibtnAddWBS.Image = CType(resources.GetObject("ibtnAddWBS.Image"), System.Drawing.Image)
            Me.ibtnAddWBS.Location = New System.Drawing.Point(536, 360)
            Me.ibtnAddWBS.Name = "ibtnAddWBS"
            Me.ibtnAddWBS.Size = New System.Drawing.Size(24, 24)
            Me.ibtnAddWBS.TabIndex = 34
            Me.ibtnAddWBS.TabStop = False
            Me.ibtnAddWBS.ThemedImage = CType(resources.GetObject("ibtnAddWBS.ThemedImage"), System.Drawing.Bitmap)
            '
            'ibtnDelWBS
            '
            Me.ibtnDelWBS.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ibtnDelWBS.Image = CType(resources.GetObject("ibtnDelWBS.Image"), System.Drawing.Image)
            Me.ibtnDelWBS.Location = New System.Drawing.Point(560, 360)
            Me.ibtnDelWBS.Name = "ibtnDelWBS"
            Me.ibtnDelWBS.Size = New System.Drawing.Size(24, 24)
            Me.ibtnDelWBS.TabIndex = 35
            Me.ibtnDelWBS.TabStop = False
            Me.ibtnDelWBS.ThemedImage = CType(resources.GetObject("ibtnDelWBS.ThemedImage"), System.Drawing.Bitmap)
            '
            'lblWBS
            '
            Me.lblWBS.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
            Me.lblWBS.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblWBS.ForeColor = System.Drawing.Color.Black
            Me.lblWBS.Location = New System.Drawing.Point(16, 344)
            Me.lblWBS.Name = "lblWBS"
            Me.lblWBS.Size = New System.Drawing.Size(104, 18)
            Me.lblWBS.TabIndex = 33
            Me.lblWBS.Text = "จัดสรร WBS:"
            Me.lblWBS.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'tgWBS
            '
            Me.tgWBS.AllowNew = False
            Me.tgWBS.AllowSorting = False
            Me.tgWBS.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.tgWBS.AutoColumnResize = True
            Me.tgWBS.CaptionVisible = False
            Me.tgWBS.Cellchanged = False
            Me.tgWBS.ColorList.AddRange(New System.Drawing.Color() {System.Drawing.Color.FromArgb(CType(255, Byte), CType(192, Byte), CType(128, Byte)), System.Drawing.Color.FromArgb(CType(255, Byte), CType(255, Byte), CType(192, Byte))})
            Me.tgWBS.DataMember = ""
            Me.tgWBS.HeaderForeColor = System.Drawing.SystemColors.ControlText
            Me.tgWBS.Location = New System.Drawing.Point(16, 360)
            Me.tgWBS.Name = "tgWBS"
            Me.tgWBS.Size = New System.Drawing.Size(520, 144)
            Me.tgWBS.SortingArrowColor = System.Drawing.Color.Red
            Me.tgWBS.TabIndex = 36
            Me.tgWBS.TreeManager = Nothing
            '
            'grbRequest2
            '
            Me.grbRequest2.Controls.Add(Me.btnCustomerDialog)
            Me.grbRequest2.Controls.Add(Me.lblCustomer)
            Me.grbRequest2.Controls.Add(Me.btnCustomerPanel)
            Me.grbRequest2.Controls.Add(Me.txtCustomerCode)
            Me.grbRequest2.Controls.Add(Me.txtCustomerName)
            Me.grbRequest2.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.grbRequest2.Location = New System.Drawing.Point(392, 200)
            Me.grbRequest2.Name = "grbRequest2"
            Me.grbRequest2.Size = New System.Drawing.Size(392, 48)
            Me.grbRequest2.TabIndex = 2
            Me.grbRequest2.TabStop = False
            Me.grbRequest2.Text = "ผู้ขอเบิก"
            '
            'AssetWithdrawDetail
            '
            Me.Controls.Add(Me.tgWBS)
            Me.Controls.Add(Me.ibtnAddWBS)
            Me.Controls.Add(Me.ibtnDelWBS)
            Me.Controls.Add(Me.lblWBS)
            Me.Controls.Add(Me.tgItem)
            Me.Controls.Add(Me.grbGeneral)
            Me.Controls.Add(Me.lblStatus)
            Me.Controls.Add(Me.ibtnBlank)
            Me.Controls.Add(Me.ibtnDelRow)
            Me.Controls.Add(Me.grbReceive)
            Me.Controls.Add(Me.lblItem)
            Me.Controls.Add(Me.grbRequest2)
            Me.Controls.Add(Me.grbRequest)
            Me.Controls.Add(Me.chkExternal)
            Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Name = "AssetWithdrawDetail"
            Me.Size = New System.Drawing.Size(800, 512)
            Me.grbReceive.ResumeLayout(False)
            Me.grbRequest.ResumeLayout(False)
            Me.grbGeneral.ResumeLayout(False)
            CType(Me.tgItem, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.tgWBS, System.ComponentModel.ISupportInitialize).EndInit()
            Me.grbRequest2.ResumeLayout(False)
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

#Region " SetLabelText "
        Public Overrides Sub SetLabelText()
            If Not m_entity Is Nothing Then Me.Text = Me.StringParserService.Parse(Me.m_entity.TabPageText)
            Me.lblCode.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AssetWithdrawDetail.lblCode}")
            Me.Validator.SetDisplayName(txtCode, lblCode.Text)

            Me.lblDocDate.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AssetWithdrawDetail.lblDocDate}")
            Me.Validator.SetDisplayName(txtDocDate, lblDocDate.Text)

            Me.lblItem.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AssetWithdrawDetail.lblItem}")

            Me.lblNote.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AssetWithdrawDetail.lblNote}")
            Me.Validator.SetDisplayName(txtNote, lblNote.Text)

            Me.lblRequestPerson.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AssetWithdrawDetail.lblRequestPerson}")

            Me.lblStoreperson.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AssetWithdrawDetail.lblStoreperson}")
            Me.Validator.SetDisplayName(txtStorepersonCode, lblStoreperson.Text)

            Me.lblStoreCC.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AssetWithdrawDetail.lblStoreCC}")
            Me.Validator.SetDisplayName(txtStoreCCCode, lblStoreCC.Text)

            Me.lblWithdraw.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AssetWithdrawDetail.lblWithdraw}")
            'If Not chkExternal.Checked Then
            Me.Validator.SetDisplayName(txtWithdrawPersonCode, lblRequestPerson.Text)
            Me.Validator.SetDisplayName(txtWithdrawCCCode, lblWithdraw.Text)
            'End If

            Me.lblCustomer.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AssetWithdrawDetail.lblCustomer}")
            Me.Validator.SetDisplayName(txtCustomerCode, lblCustomer.Text)
            Me.chkExternal.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AssetWithdrawDetail.chkExternal}")

            Me.grbRequest2.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AssetWithdrawDetail.grbRequest2}")

            Me.grbGeneral.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AssetWithdrawDetail.grbGeneral}")
            Me.grbRequest.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AssetWithdrawDetail.grbRequest}")
            Me.grbReceive.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AssetWithdrawDetail.grbReceive}")
        End Sub
#End Region

#Region " Members "
        Private m_entity As AssetWithdraw
        Private m_isInitialized As Boolean = False
        Private m_treeManager As TreeManager
        Private m_tableStyleEnable As Hashtable
        'Private m_customer As Customer
        Private m_treeManager2 As TreeManager
        Private m_wbsdInitialized As Boolean
#End Region

#Region " Constructors "
        Public Sub New()
            MyBase.New()
            Me.InitializeComponent()
            Me.SetLabelText()
            Initialize()

            Dim dt As TreeTable = AssetWithdraw.GetSchemaTable()
            Dim dst As DataGridTableStyle = Me.CreateTableStyle()
            m_treeManager = New TreeManager(dt, tgItem)
            m_treeManager.SetTableStyle(dst)
            m_treeManager.AllowSorting = False
            m_treeManager.AllowDelete = False
            tgItem.AllowNew = False

            AddHandler dt.ColumnChanging, AddressOf ItemTreetable_ColumnChanging
            AddHandler dt.ColumnChanged, AddressOf ItemTreetable_ColumnChanged
            AddHandler dt.RowDeleted, AddressOf dtItemDelete

            Dim dt2 As TreeTable = WBSDistribute.GetSchemaTable()
            Dim dst2 As DataGridTableStyle = Me.CreateTableStyle2()
            m_treeManager2 = New TreeManager(dt2, tgWBS)
            m_treeManager2.SetTableStyle(dst2)
            m_treeManager2.AllowSorting = False
            m_treeManager2.AllowDelete = False

            AddHandler dt2.ColumnChanging, AddressOf Treetable_ColumnChanging
            AddHandler dt2.ColumnChanged, AddressOf Treetable_ColumnChanged
            AddHandler dt2.RowDeleted, AddressOf ItemDelete

            EventWiring()
        End Sub
#End Region

#Region " Style "
        Public Function CreateTableStyle2() As DataGridTableStyle
            Dim dst As New DataGridTableStyle
            dst.MappingName = "WBS"
            Dim myStringParserService As StringParserService = CType(ServiceManager.Services.GetService(GetType(StringParserService)), StringParserService)

            Dim csLineNumber As New TreeTextColumn
            csLineNumber.MappingName = "LineNumber"
            csLineNumber.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.GoodsReceiptDetail.LineNumberHeaderText}")
            csLineNumber.NullText = ""
            csLineNumber.Width = 30
            csLineNumber.DataAlignment = HorizontalAlignment.Center
            csLineNumber.ReadOnly = True
            csLineNumber.TextBox.Name = "LineNumber"

            Dim csCostCenter As New TreeTextColumn
            csCostCenter.MappingName = "CostCenter"
            csCostCenter.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.GoodsReceiptDetail.CCHeaderText}")
            csCostCenter.NullText = ""
            csCostCenter.Width = 100
            csCostCenter.ReadOnly = True
            csCostCenter.TextBox.Name = "CostCenter"

            Dim csCCButton As New DataGridButtonColumn
            csCCButton.MappingName = "CCButton"
            csCCButton.HeaderText = ""
            csCCButton.NullText = ""

            Dim csWBS As New TreeTextColumn
            csWBS.MappingName = "WBS"
            csWBS.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.GoodsReceiptDetail.WBSHeaderText}")
            csWBS.NullText = ""
            csWBS.Width = 100
            csWBS.ReadOnly = True
            csWBS.TextBox.Name = "WBS"

            Dim csButton As New DataGridButtonColumn
            csButton.MappingName = "Button"
            csButton.HeaderText = ""
            csButton.NullText = ""
            AddHandler csButton.Click, AddressOf WBStgButtonClicked

            Dim csPercent As New TreeTextColumn
            csPercent.MappingName = "Percent"
            csPercent.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.GoodsReceiptDetail.PercentHeaderText}")
            csPercent.NullText = ""
            csPercent.DataAlignment = HorizontalAlignment.Right
            csPercent.Format = "#,###.##"
            csPercent.Width = 70
            csPercent.TextBox.Name = "Percent"

            Dim csAmount As New TreeTextColumn
            csAmount.MappingName = "Amount"
            csAmount.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.GoodsReceiptDetail.AmoluntHeaderText}")
            csAmount.NullText = ""
            csAmount.Alignment = HorizontalAlignment.Right
            csAmount.DataAlignment = HorizontalAlignment.Right
            csAmount.Format = "#,###.##"
            csAmount.TextBox.Name = "Amount"
            csAmount.ReadOnly = True

            Dim csBudgetRemain As New TreeTextColumn(5, True)
            csBudgetRemain.MappingName = "BudgetRemain"
            csBudgetRemain.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.GoodsReceiptDetail.BudgetRemainHeaderText}")
            csBudgetRemain.NullText = ""
            csBudgetRemain.Alignment = HorizontalAlignment.Right
            csBudgetRemain.DataAlignment = HorizontalAlignment.Right
            csBudgetRemain.Format = "#,###.##"
            csBudgetRemain.TextBox.Name = "BudgetRemain"
            csBudgetRemain.ReadOnly = True
            AddHandler csBudgetRemain.CheckCellHilighted, AddressOf SetHilightValues

            Dim csQtyRemain As New TreeTextColumn(6, True)
            csQtyRemain.MappingName = "QtyRemain"
            csQtyRemain.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.GoodsReceiptDetail.QtyRemainHeaderText}")
            csQtyRemain.NullText = ""
            csQtyRemain.Alignment = HorizontalAlignment.Right
            csQtyRemain.DataAlignment = HorizontalAlignment.Right
            csQtyRemain.Format = "#,###.##"
            csQtyRemain.TextBox.Name = "QtyRemain"
            csQtyRemain.ReadOnly = True
            AddHandler csQtyRemain.CheckCellHilighted, AddressOf SetHilightValues

            dst.GridColumnStyles.Add(csLineNumber) '0
            dst.GridColumnStyles.Add(csCostCenter)
            dst.GridColumnStyles.Add(csCCButton)
            dst.GridColumnStyles.Add(csWBS) '1
            dst.GridColumnStyles.Add(csButton) '2
            dst.GridColumnStyles.Add(csPercent) '3
            dst.GridColumnStyles.Add(csAmount) '4
            dst.GridColumnStyles.Add(csBudgetRemain) '5
            'dst.GridColumnStyles.Add(csQtyRemain) '6

            For Each colStyle As DataGridColumnStyle In dst.GridColumnStyles
                m_tableStyleEnable.Add(colStyle, colStyle.ReadOnly)
            Next
            Return dst
        End Function
        Public Sub WBStgButtonClicked(ByVal e As ButtonColumnEventArgs)
            If e.Column = 4 Then
                Me.WBSButtonClicked(e)
            Else
                Me.CCButtonClicked(e)
            End If
        End Sub
        Public Sub SetHilightValues(ByVal sender As Object, ByVal e As DataGridHilightEventArgs)
            e.HilightValue = False
            e.RedText = False
            Dim i As Integer = 0
            For Each row As DataRow In Me.m_treeManager2.Treetable.Rows
                For Each col As DataColumn In Me.m_treeManager2.Treetable.Columns
                    If col.Ordinal > 0 Then
                        If Not row.IsNull(col) AndAlso IsNumeric(row(col)) Then
                            If CDec(row(col)) < 0 Then
                                If e.Column = col.Ordinal And e.Row = i Then
                                    'e.HilightValue = True
                                    e.RedText = True
                                End If
                            End If
                        End If
                    End If
                Next
                i += 1
            Next
        End Sub
        Public Sub CCButtonClicked(ByVal e As ButtonColumnEventArgs)
            If Me.m_entity Is Nothing Then
                Return
            End If
            If Me.m_entity.WithdrawCostcenter Is Nothing Then
                Return
            End If
            If Me.m_entity.WithdrawCostcenter.BoqId = 0 Then
                Return
            End If
            Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
            Dim entity As New CostCenter
            Dim entities As New ArrayList
            myEntityPanelService.OpenListDialog(entity, AddressOf SetCostCenter)
        End Sub
        Private Sub SetCostCenter(ByVal myEntity As ISimpleEntity)
            Dim doc As AssetWithdrawItem = Me.CurrentItem
            If doc Is Nothing Then
                Return
            End If
            Dim dt As TreeTable = Me.m_treeManager2.Treetable
            Dim wsdColl As WBSDistributeCollection = doc.WBSDistributeCollection
            Dim row As TreeRow = Me.m_treeManager2.SelectedRow
            If TypeOf myEntity Is CostCenter Then
                CType(row.Tag, WBSDistribute).CostCenter = CType(myEntity, CostCenter)
                CType(row.Tag, WBSDistribute).WBS = New WBS
            End If
            Dim view As Integer = 45
            m_wbsdInitialized = False
            wsdColl.Populate(dt, doc, view)
            m_wbsdInitialized = True
            Me.WorkbenchWindow.ViewContent.IsDirty = True
        End Sub
        Dim m_wbsColl As WBSCollection
        Dim m_mrkColl As MarkupCollection
        Public Sub WBSButtonClicked(ByVal e As ButtonColumnEventArgs)
            If Me.m_entity Is Nothing Then
                Return
            End If
            If Me.m_entity.WithdrawCostcenter Is Nothing Then
                Return
            End If
            If Me.m_entity.WithdrawCostcenter.BoqId = 0 Then
                Return
            End If
            Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
            Dim entity As New WBS
            Dim filters() As Filter
            Dim row As TreeRow = Me.m_treeManager2.SelectedRow
            Dim myBOQId As Integer
            If Not CType(row.Tag, WBSDistribute).CostCenter Is Nothing AndAlso CType(row.Tag, WBSDistribute).CostCenter.BoqId > 0 Then
                myBOQId = CType(row.Tag, WBSDistribute).CostCenter.BoqId
            Else
                myBOQId = Me.m_entity.WithdrawCostcenter.BoqId
                CType(row.Tag, WBSDistribute).CostCenter = Me.m_entity.WithdrawCostcenter
            End If
            If m_wbsColl Is Nothing OrElse m_wbsColl.Boq.Id <> myBOQId Then
                m_wbsColl = New WBSCollection(myBOQId)
            End If
            If m_mrkColl Is Nothing OrElse m_mrkColl.Boq.Id <> myBOQId Then
                m_mrkColl = New MarkupCollection(myBOQId)
            End If
            'If m_wbsColl Is Nothing OrElse m_wbsColl.Boq.Id <> Me.m_entity.WithdrawCostcenter.BoqId Then
            '    m_wbsColl = New WBSCollection(Me.m_entity.WithdrawCostcenter.BoqId)
            'End If
            'If m_mrkColl Is Nothing OrElse m_mrkColl.Boq.Id <> Me.m_entity.WithdrawCostcenter.BoqId Then
            '    m_mrkColl = New MarkupCollection(Me.m_entity.WithdrawCostcenter.BoqId)
            'End If
            filters = New Filter() {New Filter("mrkColl", m_mrkColl) _
                                    , New Filter("wbsColl", m_wbsColl)}
            Dim entities As New ArrayList
            entities.Add(entity)
            myEntityPanelService.OpenListDialog(entity, AddressOf SetWBS, filters, entities)
        End Sub
        Private Sub SetWBS(ByVal myEntity As ISimpleEntity)
            Dim doc As AssetWithdrawItem = Me.CurrentItem
            If doc Is Nothing Then
                Return
            End If
            Dim dt As TreeTable = Me.m_treeManager2.Treetable
            Dim wsdColl As WBSDistributeCollection = doc.WBSDistributeCollection
            Dim row As TreeRow = Me.m_treeManager2.SelectedRow
            If TypeOf myEntity Is WBS Then
                CType(row.Tag, WBSDistribute).WBS = CType(myEntity, WBS)
                CType(row.Tag, WBSDistribute).IsMarkup = False
            ElseIf TypeOf myEntity Is Markup Then
                Dim newWBS As New WBS
                Dim myMarkup As Markup = CType(myEntity, Markup)
                newWBS.Id = myMarkup.Id
                newWBS.Code = myMarkup.Code
                newWBS.Name = myMarkup.Name
                CType(row.Tag, WBSDistribute).WBS = newWBS
                CType(row.Tag, WBSDistribute).IsMarkup = True
            End If
            Dim view As Integer = 45
            m_wbsdInitialized = False
            wsdColl.Populate(dt, doc, view)
            m_wbsdInitialized = True
            Me.WorkbenchWindow.ViewContent.IsDirty = True
        End Sub
        Private ReadOnly Property CurrentWsbsd() As WBSDistribute
            Get
                Dim row As TreeRow = Me.m_treeManager2.SelectedRow
                If row Is Nothing Then
                    Return Nothing
                End If
                Return CType(row.Tag, WBSDistribute)
            End Get
        End Property
        Protected Function CreateTableStyle() As DataGridTableStyle
            Dim dst As New DataGridTableStyle
            dst.MappingName = "AssetWithdraw"
            Dim myStringParserService As StringParserService = CType(ServiceManager.Services.GetService(GetType(StringParserService)), StringParserService)

            Dim csLineNumber As New TreeTextColumn
            csLineNumber.MappingName = "Linenumber"
            csLineNumber.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AssetWithdrawDetail.LineNumberHeaderText}")
            csLineNumber.NullText = ""
            csLineNumber.Width = 30
            csLineNumber.Alignment = HorizontalAlignment.Center
            csLineNumber.DataAlignment = HorizontalAlignment.Center
            csLineNumber.ReadOnly = True

            Dim csCode As New TreeTextColumn
            csCode.MappingName = "Code"
            csCode.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AssetWithdrawDetail.CodeHeaderText}")
            csCode.NullText = ""
            csCode.Width = 100
            csCode.Alignment = HorizontalAlignment.Center
            csCode.DataAlignment = HorizontalAlignment.Left
            csCode.ReadOnly = False
            csCode.TextBox.Name = "Code"

            Dim csType As DataGridComboColumn
            csType = New DataGridComboColumn("TYPE" _
            , CodeDescription.GetCodeList("stocki_enitytype", "code_value in (28,19)") _
            , "code_description", "code_value")
            csType.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.POPanelView.TypeHeaderText}")
            csType.NullText = String.Empty

            Dim csButton As New DataGridButtonColumn
            csButton.MappingName = "button"
            csButton.HeaderText = ""
            csButton.NullText = ""
            AddHandler csButton.Click, AddressOf GridButton_Clicked

            Dim csName As New TreeTextColumn
            csName.MappingName = "Name"
            csName.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AssetWithdrawDetail.NameHeaderText}")
            csName.NullText = ""
            csName.Alignment = HorizontalAlignment.Center
            csName.DataAlignment = HorizontalAlignment.Left
            csName.Width = 180
            csName.ReadOnly = True

            Dim csQty As New TreeTextColumn
            csQty.MappingName = "QTY"
            csQty.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.POPanelView.QtyHeaderText}")
            csQty.NullText = ""
            csQty.DataAlignment = HorizontalAlignment.Right
            csQty.Format = "#,###"
            csQty.TextBox.Name = "Qty"

            Dim csNote As New TreeTextColumn
            csNote.MappingName = "Note"
            csNote.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AssetWithdrawDetail.NoteHeaderText}")
            csNote.NullText = ""
            csNote.Alignment = HorizontalAlignment.Center
            csNote.DataAlignment = HorizontalAlignment.Left
            csNote.Width = 200
            csNote.ReadOnly = False

            ' Fill Column Style
            dst.GridColumnStyles.Add(csLineNumber)
            dst.GridColumnStyles.Add(csType)
            dst.GridColumnStyles.Add(csCode)
            dst.GridColumnStyles.Add(csButton)
            dst.GridColumnStyles.Add(csName)
            dst.GridColumnStyles.Add(csQty)
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

#Region "Properties"
        Private ReadOnly Property CurrentItem() As AssetWithdrawItem
            Get
                Dim row As TreeRow = Me.m_treeManager.SelectedRow
                If row Is Nothing Then
                    Return Nothing
                End If
                If Not TypeOf row.Tag Is AssetWithdrawItem Then
                    Return Nothing
                End If
                Return CType(row.Tag, AssetWithdrawItem)
            End Get
        End Property
#End Region

#Region "ItemTreeTable Handlers"
        Private Sub ItemTreetable_ColumnChanged(ByVal sender As Object, ByVal e As System.Data.DataColumnChangeEventArgs)
            If Not m_isInitialized Then
                Return
            End If
            Me.WorkbenchWindow.ViewContent.IsDirty = True
            Dim index As Integer = Me.tgItem.CurrentRowIndex
            RefreshDocs()
            tgItem.CurrentRowIndex = index
        End Sub
        Private Sub ItemTreetable_ColumnChanging(ByVal sender As Object, ByVal e As System.Data.DataColumnChangeEventArgs)
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
            Dim doc As AssetWithdrawItem = Me.CurrentItem
            If doc Is Nothing Then
                doc = New AssetWithdrawItem
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
                    Case "qty"
                        If IsDBNull(e.ProposedValue) Then
                            e.ProposedValue = ""
                        End If
                        Dim value As Integer = CInt(TextParser.Evaluate(e.ProposedValue.ToString))
                        doc.Qty = value
                    Case "type"
                        Dim value As ItemType
                        If IsNumeric(e.ProposedValue) Then
                            value = New ItemType(CInt(e.ProposedValue))
                        End If
                        doc.ItemType = value
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
        Private Sub dtItemDelete(ByVal sender As Object, ByVal e As System.Data.DataRowChangeEventArgs)
        End Sub
#End Region

#Region "TreeTable Handlers"
        Private Sub Treetable_ColumnChanged(ByVal sender As Object, ByVal e As System.Data.DataColumnChangeEventArgs)
            If Not m_wbsdInitialized Then
                Return
            End If
            Dim index As Integer = Me.m_treeManager2.Treetable.Childs.IndexOf(CType(e.Row, TreeRow))
            If ValidateRow(CType(e.Row, TreeRow)) Then
                'UpdateAmount(e)
                Me.m_treeManager2.Treetable.AcceptChanges()
            End If
            RefreshWBS()
            Me.WorkbenchWindow.ViewContent.IsDirty = True
        End Sub
        Private Sub UpdateAmount(ByVal e As DataColumnChangeEventArgs)
            Dim item As WBSDistribute = Me.CurrentWsbsd
            If item Is Nothing Then
                Return
            End If
            Dim view As Integer = 45
            Dim doc As AssetWithdrawItem = Me.CurrentItem
            If doc Is Nothing Then
                Return
            End If
            e.Row("Amount") = Configuration.FormatToString(item.Percent * doc.Amount / 100, DigitConfig.Price)
            If Not item.IsMarkup Then
                e.Row("BudgetRemain") = Configuration.FormatToString(item.WBS.GetTotal - item.WBS.GetActualTotal(Me.m_entity, view) + Me.m_entity.GetCurrentAmountForWBS(item.WBS, Nothing), DigitConfig.Price)
                e.Row("QtyRemain") = Configuration.FormatToString(0 - item.WBS.GetActualTotalQty(Me.m_entity, view) - 0, DigitConfig.Price)
            Else
                Dim mk As Markup = Me.m_entity.WithdrawCostcenter.Boq.MarkupCollection.GetMarkupFromId(item.WBS.Id)
                If Not mk Is Nothing Then
                    e.Row("BudgetRemain") = Configuration.FormatToString(mk.TotalAmount - mk.GetActualTotal(Me.m_entity, view) - Me.m_entity.GetCurrentAmountForMarkup(mk), DigitConfig.Price)
                End If
            End If
        End Sub
        Private Sub Treetable_ColumnChanging(ByVal sender As Object, ByVal e As System.Data.DataColumnChangeEventArgs)
            If Not m_wbsdInitialized Then
                Return
            End If
            Try
                Select Case e.Column.ColumnName.ToLower
                    Case "wbs"
                        SetCode(e)
                    Case "percent"
                        SetPercent(e)
                End Select
                ValidateRow(e)
            Catch ex As Exception
                MessageBox.Show(ex.ToString)
            End Try
        End Sub
        Public Sub ValidateRow(ByVal e As DataColumnChangeEventArgs)
            Dim wbs As Object = e.Row("wbs")
            Dim percent As Object = e.Row("percent")

            Select Case e.Column.ColumnName.ToLower
                Case "wbs"
                    wbs = e.ProposedValue
                Case "percent"
                    percent = e.ProposedValue
                Case Else
                    Return
            End Select

            Dim isBlankRow As Boolean = False
            If IsDBNull(wbs) Then
                isBlankRow = True
            End If

            If Not isBlankRow Then
                If IsDBNull(percent) OrElse CDec(percent) <= 0 Then
                    e.Row.SetColumnError("percent", Me.StringParserService.Parse("${res:Global.Error.PercentMissing}"))
                Else
                    e.Row.SetColumnError("percent", "")
                End If
                If IsDBNull(wbs) OrElse wbs.ToString.Length = 0 Then
                    e.Row.SetColumnError("wbs", Me.StringParserService.Parse("${res:Global.Error.WBSMissing}"))
                Else
                    e.Row.SetColumnError("wbs", "")
                End If
            End If

        End Sub
        Public Function ValidateRow(ByVal row As TreeRow) As Boolean
            If row.IsNull("WBS") Then
                Return False
            End If
            Return True
        End Function
        Private m_updating As Boolean = False
        Public Sub SetPercent(ByVal e As DataColumnChangeEventArgs)
            If m_updating Then
                Return
            End If
            Dim item As WBSDistribute = Me.CurrentWsbsd
            If item Is Nothing Then
                Return
            End If
            If IsDBNull(e.ProposedValue) OrElse e.ProposedValue.ToString.Length = 0 Then
                e.ProposedValue = ""
                Return
            End If
            e.ProposedValue = Configuration.FormatToString(CDec(TextParser.Evaluate(e.ProposedValue.ToString)), DigitConfig.Price)
            Dim value As Decimal = CDec(e.ProposedValue)
            Dim oldvalue As Decimal = 0
            If Not e.Row.IsNull(e.Column) Then
                oldvalue = CDec(e.Row(e.Column))
            End If
            Dim doc As AssetWithdrawItem = Me.CurrentItem
            If doc Is Nothing Then
                Return
            End If
            Dim wsdColl As WBSDistributeCollection = doc.WBSDistributeCollection
            If wsdColl.GetSumPercent - oldvalue + value > 100 Then
                e.ProposedValue = e.Row(e.Column)
                Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
                msgServ.ShowMessage("${res:Global.Error.WBSPercentExceed100}")
                Return
            End If

            m_updating = True
            item.Percent = value
            m_updating = False
        End Sub
        'Private Function DupCode(ByVal e As DataColumnChangeEventArgs) As Boolean
        '    If e.Row.IsNull("stocki_entityType") Then
        '        Return False
        '    End If
        '    If IsDBNull(e.ProposedValue) Then
        '        Return False
        '    End If
        '    For Each row As TreeRow In Me.ItemTable.Childs
        '        If Not row Is e.Row Then
        '            If Not row.IsNull("stocki_entityType") Then
        '                If CInt(row("stocki_entityType")) = CInt(e.Row("stocki_entityType")) Then
        '                    If Not row.IsNull("code") Then
        '                        If e.ProposedValue.ToString.ToLower = row("code").ToString.ToLower Then
        '                            Return True
        '                        End If
        '                    End If
        '                End If
        '            End If
        '        End If
        '    Next
        '    Return False
        'End Function
        Public Sub SetCode(ByVal e As System.Data.DataColumnChangeEventArgs)
            'If m_updating Then
            '    Return
            'End If
            'm_updating = True
            'Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
            'If e.Row.IsNull("stocki_entityType") Then
            '    msgServ.ShowMessage("${res:Global.Error.NoItemType}")
            '    e.ProposedValue = e.Row(e.Column)
            '    m_updating = False
            '    Return
            'End If
            'If DupCode(e) Then
            '    Dim item As New AssetWithdrawItem
            '    item.CopyFromDataRow(CType(e.Row, TreeRow))
            '    msgServ.ShowMessageFormatted("${res:Global.Error.AlreadyHasCode}", New String() {item.ItemType.Description, e.ProposedValue.ToString})
            '    e.ProposedValue = e.Row(e.Column)
            '    m_updating = False
            '    Return
            'End If
            'Select Case CInt(e.Row("stocki_entityType"))
            '    Case 0 'Blank
            '        msgServ.ShowMessage("${res:Global.Error.BlankItemCannotHaveCode}")
            '        e.ProposedValue = e.Row(e.Column)
            '        m_updating = False
            '        Return
            '    Case 28 'F/A
            '        msgServ.ShowMessage("${res:Global.Error.FACannotHaveCode}")
            '        e.ProposedValue = e.Row(e.Column)
            '        m_updating = False
            '        Return
            '    Case 19 'Tool
            '        If e.ProposedValue.ToString.Length = 0 Then
            '            If e.Row(e.Column).ToString.Length <> 0 Then
            '                If msgServ.AskQuestionFormatted("${res:Global.Question.DeleteToolDetail}", New String() {e.Row(e.Column).ToString}) Then
            '                    ClearRow(e)
            '                Else
            '                    e.ProposedValue = e.Row(e.Column)
            '                End If
            '            End If
            '            m_updating = False
            '            Return
            '        End If
            '        Dim myTool As New Tool(e.ProposedValue.ToString)
            '        If Not myTool.Originated Then
            '            msgServ.ShowMessageFormatted("${res:Global.Error.NoTool}", New String() {e.ProposedValue.ToString})
            '            e.ProposedValue = e.Row(e.Column)
            '            m_updating = False
            '            Return
            '        Else
            '            Dim myUnit As Unit = myTool.Unit
            '            e.Row("stocki_entity") = myTool.Id
            '            e.ProposedValue = myTool.Code
            '            e.Row("stocki_itemName") = myTool.Name
            '            If Not myUnit Is Nothing AndAlso myUnit.Originated Then
            '                e.Row("stocki_unit") = myUnit.Id
            '                e.Row("Unit") = myUnit.Name
            '            Else
            '                e.Row("stocki_unit") = DBNull.Value
            '                e.Row("Unit") = DBNull.Value
            '            End If
            '            Dim ga As GeneralAccount = GeneralAccount.GetGAForEntity(myTool.EntityId, Me.EntityId)
            '            If Not ga.Account Is Nothing AndAlso ga.Account.Originated Then
            '                e.Row("stocki_acct") = ga.Account.Id
            '                e.Row("AccountCode") = ga.Account.Code
            '                e.Row("Account") = ga.Account.Name & "<" & Me.StringParserService.Parse("${res:Global.Default}") & ">"
            '            Else
            '                e.Row("stocki_acct") = DBNull.Value
            '                e.Row("AccountCode") = DBNull.Value
            '                e.Row("Account") = DBNull.Value
            '            End If
            '        End If
            '    Case 42 'LCI
            '        If e.ProposedValue.ToString.Length = 0 Then
            '            If e.Row(e.Column).ToString.Length <> 0 Then
            '                If msgServ.AskQuestionFormatted("${res:Global.Question.DeleteLCIDetail}", New String() {e.Row(e.Column).ToString}) Then
            '                    ClearRow(e)
            '                Else
            '                    e.ProposedValue = e.Row(e.Column)
            '                End If
            '            End If
            '            m_updating = False
            '            Return
            '        End If
            '        Dim lci As New LCIItem(e.ProposedValue.ToString)
            '        If Not lci.Originated Then
            '            msgServ.ShowMessageFormatted("${res:Global.Error.NoLCI}", New String() {e.ProposedValue.ToString})
            '            e.ProposedValue = e.Row(e.Column)
            '            m_updating = False
            '            Return
            '        Else
            '            Dim myUnit As Unit = lci.DefaultUnit
            '            e.Row("stocki_entity") = lci.Id
            '            e.ProposedValue = lci.Code
            '            e.Row("stocki_itemName") = lci.Name
            '            If Not myUnit Is Nothing AndAlso myUnit.Originated Then
            '                e.Row("stocki_unit") = myUnit.Id
            '                e.Row("Unit") = myUnit.Name
            '            Else
            '                e.Row("stocki_unit") = DBNull.Value
            '                e.Row("Unit") = DBNull.Value
            '            End If
            '            If Not lci.Account Is Nothing AndAlso lci.Account.Originated Then
            '                e.Row("stocki_acct") = lci.Account.Id
            '                e.Row("AccountCode") = lci.Account.Code
            '                e.Row("Account") = lci.Account.Name & "<" & Me.StringParserService.Parse("${res:Global.Default}") & ">"
            '            Else
            '                e.Row("stocki_acct") = DBNull.Value
            '                e.Row("AccountCode") = DBNull.Value
            '                e.Row("Account") = DBNull.Value
            '            End If
            '        End If
            '    Case Else
            '        msgServ.ShowMessage("${res:Global.Error.NoItemType}")
            '        e.ProposedValue = e.Row(e.Column)
            '        m_updating = False
            '        Return
            'End Select
            'e.Row("stocki_qty") = Configuration.FormatToString(1D, DigitConfig.Qty)
            'm_updating = False
        End Sub
        Private Sub ItemDelete(ByVal sender As Object, ByVal e As System.Data.DataRowChangeEventArgs)
        End Sub
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
            OrElse m_entityRefed = 1 Then
                For Each ctrl As Control In Me.Controls
                    ctrl.Enabled = False
                Next

                tgItem.Enabled = True
                For Each colStyle As DataGridColumnStyle In Me.m_treeManager.GridTableStyle.GridColumnStyles
                    colStyle.ReadOnly = True
                Next

                'ปลด lock WBS
                Me.tgWBS.Enabled = True
                Me.ibtnAddWBS.Enabled = True
                Me.ibtnDelWBS.Enabled = True
            Else
                For Each ctrl As Control In Me.Controls
                    ctrl.Enabled = True
                Next
                For Each colStyle As DataGridColumnStyle In Me.m_treeManager.GridTableStyle.GridColumnStyles
                    colStyle.ReadOnly = CBool(m_tableStyleEnable(colStyle))
                Next
            End If
            SetIsExternal()
            CheckWBSRight()
        End Sub
        Private Sub CheckWBSRight()
            Dim secSrv As SecurityService = CType(ServiceManager.Services.GetService(GetType(SecurityService)), SecurityService)
            Dim level As Integer = secSrv.GetAccess(256)
            Dim checkString As String = BinaryHelper.DecToBin(level, 5)
            checkString = BinaryHelper.RevertString(checkString)
            If Not CBool(checkString.Substring(0, 1)) Then
                'ห้ามเห็น
                Me.lblWBS.Visible = False
                Me.tgWBS.Visible = False
                Me.ibtnAddWBS.Visible = False
                Me.ibtnDelWBS.Visible = False
            ElseIf Not CBool(checkString.Substring(1, 1)) Then
                'ห้ามแก้
                Me.lblWBS.Visible = True
                Me.tgWBS.Visible = True
                Me.ibtnAddWBS.Visible = True
                Me.ibtnDelWBS.Visible = True

                Me.tgWBS.Enabled = False
                Me.ibtnAddWBS.Enabled = False
                Me.ibtnDelWBS.Enabled = False
            Else
                Me.lblWBS.Visible = True
                Me.tgWBS.Visible = True
                Me.ibtnAddWBS.Visible = True
                Me.ibtnDelWBS.Visible = True

                Me.tgWBS.Enabled = True
                Me.ibtnAddWBS.Enabled = True
                Me.ibtnDelWBS.Enabled = True
            End If
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
            Me.dtpDocDate.Value = Now
            chkExternal.Checked = False
        End Sub
        ' Addhandler events
        Protected Overrides Sub EventWiring()
            AddHandler txtCode.TextChanged, AddressOf Me.ChangeProperty
            AddHandler txtNote.TextChanged, AddressOf Me.ChangeProperty

            AddHandler txtDocDate.Validated, AddressOf Me.ChangeProperty
            AddHandler dtpDocDate.ValueChanged, AddressOf Me.ChangeProperty

            AddHandler chkExternal.CheckedChanged, AddressOf Me.ChangeProperty

            AddHandler txtWithdrawPersonCode.Validated, AddressOf Me.ChangeProperty
            AddHandler txtWithdrawCCCode.Validated, AddressOf Me.ChangeProperty

            AddHandler txtStorepersonCode.Validated, AddressOf Me.TextHandler
            AddHandler txtStorepersonCode.TextChanged, AddressOf Me.ChangeProperty

            AddHandler txtStoreCCCode.Validated, AddressOf Me.TextHandler
            AddHandler txtStoreCCCode.TextChanged, AddressOf Me.ChangeProperty

            AddHandler txtCustomerCode.TextChanged, AddressOf Me.TextHandler
            AddHandler txtCustomerCode.Validated, AddressOf Me.ChangeProperty

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
            ' autogencode
            m_oldCode = m_entity.Code
            Me.chkAutorun.Checked = Me.m_entity.AutoGen
            Me.UpdateAutogenStatus()

            txtDocDate.Text = MinDateToNull(Me.m_entity.DocDate, Me.StringParserService.Parse("${res:Global.BlankDateText}"))
            dtpDocDate.Value = MinDateToNow(Me.m_entity.DocDate)

            'If Not Me.m_entity.Withdrawperson Is Nothing Then
            '    txtWithdrawPersonCode.Text = Me.m_entity.Withdrawperson.Code
            '    If Me.m_entity.IsExternal Then
            '        txtWithdrawPersonName.Text = CType(Me.m_entity.Withdrawperson, Customer).Name
            '    Else
            '        txtWithdrawPersonName.Text = CType(Me.m_entity.Withdrawperson, Employee).Name
            '    End If
            'End If

            'If Not Me.m_entity.Withdrawperson Is Nothing Then
            chkExternal.Checked = Me.m_entity.IsExternal
            If chkExternal.Checked Then
                txtCustomerName.Text = Me.m_entity.Customer.Name
            Else
                txtWithdrawPersonCode.Text = Me.m_entity.Withdrawperson.Code
                txtWithdrawPersonName.Text = Me.m_entity.Withdrawperson.Name
            End If
            'End If

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
            If Not Me.m_entity.Customer Is Nothing Then
                txtCustomerName.Text = Me.m_entity.Customer.Name
                txtCustomerCode.Text = Me.m_entity.Customer.Code
            End If
            ' ChekBox 
            'chkExternal.Checked = Me.m_entity.IsExternal
            SetIsExternal()

            RefreshDocs()

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
            Me.m_treeManager.Treetable.AcceptChanges()
            Me.UpdateAmount()
            Me.m_isInitialized = True

        End Sub
        Private txtcustomercodeChanged As Boolean = False
        Private txtstoreccccodeChanged As Boolean = False
        Private txtstorepersoncodeChanged As Boolean = False
        Private Sub TextHandler(ByVal sender As Object, ByVal e As EventArgs)
            If Me.m_entity Is Nothing OrElse Not m_isInitialized Then
                Return
            End If
            Select Case CType(sender, Control).Name.ToLower
                Case "txtcustomercode"
                    txtcustomercodeChanged = True
                Case "txtstoreccccode"
                    txtstoreccccodeChanged = True
                Case "txtstorepersoncode"
                    txtstorepersoncodeChanged = True
            End Select
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

                Case "chkexternal"
                    Me.m_entity.IsExternal = chkExternal.Checked

                    SetIsExternal()
                    dirtyFlag = True

                Case "txtwithdrawpersoncode"
                    'If Me.m_entity.IsExternal Then
                    '    Dim cust As New Customer
                    '    dirtyFlag = Customer.GetCustomer(txtWithdrawPersonCode, txtWithdrawPersonName, cust)
                    '    Me.m_entity.Withdrawperson = cust
                    'Else
                    Dim emp As New Employee
                    dirtyFlag = Employee.GetEmployee(txtWithdrawPersonCode, txtWithdrawPersonName, emp)
                    Me.m_entity.Withdrawperson = emp
                    'End If

                Case "txtwithdrawcccode"
                    dirtyFlag = CostCenter.GetCostCenter(txtWithdrawCCCode, txtWithdrawCCName, Me.m_entity.WithdrawCostcenter, CType(ServiceManager.Services.GetService(GetType(SecurityService)), SecurityService).CurrentUser.Id)
                Case "txtstorepersoncode"
                    dirtyFlag = Employee.GetEmployee(txtStorepersonCode, txtStorepersonName, Me.m_entity.Storeperson)

                Case "txtstorecccode"
                    Me.m_entity.ItemCollection.Clear()
                    RefreshBlankGrid()

                    dirtyFlag = CostCenter.GetCostCenterWithoutRight(txtStoreCCCode, txtStoreCCName, Me.m_entity.StoreCostcenter)
                Case "txtcustomercode"
                    If txtcustomercodeChanged Then
                        txtcustomercodeChanged = False
                        If Me.m_entity.Customer Is Nothing Then
                            Me.m_entity.Customer = New Customer
                        End If
                        dirtyFlag = Customer.GetCustomer(txtCustomerCode, txtCustomerName, Me.m_entity.Customer)

                    End If

            End Select

            Me.WorkbenchWindow.ViewContent.IsDirty = Me.WorkbenchWindow.ViewContent.IsDirty Or dirtyFlag

            CheckFormEnable()
        End Sub
        Private Sub UpdateAmount()
            Dim i As Integer = 0
            Dim rental As Decimal = 0
            'For Each item As TreeRow In Me.m_entity.ItemTable.Rows
            '    If Me.m_entity.ValidateRow(item) Then
            '        i += 1
            '        If IsNumeric(item("stocki_amt")) Then
            '            rental += CDec(item("stocki_amt"))
            '        End If
            '    End If
            'Next
            RefreshWBS()
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
        Private m_entityRefed As Integer = -1
        Public Overrides Property Entity() As ISimpleEntity
            Get
                Return Me.m_entity
            End Get
            Set(ByVal Value As ISimpleEntity)
                If Not m_entity Is Nothing Then
                    Me.m_entity = Nothing
                End If
                Me.m_entity = CType(Value, AssetWithdraw)
                If Me.m_entity.IsReferenced Then
                    m_entityRefed = 1
                Else
                    m_entityRefed = 0
                End If
                'Hack:
                Me.m_entity.OnTabPageTextChanged(m_entity, EventArgs.Empty)
                UpdateEntityProperties()
            End Set
        End Property

        Public Overrides Sub Initialize()

        End Sub


#End Region

#Region " Event Handlers "
        Private Sub ibtnAddWBS_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnAddWBS.Click
            Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
            If Me.m_entity Is Nothing Then
                Return
            End If
            If Me.m_entity.WithdrawCostcenter Is Nothing Then
                msgServ.ShowMessage("${res:Global.Error.SpecifyCC}")
                Return
            End If
            If Me.m_entity.WithdrawCostcenter.BoqId = 0 Then
                msgServ.ShowMessage("${res:Global.Error.SpecifyCCWithBOQ}")
                Return
            End If
            Dim doc As AssetWithdrawItem = Me.CurrentItem
            If doc Is Nothing Then
                Return
            End If
            Dim dt As TreeTable = Me.m_treeManager2.Treetable
            dt.Clear()
            Dim view As Integer = 45
            Dim wsdColl As WBSDistributeCollection = doc.WBSDistributeCollection
            If wsdColl.GetSumPercent >= 100 Then
                msgServ.ShowMessage("${res:Global.Error.WBSPercentExceed100}")
            Else
                Dim wbsd As New WBSDistribute
                wbsd.CostCenter = Me.m_entity.WithdrawCostcenter
                wbsd.Percent = 100 - wsdColl.GetSumPercent
                wsdColl.Add(wbsd)
            End If
            m_wbsdInitialized = False
            wsdColl.Populate(dt, doc, view)
            m_wbsdInitialized = True
            Me.WorkbenchWindow.ViewContent.IsDirty = True
        End Sub
        'Private Sub txtCustomerCode_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCustomerCode.Validated
        '  Customer.GetCustomer(txtCustomerCode, txtCustomerName, Me.m_customer)
        'End Sub
        Private Sub btnCustomerDialog_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCustomerDialog.Click
            Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
            myEntityPanelService.OpenListDialog(New Customer, AddressOf SetCustomer)
        End Sub
        Private Sub btnCustomerPanel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCustomerPanel.Click
            Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
            myEntityPanelService.OpenPanel(New Customer)
        End Sub
        Private Sub SetCustomer(ByVal e As ISimpleEntity)
            Me.txtCustomerCode.Text = e.Code
            Me.WorkbenchWindow.ViewContent.IsDirty = Customer.GetCustomer(txtCustomerCode, txtCustomerName, Me.m_entity.Customer)

        End Sub
        Private Sub ibtnDelWBS_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnDelWBS.Click
            Dim dt As TreeTable = Me.m_treeManager2.Treetable
            dt.Clear()
            Dim doc As AssetWithdrawItem = Me.CurrentItem
            If doc Is Nothing Then
                Return
            End If
            Dim wsdColl As WBSDistributeCollection = doc.WBSDistributeCollection
            If wsdColl.Count > 0 Then
                wsdColl.Remove(wsdColl.Count - 1)
                Me.WorkbenchWindow.ViewContent.IsDirty = True
            End If
            Dim view As Integer = 45
            m_wbsdInitialized = False
            wsdColl.Populate(dt, doc, view)
            m_wbsdInitialized = True
        End Sub
        Private currentY As Integer
        Private Sub tgItem_CurrentCellChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tgItem.CurrentCellChanged
            If tgItem.CurrentRowIndex <> currentY Then
                RefreshWBS()
                currentY = tgItem.CurrentRowIndex
            End If
        End Sub
        Private Sub RefreshWBS()
            Dim dt As TreeTable = Me.m_treeManager2.Treetable
            dt.Clear()
            If Me.CurrentItem Is Nothing Then
                Return
            End If
            Dim item As AssetWithdrawItem = Me.CurrentItem
            Dim wsdColl As WBSDistributeCollection = item.WBSDistributeCollection
            Dim view As Integer = 45
            m_wbsdInitialized = False
            wsdColl.Populate(dt, item, view)
            m_wbsdInitialized = True
        End Sub
        Private Function GenIDListFromDataTable(ByVal type As Integer) As String
            Dim idlist As String = ""
            For Each item As AssetWithdrawItem In Me.m_entity.ItemCollection
                If Not item.Entity Is Nothing AndAlso item.Entity.Id <> 0 AndAlso Not item.ItemType Is Nothing AndAlso item.ItemType.Value = type Then
                    idlist &= "|" & CStr(item.Entity.Id) & "|"
                End If
            Next
            Return idlist
        End Function
        Public Sub EntityButton_Click(ByVal e As ButtonColumnEventArgs)

            If Not Me.m_entity.StoreCostcenter.Originated Then
                Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
                msgServ.ShowErrorFormatted("${res:Global.MustDefine}", lblStoreCC.Text)
                txtStoreCCCode.Focus()
                Return
            End If

            Dim myEntityPanelService As IEntityPanelService = _
                CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
            Dim doc As AssetWithdrawItem = Me.CurrentItem
            If doc Is Nothing Then
                doc = New AssetWithdrawItem
                doc.ItemType = New ItemType(0)
                Me.m_entity.ItemCollection.Add(doc)
                Me.m_treeManager.SelectedRow.Tag = doc
            End If


            Dim arr(2) As Filter
            arr(0) = New Filter("isWithdraw", True)
            arr(1) = New Filter("IDList", GenIDListFromDataTable(28))
            arr(2) = New Filter("assettype_canberented", True)

            Dim filters(1)() As Filter
            filters(0) = arr
            filters(1) = Nothing

            Dim filterentities(1) As ArrayList
            filterentities(0) = New ArrayList
            Dim obj As New Asset
            obj.Costcenter = Me.m_entity.StoreCostcenter
            obj.Status.Value = 1   'ว่าง
            filterentities(0).Add(obj)
            Dim t As New ToolForSelection
            t.CC = Me.m_entity.FromCC
            t.FromWip = False

            filterentities(1) = New ArrayList
            filterentities(1).Add(t)

            Dim entities(1) As ISimpleEntity
            entities(0) = obj
            entities(1) = t
            Dim activeIndex As Integer = -1
            If Not doc.ItemType Is Nothing Then
                If doc.ItemType.Value = 19 Then
                    activeIndex = 1
                ElseIf doc.ItemType.Value = 28 Then
                    activeIndex = 0
                End If
            End If

            myEntityPanelService.OpenListDialog(entities, AddressOf SetItems, filters, filterentities, activeIndex)
        End Sub

        Private Sub SetItems(ByVal items As BasketItemCollection)
            Dim index As Integer = tgItem.CurrentRowIndex
            For i As Integer = items.Count - 1 To 0 Step -1
                Dim item As BasketItem = CType(items(i), BasketItem)
                Dim newEntity As IHasRentalRate
                Dim type As ItemType
                Select Case item.FullClassName.ToLower
                    Case "longkong.pojjaman.businesslogic.tool"
                        newEntity = New Tool(item.Id)
                        type = New ItemType(19)
                    Case "longkong.pojjaman.businesslogic.asset"
                        newEntity = New Asset(item.Id)
                        type = New ItemType(28)
                End Select
                Dim doc As New AssetWithdrawItem
                If Not Me.CurrentItem Is Nothing Then
                    doc = Me.CurrentItem
                    Me.m_treeManager.SelectedRow.Tag = Nothing
                Else
                    Me.m_entity.ItemCollection.Add(doc)
                End If
                doc.ItemType = type
                doc.Entity = newEntity
            Next
            RefreshDocs()
            tgItem.CurrentRowIndex = index
        End Sub
        Private Sub ibtnBlank_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnBlank.Click
            Dim index As Integer = tgItem.CurrentRowIndex
            If index > Me.m_entity.ItemCollection.Count - 1 Then
                Return
            End If
            Dim newAsset As New Asset
            Dim item As New AssetWithdrawItem
            item.Entity = newAsset
            Me.m_entity.ItemCollection.Insert(index, item)
            RefreshDocs()
            tgItem.CurrentRowIndex = index
        End Sub
        Private Sub ibtnDelRow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnDelRow.Click
            Dim index As Integer = Me.tgItem.CurrentRowIndex
            If index > Me.m_entity.ItemCollection.Count - 1 Then
                Return
            End If
            Me.m_entity.ItemCollection.Remove(index)
            Me.tgItem.CurrentRowIndex = index
            RefreshDocs()
            Me.WorkbenchWindow.ViewContent.IsDirty = True
        End Sub
        Private Sub ReIndex()
            Dim i As Integer = 0
            For Each row As DataRow In Me.m_treeManager.Treetable.Rows
                row("Linenumber") = i + 1
                i += 1
            Next
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
                Return (New AssetWithdraw).DetailPanelIcon
            End Get
        End Property
#End Region

#Region " Event of Button controls "
        ' Withdraw Person
        Private Sub btnWithdrawPersonEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnWithdrawPersonEdit.Click
            Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
            'If Me.m_entity.IsExternal Then
            '    myEntityPanelService.OpenPanel(New Customer)
            'Else
                myEntityPanelService.OpenPanel(New Employee)
            'End If
        End Sub
        Private Sub btnWithdrawPersonFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnWithdrawPersonFind.Click
            Dim myEntityPanelService As IEntityPanelService = _
            CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
            'If Me.m_entity.IsExternal Then
            '    myEntityPanelService.OpenListDialog(New Customer, AddressOf SetWithdrawPersonDialog)
            'Else
                myEntityPanelService.OpenListDialog(New Employee, AddressOf SetWithdrawPersonDialog)
            'End If
        End Sub

        Private Sub SetWithdrawPersonDialog(ByVal e As ISimpleEntity)
            Me.txtWithdrawPersonCode.Text = e.Code
            'If Me.m_entity.IsExternal Then
            '    Dim cust As New Customer
            '    Me.WorkbenchWindow.ViewContent.IsDirty = _
            '        Me.WorkbenchWindow.ViewContent.IsDirty _
            '        Or Customer.GetCustomer(txtWithdrawPersonCode, txtWithdrawPersonName, cust)
            '    Me.m_entity.Withdrawperson = cust
            'Else
                Dim emp As New Employee
                Me.WorkbenchWindow.ViewContent.IsDirty = _
                    Me.WorkbenchWindow.ViewContent.IsDirty _
                    Or Employee.GetEmployee(txtWithdrawPersonCode, txtWithdrawPersonName, emp)
                Me.m_entity.Withdrawperson = emp
            'End If
        End Sub
        ' Withdraw Costcenter
        Private Sub btnWithdrawCCEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnWithdrawCCEdit.Click
            Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
            myEntityPanelService.OpenPanel(New CostCenter)
        End Sub
        Private Sub btnWithdrawCCFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnWithdrawCCFind.Click
            Dim myEntityPanelService As IEntityPanelService = _
            CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
            myEntityPanelService.OpenTreeDialog(New CostCenter, AddressOf SetWithdrawCostCenterDialog)
        End Sub
        Private Sub SetWithdrawCostCenterDialog(ByVal e As ISimpleEntity)
            Me.txtWithdrawCCCode.Text = e.Code
            Me.WorkbenchWindow.ViewContent.IsDirty = _
                Me.WorkbenchWindow.ViewContent.IsDirty _
                Or CostCenter.GetCostCenter(txtWithdrawCCCode, txtWithdrawCCName, Me.m_entity.WithdrawCostcenter, CType(ServiceManager.Services.GetService(GetType(SecurityService)), SecurityService).CurrentUser.Id)
        End Sub

        ' Store Person
        Private Sub btnStorepersonEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnStorepersonEdit.Click
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
            myEntityPanelService.OpenTreeDialog(New CostCenter, AddressOf SetStoreCostCenterDialog, New Filter() {New Filter("checkright", False)})
        End Sub
        Private Sub SetStoreCostCenterDialog(ByVal e As ISimpleEntity)
            Me.txtStoreCCCode.Text = e.Code
            Me.WorkbenchWindow.ViewContent.IsDirty = _
                Me.WorkbenchWindow.ViewContent.IsDirty _
                Or CostCenter.GetCostCenterWithoutRight(txtStoreCCCode, txtStoreCCName, Me.m_entity.StoreCostcenter)
        End Sub
#End Region

#Region " IClipboardHandler Overrides "
        Public Overrides ReadOnly Property EnablePaste() As Boolean
            Get
                ' Person
                Dim data As IDataObject = Clipboard.GetDataObject
                If data.GetDataPresent((New Customer).FullClassName) OrElse data.GetDataPresent((New Customer).FullClassName) Then
                    If Not Me.ActiveControl Is Nothing Then
                        Select Case Me.ActiveControl.Name.ToLower
                            Case "txtwithdrawpersoncode", "txtwithdrawpersonname"
                                Return True
                        End Select
                    End If
                End If
                If data.GetDataPresent((New Employee).FullClassName) OrElse data.GetDataPresent((New Customer).FullClassName) Then
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
            If data.GetDataPresent((New Customer).FullClassName) Then
                Dim id As Integer = CInt(data.GetData((New Customer).FullClassName))
                Dim entity As SimpleBusinessEntityBase
                entity = New Customer(id)
                If Not Me.ActiveControl Is Nothing Then
                    Select Case Me.ActiveControl.Name.ToLower
                        Case "txtwithdrawpersoncode", "txtwithdrawpersonname"
                            Me.SetWithdrawPersonDialog(entity)
                    End Select
                End If
            End If
            If data.GetDataPresent((New Employee).FullClassName) Then
                Dim id As Integer = CInt(data.GetData((New Employee).FullClassName))
                Dim entity As SimpleBusinessEntityBase
                entity = New Employee(id)
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

#Region " Private Methods "
        Private Sub SetIsExternal()
            If chkExternal.Checked Then

                grbRequest.Enabled = False
                grbRequest2.Enabled = True

                txtWithdrawCCCode.BackColor = System.Drawing.SystemColors.Control
                txtWithdrawPersonCode.BackColor = System.Drawing.SystemColors.Control
                txtCustomerCode.BackColor = System.Drawing.SystemColors.Window

                Me.Validator.SetRequired(Me.txtCustomerCode, True)
                Me.Validator.SetRequired(Me.txtWithdrawCCCode, False)
                Me.Validator.SetRequired(Me.txtWithdrawPersonCode, False)
                Me.ErrorProvider1.SetError(Me.txtWithdrawCCCode, "")
                Me.ErrorProvider1.SetError(Me.txtWithdrawPersonCode, "")

                For Each ctl As Control In Me.grbRequest.Controls
                    If (TypeOf (ctl) Is TextBox) Then
                        ctl.Text = ""
                    End If
                Next
            Else
                grbRequest.Enabled = True
                grbRequest2.Enabled = False

                txtWithdrawCCCode.BackColor = System.Drawing.SystemColors.Window
                txtWithdrawPersonCode.BackColor = System.Drawing.SystemColors.Window
                txtCustomerCode.BackColor = System.Drawing.SystemColors.Control

                Me.Validator.SetRequired(Me.txtCustomerCode, False)
                Me.Validator.SetRequired(Me.txtWithdrawCCCode, True)
                Me.Validator.SetRequired(Me.txtWithdrawPersonCode, True)
                Me.ErrorProvider1.SetError(Me.txtCustomerCode, "")

                For Each ctl As Control In Me.grbRequest2.Controls
                    If (TypeOf (ctl) Is TextBox) Then
                        ctl.Text = ""
                    End If
                Next
              
            End If
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

