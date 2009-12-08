Imports Longkong.Pojjaman.BusinessLogic
Imports longkong.Pojjaman.Services
Imports Longkong.Core.Services

Namespace Longkong.Pojjaman.Gui.Panels
  Public Class RptWBSMonitor2FilterSubPanelx
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
    Friend WithEvents btnShowCostCenter2 As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents txtCCCode2 As System.Windows.Forms.TextBox
    Friend WithEvents lblCC2 As System.Windows.Forms.Label
    Friend WithEvents txtCCName2 As System.Windows.Forms.TextBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
      Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(RptWBSMonitor2FilterSubPanelx))
      Me.grbMaster = New Longkong.Pojjaman.Gui.Components.FixedGroupBox
      Me.grbDetail = New Longkong.Pojjaman.Gui.Components.FixedGroupBox
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
      Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider
      Me.btnShowCostCenter2 = New Longkong.Pojjaman.Gui.Components.ImageButton
      Me.txtCCCode2 = New System.Windows.Forms.TextBox
      Me.lblCC2 = New System.Windows.Forms.Label
      Me.txtCCName2 = New System.Windows.Forms.TextBox
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
      Me.grbMaster.Size = New System.Drawing.Size(480, 208)
      Me.grbMaster.TabIndex = 0
      Me.grbMaster.TabStop = False
      Me.grbMaster.Text = "ค้นหา"
      '
      'grbDetail
      '
      Me.grbDetail.Controls.Add(Me.btnShowCostCenter2)
      Me.grbDetail.Controls.Add(Me.txtCCCode2)
      Me.grbDetail.Controls.Add(Me.lblCC2)
      Me.grbDetail.Controls.Add(Me.txtCCName2)
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
      Me.grbDetail.Size = New System.Drawing.Size(448, 152)
      Me.grbDetail.TabIndex = 0
      Me.grbDetail.TabStop = False
      Me.grbDetail.Text = "ข้อมูลทั่วไป"
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
      Me.txtRequestorCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.ErrorProvider1.SetIconPadding(Me.txtRequestorCode, -15)
      Me.txtRequestorCode.Location = New System.Drawing.Point(160, 96)
      Me.txtRequestorCode.Name = "txtRequestorCode"
      Me.txtRequestorCode.Size = New System.Drawing.Size(72, 21)
      Me.txtRequestorCode.TabIndex = 4
      Me.txtRequestorCode.Text = ""
      '
      'lblRequestor
      '
      Me.lblRequestor.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblRequestor.ForeColor = System.Drawing.Color.Black
      Me.lblRequestor.Location = New System.Drawing.Point(8, 96)
      Me.lblRequestor.Name = "lblRequestor"
      Me.lblRequestor.Size = New System.Drawing.Size(152, 18)
      Me.lblRequestor.TabIndex = 11
      Me.lblRequestor.Text = "ผู้ทำรายการ:"
      Me.lblRequestor.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'cmbDetailed
      '
      Me.cmbDetailed.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbDetailed.Location = New System.Drawing.Point(160, 120)
      Me.cmbDetailed.Name = "cmbDetailed"
      Me.cmbDetailed.Size = New System.Drawing.Size(120, 21)
      Me.cmbDetailed.TabIndex = 5
      '
      'txtDocDateEnd
      '
      Me.ErrorProvider1.SetIconPadding(Me.txtDocDateEnd, -15)
      Me.txtDocDateEnd.Location = New System.Drawing.Point(160, 24)
      Me.txtDocDateEnd.MaxLength = 10
      Me.txtDocDateEnd.Name = "txtDocDateEnd"
      Me.txtDocDateEnd.Size = New System.Drawing.Size(99, 21)
      Me.txtDocDateEnd.TabIndex = 2
      Me.txtDocDateEnd.Text = ""
      '
      'dtpDocDateEnd
      '
      Me.dtpDocDateEnd.Format = System.Windows.Forms.DateTimePickerFormat.Short
      Me.dtpDocDateEnd.Location = New System.Drawing.Point(160, 24)
      Me.dtpDocDateEnd.Name = "dtpDocDateEnd"
      Me.dtpDocDateEnd.Size = New System.Drawing.Size(120, 21)
      Me.dtpDocDateEnd.TabIndex = 17
      Me.dtpDocDateEnd.TabStop = False
      '
      'lblDocDateEnd
      '
      Me.lblDocDateEnd.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblDocDateEnd.ForeColor = System.Drawing.Color.Black
      Me.lblDocDateEnd.Location = New System.Drawing.Point(8, 24)
      Me.lblDocDateEnd.Name = "lblDocDateEnd"
      Me.lblDocDateEnd.Size = New System.Drawing.Size(152, 18)
      Me.lblDocDateEnd.TabIndex = 9
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
      Me.btnShowCostCenter.TabIndex = 16
      Me.btnShowCostCenter.TabStop = False
      Me.btnShowCostCenter.ThemedImage = CType(resources.GetObject("btnShowCostCenter.ThemedImage"), System.Drawing.Bitmap)
      '
      'txtCostCenterCode
      '
      Me.txtCostCenterCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.ErrorProvider1.SetIconPadding(Me.txtCostCenterCode, -15)
      Me.txtCostCenterCode.Location = New System.Drawing.Point(160, 48)
      Me.txtCostCenterCode.Name = "txtCostCenterCode"
      Me.txtCostCenterCode.Size = New System.Drawing.Size(72, 21)
      Me.txtCostCenterCode.TabIndex = 3
      Me.txtCostCenterCode.Text = ""
      '
      'lblCostCenter
      '
      Me.lblCostCenter.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblCostCenter.ForeColor = System.Drawing.Color.Black
      Me.lblCostCenter.Location = New System.Drawing.Point(8, 48)
      Me.lblCostCenter.Name = "lblCostCenter"
      Me.lblCostCenter.Size = New System.Drawing.Size(152, 18)
      Me.lblCostCenter.TabIndex = 10
      Me.lblCostCenter.Text = "Cost Center:"
      Me.lblCostCenter.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'txtCostCenterName
      '
      Me.txtCostCenterName.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.ErrorProvider1.SetIconPadding(Me.txtCostCenterName, -15)
      Me.txtCostCenterName.Location = New System.Drawing.Point(232, 48)
      Me.txtCostCenterName.Name = "txtCostCenterName"
      Me.txtCostCenterName.ReadOnly = True
      Me.txtCostCenterName.Size = New System.Drawing.Size(184, 21)
      Me.txtCostCenterName.TabIndex = 13
      Me.txtCostCenterName.Text = ""
      '
      'chkNoDigit
      '
      Me.chkNoDigit.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.chkNoDigit.Location = New System.Drawing.Point(296, 120)
      Me.chkNoDigit.Name = "chkNoDigit"
      Me.chkNoDigit.Size = New System.Drawing.Size(120, 24)
      Me.chkNoDigit.TabIndex = 6
      Me.chkNoDigit.Text = "ไม่แสดงทศนิยม"
      '
      'lblDetailed
      '
      Me.lblDetailed.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblDetailed.ForeColor = System.Drawing.Color.Black
      Me.lblDetailed.Location = New System.Drawing.Point(8, 120)
      Me.lblDetailed.Name = "lblDetailed"
      Me.lblDetailed.Size = New System.Drawing.Size(152, 18)
      Me.lblDetailed.TabIndex = 12
      Me.lblDetailed.Text = "การแสดงรายละเอียด:"
      Me.lblDetailed.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'txtRequestorName
      '
      Me.txtRequestorName.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.ErrorProvider1.SetIconPadding(Me.txtRequestorName, -15)
      Me.txtRequestorName.Location = New System.Drawing.Point(232, 96)
      Me.txtRequestorName.Name = "txtRequestorName"
      Me.txtRequestorName.ReadOnly = True
      Me.txtRequestorName.Size = New System.Drawing.Size(184, 21)
      Me.txtRequestorName.TabIndex = 14
      Me.txtRequestorName.Text = ""
      '
      'btnSearch
      '
      Me.btnSearch.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnSearch.Location = New System.Drawing.Point(384, 176)
      Me.btnSearch.Name = "btnSearch"
      Me.btnSearch.Size = New System.Drawing.Size(80, 23)
      Me.btnSearch.TabIndex = 2
      Me.btnSearch.Text = "ค้นหา"
      '
      'btnReset
      '
      Me.btnReset.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnReset.Location = New System.Drawing.Point(296, 176)
      Me.btnReset.Name = "btnReset"
      Me.btnReset.Size = New System.Drawing.Size(80, 23)
      Me.btnReset.TabIndex = 1
      Me.btnReset.TabStop = False
      Me.btnReset.Text = "เคลียร์"
      '
      'ErrorProvider1
      '
      Me.ErrorProvider1.ContainerControl = Me
      '
      'btnShowCostCenter2
      '
      Me.btnShowCostCenter2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.btnShowCostCenter2.ForeColor = System.Drawing.SystemColors.Control
      Me.btnShowCostCenter2.Image = CType(resources.GetObject("btnShowCostCenter2.Image"), System.Drawing.Image)
      Me.btnShowCostCenter2.Location = New System.Drawing.Point(416, 72)
      Me.btnShowCostCenter2.Name = "btnShowCostCenter2"
      Me.btnShowCostCenter2.Size = New System.Drawing.Size(24, 22)
      Me.btnShowCostCenter2.TabIndex = 21
      Me.btnShowCostCenter2.TabStop = False
      Me.btnShowCostCenter2.ThemedImage = CType(resources.GetObject("btnShowCostCenter2.ThemedImage"), System.Drawing.Bitmap)
      '
      'txtCCCode2
      '
      Me.txtCCCode2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.ErrorProvider1.SetIconPadding(Me.txtCCCode2, -15)
      Me.txtCCCode2.Location = New System.Drawing.Point(160, 72)
      Me.txtCCCode2.Name = "txtCCCode2"
      Me.txtCCCode2.Size = New System.Drawing.Size(72, 21)
      Me.txtCCCode2.TabIndex = 18
      Me.txtCCCode2.Text = ""
      '
      'lblCC2
      '
      Me.lblCC2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblCC2.ForeColor = System.Drawing.Color.Black
      Me.lblCC2.Location = New System.Drawing.Point(8, 72)
      Me.lblCC2.Name = "lblCC2"
      Me.lblCC2.Size = New System.Drawing.Size(152, 18)
      Me.lblCC2.TabIndex = 19
      Me.lblCC2.Text = "Cost Center:"
      Me.lblCC2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'txtCCName2
      '
      Me.txtCCName2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.ErrorProvider1.SetIconPadding(Me.txtCCName2, -15)
      Me.txtCCName2.Location = New System.Drawing.Point(232, 72)
      Me.txtCCName2.Name = "txtCCName2"
      Me.txtCCName2.ReadOnly = True
      Me.txtCCName2.Size = New System.Drawing.Size(184, 21)
      Me.txtCCName2.TabIndex = 20
      Me.txtCCName2.Text = ""
      '
      'RptWBSMonitor2FilterSubPanelx
      '
      Me.Controls.Add(Me.grbMaster)
      Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Name = "RptWBSMonitor2FilterSubPanelx"
      Me.Size = New System.Drawing.Size(496, 224)
      Me.grbMaster.ResumeLayout(False)
      Me.grbDetail.ResumeLayout(False)
      Me.ResumeLayout(False)

    End Sub

#End Region

#Region " SetLabelText "
    Public Sub SetLabelText()

      Try
        Me.lblCostCenter.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptWBSMonitorFilterSubPanel.lblCostCenter}")
        Me.Validator.SetDisplayName(txtCostCenterCode, lblCostCenter.Text)

        Me.lblCC2.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptWBSMonitorFilterSubPanel.lblCostCenter}") & "-2"
        Me.Validator.SetDisplayName(txtCCCode2, lblCC2.Text)

        Me.lblRequestor.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptWBSMonitorFilterSubPanel.lblRequestor}")
        Me.Validator.SetDisplayName(txtRequestorCode, lblRequestor.Text)

        '' Global {ถึง}
        'Me.lblDocDateEnd.Text = Me.StringParserService.Parse("${res:Global.FilterPanelTo}")
        'Me.Validator.SetDisplayName(txtDocDateEnd, lblDocDateEnd.Text)

        ' Button
        Me.btnSearch.Text = Me.StringParserService.Parse("${res:Global.SearchButtonText}")
        Me.btnReset.Text = Me.StringParserService.Parse("${res:Global.ResetButtonText}")

        ' GroupBox
        Me.grbMaster.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptWBSMonitorFilterSubPanel.grbMaster}")
        Me.grbDetail.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptWBSMonitorFilterSubPanel.grbDetail}")

        Me.lblDetailed.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptWBSMonitorFilterSubPanel.chkDetailed}")
        Me.chkNoDigit.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptWBSMonitorFilterSubPanel.chkNoDigit}")
      Catch ex As Exception
        MessageBox.Show(ex.Message & ex.StackTrace)
      End Try

    End Sub
#End Region

#Region "Member"
    Private m_DocDateEnd As Date
    Private m_cc As CostCenter
    Private m_cc2 As CostCenter
    Private m_requestor As Employee
#End Region

#Region "Constructors"
    Public Sub New()
      MyBase.New()
      InitializeComponent()
      EventWiring()
      Initialize()
      MessageBox.Show("1")
      SetLabelText()
      MessageBox.Show("2")
      LoopControl(Me)
    End Sub
#End Region

#Region "Properties"

    Public Property DocDateEnd() As Date      Get        Return m_DocDateEnd      End Get      Set(ByVal Value As Date)        m_DocDateEnd = Value      End Set    End Property#End Region

#Region "Methods"
    Private Sub Initialize()
      RegisterDropdown()
      ClearCriterias()
    End Sub
    Private Sub RegisterDropdown()
      ' รูปแบบ
      With cmbDetailed.Items
        .Add("Summary")
        .Add("Show Documents")
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

      Me.DocDateEnd = Date.Now
      Me.txtDocDateEnd.Text = MinDateToNull(Me.DocDateEnd, "")
      Me.dtpDocDateEnd.Value = Me.DocDateEnd
      m_cc = New CostCenter
      m_cc2 = New CostCenter
      m_requestor = New Employee
    End Sub
    Public Overrides Function GetFilterString() As String

    End Function
    Public Overrides Function GetFilterArray() As Filter()
      Dim arr(5) As Filter
      If Me.txtCostCenterCode.Text.Length = 0 Then
        arr(0) = New Filter("cc", DBNull.Value)
      Else
        arr(0) = New Filter("cc", m_cc)
      End If
      If Me.txtCostCenterCode.Text.Length = 0 Then
        arr(1) = New Filter("cc2", DBNull.Value)
      Else
        arr(1) = New Filter("cc2", m_cc2)
      End If
      arr(2) = New Filter("DocDateEnd", IIf(Me.DocDateEnd.Equals(Date.MinValue), DBNull.Value, Me.DocDateEnd))
      arr(3) = New Filter("Detailed", cmbDetailed.SelectedIndex)
      arr(4) = New Filter("NoDigit", Me.chkNoDigit.Checked)
      arr(5) = New Filter("requestor", Me.ValidIdOrDBNull(m_requestor))
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
          Try
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
          Catch ex As Exception
            MessageBox.Show(ex.StackTrace)
          End Try


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
    Private Sub txtToCostCenterCode2_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCCCode2.Validated
      CostCenter.GetCostCenter(txtCCCode2, Me.txtCCName2, Me.m_cc2)
    End Sub
    Private Sub txtRequestorCode_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtRequestorCode.Validated
      Employee.GetEmployee(txtRequestorCode, Me.txtRequestorName, Me.m_requestor)
    End Sub
    Private Sub btnShowCostCenter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnShowCostCenter.Click, btnShowCostCenter2.Click
      Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      Select Case CType(sender, Control).Name.ToLower
        Case "btnshowcostcenter"
          myEntityPanelService.OpenListDialog(New CostCenter, AddressOf SetCostCenter)
        Case "btnshowcostcenter2"
          myEntityPanelService.OpenListDialog(New CostCenter, AddressOf SetCostCenter2)
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
    Private Sub SetCostCenter2(ByVal e As ISimpleEntity)
      Me.txtCCCode2.Text = e.Code
      CostCenter.GetCostCenter(txtCCCode2, txtCCName2, Me.m_cc2)
    End Sub
    Private Sub SetEmployee(ByVal e As ISimpleEntity)
      Me.txtRequestorCode.Text = e.Code
      Employee.GetEmployee(txtRequestorCode, txtRequestorName, Me.m_requestor)
    End Sub
#End Region
  End Class

End Namespace

