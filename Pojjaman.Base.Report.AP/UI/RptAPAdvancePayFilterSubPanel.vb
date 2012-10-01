Option Explicit On
Option Strict On
Imports Longkong.Pojjaman.BusinessLogic
Imports Longkong.Pojjaman.Services
Imports Longkong.Core.Services

Namespace Longkong.Pojjaman.Gui.Panels
  Public Class RptAPAdvancePayFilterSubPanel
    Inherits AbstractFilterSubPanel
    Implements IReportFilterSubPanel
    'Inherits UserControl

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
    Friend WithEvents txtSupplierGroupName As System.Windows.Forms.TextBox
    Friend WithEvents lblSupplierGroup As System.Windows.Forms.Label
    Friend WithEvents txtSupplierGroupStart As System.Windows.Forms.TextBox
    Friend WithEvents btnSupplierGroupStart As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents chkIncludeSGChildren As System.Windows.Forms.CheckBox
    Friend WithEvents cmbStatus As System.Windows.Forms.ComboBox
    Friend WithEvents chkDetail As System.Windows.Forms.CheckBox
    Friend WithEvents cmbAdvpayType As System.Windows.Forms.ComboBox
    Friend WithEvents lblAdvpayType As System.Windows.Forms.Label
    Friend WithEvents chkIncludeChildCC As System.Windows.Forms.CheckBox
    Friend WithEvents btnCCCodeStart As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents txtCCCodeStart As System.Windows.Forms.TextBox
    Friend WithEvents lblCCStart As System.Windows.Forms.Label
    Friend WithEvents txtCostCenterName As System.Windows.Forms.TextBox
    Friend WithEvents ibtnGLCodeEnd As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents txtGLCodeEnd As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents ibtnGLCodeStart As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents txtGLCodeStart As System.Windows.Forms.TextBox
    Friend WithEvents lblGLCode As System.Windows.Forms.Label
    Friend WithEvents ibtnDocCodeEnd As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents txtDocCodeEnd As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ibtnDocCodeStart As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents txtDocCodeStart As System.Windows.Forms.TextBox
    Friend WithEvents lblDocCode As System.Windows.Forms.Label
    Friend WithEvents btnAccountEndFind As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents txtAccountCodeEnd As System.Windows.Forms.TextBox
    Friend WithEvents lblAccountEnd As System.Windows.Forms.Label
    Friend WithEvents btnAccountStartFind As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents txtAccountCodeStart As System.Windows.Forms.TextBox
    Friend WithEvents lblAccountStart As System.Windows.Forms.Label
    Friend WithEvents lblStatus As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
      Me.components = New System.ComponentModel.Container()
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(RptAPAdvancePayFilterSubPanel))
      Me.grbMaster = New Longkong.Pojjaman.Gui.Components.FixedGroupBox()
      Me.txtTemp = New System.Windows.Forms.TextBox()
      Me.grbDetail = New Longkong.Pojjaman.Gui.Components.FixedGroupBox()
      Me.ibtnGLCodeEnd = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.txtGLCodeEnd = New System.Windows.Forms.TextBox()
      Me.Label3 = New System.Windows.Forms.Label()
      Me.ibtnGLCodeStart = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.txtGLCodeStart = New System.Windows.Forms.TextBox()
      Me.lblGLCode = New System.Windows.Forms.Label()
      Me.ibtnDocCodeEnd = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.txtDocCodeEnd = New System.Windows.Forms.TextBox()
      Me.Label1 = New System.Windows.Forms.Label()
      Me.ibtnDocCodeStart = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.txtDocCodeStart = New System.Windows.Forms.TextBox()
      Me.lblDocCode = New System.Windows.Forms.Label()
      Me.cmbStatus = New System.Windows.Forms.ComboBox()
      Me.chkIncludeChildCC = New System.Windows.Forms.CheckBox()
      Me.cmbAdvpayType = New System.Windows.Forms.ComboBox()
      Me.btnSearch = New System.Windows.Forms.Button()
      Me.btnReset = New System.Windows.Forms.Button()
      Me.btnCCCodeStart = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.lblAdvpayType = New System.Windows.Forms.Label()
      Me.txtCCCodeStart = New System.Windows.Forms.TextBox()
      Me.lblCCStart = New System.Windows.Forms.Label()
      Me.lblStatus = New System.Windows.Forms.Label()
      Me.txtCostCenterName = New System.Windows.Forms.TextBox()
      Me.txtSupplierGroupName = New System.Windows.Forms.TextBox()
      Me.lblSupplierGroup = New System.Windows.Forms.Label()
      Me.txtSupplierGroupStart = New System.Windows.Forms.TextBox()
      Me.btnSupplierGroupStart = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.chkDetail = New System.Windows.Forms.CheckBox()
      Me.chkIncludeSGChildren = New System.Windows.Forms.CheckBox()
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
      Me.Validator = New Longkong.Pojjaman.Gui.Components.PJMTextboxValidator(Me.components)
      Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
      Me.btnAccountEndFind = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.txtAccountCodeEnd = New System.Windows.Forms.TextBox()
      Me.lblAccountEnd = New System.Windows.Forms.Label()
      Me.btnAccountStartFind = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.txtAccountCodeStart = New System.Windows.Forms.TextBox()
      Me.lblAccountStart = New System.Windows.Forms.Label()
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
      Me.grbMaster.Controls.Add(Me.txtTemp)
      Me.grbMaster.Controls.Add(Me.grbDetail)
      Me.grbMaster.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.grbMaster.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.grbMaster.Location = New System.Drawing.Point(8, 8)
      Me.grbMaster.Name = "grbMaster"
      Me.grbMaster.Size = New System.Drawing.Size(629, 278)
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
      Me.txtTemp.Location = New System.Drawing.Point(504, 32)
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
      Me.grbDetail.Controls.Add(Me.btnAccountEndFind)
      Me.grbDetail.Controls.Add(Me.txtAccountCodeEnd)
      Me.grbDetail.Controls.Add(Me.lblAccountEnd)
      Me.grbDetail.Controls.Add(Me.btnAccountStartFind)
      Me.grbDetail.Controls.Add(Me.txtAccountCodeStart)
      Me.grbDetail.Controls.Add(Me.lblAccountStart)
      Me.grbDetail.Controls.Add(Me.ibtnGLCodeEnd)
      Me.grbDetail.Controls.Add(Me.txtGLCodeEnd)
      Me.grbDetail.Controls.Add(Me.Label3)
      Me.grbDetail.Controls.Add(Me.ibtnGLCodeStart)
      Me.grbDetail.Controls.Add(Me.txtGLCodeStart)
      Me.grbDetail.Controls.Add(Me.lblGLCode)
      Me.grbDetail.Controls.Add(Me.ibtnDocCodeEnd)
      Me.grbDetail.Controls.Add(Me.txtDocCodeEnd)
      Me.grbDetail.Controls.Add(Me.Label1)
      Me.grbDetail.Controls.Add(Me.ibtnDocCodeStart)
      Me.grbDetail.Controls.Add(Me.txtDocCodeStart)
      Me.grbDetail.Controls.Add(Me.lblDocCode)
      Me.grbDetail.Controls.Add(Me.cmbStatus)
      Me.grbDetail.Controls.Add(Me.chkIncludeChildCC)
      Me.grbDetail.Controls.Add(Me.cmbAdvpayType)
      Me.grbDetail.Controls.Add(Me.btnSearch)
      Me.grbDetail.Controls.Add(Me.btnReset)
      Me.grbDetail.Controls.Add(Me.btnCCCodeStart)
      Me.grbDetail.Controls.Add(Me.lblAdvpayType)
      Me.grbDetail.Controls.Add(Me.txtCCCodeStart)
      Me.grbDetail.Controls.Add(Me.lblCCStart)
      Me.grbDetail.Controls.Add(Me.lblStatus)
      Me.grbDetail.Controls.Add(Me.txtCostCenterName)
      Me.grbDetail.Controls.Add(Me.txtSupplierGroupName)
      Me.grbDetail.Controls.Add(Me.lblSupplierGroup)
      Me.grbDetail.Controls.Add(Me.txtSupplierGroupStart)
      Me.grbDetail.Controls.Add(Me.btnSupplierGroupStart)
      Me.grbDetail.Controls.Add(Me.chkDetail)
      Me.grbDetail.Controls.Add(Me.chkIncludeSGChildren)
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
      Me.grbDetail.Size = New System.Drawing.Size(602, 256)
      Me.grbDetail.TabIndex = 0
      Me.grbDetail.TabStop = False
      Me.grbDetail.Text = "ข้อมูลทั่วไป"
      '
      'ibtnGLCodeEnd
      '
      Me.ibtnGLCodeEnd.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.ibtnGLCodeEnd.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.ibtnGLCodeEnd.ForeColor = System.Drawing.SystemColors.Control
      Me.ibtnGLCodeEnd.Location = New System.Drawing.Point(392, 111)
      Me.ibtnGLCodeEnd.Name = "ibtnGLCodeEnd"
      Me.ibtnGLCodeEnd.Size = New System.Drawing.Size(24, 22)
      Me.ibtnGLCodeEnd.TabIndex = 75
      Me.ibtnGLCodeEnd.TabStop = False
      Me.ibtnGLCodeEnd.ThemedImage = CType(resources.GetObject("ibtnGLCodeEnd.ThemedImage"), System.Drawing.Bitmap)
      '
      'txtGLCodeEnd
      '
      Me.Validator.SetDataType(Me.txtGLCodeEnd, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtGLCodeEnd, "")
      Me.txtGLCodeEnd.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtGLCodeEnd, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtGLCodeEnd, -15)
      Me.Validator.SetInvalidBackColor(Me.txtGLCodeEnd, System.Drawing.Color.Empty)
      Me.txtGLCodeEnd.Location = New System.Drawing.Point(296, 111)
      Me.Validator.SetMinValue(Me.txtGLCodeEnd, "")
      Me.txtGLCodeEnd.Name = "txtGLCodeEnd"
      Me.Validator.SetRegularExpression(Me.txtGLCodeEnd, "")
      Me.Validator.SetRequired(Me.txtGLCodeEnd, False)
      Me.txtGLCodeEnd.Size = New System.Drawing.Size(96, 21)
      Me.txtGLCodeEnd.TabIndex = 71
      '
      'Label3
      '
      Me.Label3.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Label3.ForeColor = System.Drawing.Color.Black
      Me.Label3.Location = New System.Drawing.Point(264, 111)
      Me.Label3.Name = "Label3"
      Me.Label3.Size = New System.Drawing.Size(24, 18)
      Me.Label3.TabIndex = 74
      Me.Label3.Text = "ถึง"
      Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
      '
      'ibtnGLCodeStart
      '
      Me.ibtnGLCodeStart.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.ibtnGLCodeStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.ibtnGLCodeStart.ForeColor = System.Drawing.SystemColors.Control
      Me.ibtnGLCodeStart.Location = New System.Drawing.Point(232, 111)
      Me.ibtnGLCodeStart.Name = "ibtnGLCodeStart"
      Me.ibtnGLCodeStart.Size = New System.Drawing.Size(24, 22)
      Me.ibtnGLCodeStart.TabIndex = 73
      Me.ibtnGLCodeStart.TabStop = False
      Me.ibtnGLCodeStart.ThemedImage = CType(resources.GetObject("ibtnGLCodeStart.ThemedImage"), System.Drawing.Bitmap)
      '
      'txtGLCodeStart
      '
      Me.Validator.SetDataType(Me.txtGLCodeStart, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtGLCodeStart, "")
      Me.txtGLCodeStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtGLCodeStart, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtGLCodeStart, -15)
      Me.Validator.SetInvalidBackColor(Me.txtGLCodeStart, System.Drawing.Color.Empty)
      Me.txtGLCodeStart.Location = New System.Drawing.Point(136, 111)
      Me.Validator.SetMinValue(Me.txtGLCodeStart, "")
      Me.txtGLCodeStart.Name = "txtGLCodeStart"
      Me.Validator.SetRegularExpression(Me.txtGLCodeStart, "")
      Me.Validator.SetRequired(Me.txtGLCodeStart, False)
      Me.txtGLCodeStart.Size = New System.Drawing.Size(96, 21)
      Me.txtGLCodeStart.TabIndex = 70
      '
      'lblGLCode
      '
      Me.lblGLCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblGLCode.ForeColor = System.Drawing.Color.Black
      Me.lblGLCode.Location = New System.Drawing.Point(16, 113)
      Me.lblGLCode.Name = "lblGLCode"
      Me.lblGLCode.Size = New System.Drawing.Size(112, 18)
      Me.lblGLCode.TabIndex = 72
      Me.lblGLCode.Text = "เลขที่GL:"
      Me.lblGLCode.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'ibtnDocCodeEnd
      '
      Me.ibtnDocCodeEnd.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.ibtnDocCodeEnd.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.ibtnDocCodeEnd.ForeColor = System.Drawing.SystemColors.Control
      Me.ibtnDocCodeEnd.Location = New System.Drawing.Point(392, 87)
      Me.ibtnDocCodeEnd.Name = "ibtnDocCodeEnd"
      Me.ibtnDocCodeEnd.Size = New System.Drawing.Size(24, 22)
      Me.ibtnDocCodeEnd.TabIndex = 69
      Me.ibtnDocCodeEnd.TabStop = False
      Me.ibtnDocCodeEnd.ThemedImage = CType(resources.GetObject("ibtnDocCodeEnd.ThemedImage"), System.Drawing.Bitmap)
      '
      'txtDocCodeEnd
      '
      Me.Validator.SetDataType(Me.txtDocCodeEnd, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtDocCodeEnd, "")
      Me.txtDocCodeEnd.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtDocCodeEnd, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtDocCodeEnd, -15)
      Me.Validator.SetInvalidBackColor(Me.txtDocCodeEnd, System.Drawing.Color.Empty)
      Me.txtDocCodeEnd.Location = New System.Drawing.Point(296, 87)
      Me.Validator.SetMinValue(Me.txtDocCodeEnd, "")
      Me.txtDocCodeEnd.Name = "txtDocCodeEnd"
      Me.Validator.SetRegularExpression(Me.txtDocCodeEnd, "")
      Me.Validator.SetRequired(Me.txtDocCodeEnd, False)
      Me.txtDocCodeEnd.Size = New System.Drawing.Size(96, 21)
      Me.txtDocCodeEnd.TabIndex = 65
      '
      'Label1
      '
      Me.Label1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Label1.ForeColor = System.Drawing.Color.Black
      Me.Label1.Location = New System.Drawing.Point(264, 87)
      Me.Label1.Name = "Label1"
      Me.Label1.Size = New System.Drawing.Size(24, 18)
      Me.Label1.TabIndex = 68
      Me.Label1.Text = "ถึง"
      Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
      '
      'ibtnDocCodeStart
      '
      Me.ibtnDocCodeStart.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.ibtnDocCodeStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.ibtnDocCodeStart.ForeColor = System.Drawing.SystemColors.Control
      Me.ibtnDocCodeStart.Location = New System.Drawing.Point(232, 87)
      Me.ibtnDocCodeStart.Name = "ibtnDocCodeStart"
      Me.ibtnDocCodeStart.Size = New System.Drawing.Size(24, 22)
      Me.ibtnDocCodeStart.TabIndex = 67
      Me.ibtnDocCodeStart.TabStop = False
      Me.ibtnDocCodeStart.ThemedImage = CType(resources.GetObject("ibtnDocCodeStart.ThemedImage"), System.Drawing.Bitmap)
      '
      'txtDocCodeStart
      '
      Me.Validator.SetDataType(Me.txtDocCodeStart, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtDocCodeStart, "")
      Me.txtDocCodeStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtDocCodeStart, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtDocCodeStart, -15)
      Me.Validator.SetInvalidBackColor(Me.txtDocCodeStart, System.Drawing.Color.Empty)
      Me.txtDocCodeStart.Location = New System.Drawing.Point(136, 87)
      Me.Validator.SetMinValue(Me.txtDocCodeStart, "")
      Me.txtDocCodeStart.Name = "txtDocCodeStart"
      Me.Validator.SetRegularExpression(Me.txtDocCodeStart, "")
      Me.Validator.SetRequired(Me.txtDocCodeStart, False)
      Me.txtDocCodeStart.Size = New System.Drawing.Size(96, 21)
      Me.txtDocCodeStart.TabIndex = 64
      '
      'lblDocCode
      '
      Me.lblDocCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblDocCode.ForeColor = System.Drawing.Color.Black
      Me.lblDocCode.Location = New System.Drawing.Point(16, 89)
      Me.lblDocCode.Name = "lblDocCode"
      Me.lblDocCode.Size = New System.Drawing.Size(112, 18)
      Me.lblDocCode.TabIndex = 66
      Me.lblDocCode.Text = "เลขที่เอกสาร:"
      Me.lblDocCode.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'cmbStatus
      '
      Me.cmbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbStatus.Location = New System.Drawing.Point(135, 161)
      Me.cmbStatus.Name = "cmbStatus"
      Me.cmbStatus.Size = New System.Drawing.Size(120, 21)
      Me.cmbStatus.TabIndex = 7
      '
      'chkIncludeChildCC
      '
      Me.chkIncludeChildCC.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.chkIncludeChildCC.Location = New System.Drawing.Point(419, 145)
      Me.chkIncludeChildCC.Name = "chkIncludeChildCC"
      Me.chkIncludeChildCC.Size = New System.Drawing.Size(128, 21)
      Me.chkIncludeChildCC.TabIndex = 38
      Me.chkIncludeChildCC.Text = "รวม Cost Center ลูก"
      '
      'cmbAdvpayType
      '
      Me.cmbAdvpayType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbAdvpayType.Location = New System.Drawing.Point(296, 161)
      Me.cmbAdvpayType.Name = "cmbAdvpayType"
      Me.cmbAdvpayType.Size = New System.Drawing.Size(120, 21)
      Me.cmbAdvpayType.TabIndex = 62
      '
      'btnSearch
      '
      Me.btnSearch.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnSearch.Location = New System.Drawing.Point(521, 229)
      Me.btnSearch.Name = "btnSearch"
      Me.btnSearch.Size = New System.Drawing.Size(75, 23)
      Me.btnSearch.TabIndex = 2
      Me.btnSearch.Text = "ค้นหา"
      '
      'btnReset
      '
      Me.btnReset.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnReset.Location = New System.Drawing.Point(441, 229)
      Me.btnReset.Name = "btnReset"
      Me.btnReset.Size = New System.Drawing.Size(75, 23)
      Me.btnReset.TabIndex = 1
      Me.btnReset.TabStop = False
      Me.btnReset.Text = "เคลียร์"
      '
      'btnCCCodeStart
      '
      Me.btnCCCodeStart.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnCCCodeStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.btnCCCodeStart.ForeColor = System.Drawing.SystemColors.Control
      Me.btnCCCodeStart.Location = New System.Drawing.Point(232, 135)
      Me.btnCCCodeStart.Name = "btnCCCodeStart"
      Me.btnCCCodeStart.Size = New System.Drawing.Size(24, 22)
      Me.btnCCCodeStart.TabIndex = 35
      Me.btnCCCodeStart.TabStop = False
      Me.btnCCCodeStart.ThemedImage = CType(resources.GetObject("btnCCCodeStart.ThemedImage"), System.Drawing.Bitmap)
      '
      'lblAdvpayType
      '
      Me.lblAdvpayType.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblAdvpayType.ForeColor = System.Drawing.Color.Black
      Me.lblAdvpayType.Location = New System.Drawing.Point(254, 161)
      Me.lblAdvpayType.Name = "lblAdvpayType"
      Me.lblAdvpayType.Size = New System.Drawing.Size(44, 18)
      Me.lblAdvpayType.TabIndex = 63
      Me.lblAdvpayType.Text = "Type:"
      Me.lblAdvpayType.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'txtCCCodeStart
      '
      Me.Validator.SetDataType(Me.txtCCCodeStart, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtCCCodeStart, "")
      Me.txtCCCodeStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtCCCodeStart, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtCCCodeStart, -15)
      Me.Validator.SetInvalidBackColor(Me.txtCCCodeStart, System.Drawing.Color.Empty)
      Me.txtCCCodeStart.Location = New System.Drawing.Point(136, 135)
      Me.txtCCCodeStart.MaxLength = 50
      Me.Validator.SetMinValue(Me.txtCCCodeStart, "")
      Me.txtCCCodeStart.Name = "txtCCCodeStart"
      Me.Validator.SetRegularExpression(Me.txtCCCodeStart, "")
      Me.Validator.SetRequired(Me.txtCCCodeStart, False)
      Me.txtCCCodeStart.Size = New System.Drawing.Size(96, 21)
      Me.txtCCCodeStart.TabIndex = 34
      '
      'lblCCStart
      '
      Me.lblCCStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblCCStart.ForeColor = System.Drawing.Color.Black
      Me.lblCCStart.Location = New System.Drawing.Point(40, 135)
      Me.lblCCStart.Name = "lblCCStart"
      Me.lblCCStart.Size = New System.Drawing.Size(88, 18)
      Me.lblCCStart.TabIndex = 36
      Me.lblCCStart.Text = "Cost Center"
      Me.lblCCStart.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblStatus
      '
      Me.lblStatus.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblStatus.ForeColor = System.Drawing.Color.Black
      Me.lblStatus.Location = New System.Drawing.Point(31, 161)
      Me.lblStatus.Name = "lblStatus"
      Me.lblStatus.Size = New System.Drawing.Size(96, 18)
      Me.lblStatus.TabIndex = 61
      Me.lblStatus.Text = "Status:"
      Me.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'txtCostCenterName
      '
      Me.Validator.SetDataType(Me.txtCostCenterName, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtCostCenterName, "")
      Me.txtCostCenterName.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtCostCenterName, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtCostCenterName, -15)
      Me.Validator.SetInvalidBackColor(Me.txtCostCenterName, System.Drawing.Color.Empty)
      Me.txtCostCenterName.Location = New System.Drawing.Point(256, 135)
      Me.txtCostCenterName.MaxLength = 50
      Me.Validator.SetMinValue(Me.txtCostCenterName, "")
      Me.txtCostCenterName.Name = "txtCostCenterName"
      Me.txtCostCenterName.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtCostCenterName, "")
      Me.Validator.SetRequired(Me.txtCostCenterName, False)
      Me.txtCostCenterName.Size = New System.Drawing.Size(160, 21)
      Me.txtCostCenterName.TabIndex = 37
      '
      'txtSupplierGroupName
      '
      Me.Validator.SetDataType(Me.txtSupplierGroupName, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtSupplierGroupName, "")
      Me.txtSupplierGroupName.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtSupplierGroupName, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtSupplierGroupName, -15)
      Me.Validator.SetInvalidBackColor(Me.txtSupplierGroupName, System.Drawing.Color.Empty)
      Me.txtSupplierGroupName.Location = New System.Drawing.Point(256, 40)
      Me.txtSupplierGroupName.MaxLength = 50
      Me.Validator.SetMinValue(Me.txtSupplierGroupName, "")
      Me.txtSupplierGroupName.Name = "txtSupplierGroupName"
      Me.txtSupplierGroupName.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtSupplierGroupName, "")
      Me.Validator.SetRequired(Me.txtSupplierGroupName, False)
      Me.txtSupplierGroupName.Size = New System.Drawing.Size(160, 21)
      Me.txtSupplierGroupName.TabIndex = 56
      '
      'lblSupplierGroup
      '
      Me.lblSupplierGroup.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblSupplierGroup.ForeColor = System.Drawing.Color.Black
      Me.lblSupplierGroup.Location = New System.Drawing.Point(40, 40)
      Me.lblSupplierGroup.Name = "lblSupplierGroup"
      Me.lblSupplierGroup.Size = New System.Drawing.Size(88, 18)
      Me.lblSupplierGroup.TabIndex = 55
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
      Me.txtSupplierGroupStart.Location = New System.Drawing.Point(136, 40)
      Me.txtSupplierGroupStart.MaxLength = 50
      Me.Validator.SetMinValue(Me.txtSupplierGroupStart, "")
      Me.txtSupplierGroupStart.Name = "txtSupplierGroupStart"
      Me.Validator.SetRegularExpression(Me.txtSupplierGroupStart, "")
      Me.Validator.SetRequired(Me.txtSupplierGroupStart, False)
      Me.txtSupplierGroupStart.Size = New System.Drawing.Size(96, 21)
      Me.txtSupplierGroupStart.TabIndex = 2
      '
      'btnSupplierGroupStart
      '
      Me.btnSupplierGroupStart.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnSupplierGroupStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.btnSupplierGroupStart.ForeColor = System.Drawing.SystemColors.Control
      Me.btnSupplierGroupStart.Location = New System.Drawing.Point(232, 40)
      Me.btnSupplierGroupStart.Name = "btnSupplierGroupStart"
      Me.btnSupplierGroupStart.Size = New System.Drawing.Size(24, 22)
      Me.btnSupplierGroupStart.TabIndex = 58
      Me.btnSupplierGroupStart.TabStop = False
      Me.btnSupplierGroupStart.ThemedImage = CType(resources.GetObject("btnSupplierGroupStart.ThemedImage"), System.Drawing.Bitmap)
      '
      'chkDetail
      '
      Me.chkDetail.Checked = True
      Me.chkDetail.CheckState = System.Windows.Forms.CheckState.Checked
      Me.chkDetail.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.chkDetail.Location = New System.Drawing.Point(136, 184)
      Me.chkDetail.Name = "chkDetail"
      Me.chkDetail.Size = New System.Drawing.Size(128, 18)
      Me.chkDetail.TabIndex = 59
      Me.chkDetail.Text = "แสดงรายละเอียด"
      '
      'chkIncludeSGChildren
      '
      Me.chkIncludeSGChildren.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.chkIncludeSGChildren.Location = New System.Drawing.Point(418, 40)
      Me.chkIncludeSGChildren.Name = "chkIncludeSGChildren"
      Me.chkIncludeSGChildren.Size = New System.Drawing.Size(128, 21)
      Me.chkIncludeSGChildren.TabIndex = 59
      Me.chkIncludeSGChildren.Text = "รวมกลุ่มผู้ขายลูก"
      '
      'btnSuppliEndFind
      '
      Me.btnSuppliEndFind.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnSuppliEndFind.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.btnSuppliEndFind.ForeColor = System.Drawing.SystemColors.Control
      Me.btnSuppliEndFind.Location = New System.Drawing.Point(392, 63)
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
      Me.txtSuppliCodeEnd.Location = New System.Drawing.Point(296, 63)
      Me.Validator.SetMinValue(Me.txtSuppliCodeEnd, "")
      Me.txtSuppliCodeEnd.Name = "txtSuppliCodeEnd"
      Me.Validator.SetRegularExpression(Me.txtSuppliCodeEnd, "")
      Me.Validator.SetRequired(Me.txtSuppliCodeEnd, False)
      Me.txtSuppliCodeEnd.Size = New System.Drawing.Size(96, 21)
      Me.txtSuppliCodeEnd.TabIndex = 4
      '
      'lblSuppliEnd
      '
      Me.lblSuppliEnd.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblSuppliEnd.ForeColor = System.Drawing.Color.Black
      Me.lblSuppliEnd.Location = New System.Drawing.Point(264, 63)
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
      Me.btnSuppliStartFind.Location = New System.Drawing.Point(232, 63)
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
      Me.txtSuppliCodeStart.Location = New System.Drawing.Point(136, 63)
      Me.Validator.SetMinValue(Me.txtSuppliCodeStart, "")
      Me.txtSuppliCodeStart.Name = "txtSuppliCodeStart"
      Me.Validator.SetRegularExpression(Me.txtSuppliCodeStart, "")
      Me.Validator.SetRequired(Me.txtSuppliCodeStart, False)
      Me.txtSuppliCodeStart.Size = New System.Drawing.Size(96, 21)
      Me.txtSuppliCodeStart.TabIndex = 3
      '
      'lblSuppliStart
      '
      Me.lblSuppliStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblSuppliStart.ForeColor = System.Drawing.Color.Black
      Me.lblSuppliStart.Location = New System.Drawing.Point(16, 65)
      Me.lblSuppliStart.Name = "lblSuppliStart"
      Me.lblSuppliStart.Size = New System.Drawing.Size(112, 18)
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
      Me.txtDocDateEnd.Location = New System.Drawing.Point(296, 16)
      Me.txtDocDateEnd.MaxLength = 10
      Me.Validator.SetMinValue(Me.txtDocDateEnd, "")
      Me.txtDocDateEnd.Name = "txtDocDateEnd"
      Me.Validator.SetRegularExpression(Me.txtDocDateEnd, "")
      Me.Validator.SetRequired(Me.txtDocDateEnd, False)
      Me.txtDocDateEnd.Size = New System.Drawing.Size(85, 21)
      Me.txtDocDateEnd.TabIndex = 1
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
      Me.txtDocDateStart.Size = New System.Drawing.Size(84, 21)
      Me.txtDocDateStart.TabIndex = 0
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
      'dtpDocDateEnd
      '
      Me.dtpDocDateEnd.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
      Me.dtpDocDateEnd.Location = New System.Drawing.Point(296, 16)
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
      Me.lblDocDateStart.Size = New System.Drawing.Size(112, 18)
      Me.lblDocDateStart.TabIndex = 0
      Me.lblDocDateStart.Text = "ตั้งแต่"
      Me.lblDocDateStart.TextAlign = System.Drawing.ContentAlignment.MiddleRight
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
      'btnAccountEndFind
      '
      Me.btnAccountEndFind.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnAccountEndFind.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.btnAccountEndFind.ForeColor = System.Drawing.SystemColors.Control
      Me.btnAccountEndFind.Location = New System.Drawing.Point(392, 203)
      Me.btnAccountEndFind.Name = "btnAccountEndFind"
      Me.btnAccountEndFind.Size = New System.Drawing.Size(24, 22)
      Me.btnAccountEndFind.TabIndex = 79
      Me.btnAccountEndFind.TabStop = False
      Me.btnAccountEndFind.ThemedImage = CType(resources.GetObject("btnAccountEndFind.ThemedImage"), System.Drawing.Bitmap)
      '
      'txtAccountCodeEnd
      '
      Me.Validator.SetDataType(Me.txtAccountCodeEnd, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtAccountCodeEnd, "")
      Me.txtAccountCodeEnd.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtAccountCodeEnd, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtAccountCodeEnd, -15)
      Me.Validator.SetInvalidBackColor(Me.txtAccountCodeEnd, System.Drawing.Color.Empty)
      Me.txtAccountCodeEnd.Location = New System.Drawing.Point(296, 203)
      Me.Validator.SetMinValue(Me.txtAccountCodeEnd, "")
      Me.txtAccountCodeEnd.Name = "txtAccountCodeEnd"
      Me.Validator.SetRegularExpression(Me.txtAccountCodeEnd, "")
      Me.Validator.SetRequired(Me.txtAccountCodeEnd, False)
      Me.txtAccountCodeEnd.Size = New System.Drawing.Size(96, 21)
      Me.txtAccountCodeEnd.TabIndex = 77
      '
      'lblAccountEnd
      '
      Me.lblAccountEnd.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblAccountEnd.ForeColor = System.Drawing.Color.Black
      Me.lblAccountEnd.Location = New System.Drawing.Point(264, 203)
      Me.lblAccountEnd.Name = "lblAccountEnd"
      Me.lblAccountEnd.Size = New System.Drawing.Size(24, 18)
      Me.lblAccountEnd.TabIndex = 81
      Me.lblAccountEnd.Text = "ถึง"
      Me.lblAccountEnd.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
      '
      'btnAccountStartFind
      '
      Me.btnAccountStartFind.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnAccountStartFind.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.btnAccountStartFind.ForeColor = System.Drawing.SystemColors.Control
      Me.btnAccountStartFind.Location = New System.Drawing.Point(232, 203)
      Me.btnAccountStartFind.Name = "btnAccountStartFind"
      Me.btnAccountStartFind.Size = New System.Drawing.Size(24, 22)
      Me.btnAccountStartFind.TabIndex = 78
      Me.btnAccountStartFind.TabStop = False
      Me.btnAccountStartFind.ThemedImage = CType(resources.GetObject("btnAccountStartFind.ThemedImage"), System.Drawing.Bitmap)
      '
      'txtAccountCodeStart
      '
      Me.Validator.SetDataType(Me.txtAccountCodeStart, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtAccountCodeStart, "")
      Me.txtAccountCodeStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtAccountCodeStart, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtAccountCodeStart, -15)
      Me.Validator.SetInvalidBackColor(Me.txtAccountCodeStart, System.Drawing.Color.Empty)
      Me.txtAccountCodeStart.Location = New System.Drawing.Point(136, 203)
      Me.Validator.SetMinValue(Me.txtAccountCodeStart, "")
      Me.txtAccountCodeStart.Name = "txtAccountCodeStart"
      Me.Validator.SetRegularExpression(Me.txtAccountCodeStart, "")
      Me.Validator.SetRequired(Me.txtAccountCodeStart, False)
      Me.txtAccountCodeStart.Size = New System.Drawing.Size(96, 21)
      Me.txtAccountCodeStart.TabIndex = 76
      '
      'lblAccountStart
      '
      Me.lblAccountStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblAccountStart.ForeColor = System.Drawing.Color.Black
      Me.lblAccountStart.Location = New System.Drawing.Point(40, 203)
      Me.lblAccountStart.Name = "lblAccountStart"
      Me.lblAccountStart.Size = New System.Drawing.Size(88, 18)
      Me.lblAccountStart.TabIndex = 80
      Me.lblAccountStart.Text = "ตั้งแต่สมุดรายวัน"
      Me.lblAccountStart.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'RptAPAdvancePayFilterSubPanel
      '
      Me.Controls.Add(Me.grbMaster)
      Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Name = "RptAPAdvancePayFilterSubPanel"
      Me.Size = New System.Drawing.Size(652, 294)
      Me.grbMaster.ResumeLayout(False)
      Me.grbMaster.PerformLayout()
      Me.grbDetail.ResumeLayout(False)
      Me.grbDetail.PerformLayout()
      CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
      Me.ResumeLayout(False)

    End Sub

#End Region

#Region " SetLabelText "
    Public Sub SetLabelText()
      'If Not m_entity Is Nothing Then Me.Text = Me.StringParserService.Parse(Me.m_entity.TabPageText)
      Me.lblSuppliStart.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptAPAdvancePayFilterSubPanel.lblSuppliStart}")
      Me.Validator.SetDisplayName(txtSuppliCodeStart, lblSuppliStart.Text)

      'SupplierGroup
      Me.lblSupplierGroup.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptAPAdvancePayFilterSubPanel.lblSupplierGroup}")
      Me.Validator.SetDisplayName(txtSupplierGroupStart, lblSupplierGroup.Text)
      Me.chkIncludeSGChildren.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptAPAdvancePayFilterSubPanel.chkIncludeSGChildren}")

      Me.lblCCStart.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptRetentionFilterSubPanel.lblCCStart}")
      Me.Validator.SetDisplayName(txtCCCodeStart, lblCCStart.Text)

      Me.lblDocDateStart.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptAPAdvancePayFilterSubPanel.lblDocDateStart}")
      Me.Validator.SetDisplayName(txtDocDateStart, lblDocDateStart.Text)

      ' Global {ถึง}
      Me.lblSuppliEnd.Text = Me.StringParserService.Parse("${res:Global.FilterPanelTo}")
      Me.Validator.SetDisplayName(txtSuppliCodeStart, lblSuppliStart.Text)

      Me.lblDocDateEnd.Text = Me.StringParserService.Parse("${res:Global.FilterPanelTo}")
      Me.Validator.SetDisplayName(txtDocDateEnd, lblDocDateEnd.Text)
      ' Button
      Me.btnSearch.Text = Me.StringParserService.Parse("${res:Global.SearchButtonText}")
      Me.btnReset.Text = Me.StringParserService.Parse("${res:Global.ResetButtonText}")

      ' GroupBox
      Me.grbMaster.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptAPAdvancePayFilterSubPanel.grbMaster}")
      Me.grbDetail.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptAPAdvancePayFilterSubPanel.grbDetail}")
      Me.lblStatus.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptAPAdvancePayFilterSubPanel.lblStatus}")

            Me.chkDetail.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptAPAdvancePayFilterSubPanel.chkDetail}")
            Me.lblDocCode.Text = Me.StringParserService.Parse("${res:Global.CodeText}")
            Me.lblGLCode.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptAPAdvancePayFilterSubPanel.lblGLCode}")
            ' Global {ถึง}
            Me.Label3.Text = Me.StringParserService.Parse("${res:Global.FilterPanelTo}")
            Me.Label1.Text = Me.StringParserService.Parse("${res:Global.FilterPanelTo}")
            Me.lblAccountEnd.Text = Me.StringParserService.Parse("${res:Global.FilterPanelTo}")

            Me.chkIncludeChildCC.Text = Me.StringParserService.Parse("${res:Global.chkIncludeChildren}")
            Me.lblAccountStart.Text = Me.StringParserService.Parse("${res:Global.AccountBookStart}")




    End Sub
#End Region

#Region "Member"
    Private m_supplier As Supplier
    Private m_advancepay As AdvancePay
    Private m_journalentry As JournalEntry
    Private m_sg As SupplierGroup

    Private m_cc As Costcenter

    Private m_DocDateEnd As Date
    Private m_DocDateStart As Date
    Private m_AccountBookStart As AccountBook
    Private m_AccountBookEnd As AccountBook
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
    Public Property Advancepay() As AdvancePay
      Get
        Return m_advancepay
      End Get
      Set(ByVal value As AdvancePay)
        m_advancepay = value
      End Set
    End Property
    Public Property JournalEntry() As JournalEntry
      Get
        Return m_journalentry
      End Get
      Set(ByVal value As JournalEntry)
        m_journalentry = value
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
    Public Property Costcenter() As Costcenter
      Get
        Return m_cc
      End Get
      Set(ByVal Value As Costcenter)
        m_cc = Value
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

    Public Property AccountBookStart() As AccountBook
      Get
        Return m_AccountBookStart
      End Get
      Set(ByVal Value As AccountBook)
        m_AccountBookStart = Value
      End Set
    End Property
    Public Property AccountBookEnd() As AccountBook
      Get
        Return m_AccountBookEnd
      End Get
      Set(ByVal Value As AccountBook)
        m_AccountBookEnd = Value
      End Set
    End Property
#End Region

#Region "Methods"

    Private Sub Initialize()
      ClearCriterias()
      With Me.cmbStatus
        .Items.Clear()
        .Items.Add(Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptAPAdvancePayFilterSubPanel.CurrentUseStatus}"))
        .Items.Add(Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptAPAdvancePayFilterSubPanel.CanceledStatus}"))
        .Items.Add(Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptAPAdvancePayFilterSubPanel.NotSpecifiedStatus}"))
        .SelectedIndex = 0
      End With
      With Me.cmbAdvpayType
        .Items.Clear()
        '.Items.Add(Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptAPAdvancePayFilterSubPanel.CurrentUseStatus}"))
        '.Items.Add(Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptAPAdvancePayFilterSubPanel.CanceledStatus}"))
        '.Items.Add(Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptAPAdvancePayFilterSubPanel.NotSpecifiedStatus}"))
        'Hack ก่อนนะ
        .Items.Add("เฉพาะ AP")
        .Items.Add("เฉพาะ SC")
        .Items.Add("ทั้งหมด")
        .SelectedIndex = 2
      End With
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
      Me.SupplierGroup = New SupplierGroup

      Me.Costcenter = New CostCenter

      Me.AccountBookStart = New AccountBook
      Me.AccountBookEnd = New AccountBook

      Dim dtStart As Date = Date.Now.Subtract(New TimeSpan(7, 0, 0, 0))
      Me.DocDateStart = dtStart
      Me.txtDocDateStart.Text = MinDateToNull(Me.DocDateStart, "")
      Me.dtpDocDateStart.Value = Me.DocDateStart

      Me.DocDateEnd = Date.Now
      Me.txtDocDateEnd.Text = MinDateToNull(Me.DocDateEnd, "")
      Me.dtpDocDateEnd.Value = Me.DocDateEnd
      If cmbStatus.Items.Count > 0 Then
        cmbStatus.SelectedIndex = 0
      End If
    End Sub
    Public Overrides Function GetFilterString() As String

    End Function
    Public Overrides Function GetFilterArray() As Filter()
      Dim arr(18) As Filter
      arr(0) = New Filter("DocDateStart", IIf(Me.DocDateStart.Equals(Date.MinValue), DBNull.Value, Me.DocDateStart))
      arr(1) = New Filter("DocDateEnd", IIf(Me.DocDateEnd.Equals(Date.MinValue), DBNull.Value, Me.DocDateEnd))
      arr(2) = New Filter("SuppliCodeStart", IIf(txtSuppliCodeStart.TextLength > 0, txtSuppliCodeStart.Text, DBNull.Value))
      arr(3) = New Filter("SuppliCodeEnd", IIf(txtSuppliCodeEnd.TextLength > 0, txtSuppliCodeEnd.Text, DBNull.Value))
      arr(4) = New Filter("sg_id", Me.ValidIdOrDBNull(m_sg))
      arr(5) = New Filter("IncludeChildSG", Me.chkIncludeSGChildren.Checked)
      arr(6) = New Filter("CCId", Me.ValidIdOrDBNull(m_cc))
      arr(7) = New Filter("ChildCCIncluded", Me.chkIncludeChildCC.Checked)
      arr(8) = New Filter("userRight", CType(ServiceManager.Services.GetService(GetType(SecurityService)), SecurityService).CurrentUser.Id)
      arr(9) = New Filter("Canceled", cmbStatus.SelectedIndex)
      arr(10) = New Filter("ShowDetail", IIf(chkDetail.Checked, 1, 0))
      arr(11) = New Filter("AdvancePayType", cmbAdvpayType.SelectedIndex)
      arr(12) = New Filter("CCcode", Me.ValidCodeOrDBNull(m_cc))
      arr(13) = New Filter("DocCodeStart", IIf(txtDocCodeStart.TextLength > 0, txtDocCodeStart.Text, DBNull.Value))
      arr(14) = New Filter("DocCodeEnd", IIf(txtDocCodeEnd.TextLength > 0, txtDocCodeEnd.Text, DBNull.Value))
      arr(15) = New Filter("GLCodeStart", IIf(txtGLCodeStart.TextLength > 0, txtGLCodeStart.Text, DBNull.Value))
      arr(16) = New Filter("GLCodeEnd", IIf(txtGLCodeEnd.TextLength > 0, txtGLCodeEnd.Text, DBNull.Value))
      arr(17) = New Filter("accountbookfrom", IIf(txtAccountCodeStart.TextLength > 0, txtAccountCodeStart.Text, DBNull.Value))
      arr(18) = New Filter("accountbookend", IIf(txtAccountCodeEnd.TextLength > 0, txtAccountCodeEnd.Text, DBNull.Value))
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

      'SupplierGroup
      dpi = New DocPrintingItem
      dpi.Mapping = "SupplierGroup"
      dpi.Value = Me.txtSupplierGroupName.Text
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      'CostCenterStart
      dpi = New DocPrintingItem
      dpi.Mapping = "CostCenterStart"
      dpi.Value = Me.txtCostCenterName.Text
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      'CheckBox ChildCostCenterInclude
      If Me.chkIncludeChildCC.Checked Then
        dpi = New DocPrintingItem
        dpi.Mapping = "childCCincluded"
        dpi.Value = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptRetentionFilterSubPanel.ChildCC}")
        dpi.DataType = "System.String"
        dpiColl.Add(dpi)
      End If

      'today
      dpi = New DocPrintingItem
      dpi.Mapping = "today"
      dpi.Value = MinDateToNull(Now, "") + " : " + Now.ToShortTimeString
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      Return dpiColl
    End Function
#End Region

#Region " ChangeProperty "
    Private Sub EventWiring()
      AddHandler btnSuppliStartFind.Click, AddressOf Me.btnSupplierFind_Click
      AddHandler btnSuppliEndFind.Click, AddressOf Me.btnSupplierFind_Click

      AddHandler ibtnDocCodeStart.Click, AddressOf Me.btnDocCodeFind_Click
      AddHandler ibtnDocCodeEnd.Click, AddressOf Me.btnDocCodeFind_Click

      AddHandler ibtnGLCodeStart.Click, AddressOf Me.btnGLCodeFind_Click
      AddHandler ibtnGLCodeEnd.Click, AddressOf Me.btnGLCodeFind_Click

      AddHandler btnSupplierGroupStart.Click, AddressOf Me.btnSupplierGroupFind_Click
      AddHandler txtSupplierGroupStart.Validated, AddressOf Me.ChangeProperty

      AddHandler btnCCCodeStart.Click, AddressOf Me.btnCostcenterFind_Click
      AddHandler txtCCCodeStart.Validated, AddressOf Me.ChangeProperty

      AddHandler txtDocDateStart.Validated, AddressOf Me.ChangeProperty
      AddHandler txtDocDateEnd.Validated, AddressOf Me.ChangeProperty

      AddHandler dtpDocDateStart.ValueChanged, AddressOf Me.ChangeProperty
      AddHandler dtpDocDateEnd.ValueChanged, AddressOf Me.ChangeProperty

      AddHandler btnAccountStartFind.Click, AddressOf Me.btnAccountFind_Click
      AddHandler txtAccountCodeStart.Validated, AddressOf Me.ChangeProperty

      AddHandler btnAccountEndFind.Click, AddressOf Me.btnAccountFind_Click
      AddHandler txtAccountCodeEnd.Validated, AddressOf Me.ChangeProperty
    End Sub

    Private m_dateSetting As Boolean
    Private Sub ChangeProperty(ByVal sender As Object, ByVal e As EventArgs)

      Select Case CType(sender, Control).Name.ToLower
        'Case "txtcostcentercodestart"
        'Costcenter.GetCostCenter(TxtCostcenterCodeStart, txtTemp, m_cc, CType(ServiceManager.Services.GetService(GetType(SecurityService)), SecurityService).CurrentUser.Id)

        'Case "txtcostcentercodeend"
        'Costcenter.GetCostCenter(TxtCostcenterCodeEnd, txtTemp, m_cc, CType(ServiceManager.Services.GetService(GetType(SecurityService)), SecurityService).CurrentUser.Id)
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

        Case "txtaccountcodestart"
          AccountBook.GetAccountBook(txtAccountCodeStart, txtTemp, Me.m_AccountBookStart)
        Case "txtaccountcodeend"
          AccountBook.GetAccountBook(txtAccountCodeEnd, txtTemp, Me.m_AccountBookEnd)

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
              Case "txtcostcentercodestart", "txtcostcentercodeend"
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
    Private Sub btnDocCodeFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
      Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      Select Case CType(sender, Control).Name.ToLower
        Case "ibtndoccodestart"
          myEntityPanelService.OpenListDialog(New AdvancePay, AddressOf SetDocCodeStartDialog)

        Case "ibtndoccodeend"
          myEntityPanelService.OpenListDialog(New AdvancePay, AddressOf SetDocCodeEndDialog)

      End Select
    End Sub
    Private Sub btnGLCodeFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
      Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      Select Case CType(sender, Control).Name.ToLower
        Case "ibtnglcodestart"
          myEntityPanelService.OpenListDialog(New JournalEntry, AddressOf SetGLCodeStartDialog)

        Case "ibtnglcodeend"
          myEntityPanelService.OpenListDialog(New JournalEntry, AddressOf SetGLCodeEndDialog)

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
    Private Sub SetDocCodeStartDialog(ByVal e As ISimpleEntity)
      Me.txtDocCodeStart.Text = e.Code
      Advancepay.GetAdvancePayRemain(txtDocCodeStart, txtTemp, Me.Advancepay)
    End Sub
    Private Sub SetDocCodeEndDialog(ByVal e As ISimpleEntity)
      Me.txtDocCodeEnd.Text = e.Code
      Advancepay.GetAdvancePayRemain(txtDocCodeEnd, txtTemp, Me.Advancepay)
    End Sub
    Private Sub SetGLCodeStartDialog(ByVal e As ISimpleEntity)
      Me.txtGLCodeStart.Text = e.Code
    End Sub
    Private Sub SetGLCodeEndDialog(ByVal e As ISimpleEntity)
      Me.txtGLCodeEnd.Text = e.Code
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
    'Private Sub btnCostcenterFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    'Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
    'Select Case CType(sender, Control).Name.ToLower
    'Case "btncostcentercodestartfind"
    'myEntityPanelService.OpenTreeDialog(New Costcenter, AddressOf SetCostcenterStartDialog)

    'Case "btncostcentercodeendfind"
    'myEntityPanelService.OpenTreeDialog(New Costcenter, AddressOf SetCostcenterEndDialog)

    'End Select
    'End Sub

    'SupplierGroup
    Private Sub btnSupplierGroupFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
      Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      Select Case CType(sender, Control).Name.ToLower
        Case "btnsuppliergroupstart"
          myEntityPanelService.OpenTreeDialog(New SupplierGroup, AddressOf SetSupplierGroupStartDialog)
      End Select
    End Sub
    Private Sub SetSupplierGroupStartDialog(ByVal e As ISimpleEntity)
      Me.txtSupplierGroupStart.Text = e.Code
      SupplierGroup.GetSupplierGroup(txtSupplierGroupStart, txtSupplierGroupName, m_sg)
    End Sub
    Private Sub btnAccountFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
      Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      Select Case CType(sender, Control).Name.ToLower
        Case "btnaccountstartfind"
          myEntityPanelService.OpenListDialog(New AccountBook, AddressOf SetAcctBookStartDialog)

        Case "btnaccountendfind"
          myEntityPanelService.OpenListDialog(New AccountBook, AddressOf SetAcctBookEndDialog)

      End Select
    End Sub
    Private Sub SetAcctBookStartDialog(ByVal e As ISimpleEntity)
      Me.txtAccountCodeStart.Text = e.Code
      AccountBook.GetAccountBook(txtAccountCodeStart, txtTemp, Me.m_AccountBookStart)
    End Sub
    Private Sub SetAcctBookEndDialog(ByVal e As ISimpleEntity)
      Me.txtAccountCodeEnd.Text = e.Code
      AccountBook.GetAccountBook(txtAccountCodeEnd, txtTemp, Me.m_AccountBookEnd)
    End Sub
#End Region

  End Class
End Namespace

