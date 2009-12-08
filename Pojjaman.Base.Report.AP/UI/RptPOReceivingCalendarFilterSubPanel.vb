Imports Longkong.Pojjaman.BusinessLogic
Imports longkong.Pojjaman.Services
Imports Longkong.Core.Services

Namespace Longkong.Pojjaman.Gui.Panels
    Public Class RptPOReceivingCalendarFilterSubPanel
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
        Friend WithEvents grbDetail As Longkong.Pojjaman.Gui.Components.FixedGroupBox
        Friend WithEvents txtSuppliCodeStart As System.Windows.Forms.TextBox
        Friend WithEvents lblSuppliStart As System.Windows.Forms.Label
        Friend WithEvents btnSuppliStartFind As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents lblSuppliEnd As System.Windows.Forms.Label
        Friend WithEvents btnSuppliEndFind As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents txtSuppliCodeEnd As System.Windows.Forms.TextBox
        Friend WithEvents txtTemp As System.Windows.Forms.TextBox
        Friend WithEvents chkIncludeChildren As System.Windows.Forms.CheckBox
        Friend WithEvents btnCCCodeStart As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents txtCCCodeStart As System.Windows.Forms.TextBox
        Friend WithEvents lblCCStart As System.Windows.Forms.Label
        Friend WithEvents txtCostCenterName As System.Windows.Forms.TextBox
        Friend WithEvents txtReceivingDateEnd As System.Windows.Forms.TextBox
        Friend WithEvents txtReceivingDateStart As System.Windows.Forms.TextBox
        Friend WithEvents dtpReceivingDateStart As System.Windows.Forms.DateTimePicker
        Friend WithEvents dtpReceivingDateEnd As System.Windows.Forms.DateTimePicker
        Friend WithEvents lblReceivingDateStart As System.Windows.Forms.Label
        Friend WithEvents lblReceivingDateEnd As System.Windows.Forms.Label
        Friend WithEvents chkIncludeChildSupplierGroup As System.Windows.Forms.CheckBox
        Friend WithEvents btnSpgCodeStart As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents txtSpgCodeStart As System.Windows.Forms.TextBox
        Friend WithEvents lblSpgStart As System.Windows.Forms.Label
        Friend WithEvents txtSupplierGroupName As System.Windows.Forms.TextBox
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Me.components = New System.ComponentModel.Container
            Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(RptPOReceivingCalendarFilterSubPanel))
            Me.grbMaster = New Longkong.Pojjaman.Gui.Components.FixedGroupBox
            Me.txtTemp = New System.Windows.Forms.TextBox
            Me.grbDetail = New Longkong.Pojjaman.Gui.Components.FixedGroupBox
            Me.chkIncludeChildren = New System.Windows.Forms.CheckBox
            Me.btnCCCodeStart = New Longkong.Pojjaman.Gui.Components.ImageButton
            Me.txtCCCodeStart = New System.Windows.Forms.TextBox
            Me.lblCCStart = New System.Windows.Forms.Label
            Me.txtCostCenterName = New System.Windows.Forms.TextBox
            Me.btnSuppliEndFind = New Longkong.Pojjaman.Gui.Components.ImageButton
            Me.txtSuppliCodeEnd = New System.Windows.Forms.TextBox
            Me.lblSuppliEnd = New System.Windows.Forms.Label
            Me.btnSuppliStartFind = New Longkong.Pojjaman.Gui.Components.ImageButton
            Me.txtSuppliCodeStart = New System.Windows.Forms.TextBox
            Me.lblSuppliStart = New System.Windows.Forms.Label
            Me.txtReceivingDateEnd = New System.Windows.Forms.TextBox
            Me.txtReceivingDateStart = New System.Windows.Forms.TextBox
            Me.dtpReceivingDateStart = New System.Windows.Forms.DateTimePicker
            Me.dtpReceivingDateEnd = New System.Windows.Forms.DateTimePicker
            Me.lblReceivingDateStart = New System.Windows.Forms.Label
            Me.lblReceivingDateEnd = New System.Windows.Forms.Label
            Me.btnSearch = New System.Windows.Forms.Button
            Me.btnReset = New System.Windows.Forms.Button
            Me.Validator = New Longkong.Pojjaman.Gui.Components.PJMTextboxValidator(Me.components)
            Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider
            Me.chkIncludeChildSupplierGroup = New System.Windows.Forms.CheckBox
            Me.btnSpgCodeStart = New Longkong.Pojjaman.Gui.Components.ImageButton
            Me.txtSpgCodeStart = New System.Windows.Forms.TextBox
            Me.lblSpgStart = New System.Windows.Forms.Label
            Me.txtSupplierGroupName = New System.Windows.Forms.TextBox
            Me.grbMaster.SuspendLayout()
            Me.grbDetail.SuspendLayout()
            Me.SuspendLayout()
            '
            'grbMaster
            '
            Me.grbMaster.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.grbMaster.Controls.Add(Me.txtTemp)
            Me.grbMaster.Controls.Add(Me.grbDetail)
            Me.grbMaster.Controls.Add(Me.btnSearch)
            Me.grbMaster.Controls.Add(Me.btnReset)
            Me.grbMaster.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.grbMaster.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.grbMaster.Location = New System.Drawing.Point(8, 0)
            Me.grbMaster.Name = "grbMaster"
            Me.grbMaster.Size = New System.Drawing.Size(440, 224)
            Me.grbMaster.TabIndex = 0
            Me.grbMaster.TabStop = False
            Me.grbMaster.Text = "เช็ครับ"
            '
            'txtTemp
            '
            Me.Validator.SetDataType(Me.txtTemp, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtTemp, "")
            Me.Validator.SetGotFocusBackColor(Me.txtTemp, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtTemp, System.Drawing.Color.Empty)
            Me.txtTemp.Location = New System.Drawing.Point(464, 32)
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
            'grbDetail
            '
            Me.grbDetail.Controls.Add(Me.chkIncludeChildSupplierGroup)
            Me.grbDetail.Controls.Add(Me.btnSpgCodeStart)
            Me.grbDetail.Controls.Add(Me.txtSpgCodeStart)
            Me.grbDetail.Controls.Add(Me.lblSpgStart)
            Me.grbDetail.Controls.Add(Me.txtSupplierGroupName)
            Me.grbDetail.Controls.Add(Me.chkIncludeChildren)
            Me.grbDetail.Controls.Add(Me.btnCCCodeStart)
            Me.grbDetail.Controls.Add(Me.txtCCCodeStart)
            Me.grbDetail.Controls.Add(Me.lblCCStart)
            Me.grbDetail.Controls.Add(Me.txtCostCenterName)
            Me.grbDetail.Controls.Add(Me.btnSuppliEndFind)
            Me.grbDetail.Controls.Add(Me.txtSuppliCodeEnd)
            Me.grbDetail.Controls.Add(Me.lblSuppliEnd)
            Me.grbDetail.Controls.Add(Me.btnSuppliStartFind)
            Me.grbDetail.Controls.Add(Me.txtSuppliCodeStart)
            Me.grbDetail.Controls.Add(Me.lblSuppliStart)
            Me.grbDetail.Controls.Add(Me.txtReceivingDateEnd)
            Me.grbDetail.Controls.Add(Me.txtReceivingDateStart)
            Me.grbDetail.Controls.Add(Me.dtpReceivingDateStart)
            Me.grbDetail.Controls.Add(Me.dtpReceivingDateEnd)
            Me.grbDetail.Controls.Add(Me.lblReceivingDateStart)
            Me.grbDetail.Controls.Add(Me.lblReceivingDateEnd)
            Me.grbDetail.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.grbDetail.Location = New System.Drawing.Point(16, 16)
            Me.grbDetail.Name = "grbDetail"
            Me.grbDetail.Size = New System.Drawing.Size(408, 168)
            Me.grbDetail.TabIndex = 0
            Me.grbDetail.TabStop = False
            Me.grbDetail.Text = "ข้อมูลทั่วไป"
            '
            'chkIncludeChildren
            '
            Me.chkIncludeChildren.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.chkIncludeChildren.Location = New System.Drawing.Point(120, 136)
            Me.chkIncludeChildren.Name = "chkIncludeChildren"
            Me.chkIncludeChildren.Size = New System.Drawing.Size(256, 24)
            Me.chkIncludeChildren.TabIndex = 8
            Me.chkIncludeChildren.Text = "Cost Center Child Included"
            '
            'btnCCCodeStart
            '
            Me.btnCCCodeStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.btnCCCodeStart.ForeColor = System.Drawing.SystemColors.Control
            Me.btnCCCodeStart.Image = CType(resources.GetObject("btnCCCodeStart.Image"), System.Drawing.Image)
            Me.btnCCCodeStart.Location = New System.Drawing.Point(216, 112)
            Me.btnCCCodeStart.Name = "btnCCCodeStart"
            Me.btnCCCodeStart.Size = New System.Drawing.Size(24, 22)
            Me.btnCCCodeStart.TabIndex = 12
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
            Me.txtCCCodeStart.Location = New System.Drawing.Point(120, 112)
            Me.txtCCCodeStart.MaxLength = 50
            Me.Validator.SetMaxValue(Me.txtCCCodeStart, "")
            Me.Validator.SetMinValue(Me.txtCCCodeStart, "")
            Me.txtCCCodeStart.Name = "txtCCCodeStart"
            Me.Validator.SetRegularExpression(Me.txtCCCodeStart, "")
            Me.Validator.SetRequired(Me.txtCCCodeStart, False)
            Me.txtCCCodeStart.Size = New System.Drawing.Size(96, 21)
            Me.txtCCCodeStart.TabIndex = 6
            Me.txtCCCodeStart.Text = ""
            '
            'lblCCStart
            '
            Me.lblCCStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblCCStart.ForeColor = System.Drawing.Color.Black
            Me.lblCCStart.Location = New System.Drawing.Point(8, 112)
            Me.lblCCStart.Name = "lblCCStart"
            Me.lblCCStart.Size = New System.Drawing.Size(104, 18)
            Me.lblCCStart.TabIndex = 14
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
            Me.txtCostCenterName.Location = New System.Drawing.Point(240, 112)
            Me.txtCostCenterName.MaxLength = 50
            Me.Validator.SetMaxValue(Me.txtCostCenterName, "")
            Me.Validator.SetMinValue(Me.txtCostCenterName, "")
            Me.txtCostCenterName.Name = "txtCostCenterName"
            Me.txtCostCenterName.ReadOnly = True
            Me.Validator.SetRegularExpression(Me.txtCostCenterName, "")
            Me.Validator.SetRequired(Me.txtCostCenterName, False)
            Me.txtCostCenterName.Size = New System.Drawing.Size(160, 21)
            Me.txtCostCenterName.TabIndex = 15
            Me.txtCostCenterName.Text = ""
            '
            'btnSuppliEndFind
            '
            Me.btnSuppliEndFind.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.btnSuppliEndFind.ForeColor = System.Drawing.SystemColors.Control
            Me.btnSuppliEndFind.Image = CType(resources.GetObject("btnSuppliEndFind.Image"), System.Drawing.Image)
            Me.btnSuppliEndFind.Location = New System.Drawing.Point(376, 88)
            Me.btnSuppliEndFind.Name = "btnSuppliEndFind"
            Me.btnSuppliEndFind.Size = New System.Drawing.Size(24, 22)
            Me.btnSuppliEndFind.TabIndex = 11
            Me.btnSuppliEndFind.TabStop = False
            Me.btnSuppliEndFind.ThemedImage = CType(resources.GetObject("btnSuppliEndFind.ThemedImage"), System.Drawing.Bitmap)
            '
            'txtSuppliCodeEnd
            '
            Me.Validator.SetDataType(Me.txtSuppliCodeEnd, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtSuppliCodeEnd, "")
            Me.txtSuppliCodeEnd.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtSuppliCodeEnd, System.Drawing.Color.Empty)
            Me.ErrorProvider1.SetIconPadding(Me.txtSuppliCodeEnd, -15)
            Me.Validator.SetInvalidBackColor(Me.txtSuppliCodeEnd, System.Drawing.Color.Empty)
            Me.txtSuppliCodeEnd.Location = New System.Drawing.Point(280, 88)
            Me.Validator.SetMaxValue(Me.txtSuppliCodeEnd, "")
            Me.Validator.SetMinValue(Me.txtSuppliCodeEnd, "")
            Me.txtSuppliCodeEnd.Name = "txtSuppliCodeEnd"
            Me.Validator.SetRegularExpression(Me.txtSuppliCodeEnd, "")
            Me.Validator.SetRequired(Me.txtSuppliCodeEnd, False)
            Me.txtSuppliCodeEnd.Size = New System.Drawing.Size(96, 21)
            Me.txtSuppliCodeEnd.TabIndex = 5
            Me.txtSuppliCodeEnd.Text = ""
            '
            'lblSuppliEnd
            '
            Me.lblSuppliEnd.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblSuppliEnd.ForeColor = System.Drawing.Color.Black
            Me.lblSuppliEnd.Location = New System.Drawing.Point(248, 88)
            Me.lblSuppliEnd.Name = "lblSuppliEnd"
            Me.lblSuppliEnd.Size = New System.Drawing.Size(24, 18)
            Me.lblSuppliEnd.TabIndex = 9
            Me.lblSuppliEnd.Text = "ถึง"
            Me.lblSuppliEnd.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'btnSuppliStartFind
            '
            Me.btnSuppliStartFind.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.btnSuppliStartFind.ForeColor = System.Drawing.SystemColors.Control
            Me.btnSuppliStartFind.Image = CType(resources.GetObject("btnSuppliStartFind.Image"), System.Drawing.Image)
            Me.btnSuppliStartFind.Location = New System.Drawing.Point(216, 88)
            Me.btnSuppliStartFind.Name = "btnSuppliStartFind"
            Me.btnSuppliStartFind.Size = New System.Drawing.Size(24, 22)
            Me.btnSuppliStartFind.TabIndex = 10
            Me.btnSuppliStartFind.TabStop = False
            Me.btnSuppliStartFind.ThemedImage = CType(resources.GetObject("btnSuppliStartFind.ThemedImage"), System.Drawing.Bitmap)
            '
            'txtSuppliCodeStart
            '
            Me.Validator.SetDataType(Me.txtSuppliCodeStart, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtSuppliCodeStart, "")
            Me.txtSuppliCodeStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtSuppliCodeStart, System.Drawing.Color.Empty)
            Me.ErrorProvider1.SetIconPadding(Me.txtSuppliCodeStart, -15)
            Me.Validator.SetInvalidBackColor(Me.txtSuppliCodeStart, System.Drawing.Color.Empty)
            Me.txtSuppliCodeStart.Location = New System.Drawing.Point(120, 88)
            Me.Validator.SetMaxValue(Me.txtSuppliCodeStart, "")
            Me.Validator.SetMinValue(Me.txtSuppliCodeStart, "")
            Me.txtSuppliCodeStart.Name = "txtSuppliCodeStart"
            Me.Validator.SetRegularExpression(Me.txtSuppliCodeStart, "")
            Me.Validator.SetRequired(Me.txtSuppliCodeStart, False)
            Me.txtSuppliCodeStart.Size = New System.Drawing.Size(96, 21)
            Me.txtSuppliCodeStart.TabIndex = 4
            Me.txtSuppliCodeStart.Text = ""
            '
            'lblSuppliStart
            '
            Me.lblSuppliStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblSuppliStart.ForeColor = System.Drawing.Color.Black
            Me.lblSuppliStart.Location = New System.Drawing.Point(8, 88)
            Me.lblSuppliStart.Name = "lblSuppliStart"
            Me.lblSuppliStart.Size = New System.Drawing.Size(104, 18)
            Me.lblSuppliStart.TabIndex = 6
            Me.lblSuppliStart.Text = "Supplier:"
            Me.lblSuppliStart.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtReceivingDateEnd
            '
            Me.Validator.SetDataType(Me.txtReceivingDateEnd, Longkong.Pojjaman.Gui.Components.DataTypeConstants.DateTimeType)
            Me.Validator.SetDisplayName(Me.txtReceivingDateEnd, "")
            Me.Validator.SetGotFocusBackColor(Me.txtReceivingDateEnd, System.Drawing.Color.Empty)
            Me.ErrorProvider1.SetIconPadding(Me.txtReceivingDateEnd, -15)
            Me.Validator.SetInvalidBackColor(Me.txtReceivingDateEnd, System.Drawing.Color.Empty)
            Me.txtReceivingDateEnd.Location = New System.Drawing.Point(280, 16)
            Me.txtReceivingDateEnd.MaxLength = 10
            Me.Validator.SetMaxValue(Me.txtReceivingDateEnd, "")
            Me.Validator.SetMinValue(Me.txtReceivingDateEnd, "")
            Me.txtReceivingDateEnd.Name = "txtReceivingDateEnd"
            Me.Validator.SetRegularExpression(Me.txtReceivingDateEnd, "")
            Me.Validator.SetRequired(Me.txtReceivingDateEnd, False)
            Me.txtReceivingDateEnd.Size = New System.Drawing.Size(99, 21)
            Me.txtReceivingDateEnd.TabIndex = 2
            Me.txtReceivingDateEnd.Text = ""
            '
            'txtReceivingDateStart
            '
            Me.Validator.SetDataType(Me.txtReceivingDateStart, Longkong.Pojjaman.Gui.Components.DataTypeConstants.DateTimeType)
            Me.Validator.SetDisplayName(Me.txtReceivingDateStart, "")
            Me.Validator.SetGotFocusBackColor(Me.txtReceivingDateStart, System.Drawing.Color.Empty)
            Me.ErrorProvider1.SetIconPadding(Me.txtReceivingDateStart, -15)
            Me.Validator.SetInvalidBackColor(Me.txtReceivingDateStart, System.Drawing.Color.Empty)
            Me.txtReceivingDateStart.Location = New System.Drawing.Point(120, 16)
            Me.txtReceivingDateStart.MaxLength = 10
            Me.Validator.SetMaxValue(Me.txtReceivingDateStart, "")
            Me.Validator.SetMinValue(Me.txtReceivingDateStart, "")
            Me.txtReceivingDateStart.Name = "txtReceivingDateStart"
            Me.Validator.SetRegularExpression(Me.txtReceivingDateStart, "")
            Me.Validator.SetRequired(Me.txtReceivingDateStart, False)
            Me.txtReceivingDateStart.Size = New System.Drawing.Size(99, 21)
            Me.txtReceivingDateStart.TabIndex = 1
            Me.txtReceivingDateStart.Text = ""
            '
            'dtpReceivingDateStart
            '
            Me.dtpReceivingDateStart.Format = System.Windows.Forms.DateTimePickerFormat.Short
            Me.dtpReceivingDateStart.Location = New System.Drawing.Point(120, 16)
            Me.dtpReceivingDateStart.Name = "dtpReceivingDateStart"
            Me.dtpReceivingDateStart.Size = New System.Drawing.Size(120, 21)
            Me.dtpReceivingDateStart.TabIndex = 2
            Me.dtpReceivingDateStart.TabStop = False
            '
            'dtpReceivingDateEnd
            '
            Me.dtpReceivingDateEnd.Format = System.Windows.Forms.DateTimePickerFormat.Short
            Me.dtpReceivingDateEnd.Location = New System.Drawing.Point(280, 16)
            Me.dtpReceivingDateEnd.Name = "dtpReceivingDateEnd"
            Me.dtpReceivingDateEnd.Size = New System.Drawing.Size(120, 21)
            Me.dtpReceivingDateEnd.TabIndex = 5
            Me.dtpReceivingDateEnd.TabStop = False
            '
            'lblReceivingDateStart
            '
            Me.lblReceivingDateStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblReceivingDateStart.ForeColor = System.Drawing.Color.Black
            Me.lblReceivingDateStart.Location = New System.Drawing.Point(8, 16)
            Me.lblReceivingDateStart.Name = "lblReceivingDateStart"
            Me.lblReceivingDateStart.Size = New System.Drawing.Size(104, 18)
            Me.lblReceivingDateStart.TabIndex = 0
            Me.lblReceivingDateStart.Text = "ตั้งแต่"
            Me.lblReceivingDateStart.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblReceivingDateEnd
            '
            Me.lblReceivingDateEnd.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblReceivingDateEnd.ForeColor = System.Drawing.Color.Black
            Me.lblReceivingDateEnd.Location = New System.Drawing.Point(248, 16)
            Me.lblReceivingDateEnd.Name = "lblReceivingDateEnd"
            Me.lblReceivingDateEnd.Size = New System.Drawing.Size(24, 18)
            Me.lblReceivingDateEnd.TabIndex = 3
            Me.lblReceivingDateEnd.Text = "ถึง"
            Me.lblReceivingDateEnd.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'btnSearch
            '
            Me.btnSearch.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.btnSearch.Location = New System.Drawing.Point(348, 192)
            Me.btnSearch.Name = "btnSearch"
            Me.btnSearch.TabIndex = 2
            Me.btnSearch.Text = "ค้นหา"
            '
            'btnReset
            '
            Me.btnReset.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.btnReset.Location = New System.Drawing.Point(268, 192)
            Me.btnReset.Name = "btnReset"
            Me.btnReset.TabIndex = 1
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
            'chkIncludeChildSupplierGroup
            '
            Me.chkIncludeChildSupplierGroup.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.chkIncludeChildSupplierGroup.Location = New System.Drawing.Point(120, 64)
            Me.chkIncludeChildSupplierGroup.Name = "chkIncludeChildSupplierGroup"
            Me.chkIncludeChildSupplierGroup.Size = New System.Drawing.Size(128, 24)
            Me.chkIncludeChildSupplierGroup.TabIndex = 7
            Me.chkIncludeChildSupplierGroup.Text = "รวมกลุ่มผู้ขายลูก"
            '
            'btnSpgCodeStart
            '
            Me.btnSpgCodeStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.btnSpgCodeStart.ForeColor = System.Drawing.SystemColors.Control
            Me.btnSpgCodeStart.Image = CType(resources.GetObject("btnSpgCodeStart.Image"), System.Drawing.Image)
            Me.btnSpgCodeStart.Location = New System.Drawing.Point(216, 40)
            Me.btnSpgCodeStart.Name = "btnSpgCodeStart"
            Me.btnSpgCodeStart.Size = New System.Drawing.Size(24, 22)
            Me.btnSpgCodeStart.TabIndex = 9
            Me.btnSpgCodeStart.TabStop = False
            Me.btnSpgCodeStart.ThemedImage = CType(resources.GetObject("btnSpgCodeStart.ThemedImage"), System.Drawing.Bitmap)
            '
            'txtSpgCodeStart
            '
            Me.Validator.SetDataType(Me.txtSpgCodeStart, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtSpgCodeStart, "")
            Me.txtSpgCodeStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtSpgCodeStart, System.Drawing.Color.Empty)
            Me.ErrorProvider1.SetIconPadding(Me.txtSpgCodeStart, -15)
            Me.Validator.SetInvalidBackColor(Me.txtSpgCodeStart, System.Drawing.Color.Empty)
            Me.txtSpgCodeStart.Location = New System.Drawing.Point(120, 40)
            Me.txtSpgCodeStart.MaxLength = 50
            Me.Validator.SetMaxValue(Me.txtSpgCodeStart, "")
            Me.Validator.SetMinValue(Me.txtSpgCodeStart, "")
            Me.txtSpgCodeStart.Name = "txtSpgCodeStart"
            Me.Validator.SetRegularExpression(Me.txtSpgCodeStart, "")
            Me.Validator.SetRequired(Me.txtSpgCodeStart, False)
            Me.txtSpgCodeStart.Size = New System.Drawing.Size(96, 21)
            Me.txtSpgCodeStart.TabIndex = 3
            Me.txtSpgCodeStart.Text = ""
            '
            'lblSpgStart
            '
            Me.lblSpgStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblSpgStart.ForeColor = System.Drawing.Color.Black
            Me.lblSpgStart.Location = New System.Drawing.Point(24, 40)
            Me.lblSpgStart.Name = "lblSpgStart"
            Me.lblSpgStart.Size = New System.Drawing.Size(88, 18)
            Me.lblSpgStart.TabIndex = 40
            Me.lblSpgStart.Text = "กลุ่มผู้ขาย"
            Me.lblSpgStart.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtSupplierGroupName
            '
            Me.Validator.SetDataType(Me.txtSupplierGroupName, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtSupplierGroupName, "")
            Me.txtSupplierGroupName.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtSupplierGroupName, System.Drawing.Color.Empty)
            Me.ErrorProvider1.SetIconPadding(Me.txtSupplierGroupName, -15)
            Me.Validator.SetInvalidBackColor(Me.txtSupplierGroupName, System.Drawing.Color.Empty)
            Me.txtSupplierGroupName.Location = New System.Drawing.Point(240, 40)
            Me.txtSupplierGroupName.MaxLength = 50
            Me.Validator.SetMaxValue(Me.txtSupplierGroupName, "")
            Me.Validator.SetMinValue(Me.txtSupplierGroupName, "")
            Me.txtSupplierGroupName.Name = "txtSupplierGroupName"
            Me.txtSupplierGroupName.ReadOnly = True
            Me.Validator.SetRegularExpression(Me.txtSupplierGroupName, "")
            Me.Validator.SetRequired(Me.txtSupplierGroupName, False)
            Me.txtSupplierGroupName.Size = New System.Drawing.Size(160, 21)
            Me.txtSupplierGroupName.TabIndex = 41
            Me.txtSupplierGroupName.Text = ""
            '
            'RptPOReceivingCalendarFilterSubPanel
            '
            Me.Controls.Add(Me.grbMaster)
            Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Name = "RptPOReceivingCalendarFilterSubPanel"
            Me.Size = New System.Drawing.Size(472, 240)
            Me.grbMaster.ResumeLayout(False)
            Me.grbDetail.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

#End Region

#Region " SetLabelText "
        Public Sub SetLabelText()
            'If Not m_entity Is Nothing Then Me.Text = Me.StringParserService.Parse(Me.m_entity.TabPageText)
            Me.lblSuppliStart.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptPOReceivingCalendarFilterSubPanel.lblSuppliStart}")
            Me.Validator.SetDisplayName(txtSuppliCodeStart, lblSuppliStart.Text)

            Me.lblCCStart.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptPOReceivingCalendarFilterSubPanel.lblCostcenterStart}")
            Me.Validator.SetDisplayName(txtCCCodeStart, lblCCStart.Text)

            Me.lblReceivingDateStart.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptPOReceivingCalendarFilterSubPanel.lblReceivingDateStart}")
            Me.Validator.SetDisplayName(txtReceivingDateStart, lblReceivingDateStart.Text)

            ' Global {ถึง}
            Me.lblSuppliEnd.Text = Me.StringParserService.Parse("${res:Global.FilterPanelTo}")
            Me.Validator.SetDisplayName(txtSuppliCodeStart, lblSuppliStart.Text)

            Me.lblReceivingDateEnd.Text = Me.StringParserService.Parse("${res:Global.FilterPanelTo}")
            Me.Validator.SetDisplayName(txtReceivingDateEnd, lblReceivingDateEnd.Text)
            ' Button
            Me.btnSearch.Text = Me.StringParserService.Parse("${res:Global.SearchButtonText}")
            Me.btnReset.Text = Me.StringParserService.Parse("${res:Global.ResetButtonText}")

            ' GroupBox
            Me.grbMaster.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptPOReceivingCalendarFilterSubPanel.grbMaster}")
            Me.grbDetail.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptPOReceivingCalendarFilterSubPanel.grbDetail}")
            Me.lblSpgStart.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptPOReceivingCalendarFilterSubPanel.lblSpgStart}")
            Me.chkIncludeChildSupplierGroup.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptPOReceivingCalendarFilterSubPanel.chkIncludeChildSupplierGroup}")
        End Sub
#End Region

#Region "Member"
        Private m_supplier As Supplier
        Private m_cc As Costcenter

        Private m_ReceivingDateEnd As Date
        Private m_ReceivingDateStart As Date
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
        Public Property Supplier() As Supplier
            Get
                Return m_supplier
            End Get
            Set(ByVal Value As Supplier)
                m_supplier = Value
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
        Public Property ReceivingDateEnd() As Date            Get                Return m_ReceivingDateEnd            End Get            Set(ByVal Value As Date)                m_ReceivingDateEnd = Value            End Set        End Property        Public Property ReceivingDateStart() As Date            Get                Return m_ReceivingDateStart            End Get            Set(ByVal Value As Date)                m_ReceivingDateStart = Value            End Set        End Property
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
            Me.Costcenter = New Costcenter

            Dim dtStart As Date = Date.Now.Subtract(New TimeSpan(7, 0, 0, 0))
            Me.ReceivingDateStart = dtStart
            Me.txtReceivingDateStart.Text = MinDateToNull(Me.ReceivingDateStart, "")
            Me.dtpReceivingDateStart.Value = Me.ReceivingDateStart

            Me.ReceivingDateEnd = Date.Now
            Me.txtReceivingDateEnd.Text = MinDateToNull(Me.ReceivingDateEnd, "")
            Me.dtpReceivingDateEnd.Value = Me.ReceivingDateEnd
            Me.SupplierGroup = New SupplierGroup
        End Sub
        Public Overrides Function GetFilterString() As String

        End Function
        Public Overrides Function GetFilterArray() As Filter()
            Dim arr(8) As Filter
            arr(0) = New Filter("ReceivingDateStart", IIf(Me.ReceivingDateStart.Equals(Date.MinValue), DBNull.Value, Me.ReceivingDateStart))
            arr(1) = New Filter("ReceivingDateEnd", IIf(Me.ReceivingDateEnd.Equals(Date.MinValue), DBNull.Value, Me.ReceivingDateEnd))
            arr(2) = New Filter("SuppliCodeStart", IIf(txtSuppliCodeStart.TextLength > 0, txtSuppliCodeStart.Text, DBNull.Value))
            arr(3) = New Filter("SuppliCodeEnd", IIf(txtSuppliCodeEnd.TextLength > 0, txtSuppliCodeEnd.Text, DBNull.Value))
            arr(4) = New Filter("cc_id", Me.ValidIdOrDBNull(m_cc))
            arr(5) = New Filter("IncludeChildCC", Me.chkIncludeChildren.Checked)
            arr(6) = New Filter("userRight", CType(ServiceManager.Services.GetService(GetType(SecurityService)), SecurityService).CurrentUser.Id)
            arr(7) = New Filter("SupplierGroupID", Me.ValidIdOrDBNull(m_suppliergroup))
            arr(8) = New Filter("IncludeChildSupplierGroup", Me.chkIncludeChildSupplierGroup.Checked)
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

            'ReceivingDate Start
            dpi = New DocPrintingItem
            dpi.Mapping = "ReceivingDateStart"
            dpi.Value = Me.txtReceivingDateStart.Text
            dpi.DataType = "System.String"
            dpiColl.Add(dpi)

            'ReceivingDate End
            dpi = New DocPrintingItem
            dpi.Mapping = "ReceivingDateEnd"
            dpi.Value = Me.txtReceivingDateEnd.Text
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

            'Supplier Start
            dpi = New DocPrintingItem
            dpi.Mapping = "SupplierStart"
            dpi.Value = Me.txtSuppliCodeStart.Text
            dpi.DataType = "System.String"
            dpiColl.Add(dpi)

            'Supplier End
            dpi = New DocPrintingItem
            dpi.Mapping = "SupplierEnd"
            dpi.Value = Me.txtSuppliCodeEnd.Text
            dpi.DataType = "System.String"
            dpiColl.Add(dpi)

            'CostCenter Start
            dpi = New DocPrintingItem
            dpi.Mapping = "CostcenterStart"
            dpi.Value = Me.txtCostCenterName.Text
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
                dpi.Value = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptPOReceivingCalendarFilterSubPanel.childSupplierGroupincluded}")
                dpi.DataType = "System.String"
                dpiColl.Add(dpi)
            End If

            Return dpiColl
        End Function
#End Region

#Region " ChangeProperty "
        Private Sub EventWiring()
            AddHandler btnSuppliStartFind.Click, AddressOf Me.btnSupplierFind_Click
            AddHandler btnSuppliEndFind.Click, AddressOf Me.btnSupplierFind_Click

            AddHandler btnCCCodeStart.Click, AddressOf Me.btnCostcenterFind_Click
            AddHandler txtCCCodeStart.Validated, AddressOf Me.ChangeProperty

            AddHandler txtReceivingDateStart.Validated, AddressOf Me.ChangeProperty
            AddHandler txtReceivingDateEnd.Validated, AddressOf Me.ChangeProperty

            AddHandler dtpReceivingDateStart.ValueChanged, AddressOf Me.ChangeProperty
            AddHandler dtpReceivingDateEnd.ValueChanged, AddressOf Me.ChangeProperty
            AddHandler btnSpgCodeStart.Click, AddressOf Me.btnSupplierGroupFind_Click

        End Sub

        Private m_dateSetting As Boolean
        Private Sub ChangeProperty(ByVal sender As Object, ByVal e As EventArgs)

            Select Case CType(sender, Control).Name.ToLower
                Case "txtcccodestart"
                    Costcenter.GetCostCenter(txtCCCodeStart, Me.txtCostCenterName, m_cc, CType(ServiceManager.Services.GetService(GetType(SecurityService)), SecurityService).CurrentUser.Id)

                Case "dtpreceivingdatestart"
                    If Not Me.ReceivingDateStart.Equals(dtpReceivingDateStart.Value) Then
                        If Not m_dateSetting Then
                            Me.txtReceivingDateStart.Text = MinDateToNull(dtpReceivingDateStart.Value, Me.StringParserService.Parse("${res:Global.BlankDateText}"))
                            Me.ReceivingDateStart = dtpReceivingDateStart.Value
                        End If
                    End If
                Case "txtreceivingdatestart"
                    m_dateSetting = True
                    If Not Me.txtReceivingDateStart.Text.Length = 0 AndAlso Me.Validator.GetErrorMessage(Me.txtReceivingDateStart) = "" Then
                        Dim theDate As Date = CDate(Me.txtReceivingDateStart.Text)
                        If Not Me.ReceivingDateStart.Equals(theDate) Then
                            dtpReceivingDateStart.Value = theDate
                            Me.ReceivingDateStart = dtpReceivingDateStart.Value
                        End If
                    Else
                        Me.dtpReceivingDateStart.Value = Date.Now
                        Me.ReceivingDateStart = Date.MinValue
                    End If
                    m_dateSetting = False

                Case "dtpreceivingdateend"
                    If Not Me.ReceivingDateEnd.Equals(dtpReceivingDateEnd.Value) Then
                        If Not m_dateSetting Then
                            Me.txtReceivingDateEnd.Text = MinDateToNull(dtpReceivingDateEnd.Value, Me.StringParserService.Parse("${res:Global.BlankDateText}"))
                            Me.ReceivingDateEnd = dtpReceivingDateEnd.Value
                        End If
                    End If
                Case "txtreceivingdateend"
                    m_dateSetting = True
                    If Not Me.txtReceivingDateEnd.Text.Length = 0 AndAlso Me.Validator.GetErrorMessage(Me.txtReceivingDateEnd) = "" Then
                        Dim theDate As Date = CDate(Me.txtReceivingDateEnd.Text)
                        If Not Me.ReceivingDateEnd.Equals(theDate) Then
                            dtpReceivingDateEnd.Value = theDate
                            Me.ReceivingDateEnd = dtpReceivingDateEnd.Value
                        End If
                    Else
                        Me.dtpReceivingDateEnd.Value = Date.Now
                        Me.ReceivingDateEnd = Date.MinValue
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
#End Region

    End Class
End Namespace

