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
    Public Class VatItemPanelView
        Inherits AbstractEntityPanelViewContent
        Implements ISimpleListPanel, IValidatable, IHasTreeTable

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
        Friend WithEvents grbRefDoc As Longkong.Pojjaman.Gui.Components.FixedGroupBox
        Friend WithEvents grbDetail As Longkong.Pojjaman.Gui.Components.FixedGroupBox
        Friend WithEvents txtItemCode As System.Windows.Forms.TextBox
        Friend WithEvents chkIncludeChildren As System.Windows.Forms.CheckBox
        Friend WithEvents btnCCCodeStart As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents txtCCCodeStart As System.Windows.Forms.TextBox
        Friend WithEvents lblCCStart As System.Windows.Forms.Label
        Friend WithEvents btnSuppliEndFind As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents txtSuppliCodeEnd As System.Windows.Forms.TextBox
        Friend WithEvents lblSuppliEnd As System.Windows.Forms.Label
        Friend WithEvents btnSuppliStartFind As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents txtSuppliCodeStart As System.Windows.Forms.TextBox
        Friend WithEvents lblSuppliStart As System.Windows.Forms.Label
        Friend WithEvents txtDocDateEnd As System.Windows.Forms.TextBox
        Friend WithEvents txtDocDateStart As System.Windows.Forms.TextBox
        Friend WithEvents dtpDocDateStart As System.Windows.Forms.DateTimePicker
        Friend WithEvents dtpDocDateEnd As System.Windows.Forms.DateTimePicker
        Friend WithEvents lblDocDateStart As System.Windows.Forms.Label
        Friend WithEvents lblDocDateEnd As System.Windows.Forms.Label
        Friend WithEvents lblDirection As System.Windows.Forms.Label
        Friend WithEvents cmbDirection As System.Windows.Forms.ComboBox
        Friend WithEvents btnSearch As System.Windows.Forms.Button
        Friend WithEvents btnReset As System.Windows.Forms.Button
        Friend WithEvents txtVatGroupEnd As System.Windows.Forms.TextBox
        Friend WithEvents lblVatGroupEnd As System.Windows.Forms.Label
        Friend WithEvents txtVatGroupStart As System.Windows.Forms.TextBox
        Friend WithEvents lblVatGroupStart As System.Windows.Forms.Label
        Friend WithEvents lblItemCode As System.Windows.Forms.Label
        Friend WithEvents txtSubmitalDateEnd As System.Windows.Forms.TextBox
        Friend WithEvents txtSubmitalDateStart As System.Windows.Forms.TextBox
        Friend WithEvents dtpSubmitalDateStart As System.Windows.Forms.DateTimePicker
        Friend WithEvents dtpSubmitalDateEnd As System.Windows.Forms.DateTimePicker
        Friend WithEvents lblSubmitalDateStart As System.Windows.Forms.Label
        Friend WithEvents lblSubmitalDateEnd As System.Windows.Forms.Label
        Friend WithEvents tgItem As Longkong.Pojjaman.Gui.Components.TreeGrid
        Friend WithEvents Validator As Longkong.Pojjaman.Gui.Components.PJMTextboxValidator
        Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
        Friend WithEvents txtTemp As System.Windows.Forms.TextBox
        Friend WithEvents btnVatGroupStartFind As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents btnVatGroupEndFind As Longkong.Pojjaman.Gui.Components.ImageButton
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Me.components = New System.ComponentModel.Container
            Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(VatItemPanelView))
            Me.grbRefDoc = New Longkong.Pojjaman.Gui.Components.FixedGroupBox
            Me.btnSearch = New System.Windows.Forms.Button
            Me.btnReset = New System.Windows.Forms.Button
            Me.grbDetail = New Longkong.Pojjaman.Gui.Components.FixedGroupBox
            Me.txtTemp = New System.Windows.Forms.TextBox
            Me.txtVatGroupEnd = New System.Windows.Forms.TextBox
            Me.lblVatGroupEnd = New System.Windows.Forms.Label
            Me.txtVatGroupStart = New System.Windows.Forms.TextBox
            Me.lblVatGroupStart = New System.Windows.Forms.Label
            Me.txtItemCode = New System.Windows.Forms.TextBox
            Me.lblItemCode = New System.Windows.Forms.Label
            Me.txtSubmitalDateEnd = New System.Windows.Forms.TextBox
            Me.txtSubmitalDateStart = New System.Windows.Forms.TextBox
            Me.dtpSubmitalDateStart = New System.Windows.Forms.DateTimePicker
            Me.dtpSubmitalDateEnd = New System.Windows.Forms.DateTimePicker
            Me.lblSubmitalDateStart = New System.Windows.Forms.Label
            Me.lblSubmitalDateEnd = New System.Windows.Forms.Label
            Me.chkIncludeChildren = New System.Windows.Forms.CheckBox
            Me.btnCCCodeStart = New Longkong.Pojjaman.Gui.Components.ImageButton
            Me.txtCCCodeStart = New System.Windows.Forms.TextBox
            Me.lblCCStart = New System.Windows.Forms.Label
            Me.btnSuppliEndFind = New Longkong.Pojjaman.Gui.Components.ImageButton
            Me.txtSuppliCodeEnd = New System.Windows.Forms.TextBox
            Me.lblSuppliEnd = New System.Windows.Forms.Label
            Me.btnSuppliStartFind = New Longkong.Pojjaman.Gui.Components.ImageButton
            Me.txtSuppliCodeStart = New System.Windows.Forms.TextBox
            Me.lblSuppliStart = New System.Windows.Forms.Label
            Me.txtDocDateEnd = New System.Windows.Forms.TextBox
            Me.txtDocDateStart = New System.Windows.Forms.TextBox
            Me.dtpDocDateStart = New System.Windows.Forms.DateTimePicker
            Me.dtpDocDateEnd = New System.Windows.Forms.DateTimePicker
            Me.lblDocDateStart = New System.Windows.Forms.Label
            Me.lblDocDateEnd = New System.Windows.Forms.Label
            Me.lblDirection = New System.Windows.Forms.Label
            Me.cmbDirection = New System.Windows.Forms.ComboBox
            Me.btnVatGroupStartFind = New Longkong.Pojjaman.Gui.Components.ImageButton
            Me.btnVatGroupEndFind = New Longkong.Pojjaman.Gui.Components.ImageButton
            Me.tgItem = New Longkong.Pojjaman.Gui.Components.TreeGrid
            Me.Validator = New Longkong.Pojjaman.Gui.Components.PJMTextboxValidator(Me.components)
            Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider
            Me.grbRefDoc.SuspendLayout()
            Me.grbDetail.SuspendLayout()
            CType(Me.tgItem, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'grbRefDoc
            '
            Me.grbRefDoc.Controls.Add(Me.btnSearch)
            Me.grbRefDoc.Controls.Add(Me.btnReset)
            Me.grbRefDoc.Controls.Add(Me.grbDetail)
            Me.grbRefDoc.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.grbRefDoc.Location = New System.Drawing.Point(8, 8)
            Me.grbRefDoc.Name = "grbRefDoc"
            Me.grbRefDoc.Size = New System.Drawing.Size(760, 176)
            Me.grbRefDoc.TabIndex = 1
            Me.grbRefDoc.TabStop = False
            Me.grbRefDoc.Text = "ค้นหา"
            '
            'btnSearch
            '
            Me.btnSearch.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.btnSearch.Location = New System.Drawing.Point(677, 144)
            Me.btnSearch.Name = "btnSearch"
            Me.btnSearch.TabIndex = 7
            Me.btnSearch.Text = "Search"
            '
            'btnReset
            '
            Me.btnReset.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.btnReset.Location = New System.Drawing.Point(597, 144)
            Me.btnReset.Name = "btnReset"
            Me.btnReset.TabIndex = 6
            Me.btnReset.Text = "Reset"
            '
            'grbDetail
            '
            Me.grbDetail.Controls.Add(Me.txtTemp)
            Me.grbDetail.Controls.Add(Me.txtVatGroupEnd)
            Me.grbDetail.Controls.Add(Me.lblVatGroupEnd)
            Me.grbDetail.Controls.Add(Me.txtVatGroupStart)
            Me.grbDetail.Controls.Add(Me.lblVatGroupStart)
            Me.grbDetail.Controls.Add(Me.txtItemCode)
            Me.grbDetail.Controls.Add(Me.lblItemCode)
            Me.grbDetail.Controls.Add(Me.txtSubmitalDateEnd)
            Me.grbDetail.Controls.Add(Me.txtSubmitalDateStart)
            Me.grbDetail.Controls.Add(Me.dtpSubmitalDateStart)
            Me.grbDetail.Controls.Add(Me.dtpSubmitalDateEnd)
            Me.grbDetail.Controls.Add(Me.lblSubmitalDateStart)
            Me.grbDetail.Controls.Add(Me.lblSubmitalDateEnd)
            Me.grbDetail.Controls.Add(Me.chkIncludeChildren)
            Me.grbDetail.Controls.Add(Me.btnCCCodeStart)
            Me.grbDetail.Controls.Add(Me.txtCCCodeStart)
            Me.grbDetail.Controls.Add(Me.lblCCStart)
            Me.grbDetail.Controls.Add(Me.btnSuppliEndFind)
            Me.grbDetail.Controls.Add(Me.txtSuppliCodeEnd)
            Me.grbDetail.Controls.Add(Me.lblSuppliEnd)
            Me.grbDetail.Controls.Add(Me.btnSuppliStartFind)
            Me.grbDetail.Controls.Add(Me.txtSuppliCodeStart)
            Me.grbDetail.Controls.Add(Me.lblSuppliStart)
            Me.grbDetail.Controls.Add(Me.txtDocDateEnd)
            Me.grbDetail.Controls.Add(Me.txtDocDateStart)
            Me.grbDetail.Controls.Add(Me.dtpDocDateStart)
            Me.grbDetail.Controls.Add(Me.dtpDocDateEnd)
            Me.grbDetail.Controls.Add(Me.lblDocDateStart)
            Me.grbDetail.Controls.Add(Me.lblDocDateEnd)
            Me.grbDetail.Controls.Add(Me.lblDirection)
            Me.grbDetail.Controls.Add(Me.cmbDirection)
            Me.grbDetail.Controls.Add(Me.btnVatGroupStartFind)
            Me.grbDetail.Controls.Add(Me.btnVatGroupEndFind)
            Me.grbDetail.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.grbDetail.Location = New System.Drawing.Point(8, 16)
            Me.grbDetail.Name = "grbDetail"
            Me.grbDetail.Size = New System.Drawing.Size(744, 124)
            Me.grbDetail.TabIndex = 3
            Me.grbDetail.TabStop = False
            Me.grbDetail.Text = "ข้อมูลทั่วไป"
            '
            'txtTemp
            '
            Me.Validator.SetDataType(Me.txtTemp, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtTemp, "")
            Me.Validator.SetGotFocusBackColor(Me.txtTemp, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtTemp, System.Drawing.Color.Empty)
            Me.txtTemp.Location = New System.Drawing.Point(768, 52)
            Me.txtTemp.MaxLength = 255
            Me.Validator.SetMaxValue(Me.txtTemp, "")
            Me.Validator.SetMinValue(Me.txtTemp, "")
            Me.txtTemp.Name = "txtTemp"
            Me.txtTemp.ReadOnly = True
            Me.Validator.SetRegularExpression(Me.txtTemp, "")
            Me.Validator.SetRequired(Me.txtTemp, False)
            Me.txtTemp.Size = New System.Drawing.Size(104, 20)
            Me.txtTemp.TabIndex = 78
            Me.txtTemp.Text = ""
            Me.txtTemp.Visible = False
            '
            'txtVatGroupEnd
            '
            Me.Validator.SetDataType(Me.txtVatGroupEnd, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtVatGroupEnd, "")
            Me.Validator.SetGotFocusBackColor(Me.txtVatGroupEnd, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtVatGroupEnd, System.Drawing.Color.Empty)
            Me.txtVatGroupEnd.Location = New System.Drawing.Point(256, 64)
            Me.Validator.SetMaxValue(Me.txtVatGroupEnd, "")
            Me.Validator.SetMinValue(Me.txtVatGroupEnd, "")
            Me.txtVatGroupEnd.Name = "txtVatGroupEnd"
            Me.Validator.SetRegularExpression(Me.txtVatGroupEnd, "")
            Me.Validator.SetRequired(Me.txtVatGroupEnd, False)
            Me.txtVatGroupEnd.Size = New System.Drawing.Size(96, 20)
            Me.txtVatGroupEnd.TabIndex = 6
            Me.txtVatGroupEnd.Text = ""
            '
            'lblVatGroupEnd
            '
            Me.lblVatGroupEnd.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblVatGroupEnd.ForeColor = System.Drawing.Color.Black
            Me.lblVatGroupEnd.Location = New System.Drawing.Point(227, 64)
            Me.lblVatGroupEnd.Name = "lblVatGroupEnd"
            Me.lblVatGroupEnd.Size = New System.Drawing.Size(24, 18)
            Me.lblVatGroupEnd.TabIndex = 76
            Me.lblVatGroupEnd.Text = "ถึง"
            Me.lblVatGroupEnd.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtVatGroupStart
            '
            Me.Validator.SetDataType(Me.txtVatGroupStart, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtVatGroupStart, "")
            Me.Validator.SetGotFocusBackColor(Me.txtVatGroupStart, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtVatGroupStart, System.Drawing.Color.Empty)
            Me.txtVatGroupStart.Location = New System.Drawing.Point(104, 64)
            Me.Validator.SetMaxValue(Me.txtVatGroupStart, "")
            Me.Validator.SetMinValue(Me.txtVatGroupStart, "")
            Me.txtVatGroupStart.Name = "txtVatGroupStart"
            Me.Validator.SetRegularExpression(Me.txtVatGroupStart, "")
            Me.Validator.SetRequired(Me.txtVatGroupStart, False)
            Me.txtVatGroupStart.Size = New System.Drawing.Size(96, 20)
            Me.txtVatGroupStart.TabIndex = 5
            Me.txtVatGroupStart.Text = ""
            '
            'lblVatGroupStart
            '
            Me.lblVatGroupStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblVatGroupStart.ForeColor = System.Drawing.Color.Black
            Me.lblVatGroupStart.Location = New System.Drawing.Point(8, 64)
            Me.lblVatGroupStart.Name = "lblVatGroupStart"
            Me.lblVatGroupStart.Size = New System.Drawing.Size(96, 18)
            Me.lblVatGroupStart.TabIndex = 74
            Me.lblVatGroupStart.Text = "กลุ่มภาษี:"
            Me.lblVatGroupStart.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtItemCode
            '
            Me.Validator.SetDataType(Me.txtItemCode, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtItemCode, "")
            Me.Validator.SetGotFocusBackColor(Me.txtItemCode, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtItemCode, System.Drawing.Color.Empty)
            Me.txtItemCode.Location = New System.Drawing.Point(104, 88)
            Me.Validator.SetMaxValue(Me.txtItemCode, "")
            Me.Validator.SetMinValue(Me.txtItemCode, "")
            Me.txtItemCode.Name = "txtItemCode"
            Me.Validator.SetRegularExpression(Me.txtItemCode, "")
            Me.Validator.SetRequired(Me.txtItemCode, False)
            Me.txtItemCode.Size = New System.Drawing.Size(120, 20)
            Me.txtItemCode.TabIndex = 9
            Me.txtItemCode.Text = ""
            '
            'lblItemCode
            '
            Me.lblItemCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblItemCode.ForeColor = System.Drawing.Color.Black
            Me.lblItemCode.Location = New System.Drawing.Point(8, 88)
            Me.lblItemCode.Name = "lblItemCode"
            Me.lblItemCode.Size = New System.Drawing.Size(96, 18)
            Me.lblItemCode.TabIndex = 72
            Me.lblItemCode.Text = "Tax Invoce No.:"
            Me.lblItemCode.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtSubmitalDateEnd
            '
            Me.Validator.SetDataType(Me.txtSubmitalDateEnd, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtSubmitalDateEnd, "")
            Me.Validator.SetGotFocusBackColor(Me.txtSubmitalDateEnd, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtSubmitalDateEnd, System.Drawing.Color.Empty)
            Me.txtSubmitalDateEnd.Location = New System.Drawing.Point(616, 40)
            Me.txtSubmitalDateEnd.MaxLength = 10
            Me.Validator.SetMaxValue(Me.txtSubmitalDateEnd, "")
            Me.Validator.SetMinValue(Me.txtSubmitalDateEnd, "")
            Me.txtSubmitalDateEnd.Name = "txtSubmitalDateEnd"
            Me.Validator.SetRegularExpression(Me.txtSubmitalDateEnd, "")
            Me.Validator.SetRequired(Me.txtSubmitalDateEnd, False)
            Me.txtSubmitalDateEnd.Size = New System.Drawing.Size(99, 20)
            Me.txtSubmitalDateEnd.TabIndex = 4
            Me.txtSubmitalDateEnd.Text = ""
            '
            'txtSubmitalDateStart
            '
            Me.Validator.SetDataType(Me.txtSubmitalDateStart, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtSubmitalDateStart, "")
            Me.Validator.SetGotFocusBackColor(Me.txtSubmitalDateStart, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtSubmitalDateStart, System.Drawing.Color.Empty)
            Me.txtSubmitalDateStart.Location = New System.Drawing.Point(464, 40)
            Me.txtSubmitalDateStart.MaxLength = 10
            Me.Validator.SetMaxValue(Me.txtSubmitalDateStart, "")
            Me.Validator.SetMinValue(Me.txtSubmitalDateStart, "")
            Me.txtSubmitalDateStart.Name = "txtSubmitalDateStart"
            Me.Validator.SetRegularExpression(Me.txtSubmitalDateStart, "")
            Me.Validator.SetRequired(Me.txtSubmitalDateStart, False)
            Me.txtSubmitalDateStart.Size = New System.Drawing.Size(109, 20)
            Me.txtSubmitalDateStart.TabIndex = 3
            Me.txtSubmitalDateStart.Text = ""
            '
            'dtpSubmitalDateStart
            '
            Me.dtpSubmitalDateStart.Format = System.Windows.Forms.DateTimePickerFormat.Short
            Me.dtpSubmitalDateStart.Location = New System.Drawing.Point(464, 40)
            Me.dtpSubmitalDateStart.Name = "dtpSubmitalDateStart"
            Me.dtpSubmitalDateStart.Size = New System.Drawing.Size(128, 20)
            Me.dtpSubmitalDateStart.TabIndex = 68
            Me.dtpSubmitalDateStart.TabStop = False
            '
            'dtpSubmitalDateEnd
            '
            Me.dtpSubmitalDateEnd.Format = System.Windows.Forms.DateTimePickerFormat.Short
            Me.dtpSubmitalDateEnd.Location = New System.Drawing.Point(616, 40)
            Me.dtpSubmitalDateEnd.Name = "dtpSubmitalDateEnd"
            Me.dtpSubmitalDateEnd.Size = New System.Drawing.Size(120, 20)
            Me.dtpSubmitalDateEnd.TabIndex = 71
            Me.dtpSubmitalDateEnd.TabStop = False
            '
            'lblSubmitalDateStart
            '
            Me.lblSubmitalDateStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblSubmitalDateStart.ForeColor = System.Drawing.Color.Black
            Me.lblSubmitalDateStart.Location = New System.Drawing.Point(384, 38)
            Me.lblSubmitalDateStart.Name = "lblSubmitalDateStart"
            Me.lblSubmitalDateStart.Size = New System.Drawing.Size(80, 24)
            Me.lblSubmitalDateStart.TabIndex = 66
            Me.lblSubmitalDateStart.Text = "Submital Date:"
            Me.lblSubmitalDateStart.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblSubmitalDateEnd
            '
            Me.lblSubmitalDateEnd.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblSubmitalDateEnd.ForeColor = System.Drawing.Color.Black
            Me.lblSubmitalDateEnd.Location = New System.Drawing.Point(592, 40)
            Me.lblSubmitalDateEnd.Name = "lblSubmitalDateEnd"
            Me.lblSubmitalDateEnd.Size = New System.Drawing.Size(22, 18)
            Me.lblSubmitalDateEnd.TabIndex = 69
            Me.lblSubmitalDateEnd.Text = "ถึง"
            Me.lblSubmitalDateEnd.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'chkIncludeChildren
            '
            Me.chkIncludeChildren.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.chkIncludeChildren.Location = New System.Drawing.Point(616, 88)
            Me.chkIncludeChildren.Name = "chkIncludeChildren"
            Me.chkIncludeChildren.Size = New System.Drawing.Size(120, 24)
            Me.chkIncludeChildren.TabIndex = 11
            Me.chkIncludeChildren.Text = "รวม Cost Center ลูก"
            '
            'btnCCCodeStart
            '
            Me.btnCCCodeStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.btnCCCodeStart.ForeColor = System.Drawing.SystemColors.Control
            Me.btnCCCodeStart.Image = CType(resources.GetObject("btnCCCodeStart.Image"), System.Drawing.Image)
            Me.btnCCCodeStart.Location = New System.Drawing.Point(568, 88)
            Me.btnCCCodeStart.Name = "btnCCCodeStart"
            Me.btnCCCodeStart.Size = New System.Drawing.Size(24, 22)
            Me.btnCCCodeStart.TabIndex = 64
            Me.btnCCCodeStart.TabStop = False
            Me.btnCCCodeStart.ThemedImage = CType(resources.GetObject("btnCCCodeStart.ThemedImage"), System.Drawing.Bitmap)
            '
            'txtCCCodeStart
            '
            Me.Validator.SetDataType(Me.txtCCCodeStart, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtCCCodeStart, "")
            Me.txtCCCodeStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtCCCodeStart, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtCCCodeStart, System.Drawing.Color.Empty)
            Me.txtCCCodeStart.Location = New System.Drawing.Point(464, 88)
            Me.txtCCCodeStart.MaxLength = 50
            Me.Validator.SetMaxValue(Me.txtCCCodeStart, "")
            Me.Validator.SetMinValue(Me.txtCCCodeStart, "")
            Me.txtCCCodeStart.Name = "txtCCCodeStart"
            Me.Validator.SetRegularExpression(Me.txtCCCodeStart, "")
            Me.Validator.SetRequired(Me.txtCCCodeStart, False)
            Me.txtCCCodeStart.Size = New System.Drawing.Size(104, 21)
            Me.txtCCCodeStart.TabIndex = 10
            Me.txtCCCodeStart.Text = ""
            '
            'lblCCStart
            '
            Me.lblCCStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblCCStart.ForeColor = System.Drawing.Color.Black
            Me.lblCCStart.Location = New System.Drawing.Point(376, 89)
            Me.lblCCStart.Name = "lblCCStart"
            Me.lblCCStart.Size = New System.Drawing.Size(88, 18)
            Me.lblCCStart.TabIndex = 62
            Me.lblCCStart.Text = "Cost Center:"
            Me.lblCCStart.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'btnSuppliEndFind
            '
            Me.btnSuppliEndFind.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.btnSuppliEndFind.ForeColor = System.Drawing.SystemColors.Control
            Me.btnSuppliEndFind.Image = CType(resources.GetObject("btnSuppliEndFind.Image"), System.Drawing.Image)
            Me.btnSuppliEndFind.Location = New System.Drawing.Point(712, 64)
            Me.btnSuppliEndFind.Name = "btnSuppliEndFind"
            Me.btnSuppliEndFind.Size = New System.Drawing.Size(24, 22)
            Me.btnSuppliEndFind.TabIndex = 61
            Me.btnSuppliEndFind.TabStop = False
            Me.btnSuppliEndFind.ThemedImage = CType(resources.GetObject("btnSuppliEndFind.ThemedImage"), System.Drawing.Bitmap)
            '
            'txtSuppliCodeEnd
            '
            Me.Validator.SetDataType(Me.txtSuppliCodeEnd, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtSuppliCodeEnd, "")
            Me.txtSuppliCodeEnd.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtSuppliCodeEnd, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtSuppliCodeEnd, System.Drawing.Color.Empty)
            Me.txtSuppliCodeEnd.Location = New System.Drawing.Point(616, 64)
            Me.Validator.SetMaxValue(Me.txtSuppliCodeEnd, "")
            Me.Validator.SetMinValue(Me.txtSuppliCodeEnd, "")
            Me.txtSuppliCodeEnd.Name = "txtSuppliCodeEnd"
            Me.Validator.SetRegularExpression(Me.txtSuppliCodeEnd, "")
            Me.Validator.SetRequired(Me.txtSuppliCodeEnd, False)
            Me.txtSuppliCodeEnd.Size = New System.Drawing.Size(96, 21)
            Me.txtSuppliCodeEnd.TabIndex = 8
            Me.txtSuppliCodeEnd.Text = ""
            '
            'lblSuppliEnd
            '
            Me.lblSuppliEnd.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblSuppliEnd.ForeColor = System.Drawing.Color.Black
            Me.lblSuppliEnd.Location = New System.Drawing.Point(592, 64)
            Me.lblSuppliEnd.Name = "lblSuppliEnd"
            Me.lblSuppliEnd.Size = New System.Drawing.Size(24, 18)
            Me.lblSuppliEnd.TabIndex = 59
            Me.lblSuppliEnd.Text = "ถึง"
            Me.lblSuppliEnd.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'btnSuppliStartFind
            '
            Me.btnSuppliStartFind.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.btnSuppliStartFind.ForeColor = System.Drawing.SystemColors.Control
            Me.btnSuppliStartFind.Image = CType(resources.GetObject("btnSuppliStartFind.Image"), System.Drawing.Image)
            Me.btnSuppliStartFind.Location = New System.Drawing.Point(568, 64)
            Me.btnSuppliStartFind.Name = "btnSuppliStartFind"
            Me.btnSuppliStartFind.Size = New System.Drawing.Size(24, 22)
            Me.btnSuppliStartFind.TabIndex = 58
            Me.btnSuppliStartFind.TabStop = False
            Me.btnSuppliStartFind.ThemedImage = CType(resources.GetObject("btnSuppliStartFind.ThemedImage"), System.Drawing.Bitmap)
            '
            'txtSuppliCodeStart
            '
            Me.Validator.SetDataType(Me.txtSuppliCodeStart, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtSuppliCodeStart, "")
            Me.txtSuppliCodeStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtSuppliCodeStart, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtSuppliCodeStart, System.Drawing.Color.Empty)
            Me.txtSuppliCodeStart.Location = New System.Drawing.Point(464, 64)
            Me.Validator.SetMaxValue(Me.txtSuppliCodeStart, "")
            Me.Validator.SetMinValue(Me.txtSuppliCodeStart, "")
            Me.txtSuppliCodeStart.Name = "txtSuppliCodeStart"
            Me.Validator.SetRegularExpression(Me.txtSuppliCodeStart, "")
            Me.Validator.SetRequired(Me.txtSuppliCodeStart, False)
            Me.txtSuppliCodeStart.Size = New System.Drawing.Size(104, 21)
            Me.txtSuppliCodeStart.TabIndex = 7
            Me.txtSuppliCodeStart.Text = ""
            '
            'lblSuppliStart
            '
            Me.lblSuppliStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblSuppliStart.ForeColor = System.Drawing.Color.Black
            Me.lblSuppliStart.Location = New System.Drawing.Point(376, 62)
            Me.lblSuppliStart.Name = "lblSuppliStart"
            Me.lblSuppliStart.Size = New System.Drawing.Size(88, 24)
            Me.lblSuppliStart.TabIndex = 56
            Me.lblSuppliStart.Text = "Supplier/Customer:"
            Me.lblSuppliStart.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtDocDateEnd
            '
            Me.Validator.SetDataType(Me.txtDocDateEnd, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtDocDateEnd, "")
            Me.Validator.SetGotFocusBackColor(Me.txtDocDateEnd, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtDocDateEnd, System.Drawing.Color.Empty)
            Me.txtDocDateEnd.Location = New System.Drawing.Point(256, 40)
            Me.txtDocDateEnd.MaxLength = 10
            Me.Validator.SetMaxValue(Me.txtDocDateEnd, "")
            Me.Validator.SetMinValue(Me.txtDocDateEnd, "")
            Me.txtDocDateEnd.Name = "txtDocDateEnd"
            Me.Validator.SetRegularExpression(Me.txtDocDateEnd, "")
            Me.Validator.SetRequired(Me.txtDocDateEnd, False)
            Me.txtDocDateEnd.TabIndex = 2
            Me.txtDocDateEnd.Text = ""
            '
            'txtDocDateStart
            '
            Me.Validator.SetDataType(Me.txtDocDateStart, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtDocDateStart, "")
            Me.Validator.SetGotFocusBackColor(Me.txtDocDateStart, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtDocDateStart, System.Drawing.Color.Empty)
            Me.txtDocDateStart.Location = New System.Drawing.Point(104, 40)
            Me.txtDocDateStart.MaxLength = 10
            Me.Validator.SetMaxValue(Me.txtDocDateStart, "")
            Me.Validator.SetMinValue(Me.txtDocDateStart, "")
            Me.txtDocDateStart.Name = "txtDocDateStart"
            Me.Validator.SetRegularExpression(Me.txtDocDateStart, "")
            Me.Validator.SetRequired(Me.txtDocDateStart, False)
            Me.txtDocDateStart.Size = New System.Drawing.Size(101, 20)
            Me.txtDocDateStart.TabIndex = 1
            Me.txtDocDateStart.Text = ""
            '
            'dtpDocDateStart
            '
            Me.dtpDocDateStart.Format = System.Windows.Forms.DateTimePickerFormat.Short
            Me.dtpDocDateStart.Location = New System.Drawing.Point(104, 40)
            Me.dtpDocDateStart.Name = "dtpDocDateStart"
            Me.dtpDocDateStart.Size = New System.Drawing.Size(120, 20)
            Me.dtpDocDateStart.TabIndex = 52
            Me.dtpDocDateStart.TabStop = False
            '
            'dtpDocDateEnd
            '
            Me.dtpDocDateEnd.Format = System.Windows.Forms.DateTimePickerFormat.Short
            Me.dtpDocDateEnd.Location = New System.Drawing.Point(256, 40)
            Me.dtpDocDateEnd.Name = "dtpDocDateEnd"
            Me.dtpDocDateEnd.Size = New System.Drawing.Size(120, 20)
            Me.dtpDocDateEnd.TabIndex = 55
            Me.dtpDocDateEnd.TabStop = False
            '
            'lblDocDateStart
            '
            Me.lblDocDateStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblDocDateStart.ForeColor = System.Drawing.Color.Black
            Me.lblDocDateStart.Location = New System.Drawing.Point(8, 38)
            Me.lblDocDateStart.Name = "lblDocDateStart"
            Me.lblDocDateStart.Size = New System.Drawing.Size(96, 24)
            Me.lblDocDateStart.TabIndex = 50
            Me.lblDocDateStart.Text = "VAT Document Date:"
            Me.lblDocDateStart.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblDocDateEnd
            '
            Me.lblDocDateEnd.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblDocDateEnd.ForeColor = System.Drawing.Color.Black
            Me.lblDocDateEnd.Location = New System.Drawing.Point(232, 40)
            Me.lblDocDateEnd.Name = "lblDocDateEnd"
            Me.lblDocDateEnd.Size = New System.Drawing.Size(22, 18)
            Me.lblDocDateEnd.TabIndex = 53
            Me.lblDocDateEnd.Text = "ถึง"
            Me.lblDocDateEnd.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'lblDirection
            '
            Me.lblDirection.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblDirection.ForeColor = System.Drawing.Color.Black
            Me.lblDirection.Location = New System.Drawing.Point(8, 16)
            Me.lblDirection.Name = "lblDirection"
            Me.lblDirection.Size = New System.Drawing.Size(96, 18)
            Me.lblDirection.TabIndex = 48
            Me.lblDirection.Text = "ประเภทภาษี:"
            Me.lblDirection.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'cmbDirection
            '
            Me.cmbDirection.BackColor = System.Drawing.SystemColors.Window
            Me.cmbDirection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cmbDirection.Location = New System.Drawing.Point(104, 16)
            Me.cmbDirection.Name = "cmbDirection"
            Me.cmbDirection.Size = New System.Drawing.Size(120, 21)
            Me.cmbDirection.TabIndex = 0
            Me.cmbDirection.TabStop = False
            '
            'btnVatGroupStartFind
            '
            Me.btnVatGroupStartFind.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.btnVatGroupStartFind.ForeColor = System.Drawing.SystemColors.Control
            Me.btnVatGroupStartFind.Image = CType(resources.GetObject("btnVatGroupStartFind.Image"), System.Drawing.Image)
            Me.btnVatGroupStartFind.Location = New System.Drawing.Point(200, 63)
            Me.btnVatGroupStartFind.Name = "btnVatGroupStartFind"
            Me.btnVatGroupStartFind.Size = New System.Drawing.Size(24, 22)
            Me.btnVatGroupStartFind.TabIndex = 58
            Me.btnVatGroupStartFind.TabStop = False
            Me.btnVatGroupStartFind.ThemedImage = CType(resources.GetObject("btnVatGroupStartFind.ThemedImage"), System.Drawing.Bitmap)
            '
            'btnVatGroupEndFind
            '
            Me.btnVatGroupEndFind.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.btnVatGroupEndFind.ForeColor = System.Drawing.SystemColors.Control
            Me.btnVatGroupEndFind.Image = CType(resources.GetObject("btnVatGroupEndFind.Image"), System.Drawing.Image)
            Me.btnVatGroupEndFind.Location = New System.Drawing.Point(352, 63)
            Me.btnVatGroupEndFind.Name = "btnVatGroupEndFind"
            Me.btnVatGroupEndFind.Size = New System.Drawing.Size(24, 22)
            Me.btnVatGroupEndFind.TabIndex = 61
            Me.btnVatGroupEndFind.TabStop = False
            Me.btnVatGroupEndFind.ThemedImage = CType(resources.GetObject("btnVatGroupEndFind.ThemedImage"), System.Drawing.Bitmap)
            '
            'tgItem
            '
            Me.tgItem.AllowDrop = True
            Me.tgItem.AllowNew = False
            Me.tgItem.AllowSorting = False
            Me.tgItem.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.tgItem.AutoColumnResize = True
            Me.tgItem.CaptionVisible = False
            Me.tgItem.Cellchanged = False
            Me.tgItem.ColorList.AddRange(New System.Drawing.Color() {System.Drawing.Color.FromArgb(CType(255, Byte), CType(128, Byte), CType(0, Byte)), System.Drawing.Color.FromArgb(CType(255, Byte), CType(255, Byte), CType(128, Byte))})
            Me.tgItem.DataMember = ""
            Me.tgItem.HeaderBackColor = System.Drawing.Color.Khaki
            Me.tgItem.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.tgItem.HeaderForeColor = System.Drawing.SystemColors.ControlText
            Me.tgItem.Location = New System.Drawing.Point(8, 200)
            Me.tgItem.Name = "tgItem"
            Me.tgItem.Size = New System.Drawing.Size(760, 304)
            Me.tgItem.SortingArrowColor = System.Drawing.Color.Red
            Me.tgItem.TabIndex = 7
            Me.tgItem.TreeManager = Nothing
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
            'VatItemPanelView
            '
            Me.Controls.Add(Me.tgItem)
            Me.Controls.Add(Me.grbRefDoc)
            Me.Name = "VatItemPanelView"
            Me.Size = New System.Drawing.Size(776, 512)
            Me.grbRefDoc.ResumeLayout(False)
            Me.grbDetail.ResumeLayout(False)
            CType(Me.tgItem, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub

#End Region

#Region "Members"
        Private m_entity As Vat
        Private m_treeManager As TreeManager
        Private m_supplierstart As Supplier
        Private m_supplierend As Supplier
        Private m_DocDateEnd As Date
        Private m_DocDateStart As Date
        Private m_SubmitalDateEnd As Date
        Private m_SubmitalDateStart As Date
        Private m_cc As CostCenter
        Private m_vatgroupstart As VatGroup
        Private m_vatgroupend As VatGroup

        Private m_tableInitialized As Boolean
#End Region

#Region "Constructors"
        Public Sub New(ByVal entity As ISimpleEntity, ByVal handler As Object, ByVal basket As BasketDialog, ByVal filters As Filter(), ByVal entities As ArrayList)
            MyBase.New()
            Me.InitializeComponent()
            Me.SetLabelText()
            Initialize()
            EventWiring()
            m_entity = New Vat

            Dim dt As TreeTable = VatItem.GetSchemaTable()
            Dim dst As DataGridTableStyle = Me.CreateTableStyle()
            m_treeManager = New TreeManager(dt, tgItem)
            m_treeManager.SetTableStyle(dst)
            m_treeManager.AllowSorting = False
            m_treeManager.AllowDelete = False
            tgItem.AllowNew = False

            Me.TitleName = m_entity.TabPageText
        End Sub
#End Region

#Region "Style"
        Public Function CreateTableStyle() As DataGridTableStyle
            Dim dst As New DataGridTableStyle
            dst.MappingName = "VatItem"
            Dim myStringParserService As StringParserService = CType(ServiceManager.Services.GetService(GetType(StringParserService)), StringParserService)

            Dim csCode As New TreeTextColumn
            csCode.MappingName = "Code"
            csCode.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.VatItemPanelView.CodeHeaderText}")
            csCode.NullText = ""
            csCode.Width = 150
            csCode.DataAlignment = HorizontalAlignment.Left
            csCode.ReadOnly = True

            Dim csRefDocCode As New TreeTextColumn
            csRefDocCode.MappingName = "RefDocCode"
            csRefDocCode.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.VatItemPanelView.RefDocCodeHeaderText}")
            csRefDocCode.NullText = ""
            csRefDocCode.Width = 150
            csRefDocCode.DataAlignment = HorizontalAlignment.Left
            csRefDocCode.ReadOnly = True

            Dim csDocDate As New TreeTextColumn
            csDocDate.MappingName = "DocDate"
            csDocDate.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.VatItemPanelView.DocDateHeaderText}")
            csDocDate.NullText = ""
            csDocDate.Width = 120
            csDocDate.DataAlignment = HorizontalAlignment.Center
            csDocDate.ReadOnly = True

            Dim csSupplierName As New TreeTextColumn
            csSupplierName.MappingName = "SupplierName"
            csSupplierName.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.VatItemPanelView.SuppliernameHeaderText}")
            csSupplierName.NullText = ""
            csSupplierName.Width = 180
            csSupplierName.DataAlignment = HorizontalAlignment.Left
            csSupplierName.ReadOnly = True

            Dim csTaxBase As New TreeTextColumn
            csTaxBase.MappingName = "TaxBase"
            csTaxBase.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.VatItemPanelView.TaxBaseHeaderText}")
            csTaxBase.NullText = ""
            csTaxBase.Width = 150
            csTaxBase.DataAlignment = HorizontalAlignment.Right
            csTaxBase.ReadOnly = True

            Dim csTaxRate As New TreeTextColumn
            csTaxRate.MappingName = "TaxRate"
            csTaxRate.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.VatItemPanelView.TaxRateHeaderText}")
            csTaxRate.NullText = ""
            csTaxRate.Width = 120
            csTaxRate.DataAlignment = HorizontalAlignment.Right
            csTaxRate.ReadOnly = True

            Dim csTaxAmount As New TreeTextColumn
            csTaxAmount.MappingName = "TaxAmount"
            csTaxAmount.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.VatItemPanelView.TaxAmountHeaderText}")
            csTaxAmount.NullText = ""
            csTaxAmount.Width = 150
            csTaxAmount.DataAlignment = HorizontalAlignment.Right
            csTaxAmount.ReadOnly = True

            Dim csVatGroupCode As New TreeTextColumn
            csVatGroupCode.MappingName = "VatGroupCode"
            csVatGroupCode.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.VatItemPanelView.VatGroupCodeHeaderText}")
            csVatGroupCode.NullText = ""
            csVatGroupCode.Width = 150
            csVatGroupCode.DataAlignment = HorizontalAlignment.Left
            'csVatGroupCode.ReadOnly = True

            Dim csVatGroupButton As New DataGridButtonColumn
            csVatGroupButton.MappingName = "VatGroupButton"
            csVatGroupButton.HeaderText = ""
            csVatGroupButton.NullText = ""
            AddHandler csVatGroupButton.Click, AddressOf VatGroupButtonClicked

            Dim csVatGroupName As New TreeTextColumn
            csVatGroupName.MappingName = "VatGroupName"
            csVatGroupName.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.VatItemPanelView.VatGroupNameHeaderText}")
            csVatGroupName.NullText = ""
            csVatGroupName.Width = 180
            csVatGroupName.DataAlignment = HorizontalAlignment.Left
            csVatGroupName.ReadOnly = True

            Dim csSubmitalDate As New DataGridTimePickerColumn
            csSubmitalDate.MappingName = "SubmitalDate"
            csSubmitalDate.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.VatItemPanelView.SubmitalDateHeaderText}")
            csSubmitalDate.NullText = ""
            csSubmitalDate.Width = 120

            dst.GridColumnStyles.Add(csCode)
            dst.GridColumnStyles.Add(csRefDocCode)
            dst.GridColumnStyles.Add(csDocDate)
            dst.GridColumnStyles.Add(csSupplierName)
            dst.GridColumnStyles.Add(csTaxBase)
            dst.GridColumnStyles.Add(csTaxRate)
            dst.GridColumnStyles.Add(csTaxAmount)
            dst.GridColumnStyles.Add(csVatGroupCode)
            dst.GridColumnStyles.Add(csVatGroupButton)
            dst.GridColumnStyles.Add(csVatGroupName)
            dst.GridColumnStyles.Add(csSubmitalDate)

            Return dst
        End Function
#End Region

#Region "TreeTable Handlers"
        Private Sub Treetable_ColumnChanged(ByVal sender As Object, ByVal e As System.Data.DataColumnChangeEventArgs)
            Me.m_treeManager.Treetable.AcceptChanges()
            If Not Me.m_tableInitialized Then
                Return
            End If
            Dim index As Integer = Me.m_treeManager.Treetable.Childs.IndexOf(CType(e.Row, TreeRow))
            If ValidateRow(CType(e.Row, TreeRow)) Then
                Dim pe As New PropertyChangedEventArgs
            End If
            Me.m_treeManager.Treetable.AcceptChanges()
            Me.IsDirty = True
        End Sub
        Private Sub Treetable_ColumnChanging(ByVal sender As Object, ByVal e As System.Data.DataColumnChangeEventArgs)
            If Not Me.m_tableInitialized Then
                Return
            End If
            Try
                Select Case e.Column.ColumnName.ToLower
                    Case "vatgroupcode"
                        SetCode(e)
                    Case "submitaldate"
                        SetDate(e)
                End Select
                ValidateRow(e)
            Catch ex As Exception
                MessageBox.Show(ex.ToString)
            End Try
        End Sub
        Public Sub ValidateRow(ByVal e As DataColumnChangeEventArgs)

        End Sub
        Public Function ValidateRow(ByVal row As TreeRow) As Boolean
            Return True
        End Function
        Private m_updating As Boolean = False
        Public Sub SetCode(ByVal e As System.Data.DataColumnChangeEventArgs)
            If m_updating Then
                Return
            End If
            m_updating = True
            Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
            'Expose new object by Code as string
            Dim myGroup As New VatGroup(e.ProposedValue.ToString)
            If Not myGroup Is Nothing AndAlso myGroup.Originated Then
                e.Row("vati_group") = myGroup.Id
                e.ProposedValue = myGroup.Code
                e.Row("VatGroupName") = myGroup.Name
            Else
                If e.ProposedValue.ToString.Length = 0 Then
                    e.Row("vati_group") = DBNull.Value
                    e.ProposedValue = DBNull.Value
                    e.Row("VatGroupName") = DBNull.Value
                Else
                    msgServ.ShowMessage("${res:Global.Error.InvalidVatg}")
                    e.ProposedValue = e.Row(e.Column)
                End If
            End If
            m_updating = False
        End Sub
        Public Sub SetDate(ByVal e As System.Data.DataColumnChangeEventArgs)
            If m_updating Then
                Return
            End If
            m_updating = True

            m_updating = False
        End Sub
        Private Sub ItemDelete(ByVal sender As Object, ByVal e As System.Data.DataRowChangeEventArgs)
            'Dim row As DataRow = e.Row
            'Me.m_treeManager.Treetable.Childs.Remove(CType(row, TreeRow))
            'Try
            '    If Not Me.m_isInitialized Then
            '        Return
            '    End If

            '    Dim index As TreeRow = CType(e.Row, TreeRow)
            '    Me.m_treeManager.Treetable.Childs.Remove(index)
            'Catch ex As Exception
            '    MessageBox.Show(ex.ToString)
            'End Try
        End Sub
#End Region

#Region "Properties"
        Public Property SupplierStart() As Supplier
            Get
                Return m_supplierstart
            End Get
            Set(ByVal Value As Supplier)
                m_supplierstart = Value
            End Set
        End Property
        Public Property SupplierEnd() As Supplier
            Get
                Return m_supplierend
            End Get
            Set(ByVal Value As Supplier)
                m_supplierend = Value
            End Set
        End Property
        Public Property DocDateEnd() As Date            Get                Return m_DocDateEnd            End Get            Set(ByVal Value As Date)                m_DocDateEnd = Value            End Set        End Property        Public Property DocDateStart() As Date            Get                Return m_DocDateStart            End Get            Set(ByVal Value As Date)                m_DocDateStart = Value            End Set        End Property
        Public Property SubmitalDateEnd() As Date            Get                Return m_SubmitalDateEnd            End Get            Set(ByVal Value As Date)                m_SubmitalDateEnd = Value            End Set        End Property        Public Property SubmitalDateStart() As Date            Get                Return m_SubmitalDateStart            End Get            Set(ByVal Value As Date)                m_SubmitalDateStart = Value            End Set        End Property
        Public Property CostCenter() As CostCenter
            Get
                Return m_cc
            End Get
            Set(ByVal Value As CostCenter)
                m_cc = Value
            End Set
        End Property
        Public Property VatGroupStart() As VatGroup
            Get
                Return m_vatgroupstart
            End Get
            Set(ByVal Value As VatGroup)
                m_vatgroupstart = Value
            End Set
        End Property
        Public Property VatGroupEnd() As VatGroup
            Get
                Return m_vatgroupstart
            End Get
            Set(ByVal Value As VatGroup)
                m_vatgroupstart = Value
            End Set
        End Property
#End Region

#Region "Event Handlers"
        Public Sub VatGroupButtonClicked(ByVal e As ButtonColumnEventArgs)
            Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
            Dim entities As New ArrayList
            Dim dummy As New VatGroup
            entities.Add(dummy)
            myEntityPanelService.OpenTreeDialog(dummy, AddressOf SetVatGroup, Nothing, entities)
        End Sub
        Private Sub SetVatGroup(ByVal vg As ISimpleEntity)
            Me.m_treeManager.SelectedRow("VatGroupCode") = vg.Code
        End Sub
        Private Sub btnVatGroupFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
            Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
            Select Case CType(sender, Control).Name.ToLower
                Case "btnvatgroupstartfind"
                    myEntityPanelService.OpenTreeDialog(New VatGroup, AddressOf SetVatGroupStartDialog)

                Case "btnvatgroupendfind"
                    myEntityPanelService.OpenTreeDialog(New VatGroup, AddressOf SetVatGroupEndDialog)

            End Select
        End Sub
        Private Sub btnSupplierFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
            Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
            Select Case CType(sender, Control).Name.ToLower
                Case "btnsupplistartfind"
                    myEntityPanelService.OpenListDialog(New Supplier, AddressOf SetSupplierStartDialog)

                Case "btnsuppliendfind"
                    myEntityPanelService.OpenListDialog(New Supplier, AddressOf SetSupplierEndDialog)

            End Select
        End Sub
        Private Sub btnCostcenterFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
            Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
            Select Case CType(sender, Control).Name.ToLower
                Case "btncccodestart"
                    myEntityPanelService.OpenTreeDialog(New CostCenter, AddressOf SetCCCodeStartDialog)
            End Select
        End Sub
        Private Sub SetSupplierStartDialog(ByVal e As ISimpleEntity)
            Me.txtSuppliCodeStart.Text = e.Code
            Supplier.GetSupplier(txtSuppliCodeStart, txtTemp, Me.SupplierStart)
        End Sub
        Private Sub SetSupplierEndDialog(ByVal e As ISimpleEntity)
            Me.txtSuppliCodeEnd.Text = e.Code
            Supplier.GetSupplier(txtSuppliCodeEnd, txtTemp, Me.SupplierEnd)
        End Sub
        Private Sub SetVatGroupStartDialog(ByVal e As ISimpleEntity)
            Me.txtVatGroupStart.Text = e.Code
            VatGroup.GetVatGroup(txtVatGroupStart, txtTemp, Me.VatGroupStart)
        End Sub
        Private Sub SetVatGroupEndDialog(ByVal e As ISimpleEntity)
            Me.txtVatGroupEnd.Text = e.Code
            VatGroup.GetVatGroup(txtVatGroupStart, txtTemp, Me.VatGroupEnd)
        End Sub
        Private Sub SetCCCodeStartDialog(ByVal e As ISimpleEntity)
            Me.txtCCCodeStart.Text = e.Code
            CostCenter.GetCostCenter(txtCCCodeStart, txtTemp, m_cc)
        End Sub
#End Region

#Region "ISimpleEntityPanel"
        Public Property Entity() As BusinessLogic.ISimpleEntity Implements ISimpleEntityPanel.Entity
            Get
                Return m_entity
            End Get
            Set(ByVal Value As BusinessLogic.ISimpleEntity)

            End Set
        End Property
        Public Event EntityPropertyChanged(ByVal sender As Object, ByVal e As System.EventArgs) Implements ISimpleEntityPanel.EntityPropertyChanged
        Public Sub AddNew() Implements ISimpleListPanel.AddNew

        End Sub
        Public Event EntitySelected(ByVal entity As BusinessLogic.ISimpleEntity) Implements ISimpleListPanel.EntitySelected
        Public Sub RefreshData(ByVal id As String) Implements ISimpleListPanel.RefreshData

        End Sub
        Public Property SelectedEntity() As BusinessLogic.ISimpleEntity Implements ISimpleListPanel.SelectedEntity
            Get
                Return m_entity
            End Get
            Set(ByVal Value As BusinessLogic.ISimpleEntity)

            End Set
        End Property
        Public Sub CheckFormEnable() Implements ISimplePanel.CheckFormEnable

        End Sub
        Public Sub ClearDetail() Implements ISimplePanel.ClearDetail

        End Sub
        Public ReadOnly Property Icon() As String Implements ISimplePanel.Icon
            Get

            End Get
        End Property
        Public Sub Initialize() Implements ISimplePanel.Initialize
            RegisterDropdown()
            ClearCriterias()
        End Sub
        Public Sub SetLabelText() Implements ISimplePanel.SetLabelText
            If Not m_entity Is Nothing Then
                Me.Text = Me.StringParserService.Parse(m_entity.ListPanelTitle)
            End If
            Me.lblDirection.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.VatItemPanelView.lblDirection}")
            Me.lblItemCode.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.VatItemPanelView.lblItemCode}")
            Me.lblVatGroupStart.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.VatItemPanelView.lblVatGroupStart}")

            Me.lblDocDateStart.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.VatItemPanelView.lblDocDateStart}")
            Me.Validator.SetDisplayName(txtDocDateStart, lblDocDateStart.Text)

            Me.lblSubmitalDateStart.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.VatItemPanelView.lblSubmitalDateStart}")
            Me.Validator.SetDisplayName(txtSubmitalDateStart, lblSubmitalDateStart.Text)

            Me.lblCCStart.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.VatItemPanelView.lblCCStart}")
            Me.Validator.SetDisplayName(txtCCCodeStart, lblCCStart.Text)

            Me.lblSuppliStart.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.VatItemPanelView.lblSuppliStart}")
            Me.Validator.SetDisplayName(txtSuppliCodeStart, lblSuppliStart.Text)
            ' Global {ถึง}
            Me.lblDocDateEnd.Text = Me.StringParserService.Parse("${res:Global.FilterPanelTo}")
            Me.Validator.SetDisplayName(txtDocDateEnd, lblDocDateEnd.Text)

            Me.lblSubmitalDateEnd.Text = Me.StringParserService.Parse("${res:Global.FilterPanelTo}")
            Me.Validator.SetDisplayName(txtSubmitalDateEnd, lblSubmitalDateEnd.Text)

            Me.lblSuppliEnd.Text = Me.StringParserService.Parse("${res:Global.FilterPanelTo}")
            Me.Validator.SetDisplayName(txtSuppliCodeEnd, lblSuppliEnd.Text)

            Me.lblVatGroupEnd.Text = Me.StringParserService.Parse("${res:Global.FilterPanelTo}")

            ' Button
            Me.btnSearch.Text = Me.StringParserService.Parse("${res:Global.SearchButtonText}")
            Me.btnReset.Text = Me.StringParserService.Parse("${res:Global.ResetButtonText}")

            ' GroupBox
            Me.grbRefDoc.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.VatItemPanelView.grbMaster}")
            Me.grbDetail.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.VatItemPanelView.grbDetail}")

            'Checkbox
            Me.chkIncludeChildren.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.VatItemPanelView.chkIncludeChildren}")
        End Sub
        Public Sub ShowInPad() Implements ISimplePanel.ShowInPad

        End Sub
        Public ReadOnly Property Title() As String Implements ISimplePanel.Title
            Get
                If Not m_entity Is Nothing Then
                    Return Me.m_entity.ListPanelTitle
                End If
            End Get
        End Property
        Public Sub UpdateEntityProperties() Implements ISimplePanel.UpdateEntityProperties

        End Sub
        Public Sub ChangeTitle(ByVal sender As Object, ByVal e As System.EventArgs) Implements ISimpleListPanel.ChangeTitle

        End Sub
#End Region

#Region "Overrides"
        Public Overrides ReadOnly Property TabPageText() As String
            Get
                Return Me.m_entity.ListPanelTitle
            End Get
        End Property
#End Region

#Region "IValidatable"
        Public ReadOnly Property FormValidator() As components.PJMTextboxValidator Implements IValidatable.FormValidator
            Get
                Return Me.Validator
            End Get
        End Property
#End Region

        Private Sub RegisterDropdown()
            CodeDescription.ListCodeDescriptionInComboBox(Me.cmbDirection, "vat_direction")
        End Sub

        Private Sub ClearCriterias()
            For Each ctrl As Control In Me.grbDetail.Controls
                If TypeOf ctrl Is TextBox Then
                    ctrl.Text = ""
                End If
            Next

            Me.CostCenter = New CostCenter
            Me.SupplierStart = New Supplier
            Me.SupplierEnd = New Supplier

            'Dim dtStart As Date = Date.Now.Subtract(New TimeSpan(7, 0, 0, 0))

            'Me.DocDateStart = dtStart
            'Me.txtDocDateStart.Text = MinDateToNull(Me.DocDateStart, "")
            'Me.dtpDocDateStart.Value = Me.DocDateStart

            'Me.DocDateEnd = Date.Now
            'Me.txtDocDateEnd.Text = MinDateToNull(Me.DocDateEnd, "")
            'Me.dtpDocDateEnd.Value = Me.DocDateEnd

            'Me.SubmitalDateStart = Date.Now
            'Me.txtSubmitalDateStart.Text = MinDateToNull(Me.SubmitalDateStart, "")
            'Me.dtpSubmitalDateStart.Value = Me.SubmitalDateStart

            'Me.SubmitalDateEnd = Date.Now
            'Me.txtSubmitalDateEnd.Text = MinDateToNull(Me.SubmitalDateEnd, "")
            'Me.dtpSubmitalDateEnd.Value = Me.SubmitalDateEnd
            cmbDirection.SelectedIndex = 0
        End Sub

        Private Sub Button_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSearch.Click, btnReset.Click
            If CType(sender, Control).Name.ToLower = "btnreset" Then
                ClearCriterias()
            End If
            'Load Items**********************************************************
            Me.m_tableInitialized = False
            Dim filters As Filter() = Me.GetFilterArray
            Dim dt As TreeTable = VatItem.GetItemDataTable(filters)
            Me.m_treeManager.Treetable = dt
            Me.Validator.DataTable = m_treeManager.Treetable
            Me.m_tableInitialized = True

            AddHandler dt.ColumnChanging, AddressOf Treetable_ColumnChanging
            AddHandler dt.ColumnChanged, AddressOf Treetable_ColumnChanged
            AddHandler dt.RowDeleted, AddressOf ItemDelete
            '********************************************************************
        End Sub

        Public Function ValidIdOrDBNull(ByVal entity As SimpleBusinessEntityBase) As Object
            If entity Is Nothing OrElse Not entity.Valid Then
                Return DBNull.Value
            End If
            Return entity.Id
        End Function

        Public Function MinDateToNull(ByVal dt As Date, ByVal nullString As String) As String
            If dt.Equals(Date.MinValue) Then
                Return nullString
            End If
            Return dt.ToShortDateString
        End Function

        Public Function GetFilterArray() As Filter()
            Dim arr(11) As Filter
            Dim vd As Object

            If cmbDirection.SelectedItem Is Nothing Then
                vd = DBNull.Value
            Else
                vd = CType(cmbDirection.SelectedItem, IdValuePair).Id
            End If
            arr(0) = New Filter("VatType", vd)
            arr(1) = New Filter("DocDateStart", IIf(Me.DocDateStart.Equals(Date.MinValue), DBNull.Value, Me.DocDateStart))
            arr(2) = New Filter("DocDateEnd", IIf(Me.DocDateEnd.Equals(Date.MinValue), DBNull.Value, Me.DocDateEnd))
            arr(3) = New Filter("cc_id", Me.ValidIdOrDBNull(m_cc))
            arr(4) = New Filter("IncludeChildCC", Me.chkIncludeChildren.Checked)
            arr(5) = New Filter("SuppliCodeStart", IIf(txtSuppliCodeStart.TextLength > 0, txtSuppliCodeStart.Text, DBNull.Value))
            arr(6) = New Filter("SuppliCodeEnd", IIf(txtSuppliCodeEnd.TextLength > 0, txtSuppliCodeEnd.Text, DBNull.Value))
            arr(7) = New Filter("vati_code", IIf(txtItemCode.TextLength > 0, txtItemCode.Text, DBNull.Value))
            arr(8) = New Filter("VatgCodeStart", IIf(txtVatGroupStart.TextLength > 0, txtVatGroupStart.Text, DBNull.Value))
            arr(9) = New Filter("VatgCodeEnd", IIf(txtVatGroupEnd.TextLength > 0, txtVatGroupEnd.Text, DBNull.Value))
            arr(10) = New Filter("SubmitalDateStart", IIf(Me.SubmitalDateStart.Equals(Date.MinValue), DBNull.Value, Me.SubmitalDateStart))
            arr(11) = New Filter("SubmitalDateEnd", IIf(Me.SubmitalDateEnd.Equals(Date.MinValue), DBNull.Value, Me.SubmitalDateEnd))
            Return arr
        End Function

#Region " ChangeProperty "
        Private Sub EventWiring()
            AddHandler btnSuppliStartFind.Click, AddressOf Me.btnSupplierFind_Click
            AddHandler btnSuppliEndFind.Click, AddressOf Me.btnSupplierFind_Click

            AddHandler btnVatGroupStartFind.Click, AddressOf Me.btnVatGroupFind_Click
            AddHandler btnVatGroupEndFind.Click, AddressOf Me.btnVatGroupFind_Click

            AddHandler btnCCCodeStart.Click, AddressOf Me.btnCostcenterFind_Click
            AddHandler txtCCCodeStart.Validated, AddressOf Me.ChangeProperty

            AddHandler txtDocDateStart.Validated, AddressOf Me.ChangeProperty
            AddHandler txtDocDateEnd.Validated, AddressOf Me.ChangeProperty

            AddHandler dtpDocDateStart.ValueChanged, AddressOf Me.ChangeProperty
            AddHandler dtpDocDateEnd.ValueChanged, AddressOf Me.ChangeProperty

            AddHandler txtSubmitalDateStart.Validated, AddressOf Me.ChangeProperty
            AddHandler txtSubmitalDateEnd.Validated, AddressOf Me.ChangeProperty

            AddHandler dtpSubmitalDateStart.ValueChanged, AddressOf Me.ChangeProperty
            AddHandler dtpSubmitalDateEnd.ValueChanged, AddressOf Me.ChangeProperty
        End Sub

        Private m_dateSetting As Boolean
        Private Sub ChangeProperty(ByVal sender As Object, ByVal e As EventArgs)
            Select Case CType(sender, Control).Name.ToLower
                Case "dtpdocdatestart"
                    If Not Me.DocDateStart.Equals(dtpDocDateStart.Value) Then
                        If Not m_dateSetting Then
                            Me.txtDocDateStart.Text = MinDateToNull(dtpDocDateStart.Value, Me.StringParserService.Parse("${res:Global.BlankDateText}"))
                            Me.DocDateStart = dtpDocDateStart.Value
                        End If
                    End If
                Case "txtdocdatestart"
                    m_dateSetting = True
                    If Not Me.txtDocDateStart.Text.Length = 0 AndAlso Me.Validator.GetErrorMessage(Me.txtDocDateStart) = "" Then
                        Dim theDate As Date = CDate(Me.txtDocDateStart.Text)
                        If Not Me.DocDateStart.Equals(theDate) Then
                            dtpDocDateStart.Value = theDate
                            Me.DocDateStart = dtpDocDateStart.Value
                        End If
                    Else
                        Me.dtpDocDateStart.Value = Date.Now
                        Me.DocDateStart = Date.MinValue
                    End If
                    m_dateSetting = False

                Case "dtpdocdateend"
                    If Not Me.DocDateEnd.Equals(dtpDocDateEnd.Value) Then
                        If Not m_dateSetting Then
                            Me.txtDocDateEnd.Text = MinDateToNull(dtpDocDateEnd.Value, Me.StringParserService.Parse("${res:Global.BlankDateText}"))
                            Me.DocDateEnd = dtpDocDateEnd.Value
                        End If
                    End If
                Case "txtdocdateend"
                    m_dateSetting = True
                    If Not Me.txtDocDateEnd.Text.Length = 0 AndAlso Me.Validator.GetErrorMessage(Me.txtDocDateEnd) = "" Then
                        Dim theDate As Date = CDate(Me.txtDocDateEnd.Text)
                        If Not Me.DocDateEnd.Equals(theDate) Then
                            dtpDocDateEnd.Value = theDate
                            Me.DocDateEnd = dtpDocDateEnd.Value
                        End If
                    Else
                        Me.dtpDocDateEnd.Value = Date.Now
                        Me.DocDateEnd = Date.MinValue
                    End If
                    m_dateSetting = False
                Case "dtpsubmitaldatestart"
                    If Not Me.SubmitalDateStart.Equals(dtpSubmitalDateStart.Value) Then
                        If Not m_dateSetting Then
                            Me.txtSubmitalDateStart.Text = MinDateToNull(dtpSubmitalDateStart.Value, Me.StringParserService.Parse("${res:Global.BlankDateText}"))
                            Me.SubmitalDateStart = dtpSubmitalDateStart.Value
                        End If
                    End If
                Case "txtsubmitaldatestart"
                    m_dateSetting = True
                    If Not Me.txtSubmitalDateStart.Text.Length = 0 AndAlso Me.Validator.GetErrorMessage(Me.txtSubmitalDateStart) = "" Then
                        Dim theDate As Date = CDate(Me.txtSubmitalDateStart.Text)
                        If Not Me.SubmitalDateStart.Equals(theDate) Then
                            dtpSubmitalDateStart.Value = theDate
                            Me.SubmitalDateStart = dtpSubmitalDateStart.Value
                        End If
                    Else
                        Me.dtpSubmitalDateStart.Value = Date.Now
                        Me.SubmitalDateStart = Date.MinValue
                    End If
                    m_dateSetting = False

                Case "dtpsubmitaldateend"
                    If Not Me.SubmitalDateEnd.Equals(dtpSubmitalDateEnd.Value) Then
                        If Not m_dateSetting Then
                            Me.txtSubmitalDateEnd.Text = MinDateToNull(dtpSubmitalDateEnd.Value, Me.StringParserService.Parse("${res:Global.BlankDateText}"))
                            Me.SubmitalDateEnd = dtpSubmitalDateEnd.Value
                        End If
                    End If
                Case "txtsubmitaldateend"
                    m_dateSetting = True
                    If Not Me.txtSubmitalDateEnd.Text.Length = 0 AndAlso Me.Validator.GetErrorMessage(Me.txtSubmitalDateEnd) = "" Then
                        Dim theDate As Date = CDate(Me.txtSubmitalDateEnd.Text)
                        If Not Me.SubmitalDateEnd.Equals(theDate) Then
                            dtpSubmitalDateEnd.Value = theDate
                            Me.SubmitalDateEnd = dtpSubmitalDateEnd.Value
                        End If
                    Else
                        Me.dtpSubmitalDateEnd.Value = Date.Now
                        Me.SubmitalDateEnd = Date.MinValue
                    End If
                    m_dateSetting = False
                Case Else
            End Select
        End Sub
#End Region

        Public ReadOnly Property TreeTable() As components.TreeTable Implements IHasTreeTable.TreeTable
            Get
                Return Me.m_treeManager.Treetable
            End Get
        End Property
        Public ReadOnly Property CanSaveBy() As ICanSaveTreeTable Implements IHasTreeTable.CanSaveBy
            Get
                Return New VatItem
            End Get
        End Property
    End Class
End Namespace