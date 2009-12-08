Imports Longkong.Pojjaman.BusinessLogic
Imports longkong.Pojjaman.Services
Imports Longkong.Core.Services

Namespace Longkong.Pojjaman.Gui.Panels
    Public Class RptPaymentByCheckFilterSubPanel
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
        Friend WithEvents grbDetail As Longkong.Pojjaman.Gui.Components.FixedGroupBox
        Friend WithEvents btnSupplierStartFind As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents txtSupplierCodeStart As System.Windows.Forms.TextBox
        Friend WithEvents lblSupplierStart As System.Windows.Forms.Label
        Friend WithEvents cmbChkStatus As System.Windows.Forms.ComboBox
        Friend WithEvents lblChkStatus As System.Windows.Forms.Label
        Friend WithEvents btnCheckCodeStartFind As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents txtCheckCodeStart As System.Windows.Forms.TextBox
        Friend WithEvents lblCheckCodeStart As System.Windows.Forms.Label
        Friend WithEvents chkIncludeChildren As System.Windows.Forms.CheckBox
        Friend WithEvents txtCCCodeStart As System.Windows.Forms.TextBox
        Friend WithEvents lblCCStart As System.Windows.Forms.Label
        Friend WithEvents txtCostCenterName As System.Windows.Forms.TextBox
        Friend WithEvents btnCCCodeStart As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents txtDocDateEnd As System.Windows.Forms.TextBox
        Friend WithEvents txtDocDateStart As System.Windows.Forms.TextBox
        Friend WithEvents dtpDocDateStart As System.Windows.Forms.DateTimePicker
        Friend WithEvents dtpDocDateEnd As System.Windows.Forms.DateTimePicker
        Friend WithEvents lblDocDateStart As System.Windows.Forms.Label
        Friend WithEvents lblDocDateEnd As System.Windows.Forms.Label
        Friend WithEvents txtCheckDateEnd As System.Windows.Forms.TextBox
        Friend WithEvents dtpCheckDateEnd As System.Windows.Forms.DateTimePicker
        Friend WithEvents lblCheckDateStart As System.Windows.Forms.Label
        Friend WithEvents lblCheckDateEnd As System.Windows.Forms.Label
        Friend WithEvents txtCheckDateStart As System.Windows.Forms.TextBox
        Friend WithEvents dtpCheckDateStart As System.Windows.Forms.DateTimePicker
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Me.components = New System.ComponentModel.Container
            Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(RptPaymentByCheckFilterSubPanel))
            Me.grbMaster = New Longkong.Pojjaman.Gui.Components.FixedGroupBox
            Me.grbDetail = New Longkong.Pojjaman.Gui.Components.FixedGroupBox
            Me.txtDocDateEnd = New System.Windows.Forms.TextBox
            Me.txtDocDateStart = New System.Windows.Forms.TextBox
            Me.dtpDocDateStart = New System.Windows.Forms.DateTimePicker
            Me.dtpDocDateEnd = New System.Windows.Forms.DateTimePicker
            Me.lblDocDateStart = New System.Windows.Forms.Label
            Me.lblDocDateEnd = New System.Windows.Forms.Label
            Me.btnCCCodeStart = New Longkong.Pojjaman.Gui.Components.ImageButton
            Me.chkIncludeChildren = New System.Windows.Forms.CheckBox
            Me.txtCCCodeStart = New System.Windows.Forms.TextBox
            Me.lblCCStart = New System.Windows.Forms.Label
            Me.txtCostCenterName = New System.Windows.Forms.TextBox
            Me.cmbChkStatus = New System.Windows.Forms.ComboBox
            Me.lblChkStatus = New System.Windows.Forms.Label
            Me.btnCheckCodeStartFind = New Longkong.Pojjaman.Gui.Components.ImageButton
            Me.txtCheckCodeStart = New System.Windows.Forms.TextBox
            Me.lblCheckCodeStart = New System.Windows.Forms.Label
            Me.btnSupplierStartFind = New Longkong.Pojjaman.Gui.Components.ImageButton
            Me.txtSupplierCodeStart = New System.Windows.Forms.TextBox
            Me.lblSupplierStart = New System.Windows.Forms.Label
            Me.txtTemp = New System.Windows.Forms.TextBox
            Me.btnSearch = New System.Windows.Forms.Button
            Me.btnReset = New System.Windows.Forms.Button
            Me.Validator = New Longkong.Pojjaman.Gui.Components.PJMTextboxValidator(Me.components)
            Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider
            Me.txtCheckDateEnd = New System.Windows.Forms.TextBox
            Me.txtCheckDateStart = New System.Windows.Forms.TextBox
            Me.dtpCheckDateStart = New System.Windows.Forms.DateTimePicker
            Me.dtpCheckDateEnd = New System.Windows.Forms.DateTimePicker
            Me.lblCheckDateStart = New System.Windows.Forms.Label
            Me.lblCheckDateEnd = New System.Windows.Forms.Label
            Me.grbMaster.SuspendLayout()
            Me.grbDetail.SuspendLayout()
            Me.SuspendLayout()
            '
            'grbMaster
            '
            Me.grbMaster.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.grbMaster.Controls.Add(Me.grbDetail)
            Me.grbMaster.Controls.Add(Me.btnSearch)
            Me.grbMaster.Controls.Add(Me.btnReset)
            Me.grbMaster.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.grbMaster.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.grbMaster.Location = New System.Drawing.Point(8, 8)
            Me.grbMaster.Name = "grbMaster"
            Me.grbMaster.Size = New System.Drawing.Size(720, 216)
            Me.grbMaster.TabIndex = 0
            Me.grbMaster.TabStop = False
            Me.grbMaster.Text = "เช็ครับ"
            '
            'grbDetail
            '
            Me.grbDetail.Controls.Add(Me.txtCheckDateEnd)
            Me.grbDetail.Controls.Add(Me.txtCheckDateStart)
            Me.grbDetail.Controls.Add(Me.dtpCheckDateStart)
            Me.grbDetail.Controls.Add(Me.dtpCheckDateEnd)
            Me.grbDetail.Controls.Add(Me.lblCheckDateStart)
            Me.grbDetail.Controls.Add(Me.lblCheckDateEnd)
            Me.grbDetail.Controls.Add(Me.txtDocDateEnd)
            Me.grbDetail.Controls.Add(Me.txtDocDateStart)
            Me.grbDetail.Controls.Add(Me.dtpDocDateStart)
            Me.grbDetail.Controls.Add(Me.dtpDocDateEnd)
            Me.grbDetail.Controls.Add(Me.lblDocDateStart)
            Me.grbDetail.Controls.Add(Me.lblDocDateEnd)
            Me.grbDetail.Controls.Add(Me.btnCCCodeStart)
            Me.grbDetail.Controls.Add(Me.chkIncludeChildren)
            Me.grbDetail.Controls.Add(Me.txtCCCodeStart)
            Me.grbDetail.Controls.Add(Me.lblCCStart)
            Me.grbDetail.Controls.Add(Me.txtCostCenterName)
            Me.grbDetail.Controls.Add(Me.cmbChkStatus)
            Me.grbDetail.Controls.Add(Me.lblChkStatus)
            Me.grbDetail.Controls.Add(Me.btnCheckCodeStartFind)
            Me.grbDetail.Controls.Add(Me.txtCheckCodeStart)
            Me.grbDetail.Controls.Add(Me.lblCheckCodeStart)
            Me.grbDetail.Controls.Add(Me.btnSupplierStartFind)
            Me.grbDetail.Controls.Add(Me.txtSupplierCodeStart)
            Me.grbDetail.Controls.Add(Me.lblSupplierStart)
            Me.grbDetail.Controls.Add(Me.txtTemp)
            Me.grbDetail.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.grbDetail.Location = New System.Drawing.Point(16, 16)
            Me.grbDetail.Name = "grbDetail"
            Me.grbDetail.Size = New System.Drawing.Size(688, 160)
            Me.grbDetail.TabIndex = 0
            Me.grbDetail.TabStop = False
            Me.grbDetail.Text = "ข้อมูลทั่วไป"
            '
            'txtDocDateEnd
            '
            Me.Validator.SetDataType(Me.txtDocDateEnd, Longkong.Pojjaman.Gui.Components.DataTypeConstants.DateTimeType)
            Me.Validator.SetDisplayName(Me.txtDocDateEnd, "")
            Me.Validator.SetGotFocusBackColor(Me.txtDocDateEnd, System.Drawing.Color.Empty)
            Me.ErrorProvider1.SetIconPadding(Me.txtDocDateEnd, -15)
            Me.Validator.SetInvalidBackColor(Me.txtDocDateEnd, System.Drawing.Color.Empty)
            Me.txtDocDateEnd.Location = New System.Drawing.Point(392, 24)
            Me.txtDocDateEnd.MaxLength = 10
            Me.Validator.SetMaxValue(Me.txtDocDateEnd, "")
            Me.Validator.SetMinValue(Me.txtDocDateEnd, "")
            Me.txtDocDateEnd.Name = "txtDocDateEnd"
            Me.Validator.SetRegularExpression(Me.txtDocDateEnd, "")
            Me.Validator.SetRequired(Me.txtDocDateEnd, False)
            Me.txtDocDateEnd.Size = New System.Drawing.Size(99, 21)
            Me.txtDocDateEnd.TabIndex = 1
            Me.txtDocDateEnd.Text = ""
            '
            'txtDocDateStart
            '
            Me.Validator.SetDataType(Me.txtDocDateStart, Longkong.Pojjaman.Gui.Components.DataTypeConstants.DateTimeType)
            Me.Validator.SetDisplayName(Me.txtDocDateStart, "")
            Me.Validator.SetGotFocusBackColor(Me.txtDocDateStart, System.Drawing.Color.Empty)
            Me.ErrorProvider1.SetIconPadding(Me.txtDocDateStart, -15)
            Me.Validator.SetInvalidBackColor(Me.txtDocDateStart, System.Drawing.Color.Empty)
            Me.txtDocDateStart.Location = New System.Drawing.Point(160, 24)
            Me.txtDocDateStart.MaxLength = 10
            Me.Validator.SetMaxValue(Me.txtDocDateStart, "")
            Me.Validator.SetMinValue(Me.txtDocDateStart, "")
            Me.txtDocDateStart.Name = "txtDocDateStart"
            Me.Validator.SetRegularExpression(Me.txtDocDateStart, "")
            Me.Validator.SetRequired(Me.txtDocDateStart, False)
            Me.txtDocDateStart.Size = New System.Drawing.Size(99, 21)
            Me.txtDocDateStart.TabIndex = 0
            Me.txtDocDateStart.Text = ""
            '
            'dtpDocDateStart
            '
            Me.dtpDocDateStart.Format = System.Windows.Forms.DateTimePickerFormat.Short
            Me.dtpDocDateStart.Location = New System.Drawing.Point(160, 24)
            Me.dtpDocDateStart.Name = "dtpDocDateStart"
            Me.dtpDocDateStart.Size = New System.Drawing.Size(120, 21)
            Me.dtpDocDateStart.TabIndex = 11
            Me.dtpDocDateStart.TabStop = False
            '
            'dtpDocDateEnd
            '
            Me.dtpDocDateEnd.Format = System.Windows.Forms.DateTimePickerFormat.Short
            Me.dtpDocDateEnd.Location = New System.Drawing.Point(392, 24)
            Me.dtpDocDateEnd.Name = "dtpDocDateEnd"
            Me.dtpDocDateEnd.Size = New System.Drawing.Size(120, 21)
            Me.dtpDocDateEnd.TabIndex = 12
            Me.dtpDocDateEnd.TabStop = False
            '
            'lblDocDateStart
            '
            Me.lblDocDateStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblDocDateStart.ForeColor = System.Drawing.Color.Black
            Me.lblDocDateStart.Location = New System.Drawing.Point(64, 24)
            Me.lblDocDateStart.Name = "lblDocDateStart"
            Me.lblDocDateStart.Size = New System.Drawing.Size(88, 18)
            Me.lblDocDateStart.TabIndex = 25
            Me.lblDocDateStart.Text = "ตั้งแต่วันที่"
            Me.lblDocDateStart.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblDocDateEnd
            '
            Me.lblDocDateEnd.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblDocDateEnd.ForeColor = System.Drawing.Color.Black
            Me.lblDocDateEnd.Location = New System.Drawing.Point(288, 24)
            Me.lblDocDateEnd.Name = "lblDocDateEnd"
            Me.lblDocDateEnd.Size = New System.Drawing.Size(96, 18)
            Me.lblDocDateEnd.TabIndex = 28
            Me.lblDocDateEnd.Text = "ถึง"
            Me.lblDocDateEnd.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'btnCCCodeStart
            '
            Me.btnCCCodeStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.btnCCCodeStart.ForeColor = System.Drawing.SystemColors.Control
            Me.btnCCCodeStart.Image = CType(resources.GetObject("btnCCCodeStart.Image"), System.Drawing.Image)
            Me.btnCCCodeStart.Location = New System.Drawing.Point(488, 72)
            Me.btnCCCodeStart.Name = "btnCCCodeStart"
            Me.btnCCCodeStart.Size = New System.Drawing.Size(24, 22)
            Me.btnCCCodeStart.TabIndex = 16
            Me.btnCCCodeStart.TabStop = False
            Me.btnCCCodeStart.ThemedImage = CType(resources.GetObject("btnCCCodeStart.ThemedImage"), System.Drawing.Bitmap)
            '
            'chkIncludeChildren
            '
            Me.chkIncludeChildren.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.chkIncludeChildren.Location = New System.Drawing.Point(392, 96)
            Me.chkIncludeChildren.Name = "chkIncludeChildren"
            Me.chkIncludeChildren.Size = New System.Drawing.Size(272, 24)
            Me.chkIncludeChildren.TabIndex = 8
            Me.chkIncludeChildren.Text = "รวม Cost Center ลูก"
            '
            'txtCCCodeStart
            '
            Me.Validator.SetDataType(Me.txtCCCodeStart, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtCCCodeStart, "")
            Me.txtCCCodeStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtCCCodeStart, System.Drawing.Color.Empty)
            Me.ErrorProvider1.SetIconPadding(Me.txtCCCodeStart, -15)
            Me.Validator.SetInvalidBackColor(Me.txtCCCodeStart, System.Drawing.Color.Empty)
            Me.txtCCCodeStart.Location = New System.Drawing.Point(392, 72)
            Me.txtCCCodeStart.MaxLength = 50
            Me.Validator.SetMaxValue(Me.txtCCCodeStart, "")
            Me.Validator.SetMinValue(Me.txtCCCodeStart, "")
            Me.txtCCCodeStart.Name = "txtCCCodeStart"
            Me.Validator.SetRegularExpression(Me.txtCCCodeStart, "")
            Me.Validator.SetRequired(Me.txtCCCodeStart, False)
            Me.txtCCCodeStart.Size = New System.Drawing.Size(96, 21)
            Me.txtCCCodeStart.TabIndex = 5
            Me.txtCCCodeStart.Text = ""
            '
            'lblCCStart
            '
            Me.lblCCStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblCCStart.ForeColor = System.Drawing.Color.Black
            Me.lblCCStart.Location = New System.Drawing.Point(288, 72)
            Me.lblCCStart.Name = "lblCCStart"
            Me.lblCCStart.Size = New System.Drawing.Size(96, 18)
            Me.lblCCStart.TabIndex = 19
            Me.lblCCStart.Text = "Cost Center"
            Me.lblCCStart.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtCostCenterName
            '
            Me.Validator.SetDataType(Me.txtCostCenterName, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtCostCenterName, "")
            Me.txtCostCenterName.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtCostCenterName, System.Drawing.Color.Empty)
            Me.ErrorProvider1.SetIconPadding(Me.txtCostCenterName, -15)
            Me.Validator.SetInvalidBackColor(Me.txtCostCenterName, System.Drawing.Color.Empty)
            Me.txtCostCenterName.Location = New System.Drawing.Point(512, 72)
            Me.txtCostCenterName.MaxLength = 50
            Me.Validator.SetMaxValue(Me.txtCostCenterName, "")
            Me.Validator.SetMinValue(Me.txtCostCenterName, "")
            Me.txtCostCenterName.Name = "txtCostCenterName"
            Me.txtCostCenterName.ReadOnly = True
            Me.Validator.SetRegularExpression(Me.txtCostCenterName, "")
            Me.Validator.SetRequired(Me.txtCostCenterName, False)
            Me.txtCostCenterName.Size = New System.Drawing.Size(160, 21)
            Me.txtCostCenterName.TabIndex = 20
            Me.txtCostCenterName.Text = ""
            '
            'cmbChkStatus
            '
            Me.cmbChkStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cmbChkStatus.Location = New System.Drawing.Point(160, 120)
            Me.cmbChkStatus.Name = "cmbChkStatus"
            Me.cmbChkStatus.TabIndex = 7
            '
            'lblChkStatus
            '
            Me.lblChkStatus.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblChkStatus.ForeColor = System.Drawing.Color.Black
            Me.lblChkStatus.Location = New System.Drawing.Point(64, 120)
            Me.lblChkStatus.Name = "lblChkStatus"
            Me.lblChkStatus.Size = New System.Drawing.Size(88, 18)
            Me.lblChkStatus.TabIndex = 13
            Me.lblChkStatus.Text = "สถานะเช็ค"
            Me.lblChkStatus.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'btnCheckCodeStartFind
            '
            Me.btnCheckCodeStartFind.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.btnCheckCodeStartFind.ForeColor = System.Drawing.SystemColors.Control
            Me.btnCheckCodeStartFind.Image = CType(resources.GetObject("btnCheckCodeStartFind.Image"), System.Drawing.Image)
            Me.btnCheckCodeStartFind.Location = New System.Drawing.Point(256, 72)
            Me.btnCheckCodeStartFind.Name = "btnCheckCodeStartFind"
            Me.btnCheckCodeStartFind.Size = New System.Drawing.Size(24, 22)
            Me.btnCheckCodeStartFind.TabIndex = 15
            Me.btnCheckCodeStartFind.TabStop = False
            Me.btnCheckCodeStartFind.ThemedImage = CType(resources.GetObject("btnCheckCodeStartFind.ThemedImage"), System.Drawing.Bitmap)
            '
            'txtCheckCodeStart
            '
            Me.Validator.SetDataType(Me.txtCheckCodeStart, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtCheckCodeStart, "")
            Me.txtCheckCodeStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtCheckCodeStart, System.Drawing.Color.Empty)
            Me.ErrorProvider1.SetIconPadding(Me.txtCheckCodeStart, -15)
            Me.Validator.SetInvalidBackColor(Me.txtCheckCodeStart, System.Drawing.Color.Empty)
            Me.txtCheckCodeStart.Location = New System.Drawing.Point(160, 72)
            Me.txtCheckCodeStart.MaxLength = 50
            Me.Validator.SetMaxValue(Me.txtCheckCodeStart, "")
            Me.Validator.SetMinValue(Me.txtCheckCodeStart, "")
            Me.txtCheckCodeStart.Name = "txtCheckCodeStart"
            Me.Validator.SetRegularExpression(Me.txtCheckCodeStart, "")
            Me.Validator.SetRequired(Me.txtCheckCodeStart, False)
            Me.txtCheckCodeStart.Size = New System.Drawing.Size(96, 21)
            Me.txtCheckCodeStart.TabIndex = 4
            Me.txtCheckCodeStart.Text = ""
            '
            'lblCheckCodeStart
            '
            Me.lblCheckCodeStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblCheckCodeStart.ForeColor = System.Drawing.Color.Black
            Me.lblCheckCodeStart.Location = New System.Drawing.Point(64, 72)
            Me.lblCheckCodeStart.Name = "lblCheckCodeStart"
            Me.lblCheckCodeStart.Size = New System.Drawing.Size(88, 18)
            Me.lblCheckCodeStart.TabIndex = 6
            Me.lblCheckCodeStart.Text = "เลขที่เช็ค"
            Me.lblCheckCodeStart.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'btnSupplierStartFind
            '
            Me.btnSupplierStartFind.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.btnSupplierStartFind.ForeColor = System.Drawing.SystemColors.Control
            Me.btnSupplierStartFind.Image = CType(resources.GetObject("btnSupplierStartFind.Image"), System.Drawing.Image)
            Me.btnSupplierStartFind.Location = New System.Drawing.Point(256, 96)
            Me.btnSupplierStartFind.Name = "btnSupplierStartFind"
            Me.btnSupplierStartFind.Size = New System.Drawing.Size(24, 22)
            Me.btnSupplierStartFind.TabIndex = 17
            Me.btnSupplierStartFind.TabStop = False
            Me.btnSupplierStartFind.ThemedImage = CType(resources.GetObject("btnSupplierStartFind.ThemedImage"), System.Drawing.Bitmap)
            '
            'txtSupplierCodeStart
            '
            Me.Validator.SetDataType(Me.txtSupplierCodeStart, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtSupplierCodeStart, "")
            Me.txtSupplierCodeStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtSupplierCodeStart, System.Drawing.Color.Empty)
            Me.ErrorProvider1.SetIconPadding(Me.txtSupplierCodeStart, -15)
            Me.Validator.SetInvalidBackColor(Me.txtSupplierCodeStart, System.Drawing.Color.Empty)
            Me.txtSupplierCodeStart.Location = New System.Drawing.Point(160, 96)
            Me.txtSupplierCodeStart.MaxLength = 50
            Me.Validator.SetMaxValue(Me.txtSupplierCodeStart, "")
            Me.Validator.SetMinValue(Me.txtSupplierCodeStart, "")
            Me.txtSupplierCodeStart.Name = "txtSupplierCodeStart"
            Me.Validator.SetRegularExpression(Me.txtSupplierCodeStart, "")
            Me.Validator.SetRequired(Me.txtSupplierCodeStart, False)
            Me.txtSupplierCodeStart.Size = New System.Drawing.Size(96, 21)
            Me.txtSupplierCodeStart.TabIndex = 6
            Me.txtSupplierCodeStart.Text = ""
            '
            'lblSupplierStart
            '
            Me.lblSupplierStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblSupplierStart.ForeColor = System.Drawing.Color.Black
            Me.lblSupplierStart.Location = New System.Drawing.Point(64, 96)
            Me.lblSupplierStart.Name = "lblSupplierStart"
            Me.lblSupplierStart.Size = New System.Drawing.Size(88, 18)
            Me.lblSupplierStart.TabIndex = 6
            Me.lblSupplierStart.Text = "ผู้ขาย"
            Me.lblSupplierStart.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtTemp
            '
            Me.Validator.SetDataType(Me.txtTemp, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtTemp, "")
            Me.Validator.SetGotFocusBackColor(Me.txtTemp, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtTemp, System.Drawing.Color.Empty)
            Me.txtTemp.Location = New System.Drawing.Point(696, 72)
            Me.txtTemp.MaxLength = 255
            Me.Validator.SetMaxValue(Me.txtTemp, "")
            Me.Validator.SetMinValue(Me.txtTemp, "")
            Me.txtTemp.Name = "txtTemp"
            Me.txtTemp.ReadOnly = True
            Me.Validator.SetRegularExpression(Me.txtTemp, "")
            Me.Validator.SetRequired(Me.txtTemp, False)
            Me.txtTemp.Size = New System.Drawing.Size(104, 21)
            Me.txtTemp.TabIndex = 3
            Me.txtTemp.Text = ""
            Me.txtTemp.Visible = False
            '
            'btnSearch
            '
            Me.btnSearch.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.btnSearch.Location = New System.Drawing.Point(632, 184)
            Me.btnSearch.Name = "btnSearch"
            Me.btnSearch.TabIndex = 9
            Me.btnSearch.Text = "ค้นหา"
            '
            'btnReset
            '
            Me.btnReset.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.btnReset.Location = New System.Drawing.Point(552, 184)
            Me.btnReset.Name = "btnReset"
            Me.btnReset.TabIndex = 10
            Me.btnReset.TabStop = False
            Me.btnReset.Text = "เคลียร์"
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
            'txtCheckDateEnd
            '
            Me.Validator.SetDataType(Me.txtCheckDateEnd, Longkong.Pojjaman.Gui.Components.DataTypeConstants.DateTimeType)
            Me.Validator.SetDisplayName(Me.txtCheckDateEnd, "")
            Me.Validator.SetGotFocusBackColor(Me.txtCheckDateEnd, System.Drawing.Color.Empty)
            Me.ErrorProvider1.SetIconPadding(Me.txtCheckDateEnd, -15)
            Me.Validator.SetInvalidBackColor(Me.txtCheckDateEnd, System.Drawing.Color.Empty)
            Me.txtCheckDateEnd.Location = New System.Drawing.Point(392, 48)
            Me.txtCheckDateEnd.MaxLength = 10
            Me.Validator.SetMaxValue(Me.txtCheckDateEnd, "")
            Me.Validator.SetMinValue(Me.txtCheckDateEnd, "")
            Me.txtCheckDateEnd.Name = "txtCheckDateEnd"
            Me.Validator.SetRegularExpression(Me.txtCheckDateEnd, "")
            Me.Validator.SetRequired(Me.txtCheckDateEnd, False)
            Me.txtCheckDateEnd.Size = New System.Drawing.Size(99, 21)
            Me.txtCheckDateEnd.TabIndex = 3
            Me.txtCheckDateEnd.Text = ""
            '
            'txtCheckDateStart
            '
            Me.Validator.SetDataType(Me.txtCheckDateStart, Longkong.Pojjaman.Gui.Components.DataTypeConstants.DateTimeType)
            Me.Validator.SetDisplayName(Me.txtCheckDateStart, "")
            Me.Validator.SetGotFocusBackColor(Me.txtCheckDateStart, System.Drawing.Color.Empty)
            Me.ErrorProvider1.SetIconPadding(Me.txtCheckDateStart, -15)
            Me.Validator.SetInvalidBackColor(Me.txtCheckDateStart, System.Drawing.Color.Empty)
            Me.txtCheckDateStart.Location = New System.Drawing.Point(160, 48)
            Me.txtCheckDateStart.MaxLength = 10
            Me.Validator.SetMaxValue(Me.txtCheckDateStart, "")
            Me.Validator.SetMinValue(Me.txtCheckDateStart, "")
            Me.txtCheckDateStart.Name = "txtCheckDateStart"
            Me.Validator.SetRegularExpression(Me.txtCheckDateStart, "")
            Me.Validator.SetRequired(Me.txtCheckDateStart, False)
            Me.txtCheckDateStart.Size = New System.Drawing.Size(99, 21)
            Me.txtCheckDateStart.TabIndex = 2
            Me.txtCheckDateStart.Text = ""
            '
            'dtpCheckDateStart
            '
            Me.dtpCheckDateStart.Format = System.Windows.Forms.DateTimePickerFormat.Short
            Me.dtpCheckDateStart.Location = New System.Drawing.Point(160, 48)
            Me.dtpCheckDateStart.Name = "dtpCheckDateStart"
            Me.dtpCheckDateStart.Size = New System.Drawing.Size(120, 21)
            Me.dtpCheckDateStart.TabIndex = 13
            Me.dtpCheckDateStart.TabStop = False
            '
            'dtpCheckDateEnd
            '
            Me.dtpCheckDateEnd.Format = System.Windows.Forms.DateTimePickerFormat.Short
            Me.dtpCheckDateEnd.Location = New System.Drawing.Point(392, 48)
            Me.dtpCheckDateEnd.Name = "dtpCheckDateEnd"
            Me.dtpCheckDateEnd.Size = New System.Drawing.Size(120, 21)
            Me.dtpCheckDateEnd.TabIndex = 14
            Me.dtpCheckDateEnd.TabStop = False
            '
            'lblCheckDateStart
            '
            Me.lblCheckDateStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblCheckDateStart.ForeColor = System.Drawing.Color.Black
            Me.lblCheckDateStart.Location = New System.Drawing.Point(8, 48)
            Me.lblCheckDateStart.Name = "lblCheckDateStart"
            Me.lblCheckDateStart.Size = New System.Drawing.Size(144, 18)
            Me.lblCheckDateStart.TabIndex = 31
            Me.lblCheckDateStart.Text = "วันที่ครบกำหนดตั้งแต่"
            Me.lblCheckDateStart.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblCheckDateEnd
            '
            Me.lblCheckDateEnd.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblCheckDateEnd.ForeColor = System.Drawing.Color.Black
            Me.lblCheckDateEnd.Location = New System.Drawing.Point(288, 48)
            Me.lblCheckDateEnd.Name = "lblCheckDateEnd"
            Me.lblCheckDateEnd.Size = New System.Drawing.Size(96, 18)
            Me.lblCheckDateEnd.TabIndex = 34
            Me.lblCheckDateEnd.Text = "ถึง"
            Me.lblCheckDateEnd.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'RptPaymentByCheckFilterSubPanel
            '
            Me.Controls.Add(Me.grbMaster)
            Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Name = "RptPaymentByCheckFilterSubPanel"
            Me.Size = New System.Drawing.Size(736, 232)
            Me.grbMaster.ResumeLayout(False)
            Me.grbDetail.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

#End Region

#Region " SetLabelText "
        Public Sub SetLabelText()
            'If Not m_entity Is Nothing Then Me.Text = Me.StringParserService.Parse(Me.m_entity.TabPageText)
            Me.lblDocDateStart.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptPaymentByCheckFilterSubPanel.lblDocDateStart}")
            Me.Validator.SetDisplayName(txtDocDateStart, lblDocDateStart.Text)

            ' Global {ถึง}
            Me.lblDocDateEnd.Text = Me.StringParserService.Parse("${res:Global.FilterPanelTo}")
            Me.Validator.SetDisplayName(txtDocDateEnd, lblDocDateEnd.Text)

            Me.lblCheckDateStart.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptPaymentByCheckFilterSubPanel.lblCheckDateStart}")
            Me.Validator.SetDisplayName(txtCheckDateStart, lblCheckDateStart.Text)

            Me.lblCheckDateEnd.Text = Me.StringParserService.Parse("${res:Global.FilterPanelTo}")
            Me.Validator.SetDisplayName(txtCheckDateEnd, lblCheckDateEnd.Text)

            Me.lblCheckCodeStart.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptPaymentByCheckFilterSubPanel.lblCheckCodeStart}")
            Me.Validator.SetDisplayName(txtCheckCodeStart, lblCheckCodeStart.Text)

            Me.lblSupplierStart.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptPaymentByCheckFilterSubPanel.lblSupplierStart}")
            Me.Validator.SetDisplayName(txtSupplierCodeStart, lblSupplierStart.Text)

            Me.lblCCStart.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptPaymentByCheckFilterSubPanel.lblCostcenterStart}")
            Me.Validator.SetDisplayName(txtCCCodeStart, lblCCStart.Text)

            ' Button
            Me.btnSearch.Text = Me.StringParserService.Parse("${res:Global.SearchButtonText}")
            Me.btnReset.Text = Me.StringParserService.Parse("${res:Global.ResetButtonText}")

            ' GroupBox
            Me.grbMaster.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptPaymentByCheckFilterSubPanel.grbMaster}")
            Me.grbDetail.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptPaymentByCheckFilterSubPanel.grbDetail}")

            Me.lblChkStatus.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptPaymentByCheckFilterSubPanel.lblChkStatus}")
            'Checkbox
            Me.chkIncludeChildren.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptPaymentByCheckFilterSubPanel.chkIncludeChildren}")
        End Sub
#End Region

#Region "Member"
        Private m_checkcodestart As OutgoingCheck
        Private m_supplierstart As Supplier

        Private m_DocDateEnd As Date
        Private m_DocDateStart As Date

        Private m_CheckDateEnd As Date
        Private m_CheckDateStart As Date

        Private m_chkstatus As OutgoingCheckDocStatus
        Private m_cc As CostCenter
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
        Public Property CheckDateEnd() As Date            Get                Return m_CheckDateEnd            End Get            Set(ByVal Value As Date)                m_CheckDateEnd = Value            End Set        End Property        Public Property CheckDateStart() As Date            Get                Return m_CheckDateStart            End Get            Set(ByVal Value As Date)                m_CheckDateStart = Value            End Set        End Property
        Public Property DocDateEnd() As Date            Get                Return m_DocDateEnd            End Get            Set(ByVal Value As Date)                m_DocDateEnd = Value            End Set        End Property        Public Property DocDateStart() As Date            Get                Return m_DocDateStart            End Get            Set(ByVal Value As Date)                m_DocDateStart = Value            End Set        End Property
        Private Property ChkStatus() As CodeDescription
            Get
                Return m_chkstatus
            End Get
            Set(ByVal Value As CodeDescription)
                m_chkstatus = CType(Value, OutgoingCheckDocStatus)
            End Set
        End Property
        Public Property SupplierStart() As Supplier
            Get
                Return m_supplierstart
            End Get
            Set(ByVal Value As Supplier)
                m_supplierstart = Value
            End Set
        End Property
        Public Property CheckCodeStart() As OutgoingCheck
            Get
                Return m_checkcodestart
            End Get
            Set(ByVal Value As OutgoingCheck)
                m_checkcodestart = Value
            End Set
        End Property
        Public Property Costcenter() As Costcenter
            Get
                Return m_cc
            End Get
            Set(ByVal Value As Costcenter)
                m_cc = Value
            End Set
        End Property
#End Region

#Region "Methods"
        Private Sub RegisterDropdown()
            ' รูปแบบ
            OutgoingCheckDocStatus.ListCodeDescriptionInComboBox(Me.cmbChkStatus, "outgoingcheck_docstatus", True)
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

            Me.Costcenter = New Costcenter

            Me.SupplierStart = New Supplier
            Me.CheckCodeStart = New OutgoingCheck

            Dim dtStart As Date = Date.Now.Subtract(New TimeSpan(7, 0, 0, 0))
            Me.DocDateStart = dtStart
            Me.txtDocDateStart.Text = MinDateToNull(Me.DocDateStart, "")
            Me.dtpDocDateStart.Value = Me.DocDateStart

            Me.DocDateEnd = Date.Now
            Me.txtDocDateEnd.Text = MinDateToNull(Me.DocDateEnd, "")
            Me.dtpDocDateEnd.Value = Me.DocDateEnd


            Me.CheckDateStart = dtStart
            Me.txtCheckDateStart.Text = MinDateToNull(Me.CheckDateStart, "")
            Me.dtpCheckDateStart.Value = Me.CheckDateStart

            Me.CheckDateEnd = Date.Now
            Me.txtCheckDateEnd.Text = MinDateToNull(Me.CheckDateEnd, "")
            Me.dtpCheckDateEnd.Value = Me.CheckDateEnd

            Me.cmbChkStatus.SelectedIndex = 0
        End Sub
        Public Overrides Function GetFilterString() As String

        End Function
        Public Overrides Function GetFilterArray() As Filter()
            Dim arr(9) As Filter
            arr(0) = New Filter("DocDateStart", IIf(Me.DocDateStart.Equals(Date.MinValue), DBNull.Value, Me.DocDateStart))
            arr(1) = New Filter("DocDateEnd", IIf(Me.DocDateEnd.Equals(Date.MinValue), DBNull.Value, Me.DocDateEnd))
            arr(2) = New Filter("SuppliCodeStart", IIf(txtSupplierCodeStart.TextLength > 0, txtSupplierCodeStart.Text, DBNull.Value))
            arr(3) = New Filter("CheckCodeStart", IIf(txtCheckCodeStart.TextLength > 0, txtCheckCodeStart.Text, DBNull.Value))
            arr(4) = New Filter("CheckStatus", IIf(cmbChkStatus.SelectedItem Is Nothing, DBNull.Value, CType(cmbChkStatus.SelectedItem, IdValuePair).Id))
            arr(5) = New Filter("cc_id", Me.ValidIdOrDBNull(m_cc))
            arr(6) = New Filter("IncludeChildCC", Me.chkIncludeChildren.Checked)
            arr(7) = New Filter("userRight", CType(ServiceManager.Services.GetService(GetType(SecurityService)), SecurityService).CurrentUser.Id)
            arr(8) = New Filter("CheckDateStart", IIf(Me.CheckDateStart.Equals(Date.MinValue), DBNull.Value, Me.CheckDateStart))
            arr(9) = New Filter("CheckDateEnd", IIf(Me.CheckDateEnd.Equals(Date.MinValue), DBNull.Value, Me.CheckDateEnd))
            Return arr
        End Function
        Public Overrides ReadOnly Property SearchButton() As System.Windows.Forms.Button
            Get
                Return Me.btnSearch
            End Get
        End Property

        Private Sub btnReset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReset.Click
            ClearCriterias()
            Me.btnSearch.PerformClick()
        End Sub
#End Region

#Region " IReportFilterSubPanel "
        Public Function GetFixValueCollection() As BusinessLogic.DocPrintingItemCollection Implements IReportFilterSubPanel.GetFixValueCollection
            Dim dpiColl As New DocPrintingItemCollection
            Dim dpi As DocPrintingItem

            'Docdate Start
            dpi = New DocPrintingItem
            dpi.Mapping = "docdatestart"
            dpi.Value = Me.txtDocDateStart.Text
            dpi.DataType = "System.String"
            dpiColl.Add(dpi)

            'Docdate End
            dpi = New DocPrintingItem
            dpi.Mapping = "docdateend"
            dpi.Value = Me.txtDocDateEnd.Text
            dpi.DataType = "System.String"
            dpiColl.Add(dpi)

            'CheckCode start
            dpi = New DocPrintingItem
            dpi.Mapping = "checkcodestart"
            dpi.Value = Me.txtCheckCodeStart.Text
            dpi.DataType = "System.String"
            dpiColl.Add(dpi)

            'Supplier start
            dpi = New DocPrintingItem
            dpi.Mapping = "suppliercodestart"
            dpi.Value = Me.txtSupplierCodeStart.Text
            dpi.DataType = "System.String"
            dpiColl.Add(dpi)

            'Checkstatus
            dpi = New DocPrintingItem
            dpi.Mapping = "Checkstatus"
            dpi.Value = Me.cmbChkStatus.Text
            dpi.DataType = "System.String"
            dpiColl.Add(dpi)

            'CostCenterStart
            dpi = New DocPrintingItem
            dpi.Mapping = "CostCenterStart"
            dpi.Value = txtCostCenterName.Text
            dpi.DataType = "System.String"
            dpiColl.Add(dpi)

            'Checkdate Start
            dpi = New DocPrintingItem
            dpi.Mapping = "Checkdatestart"
            dpi.Value = Me.txtCheckDateStart.Text
            dpi.DataType = "System.String"
            dpiColl.Add(dpi)

            'Checkdate End
            dpi = New DocPrintingItem
            dpi.Mapping = "Checkdateend"
            dpi.Value = Me.txtCheckDateEnd.Text
            dpi.DataType = "System.String"
            dpiColl.Add(dpi)

            Return dpiColl
        End Function
#End Region

#Region " ChangeProperty "
        Private Sub EventWiring()
            AddHandler txtDocDateStart.Validated, AddressOf Me.ChangeProperty
            AddHandler txtDocDateEnd.Validated, AddressOf Me.ChangeProperty

            AddHandler dtpDocDateStart.ValueChanged, AddressOf Me.ChangeProperty
            AddHandler dtpDocDateEnd.ValueChanged, AddressOf Me.ChangeProperty

            AddHandler txtCheckDateStart.Validated, AddressOf Me.ChangeProperty
            AddHandler txtCheckDateEnd.Validated, AddressOf Me.ChangeProperty

            AddHandler dtpCheckDateStart.ValueChanged, AddressOf Me.ChangeProperty
            AddHandler dtpCheckDateEnd.ValueChanged, AddressOf Me.ChangeProperty

            AddHandler btnCheckCodeStartFind.Click, AddressOf Me.btnCheckCodeFind_Click

            AddHandler btnCCCodeStart.Click, AddressOf Me.btnCostcenterFind_Click
            AddHandler txtCCCodeStart.Validated, AddressOf Me.ChangeProperty

            AddHandler btnSupplierStartFind.Click, AddressOf Me.btnSupplierFind_Click
            AddHandler txtSupplierCodeStart.Validated, AddressOf Me.ChangeProperty
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


                Case "dtpcheckdatestart"
                    If Not Me.CheckDateStart.Equals(dtpCheckDateStart.Value) Then
                        If Not m_dateSetting Then
                            Me.txtCheckDateStart.Text = MinDateToNull(dtpCheckDateStart.Value, Me.StringParserService.Parse("${res:Global.BlankDateText}"))
                            Me.CheckDateStart = dtpCheckDateStart.Value
                        End If
                    End If
                Case "txtcheckdatestart"
                    m_dateSetting = True
                    If Not Me.txtCheckDateStart.Text.Length = 0 AndAlso Me.Validator.GetErrorMessage(Me.txtCheckDateStart) = "" Then
                        Dim theDate As Date = CDate(Me.txtCheckDateStart.Text)
                        If Not Me.CheckDateStart.Equals(theDate) Then
                            dtpCheckDateStart.Value = theDate
                            Me.CheckDateStart = dtpCheckDateStart.Value
                        End If
                    Else
                        Me.dtpCheckDateStart.Value = Date.Now
                        Me.CheckDateStart = Date.MinValue
                    End If
                    m_dateSetting = False

                Case "dtpcheckdateend"
                    If Not Me.CheckDateEnd.Equals(dtpCheckDateEnd.Value) Then
                        If Not m_dateSetting Then
                            Me.txtCheckDateEnd.Text = MinDateToNull(dtpCheckDateEnd.Value, Me.StringParserService.Parse("${res:Global.BlankDateText}"))
                            Me.CheckDateEnd = dtpCheckDateEnd.Value
                        End If
                    End If
                Case "txtcheckdateend"
                    m_dateSetting = True
                    If Not Me.txtCheckDateEnd.Text.Length = 0 AndAlso Me.Validator.GetErrorMessage(Me.txtCheckDateEnd) = "" Then
                        Dim theDate As Date = CDate(Me.txtCheckDateEnd.Text)
                        If Not Me.CheckDateEnd.Equals(theDate) Then
                            dtpCheckDateEnd.Value = theDate
                            Me.CheckDateEnd = dtpCheckDateEnd.Value
                        End If
                    Else
                        Me.dtpCheckDateEnd.Value = Date.Now
                        Me.CheckDateEnd = Date.MinValue
                    End If
                    m_dateSetting = False
                Case "txtcccodestart"
                    Costcenter.GetCostCenter(txtCCCodeStart, Me.txtCostCenterName, m_cc, CType(ServiceManager.Services.GetService(GetType(SecurityService)), SecurityService).CurrentUser.Id)
                Case Else
            End Select
        End Sub
#End Region

#Region "IClipboardHandler Overrides"
        Public Overrides ReadOnly Property EnablePaste() As Boolean
            Get
                Dim data As IDataObject = Clipboard.GetDataObject
                ' CheckCode
                If data.GetDataPresent((New OutgoingCheck).FullClassName) Then
                    If Not Me.ActiveControl Is Nothing Then
                        Select Case Me.ActiveControl.Name.ToLower
                            Case "txtcheckcodestart", "txtcheckcodeend"
                                Return True
                        End Select
                    End If
                End If
                ' Supplier
                If data.GetDataPresent((New Supplier).FullClassName) Then
                    If Not Me.ActiveControl Is Nothing Then
                        Select Case Me.ActiveControl.Name.ToLower
                            Case "txtsuppliercodestart", "txtsuppliercodeend"
                                Return True
                        End Select
                    End If
                End If
                'CostCenter
                If data.GetDataPresent((New Costcenter).FullClassName) Then
                    If Not Me.ActiveControl Is Nothing Then
                        Select Case Me.ActiveControl.Name.ToLower
                            Case "txtcccodestart", "txtcccodeend"
                                Return True
                        End Select
                    End If
                End If
            End Get
        End Property
        Public Overrides Sub Paste(ByVal sender As Object, ByVal e As System.EventArgs)
            Dim data As IDataObject = Clipboard.GetDataObject
            ' checkcode
            If data.GetDataPresent((New OutgoingCheck).FullClassName) Then
                Dim id As Integer = CInt(data.GetData((New OutgoingCheck).FullClassName))
                Dim entity As New OutgoingCheck(id)
                If Not Me.ActiveControl Is Nothing Then
                    Select Case Me.ActiveControl.Name.ToLower
                        Case "txtcheckcodestart"
                            Me.SetCheckCodeStartDialog(entity)
                    End Select
                End If
            End If
            ' Supplier
            If data.GetDataPresent((New Supplier).FullClassName) Then
                Dim id As Integer = CInt(data.GetData((New Supplier).FullClassName))
                Dim entity As New Supplier(id)
                If Not Me.ActiveControl Is Nothing Then
                    Select Case Me.ActiveControl.Name.ToLower
                        Case "txtsuppliercodestart"
                            Me.SetSupplierStartDialog(entity)
                    End Select
                End If
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
        'CheckCode
        Private Sub btnCheckCodeFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
            Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
            Select Case CType(sender, Control).Name.ToLower
                Case "btncheckcodestartfind"
                    myEntityPanelService.OpenListDialog(New OutgoingCheck, AddressOf SetCheckCodeStartDialog)
            End Select
        End Sub
        Private Sub SetCheckCodeStartDialog(ByVal e As ISimpleEntity)
            Dim chkcode As OutgoingCheck = CType(e, OutgoingCheck)
            Me.txtCheckCodeStart.Text = chkcode.CqCode
        End Sub
        'Supplier
        Private Sub btnSupplierFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
            Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
            Select Case CType(sender, Control).Name.ToLower
                Case "btnsupplierstartfind"
                    myEntityPanelService.OpenListDialog(New Supplier, AddressOf SetSupplierStartDialog)
            End Select
        End Sub
        ' Costcenter
        Private Sub btnCostcenterFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
            Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
            Select Case CType(sender, Control).Name.ToLower
                Case "btncccodestart"
                    myEntityPanelService.OpenTreeDialog(New Costcenter, AddressOf SetCCCodeStartDialog)
            End Select
        End Sub
        Private Sub SetSupplierStartDialog(ByVal e As ISimpleEntity)
            Me.txtSupplierCodeStart.Text = e.Code
        End Sub
        Private Sub SetCCCodeStartDialog(ByVal e As ISimpleEntity)
            Me.txtCCCodeStart.Text = e.Code
            Costcenter.GetCostCenter(txtCCCodeStart, txtCostCenterName, m_cc, CType(ServiceManager.Services.GetService(GetType(SecurityService)), SecurityService).CurrentUser.Id)
        End Sub
#End Region

    End Class

End Namespace

