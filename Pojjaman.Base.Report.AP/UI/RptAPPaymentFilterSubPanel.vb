Imports Longkong.Pojjaman.BusinessLogic
Imports Longkong.Pojjaman.Services
Imports Longkong.Core.Services

Namespace Longkong.Pojjaman.Gui.Panels
  Public Class RptAPPaymentFilterSubPanel
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
    Friend WithEvents lblPaymentType As System.Windows.Forms.Label
    Friend WithEvents cmbPaymentType As System.Windows.Forms.ComboBox
    Friend WithEvents txtSupplierGroupName As System.Windows.Forms.TextBox
    Friend WithEvents lblSupplierGroup As System.Windows.Forms.Label
    Friend WithEvents txtSupplierGroupStart As System.Windows.Forms.TextBox
    Friend WithEvents btnSupplierGroupStart As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents chkIncludeSGChildren As System.Windows.Forms.CheckBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtRefDocCodePrefix As System.Windows.Forms.TextBox
    Friend WithEvents txtGLCodeprefix As System.Windows.Forms.TextBox
    Friend WithEvents lblOrderBy As System.Windows.Forms.Label
    Friend WithEvents cmbOrderBy As System.Windows.Forms.ComboBox
    Friend WithEvents chkDetail As System.Windows.Forms.CheckBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
      Me.components = New System.ComponentModel.Container()
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(RptAPPaymentFilterSubPanel))
      Me.grbMaster = New Longkong.Pojjaman.Gui.Components.FixedGroupBox()
      Me.txtTemp = New System.Windows.Forms.TextBox()
      Me.grbDetail = New Longkong.Pojjaman.Gui.Components.FixedGroupBox()
      Me.chkDetail = New System.Windows.Forms.CheckBox()
      Me.txtSupplierGroupName = New System.Windows.Forms.TextBox()
      Me.lblSupplierGroup = New System.Windows.Forms.Label()
      Me.txtSupplierGroupStart = New System.Windows.Forms.TextBox()
      Me.btnSupplierGroupStart = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.chkIncludeSGChildren = New System.Windows.Forms.CheckBox()
      Me.cmbPaymentType = New System.Windows.Forms.ComboBox()
      Me.lblPaymentType = New System.Windows.Forms.Label()
      Me.chkIncludeChildren = New System.Windows.Forms.CheckBox()
      Me.btnCCCodeStart = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.txtCCCodeStart = New System.Windows.Forms.TextBox()
      Me.lblCCStart = New System.Windows.Forms.Label()
      Me.txtCostCenterName = New System.Windows.Forms.TextBox()
      Me.btnSuppliEndFind = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.txtSuppliCodeEnd = New System.Windows.Forms.TextBox()
      Me.lblSuppliEnd = New System.Windows.Forms.Label()
      Me.btnSuppliStartFind = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.txtSuppliCodeStart = New System.Windows.Forms.TextBox()
      Me.lblSuppliStart = New System.Windows.Forms.Label()
      Me.txtDocDateEnd = New System.Windows.Forms.TextBox()
      Me.txtDocDateStart = New System.Windows.Forms.TextBox()
      Me.dtpDocDateStart = New System.Windows.Forms.DateTimePicker()
      Me.dtpDocDateEnd = New System.Windows.Forms.DateTimePicker()
      Me.lblDocDateStart = New System.Windows.Forms.Label()
      Me.lblDocDateEnd = New System.Windows.Forms.Label()
      Me.btnSearch = New System.Windows.Forms.Button()
      Me.btnReset = New System.Windows.Forms.Button()
      Me.Validator = New Longkong.Pojjaman.Gui.Components.PJMTextboxValidator()
      Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider()
      Me.Label2 = New System.Windows.Forms.Label()
      Me.Label1 = New System.Windows.Forms.Label()
      Me.txtRefDocCodePrefix = New System.Windows.Forms.TextBox()
      Me.txtGLCodeprefix = New System.Windows.Forms.TextBox()
      Me.lblOrderBy = New System.Windows.Forms.Label()
      Me.cmbOrderBy = New System.Windows.Forms.ComboBox()
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
      Me.grbMaster.Location = New System.Drawing.Point(8, 8)
      Me.grbMaster.Name = "grbMaster"
      Me.grbMaster.Size = New System.Drawing.Size(664, 224)
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
      Me.txtTemp.Location = New System.Drawing.Point(672, 32)
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
      Me.grbDetail.Controls.Add(Me.Label2)
      Me.grbDetail.Controls.Add(Me.chkDetail)
      Me.grbDetail.Controls.Add(Me.Label1)
      Me.grbDetail.Controls.Add(Me.txtSupplierGroupName)
      Me.grbDetail.Controls.Add(Me.txtRefDocCodePrefix)
      Me.grbDetail.Controls.Add(Me.lblSupplierGroup)
      Me.grbDetail.Controls.Add(Me.txtGLCodeprefix)
      Me.grbDetail.Controls.Add(Me.txtSupplierGroupStart)
      Me.grbDetail.Controls.Add(Me.lblOrderBy)
      Me.grbDetail.Controls.Add(Me.btnSupplierGroupStart)
      Me.grbDetail.Controls.Add(Me.cmbOrderBy)
      Me.grbDetail.Controls.Add(Me.chkIncludeSGChildren)
      Me.grbDetail.Controls.Add(Me.cmbPaymentType)
      Me.grbDetail.Controls.Add(Me.lblPaymentType)
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
      Me.grbDetail.Controls.Add(Me.txtDocDateEnd)
      Me.grbDetail.Controls.Add(Me.txtDocDateStart)
      Me.grbDetail.Controls.Add(Me.dtpDocDateStart)
      Me.grbDetail.Controls.Add(Me.dtpDocDateEnd)
      Me.grbDetail.Controls.Add(Me.lblDocDateStart)
      Me.grbDetail.Controls.Add(Me.lblDocDateEnd)
      Me.grbDetail.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.grbDetail.Location = New System.Drawing.Point(16, 16)
      Me.grbDetail.Name = "grbDetail"
      Me.grbDetail.Size = New System.Drawing.Size(632, 168)
      Me.grbDetail.TabIndex = 0
      Me.grbDetail.TabStop = False
      Me.grbDetail.Text = "ข้อมูลทั่วไป"
      '
      'chkDetail
      '
      Me.chkDetail.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.chkDetail.Location = New System.Drawing.Point(496, 40)
      Me.chkDetail.Name = "chkDetail"
      Me.chkDetail.Size = New System.Drawing.Size(128, 24)
      Me.chkDetail.TabIndex = 55
      Me.chkDetail.Text = "แสดงรายละเอียด"
      '
      'txtSupplierGroupName
      '
      Me.Validator.SetDataType(Me.txtSupplierGroupName, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtSupplierGroupName, "")
      Me.txtSupplierGroupName.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtSupplierGroupName, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtSupplierGroupName, -15)
      Me.Validator.SetInvalidBackColor(Me.txtSupplierGroupName, System.Drawing.Color.Empty)
      Me.txtSupplierGroupName.Location = New System.Drawing.Point(224, 40)
      Me.txtSupplierGroupName.MaxLength = 50
      Me.Validator.SetMinValue(Me.txtSupplierGroupName, "")
      Me.txtSupplierGroupName.Name = "txtSupplierGroupName"
      Me.txtSupplierGroupName.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtSupplierGroupName, "")
      Me.Validator.SetRequired(Me.txtSupplierGroupName, False)
      Me.txtSupplierGroupName.Size = New System.Drawing.Size(160, 21)
      Me.txtSupplierGroupName.TabIndex = 51
      '
      'lblSupplierGroup
      '
      Me.lblSupplierGroup.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblSupplierGroup.ForeColor = System.Drawing.Color.Black
      Me.lblSupplierGroup.Location = New System.Drawing.Point(8, 40)
      Me.lblSupplierGroup.Name = "lblSupplierGroup"
      Me.lblSupplierGroup.Size = New System.Drawing.Size(88, 18)
      Me.lblSupplierGroup.TabIndex = 50
      Me.lblSupplierGroup.Text = "กลุ่มผู้ขาย:"
      Me.lblSupplierGroup.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'txtSupplierGroupStart
      '
      Me.Validator.SetDataType(Me.txtSupplierGroupStart, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtSupplierGroupStart, "")
      Me.txtSupplierGroupStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtSupplierGroupStart, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtSupplierGroupStart, -15)
      Me.Validator.SetInvalidBackColor(Me.txtSupplierGroupStart, System.Drawing.Color.Empty)
      Me.txtSupplierGroupStart.Location = New System.Drawing.Point(104, 40)
      Me.txtSupplierGroupStart.MaxLength = 50
      Me.Validator.SetMinValue(Me.txtSupplierGroupStart, "")
      Me.txtSupplierGroupStart.Name = "txtSupplierGroupStart"
      Me.Validator.SetRegularExpression(Me.txtSupplierGroupStart, "")
      Me.Validator.SetRequired(Me.txtSupplierGroupStart, False)
      Me.txtSupplierGroupStart.Size = New System.Drawing.Size(96, 21)
      Me.txtSupplierGroupStart.TabIndex = 52
      '
      'btnSupplierGroupStart
      '
      Me.btnSupplierGroupStart.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnSupplierGroupStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.btnSupplierGroupStart.ForeColor = System.Drawing.SystemColors.Control
      Me.btnSupplierGroupStart.Location = New System.Drawing.Point(200, 40)
      Me.btnSupplierGroupStart.Name = "btnSupplierGroupStart"
      Me.btnSupplierGroupStart.Size = New System.Drawing.Size(24, 22)
      Me.btnSupplierGroupStart.TabIndex = 53
      Me.btnSupplierGroupStart.TabStop = False
      Me.btnSupplierGroupStart.ThemedImage = CType(resources.GetObject("btnSupplierGroupStart.ThemedImage"), System.Drawing.Bitmap)
      '
      'chkIncludeSGChildren
      '
      Me.chkIncludeSGChildren.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.chkIncludeSGChildren.Location = New System.Drawing.Point(104, 64)
      Me.chkIncludeSGChildren.Name = "chkIncludeSGChildren"
      Me.chkIncludeSGChildren.Size = New System.Drawing.Size(128, 24)
      Me.chkIncludeSGChildren.TabIndex = 54
      Me.chkIncludeSGChildren.Text = "รวมกลุ่มผู้ขายลูก"
      '
      'cmbPaymentType
      '
      Me.cmbPaymentType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbPaymentType.Location = New System.Drawing.Point(496, 16)
      Me.cmbPaymentType.Name = "cmbPaymentType"
      Me.cmbPaymentType.Size = New System.Drawing.Size(120, 21)
      Me.cmbPaymentType.TabIndex = 32
      '
      'lblPaymentType
      '
      Me.lblPaymentType.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblPaymentType.ForeColor = System.Drawing.Color.Black
      Me.lblPaymentType.Location = New System.Drawing.Point(408, 16)
      Me.lblPaymentType.Name = "lblPaymentType"
      Me.lblPaymentType.Size = New System.Drawing.Size(80, 18)
      Me.lblPaymentType.TabIndex = 31
      Me.lblPaymentType.Text = "ประเภทการจ่าย"
      Me.lblPaymentType.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'chkIncludeChildren
      '
      Me.chkIncludeChildren.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.chkIncludeChildren.Location = New System.Drawing.Point(104, 136)
      Me.chkIncludeChildren.Name = "chkIncludeChildren"
      Me.chkIncludeChildren.Size = New System.Drawing.Size(144, 24)
      Me.chkIncludeChildren.TabIndex = 23
      Me.chkIncludeChildren.Text = "รวม Cost Center ลูก"
      '
      'btnCCCodeStart
      '
      Me.btnCCCodeStart.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnCCCodeStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.btnCCCodeStart.ForeColor = System.Drawing.SystemColors.Control
      Me.btnCCCodeStart.Location = New System.Drawing.Point(200, 112)
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
      Me.txtCCCodeStart.Location = New System.Drawing.Point(104, 112)
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
      Me.lblCCStart.Location = New System.Drawing.Point(32, 112)
      Me.lblCCStart.Name = "lblCCStart"
      Me.lblCCStart.Size = New System.Drawing.Size(64, 18)
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
      Me.txtCostCenterName.Location = New System.Drawing.Point(224, 112)
      Me.txtCostCenterName.MaxLength = 50
      Me.Validator.SetMinValue(Me.txtCostCenterName, "")
      Me.txtCostCenterName.Name = "txtCostCenterName"
      Me.txtCostCenterName.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtCostCenterName, "")
      Me.Validator.SetRequired(Me.txtCostCenterName, False)
      Me.txtCostCenterName.Size = New System.Drawing.Size(160, 21)
      Me.txtCostCenterName.TabIndex = 20
      '
      'btnSuppliEndFind
      '
      Me.btnSuppliEndFind.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnSuppliEndFind.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.btnSuppliEndFind.ForeColor = System.Drawing.SystemColors.Control
      Me.btnSuppliEndFind.Location = New System.Drawing.Point(360, 88)
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
      Me.txtSuppliCodeEnd.Location = New System.Drawing.Point(264, 88)
      Me.Validator.SetMinValue(Me.txtSuppliCodeEnd, "")
      Me.txtSuppliCodeEnd.Name = "txtSuppliCodeEnd"
      Me.Validator.SetRegularExpression(Me.txtSuppliCodeEnd, "")
      Me.Validator.SetRequired(Me.txtSuppliCodeEnd, False)
      Me.txtSuppliCodeEnd.Size = New System.Drawing.Size(96, 21)
      Me.txtSuppliCodeEnd.TabIndex = 10
      '
      'lblSuppliEnd
      '
      Me.lblSuppliEnd.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblSuppliEnd.ForeColor = System.Drawing.Color.Black
      Me.lblSuppliEnd.Location = New System.Drawing.Point(232, 88)
      Me.lblSuppliEnd.Name = "lblSuppliEnd"
      Me.lblSuppliEnd.Size = New System.Drawing.Size(24, 18)
      Me.lblSuppliEnd.TabIndex = 9
      Me.lblSuppliEnd.Text = "ถึง"
      Me.lblSuppliEnd.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
      '
      'btnSuppliStartFind
      '
      Me.btnSuppliStartFind.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnSuppliStartFind.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.btnSuppliStartFind.ForeColor = System.Drawing.SystemColors.Control
      Me.btnSuppliStartFind.Location = New System.Drawing.Point(200, 88)
      Me.btnSuppliStartFind.Name = "btnSuppliStartFind"
      Me.btnSuppliStartFind.Size = New System.Drawing.Size(24, 22)
      Me.btnSuppliStartFind.TabIndex = 8
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
      Me.txtSuppliCodeStart.Location = New System.Drawing.Point(104, 88)
      Me.Validator.SetMinValue(Me.txtSuppliCodeStart, "")
      Me.txtSuppliCodeStart.Name = "txtSuppliCodeStart"
      Me.Validator.SetRegularExpression(Me.txtSuppliCodeStart, "")
      Me.Validator.SetRequired(Me.txtSuppliCodeStart, False)
      Me.txtSuppliCodeStart.Size = New System.Drawing.Size(96, 21)
      Me.txtSuppliCodeStart.TabIndex = 7
      '
      'lblSuppliStart
      '
      Me.lblSuppliStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblSuppliStart.ForeColor = System.Drawing.Color.Black
      Me.lblSuppliStart.Location = New System.Drawing.Point(8, 88)
      Me.lblSuppliStart.Name = "lblSuppliStart"
      Me.lblSuppliStart.Size = New System.Drawing.Size(88, 18)
      Me.lblSuppliStart.TabIndex = 6
      Me.lblSuppliStart.Text = "Supplier:"
      Me.lblSuppliStart.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'txtDocDateEnd
      '
      Me.Validator.SetDataType(Me.txtDocDateEnd, Longkong.Pojjaman.Gui.Components.DataTypeConstants.DateTimeType)
      Me.Validator.SetDisplayName(Me.txtDocDateEnd, "")
      Me.Validator.SetGotFocusBackColor(Me.txtDocDateEnd, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtDocDateEnd, -15)
      Me.Validator.SetInvalidBackColor(Me.txtDocDateEnd, System.Drawing.Color.Empty)
      Me.txtDocDateEnd.Location = New System.Drawing.Point(264, 16)
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
      Me.txtDocDateStart.Location = New System.Drawing.Point(104, 16)
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
      Me.dtpDocDateStart.Location = New System.Drawing.Point(104, 16)
      Me.dtpDocDateStart.Name = "dtpDocDateStart"
      Me.dtpDocDateStart.Size = New System.Drawing.Size(120, 21)
      Me.dtpDocDateStart.TabIndex = 2
      Me.dtpDocDateStart.TabStop = False
      '
      'dtpDocDateEnd
      '
      Me.dtpDocDateEnd.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
      Me.dtpDocDateEnd.Location = New System.Drawing.Point(264, 16)
      Me.dtpDocDateEnd.Name = "dtpDocDateEnd"
      Me.dtpDocDateEnd.Size = New System.Drawing.Size(120, 21)
      Me.dtpDocDateEnd.TabIndex = 5
      Me.dtpDocDateEnd.TabStop = False
      '
      'lblDocDateStart
      '
      Me.lblDocDateStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblDocDateStart.ForeColor = System.Drawing.Color.Black
      Me.lblDocDateStart.Location = New System.Drawing.Point(8, 16)
      Me.lblDocDateStart.Name = "lblDocDateStart"
      Me.lblDocDateStart.Size = New System.Drawing.Size(88, 18)
      Me.lblDocDateStart.TabIndex = 0
      Me.lblDocDateStart.Text = "ตั้งแต่"
      Me.lblDocDateStart.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblDocDateEnd
      '
      Me.lblDocDateEnd.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblDocDateEnd.ForeColor = System.Drawing.Color.Black
      Me.lblDocDateEnd.Location = New System.Drawing.Point(232, 16)
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
      Me.btnSearch.Location = New System.Drawing.Point(576, 192)
      Me.btnSearch.Name = "btnSearch"
      Me.btnSearch.Size = New System.Drawing.Size(75, 23)
      Me.btnSearch.TabIndex = 2
      Me.btnSearch.Text = "ค้นหา"
      '
      'btnReset
      '
      Me.btnReset.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnReset.Location = New System.Drawing.Point(496, 192)
      Me.btnReset.Name = "btnReset"
      Me.btnReset.Size = New System.Drawing.Size(75, 23)
      Me.btnReset.TabIndex = 1
      Me.btnReset.TabStop = False
      Me.btnReset.Text = "เคลียร์"
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
      'Label2
      '
      Me.Label2.Location = New System.Drawing.Point(408, 114)
      Me.Label2.Name = "Label2"
      Me.Label2.Size = New System.Drawing.Size(80, 16)
      Me.Label2.TabIndex = 39
      Me.Label2.Text = "RefCodePrefix"
      '
      'Label1
      '
      Me.Label1.Location = New System.Drawing.Point(408, 90)
      Me.Label1.Name = "Label1"
      Me.Label1.Size = New System.Drawing.Size(72, 16)
      Me.Label1.TabIndex = 38
      Me.Label1.Text = "GLCodePrefix"
      '
      'txtRefDocCodePrefix
      '
      Me.Validator.SetDataType(Me.txtRefDocCodePrefix, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtRefDocCodePrefix, "")
      Me.Validator.SetGotFocusBackColor(Me.txtRefDocCodePrefix, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtRefDocCodePrefix, System.Drawing.Color.Empty)
      Me.txtRefDocCodePrefix.Location = New System.Drawing.Point(496, 114)
      Me.Validator.SetMinValue(Me.txtRefDocCodePrefix, "")
      Me.txtRefDocCodePrefix.Name = "txtRefDocCodePrefix"
      Me.Validator.SetRegularExpression(Me.txtRefDocCodePrefix, "")
      Me.Validator.SetRequired(Me.txtRefDocCodePrefix, False)
      Me.txtRefDocCodePrefix.Size = New System.Drawing.Size(120, 21)
      Me.txtRefDocCodePrefix.TabIndex = 37
      '
      'txtGLCodeprefix
      '
      Me.Validator.SetDataType(Me.txtGLCodeprefix, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtGLCodeprefix, "")
      Me.Validator.SetGotFocusBackColor(Me.txtGLCodeprefix, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtGLCodeprefix, System.Drawing.Color.Empty)
      Me.txtGLCodeprefix.Location = New System.Drawing.Point(496, 90)
      Me.Validator.SetMinValue(Me.txtGLCodeprefix, "")
      Me.txtGLCodeprefix.Name = "txtGLCodeprefix"
      Me.Validator.SetRegularExpression(Me.txtGLCodeprefix, "")
      Me.Validator.SetRequired(Me.txtGLCodeprefix, False)
      Me.txtGLCodeprefix.Size = New System.Drawing.Size(120, 21)
      Me.txtGLCodeprefix.TabIndex = 36
      '
      'lblOrderBy
      '
      Me.lblOrderBy.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblOrderBy.ForeColor = System.Drawing.Color.Black
      Me.lblOrderBy.Location = New System.Drawing.Point(400, 66)
      Me.lblOrderBy.Name = "lblOrderBy"
      Me.lblOrderBy.Size = New System.Drawing.Size(88, 18)
      Me.lblOrderBy.TabIndex = 35
      Me.lblOrderBy.Text = "เรียงตาม"
      Me.lblOrderBy.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'cmbOrderBy
      '
      Me.cmbOrderBy.Location = New System.Drawing.Point(496, 66)
      Me.cmbOrderBy.Name = "cmbOrderBy"
      Me.cmbOrderBy.Size = New System.Drawing.Size(120, 21)
      Me.cmbOrderBy.TabIndex = 34
      '
      'RptAPPaymentFilterSubPanel
      '
      Me.Controls.Add(Me.grbMaster)
      Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Name = "RptAPPaymentFilterSubPanel"
      Me.Size = New System.Drawing.Size(680, 240)
      Me.grbMaster.ResumeLayout(False)
      Me.grbMaster.PerformLayout()
      Me.grbDetail.ResumeLayout(False)
      Me.grbDetail.PerformLayout()
      Me.ResumeLayout(False)

    End Sub

#End Region

#Region " SetLabelText "
    Public Sub SetLabelText()
      'If Not m_entity Is Nothing Then Me.Text = Me.StringParserService.Parse(Me.m_entity.TabPageText)
      Me.lblSuppliStart.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptAPPaymentFilterSubPanel.lblSuppliStart}")
      Me.Validator.SetDisplayName(txtSuppliCodeStart, lblSuppliStart.Text)

      'SupplierGroup
      Me.lblSupplierGroup.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptAPPaymentFilterSubPanel.lblSupplierGroup}")
      Me.Validator.SetDisplayName(txtSupplierGroupStart, lblSupplierGroup.Text)
      Me.chkIncludeSGChildren.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptAPPaymentFilterSubPanel.chkIncludeSGChildren}")

      Me.lblDocDateStart.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptAPPaymentFilterSubPanel.lblDocDateStart}")
      Me.Validator.SetDisplayName(txtDocDateStart, lblDocDateStart.Text)

      Me.lblCCStart.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptAPPaymentFilterSubPanel.lblCCStart}")
      Me.Validator.SetDisplayName(txtCCCodeStart, lblCCStart.Text)

      ' Global {ถึง}
      Me.lblSuppliEnd.Text = Me.StringParserService.Parse("${res:Global.FilterPanelTo}")
      Me.Validator.SetDisplayName(txtSuppliCodeEnd, lblSuppliEnd.Text)

      Me.lblDocDateEnd.Text = Me.StringParserService.Parse("${res:Global.FilterPanelTo}")
      Me.Validator.SetDisplayName(txtDocDateEnd, lblDocDateEnd.Text)
      ' Button
      Me.btnSearch.Text = Me.StringParserService.Parse("${res:Global.SearchButtonText}")
      Me.btnReset.Text = Me.StringParserService.Parse("${res:Global.ResetButtonText}")

      ' GroupBox
      Me.grbMaster.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptAPPaymentFilterSubPanel.grbMaster}")
      Me.grbDetail.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptAPPaymentFilterSubPanel.grbDetail}")
      'Checkbox
      Me.chkIncludeChildren.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptAPPaymentFilterSubPanel.chkIncludeChildren}")

      Me.lblPaymentType.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptAPPaymentFilterSubPanel.lblPaymentType}")
      Me.chkDetail.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptAPPaymentFilterSubPanel.chkDetail}")
    End Sub
#End Region

#Region "Member"
    Private m_supplierstart As Supplier
    Private m_supplierend As Supplier
    Private m_sg As SupplierGroup

    Private m_DocDateEnd As Date
    Private m_DocDateStart As Date

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
    Public Property SupplierStart() As Supplier
      Get
        Return m_supplierstart
      End Get
      Set(ByVal Value As Supplier)
        m_supplierstart = Value
      End Set
    End Property
    Public Property SupplierEnd() As Supplier
      Get
        Return m_supplierend
      End Get
      Set(ByVal Value As Supplier)
        m_supplierend = Value
      End Set
    End Property
    Public Property SupplierGroup() As SupplierGroup
      Get
        Return m_sg
      End Get
      Set(ByVal Value As SupplierGroup)
        m_sg = Value
      End Set
    End Property
    Public Property DocDateEnd() As Date      Get        Return m_DocDateEnd      End Get      Set(ByVal Value As Date)        m_DocDateEnd = Value      End Set    End Property    Public Property DocDateStart() As Date      Get        Return m_DocDateStart      End Get      Set(ByVal Value As Date)        m_DocDateStart = Value      End Set    End Property

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
      CodeDescription.ListCodeDescriptionInComboBox(cmbPaymentType, "paymenti_entityType", True)
      cmbPaymentType.SelectedIndex = 0
      cmbOrderBy.Items.Clear()
      cmbOrderBy.Items.Add("วันที่เอกสารจ่าย")
      cmbOrderBy.Items.Add("เลขที่ใบสำคัญ")
      cmbOrderBy.SelectedIndex = 0

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

      Me.SupplierGroup = New SupplierGroup
      Me.SupplierStart = New Supplier
      Me.SupplierEnd = New Supplier

      Dim dtStart As Date = Date.Now.Subtract(New TimeSpan(7, 0, 0, 0))
      Me.DocDateStart = dtStart
      Me.txtDocDateStart.Text = MinDateToNull(Me.DocDateStart, "")
      Me.dtpDocDateStart.Value = Me.DocDateStart
      cmbOrderBy.SelectedIndex = 0
      Me.DocDateEnd = Date.Now
      Me.txtDocDateEnd.Text = MinDateToNull(Me.DocDateEnd, "")
      Me.dtpDocDateEnd.Value = Me.DocDateEnd
      Me.chkDetail.Checked = False
    End Sub
    Public Overrides Function GetFilterString() As String

    End Function
    Public Overrides Function GetFilterArray() As Filter()
      Dim arr(13) As Filter
      arr(0) = New Filter("DocDateStart", IIf(Me.DocDateStart.Equals(Date.MinValue), DBNull.Value, Me.DocDateStart))
      arr(1) = New Filter("DocDateEnd", IIf(Me.DocDateEnd.Equals(Date.MinValue), DBNull.Value, Me.DocDateEnd))
      arr(2) = New Filter("SuppliCodeStart", IIf(txtSuppliCodeStart.TextLength > 0, txtSuppliCodeStart.Text, DBNull.Value))
      arr(3) = New Filter("SuppliCodeEnd", IIf(txtSuppliCodeEnd.TextLength > 0, txtSuppliCodeEnd.Text, DBNull.Value))
      arr(4) = New Filter("sg_id", Me.ValidIdOrDBNull(m_sg))
      arr(5) = New Filter("IncludeChildSG", Me.chkIncludeSGChildren.Checked)
      arr(6) = New Filter("cc_id", Me.ValidIdOrDBNull(m_cc))
      arr(7) = New Filter("IncludeChildCC", Me.chkIncludeChildren.Checked)
      arr(8) = New Filter("PaymentType", CType(cmbPaymentType.SelectedItem, IdValuePair).Id)
      arr(9) = New Filter("userRight", CType(ServiceManager.Services.GetService(GetType(SecurityService)), SecurityService).CurrentUser.Id)
      arr(10) = New Filter("ShowDetail", IIf(Me.chkDetail.Checked, 1, 0))
      arr(11) = New Filter("OrderBy", Me.cmbOrderBy.SelectedIndex)
      arr(12) = New Filter("GLCodeprefix", IIf(txtGLCodeprefix.TextLength > 0, txtGLCodeprefix.Text, DBNull.Value))
      arr(13) = New Filter("RefDocCodePrefix", IIf(txtRefDocCodePrefix.TextLength > 0, txtRefDocCodePrefix.Text, DBNull.Value))

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

      'Payment Type
      dpi = New DocPrintingItem
      dpi.Mapping = "paymenttype"
      dpi.Value = CType(Me.cmbPaymentType.SelectedItem, IdValuePair).Value
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      'SupplierGroup
      dpi = New DocPrintingItem
      dpi.Mapping = "SupplierGroup"
      dpi.Value = Me.txtSupplierGroupName.Text
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      Return dpiColl
    End Function
#End Region

#Region " ChangeProperty "
    Private Sub EventWiring()
      AddHandler btnSuppliStartFind.Click, AddressOf Me.btnSupplierFind_Click
      AddHandler btnSuppliEndFind.Click, AddressOf Me.btnSupplierFind_Click

      AddHandler btnSupplierGroupStart.Click, AddressOf Me.btnSupplierGroupFind_Click
      AddHandler txtSupplierGroupStart.Validated, AddressOf Me.ChangeProperty

      AddHandler btnCCCodeStart.Click, AddressOf Me.btnCostcenterFind_Click
      AddHandler txtCCCodeStart.Validated, AddressOf Me.ChangeProperty

      AddHandler txtDocDateStart.Validated, AddressOf Me.ChangeProperty
      AddHandler txtDocDateEnd.Validated, AddressOf Me.ChangeProperty

      AddHandler dtpDocDateStart.ValueChanged, AddressOf Me.ChangeProperty
      AddHandler dtpDocDateEnd.ValueChanged, AddressOf Me.ChangeProperty
    End Sub

    Private m_dateSetting As Boolean
    Private Sub ChangeProperty(ByVal sender As Object, ByVal e As EventArgs)

      Select Case CType(sender, Control).Name.ToLower
        Case "txtcccodestart"
          Costcenter.GetCostCenter(txtCCCodeStart, Me.txtCostCenterName, m_cc, CType(ServiceManager.Services.GetService(GetType(SecurityService)), SecurityService).CurrentUser.Id)

        Case "txtsuppliergroupstart"
          SupplierGroup.GetSupplierGroup(txtSupplierGroupStart, Me.txtSupplierGroupName, m_sg)

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
    Private Sub btnSupplierFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
      Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      Select Case CType(sender, Control).Name.ToLower
        Case "btnsupplistartfind"
          myEntityPanelService.OpenListDialog(New Supplier, AddressOf SetSupplierStartDialog)

        Case "btnsuppliendfind"
          myEntityPanelService.OpenListDialog(New Supplier, AddressOf SetSupplierEndDialog)

      End Select
    End Sub
    ' Costcenter
    Private Sub btnCostcenterFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
      Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      Select Case CType(sender, Control).Name.ToLower
        Case "btncccodestart"
          myEntityPanelService.OpenTreeDialog(New CostCenter, AddressOf SetCCCodeStartDialog)
      End Select
    End Sub
    Private Sub btnSupplierGroupFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
      Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      Select Case CType(sender, Control).Name.ToLower
        Case "btnsuppliergroupstart"
          myEntityPanelService.OpenTreeDialog(New SupplierGroup, AddressOf SetSupplierGroupStartDialog)
      End Select
    End Sub
    Private Sub SetSupplierStartDialog(ByVal e As ISimpleEntity)
      Me.txtSuppliCodeStart.Text = e.Code
      Supplier.GetSupplier(txtSuppliCodeStart, txtTemp, Me.SupplierStart)
    End Sub
    Private Sub SetSupplierEndDialog(ByVal e As ISimpleEntity)
      Me.txtSuppliCodeEnd.Text = e.Code
      Supplier.GetSupplier(txtSuppliCodeEnd, txtTemp, Me.SupplierEnd)
    End Sub
    Private Sub SetSupplierGroupStartDialog(ByVal e As ISimpleEntity)
      Me.txtSupplierGroupStart.Text = e.Code
      SupplierGroup.GetSupplierGroup(txtSupplierGroupStart, txtSupplierGroupName, m_sg)
    End Sub
    Private Sub SetCCCodeStartDialog(ByVal e As ISimpleEntity)
      Me.txtCCCodeStart.Text = e.Code
      Costcenter.GetCostCenter(txtCCCodeStart, txtCostCenterName, m_cc, CType(ServiceManager.Services.GetService(GetType(SecurityService)), SecurityService).CurrentUser.Id)
    End Sub
#End Region

  End Class
End Namespace

