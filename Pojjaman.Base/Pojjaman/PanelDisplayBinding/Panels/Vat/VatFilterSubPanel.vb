Imports Longkong.Pojjaman.BusinessLogic
Imports longkong.Pojjaman.Services
Imports Longkong.Core.Services

Namespace Longkong.Pojjaman.Gui.Panels
    Public Class VatFilterSubPanel
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
        Friend WithEvents btnSearch As System.Windows.Forms.Button
        Friend WithEvents btnReset As System.Windows.Forms.Button
        Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
        Friend WithEvents Validator As Longkong.Pojjaman.Gui.Components.PJMTextboxValidator
        Friend WithEvents txtVatGroupEnd As System.Windows.Forms.TextBox
        Friend WithEvents lblVatGroupEnd As System.Windows.Forms.Label
        Friend WithEvents txtVatGroupStart As System.Windows.Forms.TextBox
        Friend WithEvents lblVatGroupStart As System.Windows.Forms.Label
        Friend WithEvents txtItemCode As System.Windows.Forms.TextBox
        Friend WithEvents lblItemCode As System.Windows.Forms.Label
        Friend WithEvents txtSubmitalDateEnd As System.Windows.Forms.TextBox
        Friend WithEvents txtSubmitalDateStart As System.Windows.Forms.TextBox
        Friend WithEvents dtpSubmitalDateStart As System.Windows.Forms.DateTimePicker
        Friend WithEvents dtpSubmitalDateEnd As System.Windows.Forms.DateTimePicker
        Friend WithEvents lblSubmitalDateStart As System.Windows.Forms.Label
        Friend WithEvents lblSubmitalDateEnd As System.Windows.Forms.Label
        Friend WithEvents chkIncludeChildren As System.Windows.Forms.CheckBox
        Friend WithEvents btnCCCodeStart As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents txtCCCodeStart As System.Windows.Forms.TextBox
        Friend WithEvents lblCCStart As System.Windows.Forms.Label
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
        Friend WithEvents grbDetail As Longkong.Pojjaman.Gui.Components.FixedGroupBox
        Friend WithEvents txtSupplierName As System.Windows.Forms.TextBox
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Me.components = New System.ComponentModel.Container
            Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(VatFilterSubPanel))
            Me.btnSearch = New System.Windows.Forms.Button
            Me.btnReset = New System.Windows.Forms.Button
            Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider
            Me.Validator = New Longkong.Pojjaman.Gui.Components.PJMTextboxValidator(Me.components)
            Me.txtSupplierName = New System.Windows.Forms.TextBox
            Me.txtVatGroupEnd = New System.Windows.Forms.TextBox
            Me.txtVatGroupStart = New System.Windows.Forms.TextBox
            Me.txtItemCode = New System.Windows.Forms.TextBox
            Me.txtSubmitalDateEnd = New System.Windows.Forms.TextBox
            Me.txtSubmitalDateStart = New System.Windows.Forms.TextBox
            Me.txtCCCodeStart = New System.Windows.Forms.TextBox
            Me.txtSuppliCodeStart = New System.Windows.Forms.TextBox
            Me.txtDocDateEnd = New System.Windows.Forms.TextBox
            Me.txtDocDateStart = New System.Windows.Forms.TextBox
            Me.grbDetail = New Longkong.Pojjaman.Gui.Components.FixedGroupBox
            Me.lblVatGroupEnd = New System.Windows.Forms.Label
            Me.lblVatGroupStart = New System.Windows.Forms.Label
            Me.lblItemCode = New System.Windows.Forms.Label
            Me.dtpSubmitalDateStart = New System.Windows.Forms.DateTimePicker
            Me.dtpSubmitalDateEnd = New System.Windows.Forms.DateTimePicker
            Me.lblSubmitalDateStart = New System.Windows.Forms.Label
            Me.lblSubmitalDateEnd = New System.Windows.Forms.Label
            Me.chkIncludeChildren = New System.Windows.Forms.CheckBox
            Me.btnCCCodeStart = New Longkong.Pojjaman.Gui.Components.ImageButton
            Me.lblCCStart = New System.Windows.Forms.Label
            Me.btnSuppliStartFind = New Longkong.Pojjaman.Gui.Components.ImageButton
            Me.lblSuppliStart = New System.Windows.Forms.Label
            Me.dtpDocDateStart = New System.Windows.Forms.DateTimePicker
            Me.dtpDocDateEnd = New System.Windows.Forms.DateTimePicker
            Me.lblDocDateStart = New System.Windows.Forms.Label
            Me.lblDocDateEnd = New System.Windows.Forms.Label
            Me.lblDirection = New System.Windows.Forms.Label
            Me.cmbDirection = New System.Windows.Forms.ComboBox
            Me.grbDetail.SuspendLayout()
            Me.SuspendLayout()
            '
            'btnSearch
            '
            Me.btnSearch.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.btnSearch.Location = New System.Drawing.Point(672, 144)
            Me.btnSearch.Name = "btnSearch"
            Me.btnSearch.TabIndex = 16
            Me.btnSearch.Text = "Search"
            '
            'btnReset
            '
            Me.btnReset.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.btnReset.Location = New System.Drawing.Point(592, 144)
            Me.btnReset.Name = "btnReset"
            Me.btnReset.TabIndex = 15
            Me.btnReset.TabStop = False
            Me.btnReset.Text = "Reset"
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
            Me.Validator.GotFocusBackColor = System.Drawing.Color.Empty
            Me.Validator.HasNewRow = False
            Me.Validator.InvalidBackColor = System.Drawing.Color.Empty
            '
            'txtSupplierName
            '
            Me.Validator.SetDataType(Me.txtSupplierName, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtSupplierName, "")
            Me.Validator.SetGotFocusBackColor(Me.txtSupplierName, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtSupplierName, System.Drawing.Color.Empty)
            Me.txtSupplierName.Location = New System.Drawing.Point(576, 64)
            Me.txtSupplierName.MaxLength = 255
            Me.Validator.SetMaxValue(Me.txtSupplierName, "")
            Me.Validator.SetMinValue(Me.txtSupplierName, "")
            Me.txtSupplierName.Name = "txtSupplierName"
            Me.txtSupplierName.ReadOnly = True
            Me.Validator.SetRegularExpression(Me.txtSupplierName, "")
            Me.Validator.SetRequired(Me.txtSupplierName, False)
            Me.txtSupplierName.Size = New System.Drawing.Size(152, 20)
            Me.txtSupplierName.TabIndex = 78
            Me.txtSupplierName.Text = ""
            Me.txtSupplierName.Visible = False
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
            Me.txtVatGroupEnd.Size = New System.Drawing.Size(120, 20)
            Me.txtVatGroupEnd.TabIndex = 77
            Me.txtVatGroupEnd.Text = ""
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
            Me.txtVatGroupStart.Size = New System.Drawing.Size(120, 20)
            Me.txtVatGroupStart.TabIndex = 75
            Me.txtVatGroupStart.Text = ""
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
            Me.txtItemCode.TabIndex = 73
            Me.txtItemCode.Text = ""
            '
            'txtSubmitalDateEnd
            '
            Me.Validator.SetDataType(Me.txtSubmitalDateEnd, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtSubmitalDateEnd, "")
            Me.Validator.SetGotFocusBackColor(Me.txtSubmitalDateEnd, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtSubmitalDateEnd, System.Drawing.Color.Empty)
            Me.txtSubmitalDateEnd.Location = New System.Drawing.Point(608, 40)
            Me.txtSubmitalDateEnd.MaxLength = 10
            Me.Validator.SetMaxValue(Me.txtSubmitalDateEnd, "")
            Me.Validator.SetMinValue(Me.txtSubmitalDateEnd, "")
            Me.txtSubmitalDateEnd.Name = "txtSubmitalDateEnd"
            Me.Validator.SetRegularExpression(Me.txtSubmitalDateEnd, "")
            Me.Validator.SetRequired(Me.txtSubmitalDateEnd, False)
            Me.txtSubmitalDateEnd.Size = New System.Drawing.Size(99, 20)
            Me.txtSubmitalDateEnd.TabIndex = 70
            Me.txtSubmitalDateEnd.Text = ""
            '
            'txtSubmitalDateStart
            '
            Me.Validator.SetDataType(Me.txtSubmitalDateStart, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtSubmitalDateStart, "")
            Me.Validator.SetGotFocusBackColor(Me.txtSubmitalDateStart, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtSubmitalDateStart, System.Drawing.Color.Empty)
            Me.txtSubmitalDateStart.Location = New System.Drawing.Point(448, 40)
            Me.txtSubmitalDateStart.MaxLength = 10
            Me.Validator.SetMaxValue(Me.txtSubmitalDateStart, "")
            Me.Validator.SetMinValue(Me.txtSubmitalDateStart, "")
            Me.txtSubmitalDateStart.Name = "txtSubmitalDateStart"
            Me.Validator.SetRegularExpression(Me.txtSubmitalDateStart, "")
            Me.Validator.SetRequired(Me.txtSubmitalDateStart, False)
            Me.txtSubmitalDateStart.Size = New System.Drawing.Size(109, 20)
            Me.txtSubmitalDateStart.TabIndex = 67
            Me.txtSubmitalDateStart.Text = ""
            '
            'txtCCCodeStart
            '
            Me.Validator.SetDataType(Me.txtCCCodeStart, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtCCCodeStart, "")
            Me.txtCCCodeStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtCCCodeStart, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtCCCodeStart, System.Drawing.Color.Empty)
            Me.txtCCCodeStart.Location = New System.Drawing.Point(448, 88)
            Me.txtCCCodeStart.MaxLength = 50
            Me.Validator.SetMaxValue(Me.txtCCCodeStart, "")
            Me.Validator.SetMinValue(Me.txtCCCodeStart, "")
            Me.txtCCCodeStart.Name = "txtCCCodeStart"
            Me.Validator.SetRegularExpression(Me.txtCCCodeStart, "")
            Me.Validator.SetRequired(Me.txtCCCodeStart, False)
            Me.txtCCCodeStart.Size = New System.Drawing.Size(104, 21)
            Me.txtCCCodeStart.TabIndex = 63
            Me.txtCCCodeStart.Text = ""
            '
            'txtSuppliCodeStart
            '
            Me.Validator.SetDataType(Me.txtSuppliCodeStart, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtSuppliCodeStart, "")
            Me.txtSuppliCodeStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtSuppliCodeStart, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtSuppliCodeStart, System.Drawing.Color.Empty)
            Me.txtSuppliCodeStart.Location = New System.Drawing.Point(448, 64)
            Me.Validator.SetMaxValue(Me.txtSuppliCodeStart, "")
            Me.Validator.SetMinValue(Me.txtSuppliCodeStart, "")
            Me.txtSuppliCodeStart.Name = "txtSuppliCodeStart"
            Me.Validator.SetRegularExpression(Me.txtSuppliCodeStart, "")
            Me.Validator.SetRequired(Me.txtSuppliCodeStart, False)
            Me.txtSuppliCodeStart.Size = New System.Drawing.Size(104, 21)
            Me.txtSuppliCodeStart.TabIndex = 57
            Me.txtSuppliCodeStart.Text = ""
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
            Me.txtDocDateEnd.TabIndex = 54
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
            Me.txtDocDateStart.TabIndex = 51
            Me.txtDocDateStart.Text = ""
            '
            'grbDetail
            '
            Me.grbDetail.Controls.Add(Me.txtSupplierName)
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
            Me.grbDetail.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.grbDetail.Location = New System.Drawing.Point(8, 8)
            Me.grbDetail.Name = "grbDetail"
            Me.grbDetail.Size = New System.Drawing.Size(744, 124)
            Me.grbDetail.TabIndex = 17
            Me.grbDetail.TabStop = False
            Me.grbDetail.Text = "ข้อมูลทั่วไป"
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
            'lblVatGroupStart
            '
            Me.lblVatGroupStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblVatGroupStart.ForeColor = System.Drawing.Color.Black
            Me.lblVatGroupStart.Location = New System.Drawing.Point(40, 64)
            Me.lblVatGroupStart.Name = "lblVatGroupStart"
            Me.lblVatGroupStart.Size = New System.Drawing.Size(64, 18)
            Me.lblVatGroupStart.TabIndex = 74
            Me.lblVatGroupStart.Text = "กลุ่มภาษี:"
            Me.lblVatGroupStart.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblItemCode
            '
            Me.lblItemCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblItemCode.ForeColor = System.Drawing.Color.Black
            Me.lblItemCode.Location = New System.Drawing.Point(32, 88)
            Me.lblItemCode.Name = "lblItemCode"
            Me.lblItemCode.Size = New System.Drawing.Size(72, 18)
            Me.lblItemCode.TabIndex = 72
            Me.lblItemCode.Text = "เลขที่ใบกำกับ:"
            Me.lblItemCode.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'dtpSubmitalDateStart
            '
            Me.dtpSubmitalDateStart.Format = System.Windows.Forms.DateTimePickerFormat.Short
            Me.dtpSubmitalDateStart.Location = New System.Drawing.Point(448, 40)
            Me.dtpSubmitalDateStart.Name = "dtpSubmitalDateStart"
            Me.dtpSubmitalDateStart.Size = New System.Drawing.Size(128, 20)
            Me.dtpSubmitalDateStart.TabIndex = 68
            Me.dtpSubmitalDateStart.TabStop = False
            '
            'dtpSubmitalDateEnd
            '
            Me.dtpSubmitalDateEnd.Format = System.Windows.Forms.DateTimePickerFormat.Short
            Me.dtpSubmitalDateEnd.Location = New System.Drawing.Point(608, 40)
            Me.dtpSubmitalDateEnd.Name = "dtpSubmitalDateEnd"
            Me.dtpSubmitalDateEnd.Size = New System.Drawing.Size(120, 20)
            Me.dtpSubmitalDateEnd.TabIndex = 71
            Me.dtpSubmitalDateEnd.TabStop = False
            '
            'lblSubmitalDateStart
            '
            Me.lblSubmitalDateStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblSubmitalDateStart.ForeColor = System.Drawing.Color.Black
            Me.lblSubmitalDateStart.Location = New System.Drawing.Point(384, 40)
            Me.lblSubmitalDateStart.Name = "lblSubmitalDateStart"
            Me.lblSubmitalDateStart.Size = New System.Drawing.Size(64, 18)
            Me.lblSubmitalDateStart.TabIndex = 66
            Me.lblSubmitalDateStart.Text = "วันที่ยื่นภาษี:"
            Me.lblSubmitalDateStart.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblSubmitalDateEnd
            '
            Me.lblSubmitalDateEnd.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblSubmitalDateEnd.ForeColor = System.Drawing.Color.Black
            Me.lblSubmitalDateEnd.Location = New System.Drawing.Point(584, 40)
            Me.lblSubmitalDateEnd.Name = "lblSubmitalDateEnd"
            Me.lblSubmitalDateEnd.Size = New System.Drawing.Size(22, 18)
            Me.lblSubmitalDateEnd.TabIndex = 69
            Me.lblSubmitalDateEnd.Text = "ถึง"
            Me.lblSubmitalDateEnd.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'chkIncludeChildren
            '
            Me.chkIncludeChildren.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.chkIncludeChildren.Location = New System.Drawing.Point(608, 88)
            Me.chkIncludeChildren.Name = "chkIncludeChildren"
            Me.chkIncludeChildren.Size = New System.Drawing.Size(120, 24)
            Me.chkIncludeChildren.TabIndex = 65
            Me.chkIncludeChildren.Text = "รวม Cost Center ลูก"
            '
            'btnCCCodeStart
            '
            Me.btnCCCodeStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.btnCCCodeStart.ForeColor = System.Drawing.SystemColors.Control
            Me.btnCCCodeStart.Image = CType(resources.GetObject("btnCCCodeStart.Image"), System.Drawing.Image)
            Me.btnCCCodeStart.Location = New System.Drawing.Point(552, 88)
            Me.btnCCCodeStart.Name = "btnCCCodeStart"
            Me.btnCCCodeStart.Size = New System.Drawing.Size(24, 22)
            Me.btnCCCodeStart.TabIndex = 64
            Me.btnCCCodeStart.TabStop = False
            Me.btnCCCodeStart.ThemedImage = CType(resources.GetObject("btnCCCodeStart.ThemedImage"), System.Drawing.Bitmap)
            '
            'lblCCStart
            '
            Me.lblCCStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblCCStart.ForeColor = System.Drawing.Color.Black
            Me.lblCCStart.Location = New System.Drawing.Point(376, 88)
            Me.lblCCStart.Name = "lblCCStart"
            Me.lblCCStart.Size = New System.Drawing.Size(72, 18)
            Me.lblCCStart.TabIndex = 62
            Me.lblCCStart.Text = "Cost Center:"
            Me.lblCCStart.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'btnSuppliStartFind
            '
            Me.btnSuppliStartFind.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.btnSuppliStartFind.ForeColor = System.Drawing.SystemColors.Control
            Me.btnSuppliStartFind.Image = CType(resources.GetObject("btnSuppliStartFind.Image"), System.Drawing.Image)
            Me.btnSuppliStartFind.Location = New System.Drawing.Point(552, 64)
            Me.btnSuppliStartFind.Name = "btnSuppliStartFind"
            Me.btnSuppliStartFind.Size = New System.Drawing.Size(24, 22)
            Me.btnSuppliStartFind.TabIndex = 58
            Me.btnSuppliStartFind.TabStop = False
            Me.btnSuppliStartFind.ThemedImage = CType(resources.GetObject("btnSuppliStartFind.ThemedImage"), System.Drawing.Bitmap)
            '
            'lblSuppliStart
            '
            Me.lblSuppliStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblSuppliStart.ForeColor = System.Drawing.Color.Black
            Me.lblSuppliStart.Location = New System.Drawing.Point(376, 64)
            Me.lblSuppliStart.Name = "lblSuppliStart"
            Me.lblSuppliStart.Size = New System.Drawing.Size(72, 18)
            Me.lblSuppliStart.TabIndex = 56
            Me.lblSuppliStart.Text = "ผู้ขาย/ลูกค้า:"
            Me.lblSuppliStart.TextAlign = System.Drawing.ContentAlignment.MiddleRight
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
            Me.lblDocDateStart.Location = New System.Drawing.Point(8, 40)
            Me.lblDocDateStart.Name = "lblDocDateStart"
            Me.lblDocDateStart.Size = New System.Drawing.Size(96, 18)
            Me.lblDocDateStart.TabIndex = 50
            Me.lblDocDateStart.Text = "วันที่ใบกำกับภาษี:"
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
            Me.lblDirection.Location = New System.Drawing.Point(16, 16)
            Me.lblDirection.Name = "lblDirection"
            Me.lblDirection.Size = New System.Drawing.Size(88, 18)
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
            Me.cmbDirection.TabIndex = 49
            Me.cmbDirection.TabStop = False
            '
            'VatFilterSubPanel
            '
            Me.Controls.Add(Me.grbDetail)
            Me.Controls.Add(Me.btnReset)
            Me.Controls.Add(Me.btnSearch)
            Me.Name = "VatFilterSubPanel"
            Me.Size = New System.Drawing.Size(760, 176)
            Me.grbDetail.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

#End Region

#Region "Member"
        Dim m_entity As New Vat
        Private m_supplier As Supplier
        Private m_customer As Customer
        Private m_DocDateEnd As Date
        Private m_DocDateStart As Date
        Private m_SubmitalDateEnd As Date
        Private m_SubmitalDateStart As Date
        Private m_cc As CostCenter
#End Region

#Region "Constructors"
        Public Sub New()
            MyBase.New()
            InitializeComponent()
            SetLabelText()
            Initialize()
            EventWiring()
            m_entity = New Vat
        End Sub
#End Region

#Region "Properties"
        Private Property Vat() As Vat
            Get
                Return m_entity
            End Get
            Set(ByVal Value As Vat)
                m_entity = Value
            End Set
        End Property
        Public Property Supplier() As Supplier
            Get
                Return m_supplier
            End Get
            Set(ByVal Value As Supplier)
                m_supplier = Value
            End Set
        End Property
        Public Property Customer() As Customer
            Get
                Return m_customer
            End Get
            Set(ByVal Value As Customer)
                m_customer = Value
            End Set
        End Property
        Public Property DocDateEnd() As Date            Get                Return m_DocDateEnd            End Get            Set(ByVal Value As Date)                m_DocDateEnd = Value            End Set        End Property        Public Property DocDateStart() As Date            Get                Return m_DocDateStart            End Get            Set(ByVal Value As Date)                m_DocDateStart = Value            End Set        End Property
        Public Property SubmitalDateEnd() As Date            Get                Return m_SubmitalDateEnd            End Get            Set(ByVal Value As Date)                m_SubmitalDateEnd = Value            End Set        End Property        Public Property SubmitalDateStart() As Date            Get                Return m_SubmitalDateStart            End Get            Set(ByVal Value As Date)                m_SubmitalDateStart = Value            End Set        End Property
        Public Property CostCenter() As CostCenter
            Get
                Return m_cc
            End Get
            Set(ByVal Value As CostCenter)
                m_cc = Value
            End Set
        End Property
#End Region

#Region "Methods"
        Private Sub Initialize()
            RegisterDropdown()
            ClearCriterias()
        End Sub
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
            Me.Supplier = New Supplier
            Me.customer = New Customer

            Dim dtStart As Date = Date.Now.Subtract(New TimeSpan(30, 0, 0, 0))

            Me.DocDateStart = dtStart
            Me.txtDocDateStart.Text = MinDateToNull(Me.DocDateStart, "")
            Me.dtpDocDateStart.Value = Me.DocDateStart

            Me.DocDateEnd = Date.Now
            Me.txtDocDateEnd.Text = MinDateToNull(Me.DocDateEnd, "")
            Me.dtpDocDateEnd.Value = Me.DocDateEnd

            'Me.SubmitalDateStart = Date.Now
            'Me.txtSubmitalDateStart.Text = MinDateToNull(Me.SubmitalDateStart, "")
            'Me.dtpSubmitalDateStart.Value = Me.SubmitalDateStart

            'Me.SubmitalDateEnd = Date.Now
            'Me.txtSubmitalDateEnd.Text = MinDateToNull(Me.SubmitalDateEnd, "")
            'Me.dtpSubmitalDateEnd.Value = Me.SubmitalDateEnd
            cmbDirection.SelectedIndex = 0
        End Sub

        Public Sub SetLabelText()
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

            Me.lblVatGroupEnd.Text = Me.StringParserService.Parse("${res:Global.FilterPanelTo}")

            ' Button
            Me.btnSearch.Text = Me.StringParserService.Parse("${res:Global.SearchButtonText}")
            Me.btnReset.Text = Me.StringParserService.Parse("${res:Global.ResetButtonText}")

            ' GroupBox
            Me.grbDetail.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.VatItemPanelView.grbDetail}")

            'Checkbox
            Me.chkIncludeChildren.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.VatItemPanelView.chkIncludeChildren}")
        End Sub
        Public Overrides Function GetFilterString() As String

        End Function
        Public Overrides Function GetFilterArray() As Filter()
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
            arr(6) = New Filter("SuppliCodeEnd", IIf(txtSuppliCodeStart.TextLength > 0, txtSuppliCodeStart.Text, DBNull.Value))
            arr(7) = New Filter("vati_code", IIf(txtItemCode.TextLength > 0, txtItemCode.Text, DBNull.Value))
            arr(8) = New Filter("VatgCodeStart", IIf(txtVatGroupStart.TextLength > 0, txtVatGroupStart.Text, DBNull.Value))
            arr(9) = New Filter("VatgCodeEnd", IIf(txtVatGroupEnd.TextLength > 0, txtVatGroupEnd.Text, DBNull.Value))
            arr(10) = New Filter("SubmitalDateStart", IIf(Me.SubmitalDateStart.Equals(Date.MinValue), DBNull.Value, Me.SubmitalDateStart))
            arr(11) = New Filter("SubmitalDateEnd", IIf(Me.SubmitalDateEnd.Equals(Date.MinValue), DBNull.Value, Me.SubmitalDateEnd))
            Return arr
        End Function
        Public Overrides ReadOnly Property SearchButton() As System.Windows.Forms.Button
            Get
                Return Me.btnSearch
            End Get
        End Property
        Public Overrides Property Entities() As System.Collections.ArrayList
            Get
                Return MyBase.Entities
            End Get
            Set(ByVal Value As System.Collections.ArrayList)
                MyBase.Entities = Value
                For Each entity As ISimpleEntity In Value
                    If TypeOf entity Is Supplier Then
                        Me.SetSupplierStartDialog(entity)
                        Me.txtSuppliCodeStart.Enabled = False
                        Me.txtSupplierName.Enabled = False
                        Me.btnSuppliStartFind.Enabled = False
                    ElseIf TypeOf entity Is Customer Then
                        Me.SetCustomerStartDialog(entity)
                        Me.txtSuppliCodeStart.Enabled = False
                        Me.txtSupplierName.Enabled = False
                        Me.btnSuppliStartFind.Enabled = False
                    End If
                    If TypeOf entity Is Vat Then
                        CodeDescription.ComboSelect(Me.cmbDirection, CType(entity, Vat).Direction)
                        cmbDirection.Enabled = False
                    End If
                Next
            End Set
        End Property
#End Region

#Region " ChangeProperty "
        Private Sub EventWiring()
            AddHandler btnSuppliStartFind.Click, AddressOf Me.btnSupplierFind_Click

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
                Case "dtpSubmitalDatestart"
                    If Not Me.SubmitalDateStart.Equals(dtpSubmitalDateStart.Value) Then
                        If Not m_dateSetting Then
                            Me.txtSubmitalDateStart.Text = MinDateToNull(dtpSubmitalDateStart.Value, Me.StringParserService.Parse("${res:Global.BlankDateText}"))
                            Me.SubmitalDateStart = dtpSubmitalDateStart.Value
                        End If
                    End If
                Case "txtSubmitalDatestart"
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

                Case "dtpSubmitalDateend"
                    If Not Me.SubmitalDateEnd.Equals(dtpSubmitalDateEnd.Value) Then
                        If Not m_dateSetting Then
                            Me.txtSubmitalDateEnd.Text = MinDateToNull(dtpSubmitalDateEnd.Value, Me.StringParserService.Parse("${res:Global.BlankDateText}"))
                            Me.SubmitalDateEnd = dtpSubmitalDateEnd.Value
                        End If
                    End If
                Case "txtSubmitalDateend"
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

#Region "Event Handlers"
        Private Sub btnReset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReset.Click
            ClearCriterias()
            Me.btnSearch.PerformClick()
        End Sub
        Private Sub btnSupplierFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
            Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
            Select Case CType(sender, Control).Name.ToLower
                Case "btnsupplistartfind"
                    If m_supplier.Originated Then
                        myEntityPanelService.OpenListDialog(New Supplier, AddressOf SetSupplierStartDialog)
                    Else
                        myEntityPanelService.OpenListDialog(New Customer, AddressOf SetCustomerStartDialog)
                    End If
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
            Supplier.GetSupplier(Me.txtSuppliCodeStart, txtSupplierName, Me.Supplier)
        End Sub
        Private Sub SetCustomerStartDialog(ByVal e As ISimpleEntity)
            Me.txtSuppliCodeStart.Text = e.Code
            Customer.GetCustomer(Me.txtSuppliCodeStart, txtSupplierName, Me.Customer)
        End Sub
        Private Sub SetCCCodeStartDialog(ByVal e As ISimpleEntity)
            Me.txtCCCodeStart.Text = e.Code
            CostCenter.GetCostCenter(txtCCCodeStart, New TextBox, m_cc)
        End Sub
#End Region

#Region "IClipboardHandler Overrides"
        'Public Overrides ReadOnly Property EnablePaste() As Boolean
        '    Get
        '        Dim data As IDataObject = Clipboard.GetDataObject
        '        If data.GetDataPresent((New VatGroup).FullClassName) Then
        '            If Not Me.ActiveControl Is Nothing Then
        '                Select Case Me.ActiveControl.Name.ToLower
        '                    Case 
        '                        Return True
        '                End Select
        '            End If
        '        End If
        '    End Get
        'End Property
        'Public Overrides Sub Paste(ByVal sender As Object, ByVal e As System.EventArgs)
        '    Dim data As IDataObject = Clipboard.GetDataObject
        '    If data.GetDataPresent((New CustomerGroup).FullClassName) Then
        '        Dim id As Integer = CInt(data.GetData((New CustomerGroup).FullClassName))
        '        Dim entity As New CustomerGroup(id)
        '        If Not Me.ActiveControl Is Nothing Then
        '            Select Case Me.ActiveControl.Name.ToLower
        '                Case "txtgroupcode", "txtgroupname"
        '                    Me.SetCustomerGroup(entity)
        '            End Select
        '        End If
        '    End If
        'End Sub
#End Region

    End Class
End Namespace

