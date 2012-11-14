Imports Longkong.Pojjaman.BusinessLogic
Imports Longkong.Pojjaman.Services
Imports Longkong.Core.Services
Imports Longkong.Pojjaman.DataAccessLayer
Imports System.Collections.Generic
Imports Longkong.Pojjaman.Gui.Components

Namespace Longkong.Pojjaman.Gui.Panels
    Public Class RptUnorderPRItemVArcFilterSubPanel
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
        Friend WithEvents txtEmployeeName As System.Windows.Forms.TextBox
        Friend WithEvents txtDocDateEnd1 As System.Windows.Forms.TextBox
        Friend WithEvents txtDocDateStart1 As System.Windows.Forms.TextBox
        Friend WithEvents dtpDocDateStart1 As System.Windows.Forms.DateTimePicker
        Friend WithEvents dtpDocDateEnd1 As System.Windows.Forms.DateTimePicker
        Friend WithEvents Label1 As System.Windows.Forms.Label
        Friend WithEvents btnMaterialCode As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
        Friend WithEvents ibtnDown As System.Windows.Forms.Button
        Friend WithEvents ibtnUp As System.Windows.Forms.Button
        Friend WithEvents clbMaterial As System.Windows.Forms.ListBox
        Friend WithEvents Label2 As System.Windows.Forms.Label
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Me.components = New System.ComponentModel.Container()
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(RptUnorderPRItemVArcFilterSubPanel))
            Me.grbMaster = New Longkong.Pojjaman.Gui.Components.FixedGroupBox()
            Me.GroupBox1 = New System.Windows.Forms.GroupBox()
            Me.clbMaterial = New System.Windows.Forms.ListBox()
            Me.ibtnDown = New System.Windows.Forms.Button()
            Me.ibtnUp = New System.Windows.Forms.Button()
            Me.btnMaterialCode = New Longkong.Pojjaman.Gui.Components.ImageButton()
            Me.grbDetail = New Longkong.Pojjaman.Gui.Components.FixedGroupBox()
            Me.txtDocDateEnd1 = New System.Windows.Forms.TextBox()
            Me.txtDocDateStart1 = New System.Windows.Forms.TextBox()
            Me.dtpDocDateStart1 = New System.Windows.Forms.DateTimePicker()
            Me.dtpDocDateEnd1 = New System.Windows.Forms.DateTimePicker()
            Me.Label1 = New System.Windows.Forms.Label()
            Me.Label2 = New System.Windows.Forms.Label()
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
            Me.grbMaster.SuspendLayout()
            Me.GroupBox1.SuspendLayout()
            Me.grbDetail.SuspendLayout()
            CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'grbMaster
            '
            Me.grbMaster.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.grbMaster.Controls.Add(Me.GroupBox1)
            Me.grbMaster.Controls.Add(Me.grbDetail)
            Me.grbMaster.Controls.Add(Me.btnReset)
            Me.grbMaster.Controls.Add(Me.btnSearch)
            Me.grbMaster.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.grbMaster.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.grbMaster.Location = New System.Drawing.Point(8, 8)
            Me.grbMaster.Name = "grbMaster"
            Me.grbMaster.Size = New System.Drawing.Size(830, 332)
            Me.grbMaster.TabIndex = 0
            Me.grbMaster.TabStop = False
            Me.grbMaster.Text = "ค้นหา"
            '
            'GroupBox1
            '
            Me.GroupBox1.Controls.Add(Me.clbMaterial)
            Me.GroupBox1.Controls.Add(Me.ibtnDown)
            Me.GroupBox1.Controls.Add(Me.ibtnUp)
            Me.GroupBox1.Controls.Add(Me.btnMaterialCode)
            Me.GroupBox1.Location = New System.Drawing.Point(16, 133)
            Me.GroupBox1.Name = "GroupBox1"
            Me.GroupBox1.Size = New System.Drawing.Size(387, 183)
            Me.GroupBox1.TabIndex = 74
            Me.GroupBox1.TabStop = False
            Me.GroupBox1.Text = "วัสดุ"
            '
            'clbMaterial
            '
            Me.clbMaterial.FormattingEnabled = True
            Me.clbMaterial.Location = New System.Drawing.Point(31, 20)
            Me.clbMaterial.Name = "clbMaterial"
            Me.clbMaterial.Size = New System.Drawing.Size(286, 147)
            Me.clbMaterial.TabIndex = 75
            '
            'ibtnDown
            '
            Me.ibtnDown.Image = CType(resources.GetObject("ibtnDown.Image"), System.Drawing.Image)
            Me.ibtnDown.Location = New System.Drawing.Point(323, 85)
            Me.ibtnDown.Name = "ibtnDown"
            Me.ibtnDown.Size = New System.Drawing.Size(34, 37)
            Me.ibtnDown.TabIndex = 76
            Me.ibtnDown.UseVisualStyleBackColor = False
            '
            'ibtnUp
            '
            Me.ibtnUp.Image = CType(resources.GetObject("ibtnUp.Image"), System.Drawing.Image)
            Me.ibtnUp.Location = New System.Drawing.Point(323, 48)
            Me.ibtnUp.Name = "ibtnUp"
            Me.ibtnUp.Size = New System.Drawing.Size(34, 37)
            Me.ibtnUp.TabIndex = 75
            Me.ibtnUp.UseVisualStyleBackColor = False
            '
            'btnMaterialCode
            '
            Me.btnMaterialCode.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.btnMaterialCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.btnMaterialCode.ForeColor = System.Drawing.SystemColors.Control
            Me.btnMaterialCode.Location = New System.Drawing.Point(323, 20)
            Me.btnMaterialCode.Name = "btnMaterialCode"
            Me.btnMaterialCode.Size = New System.Drawing.Size(24, 22)
            Me.btnMaterialCode.TabIndex = 71
            Me.btnMaterialCode.TabStop = False
            Me.btnMaterialCode.ThemedImage = CType(resources.GetObject("btnMaterialCode.ThemedImage"), System.Drawing.Bitmap)
            '
            'grbDetail
            '
            Me.grbDetail.Controls.Add(Me.txtDocDateEnd1)
            Me.grbDetail.Controls.Add(Me.txtDocDateStart1)
            Me.grbDetail.Controls.Add(Me.dtpDocDateStart1)
            Me.grbDetail.Controls.Add(Me.dtpDocDateEnd1)
            Me.grbDetail.Controls.Add(Me.Label1)
            Me.grbDetail.Controls.Add(Me.Label2)
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
            Me.grbDetail.Size = New System.Drawing.Size(800, 110)
            Me.grbDetail.TabIndex = 0
            Me.grbDetail.TabStop = False
            Me.grbDetail.Text = "ข้อมูลทั่วไป"
            '
            'txtDocDateEnd1
            '
            Me.Validator.SetDataType(Me.txtDocDateEnd1, Longkong.Pojjaman.Gui.Components.DataTypeConstants.DateTimeType)
            Me.Validator.SetDisplayName(Me.txtDocDateEnd1, "")
            Me.Validator.SetGotFocusBackColor(Me.txtDocDateEnd1, System.Drawing.Color.Empty)
            Me.ErrorProvider1.SetIconPadding(Me.txtDocDateEnd1, -15)
            Me.Validator.SetInvalidBackColor(Me.txtDocDateEnd1, System.Drawing.Color.Empty)
            Me.txtDocDateEnd1.Location = New System.Drawing.Point(267, 80)
            Me.txtDocDateEnd1.MaxLength = 10
            Me.Validator.SetMinValue(Me.txtDocDateEnd1, "")
            Me.txtDocDateEnd1.Name = "txtDocDateEnd1"
            Me.Validator.SetRegularExpression(Me.txtDocDateEnd1, "")
            Me.Validator.SetRequired(Me.txtDocDateEnd1, False)
            Me.txtDocDateEnd1.Size = New System.Drawing.Size(99, 21)
            Me.txtDocDateEnd1.TabIndex = 67
            '
            'txtDocDateStart1
            '
            Me.Validator.SetDataType(Me.txtDocDateStart1, Longkong.Pojjaman.Gui.Components.DataTypeConstants.DateTimeType)
            Me.Validator.SetDisplayName(Me.txtDocDateStart1, "")
            Me.Validator.SetGotFocusBackColor(Me.txtDocDateStart1, System.Drawing.Color.Empty)
            Me.ErrorProvider1.SetIconPadding(Me.txtDocDateStart1, -15)
            Me.Validator.SetInvalidBackColor(Me.txtDocDateStart1, System.Drawing.Color.Empty)
            Me.txtDocDateStart1.Location = New System.Drawing.Point(107, 80)
            Me.txtDocDateStart1.MaxLength = 10
            Me.Validator.SetMinValue(Me.txtDocDateStart1, "")
            Me.txtDocDateStart1.Name = "txtDocDateStart1"
            Me.Validator.SetRegularExpression(Me.txtDocDateStart1, "")
            Me.Validator.SetRequired(Me.txtDocDateStart1, False)
            Me.txtDocDateStart1.Size = New System.Drawing.Size(99, 21)
            Me.txtDocDateStart1.TabIndex = 65
            '
            'dtpDocDateStart1
            '
            Me.dtpDocDateStart1.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
            Me.dtpDocDateStart1.Location = New System.Drawing.Point(107, 80)
            Me.dtpDocDateStart1.Name = "dtpDocDateStart1"
            Me.dtpDocDateStart1.Size = New System.Drawing.Size(120, 21)
            Me.dtpDocDateStart1.TabIndex = 66
            Me.dtpDocDateStart1.TabStop = False
            '
            'dtpDocDateEnd1
            '
            Me.dtpDocDateEnd1.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
            Me.dtpDocDateEnd1.Location = New System.Drawing.Point(267, 80)
            Me.dtpDocDateEnd1.Name = "dtpDocDateEnd1"
            Me.dtpDocDateEnd1.Size = New System.Drawing.Size(120, 21)
            Me.dtpDocDateEnd1.TabIndex = 69
            Me.dtpDocDateEnd1.TabStop = False
            '
            'Label1
            '
            Me.Label1.AutoSize = True
            Me.Label1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Label1.ForeColor = System.Drawing.Color.Black
            Me.Label1.Location = New System.Drawing.Point(243, 83)
            Me.Label1.Name = "Label1"
            Me.Label1.Size = New System.Drawing.Size(18, 13)
            Me.Label1.TabIndex = 68
            Me.Label1.Text = "ถึง"
            Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'Label2
            '
            Me.Label2.AutoSize = True
            Me.Label2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Label2.ForeColor = System.Drawing.Color.Black
            Me.Label2.Location = New System.Drawing.Point(6, 83)
            Me.Label2.Name = "Label2"
            Me.Label2.Size = New System.Drawing.Size(97, 13)
            Me.Label2.TabIndex = 58
            Me.Label2.Text = "ตั้งแต่วันที่อนุมัติ PR"
            Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtEmployee
            '
            Me.Validator.SetDataType(Me.txtEmployee, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtEmployee, "")
            Me.txtEmployee.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtEmployee, System.Drawing.Color.Empty)
            Me.ErrorProvider1.SetIconPadding(Me.txtEmployee, -15)
            Me.Validator.SetInvalidBackColor(Me.txtEmployee, System.Drawing.Color.Empty)
            Me.txtEmployee.Location = New System.Drawing.Point(107, 53)
            Me.txtEmployee.MaxLength = 50
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
            Me.btnEmployee.Location = New System.Drawing.Point(203, 53)
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
            Me.txtEmployeeName.Location = New System.Drawing.Point(227, 53)
            Me.txtEmployeeName.MaxLength = 50
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
            Me.lblEmpStart.AutoSize = True
            Me.lblEmpStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblEmpStart.ForeColor = System.Drawing.Color.Black
            Me.lblEmpStart.Location = New System.Drawing.Point(29, 56)
            Me.lblEmpStart.Name = "lblEmpStart"
            Me.lblEmpStart.Size = New System.Drawing.Size(74, 13)
            Me.lblEmpStart.TabIndex = 50
            Me.lblEmpStart.Text = "พนักงานขอซื้อ"
            Me.lblEmpStart.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'btnPREndFind
            '
            Me.btnPREndFind.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.btnPREndFind.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.btnPREndFind.ForeColor = System.Drawing.SystemColors.Control
            Me.btnPREndFind.Location = New System.Drawing.Point(363, 28)
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
            Me.txtPRCodeEnd.Location = New System.Drawing.Point(267, 28)
            Me.Validator.SetMinValue(Me.txtPRCodeEnd, "")
            Me.txtPRCodeEnd.Name = "txtPRCodeEnd"
            Me.Validator.SetRegularExpression(Me.txtPRCodeEnd, "")
            Me.Validator.SetRequired(Me.txtPRCodeEnd, False)
            Me.txtPRCodeEnd.Size = New System.Drawing.Size(96, 21)
            Me.txtPRCodeEnd.TabIndex = 46
            '
            'lblPREnd
            '
            Me.lblPREnd.AutoSize = True
            Me.lblPREnd.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblPREnd.ForeColor = System.Drawing.Color.Black
            Me.lblPREnd.Location = New System.Drawing.Point(243, 31)
            Me.lblPREnd.Name = "lblPREnd"
            Me.lblPREnd.Size = New System.Drawing.Size(18, 13)
            Me.lblPREnd.TabIndex = 45
            Me.lblPREnd.Text = "ถึง"
            Me.lblPREnd.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'btnPRStartFind
            '
            Me.btnPRStartFind.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.btnPRStartFind.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.btnPRStartFind.ForeColor = System.Drawing.SystemColors.Control
            Me.btnPRStartFind.Location = New System.Drawing.Point(203, 28)
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
            Me.txtPRCodeStart.Location = New System.Drawing.Point(107, 28)
            Me.Validator.SetMinValue(Me.txtPRCodeStart, "")
            Me.txtPRCodeStart.Name = "txtPRCodeStart"
            Me.Validator.SetRegularExpression(Me.txtPRCodeStart, "")
            Me.Validator.SetRequired(Me.txtPRCodeStart, False)
            Me.txtPRCodeStart.Size = New System.Drawing.Size(96, 21)
            Me.txtPRCodeStart.TabIndex = 43
            '
            'lblPRStart
            '
            Me.lblPRStart.AutoSize = True
            Me.lblPRStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblPRStart.ForeColor = System.Drawing.Color.Black
            Me.lblPRStart.Location = New System.Drawing.Point(28, 31)
            Me.lblPRStart.Name = "lblPRStart"
            Me.lblPRStart.Size = New System.Drawing.Size(75, 13)
            Me.lblPRStart.TabIndex = 42
            Me.lblPRStart.Text = "ตั้งแต่เลขที่ PR"
            Me.lblPRStart.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'btnCCCodeStart
            '
            Me.btnCCCodeStart.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.btnCCCodeStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.btnCCCodeStart.ForeColor = System.Drawing.SystemColors.Control
            Me.btnCCCodeStart.Location = New System.Drawing.Point(598, 52)
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
            Me.txtCCCodeStart.Location = New System.Drawing.Point(500, 53)
            Me.txtCCCodeStart.MaxLength = 50
            Me.Validator.SetMinValue(Me.txtCCCodeStart, "")
            Me.txtCCCodeStart.Name = "txtCCCodeStart"
            Me.Validator.SetRegularExpression(Me.txtCCCodeStart, "")
            Me.Validator.SetRequired(Me.txtCCCodeStart, False)
            Me.txtCCCodeStart.Size = New System.Drawing.Size(96, 21)
            Me.txtCCCodeStart.TabIndex = 6
            '
            'lblCCStart
            '
            Me.lblCCStart.AutoSize = True
            Me.lblCCStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblCCStart.ForeColor = System.Drawing.Color.Black
            Me.lblCCStart.Location = New System.Drawing.Point(429, 57)
            Me.lblCCStart.Name = "lblCCStart"
            Me.lblCCStart.Size = New System.Drawing.Size(65, 13)
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
            Me.txtCostCenterName.Location = New System.Drawing.Point(622, 54)
            Me.txtCostCenterName.MaxLength = 50
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
            Me.txtDocDateEnd.Location = New System.Drawing.Point(661, 25)
            Me.txtDocDateEnd.MaxLength = 10
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
            Me.txtDocDateStart.Location = New System.Drawing.Point(501, 25)
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
            Me.dtpDocDateStart.Location = New System.Drawing.Point(501, 25)
            Me.dtpDocDateStart.Name = "dtpDocDateStart"
            Me.dtpDocDateStart.Size = New System.Drawing.Size(120, 21)
            Me.dtpDocDateStart.TabIndex = 2
            Me.dtpDocDateStart.TabStop = False
            '
            'dtpDocDateEnd
            '
            Me.dtpDocDateEnd.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
            Me.dtpDocDateEnd.Location = New System.Drawing.Point(661, 25)
            Me.dtpDocDateEnd.Name = "dtpDocDateEnd"
            Me.dtpDocDateEnd.Size = New System.Drawing.Size(120, 21)
            Me.dtpDocDateEnd.TabIndex = 5
            Me.dtpDocDateEnd.TabStop = False
            '
            'lblDocDateStart
            '
            Me.lblDocDateStart.AutoSize = True
            Me.lblDocDateStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblDocDateStart.ForeColor = System.Drawing.Color.Black
            Me.lblDocDateStart.Location = New System.Drawing.Point(426, 28)
            Me.lblDocDateStart.Name = "lblDocDateStart"
            Me.lblDocDateStart.Size = New System.Drawing.Size(69, 13)
            Me.lblDocDateStart.TabIndex = 0
            Me.lblDocDateStart.Text = "ตั้งแต่วันที่ PR"
            Me.lblDocDateStart.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblDocDateEnd
            '
            Me.lblDocDateEnd.AutoSize = True
            Me.lblDocDateEnd.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblDocDateEnd.ForeColor = System.Drawing.Color.Black
            Me.lblDocDateEnd.Location = New System.Drawing.Point(637, 28)
            Me.lblDocDateEnd.Name = "lblDocDateEnd"
            Me.lblDocDateEnd.Size = New System.Drawing.Size(18, 13)
            Me.lblDocDateEnd.TabIndex = 3
            Me.lblDocDateEnd.Text = "ถึง"
            Me.lblDocDateEnd.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'btnReset
            '
            Me.btnReset.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.btnReset.Location = New System.Drawing.Point(654, 300)
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
            Me.btnSearch.Location = New System.Drawing.Point(734, 300)
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
            'RptUnorderPRItemVArcFilterSubPanel
            '
            Me.Controls.Add(Me.grbMaster)
            Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Name = "RptUnorderPRItemVArcFilterSubPanel"
            Me.Size = New System.Drawing.Size(854, 361)
            Me.grbMaster.ResumeLayout(False)
            Me.GroupBox1.ResumeLayout(False)
            Me.grbDetail.ResumeLayout(False)
            Me.grbDetail.PerformLayout()
            CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub

#End Region

#Region " SetLabelText "
        Public Sub SetLabelText()
            'If Not m_entity Is Nothing Then Me.Text = Me.StringParserService.Parse(Me.m_entity.TabPageText)
            Me.lblDocDateStart.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptUnorderPRItemVArcFilterSubPanel.lblDocDateStart}")
            Me.Validator.SetDisplayName(txtDocDateStart, lblDocDateStart.Text)

            Me.lblCCStart.Text = Me.StringParserService.Parse("${res:Global.CostCenterText}")
            Me.Validator.SetDisplayName(txtCCCodeStart, lblCCStart.Text)

            Me.lblDocDateEnd.Text = Me.StringParserService.Parse("${res:Global.FilterPanelTo}")
            Me.Validator.SetDisplayName(txtDocDateEnd, lblDocDateEnd.Text)

            Me.Label2.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptUnorderPRItemVArcFilterSubPanel.Label2}")
            Me.Validator.SetDisplayName(txtDocDateStart1, Label2.Text)

            Me.Label1.Text = Me.StringParserService.Parse("${res:Global.FilterPanelTo}")
            Me.Validator.SetDisplayName(txtDocDateEnd1, Label1.Text)

            ' Button
            Me.btnSearch.Text = Me.StringParserService.Parse("${res:Global.SearchButtonText}")
            Me.btnReset.Text = Me.StringParserService.Parse("${res:Global.ResetButtonText}")

            ' GroupBox
            Me.grbMaster.Text = Me.StringParserService.Parse("${res:Global.SearchText}")
            Me.grbDetail.Text = Me.StringParserService.Parse("${res:Global.grbGeneral}")
            Me.GroupBox1.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptUnorderPRItemVArcFilterSubPanel.GroupBox1}")

            'Checkbox
            Me.lblPRStart.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptUnorderPRItemVArcFilterSubPanel.lblPRStart}")
            Me.lblPREnd.Text = Me.StringParserService.Parse("${res:Global.FilterPanelTo}")
            Me.lblEmpStart.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptUnorderPRItemVArcFilterSubPanel.lblEmpStart}")
        End Sub
#End Region

#Region "Member"

        Private m_DocDateEnd As Date
        Private m_DocDateStart As Date

        Private m_DocDateEnd1 As Date
        Private m_DocDateStart1 As Date

        Private m_cc As CostCenter
        Private m_employee As Employee

        Private m_LCIList As Dictionary(Of String, LCIForList)
#End Region

#Region "Constructors"
        Public Sub New()
            MyBase.New()
            InitializeComponent()
            EventWiring()
            Initialize()

            'clbMaterial.CheckOnClick = True

            SetLabelText()
            ' LoopControl(Me)
        End Sub
#End Region

#Region "Properties"
        Public Property DocDateEnd() As Date            Get                Return m_DocDateEnd            End Get            Set(ByVal Value As Date)                m_DocDateEnd = Value            End Set        End Property        Public Property DocDateStart() As Date            Get                Return m_DocDateStart            End Get            Set(ByVal Value As Date)                m_DocDateStart = Value            End Set        End Property

        Public Property DocDateEnd1() As Date            Get                Return m_DocDateEnd1            End Get            Set(ByVal Value As Date)                m_DocDateEnd1 = Value            End Set        End Property        Public Property DocDateStart1() As Date            Get                Return m_DocDateStart1            End Get            Set(ByVal Value As Date)                m_DocDateStart1 = Value            End Set        End Property

        Public Property Costcenter() As CostCenter
            Get
                Return m_cc
            End Get
            Set(ByVal Value As CostCenter)
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
            'LoadCostCenter()
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

            Me.Costcenter = New CostCenter
            Me.Employee = New Employee

            Dim dtStart As Date = Date.Now.Subtract(New TimeSpan(7, 0, 0, 0))
            Me.DocDateStart = dtStart
            Me.txtDocDateStart.Text = MinDateToNull(Me.DocDateStart, "")
            Me.dtpDocDateStart.Value = Me.DocDateStart

            Me.DocDateEnd = Date.Now
            Me.txtDocDateEnd.Text = MinDateToNull(Me.DocDateEnd, "")
            Me.dtpDocDateEnd.Value = Me.DocDateEnd

            Me.DocDateStart1 = dtStart
            Me.txtDocDateStart1.Text = MinDateToNull(Me.DocDateStart1, "")
            Me.dtpDocDateStart1.Value = Me.DocDateStart1

            Me.DocDateEnd1 = Date.Now
            Me.txtDocDateEnd1.Text = MinDateToNull(Me.DocDateEnd1, "")
            Me.dtpDocDateEnd1.Value = Me.DocDateEnd1
            'txtMaterialName.Text = ""
            clbMaterial.Items.Clear()


        End Sub
        Public Overrides Function GetFilterString() As String

        End Function
        Public Overrides Function GetFilterArray() As Filter()
            Dim arr(9) As Filter
            arr(0) = New Filter("DocDateStart", IIf(Me.DocDateStart.Equals(Date.MinValue), DBNull.Value, Me.DocDateStart))
            arr(1) = New Filter("DocDateEnd", IIf(Me.DocDateEnd.Equals(Date.MinValue), DBNull.Value, Me.DocDateEnd))
            arr(2) = New Filter("PRCodeStart", IIf(txtPRCodeStart.TextLength > 0, txtPRCodeStart.Text, DBNull.Value))
            arr(3) = New Filter("PRCodeEnd", IIf(txtPRCodeEnd.TextLength > 0, txtPRCodeEnd.Text, DBNull.Value))
            arr(4) = New Filter("Employee_id", Me.ValidIdOrDBNull(m_employee))
            arr(5) = New Filter("cc_id", Me.ValidIdOrDBNull(m_cc))

            arr(6) = New Filter("APDocDateStart", IIf(Me.DocDateStart1.Equals(Date.MinValue), DBNull.Value, Me.DocDateStart1))
            arr(7) = New Filter("APDocDateEnd", IIf(Me.DocDateEnd1.Equals(Date.MinValue), DBNull.Value, Me.DocDateEnd1))
            arr(8) = New Filter("userRight", CType(ServiceManager.Services.GetService(GetType(SecurityService)), SecurityService).CurrentUser.Id)
            arr(9) = New Filter("MaterialName", CheckedLCIListString)
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

        Private LCIList As Dictionary(Of String, LCIItem)
        Private Sub LoadCostCenter()

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

            'Docdate Start AP
            dpi = New DocPrintingItem
            dpi.Mapping = "APDocdateStart"
            dpi.Value = Me.txtDocDateStart1.Text
            dpi.DataType = "System.String"
            dpiColl.Add(dpi)

            'Docdate End AP
            dpi = New DocPrintingItem
            dpi.Mapping = "APDocdateEnd"
            dpi.Value = Me.txtDocDateEnd1.Text
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
            dpi.Value = Me.txtPRCodeStart.Text
            dpi.DataType = "System.String"
            dpiColl.Add(dpi)

            'Employee Code
            dpi = New DocPrintingItem
            dpi.Mapping = "EmployeeCode"
            dpi.Value = Me.txtEmployee.Text
            dpi.DataType = "System.String"
            dpiColl.Add(dpi)

            'Employee Name
            dpi = New DocPrintingItem
            dpi.Mapping = "EmployeeName"
            dpi.Value = Me.txtEmployeeName.Text
            dpi.DataType = "System.String"
            dpiColl.Add(dpi)

            'CostCenterCode
            dpi = New DocPrintingItem
            dpi.Mapping = "CostCenterCode"
            dpi.Value = Me.txtCCCodeStart.Text
            dpi.DataType = "System.String"
            dpiColl.Add(dpi)

            'CostCenterName
            dpi = New DocPrintingItem
            dpi.Mapping = "CostCenterName"
            dpi.Value = Me.txtCostCenterName.Text
            dpi.DataType = "System.String"
            dpiColl.Add(dpi)

            'CostCenterInfo
            dpi = New DocPrintingItem
            dpi.Mapping = "CostCenterInfo"
            dpi.Value = Me.txtCCCodeStart.Text & ":" & Me.txtCostCenterName.Text
            dpi.DataType = "System.String"
            dpiColl.Add(dpi)

            ''CheckBox chkIncludeChildren
            'If Me.chkIncludeChildren.Checked Then
            '    dpi = New DocPrintingItem
            '    dpi.Mapping = "childincluded"
            '    dpi.Value = "(รวมในสังกัด)"
            '    dpi.DataType = "System.String"
            '    dpiColl.Add(dpi)
            'End If

            ''CheckBox ShowDetail
            'If Me.chkShowDetail.Checked Then
            '    dpi = New DocPrintingItem
            '    dpi.Mapping = "ShowDetail"
            '    dpi.Value = "(โชว์รายละเอียด)"
            '    dpi.DataType = "System.String"
            '    dpiColl.Add(dpi)
            'End If
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

            AddHandler txtDocDateStart1.Validated, AddressOf Me.ChangeProperty
            AddHandler txtDocDateEnd1.Validated, AddressOf Me.ChangeProperty

            AddHandler dtpDocDateStart1.ValueChanged, AddressOf Me.ChangeProperty
            AddHandler dtpDocDateEnd1.ValueChanged, AddressOf Me.ChangeProperty

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

                    '---------
                Case "dtpdocdatestart1"
                    If Not Me.DocDateStart1.Equals(dtpDocDateStart1.Value) Then
                        If Not m_dateSetting Then
                            Me.txtDocDateStart1.Text = MinDateToNull(dtpDocDateStart1.Value, Me.StringParserService.Parse("${res:Global.BlankDateText}"))
                            Me.DocDateStart1 = dtpDocDateStart1.Value
                        End If
                    End If
                Case "txtdocdatestart1"
                    m_dateSetting = True
                    If Not Me.txtDocDateStart1.Text.Length = 0 AndAlso Me.Validator.GetErrorMessage(Me.txtDocDateStart1) = "" Then
                        Dim theDate As Date = CDate(Me.txtDocDateStart1.Text)
                        If Not Me.DocDateStart1.Equals(theDate) Then
                            dtpDocDateStart.Value = theDate
                            Me.DocDateStart1 = dtpDocDateStart1.Value
                        End If
                    Else
                        Me.dtpDocDateStart1.Value = Date.Now
                        Me.DocDateStart1 = Date.MinValue
                    End If
                    m_dateSetting = False

                Case "dtpdocdateend1"
                    If Not Me.DocDateEnd1.Equals(dtpDocDateEnd1.Value) Then
                        If Not m_dateSetting Then
                            Me.txtDocDateEnd1.Text = MinDateToNull(dtpDocDateEnd1.Value, Me.StringParserService.Parse("${res:Global.BlankDateText}"))
                            Me.DocDateEnd1 = dtpDocDateEnd1.Value
                        End If
                    End If
                Case "txtdocdateend1"
                    m_dateSetting = True
                    If Not Me.txtDocDateEnd1.Text.Length = 0 AndAlso Me.Validator.GetErrorMessage(Me.txtDocDateEnd1) = "" Then
                        Dim theDate As Date = CDate(Me.txtDocDateEnd1.Text)
                        If Not Me.DocDateEnd1.Equals(theDate) Then
                            dtpDocDateEnd1.Value = theDate
                            Me.DocDateEnd1 = dtpDocDateEnd1.Value
                        End If
                    Else
                        Me.dtpDocDateEnd1.Value = Date.Now
                        Me.DocDateEnd1 = Date.MinValue
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
        ' Costcenter
        Private Sub btnCostcenterFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
            Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
            Select Case CType(sender, Control).Name.ToLower
                Case "btncccodestart"
                    myEntityPanelService.OpenTreeDialog(New CostCenter, AddressOf SetCCCodeStartDialog)
            End Select
        End Sub
        'PR
        Private Sub btnPRFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) 'Handles btnPRStartFind.Click, btnPREndFind.Click
            Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
            Dim thePR As New PRForSelection
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
        Private Sub btnMaterialCode_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMaterialCode.Click
            Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
            Dim i = 0
            'txtMaterialName.Text = ""

            clbMaterial.Items.Clear()

            LCICodeList = New ArrayList
            Dim entities(0) As ISimpleEntity

            entities(0) = New LCIForList
        
            myEntityPanelService.OpenListDialog(entities, AddressOf SetItems)
            'txtMaterialName.Text = String.Join(",", LCICodeList.ToArray)

            'CheckedLCIListString = String.Join(",", LCICodeList.ToArray)
 
            For i = 0 To LCICodeList.Count
                clbMaterial.Items.Add(LCICodeList(i))
            Next



        End Sub

        Private Function CheckedLCIListString() As String

            Dim chkId As New List(Of String)
            Dim order As Integer = 0
            Dim i As Integer = 0

            For Each chki As Object In clbMaterial.Items
                Dim s As String = chki
                s = s & "|" & order.ToString
                chkId.Add(s)
                order += 1
            Next
            Return String.Join(",", chkId)

        End Function

#End Region
        'Dim CheckedLCIListString As String
        Dim LCICodeList As ArrayList
        Public Sub SetItems(ByVal items As BasketItemCollection, Optional ByVal targetType As Integer = -1)
            LCICodeList = New ArrayList

            For i As Integer = 0 To items.Count - 1
                If Not TypeOf items(i) Is StockBasketItem Then
                    '-----------------LCI Items--------------------

                    Dim item As BasketItem = CType(items(i), BasketItem)
                    Dim newItem As IHasName
                    Dim newType As Integer = -1
                    Select Case item.FullClassName.ToLower
                        Case "longkong.pojjaman.businesslogic.lciitem", "longkong.pojjaman.businesslogic.lciforlist"
                            newItem = New LCIItem(item.Id)
                            If targetType > -1 Then
                                newType = targetType
                            Else
                                newType = 42
                            End If

                            LCICodeList.Add(newItem.Code)
                    End Select
                End If
            Next
        End Sub

        Private Sub ibtnUp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnUp.Click
            Dim code As String = clbMaterial.SelectedItem.ToString
            Dim index As Integer = clbMaterial.SelectedIndex
            Dim chk As Boolean = clbMaterial.SelectedItems.Contains(clbMaterial.SelectedItem)

            Dim swap As Object = clbMaterial.SelectedItem
            If Not (swap Is Nothing) AndAlso index >= 1 Then               'If something is selected...
                clbMaterial.Items.RemoveAt(index)                   'Remove it
                clbMaterial.Items.Insert(index - 1, swap)           'Add it back in one spot up
                clbMaterial.SetSelected(index - 1, chk)
                clbMaterial.SelectedItem = swap                     'Keep this item selected

            End If
        End Sub

        Private Sub ibtnDown_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ibtnDown.Click
            Dim index As Integer = clbMaterial.SelectedIndex
            Dim swap As Object = clbMaterial.SelectedItem
            Dim chk As Boolean = clbMaterial.SelectedItems.Contains(clbMaterial.SelectedItem)
            If Not (swap Is Nothing) AndAlso index < clbMaterial.Items.Count - 1 Then     'If something is selected...
                clbMaterial.Items.RemoveAt(index)                   'Remove it
                clbMaterial.Items.Insert(index + 1, swap)           'Add it back in one spot up
                clbMaterial.SetSelected(index + 1, chk)
                clbMaterial.SelectedItem = swap                     'Keep this item selected
            End If
        End Sub
    End Class
End Namespace

