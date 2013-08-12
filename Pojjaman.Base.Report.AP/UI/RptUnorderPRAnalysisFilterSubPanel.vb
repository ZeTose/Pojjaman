Imports Longkong.Pojjaman.BusinessLogic
Imports longkong.Pojjaman.Services
Imports Longkong.Core.Services

Namespace Longkong.Pojjaman.Gui.Panels
  Public Class RptUnorderPRAnalysisFilterSubPanel
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
    Friend WithEvents chkIncludeChildren As System.Windows.Forms.CheckBox
    Friend WithEvents btnCCCodeStart As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents txtCCCodeStart As System.Windows.Forms.TextBox
    Friend WithEvents lblCCStart As System.Windows.Forms.Label
    Friend WithEvents txtCostCenterName As System.Windows.Forms.TextBox
    Friend WithEvents btnPREndFind As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents txtPRCodeEnd As System.Windows.Forms.TextBox
    Friend WithEvents lblPREnd As System.Windows.Forms.Label
    Friend WithEvents btnPRStartFind As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents txtPRCodeStart As System.Windows.Forms.TextBox
    Friend WithEvents lblPRStart As System.Windows.Forms.Label
    Friend WithEvents lblEmpStart As System.Windows.Forms.Label
    Friend WithEvents txtEmployee As System.Windows.Forms.TextBox
        Friend WithEvents btnEmployee As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents btnLciEndFind As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents lblLciStart As System.Windows.Forms.Label
        Friend WithEvents txtLciCodeEnd As System.Windows.Forms.TextBox
        Friend WithEvents txtLciCodeStart As System.Windows.Forms.TextBox
        Friend WithEvents lblLciEnd As System.Windows.Forms.Label
        Friend WithEvents btnLciStartFind As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents btnLciCodeNameFind As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents txtItemCode As System.Windows.Forms.TextBox
        Friend WithEvents lblItemCode As System.Windows.Forms.Label
    Friend WithEvents txtEmployeeName As System.Windows.Forms.TextBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Me.components = New System.ComponentModel.Container()
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(RptUnorderPRAnalysisFilterSubPanel))
            Me.grbMaster = New Longkong.Pojjaman.Gui.Components.FixedGroupBox()
            Me.grbDetail = New Longkong.Pojjaman.Gui.Components.FixedGroupBox()
            Me.txtEmployee = New System.Windows.Forms.TextBox()
            Me.btnEmployee = New Longkong.Pojjaman.Gui.Components.ImageButton()
            Me.txtEmployeeName = New System.Windows.Forms.TextBox()
            Me.lblEmpStart = New System.Windows.Forms.Label()
            Me.btnPREndFind = New Longkong.Pojjaman.Gui.Components.ImageButton()
            Me.txtPRCodeEnd = New System.Windows.Forms.TextBox()
            Me.lblPREnd = New System.Windows.Forms.Label()
            Me.btnPRStartFind = New Longkong.Pojjaman.Gui.Components.ImageButton()
            Me.txtPRCodeStart = New System.Windows.Forms.TextBox()
            Me.lblPRStart = New System.Windows.Forms.Label()
            Me.chkIncludeChildren = New System.Windows.Forms.CheckBox()
            Me.btnCCCodeStart = New Longkong.Pojjaman.Gui.Components.ImageButton()
            Me.txtCCCodeStart = New System.Windows.Forms.TextBox()
            Me.lblCCStart = New System.Windows.Forms.Label()
            Me.txtCostCenterName = New System.Windows.Forms.TextBox()
            Me.txtDocDateEnd = New System.Windows.Forms.TextBox()
            Me.txtDocDateStart = New System.Windows.Forms.TextBox()
            Me.dtpDocDateStart = New System.Windows.Forms.DateTimePicker()
            Me.dtpDocDateEnd = New System.Windows.Forms.DateTimePicker()
            Me.lblDocDateStart = New System.Windows.Forms.Label()
            Me.lblDocDateEnd = New System.Windows.Forms.Label()
            Me.btnReset = New System.Windows.Forms.Button()
            Me.btnSearch = New System.Windows.Forms.Button()
            Me.Validator = New Longkong.Pojjaman.Gui.Components.PJMTextboxValidator(Me.components)
            Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
            Me.btnLciEndFind = New Longkong.Pojjaman.Gui.Components.ImageButton()
            Me.lblLciStart = New System.Windows.Forms.Label()
            Me.txtLciCodeEnd = New System.Windows.Forms.TextBox()
            Me.txtLciCodeStart = New System.Windows.Forms.TextBox()
            Me.lblLciEnd = New System.Windows.Forms.Label()
            Me.btnLciStartFind = New Longkong.Pojjaman.Gui.Components.ImageButton()
            Me.btnLciCodeNameFind = New Longkong.Pojjaman.Gui.Components.ImageButton()
            Me.txtItemCode = New System.Windows.Forms.TextBox()
            Me.lblItemCode = New System.Windows.Forms.Label()
            Me.grbMaster.SuspendLayout()
            Me.grbDetail.SuspendLayout()
            CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'grbMaster
            '
            Me.grbMaster.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.grbMaster.Controls.Add(Me.grbDetail)
            Me.grbMaster.Controls.Add(Me.btnReset)
            Me.grbMaster.Controls.Add(Me.btnSearch)
            Me.grbMaster.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.grbMaster.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.grbMaster.Location = New System.Drawing.Point(8, 8)
            Me.grbMaster.Name = "grbMaster"
            Me.grbMaster.Size = New System.Drawing.Size(840, 208)
            Me.grbMaster.TabIndex = 0
            Me.grbMaster.TabStop = False
            Me.grbMaster.Text = "ค้นหา"
            '
            'grbDetail
            '
            Me.grbDetail.Controls.Add(Me.btnLciCodeNameFind)
            Me.grbDetail.Controls.Add(Me.txtItemCode)
            Me.grbDetail.Controls.Add(Me.lblItemCode)
            Me.grbDetail.Controls.Add(Me.btnLciEndFind)
            Me.grbDetail.Controls.Add(Me.lblLciStart)
            Me.grbDetail.Controls.Add(Me.txtLciCodeEnd)
            Me.grbDetail.Controls.Add(Me.txtLciCodeStart)
            Me.grbDetail.Controls.Add(Me.lblLciEnd)
            Me.grbDetail.Controls.Add(Me.btnLciStartFind)
            Me.grbDetail.Controls.Add(Me.txtEmployee)
            Me.grbDetail.Controls.Add(Me.btnEmployee)
            Me.grbDetail.Controls.Add(Me.txtEmployeeName)
            Me.grbDetail.Controls.Add(Me.lblEmpStart)
            Me.grbDetail.Controls.Add(Me.btnPREndFind)
            Me.grbDetail.Controls.Add(Me.txtPRCodeEnd)
            Me.grbDetail.Controls.Add(Me.lblPREnd)
            Me.grbDetail.Controls.Add(Me.btnPRStartFind)
            Me.grbDetail.Controls.Add(Me.txtPRCodeStart)
            Me.grbDetail.Controls.Add(Me.lblPRStart)
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
            Me.grbDetail.Size = New System.Drawing.Size(812, 152)
            Me.grbDetail.TabIndex = 0
            Me.grbDetail.TabStop = False
            Me.grbDetail.Text = "ข้อมูลทั่วไป"
            '
            'txtEmployee
            '
            Me.Validator.SetDataType(Me.txtEmployee, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtEmployee, "")
            Me.txtEmployee.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtEmployee, System.Drawing.Color.Empty)
            Me.ErrorProvider1.SetIconPadding(Me.txtEmployee, -15)
            Me.Validator.SetInvalidBackColor(Me.txtEmployee, System.Drawing.Color.Empty)
            Me.txtEmployee.Location = New System.Drawing.Point(112, 72)
            Me.txtEmployee.MaxLength = 50
            Me.Validator.SetMaxValue(Me.txtEmployee, "")
            Me.Validator.SetMinValue(Me.txtEmployee, "")
            Me.txtEmployee.Name = "txtEmployee"
            Me.Validator.SetRegularExpression(Me.txtEmployee, "")
            Me.Validator.SetRequired(Me.txtEmployee, False)
            Me.txtEmployee.Size = New System.Drawing.Size(96, 21)
            Me.txtEmployee.TabIndex = 54
            '
            'btnEmployee
            '
            Me.btnEmployee.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.btnEmployee.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.btnEmployee.ForeColor = System.Drawing.SystemColors.Control
            Me.btnEmployee.Location = New System.Drawing.Point(208, 72)
            Me.btnEmployee.Name = "btnEmployee"
            Me.btnEmployee.Size = New System.Drawing.Size(24, 22)
            Me.btnEmployee.TabIndex = 55
            Me.btnEmployee.TabStop = False
            Me.btnEmployee.ThemedImage = CType(resources.GetObject("btnEmployee.ThemedImage"), System.Drawing.Bitmap)
            '
            'txtEmployeeName
            '
            Me.Validator.SetDataType(Me.txtEmployeeName, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtEmployeeName, "")
            Me.txtEmployeeName.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtEmployeeName, System.Drawing.Color.Empty)
            Me.ErrorProvider1.SetIconPadding(Me.txtEmployeeName, -15)
            Me.Validator.SetInvalidBackColor(Me.txtEmployeeName, System.Drawing.Color.Empty)
            Me.txtEmployeeName.Location = New System.Drawing.Point(232, 72)
            Me.txtEmployeeName.MaxLength = 50
            Me.Validator.SetMaxValue(Me.txtEmployeeName, "")
            Me.Validator.SetMinValue(Me.txtEmployeeName, "")
            Me.txtEmployeeName.Name = "txtEmployeeName"
            Me.txtEmployeeName.ReadOnly = True
            Me.Validator.SetRegularExpression(Me.txtEmployeeName, "")
            Me.Validator.SetRequired(Me.txtEmployeeName, False)
            Me.txtEmployeeName.Size = New System.Drawing.Size(160, 21)
            Me.txtEmployeeName.TabIndex = 57
            '
            'lblEmpStart
            '
            Me.lblEmpStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblEmpStart.ForeColor = System.Drawing.Color.Black
            Me.lblEmpStart.Location = New System.Drawing.Point(16, 72)
            Me.lblEmpStart.Name = "lblEmpStart"
            Me.lblEmpStart.Size = New System.Drawing.Size(88, 18)
            Me.lblEmpStart.TabIndex = 50
            Me.lblEmpStart.Text = "พนักงานขอซื้อ"
            Me.lblEmpStart.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'btnPREndFind
            '
            Me.btnPREndFind.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.btnPREndFind.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.btnPREndFind.ForeColor = System.Drawing.SystemColors.Control
            Me.btnPREndFind.Location = New System.Drawing.Point(368, 24)
            Me.btnPREndFind.Name = "btnPREndFind"
            Me.btnPREndFind.Size = New System.Drawing.Size(24, 22)
            Me.btnPREndFind.TabIndex = 47
            Me.btnPREndFind.TabStop = False
            Me.btnPREndFind.ThemedImage = CType(resources.GetObject("btnPREndFind.ThemedImage"), System.Drawing.Bitmap)
            '
            'txtPRCodeEnd
            '
            Me.Validator.SetDataType(Me.txtPRCodeEnd, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtPRCodeEnd, "")
            Me.txtPRCodeEnd.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtPRCodeEnd, System.Drawing.Color.Empty)
            Me.ErrorProvider1.SetIconPadding(Me.txtPRCodeEnd, -15)
            Me.Validator.SetInvalidBackColor(Me.txtPRCodeEnd, System.Drawing.Color.Empty)
            Me.txtPRCodeEnd.Location = New System.Drawing.Point(272, 24)
            Me.Validator.SetMaxValue(Me.txtPRCodeEnd, "")
            Me.Validator.SetMinValue(Me.txtPRCodeEnd, "")
            Me.txtPRCodeEnd.Name = "txtPRCodeEnd"
            Me.Validator.SetRegularExpression(Me.txtPRCodeEnd, "")
            Me.Validator.SetRequired(Me.txtPRCodeEnd, False)
            Me.txtPRCodeEnd.Size = New System.Drawing.Size(96, 21)
            Me.txtPRCodeEnd.TabIndex = 46
            '
            'lblPREnd
            '
            Me.lblPREnd.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblPREnd.ForeColor = System.Drawing.Color.Black
            Me.lblPREnd.Location = New System.Drawing.Point(240, 24)
            Me.lblPREnd.Name = "lblPREnd"
            Me.lblPREnd.Size = New System.Drawing.Size(24, 18)
            Me.lblPREnd.TabIndex = 45
            Me.lblPREnd.Text = "ถึง"
            Me.lblPREnd.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'btnPRStartFind
            '
            Me.btnPRStartFind.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.btnPRStartFind.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.btnPRStartFind.ForeColor = System.Drawing.SystemColors.Control
            Me.btnPRStartFind.Location = New System.Drawing.Point(208, 24)
            Me.btnPRStartFind.Name = "btnPRStartFind"
            Me.btnPRStartFind.Size = New System.Drawing.Size(24, 22)
            Me.btnPRStartFind.TabIndex = 44
            Me.btnPRStartFind.TabStop = False
            Me.btnPRStartFind.ThemedImage = CType(resources.GetObject("btnPRStartFind.ThemedImage"), System.Drawing.Bitmap)
            '
            'txtPRCodeStart
            '
            Me.Validator.SetDataType(Me.txtPRCodeStart, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtPRCodeStart, "")
            Me.txtPRCodeStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtPRCodeStart, System.Drawing.Color.Empty)
            Me.ErrorProvider1.SetIconPadding(Me.txtPRCodeStart, -15)
            Me.Validator.SetInvalidBackColor(Me.txtPRCodeStart, System.Drawing.Color.Empty)
            Me.txtPRCodeStart.Location = New System.Drawing.Point(112, 24)
            Me.Validator.SetMaxValue(Me.txtPRCodeStart, "")
            Me.Validator.SetMinValue(Me.txtPRCodeStart, "")
            Me.txtPRCodeStart.Name = "txtPRCodeStart"
            Me.Validator.SetRegularExpression(Me.txtPRCodeStart, "")
            Me.Validator.SetRequired(Me.txtPRCodeStart, False)
            Me.txtPRCodeStart.Size = New System.Drawing.Size(96, 21)
            Me.txtPRCodeStart.TabIndex = 43
            '
            'lblPRStart
            '
            Me.lblPRStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblPRStart.ForeColor = System.Drawing.Color.Black
            Me.lblPRStart.Location = New System.Drawing.Point(16, 24)
            Me.lblPRStart.Name = "lblPRStart"
            Me.lblPRStart.Size = New System.Drawing.Size(88, 18)
            Me.lblPRStart.TabIndex = 42
            Me.lblPRStart.Text = "ตั้งแต่เลขที่ PR"
            Me.lblPRStart.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'chkIncludeChildren
            '
            Me.chkIncludeChildren.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.chkIncludeChildren.Location = New System.Drawing.Point(112, 120)
            Me.chkIncludeChildren.Name = "chkIncludeChildren"
            Me.chkIncludeChildren.Size = New System.Drawing.Size(128, 24)
            Me.chkIncludeChildren.TabIndex = 8
            Me.chkIncludeChildren.Text = "รวม Cost Center ลูก"
            '
            'btnCCCodeStart
            '
            Me.btnCCCodeStart.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.btnCCCodeStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.btnCCCodeStart.ForeColor = System.Drawing.SystemColors.Control
            Me.btnCCCodeStart.Location = New System.Drawing.Point(208, 96)
            Me.btnCCCodeStart.Name = "btnCCCodeStart"
            Me.btnCCCodeStart.Size = New System.Drawing.Size(24, 22)
            Me.btnCCCodeStart.TabIndex = 13
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
            Me.txtCCCodeStart.Location = New System.Drawing.Point(112, 96)
            Me.txtCCCodeStart.MaxLength = 50
            Me.Validator.SetMaxValue(Me.txtCCCodeStart, "")
            Me.Validator.SetMinValue(Me.txtCCCodeStart, "")
            Me.txtCCCodeStart.Name = "txtCCCodeStart"
            Me.Validator.SetRegularExpression(Me.txtCCCodeStart, "")
            Me.Validator.SetRequired(Me.txtCCCodeStart, False)
            Me.txtCCCodeStart.Size = New System.Drawing.Size(96, 21)
            Me.txtCCCodeStart.TabIndex = 6
            '
            'lblCCStart
            '
            Me.lblCCStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblCCStart.ForeColor = System.Drawing.Color.Black
            Me.lblCCStart.Location = New System.Drawing.Point(24, 96)
            Me.lblCCStart.Name = "lblCCStart"
            Me.lblCCStart.Size = New System.Drawing.Size(80, 18)
            Me.lblCCStart.TabIndex = 40
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
            Me.txtCostCenterName.Location = New System.Drawing.Point(232, 96)
            Me.txtCostCenterName.MaxLength = 50
            Me.Validator.SetMaxValue(Me.txtCostCenterName, "")
            Me.Validator.SetMinValue(Me.txtCostCenterName, "")
            Me.txtCostCenterName.Name = "txtCostCenterName"
            Me.txtCostCenterName.ReadOnly = True
            Me.Validator.SetRegularExpression(Me.txtCostCenterName, "")
            Me.Validator.SetRequired(Me.txtCostCenterName, False)
            Me.txtCostCenterName.Size = New System.Drawing.Size(160, 21)
            Me.txtCostCenterName.TabIndex = 41
            '
            'txtDocDateEnd
            '
            Me.Validator.SetDataType(Me.txtDocDateEnd, Longkong.Pojjaman.Gui.Components.DataTypeConstants.DateTimeType)
            Me.Validator.SetDisplayName(Me.txtDocDateEnd, "")
            Me.Validator.SetGotFocusBackColor(Me.txtDocDateEnd, System.Drawing.Color.Empty)
            Me.ErrorProvider1.SetIconPadding(Me.txtDocDateEnd, -15)
            Me.Validator.SetInvalidBackColor(Me.txtDocDateEnd, System.Drawing.Color.Empty)
            Me.txtDocDateEnd.Location = New System.Drawing.Point(272, 48)
            Me.txtDocDateEnd.MaxLength = 10
            Me.Validator.SetMaxValue(Me.txtDocDateEnd, "")
            Me.Validator.SetMinValue(Me.txtDocDateEnd, "")
            Me.txtDocDateEnd.Name = "txtDocDateEnd"
            Me.Validator.SetRegularExpression(Me.txtDocDateEnd, "")
            Me.Validator.SetRequired(Me.txtDocDateEnd, False)
            Me.txtDocDateEnd.Size = New System.Drawing.Size(99, 21)
            Me.txtDocDateEnd.TabIndex = 2
            '
            'txtDocDateStart
            '
            Me.Validator.SetDataType(Me.txtDocDateStart, Longkong.Pojjaman.Gui.Components.DataTypeConstants.DateTimeType)
            Me.Validator.SetDisplayName(Me.txtDocDateStart, "")
            Me.Validator.SetGotFocusBackColor(Me.txtDocDateStart, System.Drawing.Color.Empty)
            Me.ErrorProvider1.SetIconPadding(Me.txtDocDateStart, -15)
            Me.Validator.SetInvalidBackColor(Me.txtDocDateStart, System.Drawing.Color.Empty)
            Me.txtDocDateStart.Location = New System.Drawing.Point(112, 48)
            Me.txtDocDateStart.MaxLength = 10
            Me.Validator.SetMaxValue(Me.txtDocDateStart, "")
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
            Me.dtpDocDateStart.Location = New System.Drawing.Point(112, 48)
            Me.dtpDocDateStart.Name = "dtpDocDateStart"
            Me.dtpDocDateStart.Size = New System.Drawing.Size(120, 21)
            Me.dtpDocDateStart.TabIndex = 2
            Me.dtpDocDateStart.TabStop = False
            '
            'dtpDocDateEnd
            '
            Me.dtpDocDateEnd.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
            Me.dtpDocDateEnd.Location = New System.Drawing.Point(272, 48)
            Me.dtpDocDateEnd.Name = "dtpDocDateEnd"
            Me.dtpDocDateEnd.Size = New System.Drawing.Size(120, 21)
            Me.dtpDocDateEnd.TabIndex = 5
            Me.dtpDocDateEnd.TabStop = False
            '
            'lblDocDateStart
            '
            Me.lblDocDateStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblDocDateStart.ForeColor = System.Drawing.Color.Black
            Me.lblDocDateStart.Location = New System.Drawing.Point(16, 48)
            Me.lblDocDateStart.Name = "lblDocDateStart"
            Me.lblDocDateStart.Size = New System.Drawing.Size(88, 18)
            Me.lblDocDateStart.TabIndex = 0
            Me.lblDocDateStart.Text = "ตั้งแต่วันที่ PR"
            Me.lblDocDateStart.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblDocDateEnd
            '
            Me.lblDocDateEnd.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblDocDateEnd.ForeColor = System.Drawing.Color.Black
            Me.lblDocDateEnd.Location = New System.Drawing.Point(240, 48)
            Me.lblDocDateEnd.Name = "lblDocDateEnd"
            Me.lblDocDateEnd.Size = New System.Drawing.Size(24, 18)
            Me.lblDocDateEnd.TabIndex = 3
            Me.lblDocDateEnd.Text = "ถึง"
            Me.lblDocDateEnd.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'btnReset
            '
            Me.btnReset.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.btnReset.Location = New System.Drawing.Point(664, 176)
            Me.btnReset.Name = "btnReset"
            Me.btnReset.Size = New System.Drawing.Size(75, 23)
            Me.btnReset.TabIndex = 1
            Me.btnReset.TabStop = False
            Me.btnReset.Text = "เคลียร์"
            '
            'btnSearch
            '
            Me.btnSearch.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.btnSearch.Location = New System.Drawing.Point(744, 176)
            Me.btnSearch.Name = "btnSearch"
            Me.btnSearch.Size = New System.Drawing.Size(75, 23)
            Me.btnSearch.TabIndex = 2
            Me.btnSearch.Text = "ค้นหา"
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
            'btnLciEndFind
            '
            Me.btnLciEndFind.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.btnLciEndFind.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.btnLciEndFind.ForeColor = System.Drawing.SystemColors.Control
            Me.btnLciEndFind.Location = New System.Drawing.Point(754, 51)
            Me.btnLciEndFind.Name = "btnLciEndFind"
            Me.btnLciEndFind.Size = New System.Drawing.Size(24, 22)
            Me.btnLciEndFind.TabIndex = 63
            Me.btnLciEndFind.TabStop = False
            Me.btnLciEndFind.ThemedImage = CType(resources.GetObject("btnLciEndFind.ThemedImage"), System.Drawing.Bitmap)
            '
            'lblLciStart
            '
            Me.lblLciStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblLciStart.ForeColor = System.Drawing.Color.Black
            Me.lblLciStart.Location = New System.Drawing.Point(402, 51)
            Me.lblLciStart.Name = "lblLciStart"
            Me.lblLciStart.Size = New System.Drawing.Size(88, 18)
            Me.lblLciStart.TabIndex = 58
            Me.lblLciStart.Text = "ตั้งแต่วัสดุ:"
            Me.lblLciStart.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtLciCodeEnd
            '
            Me.Validator.SetDataType(Me.txtLciCodeEnd, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtLciCodeEnd, "")
            Me.txtLciCodeEnd.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtLciCodeEnd, System.Drawing.Color.Empty)
            Me.ErrorProvider1.SetIconPadding(Me.txtLciCodeEnd, -15)
            Me.Validator.SetInvalidBackColor(Me.txtLciCodeEnd, System.Drawing.Color.Empty)
            Me.txtLciCodeEnd.Location = New System.Drawing.Point(658, 51)
            Me.Validator.SetMaxValue(Me.txtLciCodeEnd, "")
            Me.Validator.SetMinValue(Me.txtLciCodeEnd, "")
            Me.txtLciCodeEnd.Name = "txtLciCodeEnd"
            Me.Validator.SetRegularExpression(Me.txtLciCodeEnd, "")
            Me.Validator.SetRequired(Me.txtLciCodeEnd, False)
            Me.txtLciCodeEnd.Size = New System.Drawing.Size(96, 21)
            Me.txtLciCodeEnd.TabIndex = 62
            '
            'txtLciCodeStart
            '
            Me.Validator.SetDataType(Me.txtLciCodeStart, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtLciCodeStart, "")
            Me.txtLciCodeStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtLciCodeStart, System.Drawing.Color.Empty)
            Me.ErrorProvider1.SetIconPadding(Me.txtLciCodeStart, -15)
            Me.Validator.SetInvalidBackColor(Me.txtLciCodeStart, System.Drawing.Color.Empty)
            Me.txtLciCodeStart.Location = New System.Drawing.Point(498, 51)
            Me.Validator.SetMaxValue(Me.txtLciCodeStart, "")
            Me.Validator.SetMinValue(Me.txtLciCodeStart, "")
            Me.txtLciCodeStart.Name = "txtLciCodeStart"
            Me.Validator.SetRegularExpression(Me.txtLciCodeStart, "")
            Me.Validator.SetRequired(Me.txtLciCodeStart, False)
            Me.txtLciCodeStart.Size = New System.Drawing.Size(96, 21)
            Me.txtLciCodeStart.TabIndex = 59
            '
            'lblLciEnd
            '
            Me.lblLciEnd.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblLciEnd.ForeColor = System.Drawing.Color.Black
            Me.lblLciEnd.Location = New System.Drawing.Point(626, 51)
            Me.lblLciEnd.Name = "lblLciEnd"
            Me.lblLciEnd.Size = New System.Drawing.Size(24, 18)
            Me.lblLciEnd.TabIndex = 61
            Me.lblLciEnd.Text = "ถึง"
            Me.lblLciEnd.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'btnLciStartFind
            '
            Me.btnLciStartFind.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.btnLciStartFind.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.btnLciStartFind.ForeColor = System.Drawing.SystemColors.Control
            Me.btnLciStartFind.Location = New System.Drawing.Point(594, 51)
            Me.btnLciStartFind.Name = "btnLciStartFind"
            Me.btnLciStartFind.Size = New System.Drawing.Size(24, 22)
            Me.btnLciStartFind.TabIndex = 60
            Me.btnLciStartFind.TabStop = False
            Me.btnLciStartFind.ThemedImage = CType(resources.GetObject("btnLciStartFind.ThemedImage"), System.Drawing.Bitmap)
            '
            'btnLciCodeNameFind
            '
            Me.btnLciCodeNameFind.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.btnLciCodeNameFind.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.btnLciCodeNameFind.ForeColor = System.Drawing.SystemColors.Control
            Me.btnLciCodeNameFind.Location = New System.Drawing.Point(754, 24)
            Me.btnLciCodeNameFind.Name = "btnLciCodeNameFind"
            Me.btnLciCodeNameFind.Size = New System.Drawing.Size(24, 22)
            Me.btnLciCodeNameFind.TabIndex = 66
            Me.btnLciCodeNameFind.TabStop = False
            Me.btnLciCodeNameFind.ThemedImage = CType(resources.GetObject("btnLciCodeNameFind.ThemedImage"), System.Drawing.Bitmap)
            '
            'txtItemCode
            '
            Me.Validator.SetDataType(Me.txtItemCode, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtItemCode, "")
            Me.Validator.SetGotFocusBackColor(Me.txtItemCode, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtItemCode, System.Drawing.Color.Empty)
            Me.txtItemCode.Location = New System.Drawing.Point(498, 24)
            Me.Validator.SetMaxValue(Me.txtItemCode, "")
            Me.Validator.SetMinValue(Me.txtItemCode, "")
            Me.txtItemCode.Name = "txtItemCode"
            Me.Validator.SetRegularExpression(Me.txtItemCode, "")
            Me.Validator.SetRequired(Me.txtItemCode, False)
            Me.txtItemCode.Size = New System.Drawing.Size(256, 21)
            Me.txtItemCode.TabIndex = 65
            '
            'lblItemCode
            '
            Me.lblItemCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblItemCode.ForeColor = System.Drawing.Color.Black
            Me.lblItemCode.Location = New System.Drawing.Point(399, 24)
            Me.lblItemCode.Name = "lblItemCode"
            Me.lblItemCode.Size = New System.Drawing.Size(91, 18)
            Me.lblItemCode.TabIndex = 64
            Me.lblItemCode.Text = "รหัส/ชื่อวัสดุ:"
            Me.lblItemCode.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'RptUnorderPRAnalysisFilterSubPanel
            '
            Me.Controls.Add(Me.grbMaster)
            Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Name = "RptUnorderPRAnalysisFilterSubPanel"
            Me.Size = New System.Drawing.Size(863, 224)
            Me.grbMaster.ResumeLayout(False)
            Me.grbDetail.ResumeLayout(False)
            Me.grbDetail.PerformLayout()
            CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub

#End Region

#Region " SetLabelText "
    Public Sub SetLabelText()

      'ตั้งแต่เลขที่ PR
      Me.lblPRStart.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptUnorderPRAnalysisFilterSubPanel.lblPRStart}")
      'ถึง
      Me.lblPREnd.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptUnorderPRAnalysisFilterSubPanel.lblPREnd}")

      'ตั้งแต่วันที่ PR
      Me.lblDocDateStart.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptUnorderPRAnalysisFilterSubPanel.lblDocDateStart}")
      'ถึง
      Me.lblDocDateEnd.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptUnorderPRAnalysisFilterSubPanel.lblDocDateEnd}")

      'ตั้งแต่วันที่ PR
      Me.lblDocDateStart.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptUnorderPRAnalysisFilterSubPanel.lblDocDateStart}")
      'ถึง
      Me.lblDocDateEnd.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptUnorderPRAnalysisFilterSubPanel.lblDocDateEnd}")

      'พนักงานขอซื้อ
      Me.lblEmpStart.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptUnorderPRAnalysisFilterSubPanel.lblEmpStart}")



      Me.lblDocDateStart.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptUnorderPRAnalysisFilterSubPanel.lblDocDateStart}")
      Me.Validator.SetDisplayName(txtDocDateStart, lblDocDateStart.Text)

      Me.lblCCStart.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptUnorderPRAnalysisFilterSubPanel.lblCCStart}")
      Me.Validator.SetDisplayName(txtCCCodeStart, lblCCStart.Text)

      Me.lblDocDateEnd.Text = Me.StringParserService.Parse("${res:Global.FilterPanelTo}")
      Me.Validator.SetDisplayName(txtDocDateEnd, lblDocDateEnd.Text)

      ' Button
      Me.btnSearch.Text = Me.StringParserService.Parse("${res:Global.SearchButtonText}")
      Me.btnReset.Text = Me.StringParserService.Parse("${res:Global.ResetButtonText}")

      ' GroupBox
      Me.grbMaster.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptUnorderPRAnalysisFilterSubPanel.grbMaster}")
      Me.grbDetail.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptUnorderPRAnalysisFilterSubPanel.grbDetail}")

      'Checkbox
      Me.chkIncludeChildren.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptUnorderPRAnalysisFilterSubPanel.chkIncludeChildren}")

            Me.lblItemCode.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptUnorderPRAnalysisFilterSubPanel.lblItemCode}")

            Me.lblLciStart.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptUnorderPRAnalysisFilterSubPanel.lblLciStart}")
            Me.Validator.SetDisplayName(txtLciCodeStart, lblLciStart.Text)

            ' Global {ถึง}
            Me.lblLciEnd.Text = Me.StringParserService.Parse("${res:Global.FilterPanelTo}")
            Me.Validator.SetDisplayName(txtLciCodeEnd, lblLciEnd.Text)

    End Sub
#End Region

#Region "Member"

    Private m_DocDateEnd As Date
    Private m_DocDateStart As Date

    Private m_cc As Costcenter
    Private m_employee As Employee
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
    Public Property DocDateEnd() As Date      Get        Return m_DocDateEnd      End Get      Set(ByVal Value As Date)        m_DocDateEnd = Value      End Set    End Property    Public Property DocDateStart() As Date      Get        Return m_DocDateStart      End Get      Set(ByVal Value As Date)        m_DocDateStart = Value      End Set    End Property

    Public Property Costcenter() As Costcenter
      Get
        Return m_cc
      End Get
      Set(ByVal Value As Costcenter)
        m_cc = Value
      End Set
    End Property
    Public Property Employee() As Employee
      Get
        Return m_employee
      End Get
      Set(ByVal Value As Employee)
        m_employee = Value
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

      Me.Costcenter = New Costcenter
      Me.Employee = New Employee

      Dim dtStart As Date = Date.Now.Subtract(New TimeSpan(7, 0, 0, 0))
      Me.DocDateStart = dtStart
      Me.txtDocDateStart.Text = MinDateToNull(Me.DocDateStart, "")
      Me.dtpDocDateStart.Value = Me.DocDateStart

      Me.DocDateEnd = Date.Now
      Me.txtDocDateEnd.Text = MinDateToNull(Me.DocDateEnd, "")
      Me.dtpDocDateEnd.Value = Me.DocDateEnd
    End Sub
    Public Overrides Function GetFilterString() As String

    End Function
    Public Overrides Function GetFilterArray() As Filter()
            Dim arr(10) As Filter
      arr(0) = New Filter("PRCodeStart", IIf(txtPRCodeStart.TextLength > 0, txtPRCodeStart.Text, DBNull.Value))
      arr(1) = New Filter("PRCodeEnd", IIf(txtPRCodeEnd.TextLength > 0, txtPRCodeEnd.Text, DBNull.Value))
      arr(2) = New Filter("DocDateStart", IIf(Me.DocDateStart.Equals(Date.MinValue), DBNull.Value, Me.DocDateStart))
      arr(3) = New Filter("DocDateEnd", IIf(Me.DocDateEnd.Equals(Date.MinValue), DBNull.Value, Me.DocDateEnd))
      arr(4) = New Filter("Employee_id", Me.ValidIdOrDBNull(m_employee))
      arr(5) = New Filter("cc_id", Me.ValidIdOrDBNull(m_cc))
      arr(6) = New Filter("IncludeChildCC", Me.chkIncludeChildren.Checked)
            arr(7) = New Filter("userRight", CType(ServiceManager.Services.GetService(GetType(SecurityService)), SecurityService).CurrentUser.Id)
            arr(8) = New Filter("LciCodeStart", IIf(txtLciCodeStart.TextLength > 0, txtLciCodeStart.Text, DBNull.Value))
            arr(9) = New Filter("LciCodeEnd", IIf(txtLciCodeEnd.TextLength > 0, txtLciCodeEnd.Text, DBNull.Value))
            arr(10) = New Filter("ItemCode", IIf(Me.lblItemCode.Text.Length = 0, DBNull.Value, Me.txtItemCode.Text))
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

      'PRCodeStart
      dpi = New DocPrintingItem
      dpi.Mapping = "PRCodeStart"
      dpi.Value = Me.txtPRCodeStart.Text
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      'PRCodeEnd
      dpi = New DocPrintingItem
      dpi.Mapping = "PRCodeEnd"
      dpi.Value = Me.txtPRCodeEnd.Text
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

      'Employee
      dpi = New DocPrintingItem
      dpi.Mapping = "Employee"
      dpi.Value = Me.txtEmployee.Text
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      'CostCenter
      dpi = New DocPrintingItem
      dpi.Mapping = "CostCenterStart"
      dpi.Value = Me.txtCCCodeStart.Text
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      'CheckBox chkIncludeChildren
      If Me.chkIncludeChildren.Checked Then
        dpi = New DocPrintingItem
        dpi.Mapping = "childincluded"
        dpi.Value = "(รวมในสังกัด)"
        dpi.DataType = "System.String"
        dpiColl.Add(dpi)
            End If

            'lci start
            dpi = New DocPrintingItem
            dpi.Mapping = "lcistart"
            dpi.Value = Me.txtLciCodeStart.Text
            dpi.DataType = "System.String"
            dpiColl.Add(dpi)

            'lci end
            dpi = New DocPrintingItem
            dpi.Mapping = "lciend"
            dpi.Value = Me.txtLciCodeEnd.Text
            dpi.DataType = "System.String"
            dpiColl.Add(dpi)

      Return dpiColl
    End Function
#End Region

#Region " ChangeProperty "
    Private Sub EventWiring()

      AddHandler btnCCCodeStart.Click, AddressOf Me.btnCostcenterFind_Click
      AddHandler txtCCCodeStart.Validated, AddressOf Me.ChangeProperty

      AddHandler btnPRStartFind.Click, AddressOf Me.btnPRFind_Click
      AddHandler btnPREndFind.Click, AddressOf Me.btnPRFind_Click

      AddHandler txtEmployee.Validated, AddressOf Me.ChangeProperty
      AddHandler btnEmployee.Click, AddressOf Me.btnEmployee_Click


      AddHandler txtDocDateStart.Validated, AddressOf Me.ChangeProperty
      AddHandler txtDocDateEnd.Validated, AddressOf Me.ChangeProperty

      AddHandler dtpDocDateStart.ValueChanged, AddressOf Me.ChangeProperty
      AddHandler dtpDocDateEnd.ValueChanged, AddressOf Me.ChangeProperty

            AddHandler btnLciCodeNameFind.Click, AddressOf Me.btnLciFind_Click
            AddHandler txtItemCode.Validated, AddressOf Me.ChangeProperty

            AddHandler btnLciStartFind.Click, AddressOf Me.btnLciFind_Click
            AddHandler txtLciCodeStart.Validated, AddressOf Me.ChangeProperty

            AddHandler btnLciEndFind.Click, AddressOf Me.btnLciFind_Click
            AddHandler txtLciCodeEnd.Validated, AddressOf Me.ChangeProperty

    End Sub

    Private m_dateSetting As Boolean
    Private Sub ChangeProperty(ByVal sender As Object, ByVal e As EventArgs)

      Select Case CType(sender, Control).Name.ToLower
        Case "txtcccodestart"
          Costcenter.GetCostCenter(txtCCCodeStart, Me.txtCostCenterName, m_cc, CType(ServiceManager.Services.GetService(GetType(SecurityService)), SecurityService).CurrentUser.Id)
        Case "txtemployee"
          Employee.GetEmployee(txtEmployee, Me.txtEmployeeName, Employee)
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
      If data.GetDataPresent((New Supplier).FullClassName) Then
        Dim id As Integer = CInt(data.GetData((New Supplier).FullClassName))
        Dim entity As New Supplier(id)
        If Not Me.ActiveControl Is Nothing Then
          Select Case Me.ActiveControl.Name.ToLower
            'Case "txtsupplicodestart"
            '    Me.SetSupplierStartDialog(entity)

            'Case "txtsupplicodeend"
            '    Me.SetSupplierEndDialog(entity)

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
    ' Costcenter
    Private Sub btnCostcenterFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
      Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      Select Case CType(sender, Control).Name.ToLower
        Case "btncccodestart"
          myEntityPanelService.OpenTreeDialog(New Costcenter, AddressOf SetCCCodeStartDialog)
      End Select
    End Sub
    'PR
    Private Sub btnPRFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
      Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      Dim thePR As New PR
      Select Case CType(sender, Control).Name.ToLower
        Case "btnprstartfind"
          myEntityPanelService.OpenListDialog(thePR, AddressOf SetPRStartDialog)
        Case "btnprendfind"
          myEntityPanelService.OpenListDialog(thePR, AddressOf SetPREndDialog)
      End Select
      thePR = Nothing
    End Sub
    'Employee 
    Private Sub btnEmployee_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
      Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      Select Case CType(sender, Control).Name.ToLower
        Case "btnemployee"
          myEntityPanelService.OpenListDialog(New Employee, AddressOf SetEmployeeDialog)
      End Select

    End Sub
    Private Sub SetEmployeeDialog(ByVal e As ISimpleEntity)
      Me.txtEmployee.Text = e.Code
      Employee.GetEmployee(txtEmployee, txtEmployeeName, Me.Employee)
    End Sub
    Private Sub SetPRStartDialog(ByVal e As ISimpleEntity)
      Me.txtPRCodeStart.Text = e.Code
    End Sub
    Private Sub SetPREndDialog(ByVal e As ISimpleEntity)
      Me.txtPRCodeEnd.Text = e.Code
    End Sub
    Private Sub SetCCCodeStartDialog(ByVal e As ISimpleEntity)
      Me.txtCCCodeStart.Text = e.Code
      Costcenter.GetCostCenter(txtCCCodeStart, txtCostCenterName, m_cc, CType(ServiceManager.Services.GetService(GetType(SecurityService)), SecurityService).CurrentUser.Id)
        End Sub

        Private Sub SetLciDialog(ByVal e As ISimpleEntity)
            Me.txtItemCode.Text = e.Code
        End Sub
        Private Sub SetLciStartDialog(ByVal e As ISimpleEntity)
            Me.txtLciCodeStart.Text = e.Code
        End Sub
        Private Sub SetLciEndDialog(ByVal e As ISimpleEntity)
            Me.txtLciCodeEnd.Text = e.Code
        End Sub
        Private Sub btnLciFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
            Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
            Select Case CType(sender, Control).Name.ToLower
                Case "btnlcicodenamefind"
                    myEntityPanelService.OpenListDialog(New LCIItem, AddressOf SetLciDialog)
                Case "btnlcistartfind"
                    myEntityPanelService.OpenListDialog(New LCIItem, AddressOf SetLciStartDialog)
                Case "btnlciendfind"
                    myEntityPanelService.OpenListDialog(New LCIItem, AddressOf SetLciEndDialog)
            End Select
        End Sub
#End Region

  End Class
End Namespace

