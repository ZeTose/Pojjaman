Imports Longkong.Pojjaman.BusinessLogic
Imports Longkong.Pojjaman.Services
Imports Longkong.Core.Services

Namespace Longkong.Pojjaman.Gui.Panels
    Public Class APOnpeningBalanceFilterSubPanel
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
        Friend WithEvents grbDocDate As Longkong.Pojjaman.Gui.Components.FixedGroupBox
        Friend WithEvents lblDocDateStart As System.Windows.Forms.Label
        Friend WithEvents lblDocDateEnd As System.Windows.Forms.Label
        Friend WithEvents btnSupplierDialog As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents btnSupplierPanel As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents txtSupplierCode As System.Windows.Forms.TextBox
        Friend WithEvents lblSupplier As System.Windows.Forms.Label
        Friend WithEvents txtSupplierName As System.Windows.Forms.TextBox
        Friend WithEvents grbDueDate As Longkong.Pojjaman.Gui.Components.FixedGroupBox
        Friend WithEvents lblDueDateStart As System.Windows.Forms.Label
        Friend WithEvents lblDueDateEnd As System.Windows.Forms.Label
        Friend WithEvents txtDocDateStart As System.Windows.Forms.TextBox
        Friend WithEvents txtDocDateEnd As System.Windows.Forms.TextBox
        Friend WithEvents dtpDocDateStart As System.Windows.Forms.DateTimePicker
        Friend WithEvents dtpDocDateEnd As System.Windows.Forms.DateTimePicker
        Friend WithEvents txtDueDateStart As System.Windows.Forms.TextBox
        Friend WithEvents txtDueDateEnd As System.Windows.Forms.TextBox
        Friend WithEvents dtpDueDateStart As System.Windows.Forms.DateTimePicker
        Friend WithEvents dtpDueDateEnd As System.Windows.Forms.DateTimePicker
        Friend WithEvents Validator As Longkong.Pojjaman.Gui.Components.PJMTextboxValidator
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Me.components = New System.ComponentModel.Container
            Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(APOnpeningBalanceFilterSubPanel))
            Me.lblCode = New System.Windows.Forms.Label
            Me.txtCode = New System.Windows.Forms.TextBox
            Me.grbDetail = New Longkong.Pojjaman.Gui.Components.FixedGroupBox
            Me.grbDueDate = New Longkong.Pojjaman.Gui.Components.FixedGroupBox
            Me.txtDueDateStart = New System.Windows.Forms.TextBox
            Me.txtDueDateEnd = New System.Windows.Forms.TextBox
            Me.dtpDueDateStart = New System.Windows.Forms.DateTimePicker
            Me.dtpDueDateEnd = New System.Windows.Forms.DateTimePicker
            Me.lblDueDateStart = New System.Windows.Forms.Label
            Me.lblDueDateEnd = New System.Windows.Forms.Label
            Me.btnSupplierDialog = New Longkong.Pojjaman.Gui.Components.ImageButton
            Me.btnSupplierPanel = New Longkong.Pojjaman.Gui.Components.ImageButton
            Me.txtSupplierCode = New System.Windows.Forms.TextBox
            Me.lblSupplier = New System.Windows.Forms.Label
            Me.grbDocDate = New Longkong.Pojjaman.Gui.Components.FixedGroupBox
            Me.txtDocDateStart = New System.Windows.Forms.TextBox
            Me.txtDocDateEnd = New System.Windows.Forms.TextBox
            Me.dtpDocDateStart = New System.Windows.Forms.DateTimePicker
            Me.dtpDocDateEnd = New System.Windows.Forms.DateTimePicker
            Me.lblDocDateStart = New System.Windows.Forms.Label
            Me.lblDocDateEnd = New System.Windows.Forms.Label
            Me.btnSearch = New System.Windows.Forms.Button
            Me.btnReset = New System.Windows.Forms.Button
            Me.txtSupplierName = New System.Windows.Forms.TextBox
            Me.Validator = New Longkong.Pojjaman.Gui.Components.PJMTextboxValidator(Me.components)
            Me.grbDetail.SuspendLayout()
            Me.grbDueDate.SuspendLayout()
            Me.grbDocDate.SuspendLayout()
            Me.SuspendLayout()
            '
            'lblCode
            '
            Me.lblCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblCode.ForeColor = System.Drawing.Color.Black
            Me.lblCode.Location = New System.Drawing.Point(8, 24)
            Me.lblCode.Name = "lblCode"
            Me.lblCode.Size = New System.Drawing.Size(80, 18)
            Me.lblCode.TabIndex = 0
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
            Me.txtCode.Location = New System.Drawing.Point(88, 24)
            Me.txtCode.MaxLength = 255
            Me.Validator.SetMaxValue(Me.txtCode, "")
            Me.Validator.SetMinValue(Me.txtCode, "")
            Me.txtCode.Name = "txtCode"
            Me.Validator.SetRegularExpression(Me.txtCode, "")
            Me.Validator.SetRequired(Me.txtCode, False)
            Me.txtCode.Size = New System.Drawing.Size(424, 21)
            Me.txtCode.TabIndex = 1
            Me.txtCode.Text = ""
            '
            'grbDetail
            '
            Me.grbDetail.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.grbDetail.Controls.Add(Me.grbDueDate)
            Me.grbDetail.Controls.Add(Me.btnSupplierDialog)
            Me.grbDetail.Controls.Add(Me.btnSupplierPanel)
            Me.grbDetail.Controls.Add(Me.txtSupplierCode)
            Me.grbDetail.Controls.Add(Me.lblSupplier)
            Me.grbDetail.Controls.Add(Me.grbDocDate)
            Me.grbDetail.Controls.Add(Me.btnSearch)
            Me.grbDetail.Controls.Add(Me.txtCode)
            Me.grbDetail.Controls.Add(Me.lblCode)
            Me.grbDetail.Controls.Add(Me.btnReset)
            Me.grbDetail.Controls.Add(Me.txtSupplierName)
            Me.grbDetail.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.grbDetail.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.grbDetail.Location = New System.Drawing.Point(8, 16)
            Me.grbDetail.Name = "grbDetail"
            Me.grbDetail.Size = New System.Drawing.Size(680, 160)
            Me.grbDetail.TabIndex = 0
            Me.grbDetail.TabStop = False
            Me.grbDetail.Text = "ค้นหา"
            '
            'grbDueDate
            '
            Me.grbDueDate.Controls.Add(Me.txtDueDateStart)
            Me.grbDueDate.Controls.Add(Me.txtDueDateEnd)
            Me.grbDueDate.Controls.Add(Me.dtpDueDateStart)
            Me.grbDueDate.Controls.Add(Me.dtpDueDateEnd)
            Me.grbDueDate.Controls.Add(Me.lblDueDateStart)
            Me.grbDueDate.Controls.Add(Me.lblDueDateEnd)
            Me.grbDueDate.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.grbDueDate.Location = New System.Drawing.Point(264, 80)
            Me.grbDueDate.Name = "grbDueDate"
            Me.grbDueDate.Size = New System.Drawing.Size(248, 72)
            Me.grbDueDate.TabIndex = 10
            Me.grbDueDate.TabStop = False
            Me.grbDueDate.Text = "วันที่ครบกำหนด"
            '
            'txtDueDateStart
            '
            Me.txtDueDateStart.BackColor = System.Drawing.SystemColors.Window
            Me.Validator.SetDataType(Me.txtDueDateStart, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtDueDateStart, "")
            Me.Validator.SetGotFocusBackColor(Me.txtDueDateStart, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtDueDateStart, System.Drawing.Color.Empty)
            Me.txtDueDateStart.Location = New System.Drawing.Point(88, 13)
            Me.Validator.SetMaxValue(Me.txtDueDateStart, "")
            Me.Validator.SetMinValue(Me.txtDueDateStart, "")
            Me.txtDueDateStart.Name = "txtDueDateStart"
            Me.Validator.SetRegularExpression(Me.txtDueDateStart, "")
            Me.Validator.SetRequired(Me.txtDueDateStart, False)
            Me.txtDueDateStart.Size = New System.Drawing.Size(132, 21)
            Me.txtDueDateStart.TabIndex = 12
            Me.txtDueDateStart.Text = ""
            '
            'txtDueDateEnd
            '
            Me.txtDueDateEnd.BackColor = System.Drawing.SystemColors.Window
            Me.Validator.SetDataType(Me.txtDueDateEnd, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtDueDateEnd, "")
            Me.Validator.SetGotFocusBackColor(Me.txtDueDateEnd, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtDueDateEnd, System.Drawing.Color.Empty)
            Me.txtDueDateEnd.Location = New System.Drawing.Point(88, 39)
            Me.Validator.SetMaxValue(Me.txtDueDateEnd, "")
            Me.Validator.SetMinValue(Me.txtDueDateEnd, "")
            Me.txtDueDateEnd.Name = "txtDueDateEnd"
            Me.Validator.SetRegularExpression(Me.txtDueDateEnd, "")
            Me.Validator.SetRequired(Me.txtDueDateEnd, False)
            Me.txtDueDateEnd.Size = New System.Drawing.Size(132, 21)
            Me.txtDueDateEnd.TabIndex = 13
            Me.txtDueDateEnd.Text = ""
            '
            'dtpDueDateStart
            '
            Me.dtpDueDateStart.Format = System.Windows.Forms.DateTimePickerFormat.Short
            Me.dtpDueDateStart.Location = New System.Drawing.Point(96, 13)
            Me.dtpDueDateStart.Name = "dtpDueDateStart"
            Me.dtpDueDateStart.Size = New System.Drawing.Size(144, 21)
            Me.dtpDueDateStart.TabIndex = 14
            Me.dtpDueDateStart.TabStop = False
            '
            'dtpDueDateEnd
            '
            Me.dtpDueDateEnd.Format = System.Windows.Forms.DateTimePickerFormat.Short
            Me.dtpDueDateEnd.Location = New System.Drawing.Point(96, 39)
            Me.dtpDueDateEnd.Name = "dtpDueDateEnd"
            Me.dtpDueDateEnd.Size = New System.Drawing.Size(144, 21)
            Me.dtpDueDateEnd.TabIndex = 15
            Me.dtpDueDateEnd.TabStop = False
            '
            'lblDueDateStart
            '
            Me.lblDueDateStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblDueDateStart.ForeColor = System.Drawing.Color.Black
            Me.lblDueDateStart.Location = New System.Drawing.Point(8, 17)
            Me.lblDueDateStart.Name = "lblDueDateStart"
            Me.lblDueDateStart.Size = New System.Drawing.Size(80, 18)
            Me.lblDueDateStart.TabIndex = 0
            Me.lblDueDateStart.Text = "Start Date:"
            Me.lblDueDateStart.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblDueDateEnd
            '
            Me.lblDueDateEnd.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblDueDateEnd.ForeColor = System.Drawing.Color.Black
            Me.lblDueDateEnd.Location = New System.Drawing.Point(8, 40)
            Me.lblDueDateEnd.Name = "lblDueDateEnd"
            Me.lblDueDateEnd.Size = New System.Drawing.Size(80, 24)
            Me.lblDueDateEnd.TabIndex = 2
            Me.lblDueDateEnd.Text = "End Date:"
            Me.lblDueDateEnd.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'btnSupplierDialog
            '
            Me.btnSupplierDialog.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.btnSupplierDialog.ForeColor = System.Drawing.SystemColors.Control
            Me.btnSupplierDialog.Image = CType(resources.GetObject("btnSupplierDialog.Image"), System.Drawing.Image)
            Me.btnSupplierDialog.Location = New System.Drawing.Point(432, 48)
            Me.btnSupplierDialog.Name = "btnSupplierDialog"
            Me.btnSupplierDialog.Size = New System.Drawing.Size(40, 23)
            Me.btnSupplierDialog.TabIndex = 5
            Me.btnSupplierDialog.TabStop = False
            Me.btnSupplierDialog.ThemedImage = CType(resources.GetObject("btnSupplierDialog.ThemedImage"), System.Drawing.Bitmap)
            '
            'btnSupplierPanel
            '
            Me.btnSupplierPanel.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.btnSupplierPanel.Image = CType(resources.GetObject("btnSupplierPanel.Image"), System.Drawing.Image)
            Me.btnSupplierPanel.Location = New System.Drawing.Point(472, 48)
            Me.btnSupplierPanel.Name = "btnSupplierPanel"
            Me.btnSupplierPanel.Size = New System.Drawing.Size(40, 23)
            Me.btnSupplierPanel.TabIndex = 6
            Me.btnSupplierPanel.TabStop = False
            Me.btnSupplierPanel.ThemedImage = CType(resources.GetObject("btnSupplierPanel.ThemedImage"), System.Drawing.Bitmap)
            '
            'txtSupplierCode
            '
            Me.Validator.SetDataType(Me.txtSupplierCode, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtSupplierCode, "")
            Me.Validator.SetGotFocusBackColor(Me.txtSupplierCode, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtSupplierCode, System.Drawing.Color.Empty)
            Me.txtSupplierCode.Location = New System.Drawing.Point(88, 48)
            Me.txtSupplierCode.MaxLength = 20
            Me.Validator.SetMaxValue(Me.txtSupplierCode, "")
            Me.Validator.SetMinValue(Me.txtSupplierCode, "")
            Me.txtSupplierCode.Name = "txtSupplierCode"
            Me.Validator.SetRegularExpression(Me.txtSupplierCode, "")
            Me.Validator.SetRequired(Me.txtSupplierCode, False)
            Me.txtSupplierCode.Size = New System.Drawing.Size(176, 21)
            Me.txtSupplierCode.TabIndex = 3
            Me.txtSupplierCode.Text = ""
            '
            'lblSupplier
            '
            Me.lblSupplier.BackColor = System.Drawing.Color.Transparent
            Me.lblSupplier.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblSupplier.ForeColor = System.Drawing.SystemColors.WindowText
            Me.lblSupplier.Location = New System.Drawing.Point(8, 48)
            Me.lblSupplier.Name = "lblSupplier"
            Me.lblSupplier.Size = New System.Drawing.Size(80, 18)
            Me.lblSupplier.TabIndex = 2
            Me.lblSupplier.Text = "Supplier:"
            Me.lblSupplier.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'grbDocDate
            '
            Me.grbDocDate.Controls.Add(Me.txtDocDateStart)
            Me.grbDocDate.Controls.Add(Me.txtDocDateEnd)
            Me.grbDocDate.Controls.Add(Me.dtpDocDateStart)
            Me.grbDocDate.Controls.Add(Me.dtpDocDateEnd)
            Me.grbDocDate.Controls.Add(Me.lblDocDateStart)
            Me.grbDocDate.Controls.Add(Me.lblDocDateEnd)
            Me.grbDocDate.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.grbDocDate.Location = New System.Drawing.Point(8, 80)
            Me.grbDocDate.Name = "grbDocDate"
            Me.grbDocDate.Size = New System.Drawing.Size(256, 72)
            Me.grbDocDate.TabIndex = 7
            Me.grbDocDate.TabStop = False
            Me.grbDocDate.Text = "วันที่เอกสาร"
            '
            'txtDocDateStart
            '
            Me.txtDocDateStart.BackColor = System.Drawing.SystemColors.Window
            Me.Validator.SetDataType(Me.txtDocDateStart, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtDocDateStart, "")
            Me.Validator.SetGotFocusBackColor(Me.txtDocDateStart, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtDocDateStart, System.Drawing.Color.Empty)
            Me.txtDocDateStart.Location = New System.Drawing.Point(80, 14)
            Me.Validator.SetMaxValue(Me.txtDocDateStart, "")
            Me.Validator.SetMinValue(Me.txtDocDateStart, "")
            Me.txtDocDateStart.Name = "txtDocDateStart"
            Me.Validator.SetRegularExpression(Me.txtDocDateStart, "")
            Me.Validator.SetRequired(Me.txtDocDateStart, False)
            Me.txtDocDateStart.Size = New System.Drawing.Size(148, 21)
            Me.txtDocDateStart.TabIndex = 12
            Me.txtDocDateStart.Text = ""
            '
            'txtDocDateEnd
            '
            Me.txtDocDateEnd.BackColor = System.Drawing.SystemColors.Window
            Me.Validator.SetDataType(Me.txtDocDateEnd, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtDocDateEnd, "")
            Me.Validator.SetGotFocusBackColor(Me.txtDocDateEnd, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtDocDateEnd, System.Drawing.Color.Empty)
            Me.txtDocDateEnd.Location = New System.Drawing.Point(80, 38)
            Me.Validator.SetMaxValue(Me.txtDocDateEnd, "")
            Me.Validator.SetMinValue(Me.txtDocDateEnd, "")
            Me.txtDocDateEnd.Name = "txtDocDateEnd"
            Me.Validator.SetRegularExpression(Me.txtDocDateEnd, "")
            Me.Validator.SetRequired(Me.txtDocDateEnd, False)
            Me.txtDocDateEnd.Size = New System.Drawing.Size(148, 21)
            Me.txtDocDateEnd.TabIndex = 13
            Me.txtDocDateEnd.Text = ""
            '
            'dtpDocDateStart
            '
            Me.dtpDocDateStart.Format = System.Windows.Forms.DateTimePickerFormat.Short
            Me.dtpDocDateStart.Location = New System.Drawing.Point(104, 14)
            Me.dtpDocDateStart.Name = "dtpDocDateStart"
            Me.dtpDocDateStart.Size = New System.Drawing.Size(144, 21)
            Me.dtpDocDateStart.TabIndex = 14
            Me.dtpDocDateStart.TabStop = False
            '
            'dtpDocDateEnd
            '
            Me.dtpDocDateEnd.Format = System.Windows.Forms.DateTimePickerFormat.Short
            Me.dtpDocDateEnd.Location = New System.Drawing.Point(80, 38)
            Me.dtpDocDateEnd.Name = "dtpDocDateEnd"
            Me.dtpDocDateEnd.Size = New System.Drawing.Size(168, 21)
            Me.dtpDocDateEnd.TabIndex = 15
            Me.dtpDocDateEnd.TabStop = False
            '
            'lblDocDateStart
            '
            Me.lblDocDateStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblDocDateStart.ForeColor = System.Drawing.Color.Black
            Me.lblDocDateStart.Location = New System.Drawing.Point(8, 16)
            Me.lblDocDateStart.Name = "lblDocDateStart"
            Me.lblDocDateStart.Size = New System.Drawing.Size(72, 24)
            Me.lblDocDateStart.TabIndex = 0
            Me.lblDocDateStart.Text = "ตั้งแต่:"
            Me.lblDocDateStart.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblDocDateEnd
            '
            Me.lblDocDateEnd.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblDocDateEnd.ForeColor = System.Drawing.Color.Black
            Me.lblDocDateEnd.Location = New System.Drawing.Point(8, 40)
            Me.lblDocDateEnd.Name = "lblDocDateEnd"
            Me.lblDocDateEnd.Size = New System.Drawing.Size(72, 24)
            Me.lblDocDateEnd.TabIndex = 2
            Me.lblDocDateEnd.Text = "ถึง:"
            Me.lblDocDateEnd.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'btnSearch
            '
            Me.btnSearch.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.btnSearch.Location = New System.Drawing.Point(592, 120)
            Me.btnSearch.Name = "btnSearch"
            Me.btnSearch.Size = New System.Drawing.Size(80, 23)
            Me.btnSearch.TabIndex = 9
            Me.btnSearch.Text = "Search"
            '
            'btnReset
            '
            Me.btnReset.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.btnReset.Location = New System.Drawing.Point(520, 120)
            Me.btnReset.Name = "btnReset"
            Me.btnReset.Size = New System.Drawing.Size(72, 23)
            Me.btnReset.TabIndex = 8
            Me.btnReset.Text = "Reset"
            '
            'txtSupplierName
            '
            Me.Validator.SetDataType(Me.txtSupplierName, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtSupplierName, "")
            Me.Validator.SetGotFocusBackColor(Me.txtSupplierName, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtSupplierName, System.Drawing.Color.Empty)
            Me.txtSupplierName.Location = New System.Drawing.Point(264, 48)
            Me.Validator.SetMaxValue(Me.txtSupplierName, "")
            Me.Validator.SetMinValue(Me.txtSupplierName, "")
            Me.txtSupplierName.Name = "txtSupplierName"
            Me.txtSupplierName.ReadOnly = True
            Me.Validator.SetRegularExpression(Me.txtSupplierName, "")
            Me.Validator.SetRequired(Me.txtSupplierName, False)
            Me.txtSupplierName.Size = New System.Drawing.Size(168, 21)
            Me.txtSupplierName.TabIndex = 4
            Me.txtSupplierName.TabStop = False
            Me.txtSupplierName.Text = ""
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
            'APOnpeningBalanceFilterSubPanel
            '
            Me.Controls.Add(Me.grbDetail)
            Me.Name = "APOnpeningBalanceFilterSubPanel"
            Me.Size = New System.Drawing.Size(696, 184)
            Me.grbDetail.ResumeLayout(False)
            Me.grbDueDate.ResumeLayout(False)
            Me.grbDocDate.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

#End Region

#Region "Constructors"
        Public Sub New()
            MyBase.New()

            m_supplier = New Supplier
            InitializeComponent()
            Initialize()
            SetLabelText()

        End Sub
#End Region

#Region "Members"
        Private m_supplier As Supplier
        Private docDateStart As Date
        Private docDateEnd As Date
        Private dueDateStart As Date
        Private dueDateEnd As Date
#End Region

#Region "Methods"
        Public Sub Initialize()
            AddHandler txtDocDateStart.Validated, AddressOf Me.ChangeProperty
            AddHandler dtpDocDateStart.ValueChanged, AddressOf Me.ChangeProperty
            AddHandler txtDocDateEnd.Validated, AddressOf Me.ChangeProperty
            AddHandler dtpDocDateEnd.ValueChanged, AddressOf Me.ChangeProperty
            AddHandler txtDueDateStart.Validated, AddressOf Me.ChangeProperty
            AddHandler dtpDueDateStart.ValueChanged, AddressOf Me.ChangeProperty
            AddHandler txtDueDateEnd.Validated, AddressOf Me.ChangeProperty
            AddHandler dtpDueDateEnd.ValueChanged, AddressOf Me.ChangeProperty

            PopulateStatus()
            ClearCriterias()
        End Sub
        Private m_dateSetting As Boolean
        Public Sub ChangeProperty(ByVal sender As Object, ByVal e As EventArgs)
            Dim dirtyFlag As Boolean = False
            Select Case CType(sender, Control).Name.ToLower
                Case "dtpdocdatestart"
                    If Not Me.docDateStart.Equals(dtpDocDateStart.Value) Then
                        If Not m_dateSetting Then
                            Me.txtDocDateStart.Text = MinDateToNull(dtpDocDateStart.Value, Me.StringParserService.Parse("${res:Global.BlankDateText}"))
                            Me.docDateStart = dtpDocDateStart.Value
                        End If
                        dirtyFlag = True
                    End If
                Case "txtdocdatestart"
                    m_dateSetting = True
                    If Not Me.txtDocDateStart.Text.Length = 0 AndAlso Me.Validator.GetErrorMessage(Me.txtDocDateStart) = "" Then
                        Dim theDate As Date = CDate(Me.txtDocDateStart.Text)
                        If Not Me.docDateStart.Equals(theDate) Then
                            dtpDocDateStart.Value = theDate
                            Me.docDateStart = dtpDocDateStart.Value
                            dirtyFlag = True
                        End If
                    Else
                        Me.dtpDocDateStart.Value = Date.Now
                        Me.docDateStart = Date.MinValue
                        dirtyFlag = True
                    End If
                    m_dateSetting = False
                Case "dtpdocdateend"
                    If Not Me.docDateEnd.Equals(dtpDocDateEnd.Value) Then
                        If Not m_dateSetting Then
                            Me.txtDocDateEnd.Text = MinDateToNull(dtpDocDateEnd.Value, Me.StringParserService.Parse("${res:Global.BlankDateText}"))
                            Me.docDateEnd = dtpDocDateEnd.Value
                        End If
                        dirtyFlag = True
                    End If
                Case "txtdocdateend"
                    m_dateSetting = True
                    If Not Me.txtDocDateEnd.Text.Length = 0 AndAlso Me.Validator.GetErrorMessage(Me.txtDocDateEnd) = "" Then
                        Dim theDate As Date = CDate(Me.txtDocDateEnd.Text)
                        If Not Me.docDateEnd.Equals(theDate) Then
                            dtpDocDateEnd.Value = theDate
                            Me.docDateEnd = dtpDocDateEnd.Value
                            dirtyFlag = True
                        End If
                    Else
                        Me.dtpDocDateEnd.Value = Date.Now
                        Me.docDateEnd = Date.MinValue
                        dirtyFlag = True
                    End If
                    m_dateSetting = False
                Case "dtpduedatestart"
                    If Not Me.dueDateStart.Equals(dtpDueDateStart.Value) Then
                        If Not m_dateSetting Then
                            Me.txtDueDateStart.Text = MinDateToNull(dtpDueDateStart.Value, Me.StringParserService.Parse("${res:Global.BlankDateText}"))
                            Me.dueDateStart = dtpDueDateStart.Value
                        End If
                        dirtyFlag = True
                    End If
                Case "txtduedatestart"
                    m_dateSetting = True
                    If Not Me.txtDueDateStart.Text.Length = 0 AndAlso Me.Validator.GetErrorMessage(Me.txtDueDateStart) = "" Then
                        Dim theDate As Date = CDate(Me.txtDueDateStart.Text)
                        If Not Me.dueDateStart.Equals(theDate) Then
                            dtpDueDateStart.Value = theDate
                            Me.dueDateStart = dtpDueDateStart.Value
                            dirtyFlag = True
                        End If
                    Else
                        Me.dtpDueDateStart.Value = Date.Now
                        Me.dueDateStart = Date.MinValue
                        dirtyFlag = True
                    End If
                    m_dateSetting = False
                Case "dtpduedateend"
                    If Not Me.dueDateEnd.Equals(dtpDueDateEnd.Value) Then
                        If Not m_dateSetting Then
                            Me.txtDueDateEnd.Text = MinDateToNull(dtpDueDateEnd.Value, Me.StringParserService.Parse("${res:Global.BlankDateText}"))
                            Me.dueDateEnd = dtpDueDateEnd.Value
                        End If
                        dirtyFlag = True
                    End If
                Case "txtduedateend"
                    m_dateSetting = True
                    If Not Me.txtDueDateEnd.Text.Length = 0 AndAlso Me.Validator.GetErrorMessage(Me.txtDueDateEnd) = "" Then
                        Dim theDate As Date = CDate(Me.txtDueDateEnd.Text)
                        If Not Me.dueDateEnd.Equals(theDate) Then
                            dtpDueDateEnd.Value = theDate
                            Me.dueDateEnd = dtpDueDateEnd.Value
                            dirtyFlag = True
                        End If
                    Else
                        Me.dtpDueDateEnd.Value = Date.Now
                        Me.dueDateEnd = Date.MinValue
                        dirtyFlag = True
                    End If
                    m_dateSetting = False
                Case Else
            End Select
        End Sub
        Private Sub ClearCriterias()
            Me.txtCode.Text = ""
            Me.txtSupplierCode.Text = ""
            Me.txtSupplierName.Text = ""
            Me.m_supplier = New Supplier

            Me.dtpDocDateStart.Value = DateAdd(DateInterval.Month, -1, Now.Date)
            Me.dtpDocDateEnd.Value = Now.Date

            Me.txtDocDateStart.Text = Me.MinDateToNull(DateAdd(DateInterval.Month, -1, Now.Date), "")
            Me.txtDocDateEnd.Text = Me.MinDateToNull(Now.Date, "")

            Me.docDateStart = DateAdd(DateInterval.Month, -1, Now.Date)
            Me.docDateEnd = Now.Date

            Me.dtpDueDateStart.Value = Me.MinDateToNull(DateAdd(DateInterval.Month, -1, Now.Date), "")
            Me.dtpDueDateEnd.Value = Me.MinDateToNull(DateAdd(DateInterval.Month, 1, Now.Date), "")

            Me.txtDueDateStart.Text = ""
            Me.txtDueDateEnd.Text = ""

            Me.dueDateStart = Date.MinValue
            Me.dueDateEnd = Date.MinValue
        End Sub
        Private Sub PopulateStatus()
            'Dim dt As DataTable = CodeDescription.GetCodeList("pr_status")
            'Me.cmbStatus.DataSource = dt
            'Me.cmbStatus.DisplayMember = "code_description"
            'Me.cmbStatus.ValueMember = "code_value"
        End Sub
        Public Sub SetLabelText()
            'Me.Text = Me.StringParserService.Parse(.TabPageText)
            Me.grbDetail.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.APOnpeningBalanceFilterSubPanel.grbDetail}")
            Me.lblCode.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.APOnpeningBalanceFilterSubPanel.lblCode}")
            Me.btnSearch.Text = Me.StringParserService.Parse("${res:Global.SearchButtonText}")
            Me.btnReset.Text = Me.StringParserService.Parse("${res:Global.ResetButtonText}")
            Me.grbDocDate.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.APOnpeningBalanceFilterSubPanel.grbDocDate}")
            Me.lblDocDateStart.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.APOnpeningBalanceFilterSubPanel.lblDocDateStart}")
            Me.lblDocDateEnd.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.APOnpeningBalanceFilterSubPanel.lblDocDateEnd}")
            Me.grbDueDate.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.APOnpeningBalanceFilterSubPanel.grbDueDate}")
            Me.lblDueDateStart.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.APOnpeningBalanceFilterSubPanel.lblDueDateStart}")
            Me.lblDueDateEnd.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.APOnpeningBalanceFilterSubPanel.lblDueDateEnd}")
            Me.lblSupplier.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.APOnpeningBalanceFilterSubPanel.lblSupplier}")
        End Sub
        Public Overrides Function GetFilterArray() As Filter()
            Dim arr(5) As Filter
            arr(0) = New Filter("code", IIf(Me.txtCode.Text.Length = 0, DBNull.Value, Me.txtCode.Text))
            arr(1) = New Filter("supplier", IIf(Me.Supplier.Valid, Me.Supplier.Id, DBNull.Value))
            arr(2) = New Filter("docdatestart", ValidDateOrDBNull(docDateStart))
            arr(3) = New Filter("docdateend", ValidDateOrDBNull(docDateEnd))
            arr(4) = New Filter("duedatestart", ValidDateOrDBNull(dueDateStart))
            arr(5) = New Filter("duedateend", ValidDateOrDBNull(dueDateEnd))
            Return arr
        End Function
        Private Property Supplier() As Supplier
            Get
                Return m_supplier
            End Get
            Set(ByVal Value As Supplier)
                m_supplier = Value
            End Set
        End Property
        Public Overrides ReadOnly Property SearchButton() As System.Windows.Forms.Button
            Get
                Return Me.btnSearch
            End Get
        End Property
#End Region

#Region "Event Handlers"
        Private Sub txtsupplierCode_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSupplierCode.Validated
            Supplier.GetSupplier(txtSupplierCode, txtSupplierName, Me.Supplier)
        End Sub
        Private Sub btnReset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReset.Click
            ClearCriterias()
            Me.btnSearch.PerformClick()
        End Sub
        Private Sub btnSupplierDialog_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSupplierDialog.Click
            Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
            myEntityPanelService.OpenListDialog(New Supplier, AddressOf SetSupplierDialog)
        End Sub

        Private Sub SetSupplierDialog(ByVal e As ISimpleEntity)
            Me.txtSupplierCode.Text = e.Code
            Supplier.GetSupplier(txtSupplierCode, txtSupplierName, Me.Supplier)
        End Sub
        Private Sub btnSupplierPanel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSupplierPanel.Click
            Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
            myEntityPanelService.OpenPanel(New Supplier)
        End Sub

        Private Sub btnCostCenterPanel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
            Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
            myEntityPanelService.OpenPanel(New CostCenter)
        End Sub
#End Region

#Region "IClipboardHandler Overrides"
        Public Overrides ReadOnly Property EnablePaste() As Boolean
            Get
                Dim data As IDataObject = Clipboard.GetDataObject
                If data.GetDataPresent((New Supplier).FullClassName) Then
                    If Not Me.ActiveControl Is Nothing Then
                        Select Case Me.ActiveControl.Name.ToLower
                            Case "txtsuppliercode", "txtsuppliername"
                                Return True
                        End Select
                    End If
                End If
                Return False
            End Get
        End Property
        Public Overrides Sub Paste(ByVal sender As Object, ByVal e As System.EventArgs)
            Dim data As IDataObject = Clipboard.GetDataObject
            If data.GetDataPresent((New Supplier).FullClassName) Then
                Dim id As Integer = CInt(data.GetData((New Supplier).FullClassName))
                Dim entity As New Supplier(id)
                If Not Me.ActiveControl Is Nothing Then
                    Select Case Me.ActiveControl.Name.ToLower
                        Case "txtsuppliercode", "txtsuppliername"
                            Me.SetSupplierDialog(entity)
                    End Select
                End If
            End If
        End Sub
#End Region

        Public Overrides Property Entities() As System.Collections.ArrayList
            Get
                Return MyBase.Entities
            End Get
            Set(ByVal Value As System.Collections.ArrayList)
                MyBase.Entities = Value
                For Each entity As ISimpleEntity In Value

                    If TypeOf entity Is APOpeningBalance Then
                        Dim obj As APOpeningBalance
                        obj = CType(entity, APOpeningBalance)
                        ' Account ...
                        If obj.Supplier.Originated Then
                            Me.SetSupplierDialog(obj.Supplier)
                            Me.txtSupplierCode.Enabled = False
                            Me.txtSupplierName.Enabled = False
                            Me.btnSupplierDialog.Enabled = False
                            Me.btnSupplierPanel.Enabled = False
                        End If
                    End If
                    If TypeOf entity Is Supplier Then
                        Me.SetSupplierDialog(entity)
                        Me.txtSupplierCode.Enabled = False
                        Me.txtSupplierName.Enabled = False
                        Me.btnSupplierDialog.Enabled = False
                        Me.btnSupplierPanel.Enabled = False
                    End If
                Next
            End Set
        End Property

        Private Sub APOnpeningBalanceFilterSubPanel_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        End Sub

        Private Sub grbDetail_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles grbDetail.Enter

        End Sub
    End Class
End Namespace

