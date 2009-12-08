Imports Longkong.Pojjaman.BusinessLogic
Imports longkong.Pojjaman.Services
Imports Longkong.Core.Services

Namespace Longkong.Pojjaman.Gui.Panels
  Public Class RptWBSMonitor2FilterSubPanel
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
    Friend WithEvents txtDocDateEnd As System.Windows.Forms.TextBox
    Friend WithEvents dtpDocDateEnd As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblDocDateEnd As System.Windows.Forms.Label
    Friend WithEvents btnShowCostCenter As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents txtCostCenterCode As System.Windows.Forms.TextBox
    Friend WithEvents lblCostCenter As System.Windows.Forms.Label
    Friend WithEvents txtCostCenterName As System.Windows.Forms.TextBox
    Friend WithEvents chkNoDigit As System.Windows.Forms.CheckBox
    Friend WithEvents cmbDetailed As System.Windows.Forms.ComboBox
    Friend WithEvents lblDetailed As System.Windows.Forms.Label
    Friend WithEvents btnShowRequestor As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents txtRequestorCode As System.Windows.Forms.TextBox
    Friend WithEvents txtRequestorName As System.Windows.Forms.TextBox
    Friend WithEvents lblRequestor As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmbSystem As System.Windows.Forms.ComboBox
    Friend WithEvents txtDocDateStart As System.Windows.Forms.TextBox
    Friend WithEvents dtpDocDateStart As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label2 As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
      Me.components = New System.ComponentModel.Container
      Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(RptWBSMonitor2FilterSubPanel))
      Me.grbMaster = New Longkong.Pojjaman.Gui.Components.FixedGroupBox
      Me.grbDetail = New Longkong.Pojjaman.Gui.Components.FixedGroupBox
      Me.cmbSystem = New System.Windows.Forms.ComboBox
      Me.Label1 = New System.Windows.Forms.Label
      Me.btnShowRequestor = New Longkong.Pojjaman.Gui.Components.ImageButton
      Me.txtRequestorCode = New System.Windows.Forms.TextBox
      Me.lblRequestor = New System.Windows.Forms.Label
      Me.cmbDetailed = New System.Windows.Forms.ComboBox
      Me.txtDocDateEnd = New System.Windows.Forms.TextBox
      Me.dtpDocDateEnd = New System.Windows.Forms.DateTimePicker
      Me.lblDocDateEnd = New System.Windows.Forms.Label
      Me.btnShowCostCenter = New Longkong.Pojjaman.Gui.Components.ImageButton
      Me.txtCostCenterCode = New System.Windows.Forms.TextBox
      Me.lblCostCenter = New System.Windows.Forms.Label
      Me.txtCostCenterName = New System.Windows.Forms.TextBox
      Me.chkNoDigit = New System.Windows.Forms.CheckBox
      Me.lblDetailed = New System.Windows.Forms.Label
      Me.txtRequestorName = New System.Windows.Forms.TextBox
      Me.btnSearch = New System.Windows.Forms.Button
      Me.btnReset = New System.Windows.Forms.Button
      Me.Validator = New Longkong.Pojjaman.Gui.Components.PJMTextboxValidator(Me.components)
      Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider
      Me.txtDocDateStart = New System.Windows.Forms.TextBox
      Me.dtpDocDateStart = New System.Windows.Forms.DateTimePicker
      Me.Label2 = New System.Windows.Forms.Label
      Me.grbMaster.SuspendLayout()
      Me.grbDetail.SuspendLayout()
      Me.SuspendLayout()
      '
      'grbMaster
      '
      Me.grbMaster.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                  Or System.Windows.Forms.AnchorStyles.Left) _
                  Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.grbMaster.Controls.Add(Me.grbDetail)
      Me.grbMaster.Controls.Add(Me.btnSearch)
      Me.grbMaster.Controls.Add(Me.btnReset)
      Me.grbMaster.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.grbMaster.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.grbMaster.Location = New System.Drawing.Point(8, 8)
      Me.grbMaster.Name = "grbMaster"
      Me.grbMaster.Size = New System.Drawing.Size(480, 216)
      Me.grbMaster.TabIndex = 0
      Me.grbMaster.TabStop = False
      Me.grbMaster.Text = "ค้นหา"
      '
      'grbDetail
      '
      Me.grbDetail.Controls.Add(Me.Label2)
      Me.grbDetail.Controls.Add(Me.txtDocDateStart)
      Me.grbDetail.Controls.Add(Me.dtpDocDateStart)
      Me.grbDetail.Controls.Add(Me.cmbSystem)
      Me.grbDetail.Controls.Add(Me.Label1)
      Me.grbDetail.Controls.Add(Me.btnShowRequestor)
      Me.grbDetail.Controls.Add(Me.txtRequestorCode)
      Me.grbDetail.Controls.Add(Me.lblRequestor)
      Me.grbDetail.Controls.Add(Me.cmbDetailed)
      Me.grbDetail.Controls.Add(Me.txtDocDateEnd)
      Me.grbDetail.Controls.Add(Me.dtpDocDateEnd)
      Me.grbDetail.Controls.Add(Me.lblDocDateEnd)
      Me.grbDetail.Controls.Add(Me.btnShowCostCenter)
      Me.grbDetail.Controls.Add(Me.txtCostCenterCode)
      Me.grbDetail.Controls.Add(Me.lblCostCenter)
      Me.grbDetail.Controls.Add(Me.txtCostCenterName)
      Me.grbDetail.Controls.Add(Me.chkNoDigit)
      Me.grbDetail.Controls.Add(Me.lblDetailed)
      Me.grbDetail.Controls.Add(Me.txtRequestorName)
      Me.grbDetail.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.grbDetail.Location = New System.Drawing.Point(16, 16)
      Me.grbDetail.Name = "grbDetail"
      Me.grbDetail.Size = New System.Drawing.Size(448, 160)
      Me.grbDetail.TabIndex = 0
      Me.grbDetail.TabStop = False
      Me.grbDetail.Text = "ข้อมูลทั่วไป"
      '
      'cmbSystem
      '
      Me.cmbSystem.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbSystem.Items.AddRange(New Object() {"All", "1000", "2000", "3000", "4000", "5000", "6000", "7000", "8000", "9000"})
      Me.cmbSystem.Location = New System.Drawing.Point(120, 72)
      Me.cmbSystem.Name = "cmbSystem"
      Me.cmbSystem.Size = New System.Drawing.Size(160, 21)
      Me.cmbSystem.TabIndex = 11
      '
      'Label1
      '
      Me.Label1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Label1.ForeColor = System.Drawing.Color.Black
      Me.Label1.Location = New System.Drawing.Point(8, 72)
      Me.Label1.Name = "Label1"
      Me.Label1.Size = New System.Drawing.Size(112, 18)
      Me.Label1.TabIndex = 10
      Me.Label1.Text = "System:"
      Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'btnShowRequestor
      '
      Me.btnShowRequestor.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.btnShowRequestor.ForeColor = System.Drawing.SystemColors.Control
      Me.btnShowRequestor.Image = CType(resources.GetObject("btnShowRequestor.Image"), System.Drawing.Image)
      Me.btnShowRequestor.Location = New System.Drawing.Point(416, 96)
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
      Me.txtRequestorCode.Location = New System.Drawing.Point(120, 96)
      Me.Validator.SetMaxValue(Me.txtRequestorCode, "")
      Me.Validator.SetMinValue(Me.txtRequestorCode, "")
      Me.txtRequestorCode.Name = "txtRequestorCode"
      Me.Validator.SetRegularExpression(Me.txtRequestorCode, "")
      Me.Validator.SetRequired(Me.txtRequestorCode, False)
      Me.txtRequestorCode.Size = New System.Drawing.Size(112, 21)
      Me.txtRequestorCode.TabIndex = 13
      Me.txtRequestorCode.Text = ""
      '
      'lblRequestor
      '
      Me.lblRequestor.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblRequestor.ForeColor = System.Drawing.Color.Black
      Me.lblRequestor.Location = New System.Drawing.Point(8, 96)
      Me.lblRequestor.Name = "lblRequestor"
      Me.lblRequestor.Size = New System.Drawing.Size(112, 18)
      Me.lblRequestor.TabIndex = 12
      Me.lblRequestor.Text = "ผู้ทำรายการ:"
      Me.lblRequestor.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'cmbDetailed
      '
      Me.cmbDetailed.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbDetailed.Location = New System.Drawing.Point(120, 120)
      Me.cmbDetailed.Name = "cmbDetailed"
      Me.cmbDetailed.Size = New System.Drawing.Size(160, 21)
      Me.cmbDetailed.TabIndex = 17
      '
      'txtDocDateEnd
      '
      Me.Validator.SetDataType(Me.txtDocDateEnd, Longkong.Pojjaman.Gui.Components.DataTypeConstants.DateTimeType)
      Me.Validator.SetDisplayName(Me.txtDocDateEnd, "")
      Me.Validator.SetGotFocusBackColor(Me.txtDocDateEnd, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtDocDateEnd, -15)
      Me.Validator.SetInvalidBackColor(Me.txtDocDateEnd, System.Drawing.Color.Empty)
      Me.txtDocDateEnd.Location = New System.Drawing.Point(312, 24)
      Me.txtDocDateEnd.MaxLength = 10
      Me.Validator.SetMaxValue(Me.txtDocDateEnd, "")
      Me.Validator.SetMinValue(Me.txtDocDateEnd, "")
      Me.txtDocDateEnd.Name = "txtDocDateEnd"
      Me.Validator.SetRegularExpression(Me.txtDocDateEnd, "")
      Me.Validator.SetRequired(Me.txtDocDateEnd, False)
      Me.txtDocDateEnd.Size = New System.Drawing.Size(112, 21)
      Me.txtDocDateEnd.TabIndex = 4
      Me.txtDocDateEnd.Text = ""
      '
      'dtpDocDateEnd
      '
      Me.dtpDocDateEnd.Format = System.Windows.Forms.DateTimePickerFormat.Short
      Me.dtpDocDateEnd.Location = New System.Drawing.Point(312, 24)
      Me.dtpDocDateEnd.Name = "dtpDocDateEnd"
      Me.dtpDocDateEnd.Size = New System.Drawing.Size(128, 21)
      Me.dtpDocDateEnd.TabIndex = 5
      Me.dtpDocDateEnd.TabStop = False
      '
      'lblDocDateEnd
      '
      Me.lblDocDateEnd.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblDocDateEnd.ForeColor = System.Drawing.Color.Black
      Me.lblDocDateEnd.Location = New System.Drawing.Point(8, 24)
      Me.lblDocDateEnd.Name = "lblDocDateEnd"
      Me.lblDocDateEnd.Size = New System.Drawing.Size(112, 18)
      Me.lblDocDateEnd.TabIndex = 0
      Me.lblDocDateEnd.Text = "เรียกข้อมูลถึงวันที่:"
      Me.lblDocDateEnd.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'btnShowCostCenter
      '
      Me.btnShowCostCenter.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.btnShowCostCenter.ForeColor = System.Drawing.SystemColors.Control
      Me.btnShowCostCenter.Image = CType(resources.GetObject("btnShowCostCenter.Image"), System.Drawing.Image)
      Me.btnShowCostCenter.Location = New System.Drawing.Point(416, 48)
      Me.btnShowCostCenter.Name = "btnShowCostCenter"
      Me.btnShowCostCenter.Size = New System.Drawing.Size(24, 22)
      Me.btnShowCostCenter.TabIndex = 9
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
      Me.txtCostCenterCode.Location = New System.Drawing.Point(120, 48)
      Me.Validator.SetMaxValue(Me.txtCostCenterCode, "")
      Me.Validator.SetMinValue(Me.txtCostCenterCode, "")
      Me.txtCostCenterCode.Name = "txtCostCenterCode"
      Me.Validator.SetRegularExpression(Me.txtCostCenterCode, "")
      Me.Validator.SetRequired(Me.txtCostCenterCode, False)
      Me.txtCostCenterCode.Size = New System.Drawing.Size(112, 21)
      Me.txtCostCenterCode.TabIndex = 7
      Me.txtCostCenterCode.Text = ""
      '
      'lblCostCenter
      '
      Me.lblCostCenter.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblCostCenter.ForeColor = System.Drawing.Color.Black
      Me.lblCostCenter.Location = New System.Drawing.Point(8, 48)
      Me.lblCostCenter.Name = "lblCostCenter"
      Me.lblCostCenter.Size = New System.Drawing.Size(112, 18)
      Me.lblCostCenter.TabIndex = 6
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
      Me.txtCostCenterName.Location = New System.Drawing.Point(232, 48)
      Me.Validator.SetMaxValue(Me.txtCostCenterName, "")
      Me.Validator.SetMinValue(Me.txtCostCenterName, "")
      Me.txtCostCenterName.Name = "txtCostCenterName"
      Me.txtCostCenterName.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtCostCenterName, "")
      Me.Validator.SetRequired(Me.txtCostCenterName, False)
      Me.txtCostCenterName.Size = New System.Drawing.Size(184, 21)
      Me.txtCostCenterName.TabIndex = 8
      Me.txtCostCenterName.Text = ""
      '
      'chkNoDigit
      '
      Me.chkNoDigit.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.chkNoDigit.Location = New System.Drawing.Point(296, 120)
      Me.chkNoDigit.Name = "chkNoDigit"
      Me.chkNoDigit.Size = New System.Drawing.Size(120, 24)
      Me.chkNoDigit.TabIndex = 18
      Me.chkNoDigit.Text = "ไม่แสดงทศนิยม"
      '
      'lblDetailed
      '
      Me.lblDetailed.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblDetailed.ForeColor = System.Drawing.Color.Black
      Me.lblDetailed.Location = New System.Drawing.Point(8, 120)
      Me.lblDetailed.Name = "lblDetailed"
      Me.lblDetailed.Size = New System.Drawing.Size(112, 18)
      Me.lblDetailed.TabIndex = 16
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
      Me.txtRequestorName.Location = New System.Drawing.Point(232, 96)
      Me.Validator.SetMaxValue(Me.txtRequestorName, "")
      Me.Validator.SetMinValue(Me.txtRequestorName, "")
      Me.txtRequestorName.Name = "txtRequestorName"
      Me.txtRequestorName.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtRequestorName, "")
      Me.Validator.SetRequired(Me.txtRequestorName, False)
      Me.txtRequestorName.Size = New System.Drawing.Size(184, 21)
      Me.txtRequestorName.TabIndex = 14
      Me.txtRequestorName.Text = ""
      '
      'btnSearch
      '
      Me.btnSearch.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnSearch.Location = New System.Drawing.Point(384, 184)
      Me.btnSearch.Name = "btnSearch"
      Me.btnSearch.Size = New System.Drawing.Size(80, 23)
      Me.btnSearch.TabIndex = 2
      Me.btnSearch.Text = "ค้นหา"
      '
      'btnReset
      '
      Me.btnReset.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnReset.Location = New System.Drawing.Point(296, 184)
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
      Me.Validator.GotFocusBackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
      Me.Validator.HasNewRow = False
      Me.Validator.InvalidBackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(128, Byte), CType(0, Byte))
      '
      'ErrorProvider1
      '
      Me.ErrorProvider1.ContainerControl = Me
      '
      'txtDocDateStart
      '
      Me.Validator.SetDataType(Me.txtDocDateStart, Longkong.Pojjaman.Gui.Components.DataTypeConstants.DateTimeType)
      Me.Validator.SetDisplayName(Me.txtDocDateStart, "")
      Me.Validator.SetGotFocusBackColor(Me.txtDocDateStart, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtDocDateStart, -15)
      Me.Validator.SetInvalidBackColor(Me.txtDocDateStart, System.Drawing.Color.Empty)
      Me.txtDocDateStart.Location = New System.Drawing.Point(120, 24)
      Me.txtDocDateStart.MaxLength = 10
      Me.Validator.SetMaxValue(Me.txtDocDateStart, "")
      Me.Validator.SetMinValue(Me.txtDocDateStart, "")
      Me.txtDocDateStart.Name = "txtDocDateStart"
      Me.Validator.SetRegularExpression(Me.txtDocDateStart, "")
      Me.Validator.SetRequired(Me.txtDocDateStart, False)
      Me.txtDocDateStart.Size = New System.Drawing.Size(112, 21)
      Me.txtDocDateStart.TabIndex = 1
      Me.txtDocDateStart.Text = ""
      '
      'dtpDocDateStart
      '
      Me.dtpDocDateStart.Format = System.Windows.Forms.DateTimePickerFormat.Short
      Me.dtpDocDateStart.Location = New System.Drawing.Point(120, 24)
      Me.dtpDocDateStart.Name = "dtpDocDateStart"
      Me.dtpDocDateStart.Size = New System.Drawing.Size(128, 21)
      Me.dtpDocDateStart.TabIndex = 2
      Me.dtpDocDateStart.TabStop = False
      '
      'Label2
      '
      Me.Label2.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Label2.ForeColor = System.Drawing.Color.Black
      Me.Label2.Location = New System.Drawing.Point(256, 24)
      Me.Label2.Name = "Label2"
      Me.Label2.Size = New System.Drawing.Size(56, 18)
      Me.Label2.TabIndex = 3
      Me.Label2.Text = "-"
      Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
      '
      'RptWBSMonitor2FilterSubPanel
      '
      Me.Controls.Add(Me.grbMaster)
      Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Name = "RptWBSMonitor2FilterSubPanel"
      Me.Size = New System.Drawing.Size(496, 232)
      Me.grbMaster.ResumeLayout(False)
      Me.grbDetail.ResumeLayout(False)
      Me.ResumeLayout(False)

    End Sub

#End Region

#Region " SetLabelText "
    Public Sub SetLabelText()

      Me.lblCostCenter.Text = "Project:" '"(M-L-E)" & Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptWBSMonitorFilterSubPanel.lblCostCenter}")
      Me.Validator.SetDisplayName(txtCostCenterCode, lblCostCenter.Text)

      Me.lblRequestor.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptWBSMonitorFilterSubPanel.lblRequestor}")
      Me.Validator.SetDisplayName(txtRequestorCode, lblRequestor.Text)

      ' Global {ถึง}
      Me.lblDocDateEnd.Text = "From:" 'Me.StringParserService.Parse("${res:Global.FilterPanelTo}")
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
    Private m_DocDateStart As Date
    Private m_DocDateEnd As Date
    Private m_cc As CostCenter

    Private m_requestor As Employee

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
    Public Property DocDateStart() As Date      Get        Return m_DocDateStart      End Get      Set(ByVal Value As Date)        m_DocDateStart = Value      End Set    End Property
    Public Property DocDateEnd() As Date      Get        Return m_DocDateEnd      End Get      Set(ByVal Value As Date)        m_DocDateEnd = Value      End Set    End Property#End Region

#Region "Methods"
    Private Sub Initialize()
      RegisterDropdown()
      ClearCriterias()
    End Sub
    Private Sub RegisterDropdown()
      ' รูปแบบ
      With cmbDetailed.Items
        .Add("ไม่แสดงรายการ")
        .Add("แสดงรายการ")
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

      Me.DocDateStart = Date.MinValue
      Me.txtDocDateEnd.Text = MinDateToNull(Me.DocDateStart, "")
      Me.dtpDocDateEnd.Value = Date.Now

      Me.DocDateEnd = Date.Now
      Me.txtDocDateEnd.Text = MinDateToNull(Me.DocDateEnd, "")
      Me.dtpDocDateEnd.Value = Me.DocDateEnd
      m_cc = New CostCenter
      m_requestor = New Employee
      Me.cmbSystem.SelectedIndex = 0
    End Sub
    Public Overrides Function GetFilterString() As String

    End Function
    Public Overrides Function GetFilterArray() As Filter()
      Dim arr(6) As Filter
      If Me.txtCostCenterCode.Text.Length = 0 Then
        arr(0) = New Filter("cc0", DBNull.Value)
      Else
        arr(0) = New Filter("cc0", m_cc)
      End If
      arr(1) = New Filter("System", cmbSystem.Text)
      arr(2) = New Filter("DocDateEnd", IIf(Me.DocDateEnd.Equals(Date.MinValue), DBNull.Value, Me.DocDateEnd))
      arr(3) = New Filter("Detailed", cmbDetailed.SelectedIndex)
      arr(4) = New Filter("NoDigit", Me.chkNoDigit.Checked)
      arr(5) = New Filter("requestor", Me.ValidIdOrDBNull(m_requestor))
      arr(6) = New Filter("DocDateStart", IIf(Me.DocDateStart.Equals(Date.MinValue), DBNull.Value, Me.DocDateStart))
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

    End Function
#End Region

#Region " ChangeProperty "
    Private Sub EventWiring()
      AddHandler txtDocDateEnd.Validated, AddressOf Me.ChangeProperty
      AddHandler dtpDocDateEnd.ValueChanged, AddressOf Me.ChangeProperty

      AddHandler txtDocDateStart.Validated, AddressOf Me.ChangeProperty
      AddHandler dtpDocDateStart.ValueChanged, AddressOf Me.ChangeProperty
    End Sub

    Private m_dateSetting As Boolean
    Private Sub ChangeProperty(ByVal sender As Object, ByVal e As EventArgs)

      Select Case CType(sender, Control).Name.ToLower
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
#End Region

  End Class

End Namespace

