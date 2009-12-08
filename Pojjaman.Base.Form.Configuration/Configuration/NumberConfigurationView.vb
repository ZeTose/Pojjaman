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
Imports Longkong.Pojjaman.Gui.Dialogs
Namespace Longkong.Pojjaman.Gui.Panels
    Public Class NumberConfigurationView
        'Inherits UserControl
        Inherits AbstractOptionPanel
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
        Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
        Friend WithEvents Validator As Longkong.Pojjaman.Gui.Components.PJMTextboxValidator
        Friend WithEvents grbDigitConfig As Longkong.Pojjaman.Gui.Components.FixedGroupBox
        Friend WithEvents txtQty As System.Windows.Forms.TextBox
        Friend WithEvents txtPrice As System.Windows.Forms.TextBox
        Friend WithEvents txtUnitPrice As System.Windows.Forms.TextBox
        Friend WithEvents txtCost As System.Windows.Forms.TextBox
        Friend WithEvents lblQty As System.Windows.Forms.Label
        Friend WithEvents lblPrice As System.Windows.Forms.Label
        Friend WithEvents lblUnitPrice As System.Windows.Forms.Label
        Friend WithEvents lblCost As System.Windows.Forms.Label
        Friend WithEvents grbMinusSign As Longkong.Pojjaman.Gui.Components.FixedGroupBox
        Friend WithEvents grbEra As Longkong.Pojjaman.Gui.Components.FixedGroupBox
        Friend WithEvents rdMinusSign As System.Windows.Forms.RadioButton
        Friend WithEvents rdBracket As System.Windows.Forms.RadioButton
        Friend WithEvents rdWindows As System.Windows.Forms.RadioButton
        Friend WithEvents rdBE As System.Windows.Forms.RadioButton
        Friend WithEvents rdCE As System.Windows.Forms.RadioButton
        Friend WithEvents grbMoneyUnit As Longkong.Pojjaman.Gui.Components.FixedGroupBox
        Friend WithEvents txtBigUnit As System.Windows.Forms.TextBox
        Friend WithEvents lblBigUnit As System.Windows.Forms.Label
        Friend WithEvents lblSmallUnit As System.Windows.Forms.Label
        Friend WithEvents txtSmallUnit As System.Windows.Forms.TextBox
        Friend WithEvents grbJEDate As Longkong.Pojjaman.Gui.Components.FixedGroupBox
        Friend WithEvents chkJEDate As System.Windows.Forms.CheckBox
        Friend WithEvents chkShowCents As System.Windows.Forms.CheckBox
        <System.Diagnostics.DebuggerStepThrough()> Protected Sub InitializeComponent()
            Me.components = New System.ComponentModel.Container
            Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider
            Me.Validator = New Longkong.Pojjaman.Gui.Components.PJMTextboxValidator(Me.components)
            Me.txtQty = New System.Windows.Forms.TextBox
            Me.txtPrice = New System.Windows.Forms.TextBox
            Me.txtUnitPrice = New System.Windows.Forms.TextBox
            Me.txtCost = New System.Windows.Forms.TextBox
            Me.txtBigUnit = New System.Windows.Forms.TextBox
            Me.txtSmallUnit = New System.Windows.Forms.TextBox
            Me.grbDigitConfig = New Longkong.Pojjaman.Gui.Components.FixedGroupBox
            Me.lblQty = New System.Windows.Forms.Label
            Me.lblPrice = New System.Windows.Forms.Label
            Me.lblUnitPrice = New System.Windows.Forms.Label
            Me.lblCost = New System.Windows.Forms.Label
            Me.grbMinusSign = New Longkong.Pojjaman.Gui.Components.FixedGroupBox
            Me.rdMinusSign = New System.Windows.Forms.RadioButton
            Me.rdBracket = New System.Windows.Forms.RadioButton
            Me.grbEra = New Longkong.Pojjaman.Gui.Components.FixedGroupBox
            Me.rdWindows = New System.Windows.Forms.RadioButton
            Me.rdBE = New System.Windows.Forms.RadioButton
            Me.rdCE = New System.Windows.Forms.RadioButton
            Me.grbMoneyUnit = New Longkong.Pojjaman.Gui.Components.FixedGroupBox
            Me.lblBigUnit = New System.Windows.Forms.Label
            Me.lblSmallUnit = New System.Windows.Forms.Label
            Me.grbJEDate = New Longkong.Pojjaman.Gui.Components.FixedGroupBox
            Me.chkJEDate = New System.Windows.Forms.CheckBox
            Me.chkShowCents = New System.Windows.Forms.CheckBox
            Me.grbDigitConfig.SuspendLayout()
            Me.grbMinusSign.SuspendLayout()
            Me.grbEra.SuspendLayout()
            Me.grbMoneyUnit.SuspendLayout()
            Me.grbJEDate.SuspendLayout()
            Me.SuspendLayout()
            '
            'ErrorProvider1
            '
            Me.ErrorProvider1.ContainerControl = Me
            '
            'Validator
            '
            Me.Validator.BackcolorChanging = False
            Me.Validator.DataTable = Nothing
            Me.Validator.ErrorProvider = Nothing
            Me.Validator.GotFocusBackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
            Me.Validator.HasNewRow = False
            Me.Validator.InvalidBackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(128, Byte), CType(0, Byte))
            '
            'txtQty
            '
            Me.Validator.SetDataType(Me.txtQty, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtQty, "")
            Me.txtQty.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtQty, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtQty, System.Drawing.Color.Empty)
            Me.txtQty.Location = New System.Drawing.Point(64, 24)
            Me.txtQty.MaxLength = 25
            Me.Validator.SetMaxValue(Me.txtQty, "")
            Me.Validator.SetMinValue(Me.txtQty, "")
            Me.txtQty.Name = "txtQty"
            Me.Validator.SetRegularExpression(Me.txtQty, "")
            Me.Validator.SetRequired(Me.txtQty, False)
            Me.txtQty.Size = New System.Drawing.Size(64, 23)
            Me.txtQty.TabIndex = 0
            Me.txtQty.Text = ""
            Me.txtQty.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
            '
            'txtPrice
            '
            Me.Validator.SetDataType(Me.txtPrice, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtPrice, "")
            Me.txtPrice.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtPrice, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtPrice, System.Drawing.Color.Empty)
            Me.txtPrice.Location = New System.Drawing.Point(192, 48)
            Me.Validator.SetMaxValue(Me.txtPrice, "")
            Me.Validator.SetMinValue(Me.txtPrice, "")
            Me.txtPrice.Name = "txtPrice"
            Me.Validator.SetRegularExpression(Me.txtPrice, "")
            Me.Validator.SetRequired(Me.txtPrice, False)
            Me.txtPrice.Size = New System.Drawing.Size(64, 23)
            Me.txtPrice.TabIndex = 3
            Me.txtPrice.Text = ""
            Me.txtPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
            '
            'txtUnitPrice
            '
            Me.Validator.SetDataType(Me.txtUnitPrice, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtUnitPrice, "")
            Me.txtUnitPrice.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtUnitPrice, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtUnitPrice, System.Drawing.Color.Empty)
            Me.txtUnitPrice.Location = New System.Drawing.Point(64, 48)
            Me.Validator.SetMaxValue(Me.txtUnitPrice, "")
            Me.Validator.SetMinValue(Me.txtUnitPrice, "")
            Me.txtUnitPrice.Name = "txtUnitPrice"
            Me.Validator.SetRegularExpression(Me.txtUnitPrice, "")
            Me.Validator.SetRequired(Me.txtUnitPrice, False)
            Me.txtUnitPrice.Size = New System.Drawing.Size(64, 23)
            Me.txtUnitPrice.TabIndex = 2
            Me.txtUnitPrice.Text = ""
            Me.txtUnitPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
            '
            'txtCost
            '
            Me.Validator.SetDataType(Me.txtCost, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtCost, "")
            Me.txtCost.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtCost, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtCost, System.Drawing.Color.Empty)
            Me.txtCost.Location = New System.Drawing.Point(192, 24)
            Me.Validator.SetMaxValue(Me.txtCost, "")
            Me.Validator.SetMinValue(Me.txtCost, "")
            Me.txtCost.Name = "txtCost"
            Me.Validator.SetRegularExpression(Me.txtCost, "")
            Me.Validator.SetRequired(Me.txtCost, False)
            Me.txtCost.Size = New System.Drawing.Size(64, 23)
            Me.txtCost.TabIndex = 1
            Me.txtCost.Text = ""
            Me.txtCost.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
            '
            'txtBigUnit
            '
            Me.Validator.SetDataType(Me.txtBigUnit, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtBigUnit, "")
            Me.txtBigUnit.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtBigUnit, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtBigUnit, System.Drawing.Color.Empty)
            Me.txtBigUnit.Location = New System.Drawing.Point(80, 24)
            Me.txtBigUnit.MaxLength = 25
            Me.Validator.SetMaxValue(Me.txtBigUnit, "")
            Me.Validator.SetMinValue(Me.txtBigUnit, "")
            Me.txtBigUnit.Name = "txtBigUnit"
            Me.Validator.SetRegularExpression(Me.txtBigUnit, "")
            Me.Validator.SetRequired(Me.txtBigUnit, False)
            Me.txtBigUnit.Size = New System.Drawing.Size(48, 23)
            Me.txtBigUnit.TabIndex = 0
            Me.txtBigUnit.Text = ""
            Me.txtBigUnit.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
            '
            'txtSmallUnit
            '
            Me.Validator.SetDataType(Me.txtSmallUnit, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtSmallUnit, "")
            Me.txtSmallUnit.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtSmallUnit, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtSmallUnit, System.Drawing.Color.Empty)
            Me.txtSmallUnit.Location = New System.Drawing.Point(80, 48)
            Me.Validator.SetMaxValue(Me.txtSmallUnit, "")
            Me.Validator.SetMinValue(Me.txtSmallUnit, "")
            Me.txtSmallUnit.Name = "txtSmallUnit"
            Me.Validator.SetRegularExpression(Me.txtSmallUnit, "")
            Me.Validator.SetRequired(Me.txtSmallUnit, False)
            Me.txtSmallUnit.Size = New System.Drawing.Size(48, 23)
            Me.txtSmallUnit.TabIndex = 2
            Me.txtSmallUnit.Text = ""
            Me.txtSmallUnit.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
            '
            'grbDigitConfig
            '
            Me.grbDigitConfig.Controls.Add(Me.txtQty)
            Me.grbDigitConfig.Controls.Add(Me.lblQty)
            Me.grbDigitConfig.Controls.Add(Me.txtPrice)
            Me.grbDigitConfig.Controls.Add(Me.lblPrice)
            Me.grbDigitConfig.Controls.Add(Me.lblUnitPrice)
            Me.grbDigitConfig.Controls.Add(Me.txtUnitPrice)
            Me.grbDigitConfig.Controls.Add(Me.txtCost)
            Me.grbDigitConfig.Controls.Add(Me.lblCost)
            Me.grbDigitConfig.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.grbDigitConfig.Location = New System.Drawing.Point(24, 16)
            Me.grbDigitConfig.Name = "grbDigitConfig"
            Me.grbDigitConfig.Size = New System.Drawing.Size(272, 112)
            Me.grbDigitConfig.TabIndex = 0
            Me.grbDigitConfig.TabStop = False
            Me.grbDigitConfig.Text = "จำนวนตำแน่งทศนิยม"
            '
            'lblQty
            '
            Me.lblQty.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblQty.ForeColor = System.Drawing.SystemColors.ControlText
            Me.lblQty.Location = New System.Drawing.Point(8, 24)
            Me.lblQty.Name = "lblQty"
            Me.lblQty.Size = New System.Drawing.Size(56, 18)
            Me.lblQty.TabIndex = 4
            Me.lblQty.Text = "ปริมาณ:"
            Me.lblQty.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblPrice
            '
            Me.lblPrice.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblPrice.ForeColor = System.Drawing.SystemColors.ControlText
            Me.lblPrice.Location = New System.Drawing.Point(136, 48)
            Me.lblPrice.Name = "lblPrice"
            Me.lblPrice.Size = New System.Drawing.Size(56, 18)
            Me.lblPrice.TabIndex = 7
            Me.lblPrice.Text = "มูลค่า:"
            Me.lblPrice.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblUnitPrice
            '
            Me.lblUnitPrice.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblUnitPrice.ForeColor = System.Drawing.SystemColors.ControlText
            Me.lblUnitPrice.Location = New System.Drawing.Point(8, 48)
            Me.lblUnitPrice.Name = "lblUnitPrice"
            Me.lblUnitPrice.Size = New System.Drawing.Size(56, 18)
            Me.lblUnitPrice.TabIndex = 5
            Me.lblUnitPrice.Text = "ราคา:"
            Me.lblUnitPrice.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblCost
            '
            Me.lblCost.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblCost.ForeColor = System.Drawing.SystemColors.ControlText
            Me.lblCost.Location = New System.Drawing.Point(136, 24)
            Me.lblCost.Name = "lblCost"
            Me.lblCost.Size = New System.Drawing.Size(56, 18)
            Me.lblCost.TabIndex = 6
            Me.lblCost.Text = "ต้นทุน:"
            Me.lblCost.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'grbMinusSign
            '
            Me.grbMinusSign.Controls.Add(Me.rdMinusSign)
            Me.grbMinusSign.Controls.Add(Me.rdBracket)
            Me.grbMinusSign.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.grbMinusSign.Location = New System.Drawing.Point(24, 136)
            Me.grbMinusSign.Name = "grbMinusSign"
            Me.grbMinusSign.Size = New System.Drawing.Size(416, 72)
            Me.grbMinusSign.TabIndex = 2
            Me.grbMinusSign.TabStop = False
            Me.grbMinusSign.Text = "เครื่องหมายติดลบ (ในการทำรายงาน)"
            '
            'rdMinusSign
            '
            Me.rdMinusSign.Location = New System.Drawing.Point(32, 16)
            Me.rdMinusSign.Name = "rdMinusSign"
            Me.rdMinusSign.Size = New System.Drawing.Size(320, 24)
            Me.rdMinusSign.TabIndex = 0
            Me.rdMinusSign.Text = "เครื่องหมายลบ ""-"""
            '
            'rdBracket
            '
            Me.rdBracket.Location = New System.Drawing.Point(32, 40)
            Me.rdBracket.Name = "rdBracket"
            Me.rdBracket.Size = New System.Drawing.Size(320, 24)
            Me.rdBracket.TabIndex = 1
            Me.rdBracket.Text = "วงเล็บ ""()"""
            '
            'grbEra
            '
            Me.grbEra.Controls.Add(Me.rdWindows)
            Me.grbEra.Controls.Add(Me.rdBE)
            Me.grbEra.Controls.Add(Me.rdCE)
            Me.grbEra.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.grbEra.Location = New System.Drawing.Point(24, 216)
            Me.grbEra.Name = "grbEra"
            Me.grbEra.Size = New System.Drawing.Size(216, 96)
            Me.grbEra.TabIndex = 3
            Me.grbEra.TabStop = False
            Me.grbEra.Text = "การใช้เลขศักราช"
            '
            'rdWindows
            '
            Me.rdWindows.Location = New System.Drawing.Point(32, 16)
            Me.rdWindows.Name = "rdWindows"
            Me.rdWindows.Size = New System.Drawing.Size(168, 24)
            Me.rdWindows.TabIndex = 0
            Me.rdWindows.Text = "ตาม Regional Settings"
            '
            'rdBE
            '
            Me.rdBE.Location = New System.Drawing.Point(32, 40)
            Me.rdBE.Name = "rdBE"
            Me.rdBE.Size = New System.Drawing.Size(168, 24)
            Me.rdBE.TabIndex = 1
            Me.rdBE.Text = "พุทธศักราช"
            '
            'rdCE
            '
            Me.rdCE.Location = New System.Drawing.Point(32, 64)
            Me.rdCE.Name = "rdCE"
            Me.rdCE.Size = New System.Drawing.Size(168, 24)
            Me.rdCE.TabIndex = 2
            Me.rdCE.Text = "คริสตศักราช"
            '
            'grbMoneyUnit
            '
            Me.grbMoneyUnit.Controls.Add(Me.txtBigUnit)
            Me.grbMoneyUnit.Controls.Add(Me.lblBigUnit)
            Me.grbMoneyUnit.Controls.Add(Me.lblSmallUnit)
            Me.grbMoneyUnit.Controls.Add(Me.txtSmallUnit)
            Me.grbMoneyUnit.Controls.Add(Me.chkShowCents)
            Me.grbMoneyUnit.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.grbMoneyUnit.Location = New System.Drawing.Point(304, 16)
            Me.grbMoneyUnit.Name = "grbMoneyUnit"
            Me.grbMoneyUnit.Size = New System.Drawing.Size(136, 112)
            Me.grbMoneyUnit.TabIndex = 1
            Me.grbMoneyUnit.TabStop = False
            Me.grbMoneyUnit.Text = "หน่วยเงินตรา"
            '
            'lblBigUnit
            '
            Me.lblBigUnit.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblBigUnit.ForeColor = System.Drawing.SystemColors.ControlText
            Me.lblBigUnit.Location = New System.Drawing.Point(16, 24)
            Me.lblBigUnit.Name = "lblBigUnit"
            Me.lblBigUnit.Size = New System.Drawing.Size(64, 18)
            Me.lblBigUnit.TabIndex = 4
            Me.lblBigUnit.Text = "หน่วยใหญ่:"
            Me.lblBigUnit.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblSmallUnit
            '
            Me.lblSmallUnit.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblSmallUnit.ForeColor = System.Drawing.SystemColors.ControlText
            Me.lblSmallUnit.Location = New System.Drawing.Point(16, 48)
            Me.lblSmallUnit.Name = "lblSmallUnit"
            Me.lblSmallUnit.Size = New System.Drawing.Size(64, 18)
            Me.lblSmallUnit.TabIndex = 5
            Me.lblSmallUnit.Text = "หน่วยย่อย:"
            Me.lblSmallUnit.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'grbJEDate
            '
            Me.grbJEDate.Controls.Add(Me.chkJEDate)
            Me.grbJEDate.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.grbJEDate.Location = New System.Drawing.Point(248, 216)
            Me.grbJEDate.Name = "grbJEDate"
            Me.grbJEDate.Size = New System.Drawing.Size(192, 48)
            Me.grbJEDate.TabIndex = 4
            Me.grbJEDate.TabStop = False
            Me.grbJEDate.Text = "วันที่เอกสาร GL"
            '
            'chkJEDate
            '
            Me.chkJEDate.Location = New System.Drawing.Point(8, 16)
            Me.chkJEDate.Name = "chkJEDate"
            Me.chkJEDate.Size = New System.Drawing.Size(176, 24)
            Me.chkJEDate.TabIndex = 0
            Me.chkJEDate.Text = "ใช้วันที่เดียวกับเอกสารหลัก"
            '
            'chkShowCents
            '
            Me.chkShowCents.Location = New System.Drawing.Point(48, 80)
            Me.chkShowCents.Name = "chkShowCents"
            Me.chkShowCents.Size = New System.Drawing.Size(72, 24)
            Me.chkShowCents.TabIndex = 0
            Me.chkShowCents.Text = "x/100"
            '
            'NumberConfigurationView
            '
            Me.Controls.Add(Me.grbJEDate)
            Me.Controls.Add(Me.grbMoneyUnit)
            Me.Controls.Add(Me.grbDigitConfig)
            Me.Controls.Add(Me.grbMinusSign)
            Me.Controls.Add(Me.grbEra)
            Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Name = "NumberConfigurationView"
            Me.Size = New System.Drawing.Size(456, 320)
            Me.grbDigitConfig.ResumeLayout(False)
            Me.grbMinusSign.ResumeLayout(False)
            Me.grbEra.ResumeLayout(False)
            Me.grbMoneyUnit.ResumeLayout(False)
            Me.grbJEDate.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

#End Region

#Region "Members"
        Private m_isInitialized As Boolean
        Public ConfigFilters(9) As Filter
        Private Dirty As Boolean
#End Region

#Region "Constructors"
        Public Sub New()
            MyBase.New()
            InitializeComponent()
            Me.SetLabelText()
            Initialize()
            EventWiring()
        End Sub
#End Region

#Region "Properties"

#End Region

#Region "IListDetail"
        Public Sub CheckFormEnable()
        End Sub
        Public Sub ClearDetail()
            rdWindows.PerformClick()
            rdMinusSign.PerformClick()
        End Sub
        Public Sub SetLabelText()
            Me.grbDigitConfig.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.NumberConfigurationView.grbDigitConfig}")
            Me.lblQty.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.NumberConfigurationView.lblQty}")
            Me.lblPrice.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.NumberConfigurationView.lblPrice}")
            Me.lblUnitPrice.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.NumberConfigurationView.lblUnitPrice}")
            Me.lblCost.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.NumberConfigurationView.lblCost}")

            Me.grbEra.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.NumberConfigurationView.grbEra}")
            Me.rdWindows.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.NumberConfigurationView.rdWindows}")
            Me.rdBE.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.NumberConfigurationView.rdBE}")
            Me.rdCE.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.NumberConfigurationView.rdCE}")

            Me.grbMinusSign.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.NumberConfigurationView.grbMinusSign}")
            Me.rdMinusSign.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.NumberConfigurationView.rdMinusSign}")
            Me.rdBracket.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.NumberConfigurationView.rdBracket}")

            Me.grbMoneyUnit.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.NumberConfigurationView.grbMoneyUnit}")
            Me.lblBigUnit.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.NumberConfigurationView.lblBigUnit}")
            Me.lblSmallUnit.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.NumberConfigurationView.lblSmallUnit}")
            Me.chkShowCents.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.NumberConfigurationView.chkShowCents}")

            Me.grbJEDate.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.NumberConfigurationView.grbJEDate}")
            Me.chkJEDate.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.NumberConfigurationView.chkJEDate}")
        End Sub
        Protected Sub EventWiring()

            AddHandler txtCost.TextChanged, AddressOf ChangeProperty
            AddHandler txtQty.TextChanged, AddressOf ChangeProperty
            AddHandler txtUnitPrice.TextChanged, AddressOf ChangeProperty
            AddHandler txtPrice.TextChanged, AddressOf ChangeProperty

            AddHandler txtCost.Validated, AddressOf TextHandler
            AddHandler txtQty.Validated, AddressOf TextHandler
            AddHandler txtUnitPrice.Validated, AddressOf TextHandler
            AddHandler txtPrice.Validated, AddressOf TextHandler

            AddHandler rdWindows.CheckedChanged, AddressOf ChangeProperty
            AddHandler rdBE.CheckedChanged, AddressOf ChangeProperty
            AddHandler rdCE.CheckedChanged, AddressOf ChangeProperty

            AddHandler rdBracket.CheckedChanged, AddressOf ChangeProperty
            AddHandler rdMinusSign.CheckedChanged, AddressOf ChangeProperty

            AddHandler txtBigUnit.TextChanged, AddressOf ChangeProperty
            AddHandler txtSmallUnit.TextChanged, AddressOf ChangeProperty

            AddHandler chkJEDate.CheckedChanged, AddressOf ChangeProperty
            AddHandler chkShowCents.CheckedChanged, AddressOf ChangeProperty

        End Sub

        Public Sub TextHandler(ByVal sender As Object, ByVal e As EventArgs)
            Select Case CType(sender, Control).Name.ToLower
                Case "txtcost"
                    Dim txt As String = Me.txtCost.Text
                    Dim val As Integer
                    If txt.Length > 0 AndAlso IsNumeric(txt) Then
                        val = CInt(txt)
                    Else
                        val = 0
                    End If
                    Me.SetFilterValue("CompanyCostDigit", val)
                    txtCost.Text = Configuration.FormatToString(val, DigitConfig.Int)
                Case "txtqty"
                    Dim txt As String = Me.txtQty.Text
                    Dim val As Integer
                    If txt.Length > 0 AndAlso IsNumeric(txt) Then
                        val = CInt(txt)
                    Else
                        val = 0
                    End If
                    Me.SetFilterValue("CompanyQtyDigit", val)
                    txtQty.Text = Configuration.FormatToString(val, DigitConfig.Int)
                Case "txtunitprice"
                    Dim txt As String = Me.txtUnitPrice.Text
                    Dim val As Integer
                    If txt.Length > 0 AndAlso IsNumeric(txt) Then
                        val = CInt(txt)
                    Else
                        val = 0
                    End If
                    Me.SetFilterValue("CompanyUnitPriceDigit", val)
                    txtUnitPrice.Text = Configuration.FormatToString(val, DigitConfig.Int)
                Case "txtprice"
                    Dim txt As String = Me.txtPrice.Text
                    Dim val As Integer
                    If txt.Length > 0 AndAlso IsNumeric(txt) Then
                        val = CInt(txt)
                    Else
                        val = 0
                    End If
                    Me.SetFilterValue("CompanyPriceDigit", val)
                    txtPrice.Text = Configuration.FormatToString(val, DigitConfig.Int)
            End Select
        End Sub
        Public Sub ChangeProperty(ByVal sender As Object, ByVal e As EventArgs)
            If Not m_isInitialized Then
                Return
            End If
            Dim dirtyFlag As Boolean = False
            Select Case CType(sender, Control).Name.ToLower
                Case "txtcost"
                    dirtyFlag = True
                Case "txtqty"
                    dirtyFlag = True
                Case "txtunitprice"
                    dirtyFlag = True
                Case "txtprice"
                    dirtyFlag = True
                Case "txtcost"
                    dirtyFlag = True
                Case "rdbe", "rdce", "rdwindows"
                    If rdWindows.Checked Then
                        SetFilterValue("CompanyEra", 0)
                    ElseIf rdBE.Checked Then
                        SetFilterValue("CompanyEra", 1)
                    Else
                        SetFilterValue("CompanyEra", 2)
                    End If
                    dirtyFlag = True
                Case "rdBracket", "rdminussign"
                    If rdMinusSign.Checked Then
                        SetFilterValue("CompanyMinusSign", 0)
                    Else
                        SetFilterValue("CompanyMinusSign", 1)
                    End If
                    dirtyFlag = True
                Case "chkjedate"
                    Me.SetFilterValue("JEDateComesFromDocDate", chkJEDate.Checked)
                    dirtyFlag = True
                Case "chkshowcents"
                    Me.SetFilterValue("ShowCents", chkShowCents.Checked)
                    dirtyFlag = True
                Case "txtbigunit"
                    Me.SetFilterValue("BigMoney", txtBigUnit.Text)
                    dirtyFlag = True
                Case "txtsmallunit"
                    Me.SetFilterValue("SmallMoney", txtSmallUnit.Text)
                    dirtyFlag = True
            End Select
            Dirty = Dirty Or dirtyFlag
            CheckFormEnable()
        End Sub
        Public Sub SetStatus()

        End Sub
        Public Sub Initialize()
            ConfigFilters(0) = New Filter("CompanyQtyDigit", Configuration.GetConfig("CompanyQtyDigit"))
            ConfigFilters(1) = New Filter("CompanyCostDigit", Configuration.GetConfig("CompanyCostDigit"))
            ConfigFilters(2) = New Filter("CompanyUnitPriceDigit", Configuration.GetConfig("CompanyUnitPriceDigit"))
            ConfigFilters(3) = New Filter("CompanyPriceDigit", Configuration.GetConfig("CompanyPriceDigit"))
            ConfigFilters(4) = New Filter("CompanyMinusSign", Configuration.GetConfig("CompanyMinusSign"))
            ConfigFilters(5) = New Filter("CompanyEra", Configuration.GetConfig("CompanyEra"))
            ConfigFilters(6) = New Filter("JEDateComesFromDocDate", Configuration.GetConfig("JEDateComesFromDocDate"))
            ConfigFilters(7) = New Filter("BigMoney", Configuration.GetConfig("BigMoney"))
            ConfigFilters(8) = New Filter("SmallMoney", Configuration.GetConfig("SmallMoney"))
            ConfigFilters(9) = New Filter("ShowCents", Configuration.GetConfig("ShowCents"))
        End Sub
        Private Sub SetFilterValue(ByVal name As String, ByVal value As Object)
            For Each filter As filter In ConfigFilters
                If filter.Name.ToLower = name.ToLower Then
                    filter.Value = value
                    Exit For
                End If
            Next
        End Sub
        Private Function GetFilterValue(ByVal name As String) As Object
            For Each filter As filter In ConfigFilters
                If filter.Name.ToLower = name.ToLower Then
                    Return filter.Value
                End If
            Next
        End Function
#End Region

#Region "Methods"
#End Region

#Region "Event Handers"
        Private Sub ibtnRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        End Sub
#End Region

#Region "Overrides"
        Public Overloads Overrides Sub LoadPanelContents()
            m_isInitialized = False
            ClearDetail()
            Me.txtCost.Text = Configuration.FormatToString(CDec(GetFilterValue("CompanyCostDigit")), DigitConfig.Int)
            Me.txtQty.Text = Configuration.FormatToString(CDec(GetFilterValue("CompanyQtyDigit")), DigitConfig.Int)
            Me.txtUnitPrice.Text = Configuration.FormatToString(CDec(GetFilterValue("CompanyUnitPriceDigit")), DigitConfig.Int)
            Me.txtPrice.Text = Configuration.FormatToString(CDec(GetFilterValue("CompanyPriceDigit")), DigitConfig.Int)
            Me.txtCost.Text = Configuration.FormatToString(CDec(GetFilterValue("CompanyCostDigit")), DigitConfig.Int)

            Me.txtBigUnit.Text = CStr(GetFilterValue("BigMoney"))
            Me.txtSmallUnit.Text = CStr(GetFilterValue("SmallMoney"))

            Dim era As Integer = CInt(GetFilterValue("CompanyEra"))
            If era = 0 Then
                rdWindows.PerformClick()
            ElseIf era = 1 Then
                rdBE.PerformClick()
            Else
                rdCE.PerformClick()
            End If

            If CInt(GetFilterValue("CompanyMinusSign")) = 0 Then
                Me.rdMinusSign.PerformClick()
            Else
                Me.rdBracket.PerformClick()
            End If

            Me.chkJEDate.Checked = CBool(GetFilterValue("JEDateComesFromDocDate"))
            Me.chkShowCents.Checked = CBool(GetFilterValue("ShowCents"))

            SetStatus()
            SetLabelText()
            CheckFormEnable()
            m_isInitialized = True
        End Sub
        Public Overloads Overrides Function StorePanelContents() As Boolean
            If Not m_isInitialized Then
                Return True
            End If
            If Not Dirty Then
                Return True
            End If
            Configuration.Save(Me.ConfigFilters)
            Return True
        End Function
#End Region

#Region "IValidatable"
        Public ReadOnly Property FormValidator() As components.PJMTextboxValidator Implements IValidatable.FormValidator
            Get
                Return Me.Validator
            End Get
        End Property
#End Region

    End Class
End Namespace