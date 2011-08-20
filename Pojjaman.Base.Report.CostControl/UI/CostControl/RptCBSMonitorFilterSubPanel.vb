Imports Longkong.Pojjaman.BusinessLogic
Imports Longkong.Pojjaman.Services
Imports Longkong.Core.Services
Imports System.Collections.Generic

Namespace Longkong.Pojjaman.Gui.Panels
  Public Class RptCBSMonitorFilterSubPanel
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
    Friend WithEvents Validator As Longkong.Pojjaman.Gui.Components.PJMTextboxValidator
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents grbDetail As Longkong.Pojjaman.Gui.Components.FixedGroupBox
    Friend WithEvents txtDocDateEnd As System.Windows.Forms.TextBox
    Friend WithEvents dtpDocDateEnd As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblDocDateEnd As System.Windows.Forms.Label
    Friend WithEvents chkNoDigit As System.Windows.Forms.CheckBox
    Friend WithEvents grbPeriod As System.Windows.Forms.GroupBox
    Friend WithEvents txtDocEndDate As System.Windows.Forms.TextBox
    Friend WithEvents dtpDocEndDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblDocEndDate As System.Windows.Forms.Label
    Friend WithEvents txtDocStartDate As System.Windows.Forms.TextBox
    Friend WithEvents dtpDocStartDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents btnDocTypeList As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents txtDoctypeList As System.Windows.Forms.TextBox
    Friend WithEvents lblDocStartDate As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
      Me.components = New System.ComponentModel.Container()
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(RptCBSMonitorFilterSubPanel))
      Me.grbMaster = New Longkong.Pojjaman.Gui.Components.FixedGroupBox()
      Me.grbPeriod = New System.Windows.Forms.GroupBox()
      Me.txtDocEndDate = New System.Windows.Forms.TextBox()
      Me.dtpDocEndDate = New System.Windows.Forms.DateTimePicker()
      Me.lblDocEndDate = New System.Windows.Forms.Label()
      Me.txtDocStartDate = New System.Windows.Forms.TextBox()
      Me.dtpDocStartDate = New System.Windows.Forms.DateTimePicker()
      Me.lblDocStartDate = New System.Windows.Forms.Label()
      Me.grbDetail = New Longkong.Pojjaman.Gui.Components.FixedGroupBox()
      Me.txtDocDateEnd = New System.Windows.Forms.TextBox()
      Me.dtpDocDateEnd = New System.Windows.Forms.DateTimePicker()
      Me.lblDocDateEnd = New System.Windows.Forms.Label()
      Me.btnSearch = New System.Windows.Forms.Button()
      Me.btnReset = New System.Windows.Forms.Button()
      Me.chkNoDigit = New System.Windows.Forms.CheckBox()
      Me.Validator = New Longkong.Pojjaman.Gui.Components.PJMTextboxValidator(Me.components)
      Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
      Me.btnDocTypeList = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.txtDoctypeList = New System.Windows.Forms.TextBox()
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
      Me.grbMaster.Controls.Add(Me.chkNoDigit)
      Me.grbMaster.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.grbMaster.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.grbMaster.Location = New System.Drawing.Point(8, 8)
      Me.grbMaster.Name = "grbMaster"
      Me.grbMaster.Size = New System.Drawing.Size(738, 154)
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
      Me.grbDetail.Controls.Add(Me.btnDocTypeList)
      Me.grbDetail.Controls.Add(Me.txtDoctypeList)
      Me.grbDetail.Controls.Add(Me.txtDocDateEnd)
      Me.grbDetail.Controls.Add(Me.dtpDocDateEnd)
      Me.grbDetail.Controls.Add(Me.lblDocDateEnd)
      Me.grbDetail.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.grbDetail.Location = New System.Drawing.Point(16, 16)
      Me.grbDetail.Name = "grbDetail"
      Me.grbDetail.Size = New System.Drawing.Size(448, 100)
      Me.grbDetail.TabIndex = 0
      Me.grbDetail.TabStop = False
      Me.grbDetail.Text = "ข้อมูลทั่วไป"
      '
      'txtDocDateEnd
      '
      Me.Validator.SetDataType(Me.txtDocDateEnd, Longkong.Pojjaman.Gui.Components.DataTypeConstants.DateTimeType)
      Me.Validator.SetDisplayName(Me.txtDocDateEnd, "")
      Me.Validator.SetGotFocusBackColor(Me.txtDocDateEnd, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtDocDateEnd, -15)
      Me.Validator.SetInvalidBackColor(Me.txtDocDateEnd, System.Drawing.Color.Empty)
      Me.txtDocDateEnd.Location = New System.Drawing.Point(160, 12)
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
      Me.dtpDocDateEnd.Location = New System.Drawing.Point(160, 12)
      Me.dtpDocDateEnd.Name = "dtpDocDateEnd"
      Me.dtpDocDateEnd.Size = New System.Drawing.Size(120, 21)
      Me.dtpDocDateEnd.TabIndex = 17
      Me.dtpDocDateEnd.TabStop = False
      '
      'lblDocDateEnd
      '
      Me.lblDocDateEnd.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblDocDateEnd.ForeColor = System.Drawing.Color.Black
      Me.lblDocDateEnd.Location = New System.Drawing.Point(8, 12)
      Me.lblDocDateEnd.Name = "lblDocDateEnd"
      Me.lblDocDateEnd.Size = New System.Drawing.Size(152, 18)
      Me.lblDocDateEnd.TabIndex = 9
      Me.lblDocDateEnd.Text = "เรียกข้อมูลถึงวันที่:"
      Me.lblDocDateEnd.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'btnSearch
      '
      Me.btnSearch.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnSearch.Location = New System.Drawing.Point(642, 122)
      Me.btnSearch.Name = "btnSearch"
      Me.btnSearch.Size = New System.Drawing.Size(80, 23)
      Me.btnSearch.TabIndex = 2
      Me.btnSearch.Text = "ค้นหา"
      '
      'btnReset
      '
      Me.btnReset.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnReset.Location = New System.Drawing.Point(554, 122)
      Me.btnReset.Name = "btnReset"
      Me.btnReset.Size = New System.Drawing.Size(80, 23)
      Me.btnReset.TabIndex = 1
      Me.btnReset.TabStop = False
      Me.btnReset.Text = "เคลียร์"
      '
      'chkNoDigit
      '
      Me.chkNoDigit.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.chkNoDigit.Location = New System.Drawing.Point(565, 92)
      Me.chkNoDigit.Name = "chkNoDigit"
      Me.chkNoDigit.Size = New System.Drawing.Size(120, 24)
      Me.chkNoDigit.TabIndex = 6
      Me.chkNoDigit.Text = "ไม่แสดงทศนิยม"
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
      'btnDocTypeList
      '
      Me.btnDocTypeList.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnDocTypeList.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.btnDocTypeList.Location = New System.Drawing.Point(327, 37)
      Me.btnDocTypeList.Name = "btnDocTypeList"
      Me.btnDocTypeList.Size = New System.Drawing.Size(24, 23)
      Me.btnDocTypeList.TabIndex = 24
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
      Me.txtDoctypeList.Location = New System.Drawing.Point(160, 39)
      Me.Validator.SetMinValue(Me.txtDoctypeList, "")
      Me.txtDoctypeList.Name = "txtDoctypeList"
      Me.txtDoctypeList.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtDoctypeList, "")
      Me.Validator.SetRequired(Me.txtDoctypeList, False)
      Me.txtDoctypeList.Size = New System.Drawing.Size(166, 21)
      Me.txtDoctypeList.TabIndex = 25
      Me.txtDoctypeList.TabStop = False
      Me.txtDoctypeList.Text = "ทุกชนิดเอกสาร"
      '
      'RptCBSMonitorFilterSubPanel
      '
      Me.Controls.Add(Me.grbMaster)
      Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Name = "RptCBSMonitorFilterSubPanel"
      Me.Size = New System.Drawing.Size(754, 170)
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
      Me.Validator.SetDisplayName(txtStartCostCenterCode, lblCostCenter.Text)



      ' Global {ถึง}
      Me.lblDocDateEnd.Text = Me.StringParserService.Parse("${res:Global.FilterPanelTo}")
      Me.Validator.SetDisplayName(txtDocDateEnd, lblDocDateEnd.Text)

      ' Button
      Me.btnSearch.Text = Me.StringParserService.Parse("${res:Global.SearchButtonText}")
      Me.btnReset.Text = Me.StringParserService.Parse("${res:Global.ResetButtonText}")

      ' GroupBox
      Me.grbMaster.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptWBSMonitorFilterSubPanel.grbMaster}")
      Me.grbDetail.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptWBSMonitorFilterSubPanel.grbDetail}")

      Me.chkNoDigit.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptWBSMonitorFilterSubPanel.chkNoDigit}")
    End Sub
#End Region

#Region "Member"
    Private m_DocDateEnd As Date
    Private m_DocDateStart As Date
    Private m_startcc As CostCenter
    Private m_endcc As CostCenter



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
      'LoadCombo()
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
      m_dateSetting = True

      Me.DocDateStart = Date.MinValue
      Me.txtDocStartDate.Text = MinDateToNull(Me.DocDateStart, "")
      Me.dtpDocStartDate.Value = Date.Now

      Me.DocDateEnd = Date.Now
      Me.txtDocDateEnd.Text = MinDateToNull(Me.DocDateEnd, "")
      Me.dtpDocDateEnd.Value = Me.DocDateEnd

      Me.txtDocEndDate.Text = MinDateToNull(Me.DocDateEnd, "")
      Me.dtpDocEndDate.Value = Me.DocDateEnd



      m_startcc = New CostCenter
      m_endcc = New CostCenter
      'Try
      '  If Me.cmbType.Items.Count > 0 Then
      '    Me.cmbType.SelectedIndex = 1
      '  End If
      '  If Me.cmbReportType.Items.Count > 0 Then
      '    Me.cmbReportType.SelectedIndex = 0
      '  End If
      'Catch ex As Exception

      'End Try
    End Sub
    Public Overrides Function GetFilterString() As String

    End Function
    Public Overrides Function GetFilterArray() As Filter()


      Dim arr(4) As Filter
      If Me.txtStartCostCenterCode.Text.Length = 0 Then
        arr(0) = New Filter("startcc", DBNull.Value)
      Else
        arr(0) = New Filter("startcc", txtStartCostCenterCode.Text)
      End If
      If Me.txtEndCostcenterCode.Text.Length = 0 Then
        arr(1) = New Filter("endcc", DBNull.Value)
      Else
        arr(1) = New Filter("endcc", txtEndCostcenterCode.Text)
      End If
      arr(2) = New Filter("DocDateEnd", IIf(Me.DocDateEnd.Equals(Date.MinValue), DBNull.Value, Me.DocDateEnd))
      arr(3) = New Filter("NoDigit", Me.chkNoDigit.Checked)
      arr(4) = New Filter("DocDateStart", IIf(Me.DocDateStart.Equals(Date.MinValue), DBNull.Value, Me.DocDateStart))
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
        If data.GetDataPresent(m_startcc.FullClassName) Then
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
      If data.GetDataPresent(m_startcc.FullClassName) Then
        Dim id As Integer = CInt(data.GetData(m_startcc.FullClassName))
        Dim entity As New CostCenter(id)
        If Not Me.ActiveControl Is Nothing Then
          Select Case Me.ActiveControl.Name.ToLower

            Case "txttoccstart"
              Me.SetStartCostCenter(entity)


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
    Private Sub txtToCostCenterCode_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs)
      Select Case CType(sender, Control).Name.ToLower
        Case "txtstartcostcentercode"
          CostCenter.GetCostCenter(txtStartCostCenterCode, Me.txtStartCostCenterName, Me.m_startcc)
        Case "txtendcostcentercode"
          CostCenter.GetCostCenter(txtEndCostcenterCode, Me.txtEndCostcenterName, Me.m_endcc)
      End Select

    End Sub

    Private Sub btnShowCostCenter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
      Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      Select Case CType(sender, Control).Name.ToLower
        Case "btnshowstartcostcenter"
          myEntityPanelService.OpenListDialog(New CostCenter, AddressOf SetStartCostCenter)
        Case "btnshowendcostcenter"
          myEntityPanelService.OpenListDialog(New CostCenter, AddressOf SetEndCostCenter)
      End Select
    End Sub

    Private Sub SetStartCostCenter(ByVal e As ISimpleEntity)
      Me.txtStartCostCenterCode.Text = e.Code
      CostCenter.GetCostCenter(txtStartCostCenterCode, txtStartCostCenterName, Me.m_startcc)
    End Sub
    Private Sub SetEndCostCenter(ByVal e As ISimpleEntity)
      Me.txtEndCostcenterCode.Text = e.Code
      CostCenter.GetCostCenter(txtEndCostcenterCode, txtEndCostcenterName, Me.m_endcc)
    End Sub
#End Region



  End Class

End Namespace

