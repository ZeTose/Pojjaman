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
    Public Class ToolReturnDetail
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
        Friend WithEvents btnRecieveCCEdit As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents lblRecieveCC As System.Windows.Forms.Label
        Friend WithEvents txtRecieveCCCode As System.Windows.Forms.TextBox
        Friend WithEvents btnReturnCCEdit As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents txtReturnCCCode As System.Windows.Forms.TextBox
        Friend WithEvents btnReturnPersonEdit As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents btnReturnCCFind As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents txtReturnCCName As System.Windows.Forms.TextBox
        Friend WithEvents btnReturnPersonFind As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents btnRecieveCCFind As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents txtRecieveCCName As System.Windows.Forms.TextBox
        Friend WithEvents txtRecievePersonName As System.Windows.Forms.TextBox
        Friend WithEvents lblStatus As System.Windows.Forms.Label
        Friend WithEvents ibtnBlank As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents ibtnDelRow As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents btnRecievePersonFind As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents btnRecievePersonEdit As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
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
        Protected Sub InitializeComponent()
            Me.components = New System.ComponentModel.Container
            Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(ToolReturnDetail))
            Me.lblReturnCC = New System.Windows.Forms.Label
            Me.lblRecievePerson = New System.Windows.Forms.Label
            Me.lblItem = New System.Windows.Forms.Label
            Me.btnRecieveCCEdit = New Longkong.Pojjaman.Gui.Components.ImageButton
            Me.lblRecieveCC = New System.Windows.Forms.Label
            Me.txtRecieveCCCode = New System.Windows.Forms.TextBox
            Me.btnReturnCCEdit = New Longkong.Pojjaman.Gui.Components.ImageButton
            Me.txtReturnCCCode = New System.Windows.Forms.TextBox
            Me.txtRecievePersonCode = New System.Windows.Forms.TextBox
            Me.txtReturnPersonCode = New System.Windows.Forms.TextBox
            Me.lblReturnPerson = New System.Windows.Forms.Label
            Me.btnReturnPersonEdit = New Longkong.Pojjaman.Gui.Components.ImageButton
            Me.grbReturn = New Longkong.Pojjaman.Gui.Components.FixedGroupBox
            Me.btnReturnCCFind = New Longkong.Pojjaman.Gui.Components.ImageButton
            Me.txtReturnCCName = New System.Windows.Forms.TextBox
            Me.btnReturnPersonFind = New Longkong.Pojjaman.Gui.Components.ImageButton
            Me.txtReturnPersonName = New System.Windows.Forms.TextBox
            Me.grbRecieve = New Longkong.Pojjaman.Gui.Components.FixedGroupBox
            Me.btnRecievePersonFind = New Longkong.Pojjaman.Gui.Components.ImageButton
            Me.btnRecievePersonEdit = New Longkong.Pojjaman.Gui.Components.ImageButton
            Me.btnRecieveCCFind = New Longkong.Pojjaman.Gui.Components.ImageButton
            Me.txtRecieveCCName = New System.Windows.Forms.TextBox
            Me.txtRecievePersonName = New System.Windows.Forms.TextBox
            Me.grbSummary = New Longkong.Pojjaman.Gui.Components.FixedGroupBox
            Me.txtItemCount = New System.Windows.Forms.TextBox
            Me.lblItemCount = New System.Windows.Forms.Label
            Me.lblItemCountUnit = New System.Windows.Forms.Label
            Me.Validator = New Longkong.Pojjaman.Gui.Components.PJMTextboxValidator(Me.components)
            Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider
            Me.txtDocDate = New System.Windows.Forms.TextBox
            Me.txtCode = New System.Windows.Forms.TextBox
            Me.txtNote = New System.Windows.Forms.TextBox
            Me.lblStatus = New System.Windows.Forms.Label
            Me.ibtnBlank = New Longkong.Pojjaman.Gui.Components.ImageButton
            Me.ibtnDelRow = New Longkong.Pojjaman.Gui.Components.ImageButton
            Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
            Me.grbGeneral = New Longkong.Pojjaman.Gui.Components.FixedGroupBox
            Me.lblNote = New System.Windows.Forms.Label
            Me.chkAutorun = New System.Windows.Forms.CheckBox
            Me.dtpDocDate = New System.Windows.Forms.DateTimePicker
            Me.lblDocDate = New System.Windows.Forms.Label
            Me.lblCode = New System.Windows.Forms.Label
            Me.tgItem = New Longkong.Pojjaman.Gui.Components.TreeGrid
            Me.grbReturn.SuspendLayout()
            Me.grbRecieve.SuspendLayout()
            Me.grbSummary.SuspendLayout()
            Me.grbGeneral.SuspendLayout()
            CType(Me.tgItem, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'lblReturnCC
            '
            Me.lblReturnCC.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblReturnCC.Location = New System.Drawing.Point(8, 16)
            Me.lblReturnCC.Name = "lblReturnCC"
            Me.lblReturnCC.Size = New System.Drawing.Size(128, 18)
            Me.lblReturnCC.TabIndex = 0
            Me.lblReturnCC.Text = "Cost Center ที่ส่งคืน:"
            Me.lblReturnCC.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblRecievePerson
            '
            Me.lblRecievePerson.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblRecievePerson.Location = New System.Drawing.Point(8, 40)
            Me.lblRecievePerson.Name = "lblRecievePerson"
            Me.lblRecievePerson.Size = New System.Drawing.Size(136, 18)
            Me.lblRecievePerson.TabIndex = 5
            Me.lblRecievePerson.Text = "ผู้รับคืน:"
            Me.lblRecievePerson.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblItem
            '
            Me.lblItem.AutoSize = True
            Me.lblItem.BackColor = System.Drawing.Color.Transparent
            Me.lblItem.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblItem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.lblItem.Location = New System.Drawing.Point(16, 160)
            Me.lblItem.Name = "lblItem"
            Me.lblItem.Size = New System.Drawing.Size(128, 19)
            Me.lblItem.TabIndex = 9
            Me.lblItem.Text = "รายการคืนเครื่องมือ:"
            Me.lblItem.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'btnRecieveCCEdit
            '
            Me.btnRecieveCCEdit.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.btnRecieveCCEdit.Image = CType(resources.GetObject("btnRecieveCCEdit.Image"), System.Drawing.Image)
            Me.btnRecieveCCEdit.Location = New System.Drawing.Point(360, 16)
            Me.btnRecieveCCEdit.Name = "btnRecieveCCEdit"
            Me.btnRecieveCCEdit.Size = New System.Drawing.Size(24, 23)
            Me.btnRecieveCCEdit.TabIndex = 4
            Me.btnRecieveCCEdit.TabStop = False
            Me.btnRecieveCCEdit.ThemedImage = CType(resources.GetObject("btnRecieveCCEdit.ThemedImage"), System.Drawing.Bitmap)
            '
            'lblRecieveCC
            '
            Me.lblRecieveCC.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblRecieveCC.Location = New System.Drawing.Point(8, 16)
            Me.lblRecieveCC.Name = "lblRecieveCC"
            Me.lblRecieveCC.Size = New System.Drawing.Size(136, 18)
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
            Me.txtRecieveCCCode.Location = New System.Drawing.Point(152, 16)
            Me.txtRecieveCCCode.MaxLength = 20
            Me.Validator.SetMaxValue(Me.txtRecieveCCCode, "")
            Me.Validator.SetMinValue(Me.txtRecieveCCCode, "")
            Me.txtRecieveCCCode.Name = "txtRecieveCCCode"
            Me.Validator.SetRegularExpression(Me.txtRecieveCCCode, "")
            Me.Validator.SetRequired(Me.txtRecieveCCCode, False)
            Me.txtRecieveCCCode.Size = New System.Drawing.Size(64, 21)
            Me.txtRecieveCCCode.TabIndex = 7
            Me.txtRecieveCCCode.Text = ""
            '
            'btnReturnCCEdit
            '
            Me.btnReturnCCEdit.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.btnReturnCCEdit.Image = CType(resources.GetObject("btnReturnCCEdit.Image"), System.Drawing.Image)
            Me.btnReturnCCEdit.Location = New System.Drawing.Point(352, 16)
            Me.btnReturnCCEdit.Name = "btnReturnCCEdit"
            Me.btnReturnCCEdit.Size = New System.Drawing.Size(24, 23)
            Me.btnReturnCCEdit.TabIndex = 4
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
            Me.txtReturnCCCode.Location = New System.Drawing.Point(144, 16)
            Me.txtReturnCCCode.MaxLength = 20
            Me.Validator.SetMaxValue(Me.txtReturnCCCode, "")
            Me.Validator.SetMinValue(Me.txtReturnCCCode, "")
            Me.txtReturnCCCode.Name = "txtReturnCCCode"
            Me.Validator.SetRegularExpression(Me.txtReturnCCCode, "")
            Me.Validator.SetRequired(Me.txtReturnCCCode, False)
            Me.txtReturnCCCode.Size = New System.Drawing.Size(64, 21)
            Me.txtReturnCCCode.TabIndex = 5
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
            Me.txtRecievePersonCode.Location = New System.Drawing.Point(152, 40)
            Me.txtRecievePersonCode.MaxLength = 20
            Me.Validator.SetMaxValue(Me.txtRecievePersonCode, "")
            Me.Validator.SetMinValue(Me.txtRecievePersonCode, "")
            Me.txtRecievePersonCode.Name = "txtRecievePersonCode"
            Me.Validator.SetRegularExpression(Me.txtRecievePersonCode, "")
            Me.Validator.SetRequired(Me.txtRecievePersonCode, False)
            Me.txtRecievePersonCode.Size = New System.Drawing.Size(64, 21)
            Me.txtRecievePersonCode.TabIndex = 8
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
            Me.txtReturnPersonCode.Location = New System.Drawing.Point(144, 40)
            Me.txtReturnPersonCode.MaxLength = 20
            Me.Validator.SetMaxValue(Me.txtReturnPersonCode, "")
            Me.Validator.SetMinValue(Me.txtReturnPersonCode, "")
            Me.txtReturnPersonCode.Name = "txtReturnPersonCode"
            Me.Validator.SetRegularExpression(Me.txtReturnPersonCode, "")
            Me.Validator.SetRequired(Me.txtReturnPersonCode, True)
            Me.txtReturnPersonCode.Size = New System.Drawing.Size(64, 21)
            Me.txtReturnPersonCode.TabIndex = 6
            Me.txtReturnPersonCode.Text = ""
            '
            'lblReturnPerson
            '
            Me.lblReturnPerson.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblReturnPerson.Location = New System.Drawing.Point(8, 40)
            Me.lblReturnPerson.Name = "lblReturnPerson"
            Me.lblReturnPerson.Size = New System.Drawing.Size(128, 18)
            Me.lblReturnPerson.TabIndex = 5
            Me.lblReturnPerson.Text = "ผู้ส่งคืน:"
            Me.lblReturnPerson.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'btnReturnPersonEdit
            '
            Me.btnReturnPersonEdit.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.btnReturnPersonEdit.Image = CType(resources.GetObject("btnReturnPersonEdit.Image"), System.Drawing.Image)
            Me.btnReturnPersonEdit.Location = New System.Drawing.Point(352, 40)
            Me.btnReturnPersonEdit.Name = "btnReturnPersonEdit"
            Me.btnReturnPersonEdit.Size = New System.Drawing.Size(24, 23)
            Me.btnReturnPersonEdit.TabIndex = 9
            Me.btnReturnPersonEdit.TabStop = False
            Me.btnReturnPersonEdit.ThemedImage = CType(resources.GetObject("btnReturnPersonEdit.ThemedImage"), System.Drawing.Bitmap)
            '
            'grbReturn
            '
            Me.grbReturn.Controls.Add(Me.btnReturnCCFind)
            Me.grbReturn.Controls.Add(Me.txtReturnCCName)
            Me.grbReturn.Controls.Add(Me.btnReturnPersonFind)
            Me.grbReturn.Controls.Add(Me.txtReturnPersonCode)
            Me.grbReturn.Controls.Add(Me.lblReturnPerson)
            Me.grbReturn.Controls.Add(Me.lblReturnCC)
            Me.grbReturn.Controls.Add(Me.btnReturnCCEdit)
            Me.grbReturn.Controls.Add(Me.txtReturnCCCode)
            Me.grbReturn.Controls.Add(Me.btnReturnPersonEdit)
            Me.grbReturn.Controls.Add(Me.txtReturnPersonName)
            Me.grbReturn.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.grbReturn.Location = New System.Drawing.Point(8, 80)
            Me.grbReturn.Name = "grbReturn"
            Me.grbReturn.Size = New System.Drawing.Size(384, 72)
            Me.grbReturn.TabIndex = 5
            Me.grbReturn.TabStop = False
            Me.grbReturn.Text = "ผู้ส่งคืน"
            '
            'btnReturnCCFind
            '
            Me.btnReturnCCFind.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.btnReturnCCFind.ForeColor = System.Drawing.SystemColors.Control
            Me.btnReturnCCFind.Image = CType(resources.GetObject("btnReturnCCFind.Image"), System.Drawing.Image)
            Me.btnReturnCCFind.Location = New System.Drawing.Point(328, 16)
            Me.btnReturnCCFind.Name = "btnReturnCCFind"
            Me.btnReturnCCFind.Size = New System.Drawing.Size(24, 23)
            Me.btnReturnCCFind.TabIndex = 3
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
            Me.txtReturnCCName.Location = New System.Drawing.Point(208, 16)
            Me.Validator.SetMaxValue(Me.txtReturnCCName, "")
            Me.Validator.SetMinValue(Me.txtReturnCCName, "")
            Me.txtReturnCCName.Name = "txtReturnCCName"
            Me.txtReturnCCName.ReadOnly = True
            Me.Validator.SetRegularExpression(Me.txtReturnCCName, "")
            Me.Validator.SetRequired(Me.txtReturnCCName, False)
            Me.txtReturnCCName.Size = New System.Drawing.Size(120, 21)
            Me.txtReturnCCName.TabIndex = 4
            Me.txtReturnCCName.TabStop = False
            Me.txtReturnCCName.Text = ""
            '
            'btnReturnPersonFind
            '
            Me.btnReturnPersonFind.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.btnReturnPersonFind.ForeColor = System.Drawing.SystemColors.Control
            Me.btnReturnPersonFind.Image = CType(resources.GetObject("btnReturnPersonFind.Image"), System.Drawing.Image)
            Me.btnReturnPersonFind.Location = New System.Drawing.Point(328, 40)
            Me.btnReturnPersonFind.Name = "btnReturnPersonFind"
            Me.btnReturnPersonFind.Size = New System.Drawing.Size(24, 23)
            Me.btnReturnPersonFind.TabIndex = 8
            Me.btnReturnPersonFind.TabStop = False
            Me.btnReturnPersonFind.ThemedImage = CType(resources.GetObject("btnReturnPersonFind.ThemedImage"), System.Drawing.Bitmap)
            '
            'txtReturnPersonName
            '
            Me.txtReturnPersonName.BackColor = System.Drawing.SystemColors.Control
            Me.Validator.SetDataType(Me.txtReturnPersonName, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtReturnPersonName, "")
            Me.Validator.SetGotFocusBackColor(Me.txtReturnPersonName, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtReturnPersonName, System.Drawing.Color.Empty)
            Me.txtReturnPersonName.Location = New System.Drawing.Point(208, 40)
            Me.Validator.SetMaxValue(Me.txtReturnPersonName, "")
            Me.Validator.SetMinValue(Me.txtReturnPersonName, "")
            Me.txtReturnPersonName.Name = "txtReturnPersonName"
            Me.txtReturnPersonName.ReadOnly = True
            Me.Validator.SetRegularExpression(Me.txtReturnPersonName, "")
            Me.Validator.SetRequired(Me.txtReturnPersonName, False)
            Me.txtReturnPersonName.Size = New System.Drawing.Size(120, 21)
            Me.txtReturnPersonName.TabIndex = 6
            Me.txtReturnPersonName.TabStop = False
            Me.txtReturnPersonName.Text = ""
            '
            'grbRecieve
            '
            Me.grbRecieve.Controls.Add(Me.btnRecievePersonFind)
            Me.grbRecieve.Controls.Add(Me.btnRecievePersonEdit)
            Me.grbRecieve.Controls.Add(Me.btnRecieveCCFind)
            Me.grbRecieve.Controls.Add(Me.txtRecieveCCName)
            Me.grbRecieve.Controls.Add(Me.txtRecievePersonName)
            Me.grbRecieve.Controls.Add(Me.txtRecieveCCCode)
            Me.grbRecieve.Controls.Add(Me.lblRecievePerson)
            Me.grbRecieve.Controls.Add(Me.btnRecieveCCEdit)
            Me.grbRecieve.Controls.Add(Me.lblRecieveCC)
            Me.grbRecieve.Controls.Add(Me.txtRecievePersonCode)
            Me.grbRecieve.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.grbRecieve.Location = New System.Drawing.Point(400, 80)
            Me.grbRecieve.Name = "grbRecieve"
            Me.grbRecieve.Size = New System.Drawing.Size(392, 72)
            Me.grbRecieve.TabIndex = 6
            Me.grbRecieve.TabStop = False
            Me.grbRecieve.Text = "ผู้รับคืน"
            '
            'btnRecievePersonFind
            '
            Me.btnRecievePersonFind.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.btnRecievePersonFind.ForeColor = System.Drawing.SystemColors.Control
            Me.btnRecievePersonFind.Image = CType(resources.GetObject("btnRecievePersonFind.Image"), System.Drawing.Image)
            Me.btnRecievePersonFind.Location = New System.Drawing.Point(336, 40)
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
            Me.btnRecievePersonEdit.Location = New System.Drawing.Point(360, 40)
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
            Me.btnRecieveCCFind.Location = New System.Drawing.Point(336, 16)
            Me.btnRecieveCCFind.Name = "btnRecieveCCFind"
            Me.btnRecieveCCFind.Size = New System.Drawing.Size(24, 23)
            Me.btnRecieveCCFind.TabIndex = 3
            Me.btnRecieveCCFind.TabStop = False
            Me.btnRecieveCCFind.ThemedImage = CType(resources.GetObject("btnRecieveCCFind.ThemedImage"), System.Drawing.Bitmap)
            '
            'txtRecieveCCName
            '
            Me.txtRecieveCCName.BackColor = System.Drawing.SystemColors.Control
            Me.Validator.SetDataType(Me.txtRecieveCCName, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtRecieveCCName, "")
            Me.Validator.SetGotFocusBackColor(Me.txtRecieveCCName, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtRecieveCCName, System.Drawing.Color.Empty)
            Me.txtRecieveCCName.Location = New System.Drawing.Point(216, 16)
            Me.Validator.SetMaxValue(Me.txtRecieveCCName, "")
            Me.Validator.SetMinValue(Me.txtRecieveCCName, "")
            Me.txtRecieveCCName.Name = "txtRecieveCCName"
            Me.txtRecieveCCName.ReadOnly = True
            Me.Validator.SetRegularExpression(Me.txtRecieveCCName, "")
            Me.Validator.SetRequired(Me.txtRecieveCCName, False)
            Me.txtRecieveCCName.Size = New System.Drawing.Size(120, 21)
            Me.txtRecieveCCName.TabIndex = 8
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
            Me.txtRecievePersonName.Location = New System.Drawing.Point(216, 40)
            Me.Validator.SetMaxValue(Me.txtRecievePersonName, "")
            Me.Validator.SetMinValue(Me.txtRecievePersonName, "")
            Me.txtRecievePersonName.Name = "txtRecievePersonName"
            Me.txtRecievePersonName.ReadOnly = True
            Me.Validator.SetRegularExpression(Me.txtRecievePersonName, "")
            Me.Validator.SetRequired(Me.txtRecievePersonName, False)
            Me.txtRecievePersonName.Size = New System.Drawing.Size(120, 21)
            Me.txtRecievePersonName.TabIndex = 10
            Me.txtRecievePersonName.TabStop = False
            Me.txtRecievePersonName.Text = ""
            '
            'grbSummary
            '
            Me.grbSummary.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
            Me.grbSummary.Controls.Add(Me.txtItemCount)
            Me.grbSummary.Controls.Add(Me.lblItemCount)
            Me.grbSummary.Controls.Add(Me.lblItemCountUnit)
            Me.grbSummary.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.grbSummary.Location = New System.Drawing.Point(424, 376)
            Me.grbSummary.Name = "grbSummary"
            Me.grbSummary.Size = New System.Drawing.Size(360, 48)
            Me.grbSummary.TabIndex = 13
            Me.grbSummary.TabStop = False
            Me.grbSummary.Text = "สรุปยอดคืนเครื่องมือ"
            '
            'txtItemCount
            '
            Me.txtItemCount.BackColor = System.Drawing.SystemColors.Control
            Me.txtItemCount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.Validator.SetDataType(Me.txtItemCount, Longkong.Pojjaman.Gui.Components.DataTypeConstants.Int32Type)
            Me.Validator.SetDisplayName(Me.txtItemCount, "")
            Me.Validator.SetGotFocusBackColor(Me.txtItemCount, System.Drawing.Color.Empty)
            Me.ErrorProvider1.SetIconPadding(Me.txtItemCount, -15)
            Me.Validator.SetInvalidBackColor(Me.txtItemCount, System.Drawing.Color.Empty)
            Me.txtItemCount.Location = New System.Drawing.Point(168, 15)
            Me.Validator.SetMaxValue(Me.txtItemCount, "")
            Me.Validator.SetMinValue(Me.txtItemCount, "")
            Me.txtItemCount.Name = "txtItemCount"
            Me.txtItemCount.ReadOnly = True
            Me.Validator.SetRegularExpression(Me.txtItemCount, "")
            Me.Validator.SetRequired(Me.txtItemCount, False)
            Me.txtItemCount.Size = New System.Drawing.Size(88, 21)
            Me.txtItemCount.TabIndex = 12
            Me.txtItemCount.TabStop = False
            Me.txtItemCount.Text = ""
            Me.txtItemCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
            '
            'lblItemCount
            '
            Me.lblItemCount.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblItemCount.Location = New System.Drawing.Point(8, 16)
            Me.lblItemCount.Name = "lblItemCount"
            Me.lblItemCount.Size = New System.Drawing.Size(152, 18)
            Me.lblItemCount.TabIndex = 0
            Me.lblItemCount.Text = "จำนวนรายการคืน"
            Me.lblItemCount.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblItemCountUnit
            '
            Me.lblItemCountUnit.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblItemCountUnit.Location = New System.Drawing.Point(264, 16)
            Me.lblItemCountUnit.Name = "lblItemCountUnit"
            Me.lblItemCountUnit.Size = New System.Drawing.Size(40, 18)
            Me.lblItemCountUnit.TabIndex = 2
            Me.lblItemCountUnit.Text = "รายการ"
            Me.lblItemCountUnit.TextAlign = System.Drawing.ContentAlignment.MiddleRight
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
            Me.txtDocDate.Location = New System.Drawing.Point(376, 16)
            Me.txtDocDate.MaxLength = 20
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
            Me.txtCode.Size = New System.Drawing.Size(112, 21)
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
            'lblStatus
            '
            Me.lblStatus.AutoSize = True
            Me.lblStatus.Enabled = False
            Me.lblStatus.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.lblStatus.Location = New System.Drawing.Point(392, 160)
            Me.lblStatus.Name = "lblStatus"
            Me.lblStatus.Size = New System.Drawing.Size(47, 17)
            Me.lblStatus.TabIndex = 14
            Me.lblStatus.Text = "lblStatus"
            '
            'ibtnBlank
            '
            Me.ibtnBlank.Image = CType(resources.GetObject("ibtnBlank.Image"), System.Drawing.Image)
            Me.ibtnBlank.Location = New System.Drawing.Point(200, 154)
            Me.ibtnBlank.Name = "ibtnBlank"
            Me.ibtnBlank.Size = New System.Drawing.Size(32, 32)
            Me.ibtnBlank.TabIndex = 11
            Me.ibtnBlank.TabStop = False
            Me.ibtnBlank.ThemedImage = CType(resources.GetObject("ibtnBlank.ThemedImage"), System.Drawing.Bitmap)
            '
            'ibtnDelRow
            '
            Me.ibtnDelRow.Image = CType(resources.GetObject("ibtnDelRow.Image"), System.Drawing.Image)
            Me.ibtnDelRow.Location = New System.Drawing.Point(232, 154)
            Me.ibtnDelRow.Name = "ibtnDelRow"
            Me.ibtnDelRow.Size = New System.Drawing.Size(32, 32)
            Me.ibtnDelRow.TabIndex = 12
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
            Me.grbGeneral.Size = New System.Drawing.Size(784, 72)
            Me.grbGeneral.TabIndex = 325
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
            Me.lblNote.TabIndex = 331
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
            Me.chkAutorun.TabIndex = 330
            Me.chkAutorun.TabStop = False
            '
            'dtpDocDate
            '
            Me.dtpDocDate.Format = System.Windows.Forms.DateTimePickerFormat.Short
            Me.dtpDocDate.Location = New System.Drawing.Point(376, 16)
            Me.dtpDocDate.Name = "dtpDocDate"
            Me.dtpDocDate.Size = New System.Drawing.Size(144, 21)
            Me.dtpDocDate.TabIndex = 3
            Me.dtpDocDate.TabStop = False
            '
            'lblDocDate
            '
            Me.lblDocDate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblDocDate.Location = New System.Drawing.Point(280, 16)
            Me.lblDocDate.Name = "lblDocDate"
            Me.lblDocDate.Size = New System.Drawing.Size(88, 18)
            Me.lblDocDate.TabIndex = 326
            Me.lblDocDate.Text = "วันที่เอกสาร"
            Me.lblDocDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblCode
            '
            Me.lblCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblCode.Location = New System.Drawing.Point(8, 16)
            Me.lblCode.Name = "lblCode"
            Me.lblCode.Size = New System.Drawing.Size(112, 18)
            Me.lblCode.TabIndex = 325
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
            Me.tgItem.Location = New System.Drawing.Point(8, 186)
            Me.tgItem.Name = "tgItem"
            Me.tgItem.ParentRowsBackColor = System.Drawing.SystemColors.ControlText
            Me.tgItem.SelectionBackColor = System.Drawing.Color.Sienna
            Me.tgItem.Size = New System.Drawing.Size(784, 182)
            Me.tgItem.SortingArrowColor = System.Drawing.Color.Red
            Me.tgItem.TabIndex = 9
            Me.tgItem.TreeManager = Nothing
            '
            'ToolReturnDetail
            '
            Me.Controls.Add(Me.tgItem)
            Me.Controls.Add(Me.grbGeneral)
            Me.Controls.Add(Me.ibtnBlank)
            Me.Controls.Add(Me.ibtnDelRow)
            Me.Controls.Add(Me.lblStatus)
            Me.Controls.Add(Me.grbSummary)
            Me.Controls.Add(Me.grbRecieve)
            Me.Controls.Add(Me.grbReturn)
            Me.Controls.Add(Me.lblItem)
            Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Name = "ToolReturnDetail"
            Me.Size = New System.Drawing.Size(800, 432)
            Me.grbReturn.ResumeLayout(False)
            Me.grbRecieve.ResumeLayout(False)
            Me.grbSummary.ResumeLayout(False)
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

#Region "Members"
        Private m_entity As ToolReturn
        Private m_printDocument As PrintDocument
        Private m_printingStringFormat As StringFormat

        Private m_isInitialized As Boolean = False
        Private m_treeManager As TreeManager
        Private m_tableStyleEnable As Hashtable
#End Region

#Region " SetLabelText "
        Public Overrides Sub SetLabelText()
            If Not m_entity Is Nothing Then Me.Text = Me.StringParserService.Parse(Me.m_entity.TabPageText)
            Me.lblCode.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ToolReturnDetail.lblCode}")
            Me.Validator.SetDisplayName(Me.txtCode, StringHelper.GetRidOfAtEnd(Me.lblCode.Text, ":"))

            Me.lblDocDate.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ToolReturnDetail.lblDocDate}")
            Me.Validator.SetDisplayName(Me.txtDocDate, StringHelper.GetRidOfAtEnd(Me.lblDocDate.Text, ":"))

            Me.lblNote.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ToolReturnDetail.lblNote}")
            Me.Validator.SetDisplayName(Me.txtNote, StringHelper.GetRidOfAtEnd(Me.lblNote.Text, ":"))

            Me.lblRecievePerson.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ToolReturnDetail.lblReceivePerson}")
            Me.Validator.SetDisplayName(Me.txtRecievePersonCode, StringHelper.GetRidOfAtEnd(Me.lblRecievePerson.Text, ":"))

            Me.lblItem.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ToolReturnDetail.lblItem}")

            Me.lblReturnPerson.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ToolReturnDetail.lblReturnPerson}")
            Me.Validator.SetDisplayName(Me.txtReturnPersonCode, StringHelper.GetRidOfAtEnd(Me.lblReturnPerson.Text, ":"))

            Me.lblItemCount.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ToolReturnDetail.lblItemCount}")
            Me.Validator.SetDisplayName(Me.txtItemCount, StringHelper.GetRidOfAtEnd(Me.lblItemCount.Text, ":"))

            Me.lblItemCountUnit.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ToolReturnDetail.lblItemCountUnit}")

            Me.lblReturnCC.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ToolReturnDetail.lblReturnCC}")
            Me.Validator.SetDisplayName(Me.txtReturnCCCode, StringHelper.GetRidOfAtEnd(Me.lblReturnCC.Text, ":"))

            Me.lblRecieveCC.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ToolReturnDetail.lblRecieveCC}")
            Me.Validator.SetDisplayName(Me.txtRecieveCCCode, StringHelper.GetRidOfAtEnd(Me.lblRecieveCC.Text, ":"))

            Me.chkAutorun.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ToolReturnDetail.chkAutorun}")

            Me.grbReturn.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ToolReturnDetail.grbReturn}")
            Me.grbRecieve.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ToolReturnDetail.grbRecieve}")
            Me.grbSummary.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ToolReturnDetail.grbSummary}")
            Me.grbGeneral.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ToolReturnDetail.grbGeneral}")
        End Sub
#End Region

#Region " Constructors "
        Public Sub New()
            MyBase.New()
            Me.InitializeComponent()
            Me.SetLabelText()

            Initialize()

            Dim dt As TreeTable = ToolReturn.GetSchemaTable()
            Dim dst As DataGridTableStyle = Me.CreateTableStyle()
            m_treeManager = New TreeManager(dt, tgItem)
            m_treeManager.SetTableStyle(dst)
            m_treeManager.AllowSorting = False
            m_treeManager.AllowDelete = False
            tgItem.AllowNew = False

            EventWiring()
        End Sub
#End Region

#Region " Style "
        Public Function CreateTableStyle() As DataGridTableStyle
            Dim dst As New DataGridTableStyle
            dst.MappingName = "StockItem"
            Dim myStringParserService As StringParserService = CType(ServiceManager.Services.GetService(GetType(StringParserService)), StringParserService)

            Dim csLineNumber As New TreeTextColumn
            csLineNumber.MappingName = "stocki_lineNumber"
            csLineNumber.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ToolreturnDetail.LineNumberHeaderText}")
            csLineNumber.NullText = ""
            csLineNumber.Width = 30
            csLineNumber.Alignment = HorizontalAlignment.Center
            csLineNumber.DataAlignment = HorizontalAlignment.Center
            csLineNumber.ReadOnly = True
            csLineNumber.TextBox.Name = "stocki_lineNumber"

            Dim csCode As New TreeTextColumn
            csCode.MappingName = "Code"
            csCode.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ToolreturnDetail.CodeHeaderText}")
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
            csName.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ToolreturnDetail.NameHeaderText}")
            csName.NullText = ""
            csName.Alignment = HorizontalAlignment.Center
            csName.DataAlignment = HorizontalAlignment.Left
            csName.Width = 150
            csName.ReadOnly = True
            csName.TextBox.Name = "Name"

            Dim csToolg As New TreeTextColumn
            csToolg.MappingName = "ToolGroup"
            csToolg.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ToolreturnDetail.GroupHeaderText}")
            csToolg.NullText = ""
            csToolg.Alignment = HorizontalAlignment.Center
            csToolg.DataAlignment = HorizontalAlignment.Left
            csToolg.Width = 150
            csToolg.ReadOnly = True
            csToolg.TextBox.Name = "ToolGroup"

            Dim csUnit As New TreeTextColumn
            csUnit.MappingName = "UnitName"
            csUnit.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ToolreturnDetail.UnitHeaderText}")
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
            csQty.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ToolreturnDetail.QtyHeaderText}")
            csQty.NullText = ""
            csQty.Alignment = HorizontalAlignment.Center
            csQty.DataAlignment = HorizontalAlignment.Right
            csQty.Format = "#,##0.00"
            csQty.Width = 100
            csQty.ReadOnly = False
            csQty.TextBox.Name = "stocki_qty"


            Dim csNote As New TreeTextColumn
            csNote.MappingName = "stocki_note"
            csNote.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ToolreturnDetail.NoteHeaderText}")
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
        Public Sub GridButton_Clicked(ByVal e As ButtonColumnEventArgs)
            If e.Column = 2 Then
                EntityButton_Click(e)
            Else
                ' กรณีอื่น ๆ ...
            End If
        End Sub
#End Region

#Region " IListDetail "
        ' Check Enable 
        Public Overrides Sub CheckFormEnable()
            If Me.m_entity.Canceled Then
                For Each ctrl As Control In Me.Controls
                    ctrl.Enabled = False
                Next
                ' DataGrid Configuration
                tgItem.Enabled = True
                For Each colStyle As DataGridColumnStyle In Me.m_treeManager.GridTableStyle.GridColumnStyles
                    colStyle.ReadOnly = True
                Next
            Else
                For Each ctrl As Control In Me.Controls
                    ctrl.Enabled = True
                Next
                ' DataGrid Configuration
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
            Me.dtpDocDate.Value = Now
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

            If Not Me.m_entity.ReturnPerson Is Nothing Then
                txtReturnPersonCode.Text = Me.m_entity.ReturnPerson.Code
                txtReturnPersonName.Text = Me.m_entity.ReturnPerson.Name
            End If

            If Not Me.m_entity.ReturnCostcenter Is Nothing Then
                txtReturnCCCode.Text = Me.m_entity.ReturnCostcenter.Code
                txtReturnCCName.Text = Me.m_entity.ReturnCostcenter.Name
            End If

            If Not Me.m_entity.Recieveperson Is Nothing Then
                txtRecievePersonCode.Text = Me.m_entity.Recieveperson.Code
                txtRecievePersonName.Text = Me.m_entity.Recieveperson.Name
            End If

            If Not Me.m_entity.RecieveCostcenter Is Nothing Then
                txtRecieveCCCode.Text = Me.m_entity.RecieveCostcenter.Code
                txtRecieveCCName.Text = Me.m_entity.RecieveCostcenter.Name
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

                Case "chkreturn"
                    dirtyFlag = True


                Case "txtreturnpersoncode"
                    dirtyFlag = Employee.GetEmployee(txtReturnPersonCode, txtReturnPersonName, Me.m_entity.ReturnPerson)

                Case "txtreturncccode"
                    dirtyFlag = CostCenter.GetCostCenterWithoutRight(txtReturnCCCode, txtReturnCCName, Me.m_entity.ReturnCostcenter)

                Case "txtrecievepersoncode"
                    dirtyFlag = Employee.GetEmployee(txtRecievePersonCode, txtRecievePersonName, Me.m_entity.Recieveperson)

                Case "txtrecievecccode"
                    dirtyFlag = CostCenter.GetCostCenter(txtRecieveCCCode, txtRecieveCCName, Me.m_entity.RecieveCostcenter, CType(ServiceManager.Services.GetService(GetType(SecurityService)), SecurityService).CurrentUser.Id)

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
                Me.m_entity = CType(Value, ToolReturn)
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
            entity.FromWip = False 'True
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
                myItem.CostCenter = Me.m_entity.RecieveCostcenter

                myItem.ItemType = New ItemType(newItem.EntityId)
                myItem.Type = New StockDocType(Me.m_entity.EntityId)

                myItem.Qty = 1

                If i = items.Count - 1 Then
                    If Me.m_entity.ItemTable.Childs.Count = 0 Then
                        Me.m_entity.Add(myItem)
                    Else
                        myItem.LineNumber = CInt(Me.m_entity.ItemTable.Childs(index)("stocki_lineNumber"))
                        myItem.EntityBase = Me.m_entity
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
                Return (New ToolReturn).DetailPanelIcon
            End Get
        End Property
#End Region

#Region " Event of Button controls "
        ' Return Person
        Private Sub btnReturnPersonEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReturnPersonEdit.Click
            Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
            myEntityPanelService.OpenPanel(New Employee)
        End Sub
        Private Sub btnReturnPersonFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReturnPersonFind.Click
            Dim myEntityPanelService As IEntityPanelService = _
             CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
            myEntityPanelService.OpenListDialog(New Employee, AddressOf SetReturnPersonDialog)
        End Sub

        Private Sub SetReturnPersonDialog(ByVal e As ISimpleEntity)
            Me.txtReturnPersonCode.Text = e.Code
            Me.WorkbenchWindow.ViewContent.IsDirty = _
                Me.WorkbenchWindow.ViewContent.IsDirty _
                Or Employee.GetEmployee(txtReturnPersonCode, txtReturnPersonName, Me.m_entity.ReturnPerson)
        End Sub
        ' Retrun Costcenter
        Private Sub btnReturnCCEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReturnCCEdit.Click
            Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
            myEntityPanelService.OpenPanel(New CostCenter)
        End Sub
        Private Sub btnReturnCCFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReturnCCFind.Click
            Dim myEntityPanelService As IEntityPanelService = _
                         CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
            myEntityPanelService.OpenTreeDialog(New CostCenter, AddressOf SetReturnCostCenterDialog, New Filter() {New Filter("checkright", False)})
        End Sub
        Private Sub SetReturnCostCenterDialog(ByVal e As ISimpleEntity)
            Me.txtReturnCCCode.Text = e.Code
            Me.WorkbenchWindow.ViewContent.IsDirty = _
                Me.WorkbenchWindow.ViewContent.IsDirty _
                Or CostCenter.GetCostCenterWithoutRight(txtReturnCCCode, txtReturnCCName, Me.m_entity.ReturnCostcenter)
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
                Or Employee.GetEmployee(txtRecievePersonCode, txtRecievePersonName, Me.m_entity.Recieveperson)
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
                Or CostCenter.GetCostCenter(txtRecieveCCCode, txtRecieveCCName, Me.m_entity.RecieveCostcenter, CType(ServiceManager.Services.GetService(GetType(SecurityService)), SecurityService).CurrentUser.Id)
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

