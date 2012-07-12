Imports Longkong.Pojjaman.BusinessLogic
Imports Longkong.Pojjaman.Services
Imports Longkong.Core.Services

Namespace Longkong.Pojjaman.Gui.Panels
  Public Class RptDRFilterSubPanel
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
    Friend WithEvents chkIncludeChildren As System.Windows.Forms.CheckBox
    Friend WithEvents txtCostCenterName As System.Windows.Forms.TextBox
    Friend WithEvents cmbStatus As System.Windows.Forms.ComboBox
    Friend WithEvents grbItem As Longkong.Pojjaman.Gui.Components.FixedGroupBox
    Friend WithEvents lblFromCostCenter As System.Windows.Forms.Label
    Friend WithEvents lblFromCCPerson As System.Windows.Forms.Label
    Friend WithEvents txtFromCostCenterCode As System.Windows.Forms.TextBox
    Friend WithEvents txtFromCCPersonCode As System.Windows.Forms.TextBox
    Friend WithEvents txtFromCCPersonName As System.Windows.Forms.TextBox
    Friend WithEvents txtFromCostCenterName As System.Windows.Forms.TextBox
    Friend WithEvents grbMainDetail As Longkong.Pojjaman.Gui.Components.FixedGroupBox
    Friend WithEvents lblSubcontractorStart As System.Windows.Forms.Label
    Friend WithEvents lblSubcontractorEnd As System.Windows.Forms.Label
    Friend WithEvents lbltoCCStart As System.Windows.Forms.Label
    Friend WithEvents txttoCCCodeStart As System.Windows.Forms.TextBox
    Friend WithEvents lblStatus As System.Windows.Forms.Label
    Friend WithEvents txtSuContractCodeEnd As System.Windows.Forms.TextBox
    Friend WithEvents btntoCCCodeStart As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents btnSubcontractEndFind As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents btnSubcontractStartFind As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents btnfromCCCodeStart As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents btnfromCCPersoneStart As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents txtTemp As System.Windows.Forms.TextBox
    Friend WithEvents chkShowDetail As System.Windows.Forms.CheckBox
    Friend WithEvents btnDRCodeEndFind As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents txtDRCodeEnd As System.Windows.Forms.TextBox
    Friend WithEvents KeepKeyCombo1 As Longkong.Pojjaman.Gui.Components.KeepKeyCombo
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnDRCodeStartFind As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents txtDRCodeStart As System.Windows.Forms.TextBox
    Friend WithEvents lblDRCode As System.Windows.Forms.Label
    Friend WithEvents KeepKeyCombo2 As Longkong.Pojjaman.Gui.Components.KeepKeyCombo
    Friend WithEvents lblSCCode As System.Windows.Forms.Label
    Friend WithEvents txtSCCode As System.Windows.Forms.TextBox
    Friend WithEvents ibtnShowSCDialog As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents chkOnlyNoSCCode As System.Windows.Forms.CheckBox
    Friend WithEvents txtSuContractCodeStart As System.Windows.Forms.TextBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
      Me.components = New System.ComponentModel.Container()
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(RptDRFilterSubPanel))
      Me.grbMaster = New Longkong.Pojjaman.Gui.Components.FixedGroupBox()
      Me.KeepKeyCombo2 = New Longkong.Pojjaman.Gui.Components.KeepKeyCombo()
      Me.btnSearch = New System.Windows.Forms.Button()
      Me.btnReset = New System.Windows.Forms.Button()
      Me.grbMainDetail = New Longkong.Pojjaman.Gui.Components.FixedGroupBox()
      Me.lblSCCode = New System.Windows.Forms.Label()
      Me.txtSCCode = New System.Windows.Forms.TextBox()
      Me.ibtnShowSCDialog = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.chkShowDetail = New System.Windows.Forms.CheckBox()
      Me.btnDRCodeEndFind = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.txtDRCodeEnd = New System.Windows.Forms.TextBox()
      Me.Label1 = New System.Windows.Forms.Label()
      Me.btnDRCodeStartFind = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.txtDRCodeStart = New System.Windows.Forms.TextBox()
      Me.lblDRCode = New System.Windows.Forms.Label()
      Me.txttoCCCodeStart = New System.Windows.Forms.TextBox()
      Me.cmbStatus = New System.Windows.Forms.ComboBox()
      Me.lblStatus = New System.Windows.Forms.Label()
      Me.lbltoCCStart = New System.Windows.Forms.Label()
      Me.txtCostCenterName = New System.Windows.Forms.TextBox()
      Me.txtDocDateEnd = New System.Windows.Forms.TextBox()
      Me.lblDocDateStart = New System.Windows.Forms.Label()
      Me.dtpDocDateEnd = New System.Windows.Forms.DateTimePicker()
      Me.lblDocDateEnd = New System.Windows.Forms.Label()
      Me.txtDocDateStart = New System.Windows.Forms.TextBox()
      Me.chkIncludeChildren = New System.Windows.Forms.CheckBox()
      Me.btntoCCCodeStart = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.dtpDocDateStart = New System.Windows.Forms.DateTimePicker()
      Me.btnSubcontractEndFind = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.txtSuContractCodeEnd = New System.Windows.Forms.TextBox()
      Me.lblSubcontractorEnd = New System.Windows.Forms.Label()
      Me.btnSubcontractStartFind = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.txtSuContractCodeStart = New System.Windows.Forms.TextBox()
      Me.lblSubcontractorStart = New System.Windows.Forms.Label()
      Me.grbItem = New Longkong.Pojjaman.Gui.Components.FixedGroupBox()
      Me.lblFromCostCenter = New System.Windows.Forms.Label()
      Me.lblFromCCPerson = New System.Windows.Forms.Label()
      Me.txtFromCostCenterCode = New System.Windows.Forms.TextBox()
      Me.txtFromCCPersonCode = New System.Windows.Forms.TextBox()
      Me.txtFromCCPersonName = New System.Windows.Forms.TextBox()
      Me.txtFromCostCenterName = New System.Windows.Forms.TextBox()
      Me.btnfromCCCodeStart = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.btnfromCCPersoneStart = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.txtTemp = New System.Windows.Forms.TextBox()
      Me.Validator = New Longkong.Pojjaman.Gui.Components.PJMTextboxValidator(Me.components)
      Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
      Me.KeepKeyCombo1 = New Longkong.Pojjaman.Gui.Components.KeepKeyCombo()
      Me.chkOnlyNoSCCode = New System.Windows.Forms.CheckBox()
      Me.grbMaster.SuspendLayout()
      Me.grbMainDetail.SuspendLayout()
      Me.grbItem.SuspendLayout()
      CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.SuspendLayout()
      '
      'grbMaster
      '
      Me.grbMaster.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                  Or System.Windows.Forms.AnchorStyles.Left) _
                  Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.grbMaster.Controls.Add(Me.KeepKeyCombo2)
      Me.grbMaster.Controls.Add(Me.btnSearch)
      Me.grbMaster.Controls.Add(Me.btnReset)
      Me.grbMaster.Controls.Add(Me.grbMainDetail)
      Me.grbMaster.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.grbMaster.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.grbMaster.Location = New System.Drawing.Point(8, 8)
      Me.grbMaster.Name = "grbMaster"
      Me.grbMaster.Size = New System.Drawing.Size(840, 248)
      Me.grbMaster.TabIndex = 1
      Me.grbMaster.TabStop = False
      Me.grbMaster.Text = "ใบหักค่าใช้จ่าย"
      '
      'KeepKeyCombo2
      '
      Me.KeepKeyCombo2.FormattingEnabled = True
      Me.KeepKeyCombo2.Location = New System.Drawing.Point(392, 258)
      Me.KeepKeyCombo2.Name = "KeepKeyCombo2"
      Me.KeepKeyCombo2.Size = New System.Drawing.Size(121, 21)
      Me.KeepKeyCombo2.TabIndex = 46
      '
      'btnSearch
      '
      Me.btnSearch.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnSearch.Location = New System.Drawing.Point(752, 216)
      Me.btnSearch.Name = "btnSearch"
      Me.btnSearch.Size = New System.Drawing.Size(75, 23)
      Me.btnSearch.TabIndex = 2
      Me.btnSearch.Text = "ค้นหา"
      '
      'btnReset
      '
      Me.btnReset.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnReset.ForeColor = System.Drawing.SystemColors.ControlText
      Me.btnReset.Location = New System.Drawing.Point(672, 216)
      Me.btnReset.Name = "btnReset"
      Me.btnReset.Size = New System.Drawing.Size(75, 23)
      Me.btnReset.TabIndex = 1
      Me.btnReset.TabStop = False
      Me.btnReset.Text = "เคลียร์"
      '
      'grbMainDetail
      '
      Me.grbMainDetail.Controls.Add(Me.lblSCCode)
      Me.grbMainDetail.Controls.Add(Me.txtSCCode)
      Me.grbMainDetail.Controls.Add(Me.ibtnShowSCDialog)
      Me.grbMainDetail.Controls.Add(Me.chkOnlyNoSCCode)
      Me.grbMainDetail.Controls.Add(Me.chkShowDetail)
      Me.grbMainDetail.Controls.Add(Me.btnDRCodeEndFind)
      Me.grbMainDetail.Controls.Add(Me.txtDRCodeEnd)
      Me.grbMainDetail.Controls.Add(Me.Label1)
      Me.grbMainDetail.Controls.Add(Me.btnDRCodeStartFind)
      Me.grbMainDetail.Controls.Add(Me.txtDRCodeStart)
      Me.grbMainDetail.Controls.Add(Me.lblDRCode)
      Me.grbMainDetail.Controls.Add(Me.txttoCCCodeStart)
      Me.grbMainDetail.Controls.Add(Me.cmbStatus)
      Me.grbMainDetail.Controls.Add(Me.lblStatus)
      Me.grbMainDetail.Controls.Add(Me.lbltoCCStart)
      Me.grbMainDetail.Controls.Add(Me.txtCostCenterName)
      Me.grbMainDetail.Controls.Add(Me.txtDocDateEnd)
      Me.grbMainDetail.Controls.Add(Me.lblDocDateStart)
      Me.grbMainDetail.Controls.Add(Me.dtpDocDateEnd)
      Me.grbMainDetail.Controls.Add(Me.lblDocDateEnd)
      Me.grbMainDetail.Controls.Add(Me.txtDocDateStart)
      Me.grbMainDetail.Controls.Add(Me.chkIncludeChildren)
      Me.grbMainDetail.Controls.Add(Me.btntoCCCodeStart)
      Me.grbMainDetail.Controls.Add(Me.dtpDocDateStart)
      Me.grbMainDetail.Controls.Add(Me.btnSubcontractEndFind)
      Me.grbMainDetail.Controls.Add(Me.txtSuContractCodeEnd)
      Me.grbMainDetail.Controls.Add(Me.lblSubcontractorEnd)
      Me.grbMainDetail.Controls.Add(Me.btnSubcontractStartFind)
      Me.grbMainDetail.Controls.Add(Me.txtSuContractCodeStart)
      Me.grbMainDetail.Controls.Add(Me.lblSubcontractorStart)
      Me.grbMainDetail.Controls.Add(Me.grbItem)
      Me.grbMainDetail.Controls.Add(Me.txtTemp)
      Me.grbMainDetail.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.grbMainDetail.Location = New System.Drawing.Point(8, 24)
      Me.grbMainDetail.Name = "grbMainDetail"
      Me.grbMainDetail.Size = New System.Drawing.Size(824, 187)
      Me.grbMainDetail.TabIndex = 0
      Me.grbMainDetail.TabStop = False
      Me.grbMainDetail.Text = "รายละเอียดทั่วไป"
      '
      'lblSCCode
      '
      Me.lblSCCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblSCCode.ForeColor = System.Drawing.Color.Black
      Me.lblSCCode.Location = New System.Drawing.Point(9, 44)
      Me.lblSCCode.Name = "lblSCCode"
      Me.lblSCCode.Size = New System.Drawing.Size(105, 18)
      Me.lblSCCode.TabIndex = 341
      Me.lblSCCode.Text = "เลขที่ SC"
      Me.lblSCCode.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'txtSCCode
      '
      Me.Validator.SetDataType(Me.txtSCCode, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtSCCode, "")
      Me.txtSCCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtSCCode, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtSCCode, System.Drawing.Color.Empty)
      Me.txtSCCode.Location = New System.Drawing.Point(120, 43)
      Me.Validator.SetMinValue(Me.txtSCCode, "")
      Me.txtSCCode.Name = "txtSCCode"
      Me.Validator.SetRegularExpression(Me.txtSCCode, "")
      Me.Validator.SetRequired(Me.txtSCCode, False)
      Me.txtSCCode.Size = New System.Drawing.Size(104, 21)
      Me.txtSCCode.TabIndex = 2
      Me.txtSCCode.TabStop = False
      '
      'ibtnShowSCDialog
      '
      Me.ibtnShowSCDialog.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.ibtnShowSCDialog.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.ibtnShowSCDialog.ForeColor = System.Drawing.SystemColors.Control
      Me.ibtnShowSCDialog.Location = New System.Drawing.Point(224, 43)
      Me.ibtnShowSCDialog.Name = "ibtnShowSCDialog"
      Me.ibtnShowSCDialog.Size = New System.Drawing.Size(24, 23)
      Me.ibtnShowSCDialog.TabIndex = 342
      Me.ibtnShowSCDialog.TabStop = False
      Me.ibtnShowSCDialog.ThemedImage = CType(resources.GetObject("ibtnShowSCDialog.ThemedImage"), System.Drawing.Bitmap)
      '
      'chkShowDetail
      '
      Me.chkShowDetail.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.chkShowDetail.Location = New System.Drawing.Point(120, 161)
      Me.chkShowDetail.Name = "chkShowDetail"
      Me.chkShowDetail.Size = New System.Drawing.Size(128, 24)
      Me.chkShowDetail.TabIndex = 9
      Me.chkShowDetail.Text = "แสดงรายละเอียด"
      '
      'btnDRCodeEndFind
      '
      Me.btnDRCodeEndFind.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnDRCodeEndFind.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.btnDRCodeEndFind.ForeColor = System.Drawing.SystemColors.Control
      Me.btnDRCodeEndFind.Location = New System.Drawing.Point(384, 67)
      Me.btnDRCodeEndFind.Name = "btnDRCodeEndFind"
      Me.btnDRCodeEndFind.Size = New System.Drawing.Size(24, 22)
      Me.btnDRCodeEndFind.TabIndex = 43
      Me.btnDRCodeEndFind.TabStop = False
      Me.btnDRCodeEndFind.ThemedImage = CType(resources.GetObject("btnDRCodeEndFind.ThemedImage"), System.Drawing.Bitmap)
      '
      'txtDRCodeEnd
      '
      Me.Validator.SetDataType(Me.txtDRCodeEnd, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtDRCodeEnd, "")
      Me.txtDRCodeEnd.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtDRCodeEnd, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtDRCodeEnd, -15)
      Me.Validator.SetInvalidBackColor(Me.txtDRCodeEnd, System.Drawing.Color.Empty)
      Me.txtDRCodeEnd.Location = New System.Drawing.Point(281, 67)
      Me.Validator.SetMinValue(Me.txtDRCodeEnd, "")
      Me.txtDRCodeEnd.Name = "txtDRCodeEnd"
      Me.Validator.SetRegularExpression(Me.txtDRCodeEnd, "")
      Me.Validator.SetRequired(Me.txtDRCodeEnd, False)
      Me.txtDRCodeEnd.Size = New System.Drawing.Size(103, 21)
      Me.txtDRCodeEnd.TabIndex = 4
      '
      'Label1
      '
      Me.Label1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Label1.ForeColor = System.Drawing.Color.Black
      Me.Label1.Location = New System.Drawing.Point(252, 67)
      Me.Label1.Name = "Label1"
      Me.Label1.Size = New System.Drawing.Size(24, 18)
      Me.Label1.TabIndex = 44
      Me.Label1.Text = "ถึง"
      Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
      '
      'btnDRCodeStartFind
      '
      Me.btnDRCodeStartFind.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnDRCodeStartFind.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.btnDRCodeStartFind.ForeColor = System.Drawing.SystemColors.Control
      Me.btnDRCodeStartFind.Location = New System.Drawing.Point(224, 67)
      Me.btnDRCodeStartFind.Name = "btnDRCodeStartFind"
      Me.btnDRCodeStartFind.Size = New System.Drawing.Size(24, 22)
      Me.btnDRCodeStartFind.TabIndex = 41
      Me.btnDRCodeStartFind.TabStop = False
      Me.btnDRCodeStartFind.ThemedImage = CType(resources.GetObject("btnDRCodeStartFind.ThemedImage"), System.Drawing.Bitmap)
      '
      'txtDRCodeStart
      '
      Me.Validator.SetDataType(Me.txtDRCodeStart, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtDRCodeStart, "")
      Me.txtDRCodeStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtDRCodeStart, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtDRCodeStart, -15)
      Me.Validator.SetInvalidBackColor(Me.txtDRCodeStart, System.Drawing.Color.Empty)
      Me.txtDRCodeStart.Location = New System.Drawing.Point(120, 67)
      Me.Validator.SetMinValue(Me.txtDRCodeStart, "")
      Me.txtDRCodeStart.Name = "txtDRCodeStart"
      Me.Validator.SetRegularExpression(Me.txtDRCodeStart, "")
      Me.Validator.SetRequired(Me.txtDRCodeStart, False)
      Me.txtDRCodeStart.Size = New System.Drawing.Size(104, 21)
      Me.txtDRCodeStart.TabIndex = 3
      '
      'lblDRCode
      '
      Me.lblDRCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblDRCode.ForeColor = System.Drawing.Color.Black
      Me.lblDRCode.Location = New System.Drawing.Point(6, 67)
      Me.lblDRCode.Name = "lblDRCode"
      Me.lblDRCode.Size = New System.Drawing.Size(109, 18)
      Me.lblDRCode.TabIndex = 42
      Me.lblDRCode.Text = "เลขที่ใบหักค่าใช้จ่าย"
      Me.lblDRCode.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'txttoCCCodeStart
      '
      Me.Validator.SetDataType(Me.txttoCCCodeStart, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txttoCCCodeStart, "")
      Me.txttoCCCodeStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txttoCCCodeStart, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txttoCCCodeStart, -15)
      Me.Validator.SetInvalidBackColor(Me.txttoCCCodeStart, System.Drawing.Color.Empty)
      Me.txttoCCCodeStart.Location = New System.Drawing.Point(120, 115)
      Me.txttoCCCodeStart.MaxLength = 50
      Me.Validator.SetMinValue(Me.txttoCCCodeStart, "")
      Me.txttoCCCodeStart.Name = "txttoCCCodeStart"
      Me.Validator.SetRegularExpression(Me.txttoCCCodeStart, "")
      Me.Validator.SetRequired(Me.txttoCCCodeStart, False)
      Me.txttoCCCodeStart.Size = New System.Drawing.Size(104, 21)
      Me.txttoCCCodeStart.TabIndex = 7
      '
      'cmbStatus
      '
      Me.cmbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbStatus.Location = New System.Drawing.Point(544, 139)
      Me.cmbStatus.Name = "cmbStatus"
      Me.cmbStatus.Size = New System.Drawing.Size(120, 21)
      Me.cmbStatus.TabIndex = 38
      Me.cmbStatus.Visible = False
      '
      'lblStatus
      '
      Me.lblStatus.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblStatus.ForeColor = System.Drawing.Color.Black
      Me.lblStatus.Location = New System.Drawing.Point(498, 139)
      Me.lblStatus.Name = "lblStatus"
      Me.lblStatus.Size = New System.Drawing.Size(40, 18)
      Me.lblStatus.TabIndex = 37
      Me.lblStatus.Text = "สถานะ"
      Me.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      Me.lblStatus.Visible = False
      '
      'lbltoCCStart
      '
      Me.lbltoCCStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lbltoCCStart.ForeColor = System.Drawing.Color.Black
      Me.lbltoCCStart.Location = New System.Drawing.Point(43, 115)
      Me.lbltoCCStart.Name = "lbltoCCStart"
      Me.lbltoCCStart.Size = New System.Drawing.Size(72, 18)
      Me.lbltoCCStart.TabIndex = 14
      Me.lbltoCCStart.Text = "Cost Center"
      Me.lbltoCCStart.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'txtCostCenterName
      '
      Me.Validator.SetDataType(Me.txtCostCenterName, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtCostCenterName, "")
      Me.txtCostCenterName.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtCostCenterName, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtCostCenterName, -15)
      Me.Validator.SetInvalidBackColor(Me.txtCostCenterName, System.Drawing.Color.Empty)
      Me.txtCostCenterName.Location = New System.Drawing.Point(248, 115)
      Me.txtCostCenterName.MaxLength = 50
      Me.Validator.SetMinValue(Me.txtCostCenterName, "")
      Me.txtCostCenterName.Name = "txtCostCenterName"
      Me.txtCostCenterName.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtCostCenterName, "")
      Me.Validator.SetRequired(Me.txtCostCenterName, False)
      Me.txtCostCenterName.Size = New System.Drawing.Size(160, 21)
      Me.txtCostCenterName.TabIndex = 15
      '
      'txtDocDateEnd
      '
      Me.Validator.SetDataType(Me.txtDocDateEnd, Longkong.Pojjaman.Gui.Components.DataTypeConstants.DateTimeType)
      Me.Validator.SetDisplayName(Me.txtDocDateEnd, "")
      Me.Validator.SetGotFocusBackColor(Me.txtDocDateEnd, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtDocDateEnd, -15)
      Me.Validator.SetInvalidBackColor(Me.txtDocDateEnd, System.Drawing.Color.Empty)
      Me.txtDocDateEnd.Location = New System.Drawing.Point(281, 19)
      Me.txtDocDateEnd.MaxLength = 10
      Me.Validator.SetMinValue(Me.txtDocDateEnd, "")
      Me.txtDocDateEnd.Name = "txtDocDateEnd"
      Me.Validator.SetRegularExpression(Me.txtDocDateEnd, "")
      Me.Validator.SetRequired(Me.txtDocDateEnd, False)
      Me.txtDocDateEnd.Size = New System.Drawing.Size(99, 21)
      Me.txtDocDateEnd.TabIndex = 1
      '
      'lblDocDateStart
      '
      Me.lblDocDateStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblDocDateStart.ForeColor = System.Drawing.Color.Black
      Me.lblDocDateStart.Location = New System.Drawing.Point(59, 19)
      Me.lblDocDateStart.Name = "lblDocDateStart"
      Me.lblDocDateStart.Size = New System.Drawing.Size(56, 18)
      Me.lblDocDateStart.TabIndex = 0
      Me.lblDocDateStart.Text = "ตั้งแต่วันที่"
      Me.lblDocDateStart.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'dtpDocDateEnd
      '
      Me.dtpDocDateEnd.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
      Me.dtpDocDateEnd.Location = New System.Drawing.Point(288, 19)
      Me.dtpDocDateEnd.Name = "dtpDocDateEnd"
      Me.dtpDocDateEnd.Size = New System.Drawing.Size(120, 21)
      Me.dtpDocDateEnd.TabIndex = 5
      Me.dtpDocDateEnd.TabStop = False
      '
      'lblDocDateEnd
      '
      Me.lblDocDateEnd.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblDocDateEnd.ForeColor = System.Drawing.Color.Black
      Me.lblDocDateEnd.Location = New System.Drawing.Point(251, 19)
      Me.lblDocDateEnd.Name = "lblDocDateEnd"
      Me.lblDocDateEnd.Size = New System.Drawing.Size(24, 18)
      Me.lblDocDateEnd.TabIndex = 3
      Me.lblDocDateEnd.Text = "ถึง"
      Me.lblDocDateEnd.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
      '
      'txtDocDateStart
      '
      Me.Validator.SetDataType(Me.txtDocDateStart, Longkong.Pojjaman.Gui.Components.DataTypeConstants.DateTimeType)
      Me.Validator.SetDisplayName(Me.txtDocDateStart, "")
      Me.Validator.SetGotFocusBackColor(Me.txtDocDateStart, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtDocDateStart, -15)
      Me.Validator.SetInvalidBackColor(Me.txtDocDateStart, System.Drawing.Color.Empty)
      Me.txtDocDateStart.Location = New System.Drawing.Point(120, 19)
      Me.txtDocDateStart.MaxLength = 10
      Me.Validator.SetMinValue(Me.txtDocDateStart, "")
      Me.txtDocDateStart.Name = "txtDocDateStart"
      Me.Validator.SetRegularExpression(Me.txtDocDateStart, "")
      Me.Validator.SetRequired(Me.txtDocDateStart, False)
      Me.txtDocDateStart.Size = New System.Drawing.Size(99, 21)
      Me.txtDocDateStart.TabIndex = 0
      '
      'chkIncludeChildren
      '
      Me.chkIncludeChildren.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.chkIncludeChildren.Location = New System.Drawing.Point(120, 138)
      Me.chkIncludeChildren.Name = "chkIncludeChildren"
      Me.chkIncludeChildren.Size = New System.Drawing.Size(128, 24)
      Me.chkIncludeChildren.TabIndex = 8
      Me.chkIncludeChildren.Text = "รวม Cost Center ลูก"
      '
      'btntoCCCodeStart
      '
      Me.btntoCCCodeStart.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btntoCCCodeStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.btntoCCCodeStart.ForeColor = System.Drawing.SystemColors.Control
      Me.btntoCCCodeStart.Location = New System.Drawing.Point(224, 115)
      Me.btntoCCCodeStart.Name = "btntoCCCodeStart"
      Me.btntoCCCodeStart.Size = New System.Drawing.Size(24, 22)
      Me.btntoCCCodeStart.TabIndex = 22
      Me.btntoCCCodeStart.TabStop = False
      Me.btntoCCCodeStart.ThemedImage = CType(resources.GetObject("btntoCCCodeStart.ThemedImage"), System.Drawing.Bitmap)
      '
      'dtpDocDateStart
      '
      Me.dtpDocDateStart.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
      Me.dtpDocDateStart.Location = New System.Drawing.Point(131, 19)
      Me.dtpDocDateStart.Name = "dtpDocDateStart"
      Me.dtpDocDateStart.Size = New System.Drawing.Size(117, 21)
      Me.dtpDocDateStart.TabIndex = 1
      Me.dtpDocDateStart.TabStop = False
      '
      'btnSubcontractEndFind
      '
      Me.btnSubcontractEndFind.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnSubcontractEndFind.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.btnSubcontractEndFind.ForeColor = System.Drawing.SystemColors.Control
      Me.btnSubcontractEndFind.Location = New System.Drawing.Point(384, 91)
      Me.btnSubcontractEndFind.Name = "btnSubcontractEndFind"
      Me.btnSubcontractEndFind.Size = New System.Drawing.Size(24, 22)
      Me.btnSubcontractEndFind.TabIndex = 21
      Me.btnSubcontractEndFind.TabStop = False
      Me.btnSubcontractEndFind.ThemedImage = CType(resources.GetObject("btnSubcontractEndFind.ThemedImage"), System.Drawing.Bitmap)
      '
      'txtSuContractCodeEnd
      '
      Me.Validator.SetDataType(Me.txtSuContractCodeEnd, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtSuContractCodeEnd, "")
      Me.txtSuContractCodeEnd.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtSuContractCodeEnd, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtSuContractCodeEnd, -15)
      Me.Validator.SetInvalidBackColor(Me.txtSuContractCodeEnd, System.Drawing.Color.Empty)
      Me.txtSuContractCodeEnd.Location = New System.Drawing.Point(281, 91)
      Me.Validator.SetMinValue(Me.txtSuContractCodeEnd, "")
      Me.txtSuContractCodeEnd.Name = "txtSuContractCodeEnd"
      Me.Validator.SetRegularExpression(Me.txtSuContractCodeEnd, "")
      Me.Validator.SetRequired(Me.txtSuContractCodeEnd, False)
      Me.txtSuContractCodeEnd.Size = New System.Drawing.Size(103, 21)
      Me.txtSuContractCodeEnd.TabIndex = 6
      '
      'lblSubcontractorEnd
      '
      Me.lblSubcontractorEnd.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblSubcontractorEnd.ForeColor = System.Drawing.Color.Black
      Me.lblSubcontractorEnd.Location = New System.Drawing.Point(252, 91)
      Me.lblSubcontractorEnd.Name = "lblSubcontractorEnd"
      Me.lblSubcontractorEnd.Size = New System.Drawing.Size(24, 18)
      Me.lblSubcontractorEnd.TabIndex = 22
      Me.lblSubcontractorEnd.Text = "ถึง"
      Me.lblSubcontractorEnd.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
      '
      'btnSubcontractStartFind
      '
      Me.btnSubcontractStartFind.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnSubcontractStartFind.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.btnSubcontractStartFind.ForeColor = System.Drawing.SystemColors.Control
      Me.btnSubcontractStartFind.Location = New System.Drawing.Point(224, 91)
      Me.btnSubcontractStartFind.Name = "btnSubcontractStartFind"
      Me.btnSubcontractStartFind.Size = New System.Drawing.Size(24, 22)
      Me.btnSubcontractStartFind.TabIndex = 9
      Me.btnSubcontractStartFind.TabStop = False
      Me.btnSubcontractStartFind.ThemedImage = CType(resources.GetObject("btnSubcontractStartFind.ThemedImage"), System.Drawing.Bitmap)
      '
      'txtSuContractCodeStart
      '
      Me.Validator.SetDataType(Me.txtSuContractCodeStart, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtSuContractCodeStart, "")
      Me.txtSuContractCodeStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtSuContractCodeStart, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtSuContractCodeStart, -15)
      Me.Validator.SetInvalidBackColor(Me.txtSuContractCodeStart, System.Drawing.Color.Empty)
      Me.txtSuContractCodeStart.Location = New System.Drawing.Point(120, 91)
      Me.Validator.SetMinValue(Me.txtSuContractCodeStart, "")
      Me.txtSuContractCodeStart.Name = "txtSuContractCodeStart"
      Me.Validator.SetRegularExpression(Me.txtSuContractCodeStart, "")
      Me.Validator.SetRequired(Me.txtSuContractCodeStart, False)
      Me.txtSuContractCodeStart.Size = New System.Drawing.Size(104, 21)
      Me.txtSuContractCodeStart.TabIndex = 5
      '
      'lblSubcontractorStart
      '
      Me.lblSubcontractorStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblSubcontractorStart.ForeColor = System.Drawing.Color.Black
      Me.lblSubcontractorStart.Location = New System.Drawing.Point(43, 91)
      Me.lblSubcontractorStart.Name = "lblSubcontractorStart"
      Me.lblSubcontractorStart.Size = New System.Drawing.Size(72, 18)
      Me.lblSubcontractorStart.TabIndex = 19
      Me.lblSubcontractorStart.Text = "ผู้รับเหมา"
      Me.lblSubcontractorStart.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'grbItem
      '
      Me.grbItem.Controls.Add(Me.lblFromCostCenter)
      Me.grbItem.Controls.Add(Me.lblFromCCPerson)
      Me.grbItem.Controls.Add(Me.txtFromCostCenterCode)
      Me.grbItem.Controls.Add(Me.txtFromCCPersonCode)
      Me.grbItem.Controls.Add(Me.txtFromCCPersonName)
      Me.grbItem.Controls.Add(Me.txtFromCostCenterName)
      Me.grbItem.Controls.Add(Me.btnfromCCCodeStart)
      Me.grbItem.Controls.Add(Me.btnfromCCPersoneStart)
      Me.grbItem.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.grbItem.Location = New System.Drawing.Point(424, 11)
      Me.grbItem.Name = "grbItem"
      Me.grbItem.Size = New System.Drawing.Size(384, 88)
      Me.grbItem.TabIndex = 1
      Me.grbItem.TabStop = False
      Me.grbItem.Text = "ข้อมูลผู้ให้เบิก"
      '
      'lblFromCostCenter
      '
      Me.lblFromCostCenter.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblFromCostCenter.Location = New System.Drawing.Point(8, 24)
      Me.lblFromCostCenter.Name = "lblFromCostCenter"
      Me.lblFromCostCenter.Size = New System.Drawing.Size(112, 18)
      Me.lblFromCostCenter.TabIndex = 18
      Me.lblFromCostCenter.Text = "Cost Center ที่ให้เบิก:"
      Me.lblFromCostCenter.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblFromCCPerson
      '
      Me.lblFromCCPerson.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblFromCCPerson.Location = New System.Drawing.Point(56, 48)
      Me.lblFromCCPerson.Name = "lblFromCCPerson"
      Me.lblFromCCPerson.Size = New System.Drawing.Size(64, 18)
      Me.lblFromCCPerson.TabIndex = 19
      Me.lblFromCCPerson.Text = "ผู้ให้เบิก:"
      Me.lblFromCCPerson.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'txtFromCostCenterCode
      '
      Me.txtFromCostCenterCode.BackColor = System.Drawing.SystemColors.Window
      Me.Validator.SetDataType(Me.txtFromCostCenterCode, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtFromCostCenterCode, "")
      Me.Validator.SetGotFocusBackColor(Me.txtFromCostCenterCode, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtFromCostCenterCode, System.Drawing.Color.Empty)
      Me.txtFromCostCenterCode.Location = New System.Drawing.Point(120, 24)
      Me.Validator.SetMinValue(Me.txtFromCostCenterCode, "")
      Me.txtFromCostCenterCode.Name = "txtFromCostCenterCode"
      Me.Validator.SetRegularExpression(Me.txtFromCostCenterCode, "")
      Me.Validator.SetRequired(Me.txtFromCostCenterCode, False)
      Me.txtFromCostCenterCode.Size = New System.Drawing.Size(72, 21)
      Me.txtFromCostCenterCode.TabIndex = 0
      '
      'txtFromCCPersonCode
      '
      Me.txtFromCCPersonCode.BackColor = System.Drawing.SystemColors.Window
      Me.Validator.SetDataType(Me.txtFromCCPersonCode, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtFromCCPersonCode, "")
      Me.Validator.SetGotFocusBackColor(Me.txtFromCCPersonCode, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtFromCCPersonCode, System.Drawing.Color.Empty)
      Me.txtFromCCPersonCode.Location = New System.Drawing.Point(120, 48)
      Me.Validator.SetMinValue(Me.txtFromCCPersonCode, "")
      Me.txtFromCCPersonCode.Name = "txtFromCCPersonCode"
      Me.Validator.SetRegularExpression(Me.txtFromCCPersonCode, "")
      Me.Validator.SetRequired(Me.txtFromCCPersonCode, False)
      Me.txtFromCCPersonCode.Size = New System.Drawing.Size(72, 21)
      Me.txtFromCCPersonCode.TabIndex = 1
      '
      'txtFromCCPersonName
      '
      Me.Validator.SetDataType(Me.txtFromCCPersonName, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtFromCCPersonName, "")
      Me.Validator.SetGotFocusBackColor(Me.txtFromCCPersonName, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtFromCCPersonName, System.Drawing.Color.Empty)
      Me.txtFromCCPersonName.Location = New System.Drawing.Point(216, 48)
      Me.Validator.SetMinValue(Me.txtFromCCPersonName, "")
      Me.txtFromCCPersonName.Name = "txtFromCCPersonName"
      Me.txtFromCCPersonName.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtFromCCPersonName, "")
      Me.Validator.SetRequired(Me.txtFromCCPersonName, False)
      Me.txtFromCCPersonName.Size = New System.Drawing.Size(160, 21)
      Me.txtFromCCPersonName.TabIndex = 13
      Me.txtFromCCPersonName.TabStop = False
      '
      'txtFromCostCenterName
      '
      Me.Validator.SetDataType(Me.txtFromCostCenterName, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtFromCostCenterName, "")
      Me.Validator.SetGotFocusBackColor(Me.txtFromCostCenterName, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtFromCostCenterName, System.Drawing.Color.Empty)
      Me.txtFromCostCenterName.Location = New System.Drawing.Point(216, 24)
      Me.Validator.SetMinValue(Me.txtFromCostCenterName, "")
      Me.txtFromCostCenterName.Name = "txtFromCostCenterName"
      Me.txtFromCostCenterName.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtFromCostCenterName, "")
      Me.Validator.SetRequired(Me.txtFromCostCenterName, False)
      Me.txtFromCostCenterName.Size = New System.Drawing.Size(160, 21)
      Me.txtFromCostCenterName.TabIndex = 12
      Me.txtFromCostCenterName.TabStop = False
      '
      'btnfromCCCodeStart
      '
      Me.btnfromCCCodeStart.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnfromCCCodeStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.btnfromCCCodeStart.ForeColor = System.Drawing.SystemColors.Control
      Me.btnfromCCCodeStart.Location = New System.Drawing.Point(192, 24)
      Me.btnfromCCCodeStart.Name = "btnfromCCCodeStart"
      Me.btnfromCCCodeStart.Size = New System.Drawing.Size(24, 23)
      Me.btnfromCCCodeStart.TabIndex = 14
      Me.btnfromCCCodeStart.TabStop = False
      Me.btnfromCCCodeStart.ThemedImage = CType(resources.GetObject("btnfromCCCodeStart.ThemedImage"), System.Drawing.Bitmap)
      '
      'btnfromCCPersoneStart
      '
      Me.btnfromCCPersoneStart.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnfromCCPersoneStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.btnfromCCPersoneStart.ForeColor = System.Drawing.SystemColors.Control
      Me.btnfromCCPersoneStart.Location = New System.Drawing.Point(192, 48)
      Me.btnfromCCPersoneStart.Name = "btnfromCCPersoneStart"
      Me.btnfromCCPersoneStart.Size = New System.Drawing.Size(24, 23)
      Me.btnfromCCPersoneStart.TabIndex = 15
      Me.btnfromCCPersoneStart.TabStop = False
      Me.btnfromCCPersoneStart.ThemedImage = CType(resources.GetObject("btnfromCCPersoneStart.ThemedImage"), System.Drawing.Bitmap)
      '
      'txtTemp
      '
      Me.Validator.SetDataType(Me.txtTemp, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtTemp, "")
      Me.Validator.SetGotFocusBackColor(Me.txtTemp, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtTemp, System.Drawing.Color.Empty)
      Me.txtTemp.Location = New System.Drawing.Point(288, 91)
      Me.txtTemp.MaxLength = 255
      Me.Validator.SetMinValue(Me.txtTemp, "")
      Me.txtTemp.Name = "txtTemp"
      Me.txtTemp.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtTemp, "")
      Me.Validator.SetRequired(Me.txtTemp, False)
      Me.txtTemp.Size = New System.Drawing.Size(104, 21)
      Me.txtTemp.TabIndex = 4
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
      'KeepKeyCombo1
      '
      Me.KeepKeyCombo1.FormattingEnabled = True
      Me.KeepKeyCombo1.Location = New System.Drawing.Point(422, 292)
      Me.KeepKeyCombo1.Name = "KeepKeyCombo1"
      Me.KeepKeyCombo1.Size = New System.Drawing.Size(121, 21)
      Me.KeepKeyCombo1.TabIndex = 4
      '
      'chkOnlyNoSCCode
      '
      Me.chkOnlyNoSCCode.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.chkOnlyNoSCCode.Location = New System.Drawing.Point(264, 161)
      Me.chkOnlyNoSCCode.Name = "chkOnlyNoSCCode"
      Me.chkOnlyNoSCCode.Size = New System.Drawing.Size(191, 24)
      Me.chkOnlyNoSCCode.TabIndex = 9
      Me.chkOnlyNoSCCode.Text = "แสดงเฉพาะเอกสารที่ไม่มีใบสั่งจ้าง"
      '
      'RptDRFilterSubPanel
      '
      Me.Controls.Add(Me.KeepKeyCombo1)
      Me.Controls.Add(Me.grbMaster)
      Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Name = "RptDRFilterSubPanel"
      Me.Size = New System.Drawing.Size(864, 265)
      Me.grbMaster.ResumeLayout(False)
      Me.grbMainDetail.ResumeLayout(False)
      Me.grbMainDetail.PerformLayout()
      Me.grbItem.ResumeLayout(False)
      Me.grbItem.PerformLayout()
      CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
      Me.ResumeLayout(False)

    End Sub

#End Region

#Region " SetLabelText "
    Public Sub SetLabelText()

      Me.grbMaster.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptDRFilterSubPanel.grbMaster}")
      Me.grbMainDetail.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptDRFilterSubPanel.grbMainDetail}")
      Me.lblDocDateStart.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptDRFilterSubPanel.lblDocDateStart}")
      Me.lblDocDateEnd.Text = Me.StringParserService.Parse("${res:Global.FilterPanelTo}")
      Me.lblSubcontractorStart.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptDRFilterSubPanel.lblSubcontractorStart}")
      Me.lblSubcontractorEnd.Text = Me.StringParserService.Parse("${res:Global.FilterPanelTo}")
      Me.chkIncludeChildren.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptDRFilterSubPanel.chkIncludeChildren}")
      Me.lblStatus.Text = StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptDRFilterSubPanel.lblStatus}")
      Me.chkOnlyNoSCCode.Text = StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptDRFilterSubPanel.chkOnlyNoSCCode}")

      Me.grbItem.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptDRFilterSubPanel.grbItem}")
      Me.lblFromCostCenter.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptDRFilterSubPanel.lblFromCostCenter}")

      ''If Not m_entity Is Nothing Then Me.Text = Me.StringParserService.Parse(Me.m_entity.TabPageText)
      Me.lbltoCCStart.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptDRFilterSubPanel.lbltoCCStart}")
      Me.Validator.SetDisplayName(txttoCCCodeStart, lbltoCCStart.Text)

      Me.Validator.SetDisplayName(txtSuContractCodeStart, lblSubcontractorStart.Text)

      Me.Validator.SetDisplayName(txtDocDateStart, lblDocDateStart.Text)

      Me.Validator.SetDisplayName(txtDocDateEnd, lblDocDateEnd.Text)

      Me.lblSCCode.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptSCFilterSubPanel.lblSCCode}")

      ' Button
      Me.btnSearch.Text = Me.StringParserService.Parse("${res:Global.SearchButtonText}")
      Me.btnReset.Text = Me.StringParserService.Parse("${res:Global.ResetButtonText}")


    End Sub
#End Region

#Region "Member"
    Private m_tocc As CostCenter
    Private m_fromcc As CostCenter
    Private m_subcontractor As Supplier
    Private m_DocDateEnd As Date
    Private m_DocDateStart As Date
    'Private m_DueDateEnd As Date
    'Private m_DueDateStart As Date
    Private m_subcontractorgroup As SupplierGroup
    Private m_frompersone As Employee
    Private m_dr As DR

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
    Public Property toCostcenter() As CostCenter
      Get
        Return m_tocc
      End Get
      Set(ByVal Value As CostCenter)
        m_tocc = Value
      End Set
    End Property
    Public Property fromCostcenter() As CostCenter
      Get
        Return m_fromcc
      End Get
      Set(ByVal Value As CostCenter)
        m_fromcc = Value
      End Set
    End Property
    Private Property DRCode As DR
      Get
        Return m_dr
      End Get
      Set(ByVal value As DR)
        m_dr = value
      End Set
    End Property

    Public Property Subcontractor() As Supplier
      Get
        Return m_subcontractor
      End Get
      Set(ByVal Value As Supplier)
        m_subcontractor = Value
      End Set
    End Property
    Public Property DocDateEnd() As Date      Get        Return m_DocDateEnd      End Get      Set(ByVal Value As Date)        m_DocDateEnd = Value      End Set    End Property    Public Property DocDateStart() As Date      Get        Return m_DocDateStart      End Get      Set(ByVal Value As Date)        m_DocDateStart = Value      End Set    End Property
    'Public Property DueDateEnd() As Date    '    Get    '        Return m_DocDateEnd    '    End Get    '    Set(ByVal Value As Date)    '        m_DocDateEnd = Value    '    End Set    'End Property    'Public Property DueDateStart() As Date    '    Get    '        Return m_DocDateStart    '    End Get    '    Set(ByVal Value As Date)    '        m_DocDateStart = Value    '    End Set    'End Property
    Public Property SubcontractorGroup() As SupplierGroup
      Get
        Return m_subcontractorgroup
      End Get
      Set(ByVal Value As SupplierGroup)
        m_subcontractorgroup = Value
      End Set
    End Property
    Public Property frompersone() As Employee
      Get
        Return m_frompersone
      End Get
      Set(ByVal Value As Employee)
        m_frompersone = Value
      End Set
    End Property
#End Region

#Region "Methods"
    'Private Sub RegisterDropdown()
    '  CodeDescription.ListCodeDescriptionInComboBox(Me.cmbDocStatus, "goodsreceipt_status", True)
    '  cmbDocStatus.SelectedIndex = 0
    'End Sub
    Private Sub Initialize()
      'RegisterDropdown()
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

      Me.Subcontractor = New Supplier
      Me.toCostcenter = New CostCenter
      Me.fromCostcenter = New CostCenter

      Dim dtStart As Date = Date.Now.Subtract(New TimeSpan(7, 0, 0, 0))

      Me.DocDateStart = dtStart
      Me.txtDocDateStart.Text = MinDateToNull(Me.DocDateStart, "")
      Me.dtpDocDateStart.Value = Me.DocDateStart

      Me.DocDateEnd = Date.Now
      Me.txtDocDateEnd.Text = MinDateToNull(Me.DocDateEnd, "")
      Me.dtpDocDateEnd.Value = Me.DocDateEnd

      Me.txtDRCodeStart.Text = ""
      Me.txtDRCodeEnd.Text = ""

      Me.SubcontractorGroup = New SupplierGroup
      Me.frompersone = New Employee

      Me.txtFromCostCenterCode.Text = ""
      Me.txtFromCostCenterName.Clear()
      Me.txtFromCCPersonCode.Clear()

      Me.txtFromCCPersonName.Text = ""
      'If chkIncludeChildren.Checked Then
      Me.chkIncludeChildren.Checked = False
      Me.chkShowDetail.Checked = False
      Me.chkOnlyNoSCCode.Checked = False
      'End If

    End Sub
    Public Overrides Function GetFilterString() As String

    End Function
    Public Overrides Function GetFilterArray() As Filter()
      Dim arr(13) As Filter
      arr(0) = New Filter("docdatestart", IIf(Me.DocDateStart.Equals(Date.MinValue), DBNull.Value, Me.DocDateStart))
      arr(1) = New Filter("docdateend", IIf(Me.DocDateEnd.Equals(Date.MinValue), DBNull.Value, Me.DocDateEnd))
      arr(2) = New Filter("SubcontractorCodeStart", IIf(txtSuContractCodeStart.TextLength > 0, txtSuContractCodeStart.Text, DBNull.Value))
      arr(3) = New Filter("SubcontractorCodeEnd", IIf(txtSuContractCodeEnd.TextLength > 0, txtSuContractCodeEnd.Text, DBNull.Value))
      arr(4) = New Filter("Tocc", Me.ValidIdOrDBNull(m_tocc))
      arr(5) = New Filter("IncludeChildCC", Me.chkIncludeChildren.Checked)
      arr(6) = New Filter("status", cmbStatus.SelectedIndex) ' IIf(cmbDocStatus.SelectedItem Is Nothing, DBNull.Value, CType(cmbDocStatus.SelectedItem, IdValuePair).Id))
      arr(7) = New Filter("Fromcc", Me.ValidIdOrDBNull(m_fromcc))
      arr(8) = New Filter("userRight", CType(ServiceManager.Services.GetService(GetType(SecurityService)), SecurityService).CurrentUser.Id)
      arr(9) = New Filter("DRCodeStart", IIf(txtDRCodeStart.TextLength > 0, txtDRCodeStart.Text, DBNull.Value))
      arr(10) = New Filter("DRCodeEnd", IIf(txtDRCodeEnd.TextLength > 0, txtDRCodeEnd.Text, DBNull.Value))
      arr(11) = New Filter("ShowDetail", Me.chkShowDetail.Checked)
      arr(12) = New Filter("SCCode", IIf(Me.txtSCCode.Text.Trim.Length = 0, DBNull.Value, Me.txtSCCode.Text.Trim))
      arr(13) = New Filter("OnlyNoSC", Me.chkOnlyNoSCCode.Checked)
      'arr(8) = New Filter("SubcontractorGroupID", Me.ValidIdOrDBNull(m_subcontractorgroup))
      'arr(9) = New Filter("IncludeChildSubcontractorGroup", Me.chkIncludeChildSupplierGroup.Checked)
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

      'Subcontractor Code
      dpi = New DocPrintingItem
      dpi.Mapping = "SubcontractorCode"
      dpi.Value = Me.txtSuContractCodeStart.Text
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      'Subcontractor Name
      dpi = New DocPrintingItem
      dpi.Mapping = "SubcontractorName"
      dpi.Value = Me.txtSuContractCodeEnd.Text
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      'to CostCenter Code
      dpi = New DocPrintingItem
      dpi.Mapping = "ToCostCenterCode"
      dpi.Value = Me.txttoCCCodeStart.Text
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      'to CostCenter Name
      dpi = New DocPrintingItem
      dpi.Mapping = "ToCostCenterName"
      dpi.Value = Me.txtCostCenterName.Text
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      'To CostCenter Info
      dpi = New DocPrintingItem
      dpi.Mapping = "ToCostCenterInfo"
      dpi.Value = Me.txttoCCCodeStart.Text & ":" & Me.txtCostCenterName.Text
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      'Include CCChildren
      If Me.chkIncludeChildren.Checked Then
        dpi = New DocPrintingItem
        dpi.Mapping = "IncludeCCChildren"
        dpi.Value = "(รวมในสังกัด)"
        dpi.DataType = "System.String"
        dpiColl.Add(dpi)
      End If

      'Status
      dpi = New DocPrintingItem
      dpi.Mapping = "Status"
      dpi.Value = Me.cmbStatus.Text
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      'from CostCenter Code
      dpi = New DocPrintingItem
      dpi.Mapping = "FromCostCenterName"
      dpi.Value = Me.txtFromCostCenterCode.Text
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      'from CostCenter Name
      dpi = New DocPrintingItem
      dpi.Mapping = "FromCostCenterName"
      dpi.Value = Me.txtFromCostCenterName.Text
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      'from CostCenter Info
      dpi = New DocPrintingItem
      dpi.Mapping = "FromCostCenterInfo"
      dpi.Value = Me.txtFromCostCenterCode.Text & ":" & Me.txtFromCostCenterName.Text
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      'Employee Code
      dpi = New DocPrintingItem
      dpi.Mapping = "FromCCPersonCode"
      dpi.Value = Me.txtFromCCPersonCode.Text
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      'Employee Name
      dpi = New DocPrintingItem
      dpi.Mapping = "FromCCPersonName"
      dpi.Value = Me.txtFromCCPersonName.Text
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      'from CostCenter Persone Info
      dpi = New DocPrintingItem
      dpi.Mapping = "FromCCPersonInfo"
      dpi.Value = Me.txtFromCCPersonCode.Text & ":" & Me.txtFromCCPersonName.Text
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      Return dpiColl
    End Function
#End Region

#Region " ChangeProperty "
    Private Sub EventWiring()
      AddHandler btnSubcontractStartFind.Click, AddressOf Me.btnSubcontractStartFind_Click
      AddHandler txttoCCCodeStart.Validated, AddressOf Me.ChangeProperty

      AddHandler btnSubcontractEndFind.Click, AddressOf Me.btnSubcontractEndFind_Click
      AddHandler txtSuContractCodeEnd.Validated, AddressOf Me.ChangeProperty

      AddHandler btnDRCodeStartFind.Click, AddressOf Me.btnDRCodeStartFind_Click
      AddHandler txtDRCodeStart.Validated, AddressOf Me.ChangeProperty

      AddHandler btnDRCodeEndFind.Click, AddressOf Me.btnDRCodeEndFind_Click
      AddHandler txtDRCodeEnd.Validated, AddressOf Me.ChangeProperty

      AddHandler btntoCCCodeStart.Click, AddressOf Me.btntoCCCodeStart_Click
      AddHandler txttoCCCodeStart.Validated, AddressOf Me.ChangeProperty

      AddHandler btnfromCCCodeStart.Click, AddressOf Me.btnfromCCCodeStart_Click
      AddHandler txtFromCostCenterCode.Validated, AddressOf Me.ChangeProperty

      AddHandler txtDocDateStart.Validated, AddressOf Me.ChangeProperty
      AddHandler txtDocDateEnd.Validated, AddressOf Me.ChangeProperty

      AddHandler dtpDocDateStart.ValueChanged, AddressOf Me.ChangeProperty
      AddHandler dtpDocDateEnd.ValueChanged, AddressOf Me.ChangeProperty

      AddHandler btnfromCCPersoneStart.Click, AddressOf Me.btnfromCCPersoneStart_Click
      AddHandler txtFromCCPersonCode.Validated, AddressOf Me.ChangeProperty

      'AddHandler btnSpgCodeStart.Click, AddressOf Me.btnSupplierGroupFind_Click

    End Sub

    Private m_dateSetting As Boolean
    Private Sub ChangeProperty(ByVal sender As Object, ByVal e As EventArgs)

      Select Case CType(sender, Control).Name.ToLower
        Case "txttocccodestart"
          CostCenter.GetCostCenter(txttoCCCodeStart, Me.txtCostCenterName, m_tocc, CType(ServiceManager.Services.GetService(GetType(SecurityService)), SecurityService).CurrentUser.Id)
        Case "txtfromcostcentercode"
          CostCenter.GetCostCenter(txtFromCostCenterCode, Me.txtFromCostCenterName, m_tocc, CType(ServiceManager.Services.GetService(GetType(SecurityService)), SecurityService).CurrentUser.Id)
        Case "txtfromccpersoncode"
          CostCenter.GetCostCenter(txtFromCCPersonCode, Me.txtFromCCPersonName, m_tocc, CType(ServiceManager.Services.GetService(GetType(SecurityService)), SecurityService).CurrentUser.Id)

          'Case "txtemployee"
          '    Employee.GetEmployee(txtEmployee, Me.txtEmployeeName, Director)
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
      ' Supplier
      If data.GetDataPresent((New Supplier).FullClassName) Then
        Dim id As Integer = CInt(data.GetData((New Supplier).FullClassName))
        Dim entity As New Supplier(id)
        'If Not Me.ActiveControl Is Nothing Then
        '    Select Case Me.ActiveControl.Name.ToLower
        '        Case "txtsupplicodestart"
        '            Me.SetSupplierStartDialog(entity)

        '        Case "txtsupplicodeend"
        '            Me.SetSupplierEndDialog(entity)

        '    End Select
        'End If
      End If
      ' Costcenter
      'If data.GetDataPresent((New Costcenter).FullClassName) Then
      '    Dim id As Integer = CInt(data.GetData((New Costcenter).FullClassName))
      '    Dim entity As New Costcenter(id)
      '    If Not Me.ActiveControl Is Nothing Then
      '        Select Case Me.ActiveControl.Name.ToLower
      '            Case "txtcostcentercodestart"
      '                Me.SetCCCodeStartDialog(entity)

      '            Case "txtcostcentercodeend"
      '                Me.SetCCCodeStartDialog(entity)

      '        End Select
      '    End If
      'End If
    End Sub
#End Region

#Region " Event Handlers "
    ' Subcontractor
    Private Sub btnSubcontractStartFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
      Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      Select Case CType(sender, Control).Name.ToLower
        Case "btnsubcontractstartfind"
          myEntityPanelService.OpenListDialog(New Supplier, AddressOf SetSupplierStartDialog)

          'Case "btnsubcontractendfind"
          '    myEntityPanelService.OpenListDialog(New Supplier, AddressOf SetSupplierEndDialog)

      End Select
    End Sub
    Private Sub SetSupplierStartDialog(ByVal e As ISimpleEntity)
      Me.txtSuContractCodeStart.Text = e.Code
      Supplier.GetSupplier(txtSuContractCodeStart, txtTemp, Me.Subcontractor)
    End Sub
    Private Sub btnSubcontractEndFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
      Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      Select Case CType(sender, Control).Name.ToLower
        'Case "btnsubcontractendfind"
        '    myEntityPanelService.OpenListDialog(New Supplier, AddressOf SetSupplierStartDialog)

        Case "btnsubcontractendfind"
          myEntityPanelService.OpenListDialog(New Supplier, AddressOf SetSupplierEndDialog)

      End Select
    End Sub
    Private Sub btnDRCodeStartFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
      Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      Select Case CType(sender, Control).Name.ToLower

        Case "btndrcodestartfind"
          myEntityPanelService.OpenListDialog(New DR, AddressOf SetDRStartDialog)

      End Select
    End Sub
    Private Sub btnDRCodeEndFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
      Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      Select Case CType(sender, Control).Name.ToLower

        Case "btndrcodeendfind"
          myEntityPanelService.OpenListDialog(New DR, AddressOf SetDREndDialog)

      End Select
    End Sub
    Private Sub SetSupplierEndDialog(ByVal e As ISimpleEntity)
      Me.txtSuContractCodeEnd.Text = e.Code
      Supplier.GetSupplier(txtSuContractCodeEnd, txtTemp, Me.Subcontractor)
    End Sub
    Private Sub SetDRStartDialog(ByVal e As ISimpleEntity)
      Me.txtDRCodeStart.Text = e.Code
      DR.GetDR(txtDRCodeStart, txtTemp, Me.DRCode)
    End Sub
    Private Sub SetDREndDialog(ByVal e As ISimpleEntity)
      Me.txtDRCodeEnd.Text = e.Code
      DR.GetDR(txtDRCodeEnd, txtTemp, Me.DRCode)
    End Sub
    ' To Costcenter
    Private Sub btntoCCCodeStart_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
      Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      Select Case CType(sender, Control).Name.ToLower
        Case "btntocccodestart"
          myEntityPanelService.OpenTreeDialog(New CostCenter, AddressOf SetToCCCodeStartDialog)
      End Select
    End Sub
    Private Sub SetToCCCodeStartDialog(ByVal e As ISimpleEntity)
      Me.txttoCCCodeStart.Text = e.Code
      CostCenter.GetCostCenter(txttoCCCodeStart, txtCostCenterName, m_tocc, CType(ServiceManager.Services.GetService(GetType(SecurityService)), SecurityService).CurrentUser.Id)
    End Sub
    ' From Cost Center
    Private Sub btnfromCCCodeStart_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
      Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      Select Case CType(sender, Control).Name.ToLower
        Case "btnfromcccodestart"
          myEntityPanelService.OpenTreeDialog(New CostCenter, AddressOf SetFromCCCodeStartDialog)
      End Select
    End Sub
    Private Sub SetFromCCCodeStartDialog(ByVal e As ISimpleEntity)
      Me.txtFromCostCenterCode.Text = e.Code
      CostCenter.GetCostCenter(txtFromCostCenterCode, txtFromCostCenterName, m_tocc, CType(ServiceManager.Services.GetService(GetType(SecurityService)), SecurityService).CurrentUser.Id)
    End Sub
    ' From Person
    Private Sub btnfromCCPersoneStart_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
      Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      Select Case CType(sender, Control).Name.ToLower
        Case "btnfromccpersonestart"
          myEntityPanelService.OpenListDialog(New Employee, AddressOf SetfromCCPersoneStartDialog)

      End Select
    End Sub
    Private Sub SetfromCCPersoneStartDialog(ByVal e As ISimpleEntity)
      Me.txtFromCCPersonCode.Text = e.Code
      Employee.GetEmployee(txtFromCCPersonCode, txtFromCCPersonName, Me.frompersone)
    End Sub


#End Region


    Private Sub ibtnShowSCDialog_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnShowSCDialog.Click
      Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      Select Case CType(sender, Control).Name.ToLower
        Case "ibtnshowscdialog"
          myEntityPanelService.OpenListDialog(New SC, AddressOf SetSCDialog)
      End Select
    End Sub

    Private Sub SetSCDialog(ByVal e As ISimpleEntity)
      Me.txtSCCode.Text = e.Code
    End Sub

  End Class
End Namespace

