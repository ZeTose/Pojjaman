Imports Longkong.Pojjaman.BusinessLogic
Imports longkong.Pojjaman.Services
Imports Longkong.Core.Services

Namespace Longkong.Pojjaman.Gui.Panels
    Public Class Rpt276FilterSubPanel
        Inherits AbstractFilterSubPanel
        Implements IReportFilterSubPanel

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
        Friend WithEvents grbMaster As Longkong.Pojjaman.Gui.Components.FixedGroupBox
        Friend WithEvents btnSearch As System.Windows.Forms.Button
        Friend WithEvents btnReset As System.Windows.Forms.Button
    Friend WithEvents Validator As Longkong.Pojjaman.Gui.Components.PJMTextboxValidator
        Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents txtTemp As System.Windows.Forms.TextBox
    Friend WithEvents grbDisplay As Longkong.Pojjaman.Gui.Components.FixedGroupBox
    Friend WithEvents cmbStatus As System.Windows.Forms.ComboBox
    Friend WithEvents grbDetail As Longkong.Pojjaman.Gui.Components.FixedGroupBox
    Friend WithEvents txtDueDateEnd As System.Windows.Forms.TextBox
    Friend WithEvents txtDueDateStart As System.Windows.Forms.TextBox
    Friend WithEvents dtpDueDateStart As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpDueDateEnd As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblDueDateStart As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents chkIncludeChildSupplierGroup As System.Windows.Forms.CheckBox
    Friend WithEvents btnSpgCodeStart As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents txtSpgCodeStart As System.Windows.Forms.TextBox
    Friend WithEvents lblSpgStart As System.Windows.Forms.Label
    Friend WithEvents txtSupplierGroupName As System.Windows.Forms.TextBox
    Friend WithEvents cmbDocStatus As System.Windows.Forms.ComboBox
    Friend WithEvents lblDocStatus As System.Windows.Forms.Label
    Friend WithEvents btnSuppliEndFind As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents txtSuppliCodeEnd As System.Windows.Forms.TextBox
    Friend WithEvents lblSuppliEnd As System.Windows.Forms.Label
    Friend WithEvents btnSuppliStartFind As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents txtSuppliCodeStart As System.Windows.Forms.TextBox
    Friend WithEvents lblSuppliStart As System.Windows.Forms.Label
    Friend WithEvents chkIncludeChildren As System.Windows.Forms.CheckBox
    Friend WithEvents btnCCCodeStart As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents txtCCCodeStart As System.Windows.Forms.TextBox
    Friend WithEvents lblCCStart As System.Windows.Forms.Label
    Friend WithEvents txtCostCenterName As System.Windows.Forms.TextBox
    Friend WithEvents txtDocDateEnd As System.Windows.Forms.TextBox
    Friend WithEvents txtDocDateStart As System.Windows.Forms.TextBox
    Friend WithEvents dtpDocDateStart As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpDocDateEnd As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblDocDateStart As System.Windows.Forms.Label
    Friend WithEvents lblDocDateEnd As System.Windows.Forms.Label
    Friend WithEvents txtPersonReceiveCode As System.Windows.Forms.TextBox
    Friend WithEvents lblPersonReceive As System.Windows.Forms.Label
    Friend WithEvents txtPersonReceiveName As System.Windows.Forms.TextBox
    Friend WithEvents btnPersonReceiveDialog As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents lblStatus As System.Windows.Forms.Label
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
      Me.components = New System.ComponentModel.Container()
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Rpt276FilterSubPanel))
      Me.grbMaster = New Longkong.Pojjaman.Gui.Components.FixedGroupBox()
      Me.btnSearch = New System.Windows.Forms.Button()
      Me.btnReset = New System.Windows.Forms.Button()
      Me.grbDisplay = New Longkong.Pojjaman.Gui.Components.FixedGroupBox()
      Me.cmbStatus = New System.Windows.Forms.ComboBox()
      Me.lblStatus = New System.Windows.Forms.Label()
      Me.txtTemp = New System.Windows.Forms.TextBox()
      Me.Validator = New Longkong.Pojjaman.Gui.Components.PJMTextboxValidator()
      Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider()
      Me.lblDocDateEnd = New System.Windows.Forms.Label()
      Me.lblDocDateStart = New System.Windows.Forms.Label()
      Me.dtpDocDateEnd = New System.Windows.Forms.DateTimePicker()
      Me.dtpDocDateStart = New System.Windows.Forms.DateTimePicker()
      Me.txtDocDateStart = New System.Windows.Forms.TextBox()
      Me.txtDocDateEnd = New System.Windows.Forms.TextBox()
      Me.txtCostCenterName = New System.Windows.Forms.TextBox()
      Me.lblCCStart = New System.Windows.Forms.Label()
      Me.txtCCCodeStart = New System.Windows.Forms.TextBox()
      Me.btnCCCodeStart = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.chkIncludeChildren = New System.Windows.Forms.CheckBox()
      Me.lblSuppliStart = New System.Windows.Forms.Label()
      Me.txtSuppliCodeStart = New System.Windows.Forms.TextBox()
      Me.btnSuppliStartFind = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.lblSuppliEnd = New System.Windows.Forms.Label()
      Me.txtSuppliCodeEnd = New System.Windows.Forms.TextBox()
      Me.btnSuppliEndFind = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.lblDocStatus = New System.Windows.Forms.Label()
      Me.cmbDocStatus = New System.Windows.Forms.ComboBox()
      Me.txtSupplierGroupName = New System.Windows.Forms.TextBox()
      Me.lblSpgStart = New System.Windows.Forms.Label()
      Me.txtSpgCodeStart = New System.Windows.Forms.TextBox()
      Me.btnSpgCodeStart = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.chkIncludeChildSupplierGroup = New System.Windows.Forms.CheckBox()
      Me.Label2 = New System.Windows.Forms.Label()
      Me.lblDueDateStart = New System.Windows.Forms.Label()
      Me.dtpDueDateEnd = New System.Windows.Forms.DateTimePicker()
      Me.dtpDueDateStart = New System.Windows.Forms.DateTimePicker()
      Me.txtDueDateStart = New System.Windows.Forms.TextBox()
      Me.txtDueDateEnd = New System.Windows.Forms.TextBox()
      Me.grbDetail = New Longkong.Pojjaman.Gui.Components.FixedGroupBox()
      Me.txtPersonReceiveCode = New System.Windows.Forms.TextBox()
      Me.lblPersonReceive = New System.Windows.Forms.Label()
      Me.txtPersonReceiveName = New System.Windows.Forms.TextBox()
      Me.btnPersonReceiveDialog = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.grbMaster.SuspendLayout()
      Me.grbDisplay.SuspendLayout()
      Me.grbDetail.SuspendLayout()
      Me.SuspendLayout()
      '
      'grbMaster
      '
      Me.grbMaster.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                  Or System.Windows.Forms.AnchorStyles.Left) _
                  Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.grbMaster.Controls.Add(Me.btnSearch)
      Me.grbMaster.Controls.Add(Me.btnReset)
      Me.grbMaster.Controls.Add(Me.grbDisplay)
      Me.grbMaster.Controls.Add(Me.txtTemp)
      Me.grbMaster.Controls.Add(Me.grbDetail)
      Me.grbMaster.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.grbMaster.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.grbMaster.Location = New System.Drawing.Point(8, 0)
      Me.grbMaster.Name = "grbMaster"
      Me.grbMaster.Size = New System.Drawing.Size(768, 206)
      Me.grbMaster.TabIndex = 0
      Me.grbMaster.TabStop = False
      Me.grbMaster.Text = "เช็ครับ"
      '
      'btnSearch
      '
      Me.btnSearch.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnSearch.Location = New System.Drawing.Point(680, 166)
      Me.btnSearch.Name = "btnSearch"
      Me.btnSearch.Size = New System.Drawing.Size(75, 23)
      Me.btnSearch.TabIndex = 2
      Me.btnSearch.Text = "ค้นหา"
      '
      'btnReset
      '
      Me.btnReset.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnReset.Location = New System.Drawing.Point(600, 166)
      Me.btnReset.Name = "btnReset"
      Me.btnReset.Size = New System.Drawing.Size(75, 23)
      Me.btnReset.TabIndex = 1
      Me.btnReset.TabStop = False
      Me.btnReset.Text = "เคลียร์"
      '
      'grbDisplay
      '
      Me.grbDisplay.Controls.Add(Me.cmbStatus)
      Me.grbDisplay.Controls.Add(Me.lblStatus)
      Me.grbDisplay.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.grbDisplay.Location = New System.Drawing.Point(464, 16)
      Me.grbDisplay.Name = "grbDisplay"
      Me.grbDisplay.Size = New System.Drawing.Size(296, 46)
      Me.grbDisplay.TabIndex = 6
      Me.grbDisplay.TabStop = False
      Me.grbDisplay.Text = "รูปแบบการแสดงผล"
      '
      'cmbStatus
      '
      Me.cmbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbStatus.Location = New System.Drawing.Point(72, 16)
      Me.cmbStatus.Name = "cmbStatus"
      Me.cmbStatus.Size = New System.Drawing.Size(208, 21)
      Me.cmbStatus.TabIndex = 1
      '
      'lblStatus
      '
      Me.lblStatus.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblStatus.ForeColor = System.Drawing.Color.Black
      Me.lblStatus.Location = New System.Drawing.Point(8, 17)
      Me.lblStatus.Name = "lblStatus"
      Me.lblStatus.Size = New System.Drawing.Size(56, 18)
      Me.lblStatus.TabIndex = 0
      Me.lblStatus.Text = "สถานะ"
      Me.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'txtTemp
      '
      Me.Validator.SetDataType(Me.txtTemp, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtTemp, "")
      Me.Validator.SetGotFocusBackColor(Me.txtTemp, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtTemp, System.Drawing.Color.Empty)
      Me.txtTemp.Location = New System.Drawing.Point(512, 32)
      Me.txtTemp.MaxLength = 255
      Me.Validator.SetMinValue(Me.txtTemp, "")
      Me.txtTemp.Name = "txtTemp"
      Me.txtTemp.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtTemp, "")
      Me.Validator.SetRequired(Me.txtTemp, False)
      Me.txtTemp.Size = New System.Drawing.Size(104, 21)
      Me.txtTemp.TabIndex = 3
      Me.txtTemp.Visible = False
      '
      'Validator
      '
      Me.Validator.BackcolorChanging = False
      Me.Validator.DataTable = Nothing
      Me.Validator.ErrorProvider = Me.ErrorProvider1
      Me.Validator.GotFocusBackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
      Me.Validator.HasNewRow = False
      Me.Validator.InvalidBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
      '
      'ErrorProvider1
      '
      Me.ErrorProvider1.ContainerControl = Me
      '
      'lblDocDateEnd
      '
      Me.lblDocDateEnd.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblDocDateEnd.ForeColor = System.Drawing.Color.Black
      Me.lblDocDateEnd.Location = New System.Drawing.Point(264, 16)
      Me.lblDocDateEnd.Name = "lblDocDateEnd"
      Me.lblDocDateEnd.Size = New System.Drawing.Size(24, 18)
      Me.lblDocDateEnd.TabIndex = 3
      Me.lblDocDateEnd.Text = "ถึง"
      Me.lblDocDateEnd.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
      '
      'lblDocDateStart
      '
      Me.lblDocDateStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblDocDateStart.ForeColor = System.Drawing.Color.Black
      Me.lblDocDateStart.Location = New System.Drawing.Point(16, 16)
      Me.lblDocDateStart.Name = "lblDocDateStart"
      Me.lblDocDateStart.Size = New System.Drawing.Size(112, 18)
      Me.lblDocDateStart.TabIndex = 0
      Me.lblDocDateStart.Text = "ตั้งแต่วันที่"
      Me.lblDocDateStart.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'dtpDocDateEnd
      '
      Me.dtpDocDateEnd.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
      Me.dtpDocDateEnd.Location = New System.Drawing.Point(296, 16)
      Me.dtpDocDateEnd.Name = "dtpDocDateEnd"
      Me.dtpDocDateEnd.Size = New System.Drawing.Size(120, 21)
      Me.dtpDocDateEnd.TabIndex = 5
      Me.dtpDocDateEnd.TabStop = False
      '
      'dtpDocDateStart
      '
      Me.dtpDocDateStart.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
      Me.dtpDocDateStart.Location = New System.Drawing.Point(136, 16)
      Me.dtpDocDateStart.Name = "dtpDocDateStart"
      Me.dtpDocDateStart.Size = New System.Drawing.Size(120, 21)
      Me.dtpDocDateStart.TabIndex = 2
      Me.dtpDocDateStart.TabStop = False
      '
      'txtDocDateStart
      '
      Me.Validator.SetDataType(Me.txtDocDateStart, Longkong.Pojjaman.Gui.Components.DataTypeConstants.DateTimeType)
      Me.Validator.SetDisplayName(Me.txtDocDateStart, "")
      Me.Validator.SetGotFocusBackColor(Me.txtDocDateStart, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtDocDateStart, -15)
      Me.Validator.SetInvalidBackColor(Me.txtDocDateStart, System.Drawing.Color.Empty)
      Me.txtDocDateStart.Location = New System.Drawing.Point(136, 16)
      Me.txtDocDateStart.MaxLength = 10
      Me.Validator.SetMinValue(Me.txtDocDateStart, "")
      Me.txtDocDateStart.Name = "txtDocDateStart"
      Me.Validator.SetRegularExpression(Me.txtDocDateStart, "")
      Me.Validator.SetRequired(Me.txtDocDateStart, False)
      Me.txtDocDateStart.Size = New System.Drawing.Size(99, 21)
      Me.txtDocDateStart.TabIndex = 1
      '
      'txtDocDateEnd
      '
      Me.Validator.SetDataType(Me.txtDocDateEnd, Longkong.Pojjaman.Gui.Components.DataTypeConstants.DateTimeType)
      Me.Validator.SetDisplayName(Me.txtDocDateEnd, "")
      Me.Validator.SetGotFocusBackColor(Me.txtDocDateEnd, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtDocDateEnd, -15)
      Me.Validator.SetInvalidBackColor(Me.txtDocDateEnd, System.Drawing.Color.Empty)
      Me.txtDocDateEnd.Location = New System.Drawing.Point(296, 16)
      Me.txtDocDateEnd.MaxLength = 10
      Me.Validator.SetMinValue(Me.txtDocDateEnd, "")
      Me.txtDocDateEnd.Name = "txtDocDateEnd"
      Me.Validator.SetRegularExpression(Me.txtDocDateEnd, "")
      Me.Validator.SetRequired(Me.txtDocDateEnd, False)
      Me.txtDocDateEnd.Size = New System.Drawing.Size(99, 21)
      Me.txtDocDateEnd.TabIndex = 4
      '
      'txtCostCenterName
      '
      Me.Validator.SetDataType(Me.txtCostCenterName, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtCostCenterName, "")
      Me.txtCostCenterName.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtCostCenterName, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtCostCenterName, -15)
      Me.Validator.SetInvalidBackColor(Me.txtCostCenterName, System.Drawing.Color.Empty)
      Me.txtCostCenterName.Location = New System.Drawing.Point(256, 111)
      Me.txtCostCenterName.MaxLength = 50
      Me.Validator.SetMinValue(Me.txtCostCenterName, "")
      Me.txtCostCenterName.Name = "txtCostCenterName"
      Me.txtCostCenterName.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtCostCenterName, "")
      Me.Validator.SetRequired(Me.txtCostCenterName, False)
      Me.txtCostCenterName.Size = New System.Drawing.Size(160, 21)
      Me.txtCostCenterName.TabIndex = 15
      '
      'lblCCStart
      '
      Me.lblCCStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblCCStart.ForeColor = System.Drawing.Color.Black
      Me.lblCCStart.Location = New System.Drawing.Point(16, 111)
      Me.lblCCStart.Name = "lblCCStart"
      Me.lblCCStart.Size = New System.Drawing.Size(112, 18)
      Me.lblCCStart.TabIndex = 14
      Me.lblCCStart.Text = "Cost Center"
      Me.lblCCStart.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'txtCCCodeStart
      '
      Me.Validator.SetDataType(Me.txtCCCodeStart, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtCCCodeStart, "")
      Me.txtCCCodeStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtCCCodeStart, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtCCCodeStart, -15)
      Me.Validator.SetInvalidBackColor(Me.txtCCCodeStart, System.Drawing.Color.Empty)
      Me.txtCCCodeStart.Location = New System.Drawing.Point(136, 111)
      Me.txtCCCodeStart.MaxLength = 50
      Me.Validator.SetMinValue(Me.txtCCCodeStart, "")
      Me.txtCCCodeStart.Name = "txtCCCodeStart"
      Me.Validator.SetRegularExpression(Me.txtCCCodeStart, "")
      Me.Validator.SetRequired(Me.txtCCCodeStart, False)
      Me.txtCCCodeStart.Size = New System.Drawing.Size(96, 21)
      Me.txtCCCodeStart.TabIndex = 11
      '
      'btnCCCodeStart
      '
      Me.btnCCCodeStart.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnCCCodeStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.btnCCCodeStart.ForeColor = System.Drawing.SystemColors.Control
      Me.btnCCCodeStart.Location = New System.Drawing.Point(232, 111)
      Me.btnCCCodeStart.Name = "btnCCCodeStart"
      Me.btnCCCodeStart.Size = New System.Drawing.Size(24, 22)
      Me.btnCCCodeStart.TabIndex = 22
      Me.btnCCCodeStart.TabStop = False
      Me.btnCCCodeStart.ThemedImage = CType(resources.GetObject("btnCCCodeStart.ThemedImage"), System.Drawing.Bitmap)
      '
      'chkIncludeChildren
      '
      Me.chkIncludeChildren.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.chkIncludeChildren.Location = New System.Drawing.Point(422, 111)
      Me.chkIncludeChildren.Name = "chkIncludeChildren"
      Me.chkIncludeChildren.Size = New System.Drawing.Size(128, 21)
      Me.chkIncludeChildren.TabIndex = 12
      Me.chkIncludeChildren.Text = "รวม Cost Center ลูก"
      '
      'lblSuppliStart
      '
      Me.lblSuppliStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblSuppliStart.ForeColor = System.Drawing.Color.Black
      Me.lblSuppliStart.Location = New System.Drawing.Point(16, 88)
      Me.lblSuppliStart.Name = "lblSuppliStart"
      Me.lblSuppliStart.Size = New System.Drawing.Size(112, 18)
      Me.lblSuppliStart.TabIndex = 19
      Me.lblSuppliStart.Text = "ผู้ขาย"
      Me.lblSuppliStart.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'txtSuppliCodeStart
      '
      Me.Validator.SetDataType(Me.txtSuppliCodeStart, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtSuppliCodeStart, "")
      Me.txtSuppliCodeStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtSuppliCodeStart, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtSuppliCodeStart, -15)
      Me.Validator.SetInvalidBackColor(Me.txtSuppliCodeStart, System.Drawing.Color.Empty)
      Me.txtSuppliCodeStart.Location = New System.Drawing.Point(136, 88)
      Me.Validator.SetMinValue(Me.txtSuppliCodeStart, "")
      Me.txtSuppliCodeStart.Name = "txtSuppliCodeStart"
      Me.Validator.SetRegularExpression(Me.txtSuppliCodeStart, "")
      Me.Validator.SetRequired(Me.txtSuppliCodeStart, False)
      Me.txtSuppliCodeStart.Size = New System.Drawing.Size(96, 21)
      Me.txtSuppliCodeStart.TabIndex = 8
      '
      'btnSuppliStartFind
      '
      Me.btnSuppliStartFind.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnSuppliStartFind.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.btnSuppliStartFind.ForeColor = System.Drawing.SystemColors.Control
      Me.btnSuppliStartFind.Location = New System.Drawing.Point(232, 88)
      Me.btnSuppliStartFind.Name = "btnSuppliStartFind"
      Me.btnSuppliStartFind.Size = New System.Drawing.Size(24, 22)
      Me.btnSuppliStartFind.TabIndex = 20
      Me.btnSuppliStartFind.TabStop = False
      Me.btnSuppliStartFind.ThemedImage = CType(resources.GetObject("btnSuppliStartFind.ThemedImage"), System.Drawing.Bitmap)
      '
      'lblSuppliEnd
      '
      Me.lblSuppliEnd.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblSuppliEnd.ForeColor = System.Drawing.Color.Black
      Me.lblSuppliEnd.Location = New System.Drawing.Point(264, 88)
      Me.lblSuppliEnd.Name = "lblSuppliEnd"
      Me.lblSuppliEnd.Size = New System.Drawing.Size(24, 18)
      Me.lblSuppliEnd.TabIndex = 22
      Me.lblSuppliEnd.Text = "ถึง"
      Me.lblSuppliEnd.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
      '
      'txtSuppliCodeEnd
      '
      Me.Validator.SetDataType(Me.txtSuppliCodeEnd, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtSuppliCodeEnd, "")
      Me.txtSuppliCodeEnd.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtSuppliCodeEnd, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtSuppliCodeEnd, -15)
      Me.Validator.SetInvalidBackColor(Me.txtSuppliCodeEnd, System.Drawing.Color.Empty)
      Me.txtSuppliCodeEnd.Location = New System.Drawing.Point(296, 88)
      Me.Validator.SetMinValue(Me.txtSuppliCodeEnd, "")
      Me.txtSuppliCodeEnd.Name = "txtSuppliCodeEnd"
      Me.Validator.SetRegularExpression(Me.txtSuppliCodeEnd, "")
      Me.Validator.SetRequired(Me.txtSuppliCodeEnd, False)
      Me.txtSuppliCodeEnd.Size = New System.Drawing.Size(96, 21)
      Me.txtSuppliCodeEnd.TabIndex = 9
      '
      'btnSuppliEndFind
      '
      Me.btnSuppliEndFind.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnSuppliEndFind.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.btnSuppliEndFind.ForeColor = System.Drawing.SystemColors.Control
      Me.btnSuppliEndFind.Location = New System.Drawing.Point(392, 88)
      Me.btnSuppliEndFind.Name = "btnSuppliEndFind"
      Me.btnSuppliEndFind.Size = New System.Drawing.Size(24, 22)
      Me.btnSuppliEndFind.TabIndex = 21
      Me.btnSuppliEndFind.TabStop = False
      Me.btnSuppliEndFind.ThemedImage = CType(resources.GetObject("btnSuppliEndFind.ThemedImage"), System.Drawing.Bitmap)
      '
      'lblDocStatus
      '
      Me.lblDocStatus.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblDocStatus.ForeColor = System.Drawing.Color.Black
      Me.lblDocStatus.Location = New System.Drawing.Point(48, 160)
      Me.lblDocStatus.Name = "lblDocStatus"
      Me.lblDocStatus.Size = New System.Drawing.Size(80, 18)
      Me.lblDocStatus.TabIndex = 31
      Me.lblDocStatus.Text = "สถานะเอกสาร"
      Me.lblDocStatus.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'cmbDocStatus
      '
      Me.cmbDocStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbDocStatus.Location = New System.Drawing.Point(136, 160)
      Me.cmbDocStatus.Name = "cmbDocStatus"
      Me.cmbDocStatus.Size = New System.Drawing.Size(120, 21)
      Me.cmbDocStatus.TabIndex = 10
      '
      'txtSupplierGroupName
      '
      Me.Validator.SetDataType(Me.txtSupplierGroupName, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtSupplierGroupName, "")
      Me.txtSupplierGroupName.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtSupplierGroupName, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtSupplierGroupName, -15)
      Me.Validator.SetInvalidBackColor(Me.txtSupplierGroupName, System.Drawing.Color.Empty)
      Me.txtSupplierGroupName.Location = New System.Drawing.Point(256, 64)
      Me.txtSupplierGroupName.MaxLength = 50
      Me.Validator.SetMinValue(Me.txtSupplierGroupName, "")
      Me.txtSupplierGroupName.Name = "txtSupplierGroupName"
      Me.txtSupplierGroupName.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtSupplierGroupName, "")
      Me.Validator.SetRequired(Me.txtSupplierGroupName, False)
      Me.txtSupplierGroupName.Size = New System.Drawing.Size(160, 21)
      Me.txtSupplierGroupName.TabIndex = 36
      '
      'lblSpgStart
      '
      Me.lblSpgStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblSpgStart.ForeColor = System.Drawing.Color.Black
      Me.lblSpgStart.Location = New System.Drawing.Point(40, 64)
      Me.lblSpgStart.Name = "lblSpgStart"
      Me.lblSpgStart.Size = New System.Drawing.Size(88, 18)
      Me.lblSpgStart.TabIndex = 35
      Me.lblSpgStart.Text = "กลุ่มผู้ขาย"
      Me.lblSpgStart.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'txtSpgCodeStart
      '
      Me.Validator.SetDataType(Me.txtSpgCodeStart, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtSpgCodeStart, "")
      Me.txtSpgCodeStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtSpgCodeStart, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtSpgCodeStart, -15)
      Me.Validator.SetInvalidBackColor(Me.txtSpgCodeStart, System.Drawing.Color.Empty)
      Me.txtSpgCodeStart.Location = New System.Drawing.Point(136, 64)
      Me.txtSpgCodeStart.MaxLength = 50
      Me.Validator.SetMinValue(Me.txtSpgCodeStart, "")
      Me.txtSpgCodeStart.Name = "txtSpgCodeStart"
      Me.Validator.SetRegularExpression(Me.txtSpgCodeStart, "")
      Me.Validator.SetRequired(Me.txtSpgCodeStart, False)
      Me.txtSpgCodeStart.Size = New System.Drawing.Size(96, 21)
      Me.txtSpgCodeStart.TabIndex = 6
      '
      'btnSpgCodeStart
      '
      Me.btnSpgCodeStart.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnSpgCodeStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.btnSpgCodeStart.ForeColor = System.Drawing.SystemColors.Control
      Me.btnSpgCodeStart.Location = New System.Drawing.Point(232, 64)
      Me.btnSpgCodeStart.Name = "btnSpgCodeStart"
      Me.btnSpgCodeStart.Size = New System.Drawing.Size(24, 22)
      Me.btnSpgCodeStart.TabIndex = 19
      Me.btnSpgCodeStart.TabStop = False
      Me.btnSpgCodeStart.ThemedImage = CType(resources.GetObject("btnSpgCodeStart.ThemedImage"), System.Drawing.Bitmap)
      '
      'chkIncludeChildSupplierGroup
      '
      Me.chkIncludeChildSupplierGroup.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.chkIncludeChildSupplierGroup.Location = New System.Drawing.Point(422, 64)
      Me.chkIncludeChildSupplierGroup.Name = "chkIncludeChildSupplierGroup"
      Me.chkIncludeChildSupplierGroup.Size = New System.Drawing.Size(128, 21)
      Me.chkIncludeChildSupplierGroup.TabIndex = 7
      Me.chkIncludeChildSupplierGroup.Text = "รวมกลุ่มผู้ขายลูก"
      '
      'Label2
      '
      Me.Label2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Label2.ForeColor = System.Drawing.Color.Black
      Me.Label2.Location = New System.Drawing.Point(264, 41)
      Me.Label2.Name = "Label2"
      Me.Label2.Size = New System.Drawing.Size(24, 18)
      Me.Label2.TabIndex = 40
      Me.Label2.Text = "ถึง"
      Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
      '
      'lblDueDateStart
      '
      Me.lblDueDateStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblDueDateStart.ForeColor = System.Drawing.Color.Black
      Me.lblDueDateStart.Location = New System.Drawing.Point(8, 41)
      Me.lblDueDateStart.Name = "lblDueDateStart"
      Me.lblDueDateStart.Size = New System.Drawing.Size(120, 18)
      Me.lblDueDateStart.TabIndex = 37
      Me.lblDueDateStart.Text = "ตั้งแต่วันที่ครบกำหนด"
      Me.lblDueDateStart.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'dtpDueDateEnd
      '
      Me.dtpDueDateEnd.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
      Me.dtpDueDateEnd.Location = New System.Drawing.Point(296, 41)
      Me.dtpDueDateEnd.Name = "dtpDueDateEnd"
      Me.dtpDueDateEnd.Size = New System.Drawing.Size(120, 21)
      Me.dtpDueDateEnd.TabIndex = 42
      Me.dtpDueDateEnd.TabStop = False
      '
      'dtpDueDateStart
      '
      Me.dtpDueDateStart.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
      Me.dtpDueDateStart.Location = New System.Drawing.Point(136, 41)
      Me.dtpDueDateStart.Name = "dtpDueDateStart"
      Me.dtpDueDateStart.Size = New System.Drawing.Size(120, 21)
      Me.dtpDueDateStart.TabIndex = 39
      Me.dtpDueDateStart.TabStop = False
      '
      'txtDueDateStart
      '
      Me.Validator.SetDataType(Me.txtDueDateStart, Longkong.Pojjaman.Gui.Components.DataTypeConstants.DateTimeType)
      Me.Validator.SetDisplayName(Me.txtDueDateStart, "")
      Me.Validator.SetGotFocusBackColor(Me.txtDueDateStart, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtDueDateStart, -15)
      Me.Validator.SetInvalidBackColor(Me.txtDueDateStart, System.Drawing.Color.Empty)
      Me.txtDueDateStart.Location = New System.Drawing.Point(136, 41)
      Me.txtDueDateStart.MaxLength = 10
      Me.Validator.SetMinValue(Me.txtDueDateStart, "")
      Me.txtDueDateStart.Name = "txtDueDateStart"
      Me.Validator.SetRegularExpression(Me.txtDueDateStart, "")
      Me.Validator.SetRequired(Me.txtDueDateStart, False)
      Me.txtDueDateStart.Size = New System.Drawing.Size(99, 21)
      Me.txtDueDateStart.TabIndex = 43
      '
      'txtDueDateEnd
      '
      Me.Validator.SetDataType(Me.txtDueDateEnd, Longkong.Pojjaman.Gui.Components.DataTypeConstants.DateTimeType)
      Me.Validator.SetDisplayName(Me.txtDueDateEnd, "")
      Me.Validator.SetGotFocusBackColor(Me.txtDueDateEnd, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtDueDateEnd, -15)
      Me.Validator.SetInvalidBackColor(Me.txtDueDateEnd, System.Drawing.Color.Empty)
      Me.txtDueDateEnd.Location = New System.Drawing.Point(296, 41)
      Me.txtDueDateEnd.MaxLength = 10
      Me.Validator.SetMinValue(Me.txtDueDateEnd, "")
      Me.txtDueDateEnd.Name = "txtDueDateEnd"
      Me.Validator.SetRegularExpression(Me.txtDueDateEnd, "")
      Me.Validator.SetRequired(Me.txtDueDateEnd, False)
      Me.txtDueDateEnd.Size = New System.Drawing.Size(99, 21)
      Me.txtDueDateEnd.TabIndex = 44
      '
      'grbDetail
      '
      Me.grbDetail.Controls.Add(Me.txtPersonReceiveCode)
      Me.grbDetail.Controls.Add(Me.lblPersonReceive)
      Me.grbDetail.Controls.Add(Me.txtPersonReceiveName)
      Me.grbDetail.Controls.Add(Me.btnPersonReceiveDialog)
      Me.grbDetail.Controls.Add(Me.txtDueDateEnd)
      Me.grbDetail.Controls.Add(Me.txtDueDateStart)
      Me.grbDetail.Controls.Add(Me.dtpDueDateStart)
      Me.grbDetail.Controls.Add(Me.dtpDueDateEnd)
      Me.grbDetail.Controls.Add(Me.lblDueDateStart)
      Me.grbDetail.Controls.Add(Me.Label2)
      Me.grbDetail.Controls.Add(Me.chkIncludeChildSupplierGroup)
      Me.grbDetail.Controls.Add(Me.btnSpgCodeStart)
      Me.grbDetail.Controls.Add(Me.txtSpgCodeStart)
      Me.grbDetail.Controls.Add(Me.lblSpgStart)
      Me.grbDetail.Controls.Add(Me.txtSupplierGroupName)
      Me.grbDetail.Controls.Add(Me.cmbDocStatus)
      Me.grbDetail.Controls.Add(Me.lblDocStatus)
      Me.grbDetail.Controls.Add(Me.btnSuppliEndFind)
      Me.grbDetail.Controls.Add(Me.txtSuppliCodeEnd)
      Me.grbDetail.Controls.Add(Me.lblSuppliEnd)
      Me.grbDetail.Controls.Add(Me.btnSuppliStartFind)
      Me.grbDetail.Controls.Add(Me.txtSuppliCodeStart)
      Me.grbDetail.Controls.Add(Me.lblSuppliStart)
      Me.grbDetail.Controls.Add(Me.chkIncludeChildren)
      Me.grbDetail.Controls.Add(Me.btnCCCodeStart)
      Me.grbDetail.Controls.Add(Me.txtCCCodeStart)
      Me.grbDetail.Controls.Add(Me.lblCCStart)
      Me.grbDetail.Controls.Add(Me.txtCostCenterName)
      Me.grbDetail.Controls.Add(Me.txtDocDateEnd)
      Me.grbDetail.Controls.Add(Me.txtDocDateStart)
      Me.grbDetail.Controls.Add(Me.dtpDocDateStart)
      Me.grbDetail.Controls.Add(Me.dtpDocDateEnd)
      Me.grbDetail.Controls.Add(Me.lblDocDateStart)
      Me.grbDetail.Controls.Add(Me.lblDocDateEnd)
      Me.grbDetail.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.grbDetail.Location = New System.Drawing.Point(16, 16)
      Me.grbDetail.Name = "grbDetail"
      Me.grbDetail.Size = New System.Drawing.Size(744, 186)
      Me.grbDetail.TabIndex = 0
      Me.grbDetail.TabStop = False
      Me.grbDetail.Text = "ข้อมูลทั่วไป"
      '
      'txtPersonReceiveCode
      '
      Me.Validator.SetDataType(Me.txtPersonReceiveCode, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtPersonReceiveCode, "")
      Me.Validator.SetGotFocusBackColor(Me.txtPersonReceiveCode, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtPersonReceiveCode, System.Drawing.Color.Empty)
      Me.txtPersonReceiveCode.Location = New System.Drawing.Point(136, 135)
      Me.Validator.SetMinValue(Me.txtPersonReceiveCode, "")
      Me.txtPersonReceiveCode.Name = "txtPersonReceiveCode"
      Me.Validator.SetRegularExpression(Me.txtPersonReceiveCode, "")
      Me.Validator.SetRequired(Me.txtPersonReceiveCode, False)
      Me.txtPersonReceiveCode.Size = New System.Drawing.Size(96, 21)
      Me.txtPersonReceiveCode.TabIndex = 207
      '
      'lblPersonReceive
      '
      Me.lblPersonReceive.BackColor = System.Drawing.Color.Transparent
      Me.lblPersonReceive.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblPersonReceive.ForeColor = System.Drawing.SystemColors.WindowText
      Me.lblPersonReceive.Location = New System.Drawing.Point(48, 134)
      Me.lblPersonReceive.Name = "lblPersonReceive"
      Me.lblPersonReceive.Size = New System.Drawing.Size(88, 18)
      Me.lblPersonReceive.TabIndex = 206
      Me.lblPersonReceive.Text = "ชื่อผู้รับของ:"
      Me.lblPersonReceive.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'txtPersonReceiveName
      '
      Me.Validator.SetDataType(Me.txtPersonReceiveName, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtPersonReceiveName, "")
      Me.Validator.SetGotFocusBackColor(Me.txtPersonReceiveName, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtPersonReceiveName, System.Drawing.Color.Empty)
      Me.txtPersonReceiveName.Location = New System.Drawing.Point(257, 135)
      Me.Validator.SetMinValue(Me.txtPersonReceiveName, "")
      Me.txtPersonReceiveName.Name = "txtPersonReceiveName"
      Me.txtPersonReceiveName.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtPersonReceiveName, "")
      Me.Validator.SetRequired(Me.txtPersonReceiveName, False)
      Me.txtPersonReceiveName.Size = New System.Drawing.Size(159, 21)
      Me.txtPersonReceiveName.TabIndex = 208
      Me.txtPersonReceiveName.TabStop = False
      '
      'btnPersonReceiveDialog
      '
      Me.btnPersonReceiveDialog.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnPersonReceiveDialog.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.btnPersonReceiveDialog.ForeColor = System.Drawing.SystemColors.Control
      Me.btnPersonReceiveDialog.Location = New System.Drawing.Point(232, 134)
      Me.btnPersonReceiveDialog.Name = "btnPersonReceiveDialog"
      Me.btnPersonReceiveDialog.Size = New System.Drawing.Size(24, 23)
      Me.btnPersonReceiveDialog.TabIndex = 209
      Me.btnPersonReceiveDialog.TabStop = False
      Me.btnPersonReceiveDialog.ThemedImage = CType(resources.GetObject("btnPersonReceiveDialog.ThemedImage"), System.Drawing.Bitmap)
      '
      'Rpt276FilterSubPanel
      '
      Me.Controls.Add(Me.grbMaster)
      Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Name = "Rpt276FilterSubPanel"
      Me.Size = New System.Drawing.Size(784, 219)
      Me.grbMaster.ResumeLayout(False)
      Me.grbMaster.PerformLayout()
      Me.grbDisplay.ResumeLayout(False)
      Me.grbDetail.ResumeLayout(False)
      Me.grbDetail.PerformLayout()
      Me.ResumeLayout(False)

    End Sub

#End Region

#Region " SetLabelText "
        Public Sub SetLabelText()
            'If Not m_entity Is Nothing Then Me.Text = Me.StringParserService.Parse(Me.m_entity.TabPageText)
            Me.lblCCStart.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.Rpt276FilterSubPanel.lblCostcenterStart}")
            Me.Validator.SetDisplayName(txtCCCodeStart, lblCCStart.Text)

            Me.lblSuppliStart.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.Rpt276FilterSubPanel.lblSuppliStart}")
            Me.Validator.SetDisplayName(txtSuppliCodeStart, lblSuppliStart.Text)

            Me.lblDocDateStart.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.Rpt276FilterSubPanel.lblDocDateStart}")
            Me.Validator.SetDisplayName(txtDocDateStart, lblDocDateStart.Text)


            Me.lblDocDateEnd.Text = Me.StringParserService.Parse("${res:Global.FilterPanelTo}")
            Me.Validator.SetDisplayName(txtDocDateEnd, lblDocDateEnd.Text)

            'ตั้งแต่วันที่ครบกำหนด: Start
            Me.lblDueDateStart.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.Rpt276FilterSubPanel.lblDueDateStart}")
            Me.Validator.SetDisplayName(txtDueDateStart, lblDueDateStart.Text)

            'ตั้งแต่วันที่ครบกำหนด: End
            Me.lblDocDateEnd.Text = Me.StringParserService.Parse("${res:Global.FilterPanelTo}")
            Me.Validator.SetDisplayName(txtDueDateEnd, lblDocDateEnd.Text)


            ' Button
            Me.btnSearch.Text = Me.StringParserService.Parse("${res:Global.SearchButtonText}")
            Me.btnReset.Text = Me.StringParserService.Parse("${res:Global.ResetButtonText}")

            ' GroupBox
            Me.grbMaster.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.Rpt276FilterSubPanel.grbMaster}")
            Me.grbDetail.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.Rpt276FilterSubPanel.grbDetail}")

            Me.lblDocStatus.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.Rpt276FilterSubPanel.lblDocStatus}")

            Me.lblSpgStart.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.Rpt276FilterSubPanel.lblSpgStart}")
            Me.chkIncludeChildSupplierGroup.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.Rpt276FilterSubPanel.chkIncludeChildSupplierGroup}")

            'Me.cmbDocStatus.Items.Add(Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.Rpt274FilterSubPanel.cbCancel}"))
            'Me.cmbDocStatus.Items.Add(Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.Rpt274FilterSubPanel.cbAll}"))
            Me.cmbDocStatus.SelectedIndex = 0
            Me.grbDisplay.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.Rpt276FilterSubPanel.grbDisplay}")
            Me.lblStatus.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.Rpt276FilterSubPanel.lblStatus}")
            Me.cmbStatus.Items.Add(Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.Rpt276FilterSubPanel.cmbDocAll}")) 'เอกสารซื้อสินค้า/บริการทั้งหมด
            Me.cmbStatus.Items.Add(Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.Rpt276FilterSubPanel.cmbDocApprove}")) 'เอกสารซื้อสินค้า/บริการที่อนุมัติแล้ว
            Me.cmbStatus.Items.Add(Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.Rpt276FilterSubPanel.cmbDocNoApprove}")) 'เอกสารซื้อสินค้า/บริการที่ยังไม่อนุมัติ
            Me.cmbStatus.SelectedIndex = 0





        End Sub
#End Region

#Region "Member"
        Private m_cc As Costcenter
    Private m_supplier As Supplier
    Private m_PersonReceive As Employee
        Private m_DocDateEnd As Date
        Private m_DocDateStart As Date
        Private m_DueDateEnd As Date
        Private m_DueDateStart As Date
        Private m_suppliergroup As SupplierGroup
#End Region

#Region "Constructors"
        Public Sub New()
            MyBase.New()
            InitializeComponent()
            EventWiring()
            Initialize()

            SetLabelText()
            LoopControl(Me)
        End Sub
#End Region

#Region "Properties"
        Public Property Costcenter() As Costcenter
            Get
                Return m_cc
            End Get
            Set(ByVal Value As Costcenter)
                m_cc = Value
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
        Public Property DocDateEnd() As Date
            Get
                Return m_DocDateEnd
            End Get
            Set(ByVal Value As Date)
                m_DocDateEnd = Value
            End Set
        End Property

        Public Property DocDateStart() As Date
            Get
                Return m_DocDateStart
            End Get
            Set(ByVal Value As Date)
                m_DocDateStart = Value
            End Set
        End Property
        Public Property DueDateEnd() As Date
            Get
                Return m_DueDateEnd
            End Get
            Set(ByVal Value As Date)
                m_DueDateEnd = Value
            End Set
        End Property

        Public Property DueDateStart() As Date
            Get
                Return m_DueDateStart
            End Get
            Set(ByVal Value As Date)
                m_DueDateStart = Value
            End Set
        End Property
        Public Property SupplierGroup() As SupplierGroup
            Get
                Return m_suppliergroup
            End Get
            Set(ByVal Value As SupplierGroup)
                m_suppliergroup = Value
            End Set
        End Property
#End Region

#Region "Methods"
        Private Sub RegisterDropdown()
            CodeDescription.ListCodeDescriptionInComboBox(Me.cmbDocStatus, "goodsreceipt_status", True)
            cmbDocStatus.SelectedIndex = 0
        End Sub
        Private Sub Initialize()
            RegisterDropdown()
            ClearCriterias()
        End Sub

        Private Sub ClearCriterias()
            For Each grbCtrl As Control In grbMaster.Controls
                If TypeOf grbCtrl Is Longkong.Pojjaman.Gui.Components.FixedGroupBox Then
                    For Each Ctrl As Control In grbCtrl.Controls
                        If TypeOf Ctrl Is TextBox Then
                            Ctrl.Text = ""
                        End If
                    Next
                End If
            Next

            Me.Supplier = New Supplier
            Me.Costcenter = New Costcenter
      Me.txtPersonReceiveCode.Text = ""
      Me.txtPersonReceiveName.Text = ""
      Me.m_PersonReceive = New Employee
            Dim dtStart As Date = Date.Now.Subtract(New TimeSpan(7, 0, 0, 0))

            Me.DocDateStart = dtStart
            Me.txtDocDateStart.Text = MinDateToNull(Me.DocDateStart, "")
            Me.dtpDocDateStart.Value = Me.DocDateStart

            Me.DocDateEnd = Date.Now
            Me.txtDocDateEnd.Text = MinDateToNull(Me.DocDateEnd, "")
            Me.dtpDocDateEnd.Value = Me.DocDateEnd

            Me.DueDateStart = dtStart
            Me.txtDueDateStart.Text = MinDateToNull(Me.DueDateStart, "")
            Me.dtpDueDateStart.Value = Me.DueDateStart

            Me.DueDateEnd = Date.Now
            Me.txtDueDateEnd.Text = MinDateToNull(Me.DueDateEnd, "")
            Me.dtpDueDateEnd.Value = Me.DueDateEnd

            Me.SupplierGroup = New SupplierGroup

        End Sub
        Public Overrides Function GetFilterString() As String

        End Function
        Public Overrides Function GetFilterArray() As Filter()
      Dim arr(13) As Filter
            arr(0) = New Filter("DocDateStart", IIf(Me.DocDateStart.Equals(Date.MinValue), DBNull.Value, Me.DocDateStart))
            arr(1) = New Filter("DocDateEnd", IIf(Me.DocDateEnd.Equals(Date.MinValue), DBNull.Value, Me.DocDateEnd))
            arr(2) = New Filter("duedatestart", IIf(Me.DueDateStart.Equals(Date.MinValue), DBNull.Value, Me.DueDateStart))
            arr(3) = New Filter("duedateend", IIf(Me.DueDateEnd.Equals(Date.MinValue), DBNull.Value, Me.DueDateEnd))
            arr(4) = New Filter("SuppliCodeStart", IIf(txtSuppliCodeStart.TextLength > 0, txtSuppliCodeStart.Text, DBNull.Value))
            arr(5) = New Filter("SuppliCodeEnd", IIf(txtSuppliCodeEnd.TextLength > 0, txtSuppliCodeEnd.Text, DBNull.Value))
            arr(6) = New Filter("cc_id", Me.ValidIdOrDBNull(m_cc))
            arr(7) = New Filter("IncludeChildCC", Me.chkIncludeChildren.Checked)
            arr(8) = New Filter("status", IIf(cmbDocStatus.SelectedItem Is Nothing, DBNull.Value, CType(cmbDocStatus.SelectedItem, IdValuePair).Id)) 'cmbDocStatus.SelectedIndex) ' IIf(cmbDocStatus.SelectedItem Is Nothing, DBNull.Value, CType(cmbDocStatus.SelectedItem, IdValuePair).Id))
            arr(9) = New Filter("userRight", CType(ServiceManager.Services.GetService(GetType(SecurityService)), SecurityService).CurrentUser.Id)
            arr(10) = New Filter("SupplierGroupID", Me.ValidIdOrDBNull(m_suppliergroup))
            arr(11) = New Filter("IncludeChildSupplierGroup", Me.chkIncludeChildSupplierGroup.Checked)
            arr(12) = New Filter("ApproveStatus", Me.cmbStatus.SelectedIndex)
      arr(13) = New Filter("PersonReceive", IIf(Me.m_PersonReceive.Valid, Me.m_PersonReceive.Id, DBNull.Value))

      Return arr
        End Function
        Public Overrides ReadOnly Property SearchButton() As System.Windows.Forms.Button
            Get
                Return Me.btnSearch
            End Get
        End Property

        Private Sub btnReset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReset.Click
            ClearCriterias()
            'Me.btnSearch.PerformClick()
        End Sub
#End Region

#Region "IReportFilterSubPanel"
        Public Function GetFixValueCollection() As BusinessLogic.DocPrintingItemCollection Implements IReportFilterSubPanel.GetFixValueCollection
            Dim dpiColl As New DocPrintingItemCollection
            Dim dpi As DocPrintingItem

            'Status
            dpi = New DocPrintingItem
            dpi.Mapping = "Status"
            dpi.Value = Me.cmbDocStatus.Text
            dpi.DataType = "System.String"
            dpiColl.Add(dpi)

            'Month
            dpi = New DocPrintingItem
            dpi.Mapping = "Month"
            dpi.Value = "" 'Me.cmbMonth.Text
            dpi.DataType = "System.String"
            dpiColl.Add(dpi)

            'Year
            dpi = New DocPrintingItem
            dpi.Mapping = "Year"
            dpi.Value = "" 'Me.cmbYear.Text
            dpi.DataType = "System.String"
            dpiColl.Add(dpi)

            'Docdate Start
            dpi = New DocPrintingItem
            dpi.Mapping = "DocdateStart"
            dpi.Value = Me.txtDocDateStart.Text
            dpi.DataType = "System.String"
            dpiColl.Add(dpi)

            'Docdate End
            dpi = New DocPrintingItem
            dpi.Mapping = "DocdateEnd"
            dpi.Value = Me.txtDocDateEnd.Text
            dpi.DataType = "System.String"
            dpiColl.Add(dpi)

            'SupplierStart
            dpi = New DocPrintingItem
            dpi.Mapping = "SupplierStart"
            dpi.Value = Me.txtSuppliCodeStart.Text
            dpi.DataType = "System.String"
            dpiColl.Add(dpi)

            'SupplierEnd
            dpi = New DocPrintingItem
            dpi.Mapping = "SupplierEnd"
            dpi.Value = Me.txtSuppliCodeEnd.Text
            dpi.DataType = "System.String"
            dpiColl.Add(dpi)

            'CheckBox ChildInclude
            If Me.chkIncludeChildren.Checked Then
                dpi = New DocPrintingItem
                dpi.Mapping = "childincluded"
                dpi.Value = "(รวมในสังกัด)"
                dpi.DataType = "System.String"
                dpiColl.Add(dpi)
            End If

            'CostCenter Start
            dpi = New DocPrintingItem
            dpi.Mapping = "CostcenterStart"
            dpi.Value = Me.txtCCCodeStart.Text
            dpi.DataType = "System.String"
            dpiColl.Add(dpi)

            'SupplierGroup Start
            dpi = New DocPrintingItem
            dpi.Mapping = "SupplierGroupCodeStart"
            dpi.Value = Me.txtSpgCodeStart.Text
            dpi.DataType = "System.String"
            dpiColl.Add(dpi)

            'CheckBox ChildSupplierGroupInclude
            If Me.chkIncludeChildSupplierGroup.Checked Then
                dpi = New DocPrintingItem
                dpi.Mapping = "childSupplierGroupincluded"
                dpi.Value = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.Rpt276FilterSubPanel.childSupplierGroupincluded}")
                dpi.DataType = "System.String"
                dpiColl.Add(dpi)
            End If

            'ApproveStatus
            dpi = New DocPrintingItem
            dpi.Mapping = "ApproveStatus"
            dpi.Value = Me.cmbStatus.Text
            dpi.DataType = "System.String"
            dpiColl.Add(dpi)


            Return dpiColl
        End Function
#End Region

#Region " ChangeProperty "
        Private Sub EventWiring()
            AddHandler btnSuppliStartFind.Click, AddressOf Me.btnSupplierFind_Click
            AddHandler btnSuppliEndFind.Click, AddressOf Me.btnSupplierFind_Click

            AddHandler btnCCCodeStart.Click, AddressOf Me.btnCostcenterFind_Click
            AddHandler txtCCCodeStart.Validated, AddressOf Me.ChangeProperty

            AddHandler txtDocDateStart.Validated, AddressOf Me.ChangeProperty
            AddHandler txtDocDateEnd.Validated, AddressOf Me.ChangeProperty

            AddHandler txtDueDateStart.Validated, AddressOf Me.ChangeProperty
            AddHandler txtDueDateEnd.Validated, AddressOf Me.ChangeProperty

            AddHandler dtpDocDateStart.ValueChanged, AddressOf Me.ChangeProperty
            AddHandler dtpDocDateEnd.ValueChanged, AddressOf Me.ChangeProperty

            AddHandler dtpDueDateStart.ValueChanged, AddressOf Me.ChangeProperty
            AddHandler dtpDueDateEnd.ValueChanged, AddressOf Me.ChangeProperty

            AddHandler btnSpgCodeStart.Click, AddressOf Me.btnSupplierGroupFind_Click
        End Sub

        Private m_dateSetting As Boolean
        Private Sub ChangeProperty(ByVal sender As Object, ByVal e As EventArgs)

            Select Case CType(sender, Control).Name.ToLower
                Case "txtcccodestart"
                    Costcenter.GetCostCenter(txtCCCodeStart, Me.txtCostCenterName, m_cc, CType(ServiceManager.Services.GetService(GetType(SecurityService)), SecurityService).CurrentUser.Id)

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

                    '************************* start
                Case "dtpduedatestart"
                    If Not Me.DueDateStart.Equals(dtpDueDateStart.Value) Then
                        If Not m_dateSetting Then
                            Me.txtDueDateStart.Text = MinDateToNull(dtpDueDateStart.Value, Me.StringParserService.Parse("${res:Global.BlankDateText}"))
                            Me.DueDateStart = dtpDueDateStart.Value
                        End If
                    End If
                Case "txtduedatestart"
                    m_dateSetting = True
                    If Not Me.txtDueDateStart.Text.Length = 0 AndAlso Me.Validator.GetErrorMessage(Me.txtDueDateStart) = "" Then
                        Dim theDate As Date = CDate(Me.txtDueDateStart.Text)
                        If Not Me.DueDateStart.Equals(theDate) Then
                            dtpDueDateStart.Value = theDate
                            Me.DueDateStart = dtpDueDateStart.Value
                        End If
                    Else
                        Me.dtpDueDateStart.Value = Date.Now
                        Me.DueDateStart = Date.MinValue
                    End If
                    m_dateSetting = False
                    '************************* start

                    '************************* End
                Case "dtpduedateend"
                    If Not Me.DueDateEnd.Equals(dtpDueDateEnd.Value) Then
                        If Not m_dateSetting Then
                            Me.txtDueDateEnd.Text = MinDateToNull(dtpDueDateEnd.Value, Me.StringParserService.Parse("${res:Global.BlankDateText}"))
                            Me.DueDateEnd = dtpDueDateEnd.Value
                        End If
                    End If
                Case "txtduedateend"
                    m_dateSetting = True
                    If Not Me.txtDueDateEnd.Text.Length = 0 AndAlso Me.Validator.GetErrorMessage(Me.txtDueDateEnd) = "" Then
                        Dim theDate As Date = CDate(Me.txtDocDateEnd.Text)
                        If Not Me.DueDateEnd.Equals(theDate) Then
                            dtpDueDateEnd.Value = theDate
                            Me.DueDateEnd = dtpDueDateEnd.Value
                        End If
                    Else
                        Me.dtpDueDateEnd.Value = Date.Now
                        Me.DueDateEnd = Date.MinValue
                    End If
                    m_dateSetting = False
                    '************************* End

                Case Else

            End Select
        End Sub
#End Region

#Region "IClipboardHandler Overrides"
        Public Overrides ReadOnly Property EnablePaste() As Boolean
            Get
                Dim data As IDataObject = Clipboard.GetDataObject
                ' Supplier
                If data.GetDataPresent((New Supplier).FullClassName) Then
                    If Not Me.ActiveControl Is Nothing Then
                        Select Case Me.ActiveControl.Name.ToLower
                            Case "txtsupplicodestart", "txtsupplicodeend"
                                Return True
                        End Select
                    End If
                End If
                ' Costcenter
                If data.GetDataPresent((New Costcenter).FullClassName) Then
                    If Not Me.ActiveControl Is Nothing Then
                        Select Case Me.ActiveControl.Name.ToLower
                            Case "txtcccodestart", "txtcccodeend"
                                Return True
                        End Select
                    End If
        End If
        If data.GetDataPresent((New Employee).FullClassName) Then
          Select Case Me.ActiveControl.Name.ToLower
            Case "txtpersonreceivecode", "txtpersonreceivename"
              Return True
          End Select
        End If
            End Get
        End Property
        Public Overrides Sub Paste(ByVal sender As Object, ByVal e As System.EventArgs)
            Dim data As IDataObject = Clipboard.GetDataObject
            ' Supplier
            If data.GetDataPresent((New Supplier).FullClassName) Then
                Dim id As Integer = CInt(data.GetData((New Supplier).FullClassName))
                Dim entity As New Supplier(id)
                If Not Me.ActiveControl Is Nothing Then
                    Select Case Me.ActiveControl.Name.ToLower
                        Case "txtsupplicodestart"
                            Me.SetSupplierStartDialog(entity)

                        Case "txtsupplicodeend"
                            Me.SetSupplierEndDialog(entity)

                    End Select
                End If
      End If
      If data.GetDataPresent((New Employee).FullClassName) Then
        Dim id As Integer = CInt(data.GetData((New Employee).FullClassName))
        Dim entity As New Employee(id)
        Select Case Me.ActiveControl.Name.ToLower
          Case "txtpersonreceivecode", "txtpersonreceivename"
            Me.SetToCCPerson(entity)
        End Select
      End If
            ' Costcenter
            If data.GetDataPresent((New Costcenter).FullClassName) Then
                Dim id As Integer = CInt(data.GetData((New Costcenter).FullClassName))
                Dim entity As New Costcenter(id)
                If Not Me.ActiveControl Is Nothing Then
                    Select Case Me.ActiveControl.Name.ToLower
                        Case "txtcostcentercodestart"
                            Me.SetCCCodeStartDialog(entity)

                        Case "txtcostcentercodeend"
                            Me.SetCCCodeStartDialog(entity)

                    End Select
                End If
            End If
        End Sub
#End Region

#Region " Event Handlers "
        ' Supplier
        Private Sub btnSupplierFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
            Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
            Select Case CType(sender, Control).Name.ToLower
                Case "btnsupplistartfind"
                    myEntityPanelService.OpenListDialog(New Supplier, AddressOf SetSupplierStartDialog)

                Case "btnsuppliendfind"
                    myEntityPanelService.OpenListDialog(New Supplier, AddressOf SetSupplierEndDialog)

            End Select
        End Sub
        Private Sub SetSupplierStartDialog(ByVal e As ISimpleEntity)
            Me.txtSuppliCodeStart.Text = e.Code
            Supplier.GetSupplier(txtSuppliCodeStart, txtTemp, Me.Supplier)
        End Sub
        Private Sub SetSupplierEndDialog(ByVal e As ISimpleEntity)
            Me.txtSuppliCodeEnd.Text = e.Code
            Supplier.GetSupplier(txtSuppliCodeEnd, txtTemp, Me.Supplier)
        End Sub
        ' Costcenter
        Private Sub btnCostcenterFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
            Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
            Select Case CType(sender, Control).Name.ToLower
                Case "btncccodestart"
                    myEntityPanelService.OpenTreeDialog(New Costcenter, AddressOf SetCCCodeStartDialog)
            End Select
        End Sub
        Private Sub SetCCCodeStartDialog(ByVal e As ISimpleEntity)
            Me.txtCCCodeStart.Text = e.Code
            Costcenter.GetCostCenter(txtCCCodeStart, txtCostCenterName, m_cc, CType(ServiceManager.Services.GetService(GetType(SecurityService)), SecurityService).CurrentUser.Id)
        End Sub
        ' SupplierGroup
        Private Sub btnSupplierGroupFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
            Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
            Select Case CType(sender, Control).Name.ToLower
                Case "btnspgcodestart"
                    myEntityPanelService.OpenTreeDialog(New SupplierGroup, AddressOf SetSpgCodeStartDialog)
            End Select
        End Sub
        Private Sub SetSpgCodeStartDialog(ByVal e As ISimpleEntity)
            Me.txtSpgCodeStart.Text = e.Code
            SupplierGroup.GetSupplierGroup(txtSpgCodeStart, txtSupplierGroupName, m_suppliergroup, True)
    End Sub
    Private Sub txtpersonreceiveCode_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPersonReceiveCode.Validated
      Employee.GetEmployee(txtPersonReceiveCode, txtPersonReceiveName, Me.m_PersonReceive)
    End Sub
    Private Sub btnpersonreceiveDialog_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPersonReceiveDialog.Click
      Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      myEntityPanelService.OpenListDialog(New Employee, AddressOf SetToCCPerson)
    End Sub
    Private Sub SetToCCPerson(ByVal e As ISimpleEntity)
      Me.txtPersonReceiveCode.Text = e.Code
      Employee.GetEmployee(txtPersonReceiveCode, txtPersonReceiveName, Me.m_PersonReceive)
    End Sub
#End Region

    End Class
End Namespace

