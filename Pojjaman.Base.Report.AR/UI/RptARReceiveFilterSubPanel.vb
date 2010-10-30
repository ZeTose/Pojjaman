Option Strict On
Option Explicit On
Imports Longkong.Pojjaman.BusinessLogic
Imports Longkong.Pojjaman.Services
Imports Longkong.Core.Services

Namespace Longkong.Pojjaman.Gui.Panels
    Public Class RptARReceiveFilterSubPanel
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
        Friend WithEvents txtcustCodeStart As System.Windows.Forms.TextBox
        Friend WithEvents lblcustStart As System.Windows.Forms.Label
        Friend WithEvents lblcustEnd As System.Windows.Forms.Label
        Friend WithEvents txtcustCodeEnd As System.Windows.Forms.TextBox
        Friend WithEvents txtTemp As System.Windows.Forms.TextBox
        Friend WithEvents chkIncludeChildren As System.Windows.Forms.CheckBox
        Friend WithEvents btnCCCodeStart As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents txtCCCodeStart As System.Windows.Forms.TextBox
        Friend WithEvents lblCCStart As System.Windows.Forms.Label
        Friend WithEvents txtCostCenterName As System.Windows.Forms.TextBox
        Friend WithEvents btnCustEndFind As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents btnCustStartFind As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents chkShowDetail As System.Windows.Forms.CheckBox
        Friend WithEvents Label2 As System.Windows.Forms.Label
        Friend WithEvents Label1 As System.Windows.Forms.Label
        Friend WithEvents txtRefDocCodePrefix As System.Windows.Forms.TextBox
        Friend WithEvents txtGLCodeprefix As System.Windows.Forms.TextBox
        Friend WithEvents grbTypeDisplay As Longkong.Pojjaman.Gui.Components.FixedGroupBox
        Friend WithEvents chkChq As System.Windows.Forms.CheckBox
        Friend WithEvents chkTransfer As System.Windows.Forms.CheckBox
        Friend WithEvents cmbReceiveType As System.Windows.Forms.ComboBox
        Friend WithEvents btnCustomerGroup As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents txtCustomerGroupCode As System.Windows.Forms.TextBox
        Friend WithEvents lblCustomerGroup As System.Windows.Forms.Label
        Friend WithEvents txtCustomerGroupName As System.Windows.Forms.TextBox
        Friend WithEvents chkIncludeChildCust As System.Windows.Forms.CheckBox
        Friend WithEvents chkCash As System.Windows.Forms.CheckBox
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Me.components = New System.ComponentModel.Container()
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(RptARReceiveFilterSubPanel))
            Me.grbMaster = New Longkong.Pojjaman.Gui.Components.FixedGroupBox()
            Me.txtTemp = New System.Windows.Forms.TextBox()
            Me.grbDetail = New Longkong.Pojjaman.Gui.Components.FixedGroupBox()
            Me.btnCustomerGroup = New Longkong.Pojjaman.Gui.Components.ImageButton()
            Me.txtCustomerGroupCode = New System.Windows.Forms.TextBox()
            Me.lblCustomerGroup = New System.Windows.Forms.Label()
            Me.txtCustomerGroupName = New System.Windows.Forms.TextBox()
            Me.chkIncludeChildCust = New System.Windows.Forms.CheckBox()
            Me.grbTypeDisplay = New Longkong.Pojjaman.Gui.Components.FixedGroupBox()
            Me.chkChq = New System.Windows.Forms.CheckBox()
            Me.chkTransfer = New System.Windows.Forms.CheckBox()
            Me.chkCash = New System.Windows.Forms.CheckBox()
            Me.Label2 = New System.Windows.Forms.Label()
            Me.Label1 = New System.Windows.Forms.Label()
            Me.txtRefDocCodePrefix = New System.Windows.Forms.TextBox()
            Me.txtGLCodeprefix = New System.Windows.Forms.TextBox()
            Me.btnCustEndFind = New Longkong.Pojjaman.Gui.Components.ImageButton()
            Me.btnCustStartFind = New Longkong.Pojjaman.Gui.Components.ImageButton()
            Me.chkIncludeChildren = New System.Windows.Forms.CheckBox()
            Me.btnCCCodeStart = New Longkong.Pojjaman.Gui.Components.ImageButton()
            Me.txtCCCodeStart = New System.Windows.Forms.TextBox()
            Me.lblCCStart = New System.Windows.Forms.Label()
            Me.txtCostCenterName = New System.Windows.Forms.TextBox()
            Me.txtcustCodeEnd = New System.Windows.Forms.TextBox()
            Me.lblcustEnd = New System.Windows.Forms.Label()
            Me.txtcustCodeStart = New System.Windows.Forms.TextBox()
            Me.lblcustStart = New System.Windows.Forms.Label()
            Me.txtDocDateEnd = New System.Windows.Forms.TextBox()
            Me.txtDocDateStart = New System.Windows.Forms.TextBox()
            Me.dtpDocDateStart = New System.Windows.Forms.DateTimePicker()
            Me.dtpDocDateEnd = New System.Windows.Forms.DateTimePicker()
            Me.lblDocDateStart = New System.Windows.Forms.Label()
            Me.lblDocDateEnd = New System.Windows.Forms.Label()
            Me.chkShowDetail = New System.Windows.Forms.CheckBox()
            Me.btnSearch = New System.Windows.Forms.Button()
            Me.btnReset = New System.Windows.Forms.Button()
            Me.cmbReceiveType = New System.Windows.Forms.ComboBox()
            Me.Validator = New Longkong.Pojjaman.Gui.Components.PJMTextboxValidator(Me.components)
            Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
            Me.grbMaster.SuspendLayout()
            Me.grbDetail.SuspendLayout()
            Me.grbTypeDisplay.SuspendLayout()
            CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
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
            Me.grbMaster.Controls.Add(Me.cmbReceiveType)
            Me.grbMaster.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.grbMaster.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.grbMaster.Location = New System.Drawing.Point(8, 8)
            Me.grbMaster.Name = "grbMaster"
            Me.grbMaster.Size = New System.Drawing.Size(717, 225)
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
            Me.txtTemp.Location = New System.Drawing.Point(729, 24)
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
            'grbDetail
            '
            Me.grbDetail.Controls.Add(Me.btnCustomerGroup)
            Me.grbDetail.Controls.Add(Me.txtCustomerGroupCode)
            Me.grbDetail.Controls.Add(Me.lblCustomerGroup)
            Me.grbDetail.Controls.Add(Me.txtCustomerGroupName)
            Me.grbDetail.Controls.Add(Me.chkIncludeChildCust)
            Me.grbDetail.Controls.Add(Me.grbTypeDisplay)
            Me.grbDetail.Controls.Add(Me.Label2)
            Me.grbDetail.Controls.Add(Me.Label1)
            Me.grbDetail.Controls.Add(Me.txtRefDocCodePrefix)
            Me.grbDetail.Controls.Add(Me.txtGLCodeprefix)
            Me.grbDetail.Controls.Add(Me.btnCustEndFind)
            Me.grbDetail.Controls.Add(Me.btnCustStartFind)
            Me.grbDetail.Controls.Add(Me.chkIncludeChildren)
            Me.grbDetail.Controls.Add(Me.btnCCCodeStart)
            Me.grbDetail.Controls.Add(Me.txtCCCodeStart)
            Me.grbDetail.Controls.Add(Me.lblCCStart)
            Me.grbDetail.Controls.Add(Me.txtCostCenterName)
            Me.grbDetail.Controls.Add(Me.txtcustCodeEnd)
            Me.grbDetail.Controls.Add(Me.lblcustEnd)
            Me.grbDetail.Controls.Add(Me.txtcustCodeStart)
            Me.grbDetail.Controls.Add(Me.lblcustStart)
            Me.grbDetail.Controls.Add(Me.txtDocDateEnd)
            Me.grbDetail.Controls.Add(Me.txtDocDateStart)
            Me.grbDetail.Controls.Add(Me.dtpDocDateStart)
            Me.grbDetail.Controls.Add(Me.dtpDocDateEnd)
            Me.grbDetail.Controls.Add(Me.lblDocDateStart)
            Me.grbDetail.Controls.Add(Me.lblDocDateEnd)
            Me.grbDetail.Controls.Add(Me.chkShowDetail)
            Me.grbDetail.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.grbDetail.Location = New System.Drawing.Point(16, 16)
            Me.grbDetail.Name = "grbDetail"
            Me.grbDetail.Size = New System.Drawing.Size(690, 171)
            Me.grbDetail.TabIndex = 0
            Me.grbDetail.TabStop = False
            Me.grbDetail.Text = "ข้อมูลทั่วไป"
            '
            'btnCustomerGroup
            '
            Me.btnCustomerGroup.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.btnCustomerGroup.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.btnCustomerGroup.ForeColor = System.Drawing.SystemColors.Control
            Me.btnCustomerGroup.Location = New System.Drawing.Point(190, 64)
            Me.btnCustomerGroup.Name = "btnCustomerGroup"
            Me.btnCustomerGroup.Size = New System.Drawing.Size(24, 22)
            Me.btnCustomerGroup.TabIndex = 97
            Me.btnCustomerGroup.TabStop = False
            Me.btnCustomerGroup.ThemedImage = CType(resources.GetObject("btnCustomerGroup.ThemedImage"), System.Drawing.Bitmap)
            '
            'txtCustomerGroupCode
            '
            Me.Validator.SetDataType(Me.txtCustomerGroupCode, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtCustomerGroupCode, "")
            Me.txtCustomerGroupCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtCustomerGroupCode, System.Drawing.Color.Empty)
            Me.ErrorProvider1.SetIconPadding(Me.txtCustomerGroupCode, -15)
            Me.Validator.SetInvalidBackColor(Me.txtCustomerGroupCode, System.Drawing.Color.Empty)
            Me.txtCustomerGroupCode.Location = New System.Drawing.Point(94, 64)
            Me.txtCustomerGroupCode.MaxLength = 50
            Me.Validator.SetMinValue(Me.txtCustomerGroupCode, "")
            Me.txtCustomerGroupCode.Name = "txtCustomerGroupCode"
            Me.Validator.SetRegularExpression(Me.txtCustomerGroupCode, "")
            Me.Validator.SetRequired(Me.txtCustomerGroupCode, False)
            Me.txtCustomerGroupCode.Size = New System.Drawing.Size(96, 21)
            Me.txtCustomerGroupCode.TabIndex = 96
            '
            'lblCustomerGroup
            '
            Me.lblCustomerGroup.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblCustomerGroup.ForeColor = System.Drawing.Color.Black
            Me.lblCustomerGroup.Location = New System.Drawing.Point(10, 64)
            Me.lblCustomerGroup.Name = "lblCustomerGroup"
            Me.lblCustomerGroup.Size = New System.Drawing.Size(76, 18)
            Me.lblCustomerGroup.TabIndex = 94
            Me.lblCustomerGroup.Text = "กลุ่มลูกค้า"
            Me.lblCustomerGroup.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtCustomerGroupName
            '
            Me.Validator.SetDataType(Me.txtCustomerGroupName, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtCustomerGroupName, "")
            Me.txtCustomerGroupName.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtCustomerGroupName, System.Drawing.Color.Empty)
            Me.ErrorProvider1.SetIconPadding(Me.txtCustomerGroupName, -15)
            Me.Validator.SetInvalidBackColor(Me.txtCustomerGroupName, System.Drawing.Color.Empty)
            Me.txtCustomerGroupName.Location = New System.Drawing.Point(214, 65)
            Me.txtCustomerGroupName.MaxLength = 50
            Me.Validator.SetMinValue(Me.txtCustomerGroupName, "")
            Me.txtCustomerGroupName.Name = "txtCustomerGroupName"
            Me.txtCustomerGroupName.ReadOnly = True
            Me.Validator.SetRegularExpression(Me.txtCustomerGroupName, "")
            Me.Validator.SetRequired(Me.txtCustomerGroupName, False)
            Me.txtCustomerGroupName.Size = New System.Drawing.Size(160, 21)
            Me.txtCustomerGroupName.TabIndex = 95
            '
            'chkIncludeChildCust
            '
            Me.chkIncludeChildCust.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.chkIncludeChildCust.Location = New System.Drawing.Point(94, 88)
            Me.chkIncludeChildCust.Name = "chkIncludeChildCust"
            Me.chkIncludeChildCust.Size = New System.Drawing.Size(128, 21)
            Me.chkIncludeChildCust.TabIndex = 93
            Me.chkIncludeChildCust.Text = "รวมกลุ่มลูกค้าลูก"
            '
            'grbTypeDisplay
            '
            Me.grbTypeDisplay.Controls.Add(Me.chkChq)
            Me.grbTypeDisplay.Controls.Add(Me.chkTransfer)
            Me.grbTypeDisplay.Controls.Add(Me.chkCash)
            Me.grbTypeDisplay.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.grbTypeDisplay.Location = New System.Drawing.Point(479, 68)
            Me.grbTypeDisplay.Name = "grbTypeDisplay"
            Me.grbTypeDisplay.Size = New System.Drawing.Size(170, 41)
            Me.grbTypeDisplay.TabIndex = 44
            Me.grbTypeDisplay.TabStop = False
            Me.grbTypeDisplay.Text = "ประเภทการจ่าย"
            '
            'chkChq
            '
            Me.chkChq.Checked = True
            Me.chkChq.CheckState = System.Windows.Forms.CheckState.Checked
            Me.chkChq.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.chkChq.Location = New System.Drawing.Point(71, 19)
            Me.chkChq.Name = "chkChq"
            Me.chkChq.Size = New System.Drawing.Size(47, 16)
            Me.chkChq.TabIndex = 17
            Me.chkChq.Text = "เช็ค"
            '
            'chkTransfer
            '
            Me.chkTransfer.Checked = True
            Me.chkTransfer.CheckState = System.Windows.Forms.CheckState.Checked
            Me.chkTransfer.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.chkTransfer.Location = New System.Drawing.Point(124, 19)
            Me.chkTransfer.Name = "chkTransfer"
            Me.chkTransfer.Size = New System.Drawing.Size(40, 16)
            Me.chkTransfer.TabIndex = 14
            Me.chkTransfer.Text = "โอน"
            '
            'chkCash
            '
            Me.chkCash.Checked = True
            Me.chkCash.CheckState = System.Windows.Forms.CheckState.Checked
            Me.chkCash.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.chkCash.Location = New System.Drawing.Point(10, 19)
            Me.chkCash.Name = "chkCash"
            Me.chkCash.Size = New System.Drawing.Size(88, 16)
            Me.chkCash.TabIndex = 13
            Me.chkCash.Text = "เงินสด"
            '
            'Label2
            '
            Me.Label2.Location = New System.Drawing.Point(476, 37)
            Me.Label2.Name = "Label2"
            Me.Label2.Size = New System.Drawing.Size(80, 16)
            Me.Label2.TabIndex = 43
            Me.Label2.Text = "RefCodePrefix"
            '
            'Label1
            '
            Me.Label1.Location = New System.Drawing.Point(476, 13)
            Me.Label1.Name = "Label1"
            Me.Label1.Size = New System.Drawing.Size(72, 16)
            Me.Label1.TabIndex = 42
            Me.Label1.Text = "GLCodePrefix"
            '
            'txtRefDocCodePrefix
            '
            Me.Validator.SetDataType(Me.txtRefDocCodePrefix, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtRefDocCodePrefix, "")
            Me.Validator.SetGotFocusBackColor(Me.txtRefDocCodePrefix, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtRefDocCodePrefix, System.Drawing.Color.Empty)
            Me.txtRefDocCodePrefix.Location = New System.Drawing.Point(564, 37)
            Me.Validator.SetMinValue(Me.txtRefDocCodePrefix, "")
            Me.txtRefDocCodePrefix.Name = "txtRefDocCodePrefix"
            Me.Validator.SetRegularExpression(Me.txtRefDocCodePrefix, "")
            Me.Validator.SetRequired(Me.txtRefDocCodePrefix, False)
            Me.txtRefDocCodePrefix.Size = New System.Drawing.Size(120, 21)
            Me.txtRefDocCodePrefix.TabIndex = 41
            '
            'txtGLCodeprefix
            '
            Me.Validator.SetDataType(Me.txtGLCodeprefix, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtGLCodeprefix, "")
            Me.Validator.SetGotFocusBackColor(Me.txtGLCodeprefix, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtGLCodeprefix, System.Drawing.Color.Empty)
            Me.txtGLCodeprefix.Location = New System.Drawing.Point(564, 13)
            Me.Validator.SetMinValue(Me.txtGLCodeprefix, "")
            Me.txtGLCodeprefix.Name = "txtGLCodeprefix"
            Me.Validator.SetRegularExpression(Me.txtGLCodeprefix, "")
            Me.Validator.SetRequired(Me.txtGLCodeprefix, False)
            Me.txtGLCodeprefix.Size = New System.Drawing.Size(120, 21)
            Me.txtGLCodeprefix.TabIndex = 40
            '
            'btnCustEndFind
            '
            Me.btnCustEndFind.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.btnCustEndFind.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.btnCustEndFind.ForeColor = System.Drawing.SystemColors.Control
            Me.btnCustEndFind.Location = New System.Drawing.Point(350, 40)
            Me.btnCustEndFind.Name = "btnCustEndFind"
            Me.btnCustEndFind.Size = New System.Drawing.Size(24, 22)
            Me.btnCustEndFind.TabIndex = 25
            Me.btnCustEndFind.TabStop = False
            Me.btnCustEndFind.ThemedImage = CType(resources.GetObject("btnCustEndFind.ThemedImage"), System.Drawing.Bitmap)
            '
            'btnCustStartFind
            '
            Me.btnCustStartFind.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.btnCustStartFind.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.btnCustStartFind.ForeColor = System.Drawing.SystemColors.Control
            Me.btnCustStartFind.Location = New System.Drawing.Point(190, 40)
            Me.btnCustStartFind.Name = "btnCustStartFind"
            Me.btnCustStartFind.Size = New System.Drawing.Size(24, 22)
            Me.btnCustStartFind.TabIndex = 24
            Me.btnCustStartFind.TabStop = False
            Me.btnCustStartFind.ThemedImage = CType(resources.GetObject("btnCustStartFind.ThemedImage"), System.Drawing.Bitmap)
            '
            'chkIncludeChildren
            '
            Me.chkIncludeChildren.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.chkIncludeChildren.Location = New System.Drawing.Point(380, 110)
            Me.chkIncludeChildren.Name = "chkIncludeChildren"
            Me.chkIncludeChildren.Size = New System.Drawing.Size(118, 24)
            Me.chkIncludeChildren.TabIndex = 23
            Me.chkIncludeChildren.Text = "รวม Cost Center ลูก"
            '
            'btnCCCodeStart
            '
            Me.btnCCCodeStart.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.btnCCCodeStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.btnCCCodeStart.ForeColor = System.Drawing.SystemColors.Control
            Me.btnCCCodeStart.Location = New System.Drawing.Point(190, 112)
            Me.btnCCCodeStart.Name = "btnCCCodeStart"
            Me.btnCCCodeStart.Size = New System.Drawing.Size(24, 22)
            Me.btnCCCodeStart.TabIndex = 22
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
            Me.txtCCCodeStart.Location = New System.Drawing.Point(94, 112)
            Me.txtCCCodeStart.MaxLength = 50
            Me.Validator.SetMinValue(Me.txtCCCodeStart, "")
            Me.txtCCCodeStart.Name = "txtCCCodeStart"
            Me.Validator.SetRegularExpression(Me.txtCCCodeStart, "")
            Me.Validator.SetRequired(Me.txtCCCodeStart, False)
            Me.txtCCCodeStart.Size = New System.Drawing.Size(96, 21)
            Me.txtCCCodeStart.TabIndex = 21
            '
            'lblCCStart
            '
            Me.lblCCStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblCCStart.ForeColor = System.Drawing.Color.Black
            Me.lblCCStart.Location = New System.Drawing.Point(26, 112)
            Me.lblCCStart.Name = "lblCCStart"
            Me.lblCCStart.Size = New System.Drawing.Size(60, 18)
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
            Me.txtCostCenterName.Location = New System.Drawing.Point(214, 112)
            Me.txtCostCenterName.MaxLength = 50
            Me.Validator.SetMinValue(Me.txtCostCenterName, "")
            Me.txtCostCenterName.Name = "txtCostCenterName"
            Me.txtCostCenterName.ReadOnly = True
            Me.Validator.SetRegularExpression(Me.txtCostCenterName, "")
            Me.Validator.SetRequired(Me.txtCostCenterName, False)
            Me.txtCostCenterName.Size = New System.Drawing.Size(160, 21)
            Me.txtCostCenterName.TabIndex = 20
            '
            'txtcustCodeEnd
            '
            Me.Validator.SetDataType(Me.txtcustCodeEnd, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtcustCodeEnd, "")
            Me.txtcustCodeEnd.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtcustCodeEnd, System.Drawing.Color.Empty)
            Me.ErrorProvider1.SetIconPadding(Me.txtcustCodeEnd, -15)
            Me.Validator.SetInvalidBackColor(Me.txtcustCodeEnd, System.Drawing.Color.Empty)
            Me.txtcustCodeEnd.Location = New System.Drawing.Point(254, 40)
            Me.Validator.SetMinValue(Me.txtcustCodeEnd, "")
            Me.txtcustCodeEnd.Name = "txtcustCodeEnd"
            Me.Validator.SetRegularExpression(Me.txtcustCodeEnd, "")
            Me.Validator.SetRequired(Me.txtcustCodeEnd, False)
            Me.txtcustCodeEnd.Size = New System.Drawing.Size(96, 21)
            Me.txtcustCodeEnd.TabIndex = 10
            '
            'lblcustEnd
            '
            Me.lblcustEnd.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblcustEnd.ForeColor = System.Drawing.Color.Black
            Me.lblcustEnd.Location = New System.Drawing.Point(222, 40)
            Me.lblcustEnd.Name = "lblcustEnd"
            Me.lblcustEnd.Size = New System.Drawing.Size(24, 18)
            Me.lblcustEnd.TabIndex = 9
            Me.lblcustEnd.Text = "ถึง"
            Me.lblcustEnd.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'txtcustCodeStart
            '
            Me.Validator.SetDataType(Me.txtcustCodeStart, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtcustCodeStart, "")
            Me.txtcustCodeStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtcustCodeStart, System.Drawing.Color.Empty)
            Me.ErrorProvider1.SetIconPadding(Me.txtcustCodeStart, -15)
            Me.Validator.SetInvalidBackColor(Me.txtcustCodeStart, System.Drawing.Color.Empty)
            Me.txtcustCodeStart.Location = New System.Drawing.Point(94, 40)
            Me.Validator.SetMinValue(Me.txtcustCodeStart, "")
            Me.txtcustCodeStart.Name = "txtcustCodeStart"
            Me.Validator.SetRegularExpression(Me.txtcustCodeStart, "")
            Me.Validator.SetRequired(Me.txtcustCodeStart, False)
            Me.txtcustCodeStart.Size = New System.Drawing.Size(96, 21)
            Me.txtcustCodeStart.TabIndex = 7
            '
            'lblcustStart
            '
            Me.lblcustStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblcustStart.ForeColor = System.Drawing.Color.Black
            Me.lblcustStart.Location = New System.Drawing.Point(25, 40)
            Me.lblcustStart.Name = "lblcustStart"
            Me.lblcustStart.Size = New System.Drawing.Size(61, 18)
            Me.lblcustStart.TabIndex = 6
            Me.lblcustStart.Text = "custer:"
            Me.lblcustStart.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtDocDateEnd
            '
            Me.Validator.SetDataType(Me.txtDocDateEnd, Longkong.Pojjaman.Gui.Components.DataTypeConstants.DateTimeType)
            Me.Validator.SetDisplayName(Me.txtDocDateEnd, "")
            Me.Validator.SetGotFocusBackColor(Me.txtDocDateEnd, System.Drawing.Color.Empty)
            Me.ErrorProvider1.SetIconPadding(Me.txtDocDateEnd, -15)
            Me.Validator.SetInvalidBackColor(Me.txtDocDateEnd, System.Drawing.Color.Empty)
            Me.txtDocDateEnd.Location = New System.Drawing.Point(254, 16)
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
            Me.txtDocDateStart.Location = New System.Drawing.Point(94, 16)
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
            Me.dtpDocDateStart.Location = New System.Drawing.Point(94, 16)
            Me.dtpDocDateStart.Name = "dtpDocDateStart"
            Me.dtpDocDateStart.Size = New System.Drawing.Size(120, 21)
            Me.dtpDocDateStart.TabIndex = 2
            Me.dtpDocDateStart.TabStop = False
            '
            'dtpDocDateEnd
            '
            Me.dtpDocDateEnd.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
            Me.dtpDocDateEnd.Location = New System.Drawing.Point(254, 16)
            Me.dtpDocDateEnd.Name = "dtpDocDateEnd"
            Me.dtpDocDateEnd.Size = New System.Drawing.Size(120, 21)
            Me.dtpDocDateEnd.TabIndex = 5
            Me.dtpDocDateEnd.TabStop = False
            '
            'lblDocDateStart
            '
            Me.lblDocDateStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblDocDateStart.ForeColor = System.Drawing.Color.Black
            Me.lblDocDateStart.Location = New System.Drawing.Point(26, 16)
            Me.lblDocDateStart.Name = "lblDocDateStart"
            Me.lblDocDateStart.Size = New System.Drawing.Size(60, 18)
            Me.lblDocDateStart.TabIndex = 0
            Me.lblDocDateStart.Text = "ตั้งแต่"
            Me.lblDocDateStart.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblDocDateEnd
            '
            Me.lblDocDateEnd.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblDocDateEnd.ForeColor = System.Drawing.Color.Black
            Me.lblDocDateEnd.Location = New System.Drawing.Point(222, 16)
            Me.lblDocDateEnd.Name = "lblDocDateEnd"
            Me.lblDocDateEnd.Size = New System.Drawing.Size(24, 18)
            Me.lblDocDateEnd.TabIndex = 3
            Me.lblDocDateEnd.Text = "ถึง"
            Me.lblDocDateEnd.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'chkShowDetail
            '
            Me.chkShowDetail.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.chkShowDetail.Location = New System.Drawing.Point(94, 138)
            Me.chkShowDetail.Name = "chkShowDetail"
            Me.chkShowDetail.Size = New System.Drawing.Size(112, 24)
            Me.chkShowDetail.TabIndex = 23
            Me.chkShowDetail.Text = "แสดงรายละเอียด"
            '
            'btnSearch
            '
            Me.btnSearch.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.btnSearch.Location = New System.Drawing.Point(629, 193)
            Me.btnSearch.Name = "btnSearch"
            Me.btnSearch.Size = New System.Drawing.Size(75, 23)
            Me.btnSearch.TabIndex = 2
            Me.btnSearch.Text = "ค้นหา"
            '
            'btnReset
            '
            Me.btnReset.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.btnReset.Location = New System.Drawing.Point(549, 193)
            Me.btnReset.Name = "btnReset"
            Me.btnReset.Size = New System.Drawing.Size(75, 23)
            Me.btnReset.TabIndex = 1
            Me.btnReset.TabStop = False
            Me.btnReset.Text = "เคลียร์"
            '
            'cmbReceiveType
            '
            Me.cmbReceiveType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cmbReceiveType.Location = New System.Drawing.Point(871, 26)
            Me.cmbReceiveType.Name = "cmbReceiveType"
            Me.cmbReceiveType.Size = New System.Drawing.Size(120, 21)
            Me.cmbReceiveType.TabIndex = 34
            Me.cmbReceiveType.Visible = False
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
            'RptARReceiveFilterSubPanel
            '
            Me.Controls.Add(Me.grbMaster)
            Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Name = "RptARReceiveFilterSubPanel"
            Me.Size = New System.Drawing.Size(733, 241)
            Me.grbMaster.ResumeLayout(False)
            Me.grbMaster.PerformLayout()
            Me.grbDetail.ResumeLayout(False)
            Me.grbDetail.PerformLayout()
            Me.grbTypeDisplay.ResumeLayout(False)
            CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub

#End Region

#Region " SetLabelText "
        Public Sub SetLabelText()
            'If Not m_entity Is Nothing Then Me.Text = Me.StringParserService.Parse(Me.m_entity.TabPageText)
            Me.lblcustStart.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptARReceiveFilterSubPanel.lblcustStart}")
            Me.Validator.SetDisplayName(txtcustCodeStart, lblcustStart.Text)

            Me.lblDocDateStart.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptARReceiveFilterSubPanel.lblDocDateStart}")
            Me.Validator.SetDisplayName(txtDocDateStart, lblDocDateStart.Text)

            Me.lblCCStart.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptARReceiveFilterSubPanel.lblCCStart}")
            Me.Validator.SetDisplayName(txtCCCodeStart, lblCCStart.Text)

            ' Global {ถึง}
            Me.lblcustEnd.Text = Me.StringParserService.Parse("${res:Global.FilterPanelTo}")
            Me.Validator.SetDisplayName(txtcustCodeEnd, lblcustEnd.Text)

            Me.lblDocDateEnd.Text = Me.StringParserService.Parse("${res:Global.FilterPanelTo}")
            Me.Validator.SetDisplayName(txtDocDateEnd, lblDocDateEnd.Text)
            ' Button
            Me.btnSearch.Text = Me.StringParserService.Parse("${res:Global.SearchButtonText}")
            Me.btnReset.Text = Me.StringParserService.Parse("${res:Global.ResetButtonText}")

            ' GroupBox
            Me.grbMaster.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptARReceiveFilterSubPanel.grbMaster}")
            Me.grbDetail.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptARReceiveFilterSubPanel.grbDetail}")
            Me.grbTypeDisplay.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptARReceiveFilterSubPanel.lblReceiveType}")
            'Checkbox
            Me.chkIncludeChildren.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptARReceiveFilterSubPanel.chkIncludeChildren}")
            Me.chkShowDetail.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptARReceiveFilterSubPanel.chkShowDetail}")

        End Sub
#End Region

#Region "Member"
        Private m_customerstart As Customer
        Private m_customerend As Customer

        Private m_DocDateEnd As Date
        Private m_DocDateStart As Date

        Private m_cc As CostCenter

        Private m_csg As CustomerGroup
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
        Public Property customerStart() As Customer
            Get
                Return m_customerstart
            End Get
            Set(ByVal Value As Customer)
                m_customerstart = Value
            End Set
        End Property
        Public Property customerEnd() As Customer
            Get
                Return m_customerend
            End Get
            Set(ByVal Value As Customer)
                m_customerend = Value
            End Set
        End Property
        Public Property CustomerGroup() As CustomerGroup
            Get
                Return m_csg
            End Get
            Set(ByVal Value As CustomerGroup)
                m_csg = Value
            End Set
        End Property
        Public Property DocDateEnd() As Date            Get                Return m_DocDateEnd            End Get            Set(ByVal Value As Date)                m_DocDateEnd = Value            End Set        End Property        Public Property DocDateStart() As Date            Get                Return m_DocDateStart            End Get            Set(ByVal Value As Date)                m_DocDateStart = Value            End Set        End Property

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

        Private Sub Initialize()
            RegisterDropdown()
            ClearCriterias()
        End Sub
        Private Sub RegisterDropdown()
            ' ประเภทการจ่าย
            CodeDescription.ListCodeDescriptionInComboBox(cmbReceiveType, "receivei_entityType", True)
            cmbReceiveType.SelectedIndex = 0
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

            Me.customerStart = New Customer
            Me.customerEnd = New Customer

            Dim dtStart As Date = Date.Now.Subtract(New TimeSpan(7, 0, 0, 0))
            Me.DocDateStart = dtStart
            Me.txtDocDateStart.Text = MinDateToNull(Me.DocDateStart, "")
            Me.dtpDocDateStart.Value = Me.DocDateStart

            Me.DocDateEnd = Date.Now
            Me.txtDocDateEnd.Text = MinDateToNull(Me.DocDateEnd, "")
            Me.dtpDocDateEnd.Value = Me.DocDateEnd

            Me.chkIncludeChildren.Checked = False
            Me.chkShowDetail.Checked = False
            If Me.cmbReceiveType.Items.Count > 0 Then
                Me.cmbReceiveType.SelectedIndex = 0
            End If
            Me.chkIncludeChildCust.Checked = False
        End Sub
        Public Overrides Function GetFilterString() As String

        End Function
        Public Overrides Function GetFilterArray() As Filter()
            Dim arr(13) As Filter
            arr(0) = New Filter("DocDateStart", IIf(Me.DocDateStart.Equals(Date.MinValue), DBNull.Value, Me.DocDateStart))
            arr(1) = New Filter("DocDateEnd", IIf(Me.DocDateEnd.Equals(Date.MinValue), DBNull.Value, Me.DocDateEnd))
            arr(2) = New Filter("custCodeStart", IIf(txtcustCodeStart.TextLength > 0, txtcustCodeStart.Text, DBNull.Value))
            arr(3) = New Filter("custCodeEnd", IIf(txtcustCodeEnd.TextLength > 0, txtcustCodeEnd.Text, DBNull.Value))
            arr(4) = New Filter("cc_id", Me.ValidIdOrDBNull(m_cc))
            arr(5) = New Filter("IncludeChildCC", Me.chkIncludeChildren.Checked)
            arr(6) = New Filter("userRight", CType(ServiceManager.Services.GetService(GetType(SecurityService)), SecurityService).CurrentUser.Id)
            arr(7) = New Filter("ShowDetail", Me.chkShowDetail.Checked)
            arr(8) = New Filter("ReceiveType", Me.cmbReceiveType.SelectedIndex - 1)
            arr(9) = New Filter("GLCodeprefix", IIf(txtGLCodeprefix.TextLength > 0, txtGLCodeprefix.Text, DBNull.Value))
            arr(10) = New Filter("RefDocCodePrefix", IIf(txtRefDocCodePrefix.TextLength > 0, txtRefDocCodePrefix.Text, DBNull.Value))
            arr(11) = New Filter("Type", GetChekType())
            arr(12) = New Filter("CustGroupCode", IIf(txtCustomerGroupCode.TextLength > 0, txtCustomerGroupCode.Text, DBNull.Value))
            arr(13) = New Filter("IncludeChildCust", Me.chkIncludeChildCust.Checked)
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

            'costcenter start
            dpi = New DocPrintingItem
            dpi.Mapping = "costcenterstart"
            dpi.Value = Me.txtCostCenterName.Text
            dpi.DataType = "System.String"
            dpiColl.Add(dpi)

            Return dpiColl
        End Function
#End Region

#Region " ChangeProperty "
        Private Sub EventWiring()
            AddHandler btnCustStartFind.Click, AddressOf Me.btncustomerFind_Click
            AddHandler btnCustEndFind.Click, AddressOf Me.btncustomerFind_Click

            AddHandler btnCCCodeStart.Click, AddressOf Me.btnCostcenterFind_Click
            AddHandler txtCCCodeStart.Validated, AddressOf Me.ChangeProperty

            AddHandler txtDocDateStart.Validated, AddressOf Me.ChangeProperty
            AddHandler txtDocDateEnd.Validated, AddressOf Me.ChangeProperty

            AddHandler dtpDocDateStart.ValueChanged, AddressOf Me.ChangeProperty
            AddHandler dtpDocDateEnd.ValueChanged, AddressOf Me.ChangeProperty

            AddHandler btnCustomerGroup.Click, AddressOf Me.btnCustomerGroupFind_Click
            AddHandler txtCustomerGroupCode.Validated, AddressOf Me.ChangeProperty
        End Sub

        Private m_dateSetting As Boolean
        Private Sub ChangeProperty(ByVal sender As Object, ByVal e As EventArgs)

            Select Case CType(sender, Control).Name.ToLower
                Case "txtcccodestart"
                    Costcenter.GetCostCenter(txtCCCodeStart, Me.txtCostCenterName, m_cc, CType(ServiceManager.Services.GetService(GetType(SecurityService)), SecurityService).CurrentUser.Id)

                Case "txtcustomergroupcode"
                    CustomerGroup.GetCustomerGroup(txtCustomerGroupCode, txtCustomerGroupName, Me.CustomerGroup)

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
                If data.GetDataPresent((New Customer).FullClassName) Then
                    If Not Me.ActiveControl Is Nothing Then
                        Select Case Me.ActiveControl.Name.ToLower
                            Case "txtcustcodestart", "txtcustcodeend"
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
            If data.GetDataPresent((New Customer).FullClassName) Then
                Dim id As Integer = CInt(data.GetData((New Customer).FullClassName))
                Dim entity As New Customer(id)
                If Not Me.ActiveControl Is Nothing Then
                    Select Case Me.ActiveControl.Name.ToLower
                        Case "txtcustcodestart"
                            Me.SetcustomerStartDialog(entity)

                        Case "txtcustcodeend"
                            Me.SetcustomerEndDialog(entity)

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
        Private Sub btncustomerFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
            Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
            Select Case CType(sender, Control).Name.ToLower
                Case "btncuststartfind"
                    myEntityPanelService.OpenListDialog(New Customer, AddressOf SetcustomerStartDialog)

                Case "btncustendfind"
                    myEntityPanelService.OpenListDialog(New Customer, AddressOf SetcustomerEndDialog)

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
        ' Customergroup
        Private Sub btnCustomerGroupFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
            Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
            Select Case CType(sender, Control).Name.ToLower
                Case "btncustomergroup"
                    myEntityPanelService.OpenTreeDialog(New CustomerGroup, AddressOf SetcustomergroupDialog)
            End Select
        End Sub
        Private Sub SetcustomergroupDialog(ByVal e As ISimpleEntity)
            Me.txtCustomerGroupCode.Text = e.Code
            CustomerGroup.GetCustomerGroup(txtCustomerGroupCode, txtCustomerGroupName, Me.CustomerGroup)
        End Sub
        Private Sub SetcustomerStartDialog(ByVal e As ISimpleEntity)
            Me.txtcustCodeStart.Text = e.Code
            Customer.GetCustomer(txtcustCodeStart, txtTemp, Me.customerStart)
        End Sub
        Private Sub SetcustomerEndDialog(ByVal e As ISimpleEntity)
            Me.txtcustCodeEnd.Text = e.Code
            Customer.GetCustomer(txtcustCodeEnd, txtTemp, Me.customerEnd)
        End Sub
        Private Sub SetCCCodeStartDialog(ByVal e As ISimpleEntity)
            Me.txtCCCodeStart.Text = e.Code
            Costcenter.GetCostCenter(txtCCCodeStart, txtCostCenterName, m_cc, CType(ServiceManager.Services.GetService(GetType(SecurityService)), SecurityService).CurrentUser.Id)
        End Sub
#End Region

        Private Function GetChekType() As Object
            Dim type As String = ""
            If Me.chkCash.Checked = False And Me.chkChq.Checked = False And Me.chkTransfer.Checked = False Then
                type = Nothing
            Else

                If Me.chkCash.Checked Then
                    type &= "0"
                End If
                If Me.chkChq.Checked Then
                    If Len(type) > 0 Then
                        type &= ","
                    End If
                    type &= "27"
                End If

                If Me.chkTransfer.Checked Then
                    If Len(type) > 0 Then
                        type &= ","
                    End If
                    type &= "72"
                End If
            End If
            Return type
        End Function
    End Class
End Namespace

