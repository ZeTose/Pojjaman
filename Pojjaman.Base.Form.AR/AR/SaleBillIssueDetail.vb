Imports Longkong.Pojjaman.Services
Imports Longkong.Core.Services

Imports Longkong.Pojjaman.Gui
Imports Longkong.Pojjaman.BusinessLogic
Imports System.Drawing.Printing
Imports Longkong.Pojjaman.Gui.Components
Imports System.Globalization
Imports System.Reflection
Imports Longkong.Pojjaman.TextHelper
Imports Longkong.Pojjaman.Gui.ReportsAndDocs
Namespace Longkong.Pojjaman.Gui.Panels
    Public Class SaleBillIssueDetail
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
        Friend WithEvents Validator As Longkong.Pojjaman.Gui.Components.PJMTextboxValidator
        Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
        Friend WithEvents ibtnBlank As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents txtDocDate As System.Windows.Forms.TextBox
        Friend WithEvents txtCode As System.Windows.Forms.TextBox
        Friend WithEvents txtNote As System.Windows.Forms.TextBox
        Friend WithEvents ibtnDelRow As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents lblCredit As System.Windows.Forms.Label
        Friend WithEvents lblDueDate As System.Windows.Forms.Label
        Friend WithEvents dtpDueDate As System.Windows.Forms.DateTimePicker
        Friend WithEvents txtcreditperiod As System.Windows.Forms.TextBox
        Friend WithEvents lblDay As System.Windows.Forms.Label
        Friend WithEvents chkAutorun As System.Windows.Forms.CheckBox
        Friend WithEvents dtpDocDate As System.Windows.Forms.DateTimePicker
        Friend WithEvents lblCode As System.Windows.Forms.Label
        Friend WithEvents lblDocDate As System.Windows.Forms.Label
        Friend WithEvents grbSummary As Longkong.Pojjaman.Gui.Components.FixedGroupBox
        Friend WithEvents lblRemaining As System.Windows.Forms.Label
        Friend WithEvents txtRemaining As System.Windows.Forms.TextBox
        Friend WithEvents lblRemainingUnit As System.Windows.Forms.Label
        Friend WithEvents txtItemCount As System.Windows.Forms.TextBox
        Friend WithEvents lblItemCount As System.Windows.Forms.Label
        Friend WithEvents lblItemCountUnit As System.Windows.Forms.Label
        Friend WithEvents lblGrossUnit As System.Windows.Forms.Label
        Friend WithEvents txtGross As System.Windows.Forms.TextBox
        Friend WithEvents lblGross As System.Windows.Forms.Label
        Friend WithEvents lblItem As System.Windows.Forms.Label
        Friend WithEvents tgItem As Longkong.Pojjaman.Gui.Components.TreeGrid
        Friend WithEvents lblNote As System.Windows.Forms.Label
        Friend WithEvents txtCustomerName As System.Windows.Forms.TextBox
        Friend WithEvents txtCustomerCode As System.Windows.Forms.TextBox
        Friend WithEvents grbCustomer As Longkong.Pojjaman.Gui.Components.FixedGroupBox
        Friend WithEvents ibtnShowCustomer As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents ibtnShowCustomerDialog As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents lblCustomer As System.Windows.Forms.Label
        Friend WithEvents txtEmployeeName As System.Windows.Forms.TextBox
        Friend WithEvents txtEmployeeCode As System.Windows.Forms.TextBox
        Friend WithEvents ibtnShowEmployee As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents ibtnShowEmployeeDialog As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents lblEmployee As System.Windows.Forms.Label
        <System.Diagnostics.DebuggerStepThrough()> Protected Sub InitializeComponent()
            Me.components = New System.ComponentModel.Container
            Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(SaleBillIssueDetail))
            Me.Validator = New Longkong.Pojjaman.Gui.Components.PJMTextboxValidator(Me.components)
            Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider
            Me.txtDocDate = New System.Windows.Forms.TextBox
            Me.txtCode = New System.Windows.Forms.TextBox
            Me.txtNote = New System.Windows.Forms.TextBox
            Me.txtcreditperiod = New System.Windows.Forms.TextBox
            Me.txtCustomerName = New System.Windows.Forms.TextBox
            Me.txtCustomerCode = New System.Windows.Forms.TextBox
            Me.txtRemaining = New System.Windows.Forms.TextBox
            Me.txtItemCount = New System.Windows.Forms.TextBox
            Me.txtGross = New System.Windows.Forms.TextBox
            Me.txtEmployeeName = New System.Windows.Forms.TextBox
            Me.txtEmployeeCode = New System.Windows.Forms.TextBox
            Me.ibtnBlank = New Longkong.Pojjaman.Gui.Components.ImageButton
            Me.ibtnDelRow = New Longkong.Pojjaman.Gui.Components.ImageButton
            Me.grbCustomer = New Longkong.Pojjaman.Gui.Components.FixedGroupBox
            Me.lblCredit = New System.Windows.Forms.Label
            Me.lblDueDate = New System.Windows.Forms.Label
            Me.dtpDueDate = New System.Windows.Forms.DateTimePicker
            Me.ibtnShowCustomer = New Longkong.Pojjaman.Gui.Components.ImageButton
            Me.ibtnShowCustomerDialog = New Longkong.Pojjaman.Gui.Components.ImageButton
            Me.lblCustomer = New System.Windows.Forms.Label
            Me.lblDay = New System.Windows.Forms.Label
            Me.chkAutorun = New System.Windows.Forms.CheckBox
            Me.dtpDocDate = New System.Windows.Forms.DateTimePicker
            Me.lblCode = New System.Windows.Forms.Label
            Me.lblDocDate = New System.Windows.Forms.Label
            Me.grbSummary = New Longkong.Pojjaman.Gui.Components.FixedGroupBox
            Me.lblRemaining = New System.Windows.Forms.Label
            Me.lblRemainingUnit = New System.Windows.Forms.Label
            Me.lblItemCount = New System.Windows.Forms.Label
            Me.lblItemCountUnit = New System.Windows.Forms.Label
            Me.lblGrossUnit = New System.Windows.Forms.Label
            Me.lblGross = New System.Windows.Forms.Label
            Me.lblItem = New System.Windows.Forms.Label
            Me.tgItem = New Longkong.Pojjaman.Gui.Components.TreeGrid
            Me.lblNote = New System.Windows.Forms.Label
            Me.ibtnShowEmployee = New Longkong.Pojjaman.Gui.Components.ImageButton
            Me.ibtnShowEmployeeDialog = New Longkong.Pojjaman.Gui.Components.ImageButton
            Me.lblEmployee = New System.Windows.Forms.Label
            Me.grbCustomer.SuspendLayout()
            Me.grbSummary.SuspendLayout()
            CType(Me.tgItem, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
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
            'ErrorProvider1
            '
            Me.ErrorProvider1.ContainerControl = Me
            '
            'txtDocDate
            '
            Me.Validator.SetDataType(Me.txtDocDate, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtDocDate, "")
            Me.Validator.SetGotFocusBackColor(Me.txtDocDate, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtDocDate, System.Drawing.Color.Empty)
            Me.txtDocDate.Location = New System.Drawing.Point(240, 15)
            Me.Validator.SetMaxValue(Me.txtDocDate, "")
            Me.Validator.SetMinValue(Me.txtDocDate, "")
            Me.txtDocDate.Name = "txtDocDate"
            Me.Validator.SetRegularExpression(Me.txtDocDate, "")
            Me.Validator.SetRequired(Me.txtDocDate, False)
            Me.txtDocDate.Size = New System.Drawing.Size(78, 20)
            Me.txtDocDate.TabIndex = 1
            Me.txtDocDate.Text = ""
            '
            'txtCode
            '
            Me.Validator.SetDataType(Me.txtCode, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtCode, "")
            Me.txtCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtCode, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtCode, System.Drawing.Color.Empty)
            Me.txtCode.Location = New System.Drawing.Point(96, 15)
            Me.Validator.SetMaxValue(Me.txtCode, "")
            Me.Validator.SetMinValue(Me.txtCode, "")
            Me.txtCode.Name = "txtCode"
            Me.Validator.SetRegularExpression(Me.txtCode, "")
            Me.Validator.SetRequired(Me.txtCode, False)
            Me.txtCode.Size = New System.Drawing.Size(88, 21)
            Me.txtCode.TabIndex = 0
            Me.txtCode.TabStop = False
            Me.txtCode.Text = ""
            '
            'txtNote
            '
            Me.txtNote.BackColor = System.Drawing.SystemColors.Window
            Me.Validator.SetDataType(Me.txtNote, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtNote, "")
            Me.Validator.SetGotFocusBackColor(Me.txtNote, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtNote, System.Drawing.Color.Empty)
            Me.txtNote.Location = New System.Drawing.Point(336, 80)
            Me.Validator.SetMaxValue(Me.txtNote, "")
            Me.Validator.SetMinValue(Me.txtNote, "")
            Me.txtNote.Name = "txtNote"
            Me.Validator.SetRegularExpression(Me.txtNote, "")
            Me.Validator.SetRequired(Me.txtNote, False)
            Me.txtNote.Size = New System.Drawing.Size(416, 20)
            Me.txtNote.TabIndex = 4
            Me.txtNote.Text = ""
            '
            'txtcreditperiod
            '
            Me.txtcreditperiod.BackColor = System.Drawing.SystemColors.Window
            Me.Validator.SetDataType(Me.txtcreditperiod, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtcreditperiod, "")
            Me.Validator.SetGotFocusBackColor(Me.txtcreditperiod, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtcreditperiod, System.Drawing.Color.Empty)
            Me.txtcreditperiod.Location = New System.Drawing.Point(88, 40)
            Me.Validator.SetMaxValue(Me.txtcreditperiod, "")
            Me.Validator.SetMinValue(Me.txtcreditperiod, "")
            Me.txtcreditperiod.Name = "txtcreditperiod"
            Me.Validator.SetRegularExpression(Me.txtcreditperiod, "")
            Me.Validator.SetRequired(Me.txtcreditperiod, True)
            Me.txtcreditperiod.Size = New System.Drawing.Size(64, 20)
            Me.txtcreditperiod.TabIndex = 1
            Me.txtcreditperiod.Text = ""
            '
            'txtCustomerName
            '
            Me.txtCustomerName.BackColor = System.Drawing.SystemColors.Control
            Me.Validator.SetDataType(Me.txtCustomerName, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtCustomerName, "")
            Me.Validator.SetGotFocusBackColor(Me.txtCustomerName, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtCustomerName, System.Drawing.Color.Empty)
            Me.txtCustomerName.Location = New System.Drawing.Point(152, 16)
            Me.Validator.SetMaxValue(Me.txtCustomerName, "")
            Me.Validator.SetMinValue(Me.txtCustomerName, "")
            Me.txtCustomerName.Name = "txtCustomerName"
            Me.txtCustomerName.ReadOnly = True
            Me.Validator.SetRegularExpression(Me.txtCustomerName, "")
            Me.Validator.SetRequired(Me.txtCustomerName, False)
            Me.txtCustomerName.Size = New System.Drawing.Size(168, 20)
            Me.txtCustomerName.TabIndex = 4
            Me.txtCustomerName.TabStop = False
            Me.txtCustomerName.Text = ""
            '
            'txtCustomerCode
            '
            Me.txtCustomerCode.BackColor = System.Drawing.SystemColors.Window
            Me.Validator.SetDataType(Me.txtCustomerCode, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtCustomerCode, "")
            Me.Validator.SetGotFocusBackColor(Me.txtCustomerCode, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtCustomerCode, System.Drawing.Color.Empty)
            Me.txtCustomerCode.Location = New System.Drawing.Point(88, 16)
            Me.Validator.SetMaxValue(Me.txtCustomerCode, "")
            Me.Validator.SetMinValue(Me.txtCustomerCode, "")
            Me.txtCustomerCode.Name = "txtCustomerCode"
            Me.Validator.SetRegularExpression(Me.txtCustomerCode, "")
            Me.Validator.SetRequired(Me.txtCustomerCode, True)
            Me.txtCustomerCode.Size = New System.Drawing.Size(64, 20)
            Me.txtCustomerCode.TabIndex = 0
            Me.txtCustomerCode.Text = ""
            '
            'txtRemaining
            '
            Me.txtRemaining.BackColor = System.Drawing.SystemColors.Control
            Me.txtRemaining.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.Validator.SetDataType(Me.txtRemaining, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtRemaining, "")
            Me.Validator.SetGotFocusBackColor(Me.txtRemaining, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtRemaining, System.Drawing.Color.Empty)
            Me.txtRemaining.Location = New System.Drawing.Point(536, 16)
            Me.Validator.SetMaxValue(Me.txtRemaining, "")
            Me.Validator.SetMinValue(Me.txtRemaining, "")
            Me.txtRemaining.Name = "txtRemaining"
            Me.txtRemaining.ReadOnly = True
            Me.Validator.SetRegularExpression(Me.txtRemaining, "")
            Me.Validator.SetRequired(Me.txtRemaining, False)
            Me.txtRemaining.Size = New System.Drawing.Size(112, 20)
            Me.txtRemaining.TabIndex = 7
            Me.txtRemaining.Text = ""
            '
            'txtItemCount
            '
            Me.txtItemCount.BackColor = System.Drawing.SystemColors.Control
            Me.txtItemCount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.Validator.SetDataType(Me.txtItemCount, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtItemCount, "")
            Me.Validator.SetGotFocusBackColor(Me.txtItemCount, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtItemCount, System.Drawing.Color.Empty)
            Me.txtItemCount.Location = New System.Drawing.Point(88, 16)
            Me.Validator.SetMaxValue(Me.txtItemCount, "")
            Me.Validator.SetMinValue(Me.txtItemCount, "")
            Me.txtItemCount.Name = "txtItemCount"
            Me.txtItemCount.ReadOnly = True
            Me.Validator.SetRegularExpression(Me.txtItemCount, "")
            Me.Validator.SetRequired(Me.txtItemCount, False)
            Me.txtItemCount.Size = New System.Drawing.Size(56, 20)
            Me.txtItemCount.TabIndex = 1
            Me.txtItemCount.Text = ""
            '
            'txtGross
            '
            Me.txtGross.BackColor = System.Drawing.SystemColors.Control
            Me.txtGross.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.Validator.SetDataType(Me.txtGross, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtGross, "")
            Me.Validator.SetGotFocusBackColor(Me.txtGross, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtGross, System.Drawing.Color.Empty)
            Me.txtGross.Location = New System.Drawing.Point(288, 16)
            Me.Validator.SetMaxValue(Me.txtGross, "")
            Me.Validator.SetMinValue(Me.txtGross, "")
            Me.txtGross.Name = "txtGross"
            Me.txtGross.ReadOnly = True
            Me.Validator.SetRegularExpression(Me.txtGross, "")
            Me.Validator.SetRequired(Me.txtGross, False)
            Me.txtGross.Size = New System.Drawing.Size(112, 20)
            Me.txtGross.TabIndex = 4
            Me.txtGross.Text = ""
            '
            'txtEmployeeName
            '
            Me.txtEmployeeName.BackColor = System.Drawing.SystemColors.Control
            Me.Validator.SetDataType(Me.txtEmployeeName, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtEmployeeName, "")
            Me.Validator.SetGotFocusBackColor(Me.txtEmployeeName, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtEmployeeName, System.Drawing.Color.Empty)
            Me.txtEmployeeName.Location = New System.Drawing.Point(160, 40)
            Me.Validator.SetMaxValue(Me.txtEmployeeName, "")
            Me.Validator.SetMinValue(Me.txtEmployeeName, "")
            Me.txtEmployeeName.Name = "txtEmployeeName"
            Me.txtEmployeeName.ReadOnly = True
            Me.Validator.SetRegularExpression(Me.txtEmployeeName, "")
            Me.Validator.SetRequired(Me.txtEmployeeName, False)
            Me.txtEmployeeName.Size = New System.Drawing.Size(168, 20)
            Me.txtEmployeeName.TabIndex = 12
            Me.txtEmployeeName.TabStop = False
            Me.txtEmployeeName.Text = ""
            '
            'txtEmployeeCode
            '
            Me.txtEmployeeCode.BackColor = System.Drawing.SystemColors.Window
            Me.Validator.SetDataType(Me.txtEmployeeCode, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtEmployeeCode, "")
            Me.Validator.SetGotFocusBackColor(Me.txtEmployeeCode, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtEmployeeCode, System.Drawing.Color.Empty)
            Me.txtEmployeeCode.Location = New System.Drawing.Point(96, 40)
            Me.Validator.SetMaxValue(Me.txtEmployeeCode, "")
            Me.Validator.SetMinValue(Me.txtEmployeeCode, "")
            Me.txtEmployeeCode.Name = "txtEmployeeCode"
            Me.Validator.SetRegularExpression(Me.txtEmployeeCode, "")
            Me.Validator.SetRequired(Me.txtEmployeeCode, True)
            Me.txtEmployeeCode.Size = New System.Drawing.Size(64, 20)
            Me.txtEmployeeCode.TabIndex = 2
            Me.txtEmployeeCode.Text = ""
            '
            'ibtnBlank
            '
            Me.ibtnBlank.Image = CType(resources.GetObject("ibtnBlank.Image"), System.Drawing.Image)
            Me.ibtnBlank.Location = New System.Drawing.Point(144, 80)
            Me.ibtnBlank.Name = "ibtnBlank"
            Me.ibtnBlank.Size = New System.Drawing.Size(24, 24)
            Me.ibtnBlank.TabIndex = 16
            Me.ibtnBlank.TabStop = False
            Me.ibtnBlank.ThemedImage = CType(resources.GetObject("ibtnBlank.ThemedImage"), System.Drawing.Bitmap)
            '
            'ibtnDelRow
            '
            Me.ibtnDelRow.Image = CType(resources.GetObject("ibtnDelRow.Image"), System.Drawing.Image)
            Me.ibtnDelRow.Location = New System.Drawing.Point(168, 80)
            Me.ibtnDelRow.Name = "ibtnDelRow"
            Me.ibtnDelRow.Size = New System.Drawing.Size(24, 24)
            Me.ibtnDelRow.TabIndex = 17
            Me.ibtnDelRow.TabStop = False
            Me.ibtnDelRow.ThemedImage = CType(resources.GetObject("ibtnDelRow.ThemedImage"), System.Drawing.Bitmap)
            '
            'grbCustomer
            '
            Me.grbCustomer.Controls.Add(Me.lblCredit)
            Me.grbCustomer.Controls.Add(Me.lblDueDate)
            Me.grbCustomer.Controls.Add(Me.dtpDueDate)
            Me.grbCustomer.Controls.Add(Me.txtcreditperiod)
            Me.grbCustomer.Controls.Add(Me.ibtnShowCustomer)
            Me.grbCustomer.Controls.Add(Me.txtCustomerName)
            Me.grbCustomer.Controls.Add(Me.txtCustomerCode)
            Me.grbCustomer.Controls.Add(Me.ibtnShowCustomerDialog)
            Me.grbCustomer.Controls.Add(Me.lblCustomer)
            Me.grbCustomer.Controls.Add(Me.lblDay)
            Me.grbCustomer.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.grbCustomer.Location = New System.Drawing.Point(376, 0)
            Me.grbCustomer.Name = "grbCustomer"
            Me.grbCustomer.Size = New System.Drawing.Size(384, 72)
            Me.grbCustomer.TabIndex = 3
            Me.grbCustomer.TabStop = False
            Me.grbCustomer.Text = "ลูกค้า"
            '
            'lblCredit
            '
            Me.lblCredit.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblCredit.Location = New System.Drawing.Point(16, 40)
            Me.lblCredit.Name = "lblCredit"
            Me.lblCredit.Size = New System.Drawing.Size(72, 18)
            Me.lblCredit.TabIndex = 3
            Me.lblCredit.Text = "ระยะเครดิต:"
            Me.lblCredit.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblDueDate
            '
            Me.lblDueDate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblDueDate.Location = New System.Drawing.Point(176, 41)
            Me.lblDueDate.Name = "lblDueDate"
            Me.lblDueDate.Size = New System.Drawing.Size(88, 18)
            Me.lblDueDate.TabIndex = 6
            Me.lblDueDate.Text = "กำหนดชำระ:"
            Me.lblDueDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'dtpDueDate
            '
            Me.dtpDueDate.CustomFormat = "dd/MM/yyyy"
            Me.dtpDueDate.Enabled = False
            Me.dtpDueDate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.dtpDueDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
            Me.dtpDueDate.Location = New System.Drawing.Point(272, 40)
            Me.dtpDueDate.Name = "dtpDueDate"
            Me.dtpDueDate.Size = New System.Drawing.Size(96, 21)
            Me.dtpDueDate.TabIndex = 7
            Me.dtpDueDate.TabStop = False
            '
            'ibtnShowCustomer
            '
            Me.ibtnShowCustomer.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.ibtnShowCustomer.Image = CType(resources.GetObject("ibtnShowCustomer.Image"), System.Drawing.Image)
            Me.ibtnShowCustomer.Location = New System.Drawing.Point(344, 16)
            Me.ibtnShowCustomer.Name = "ibtnShowCustomer"
            Me.ibtnShowCustomer.Size = New System.Drawing.Size(24, 23)
            Me.ibtnShowCustomer.TabIndex = 9
            Me.ibtnShowCustomer.TabStop = False
            Me.ibtnShowCustomer.ThemedImage = CType(resources.GetObject("ibtnShowCustomer.ThemedImage"), System.Drawing.Bitmap)
            '
            'ibtnShowCustomerDialog
            '
            Me.ibtnShowCustomerDialog.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.ibtnShowCustomerDialog.ForeColor = System.Drawing.SystemColors.Control
            Me.ibtnShowCustomerDialog.Image = CType(resources.GetObject("ibtnShowCustomerDialog.Image"), System.Drawing.Image)
            Me.ibtnShowCustomerDialog.Location = New System.Drawing.Point(320, 16)
            Me.ibtnShowCustomerDialog.Name = "ibtnShowCustomerDialog"
            Me.ibtnShowCustomerDialog.Size = New System.Drawing.Size(24, 23)
            Me.ibtnShowCustomerDialog.TabIndex = 8
            Me.ibtnShowCustomerDialog.TabStop = False
            Me.ibtnShowCustomerDialog.ThemedImage = CType(resources.GetObject("ibtnShowCustomerDialog.ThemedImage"), System.Drawing.Bitmap)
            '
            'lblCustomer
            '
            Me.lblCustomer.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblCustomer.Location = New System.Drawing.Point(16, 16)
            Me.lblCustomer.Name = "lblCustomer"
            Me.lblCustomer.Size = New System.Drawing.Size(72, 18)
            Me.lblCustomer.TabIndex = 2
            Me.lblCustomer.Text = "ลูกค้า:"
            Me.lblCustomer.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblDay
            '
            Me.lblDay.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblDay.Location = New System.Drawing.Point(152, 42)
            Me.lblDay.Name = "lblDay"
            Me.lblDay.Size = New System.Drawing.Size(32, 18)
            Me.lblDay.TabIndex = 5
            Me.lblDay.Text = "วัน"
            Me.lblDay.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'chkAutorun
            '
            Me.chkAutorun.Appearance = System.Windows.Forms.Appearance.Button
            Me.chkAutorun.Image = CType(resources.GetObject("chkAutorun.Image"), System.Drawing.Image)
            Me.chkAutorun.Location = New System.Drawing.Point(184, 15)
            Me.chkAutorun.Name = "chkAutorun"
            Me.chkAutorun.Size = New System.Drawing.Size(21, 21)
            Me.chkAutorun.TabIndex = 9
            '
            'dtpDocDate
            '
            Me.dtpDocDate.CustomFormat = "dd/MM/yyyy"
            Me.dtpDocDate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.dtpDocDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
            Me.dtpDocDate.Location = New System.Drawing.Point(240, 15)
            Me.dtpDocDate.Name = "dtpDocDate"
            Me.dtpDocDate.Size = New System.Drawing.Size(96, 21)
            Me.dtpDocDate.TabIndex = 11
            Me.dtpDocDate.TabStop = False
            '
            'lblCode
            '
            Me.lblCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblCode.ForeColor = System.Drawing.Color.Black
            Me.lblCode.Location = New System.Drawing.Point(16, 16)
            Me.lblCode.Name = "lblCode"
            Me.lblCode.Size = New System.Drawing.Size(80, 18)
            Me.lblCode.TabIndex = 7
            Me.lblCode.Text = "เลขที่:"
            Me.lblCode.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblDocDate
            '
            Me.lblDocDate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblDocDate.ForeColor = System.Drawing.Color.Black
            Me.lblDocDate.Location = New System.Drawing.Point(200, 16)
            Me.lblDocDate.Name = "lblDocDate"
            Me.lblDocDate.Size = New System.Drawing.Size(40, 18)
            Me.lblDocDate.TabIndex = 10
            Me.lblDocDate.Text = "วันที่:"
            Me.lblDocDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'grbSummary
            '
            Me.grbSummary.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.grbSummary.Controls.Add(Me.lblRemaining)
            Me.grbSummary.Controls.Add(Me.txtRemaining)
            Me.grbSummary.Controls.Add(Me.lblRemainingUnit)
            Me.grbSummary.Controls.Add(Me.txtItemCount)
            Me.grbSummary.Controls.Add(Me.lblItemCount)
            Me.grbSummary.Controls.Add(Me.lblItemCountUnit)
            Me.grbSummary.Controls.Add(Me.lblGrossUnit)
            Me.grbSummary.Controls.Add(Me.txtGross)
            Me.grbSummary.Controls.Add(Me.lblGross)
            Me.grbSummary.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.grbSummary.Location = New System.Drawing.Point(112, 344)
            Me.grbSummary.Name = "grbSummary"
            Me.grbSummary.Size = New System.Drawing.Size(688, 45)
            Me.grbSummary.TabIndex = 6
            Me.grbSummary.TabStop = False
            Me.grbSummary.Text = "สรุปรายการรับวางบิล"
            '
            'lblRemaining
            '
            Me.lblRemaining.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblRemaining.Location = New System.Drawing.Point(432, 14)
            Me.lblRemaining.Name = "lblRemaining"
            Me.lblRemaining.Size = New System.Drawing.Size(104, 24)
            Me.lblRemaining.TabIndex = 6
            Me.lblRemaining.Text = "Payment Remaining"
            Me.lblRemaining.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblRemainingUnit
            '
            Me.lblRemainingUnit.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblRemainingUnit.Location = New System.Drawing.Point(648, 16)
            Me.lblRemainingUnit.Name = "lblRemainingUnit"
            Me.lblRemainingUnit.Size = New System.Drawing.Size(32, 18)
            Me.lblRemainingUnit.TabIndex = 8
            Me.lblRemainingUnit.Text = "บาท"
            Me.lblRemainingUnit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblItemCount
            '
            Me.lblItemCount.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblItemCount.Location = New System.Drawing.Point(8, 16)
            Me.lblItemCount.Name = "lblItemCount"
            Me.lblItemCount.Size = New System.Drawing.Size(80, 18)
            Me.lblItemCount.TabIndex = 0
            Me.lblItemCount.Text = "จำนวนรายการ"
            Me.lblItemCount.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblItemCountUnit
            '
            Me.lblItemCountUnit.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblItemCountUnit.Location = New System.Drawing.Point(152, 16)
            Me.lblItemCountUnit.Name = "lblItemCountUnit"
            Me.lblItemCountUnit.Size = New System.Drawing.Size(40, 18)
            Me.lblItemCountUnit.TabIndex = 2
            Me.lblItemCountUnit.Text = "รายการ"
            Me.lblItemCountUnit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblGrossUnit
            '
            Me.lblGrossUnit.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblGrossUnit.Location = New System.Drawing.Point(400, 16)
            Me.lblGrossUnit.Name = "lblGrossUnit"
            Me.lblGrossUnit.Size = New System.Drawing.Size(32, 18)
            Me.lblGrossUnit.TabIndex = 5
            Me.lblGrossUnit.Text = "บาท"
            Me.lblGrossUnit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblGross
            '
            Me.lblGross.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblGross.Location = New System.Drawing.Point(192, 14)
            Me.lblGross.Name = "lblGross"
            Me.lblGross.Size = New System.Drawing.Size(96, 24)
            Me.lblGross.TabIndex = 3
            Me.lblGross.Text = "รวมมูลค่ารับวางบิล"
            Me.lblGross.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblItem
            '
            Me.lblItem.BackColor = System.Drawing.Color.Transparent
            Me.lblItem.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblItem.Location = New System.Drawing.Point(8, 88)
            Me.lblItem.Name = "lblItem"
            Me.lblItem.Size = New System.Drawing.Size(136, 18)
            Me.lblItem.TabIndex = 15
            Me.lblItem.Text = "รายการรับวางบิล:"
            Me.lblItem.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
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
            Me.tgItem.Location = New System.Drawing.Point(8, 104)
            Me.tgItem.Name = "tgItem"
            Me.tgItem.Size = New System.Drawing.Size(784, 232)
            Me.tgItem.SortingArrowColor = System.Drawing.Color.Red
            Me.tgItem.TabIndex = 5
            Me.tgItem.TreeManager = Nothing
            '
            'lblNote
            '
            Me.lblNote.BackColor = System.Drawing.Color.Transparent
            Me.lblNote.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblNote.Location = New System.Drawing.Point(240, 80)
            Me.lblNote.Name = "lblNote"
            Me.lblNote.Size = New System.Drawing.Size(96, 18)
            Me.lblNote.TabIndex = 18
            Me.lblNote.Text = "หมายเหตุ:"
            Me.lblNote.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'ibtnShowEmployee
            '
            Me.ibtnShowEmployee.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.ibtnShowEmployee.Image = CType(resources.GetObject("ibtnShowEmployee.Image"), System.Drawing.Image)
            Me.ibtnShowEmployee.Location = New System.Drawing.Point(352, 40)
            Me.ibtnShowEmployee.Name = "ibtnShowEmployee"
            Me.ibtnShowEmployee.Size = New System.Drawing.Size(24, 23)
            Me.ibtnShowEmployee.TabIndex = 14
            Me.ibtnShowEmployee.TabStop = False
            Me.ibtnShowEmployee.ThemedImage = CType(resources.GetObject("ibtnShowEmployee.ThemedImage"), System.Drawing.Bitmap)
            '
            'ibtnShowEmployeeDialog
            '
            Me.ibtnShowEmployeeDialog.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.ibtnShowEmployeeDialog.ForeColor = System.Drawing.SystemColors.Control
            Me.ibtnShowEmployeeDialog.Image = CType(resources.GetObject("ibtnShowEmployeeDialog.Image"), System.Drawing.Image)
            Me.ibtnShowEmployeeDialog.Location = New System.Drawing.Point(328, 40)
            Me.ibtnShowEmployeeDialog.Name = "ibtnShowEmployeeDialog"
            Me.ibtnShowEmployeeDialog.Size = New System.Drawing.Size(24, 23)
            Me.ibtnShowEmployeeDialog.TabIndex = 13
            Me.ibtnShowEmployeeDialog.TabStop = False
            Me.ibtnShowEmployeeDialog.ThemedImage = CType(resources.GetObject("ibtnShowEmployeeDialog.ThemedImage"), System.Drawing.Bitmap)
            '
            'lblEmployee
            '
            Me.lblEmployee.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblEmployee.Location = New System.Drawing.Point(24, 40)
            Me.lblEmployee.Name = "lblEmployee"
            Me.lblEmployee.Size = New System.Drawing.Size(72, 18)
            Me.lblEmployee.TabIndex = 8
            Me.lblEmployee.Text = "ผู้วางบิล:"
            Me.lblEmployee.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'SaleBillIssueDetail
            '
            Me.Controls.Add(Me.ibtnShowEmployee)
            Me.Controls.Add(Me.txtEmployeeName)
            Me.Controls.Add(Me.txtEmployeeCode)
            Me.Controls.Add(Me.ibtnShowEmployeeDialog)
            Me.Controls.Add(Me.lblEmployee)
            Me.Controls.Add(Me.txtDocDate)
            Me.Controls.Add(Me.txtCode)
            Me.Controls.Add(Me.txtNote)
            Me.Controls.Add(Me.ibtnDelRow)
            Me.Controls.Add(Me.grbCustomer)
            Me.Controls.Add(Me.chkAutorun)
            Me.Controls.Add(Me.dtpDocDate)
            Me.Controls.Add(Me.lblCode)
            Me.Controls.Add(Me.lblDocDate)
            Me.Controls.Add(Me.grbSummary)
            Me.Controls.Add(Me.lblItem)
            Me.Controls.Add(Me.tgItem)
            Me.Controls.Add(Me.lblNote)
            Me.Controls.Add(Me.ibtnBlank)
            Me.Name = "SaleBillIssueDetail"
            Me.Size = New System.Drawing.Size(808, 400)
            Me.grbCustomer.ResumeLayout(False)
            Me.grbSummary.ResumeLayout(False)
            CType(Me.tgItem, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub

#End Region

#Region "Members"
        Private m_entity As SaleBillIssue
        Private m_isInitialized As Boolean = False
        Private m_treeManager As TreeManager

        Private m_tableStyleEnable As Hashtable

        Private m_enableState As Hashtable
#End Region

#Region "Constructors"
        Public Sub New()
            MyBase.New()
            Me.InitializeComponent()
            Me.SetLabelText()
            Initialize()

            SaveEnableState()
            Dim dt As TreeTable = SaleBillIssue.GetSchemaTable()
            Dim dst As DataGridTableStyle = Me.CreateTableStyle()
            m_treeManager = New TreeManager(dt, tgItem)
            m_treeManager.SetTableStyle(dst)
            m_treeManager.AllowSorting = False
            m_treeManager.AllowDelete = False
            tgItem.AllowNew = False

            AddHandler dt.ColumnChanging, AddressOf Treetable_ColumnChanging
            AddHandler dt.ColumnChanged, AddressOf Treetable_ColumnChanged
            AddHandler dt.RowDeleted, AddressOf ItemDelete

            EventWiring()
        End Sub
        Private Sub SaveEnableState()
            m_enableState = New Hashtable
            For Each ctrl As Control In Me.grbCustomer.Controls
                m_enableState.Add(ctrl, ctrl.Enabled)
            Next
            For Each ctrl As Control In Me.grbSummary.Controls
                m_enableState.Add(ctrl, ctrl.Enabled)
            Next
            For Each ctrl As Control In Me.Controls
                m_enableState.Add(ctrl, ctrl.Enabled)
            Next
        End Sub
#End Region

#Region "Style"
        Public Function CreateTableStyle() As DataGridTableStyle
            Dim dst As New DataGridTableStyle
            dst.MappingName = "SaleBillIssue"
            Dim myStringParserService As StringParserService = CType(ServiceManager.Services.GetService(GetType(StringParserService)), StringParserService)

            Dim csLineNumber As New TreeTextColumn
            csLineNumber.MappingName = "salebillii_linenumber"
            csLineNumber.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.SaleBillIssueDetail.LineNumberHeaderText}")
            csLineNumber.NullText = ""
            csLineNumber.Width = 30
            csLineNumber.DataAlignment = HorizontalAlignment.Center
            csLineNumber.ReadOnly = True
            csLineNumber.TextBox.Name = "salebillii_linenumber"

            Dim csType As DataGridComboColumn
            csType = New DataGridComboColumn("salebillii_entityType", CodeDescription.GetCodeList("ReceivableItemType", "code_value not in (48,49)"), "code_description", "code_value")
            csType.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.SaleBillIssueDetail.TypeHeaderText}")
            csType.Width = 70
            csType.NullText = String.Empty

            Dim csCode As New TreeTextColumn
            csCode.MappingName = "Code"
            csCode.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.SaleBillIssueDetail.CodeHeaderText}")
            csCode.NullText = ""
            csCode.TextBox.Name = "Code"

            Dim csButton As New DataGridButtonColumn
            csButton.MappingName = "Button"
            csButton.HeaderText = ""
            csButton.NullText = ""
            AddHandler csButton.Click, AddressOf ItemButtonClick

            Dim csDocDate As New DataGridTimePickerColumn
            csDocDate.MappingName = "DocDate"
            csDocDate.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.SaleBillIssueDetail.DocDateHeaderText}")
            csDocDate.NullText = ""
            'csDocDate.ReadOnly = True

            Dim csDueDate As New DataGridTimePickerColumn
            csDueDate.MappingName = "DueDate"
            csDueDate.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.SaleBillIssueDetail.DueDateHeaderText}")
            csDueDate.NullText = ""
            'csDueDate.ReadOnly = True

            Dim csRealAmount As New TreeTextColumn
            csRealAmount.MappingName = "RealAmount"
            csRealAmount.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.SaleBillIssueDetail.RealAmountHeaderText}")
            csRealAmount.NullText = ""
            csRealAmount.DataAlignment = HorizontalAlignment.Right
            csRealAmount.Format = "#,###.##"
            csRealAmount.ReadOnly = True
            csRealAmount.TextBox.Name = "RealAmount"

            Dim csUnreceivedAmount As New TreeTextColumn
            csUnreceivedAmount.MappingName = "UnreceivedAmount"
            csUnreceivedAmount.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.SaleBillIssueDetail.UnreceivedAmountHeaderText}")
            csUnreceivedAmount.NullText = ""
            csUnreceivedAmount.DataAlignment = HorizontalAlignment.Right
            csUnreceivedAmount.Format = "#,###.##"
            csUnreceivedAmount.ReadOnly = True
            csUnreceivedAmount.TextBox.Name = "UnreceivedAmount"

            Dim csAmount As New TreeTextColumn
            csAmount.MappingName = "salebillii_amt"
            csAmount.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.SaleBillIssueDetail.AmountHeaderText}")
            csAmount.NullText = ""
            csAmount.DataAlignment = HorizontalAlignment.Right
            csAmount.Format = "#,###.##"
            csAmount.TextBox.Name = "salebillii_amt"

            Dim csNote As New TreeTextColumn
            csNote.MappingName = "salebillii_note"
            csNote.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.SaleBillIssueDetail.NoteHeaderText}")
            csNote.NullText = ""
            csNote.Width = 180
            csNote.TextBox.Name = "salebillii_note"

            dst.GridColumnStyles.Add(csLineNumber)
            dst.GridColumnStyles.Add(csType)
            dst.GridColumnStyles.Add(csCode)
            dst.GridColumnStyles.Add(csButton)
            dst.GridColumnStyles.Add(csDocDate)
            dst.GridColumnStyles.Add(csDueDate)
            dst.GridColumnStyles.Add(csRealAmount)
            dst.GridColumnStyles.Add(csUnreceivedAmount)
            dst.GridColumnStyles.Add(csAmount)
            dst.GridColumnStyles.Add(csNote)

            m_tableStyleEnable = New Hashtable
            For Each colStyle As DataGridColumnStyle In dst.GridColumnStyles
                m_tableStyleEnable.Add(colStyle, colStyle.ReadOnly)
            Next
            Return dst
        End Function
#End Region

#Region "Properties"
        Private ReadOnly Property CurrentItem() As SaleBillIssueItem
            Get
                Dim row As TreeRow = Me.m_treeManager.SelectedRow
                If row Is Nothing Then
                    Return Nothing
                End If
                If Not TypeOf row.Tag Is SaleBillIssueItem Then
                    Return Nothing
                End If
                Return CType(row.Tag, SaleBillIssueItem)
            End Get
        End Property
#End Region

#Region "TreeTable Handlers"
        Private Sub Treetable_ColumnChanged(ByVal sender As Object, ByVal e As System.Data.DataColumnChangeEventArgs)
            If Not m_isInitialized Then
                Return
            End If
            Dim index As Integer = Me.m_treeManager.Treetable.Childs.IndexOf(CType(e.Row, TreeRow))
            If ValidateRow(CType(e.Row, TreeRow)) Then
                Me.UpdateAmount()
                Me.m_treeManager.Treetable.AcceptChanges()
            End If
            Me.WorkbenchWindow.ViewContent.IsDirty = True
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
            If Me.m_entity.Customer Is Nothing OrElse Not Me.m_entity.Customer.Originated Then
                msgServ.ShowMessage("${res:Global.Error.SpecifyCustomer}")
                e.ProposedValue = e.Row(e.Column)
                Return
            End If
            If Me.CurrentItem Is Nothing Then
                Dim doc As New SaleBillIssueItem
                Me.m_entity.ItemCollection.Add(doc)
                Me.m_treeManager.SelectedRow.Tag = doc
            End If
            Try
                Select Case e.Column.ColumnName.ToLower
                    Case "code"
                        SetCode(e)
                    Case "salebillii_entitytype"
                        SetEntityType(e)
                    Case "duedate"
                        SetDueDate(e)
                    Case "docdate"
                        SetDate(e)
                    Case "realamount"
                        SetRealAmount(e)
          Case "salebillii_amt"
            If Not IsNumeric(e.ProposedValue.ToString) Then
              e.ProposedValue = ""
            Else
              SetAmount(e)
            End If
          Case "salebillii_note"
              SetNote(e)
        End Select
                ValidateRow(e)
            Catch ex As Exception
                MessageBox.Show(ex.ToString)
            End Try
        End Sub
        Public Sub ValidateRow(ByVal e As DataColumnChangeEventArgs)
            Dim code As Object = e.Row("code")
            Dim salebillii_entitytype As Object = e.Row("salebillii_entitytype")
            Dim salebillii_amt As Object = e.Row("salebillii_amt")

            Select Case e.Column.ColumnName.ToLower
                Case "code"
                    code = e.ProposedValue
                Case "salebillii_entitytype"
                    salebillii_entitytype = e.ProposedValue
                Case "salebillii_amt"
                    salebillii_amt = e.ProposedValue
                Case Else
                    Return
            End Select

            Dim isBlankRow As Boolean = False
            If IsDBNull(salebillii_entitytype) Then
                isBlankRow = True
            End If
            If Not isBlankRow Then
                Select Case CInt(salebillii_entitytype)
                    Case 83 'ขายของ
                        If IsDBNull(code) OrElse code.ToString.Length = 0 Then
                            e.Row.SetColumnError("code", Me.StringParserService.Parse("${res:Global.Error.GoodsSoldCodeMissing}"))
                        Else
                            e.Row.SetColumnError("code", "")
                        End If
                    Case 124 'ขายสินทรัพย์
                        If IsDBNull(code) OrElse code.ToString.Length = 0 Then
                            e.Row.SetColumnError("code", Me.StringParserService.Parse("${res:Global.Error.AssetSoldCodeMissing}"))
                        Else
                            e.Row.SetColumnError("code", "")
                        End If
                    Case 56 'คืนเครื่องจักร
                        If IsDBNull(code) OrElse code.ToString.Length = 0 Then
                            e.Row.SetColumnError("code", Me.StringParserService.Parse("${res:Global.Error.AssetReturnCodeMissing}"))
                        Else
                            e.Row.SetColumnError("code", "")
                        End If
                    Case 48 'ลดหนี้
                        If IsDBNull(code) OrElse code.ToString.Length = 0 Then
                            e.Row.SetColumnError("code", Me.StringParserService.Parse("${res:Global.Error.SaleCNCodeMissing}"))
                        Else
                            e.Row.SetColumnError("code", "")
                        End If
                    Case 49 'เพิ่มหนี้
                        If IsDBNull(code) OrElse code.ToString.Length = 0 Then
                            e.Row.SetColumnError("code", Me.StringParserService.Parse("${res:Global.Error.SaleDNCodeMissing}"))
                        Else
                            e.Row.SetColumnError("code", "")
                        End If
                    Case 24 'ลูกหนี้ยกมา
                        If IsDBNull(code) OrElse code.ToString.Length = 0 Then
                            e.Row.SetColumnError("code", Me.StringParserService.Parse("${res:Global.Error.AROpeningBalanceCodeMissing}"))
                        Else
                            e.Row.SetColumnError("code", "")
                        End If
                    Case Else
                        Return
                End Select
                If IsDBNull(salebillii_amt) OrElse Not IsNumeric(salebillii_amt) OrElse CDec(salebillii_amt) <= 0 Then
                    e.Row.SetColumnError("salebillii_amt", Me.StringParserService.Parse("${res:Global.Error.SaleBillIssueAmountMissing}"))
                Else
                    e.Row.SetColumnError("salebillii_amt", "")
                End If
            End If
        End Sub
        Public Function ValidateRow(ByVal row As TreeRow) As Boolean
            If row.Tag Is Nothing Then
                Return False
            End If
            Return True
        End Function
        Private m_updating As Boolean = False
        Public Sub SetNote(ByVal e As DataColumnChangeEventArgs)
            If m_updating Then
                Return
            End If
            Dim doc As SaleBillIssueItem = Me.CurrentItem
            m_updating = True
            doc.Note = e.ProposedValue.ToString
            m_updating = False
        End Sub
        Public Sub SetAmount(ByVal e As DataColumnChangeEventArgs)
            If m_updating Then
                Return
            End If
            Dim doc As SaleBillIssueItem = Me.CurrentItem
            If IsDBNull(e.ProposedValue) OrElse e.ProposedValue.ToString.Length = 0 Then
                e.ProposedValue = ""
                Return
            End If
            e.ProposedValue = Configuration.FormatToString(CDec(TextParser.Evaluate(e.ProposedValue.ToString)), DigitConfig.Price)
            Dim value As Decimal = CDec(e.ProposedValue)
            Dim remain As Decimal = doc.GetRemainingAmountWithBillIssue(Me.m_entity.Id)
            m_updating = True
            If doc.UnreceivedAmount <> remain Then
                doc.UnreceivedAmount = remain
                e.Row("UnreceivedAmount") = Configuration.FormatToString(doc.UnreceivedAmount, DigitConfig.Price)
            End If
            Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
            If e.Row.IsNull("salebillii_entityType") Then
                msgServ.ShowMessage("${res:Global.Error.NoSaleBillIssueEntityType}")
                e.ProposedValue = e.Row(e.Column)
                m_updating = False
                Return
            End If
            If remain < value Then
                msgServ.ShowMessageFormatted("${res:Global.Error.BilliRemainingAmountLessThanAmount}", _
                New String() { _
                Configuration.FormatToString(remain, DigitConfig.Price) _
                , Configuration.FormatToString(value, DigitConfig.Price) _
                })

                e.ProposedValue = e.Row(e.Column)
                m_updating = False
                Return
            End If
            doc.Amount = value
            m_updating = False
        End Sub
        Public Sub SetRealAmount(ByVal e As DataColumnChangeEventArgs)
            If m_updating Then
                Return
            End If
            m_updating = True
            Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
            msgServ.ShowMessage("${res:Global.Error.CannotChangeRealAmount}")
            e.ProposedValue = e.Row(e.Column)
            m_updating = False
        End Sub
        Public Sub SetDate(ByVal e As DataColumnChangeEventArgs)
            If m_updating Then
                Return
            End If
            m_updating = True
            Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
            msgServ.ShowMessage("${res:Global.Error.CannotChangeDate}")
            e.ProposedValue = e.Row(e.Column)
            m_updating = False
        End Sub
        Public Sub SetDueDate(ByVal e As DataColumnChangeEventArgs)
            If m_updating Then
                Return
            End If
            m_updating = True
            Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
            msgServ.ShowMessage("${res:Global.Error.CannotChangeDueDate}")
            e.ProposedValue = e.Row(e.Column)
            m_updating = False
        End Sub
        Public Sub SetEntityType(ByVal e As DataColumnChangeEventArgs)
            If m_updating Then
                Return
            End If
            Dim doc As SaleBillIssueItem = Me.CurrentItem
            m_updating = True
            Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
            If e.Row.IsNull(e.Column) Then
                m_updating = False
                Return
            End If

            If CInt(e.ProposedValue) = CInt(e.Row(e.Column)) Then
                'ผ่านโลด
                m_updating = False
                Return
            End If
            If msgServ.AskQuestion("${res:Global.Question.ChangeSaleBillIssueEntityType}") Then
                e.Row("salebillii_entity") = DBNull.Value
                e.Row("code") = DBNull.Value
                e.Row("RealAmount") = DBNull.Value
                e.Row("salebillii_amt") = DBNull.Value
                e.Row("UnreceivedAmount") = DBNull.Value
                e.Row("DueDate") = Date.MinValue
                e.Row("DocDate") = Date.MinValue
                doc.Clear()
            Else
                e.ProposedValue = e.Row(e.Column)
                m_updating = False
                Return
            End If
            m_updating = False
        End Sub
        Private Function DupCode(ByVal e As DataColumnChangeEventArgs) As Boolean
            If e.Row.IsNull("salebillii_entityType") Then
                Return False
            End If
            If IsDBNull(e.ProposedValue) Then
                Return False
            End If
            Dim doc As SaleBillIssueItem = Me.CurrentItem
            If doc Is Nothing Then
                Return False
            End If
            For Each item As SaleBillIssueItem In Me.m_entity.ItemCollection
                If Not doc Is item Then
                    If item.EntityId = CInt(e.Row("salebillii_entityType")) Then
                        If e.ProposedValue.ToString.ToLower = item.Code.ToLower Then
                            Return True
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
            Dim doc As SaleBillIssueItem = Me.CurrentItem
            If doc Is Nothing Then
                e.ProposedValue = e.Row(e.Column)
                Return
            End If
            m_updating = True
            Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
            If e.Row.IsNull("salebillii_entityType") Then
                msgServ.ShowMessage("${res:Global.Error.NoSaleBillIssueEntityType}")
                e.ProposedValue = e.Row(e.Column)
                m_updating = False
                Return
            End If
            If DupCode(e) Then
                msgServ.ShowMessageFormatted("${res:Global.Error.AlreadyHasCode}", New String() {BusinessLogic.Entity.GetFullClassName(doc.EntityId), e.ProposedValue.ToString})
                e.ProposedValue = e.Row(e.Column)
                m_updating = False
                Return
            End If
            Select Case CInt(e.Row("salebillii_entityType"))
                Case 83 'ขายของ
                    If e.ProposedValue.ToString.Length = 0 Then
                        If e.Row(e.Column).ToString.Length <> 0 Then
                            If msgServ.AskQuestionFormatted("${res:Global.Question.DeleteGoodsSoldDetail}", New String() {e.Row(e.Column).ToString}) Then
                                e.Row("salebillii_entity") = DBNull.Value
                                e.Row("RealAmount") = DBNull.Value
                                e.Row("UnreceivedAmount") = DBNull.Value
                                e.Row("salebillii_amt") = DBNull.Value
                                e.Row("DueDate") = Date.MinValue
                                e.Row("DocDate") = Date.MinValue
                                doc.Clear()
                            Else
                                e.ProposedValue = e.Row(e.Column)
                            End If
                        End If
                        m_updating = False
                        Return
                    End If
                    Dim gs As New GoodsSold(e.ProposedValue.ToString)
                    If Not gs.Originated Then
                        msgServ.ShowMessageFormatted("${res:Global.Error.NoGoodsSold}", New String() {e.ProposedValue.ToString})
                        e.ProposedValue = e.Row(e.Column)
                        m_updating = False
                        Return
                    Else
                        If gs.Status.Value = 0 Then
                            msgServ.ShowMessageFormatted("${res:Global.Error.GoodsSoldIsCanceled}", New String() {e.ProposedValue.ToString})
                            e.ProposedValue = e.Row(e.Column)
                            m_updating = False
                            Return
                        End If
                        Dim remain As Decimal = gs.GetRemainingAmountWithBillIssue(Me.m_entity.Id)
                        If remain <= 0 Then
                            msgServ.ShowMessageFormatted("${res:Global.Error.ZeroOrLessGoodsSoldAmount}", New String() {e.ProposedValue.ToString})
                            e.ProposedValue = e.Row(e.Column)
                            m_updating = False
                            Return
                        End If
                        e.Row("salebillii_entity") = gs.Id
                        e.ProposedValue = gs.Code
                        e.Row("RealAmount") = Configuration.FormatToString(gs.Receive.Amount, DigitConfig.Price)
                        e.Row("salebillii_amt") = Configuration.FormatToString(remain, DigitConfig.Price)
                        e.Row("UnreceivedAmount") = Configuration.FormatToString(remain, DigitConfig.Price)
                        e.Row("DueDate") = gs.DueDate
                        e.Row("DocDate") = gs.DocDate
                        doc.Id = gs.Id
                        doc.RealAmount = gs.Receive.Amount
                        doc.UnreceivedAmount = remain
                        doc.Amount = remain
                        doc.Code = gs.Code
                        doc.Date = gs.DocDate
                        doc.CreditPeriod = gs.CreditPeriod
                        doc.SetType(83)
                    End If
                Case 56 'คืนเครื่องจักร
                    'If e.ProposedValue.ToString.Length = 0 Then
                    '    If e.Row(e.Column).ToString.Length <> 0 Then
                    '        If msgServ.AskQuestionFormatted("${res:Global.Question.DeleteAssetReturnDetail}", New String() {e.Row(e.Column).ToString}) Then
                    '            e.Row("salebillii_entity") = DBNull.Value
                    '            e.Row("RealAmount") = DBNull.Value
                    '            e.Row("UnreceivedAmount") = DBNull.Value
                    '            e.Row("salebillii_amt") = DBNull.Value
                    '            e.Row("DueDate") = Date.MinValue
                    '            e.Row("DocDate") = Date.MinValue
                    '            doc.Clear()
                    '        Else
                    '            e.ProposedValue = e.Row(e.Column)
                    '        End If
                    '    End If
                    '    m_updating = False
                    '    Return
                    'End If
                    'Dim gs As New AssetReturn(e.ProposedValue.ToString)
                    'If Not gs.Originated Then
                    '    msgServ.ShowMessageFormatted("${res:Global.Error.NoAssetReturn}", New String() {e.ProposedValue.ToString})
                    '    e.ProposedValue = e.Row(e.Column)
                    '    m_updating = False
                    '    Return
                    'Else
                    '    If gs.Status.Value = 0 Then
                    '        msgServ.ShowMessageFormatted("${res:Global.Error.AssetReturnIsCanceled}", New String() {e.ProposedValue.ToString})
                    '        e.ProposedValue = e.Row(e.Column)
                    '        m_updating = False
                    '        Return
                    '    End If
                    '    Dim remain As Decimal = gs.GetRemainingAmountWithBillIssue(Me.m_entity.Id)
                    '    If remain <= 0 Then
                    '        msgServ.ShowMessageFormatted("${res:Global.Error.ZeroOrLessAssetReturnAmount}", New String() {e.ProposedValue.ToString})
                    '        e.ProposedValue = e.Row(e.Column)
                    '        m_updating = False
                    '        Return
                    '    End If
                    '    e.Row("salebillii_entity") = gs.Id
                    '    e.ProposedValue = gs.Code
                    '    e.Row("RealAmount") = Configuration.FormatToString(gs.Receive.Amount, DigitConfig.Price)
                    '    e.Row("salebillii_amt") = Configuration.FormatToString(remain, DigitConfig.Price)
                    '    e.Row("UnreceivedAmount") = Configuration.FormatToString(remain, DigitConfig.Price)
                    '    e.Row("DueDate") = gs.DueDate
                    '    e.Row("DocDate") = gs.DocDate
                    '    doc.Id = gs.Id
                    '    doc.RealAmount = gs.Receive.Amount
                    '    doc.UnreceivedAmount = remain
                    '    doc.Amount = remain
                    '    doc.Code = gs.Code
                    '    doc.Date = gs.DocDate
                    '    doc.CreditPeriod = gs.CreditPeriod
                    '    doc.SetType(83)
                    'End If
                Case 124 'ขายสินทรัพย์
                    If e.ProposedValue.ToString.Length = 0 Then
                        If e.Row(e.Column).ToString.Length <> 0 Then
                            If msgServ.AskQuestionFormatted("${res:Global.Question.DeleteAssetSoldDetail}", New String() {e.Row(e.Column).ToString}) Then
                                e.Row("salebillii_entity") = DBNull.Value
                                e.Row("RealAmount") = DBNull.Value
                                e.Row("UnreceivedAmount") = DBNull.Value
                                e.Row("salebillii_amt") = DBNull.Value
                                e.Row("DueDate") = Date.MinValue
                                e.Row("DocDate") = Date.MinValue
                                doc.Clear()
                            Else
                                e.ProposedValue = e.Row(e.Column)
                            End If
                        End If
                        m_updating = False
                        Return
                    End If
                    Dim gs As New AssetSold(e.ProposedValue.ToString)
                    If Not gs.Originated Then
                        msgServ.ShowMessageFormatted("${res:Global.Error.NoAssetSold}", New String() {e.ProposedValue.ToString})
                        e.ProposedValue = e.Row(e.Column)
                        m_updating = False
                        Return
                    Else
                        If gs.Status.Value = 0 Then
                            msgServ.ShowMessageFormatted("${res:Global.Error.AssetSoldIsCanceled}", New String() {e.ProposedValue.ToString})
                            e.ProposedValue = e.Row(e.Column)
                            m_updating = False
                            Return
                        End If
                        Dim remain As Decimal = gs.GetRemainingAmountWithBillIssue(Me.m_entity.Id)
                        If remain <= 0 Then
                            msgServ.ShowMessageFormatted("${res:Global.Error.ZeroOrLessAssetSoldAmount}", New String() {e.ProposedValue.ToString})
                            e.ProposedValue = e.Row(e.Column)
                            m_updating = False
                            Return
                        End If
                        e.Row("salebillii_entity") = gs.Id
                        e.ProposedValue = gs.Code
                        e.Row("RealAmount") = Configuration.FormatToString(gs.Receive.Amount, DigitConfig.Price)
                        e.Row("salebillii_amt") = Configuration.FormatToString(remain, DigitConfig.Price)
                        e.Row("UnreceivedAmount") = Configuration.FormatToString(remain, DigitConfig.Price)
                        e.Row("DueDate") = gs.DueDate
                        e.Row("DocDate") = gs.DocDate
                        doc.Id = gs.Id
                        doc.RealAmount = gs.Receive.Amount
                        doc.UnreceivedAmount = remain
                        doc.Amount = remain
                        doc.Code = gs.Code
                        doc.Date = gs.DocDate
                        doc.CreditPeriod = gs.CreditPeriod
                        doc.SetType(83)
                    End If
                    'Case 48 'ลดหนี้
                    '    If e.ProposedValue.ToString.Length = 0 Then
                    '        If e.Row(e.Column).ToString.Length <> 0 Then
                    '            If msgServ.AskQuestionFormatted("${res:Global.Question.DeleteSaleCNDetail}", New String() {e.Row(e.Column).ToString}) Then
                    '                e.Row("salebillii_entity") = DBNull.Value
                    '                e.Row("RealAmount") = DBNull.Value
                    '                e.Row("UnreceivedAmount") = DBNull.Value
                    '                e.Row("salebillii_amt") = DBNull.Value
                    '                e.Row("DueDate") = Date.MinValue
                    '                e.Row("DocDate") = Date.MinValue
                    '                doc.Clear()
                    '            Else
                    '                e.ProposedValue = e.Row(e.Column)
                    '            End If
                    '        End If
                    '        m_updating = False
                    '        Return
                    '    End If
                    '    Dim scn As New SaleCN(e.ProposedValue.ToString)
                    '    If Not scn.Originated Then
                    '        msgServ.ShowMessageFormatted("${res:Global.Error.NoSaleCN}", New String() {e.ProposedValue.ToString})
                    '        e.ProposedValue = e.Row(e.Column)
                    '        m_updating = False
                    '        Return
                    '    Else
                    '        If scn.Status.Value = 0 Then
                    '            msgServ.ShowMessageFormatted("${res:Global.Error.SaleCNIsCanceled}", New String() {e.ProposedValue.ToString})
                    '            e.ProposedValue = e.Row(e.Column)
                    '            m_updating = False
                    '            Return
                    '        End If
                    '        Dim remain As Decimal = scn.GetRemainingAmountWithBillIssue(Me.m_entity.Id)
                    '        If remain <= 0 Then
                    '            msgServ.ShowMessageFormatted("${res:Global.Error.ZeroOrLessSaleCNAmount}", New String() {e.ProposedValue.ToString})
                    '            e.ProposedValue = e.Row(e.Column)
                    '            m_updating = False
                    '            Return
                    '        End If
                    '        e.Row("salebillii_entity") = scn.Id
                    '        e.ProposedValue = scn.Code
                    '        e.Row("RealAmount") = Configuration.FormatToString(scn.Receive.Amount, DigitConfig.Price)
                    '        e.Row("salebillii_amt") = Configuration.FormatToString(remain, DigitConfig.Price)
                    '        e.Row("UnreceivedAmount") = Configuration.FormatToString(remain, DigitConfig.Price)
                    '        e.Row("DueDate") = scn.DueDate
                    '        e.Row("DocDate") = scn.DocDate
                    '        doc.Id = scn.Id
                    '        doc.RealAmount = scn.Receive.Amount
                    '        doc.UnreceivedAmount = remain
                    '        doc.Amount = remain
                    '        doc.Code = scn.Code
                    '        doc.Date = scn.DocDate
                    '        doc.CreditPeriod = scn.CreditPeriod
                    '        doc.SetType(46)
                    '    End If
                    'Case 49 'เพิ่มหนี้
                    '    If e.ProposedValue.ToString.Length = 0 Then
                    '        If e.Row(e.Column).ToString.Length <> 0 Then
                    '            If msgServ.AskQuestionFormatted("${res:Global.Question.DeleteSaleDNDetail}", New String() {e.Row(e.Column).ToString}) Then
                    '                e.Row("salebillii_entity") = DBNull.Value
                    '                e.Row("RealAmount") = DBNull.Value
                    '                e.Row("UnreceivedAmount") = DBNull.Value
                    '                e.Row("salebillii_amt") = DBNull.Value
                    '                e.Row("DueDate") = Date.MinValue
                    '                e.Row("DocDate") = Date.MinValue
                    '                doc.Clear()
                    '            Else
                    '                e.ProposedValue = e.Row(e.Column)
                    '            End If
                    '        End If
                    '        m_updating = False
                    '        Return
                    '    End If
                    '    Dim sdn As New SaleDN(e.ProposedValue.ToString)
                    '    If Not sdn.Originated Then
                    '        msgServ.ShowMessageFormatted("${res:Global.Error.NoSaleDN}", New String() {e.ProposedValue.ToString})
                    '        e.ProposedValue = e.Row(e.Column)
                    '        m_updating = False
                    '        Return
                    '    Else
                    '        If sdn.Status.Value = 0 Then
                    '            msgServ.ShowMessageFormatted("${res:Global.Error.SaleDNIsCanceled}", New String() {e.ProposedValue.ToString})
                    '            e.ProposedValue = e.Row(e.Column)
                    '            m_updating = False
                    '            Return
                    '        End If
                    '        Dim remain As Decimal = sdn.GetRemainingAmountWithBillIssue(Me.m_entity.Id)
                    '        If remain <= 0 Then
                    '            msgServ.ShowMessageFormatted("${res:Global.Error.ZeroOrLessSaleDNAmount}", New String() {e.ProposedValue.ToString})
                    '            e.ProposedValue = e.Row(e.Column)
                    '            m_updating = False
                    '            Return
                    '        End If
                    '        e.Row("salebillii_entity") = sdn.Id
                    '        e.ProposedValue = sdn.Code
                    '        e.Row("RealAmount") = Configuration.FormatToString(sdn.Receive.Amount, DigitConfig.Price)
                    '        e.Row("salebillii_amt") = Configuration.FormatToString(remain, DigitConfig.Price)
                    '        e.Row("UnreceivedAmount") = Configuration.FormatToString(remain, DigitConfig.Price)
                    '        e.Row("DueDate") = sdn.DueDate
                    '        e.Row("DocDate") = sdn.DocDate
                    '        doc.Id = sdn.Id
                    '        doc.RealAmount = sdn.Receive.Amount
                    '        doc.UnreceivedAmount = remain
                    '        doc.Amount = remain
                    '        doc.Code = sdn.Code
                    '        doc.Date = sdn.DocDate
                    '        doc.CreditPeriod = sdn.CreditPeriod
                    '        doc.SetType(46)
                    '    End If
                Case 24 'ลูกหนี้ยกมา
                    If e.ProposedValue.ToString.Length = 0 Then
                        If e.Row(e.Column).ToString.Length <> 0 Then
                            If msgServ.AskQuestionFormatted("${res:Global.Question.DeleteAROpeningBalanceDetail}", New String() {e.Row(e.Column).ToString}) Then
                                e.Row("salebillii_entity") = DBNull.Value
                                e.Row("RealAmount") = DBNull.Value
                                e.Row("salebillii_amt") = DBNull.Value
                                e.Row("UnreceivedAmount") = DBNull.Value
                                e.Row("DueDate") = Date.MinValue
                                e.Row("DocDate") = Date.MinValue
                                doc.Clear()
                            Else
                                e.ProposedValue = e.Row(e.Column)
                            End If
                        End If
                        m_updating = False
                        Return
                    End If
                    Dim apo As New AROpeningBalance(e.ProposedValue.ToString)
                    If Not apo.Originated Then
                        msgServ.ShowMessageFormatted("${res:Global.Error.NoAROpeningBalance}", New String() {e.ProposedValue.ToString})
                        e.ProposedValue = e.Row(e.Column)
                        m_updating = False
                        Return
                    Else
                        If apo.Status.Value = 0 Then
                            msgServ.ShowMessageFormatted("${res:Global.Error.AROpeningBalanceIsCanceled}", New String() {e.ProposedValue.ToString})
                            e.ProposedValue = e.Row(e.Column)
                            m_updating = False
                            Return
                        End If
                        Dim remain As Decimal = apo.GetRemainingAmountWithBillIssue(Me.m_entity.Id)
                        If remain <= 0 Then
                            msgServ.ShowMessageFormatted("${res:Global.Error.ZeroOrLessAROpeningBalanceAmount}", New String() {e.ProposedValue.ToString})
                            e.ProposedValue = e.Row(e.Column)
                            m_updating = False
                            Return
                        End If
                        e.Row("salebillii_entity") = apo.Id
                        e.ProposedValue = apo.Code
                        e.Row("RealAmount") = Configuration.FormatToString(apo.Receive.Amount, DigitConfig.Price)
                        e.Row("salebillii_amt") = Configuration.FormatToString(remain, DigitConfig.Price)
                        e.Row("UnreceivedAmount") = Configuration.FormatToString(remain, DigitConfig.Price)
                        e.Row("DueDate") = apo.DueDate
                        e.Row("DocDate") = apo.DocDate
                        doc.Id = apo.Id
                        doc.RealAmount = apo.Receive.Amount
                        doc.UnreceivedAmount = remain
                        doc.Amount = remain
                        doc.Code = apo.Code
                        doc.Date = apo.DocDate
                        doc.CreditPeriod = apo.CreditPeriod
                        doc.SetType(46)
                    End If
                Case Else
                    msgServ.ShowMessage("${res:Global.Error.NoSaleBillIssueEntityType}")
                    e.ProposedValue = e.Row(e.Column)
                    m_updating = False
                    Return
            End Select
            m_updating = False
        End Sub
        Private Sub ItemDelete(ByVal sender As Object, ByVal e As System.Data.DataRowChangeEventArgs)
        End Sub
#End Region

#Region "IListDetail"
        Public Overrides Sub CheckFormEnable()
            If Me.m_entity Is Nothing Then
                Return
            End If
            If Me.m_entity.Status.Value = 0 _
            OrElse m_entityRefed = 1 _
            Then
                Me.Enabled = False
            Else
                Me.Enabled = True
            End If
        End Sub
        Public Overrides Sub ClearDetail()
            For Each crlt As Control In Me.Controls
                If crlt.Name.StartsWith("txt") Then
                    crlt.Text = ""
                End If
            Next
            For Each crlt As Control In grbCustomer.Controls
                If crlt.Name.StartsWith("txt") Then
                    crlt.Text = ""
                End If
            Next
            For Each crlt As Control In grbSummary.Controls
                If crlt.Name.StartsWith("txt") Then
                    crlt.Text = ""
                End If
            Next
            Me.dtpDocDate.Value = Now
        End Sub
        Public Overrides Sub SetLabelText()
            If Not m_entity Is Nothing Then Me.Text = Me.StringParserService.Parse(Me.m_entity.TabPageText)

            Me.lblDocDate.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.SaleBillIssueDetail.lblDocDate}")
            Me.Validator.SetDisplayName(Me.txtDocDate, Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.SaleBillIssueDetail.txtDocDateAlert}"))
            Me.lblCode.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.SaleBillIssueDetail.lblCode}")
            Me.Validator.SetDisplayName(Me.txtCode, Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.SaleBillIssueDetail.txtCodeAlert}"))

            Me.lblItem.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.SaleBillIssueDetail.lblItem}")
            Me.grbSummary.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.SaleBillIssueDetail.grbSummary}")
            Me.lblItemCount.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.SaleBillIssueDetail.lblItemCount}")
            Me.lblItemCountUnit.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.SaleBillIssueDetail.lblItemCountUnit}")
            Me.lblNote.Text = Me.StringParserService.Parse("${res:Global.NoteText}")

            Me.lblCredit.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.SaleBillIssueDetail.lblCredit}")
            Me.Validator.SetDisplayName(Me.txtcreditperiod, Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.SaleBillIssueDetail.txtcreditperiodAlert}"))

            Me.lblDay.Text = Me.StringParserService.Parse("${res:Global.DayText}")
            Me.lblDueDate.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.SaleBillIssueDetail.lblDueDate}")
            Me.grbCustomer.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.SaleBillIssueDetail.grbCustomer}")

            Me.lblCustomer.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.SaleBillIssueDetail.lblCustomer}")
            Me.Validator.SetDisplayName(Me.txtCustomerCode, Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.SaleBillIssueDetail.txtCustomerCodeAlert}"))

            Me.lblRemaining.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.SaleBillIssueDetail.lblRemaining}")
            Me.lblRemainingUnit.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.SaleBillIssueDetail.lblRemainingUnit}")
            Me.lblGrossUnit.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.SaleBillIssueDetail.lblGrossUnit}")
            Me.lblGross.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.SaleBillIssueDetail.lblGross}")

            Me.lblEmployee.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.SaleBillIssueDetail.lblEmployee}")
            Me.Validator.SetDisplayName(Me.txtEmployeeCode, Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.SaleBillIssueDetail.txtEmployeeCodeAlert}"))

        End Sub
        Protected Overrides Sub EventWiring()
            AddHandler txtCode.TextChanged, AddressOf Me.ChangeProperty
            AddHandler txtNote.TextChanged, AddressOf Me.ChangeProperty

            AddHandler txtDocDate.Validated, AddressOf Me.ChangeProperty
            AddHandler dtpDocDate.ValueChanged, AddressOf Me.ChangeProperty

            AddHandler txtcreditperiod.Validated, AddressOf Me.ChangeProperty
            AddHandler txtcreditperiod.TextChanged, AddressOf Me.TextHandler

            AddHandler txtNote.TextChanged, AddressOf Me.ChangeProperty

            AddHandler txtCustomerCode.Validated, AddressOf Me.ChangeProperty
            AddHandler txtCustomerCode.TextChanged, AddressOf Me.TextHandler

            AddHandler txtEmployeeCode.Validated, AddressOf Me.ChangeProperty
            AddHandler txtEmployeeCode.TextChanged, AddressOf Me.TextHandler
        End Sub
        Private customerCodeChanged As Boolean = False
        Private txtCreditPeriodChanged As Boolean = False
        Private txtEmployeeCodeChanged As Boolean = False
        Private Sub TextHandler(ByVal sender As Object, ByVal e As EventArgs)
            If Me.m_entity Is Nothing Or Not m_isInitialized Then
                Return
            End If
            Select Case CType(sender, Control).Name.ToLower
                Case "txtcustomercode"
                    customerCodeChanged = True
                Case "txtcreditperiod"
                    txtCreditPeriodChanged = True
                Case "txtemployeecode"
                    txtEmployeeCodeChanged = True
            End Select
        End Sub
        Private oldEmployeeId As Integer
        Public Overrides Sub UpdateEntityProperties()
            m_isInitialized = False
            ClearDetail()
            If m_entity Is Nothing Then
                Return
            End If
            oldCustId = Me.m_entity.Customer.Id
            oldEmployeeId = Me.m_entity.Employee.Id
            txtCode.Text = m_entity.Code
            txtNote.Text = m_entity.Note
            Me.m_oldCode = Me.m_entity.Code
            Me.chkAutorun.Checked = Me.m_entity.AutoGen
            Me.UpdateAutogenStatus()

            txtEmployeeCode.Text = m_entity.Employee.Code
            txtEmployeeName.Text = m_entity.Employee.Name

            txtCustomerCode.Text = m_entity.Customer.Code
            txtCustomerName.Text = m_entity.Customer.Name
            Me.dtpDueDate.Value = MinDateToNow(Me.m_entity.DueDate)
            txtcreditperiod.Text = Configuration.FormatToString(m_entity.CreditPeriod, DigitConfig.Int)

            txtDocDate.Text = MinDateToNull(Me.m_entity.DocDate, Me.StringParserService.Parse("${res:Global.BlankDateText}"))
            dtpDocDate.Value = MinDateToNow(Me.m_entity.DocDate)

            RefreshDocs()

            UpdateAmount()

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
            Me.m_isInitialized = True
        End Sub
        Private Sub PropChanged(ByVal sender As Object, ByVal e As PropertyChangedEventArgs)
            If e.Name = "ItemChanged" Then
                Me.WorkbenchWindow.ViewContent.IsDirty = True
            End If
        End Sub
        Private m_dateSetting As Boolean = False
        Private oldCustId As Integer
        Public Sub ChangeProperty(ByVal sender As Object, ByVal e As EventArgs)
            If Me.m_entity Is Nothing Or Not m_isInitialized Then
                Return
            End If
            Dim dirtyFlag As Boolean = False
            Select Case CType(sender, Control).Name.ToLower
                Case "txtcode"
                    Me.m_entity.Code = txtCode.Text
                    dirtyFlag = True
                Case "txtnote"
                    Me.m_entity.Note = txtNote.Text
                    dirtyFlag = True
                Case "txtcustomercode"
                    If customerCodeChanged Then
                        customerCodeChanged = False
                        Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
                        If Me.txtCustomerCode.TextLength <> 0 Then
                            Dim oldCustomer As Customer = Me.m_entity.Customer
                            Customer.GetCustomer(txtCustomerCode, txtCustomerName, Me.m_entity.Customer)
                            Try
                                If oldCustId <> Me.m_entity.Customer.Id Then
                                    If msgServ.AskQuestion("${res:Longkong.Pojjaman.Gui.Panels.SaleBillIssueDetail.Message.ChangeCustomer}", "${res:Longkong.Pojjaman.Gui.Panels.SaleBillIssueDetail.Caption.ChangeCustomer}") Then
                                        oldCustId = Me.m_entity.Customer.Id
                                        dirtyFlag = True
                                        ChangeCustomer()
                                    Else
                                        dirtyFlag = False
                                        Me.m_entity.Customer = oldCustomer
                                        Me.txtCustomerCode.Text = oldCustomer.Code
                                        Me.txtCustomerName.Text = oldCustomer.Name
                                        customerCodeChanged = False
                                    End If
                                End If
                            Catch ex As Exception
                                MessageBox.Show(ex.ToString)
                            End Try
                        Else
                            If msgServ.AskQuestion("${res:Longkong.Pojjaman.Gui.Panels.SaleBillIssueDetail.Message.ChangeCustomer}", "${res:Longkong.Pojjaman.Gui.Panels.SaleBillIssueDetail.Caption.ChangeCustomer}") Then
                                Me.m_entity.Customer = New Customer
                                dirtyFlag = True
                                txtCustomerName.Text = ""
                                ChangeCustomer()
                            Else
                                Me.txtCustomerCode.Text = Me.m_entity.Customer.Code
                            End If
                        End If
                    End If
                Case "txtemployeecode"
                    If txtEmployeeCodeChanged Then
                        txtEmployeeCodeChanged = False
                        Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
                        If Me.txtEmployeeCode.TextLength <> 0 Then
                            Employee.GetEmployee(txtEmployeeCode, txtEmployeeName, Me.m_entity.Employee)
                            Try
                                If oldEmployeeId <> Me.m_entity.Employee.Id Then
                                    oldEmployeeId = Me.m_entity.Employee.Id
                                    dirtyFlag = True
                                End If
                            Catch ex As Exception

                            End Try
                        End If
                    End If
                Case "dtpdocdate"
                    If Not Me.m_entity.DocDate.Equals(dtpDocDate.Value) Then
                        If Not m_dateSetting Then
                            Me.txtDocDate.Text = MinDateToNull(dtpDocDate.Value, Me.StringParserService.Parse("${res:Global.BlankDateText}"))
                            Me.m_entity.DocDate = dtpDocDate.Value
                        End If
                        dirtyFlag = True
                        Me.dtpDueDate.Value = MinDateToNow(Me.m_entity.DueDate)
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
                    Me.dtpDueDate.Value = MinDateToNow(Me.m_entity.DueDate)
                    m_dateSetting = False
                Case "txtcreditperiod"
                    If txtCreditPeriodChanged Then
                        txtCreditPeriodChanged = False
                        Dim txt As String = Me.txtcreditperiod.Text
                        If txt.Length > 0 AndAlso IsNumeric(txt) Then
                            Me.m_entity.CreditPeriod = CInt(txt)
                        Else
                            Me.m_entity.CreditPeriod = 0
                        End If
                        txtcreditperiod.Text = Configuration.FormatToString(Me.m_entity.CreditPeriod, DigitConfig.Int)
                        Me.dtpDueDate.Value = MinDateToNow(Me.m_entity.DueDate)
                        dirtyFlag = True
                    End If
            End Select
            Me.WorkbenchWindow.ViewContent.IsDirty = Me.WorkbenchWindow.ViewContent.IsDirty Or dirtyFlag
            CheckFormEnable()
        End Sub
        Private Sub ChangeCustomer()
            oldCustId = Me.m_entity.Customer.Id
            Me.m_entity.ItemCollection.Clear()
            RefreshDocs()
            UpdateAmount()
            customerCodeChanged = False
            Me.m_entity.CreditPeriod = Me.m_entity.Customer.CreditPeriod
            Me.txtcreditperiod.Text = Configuration.FormatToString(Me.m_entity.CreditPeriod, DigitConfig.Int)
            Me.dtpDueDate.Value = MinDateToNow(Me.m_entity.DueDate)
            txtCreditPeriodChanged = False
        End Sub
        Private Sub UpdateAmount()
            m_isInitialized = False
            txtGross.Text = Configuration.FormatToString(m_entity.Gross, DigitConfig.Price)
            Me.txtItemCount.Text = Configuration.FormatToString(m_entity.ItemCount, DigitConfig.Int)
            Me.txtRemaining.Text = Configuration.FormatToString(m_entity.RemainingAmount, DigitConfig.Price)
            m_isInitialized = True
        End Sub
        Public Sub SetStatus()
            If m_entity.Canceled Then
                Me.StatusBarService.SetMessage("ยกเลิก: " & m_entity.CancelDate.ToShortDateString & _
                " " & m_entity.CancelDate.ToShortTimeString & _
                "  โดย:" & m_entity.CancelPerson.Name)
            ElseIf m_entity.Edited Then
                Me.StatusBarService.SetMessage("แก้ไขล่าสุด: " & m_entity.LastEditDate.ToShortDateString & _
                " " & m_entity.LastEditDate.ToShortTimeString & _
                "  โดย:" & m_entity.LastEditor.Name)
            ElseIf m_entity.Originated Then
                Me.StatusBarService.SetMessage("เพิ่มเข้าสู่ระบบ: " & m_entity.OriginDate.ToShortDateString & _
                " " & m_entity.OriginDate.ToShortTimeString & _
                "  โดย:" & m_entity.Originator.Name)
            Else
                Me.StatusBarService.SetMessage("")
            End If
        End Sub
        Private m_entityRefed As Integer = -1
        Public Overrides Property Entity() As ISimpleEntity
            Get
                Return Me.m_entity
            End Get
            Set(ByVal Value As ISimpleEntity)
                If Not m_entity Is Nothing Then
                    RemoveHandler Me.m_entity.PropertyChanged, AddressOf PropChanged
                    Me.m_entity = Nothing
                End If
                Me.m_entity = CType(Value, SaleBillIssue)
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
            'PopulateRequestor()
            'PopulateCostCenter()
        End Sub


#End Region

#Region "Event Handlers"
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
        Public Sub ItemButtonClick(ByVal e As ButtonColumnEventArgs)
            Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
            Dim config As Boolean = Configuration.GetConfig("GSCannotBeRefedByBillaTwice")
            If Me.m_entity Is Nothing Then
                Return
            End If
            If Me.m_entity.Customer Is Nothing OrElse Not Me.m_entity.Customer.Originated Then
                msgServ.ShowMessage("${res:Global.Error.SpecifyCustomer}")
                Return
            End If
            Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
            Dim filterEntities(3) As ArrayList
            For i As Integer = 0 To 3
                If i <> 2 Then
                    filterEntities(i) = New ArrayList
                    filterEntities(i).Add(Me.m_entity.Customer)
                Else
                    Dim eqr As New AssetReturn
                    eqr.IsExternal = True
                    eqr.ReturnPerson = Me.m_entity.Customer
                    filterEntities(i) = New ArrayList
                    filterEntities(i).Add(eqr)
                End If
            Next
            Dim filters(3)() As Filter
            filters(0) = New Filter() {New Filter("IDList", GetItemIDList(83)), _
            New Filter("remainMustValid", True), New Filter("GSCannotBeRefedByBillaTwice", config)}
            filters(1) = New Filter() {New Filter("IDList", GetItemIDList(24)), _
            New Filter("remainMustValid", True), New Filter("GSCannotBeRefedByBillaTwice", config)}
            filters(2) = New Filter() {New Filter("IDList", GetItemIDList(56)), _
            New Filter("remainMustValid", True)}
            filters(3) = New Filter() {New Filter("IDList", GetItemIDList(124)), _
            New Filter("remainMustValid", True)}
            'filters(4) = New Filter() {New Filter("IDList", GetItemIDList(48))}
            'filters(5) = New Filter() {New Filter("IDList", GetItemIDList(49))}
            Dim entities(3) As ISimpleEntity
            entities(0) = New GoodsSold
            entities(1) = New AROpeningBalance
            entities(2) = New AssetReturn
            entities(3) = New AssetSold
            'entities(4) = New SaleCN
            'entities(5) = New SaleDN
            myEntityPanelService.OpenListDialog(entities, AddressOf SetItems, filters, filterEntities)
        End Sub
        Private Function GetItemIDList(ByVal type As Integer) As String
            Dim ret As String = ""
            For Each item As SaleBillIssueItem In Me.m_entity.ItemCollection
                If item.Originated AndAlso item.EntityId = type Then
                    ret &= item.Id.ToString & ","
                End If
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
                Dim item As BasketItem = CType(items(i), BasketItem)
                Dim newItem As SaleBillIssueItem
                If TypeOf item.Tag Is DataRow Then
                    newItem = New SaleBillIssueItem(CType(item.Tag, DataRow), "", Me.m_entity)
                Else
                    Select Case item.FullClassName.ToLower
                        Case "longkong.pojjaman.businesslogic.goodssold"
                            newItem = New SaleBillIssueItem(New GoodsSold(item.Id), Me.m_entity)
                        Case "longkong.pojjaman.businesslogic.goodssold"
                            newItem = New SaleBillIssueItem(New GoodsSold(item.Id), Me.m_entity)
                    End Select
                End If
                If i = items.Count - 1 Then
                    'ตัวแรก -- update old item
                    If Me.m_entity.ItemCollection.Count = 0 Then
                        newItem.Amount = newItem.UnreceivedAmount
                        Me.m_entity.ItemCollection.Add(newItem)
                    Else
                        Dim theDoc As SaleBillIssueItem = Me.CurrentItem
                        If Me.CurrentItem Is Nothing Then
                            If index > Me.m_entity.ItemCollection.Count - 1 Then
                                Me.m_entity.ItemCollection.Add(newItem)
                                theDoc = newItem
                                insertIndex = Me.m_entity.ItemCollection.IndexOf(newItem)
                            Else
                                Me.m_entity.ItemCollection.Insert(insertIndex, newItem)
                                theDoc = Me.m_entity.ItemCollection(insertIndex)
                            End If
                        End If
                        theDoc.Id = newItem.Id
                        theDoc.Code = newItem.Code
                        theDoc.AfterTax = newItem.RealAmount
                        theDoc.Amount = newItem.UnreceivedAmount 'newItem.Amount ยอด 0
                        theDoc.UnreceivedAmount = newItem.UnreceivedAmount
                        theDoc.SetType(newItem.EntityId)
                        theDoc.CreditPeriod = newItem.CreditPeriod
                        theDoc.Date = newItem.Date
                    End If
                Else
                    newItem.Amount = newItem.UnreceivedAmount
                    Me.m_entity.ItemCollection.Insert(insertIndex, newItem)
                End If
            Next
            RefreshDocs()
            tgItem.CurrentRowIndex = index
            UpdateAmount()
        End Sub
        Private Sub ibtnBlank_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnBlank.Click
            Dim index As Integer = tgItem.CurrentRowIndex
            If index > Me.m_entity.ItemCollection.Count - 1 Then
                Return
            End If
            Me.m_entity.ItemCollection.Insert(index, New SaleBillIssueItem)
            RefreshDocs()
            tgItem.CurrentRowIndex = index
            Dim re As New DataColumnChangeEventArgs(Me.m_treeManager.Treetable.Rows(index) _
         , Me.m_treeManager.Treetable.Columns("salebillii_amt") _
         , Me.CurrentItem.Amount)
            Me.ValidateRow(re)
            Me.WorkbenchWindow.ViewContent.IsDirty = True
        End Sub
        Private Sub ibtnDelRow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnDelRow.Click
            Dim index As Integer = Me.tgItem.CurrentRowIndex
            Dim row As TreeRow = Me.m_treeManager.SelectedRow
            If row Is Nothing Then
                Return
            End If
            Dim doc As SaleBillIssueItem = Me.CurrentItem
            If doc Is Nothing Then
                Return
            End If
            Me.WorkbenchWindow.ViewContent.IsDirty = True
            Me.m_entity.ItemCollection.Remove(doc)
            RefreshDocs()
            Me.tgItem.CurrentRowIndex = index
        End Sub
        Private Sub ReIndex()
            Dim i As Integer = 0
            For Each row As DataRow In Me.m_treeManager.Treetable.Rows
                row("salebillii_linenumber") = i + 1
                i += 1
            Next
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
        Public Overrides Sub NotifyBeforeSave()

        End Sub
        'Public Overrides Sub NotifyAfterSave(ByVal successful As Boolean)
        '    If Not successful Then
        '        Return
        '    End If
        '    Me.Entity = New PR(Me.Entity.Id)
        '    Dim listPanel As ISimpleListPanel = CType(Me.WorkbenchWindow.ViewContent, ISimpleListPanel)
        '    listPanel.SelectedEntity = Me.Entity
        'End Sub
        Public Overrides ReadOnly Property TabPageIcon() As String
            Get
                Return (New PR).DetailPanelIcon
            End Get
        End Property
#End Region

#Region "Event of Button controls"
        Private Sub btnCustomer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnShowCustomer.Click
            Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
            myEntityPanelService.OpenPanel(New Customer)
        End Sub
        Private Sub btnCustomerDialog_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnShowCustomerDialog.Click
            Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
            myEntityPanelService.OpenListDialog(New Customer, AddressOf SetCustomer)
        End Sub
        Private Sub SetCustomer(ByVal e As ISimpleEntity)
            Me.txtCustomerCode.Text = e.Code
            Me.ChangeProperty(txtCustomerCode, Nothing)
        End Sub
        Private Sub ibtnShowEmployeeDialog_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnShowEmployeeDialog.Click
            Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
            myEntityPanelService.OpenListDialog(New Employee, AddressOf SetEmployee)
        End Sub
        Private Sub ibtnShowEmployee_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnShowEmployee.Click
            Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
            myEntityPanelService.OpenPanel(New Employee)
        End Sub
        Private Sub SetEmployee(ByVal e As ISimpleEntity)
            Me.txtEmployeeCode.Text = e.Code
            Me.ChangeProperty(txtEmployeeCode, Nothing)
        End Sub
#End Region

#Region "IClipboardHandler Overrides"
        Public Overrides ReadOnly Property EnablePaste() As Boolean
            Get
                Dim data As IDataObject = Clipboard.GetDataObject
                If data.GetDataPresent((New Customer).FullClassName) Then
                    If Not Me.ActiveControl Is Nothing Then
                        Select Case Me.ActiveControl.Name.ToLower
                            Case "txtcustomercode", "txtcustomername"
                                Return True
                        End Select
                    End If
                End If
                Return False
            End Get
        End Property
        Public Overrides Sub Paste(ByVal sender As Object, ByVal e As System.EventArgs)
            Dim data As IDataObject = Clipboard.GetDataObject
            If data.GetDataPresent((New Customer).FullClassName) Then
                Dim id As Integer = CInt(data.GetData((New Customer).FullClassName))
                Dim entity As New Customer(id)
                If Not Me.ActiveControl Is Nothing Then
                    Select Case Me.ActiveControl.Name.ToLower
                        Case "txtcustomercode", "txtcustomername"
                            Me.SetCustomer(entity)
                    End Select
                End If
            End If
        End Sub
#End Region

#Region "Grid Resizing"
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
            Dim maxVisibleCount As Integer
            Dim tgRowHeight As Integer = 17
            maxVisibleCount = CInt(Math.Floor((Me.tgItem.Height - tgRowHeight) / tgRowHeight))
            Do While Me.m_treeManager.Treetable.Rows.Count < maxVisibleCount - 1
                'เพิ่มแถวจนเต็ม
                Me.m_treeManager.Treetable.Childs.Add()
            Loop
            'If Me.m_entity.MaxRowIndex = maxVisibleCount - 2 Then
            '    If Me.m_treeManager.Treetable.Rows.Count < maxVisibleCount - 1 Then
            '        'เพิ่มอีก 1 แถว ถ้ามีข้อมูลจนถึงแถวสุดท้าย
            '        Me.m_treeManager.Treetable.Childs.Add()
            '    End If
            'End If
            Me.m_treeManager.Treetable.AcceptChanges()
            tgItem.CurrentRowIndex = Math.Max(0, index)
            Me.WorkbenchWindow.ViewContent.IsDirty = dirtyFlag
        End Sub
#End Region

    End Class
End Namespace