Imports Longkong.Pojjaman.BusinessLogic
Imports Longkong.Pojjaman.Services
Imports Longkong.Core.Services
Imports System.Collections.Generic

Namespace Longkong.Pojjaman.Gui.Panels
  Public Class RptGLPayTypeFilterSubPanel
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
    Friend WithEvents cmbDetailed As System.Windows.Forms.ComboBox
    Friend WithEvents lblDetailed As System.Windows.Forms.Label
    Friend WithEvents grbPeriod As System.Windows.Forms.GroupBox
    Friend WithEvents txtDocEndDate As System.Windows.Forms.TextBox
    Friend WithEvents dtpDocEndDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblDocEndDate As System.Windows.Forms.Label
    Friend WithEvents txtDocStartDate As System.Windows.Forms.TextBox
    Friend WithEvents dtpDocStartDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblDocStartDate As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
      Me.components = New System.ComponentModel.Container()
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(RptGLPayTypeFilterSubPanel))
      Me.grbMaster = New Longkong.Pojjaman.Gui.Components.FixedGroupBox()
      Me.grbPeriod = New System.Windows.Forms.GroupBox()
      Me.txtDocEndDate = New System.Windows.Forms.TextBox()
      Me.dtpDocEndDate = New System.Windows.Forms.DateTimePicker()
      Me.lblDocEndDate = New System.Windows.Forms.Label()
      Me.txtDocStartDate = New System.Windows.Forms.TextBox()
      Me.dtpDocStartDate = New System.Windows.Forms.DateTimePicker()
      Me.lblDocStartDate = New System.Windows.Forms.Label()
      Me.grbDetail = New Longkong.Pojjaman.Gui.Components.FixedGroupBox()
      Me.cmbDetailed = New System.Windows.Forms.ComboBox()
      Me.txtDocDateEnd = New System.Windows.Forms.TextBox()
      Me.dtpDocDateEnd = New System.Windows.Forms.DateTimePicker()
      Me.lblDocDateEnd = New System.Windows.Forms.Label()
      Me.btnShowCostCenter = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.txtCostCenterCode = New System.Windows.Forms.TextBox()
      Me.lblCostCenter = New System.Windows.Forms.Label()
      Me.txtCostCenterName = New System.Windows.Forms.TextBox()
      Me.lblDetailed = New System.Windows.Forms.Label()
      Me.btnSearch = New System.Windows.Forms.Button()
      Me.btnReset = New System.Windows.Forms.Button()
      Me.Validator = New Longkong.Pojjaman.Gui.Components.PJMTextboxValidator(Me.components)
      Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
      Me.grbMaster.SuspendLayout()
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
      Me.grbMaster.Controls.Add(Me.grbPeriod)
      Me.grbMaster.Controls.Add(Me.grbDetail)
      Me.grbMaster.Controls.Add(Me.btnSearch)
      Me.grbMaster.Controls.Add(Me.btnReset)
      Me.grbMaster.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.grbMaster.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.grbMaster.Location = New System.Drawing.Point(8, 3)
      Me.grbMaster.Name = "grbMaster"
      Me.grbMaster.Size = New System.Drawing.Size(694, 126)
      Me.grbMaster.TabIndex = 0
      Me.grbMaster.TabStop = False
      Me.grbMaster.Text = "ค้นหา"
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
      Me.grbDetail.Controls.Add(Me.cmbDetailed)
      Me.grbDetail.Controls.Add(Me.txtDocDateEnd)
      Me.grbDetail.Controls.Add(Me.dtpDocDateEnd)
      Me.grbDetail.Controls.Add(Me.lblDocDateEnd)
      Me.grbDetail.Controls.Add(Me.btnShowCostCenter)
      Me.grbDetail.Controls.Add(Me.txtCostCenterCode)
      Me.grbDetail.Controls.Add(Me.lblCostCenter)
      Me.grbDetail.Controls.Add(Me.txtCostCenterName)
      Me.grbDetail.Controls.Add(Me.lblDetailed)
      Me.grbDetail.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.grbDetail.Location = New System.Drawing.Point(16, 16)
      Me.grbDetail.Name = "grbDetail"
      Me.grbDetail.Size = New System.Drawing.Size(448, 95)
      Me.grbDetail.TabIndex = 0
      Me.grbDetail.TabStop = False
      Me.grbDetail.Text = "ข้อมูลทั่วไป"
      '
      'cmbDetailed
      '
      Me.cmbDetailed.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbDetailed.Location = New System.Drawing.Point(158, 67)
      Me.cmbDetailed.Name = "cmbDetailed"
      Me.cmbDetailed.Size = New System.Drawing.Size(120, 21)
      Me.cmbDetailed.TabIndex = 5
      '
      'txtDocDateEnd
      '
      Me.Validator.SetDataType(Me.txtDocDateEnd, Longkong.Pojjaman.Gui.Components.DataTypeConstants.DateTimeType)
      Me.Validator.SetDisplayName(Me.txtDocDateEnd, "")
      Me.Validator.SetGotFocusBackColor(Me.txtDocDateEnd, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtDocDateEnd, -15)
      Me.Validator.SetInvalidBackColor(Me.txtDocDateEnd, System.Drawing.Color.Empty)
      Me.txtDocDateEnd.Location = New System.Drawing.Point(158, 18)
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
      Me.dtpDocDateEnd.Location = New System.Drawing.Point(158, 18)
      Me.dtpDocDateEnd.Name = "dtpDocDateEnd"
      Me.dtpDocDateEnd.Size = New System.Drawing.Size(120, 21)
      Me.dtpDocDateEnd.TabIndex = 17
      Me.dtpDocDateEnd.TabStop = False
      '
      'lblDocDateEnd
      '
      Me.lblDocDateEnd.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblDocDateEnd.ForeColor = System.Drawing.Color.Black
      Me.lblDocDateEnd.Location = New System.Drawing.Point(6, 18)
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
      Me.btnShowCostCenter.Location = New System.Drawing.Point(414, 42)
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
      Me.txtCostCenterCode.Location = New System.Drawing.Point(158, 42)
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
      Me.lblCostCenter.Location = New System.Drawing.Point(6, 42)
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
      Me.txtCostCenterName.Location = New System.Drawing.Point(230, 42)
      Me.Validator.SetMinValue(Me.txtCostCenterName, "")
      Me.txtCostCenterName.Name = "txtCostCenterName"
      Me.txtCostCenterName.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtCostCenterName, "")
      Me.Validator.SetRequired(Me.txtCostCenterName, False)
      Me.txtCostCenterName.Size = New System.Drawing.Size(184, 21)
      Me.txtCostCenterName.TabIndex = 13
      '
      'lblDetailed
      '
      Me.lblDetailed.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblDetailed.ForeColor = System.Drawing.Color.Black
      Me.lblDetailed.Location = New System.Drawing.Point(6, 67)
      Me.lblDetailed.Name = "lblDetailed"
      Me.lblDetailed.Size = New System.Drawing.Size(152, 18)
      Me.lblDetailed.TabIndex = 12
      Me.lblDetailed.Text = "การแสดงรายละเอียด:"
      Me.lblDetailed.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'btnSearch
      '
      Me.btnSearch.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnSearch.Location = New System.Drawing.Point(605, 94)
      Me.btnSearch.Name = "btnSearch"
      Me.btnSearch.Size = New System.Drawing.Size(80, 23)
      Me.btnSearch.TabIndex = 2
      Me.btnSearch.Text = "ค้นหา"
      '
      'btnReset
      '
      Me.btnReset.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnReset.Location = New System.Drawing.Point(519, 94)
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
      'RptGLPayTypeFilterSubPanel
      '
      Me.Controls.Add(Me.grbMaster)
      Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Name = "RptGLPayTypeFilterSubPanel"
      Me.Size = New System.Drawing.Size(710, 135)
      Me.grbMaster.ResumeLayout(False)
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

      'Me.lblType.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptWBSMonitorFilterSubPanel.lblType}")

      Me.lblCostCenter.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptWBSMonitorFilterSubPanel.lblCostCenter}")
      Me.Validator.SetDisplayName(txtCostCenterCode, lblCostCenter.Text)

      'Me.lblRequestor.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptWBSMonitorFilterSubPanel.lblRequestor}")
      'Me.Validator.SetDisplayName(txtRequestorCode, lblRequestor.Text)

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
    End Sub
#End Region

#Region "Member"
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

    Public Property DocDateEnd() As Date      Get        Return m_DocDateEnd      End Get      Set(ByVal Value As Date)        m_DocDateEnd = Value      End Set    End Property    Public Property DocDateStart() As Date      Get        Return m_DocDateStart      End Get      Set(ByVal Value As Date)        m_DocDateStart = Value      End Set    End Property#End Region

#Region "Methods"
    Private Sub LoadCombo()
      'CodeDescription.ListCodeDescriptionInComboBox(Me.cmbType, "CostControlReportType")
      'With cmbReportType
      '  .Items.Clear()
      '  .Items.Add("ขอซื้อ")
      '  .Items.Add("สั่งซื้อ")
      '  .Items.Add("รับของ")
      '  .Items.Add("เบิกของ")
      '  .SelectedIndex = 0
      'End With

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


      m_cc = New CostCenter
     
    End Sub
    Public Overrides Function GetFilterString() As String

    End Function
    Public Overrides Function GetFilterArray() As Filter()


      Dim arr(3) As Filter
      If Me.txtCostCenterCode.Text.Length = 0 Then
        arr(0) = New Filter("cc_id", DBNull.Value)
      Else
        arr(0) = New Filter("cc_id", Me.ValidIdOrDBNull(m_cc))
      End If
      arr(1) = New Filter("DocDateEnd", IIf(Me.DocDateEnd.Equals(Date.MinValue), DBNull.Value, Me.DocDateEnd))
      arr(2) = New Filter("Detailed", cmbDetailed.SelectedIndex)
      arr(3) = New Filter("DocDateStart", IIf(Me.DocDateStart.Equals(Date.MinValue), DBNull.Value, Me.DocDateStart))
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
   
    Private Sub btnShowCostCenter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnShowCostCenter.Click
      Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      Select Case CType(sender, Control).Name.ToLower
        Case "btnshowcostcenter"
          myEntityPanelService.OpenTreeDialog(New CostCenter, AddressOf SetCostCenter)
      End Select
    End Sub

    Private Sub SetCostCenter(ByVal e As ISimpleEntity)
      Me.txtCostCenterCode.Text = e.Code
      CostCenter.GetCostCenter(txtCostCenterCode, txtCostCenterName, Me.m_cc)
    End Sub
    
#End Region



  End Class

End Namespace

