Imports Longkong.Pojjaman.BusinessLogic
Imports longkong.Pojjaman.Services
Imports Longkong.Core.Services

Namespace Longkong.Pojjaman.Gui.Panels
    Public Class RptPORemainingQtyFilterSubPanel
        'Inherits UserControl
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
        Friend WithEvents lblDocDateStart As System.Windows.Forms.Label
        Friend WithEvents lblDocDateEnd As System.Windows.Forms.Label
        Friend WithEvents Validator As Longkong.Pojjaman.Gui.Components.PJMTextboxValidator
        Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
        Friend WithEvents txtDocDateEnd As System.Windows.Forms.TextBox
        Friend WithEvents txtDocDateStart As System.Windows.Forms.TextBox
        Friend WithEvents dtpDocDateStart As System.Windows.Forms.DateTimePicker
        Friend WithEvents dtpDocDateEnd As System.Windows.Forms.DateTimePicker
        Friend WithEvents grbDetail As Longkong.Pojjaman.Gui.Components.FixedGroupBox
        Friend WithEvents txtTemp As System.Windows.Forms.TextBox
        Friend WithEvents chkShowAll As System.Windows.Forms.CheckBox
        Friend WithEvents chkIncludeChildren As System.Windows.Forms.CheckBox
        Friend WithEvents btnCCCodeStart As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents txtCCCodeStart As System.Windows.Forms.TextBox
        Friend WithEvents lblCCStart As System.Windows.Forms.Label
        Friend WithEvents txtCostCenterName As System.Windows.Forms.TextBox
        Friend WithEvents btnSuppliEndFind As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents txtSuppliCodeEnd As System.Windows.Forms.TextBox
        Friend WithEvents btnSuppliStartFind As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents txtSuppliCodeStart As System.Windows.Forms.TextBox
        Friend WithEvents lblSuppliStart As System.Windows.Forms.Label
        Friend WithEvents lblSuppliEnd As System.Windows.Forms.Label
        Friend WithEvents btnLciEndFind As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents txtLciCodeEnd As System.Windows.Forms.TextBox
        Friend WithEvents lblLciEnd As System.Windows.Forms.Label
        Friend WithEvents btnLciStartFind As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents txtLciCodeStart As System.Windows.Forms.TextBox
        Friend WithEvents lblLciStart As System.Windows.Forms.Label
        Friend WithEvents txtOtherName As System.Windows.Forms.TextBox
        Friend WithEvents lblOtherName As System.Windows.Forms.Label
        Friend WithEvents lblPOStart As System.Windows.Forms.Label
        Friend WithEvents lblPOEnd As System.Windows.Forms.Label
        Friend WithEvents ibtnPOStart As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents txtPOEnd As System.Windows.Forms.TextBox
        Friend WithEvents ibtnPOEnd As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents txtPOStart As System.Windows.Forms.TextBox
        Friend WithEvents grbDisplay As Longkong.Pojjaman.Gui.Components.FixedGroupBox
        Friend WithEvents cmbStatus As System.Windows.Forms.ComboBox
        Friend WithEvents txtReceiveDateEnd As System.Windows.Forms.TextBox
        Friend WithEvents txtReceiveDateStart As System.Windows.Forms.TextBox
        Friend WithEvents dtpReceiveDateStart As System.Windows.Forms.DateTimePicker
        Friend WithEvents dtpReceiveDateEnd As System.Windows.Forms.DateTimePicker
        Friend WithEvents lblReceiveDateStart As System.Windows.Forms.Label
        Friend WithEvents lblReceiveDateEnd As System.Windows.Forms.Label
        Friend WithEvents lblDocStatus As System.Windows.Forms.Label
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Me.components = New System.ComponentModel.Container()
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(RptPORemainingQtyFilterSubPanel))
            Me.grbMaster = New Longkong.Pojjaman.Gui.Components.FixedGroupBox()
            Me.grbDisplay = New Longkong.Pojjaman.Gui.Components.FixedGroupBox()
            Me.cmbStatus = New System.Windows.Forms.ComboBox()
            Me.lblDocStatus = New System.Windows.Forms.Label()
            Me.grbDetail = New Longkong.Pojjaman.Gui.Components.FixedGroupBox()
            Me.lblPOStart = New System.Windows.Forms.Label()
            Me.txtPOStart = New System.Windows.Forms.TextBox()
            Me.lblPOEnd = New System.Windows.Forms.Label()
            Me.ibtnPOStart = New Longkong.Pojjaman.Gui.Components.ImageButton()
            Me.txtPOEnd = New System.Windows.Forms.TextBox()
            Me.ibtnPOEnd = New Longkong.Pojjaman.Gui.Components.ImageButton()
            Me.chkIncludeChildren = New System.Windows.Forms.CheckBox()
            Me.btnCCCodeStart = New Longkong.Pojjaman.Gui.Components.ImageButton()
            Me.txtCCCodeStart = New System.Windows.Forms.TextBox()
            Me.lblCCStart = New System.Windows.Forms.Label()
            Me.txtCostCenterName = New System.Windows.Forms.TextBox()
            Me.chkShowAll = New System.Windows.Forms.CheckBox()
            Me.txtDocDateEnd = New System.Windows.Forms.TextBox()
            Me.txtDocDateStart = New System.Windows.Forms.TextBox()
            Me.dtpDocDateStart = New System.Windows.Forms.DateTimePicker()
            Me.dtpDocDateEnd = New System.Windows.Forms.DateTimePicker()
            Me.lblDocDateStart = New System.Windows.Forms.Label()
            Me.lblDocDateEnd = New System.Windows.Forms.Label()
            Me.lblOtherName = New System.Windows.Forms.Label()
            Me.txtOtherName = New System.Windows.Forms.TextBox()
            Me.lblLciStart = New System.Windows.Forms.Label()
            Me.txtLciCodeStart = New System.Windows.Forms.TextBox()
            Me.btnLciStartFind = New Longkong.Pojjaman.Gui.Components.ImageButton()
            Me.lblLciEnd = New System.Windows.Forms.Label()
            Me.txtLciCodeEnd = New System.Windows.Forms.TextBox()
            Me.btnLciEndFind = New Longkong.Pojjaman.Gui.Components.ImageButton()
            Me.lblSuppliStart = New System.Windows.Forms.Label()
            Me.txtSuppliCodeStart = New System.Windows.Forms.TextBox()
            Me.lblSuppliEnd = New System.Windows.Forms.Label()
            Me.btnSuppliStartFind = New Longkong.Pojjaman.Gui.Components.ImageButton()
            Me.txtSuppliCodeEnd = New System.Windows.Forms.TextBox()
            Me.btnSuppliEndFind = New Longkong.Pojjaman.Gui.Components.ImageButton()
            Me.btnSearch = New System.Windows.Forms.Button()
            Me.btnReset = New System.Windows.Forms.Button()
            Me.txtTemp = New System.Windows.Forms.TextBox()
            Me.Validator = New Longkong.Pojjaman.Gui.Components.PJMTextboxValidator(Me.components)
            Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
            Me.txtReceiveDateEnd = New System.Windows.Forms.TextBox()
            Me.txtReceiveDateStart = New System.Windows.Forms.TextBox()
            Me.dtpReceiveDateStart = New System.Windows.Forms.DateTimePicker()
            Me.dtpReceiveDateEnd = New System.Windows.Forms.DateTimePicker()
            Me.lblReceiveDateStart = New System.Windows.Forms.Label()
            Me.lblReceiveDateEnd = New System.Windows.Forms.Label()
            Me.grbMaster.SuspendLayout()
            Me.grbDisplay.SuspendLayout()
            Me.grbDetail.SuspendLayout()
            CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'grbMaster
            '
            Me.grbMaster.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.grbMaster.Controls.Add(Me.grbDisplay)
            Me.grbMaster.Controls.Add(Me.grbDetail)
            Me.grbMaster.Controls.Add(Me.btnSearch)
            Me.grbMaster.Controls.Add(Me.btnReset)
            Me.grbMaster.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.grbMaster.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.grbMaster.Location = New System.Drawing.Point(8, 8)
            Me.grbMaster.Name = "grbMaster"
            Me.grbMaster.Size = New System.Drawing.Size(860, 278)
            Me.grbMaster.TabIndex = 0
            Me.grbMaster.TabStop = False
            Me.grbMaster.Text = "เช็ครับ"
            '
            'grbDisplay
            '
            Me.grbDisplay.Controls.Add(Me.cmbStatus)
            Me.grbDisplay.Controls.Add(Me.lblDocStatus)
            Me.grbDisplay.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.grbDisplay.Location = New System.Drawing.Point(592, 16)
            Me.grbDisplay.Name = "grbDisplay"
            Me.grbDisplay.Size = New System.Drawing.Size(256, 80)
            Me.grbDisplay.TabIndex = 5
            Me.grbDisplay.TabStop = False
            Me.grbDisplay.Text = "รูปแบบการแสดงผล"
            '
            'cmbStatus
            '
            Me.cmbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cmbStatus.Location = New System.Drawing.Point(72, 34)
            Me.cmbStatus.Name = "cmbStatus"
            Me.cmbStatus.Size = New System.Drawing.Size(168, 21)
            Me.cmbStatus.TabIndex = 1
            '
            'lblDocStatus
            '
            Me.lblDocStatus.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblDocStatus.ForeColor = System.Drawing.Color.Black
            Me.lblDocStatus.Location = New System.Drawing.Point(8, 34)
            Me.lblDocStatus.Name = "lblDocStatus"
            Me.lblDocStatus.Size = New System.Drawing.Size(56, 18)
            Me.lblDocStatus.TabIndex = 0
            Me.lblDocStatus.Text = "สถานะ"
            Me.lblDocStatus.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'grbDetail
            '
            Me.grbDetail.Controls.Add(Me.txtReceiveDateEnd)
            Me.grbDetail.Controls.Add(Me.txtReceiveDateStart)
            Me.grbDetail.Controls.Add(Me.dtpReceiveDateStart)
            Me.grbDetail.Controls.Add(Me.dtpReceiveDateEnd)
            Me.grbDetail.Controls.Add(Me.lblReceiveDateStart)
            Me.grbDetail.Controls.Add(Me.lblReceiveDateEnd)
            Me.grbDetail.Controls.Add(Me.lblPOStart)
            Me.grbDetail.Controls.Add(Me.txtPOStart)
            Me.grbDetail.Controls.Add(Me.lblPOEnd)
            Me.grbDetail.Controls.Add(Me.ibtnPOStart)
            Me.grbDetail.Controls.Add(Me.txtPOEnd)
            Me.grbDetail.Controls.Add(Me.ibtnPOEnd)
            Me.grbDetail.Controls.Add(Me.chkIncludeChildren)
            Me.grbDetail.Controls.Add(Me.btnCCCodeStart)
            Me.grbDetail.Controls.Add(Me.txtCCCodeStart)
            Me.grbDetail.Controls.Add(Me.lblCCStart)
            Me.grbDetail.Controls.Add(Me.txtCostCenterName)
            Me.grbDetail.Controls.Add(Me.chkShowAll)
            Me.grbDetail.Controls.Add(Me.txtDocDateEnd)
            Me.grbDetail.Controls.Add(Me.txtDocDateStart)
            Me.grbDetail.Controls.Add(Me.dtpDocDateStart)
            Me.grbDetail.Controls.Add(Me.dtpDocDateEnd)
            Me.grbDetail.Controls.Add(Me.lblDocDateStart)
            Me.grbDetail.Controls.Add(Me.lblDocDateEnd)
            Me.grbDetail.Controls.Add(Me.lblOtherName)
            Me.grbDetail.Controls.Add(Me.txtOtherName)
            Me.grbDetail.Controls.Add(Me.lblLciStart)
            Me.grbDetail.Controls.Add(Me.txtLciCodeStart)
            Me.grbDetail.Controls.Add(Me.btnLciStartFind)
            Me.grbDetail.Controls.Add(Me.lblLciEnd)
            Me.grbDetail.Controls.Add(Me.txtLciCodeEnd)
            Me.grbDetail.Controls.Add(Me.btnLciEndFind)
            Me.grbDetail.Controls.Add(Me.lblSuppliStart)
            Me.grbDetail.Controls.Add(Me.txtSuppliCodeStart)
            Me.grbDetail.Controls.Add(Me.lblSuppliEnd)
            Me.grbDetail.Controls.Add(Me.btnSuppliStartFind)
            Me.grbDetail.Controls.Add(Me.txtSuppliCodeEnd)
            Me.grbDetail.Controls.Add(Me.btnSuppliEndFind)
            Me.grbDetail.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.grbDetail.Location = New System.Drawing.Point(16, 16)
            Me.grbDetail.Name = "grbDetail"
            Me.grbDetail.Size = New System.Drawing.Size(576, 250)
            Me.grbDetail.TabIndex = 1
            Me.grbDetail.TabStop = False
            Me.grbDetail.Text = "ข้อมูลทั่วไป"
            '
            'lblPOStart
            '
            Me.lblPOStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblPOStart.ForeColor = System.Drawing.Color.Black
            Me.lblPOStart.Location = New System.Drawing.Point(72, 104)
            Me.lblPOStart.Name = "lblPOStart"
            Me.lblPOStart.Size = New System.Drawing.Size(64, 18)
            Me.lblPOStart.TabIndex = 12
            Me.lblPOStart.Text = "PO"
            Me.lblPOStart.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtPOStart
            '
            Me.Validator.SetDataType(Me.txtPOStart, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtPOStart, "")
            Me.txtPOStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtPOStart, System.Drawing.Color.Empty)
            Me.ErrorProvider1.SetIconPadding(Me.txtPOStart, -15)
            Me.Validator.SetInvalidBackColor(Me.txtPOStart, System.Drawing.Color.Empty)
            Me.txtPOStart.Location = New System.Drawing.Point(144, 104)
            Me.Validator.SetMinValue(Me.txtPOStart, "")
            Me.txtPOStart.Name = "txtPOStart"
            Me.Validator.SetRegularExpression(Me.txtPOStart, "")
            Me.Validator.SetRequired(Me.txtPOStart, False)
            Me.txtPOStart.Size = New System.Drawing.Size(144, 21)
            Me.txtPOStart.TabIndex = 13
            '
            'lblPOEnd
            '
            Me.lblPOEnd.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblPOEnd.ForeColor = System.Drawing.Color.Black
            Me.lblPOEnd.Location = New System.Drawing.Point(320, 104)
            Me.lblPOEnd.Name = "lblPOEnd"
            Me.lblPOEnd.Size = New System.Drawing.Size(24, 18)
            Me.lblPOEnd.TabIndex = 14
            Me.lblPOEnd.Text = "ถึง"
            Me.lblPOEnd.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'ibtnPOStart
            '
            Me.ibtnPOStart.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.ibtnPOStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.ibtnPOStart.ForeColor = System.Drawing.SystemColors.Control
            Me.ibtnPOStart.Location = New System.Drawing.Point(288, 104)
            Me.ibtnPOStart.Name = "ibtnPOStart"
            Me.ibtnPOStart.Size = New System.Drawing.Size(24, 22)
            Me.ibtnPOStart.TabIndex = 15
            Me.ibtnPOStart.TabStop = False
            Me.ibtnPOStart.ThemedImage = CType(resources.GetObject("ibtnPOStart.ThemedImage"), System.Drawing.Bitmap)
            '
            'txtPOEnd
            '
            Me.Validator.SetDataType(Me.txtPOEnd, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtPOEnd, "")
            Me.txtPOEnd.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtPOEnd, System.Drawing.Color.Empty)
            Me.ErrorProvider1.SetIconPadding(Me.txtPOEnd, -15)
            Me.Validator.SetInvalidBackColor(Me.txtPOEnd, System.Drawing.Color.Empty)
            Me.txtPOEnd.Location = New System.Drawing.Point(352, 104)
            Me.Validator.SetMinValue(Me.txtPOEnd, "")
            Me.txtPOEnd.Name = "txtPOEnd"
            Me.Validator.SetRegularExpression(Me.txtPOEnd, "")
            Me.Validator.SetRequired(Me.txtPOEnd, False)
            Me.txtPOEnd.Size = New System.Drawing.Size(144, 21)
            Me.txtPOEnd.TabIndex = 16
            '
            'ibtnPOEnd
            '
            Me.ibtnPOEnd.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.ibtnPOEnd.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.ibtnPOEnd.ForeColor = System.Drawing.SystemColors.Control
            Me.ibtnPOEnd.Location = New System.Drawing.Point(496, 104)
            Me.ibtnPOEnd.Name = "ibtnPOEnd"
            Me.ibtnPOEnd.Size = New System.Drawing.Size(24, 22)
            Me.ibtnPOEnd.TabIndex = 17
            Me.ibtnPOEnd.TabStop = False
            Me.ibtnPOEnd.ThemedImage = CType(resources.GetObject("ibtnPOEnd.ThemedImage"), System.Drawing.Bitmap)
            '
            'chkIncludeChildren
            '
            Me.chkIncludeChildren.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.chkIncludeChildren.Location = New System.Drawing.Point(144, 64)
            Me.chkIncludeChildren.Name = "chkIncludeChildren"
            Me.chkIncludeChildren.Size = New System.Drawing.Size(128, 24)
            Me.chkIncludeChildren.TabIndex = 10
            Me.chkIncludeChildren.Text = "รวม Cost Center ลูก"
            '
            'btnCCCodeStart
            '
            Me.btnCCCodeStart.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.btnCCCodeStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.btnCCCodeStart.ForeColor = System.Drawing.SystemColors.Control
            Me.btnCCCodeStart.Location = New System.Drawing.Point(240, 40)
            Me.btnCCCodeStart.Name = "btnCCCodeStart"
            Me.btnCCCodeStart.Size = New System.Drawing.Size(24, 22)
            Me.btnCCCodeStart.TabIndex = 8
            Me.btnCCCodeStart.TabStop = False
            Me.btnCCCodeStart.ThemedImage = CType(resources.GetObject("btnCCCodeStart.ThemedImage"), System.Drawing.Bitmap)
            '
            'txtCCCodeStart
            '
            Me.Validator.SetDataType(Me.txtCCCodeStart, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtCCCodeStart, "")
            Me.txtCCCodeStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtCCCodeStart, System.Drawing.Color.Empty)
            Me.ErrorProvider1.SetIconPadding(Me.txtCCCodeStart, -15)
            Me.Validator.SetInvalidBackColor(Me.txtCCCodeStart, System.Drawing.Color.Empty)
            Me.txtCCCodeStart.Location = New System.Drawing.Point(144, 40)
            Me.txtCCCodeStart.MaxLength = 50
            Me.Validator.SetMinValue(Me.txtCCCodeStart, "")
            Me.txtCCCodeStart.Name = "txtCCCodeStart"
            Me.Validator.SetRegularExpression(Me.txtCCCodeStart, "")
            Me.Validator.SetRequired(Me.txtCCCodeStart, False)
            Me.txtCCCodeStart.Size = New System.Drawing.Size(96, 21)
            Me.txtCCCodeStart.TabIndex = 7
            '
            'lblCCStart
            '
            Me.lblCCStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblCCStart.ForeColor = System.Drawing.Color.Black
            Me.lblCCStart.Location = New System.Drawing.Point(8, 40)
            Me.lblCCStart.Name = "lblCCStart"
            Me.lblCCStart.Size = New System.Drawing.Size(128, 18)
            Me.lblCCStart.TabIndex = 6
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
            Me.txtCostCenterName.Location = New System.Drawing.Point(264, 40)
            Me.txtCostCenterName.MaxLength = 50
            Me.Validator.SetMinValue(Me.txtCostCenterName, "")
            Me.txtCostCenterName.Name = "txtCostCenterName"
            Me.txtCostCenterName.ReadOnly = True
            Me.Validator.SetRegularExpression(Me.txtCostCenterName, "")
            Me.Validator.SetRequired(Me.txtCostCenterName, False)
            Me.txtCostCenterName.Size = New System.Drawing.Size(160, 21)
            Me.txtCostCenterName.TabIndex = 9
            '
            'chkShowAll
            '
            Me.chkShowAll.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.chkShowAll.Location = New System.Drawing.Point(296, 64)
            Me.chkShowAll.Name = "chkShowAll"
            Me.chkShowAll.Size = New System.Drawing.Size(136, 24)
            Me.chkShowAll.TabIndex = 11
            Me.chkShowAll.Text = "แสดงทุกรายการ"
            '
            'txtDocDateEnd
            '
            Me.Validator.SetDataType(Me.txtDocDateEnd, Longkong.Pojjaman.Gui.Components.DataTypeConstants.DateTimeType)
            Me.Validator.SetDisplayName(Me.txtDocDateEnd, "")
            Me.Validator.SetGotFocusBackColor(Me.txtDocDateEnd, System.Drawing.Color.Empty)
            Me.ErrorProvider1.SetIconPadding(Me.txtDocDateEnd, -15)
            Me.Validator.SetInvalidBackColor(Me.txtDocDateEnd, System.Drawing.Color.Empty)
            Me.txtDocDateEnd.Location = New System.Drawing.Point(304, 16)
            Me.txtDocDateEnd.MaxLength = 10
            Me.Validator.SetMinValue(Me.txtDocDateEnd, "")
            Me.txtDocDateEnd.Name = "txtDocDateEnd"
            Me.Validator.SetRegularExpression(Me.txtDocDateEnd, "")
            Me.Validator.SetRequired(Me.txtDocDateEnd, False)
            Me.txtDocDateEnd.Size = New System.Drawing.Size(99, 21)
            Me.txtDocDateEnd.TabIndex = 4
            '
            'txtDocDateStart
            '
            Me.Validator.SetDataType(Me.txtDocDateStart, Longkong.Pojjaman.Gui.Components.DataTypeConstants.DateTimeType)
            Me.Validator.SetDisplayName(Me.txtDocDateStart, "")
            Me.Validator.SetGotFocusBackColor(Me.txtDocDateStart, System.Drawing.Color.Empty)
            Me.ErrorProvider1.SetIconPadding(Me.txtDocDateStart, -15)
            Me.Validator.SetInvalidBackColor(Me.txtDocDateStart, System.Drawing.Color.Empty)
            Me.txtDocDateStart.Location = New System.Drawing.Point(144, 16)
            Me.txtDocDateStart.MaxLength = 10
            Me.Validator.SetMinValue(Me.txtDocDateStart, "")
            Me.txtDocDateStart.Name = "txtDocDateStart"
            Me.Validator.SetRegularExpression(Me.txtDocDateStart, "")
            Me.Validator.SetRequired(Me.txtDocDateStart, False)
            Me.txtDocDateStart.Size = New System.Drawing.Size(99, 21)
            Me.txtDocDateStart.TabIndex = 1
            '
            'dtpDocDateStart
            '
            Me.dtpDocDateStart.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
            Me.dtpDocDateStart.Location = New System.Drawing.Point(144, 16)
            Me.dtpDocDateStart.Name = "dtpDocDateStart"
            Me.dtpDocDateStart.Size = New System.Drawing.Size(120, 21)
            Me.dtpDocDateStart.TabIndex = 2
            Me.dtpDocDateStart.TabStop = False
            '
            'dtpDocDateEnd
            '
            Me.dtpDocDateEnd.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
            Me.dtpDocDateEnd.Location = New System.Drawing.Point(304, 16)
            Me.dtpDocDateEnd.Name = "dtpDocDateEnd"
            Me.dtpDocDateEnd.Size = New System.Drawing.Size(120, 21)
            Me.dtpDocDateEnd.TabIndex = 5
            Me.dtpDocDateEnd.TabStop = False
            '
            'lblDocDateStart
            '
            Me.lblDocDateStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblDocDateStart.ForeColor = System.Drawing.Color.Black
            Me.lblDocDateStart.Location = New System.Drawing.Point(16, 16)
            Me.lblDocDateStart.Name = "lblDocDateStart"
            Me.lblDocDateStart.Size = New System.Drawing.Size(120, 18)
            Me.lblDocDateStart.TabIndex = 0
            Me.lblDocDateStart.Text = "ตั้งแต่"
            Me.lblDocDateStart.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblDocDateEnd
            '
            Me.lblDocDateEnd.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblDocDateEnd.ForeColor = System.Drawing.Color.Black
            Me.lblDocDateEnd.Location = New System.Drawing.Point(272, 16)
            Me.lblDocDateEnd.Name = "lblDocDateEnd"
            Me.lblDocDateEnd.Size = New System.Drawing.Size(24, 18)
            Me.lblDocDateEnd.TabIndex = 3
            Me.lblDocDateEnd.Text = "ถึง"
            Me.lblDocDateEnd.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'lblOtherName
            '
            Me.lblOtherName.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblOtherName.ForeColor = System.Drawing.Color.Black
            Me.lblOtherName.Location = New System.Drawing.Point(48, 152)
            Me.lblOtherName.Name = "lblOtherName"
            Me.lblOtherName.Size = New System.Drawing.Size(88, 18)
            Me.lblOtherName.TabIndex = 25
            Me.lblOtherName.Text = "อื่นๆ"
            Me.lblOtherName.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtOtherName
            '
            Me.Validator.SetDataType(Me.txtOtherName, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtOtherName, "")
            Me.txtOtherName.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtOtherName, System.Drawing.Color.Empty)
            Me.ErrorProvider1.SetIconPadding(Me.txtOtherName, -15)
            Me.Validator.SetInvalidBackColor(Me.txtOtherName, System.Drawing.Color.Empty)
            Me.txtOtherName.Location = New System.Drawing.Point(144, 152)
            Me.Validator.SetMinValue(Me.txtOtherName, "")
            Me.txtOtherName.Name = "txtOtherName"
            Me.Validator.SetRegularExpression(Me.txtOtherName, "")
            Me.Validator.SetRequired(Me.txtOtherName, False)
            Me.txtOtherName.Size = New System.Drawing.Size(376, 21)
            Me.txtOtherName.TabIndex = 26
            '
            'lblLciStart
            '
            Me.lblLciStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblLciStart.ForeColor = System.Drawing.Color.Black
            Me.lblLciStart.Location = New System.Drawing.Point(48, 176)
            Me.lblLciStart.Name = "lblLciStart"
            Me.lblLciStart.Size = New System.Drawing.Size(88, 18)
            Me.lblLciStart.TabIndex = 27
            Me.lblLciStart.Text = "ตั้งแต่วัสดุ:"
            Me.lblLciStart.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtLciCodeStart
            '
            Me.Validator.SetDataType(Me.txtLciCodeStart, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtLciCodeStart, "")
            Me.txtLciCodeStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtLciCodeStart, System.Drawing.Color.Empty)
            Me.ErrorProvider1.SetIconPadding(Me.txtLciCodeStart, -15)
            Me.Validator.SetInvalidBackColor(Me.txtLciCodeStart, System.Drawing.Color.Empty)
            Me.txtLciCodeStart.Location = New System.Drawing.Point(144, 176)
            Me.Validator.SetMinValue(Me.txtLciCodeStart, "")
            Me.txtLciCodeStart.Name = "txtLciCodeStart"
            Me.Validator.SetRegularExpression(Me.txtLciCodeStart, "")
            Me.Validator.SetRequired(Me.txtLciCodeStart, False)
            Me.txtLciCodeStart.Size = New System.Drawing.Size(144, 21)
            Me.txtLciCodeStart.TabIndex = 28
            '
            'btnLciStartFind
            '
            Me.btnLciStartFind.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.btnLciStartFind.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.btnLciStartFind.ForeColor = System.Drawing.SystemColors.Control
            Me.btnLciStartFind.Location = New System.Drawing.Point(288, 176)
            Me.btnLciStartFind.Name = "btnLciStartFind"
            Me.btnLciStartFind.Size = New System.Drawing.Size(24, 22)
            Me.btnLciStartFind.TabIndex = 29
            Me.btnLciStartFind.TabStop = False
            Me.btnLciStartFind.ThemedImage = CType(resources.GetObject("btnLciStartFind.ThemedImage"), System.Drawing.Bitmap)
            '
            'lblLciEnd
            '
            Me.lblLciEnd.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblLciEnd.ForeColor = System.Drawing.Color.Black
            Me.lblLciEnd.Location = New System.Drawing.Point(320, 176)
            Me.lblLciEnd.Name = "lblLciEnd"
            Me.lblLciEnd.Size = New System.Drawing.Size(24, 18)
            Me.lblLciEnd.TabIndex = 30
            Me.lblLciEnd.Text = "ถึง"
            Me.lblLciEnd.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'txtLciCodeEnd
            '
            Me.Validator.SetDataType(Me.txtLciCodeEnd, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtLciCodeEnd, "")
            Me.txtLciCodeEnd.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtLciCodeEnd, System.Drawing.Color.Empty)
            Me.ErrorProvider1.SetIconPadding(Me.txtLciCodeEnd, -15)
            Me.Validator.SetInvalidBackColor(Me.txtLciCodeEnd, System.Drawing.Color.Empty)
            Me.txtLciCodeEnd.Location = New System.Drawing.Point(352, 176)
            Me.Validator.SetMinValue(Me.txtLciCodeEnd, "")
            Me.txtLciCodeEnd.Name = "txtLciCodeEnd"
            Me.Validator.SetRegularExpression(Me.txtLciCodeEnd, "")
            Me.Validator.SetRequired(Me.txtLciCodeEnd, False)
            Me.txtLciCodeEnd.Size = New System.Drawing.Size(144, 21)
            Me.txtLciCodeEnd.TabIndex = 31
            '
            'btnLciEndFind
            '
            Me.btnLciEndFind.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.btnLciEndFind.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.btnLciEndFind.ForeColor = System.Drawing.SystemColors.Control
            Me.btnLciEndFind.Location = New System.Drawing.Point(496, 176)
            Me.btnLciEndFind.Name = "btnLciEndFind"
            Me.btnLciEndFind.Size = New System.Drawing.Size(24, 22)
            Me.btnLciEndFind.TabIndex = 0
            Me.btnLciEndFind.TabStop = False
            Me.btnLciEndFind.ThemedImage = CType(resources.GetObject("btnLciEndFind.ThemedImage"), System.Drawing.Bitmap)
            '
            'lblSuppliStart
            '
            Me.lblSuppliStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblSuppliStart.ForeColor = System.Drawing.Color.Black
            Me.lblSuppliStart.Location = New System.Drawing.Point(72, 128)
            Me.lblSuppliStart.Name = "lblSuppliStart"
            Me.lblSuppliStart.Size = New System.Drawing.Size(64, 18)
            Me.lblSuppliStart.TabIndex = 18
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
            Me.txtSuppliCodeStart.Location = New System.Drawing.Point(144, 129)
            Me.Validator.SetMinValue(Me.txtSuppliCodeStart, "")
            Me.txtSuppliCodeStart.Name = "txtSuppliCodeStart"
            Me.Validator.SetRegularExpression(Me.txtSuppliCodeStart, "")
            Me.Validator.SetRequired(Me.txtSuppliCodeStart, False)
            Me.txtSuppliCodeStart.Size = New System.Drawing.Size(144, 21)
            Me.txtSuppliCodeStart.TabIndex = 19
            '
            'lblSuppliEnd
            '
            Me.lblSuppliEnd.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblSuppliEnd.ForeColor = System.Drawing.Color.Black
            Me.lblSuppliEnd.Location = New System.Drawing.Point(320, 130)
            Me.lblSuppliEnd.Name = "lblSuppliEnd"
            Me.lblSuppliEnd.Size = New System.Drawing.Size(24, 18)
            Me.lblSuppliEnd.TabIndex = 21
            Me.lblSuppliEnd.Text = "ถึง"
            Me.lblSuppliEnd.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'btnSuppliStartFind
            '
            Me.btnSuppliStartFind.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.btnSuppliStartFind.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.btnSuppliStartFind.ForeColor = System.Drawing.SystemColors.Control
            Me.btnSuppliStartFind.Location = New System.Drawing.Point(288, 128)
            Me.btnSuppliStartFind.Name = "btnSuppliStartFind"
            Me.btnSuppliStartFind.Size = New System.Drawing.Size(24, 22)
            Me.btnSuppliStartFind.TabIndex = 20
            Me.btnSuppliStartFind.TabStop = False
            Me.btnSuppliStartFind.ThemedImage = CType(resources.GetObject("btnSuppliStartFind.ThemedImage"), System.Drawing.Bitmap)
            '
            'txtSuppliCodeEnd
            '
            Me.Validator.SetDataType(Me.txtSuppliCodeEnd, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtSuppliCodeEnd, "")
            Me.txtSuppliCodeEnd.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtSuppliCodeEnd, System.Drawing.Color.Empty)
            Me.ErrorProvider1.SetIconPadding(Me.txtSuppliCodeEnd, -15)
            Me.Validator.SetInvalidBackColor(Me.txtSuppliCodeEnd, System.Drawing.Color.Empty)
            Me.txtSuppliCodeEnd.Location = New System.Drawing.Point(352, 129)
            Me.Validator.SetMinValue(Me.txtSuppliCodeEnd, "")
            Me.txtSuppliCodeEnd.Name = "txtSuppliCodeEnd"
            Me.Validator.SetRegularExpression(Me.txtSuppliCodeEnd, "")
            Me.Validator.SetRequired(Me.txtSuppliCodeEnd, False)
            Me.txtSuppliCodeEnd.Size = New System.Drawing.Size(144, 21)
            Me.txtSuppliCodeEnd.TabIndex = 23
            '
            'btnSuppliEndFind
            '
            Me.btnSuppliEndFind.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.btnSuppliEndFind.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.btnSuppliEndFind.ForeColor = System.Drawing.SystemColors.Control
            Me.btnSuppliEndFind.Location = New System.Drawing.Point(496, 128)
            Me.btnSuppliEndFind.Name = "btnSuppliEndFind"
            Me.btnSuppliEndFind.Size = New System.Drawing.Size(24, 22)
            Me.btnSuppliEndFind.TabIndex = 24
            Me.btnSuppliEndFind.TabStop = False
            Me.btnSuppliEndFind.ThemedImage = CType(resources.GetObject("btnSuppliEndFind.ThemedImage"), System.Drawing.Bitmap)
            '
            'btnSearch
            '
            Me.btnSearch.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.btnSearch.Location = New System.Drawing.Point(769, 246)
            Me.btnSearch.Name = "btnSearch"
            Me.btnSearch.Size = New System.Drawing.Size(75, 23)
            Me.btnSearch.TabIndex = 0
            Me.btnSearch.Text = "ค้นหา"
            '
            'btnReset
            '
            Me.btnReset.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.btnReset.Location = New System.Drawing.Point(689, 246)
            Me.btnReset.Name = "btnReset"
            Me.btnReset.Size = New System.Drawing.Size(75, 23)
            Me.btnReset.TabIndex = 2
            Me.btnReset.TabStop = False
            Me.btnReset.Text = "เคลียร์"
            '
            'txtTemp
            '
            Me.Validator.SetDataType(Me.txtTemp, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtTemp, "")
            Me.Validator.SetGotFocusBackColor(Me.txtTemp, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtTemp, System.Drawing.Color.Empty)
            Me.txtTemp.Location = New System.Drawing.Point(648, 40)
            Me.txtTemp.MaxLength = 255
            Me.Validator.SetMinValue(Me.txtTemp, "")
            Me.txtTemp.Name = "txtTemp"
            Me.txtTemp.ReadOnly = True
            Me.Validator.SetRegularExpression(Me.txtTemp, "")
            Me.Validator.SetRequired(Me.txtTemp, False)
            Me.txtTemp.Size = New System.Drawing.Size(8, 21)
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
            'txtReceiveDateEnd
            '
            Me.Validator.SetDataType(Me.txtReceiveDateEnd, Longkong.Pojjaman.Gui.Components.DataTypeConstants.DateTimeType)
            Me.Validator.SetDisplayName(Me.txtReceiveDateEnd, "")
            Me.Validator.SetGotFocusBackColor(Me.txtReceiveDateEnd, System.Drawing.Color.Empty)
            Me.ErrorProvider1.SetIconPadding(Me.txtReceiveDateEnd, -15)
            Me.Validator.SetInvalidBackColor(Me.txtReceiveDateEnd, System.Drawing.Color.Empty)
            Me.txtReceiveDateEnd.Location = New System.Drawing.Point(352, 202)
            Me.txtReceiveDateEnd.MaxLength = 10
            Me.Validator.SetMinValue(Me.txtReceiveDateEnd, "")
            Me.txtReceiveDateEnd.Name = "txtReceiveDateEnd"
            Me.Validator.SetRegularExpression(Me.txtReceiveDateEnd, "")
            Me.Validator.SetRequired(Me.txtReceiveDateEnd, False)
            Me.txtReceiveDateEnd.Size = New System.Drawing.Size(144, 21)
            Me.txtReceiveDateEnd.TabIndex = 36
            '
            'txtReceiveDateStart
            '
            Me.Validator.SetDataType(Me.txtReceiveDateStart, Longkong.Pojjaman.Gui.Components.DataTypeConstants.DateTimeType)
            Me.Validator.SetDisplayName(Me.txtReceiveDateStart, "")
            Me.Validator.SetGotFocusBackColor(Me.txtReceiveDateStart, System.Drawing.Color.Empty)
            Me.ErrorProvider1.SetIconPadding(Me.txtReceiveDateStart, -15)
            Me.Validator.SetInvalidBackColor(Me.txtReceiveDateStart, System.Drawing.Color.Empty)
            Me.txtReceiveDateStart.Location = New System.Drawing.Point(144, 202)
            Me.txtReceiveDateStart.MaxLength = 10
            Me.Validator.SetMinValue(Me.txtReceiveDateStart, "")
            Me.txtReceiveDateStart.Name = "txtReceiveDateStart"
            Me.Validator.SetRegularExpression(Me.txtReceiveDateStart, "")
            Me.Validator.SetRequired(Me.txtReceiveDateStart, False)
            Me.txtReceiveDateStart.Size = New System.Drawing.Size(144, 21)
            Me.txtReceiveDateStart.TabIndex = 33
            '
            'dtpReceiveDateStart
            '
            Me.dtpReceiveDateStart.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
            Me.dtpReceiveDateStart.Location = New System.Drawing.Point(144, 202)
            Me.dtpReceiveDateStart.Name = "dtpReceiveDateStart"
            Me.dtpReceiveDateStart.Size = New System.Drawing.Size(165, 21)
            Me.dtpReceiveDateStart.TabIndex = 34
            Me.dtpReceiveDateStart.TabStop = False
            '
            'dtpReceiveDateEnd
            '
            Me.dtpReceiveDateEnd.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
            Me.dtpReceiveDateEnd.Location = New System.Drawing.Point(352, 202)
            Me.dtpReceiveDateEnd.Name = "dtpReceiveDateEnd"
            Me.dtpReceiveDateEnd.Size = New System.Drawing.Size(165, 21)
            Me.dtpReceiveDateEnd.TabIndex = 37
            Me.dtpReceiveDateEnd.TabStop = False
            '
            'lblReceiveDateStart
            '
            Me.lblReceiveDateStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblReceiveDateStart.ForeColor = System.Drawing.Color.Black
            Me.lblReceiveDateStart.Location = New System.Drawing.Point(16, 202)
            Me.lblReceiveDateStart.Name = "lblReceiveDateStart"
            Me.lblReceiveDateStart.Size = New System.Drawing.Size(120, 18)
            Me.lblReceiveDateStart.TabIndex = 32
            Me.lblReceiveDateStart.Text = "วันที่ครบกำหนดรับของ:"
            Me.lblReceiveDateStart.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblReceiveDateEnd
            '
            Me.lblReceiveDateEnd.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblReceiveDateEnd.ForeColor = System.Drawing.Color.Black
            Me.lblReceiveDateEnd.Location = New System.Drawing.Point(320, 202)
            Me.lblReceiveDateEnd.Name = "lblReceiveDateEnd"
            Me.lblReceiveDateEnd.Size = New System.Drawing.Size(24, 18)
            Me.lblReceiveDateEnd.TabIndex = 35
            Me.lblReceiveDateEnd.Text = "ถึง"
            Me.lblReceiveDateEnd.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'RptPORemainingQtyFilterSubPanel
            '
            Me.Controls.Add(Me.grbMaster)
            Me.Controls.Add(Me.txtTemp)
            Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Name = "RptPORemainingQtyFilterSubPanel"
            Me.Size = New System.Drawing.Size(876, 294)
            Me.grbMaster.ResumeLayout(False)
            Me.grbDisplay.ResumeLayout(False)
            Me.grbDetail.ResumeLayout(False)
            Me.grbDetail.PerformLayout()
            CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub

#End Region

#Region " SetLabelText "
        Public Sub SetLabelText()
            'If Not m_entity Is Nothing Then Me.Text = Me.StringParserService.Parse(Me.m_entity.TabPageText)
            Me.lblDocDateStart.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptPORemainingQtyFilterSubPanel.lblDocDateStart}")
            Me.Validator.SetDisplayName(txtDocDateStart, lblDocDateStart.Text)

            Me.lblDocDateEnd.Text = Me.StringParserService.Parse("${res:Global.FilterPanelTo}")
            Me.Validator.SetDisplayName(txtDocDateEnd, lblDocDateEnd.Text)

            Me.lblCCStart.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptPORemainingQtyFilterSubPanel.lblCCStart}")
            Me.Validator.SetDisplayName(txtCCCodeStart, lblCCStart.Text)
            ' Button
            Me.btnSearch.Text = Me.StringParserService.Parse("${res:Global.SearchButtonText}")
            Me.btnReset.Text = Me.StringParserService.Parse("${res:Global.ResetButtonText}")

            ' GroupBox
            Me.grbMaster.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptPORemainingQtyFilterSubPanel.grbMaster}")
            Me.grbDetail.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptPORemainingQtyFilterSubPanel.grbDetail}")

            'CheckBox
            Me.chkShowAll.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptPORemainingQtyFilterSubPanel.chkshowall}")
            Me.chkIncludeChildren.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptPORemainingQtyFilterSubPanel.chkIncludeChildren}")

            Me.lblSuppliStart.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptPORemainingQtyFilterSubPanel.lblSuppliStart}")
            Me.lblSuppliEnd.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptPORemainingQtyFilterSubPanel.lblSuppliEnd}")

            Me.lblPOStart.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptPORemainingQtyFilterSubPanel.lblPOStart}")
            Me.lblPOEnd.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptPORemainingQtyFilterSubPanel.lblPOEnd}")

            Me.lblOtherName.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptPORemainingQtyFilterSubPanel.lblOtherName}")

            Me.lblLciStart.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptPORemainingQtyFilterSubPanel.lblLciStart}")
            Me.lblLciEnd.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptPORemainingQtyFilterSubPanel.lblLciEnd}")


            'สถานะรูปแบบการแสดงผล
            Me.lblDocStatus.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptPORemainingQtyFilterSubPanel.lblStatus}") 'สถานะ
            Me.cmbStatus.Items.Add(Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptPORemainingQtyFilterSubPanel.cmbDocAll}")) 'เอกสารสั่งซื้อทั้งหมด
            Me.cmbStatus.Items.Add(Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptPORemainingQtyFilterSubPanel.cmbDocApprove}")) 'เอกสารสั่งซื้อที่อนุมัติแล้ว
            Me.cmbStatus.Items.Add(Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptPORemainingQtyFilterSubPanel.cmbDocNoApprove}")) 'เอกสารสั่งซื้อที่ยังไม่อนุมัติ

            Me.cmbStatus.SelectedIndex = 0

            Me.grbDisplay.Text = Me.StringParserService.Parse("${res:Global.grbDisplay}")
        End Sub
#End Region

#Region "Member"
        Private m_DocDateEnd As Date
        Private m_DocDateStart As Date
        Private m_cc As CostCenter

        Private m_lcistart As LCIItem
        Private m_lciend As LCIItem
        Private m_supplier As Supplier

        Private m_ReceiveDateEnd As Date
        Private m_ReceiveDateStart As Date
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
        Public Property DocDateEnd() As Date            Get                Return m_DocDateEnd            End Get            Set(ByVal Value As Date)                m_DocDateEnd = Value            End Set        End Property        Public Property DocDateStart() As Date            Get                Return m_DocDateStart            End Get            Set(ByVal Value As Date)                m_DocDateStart = Value            End Set        End Property
        Public Property LciStart() As LCIItem
            Get
                Return m_lcistart
            End Get
            Set(ByVal Value As LCIItem)
                m_lcistart = Value
            End Set
        End Property
        Public Property LciEnd() As LCIItem
            Get
                Return m_lciend
            End Get
            Set(ByVal Value As LCIItem)
                m_lciend = Value
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
        Public Property Costcenter() As CostCenter
            Get
                Return m_cc
            End Get
            Set(ByVal Value As CostCenter)
                m_cc = Value
            End Set
        End Property

        Public Property ReceiveDateEnd() As Date            Get                Return m_ReceiveDateEnd            End Get            Set(ByVal Value As Date)                m_ReceiveDateEnd = Value            End Set        End Property        Public Property ReceiveDateStart() As Date            Get                Return m_ReceiveDateStart            End Get            Set(ByVal Value As Date)                m_ReceiveDateStart = Value            End Set        End Property
#End Region

#Region "Methods"

        Private Sub Initialize()
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

            Me.LciStart = New LCIItem
            Me.LciEnd = New LCIItem

            Me.Costcenter = New CostCenter

            Dim dtStart As Date = Date.Now.Subtract(New TimeSpan(7, 0, 0, 0))
            Me.DocDateStart = dtStart
            Me.txtDocDateStart.Text = MinDateToNull(Me.DocDateStart, "")
            Me.dtpDocDateStart.Value = Me.DocDateStart

            Me.DocDateEnd = Date.Now
            Me.txtDocDateEnd.Text = MinDateToNull(Me.DocDateEnd, "")
            Me.dtpDocDateEnd.Value = Me.DocDateEnd

            Me.ReceiveDateStart = dtStart
            Me.txtReceiveDateStart.Text = MinDateToNull(Me.ReceiveDateStart, "")
            Me.dtpReceiveDateStart.Value = Me.ReceiveDateStart

            Me.ReceiveDateEnd = Date.Now
            Me.txtReceiveDateEnd.Text = MinDateToNull(Me.ReceiveDateEnd, "")
            Me.dtpReceiveDateEnd.Value = Me.ReceiveDateEnd
        End Sub
        Public Overrides Function GetFilterString() As String

        End Function
        Public Overrides Function GetFilterArray() As Filter()
            Dim arr(15) As Filter
            arr(0) = New Filter("DocDateStart", IIf(Me.DocDateStart.Equals(Date.MinValue), DBNull.Value, Me.DocDateStart))
            arr(1) = New Filter("DocDateEnd", IIf(Me.DocDateEnd.Equals(Date.MinValue), DBNull.Value, Me.DocDateEnd))
            arr(2) = New Filter("IsShowAll", IIf(Me.chkShowAll.Checked, 1, 0))
            arr(3) = New Filter("cc_id", Me.ValidIdOrDBNull(m_cc))
            arr(4) = New Filter("IncludeChildCC", Me.chkIncludeChildren.Checked)
            arr(5) = New Filter("userRight", CType(ServiceManager.Services.GetService(GetType(SecurityService)), SecurityService).CurrentUser.Id)
            arr(6) = New Filter("LciCodeStart", IIf(txtLciCodeStart.TextLength > 0, txtLciCodeStart.Text, DBNull.Value))
            arr(7) = New Filter("LciCodeEnd", IIf(txtLciCodeEnd.TextLength > 0, txtLciCodeEnd.Text, DBNull.Value))
            arr(8) = New Filter("OtherName", IIf(Me.txtOtherName.Text.Length = 0, DBNull.Value, Me.txtOtherName.Text))
            arr(9) = New Filter("SuppliCodeStart", IIf(txtSuppliCodeStart.TextLength > 0, txtSuppliCodeStart.Text, DBNull.Value))
            arr(10) = New Filter("SuppliCodeEnd", IIf(txtSuppliCodeEnd.TextLength > 0, txtSuppliCodeEnd.Text, DBNull.Value))
            arr(11) = New Filter("POCodeStart", IIf(txtPOStart.TextLength > 0, txtPOStart.Text, DBNull.Value))
            arr(12) = New Filter("POCodeEnd", IIf(txtPOEnd.TextLength > 0, txtPOEnd.Text, DBNull.Value))
            arr(13) = New Filter("Status", Me.cmbStatus.SelectedIndex)

            arr(14) = New Filter("ReceiveDateStart", IIf(Me.ReceiveDateStart.Equals(Date.MinValue), DBNull.Value, Me.ReceiveDateStart))
            arr(15) = New Filter("ReceiveDateEnd", IIf(Me.ReceiveDateEnd.Equals(Date.MinValue), DBNull.Value, Me.ReceiveDateEnd))

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

#Region "IReportFilterSubPanel"
        Public Function GetFixValueCollection() As BusinessLogic.DocPrintingItemCollection Implements IReportFilterSubPanel.GetFixValueCollection
            Dim dpiColl As New DocPrintingItemCollection
            Dim dpi As DocPrintingItem

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

            '---------------Receivedate Start
            dpi = New DocPrintingItem
            dpi.Mapping = "ReceivedateStart"
            dpi.Value = Me.txtReceiveDateStart.Text
            dpi.DataType = "System.String"
            dpiColl.Add(dpi)

            '---------------ReceiveDocdate End
            dpi = New DocPrintingItem
            dpi.Mapping = "ReceivedateEnd"
            dpi.Value = Me.txtReceiveDateEnd.Text
            dpi.DataType = "System.String"
            dpiColl.Add(dpi)
            '**********************************

            'CostCenterStart
            dpi = New DocPrintingItem
            dpi.Mapping = "CostCenterStart"
            dpi.Value = Me.txtCostCenterName.Text
            dpi.DataType = "System.String"
            dpiColl.Add(dpi)

            'LciCodeStart
            dpi = New DocPrintingItem
            dpi.Mapping = "LciCodeStart"
            dpi.Value = Me.txtLciCodeStart.Text
            dpi.DataType = "System.String"
            dpiColl.Add(dpi)

            'LciCodeEnd
            dpi = New DocPrintingItem
            dpi.Mapping = "LciCodeEnd"
            dpi.Value = Me.txtLciCodeEnd.Text
            dpi.DataType = "System.String"
            dpiColl.Add(dpi)

            'OtherName
            dpi = New DocPrintingItem
            dpi.Mapping = "OtherName"
            dpi.Value = Me.txtOtherName.Text
            dpi.DataType = "System.String"
            dpiColl.Add(dpi)

            'SupplierCodeStart
            dpi = New DocPrintingItem
            dpi.Mapping = "SupplierCodeStart"
            dpi.Value = Me.txtSuppliCodeStart.Text
            dpi.DataType = "System.String"
            dpiColl.Add(dpi)

            'SupplierCodeEnd
            dpi = New DocPrintingItem
            dpi.Mapping = "SupplierCodeEnd"
            dpi.Value = Me.txtSuppliCodeStart.Text
            dpi.DataType = "System.String"
            dpiColl.Add(dpi)

            'POCodeStart
            dpi = New DocPrintingItem
            dpi.Mapping = "POCodeStart"
            dpi.Value = Me.txtPOStart.Text
            dpi.DataType = "System.String"
            dpiColl.Add(dpi)

            'POCodeEnd
            dpi = New DocPrintingItem
            dpi.Mapping = "POCodeEnd"
            dpi.Value = Me.txtPOEnd.Text
            dpi.DataType = "System.String"
            dpiColl.Add(dpi)

            'Status
            dpi = New DocPrintingItem
            dpi.Mapping = "Status"
            dpi.Value = Me.cmbStatus.Text
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

            AddHandler btnCCCodeStart.Click, AddressOf Me.btnCostcenterFind_Click
            AddHandler txtCCCodeStart.Validated, AddressOf Me.ChangeProperty

            AddHandler btnSuppliStartFind.Click, AddressOf Me.btnSupplierFind_Click
            AddHandler btnSuppliEndFind.Click, AddressOf Me.btnSupplierFind_Click

            AddHandler btnLciStartFind.Click, AddressOf Me.btnLciFind_Click
            AddHandler btnLciEndFind.Click, AddressOf Me.btnLciFind_Click

            AddHandler ibtnPOStart.Click, AddressOf Me.btnPOFind_Click
            AddHandler ibtnPOEnd.Click, AddressOf Me.btnPOFind_Click

            AddHandler txtReceiveDateStart.Validated, AddressOf Me.ChangeProperty
            AddHandler txtReceiveDateEnd.Validated, AddressOf Me.ChangeProperty

            AddHandler dtpReceiveDateStart.ValueChanged, AddressOf Me.ChangeProperty
            AddHandler dtpReceiveDateEnd.ValueChanged, AddressOf Me.ChangeProperty

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

                    '-----------------------------------------------------------
                Case "dtpreceivedatestart"
                    If Not Me.ReceiveDateStart.Equals(dtpReceiveDateStart.Value) Then
                        If Not m_dateSetting Then
                            Me.txtReceiveDateStart.Text = MinDateToNull(dtpReceiveDateStart.Value, Me.StringParserService.Parse("${res:Global.BlankDateText}"))
                            Me.ReceiveDateStart = dtpReceiveDateStart.Value
                        End If
                    End If
                Case "txtreceivedatestart"
                    m_dateSetting = True
                    If Not Me.txtReceiveDateStart.Text.Length = 0 AndAlso Me.Validator.GetErrorMessage(Me.txtReceiveDateStart) = "" Then
                        Dim theDate As Date = CDate(Me.txtReceiveDateStart.Text)
                        If Not Me.ReceiveDateStart.Equals(theDate) Then
                            dtpReceiveDateStart.Value = theDate
                            Me.ReceiveDateStart = dtpReceiveDateStart.Value
                        End If
                    Else
                        Me.dtpReceiveDateStart.Value = Date.Now
                        Me.ReceiveDateStart = Date.MinValue
                    End If
                    m_dateSetting = False

                Case "dtpreceivedateend"
                    If Not Me.ReceiveDateEnd.Equals(dtpReceiveDateEnd.Value) Then
                        If Not m_dateSetting Then
                            Me.txtReceiveDateEnd.Text = MinDateToNull(dtpReceiveDateEnd.Value, Me.StringParserService.Parse("${res:Global.BlankDateText}"))
                            Me.ReceiveDateEnd = dtpReceiveDateEnd.Value
                        End If
                    End If
                Case "txtreceivedateend"
                    m_dateSetting = True
                    If Not Me.txtReceiveDateEnd.Text.Length = 0 AndAlso Me.Validator.GetErrorMessage(Me.txtReceiveDateEnd) = "" Then
                        Dim theDate As Date = CDate(Me.txtReceiveDateEnd.Text)
                        If Not Me.ReceiveDateEnd.Equals(theDate) Then
                            dtpReceiveDateEnd.Value = theDate
                            Me.ReceiveDateEnd = dtpReceiveDateEnd.Value
                        End If
                    Else
                        Me.dtpReceiveDateEnd.Value = Date.Now
                        Me.ReceiveDateEnd = Date.MinValue
                    End If
                    m_dateSetting = False

                Case Else

            End Select
        End Sub
#End Region

#Region "IClipboardHandler Overrides"
        Public Overrides ReadOnly Property EnablePaste() As Boolean
            Get
                Dim data As IDataObject = Clipboard.GetDataObject
                If data.GetDataPresent((New CostCenter).FullClassName) Then
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
            If data.GetDataPresent((New CostCenter).FullClassName) Then
                Dim id As Integer = CInt(data.GetData((New CostCenter).FullClassName))
                Dim entity As New CostCenter(id)
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
        Private Sub btnLciFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
            Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
            Select Case CType(sender, Control).Name.ToLower
                Case "btnlcistartfind"
                    myEntityPanelService.OpenListDialog(New LCIItem, AddressOf SetLciStartDialog)

                Case "btnlciendfind"
                    myEntityPanelService.OpenListDialog(New LCIItem, AddressOf SetLciEndDialog)
            End Select
        End Sub
        Private Sub btnPOFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
            Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
            Dim thePO As New PO
            Select Case CType(sender, Control).Name.ToLower
                Case "ibtnpostart"
                    myEntityPanelService.OpenListDialog(thePO, AddressOf SetPOStartDialog)
                Case "ibtnpoend"
                    myEntityPanelService.OpenListDialog(thePO, AddressOf SetPOEndDialog)
            End Select
            thePO = Nothing
        End Sub
        Private Sub SetSupplierStartDialog(ByVal e As ISimpleEntity)
            Me.txtSuppliCodeStart.Text = e.Code
            Supplier.GetSupplier(txtSuppliCodeStart, txtTemp, Me.Supplier)
        End Sub
        Private Sub SetSupplierEndDialog(ByVal e As ISimpleEntity)
            Me.txtSuppliCodeEnd.Text = e.Code
            Supplier.GetSupplier(txtSuppliCodeEnd, txtTemp, Me.Supplier)
        End Sub
        Private Sub SetLciStartDialog(ByVal e As ISimpleEntity)
            Me.txtLciCodeStart.Text = e.Code
            LCIItem.GetLciitem(txtLciCodeStart, txtTemp, Me.LciStart)
        End Sub
        Private Sub SetLciEndDialog(ByVal e As ISimpleEntity)
            Me.txtLciCodeEnd.Text = e.Code
            LCIItem.GetLciitem(txtLciCodeEnd, txtTemp, Me.LciEnd)
        End Sub
        Private Sub btnCostcenterFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
            Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
            Select Case CType(sender, Control).Name.ToLower
                Case "btncccodestart"
                    myEntityPanelService.OpenTreeDialog(New CostCenter, AddressOf SetCCCodeStartDialog)
            End Select
        End Sub
        Private Sub SetCCCodeStartDialog(ByVal e As ISimpleEntity)
            Me.txtCCCodeStart.Text = e.Code
            Costcenter.GetCostCenter(txtCCCodeStart, txtCostCenterName, m_cc, CType(ServiceManager.Services.GetService(GetType(SecurityService)), SecurityService).CurrentUser.Id)
        End Sub

        Private Sub SetPOStartDialog(ByVal e As ISimpleEntity)
            Me.txtPOStart.Text = e.Code
        End Sub
        Private Sub SetPOEndDialog(ByVal e As ISimpleEntity)
            Me.txtPOEnd.Text = e.Code
        End Sub
#End Region

    End Class
End Namespace

