Imports Longkong.Pojjaman.BusinessLogic
Imports longkong.Pojjaman.Services
Imports Longkong.Core.Services

Namespace Longkong.Pojjaman.Gui.Panels
    Public Class RptSupplierPOSummaryFilterSubPanel
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
        Friend WithEvents chkIncludeChildren As System.Windows.Forms.CheckBox
        Friend WithEvents btnCCCodeStart As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents txtCCCodeStart As System.Windows.Forms.TextBox
        Friend WithEvents lblCCStart As System.Windows.Forms.Label
        Friend WithEvents txtCostCenterName As System.Windows.Forms.TextBox
        Friend WithEvents btnSuppliEndFind As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents txtSuppliCodeEnd As System.Windows.Forms.TextBox
        Friend WithEvents lblSuppliEnd As System.Windows.Forms.Label
        Friend WithEvents btnSuppliStartFind As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents txtSuppliCodeStart As System.Windows.Forms.TextBox
        Friend WithEvents lblSuppliStart As System.Windows.Forms.Label
        Friend WithEvents chkIncludeChildSupplierGroup As System.Windows.Forms.CheckBox
        Friend WithEvents btnSpgCodeStart As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents txtSpgCodeStart As System.Windows.Forms.TextBox
        Friend WithEvents lblSpgStart As System.Windows.Forms.Label
        Friend WithEvents txtSupplierGroupName As System.Windows.Forms.TextBox
        Friend WithEvents grbDisplay As Longkong.Pojjaman.Gui.Components.FixedGroupBox
        Friend WithEvents cmbStatus As System.Windows.Forms.ComboBox
        Friend WithEvents lblDocStatus As System.Windows.Forms.Label
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Me.components = New System.ComponentModel.Container
            Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(RptSupplierPOSummaryFilterSubPanel))
            Me.grbMaster = New Longkong.Pojjaman.Gui.Components.FixedGroupBox
            Me.txtTemp = New System.Windows.Forms.TextBox
            Me.grbDetail = New Longkong.Pojjaman.Gui.Components.FixedGroupBox
            Me.chkIncludeChildSupplierGroup = New System.Windows.Forms.CheckBox
            Me.btnSpgCodeStart = New Longkong.Pojjaman.Gui.Components.ImageButton
            Me.txtSpgCodeStart = New System.Windows.Forms.TextBox
            Me.lblSpgStart = New System.Windows.Forms.Label
            Me.txtSupplierGroupName = New System.Windows.Forms.TextBox
            Me.btnSuppliEndFind = New Longkong.Pojjaman.Gui.Components.ImageButton
            Me.txtSuppliCodeEnd = New System.Windows.Forms.TextBox
            Me.lblSuppliEnd = New System.Windows.Forms.Label
            Me.btnSuppliStartFind = New Longkong.Pojjaman.Gui.Components.ImageButton
            Me.txtSuppliCodeStart = New System.Windows.Forms.TextBox
            Me.lblSuppliStart = New System.Windows.Forms.Label
            Me.chkIncludeChildren = New System.Windows.Forms.CheckBox
            Me.btnCCCodeStart = New Longkong.Pojjaman.Gui.Components.ImageButton
            Me.txtCCCodeStart = New System.Windows.Forms.TextBox
            Me.lblCCStart = New System.Windows.Forms.Label
            Me.txtCostCenterName = New System.Windows.Forms.TextBox
            Me.txtDocDateEnd = New System.Windows.Forms.TextBox
            Me.txtDocDateStart = New System.Windows.Forms.TextBox
            Me.dtpDocDateStart = New System.Windows.Forms.DateTimePicker
            Me.dtpDocDateEnd = New System.Windows.Forms.DateTimePicker
            Me.lblDocDateStart = New System.Windows.Forms.Label
            Me.lblDocDateEnd = New System.Windows.Forms.Label
            Me.btnSearch = New System.Windows.Forms.Button
            Me.btnReset = New System.Windows.Forms.Button
            Me.Validator = New Longkong.Pojjaman.Gui.Components.PJMTextboxValidator(Me.components)
            Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider
            Me.grbDisplay = New Longkong.Pojjaman.Gui.Components.FixedGroupBox
            Me.cmbStatus = New System.Windows.Forms.ComboBox
            Me.lblDocStatus = New System.Windows.Forms.Label
            Me.grbMaster.SuspendLayout()
            Me.grbDetail.SuspendLayout()
            Me.grbDisplay.SuspendLayout()
            Me.SuspendLayout()
            '
            'grbMaster
            '
            Me.grbMaster.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.grbMaster.Controls.Add(Me.grbDisplay)
            Me.grbMaster.Controls.Add(Me.txtTemp)
            Me.grbMaster.Controls.Add(Me.grbDetail)
            Me.grbMaster.Controls.Add(Me.btnSearch)
            Me.grbMaster.Controls.Add(Me.btnReset)
            Me.grbMaster.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.grbMaster.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.grbMaster.Location = New System.Drawing.Point(8, 0)
            Me.grbMaster.Name = "grbMaster"
            Me.grbMaster.Size = New System.Drawing.Size(688, 200)
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
            Me.grbDetail.Size = New System.Drawing.Size(408, 168)
            Me.grbDetail.TabIndex = 0
            Me.grbDetail.TabStop = False
            Me.grbDetail.Text = "ข้อมูลทั่วไป"
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
            Me.lblSuppliEnd.TabIndex = 22
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
            Me.lblSuppliStart.Location = New System.Drawing.Point(48, 88)
            Me.lblSuppliStart.Name = "lblSuppliStart"
            Me.lblSuppliStart.Size = New System.Drawing.Size(64, 18)
            Me.lblSuppliStart.TabIndex = 19
            Me.lblSuppliStart.Text = "Supplier:"
            Me.lblSuppliStart.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'chkIncludeChildren
            '
            Me.chkIncludeChildren.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.chkIncludeChildren.Location = New System.Drawing.Point(120, 136)
            Me.chkIncludeChildren.Name = "chkIncludeChildren"
            Me.chkIncludeChildren.Size = New System.Drawing.Size(128, 24)
            Me.chkIncludeChildren.TabIndex = 8
            Me.chkIncludeChildren.Text = "รวม Cost Center ลูก"
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
            'txtDocDateEnd
            '
            Me.Validator.SetDataType(Me.txtDocDateEnd, Longkong.Pojjaman.Gui.Components.DataTypeConstants.DateTimeType)
            Me.Validator.SetDisplayName(Me.txtDocDateEnd, "")
            Me.Validator.SetGotFocusBackColor(Me.txtDocDateEnd, System.Drawing.Color.Empty)
            Me.ErrorProvider1.SetIconPadding(Me.txtDocDateEnd, -15)
            Me.Validator.SetInvalidBackColor(Me.txtDocDateEnd, System.Drawing.Color.Empty)
            Me.txtDocDateEnd.Location = New System.Drawing.Point(280, 16)
            Me.txtDocDateEnd.MaxLength = 10
            Me.Validator.SetMaxValue(Me.txtDocDateEnd, "")
            Me.Validator.SetMinValue(Me.txtDocDateEnd, "")
            Me.txtDocDateEnd.Name = "txtDocDateEnd"
            Me.Validator.SetRegularExpression(Me.txtDocDateEnd, "")
            Me.Validator.SetRequired(Me.txtDocDateEnd, False)
            Me.txtDocDateEnd.Size = New System.Drawing.Size(99, 21)
            Me.txtDocDateEnd.TabIndex = 2
            Me.txtDocDateEnd.Text = ""
            '
            'txtDocDateStart
            '
            Me.Validator.SetDataType(Me.txtDocDateStart, Longkong.Pojjaman.Gui.Components.DataTypeConstants.DateTimeType)
            Me.Validator.SetDisplayName(Me.txtDocDateStart, "")
            Me.Validator.SetGotFocusBackColor(Me.txtDocDateStart, System.Drawing.Color.Empty)
            Me.ErrorProvider1.SetIconPadding(Me.txtDocDateStart, -15)
            Me.Validator.SetInvalidBackColor(Me.txtDocDateStart, System.Drawing.Color.Empty)
            Me.txtDocDateStart.Location = New System.Drawing.Point(120, 16)
            Me.txtDocDateStart.MaxLength = 10
            Me.Validator.SetMaxValue(Me.txtDocDateStart, "")
            Me.Validator.SetMinValue(Me.txtDocDateStart, "")
            Me.txtDocDateStart.Name = "txtDocDateStart"
            Me.Validator.SetRegularExpression(Me.txtDocDateStart, "")
            Me.Validator.SetRequired(Me.txtDocDateStart, False)
            Me.txtDocDateStart.Size = New System.Drawing.Size(99, 21)
            Me.txtDocDateStart.TabIndex = 1
            Me.txtDocDateStart.Text = ""
            '
            'dtpDocDateStart
            '
            Me.dtpDocDateStart.Format = System.Windows.Forms.DateTimePickerFormat.Short
            Me.dtpDocDateStart.Location = New System.Drawing.Point(120, 16)
            Me.dtpDocDateStart.Name = "dtpDocDateStart"
            Me.dtpDocDateStart.Size = New System.Drawing.Size(120, 21)
            Me.dtpDocDateStart.TabIndex = 2
            Me.dtpDocDateStart.TabStop = False
            '
            'dtpDocDateEnd
            '
            Me.dtpDocDateEnd.Format = System.Windows.Forms.DateTimePickerFormat.Short
            Me.dtpDocDateEnd.Location = New System.Drawing.Point(280, 16)
            Me.dtpDocDateEnd.Name = "dtpDocDateEnd"
            Me.dtpDocDateEnd.Size = New System.Drawing.Size(120, 21)
            Me.dtpDocDateEnd.TabIndex = 5
            Me.dtpDocDateEnd.TabStop = False
            '
            'lblDocDateStart
            '
            Me.lblDocDateStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblDocDateStart.ForeColor = System.Drawing.Color.Black
            Me.lblDocDateStart.Location = New System.Drawing.Point(56, 16)
            Me.lblDocDateStart.Name = "lblDocDateStart"
            Me.lblDocDateStart.Size = New System.Drawing.Size(56, 18)
            Me.lblDocDateStart.TabIndex = 0
            Me.lblDocDateStart.Text = "ตั้งแต่"
            Me.lblDocDateStart.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblDocDateEnd
            '
            Me.lblDocDateEnd.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblDocDateEnd.ForeColor = System.Drawing.Color.Black
            Me.lblDocDateEnd.Location = New System.Drawing.Point(248, 16)
            Me.lblDocDateEnd.Name = "lblDocDateEnd"
            Me.lblDocDateEnd.Size = New System.Drawing.Size(24, 18)
            Me.lblDocDateEnd.TabIndex = 3
            Me.lblDocDateEnd.Text = "ถึง"
            Me.lblDocDateEnd.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'btnSearch
            '
            Me.btnSearch.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.btnSearch.Location = New System.Drawing.Point(596, 168)
            Me.btnSearch.Name = "btnSearch"
            Me.btnSearch.TabIndex = 2
            Me.btnSearch.Text = "ค้นหา"
            '
            'btnReset
            '
            Me.btnReset.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.btnReset.Location = New System.Drawing.Point(516, 168)
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
            'grbDisplay
            '
            Me.grbDisplay.Controls.Add(Me.cmbStatus)
            Me.grbDisplay.Controls.Add(Me.lblDocStatus)
            Me.grbDisplay.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.grbDisplay.Location = New System.Drawing.Point(424, 16)
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
            'RptSupplierPOSummaryFilterSubPanel
            '
            Me.Controls.Add(Me.grbMaster)
            Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Name = "RptSupplierPOSummaryFilterSubPanel"
            Me.Size = New System.Drawing.Size(704, 208)
            Me.grbMaster.ResumeLayout(False)
            Me.grbDetail.ResumeLayout(False)
            Me.grbDisplay.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

#End Region

#Region " SetLabelText "
        Public Sub SetLabelText()
            'If Not m_entity Is Nothing Then Me.Text = Me.StringParserService.Parse(Me.m_entity.TabPageText)
            Me.lblCCStart.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptSupplierPOSummaryFilterSubPanel.lblCostcenterStart}")
            Me.Validator.SetDisplayName(txtCCCodeStart, lblCCStart.Text)

            Me.lblSuppliStart.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptSupplierPOSummaryFilterSubPanel.lblSuppliStart}")
            Me.Validator.SetDisplayName(txtSuppliCodeStart, lblSuppliStart.Text)

            Me.lblDocDateStart.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptSupplierPOSummaryFilterSubPanel.lblDocDateStart}")
            Me.Validator.SetDisplayName(txtDocDateStart, lblDocDateStart.Text)

            Me.lblDocDateEnd.Text = Me.StringParserService.Parse("${res:Global.FilterPanelTo}")
            Me.Validator.SetDisplayName(txtDocDateEnd, lblDocDateEnd.Text)
            ' Button
            Me.btnSearch.Text = Me.StringParserService.Parse("${res:Global.SearchButtonText}")
            Me.btnReset.Text = Me.StringParserService.Parse("${res:Global.ResetButtonText}")

            ' GroupBox
            Me.grbMaster.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptSupplierPOSummaryFilterSubPanel.grbMaster}")
            Me.grbDetail.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptSupplierPOSummaryFilterSubPanel.grbDetail}")
            Me.lblSpgStart.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptSupplierPOSummaryFilterSubPanel.lblSpgStart}")
            Me.chkIncludeChildSupplierGroup.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptSupplierPOSummaryFilterSubPanel.chkIncludeChildSupplierGroup}")


            'สถานะรูปแบบการแสดงผล
            Me.lblDocStatus.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptSupplierPOSummaryFilterSubPanel.lblStatus}") 'สถานะ
            Me.cmbStatus.Items.Add(Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptSupplierPOSummaryFilterSubPanel.cmbDocAll}")) 'เอกสารสั่งซื้อทั้งหมด
            Me.cmbStatus.Items.Add(Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptSupplierPOSummaryFilterSubPanel.cmbDocApprove}")) 'เอกสารสั่งซื้อที่อนุมัติแล้ว
            Me.cmbStatus.Items.Add(Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptSupplierPOSummaryFilterSubPanel.cmbDocNoApprove}")) 'เอกสารสั่งซื้อที่ยังไม่อนุมัติ

            Me.cmbStatus.SelectedIndex = 0
            Me.grbDisplay.Text = Me.StringParserService.Parse("${res:Global.grbDisplay}")
            Me.lblSuppliEnd.Text = Me.StringParserService.Parse("${res:Global.FilterPanelTo}")
            Me.chkIncludeChildren.Text = Me.StringParserService.Parse("${res:Global.chkIncludeChildren}")
        End Sub
#End Region

#Region "Member"
        Private m_cc As Costcenter
        Private m_supplier As Supplier
        Private m_DocDateEnd As Date
        Private m_DocDateStart As Date
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
        Public Property Costcenter() As CostCenter
            Get
                Return m_cc
            End Get
            Set(ByVal Value As CostCenter)
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
        Public Property DocDateEnd() As Date            Get                Return m_DocDateEnd            End Get            Set(ByVal Value As Date)                m_DocDateEnd = Value            End Set        End Property        Public Property DocDateStart() As Date            Get                Return m_DocDateStart            End Get            Set(ByVal Value As Date)                m_DocDateStart = Value            End Set        End Property
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
            Me.Costcenter = New CostCenter

            Dim dtStart As Date = Date.Now.Subtract(New TimeSpan(7, 0, 0, 0))
            Me.DocDateStart = dtStart
            Me.txtDocDateStart.Text = MinDateToNull(Me.DocDateStart, "")
            Me.dtpDocDateStart.Value = Me.DocDateStart

            Me.DocDateEnd = Date.Now
            Me.txtDocDateEnd.Text = MinDateToNull(Me.DocDateEnd, "")
            Me.dtpDocDateEnd.Value = Me.DocDateEnd
            Me.SupplierGroup = New SupplierGroup
        End Sub
        Public Overrides Function GetFilterString() As String

        End Function
        Public Overrides Function GetFilterArray() As Filter()
            Dim arr(9) As Filter
            arr(0) = New Filter("DocDateStart", IIf(Me.DocDateStart.Equals(Date.MinValue), DBNull.Value, Me.DocDateStart))
            arr(1) = New Filter("DocDateEnd", IIf(Me.DocDateEnd.Equals(Date.MinValue), DBNull.Value, Me.DocDateEnd))
            arr(2) = New Filter("SuppliCodeStart", IIf(txtSuppliCodeStart.TextLength > 0, txtSuppliCodeStart.Text, DBNull.Value))
            arr(3) = New Filter("SuppliCodeEnd", IIf(txtSuppliCodeEnd.TextLength > 0, txtSuppliCodeEnd.Text, DBNull.Value))
            arr(4) = New Filter("cc_id", Me.ValidIdOrDBNull(m_cc))
            arr(5) = New Filter("IncludeChildCC", Me.chkIncludeChildren.Checked)
            arr(6) = New Filter("userRight", CType(ServiceManager.Services.GetService(GetType(SecurityService)), SecurityService).CurrentUser.Id)
            arr(7) = New Filter("SupplierGroupID", Me.ValidIdOrDBNull(m_suppliergroup))
            arr(8) = New Filter("IncludeChildSupplierGroup", Me.chkIncludeChildSupplierGroup.Checked)
            arr(9) = New Filter("Status", Me.cmbStatus.SelectedIndex)

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
                dpi.Value = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptSupplierPOSummaryFilterSubPanel.childSupplierGroupincluded}")
                dpi.DataType = "System.String"
                dpiColl.Add(dpi)
            End If

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

            AddHandler btnSuppliStartFind.Click, AddressOf Me.btnSupplierFind_Click
            AddHandler btnSuppliEndFind.Click, AddressOf Me.btnSupplierFind_Click

            AddHandler btnCCCodeStart.Click, AddressOf Me.btnCostcenterFind_Click
            AddHandler txtCCCodeStart.Validated, AddressOf Me.ChangeProperty

            'AddHandler txtSuppliCodeStart.Validated, AddressOf Me.ChangeProperty
            'AddHandler txtSuppliCodeEnd.Validated, AddressOf Me.ChangeProperty

            AddHandler txtDocDateStart.Validated, AddressOf Me.ChangeProperty
            AddHandler txtDocDateEnd.Validated, AddressOf Me.ChangeProperty

            AddHandler dtpDocDateStart.ValueChanged, AddressOf Me.ChangeProperty
            AddHandler dtpDocDateEnd.ValueChanged, AddressOf Me.ChangeProperty
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

