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
    Public Class ToolWithdrawDetail
        Inherits AbstractEntityDetailPanelView
        Implements IValidatable

#Region " Windows Form Designer generated code "
        Friend WithEvents grbSummary As Longkong.Pojjaman.Gui.Components.FixedGroupBox
        Friend WithEvents lblItem As System.Windows.Forms.Label
        Friend WithEvents txtItemCount As System.Windows.Forms.TextBox
        Friend WithEvents lblItemCount As System.Windows.Forms.Label
        Friend WithEvents lblItemCountUnit As System.Windows.Forms.Label
        Friend WithEvents grbReceive As Longkong.Pojjaman.Gui.Components.FixedGroupBox
        Friend WithEvents ImageButton3 As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents ImageButton4 As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
        Friend WithEvents Validator As Longkong.Pojjaman.Gui.Components.PJMTextboxValidator
        Friend WithEvents lblRequestPerson As System.Windows.Forms.Label
        Friend WithEvents grbRequest As Longkong.Pojjaman.Gui.Components.FixedGroupBox
        Friend WithEvents lblStatus As System.Windows.Forms.Label
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
        Friend WithEvents tgItem As Longkong.Pojjaman.Gui.Components.TreeGrid
        Private Sub InitializeComponent()
            Me.components = New System.ComponentModel.Container
            Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(ToolWithdrawDetail))
            Me.txtItemCount = New System.Windows.Forms.TextBox
            Me.lblItemCount = New System.Windows.Forms.Label
            Me.lblItemCountUnit = New System.Windows.Forms.Label
            Me.lblItem = New System.Windows.Forms.Label
            Me.grbSummary = New Longkong.Pojjaman.Gui.Components.FixedGroupBox
            Me.grbReceive = New Longkong.Pojjaman.Gui.Components.FixedGroupBox
            Me.btnStoreCCFind = New Longkong.Pojjaman.Gui.Components.ImageButton
            Me.btnStorepersonFind = New Longkong.Pojjaman.Gui.Components.ImageButton
            Me.btnStoreCCEdit = New Longkong.Pojjaman.Gui.Components.ImageButton
            Me.btnStorepersonEdit = New Longkong.Pojjaman.Gui.Components.ImageButton
            Me.txtStorepersonName = New System.Windows.Forms.TextBox
            Me.txtStoreCCName = New System.Windows.Forms.TextBox
            Me.txtStoreCCCode = New System.Windows.Forms.TextBox
            Me.lblStoreperson = New System.Windows.Forms.Label
            Me.lblStoreCC = New System.Windows.Forms.Label
            Me.txtStorepersonCode = New System.Windows.Forms.TextBox
            Me.grbRequest = New Longkong.Pojjaman.Gui.Components.FixedGroupBox
            Me.btnWithdrawCCFind = New Longkong.Pojjaman.Gui.Components.ImageButton
            Me.btnWithdrawPersonFind = New Longkong.Pojjaman.Gui.Components.ImageButton
            Me.btnWithdrawCCEdit = New Longkong.Pojjaman.Gui.Components.ImageButton
            Me.btnWithdrawPersonEdit = New Longkong.Pojjaman.Gui.Components.ImageButton
            Me.ImageButton3 = New Longkong.Pojjaman.Gui.Components.ImageButton
            Me.ImageButton4 = New Longkong.Pojjaman.Gui.Components.ImageButton
            Me.txtWithdrawCCName = New System.Windows.Forms.TextBox
            Me.txtWithdrawPersonName = New System.Windows.Forms.TextBox
            Me.txtWithdrawPersonCode = New System.Windows.Forms.TextBox
            Me.lblRequestPerson = New System.Windows.Forms.Label
            Me.lblWithdrawCC = New System.Windows.Forms.Label
            Me.txtWithdrawCCCode = New System.Windows.Forms.TextBox
            Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider
            Me.txtDocDate = New System.Windows.Forms.TextBox
            Me.txtCode = New System.Windows.Forms.TextBox
            Me.Validator = New Longkong.Pojjaman.Gui.Components.PJMTextboxValidator(Me.components)
            Me.txtNote = New System.Windows.Forms.TextBox
            Me.lblStatus = New System.Windows.Forms.Label
            Me.ibtnBlank = New Longkong.Pojjaman.Gui.Components.ImageButton
            Me.ibtnDelRow = New Longkong.Pojjaman.Gui.Components.ImageButton
            Me.grbGeneral = New Longkong.Pojjaman.Gui.Components.FixedGroupBox
            Me.lblNote = New System.Windows.Forms.Label
            Me.chkAutorun = New System.Windows.Forms.CheckBox
            Me.dtpDocDate = New System.Windows.Forms.DateTimePicker
            Me.lblDocDate = New System.Windows.Forms.Label
            Me.lblCode = New System.Windows.Forms.Label
            Me.tgItem = New Longkong.Pojjaman.Gui.Components.TreeGrid
            Me.grbSummary.SuspendLayout()
            Me.grbReceive.SuspendLayout()
            Me.grbRequest.SuspendLayout()
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
            Me.Validator.SetMaxValue(Me.txtItemCount, "")
            Me.Validator.SetMinValue(Me.txtItemCount, "")
            Me.txtItemCount.Name = "txtItemCount"
            Me.txtItemCount.ReadOnly = True
            Me.Validator.SetRegularExpression(Me.txtItemCount, "")
            Me.Validator.SetRequired(Me.txtItemCount, False)
            Me.txtItemCount.Size = New System.Drawing.Size(64, 21)
            Me.txtItemCount.TabIndex = 1
            Me.txtItemCount.TabStop = False
            Me.txtItemCount.Text = ""
            Me.txtItemCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
            '
            'lblItemCount
            '
            Me.lblItemCount.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblItemCount.Location = New System.Drawing.Point(8, 16)
            Me.lblItemCount.Name = "lblItemCount"
            Me.lblItemCount.Size = New System.Drawing.Size(104, 18)
            Me.lblItemCount.TabIndex = 0
            Me.lblItemCount.Text = "จำนวนรายการเบิก"
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
            'lblItem
            '
            Me.lblItem.AutoSize = True
            Me.lblItem.BackColor = System.Drawing.Color.Transparent
            Me.lblItem.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblItem.Location = New System.Drawing.Point(16, 164)
            Me.lblItem.Name = "lblItem"
            Me.lblItem.Size = New System.Drawing.Size(133, 19)
            Me.lblItem.TabIndex = 3
            Me.lblItem.Text = "รายการเบิกเครื่องมือ:"
            Me.lblItem.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'grbSummary
            '
            Me.grbSummary.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.grbSummary.Controls.Add(Me.txtItemCount)
            Me.grbSummary.Controls.Add(Me.lblItemCount)
            Me.grbSummary.Controls.Add(Me.lblItemCountUnit)
            Me.grbSummary.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.grbSummary.Location = New System.Drawing.Point(472, 352)
            Me.grbSummary.Name = "grbSummary"
            Me.grbSummary.Size = New System.Drawing.Size(256, 48)
            Me.grbSummary.TabIndex = 8
            Me.grbSummary.TabStop = False
            Me.grbSummary.Text = "สรุปยอดเบิกเครื่องจักร"
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
            Me.grbReceive.Location = New System.Drawing.Point(8, 80)
            Me.grbReceive.Name = "grbReceive"
            Me.grbReceive.Size = New System.Drawing.Size(352, 72)
            Me.grbReceive.TabIndex = 1
            Me.grbReceive.TabStop = False
            Me.grbReceive.Text = "ผู้ให้เบิก"
            '
            'btnStoreCCFind
            '
            Me.btnStoreCCFind.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.btnStoreCCFind.ForeColor = System.Drawing.SystemColors.Control
            Me.btnStoreCCFind.Image = CType(resources.GetObject("btnStoreCCFind.Image"), System.Drawing.Image)
            Me.btnStoreCCFind.Location = New System.Drawing.Point(296, 16)
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
            Me.btnStorepersonFind.Location = New System.Drawing.Point(296, 40)
            Me.btnStorepersonFind.Name = "btnStorepersonFind"
            Me.btnStorepersonFind.Size = New System.Drawing.Size(24, 23)
            Me.btnStorepersonFind.TabIndex = 8
            Me.btnStorepersonFind.TabStop = False
            Me.btnStorepersonFind.ThemedImage = CType(resources.GetObject("btnStorepersonFind.ThemedImage"), System.Drawing.Bitmap)
            '
            'btnStoreCCEdit
            '
            Me.btnStoreCCEdit.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.btnStoreCCEdit.Image = CType(resources.GetObject("btnStoreCCEdit.Image"), System.Drawing.Image)
            Me.btnStoreCCEdit.Location = New System.Drawing.Point(320, 16)
            Me.btnStoreCCEdit.Name = "btnStoreCCEdit"
            Me.btnStoreCCEdit.Size = New System.Drawing.Size(24, 23)
            Me.btnStoreCCEdit.TabIndex = 4
            Me.btnStoreCCEdit.TabStop = False
            Me.btnStoreCCEdit.ThemedImage = CType(resources.GetObject("btnStoreCCEdit.ThemedImage"), System.Drawing.Bitmap)
            '
            'btnStorepersonEdit
            '
            Me.btnStorepersonEdit.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.btnStorepersonEdit.Image = CType(resources.GetObject("btnStorepersonEdit.Image"), System.Drawing.Image)
            Me.btnStorepersonEdit.Location = New System.Drawing.Point(320, 40)
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
            Me.txtStorepersonName.Location = New System.Drawing.Point(176, 40)
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
            Me.txtStoreCCName.Location = New System.Drawing.Point(176, 16)
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
            Me.Validator.SetMaxValue(Me.txtStoreCCCode, "")
            Me.Validator.SetMinValue(Me.txtStoreCCCode, "")
            Me.txtStoreCCCode.Name = "txtStoreCCCode"
            Me.Validator.SetRegularExpression(Me.txtStoreCCCode, "")
            Me.Validator.SetRequired(Me.txtStoreCCCode, False)
            Me.txtStoreCCCode.Size = New System.Drawing.Size(64, 21)
            Me.txtStoreCCCode.TabIndex = 8
            Me.txtStoreCCCode.Text = ""
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
            Me.txtStorepersonCode.Location = New System.Drawing.Point(112, 40)
            Me.txtStorepersonCode.MaxLength = 20
            Me.Validator.SetMaxValue(Me.txtStorepersonCode, "")
            Me.Validator.SetMinValue(Me.txtStorepersonCode, "")
            Me.txtStorepersonCode.Name = "txtStorepersonCode"
            Me.Validator.SetRegularExpression(Me.txtStorepersonCode, "")
            Me.Validator.SetRequired(Me.txtStorepersonCode, False)
            Me.txtStorepersonCode.Size = New System.Drawing.Size(64, 21)
            Me.txtStorepersonCode.TabIndex = 9
            Me.txtStorepersonCode.Text = ""
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
            Me.grbRequest.Location = New System.Drawing.Point(368, 80)
            Me.grbRequest.Name = "grbRequest"
            Me.grbRequest.Size = New System.Drawing.Size(360, 72)
            Me.grbRequest.TabIndex = 2
            Me.grbRequest.TabStop = False
            Me.grbRequest.Text = "ผู้ขอเบิก"
            '
            'btnWithdrawCCFind
            '
            Me.btnWithdrawCCFind.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.btnWithdrawCCFind.ForeColor = System.Drawing.SystemColors.Control
            Me.btnWithdrawCCFind.Image = CType(resources.GetObject("btnWithdrawCCFind.Image"), System.Drawing.Image)
            Me.btnWithdrawCCFind.Location = New System.Drawing.Point(304, 16)
            Me.btnWithdrawCCFind.Name = "btnWithdrawCCFind"
            Me.btnWithdrawCCFind.Size = New System.Drawing.Size(24, 23)
            Me.btnWithdrawCCFind.TabIndex = 3
            Me.btnWithdrawCCFind.TabStop = False
            Me.btnWithdrawCCFind.ThemedImage = CType(resources.GetObject("btnWithdrawCCFind.ThemedImage"), System.Drawing.Bitmap)
            '
            'btnWithdrawPersonFind
            '
            Me.btnWithdrawPersonFind.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.btnWithdrawPersonFind.ForeColor = System.Drawing.SystemColors.Control
            Me.btnWithdrawPersonFind.Image = CType(resources.GetObject("btnWithdrawPersonFind.Image"), System.Drawing.Image)
            Me.btnWithdrawPersonFind.Location = New System.Drawing.Point(304, 40)
            Me.btnWithdrawPersonFind.Name = "btnWithdrawPersonFind"
            Me.btnWithdrawPersonFind.Size = New System.Drawing.Size(24, 23)
            Me.btnWithdrawPersonFind.TabIndex = 8
            Me.btnWithdrawPersonFind.TabStop = False
            Me.btnWithdrawPersonFind.ThemedImage = CType(resources.GetObject("btnWithdrawPersonFind.ThemedImage"), System.Drawing.Bitmap)
            '
            'btnWithdrawCCEdit
            '
            Me.btnWithdrawCCEdit.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.btnWithdrawCCEdit.Image = CType(resources.GetObject("btnWithdrawCCEdit.Image"), System.Drawing.Image)
            Me.btnWithdrawCCEdit.Location = New System.Drawing.Point(328, 16)
            Me.btnWithdrawCCEdit.Name = "btnWithdrawCCEdit"
            Me.btnWithdrawCCEdit.Size = New System.Drawing.Size(24, 23)
            Me.btnWithdrawCCEdit.TabIndex = 4
            Me.btnWithdrawCCEdit.TabStop = False
            Me.btnWithdrawCCEdit.ThemedImage = CType(resources.GetObject("btnWithdrawCCEdit.ThemedImage"), System.Drawing.Bitmap)
            '
            'btnWithdrawPersonEdit
            '
            Me.btnWithdrawPersonEdit.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.btnWithdrawPersonEdit.Image = CType(resources.GetObject("btnWithdrawPersonEdit.Image"), System.Drawing.Image)
            Me.btnWithdrawPersonEdit.Location = New System.Drawing.Point(328, 40)
            Me.btnWithdrawPersonEdit.Name = "btnWithdrawPersonEdit"
            Me.btnWithdrawPersonEdit.Size = New System.Drawing.Size(24, 23)
            Me.btnWithdrawPersonEdit.TabIndex = 9
            Me.btnWithdrawPersonEdit.TabStop = False
            Me.btnWithdrawPersonEdit.ThemedImage = CType(resources.GetObject("btnWithdrawPersonEdit.ThemedImage"), System.Drawing.Bitmap)
            '
            'ImageButton3
            '
            Me.ImageButton3.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.ImageButton3.ForeColor = System.Drawing.SystemColors.Control
            Me.ImageButton3.Image = CType(resources.GetObject("ImageButton3.Image"), System.Drawing.Image)
            Me.ImageButton3.Location = New System.Drawing.Point(524, 144)
            Me.ImageButton3.Name = "ImageButton3"
            Me.ImageButton3.Size = New System.Drawing.Size(24, 23)
            Me.ImageButton3.TabIndex = 256
            Me.ImageButton3.TabStop = False
            Me.ImageButton3.ThemedImage = CType(resources.GetObject("ImageButton3.ThemedImage"), System.Drawing.Bitmap)
            '
            'ImageButton4
            '
            Me.ImageButton4.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.ImageButton4.ForeColor = System.Drawing.SystemColors.Control
            Me.ImageButton4.Image = CType(resources.GetObject("ImageButton4.Image"), System.Drawing.Image)
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
            Me.txtWithdrawCCName.Location = New System.Drawing.Point(184, 16)
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
            'txtWithdrawPersonName
            '
            Me.txtWithdrawPersonName.BackColor = System.Drawing.SystemColors.Control
            Me.Validator.SetDataType(Me.txtWithdrawPersonName, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtWithdrawPersonName, "")
            Me.Validator.SetGotFocusBackColor(Me.txtWithdrawPersonName, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtWithdrawPersonName, System.Drawing.Color.Empty)
            Me.txtWithdrawPersonName.Location = New System.Drawing.Point(184, 40)
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
            'txtWithdrawPersonCode
            '
            Me.txtWithdrawPersonCode.BackColor = System.Drawing.SystemColors.Window
            Me.Validator.SetDataType(Me.txtWithdrawPersonCode, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtWithdrawPersonCode, "")
            Me.Validator.SetGotFocusBackColor(Me.txtWithdrawPersonCode, System.Drawing.Color.Empty)
            Me.ErrorProvider1.SetIconPadding(Me.txtWithdrawPersonCode, -15)
            Me.Validator.SetInvalidBackColor(Me.txtWithdrawPersonCode, System.Drawing.Color.Empty)
            Me.txtWithdrawPersonCode.Location = New System.Drawing.Point(120, 40)
            Me.txtWithdrawPersonCode.MaxLength = 20
            Me.Validator.SetMaxValue(Me.txtWithdrawPersonCode, "")
            Me.Validator.SetMinValue(Me.txtWithdrawPersonCode, "")
            Me.txtWithdrawPersonCode.Name = "txtWithdrawPersonCode"
            Me.Validator.SetRegularExpression(Me.txtWithdrawPersonCode, "")
            Me.Validator.SetRequired(Me.txtWithdrawPersonCode, True)
            Me.txtWithdrawPersonCode.Size = New System.Drawing.Size(64, 21)
            Me.txtWithdrawPersonCode.TabIndex = 11
            Me.txtWithdrawPersonCode.Text = ""
            '
            'lblRequestPerson
            '
            Me.lblRequestPerson.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblRequestPerson.Location = New System.Drawing.Point(8, 40)
            Me.lblRequestPerson.Name = "lblRequestPerson"
            Me.lblRequestPerson.Size = New System.Drawing.Size(104, 18)
            Me.lblRequestPerson.TabIndex = 5
            Me.lblRequestPerson.Text = "ผู้เบิก:"
            Me.lblRequestPerson.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblWithdrawCC
            '
            Me.lblWithdrawCC.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblWithdrawCC.Location = New System.Drawing.Point(8, 16)
            Me.lblWithdrawCC.Name = "lblWithdrawCC"
            Me.lblWithdrawCC.Size = New System.Drawing.Size(104, 18)
            Me.lblWithdrawCC.TabIndex = 0
            Me.lblWithdrawCC.Text = "เบิกเข้า Cost Center:"
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
            Me.txtWithdrawCCCode.Location = New System.Drawing.Point(120, 16)
            Me.txtWithdrawCCCode.MaxLength = 20
            Me.Validator.SetMaxValue(Me.txtWithdrawCCCode, "")
            Me.Validator.SetMinValue(Me.txtWithdrawCCCode, "")
            Me.txtWithdrawCCCode.Name = "txtWithdrawCCCode"
            Me.Validator.SetRegularExpression(Me.txtWithdrawCCCode, "")
            Me.Validator.SetRequired(Me.txtWithdrawCCCode, False)
            Me.txtWithdrawCCCode.Size = New System.Drawing.Size(64, 21)
            Me.txtWithdrawCCCode.TabIndex = 10
            Me.txtWithdrawCCCode.Text = ""
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
            Me.txtCode.Location = New System.Drawing.Point(112, 16)
            Me.txtCode.MaxLength = 20
            Me.Validator.SetMaxValue(Me.txtCode, "")
            Me.Validator.SetMinValue(Me.txtCode, "")
            Me.txtCode.Name = "txtCode"
            Me.Validator.SetRegularExpression(Me.txtCode, "")
            Me.Validator.SetRequired(Me.txtCode, True)
            Me.txtCode.Size = New System.Drawing.Size(112, 21)
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
            Me.txtNote.Location = New System.Drawing.Point(112, 40)
            Me.txtNote.MaxLength = 255
            Me.Validator.SetMaxValue(Me.txtNote, "")
            Me.Validator.SetMinValue(Me.txtNote, "")
            Me.txtNote.Name = "txtNote"
            Me.Validator.SetRegularExpression(Me.txtNote, "")
            Me.Validator.SetRequired(Me.txtNote, False)
            Me.txtNote.Size = New System.Drawing.Size(552, 21)
            Me.txtNote.TabIndex = 7
            Me.txtNote.Text = ""
            '
            'lblStatus
            '
            Me.lblStatus.AutoSize = True
            Me.lblStatus.Location = New System.Drawing.Point(376, 160)
            Me.lblStatus.Name = "lblStatus"
            Me.lblStatus.Size = New System.Drawing.Size(47, 17)
            Me.lblStatus.TabIndex = 6
            Me.lblStatus.Text = "lblStatus"
            '
            'ibtnBlank
            '
            Me.ibtnBlank.Image = CType(resources.GetObject("ibtnBlank.Image"), System.Drawing.Image)
            Me.ibtnBlank.Location = New System.Drawing.Point(184, 156)
            Me.ibtnBlank.Name = "ibtnBlank"
            Me.ibtnBlank.Size = New System.Drawing.Size(32, 32)
            Me.ibtnBlank.TabIndex = 4
            Me.ibtnBlank.TabStop = False
            Me.ibtnBlank.ThemedImage = CType(resources.GetObject("ibtnBlank.ThemedImage"), System.Drawing.Bitmap)
            '
            'ibtnDelRow
            '
            Me.ibtnDelRow.Image = CType(resources.GetObject("ibtnDelRow.Image"), System.Drawing.Image)
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
            Me.chkAutorun.Location = New System.Drawing.Point(224, 16)
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
            Me.tgItem.GridLineColor = System.Drawing.Color.FromArgb(CType(210, Byte), CType(200, Byte), CType(120, Byte))
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
            'ToolWithdrawDetail
            '
            Me.Controls.Add(Me.tgItem)
            Me.Controls.Add(Me.grbGeneral)
            Me.Controls.Add(Me.ibtnBlank)
            Me.Controls.Add(Me.ibtnDelRow)
            Me.Controls.Add(Me.lblStatus)
            Me.Controls.Add(Me.grbSummary)
            Me.Controls.Add(Me.grbReceive)
            Me.Controls.Add(Me.grbRequest)
            Me.Controls.Add(Me.lblItem)
            Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Name = "ToolWithdrawDetail"
            Me.Size = New System.Drawing.Size(752, 408)
            Me.grbSummary.ResumeLayout(False)
            Me.grbReceive.ResumeLayout(False)
            Me.grbRequest.ResumeLayout(False)
            Me.grbGeneral.ResumeLayout(False)
            CType(Me.tgItem, System.ComponentModel.ISupportInitialize).EndInit()
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
    Private m_entity As ToolWithdraw

    Private m_isInitialized As Boolean = False
    Private m_treeManager As TreeManager
    Private m_tableStyleEnable As Hashtable
#End Region

#Region " Style "
    Protected Function CreateTableStyle() As DataGridTableStyle
      Dim dst As New DataGridTableStyle
      dst.MappingName = "StockItem"
      Dim myStringParserService As StringParserService = CType(ServiceManager.Services.GetService(GetType(StringParserService)), StringParserService)

      Dim csLineNumber As New TreeTextColumn
      csLineNumber.MappingName = "stocki_lineNumber"
      csLineNumber.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ToolWithdrawDetail.LineNumberHeaderText}")
      csLineNumber.NullText = ""
      csLineNumber.Width = 30
      csLineNumber.Alignment = HorizontalAlignment.Center
      csLineNumber.DataAlignment = HorizontalAlignment.Center
      csLineNumber.ReadOnly = True
      csLineNumber.TextBox.Name = "stocki_lineNumber"

      Dim csCode As New TreeTextColumn
      csCode.MappingName = "Code"
      csCode.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ToolWithdrawDetail.CodeHeaderText}")
      csCode.NullText = ""
      csCode.Width = 100
      csCode.Alignment = HorizontalAlignment.Center
      csCode.DataAlignment = HorizontalAlignment.Left
      csCode.ReadOnly = False
      csCode.TextBox.Name = "Code"

      Dim csButton As New DataGridButtonColumn
      csButton.MappingName = "codebutton"
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
      csUnit.Width = 100
      csUnit.ReadOnly = True
      csUnit.TextBox.Name = "UnitName"

      'Dim csUnitButton As New DataGridButtonColumn
      'csUnitButton.MappingName = "UnitButton"
      'csUnitButton.HeaderText = ""
      'csUnitButton.NullText = ""
      'AddHandler csUnitButton.Click, AddressOf UnitClicked

      Dim csQty As New TreeTextColumn
      csQty.MappingName = "stocki_qty"
      csQty.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ToolWithdrawDetail.QtyHeaderText}")
      csQty.NullText = ""
      csQty.Alignment = HorizontalAlignment.Center
      csQty.DataAlignment = HorizontalAlignment.Right
      csQty.Format = "#,##0.00"
      csQty.Width = 100
      csQty.ReadOnly = False
      csQty.TextBox.Name = "stocki_qty"


      Dim csNote As New TreeTextColumn
      csNote.MappingName = "stocki_note"
      csNote.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ToolWithdrawDetail.NoteHeaderText}")
      csNote.NullText = ""
      csNote.Alignment = HorizontalAlignment.Center
      csNote.DataAlignment = HorizontalAlignment.Left
      csNote.Width = 180
      csNote.ReadOnly = False
      csNote.TextBox.Name = "stocki_note"

      ' Fill Column Style 
      dst.GridColumnStyles.Add(csLineNumber)
      dst.GridColumnStyles.Add(csCode)
      dst.GridColumnStyles.Add(csButton)
      dst.GridColumnStyles.Add(csName)
      dst.GridColumnStyles.Add(csUnit)
      dst.GridColumnStyles.Add(csQty)
      dst.GridColumnStyles.Add(csNote)

      m_tableStyleEnable = New Hashtable
      For Each colStyle As DataGridColumnStyle In dst.GridColumnStyles
        m_tableStyleEnable.Add(colStyle, colStyle.ReadOnly)
      Next

      Return dst
    End Function
    Protected Sub GridButton_Clicked(ByVal e As ButtonColumnEventArgs)
      If e.Column = 2 Then
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

      Dim dt As TreeTable = ToolWithdraw.GetSchemaTable()
      Dim dst As DataGridTableStyle = Me.CreateTableStyle()
      m_treeManager = New TreeManager(dt, tgItem)
      m_treeManager.SetTableStyle(dst)
      m_treeManager.AllowSorting = False
      m_treeManager.AllowDelete = False
      tgItem.AllowNew = False

      EventWiring()
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
      Me.m_treeManager.Treetable = Me.m_entity.ItemTable
      AddHandler Me.m_entity.PropertyChanged, AddressOf PropChanged
      Me.Validator.DataTable = m_treeManager.Treetable
      '********************************************************************

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
      SetSummaryText()
      CheckFormEnable()
    End Sub
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
        Me.m_entity = CType(Value, ToolWithdraw)
        'Hack:
        Me.m_entity.OnTabPageTextChanged(m_entity, EventArgs.Empty)
        UpdateEntityProperties()
      End Set
    End Property

    Public Overrides Sub Initialize()

    End Sub


#End Region

#Region " Event Handlers "
    Private Function GenIDListFromDataTable() As String
      Dim idlist As String = ""
      Me.m_entity.ItemTable.AcceptChanges()
      For Each row As TreeRow In Me.m_entity.ItemTable.Rows
        If Me.m_entity.ValidateRow(row) Then
          idlist &= CStr(row("stocki_entity")) & ","
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
      Dim entity As New ToolForSelection
      entity.CC = Me.m_entity.FromCC
      entity.FromWip = False
      myEntityPanelService.OpenListDialog(entity, AddressOf SetItems)
    End Sub
    Private Sub SetItems(ByVal items As BasketItemCollection)
      Dim index As Integer = tgItem.CurrentRowIndex
      For i As Integer = items.Count - 1 To 0 Step -1
        Dim item As BasketItem = CType(items(i), BasketItem)
        Dim newItem As Tool
        Dim myItem As New StockItem

        newItem = New Tool(item.Id)

        myItem.Entity = newItem

        myItem.Unit = CType(newItem, Tool).Unit
        myItem.CostCenter = Me.m_entity.StoreCostcenter

        myItem.Status = New StockStatus(1)
        myItem.ItemType = New ItemType(newItem.EntityId)
        myItem.Type = New StockDocType(Me.m_entity.EntityId)

        myItem.Qty = 1

        If i = items.Count - 1 Then
          If Me.m_entity.ItemTable.Childs.Count = 0 Then
            Me.m_entity.Add(myItem)
          Else
            myItem.LineNumber = CInt(Me.m_entity.ItemTable.Childs(index)("stocki_lineNumber"))
            myItem.Stock = Me.m_entity
            myItem.CopyToDataRow(Me.m_entity.ItemTable.Childs(index))
          End If
        Else
          Me.m_entity.Insert(index, myItem)
        End If
        Me.m_entity.ItemTable.AcceptChanges()
      Next
      tgItem.CurrentRowIndex = index
      RefreshBlankGrid()

    End Sub
    Private Sub ibtnBlank_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnBlank.Click
      Dim index As Integer = tgItem.CurrentRowIndex
      Dim newItem As New BlankItem("")
      Dim myItem As New StockItem
      Dim newtool As New Tool
      myItem.Entity = CType(newItem, IHasName)

      myItem.Unit = New Unit
      myItem.CostCenter = New CostCenter

      myItem.Status = New StockStatus(1)
      myItem.Type = New StockDocType(Me.m_entity.EntityId)
      myItem.ItemType = New ItemType(newtool.EntityId)

      myItem.Qty = 0

      Me.m_entity.Insert(index, myItem)
      Me.m_entity.ItemTable.AcceptChanges()
      tgItem.CurrentRowIndex = index
      RefreshBlankGrid()
    End Sub
    Private Sub ibtnDelRow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnDelRow.Click
      Dim index As Integer = Me.tgItem.CurrentRowIndex
      Me.m_entity.Remove(index)
      Me.tgItem.CurrentRowIndex = index
      RefreshBlankGrid()
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
        Return (New ToolWithdraw).DetailPanelIcon
      End Get
    End Property
#End Region

#Region " Event of Button controls "
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
            If Me.tgItem.Height = 0 Then
                Return
            End If
            Dim dirtyFlag As Boolean = Me.WorkbenchWindow.ViewContent.IsDirty
            Dim index As Integer = tgItem.CurrentRowIndex

            Do Until Me.m_entity.ItemTable.Rows.Count > tgItem.VisibleRowCount
                'เพิ่มแถวจนเต็ม
                Me.m_entity.AddBlankRow(1)
            Loop

            'MessageBox.Show(tgItem.VisibleRowCount.ToString & ":" & Me.m_entity.ItemTable.Childs.Count.ToString)

            If Me.m_entity.MaxRowIndex = Me.m_entity.ItemTable.Childs.Count - 1 Then
                'เพิ่มอีก 1 แถว ถ้ามีข้อมูลจนถึงแถวสุดท้าย
                Me.m_entity.AddBlankRow(1)
            End If
            Me.m_entity.ItemTable.AcceptChanges()
            tgItem.CurrentRowIndex = Math.Max(0, index)
            Me.WorkbenchWindow.ViewContent.IsDirty = dirtyFlag

            SetSummaryText()
        End Sub
#End Region

#Region " Private Methods "
        Private Sub SetSummaryText()
            Dim i As Integer = 0
            For Each item As TreeRow In Me.m_entity.ItemTable.Rows
                If Me.m_entity.ValidateRow(item) Then
                    i += 1
                End If
            Next
            txtItemCount.Text = i.ToString("#,###")
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

