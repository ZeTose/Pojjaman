Imports Longkong.Pojjaman.BusinessLogic
Imports Longkong.Pojjaman.Services
Imports Longkong.Core.Services
Imports System.Collections.Generic

Namespace Longkong.Pojjaman.Gui.Panels
  Public Class RptWBSMonitorFilterSubPanel
    Inherits AbstractFilterSubPanel
    Implements IReportFilterSubPanel, iAdvanceFind

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
    Friend WithEvents txtDocDateEnd As System.Windows.Forms.TextBox
    Friend WithEvents dtpDocDateEnd As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblDocDateEnd As System.Windows.Forms.Label
    Friend WithEvents btnShowCostCenter As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents txtCostCenterCode As System.Windows.Forms.TextBox
    Friend WithEvents lblCostCenter As System.Windows.Forms.Label
    Friend WithEvents txtCostCenterName As System.Windows.Forms.TextBox
    Friend WithEvents cmbType As System.Windows.Forms.ComboBox
    Friend WithEvents lblType As System.Windows.Forms.Label
    Friend WithEvents cmbReportType As System.Windows.Forms.ComboBox
    Friend WithEvents lblReportType As System.Windows.Forms.Label
    Friend WithEvents chkNoDigit As System.Windows.Forms.CheckBox
    Friend WithEvents cmbDetailed As System.Windows.Forms.ComboBox
    Friend WithEvents lblDetailed As System.Windows.Forms.Label
    Friend WithEvents btnShowRequestor As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents txtRequestorCode As System.Windows.Forms.TextBox
    Friend WithEvents txtRequestorName As System.Windows.Forms.TextBox
    Friend WithEvents lblRequestor As System.Windows.Forms.Label
    Friend WithEvents btnWBS As System.Windows.Forms.Button
    Friend WithEvents grbPeriod As System.Windows.Forms.GroupBox
    Friend WithEvents txtDocEndDate As System.Windows.Forms.TextBox
    Friend WithEvents dtpDocEndDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblDocEndDate As System.Windows.Forms.Label
    Friend WithEvents txtDocStartDate As System.Windows.Forms.TextBox
    Friend WithEvents dtpDocStartDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblDocStartDate As System.Windows.Forms.Label
    Friend WithEvents grbFilterDoc As Longkong.Pojjaman.Gui.Components.FixedGroupBox
    Friend WithEvents btnDocTypeList As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents txtDoctypeList As System.Windows.Forms.TextBox
    Friend WithEvents lblWBS As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
      Me.components = New System.ComponentModel.Container()
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(RptWBSMonitorFilterSubPanel))
      Me.grbMaster = New Longkong.Pojjaman.Gui.Components.FixedGroupBox()
      Me.grbFilterDoc = New Longkong.Pojjaman.Gui.Components.FixedGroupBox()
      Me.btnDocTypeList = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.txtDoctypeList = New System.Windows.Forms.TextBox()
      Me.grbPeriod = New System.Windows.Forms.GroupBox()
      Me.txtDocEndDate = New System.Windows.Forms.TextBox()
      Me.dtpDocEndDate = New System.Windows.Forms.DateTimePicker()
      Me.lblDocEndDate = New System.Windows.Forms.Label()
      Me.txtDocStartDate = New System.Windows.Forms.TextBox()
      Me.dtpDocStartDate = New System.Windows.Forms.DateTimePicker()
      Me.lblDocStartDate = New System.Windows.Forms.Label()
      Me.grbDetail = New Longkong.Pojjaman.Gui.Components.FixedGroupBox()
      Me.btnWBS = New System.Windows.Forms.Button()
      Me.lblWBS = New System.Windows.Forms.Label()
      Me.btnShowRequestor = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.txtRequestorCode = New System.Windows.Forms.TextBox()
      Me.lblRequestor = New System.Windows.Forms.Label()
      Me.cmbDetailed = New System.Windows.Forms.ComboBox()
      Me.lblReportType = New System.Windows.Forms.Label()
      Me.cmbReportType = New System.Windows.Forms.ComboBox()
      Me.cmbType = New System.Windows.Forms.ComboBox()
      Me.txtDocDateEnd = New System.Windows.Forms.TextBox()
      Me.dtpDocDateEnd = New System.Windows.Forms.DateTimePicker()
      Me.lblDocDateEnd = New System.Windows.Forms.Label()
      Me.btnShowCostCenter = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.txtCostCenterCode = New System.Windows.Forms.TextBox()
      Me.lblCostCenter = New System.Windows.Forms.Label()
      Me.txtCostCenterName = New System.Windows.Forms.TextBox()
      Me.lblType = New System.Windows.Forms.Label()
      Me.chkNoDigit = New System.Windows.Forms.CheckBox()
      Me.lblDetailed = New System.Windows.Forms.Label()
      Me.txtRequestorName = New System.Windows.Forms.TextBox()
      Me.btnSearch = New System.Windows.Forms.Button()
      Me.btnReset = New System.Windows.Forms.Button()
      Me.Validator = New Longkong.Pojjaman.Gui.Components.PJMTextboxValidator(Me.components)
      Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
      Me.grbMaster.SuspendLayout()
      Me.grbFilterDoc.SuspendLayout()
      Me.grbPeriod.SuspendLayout()
      Me.grbDetail.SuspendLayout()
      CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.SuspendLayout()
      '
      'grbMaster
      '
      Me.grbMaster.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                  Or System.Windows.Forms.AnchorStyles.Left) _
                  Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.grbMaster.Controls.Add(Me.grbFilterDoc)
      Me.grbMaster.Controls.Add(Me.grbPeriod)
      Me.grbMaster.Controls.Add(Me.grbDetail)
      Me.grbMaster.Controls.Add(Me.btnSearch)
      Me.grbMaster.Controls.Add(Me.btnReset)
      Me.grbMaster.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.grbMaster.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.grbMaster.Location = New System.Drawing.Point(8, 8)
      Me.grbMaster.Name = "grbMaster"
      Me.grbMaster.Size = New System.Drawing.Size(738, 248)
      Me.grbMaster.TabIndex = 0
      Me.grbMaster.TabStop = False
      Me.grbMaster.Text = "ค้นหา"
      '
      'grbFilterDoc
      '
      Me.grbFilterDoc.Controls.Add(Me.btnDocTypeList)
      Me.grbFilterDoc.Controls.Add(Me.txtDoctypeList)
      Me.grbFilterDoc.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.grbFilterDoc.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.grbFilterDoc.Location = New System.Drawing.Point(471, 92)
      Me.grbFilterDoc.Name = "grbFilterDoc"
      Me.grbFilterDoc.Size = New System.Drawing.Size(214, 116)
      Me.grbFilterDoc.TabIndex = 21
      Me.grbFilterDoc.TabStop = False
      Me.grbFilterDoc.Text = "กรองเอกสาร"
      '
      'btnDocTypeList
      '
      Me.btnDocTypeList.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnDocTypeList.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.btnDocTypeList.Location = New System.Drawing.Point(177, 18)
      Me.btnDocTypeList.Name = "btnDocTypeList"
      Me.btnDocTypeList.Size = New System.Drawing.Size(24, 23)
      Me.btnDocTypeList.TabIndex = 2
      Me.btnDocTypeList.TabStop = False
      Me.btnDocTypeList.ThemedImage = CType(resources.GetObject("btnDocTypeList.ThemedImage"), System.Drawing.Bitmap)
      '
      'txtDoctypeList
      '
      Me.Validator.SetDataType(Me.txtDoctypeList, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtDoctypeList, "")
      Me.txtDoctypeList.Enabled = False
      Me.txtDoctypeList.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtDoctypeList, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtDoctypeList, -15)
      Me.Validator.SetInvalidBackColor(Me.txtDoctypeList, System.Drawing.Color.Empty)
      Me.txtDoctypeList.Location = New System.Drawing.Point(10, 20)
      Me.Validator.SetMinValue(Me.txtDoctypeList, "")
      Me.txtDoctypeList.Name = "txtDoctypeList"
      Me.txtDoctypeList.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtDoctypeList, "")
      Me.Validator.SetRequired(Me.txtDoctypeList, False)
      Me.txtDoctypeList.Size = New System.Drawing.Size(166, 21)
      Me.txtDoctypeList.TabIndex = 23
      Me.txtDoctypeList.TabStop = False
      Me.txtDoctypeList.Text = "ทุกชนิดเอกสาร"
      '
      'grbPeriod
      '
      Me.grbPeriod.Controls.Add(Me.txtDocEndDate)
      Me.grbPeriod.Controls.Add(Me.dtpDocEndDate)
      Me.grbPeriod.Controls.Add(Me.lblDocEndDate)
      Me.grbPeriod.Controls.Add(Me.txtDocStartDate)
      Me.grbPeriod.Controls.Add(Me.dtpDocStartDate)
      Me.grbPeriod.Controls.Add(Me.lblDocStartDate)
      Me.grbPeriod.Location = New System.Drawing.Point(471, 16)
      Me.grbPeriod.Name = "grbPeriod"
      Me.grbPeriod.Size = New System.Drawing.Size(214, 70)
      Me.grbPeriod.TabIndex = 3
      Me.grbPeriod.TabStop = False
      Me.grbPeriod.Text = "ต้องการเป็นช่วงเวลา"
      '
      'txtDocEndDate
      '
      Me.Validator.SetDataType(Me.txtDocEndDate, Longkong.Pojjaman.Gui.Components.DataTypeConstants.DateTimeType)
      Me.Validator.SetDisplayName(Me.txtDocEndDate, "")
      Me.Validator.SetGotFocusBackColor(Me.txtDocEndDate, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtDocEndDate, -15)
      Me.Validator.SetInvalidBackColor(Me.txtDocEndDate, System.Drawing.Color.Empty)
      Me.txtDocEndDate.Location = New System.Drawing.Point(87, 40)
      Me.txtDocEndDate.MaxLength = 10
      Me.Validator.SetMinValue(Me.txtDocEndDate, "")
      Me.txtDocEndDate.Name = "txtDocEndDate"
      Me.Validator.SetRegularExpression(Me.txtDocEndDate, "")
      Me.Validator.SetRequired(Me.txtDocEndDate, False)
      Me.txtDocEndDate.Size = New System.Drawing.Size(99, 21)
      Me.txtDocEndDate.TabIndex = 23
      '
      'dtpDocEndDate
      '
      Me.dtpDocEndDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
      Me.dtpDocEndDate.Location = New System.Drawing.Point(87, 40)
      Me.dtpDocEndDate.Name = "dtpDocEndDate"
      Me.dtpDocEndDate.Size = New System.Drawing.Size(120, 21)
      Me.dtpDocEndDate.TabIndex = 25
      Me.dtpDocEndDate.TabStop = False
      '
      'lblDocEndDate
      '
      Me.lblDocEndDate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblDocEndDate.ForeColor = System.Drawing.Color.Black
      Me.lblDocEndDate.Location = New System.Drawing.Point(9, 40)
      Me.lblDocEndDate.Name = "lblDocEndDate"
      Me.lblDocEndDate.Size = New System.Drawing.Size(78, 18)
      Me.lblDocEndDate.TabIndex = 24
      Me.lblDocEndDate.Text = "ถึงวันที่:"
      Me.lblDocEndDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'txtDocStartDate
      '
      Me.Validator.SetDataType(Me.txtDocStartDate, Longkong.Pojjaman.Gui.Components.DataTypeConstants.DateTimeType)
      Me.Validator.SetDisplayName(Me.txtDocStartDate, "")
      Me.Validator.SetGotFocusBackColor(Me.txtDocStartDate, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtDocStartDate, -15)
      Me.Validator.SetInvalidBackColor(Me.txtDocStartDate, System.Drawing.Color.Empty)
      Me.txtDocStartDate.Location = New System.Drawing.Point(87, 18)
      Me.txtDocStartDate.MaxLength = 10
      Me.Validator.SetMinValue(Me.txtDocStartDate, "")
      Me.txtDocStartDate.Name = "txtDocStartDate"
      Me.Validator.SetRegularExpression(Me.txtDocStartDate, "")
      Me.Validator.SetRequired(Me.txtDocStartDate, False)
      Me.txtDocStartDate.Size = New System.Drawing.Size(99, 21)
      Me.txtDocStartDate.TabIndex = 20
      '
      'dtpDocStartDate
      '
      Me.dtpDocStartDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
      Me.dtpDocStartDate.Location = New System.Drawing.Point(86, 18)
      Me.dtpDocStartDate.Name = "dtpDocStartDate"
      Me.dtpDocStartDate.Size = New System.Drawing.Size(120, 21)
      Me.dtpDocStartDate.TabIndex = 22
      Me.dtpDocStartDate.TabStop = False
      '
      'lblDocStartDate
      '
      Me.lblDocStartDate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblDocStartDate.ForeColor = System.Drawing.Color.Black
      Me.lblDocStartDate.Location = New System.Drawing.Point(13, 18)
      Me.lblDocStartDate.Name = "lblDocStartDate"
      Me.lblDocStartDate.Size = New System.Drawing.Size(74, 18)
      Me.lblDocStartDate.TabIndex = 21
      Me.lblDocStartDate.Text = "จากวันที่:"
      Me.lblDocStartDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'grbDetail
      '
      Me.grbDetail.Controls.Add(Me.btnWBS)
      Me.grbDetail.Controls.Add(Me.lblWBS)
      Me.grbDetail.Controls.Add(Me.btnShowRequestor)
      Me.grbDetail.Controls.Add(Me.txtRequestorCode)
      Me.grbDetail.Controls.Add(Me.lblRequestor)
      Me.grbDetail.Controls.Add(Me.cmbDetailed)
      Me.grbDetail.Controls.Add(Me.lblReportType)
      Me.grbDetail.Controls.Add(Me.cmbReportType)
      Me.grbDetail.Controls.Add(Me.cmbType)
      Me.grbDetail.Controls.Add(Me.txtDocDateEnd)
      Me.grbDetail.Controls.Add(Me.dtpDocDateEnd)
      Me.grbDetail.Controls.Add(Me.lblDocDateEnd)
      Me.grbDetail.Controls.Add(Me.btnShowCostCenter)
      Me.grbDetail.Controls.Add(Me.txtCostCenterCode)
      Me.grbDetail.Controls.Add(Me.lblCostCenter)
      Me.grbDetail.Controls.Add(Me.txtCostCenterName)
      Me.grbDetail.Controls.Add(Me.lblType)
      Me.grbDetail.Controls.Add(Me.chkNoDigit)
      Me.grbDetail.Controls.Add(Me.lblDetailed)
      Me.grbDetail.Controls.Add(Me.txtRequestorName)
      Me.grbDetail.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.grbDetail.Location = New System.Drawing.Point(16, 16)
      Me.grbDetail.Name = "grbDetail"
      Me.grbDetail.Size = New System.Drawing.Size(448, 192)
      Me.grbDetail.TabIndex = 0
      Me.grbDetail.TabStop = False
      Me.grbDetail.Text = "ข้อมูลทั่วไป"
      '
      'btnWBS
      '
      Me.btnWBS.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnWBS.Location = New System.Drawing.Point(160, 112)
      Me.btnWBS.Name = "btnWBS"
      Me.btnWBS.Size = New System.Drawing.Size(88, 24)
      Me.btnWBS.TabIndex = 19
      Me.btnWBS.Text = "เลือก"
      '
      'lblWBS
      '
      Me.lblWBS.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblWBS.ForeColor = System.Drawing.Color.Black
      Me.lblWBS.Location = New System.Drawing.Point(24, 112)
      Me.lblWBS.Name = "lblWBS"
      Me.lblWBS.Size = New System.Drawing.Size(136, 18)
      Me.lblWBS.TabIndex = 18
      Me.lblWBS.Text = "WBS:"
      Me.lblWBS.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'btnShowRequestor
      '
      Me.btnShowRequestor.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnShowRequestor.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.btnShowRequestor.ForeColor = System.Drawing.SystemColors.Control
      Me.btnShowRequestor.Location = New System.Drawing.Point(416, 136)
      Me.btnShowRequestor.Name = "btnShowRequestor"
      Me.btnShowRequestor.Size = New System.Drawing.Size(24, 22)
      Me.btnShowRequestor.TabIndex = 15
      Me.btnShowRequestor.TabStop = False
      Me.btnShowRequestor.ThemedImage = CType(resources.GetObject("btnShowRequestor.ThemedImage"), System.Drawing.Bitmap)
      '
      'txtRequestorCode
      '
      Me.Validator.SetDataType(Me.txtRequestorCode, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtRequestorCode, "")
      Me.txtRequestorCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtRequestorCode, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtRequestorCode, -15)
      Me.Validator.SetInvalidBackColor(Me.txtRequestorCode, System.Drawing.Color.Empty)
      Me.txtRequestorCode.Location = New System.Drawing.Point(160, 136)
      Me.Validator.SetMinValue(Me.txtRequestorCode, "")
      Me.txtRequestorCode.Name = "txtRequestorCode"
      Me.Validator.SetRegularExpression(Me.txtRequestorCode, "")
      Me.Validator.SetRequired(Me.txtRequestorCode, False)
      Me.txtRequestorCode.Size = New System.Drawing.Size(72, 21)
      Me.txtRequestorCode.TabIndex = 4
      '
      'lblRequestor
      '
      Me.lblRequestor.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblRequestor.ForeColor = System.Drawing.Color.Black
      Me.lblRequestor.Location = New System.Drawing.Point(8, 136)
      Me.lblRequestor.Name = "lblRequestor"
      Me.lblRequestor.Size = New System.Drawing.Size(152, 18)
      Me.lblRequestor.TabIndex = 11
      Me.lblRequestor.Text = "ผู้ทำรายการ:"
      Me.lblRequestor.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'cmbDetailed
      '
      Me.cmbDetailed.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbDetailed.Location = New System.Drawing.Point(160, 160)
      Me.cmbDetailed.Name = "cmbDetailed"
      Me.cmbDetailed.Size = New System.Drawing.Size(120, 21)
      Me.cmbDetailed.TabIndex = 5
      '
      'lblReportType
      '
      Me.lblReportType.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblReportType.ForeColor = System.Drawing.Color.Black
      Me.lblReportType.Location = New System.Drawing.Point(8, 40)
      Me.lblReportType.Name = "lblReportType"
      Me.lblReportType.Size = New System.Drawing.Size(152, 18)
      Me.lblReportType.TabIndex = 8
      Me.lblReportType.Text = "ประเภทรายงาน"
      Me.lblReportType.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'cmbReportType
      '
      Me.cmbReportType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbReportType.Location = New System.Drawing.Point(160, 40)
      Me.cmbReportType.Name = "cmbReportType"
      Me.cmbReportType.Size = New System.Drawing.Size(121, 21)
      Me.cmbReportType.TabIndex = 1
      '
      'cmbType
      '
      Me.cmbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbType.Enabled = False
      Me.cmbType.Location = New System.Drawing.Point(160, 16)
      Me.cmbType.Name = "cmbType"
      Me.cmbType.Size = New System.Drawing.Size(121, 21)
      Me.cmbType.TabIndex = 0
      '
      'txtDocDateEnd
      '
      Me.Validator.SetDataType(Me.txtDocDateEnd, Longkong.Pojjaman.Gui.Components.DataTypeConstants.DateTimeType)
      Me.Validator.SetDisplayName(Me.txtDocDateEnd, "")
      Me.Validator.SetGotFocusBackColor(Me.txtDocDateEnd, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtDocDateEnd, -15)
      Me.Validator.SetInvalidBackColor(Me.txtDocDateEnd, System.Drawing.Color.Empty)
      Me.txtDocDateEnd.Location = New System.Drawing.Point(160, 64)
      Me.txtDocDateEnd.MaxLength = 10
      Me.Validator.SetMinValue(Me.txtDocDateEnd, "")
      Me.txtDocDateEnd.Name = "txtDocDateEnd"
      Me.Validator.SetRegularExpression(Me.txtDocDateEnd, "")
      Me.Validator.SetRequired(Me.txtDocDateEnd, False)
      Me.txtDocDateEnd.Size = New System.Drawing.Size(99, 21)
      Me.txtDocDateEnd.TabIndex = 2
      '
      'dtpDocDateEnd
      '
      Me.dtpDocDateEnd.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
      Me.dtpDocDateEnd.Location = New System.Drawing.Point(160, 64)
      Me.dtpDocDateEnd.Name = "dtpDocDateEnd"
      Me.dtpDocDateEnd.Size = New System.Drawing.Size(120, 21)
      Me.dtpDocDateEnd.TabIndex = 17
      Me.dtpDocDateEnd.TabStop = False
      '
      'lblDocDateEnd
      '
      Me.lblDocDateEnd.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblDocDateEnd.ForeColor = System.Drawing.Color.Black
      Me.lblDocDateEnd.Location = New System.Drawing.Point(8, 64)
      Me.lblDocDateEnd.Name = "lblDocDateEnd"
      Me.lblDocDateEnd.Size = New System.Drawing.Size(152, 18)
      Me.lblDocDateEnd.TabIndex = 9
      Me.lblDocDateEnd.Text = "เรียกข้อมูลถึงวันที่:"
      Me.lblDocDateEnd.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'btnShowCostCenter
      '
      Me.btnShowCostCenter.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnShowCostCenter.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.btnShowCostCenter.ForeColor = System.Drawing.SystemColors.Control
      Me.btnShowCostCenter.Location = New System.Drawing.Point(416, 88)
      Me.btnShowCostCenter.Name = "btnShowCostCenter"
      Me.btnShowCostCenter.Size = New System.Drawing.Size(24, 22)
      Me.btnShowCostCenter.TabIndex = 16
      Me.btnShowCostCenter.TabStop = False
      Me.btnShowCostCenter.ThemedImage = CType(resources.GetObject("btnShowCostCenter.ThemedImage"), System.Drawing.Bitmap)
      '
      'txtCostCenterCode
      '
      Me.Validator.SetDataType(Me.txtCostCenterCode, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtCostCenterCode, "")
      Me.txtCostCenterCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtCostCenterCode, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtCostCenterCode, -15)
      Me.Validator.SetInvalidBackColor(Me.txtCostCenterCode, System.Drawing.Color.Empty)
      Me.txtCostCenterCode.Location = New System.Drawing.Point(160, 88)
      Me.Validator.SetMinValue(Me.txtCostCenterCode, "")
      Me.txtCostCenterCode.Name = "txtCostCenterCode"
      Me.Validator.SetRegularExpression(Me.txtCostCenterCode, "")
      Me.Validator.SetRequired(Me.txtCostCenterCode, False)
      Me.txtCostCenterCode.Size = New System.Drawing.Size(72, 21)
      Me.txtCostCenterCode.TabIndex = 3
      '
      'lblCostCenter
      '
      Me.lblCostCenter.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblCostCenter.ForeColor = System.Drawing.Color.Black
      Me.lblCostCenter.Location = New System.Drawing.Point(8, 88)
      Me.lblCostCenter.Name = "lblCostCenter"
      Me.lblCostCenter.Size = New System.Drawing.Size(152, 18)
      Me.lblCostCenter.TabIndex = 10
      Me.lblCostCenter.Text = "Cost Center:"
      Me.lblCostCenter.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'txtCostCenterName
      '
      Me.Validator.SetDataType(Me.txtCostCenterName, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtCostCenterName, "")
      Me.txtCostCenterName.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtCostCenterName, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtCostCenterName, -15)
      Me.Validator.SetInvalidBackColor(Me.txtCostCenterName, System.Drawing.Color.Empty)
      Me.txtCostCenterName.Location = New System.Drawing.Point(232, 88)
      Me.Validator.SetMinValue(Me.txtCostCenterName, "")
      Me.txtCostCenterName.Name = "txtCostCenterName"
      Me.txtCostCenterName.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtCostCenterName, "")
      Me.Validator.SetRequired(Me.txtCostCenterName, False)
      Me.txtCostCenterName.Size = New System.Drawing.Size(184, 21)
      Me.txtCostCenterName.TabIndex = 13
      '
      'lblType
      '
      Me.lblType.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblType.ForeColor = System.Drawing.Color.Black
      Me.lblType.Location = New System.Drawing.Point(8, 16)
      Me.lblType.Name = "lblType"
      Me.lblType.Size = New System.Drawing.Size(152, 18)
      Me.lblType.TabIndex = 7
      Me.lblType.Text = "รายงาน:"
      Me.lblType.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'chkNoDigit
      '
      Me.chkNoDigit.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.chkNoDigit.Location = New System.Drawing.Point(296, 160)
      Me.chkNoDigit.Name = "chkNoDigit"
      Me.chkNoDigit.Size = New System.Drawing.Size(120, 24)
      Me.chkNoDigit.TabIndex = 6
      Me.chkNoDigit.Text = "ไม่แสดงทศนิยม"
      '
      'lblDetailed
      '
      Me.lblDetailed.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblDetailed.ForeColor = System.Drawing.Color.Black
      Me.lblDetailed.Location = New System.Drawing.Point(8, 160)
      Me.lblDetailed.Name = "lblDetailed"
      Me.lblDetailed.Size = New System.Drawing.Size(152, 18)
      Me.lblDetailed.TabIndex = 12
      Me.lblDetailed.Text = "การแสดงรายละเอียด:"
      Me.lblDetailed.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'txtRequestorName
      '
      Me.Validator.SetDataType(Me.txtRequestorName, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtRequestorName, "")
      Me.txtRequestorName.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtRequestorName, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtRequestorName, -15)
      Me.Validator.SetInvalidBackColor(Me.txtRequestorName, System.Drawing.Color.Empty)
      Me.txtRequestorName.Location = New System.Drawing.Point(232, 136)
      Me.Validator.SetMinValue(Me.txtRequestorName, "")
      Me.txtRequestorName.Name = "txtRequestorName"
      Me.txtRequestorName.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtRequestorName, "")
      Me.Validator.SetRequired(Me.txtRequestorName, False)
      Me.txtRequestorName.Size = New System.Drawing.Size(184, 21)
      Me.txtRequestorName.TabIndex = 14
      '
      'btnSearch
      '
      Me.btnSearch.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnSearch.Location = New System.Drawing.Point(642, 216)
      Me.btnSearch.Name = "btnSearch"
      Me.btnSearch.Size = New System.Drawing.Size(80, 23)
      Me.btnSearch.TabIndex = 2
      Me.btnSearch.Text = "ค้นหา"
      '
      'btnReset
      '
      Me.btnReset.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnReset.Location = New System.Drawing.Point(554, 216)
      Me.btnReset.Name = "btnReset"
      Me.btnReset.Size = New System.Drawing.Size(80, 23)
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
      'RptWBSMonitorFilterSubPanel
      '
      Me.Controls.Add(Me.grbMaster)
      Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Name = "RptWBSMonitorFilterSubPanel"
      Me.Size = New System.Drawing.Size(754, 264)
      Me.grbMaster.ResumeLayout(False)
      Me.grbFilterDoc.ResumeLayout(False)
      Me.grbFilterDoc.PerformLayout()
      Me.grbPeriod.ResumeLayout(False)
      Me.grbPeriod.PerformLayout()
      Me.grbDetail.ResumeLayout(False)
      Me.grbDetail.PerformLayout()
      CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
      Me.ResumeLayout(False)

    End Sub

#End Region

#Region " SetLabelText "
    Public Sub SetLabelText()

      Me.lblType.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptWBSMonitorFilterSubPanel.lblType}")

      Me.lblCostCenter.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptWBSMonitorFilterSubPanel.lblCostCenter}")
      Me.Validator.SetDisplayName(txtCostCenterCode, lblCostCenter.Text)

      Me.lblRequestor.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptWBSMonitorFilterSubPanel.lblRequestor}")
      Me.Validator.SetDisplayName(txtRequestorCode, lblRequestor.Text)

      ' Global {ถึง}
      Me.lblDocDateEnd.Text = Me.StringParserService.Parse("${res:Global.FilterPanelTo}")
      Me.Validator.SetDisplayName(txtDocDateEnd, lblDocDateEnd.Text)

      ' Button
      Me.btnSearch.Text = Me.StringParserService.Parse("${res:Global.SearchButtonText}")
      Me.btnReset.Text = Me.StringParserService.Parse("${res:Global.ResetButtonText}")

      ' GroupBox
      Me.grbMaster.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptWBSMonitorFilterSubPanel.grbMaster}")
      Me.grbDetail.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptWBSMonitorFilterSubPanel.grbDetail}")

      Me.lblDetailed.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptWBSMonitorFilterSubPanel.chkDetailed}")
      Me.chkNoDigit.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptWBSMonitorFilterSubPanel.chkNoDigit}")
    End Sub
#End Region

#Region "Member"
    Private m_DocDateEnd As Date
    Private m_DocDateStart As Date
    Private m_cc As CostCenter
    Private m_requestor As Employee

    Private advfColl As New AdvanceFindCollection
    Private advanceFindString As String
    Private advanceFindWbsLevel As String

    Private advanceValueString As String
    Private advanceFindLCI As String

    Private DocList As String
    Private DocIdList As String
    Private DocIndexList As String
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

    Public Property DocDateEnd() As Date      Get        Return m_DocDateEnd      End Get      Set(ByVal Value As Date)        m_DocDateEnd = Value      End Set    End Property    Public Property DocDateStart() As Date      Get        Return m_DocDateStart      End Get      Set(ByVal Value As Date)        m_DocDateStart = Value      End Set    End Property    Public Property AdvanceFindCollection() As BusinessLogic.AdvanceFindCollection Implements BusinessLogic.iAdvanceFind.AdvanceFindCollection
      Get
        Return advfColl
      End Get
      Set(ByVal Value As BusinessLogic.AdvanceFindCollection)
        advfColl = Value
      End Set
    End Property#End Region

#Region "Methods"
    Private Sub LoadCombo()
      CodeDescription.ListCodeDescriptionInComboBox(Me.cmbType, "CostControlReportType")
      With cmbReportType
        .Items.Clear()
        .Items.Add("ขอซื้อ")
        .Items.Add("สั่งซื้อ")
        .Items.Add("รับของ")
        .Items.Add("เบิกของ")
        .SelectedIndex = 0
      End With

    End Sub
    Private Sub Initialize()
      RegisterDropdown()
      LoadCombo()
      ClearCriterias()
    End Sub
    Private Sub RegisterDropdown()
      ' รูปแบบ
      With cmbDetailed.Items
        .Add("ไม่แสดงรายการ")
        .Add("แสดงรายการ")
        .Add("แสดงรายการวัสดุ")
      End With
      cmbDetailed.SelectedIndex = 0
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
      m_dateSetting = True

      Me.DocDateStart = Date.MinValue
      Me.txtDocStartDate.Text = MinDateToNull(Me.DocDateStart, "")
      Me.dtpDocStartDate.Value = Date.Now

      Me.DocDateEnd = Date.Now
      Me.txtDocDateEnd.Text = MinDateToNull(Me.DocDateEnd, "")
      Me.dtpDocDateEnd.Value = Me.DocDateEnd

      Me.txtDocEndDate.Text = MinDateToNull(Me.DocDateEnd, "")
      Me.dtpDocEndDate.Value = Me.DocDateEnd

      Me.DocIndexList = ""
      Me.DocIdList = ""

      m_cc = New CostCenter
      m_requestor = New Employee
      Try
        If Me.cmbType.Items.Count > 0 Then
          Me.cmbType.SelectedIndex = 1
        End If
        If Me.cmbReportType.Items.Count > 0 Then
          Me.cmbReportType.SelectedIndex = 0
        End If
      Catch ex As Exception

      End Try
    End Sub
    Public Overrides Function GetFilterString() As String

    End Function
    Public Overrides Function GetFilterArray() As Filter()
      

      Dim arr(11) As Filter
      If Me.txtCostCenterCode.Text.Length = 0 Then
        arr(0) = New Filter("cc", DBNull.Value)
      Else
        arr(0) = New Filter("cc", m_cc)
      End If
      arr(1) = New Filter("DocDateEnd", IIf(Me.DocDateEnd.Equals(Date.MinValue), DBNull.Value, Me.DocDateEnd))
      arr(2) = New Filter("type", IIf(cmbType.SelectedItem Is Nothing, 0, CType(cmbType.SelectedItem, IdValuePair).Id))
      Dim type As BOQ.WBSReportType = BOQ.WBSReportType.GoodsReceipt
      Select Case cmbReportType.SelectedIndex
        Case 0
          type = BOQ.WBSReportType.PR
        Case 1
          type = BOQ.WBSReportType.PO
        Case 2
          type = BOQ.WBSReportType.GoodsReceipt
        Case 3
          type = BOQ.WBSReportType.MatWithdraw
      End Select
      arr(3) = New Filter("WBSReportType", type)
      arr(4) = New Filter("Detailed", cmbDetailed.SelectedIndex)
      arr(5) = New Filter("NoDigit", Me.chkNoDigit.Checked)
      arr(6) = New Filter("requestor", Me.ValidIdOrDBNull(m_requestor))
      arr(7) = New Filter("advanceFindString", advanceFindString)
      arr(8) = New Filter("advanceValueString", advanceValueString)
      arr(9) = New Filter("advanceFindLCI", advanceFindLCI)
      arr(10) = New Filter("DocDateStart", IIf(Me.DocDateStart.Equals(Date.MinValue), DBNull.Value, Me.DocDateStart))
      arr(11) = New Filter("DocTypeList", DocIdList)
      Return arr
    End Function
    Public Overrides ReadOnly Property SearchButton() As System.Windows.Forms.Button
      Get
        Return Me.btnSearch
      End Get
    End Property

    Private Sub btnReset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReset.Click
      ClearCriterias()
      Me.AdvanceFindCollection.Clear()
      Me.btnSearch.PerformClick()
    End Sub
#End Region

#Region "IReportFilterSubPanel"
    Public Function GetFixValueCollection() As BusinessLogic.DocPrintingItemCollection Implements IReportFilterSubPanel.GetFixValueCollection

    End Function
#End Region

#Region " ChangeProperty "
    Private Sub EventWiring()
      AddHandler txtDocDateEnd.Validated, AddressOf Me.ChangeProperty
      AddHandler dtpDocDateEnd.ValueChanged, AddressOf Me.ChangeProperty
      AddHandler txtDocEndDate.Validated, AddressOf Me.ChangeProperty
      AddHandler dtpDocEndDate.ValueChanged, AddressOf Me.ChangeProperty
      AddHandler txtDocStartDate.Validated, AddressOf Me.ChangeProperty
      AddHandler dtpDocStartDate.ValueChanged, AddressOf Me.ChangeProperty
    End Sub

    Private m_dateSetting As Boolean
    Private Sub ChangeProperty(ByVal sender As Object, ByVal e As EventArgs)

      Select Case CType(sender, Control).Name.ToLower
        Case "dtpdocdateend"
          If Not Me.DocDateEnd.Equals(dtpDocDateEnd.Value) Then
            If Not m_dateSetting Then
              Me.txtDocDateEnd.Text = MinDateToNull(dtpDocDateEnd.Value, Me.StringParserService.Parse("${res:Global.BlankDateText}"))
              Me.DocDateEnd = dtpDocDateEnd.Value
              Me.txtDocEndDate.Text = MinDateToNull(Me.DocDateEnd, Me.StringParserService.Parse("${res:Global.BlankDateText}"))
            End If
          End If
          m_dateSetting = False
        Case "txtdocdateend"
          m_dateSetting = True
          If Not Me.txtDocDateEnd.Text.Length = 0 AndAlso Me.Validator.GetErrorMessage(Me.txtDocDateEnd) = "" Then
            Dim theDate As Date = CDate(Me.txtDocDateEnd.Text)
            If Not Me.DocDateEnd.Equals(theDate) Then
              dtpDocDateEnd.Value = theDate
              Me.DocDateEnd = dtpDocDateEnd.Value
              Me.txtDocEndDate.Text = MinDateToNull(Me.DocDateEnd, Me.StringParserService.Parse("${res:Global.BlankDateText}"))
            End If
          Else
            Me.dtpDocDateEnd.Value = Date.Now
            Me.DocDateEnd = Date.MinValue
          End If
          m_dateSetting = False
        Case "dtpdocenddate"
          If Not Me.DocDateEnd.Equals(dtpDocEndDate.Value) Then
            If Not m_dateSetting Then
              Me.txtDocEndDate.Text = MinDateToNull(dtpDocEndDate.Value, Me.StringParserService.Parse("${res:Global.BlankDateText}"))
              Me.txtDocDateEnd.Text = MinDateToNull(dtpDocEndDate.Value, Me.StringParserService.Parse("${res:Global.BlankDateText}"))
              Me.DocDateEnd = dtpDocEndDate.Value
            End If
          End If
          m_dateSetting = False
        Case "txtdocenddate"
          m_dateSetting = True
          If Not Me.txtDocEndDate.Text.Length = 0 AndAlso Me.Validator.GetErrorMessage(Me.txtDocEndDate) = "" Then
            Dim theDate As Date = CDate(Me.txtDocEndDate.Text)
            If Not Me.DocDateEnd.Equals(theDate) Then
              dtpDocEndDate.Value = theDate
              Me.txtDocDateEnd.Text = MinDateToNull(dtpDocEndDate.Value, Me.StringParserService.Parse("${res:Global.BlankDateText}"))
              Me.DocDateEnd = dtpDocEndDate.Value
              Me.txtDocEndDate.Text = MinDateToNull(Me.DocDateEnd, Me.StringParserService.Parse("${res:Global.BlankDateText}"))
            End If
          Else
            Me.dtpDocDateEnd.Value = Date.Now
            Me.DocDateEnd = Date.MinValue
          End If
          m_dateSetting = False
        Case "dtpdocstartdate"
          If Not Me.DocDateStart.Equals(dtpDocStartDate.Value) Then
            If Not m_dateSetting Then
              Me.txtDocStartDate.Text = MinDateToNull(dtpDocStartDate.Value, Me.StringParserService.Parse("${res:Global.BlankDateText}"))
              Me.DocDateStart = dtpDocStartDate.Value
            End If
          End If
          m_dateSetting = False
        Case "txtdocstartdate"
          m_dateSetting = True
          If Not Me.txtDocStartDate.Text.Length = 0 AndAlso Me.Validator.GetErrorMessage(Me.txtDocStartDate) = "" Then
            Dim theDate As Date = CDate(Me.txtDocStartDate.Text)
            If Not Me.DocDateStart.Equals(theDate) Then
              dtpDocStartDate.Value = theDate
              Me.DocDateStart = dtpDocStartDate.Value
            End If
          Else
            Me.dtpDocStartDate.Value = Date.Now
            Me.DocDateStart = Date.MinValue
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
        If data.GetDataPresent(m_cc.FullClassName) Then
          If Not Me.ActiveControl Is Nothing Then
            Select Case Me.ActiveControl.Name.ToLower

              Case "txttoccstart", "txttoccend"
                Return True
            End Select
          End If
        End If
        'If data.GetDataPresent(m_requestor.FullClassName) Then
        '    If Not Me.ActiveControl Is Nothing Then
        '        Select Case Me.ActiveControl.Name.ToLower

        '            Case "txtrequestorcode"
        '                Return True
        '        End Select
        '    End If
        'End If
      End Get
    End Property
    Public Overrides Sub Paste(ByVal sender As Object, ByVal e As System.EventArgs)
      Dim data As IDataObject = Clipboard.GetDataObject
      If data.GetDataPresent(m_cc.FullClassName) Then
        Dim id As Integer = CInt(data.GetData(m_cc.FullClassName))
        Dim entity As New CostCenter(id)
        If Not Me.ActiveControl Is Nothing Then
          Select Case Me.ActiveControl.Name.ToLower

            Case "txttoccstart"
              Me.SetCostCenter(entity)


          End Select
        End If
        'If Not Me.ActiveControl Is Nothing Then
        '    Select Case Me.ActiveControl.Name.ToLower

        '        Case "txtrequestorcode"
        '            Me.SetEmployee(entity)


        '    End Select
        'End If
      End If
    End Sub
#End Region

#Region " Event Handlers "
    Private Sub txtToCostCenterCode_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCostCenterCode.Validated
      CostCenter.GetCostCenter(txtCostCenterCode, Me.txtCostCenterName, Me.m_cc)
    End Sub
    Private Sub txtRequestorCode_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtRequestorCode.Validated
      Employee.GetEmployee(txtRequestorCode, Me.txtRequestorName, Me.m_requestor)
    End Sub
    Private Sub btnShowCostCenter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnShowCostCenter.Click
      Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      Select Case CType(sender, Control).Name.ToLower
        Case "btnshowcostcenter"
          myEntityPanelService.OpenListDialog(New CostCenter, AddressOf SetCostCenter)
      End Select
    End Sub
    Private Sub btnShowRequestor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnShowRequestor.Click
      Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      Select Case CType(sender, Control).Name.ToLower
        Case "btnshowrequestor"
          myEntityPanelService.OpenListDialog(New Employee, AddressOf SetEmployee)
      End Select
    End Sub
    Private Sub SetCostCenter(ByVal e As ISimpleEntity)
      Me.txtCostCenterCode.Text = e.Code
      CostCenter.GetCostCenter(txtCostCenterCode, txtCostCenterName, Me.m_cc)
    End Sub
    Private Sub SetEmployee(ByVal e As ISimpleEntity)
      Me.txtRequestorCode.Text = e.Code
      Employee.GetEmployee(txtRequestorCode, txtRequestorName, Me.m_requestor)
    End Sub
    Private Sub btnWBS_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnWBS.Click
      advanceFindString = ""
      advanceFindWbsLevel = ""
      advanceValueString = ""
      advanceFindLCI = ""
      Dim dlg As New AdvanceFindFilterPanel(Me, "wbs")
      Dim myDialog As New Longkong.Pojjaman.Gui.Dialogs.PanelDialog(dlg)
      If myDialog.ShowDialog() Then
        advanceFindString = Me.AdvanceFindCollection.GetBuiltSQLString
        advancefindWbsLevel = Me.AdvanceFindCollection.GetBuiltSQLStringforWbsLevel
        advanceValueString = Me.AdvanceFindCollection.GetBuiltSQLStringforValue
        advanceFindLCI = Me.AdvanceFindCollection.GetBuiltSQLString1
      End If
    End Sub
#End Region

#Region "Filter Document"
    ' ทุกวัน
    Private Sub btnBillRecDays_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDocTypeList.Click

      Dim ls As List(Of IDescripable) = CostItemType.GetCostDocList("245,246,247")

      Dim chkdlg As New Longkong.Pojjaman.Gui.Panels.CheckListDialog(ls, DocIndexList)
      Dim myDialog As New Longkong.Pojjaman.Gui.Dialogs.PanelDialog(chkdlg)
      If myDialog.ShowDialog() = DialogResult.OK Then
        Me.txtDoctypeList.Text = chkdlg.CheckedItemsString
        DocIdList = chkdlg.CheckedItemValuesString
        DocIndexList = chkdlg.CheckedValuesString
        Dim myContent As IViewContent = WorkbenchSingleton.Workbench.ActiveWorkbenchWindow.ViewContent
        myContent.IsDirty = True
      End If
    End Sub
#End Region

  End Class

End Namespace

