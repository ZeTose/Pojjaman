Imports Longkong.Pojjaman.BusinessLogic
Imports Longkong.Pojjaman.TextHelper
Imports Longkong.Pojjaman.Gui.Components
Imports Longkong.Pojjaman.Services
Imports Longkong.Core.Services
Imports System.Reflection
Imports Longkong.Pojjaman.DataAccessLayer
Imports System.Drawing.Printing
Imports Longkong.Pojjaman.Gui.ReportsAndDocs
Imports System.IO
Imports Longkong.Core.Properties
Imports Longkong.AdobeForm
Namespace Longkong.Pojjaman.Gui.Panels
    Public Class JournalEntryFilterSubPanel
        Inherits AbstractFilterSubPanel

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
        Friend WithEvents grbDetail As Longkong.Pojjaman.Gui.Components.FixedGroupBox
        Friend WithEvents lblCode As System.Windows.Forms.Label
        Friend WithEvents txtCode As System.Windows.Forms.TextBox
        Friend WithEvents btnSearch As System.Windows.Forms.Button
        Friend WithEvents btnReset As System.Windows.Forms.Button
        Friend WithEvents lblDocDateStart As System.Windows.Forms.Label
        Friend WithEvents lblDocDateEnd As System.Windows.Forms.Label
        Friend WithEvents dtpDocDateStart As System.Windows.Forms.DateTimePicker
        Friend WithEvents dtpDocDateEnd As System.Windows.Forms.DateTimePicker
        Friend WithEvents lblCC As System.Windows.Forms.Label
        Friend WithEvents txtCostCenterCode As System.Windows.Forms.TextBox
        Friend WithEvents cmbStatus As System.Windows.Forms.ComboBox
        Friend WithEvents lblStatus As System.Windows.Forms.Label
        Friend WithEvents txtCostCenterName As System.Windows.Forms.TextBox
        Friend WithEvents btnCostCenterDialog As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents btnCostCenterPanel As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents grbItem As Longkong.Pojjaman.Gui.Components.FixedGroupBox
        Friend WithEvents grbMainDetail As Longkong.Pojjaman.Gui.Components.FixedGroupBox
        Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
        Friend WithEvents Validator As Longkong.Pojjaman.Gui.Components.PJMTextboxValidator
        Friend WithEvents txtAccountName As System.Windows.Forms.TextBox
        Friend WithEvents ibtnShowAccount As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents lblAccount As System.Windows.Forms.Label
        Friend WithEvents ibtnShowAccountDialog As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents txtAccountCode As System.Windows.Forms.TextBox
        Friend WithEvents grbRefDetail As Longkong.Pojjaman.Gui.Components.FixedGroupBox
        Friend WithEvents txtRefCode As System.Windows.Forms.TextBox
        Friend WithEvents lblRefDoc As System.Windows.Forms.Label
        Friend WithEvents dtpRefDateStart As System.Windows.Forms.DateTimePicker
        Friend WithEvents lblRefDateStart As System.Windows.Forms.Label
        Friend WithEvents lblRefDateEnd As System.Windows.Forms.Label
        Friend WithEvents dtpRefDateEnd As System.Windows.Forms.DateTimePicker
        Friend WithEvents cmbType As System.Windows.Forms.ComboBox
        Friend WithEvents lblType As System.Windows.Forms.Label
        Friend WithEvents lblAccountBook As System.Windows.Forms.Label
        Friend WithEvents txtAccountBookName As System.Windows.Forms.TextBox
        Friend WithEvents txtAccountBookCode As System.Windows.Forms.TextBox
        Friend WithEvents ibtnShowAccountBookDialog As Longkong.Pojjaman.Gui.Components.ImageButton
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Me.components = New System.ComponentModel.Container
            Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(JournalEntryFilterSubPanel))
            Me.lblCode = New System.Windows.Forms.Label
            Me.txtCode = New System.Windows.Forms.TextBox
            Me.grbDetail = New Longkong.Pojjaman.Gui.Components.FixedGroupBox
            Me.btnSearch = New System.Windows.Forms.Button
            Me.btnReset = New System.Windows.Forms.Button
            Me.grbItem = New Longkong.Pojjaman.Gui.Components.FixedGroupBox
            Me.txtAccountName = New System.Windows.Forms.TextBox
            Me.ibtnShowAccount = New Longkong.Pojjaman.Gui.Components.ImageButton
            Me.lblAccount = New System.Windows.Forms.Label
            Me.ibtnShowAccountDialog = New Longkong.Pojjaman.Gui.Components.ImageButton
            Me.txtAccountCode = New System.Windows.Forms.TextBox
            Me.txtCostCenterCode = New System.Windows.Forms.TextBox
            Me.txtCostCenterName = New System.Windows.Forms.TextBox
            Me.btnCostCenterDialog = New Longkong.Pojjaman.Gui.Components.ImageButton
            Me.lblCC = New System.Windows.Forms.Label
            Me.btnCostCenterPanel = New Longkong.Pojjaman.Gui.Components.ImageButton
            Me.grbMainDetail = New Longkong.Pojjaman.Gui.Components.FixedGroupBox
            Me.lblAccountBook = New System.Windows.Forms.Label
            Me.txtAccountBookName = New System.Windows.Forms.TextBox
            Me.txtAccountBookCode = New System.Windows.Forms.TextBox
            Me.ibtnShowAccountBookDialog = New Longkong.Pojjaman.Gui.Components.ImageButton
            Me.lblDocDateStart = New System.Windows.Forms.Label
            Me.cmbType = New System.Windows.Forms.ComboBox
            Me.lblType = New System.Windows.Forms.Label
            Me.cmbStatus = New System.Windows.Forms.ComboBox
            Me.lblStatus = New System.Windows.Forms.Label
            Me.lblDocDateEnd = New System.Windows.Forms.Label
            Me.dtpDocDateStart = New System.Windows.Forms.DateTimePicker
            Me.dtpDocDateEnd = New System.Windows.Forms.DateTimePicker
            Me.grbRefDetail = New Longkong.Pojjaman.Gui.Components.FixedGroupBox
            Me.txtRefCode = New System.Windows.Forms.TextBox
            Me.lblRefDoc = New System.Windows.Forms.Label
            Me.dtpRefDateStart = New System.Windows.Forms.DateTimePicker
            Me.lblRefDateStart = New System.Windows.Forms.Label
            Me.lblRefDateEnd = New System.Windows.Forms.Label
            Me.dtpRefDateEnd = New System.Windows.Forms.DateTimePicker
            Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider
            Me.Validator = New Longkong.Pojjaman.Gui.Components.PJMTextboxValidator(Me.components)
            Me.grbDetail.SuspendLayout()
            Me.grbItem.SuspendLayout()
            Me.grbMainDetail.SuspendLayout()
            Me.grbRefDetail.SuspendLayout()
            Me.SuspendLayout()
            '
            'lblCode
            '
            Me.lblCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblCode.ForeColor = System.Drawing.Color.Black
            Me.lblCode.Location = New System.Drawing.Point(8, 17)
            Me.lblCode.Name = "lblCode"
            Me.lblCode.Size = New System.Drawing.Size(120, 18)
            Me.lblCode.TabIndex = 6
            Me.lblCode.Text = "รหัส:"
            Me.lblCode.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtCode
            '
            Me.Validator.SetDataType(Me.txtCode, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtCode, "")
            Me.txtCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtCode, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtCode, System.Drawing.Color.Empty)
            Me.txtCode.Location = New System.Drawing.Point(128, 16)
            Me.Validator.SetMaxValue(Me.txtCode, "")
            Me.Validator.SetMinValue(Me.txtCode, "")
            Me.txtCode.Name = "txtCode"
            Me.Validator.SetRegularExpression(Me.txtCode, "")
            Me.Validator.SetRequired(Me.txtCode, False)
            Me.txtCode.Size = New System.Drawing.Size(216, 21)
            Me.txtCode.TabIndex = 1
            Me.txtCode.Text = ""
            '
            'grbDetail
            '
            Me.grbDetail.Controls.Add(Me.btnSearch)
            Me.grbDetail.Controls.Add(Me.btnReset)
            Me.grbDetail.Controls.Add(Me.grbItem)
            Me.grbDetail.Controls.Add(Me.grbMainDetail)
            Me.grbDetail.Controls.Add(Me.grbRefDetail)
            Me.grbDetail.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.grbDetail.Location = New System.Drawing.Point(8, 8)
            Me.grbDetail.Name = "grbDetail"
            Me.grbDetail.Size = New System.Drawing.Size(728, 240)
            Me.grbDetail.TabIndex = 0
            Me.grbDetail.TabStop = False
            Me.grbDetail.Text = "รายละเอียด"
            '
            'btnSearch
            '
            Me.btnSearch.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.btnSearch.Location = New System.Drawing.Point(648, 208)
            Me.btnSearch.Name = "btnSearch"
            Me.btnSearch.TabIndex = 5
            Me.btnSearch.Text = "Search"
            '
            'btnReset
            '
            Me.btnReset.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.btnReset.Location = New System.Drawing.Point(568, 208)
            Me.btnReset.Name = "btnReset"
            Me.btnReset.TabIndex = 4
            Me.btnReset.Text = "Reset"
            '
            'grbItem
            '
            Me.grbItem.Controls.Add(Me.txtAccountName)
            Me.grbItem.Controls.Add(Me.ibtnShowAccount)
            Me.grbItem.Controls.Add(Me.lblAccount)
            Me.grbItem.Controls.Add(Me.ibtnShowAccountDialog)
            Me.grbItem.Controls.Add(Me.txtAccountCode)
            Me.grbItem.Controls.Add(Me.txtCostCenterCode)
            Me.grbItem.Controls.Add(Me.txtCostCenterName)
            Me.grbItem.Controls.Add(Me.btnCostCenterDialog)
            Me.grbItem.Controls.Add(Me.lblCC)
            Me.grbItem.Controls.Add(Me.btnCostCenterPanel)
            Me.grbItem.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.grbItem.Location = New System.Drawing.Point(368, 128)
            Me.grbItem.Name = "grbItem"
            Me.grbItem.Size = New System.Drawing.Size(352, 72)
            Me.grbItem.TabIndex = 3
            Me.grbItem.TabStop = False
            Me.grbItem.Text = "รายการ"
            '
            'txtAccountName
            '
            Me.Validator.SetDataType(Me.txtAccountName, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtAccountName, "")
            Me.Validator.SetGotFocusBackColor(Me.txtAccountName, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtAccountName, System.Drawing.Color.Empty)
            Me.txtAccountName.Location = New System.Drawing.Point(192, 16)
            Me.Validator.SetMaxValue(Me.txtAccountName, "")
            Me.Validator.SetMinValue(Me.txtAccountName, "")
            Me.txtAccountName.Name = "txtAccountName"
            Me.txtAccountName.ReadOnly = True
            Me.Validator.SetRegularExpression(Me.txtAccountName, "")
            Me.Validator.SetRequired(Me.txtAccountName, False)
            Me.txtAccountName.Size = New System.Drawing.Size(96, 20)
            Me.txtAccountName.TabIndex = 204
            Me.txtAccountName.TabStop = False
            Me.txtAccountName.Text = ""
            '
            'ibtnShowAccount
            '
            Me.ibtnShowAccount.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.ibtnShowAccount.Image = CType(resources.GetObject("ibtnShowAccount.Image"), System.Drawing.Image)
            Me.ibtnShowAccount.Location = New System.Drawing.Point(312, 16)
            Me.ibtnShowAccount.Name = "ibtnShowAccount"
            Me.ibtnShowAccount.Size = New System.Drawing.Size(24, 23)
            Me.ibtnShowAccount.TabIndex = 205
            Me.ibtnShowAccount.TabStop = False
            Me.ibtnShowAccount.ThemedImage = CType(resources.GetObject("ibtnShowAccount.ThemedImage"), System.Drawing.Bitmap)
            '
            'lblAccount
            '
            Me.lblAccount.BackColor = System.Drawing.Color.Transparent
            Me.lblAccount.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblAccount.ForeColor = System.Drawing.SystemColors.WindowText
            Me.lblAccount.Location = New System.Drawing.Point(8, 16)
            Me.lblAccount.Name = "lblAccount"
            Me.lblAccount.Size = New System.Drawing.Size(104, 18)
            Me.lblAccount.TabIndex = 203
            Me.lblAccount.Text = "ผังบัญชี:"
            Me.lblAccount.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'ibtnShowAccountDialog
            '
            Me.ibtnShowAccountDialog.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.ibtnShowAccountDialog.ForeColor = System.Drawing.SystemColors.Control
            Me.ibtnShowAccountDialog.Image = CType(resources.GetObject("ibtnShowAccountDialog.Image"), System.Drawing.Image)
            Me.ibtnShowAccountDialog.Location = New System.Drawing.Point(288, 16)
            Me.ibtnShowAccountDialog.Name = "ibtnShowAccountDialog"
            Me.ibtnShowAccountDialog.Size = New System.Drawing.Size(24, 23)
            Me.ibtnShowAccountDialog.TabIndex = 206
            Me.ibtnShowAccountDialog.TabStop = False
            Me.ibtnShowAccountDialog.ThemedImage = CType(resources.GetObject("ibtnShowAccountDialog.ThemedImage"), System.Drawing.Bitmap)
            '
            'txtAccountCode
            '
            Me.Validator.SetDataType(Me.txtAccountCode, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtAccountCode, "")
            Me.Validator.SetGotFocusBackColor(Me.txtAccountCode, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtAccountCode, System.Drawing.Color.Empty)
            Me.txtAccountCode.Location = New System.Drawing.Point(112, 16)
            Me.Validator.SetMaxValue(Me.txtAccountCode, "")
            Me.Validator.SetMinValue(Me.txtAccountCode, "")
            Me.txtAccountCode.Name = "txtAccountCode"
            Me.Validator.SetRegularExpression(Me.txtAccountCode, "")
            Me.Validator.SetRequired(Me.txtAccountCode, False)
            Me.txtAccountCode.Size = New System.Drawing.Size(80, 20)
            Me.txtAccountCode.TabIndex = 1
            Me.txtAccountCode.Text = ""
            '
            'txtCostCenterCode
            '
            Me.Validator.SetDataType(Me.txtCostCenterCode, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtCostCenterCode, "")
            Me.Validator.SetGotFocusBackColor(Me.txtCostCenterCode, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtCostCenterCode, System.Drawing.Color.Empty)
            Me.txtCostCenterCode.Location = New System.Drawing.Point(112, 40)
            Me.Validator.SetMaxValue(Me.txtCostCenterCode, "")
            Me.Validator.SetMinValue(Me.txtCostCenterCode, "")
            Me.txtCostCenterCode.Name = "txtCostCenterCode"
            Me.Validator.SetRegularExpression(Me.txtCostCenterCode, "")
            Me.Validator.SetRequired(Me.txtCostCenterCode, False)
            Me.txtCostCenterCode.Size = New System.Drawing.Size(80, 20)
            Me.txtCostCenterCode.TabIndex = 2
            Me.txtCostCenterCode.Text = ""
            '
            'txtCostCenterName
            '
            Me.Validator.SetDataType(Me.txtCostCenterName, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtCostCenterName, "")
            Me.Validator.SetGotFocusBackColor(Me.txtCostCenterName, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtCostCenterName, System.Drawing.Color.Empty)
            Me.txtCostCenterName.Location = New System.Drawing.Point(192, 40)
            Me.Validator.SetMaxValue(Me.txtCostCenterName, "")
            Me.Validator.SetMinValue(Me.txtCostCenterName, "")
            Me.txtCostCenterName.Name = "txtCostCenterName"
            Me.txtCostCenterName.ReadOnly = True
            Me.Validator.SetRegularExpression(Me.txtCostCenterName, "")
            Me.Validator.SetRequired(Me.txtCostCenterName, False)
            Me.txtCostCenterName.Size = New System.Drawing.Size(96, 20)
            Me.txtCostCenterName.TabIndex = 196
            Me.txtCostCenterName.TabStop = False
            Me.txtCostCenterName.Text = ""
            '
            'btnCostCenterDialog
            '
            Me.btnCostCenterDialog.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.btnCostCenterDialog.ForeColor = System.Drawing.SystemColors.Control
            Me.btnCostCenterDialog.Image = CType(resources.GetObject("btnCostCenterDialog.Image"), System.Drawing.Image)
            Me.btnCostCenterDialog.Location = New System.Drawing.Point(288, 40)
            Me.btnCostCenterDialog.Name = "btnCostCenterDialog"
            Me.btnCostCenterDialog.Size = New System.Drawing.Size(24, 23)
            Me.btnCostCenterDialog.TabIndex = 201
            Me.btnCostCenterDialog.TabStop = False
            Me.btnCostCenterDialog.ThemedImage = CType(resources.GetObject("btnCostCenterDialog.ThemedImage"), System.Drawing.Bitmap)
            '
            'lblCC
            '
            Me.lblCC.BackColor = System.Drawing.Color.Transparent
            Me.lblCC.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblCC.ForeColor = System.Drawing.SystemColors.WindowText
            Me.lblCC.Location = New System.Drawing.Point(8, 40)
            Me.lblCC.Name = "lblCC"
            Me.lblCC.Size = New System.Drawing.Size(104, 18)
            Me.lblCC.TabIndex = 192
            Me.lblCC.Text = "CostCenter:"
            Me.lblCC.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'btnCostCenterPanel
            '
            Me.btnCostCenterPanel.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.btnCostCenterPanel.Image = CType(resources.GetObject("btnCostCenterPanel.Image"), System.Drawing.Image)
            Me.btnCostCenterPanel.Location = New System.Drawing.Point(312, 40)
            Me.btnCostCenterPanel.Name = "btnCostCenterPanel"
            Me.btnCostCenterPanel.Size = New System.Drawing.Size(24, 23)
            Me.btnCostCenterPanel.TabIndex = 199
            Me.btnCostCenterPanel.TabStop = False
            Me.btnCostCenterPanel.ThemedImage = CType(resources.GetObject("btnCostCenterPanel.ThemedImage"), System.Drawing.Bitmap)
            '
            'grbMainDetail
            '
            Me.grbMainDetail.Controls.Add(Me.lblAccountBook)
            Me.grbMainDetail.Controls.Add(Me.txtAccountBookName)
            Me.grbMainDetail.Controls.Add(Me.txtAccountBookCode)
            Me.grbMainDetail.Controls.Add(Me.ibtnShowAccountBookDialog)
            Me.grbMainDetail.Controls.Add(Me.lblDocDateStart)
            Me.grbMainDetail.Controls.Add(Me.cmbType)
            Me.grbMainDetail.Controls.Add(Me.lblType)
            Me.grbMainDetail.Controls.Add(Me.cmbStatus)
            Me.grbMainDetail.Controls.Add(Me.lblStatus)
            Me.grbMainDetail.Controls.Add(Me.txtCode)
            Me.grbMainDetail.Controls.Add(Me.lblCode)
            Me.grbMainDetail.Controls.Add(Me.lblDocDateEnd)
            Me.grbMainDetail.Controls.Add(Me.dtpDocDateStart)
            Me.grbMainDetail.Controls.Add(Me.dtpDocDateEnd)
            Me.grbMainDetail.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.grbMainDetail.Location = New System.Drawing.Point(8, 24)
            Me.grbMainDetail.Name = "grbMainDetail"
            Me.grbMainDetail.Size = New System.Drawing.Size(352, 176)
            Me.grbMainDetail.TabIndex = 1
            Me.grbMainDetail.TabStop = False
            Me.grbMainDetail.Text = "รายละเอียดทั่วไป"
            '
            'lblAccountBook
            '
            Me.lblAccountBook.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblAccountBook.ForeColor = System.Drawing.Color.Black
            Me.lblAccountBook.Location = New System.Drawing.Point(32, 136)
            Me.lblAccountBook.Name = "lblAccountBook"
            Me.lblAccountBook.Size = New System.Drawing.Size(96, 18)
            Me.lblAccountBook.TabIndex = 221
            Me.lblAccountBook.Text = "สมุดรายวัน:"
            Me.lblAccountBook.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtAccountBookName
            '
            Me.txtAccountBookName.BackColor = System.Drawing.SystemColors.Control
            Me.Validator.SetDataType(Me.txtAccountBookName, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtAccountBookName, "")
            Me.Validator.SetGotFocusBackColor(Me.txtAccountBookName, System.Drawing.Color.Empty)
            Me.ErrorProvider1.SetIconPadding(Me.txtAccountBookName, -15)
            Me.Validator.SetInvalidBackColor(Me.txtAccountBookName, System.Drawing.Color.Empty)
            Me.txtAccountBookName.Location = New System.Drawing.Point(176, 136)
            Me.Validator.SetMaxValue(Me.txtAccountBookName, "")
            Me.Validator.SetMinValue(Me.txtAccountBookName, "")
            Me.txtAccountBookName.Name = "txtAccountBookName"
            Me.txtAccountBookName.ReadOnly = True
            Me.Validator.SetRegularExpression(Me.txtAccountBookName, "")
            Me.Validator.SetRequired(Me.txtAccountBookName, False)
            Me.txtAccountBookName.Size = New System.Drawing.Size(144, 20)
            Me.txtAccountBookName.TabIndex = 222
            Me.txtAccountBookName.TabStop = False
            Me.txtAccountBookName.Text = ""
            '
            'txtAccountBookCode
            '
            Me.Validator.SetDataType(Me.txtAccountBookCode, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtAccountBookCode, "")
            Me.Validator.SetGotFocusBackColor(Me.txtAccountBookCode, System.Drawing.Color.Empty)
            Me.ErrorProvider1.SetIconPadding(Me.txtAccountBookCode, -15)
            Me.Validator.SetInvalidBackColor(Me.txtAccountBookCode, System.Drawing.Color.Empty)
            Me.txtAccountBookCode.Location = New System.Drawing.Point(128, 136)
            Me.Validator.SetMaxValue(Me.txtAccountBookCode, "")
            Me.Validator.SetMinValue(Me.txtAccountBookCode, "")
            Me.txtAccountBookCode.Name = "txtAccountBookCode"
            Me.Validator.SetRegularExpression(Me.txtAccountBookCode, "")
            Me.Validator.SetRequired(Me.txtAccountBookCode, False)
            Me.txtAccountBookCode.Size = New System.Drawing.Size(48, 20)
            Me.txtAccountBookCode.TabIndex = 6
            Me.txtAccountBookCode.Text = ""
            '
            'ibtnShowAccountBookDialog
            '
            Me.ibtnShowAccountBookDialog.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.ibtnShowAccountBookDialog.ForeColor = System.Drawing.SystemColors.Control
            Me.ibtnShowAccountBookDialog.Image = CType(resources.GetObject("ibtnShowAccountBookDialog.Image"), System.Drawing.Image)
            Me.ibtnShowAccountBookDialog.Location = New System.Drawing.Point(320, 136)
            Me.ibtnShowAccountBookDialog.Name = "ibtnShowAccountBookDialog"
            Me.ibtnShowAccountBookDialog.Size = New System.Drawing.Size(24, 23)
            Me.ibtnShowAccountBookDialog.TabIndex = 223
            Me.ibtnShowAccountBookDialog.TabStop = False
            Me.ibtnShowAccountBookDialog.ThemedImage = CType(resources.GetObject("ibtnShowAccountBookDialog.ThemedImage"), System.Drawing.Bitmap)
            '
            'lblDocDateStart
            '
            Me.lblDocDateStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblDocDateStart.ForeColor = System.Drawing.Color.Black
            Me.lblDocDateStart.Location = New System.Drawing.Point(8, 88)
            Me.lblDocDateStart.Name = "lblDocDateStart"
            Me.lblDocDateStart.Size = New System.Drawing.Size(120, 20)
            Me.lblDocDateStart.TabIndex = 11
            Me.lblDocDateStart.Text = "ตั้งแต่"
            Me.lblDocDateStart.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'cmbType
            '
            Me.cmbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cmbType.Location = New System.Drawing.Point(128, 40)
            Me.cmbType.Name = "cmbType"
            Me.cmbType.Size = New System.Drawing.Size(216, 21)
            Me.cmbType.TabIndex = 2
            '
            'lblType
            '
            Me.lblType.BackColor = System.Drawing.Color.Transparent
            Me.lblType.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblType.ForeColor = System.Drawing.SystemColors.WindowText
            Me.lblType.Location = New System.Drawing.Point(8, 41)
            Me.lblType.Name = "lblType"
            Me.lblType.Size = New System.Drawing.Size(120, 18)
            Me.lblType.TabIndex = 199
            Me.lblType.Text = "ประเภท:"
            Me.lblType.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'cmbStatus
            '
            Me.cmbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cmbStatus.Location = New System.Drawing.Point(128, 64)
            Me.cmbStatus.Name = "cmbStatus"
            Me.cmbStatus.Size = New System.Drawing.Size(216, 21)
            Me.cmbStatus.TabIndex = 3
            '
            'lblStatus
            '
            Me.lblStatus.BackColor = System.Drawing.Color.Transparent
            Me.lblStatus.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblStatus.ForeColor = System.Drawing.SystemColors.WindowText
            Me.lblStatus.Location = New System.Drawing.Point(8, 65)
            Me.lblStatus.Name = "lblStatus"
            Me.lblStatus.Size = New System.Drawing.Size(120, 18)
            Me.lblStatus.TabIndex = 197
            Me.lblStatus.Text = "สถานะ:"
            Me.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblDocDateEnd
            '
            Me.lblDocDateEnd.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblDocDateEnd.ForeColor = System.Drawing.Color.Black
            Me.lblDocDateEnd.Location = New System.Drawing.Point(8, 112)
            Me.lblDocDateEnd.Name = "lblDocDateEnd"
            Me.lblDocDateEnd.Size = New System.Drawing.Size(120, 20)
            Me.lblDocDateEnd.TabIndex = 11
            Me.lblDocDateEnd.Text = "ถึง"
            Me.lblDocDateEnd.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'dtpDocDateStart
            '
            Me.dtpDocDateStart.Format = System.Windows.Forms.DateTimePickerFormat.Short
            Me.dtpDocDateStart.Location = New System.Drawing.Point(128, 88)
            Me.dtpDocDateStart.Name = "dtpDocDateStart"
            Me.dtpDocDateStart.Size = New System.Drawing.Size(128, 20)
            Me.dtpDocDateStart.TabIndex = 4
            '
            'dtpDocDateEnd
            '
            Me.dtpDocDateEnd.Format = System.Windows.Forms.DateTimePickerFormat.Short
            Me.dtpDocDateEnd.Location = New System.Drawing.Point(128, 112)
            Me.dtpDocDateEnd.Name = "dtpDocDateEnd"
            Me.dtpDocDateEnd.Size = New System.Drawing.Size(128, 20)
            Me.dtpDocDateEnd.TabIndex = 5
            '
            'grbRefDetail
            '
            Me.grbRefDetail.Controls.Add(Me.txtRefCode)
            Me.grbRefDetail.Controls.Add(Me.lblRefDoc)
            Me.grbRefDetail.Controls.Add(Me.dtpRefDateStart)
            Me.grbRefDetail.Controls.Add(Me.lblRefDateStart)
            Me.grbRefDetail.Controls.Add(Me.lblRefDateEnd)
            Me.grbRefDetail.Controls.Add(Me.dtpRefDateEnd)
            Me.grbRefDetail.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.grbRefDetail.Location = New System.Drawing.Point(368, 24)
            Me.grbRefDetail.Name = "grbRefDetail"
            Me.grbRefDetail.Size = New System.Drawing.Size(352, 96)
            Me.grbRefDetail.TabIndex = 2
            Me.grbRefDetail.TabStop = False
            Me.grbRefDetail.Text = "รายละเอียดทั่วไป"
            '
            'txtRefCode
            '
            Me.Validator.SetDataType(Me.txtRefCode, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtRefCode, "")
            Me.txtRefCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtRefCode, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtRefCode, System.Drawing.Color.Empty)
            Me.txtRefCode.Location = New System.Drawing.Point(112, 16)
            Me.Validator.SetMaxValue(Me.txtRefCode, "")
            Me.Validator.SetMinValue(Me.txtRefCode, "")
            Me.txtRefCode.Name = "txtRefCode"
            Me.Validator.SetRegularExpression(Me.txtRefCode, "")
            Me.Validator.SetRequired(Me.txtRefCode, False)
            Me.txtRefCode.Size = New System.Drawing.Size(224, 21)
            Me.txtRefCode.TabIndex = 1
            Me.txtRefCode.Text = ""
            '
            'lblRefDoc
            '
            Me.lblRefDoc.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblRefDoc.ForeColor = System.Drawing.Color.Black
            Me.lblRefDoc.Location = New System.Drawing.Point(8, 17)
            Me.lblRefDoc.Name = "lblRefDoc"
            Me.lblRefDoc.Size = New System.Drawing.Size(104, 18)
            Me.lblRefDoc.TabIndex = 6
            Me.lblRefDoc.Text = "รหัส:"
            Me.lblRefDoc.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'dtpRefDateStart
            '
            Me.dtpRefDateStart.Format = System.Windows.Forms.DateTimePickerFormat.Short
            Me.dtpRefDateStart.Location = New System.Drawing.Point(112, 40)
            Me.dtpRefDateStart.Name = "dtpRefDateStart"
            Me.dtpRefDateStart.Size = New System.Drawing.Size(136, 20)
            Me.dtpRefDateStart.TabIndex = 2
            '
            'lblRefDateStart
            '
            Me.lblRefDateStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblRefDateStart.ForeColor = System.Drawing.Color.Black
            Me.lblRefDateStart.Location = New System.Drawing.Point(8, 41)
            Me.lblRefDateStart.Name = "lblRefDateStart"
            Me.lblRefDateStart.Size = New System.Drawing.Size(104, 18)
            Me.lblRefDateStart.TabIndex = 11
            Me.lblRefDateStart.Text = "ตั้งแต่"
            Me.lblRefDateStart.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblRefDateEnd
            '
            Me.lblRefDateEnd.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblRefDateEnd.ForeColor = System.Drawing.Color.Black
            Me.lblRefDateEnd.Location = New System.Drawing.Point(8, 65)
            Me.lblRefDateEnd.Name = "lblRefDateEnd"
            Me.lblRefDateEnd.Size = New System.Drawing.Size(104, 18)
            Me.lblRefDateEnd.TabIndex = 11
            Me.lblRefDateEnd.Text = "ถึง"
            Me.lblRefDateEnd.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'dtpRefDateEnd
            '
            Me.dtpRefDateEnd.Format = System.Windows.Forms.DateTimePickerFormat.Short
            Me.dtpRefDateEnd.Location = New System.Drawing.Point(112, 64)
            Me.dtpRefDateEnd.Name = "dtpRefDateEnd"
            Me.dtpRefDateEnd.Size = New System.Drawing.Size(136, 20)
            Me.dtpRefDateEnd.TabIndex = 3
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
            Me.Validator.GotFocusBackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
            Me.Validator.HasNewRow = False
            Me.Validator.InvalidBackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(128, Byte), CType(0, Byte))
            '
            'JournalEntryFilterSubPanel
            '
            Me.Controls.Add(Me.grbDetail)
            Me.Name = "JournalEntryFilterSubPanel"
            Me.Size = New System.Drawing.Size(744, 256)
            Me.grbDetail.ResumeLayout(False)
            Me.grbItem.ResumeLayout(False)
            Me.grbMainDetail.ResumeLayout(False)
            Me.grbRefDetail.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

#End Region

#Region "Constructors"
        Public Sub New()
            MyBase.New()

            InitializeComponent()
            Initialize()
            SetLabelText()
            Me.LoopControl(Me)
        End Sub
#End Region

#Region "Members"
        Private m_cc As CostCenter
        Private m_acct As Account
        Private m_acctbook As AccountBook
#End Region

#Region "Methods"
        Public Sub Initialize()
            CodeDescription.ListCodeDescriptionInComboBox(Me.cmbType, "gl_type", True)
            CodeDescription.ListCodeDescriptionInComboBox(Me.cmbStatus, "gl_status", True)
            ClearCriterias()
        End Sub
        Private Sub ClearCriterias()
            Me.txtCode.Text = ""
            Me.txtRefCode.Text = ""

            Me.txtCostCenterCode.Text = ""
            Me.txtCostCenterName.Text = ""
            Me.m_cc = New CostCenter

            Me.txtAccountCode.Text = ""
            Me.txtAccountName.Text = ""
            Me.txtAccountBookCode.Text = ""
            Me.txtAccountBookName.Text = ""
            Me.m_acct = New Account
            Me.m_acctbook = New AccountBook

            Me.dtpDocDateStart.Value = Now.Subtract(New TimeSpan(7, 0, 0, 0))
            Me.dtpDocDateEnd.Value = Now.Date
            Me.dtpRefDateEnd.Value = Now.Date
            Me.dtpRefDateStart.Value = Now.Subtract(New TimeSpan(7, 0, 0, 0))

            Me.cmbType.SelectedIndex = 0
            Me.cmbStatus.SelectedIndex = 0
        End Sub
        Public Sub SetLabelText()
            Me.grbDetail.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.JournalEntryFilterSubPanel.grbDetail}")
            Me.lblCode.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.JournalEntryFilterSubPanel.lblCode}")
            Me.btnSearch.Text = Me.StringParserService.Parse("${res:Global.SearchButtonText}")
            Me.btnReset.Text = Me.StringParserService.Parse("${res:Global.ResetButtonText}")
            Me.lblDocDateStart.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.JournalEntryFilterSubPanel.lblDocDateStart}")
            Me.lblDocDateEnd.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.JournalEntryFilterSubPanel.lblDocDateEnd}")
            Me.lblCC.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.JournalEntryFilterSubPanel.lblCC}")
            Me.lblStatus.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.JournalEntryFilterSubPanel.lblStatus}")
            Me.grbItem.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.JournalEntryFilterSubPanel.grbItem}")
            Me.grbMainDetail.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.JournalEntryFilterSubPanel.grbMainDetail}")
            Me.lblAccount.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.JournalEntryFilterSubPanel.lblAccount}")
            Me.lblType.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.JournalEntryFilterSubPanel.lblType}")
            Me.grbRefDetail.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.JournalEntryFilterSubPanel.grbRefDetail}")
            Me.lblRefDoc.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.JournalEntryFilterSubPanel.lblRefDoc}")
            Me.lblRefDateStart.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.JournalEntryFilterSubPanel.lblRefDateStart}")
            Me.lblRefDateEnd.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.JournalEntryFilterSubPanel.lblRefDateEnd}")
            Me.lblAccountBook.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.JournalEntryFilterSubPanel.lblAccountBook}")
        End Sub
        Public Overrides Function GetFilterArray() As Filter()
            Dim arr(10) As Filter
            arr(0) = New Filter("code", IIf(Me.txtCode.Text.Length = 0, DBNull.Value, Me.txtCode.Text))
            arr(1) = New Filter("refcode", IIf(Me.txtRefCode.Text.Length = 0, DBNull.Value, Me.txtRefCode.Text))
            arr(2) = New Filter("cc_id", IIf(Me.m_cc.Valid, Me.m_cc.Id, DBNull.Value))
            arr(3) = New Filter("docdatestart", Me.dtpDocDateStart.Value.Date)
            arr(4) = New Filter("docdateend", Me.dtpDocDateEnd.Value.Date)
            arr(5) = New Filter("refdatestart", Me.dtpRefDateStart.Value.Date)
            arr(6) = New Filter("refdateend", Me.dtpRefDateEnd.Value.Date)
            arr(7) = New Filter("acct_id", IIf(Me.m_acct.Valid, Me.m_acct.Id, DBNull.Value))
            If Not cmbStatus.SelectedItem Is Nothing Then
                Dim item As IdValuePair = CType(cmbStatus.SelectedItem, IdValuePair)
                If item.Id = -1 Then
                    arr(8) = New Filter("status", DBNull.Value)
                Else
                    arr(8) = New Filter("status", item.Id)
                End If
            Else
                arr(8) = New Filter("status", DBNull.Value)
            End If
            If Not cmbType.SelectedItem Is Nothing Then
                Dim item As IdValuePair = CType(cmbType.SelectedItem, IdValuePair)
                If item.Id = -1 Then
                    arr(9) = New Filter("type", DBNull.Value)
                Else
                    arr(9) = New Filter("type", item.Id)
                End If
            Else
                arr(9) = New Filter("type", DBNull.Value)
            End If
            arr(10) = New Filter("acct_bookid", IIf(Me.txtAccountBookCode.Text.Length > 0, Me.m_acctbook.Id, DBNull.Value))
            Return arr
        End Function
        Public Overrides ReadOnly Property SearchButton() As System.Windows.Forms.Button
            Get
                Return Me.btnSearch
            End Get
        End Property
#End Region

#Region "Event Handlers"
        Private Sub txtAccountCode_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtAccountCode.Validated
            Account.GetAccount(txtAccountCode, txtAccountName, Me.m_acct)
        End Sub
        Private Sub txtCostCenterCode_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCostCenterCode.Validated
            CostCenter.GetCostCenter(txtCostCenterCode, txtCostCenterName, Me.m_cc)
        End Sub
        Private Sub ibtnShowAccount_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnShowAccount.Click
            Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
            myEntityPanelService.OpenPanel(New Account)
        End Sub
        Private Sub ibtnShowAccountDialog_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnShowAccountDialog.Click
            Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
            myEntityPanelService.OpenTreeDialog(New Account, AddressOf SetAccount)
        End Sub
        Private Sub SetAccount(ByVal e As ISimpleEntity)
            Me.txtAccountCode.Text = e.Code
            Account.GetAccount(txtAccountCode, txtAccountName, Me.m_acct)
        End Sub
        Private Sub btnCostCenterDialog_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCostCenterDialog.Click
            Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
            myEntityPanelService.OpenTreeDialog(New CostCenter, AddressOf SetCostCenter)
        End Sub
        Private Sub SetCostCenter(ByVal e As ISimpleEntity)
            Me.txtCostCenterCode.Text = e.Code
            CostCenter.GetCostCenter(txtCostCenterCode, txtCostCenterName, Me.m_cc)
        End Sub
        Private Sub btnCostCenterPanel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCostCenterPanel.Click
            Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
            myEntityPanelService.OpenPanel(New CostCenter)
        End Sub
        Private Sub ibtnShowAccountBookDialog_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnShowAccountBookDialog.Click
            Dim myEntityPanelService As IEntityPanelService = _
             CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
            myEntityPanelService.OpenListDialog(New AccountBook, AddressOf SetAccountBook)
        End Sub
        Private Sub SetAccountBook(ByVal e As ISimpleEntity)
            Me.txtAccountBookCode.Text = e.Code
            AccountBook.GetAccountBook(txtAccountBookCode, txtAccountBookName, Me.m_acctbook)
        End Sub
        Private Sub btnReset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReset.Click
            ClearCriterias()
            Me.btnSearch.PerformClick()
        End Sub
#End Region

#Region "IClipboardHandler Overrides" 'Undone
        Public Overrides ReadOnly Property EnablePaste() As Boolean
            Get
                If Me.ActiveControl Is Nothing Then
                    Return False
                End If
                Dim data As IDataObject = Clipboard.GetDataObject

                If data.GetDataPresent((New CostCenter).FullClassName) Then
                    Select Case Me.ActiveControl.Name.ToLower
                        Case "txtcostcentercode", "txtcostcentername"
                            Return True
                    End Select
                End If
                If data.GetDataPresent((New Account).FullClassName) Then
                    Select Case Me.ActiveControl.Name.ToLower
                        Case "txtaccountcode", "txtaccountname"
                            Return True
                    End Select
                End If
            End Get
        End Property
        Public Overrides Sub Paste(ByVal sender As Object, ByVal e As System.EventArgs)
            If Me.ActiveControl Is Nothing Then
                Return
            End If
            Dim data As IDataObject = Clipboard.GetDataObject
            If data.GetDataPresent((New CostCenter).FullClassName) Then
                Dim id As Integer = CInt(data.GetData((New CostCenter).FullClassName))
                Dim entity As New CostCenter(id)
                Select Case Me.ActiveControl.Name.ToLower
                    Case "txtcostcentercode", "txtcostcentername"
                        Me.SetCostCenter(entity)
                End Select
            End If
            If data.GetDataPresent((New Account).FullClassName) Then
                Dim id As Integer = CInt(data.GetData((New Account).FullClassName))
                Dim entity As New Employee(id)
                Select Case Me.ActiveControl.Name.ToLower
                    Case "txtaccountcode", "txtaccountname"
                        Me.SetAccount(entity)
                End Select
            End If
        End Sub
#End Region

    End Class
End Namespace

