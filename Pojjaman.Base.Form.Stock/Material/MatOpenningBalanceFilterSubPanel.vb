Imports Longkong.Pojjaman.BusinessLogic
Imports Longkong.Pojjaman.Services
Imports Longkong.Core.Services
Namespace Longkong.Pojjaman.Gui.Panels
    Public Class MatOpenningBalanceFilterSubPanel
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
        Friend WithEvents dtpDocDateStart As System.Windows.Forms.DateTimePicker
        Friend WithEvents dtpDocDateEnd As System.Windows.Forms.DateTimePicker
        Friend WithEvents cmbStatus As System.Windows.Forms.ComboBox
        Friend WithEvents lblStatus As System.Windows.Forms.Label
        Friend WithEvents ibtnShowLCIDialog As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents ibtnShowLCI As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents lblLCI As System.Windows.Forms.Label
        Friend WithEvents txtLCI As System.Windows.Forms.TextBox
        Friend WithEvents txtLCIName As System.Windows.Forms.TextBox
        Friend WithEvents grbMainDetail As Longkong.Pojjaman.Gui.Components.FixedGroupBox
        Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
        Friend WithEvents Validator As Longkong.Pojjaman.Gui.Components.PJMTextboxValidator
        Friend WithEvents btnToCostCenterPanel As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents txtToCostCenterCode As System.Windows.Forms.TextBox
        Friend WithEvents txtToCostCenterName As System.Windows.Forms.TextBox
        Friend WithEvents btnToCostCenterDialog As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents lblToCC As System.Windows.Forms.Label
        Friend WithEvents ibtnImportFromExcel As Longkong.Pojjaman.Gui.Components.ImageButton
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Me.components = New System.ComponentModel.Container
            Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(MatOpenningBalanceFilterSubPanel))
            Me.lblCode = New System.Windows.Forms.Label
            Me.txtCode = New System.Windows.Forms.TextBox
            Me.grbDetail = New Longkong.Pojjaman.Gui.Components.FixedGroupBox
            Me.ibtnImportFromExcel = New Longkong.Pojjaman.Gui.Components.ImageButton
            Me.grbDocDate = New Longkong.Pojjaman.Gui.Components.FixedGroupBox
            Me.lblDocDateStart = New System.Windows.Forms.Label
            Me.lblDocDateEnd = New System.Windows.Forms.Label
            Me.dtpDocDateStart = New System.Windows.Forms.DateTimePicker
            Me.dtpDocDateEnd = New System.Windows.Forms.DateTimePicker
            Me.btnSearch = New System.Windows.Forms.Button
            Me.btnReset = New System.Windows.Forms.Button
            Me.grbMainDetail = New Longkong.Pojjaman.Gui.Components.FixedGroupBox
            Me.cmbStatus = New System.Windows.Forms.ComboBox
            Me.lblStatus = New System.Windows.Forms.Label
            Me.btnToCostCenterPanel = New Longkong.Pojjaman.Gui.Components.ImageButton
            Me.txtToCostCenterCode = New System.Windows.Forms.TextBox
            Me.txtToCostCenterName = New System.Windows.Forms.TextBox
            Me.btnToCostCenterDialog = New Longkong.Pojjaman.Gui.Components.ImageButton
            Me.lblToCC = New System.Windows.Forms.Label
            Me.txtLCIName = New System.Windows.Forms.TextBox
            Me.txtLCI = New System.Windows.Forms.TextBox
            Me.lblLCI = New System.Windows.Forms.Label
            Me.ibtnShowLCI = New Longkong.Pojjaman.Gui.Components.ImageButton
            Me.ibtnShowLCIDialog = New Longkong.Pojjaman.Gui.Components.ImageButton
            Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider
            Me.Validator = New Longkong.Pojjaman.Gui.Components.PJMTextboxValidator(Me.components)
            Me.grbDetail.SuspendLayout()
            Me.grbDocDate.SuspendLayout()
            Me.grbMainDetail.SuspendLayout()
            Me.SuspendLayout()
            '
            'lblCode
            '
            Me.lblCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblCode.ForeColor = System.Drawing.Color.Black
            Me.lblCode.Location = New System.Drawing.Point(8, 16)
            Me.lblCode.Name = "lblCode"
            Me.lblCode.Size = New System.Drawing.Size(104, 18)
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
            Me.txtCode.Location = New System.Drawing.Point(112, 16)
            Me.Validator.SetMaxValue(Me.txtCode, "")
            Me.Validator.SetMinValue(Me.txtCode, "")
            Me.txtCode.Name = "txtCode"
            Me.Validator.SetRegularExpression(Me.txtCode, "")
            Me.Validator.SetRequired(Me.txtCode, False)
            Me.txtCode.Size = New System.Drawing.Size(224, 21)
            Me.txtCode.TabIndex = 0
            Me.txtCode.Text = ""
            '
            'grbDetail
            '
            Me.grbDetail.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.grbDetail.Controls.Add(Me.ibtnImportFromExcel)
            Me.grbDetail.Controls.Add(Me.grbDocDate)
            Me.grbDetail.Controls.Add(Me.btnSearch)
            Me.grbDetail.Controls.Add(Me.btnReset)
            Me.grbDetail.Controls.Add(Me.grbMainDetail)
            Me.grbDetail.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.grbDetail.Location = New System.Drawing.Point(8, 8)
            Me.grbDetail.Name = "grbDetail"
            Me.grbDetail.Size = New System.Drawing.Size(608, 144)
            Me.grbDetail.TabIndex = 0
            Me.grbDetail.TabStop = False
            '
            'ibtnImportFromExcel
            '
            Me.ibtnImportFromExcel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ibtnImportFromExcel.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.ibtnImportFromExcel.ForeColor = System.Drawing.SystemColors.Control
            Me.ibtnImportFromExcel.Image = CType(resources.GetObject("ibtnImportFromExcel.Image"), System.Drawing.Image)
            Me.ibtnImportFromExcel.Location = New System.Drawing.Point(378, 112)
            Me.ibtnImportFromExcel.Name = "ibtnImportFromExcel"
            Me.ibtnImportFromExcel.Size = New System.Drawing.Size(64, 24)
            Me.ibtnImportFromExcel.TabIndex = 191
            Me.ibtnImportFromExcel.TabStop = False
            Me.ibtnImportFromExcel.ThemedImage = CType(resources.GetObject("ibtnImportFromExcel.ThemedImage"), System.Drawing.Bitmap)
            '
            'grbDocDate
            '
            Me.grbDocDate.Controls.Add(Me.lblDocDateStart)
            Me.grbDocDate.Controls.Add(Me.lblDocDateEnd)
            Me.grbDocDate.Controls.Add(Me.dtpDocDateStart)
            Me.grbDocDate.Controls.Add(Me.dtpDocDateEnd)
            Me.grbDocDate.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.grbDocDate.Location = New System.Drawing.Point(368, 16)
            Me.grbDocDate.Name = "grbDocDate"
            Me.grbDocDate.Size = New System.Drawing.Size(224, 72)
            Me.grbDocDate.TabIndex = 2
            Me.grbDocDate.TabStop = False
            Me.grbDocDate.Text = "วันที่เอกสาร"
            '
            'lblDocDateStart
            '
            Me.lblDocDateStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblDocDateStart.ForeColor = System.Drawing.Color.Black
            Me.lblDocDateStart.Location = New System.Drawing.Point(8, 17)
            Me.lblDocDateStart.Name = "lblDocDateStart"
            Me.lblDocDateStart.Size = New System.Drawing.Size(72, 18)
            Me.lblDocDateStart.TabIndex = 11
            Me.lblDocDateStart.Text = "ตั้งแต่"
            Me.lblDocDateStart.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblDocDateEnd
            '
            Me.lblDocDateEnd.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblDocDateEnd.ForeColor = System.Drawing.Color.Black
            Me.lblDocDateEnd.Location = New System.Drawing.Point(8, 41)
            Me.lblDocDateEnd.Name = "lblDocDateEnd"
            Me.lblDocDateEnd.Size = New System.Drawing.Size(72, 18)
            Me.lblDocDateEnd.TabIndex = 11
            Me.lblDocDateEnd.Text = "End Date"
            Me.lblDocDateEnd.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'dtpDocDateStart
            '
            Me.dtpDocDateStart.Format = System.Windows.Forms.DateTimePickerFormat.Short
            Me.dtpDocDateStart.Location = New System.Drawing.Point(88, 16)
            Me.dtpDocDateStart.Name = "dtpDocDateStart"
            Me.dtpDocDateStart.Size = New System.Drawing.Size(120, 20)
            Me.dtpDocDateStart.TabIndex = 0
            '
            'dtpDocDateEnd
            '
            Me.dtpDocDateEnd.Format = System.Windows.Forms.DateTimePickerFormat.Short
            Me.dtpDocDateEnd.Location = New System.Drawing.Point(88, 40)
            Me.dtpDocDateEnd.Name = "dtpDocDateEnd"
            Me.dtpDocDateEnd.Size = New System.Drawing.Size(120, 20)
            Me.dtpDocDateEnd.TabIndex = 1
            '
            'btnSearch
            '
            Me.btnSearch.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.btnSearch.Location = New System.Drawing.Point(528, 112)
            Me.btnSearch.Name = "btnSearch"
            Me.btnSearch.TabIndex = 5
            Me.btnSearch.Text = "Search"
            '
            'btnReset
            '
            Me.btnReset.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.btnReset.Location = New System.Drawing.Point(448, 112)
            Me.btnReset.Name = "btnReset"
            Me.btnReset.TabIndex = 4
            Me.btnReset.Text = "Reset"
            '
            'grbMainDetail
            '
            Me.grbMainDetail.Controls.Add(Me.cmbStatus)
            Me.grbMainDetail.Controls.Add(Me.lblStatus)
            Me.grbMainDetail.Controls.Add(Me.btnToCostCenterPanel)
            Me.grbMainDetail.Controls.Add(Me.txtToCostCenterCode)
            Me.grbMainDetail.Controls.Add(Me.txtCode)
            Me.grbMainDetail.Controls.Add(Me.txtToCostCenterName)
            Me.grbMainDetail.Controls.Add(Me.lblCode)
            Me.grbMainDetail.Controls.Add(Me.btnToCostCenterDialog)
            Me.grbMainDetail.Controls.Add(Me.lblToCC)
            Me.grbMainDetail.Controls.Add(Me.txtLCIName)
            Me.grbMainDetail.Controls.Add(Me.txtLCI)
            Me.grbMainDetail.Controls.Add(Me.lblLCI)
            Me.grbMainDetail.Controls.Add(Me.ibtnShowLCI)
            Me.grbMainDetail.Controls.Add(Me.ibtnShowLCIDialog)
            Me.grbMainDetail.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.grbMainDetail.Location = New System.Drawing.Point(8, 16)
            Me.grbMainDetail.Name = "grbMainDetail"
            Me.grbMainDetail.Size = New System.Drawing.Size(352, 120)
            Me.grbMainDetail.TabIndex = 0
            Me.grbMainDetail.TabStop = False
            Me.grbMainDetail.Text = "รายละเอียดทั่วไป"
            '
            'cmbStatus
            '
            Me.cmbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cmbStatus.Location = New System.Drawing.Point(112, 64)
            Me.cmbStatus.Name = "cmbStatus"
            Me.cmbStatus.Size = New System.Drawing.Size(224, 21)
            Me.cmbStatus.TabIndex = 2
            '
            'lblStatus
            '
            Me.lblStatus.BackColor = System.Drawing.Color.Transparent
            Me.lblStatus.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblStatus.ForeColor = System.Drawing.SystemColors.WindowText
            Me.lblStatus.Location = New System.Drawing.Point(8, 64)
            Me.lblStatus.Name = "lblStatus"
            Me.lblStatus.Size = New System.Drawing.Size(104, 18)
            Me.lblStatus.TabIndex = 197
            Me.lblStatus.Text = "สถานะ:"
            Me.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'btnToCostCenterPanel
            '
            Me.btnToCostCenterPanel.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.btnToCostCenterPanel.Image = CType(resources.GetObject("btnToCostCenterPanel.Image"), System.Drawing.Image)
            Me.btnToCostCenterPanel.Location = New System.Drawing.Point(312, 40)
            Me.btnToCostCenterPanel.Name = "btnToCostCenterPanel"
            Me.btnToCostCenterPanel.Size = New System.Drawing.Size(24, 23)
            Me.btnToCostCenterPanel.TabIndex = 199
            Me.btnToCostCenterPanel.TabStop = False
            Me.btnToCostCenterPanel.ThemedImage = CType(resources.GetObject("btnToCostCenterPanel.ThemedImage"), System.Drawing.Bitmap)
            '
            'txtToCostCenterCode
            '
            Me.Validator.SetDataType(Me.txtToCostCenterCode, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtToCostCenterCode, "")
            Me.Validator.SetGotFocusBackColor(Me.txtToCostCenterCode, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtToCostCenterCode, System.Drawing.Color.Empty)
            Me.txtToCostCenterCode.Location = New System.Drawing.Point(112, 40)
            Me.Validator.SetMaxValue(Me.txtToCostCenterCode, "")
            Me.Validator.SetMinValue(Me.txtToCostCenterCode, "")
            Me.txtToCostCenterCode.Name = "txtToCostCenterCode"
            Me.Validator.SetRegularExpression(Me.txtToCostCenterCode, "")
            Me.Validator.SetRequired(Me.txtToCostCenterCode, False)
            Me.txtToCostCenterCode.Size = New System.Drawing.Size(80, 20)
            Me.txtToCostCenterCode.TabIndex = 1
            Me.txtToCostCenterCode.Text = ""
            '
            'txtToCostCenterName
            '
            Me.Validator.SetDataType(Me.txtToCostCenterName, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtToCostCenterName, "")
            Me.Validator.SetGotFocusBackColor(Me.txtToCostCenterName, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtToCostCenterName, System.Drawing.Color.Empty)
            Me.txtToCostCenterName.Location = New System.Drawing.Point(192, 40)
            Me.Validator.SetMaxValue(Me.txtToCostCenterName, "")
            Me.Validator.SetMinValue(Me.txtToCostCenterName, "")
            Me.txtToCostCenterName.Name = "txtToCostCenterName"
            Me.txtToCostCenterName.ReadOnly = True
            Me.Validator.SetRegularExpression(Me.txtToCostCenterName, "")
            Me.Validator.SetRequired(Me.txtToCostCenterName, False)
            Me.txtToCostCenterName.Size = New System.Drawing.Size(96, 20)
            Me.txtToCostCenterName.TabIndex = 196
            Me.txtToCostCenterName.TabStop = False
            Me.txtToCostCenterName.Text = ""
            '
            'btnToCostCenterDialog
            '
            Me.btnToCostCenterDialog.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.btnToCostCenterDialog.ForeColor = System.Drawing.SystemColors.Control
            Me.btnToCostCenterDialog.Image = CType(resources.GetObject("btnToCostCenterDialog.Image"), System.Drawing.Image)
            Me.btnToCostCenterDialog.Location = New System.Drawing.Point(288, 40)
            Me.btnToCostCenterDialog.Name = "btnToCostCenterDialog"
            Me.btnToCostCenterDialog.Size = New System.Drawing.Size(24, 23)
            Me.btnToCostCenterDialog.TabIndex = 201
            Me.btnToCostCenterDialog.TabStop = False
            Me.btnToCostCenterDialog.ThemedImage = CType(resources.GetObject("btnToCostCenterDialog.ThemedImage"), System.Drawing.Bitmap)
            '
            'lblToCC
            '
            Me.lblToCC.BackColor = System.Drawing.Color.Transparent
            Me.lblToCC.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblToCC.ForeColor = System.Drawing.SystemColors.WindowText
            Me.lblToCC.Location = New System.Drawing.Point(8, 40)
            Me.lblToCC.Name = "lblToCC"
            Me.lblToCC.Size = New System.Drawing.Size(104, 18)
            Me.lblToCC.TabIndex = 192
            Me.lblToCC.Text = "CostCenter:"
            Me.lblToCC.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtLCIName
            '
            Me.Validator.SetDataType(Me.txtLCIName, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtLCIName, "")
            Me.Validator.SetGotFocusBackColor(Me.txtLCIName, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtLCIName, System.Drawing.Color.Empty)
            Me.txtLCIName.Location = New System.Drawing.Point(192, 88)
            Me.Validator.SetMaxValue(Me.txtLCIName, "")
            Me.Validator.SetMinValue(Me.txtLCIName, "")
            Me.txtLCIName.Name = "txtLCIName"
            Me.txtLCIName.ReadOnly = True
            Me.Validator.SetRegularExpression(Me.txtLCIName, "")
            Me.Validator.SetRequired(Me.txtLCIName, False)
            Me.txtLCIName.Size = New System.Drawing.Size(96, 20)
            Me.txtLCIName.TabIndex = 204
            Me.txtLCIName.TabStop = False
            Me.txtLCIName.Text = ""
            '
            'txtLCI
            '
            Me.Validator.SetDataType(Me.txtLCI, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtLCI, "")
            Me.Validator.SetGotFocusBackColor(Me.txtLCI, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtLCI, System.Drawing.Color.Empty)
            Me.txtLCI.Location = New System.Drawing.Point(112, 88)
            Me.Validator.SetMaxValue(Me.txtLCI, "")
            Me.Validator.SetMinValue(Me.txtLCI, "")
            Me.txtLCI.Name = "txtLCI"
            Me.Validator.SetRegularExpression(Me.txtLCI, "")
            Me.Validator.SetRequired(Me.txtLCI, False)
            Me.txtLCI.Size = New System.Drawing.Size(80, 20)
            Me.txtLCI.TabIndex = 3
            Me.txtLCI.Text = ""
            '
            'lblLCI
            '
            Me.lblLCI.BackColor = System.Drawing.Color.Transparent
            Me.lblLCI.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblLCI.ForeColor = System.Drawing.SystemColors.WindowText
            Me.lblLCI.Location = New System.Drawing.Point(8, 88)
            Me.lblLCI.Name = "lblLCI"
            Me.lblLCI.Size = New System.Drawing.Size(104, 18)
            Me.lblLCI.TabIndex = 203
            Me.lblLCI.Text = "LCI:"
            Me.lblLCI.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'ibtnShowLCI
            '
            Me.ibtnShowLCI.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.ibtnShowLCI.Image = CType(resources.GetObject("ibtnShowLCI.Image"), System.Drawing.Image)
            Me.ibtnShowLCI.Location = New System.Drawing.Point(312, 88)
            Me.ibtnShowLCI.Name = "ibtnShowLCI"
            Me.ibtnShowLCI.Size = New System.Drawing.Size(24, 23)
            Me.ibtnShowLCI.TabIndex = 205
            Me.ibtnShowLCI.TabStop = False
            Me.ibtnShowLCI.ThemedImage = CType(resources.GetObject("ibtnShowLCI.ThemedImage"), System.Drawing.Bitmap)
            '
            'ibtnShowLCIDialog
            '
            Me.ibtnShowLCIDialog.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.ibtnShowLCIDialog.ForeColor = System.Drawing.SystemColors.Control
            Me.ibtnShowLCIDialog.Image = CType(resources.GetObject("ibtnShowLCIDialog.Image"), System.Drawing.Image)
            Me.ibtnShowLCIDialog.Location = New System.Drawing.Point(288, 88)
            Me.ibtnShowLCIDialog.Name = "ibtnShowLCIDialog"
            Me.ibtnShowLCIDialog.Size = New System.Drawing.Size(24, 23)
            Me.ibtnShowLCIDialog.TabIndex = 206
            Me.ibtnShowLCIDialog.TabStop = False
            Me.ibtnShowLCIDialog.ThemedImage = CType(resources.GetObject("ibtnShowLCIDialog.ThemedImage"), System.Drawing.Bitmap)
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
            'MatOpenningBalanceFilterSubPanel
            '
            Me.Controls.Add(Me.grbDetail)
            Me.Name = "MatOpenningBalanceFilterSubPanel"
            Me.Size = New System.Drawing.Size(616, 160)
            Me.grbDetail.ResumeLayout(False)
            Me.grbDocDate.ResumeLayout(False)
            Me.grbMainDetail.ResumeLayout(False)
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
        Private m_tocc As CostCenter
        Private m_lci As LCIItem
#End Region

#Region "Methods"
        Public Sub Initialize()
            PopulateStatus()
            ClearCriterias()
        End Sub
        Private Sub ClearCriterias()
            Me.txtCode.Text = ""
            Me.txtToCostCenterCode.Text = ""
            Me.txtToCostCenterName.Text = ""
            Me.m_tocc = New CostCenter

            Me.txtLCI.Text = ""
            Me.txtLCIName.Text = ""
            Me.m_lci = New LCIItem

            Me.dtpDocDateStart.Value = Now.Subtract(New TimeSpan(7, 0, 0, 0))
            Me.dtpDocDateEnd.Value = Now.Date

            cmbStatus.SelectedIndex = 3
        End Sub
        Private Sub PopulateStatus()
            CodeDescription.ListCodeDescriptionInComboBox(cmbStatus, "MatOpeningBalance_status", True)
        End Sub
        Public Sub SetLabelText()
            Me.grbDetail.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.MatOpenningBalanceFilterSubPanel.grbDetail}")
            Me.lblCode.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.MatOpenningBalanceFilterSubPanel.lblCode}")
            Me.btnSearch.Text = Me.StringParserService.Parse("${res:Global.SearchButtonText}")
            Me.btnReset.Text = Me.StringParserService.Parse("${res:Global.ResetButtonText}")
            Me.grbDocDate.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.MatOpenningBalanceFilterSubPanel.grbDocDate}")
            Me.lblDocDateStart.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.MatOpenningBalanceFilterSubPanel.lblDocDateStart}")
            Me.lblDocDateEnd.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.MatOpenningBalanceFilterSubPanel.lblDocDateEnd}")
            Me.lblToCC.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.MatOpenningBalanceFilterSubPanel.lblToCC}")
            Me.lblStatus.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.MatOpenningBalanceFilterSubPanel.lblStatus}")
            Me.lblLCI.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.MatOpenningBalanceFilterSubPanel.lblLCI}")
            Me.grbMainDetail.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.MatOpenningBalanceFilterSubPanel.grbMainDetail}")
        End Sub
        Public Overrides Function GetFilterArray() As Filter()
            Dim arr(6) As Filter
            arr(0) = New Filter("code", IIf(Me.txtCode.Text.Length = 0, DBNull.Value, Me.txtCode.Text))
            arr(1) = New Filter("tocc_id", IIf(Me.m_tocc.Valid, Me.m_tocc.Id, DBNull.Value))
            arr(2) = New Filter("docdatestart", Me.dtpDocDateStart.Value.Date)
            arr(3) = New Filter("docdateend", Me.dtpDocDateEnd.Value.Date)
            arr(4) = New Filter("status", IIf(cmbStatus.SelectedItem Is Nothing, DBNull.Value, CType(cmbStatus.SelectedItem, IdValuePair).Id))
            arr(5) = New Filter("lci_id", IIf(Me.m_lci.Valid, Me.m_lci.Id, DBNull.Value))
            arr(6) = New Filter("userRight", CType(ServiceManager.Services.GetService(GetType(SecurityService)), SecurityService).CurrentUser.Id)
            Return arr
        End Function
        Public Overrides ReadOnly Property SearchButton() As System.Windows.Forms.Button
            Get
                Return Me.btnSearch
            End Get
        End Property
#End Region

#Region "Event Handlers"
        Private Sub txtToCostCenterCode_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtToCostCenterCode.Validated
            CostCenter.GetCostCenter(txtToCostCenterCode, txtToCostCenterName, Me.m_tocc, CType(ServiceManager.Services.GetService(GetType(SecurityService)), SecurityService).CurrentUser.Id)
        End Sub
        Private Sub ibtnShowLCI_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnShowLCI.Click
            Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
            myEntityPanelService.OpenPanel(New LCIItem)
        End Sub

        Private Sub txtLCI_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtLCI.Validated
            LCIItem.GetLCIItem(txtLCI, txtLCIName, Me.m_lci)
        End Sub
        Private Sub SetLCi(ByVal e As ISimpleEntity)
            Me.txtLCI.Text = e.Code
            LCIItem.GetLCIItem(txtLCI, txtLCIName, Me.m_lci)
        End Sub
        Private Sub ibtnShowLCIDialog_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnShowLCIDialog.Click
            Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
            myEntityPanelService.OpenListDialog(New LCIItem, AddressOf SetLCi)
        End Sub
        Private Sub btnReset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReset.Click
            ClearCriterias()
            Me.btnSearch.PerformClick()
        End Sub
        Private Sub btnToCostCenterDialog_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnToCostCenterDialog.Click
            Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
            myEntityPanelService.OpenTreeDialog(New CostCenter, AddressOf SetToCostCenter)
        End Sub
        Private Sub SetToCostCenter(ByVal e As ISimpleEntity)
            Me.txtToCostCenterCode.Text = e.Code
            CostCenter.GetCostCenter(txtToCostCenterCode, txtToCostCenterName, Me.m_tocc, CType(ServiceManager.Services.GetService(GetType(SecurityService)), SecurityService).CurrentUser.Id)
        End Sub
        Private Sub btnToCostCenterPanel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnToCostCenterPanel.Click
            Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
            myEntityPanelService.OpenPanel(New CostCenter)
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
                        Case "txttocostcentercode", "txttocostcentername"
                            Return True
                    End Select
                End If
                If data.GetDataPresent((New LCIItem).FullClassName) Then
                    Select Case Me.ActiveControl.Name.ToLower
                        Case "txtlci", "txtlciname"
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
                    Case "txttocostcentercode", "txttocostcentername"
                        Me.SetToCostCenter(entity)
                End Select
            End If
            If data.GetDataPresent((New LCIItem).FullClassName) Then
                Dim id As Integer = CInt(data.GetData((New LCIItem).FullClassName))
                Dim entity As New LCIItem(id)
                Select Case Me.ActiveControl.Name.ToLower
                    Case "txtlci", "txtlciname"
                        Me.SetLCi(entity)
                End Select
            End If
        End Sub
#End Region

        Private Sub ibtnImportFromExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnImportFromExcel.Click
            Dim opdlg As New OpenFileDialog
            opdlg.Filter = "Excel files (*.xls)|*.xls"
            If opdlg.ShowDialog = DialogResult.OK Then
                Dim i As New Excel.Import(opdlg.FileName)
                i.Where = "[Level] is not null"
                Dim range As String = InputBox("Please specify Work Sheet/Range:", "Work Sheet/Range")
                i.Range = range
                i.Fields = "[LV1],[LV2],[LV3],[LV4],[LV5],[Level],[Name],[AltName],[FairPrice],[Unit],[Unit1],[Unit2],[Unit3],[Conv1],[Conv2],[Conv3],[Qty],[CC]"
                Dim dt As DataTable = i.Query()
                LCIItem.Import(dt)
            End If
        End Sub

        Private Sub lblDocDateStart_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblDocDateStart.Click

        End Sub
    End Class
End Namespace

