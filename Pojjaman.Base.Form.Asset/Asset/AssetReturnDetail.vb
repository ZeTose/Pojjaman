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
    Public Class AssetReturnDetail
        Inherits AbstractEntityDetailPanelView
        Implements IValidatable

#Region " Windows Form Designer generated code "
        Friend WithEvents lblRecievePerson As System.Windows.Forms.Label
        Friend WithEvents lblItem As System.Windows.Forms.Label
        Friend WithEvents txtRecievePersonCode As System.Windows.Forms.TextBox
        Friend WithEvents cmbReturnPerson As System.Windows.Forms.ComboBox
        Friend WithEvents txtReturnPersonCode As System.Windows.Forms.TextBox
        Friend WithEvents lblReturnPerson As System.Windows.Forms.Label
        Friend WithEvents grbSummary As Longkong.Pojjaman.Gui.Components.FixedGroupBox
        Friend WithEvents txtItemCount As System.Windows.Forms.TextBox
        Friend WithEvents lblItemCount As System.Windows.Forms.Label
        Friend WithEvents lblItemCountUnit As System.Windows.Forms.Label
        Friend WithEvents grbReturn As Longkong.Pojjaman.Gui.Components.FixedGroupBox
        Friend WithEvents grbRecieve As Longkong.Pojjaman.Gui.Components.FixedGroupBox
        Friend WithEvents txtReturnPersonName As System.Windows.Forms.TextBox
        Friend WithEvents Validator As Longkong.Pojjaman.Gui.Components.PJMTextboxValidator
        Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
        Friend WithEvents lblReturnCC As System.Windows.Forms.Label
        Friend WithEvents lblRecieveCC As System.Windows.Forms.Label
        Friend WithEvents txtRecieveCCCode As System.Windows.Forms.TextBox
        Friend WithEvents btnReturnCCEdit As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents txtReturnCCCode As System.Windows.Forms.TextBox
        Friend WithEvents btnReturnCCFind As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents txtReturnCCName As System.Windows.Forms.TextBox
        Friend WithEvents txtRecieveCCName As System.Windows.Forms.TextBox
        Friend WithEvents txtRecievePersonName As System.Windows.Forms.TextBox
        Friend WithEvents lblStatus As System.Windows.Forms.Label
        Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
        Friend WithEvents chkIsExternal As System.Windows.Forms.CheckBox
        Friend WithEvents btnReturnPersonFind As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents btnReturnPersonEdit As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents btnRecievePersonFind As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents btnRecievePersonEdit As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents btnRecieveCCFind As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents btnRecieveCCEdit As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents ibtnBlank As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents ibtnDelRow As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents txtRental As System.Windows.Forms.TextBox
        Friend WithEvents lblRental As System.Windows.Forms.Label
        Friend WithEvents lblRentalUnit As System.Windows.Forms.Label
        Friend WithEvents chkAutorun As System.Windows.Forms.CheckBox
        Friend WithEvents txtDocDate As System.Windows.Forms.TextBox
        Friend WithEvents dtpDocDate As System.Windows.Forms.DateTimePicker
        Friend WithEvents lblDocDate As System.Windows.Forms.Label
        Friend WithEvents lblCode As System.Windows.Forms.Label
        Friend WithEvents txtCode As System.Windows.Forms.TextBox
        Friend WithEvents txtNote As System.Windows.Forms.TextBox
        Friend WithEvents lblNote As System.Windows.Forms.Label
        Friend WithEvents tgItem As Longkong.Pojjaman.Gui.Components.TreeGrid
        Friend WithEvents grbGeneral As Longkong.Pojjaman.Gui.Components.FixedGroupBox
        Friend WithEvents btnCustomerDialog As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents lblCustomer As System.Windows.Forms.Label
        Friend WithEvents btnCustomerPanel As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents txtCustomerCode As System.Windows.Forms.TextBox
        Friend WithEvents txtCustomerName As System.Windows.Forms.TextBox
        Friend WithEvents grbReturn2 As Longkong.Pojjaman.Gui.Components.FixedGroupBox
        Protected Sub InitializeComponent()
            Me.components = New System.ComponentModel.Container
            Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(AssetReturnDetail))
            Me.lblReturnCC = New System.Windows.Forms.Label
            Me.lblRecievePerson = New System.Windows.Forms.Label
            Me.lblItem = New System.Windows.Forms.Label
            Me.lblRecieveCC = New System.Windows.Forms.Label
            Me.txtRecieveCCCode = New System.Windows.Forms.TextBox
            Me.btnReturnCCEdit = New Longkong.Pojjaman.Gui.Components.ImageButton
            Me.txtReturnCCCode = New System.Windows.Forms.TextBox
            Me.txtRecievePersonCode = New System.Windows.Forms.TextBox
            Me.txtReturnPersonCode = New System.Windows.Forms.TextBox
            Me.lblReturnPerson = New System.Windows.Forms.Label
            Me.grbReturn = New Longkong.Pojjaman.Gui.Components.FixedGroupBox
            Me.btnReturnPersonFind = New Longkong.Pojjaman.Gui.Components.ImageButton
            Me.btnReturnPersonEdit = New Longkong.Pojjaman.Gui.Components.ImageButton
            Me.btnReturnCCFind = New Longkong.Pojjaman.Gui.Components.ImageButton
            Me.txtReturnCCName = New System.Windows.Forms.TextBox
            Me.txtReturnPersonName = New System.Windows.Forms.TextBox
            Me.grbRecieve = New Longkong.Pojjaman.Gui.Components.FixedGroupBox
            Me.btnRecievePersonFind = New Longkong.Pojjaman.Gui.Components.ImageButton
            Me.btnRecievePersonEdit = New Longkong.Pojjaman.Gui.Components.ImageButton
            Me.btnRecieveCCFind = New Longkong.Pojjaman.Gui.Components.ImageButton
            Me.btnRecieveCCEdit = New Longkong.Pojjaman.Gui.Components.ImageButton
            Me.txtRecieveCCName = New System.Windows.Forms.TextBox
            Me.txtRecievePersonName = New System.Windows.Forms.TextBox
            Me.grbSummary = New Longkong.Pojjaman.Gui.Components.FixedGroupBox
            Me.txtItemCount = New System.Windows.Forms.TextBox
            Me.lblItemCount = New System.Windows.Forms.Label
            Me.lblItemCountUnit = New System.Windows.Forms.Label
            Me.txtRental = New System.Windows.Forms.TextBox
            Me.lblRental = New System.Windows.Forms.Label
            Me.lblRentalUnit = New System.Windows.Forms.Label
            Me.Validator = New Longkong.Pojjaman.Gui.Components.PJMTextboxValidator(Me.components)
            Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider
            Me.txtDocDate = New System.Windows.Forms.TextBox
            Me.txtCode = New System.Windows.Forms.TextBox
            Me.txtNote = New System.Windows.Forms.TextBox
            Me.txtCustomerCode = New System.Windows.Forms.TextBox
            Me.txtCustomerName = New System.Windows.Forms.TextBox
            Me.lblStatus = New System.Windows.Forms.Label
            Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
            Me.chkIsExternal = New System.Windows.Forms.CheckBox
            Me.ibtnBlank = New Longkong.Pojjaman.Gui.Components.ImageButton
            Me.ibtnDelRow = New Longkong.Pojjaman.Gui.Components.ImageButton
            Me.grbGeneral = New Longkong.Pojjaman.Gui.Components.FixedGroupBox
            Me.lblNote = New System.Windows.Forms.Label
            Me.chkAutorun = New System.Windows.Forms.CheckBox
            Me.dtpDocDate = New System.Windows.Forms.DateTimePicker
            Me.lblDocDate = New System.Windows.Forms.Label
            Me.lblCode = New System.Windows.Forms.Label
            Me.tgItem = New Longkong.Pojjaman.Gui.Components.TreeGrid
            Me.grbReturn2 = New Longkong.Pojjaman.Gui.Components.FixedGroupBox
            Me.btnCustomerDialog = New Longkong.Pojjaman.Gui.Components.ImageButton
            Me.lblCustomer = New System.Windows.Forms.Label
            Me.btnCustomerPanel = New Longkong.Pojjaman.Gui.Components.ImageButton
            Me.grbReturn.SuspendLayout()
            Me.grbRecieve.SuspendLayout()
            Me.grbSummary.SuspendLayout()
            Me.grbGeneral.SuspendLayout()
            CType(Me.tgItem, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.grbReturn2.SuspendLayout()
            Me.SuspendLayout()
            '
            'lblReturnCC
            '
            Me.lblReturnCC.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblReturnCC.Location = New System.Drawing.Point(8, 16)
            Me.lblReturnCC.Name = "lblReturnCC"
            Me.lblReturnCC.Size = New System.Drawing.Size(112, 18)
            Me.lblReturnCC.TabIndex = 1
            Me.lblReturnCC.Text = "Cost Center ที่ส่งคืน:"
            Me.lblReturnCC.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblRecievePerson
            '
            Me.lblRecievePerson.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblRecievePerson.Location = New System.Drawing.Point(8, 40)
            Me.lblRecievePerson.Name = "lblRecievePerson"
            Me.lblRecievePerson.Size = New System.Drawing.Size(112, 18)
            Me.lblRecievePerson.TabIndex = 5
            Me.lblRecievePerson.Text = "ผู้รับคืน:"
            Me.lblRecievePerson.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblItem
            '
            Me.lblItem.AutoSize = True
            Me.lblItem.BackColor = System.Drawing.Color.Transparent
            Me.lblItem.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblItem.Location = New System.Drawing.Point(8, 240)
            Me.lblItem.Name = "lblItem"
            Me.lblItem.Size = New System.Drawing.Size(151, 19)
            Me.lblItem.TabIndex = 4
            Me.lblItem.Text = "รายการคืน Equipment:"
            Me.lblItem.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblRecieveCC
            '
            Me.lblRecieveCC.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblRecieveCC.Location = New System.Drawing.Point(8, 16)
            Me.lblRecieveCC.Name = "lblRecieveCC"
            Me.lblRecieveCC.Size = New System.Drawing.Size(112, 18)
            Me.lblRecieveCC.TabIndex = 0
            Me.lblRecieveCC.Text = "Cost Center ที่รับคืน:"
            Me.lblRecieveCC.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtRecieveCCCode
            '
            Me.txtRecieveCCCode.BackColor = System.Drawing.SystemColors.Window
            Me.Validator.SetDataType(Me.txtRecieveCCCode, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtRecieveCCCode, "")
            Me.Validator.SetGotFocusBackColor(Me.txtRecieveCCCode, System.Drawing.Color.Empty)
            Me.ErrorProvider1.SetIconPadding(Me.txtRecieveCCCode, -15)
            Me.Validator.SetInvalidBackColor(Me.txtRecieveCCCode, System.Drawing.Color.Empty)
            Me.txtRecieveCCCode.Location = New System.Drawing.Point(128, 16)
            Me.txtRecieveCCCode.MaxLength = 20
            Me.Validator.SetMaxValue(Me.txtRecieveCCCode, "")
            Me.Validator.SetMinValue(Me.txtRecieveCCCode, "")
            Me.txtRecieveCCCode.Name = "txtRecieveCCCode"
            Me.Validator.SetRegularExpression(Me.txtRecieveCCCode, "")
            Me.Validator.SetRequired(Me.txtRecieveCCCode, True)
            Me.txtRecieveCCCode.Size = New System.Drawing.Size(64, 21)
            Me.txtRecieveCCCode.TabIndex = 8
            Me.txtRecieveCCCode.Text = ""
            '
            'btnReturnCCEdit
            '
            Me.btnReturnCCEdit.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.btnReturnCCEdit.Image = CType(resources.GetObject("btnReturnCCEdit.Image"), System.Drawing.Image)
            Me.btnReturnCCEdit.Location = New System.Drawing.Point(336, 16)
            Me.btnReturnCCEdit.Name = "btnReturnCCEdit"
            Me.btnReturnCCEdit.Size = New System.Drawing.Size(24, 23)
            Me.btnReturnCCEdit.TabIndex = 5
            Me.btnReturnCCEdit.TabStop = False
            Me.btnReturnCCEdit.ThemedImage = CType(resources.GetObject("btnReturnCCEdit.ThemedImage"), System.Drawing.Bitmap)
            '
            'txtReturnCCCode
            '
            Me.txtReturnCCCode.BackColor = System.Drawing.SystemColors.Window
            Me.Validator.SetDataType(Me.txtReturnCCCode, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtReturnCCCode, "")
            Me.Validator.SetGotFocusBackColor(Me.txtReturnCCCode, System.Drawing.Color.Empty)
            Me.ErrorProvider1.SetIconPadding(Me.txtReturnCCCode, -15)
            Me.Validator.SetInvalidBackColor(Me.txtReturnCCCode, System.Drawing.Color.Empty)
            Me.txtReturnCCCode.Location = New System.Drawing.Point(128, 16)
            Me.txtReturnCCCode.MaxLength = 20
            Me.Validator.SetMaxValue(Me.txtReturnCCCode, "")
            Me.Validator.SetMinValue(Me.txtReturnCCCode, "")
            Me.txtReturnCCCode.Name = "txtReturnCCCode"
            Me.Validator.SetRegularExpression(Me.txtReturnCCCode, "")
            Me.Validator.SetRequired(Me.txtReturnCCCode, True)
            Me.txtReturnCCCode.Size = New System.Drawing.Size(64, 21)
            Me.txtReturnCCCode.TabIndex = 6
            Me.txtReturnCCCode.Text = ""
            '
            'txtRecievePersonCode
            '
            Me.txtRecievePersonCode.BackColor = System.Drawing.SystemColors.Window
            Me.Validator.SetDataType(Me.txtRecievePersonCode, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtRecievePersonCode, "")
            Me.Validator.SetGotFocusBackColor(Me.txtRecievePersonCode, System.Drawing.Color.Empty)
            Me.ErrorProvider1.SetIconPadding(Me.txtRecievePersonCode, -15)
            Me.Validator.SetInvalidBackColor(Me.txtRecievePersonCode, System.Drawing.Color.Empty)
            Me.txtRecievePersonCode.Location = New System.Drawing.Point(128, 40)
            Me.txtRecievePersonCode.MaxLength = 20
            Me.Validator.SetMaxValue(Me.txtRecievePersonCode, "")
            Me.Validator.SetMinValue(Me.txtRecievePersonCode, "")
            Me.txtRecievePersonCode.Name = "txtRecievePersonCode"
            Me.Validator.SetRegularExpression(Me.txtRecievePersonCode, "")
            Me.Validator.SetRequired(Me.txtRecievePersonCode, True)
            Me.txtRecievePersonCode.Size = New System.Drawing.Size(64, 21)
            Me.txtRecievePersonCode.TabIndex = 9
            Me.txtRecievePersonCode.Text = ""
            '
            'txtReturnPersonCode
            '
            Me.txtReturnPersonCode.BackColor = System.Drawing.SystemColors.Window
            Me.Validator.SetDataType(Me.txtReturnPersonCode, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtReturnPersonCode, "")
            Me.Validator.SetGotFocusBackColor(Me.txtReturnPersonCode, System.Drawing.Color.Empty)
            Me.ErrorProvider1.SetIconPadding(Me.txtReturnPersonCode, -15)
            Me.Validator.SetInvalidBackColor(Me.txtReturnPersonCode, System.Drawing.Color.Empty)
            Me.txtReturnPersonCode.Location = New System.Drawing.Point(128, 40)
            Me.txtReturnPersonCode.MaxLength = 20
            Me.Validator.SetMaxValue(Me.txtReturnPersonCode, "")
            Me.Validator.SetMinValue(Me.txtReturnPersonCode, "")
            Me.txtReturnPersonCode.Name = "txtReturnPersonCode"
            Me.Validator.SetRegularExpression(Me.txtReturnPersonCode, "")
            Me.Validator.SetRequired(Me.txtReturnPersonCode, True)
            Me.txtReturnPersonCode.Size = New System.Drawing.Size(64, 21)
            Me.txtReturnPersonCode.TabIndex = 7
            Me.txtReturnPersonCode.Text = ""
            '
            'lblReturnPerson
            '
            Me.lblReturnPerson.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblReturnPerson.Location = New System.Drawing.Point(8, 40)
            Me.lblReturnPerson.Name = "lblReturnPerson"
            Me.lblReturnPerson.Size = New System.Drawing.Size(112, 18)
            Me.lblReturnPerson.TabIndex = 6
            Me.lblReturnPerson.Text = "ผู้ส่งคืน:"
            Me.lblReturnPerson.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'grbReturn
            '
            Me.grbReturn.Controls.Add(Me.btnReturnPersonFind)
            Me.grbReturn.Controls.Add(Me.btnReturnPersonEdit)
            Me.grbReturn.Controls.Add(Me.btnReturnCCFind)
            Me.grbReturn.Controls.Add(Me.txtReturnCCName)
            Me.grbReturn.Controls.Add(Me.txtReturnPersonCode)
            Me.grbReturn.Controls.Add(Me.lblReturnPerson)
            Me.grbReturn.Controls.Add(Me.lblReturnCC)
            Me.grbReturn.Controls.Add(Me.btnReturnCCEdit)
            Me.grbReturn.Controls.Add(Me.txtReturnCCCode)
            Me.grbReturn.Controls.Add(Me.txtReturnPersonName)
            Me.grbReturn.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.grbReturn.Location = New System.Drawing.Point(8, 120)
            Me.grbReturn.Name = "grbReturn"
            Me.grbReturn.Size = New System.Drawing.Size(368, 71)
            Me.grbReturn.TabIndex = 2
            Me.grbReturn.TabStop = False
            Me.grbReturn.Text = "ผู้ส่งคืน"
            '
            'btnReturnPersonFind
            '
            Me.btnReturnPersonFind.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.btnReturnPersonFind.ForeColor = System.Drawing.SystemColors.Control
            Me.btnReturnPersonFind.Image = CType(resources.GetObject("btnReturnPersonFind.Image"), System.Drawing.Image)
            Me.btnReturnPersonFind.Location = New System.Drawing.Point(312, 40)
            Me.btnReturnPersonFind.Name = "btnReturnPersonFind"
            Me.btnReturnPersonFind.Size = New System.Drawing.Size(24, 23)
            Me.btnReturnPersonFind.TabIndex = 9
            Me.btnReturnPersonFind.TabStop = False
            Me.btnReturnPersonFind.ThemedImage = CType(resources.GetObject("btnReturnPersonFind.ThemedImage"), System.Drawing.Bitmap)
            '
            'btnReturnPersonEdit
            '
            Me.btnReturnPersonEdit.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.btnReturnPersonEdit.Image = CType(resources.GetObject("btnReturnPersonEdit.Image"), System.Drawing.Image)
            Me.btnReturnPersonEdit.Location = New System.Drawing.Point(336, 40)
            Me.btnReturnPersonEdit.Name = "btnReturnPersonEdit"
            Me.btnReturnPersonEdit.Size = New System.Drawing.Size(24, 23)
            Me.btnReturnPersonEdit.TabIndex = 0
            Me.btnReturnPersonEdit.TabStop = False
            Me.btnReturnPersonEdit.ThemedImage = CType(resources.GetObject("btnReturnPersonEdit.ThemedImage"), System.Drawing.Bitmap)
            '
            'btnReturnCCFind
            '
            Me.btnReturnCCFind.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.btnReturnCCFind.ForeColor = System.Drawing.SystemColors.Control
            Me.btnReturnCCFind.Image = CType(resources.GetObject("btnReturnCCFind.Image"), System.Drawing.Image)
            Me.btnReturnCCFind.Location = New System.Drawing.Point(312, 16)
            Me.btnReturnCCFind.Name = "btnReturnCCFind"
            Me.btnReturnCCFind.Size = New System.Drawing.Size(24, 23)
            Me.btnReturnCCFind.TabIndex = 4
            Me.btnReturnCCFind.TabStop = False
            Me.btnReturnCCFind.ThemedImage = CType(resources.GetObject("btnReturnCCFind.ThemedImage"), System.Drawing.Bitmap)
            '
            'txtReturnCCName
            '
            Me.txtReturnCCName.BackColor = System.Drawing.SystemColors.Control
            Me.Validator.SetDataType(Me.txtReturnCCName, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtReturnCCName, "")
            Me.Validator.SetGotFocusBackColor(Me.txtReturnCCName, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtReturnCCName, System.Drawing.Color.Empty)
            Me.txtReturnCCName.Location = New System.Drawing.Point(192, 16)
            Me.Validator.SetMaxValue(Me.txtReturnCCName, "")
            Me.Validator.SetMinValue(Me.txtReturnCCName, "")
            Me.txtReturnCCName.Name = "txtReturnCCName"
            Me.txtReturnCCName.ReadOnly = True
            Me.Validator.SetRegularExpression(Me.txtReturnCCName, "")
            Me.Validator.SetRequired(Me.txtReturnCCName, False)
            Me.txtReturnCCName.Size = New System.Drawing.Size(120, 21)
            Me.txtReturnCCName.TabIndex = 3
            Me.txtReturnCCName.TabStop = False
            Me.txtReturnCCName.Text = ""
            '
            'txtReturnPersonName
            '
            Me.txtReturnPersonName.BackColor = System.Drawing.SystemColors.Control
            Me.Validator.SetDataType(Me.txtReturnPersonName, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtReturnPersonName, "")
            Me.Validator.SetGotFocusBackColor(Me.txtReturnPersonName, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtReturnPersonName, System.Drawing.Color.Empty)
            Me.txtReturnPersonName.Location = New System.Drawing.Point(192, 40)
            Me.Validator.SetMaxValue(Me.txtReturnPersonName, "")
            Me.Validator.SetMinValue(Me.txtReturnPersonName, "")
            Me.txtReturnPersonName.Name = "txtReturnPersonName"
            Me.txtReturnPersonName.ReadOnly = True
            Me.Validator.SetRegularExpression(Me.txtReturnPersonName, "")
            Me.Validator.SetRequired(Me.txtReturnPersonName, False)
            Me.txtReturnPersonName.Size = New System.Drawing.Size(120, 21)
            Me.txtReturnPersonName.TabIndex = 8
            Me.txtReturnPersonName.TabStop = False
            Me.txtReturnPersonName.Text = ""
            '
            'grbRecieve
            '
            Me.grbRecieve.Controls.Add(Me.btnRecievePersonFind)
            Me.grbRecieve.Controls.Add(Me.btnRecievePersonEdit)
            Me.grbRecieve.Controls.Add(Me.btnRecieveCCFind)
            Me.grbRecieve.Controls.Add(Me.btnRecieveCCEdit)
            Me.grbRecieve.Controls.Add(Me.txtRecieveCCName)
            Me.grbRecieve.Controls.Add(Me.txtRecievePersonName)
            Me.grbRecieve.Controls.Add(Me.txtRecieveCCCode)
            Me.grbRecieve.Controls.Add(Me.lblRecievePerson)
            Me.grbRecieve.Controls.Add(Me.lblRecieveCC)
            Me.grbRecieve.Controls.Add(Me.txtRecievePersonCode)
            Me.grbRecieve.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.grbRecieve.Location = New System.Drawing.Point(384, 120)
            Me.grbRecieve.Name = "grbRecieve"
            Me.grbRecieve.Size = New System.Drawing.Size(368, 72)
            Me.grbRecieve.TabIndex = 3
            Me.grbRecieve.TabStop = False
            Me.grbRecieve.Text = "ผู้รับคืน"
            '
            'btnRecievePersonFind
            '
            Me.btnRecievePersonFind.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.btnRecievePersonFind.ForeColor = System.Drawing.SystemColors.Control
            Me.btnRecievePersonFind.Image = CType(resources.GetObject("btnRecievePersonFind.Image"), System.Drawing.Image)
            Me.btnRecievePersonFind.Location = New System.Drawing.Point(312, 40)
            Me.btnRecievePersonFind.Name = "btnRecievePersonFind"
            Me.btnRecievePersonFind.Size = New System.Drawing.Size(24, 23)
            Me.btnRecievePersonFind.TabIndex = 8
            Me.btnRecievePersonFind.TabStop = False
            Me.btnRecievePersonFind.ThemedImage = CType(resources.GetObject("btnRecievePersonFind.ThemedImage"), System.Drawing.Bitmap)
            '
            'btnRecievePersonEdit
            '
            Me.btnRecievePersonEdit.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.btnRecievePersonEdit.Image = CType(resources.GetObject("btnRecievePersonEdit.Image"), System.Drawing.Image)
            Me.btnRecievePersonEdit.Location = New System.Drawing.Point(336, 40)
            Me.btnRecievePersonEdit.Name = "btnRecievePersonEdit"
            Me.btnRecievePersonEdit.Size = New System.Drawing.Size(24, 23)
            Me.btnRecievePersonEdit.TabIndex = 9
            Me.btnRecievePersonEdit.TabStop = False
            Me.btnRecievePersonEdit.ThemedImage = CType(resources.GetObject("btnRecievePersonEdit.ThemedImage"), System.Drawing.Bitmap)
            '
            'btnRecieveCCFind
            '
            Me.btnRecieveCCFind.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.btnRecieveCCFind.ForeColor = System.Drawing.SystemColors.Control
            Me.btnRecieveCCFind.Image = CType(resources.GetObject("btnRecieveCCFind.Image"), System.Drawing.Image)
            Me.btnRecieveCCFind.Location = New System.Drawing.Point(312, 16)
            Me.btnRecieveCCFind.Name = "btnRecieveCCFind"
            Me.btnRecieveCCFind.Size = New System.Drawing.Size(24, 23)
            Me.btnRecieveCCFind.TabIndex = 3
            Me.btnRecieveCCFind.TabStop = False
            Me.btnRecieveCCFind.ThemedImage = CType(resources.GetObject("btnRecieveCCFind.ThemedImage"), System.Drawing.Bitmap)
            '
            'btnRecieveCCEdit
            '
            Me.btnRecieveCCEdit.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.btnRecieveCCEdit.Image = CType(resources.GetObject("btnRecieveCCEdit.Image"), System.Drawing.Image)
            Me.btnRecieveCCEdit.Location = New System.Drawing.Point(336, 16)
            Me.btnRecieveCCEdit.Name = "btnRecieveCCEdit"
            Me.btnRecieveCCEdit.Size = New System.Drawing.Size(24, 23)
            Me.btnRecieveCCEdit.TabIndex = 4
            Me.btnRecieveCCEdit.TabStop = False
            Me.btnRecieveCCEdit.ThemedImage = CType(resources.GetObject("btnRecieveCCEdit.ThemedImage"), System.Drawing.Bitmap)
            '
            'txtRecieveCCName
            '
            Me.txtRecieveCCName.BackColor = System.Drawing.SystemColors.Control
            Me.Validator.SetDataType(Me.txtRecieveCCName, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtRecieveCCName, "")
            Me.Validator.SetGotFocusBackColor(Me.txtRecieveCCName, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtRecieveCCName, System.Drawing.Color.Empty)
            Me.txtRecieveCCName.Location = New System.Drawing.Point(192, 16)
            Me.Validator.SetMaxValue(Me.txtRecieveCCName, "")
            Me.Validator.SetMinValue(Me.txtRecieveCCName, "")
            Me.txtRecieveCCName.Name = "txtRecieveCCName"
            Me.txtRecieveCCName.ReadOnly = True
            Me.Validator.SetRegularExpression(Me.txtRecieveCCName, "")
            Me.Validator.SetRequired(Me.txtRecieveCCName, False)
            Me.txtRecieveCCName.Size = New System.Drawing.Size(120, 21)
            Me.txtRecieveCCName.TabIndex = 2
            Me.txtRecieveCCName.TabStop = False
            Me.txtRecieveCCName.Text = ""
            '
            'txtRecievePersonName
            '
            Me.txtRecievePersonName.BackColor = System.Drawing.SystemColors.Control
            Me.Validator.SetDataType(Me.txtRecievePersonName, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtRecievePersonName, "")
            Me.Validator.SetGotFocusBackColor(Me.txtRecievePersonName, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtRecievePersonName, System.Drawing.Color.Empty)
            Me.txtRecievePersonName.Location = New System.Drawing.Point(192, 40)
            Me.Validator.SetMaxValue(Me.txtRecievePersonName, "")
            Me.Validator.SetMinValue(Me.txtRecievePersonName, "")
            Me.txtRecievePersonName.Name = "txtRecievePersonName"
            Me.txtRecievePersonName.ReadOnly = True
            Me.Validator.SetRegularExpression(Me.txtRecievePersonName, "")
            Me.Validator.SetRequired(Me.txtRecievePersonName, False)
            Me.txtRecievePersonName.Size = New System.Drawing.Size(120, 21)
            Me.txtRecievePersonName.TabIndex = 7
            Me.txtRecievePersonName.TabStop = False
            Me.txtRecievePersonName.Text = ""
            '
            'grbSummary
            '
            Me.grbSummary.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
            Me.grbSummary.Controls.Add(Me.txtItemCount)
            Me.grbSummary.Controls.Add(Me.lblItemCount)
            Me.grbSummary.Controls.Add(Me.lblItemCountUnit)
            Me.grbSummary.Controls.Add(Me.txtRental)
            Me.grbSummary.Controls.Add(Me.lblRental)
            Me.grbSummary.Controls.Add(Me.lblRentalUnit)
            Me.grbSummary.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.grbSummary.Location = New System.Drawing.Point(192, 376)
            Me.grbSummary.Name = "grbSummary"
            Me.grbSummary.Size = New System.Drawing.Size(560, 48)
            Me.grbSummary.TabIndex = 8
            Me.grbSummary.TabStop = False
            Me.grbSummary.Text = "สรุปยอดคืนเครื่องมือ"
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
            Me.txtItemCount.Size = New System.Drawing.Size(96, 21)
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
            Me.lblItemCount.Text = "จำนวนรายการคืน"
            Me.lblItemCount.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblItemCountUnit
            '
            Me.lblItemCountUnit.AutoSize = True
            Me.lblItemCountUnit.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblItemCountUnit.Location = New System.Drawing.Point(224, 16)
            Me.lblItemCountUnit.Name = "lblItemCountUnit"
            Me.lblItemCountUnit.Size = New System.Drawing.Size(38, 17)
            Me.lblItemCountUnit.TabIndex = 2
            Me.lblItemCountUnit.Text = "รายการ"
            Me.lblItemCountUnit.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtRental
            '
            Me.txtRental.BackColor = System.Drawing.SystemColors.Control
            Me.txtRental.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.Validator.SetDataType(Me.txtRental, Longkong.Pojjaman.Gui.Components.DataTypeConstants.DecimalType)
            Me.Validator.SetDisplayName(Me.txtRental, "")
            Me.Validator.SetGotFocusBackColor(Me.txtRental, System.Drawing.Color.Empty)
            Me.ErrorProvider1.SetIconPadding(Me.txtRental, -15)
            Me.Validator.SetInvalidBackColor(Me.txtRental, System.Drawing.Color.Empty)
            Me.txtRental.Location = New System.Drawing.Point(416, 16)
            Me.txtRental.MaxLength = 15
            Me.Validator.SetMaxValue(Me.txtRental, "")
            Me.Validator.SetMinValue(Me.txtRental, "")
            Me.txtRental.Name = "txtRental"
            Me.txtRental.ReadOnly = True
            Me.Validator.SetRegularExpression(Me.txtRental, "")
            Me.Validator.SetRequired(Me.txtRental, False)
            Me.txtRental.Size = New System.Drawing.Size(96, 21)
            Me.txtRental.TabIndex = 4
            Me.txtRental.TabStop = False
            Me.txtRental.Text = ""
            Me.txtRental.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
            '
            'lblRental
            '
            Me.lblRental.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblRental.Location = New System.Drawing.Point(272, 16)
            Me.lblRental.Name = "lblRental"
            Me.lblRental.Size = New System.Drawing.Size(136, 18)
            Me.lblRental.TabIndex = 3
            Me.lblRental.Text = "รวมค่าเช่าเก็บจากโครงการ"
            Me.lblRental.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblRentalUnit
            '
            Me.lblRentalUnit.AutoSize = True
            Me.lblRentalUnit.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblRentalUnit.Location = New System.Drawing.Point(520, 16)
            Me.lblRentalUnit.Name = "lblRentalUnit"
            Me.lblRentalUnit.Size = New System.Drawing.Size(25, 17)
            Me.lblRentalUnit.TabIndex = 5
            Me.lblRentalUnit.Text = "บาท"
            Me.lblRentalUnit.TextAlign = System.Drawing.ContentAlignment.MiddleRight
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
            Me.txtDocDate.Location = New System.Drawing.Point(394, 16)
            Me.Validator.SetMaxValue(Me.txtDocDate, "")
            Me.Validator.SetMinValue(Me.txtDocDate, "")
            Me.txtDocDate.Name = "txtDocDate"
            Me.Validator.SetRegularExpression(Me.txtDocDate, "")
            Me.Validator.SetRequired(Me.txtDocDate, True)
            Me.txtDocDate.Size = New System.Drawing.Size(123, 21)
            Me.txtDocDate.TabIndex = 2
            Me.txtDocDate.Text = ""
            '
            'txtCode
            '
            Me.Validator.SetDataType(Me.txtCode, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtCode, "")
            Me.Validator.SetGotFocusBackColor(Me.txtCode, System.Drawing.Color.Empty)
            Me.ErrorProvider1.SetIconPadding(Me.txtCode, -15)
            Me.Validator.SetInvalidBackColor(Me.txtCode, System.Drawing.Color.Empty)
            Me.txtCode.Location = New System.Drawing.Point(128, 16)
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
            'txtNote
            '
            Me.txtNote.BackColor = System.Drawing.SystemColors.Window
            Me.Validator.SetDataType(Me.txtNote, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtNote, "")
            Me.Validator.SetGotFocusBackColor(Me.txtNote, System.Drawing.Color.Empty)
            Me.ErrorProvider1.SetIconPadding(Me.txtNote, -15)
            Me.Validator.SetInvalidBackColor(Me.txtNote, System.Drawing.Color.Empty)
            Me.txtNote.Location = New System.Drawing.Point(128, 40)
            Me.txtNote.MaxLength = 255
            Me.Validator.SetMaxValue(Me.txtNote, "")
            Me.Validator.SetMinValue(Me.txtNote, "")
            Me.txtNote.Name = "txtNote"
            Me.Validator.SetRegularExpression(Me.txtNote, "")
            Me.Validator.SetRequired(Me.txtNote, False)
            Me.txtNote.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal
            Me.txtNote.Size = New System.Drawing.Size(560, 21)
            Me.txtNote.TabIndex = 4
            Me.txtNote.Text = ""
            '
            'txtCustomerCode
            '
            Me.Validator.SetDataType(Me.txtCustomerCode, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtCustomerCode, "")
            Me.Validator.SetGotFocusBackColor(Me.txtCustomerCode, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtCustomerCode, System.Drawing.Color.Empty)
            Me.txtCustomerCode.Location = New System.Drawing.Point(128, 16)
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
            Me.txtCustomerName.Location = New System.Drawing.Point(192, 16)
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
            'lblStatus
            '
            Me.lblStatus.AutoSize = True
            Me.lblStatus.Enabled = False
            Me.lblStatus.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.lblStatus.Location = New System.Drawing.Point(384, 240)
            Me.lblStatus.Name = "lblStatus"
            Me.lblStatus.Size = New System.Drawing.Size(47, 17)
            Me.lblStatus.TabIndex = 9
            Me.lblStatus.Text = "lblStatus"
            '
            'chkIsExternal
            '
            Me.chkIsExternal.Location = New System.Drawing.Point(8, 88)
            Me.chkIsExternal.Name = "chkIsExternal"
            Me.chkIsExternal.Size = New System.Drawing.Size(200, 24)
            Me.chkIsExternal.TabIndex = 5
            Me.chkIsExternal.Text = "รับคืนจากนอกโครงการ"
            '
            'ibtnBlank
            '
            Me.ibtnBlank.Image = CType(resources.GetObject("ibtnBlank.Image"), System.Drawing.Image)
            Me.ibtnBlank.Location = New System.Drawing.Point(192, 240)
            Me.ibtnBlank.Name = "ibtnBlank"
            Me.ibtnBlank.Size = New System.Drawing.Size(24, 24)
            Me.ibtnBlank.TabIndex = 5
            Me.ibtnBlank.TabStop = False
            Me.ibtnBlank.ThemedImage = CType(resources.GetObject("ibtnBlank.ThemedImage"), System.Drawing.Bitmap)
            '
            'ibtnDelRow
            '
            Me.ibtnDelRow.Image = CType(resources.GetObject("ibtnDelRow.Image"), System.Drawing.Image)
            Me.ibtnDelRow.Location = New System.Drawing.Point(216, 240)
            Me.ibtnDelRow.Name = "ibtnDelRow"
            Me.ibtnDelRow.Size = New System.Drawing.Size(24, 24)
            Me.ibtnDelRow.TabIndex = 6
            Me.ibtnDelRow.TabStop = False
            Me.ibtnDelRow.ThemedImage = CType(resources.GetObject("ibtnDelRow.ThemedImage"), System.Drawing.Bitmap)
            '
            'grbGeneral
            '
            Me.grbGeneral.Controls.Add(Me.txtNote)
            Me.grbGeneral.Controls.Add(Me.lblNote)
            Me.grbGeneral.Controls.Add(Me.chkAutorun)
            Me.grbGeneral.Controls.Add(Me.txtDocDate)
            Me.grbGeneral.Controls.Add(Me.dtpDocDate)
            Me.grbGeneral.Controls.Add(Me.lblDocDate)
            Me.grbGeneral.Controls.Add(Me.lblCode)
            Me.grbGeneral.Controls.Add(Me.txtCode)
            Me.grbGeneral.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.grbGeneral.Location = New System.Drawing.Point(8, 8)
            Me.grbGeneral.Name = "grbGeneral"
            Me.grbGeneral.Size = New System.Drawing.Size(744, 71)
            Me.grbGeneral.TabIndex = 0
            Me.grbGeneral.TabStop = False
            Me.grbGeneral.Text = "ผู้ส่งคืน"
            '
            'lblNote
            '
            Me.lblNote.BackColor = System.Drawing.Color.Transparent
            Me.lblNote.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblNote.Location = New System.Drawing.Point(8, 40)
            Me.lblNote.Name = "lblNote"
            Me.lblNote.Size = New System.Drawing.Size(112, 18)
            Me.lblNote.TabIndex = 6
            Me.lblNote.Text = "หมายเหตุ:"
            Me.lblNote.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'chkAutorun
            '
            Me.chkAutorun.Appearance = System.Windows.Forms.Appearance.Button
            Me.chkAutorun.Image = CType(resources.GetObject("chkAutorun.Image"), System.Drawing.Image)
            Me.chkAutorun.Location = New System.Drawing.Point(248, 16)
            Me.chkAutorun.Name = "chkAutorun"
            Me.chkAutorun.Size = New System.Drawing.Size(21, 21)
            Me.chkAutorun.TabIndex = 2
            Me.chkAutorun.TabStop = False
            '
            'dtpDocDate
            '
            Me.dtpDocDate.Format = System.Windows.Forms.DateTimePickerFormat.Short
            Me.dtpDocDate.Location = New System.Drawing.Point(394, 16)
            Me.dtpDocDate.Name = "dtpDocDate"
            Me.dtpDocDate.Size = New System.Drawing.Size(144, 21)
            Me.dtpDocDate.TabIndex = 3
            Me.dtpDocDate.TabStop = False
            '
            'lblDocDate
            '
            Me.lblDocDate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblDocDate.Location = New System.Drawing.Point(298, 16)
            Me.lblDocDate.Name = "lblDocDate"
            Me.lblDocDate.Size = New System.Drawing.Size(88, 18)
            Me.lblDocDate.TabIndex = 3
            Me.lblDocDate.Text = "วันที่เอกสาร"
            Me.lblDocDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblCode
            '
            Me.lblCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblCode.Location = New System.Drawing.Point(8, 16)
            Me.lblCode.Name = "lblCode"
            Me.lblCode.Size = New System.Drawing.Size(112, 18)
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
            Me.tgItem.Location = New System.Drawing.Point(8, 264)
            Me.tgItem.Name = "tgItem"
            Me.tgItem.ParentRowsBackColor = System.Drawing.SystemColors.ControlText
            Me.tgItem.SelectionBackColor = System.Drawing.Color.Sienna
            Me.tgItem.Size = New System.Drawing.Size(744, 104)
            Me.tgItem.SortingArrowColor = System.Drawing.Color.Red
            Me.tgItem.TabIndex = 10
            Me.tgItem.TreeManager = Nothing
            '
            'grbReturn2
            '
            Me.grbReturn2.Controls.Add(Me.btnCustomerDialog)
            Me.grbReturn2.Controls.Add(Me.lblCustomer)
            Me.grbReturn2.Controls.Add(Me.btnCustomerPanel)
            Me.grbReturn2.Controls.Add(Me.txtCustomerCode)
            Me.grbReturn2.Controls.Add(Me.txtCustomerName)
            Me.grbReturn2.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.grbReturn2.Location = New System.Drawing.Point(8, 192)
            Me.grbReturn2.Name = "grbReturn2"
            Me.grbReturn2.Size = New System.Drawing.Size(368, 48)
            Me.grbReturn2.TabIndex = 11
            Me.grbReturn2.TabStop = False
            Me.grbReturn2.Text = "ผู้ส่งคืน"
            '
            'btnCustomerDialog
            '
            Me.btnCustomerDialog.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.btnCustomerDialog.ForeColor = System.Drawing.SystemColors.Control
            Me.btnCustomerDialog.Image = CType(resources.GetObject("btnCustomerDialog.Image"), System.Drawing.Image)
            Me.btnCustomerDialog.Location = New System.Drawing.Point(312, 16)
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
            Me.lblCustomer.Location = New System.Drawing.Point(88, 16)
            Me.lblCustomer.Name = "lblCustomer"
            Me.lblCustomer.Size = New System.Drawing.Size(40, 18)
            Me.lblCustomer.TabIndex = 214
            Me.lblCustomer.Text = "ลูกค้า:"
            Me.lblCustomer.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'btnCustomerPanel
            '
            Me.btnCustomerPanel.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.btnCustomerPanel.Image = CType(resources.GetObject("btnCustomerPanel.Image"), System.Drawing.Image)
            Me.btnCustomerPanel.Location = New System.Drawing.Point(336, 16)
            Me.btnCustomerPanel.Name = "btnCustomerPanel"
            Me.btnCustomerPanel.Size = New System.Drawing.Size(24, 23)
            Me.btnCustomerPanel.TabIndex = 216
            Me.btnCustomerPanel.TabStop = False
            Me.btnCustomerPanel.ThemedImage = CType(resources.GetObject("btnCustomerPanel.ThemedImage"), System.Drawing.Bitmap)
            '
            'AssetReturnDetail
            '
            Me.Controls.Add(Me.grbReturn2)
            Me.Controls.Add(Me.tgItem)
            Me.Controls.Add(Me.grbGeneral)
            Me.Controls.Add(Me.ibtnBlank)
            Me.Controls.Add(Me.ibtnDelRow)
            Me.Controls.Add(Me.chkIsExternal)
            Me.Controls.Add(Me.lblStatus)
            Me.Controls.Add(Me.grbSummary)
            Me.Controls.Add(Me.grbRecieve)
            Me.Controls.Add(Me.grbReturn)
            Me.Controls.Add(Me.lblItem)
            Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Name = "AssetReturnDetail"
            Me.Size = New System.Drawing.Size(760, 432)
            Me.grbReturn.ResumeLayout(False)
            Me.grbRecieve.ResumeLayout(False)
            Me.grbSummary.ResumeLayout(False)
            Me.grbGeneral.ResumeLayout(False)
            CType(Me.tgItem, System.ComponentModel.ISupportInitialize).EndInit()
            Me.grbReturn2.ResumeLayout(False)
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
            Me.lblCode.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AssetReturnDetail.lblCode}")
            Me.Validator.SetDisplayName(txtCode, lblCode.Text)

            Me.lblDocDate.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AssetReturnDetail.lblDocDate}")
            Me.Validator.SetDisplayName(txtDocDate, lblDocDate.Text)

            Me.lblNote.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AssetReturnDetail.lblNote}")
            Me.Validator.SetDisplayName(txtNote, lblNote.Text)

            Me.lblRecievePerson.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AssetReturnDetail.lblRecievePerson}")
            Me.Validator.SetDisplayName(txtRecievePersonCode, lblRecievePerson.Text)

            Me.lblItem.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AssetReturnDetail.lblItem}")

            Me.lblReturnPerson.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AssetReturnDetail.lblReturnPerson}")
            Me.Validator.SetDisplayName(txtReturnPersonCode, lblReturnPerson.Text)

            Me.lblItemCount.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AssetReturnDetail.lblItemCount}")
            Me.Validator.SetDisplayName(txtItemCount, lblItemCount.Text)

            Me.lblItemCountUnit.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AssetReturnDetail.lblItemCountUnit}")

            Me.lblReturnCC.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AssetReturnDetail.lblReturnCC}")
            Me.Validator.SetDisplayName(txtReturnCCCode, lblReturnCC.Text)

            Me.lblRecieveCC.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AssetReturnDetail.lblRecieveCC}")
            Me.Validator.SetDisplayName(txtRecieveCCCode, lblRecieveCC.Text)

            'Me.chkIsExternal.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AssetReturnDetail.chkIsExternal}")

            Me.lblRental.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AssetReturnDetail.lblRental}")
            Me.Validator.SetDisplayName(txtRental, lblRental.Text)

            Me.lblCustomer.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AssetReturnDetail.lblCustomer}")
            Me.Validator.SetDisplayName(txtCustomerCode, lblCustomer.Text)
            Me.chkIsExternal.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AssetReturnDetail.chkIsExternal}")

            Me.grbReturn2.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AssetReturnDetail.grbReturn2}")

            Me.grbReturn.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AssetReturnDetail.grbReturn}")
            Me.grbRecieve.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AssetReturnDetail.grbRecieve}")
            Me.grbSummary.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AssetReturnDetail.grbSummary}")
            Me.grbGeneral.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AssetReturnDetail.grbGeneral}")
        End Sub
#End Region

#Region " Members "
        Private m_entity As AssetReturn
        Private m_isInitialized As Boolean = False
        Private m_treeManager As TreeManager
        Private m_tableStyleEnable As Hashtable
#End Region

#Region " Constructors "
        Public Sub New()
            MyBase.New()
            Me.InitializeComponent()
            Me.SetLabelText()
            Initialize()

            Dim dt As TreeTable = AssetReturn.GetSchemaTable()
            Dim dst As DataGridTableStyle = Me.CreateTableStyle()
            m_treeManager = New TreeManager(dt, tgItem)
            m_treeManager.SetTableStyle(dst)
            m_treeManager.AllowSorting = False
            m_treeManager.AllowDelete = False
            tgItem.AllowNew = False

            AddHandler dt.ColumnChanging, AddressOf ItemTreetable_ColumnChanging
            AddHandler dt.ColumnChanged, AddressOf ItemTreetable_ColumnChanged
            AddHandler dt.RowDeleted, AddressOf ItemDelete

            EventWiring()
        End Sub
#End Region

#Region " Style "
        Protected Function CreateTableStyle() As DataGridTableStyle
            Dim dst As New DataGridTableStyle
            dst.MappingName = "AssetReturn"
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


            Dim csAmount As New TreeTextColumn
            csAmount.MappingName = "Amount"
            csAmount.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.GoodsReceiptDetail.AmoluntHeaderText}")
            csAmount.NullText = ""
            csAmount.Alignment = HorizontalAlignment.Center
            csAmount.DataAlignment = HorizontalAlignment.Right
            csAmount.Format = "#,###.##"
            csAmount.TextBox.Name = "Amount"

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

#Region "Properties"
        Private ReadOnly Property CurrentItem() As AssetReturnItem
            Get
                Dim row As TreeRow = Me.m_treeManager.SelectedRow
                If row Is Nothing Then
                    Return Nothing
                End If
                If Not TypeOf row.Tag Is AssetReturnItem Then
                    Return Nothing
                End If
                Return CType(row.Tag, AssetReturnItem)
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
            Dim doc As AssetReturnItem = Me.CurrentItem
            If doc Is Nothing Then
                doc = New AssetReturnItem
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
                    Case "note"
                        If IsDBNull(e.ProposedValue) Then
                            e.ProposedValue = ""
                        End If
                        doc.Note = e.ProposedValue.ToString
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
                    Case "amount"
                        If IsDBNull(e.ProposedValue) OrElse e.ProposedValue.ToString.Length = 0 Then
                            e.ProposedValue = ""
                            Return
                        End If
                        e.ProposedValue = Configuration.FormatToString(CDec(TextParser.Evaluate(e.ProposedValue.ToString)), DigitConfig.Price)
                        Dim value As Decimal = CDec(e.ProposedValue)
                        doc.Amount = value
                End Select
            Catch ex As Exception
                MessageBox.Show(ex.ToString)
            End Try
        End Sub
        Private Sub ItemDelete(ByVal sender As Object, ByVal e As System.Data.DataRowChangeEventArgs)
        End Sub
#End Region

#Region " IListDetail "
        ' Check Enable 
        Public Overrides Sub CheckFormEnable()
            If Me.m_entity.Status.Value = 0 _
            OrElse m_entityRefed = 1 Then
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
            SetIsExternalChanged()
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
            chkIsExternal.Checked = False
        End Sub
        ' Addhandler events
        Protected Overrides Sub EventWiring()
            AddHandler txtCode.TextChanged, AddressOf Me.ChangeProperty
            AddHandler txtNote.TextChanged, AddressOf Me.ChangeProperty

            AddHandler txtDocDate.Validated, AddressOf Me.ChangeProperty
            AddHandler dtpDocDate.ValueChanged, AddressOf Me.ChangeProperty

            AddHandler txtReturnPersonCode.Validated, AddressOf Me.ChangeProperty
            AddHandler txtReturnCCCode.Validated, AddressOf Me.ChangeProperty

            AddHandler txtRecievePersonCode.Validated, AddressOf Me.ChangeProperty
            AddHandler txtRecieveCCCode.Validated, AddressOf Me.ChangeProperty

            AddHandler chkIsExternal.CheckedChanged, AddressOf Me.ChangeProperty

            AddHandler txtRental.TextChanged, AddressOf Me.ChangeProperty

            AddHandler txtCustomerCode.TextChanged, AddressOf Me.TextHandler
            AddHandler txtCustomerCode.Validated, AddressOf Me.ChangeProperty
        End Sub
        ' แสดงค่าข้อมูลของลูกค้าลงใน control ที่อยู่บนฟอร์ม
        Public Overrides Sub UpdateEntityProperties()
            Me.m_isInitialized = False
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

            chkIsExternal.Checked = Me.m_entity.IsExternal
            If chkIsExternal.Checked Then
                txtCustomerCode.Text = Me.m_entity.Customer.Code
                txtCustomerName.Text = Me.m_entity.Customer.Name
            Else
                If Not Me.m_entity.ReturnCostcenter Is Nothing Then
                    txtReturnCCCode.Text = Me.m_entity.ReturnCostcenter.Code
                    txtReturnCCName.Text = Me.m_entity.ReturnCostcenter.Name
                End If
                txtReturnPersonCode.Text = Me.m_entity.ReturnPerson.Code
                txtReturnPersonName.Text = CType(Me.m_entity.ReturnPerson, Employee).Name
            End If
            SetIsExternalChanged()

            txtRental.ReadOnly = Not Me.m_entity.IsExternal
            txtRental.Text = CStr(Me.m_entity.RentalFee)

            If Not Me.m_entity.Storeperson Is Nothing Then
                txtRecievePersonCode.Text = Me.m_entity.Storeperson.Code
                txtRecievePersonName.Text = Me.m_entity.Storeperson.Name
            End If

            If Not Me.m_entity.StoreCostcenter Is Nothing Then
                txtRecieveCCCode.Text = Me.m_entity.StoreCostcenter.Code
                txtRecieveCCName.Text = Me.m_entity.StoreCostcenter.Name
            End If

            RefreshDocs()

            SetStatus()
            SetLabelText()
            CheckFormEnable()

            Me.m_isInitialized = True
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

                Case "dtpdocdate"
                    If Not Me.m_entity.DocDate.Equals(dtpDocDate.Value) Then
                        If Not m_dateSetting Then
                            Me.txtDocDate.Text = MinDateToNull(dtpDocDate.Value, Me.StringParserService.Parse("${res:Global.BlankDateText}"))
                            Me.m_entity.DocDate = dtpDocDate.Value

                        End If
                        dirtyFlag = True
                    End If
                    DateChange()
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
                    DateChange()
                Case "chkreturn"
                    dirtyFlag = True


                Case "txtreturnpersoncode"
                    'If Me.m_entity.IsExternal Then
                    '    Dim cust As New Customer
                    '    dirtyFlag = Customer.GetCustomer(txtReturnPersonCode, txtReturnPersonName, cust)
                    '    Me.m_entity.ReturnPerson = cust
                    'Else
                    Dim emp As New Employee
                    dirtyFlag = Employee.GetEmployee(txtReturnPersonCode, txtReturnPersonName, emp)
                    Me.m_entity.ReturnPerson = emp
                    'End If

                Case "txtreturncccode"
                    dirtyFlag = CostCenter.GetCostCenter(txtReturnCCCode, txtReturnCCName, Me.m_entity.ReturnCostcenter)

                Case "txtrecievepersoncode"
                    Me.m_entity.ItemCollection.Clear()
                    RefreshBlankGrid()

                    dirtyFlag = Employee.GetEmployee(txtRecievePersonCode, txtRecievePersonName, Me.m_entity.Storeperson)

                Case "txtrecievecccode"
                    dirtyFlag = CostCenter.GetCostCenter(txtRecieveCCCode, txtRecieveCCName, Me.m_entity.StoreCostcenter)

                Case "chkisexternal"
                    dirtyFlag = True
                    Me.m_entity.IsExternal = chkIsExternal.Checked

                    SetIsExternalChanged()

                Case "txtrental"
                    dirtyFlag = True
                    If txtRental.TextLength > 0 Then
                        Me.m_entity.RentalFee = CDec(txtRental.Text)
                    Else
                        Me.m_entity.RentalFee = Nothing
                    End If
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



        Private Sub DateChange()
            For Each item As AssetReturnItem In Me.m_entity.ItemCollection
                item.Amount = Decimal.MinValue
            Next
            RefreshDocs()
        End Sub
        Private Sub UpdateAmount()
            Me.txtItemCount.Text = Configuration.FormatToString(m_entity.ItemCollection.Count, DigitConfig.Int)
            Me.txtRental.Text = Configuration.FormatToString(m_entity.ItemCollection.Amount, DigitConfig.Price)
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
        Private m_entityRefed As Integer = -1
        Public Overrides Property Entity() As ISimpleEntity
            Get
                Return Me.m_entity
            End Get
            Set(ByVal Value As ISimpleEntity)
                If Not m_entity Is Nothing Then
                    Me.m_entity = Nothing
                End If
                Me.m_entity = CType(Value, AssetReturn)
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
        Private Function GenIDListFromDataTable(ByVal type As Integer) As String
            Dim idlist As String = ""
            For Each item As AssetReturnItem In Me.m_entity.ItemCollection
                If Not item.Entity Is Nothing AndAlso item.Entity.Id <> 0 AndAlso Not item.ItemType Is Nothing AndAlso item.ItemType.Value = type Then
                    idlist &= "|" & CStr(item.Entity.Id) & "|"
                End If
            Next
            Return idlist
        End Function
        Public Sub EntityButton_Click(ByVal e As ButtonColumnEventArgs)
            Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
            'Dim person As SimpleBusinessEntityBase
            'If TypeOf Me.m_entity.ReturnPerson Is SimpleBusinessEntityBase Then
            '    person = CType(Me.m_entity.ReturnPerson, SimpleBusinessEntityBase)
            'End If
            If chkIsExternal.Checked Then
                If (Me.m_entity.Customer Is Nothing OrElse Not Me.m_entity.Customer.Originated) Then
                    msgServ.ShowWarningFormatted("${res:Longkong.Pojjaman.Gui.Panels.AssetReturnDetail.CustomerError}", lblCustomer.Text)
                    Return
                End If
            Else
                If (Me.m_entity.ReturnCostcenter Is Nothing OrElse Not Me.m_entity.ReturnCostcenter.Originated) Then
                    msgServ.ShowWarningFormatted("${res:Longkong.Pojjaman.Gui.Panels.AssetReturnDetail.ReturnCostcenterError}", lblReturnCC.Text)
                    Return
                End If
            End If
            If (Me.m_entity.StoreCostcenter Is Nothing OrElse Not Me.m_entity.StoreCostcenter.Originated) Then
                msgServ.ShowWarningFormatted("${res:Longkong.Pojjaman.Gui.Panels.AssetReturnDetail.StoreCostcenterError}", lblRecieveCC.Text)
                Return
            End If
            Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
            Dim doc As AssetReturnItem = Me.CurrentItem
            If doc Is Nothing Then
                doc = New AssetReturnItem
                doc.ItemType = New ItemType(0)
                Me.m_entity.ItemCollection.Add(doc)
                Me.m_treeManager.SelectedRow.Tag = doc
            End If

            Dim arr(6) As Filter
            arr(0) = New Filter("IDList", GenIDListFromDataTable(28))
            arr(1) = New Filter("ReturnCCID", SimpleBusinessEntityBase.ValidIdOrDBNull(Me.m_entity.FromCC))
            arr(2) = New Filter("isReturn", True)
            arr(3) = New Filter("assettype_canberented", True)
            arr(4) = New Filter("ReturnCustID", SimpleBusinessEntityBase.ValidIdOrDBNull(Me.m_entity.Customer))
            arr(5) = New Filter("IsExternal", Me.m_entity.IsExternal)
            arr(6) = New Filter("ReceiveCCID", SimpleBusinessEntityBase.ValidIdOrDBNull(Me.m_entity.StoreCostcenter))

            Dim filters(1)() As Filter
            filters(0) = arr
            filters(1) = Nothing

            Dim filterentities(1) As ArrayList
            filterentities(0) = New ArrayList
            Dim obj As New Asset
            obj.Costcenter = Me.m_entity.StoreCostcenter
            obj.Status.Value = 2   'ถูกเบิก
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
                Dim seq As Integer
                Select Case item.FullClassName.ToLower
                    Case "longkong.pojjaman.businesslogic.tool"
                        newEntity = New Tool(item.Id)
                        seq = CType(newEntity, Tool).GetLastWithdrawSequence
                        type = New ItemType(19)
                    Case "longkong.pojjaman.businesslogic.asset"
                        newEntity = New Asset(item.Id)
                        seq = CType(newEntity, Asset).GetLastWithdrawSequence
                        type = New ItemType(28)
                End Select
                Dim doc As New AssetReturnItem
                If Not Me.CurrentItem Is Nothing Then
                    doc = Me.CurrentItem
                    Me.m_treeManager.SelectedRow.Tag = Nothing
                Else
                    Me.m_entity.ItemCollection.Add(doc)
                End If
                doc.ItemType = type
                doc.Entity = newEntity
                doc.RefSequence = seq
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
            Dim item As New AssetReturnItem
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
                Return (New AssetReturn).DetailPanelIcon
            End Get
        End Property
#End Region

#Region " Event of Button controls "
        ' Return Person
        Private Sub btnReturnPersonEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReturnPersonEdit.Click
            Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
            If Me.m_entity.IsExternal Then
                myEntityPanelService.OpenPanel(New Customer)
            Else
                myEntityPanelService.OpenPanel(New Employee)
            End If
        End Sub
        Private Sub btnReturnPersonFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReturnPersonFind.Click
            Dim myEntityPanelService As IEntityPanelService = _
            CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
            If Me.m_entity.IsExternal Then
                myEntityPanelService.OpenListDialog(New Customer, AddressOf SetReturnPersonDialog)
            Else
                myEntityPanelService.OpenListDialog(New Employee, AddressOf SetReturnPersonDialog)
            End If

        End Sub

        Private Sub SetReturnPersonDialog(ByVal e As ISimpleEntity)
            Me.txtReturnPersonCode.Text = e.Code
            If Me.m_entity.IsExternal Then
                Dim cust As New Customer
                Me.WorkbenchWindow.ViewContent.IsDirty = _
                    Me.WorkbenchWindow.ViewContent.IsDirty _
                    Or Customer.GetCustomer(txtReturnPersonCode, txtReturnPersonName, cust)
                Me.m_entity.ReturnPerson = cust
            Else
                Dim emp As New Employee
                Me.WorkbenchWindow.ViewContent.IsDirty = _
                    Me.WorkbenchWindow.ViewContent.IsDirty _
                    Or Employee.GetEmployee(txtReturnPersonCode, txtReturnPersonName, emp)
                Me.m_entity.ReturnPerson = emp
            End If
        End Sub
        ' Retrun Costcenter
        Private Sub btnReturnCCEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReturnCCEdit.Click
            Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
            myEntityPanelService.OpenPanel(New CostCenter)
        End Sub
        Private Sub btnReturnCCFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReturnCCFind.Click
            Dim myEntityPanelService As IEntityPanelService = _
                        CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
            myEntityPanelService.OpenTreeDialog(New CostCenter, AddressOf SetReturnCostCenterDialog)
        End Sub
        Private Sub SetReturnCostCenterDialog(ByVal e As ISimpleEntity)
            Me.txtReturnCCCode.Text = e.Code
            Me.WorkbenchWindow.ViewContent.IsDirty = _
                Me.WorkbenchWindow.ViewContent.IsDirty _
                Or CostCenter.GetCostCenter(txtReturnCCCode, txtReturnCCName, Me.m_entity.ReturnCostcenter)
        End Sub

        ' Reciever Person
        Private Sub btnRecievePersonEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRecievePersonEdit.Click
            Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
            myEntityPanelService.OpenPanel(New Employee)
        End Sub
        Private Sub btnRecievePersonFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRecievePersonFind.Click
            Dim myEntityPanelService As IEntityPanelService = _
            CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
            myEntityPanelService.OpenListDialog(New Employee, AddressOf SetRecievePersonDialog)
        End Sub
        Private Sub SetRecievePersonDialog(ByVal e As ISimpleEntity)
            Me.txtRecievePersonCode.Text = e.Code
            Me.WorkbenchWindow.ViewContent.IsDirty = _
                Me.WorkbenchWindow.ViewContent.IsDirty _
                Or Employee.GetEmployee(txtRecievePersonCode, txtRecievePersonName, Me.m_entity.Storeperson)
        End Sub
        ' Reciever Costcenter
        Private Sub btnRecieveCCEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRecieveCCEdit.Click
            Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
            myEntityPanelService.OpenPanel(New CostCenter)
        End Sub
        Private Sub btnRecieveCCFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRecieveCCFind.Click
            Dim myEntityPanelService As IEntityPanelService = _
                        CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
            myEntityPanelService.OpenTreeDialog(New CostCenter, AddressOf SetRecieveCostCenterDialog)
        End Sub
        Private Sub SetRecieveCostCenterDialog(ByVal e As ISimpleEntity)
            Me.txtRecieveCCCode.Text = e.Code
            Me.WorkbenchWindow.ViewContent.IsDirty = _
                Me.WorkbenchWindow.ViewContent.IsDirty _
                Or CostCenter.GetCostCenter(txtRecieveCCCode, txtRecieveCCName, Me.m_entity.StoreCostcenter)
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
                            Case "txtreturnpersoncode", "txtreturnpersonname"
                                Return True
                            Case "txtrecievepersoncode", "txtrecievepersonname"
                                Return True
                        End Select
                    End If
                End If
                ' Cost center
                If data.GetDataPresent((New CostCenter).FullClassName) Then
                    If Not Me.ActiveControl Is Nothing Then
                        Select Case Me.ActiveControl.Name.ToLower
                            Case "txtreturncccode", "txtreturnccname"
                                Return True
                            Case "txtrecievecccode", "txtrecieveccname"
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
                        Case "txtreturnpersoncode", "txtreturnpersonname"
                            Me.SetReturnPersonDialog(entity)
                        Case "txtrecievepersoncode", "txtrecievepersonname"
                            Me.SetRecievePersonDialog(entity)
                    End Select
                End If
            End If
            ' Cost center
            If data.GetDataPresent((New CostCenter).FullClassName) Then
                Dim id As Integer = CInt(data.GetData((New CostCenter).FullClassName))
                Dim entity As New CostCenter(id)
                If Not Me.ActiveControl Is Nothing Then
                    Select Case Me.ActiveControl.Name.ToLower
                        Case "txtreturncccode", "txtreturnccname"
                            Me.SetReturnCostCenterDialog(entity)
                        Case "txtrecievecccode", "txtrecieveccname"
                            Me.SetRecieveCostCenterDialog(entity)
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
        Private Sub SetIsExternalChanged()
            If chkIsExternal.Checked Then

                grbReturn.Enabled = False
                grbReturn2.Enabled = True

                txtReturnCCCode.BackColor = System.Drawing.SystemColors.Control
                txtReturnPersonCode.BackColor = System.Drawing.SystemColors.Control
                txtCustomerCode.BackColor = System.Drawing.SystemColors.Window

                Me.Validator.SetRequired(Me.txtCustomerCode, True)
                Me.Validator.SetRequired(Me.txtReturnCCCode, False)
                Me.Validator.SetRequired(Me.txtReturnPersonCode, False)
                Me.ErrorProvider1.SetError(Me.txtReturnCCCode, "")
                Me.ErrorProvider1.SetError(Me.txtReturnPersonCode, "")

                For Each ctl As Control In Me.grbReturn.Controls
                    If (TypeOf (ctl) Is TextBox) Then
                        ctl.Text = ""
                    End If
                Next
            Else
                grbReturn.Enabled = True
                grbReturn2.Enabled = False

                txtReturnCCCode.BackColor = System.Drawing.SystemColors.Window
                txtReturnPersonCode.BackColor = System.Drawing.SystemColors.Window
                txtCustomerCode.BackColor = System.Drawing.SystemColors.Control

                Me.Validator.SetRequired(Me.txtCustomerCode, False)
                Me.Validator.SetRequired(Me.txtReturnCCCode, True)
                Me.Validator.SetRequired(Me.txtReturnPersonCode, True)
                Me.ErrorProvider1.SetError(Me.txtCustomerCode, "")

                For Each ctl As Control In Me.grbReturn2.Controls
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

