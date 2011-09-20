Imports Longkong.Pojjaman.BusinessLogic
Imports Longkong.Pojjaman.Services
Imports Longkong.Core.Services
Namespace Longkong.Pojjaman.Gui.Panels
  Public Class ToolFilterSubPanel
    Inherits AbstractFilterSubPanel
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
    Friend WithEvents grbDetail As Longkong.Pojjaman.Gui.Components.FixedGroupBox
    Friend WithEvents lblCode As System.Windows.Forms.Label
    Friend WithEvents txtCode As System.Windows.Forms.TextBox
    Friend WithEvents btnSearch As System.Windows.Forms.Button
    Friend WithEvents btnReset As System.Windows.Forms.Button
    Friend WithEvents lblCC As System.Windows.Forms.Label
    Friend WithEvents txtCostCenterCode As System.Windows.Forms.TextBox
    Friend WithEvents cmbStatus As System.Windows.Forms.ComboBox
    Friend WithEvents lblStatus As System.Windows.Forms.Label
    Friend WithEvents txtCostCenterName As System.Windows.Forms.TextBox
    Friend WithEvents btnCostCenterDialog As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents btnCostCenterPanel As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents grbMainDetail As Longkong.Pojjaman.Gui.Components.FixedGroupBox
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents Validator As Longkong.Pojjaman.Gui.Components.PJMTextboxValidator
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
      Me.components = New System.ComponentModel.Container()
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ToolFilterSubPanel))
      Me.lblCode = New System.Windows.Forms.Label()
      Me.txtCode = New System.Windows.Forms.TextBox()
      Me.grbDetail = New Longkong.Pojjaman.Gui.Components.FixedGroupBox()
      Me.btnSearch = New System.Windows.Forms.Button()
      Me.btnReset = New System.Windows.Forms.Button()
      Me.grbMainDetail = New Longkong.Pojjaman.Gui.Components.FixedGroupBox()
      Me.cmbStatus = New System.Windows.Forms.ComboBox()
      Me.lblStatus = New System.Windows.Forms.Label()
      Me.btnCostCenterPanel = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.txtCostCenterCode = New System.Windows.Forms.TextBox()
      Me.txtCostCenterName = New System.Windows.Forms.TextBox()
      Me.btnCostCenterDialog = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.lblCC = New System.Windows.Forms.Label()
      Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
      Me.Validator = New Longkong.Pojjaman.Gui.Components.PJMTextboxValidator(Me.components)
      Me.grbDetail.SuspendLayout()
      Me.grbMainDetail.SuspendLayout()
      CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.SuspendLayout()
      '
      'lblCode
      '
      Me.lblCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblCode.ForeColor = System.Drawing.Color.Black
      Me.lblCode.Location = New System.Drawing.Point(8, 16)
      Me.lblCode.Name = "lblCode"
      Me.lblCode.Size = New System.Drawing.Size(96, 18)
      Me.lblCode.TabIndex = 4
      Me.lblCode.Text = "รหัส:"
      Me.lblCode.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'txtCode
      '
      Me.Validator.SetDataType(Me.txtCode, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtCode, "")
      Me.txtCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtCode, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtCode, System.Drawing.Color.Empty)
      Me.txtCode.Location = New System.Drawing.Point(104, 16)
      Me.Validator.SetMinValue(Me.txtCode, "")
      Me.txtCode.Name = "txtCode"
      Me.Validator.SetRegularExpression(Me.txtCode, "")
      Me.Validator.SetRequired(Me.txtCode, False)
      Me.txtCode.Size = New System.Drawing.Size(271, 21)
      Me.txtCode.TabIndex = 0
      '
      'grbDetail
      '
      Me.grbDetail.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                  Or System.Windows.Forms.AnchorStyles.Left) _
                  Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.grbDetail.Controls.Add(Me.btnSearch)
      Me.grbDetail.Controls.Add(Me.btnReset)
      Me.grbDetail.Controls.Add(Me.grbMainDetail)
      Me.grbDetail.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.grbDetail.Location = New System.Drawing.Point(7, 0)
      Me.grbDetail.Name = "grbDetail"
      Me.grbDetail.Size = New System.Drawing.Size(402, 137)
      Me.grbDetail.TabIndex = 0
      Me.grbDetail.TabStop = False
      '
      'btnSearch
      '
      Me.btnSearch.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnSearch.Location = New System.Drawing.Point(318, 108)
      Me.btnSearch.Name = "btnSearch"
      Me.btnSearch.Size = New System.Drawing.Size(75, 23)
      Me.btnSearch.TabIndex = 5
      Me.btnSearch.Text = "Search"
      '
      'btnReset
      '
      Me.btnReset.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnReset.Location = New System.Drawing.Point(237, 108)
      Me.btnReset.Name = "btnReset"
      Me.btnReset.Size = New System.Drawing.Size(75, 23)
      Me.btnReset.TabIndex = 4
      Me.btnReset.Text = "Reset"
      '
      'grbMainDetail
      '
      Me.grbMainDetail.Controls.Add(Me.cmbStatus)
      Me.grbMainDetail.Controls.Add(Me.lblStatus)
      Me.grbMainDetail.Controls.Add(Me.btnCostCenterPanel)
      Me.grbMainDetail.Controls.Add(Me.txtCostCenterCode)
      Me.grbMainDetail.Controls.Add(Me.txtCode)
      Me.grbMainDetail.Controls.Add(Me.txtCostCenterName)
      Me.grbMainDetail.Controls.Add(Me.lblCode)
      Me.grbMainDetail.Controls.Add(Me.btnCostCenterDialog)
      Me.grbMainDetail.Controls.Add(Me.lblCC)
      Me.grbMainDetail.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.grbMainDetail.Location = New System.Drawing.Point(8, 13)
      Me.grbMainDetail.Name = "grbMainDetail"
      Me.grbMainDetail.Size = New System.Drawing.Size(385, 91)
      Me.grbMainDetail.TabIndex = 0
      Me.grbMainDetail.TabStop = False
      Me.grbMainDetail.Text = "รายละเอียดทั่วไป"
      '
      'cmbStatus
      '
      Me.cmbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbStatus.Location = New System.Drawing.Point(104, 62)
      Me.cmbStatus.Name = "cmbStatus"
      Me.cmbStatus.Size = New System.Drawing.Size(224, 21)
      Me.cmbStatus.TabIndex = 3
      '
      'lblStatus
      '
      Me.lblStatus.BackColor = System.Drawing.Color.Transparent
      Me.lblStatus.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblStatus.ForeColor = System.Drawing.SystemColors.WindowText
      Me.lblStatus.Location = New System.Drawing.Point(8, 62)
      Me.lblStatus.Name = "lblStatus"
      Me.lblStatus.Size = New System.Drawing.Size(96, 18)
      Me.lblStatus.TabIndex = 7
      Me.lblStatus.Text = "สถานะ:"
      Me.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'btnCostCenterPanel
      '
      Me.btnCostCenterPanel.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnCostCenterPanel.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.btnCostCenterPanel.Location = New System.Drawing.Point(350, 39)
      Me.btnCostCenterPanel.Name = "btnCostCenterPanel"
      Me.btnCostCenterPanel.Size = New System.Drawing.Size(24, 23)
      Me.btnCostCenterPanel.TabIndex = 13
      Me.btnCostCenterPanel.TabStop = False
      Me.btnCostCenterPanel.ThemedImage = CType(resources.GetObject("btnCostCenterPanel.ThemedImage"), System.Drawing.Bitmap)
      '
      'txtCostCenterCode
      '
      Me.Validator.SetDataType(Me.txtCostCenterCode, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtCostCenterCode, "")
      Me.Validator.SetGotFocusBackColor(Me.txtCostCenterCode, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtCostCenterCode, System.Drawing.Color.Empty)
      Me.txtCostCenterCode.Location = New System.Drawing.Point(104, 39)
      Me.Validator.SetMinValue(Me.txtCostCenterCode, "")
      Me.txtCostCenterCode.Name = "txtCostCenterCode"
      Me.Validator.SetRegularExpression(Me.txtCostCenterCode, "")
      Me.Validator.SetRequired(Me.txtCostCenterCode, False)
      Me.txtCostCenterCode.Size = New System.Drawing.Size(80, 20)
      Me.txtCostCenterCode.TabIndex = 2
      '
      'txtCostCenterName
      '
      Me.Validator.SetDataType(Me.txtCostCenterName, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtCostCenterName, "")
      Me.Validator.SetGotFocusBackColor(Me.txtCostCenterName, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtCostCenterName, System.Drawing.Color.Empty)
      Me.txtCostCenterName.Location = New System.Drawing.Point(184, 39)
      Me.Validator.SetMinValue(Me.txtCostCenterName, "")
      Me.txtCostCenterName.Name = "txtCostCenterName"
      Me.txtCostCenterName.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtCostCenterName, "")
      Me.Validator.SetRequired(Me.txtCostCenterName, False)
      Me.txtCostCenterName.Size = New System.Drawing.Size(143, 20)
      Me.txtCostCenterName.TabIndex = 9
      Me.txtCostCenterName.TabStop = False
      '
      'btnCostCenterDialog
      '
      Me.btnCostCenterDialog.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnCostCenterDialog.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.btnCostCenterDialog.ForeColor = System.Drawing.SystemColors.Control
      Me.btnCostCenterDialog.Location = New System.Drawing.Point(326, 39)
      Me.btnCostCenterDialog.Name = "btnCostCenterDialog"
      Me.btnCostCenterDialog.Size = New System.Drawing.Size(24, 23)
      Me.btnCostCenterDialog.TabIndex = 12
      Me.btnCostCenterDialog.TabStop = False
      Me.btnCostCenterDialog.ThemedImage = CType(resources.GetObject("btnCostCenterDialog.ThemedImage"), System.Drawing.Bitmap)
      '
      'lblCC
      '
      Me.lblCC.BackColor = System.Drawing.Color.Transparent
      Me.lblCC.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblCC.ForeColor = System.Drawing.SystemColors.WindowText
      Me.lblCC.Location = New System.Drawing.Point(8, 39)
      Me.lblCC.Name = "lblCC"
      Me.lblCC.Size = New System.Drawing.Size(96, 18)
      Me.lblCC.TabIndex = 6
      Me.lblCC.Text = "CostCenter:"
      Me.lblCC.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'ErrorProvider1
      '
      Me.ErrorProvider1.ContainerControl = Me
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
      'toolFilterSubPanel
      '
      Me.Controls.Add(Me.grbDetail)
      Me.Name = "toolFilterSubPanel"
      Me.Size = New System.Drawing.Size(416, 148)
      Me.grbDetail.ResumeLayout(False)
      Me.grbMainDetail.ResumeLayout(False)
      Me.grbMainDetail.PerformLayout()
      CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
      Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Constructors"
    Public Sub New()
      MyBase.New()

      InitializeComponent()
      Initialize()
      SetLabelText()
      Me.LoopControl(Me)
    End Sub
#End Region

#Region "Members"
    Private m_requestor As Employee
    Private m_cc As CostCenter
    Private m_lci As LCIItem
    Private m_tool As Tool
    Private dummyCC As New CostCenter
    Private dummyLci As New LCIItem
    Private docDateStart As Date
    Private docDateEnd As Date
    Private receivingDateStart As Date
    Private receivingDateEnd As Date
    Private m_user As New User
#End Region

#Region "Methods"
    Public Sub Initialize()
      'AddHandler txtDocDateStart.Validated, AddressOf Me.ChangeProperty
      'AddHandler dtpDocDateStart.ValueChanged, AddressOf Me.ChangeProperty
      'AddHandler txtDocDateEnd.Validated, AddressOf Me.ChangeProperty
      'AddHandler dtpDocDateEnd.ValueChanged, AddressOf Me.ChangeProperty

      'AddHandler txtReceivingDateStart.Validated, AddressOf Me.ChangeProperty
      'AddHandler dtpReceivingDateStart.ValueChanged, AddressOf Me.ChangeProperty
      'AddHandler txtReceivingdateEnd.Validated, AddressOf Me.ChangeProperty
      'AddHandler dtpReceivingDateEnd.ValueChanged, AddressOf Me.ChangeProperty

      PopulateStatus()
      ClearCriterias()
    End Sub
    Private m_dateSetting As Boolean
    Public Sub ChangeProperty(ByVal sender As Object, ByVal e As EventArgs)
      Dim dirtyFlag As Boolean = False
      Select Case CType(sender, Control).Name.ToLower
        'Case "dtpdocdatestart"
        '  If Not Me.docDateStart.Equals(dtpDocDateStart.Value) Then
        '    If Not m_dateSetting Then
        '      Me.txtDocDateStart.Text = MinDateToNull(dtpDocDateStart.Value, Me.StringParserService.Parse("${res:Global.BlankDateText}"))
        '      Me.docDateStart = dtpDocDateStart.Value
        '    End If
        '    dirtyFlag = True
        '  End If
        'Case "txtdocdatestart"
        '  m_dateSetting = True
        '  If Not Me.txtDocDateStart.Text.Length = 0 AndAlso Me.Validator.GetErrorMessage(Me.txtDocDateStart) = "" Then
        '    Dim theDate As Date = CDate(Me.txtDocDateStart.Text)
        '    If Not Me.docDateStart.Equals(theDate) Then
        '      dtpDocDateStart.Value = theDate
        '      Me.docDateStart = dtpDocDateStart.Value
        '      dirtyFlag = True
        '    End If
        '  Else
        '    Me.dtpDocDateStart.Value = Date.Now
        '    Me.docDateStart = Date.MinValue
        '    dirtyFlag = True
        '  End If
        '  m_dateSetting = False
        'Case "dtpdocdateend"
        '  If Not Me.docDateEnd.Equals(dtpDocDateEnd.Value) Then
        '    If Not m_dateSetting Then
        '      Me.txtDocDateEnd.Text = MinDateToNull(dtpDocDateEnd.Value, Me.StringParserService.Parse("${res:Global.BlankDateText}"))
        '      Me.docDateEnd = dtpDocDateEnd.Value
        '    End If
        '    dirtyFlag = True
        '  End If
        'Case "txtdocdateend"
        '  m_dateSetting = True
        '  If Not Me.txtDocDateEnd.Text.Length = 0 AndAlso Me.Validator.GetErrorMessage(Me.txtDocDateEnd) = "" Then
        '    Dim theDate As Date = CDate(Me.txtDocDateEnd.Text)
        '    If Not Me.docDateEnd.Equals(theDate) Then
        '      dtpDocDateEnd.Value = theDate
        '      Me.docDateEnd = dtpDocDateEnd.Value
        '      dirtyFlag = True
        '    End If
        '  Else
        '    Me.dtpDocDateEnd.Value = Date.Now
        '    Me.docDateEnd = Date.MinValue
        '    dirtyFlag = True
        '  End If
        '  m_dateSetting = False

        'Case "dtpreceivingdatestart"
        '  If Not Me.receivingDateStart.Equals(dtpReceivingDateStart.Value) Then
        '    If Not m_dateSetting Then
        '      Me.txtReceivingDateStart.Text = MinDateToNull(dtpReceivingDateStart.Value, Me.StringParserService.Parse("${res:Global.BlankDateText}"))
        '      Me.receivingDateStart = dtpReceivingDateStart.Value
        '    End If
        '    dirtyFlag = True
        '  End If
        'Case "txtreceivingdatestart"
        '  m_dateSetting = True
        '  If Not Me.txtReceivingDateStart.Text.Length = 0 AndAlso Me.Validator.GetErrorMessage(Me.txtReceivingDateStart) = "" Then
        '    Dim theDate As Date = CDate(Me.txtReceivingDateStart.Text)
        '    If Not Me.receivingDateStart.Equals(theDate) Then
        '      dtpReceivingDateStart.Value = theDate
        '      Me.receivingDateStart = dtpReceivingDateStart.Value
        '      dirtyFlag = True
        '    End If
        '  Else
        '    Me.dtpReceivingDateStart.Value = Date.Now
        '    Me.receivingDateStart = Date.MinValue
        '    dirtyFlag = True
        '  End If
        '  m_dateSetting = False
        'Case "dtpreceivingdateend"
        '  If Not Me.receivingDateEnd.Equals(dtpReceivingDateEnd.Value) Then
        '    If Not m_dateSetting Then
        '      Me.txtReceivingdateEnd.Text = MinDateToNull(dtpReceivingDateEnd.Value, Me.StringParserService.Parse("${res:Global.BlankDateText}"))
        '      Me.receivingDateEnd = dtpReceivingDateEnd.Value
        '    End If
        '    dirtyFlag = True
        '  End If
        'Case "txtreceivingdateend"
        '  m_dateSetting = True
        '  If Not Me.txtReceivingdateEnd.Text.Length = 0 AndAlso Me.Validator.GetErrorMessage(Me.txtReceivingdateEnd) = "" Then
        '    Dim theDate As Date = CDate(Me.txtReceivingdateEnd.Text)
        '    If Not Me.receivingDateEnd.Equals(theDate) Then
        '      dtpReceivingDateEnd.Value = theDate
        '      Me.receivingDateEnd = dtpReceivingDateEnd.Value
        '      dirtyFlag = True
        '    End If
        '  Else
        '    Me.dtpReceivingDateEnd.Value = Date.Now
        '    Me.receivingDateEnd = Date.MinValue
        '    dirtyFlag = True
        '  End If
        '  m_dateSetting = False
        'Case Else
      End Select
    End Sub
    Private Sub ClearCriterias()
      Me.txtCode.Text = ""
      Me.txtCostCenterCode.Text = ""
      Me.txtCostCenterName.Text = ""
      Me.m_cc = New CostCenter

      'Me.txtRequestorCode.Text = ""
      'Me.txtRequestorName.Text = ""
      'Me.m_requestor = New Employee

      'Me.txtLCI.Text = ""
      'Me.txtLCIName.Text = ""
      'Me.m_lci = New LCIItem

      'Me.txtTool.Text = ""
      'Me.txtToolName.Text = ""
      'Me.m_tool = New Tool

      'Me.txtBlank.Text = ""

      'Me.dtpDocDateStart.Value = DateAdd(DateInterval.Day, -14, Now.Date)
      'Me.dtpDocDateEnd.Value = Now.Date

      'Me.txtDocDateStart.Text = Me.MinDateToNull(DateAdd(DateInterval.Day, -14, Now.Date), "")
      'Me.txtDocDateEnd.Text = Me.MinDateToNull(Now.Date, "")

      Me.docDateStart = DateAdd(DateInterval.Month, -1, Now.Date)
      Me.docDateEnd = Now.Date

      'Me.dtpReceivingDateStart.Value = DateAdd(DateInterval.Day, -14, Now.Date)
      'Me.dtpReceivingDateEnd.Value = Now.Date

      'Me.txtReceivingDateStart.Text = Me.MinDateToNull(DateAdd(DateInterval.Day, -14, Now.Date), "")
      'Me.txtReceivingdateEnd.Text = Me.MinDateToNull(DateAdd(DateInterval.Day, 14, Now.Date), "")

      Me.receivingDateStart = DateAdd(DateInterval.Day, -14, Now.Date)
      Me.receivingDateEnd = DateAdd(DateInterval.Day, 14, Now.Date)

      Me.cmbStatus.SelectedIndex = 2
      'Me.cmbApproveLevel.SelectedIndex = 0

      'Me.txtApprovePerson.Text = ""
      'Me.txtApprovePersonName.Text = ""
      Me.m_user = New User

    End Sub
    Private Sub PopulateStatus()
      Dim myService As StringParserService = CType(ServiceManager.Services.GetService(GetType(StringParserService)), StringParserService)
      Dim lvString As String = Me.StringParserService.Parse("${res:Global.Level}")
      Dim notAppear As String = Me.StringParserService.Parse("${res:Global.Unspecified}")
      Dim dt1 As DataTable

      'CodeDescription.ListCodeDescriptionInComboBox(cmbStatus, "eqtstatus", True)
      dt1 = CodeDescription.GetCodeList("eqtstatus")
      For Each row As DataRow In dt1.Rows
        Dim item As New IdValuePair(CInt(row("code_value")), myService.Parse(CStr(row("code_description"))))
        cmbStatus.Items.Add(item)
      Next
      'dt1 = CodeDescription.GetCodeList("approve_status")
      'For Each row As DataRow In dt1.Rows
      '  Dim item As New IdValuePair(CInt(row("code_value")), myService.Parse(CStr(row("code_description"))))
      '  cmbStatus.Items.Add(item)
      'Next
      'dt1 = CodeDescription.GetCodeList("close_status")
      'For Each row As DataRow In dt1.Rows
      '  Dim item As New IdValuePair(CInt(row("code_value")), myService.Parse(CStr(row("code_description"))))
      '  cmbStatus.Items.Add(item)
      'Next

      'cmbApproveLevel.Items.Clear()
      'cmbApproveLevel.Items.Insert(0, New IdValuePair(-1, notAppear))
      'For i As Integer = 0 To User.MaxLevel
      '  Dim item As New IdValuePair(i, lvString & Space(1) & i.ToString)
      '  cmbApproveLevel.Items.Add(item)
      'Next
    End Sub
    Public Sub SetLabelText()
      Me.grbDetail.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PRFilterSubPanel.grbDetail}")
      Me.lblCode.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PRFilterSubPanel.lblCode}")
      Me.btnSearch.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PRFilterSubPanel.btnSearch}")
      Me.btnReset.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PRFilterSubPanel.btnReset}")
      'Me.grbDocDate.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PRFilterSubPanel.grbDocDate}")
      'Me.lblDocDateStart.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PRFilterSubPanel.lblDocDateStart}")
      'Me.lblDocDateEnd.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PRFilterSubPanel.lblDocDateEnd}")
      'Me.lblReceivingDateStart.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PRFilterSubPanel.lblReceivingDateStart}")
      'Me.lblReceivingDateEnd.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PRFilterSubPanel.lblReceivingDateEnd}")
      'Me.lblRequestor.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PRFilterSubPanel.lblRequestor}")
      Me.lblCC.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PRFilterSubPanel.lblCC}")
      'Me.grbReceivingDate.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PRFilterSubPanel.grbReceivingDate}")
      Me.lblStatus.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PRFilterSubPanel.lblStatus}")
      'Me.grbItem.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PRFilterSubPanel.grbItem}")
      'Me.lblLCI.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PRFilterSubPanel.lblLCI}")
      'Me.lblTool.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PRFilterSubPanel.lblTool}")
      'Me.lblBlank.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PRFilterSubPanel.lblBlank}")
      Me.grbMainDetail.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PRFilterSubPanel.grbMainDetail}")

      'Me.grbApprove.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PRFilterSubPanel.grbApprove}")
      'Me.lblApprovePerson.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PRFilterSubPanel.lblApprovePerson}")
      'Me.lblApproveLevel.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PRFilterSubPanel.lblApproveLevel}")
    End Sub
    Public Overrides Function GetFilterArray() As Filter()
      Dim arr(1) As Filter
      arr(0) = New Filter("code", IIf(Me.txtCode.Text.Length = 0, DBNull.Value, Me.txtCode.Text))
      'arr(1) = New Filter("requestor", IIf(Me.m_requestor.Valid, Me.m_requestor.Id, DBNull.Value))
      arr(1) = New Filter("fromCC", IIf(Me.m_cc.Valid, Me.m_cc.Id, DBNull.Value))
      'arr(3) = New Filter("docdatestart", ValidDateOrDBNull(docDateStart))
      'arr(4) = New Filter("docdateend", ValidDateOrDBNull(docDateEnd))
      'arr(5) = New Filter("receivingdatestart", ValidDateOrDBNull(receivingDateStart))
      'arr(6) = New Filter("receivingdateend", ValidDateOrDBNull(receivingDateEnd))
      'arr(2) = New Filter("status", IIf(cmbStatus.SelectedItem Is Nothing, DBNull.Value, CType(cmbStatus.SelectedItem, IdValuePair).Id))
      'arr(8) = New Filter("lci_id", IIf(Me.m_lci.Valid, Me.m_lci.Id, DBNull.Value))
      'arr(9) = New Filter("tool_id", IIf(Me.m_tool.Valid, Me.m_tool.Id, DBNull.Value))
      'arr(10) = New Filter("pri_itemName", IIf(Me.txtBlank.Text.Length = 0, DBNull.Value, Me.txtBlank.Text))
      'arr(11) = New Filter("userRight", CType(ServiceManager.Services.GetService(GetType(SecurityService)), SecurityService).CurrentUser.Id)
      'arr(12) = New Filter("ApprovePerson", ValidIdOrDBNull(m_user))
      'arr(13) = New Filter("ApproveLevel", IIf(cmbApproveLevel.SelectedItem Is Nothing, DBNull.Value, CType(cmbApproveLevel.SelectedItem, IdValuePair).Id))
      Return arr
    End Function
    Public Overrides ReadOnly Property SearchButton() As System.Windows.Forms.Button
      Get
        Return Me.btnSearch
      End Get
    End Property
#End Region

#Region "Event Handlers"
    'Private Sub txtApprovePerson_Validated(ByVal sender As Object, ByVal e As System.EventArgs)
    '  User.GetUser(txtApprovePerson, txtApprovePersonName, Me.m_user)
    'End Sub
    'Private Sub txtRequestorCode_Validated(ByVal sender As Object, ByVal e As System.EventArgs)
    '  Employee.GetEmployee(txtRequestorCode, txtRequestorName, Me.m_requestor)
    'End Sub
    Private Sub txtCostCenterCode_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCostCenterCode.Validated
      CostCenter.GetCostCenter(txtCostCenterCode, txtCostCenterName, Me.m_cc, CType(ServiceManager.Services.GetService(GetType(SecurityService)), SecurityService).CurrentUser.Id)
    End Sub
    Private Sub ibtnShowLCI_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
      Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      myEntityPanelService.OpenPanel(New LCIItem)
    End Sub

    Private Sub ibtnShowTool_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
      Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      myEntityPanelService.OpenPanel(New Tool)
    End Sub
    'Private Sub txtLCI_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '  LCIItem.GetLciitem(txtLCI, txtLCIName, Me.m_lci)
    'End Sub
    'Private Sub SetLCi(ByVal e As ISimpleEntity)
    '  Me.txtLCI.Text = e.Code
    '  LCIItem.GetLciitem(txtLCI, txtLCIName, Me.m_lci)
    'End Sub
    'Private Sub txtTool_Validated(ByVal sender As Object, ByVal e As System.EventArgs)
    '  Tool.GetTool(txtTool, txtToolName, Me.m_tool)
    'End Sub
    'Private Sub SetTool(ByVal e As ISimpleEntity)
    '  Me.txtTool.Text = e.Code
    '  Tool.GetTool(txtTool, txtToolName, Me.m_tool)
    'End Sub
    'Private Sub SetUser(ByVal e As ISimpleEntity)
    '  Me.txtApprovePerson.Text = e.Code
    '  User.GetUser(txtApprovePerson, txtApprovePersonName, Me.m_user)
    'End Sub
    'Private Sub btnFineApprove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '  Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
    '  myEntityPanelService.OpenListDialog(New User, AddressOf SetUser)
    'End Sub
    'Private Sub ibtnShowLCIDialog_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '  Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
    '  myEntityPanelService.OpenListDialog(New LCIItem, AddressOf SetLCi)
    'End Sub
    'Private Sub ibtnShowToolDialog_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '  Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
    '  myEntityPanelService.OpenListDialog(New Tool, AddressOf SetTool)
    'End Sub
    Private Sub btnReset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReset.Click
      ClearCriterias()
      Me.btnSearch.PerformClick()
    End Sub
    'Private Sub btnRequestorDialog_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '  Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
    '  myEntityPanelService.OpenListDialog(New Employee, AddressOf SetRequestor)
    'End Sub
    'Private Sub SetRequestor(ByVal e As ISimpleEntity)
    '  Me.txtRequestorCode.Text = e.Code
    '  Employee.GetEmployee(txtRequestorCode, txtRequestorName, Me.m_requestor)
    'End Sub
    Private Sub btnRequestorPanel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
      Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      myEntityPanelService.OpenPanel(New Employee)
    End Sub
    Private Sub btnCostCenterDialog_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCostCenterDialog.Click
      Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      myEntityPanelService.OpenTreeDialog(New CostCenter, AddressOf SetCostCenter)
    End Sub
    Private Sub SetCostCenter(ByVal e As ISimpleEntity)
      Me.txtCostCenterCode.Text = e.Code
      CostCenter.GetCostCenter(txtCostCenterCode, txtCostCenterName, Me.m_cc, CType(ServiceManager.Services.GetService(GetType(SecurityService)), SecurityService).CurrentUser.Id)
    End Sub
    Private Sub btnCostCenterPanel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCostCenterPanel.Click
      Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      myEntityPanelService.OpenPanel(New CostCenter)
    End Sub
#End Region

#Region "IClipboardHandler Overrides" 'Undone
    Public Overrides ReadOnly Property EnablePaste() As Boolean
      Get
        If Me.ActiveControl Is Nothing Then
          Return False
        End If
        Dim data As IDataObject = Clipboard.GetDataObject

        If data.GetDataPresent((dummyCC).FullClassName) Then
          Select Case Me.ActiveControl.Name.ToLower
            Case "txtcostcentercode", "txtcostcentername"
              Return True
          End Select
        End If
        If data.GetDataPresent((New Employee).FullClassName) Then
          Select Case Me.ActiveControl.Name.ToLower
            Case "txtrequestorcode", "txtrequestorname"
              Return True
          End Select
        End If
        If data.GetDataPresent((dummyLci).FullClassName) Then
          Select Case Me.ActiveControl.Name.ToLower
            Case "txtlci", "txtlciname"
              Return True
          End Select
        End If
        If data.GetDataPresent((New Tool).FullClassName) Then
          Select Case Me.ActiveControl.Name.ToLower
            Case "txttool", "txttoolname"
              Return True
          End Select
        End If
      End Get
    End Property
    Public Overrides Sub Paste(ByVal sender As Object, ByVal e As System.EventArgs)
      If Me.ActiveControl Is Nothing Then
        Return
      End If
      Dim data As IDataObject = Clipboard.GetDataObject
      If data.GetDataPresent((dummyCC).FullClassName) Then
        Dim id As Integer = CInt(data.GetData((New CostCenter).FullClassName))
        Dim entity As New CostCenter(id)
        Select Case Me.ActiveControl.Name.ToLower
          Case "txtcostcentercode", "txtcostcentername"
            Me.SetCostCenter(entity)
        End Select
      End If
      If data.GetDataPresent((New Employee).FullClassName) Then
        Dim id As Integer = CInt(data.GetData((New Employee).FullClassName))
        Dim entity As New Employee(id)
        Select Case Me.ActiveControl.Name.ToLower
          Case "txtrequestorcode", "txtrequestorname"
            'Me.SetRequestor(entity)
        End Select
      End If
      If data.GetDataPresent((dummyLci).FullClassName) Then
        Dim id As Integer = CInt(data.GetData((New LCIItem).FullClassName))
        Dim entity As New LCIItem(id)
        Select Case Me.ActiveControl.Name.ToLower
          Case "txtlci", "txtlciname"
            'Me.SetLCi(entity)
        End Select
      End If
      If data.GetDataPresent((New Tool).FullClassName) Then
        Dim id As Integer = CInt(data.GetData((New Tool).FullClassName))
        Dim entity As New Tool(id)
        Select Case Me.ActiveControl.Name.ToLower
          Case "txttool", "txttoolname"
            'Me.SetTool(entity)
        End Select
      End If
    End Sub
#End Region

#Region " Fixed Filters "
    Public Overrides Property Entities() As System.Collections.ArrayList
      Get
        Return MyBase.Entities
      End Get
      Set(ByVal Value As System.Collections.ArrayList)
        MyBase.Entities = Value
        EntityRefresh()
      End Set
    End Property
    Private Sub EntityRefresh()
      Dim myService As StringParserService = CType(ServiceManager.Services.GetService(GetType(StringParserService)), StringParserService)

      If Entities Is Nothing Then
        Return
      End If
      For Each entity As ISimpleEntity In Entities

        If TypeOf entity Is ToolForSelection Then
          Dim ent As ToolForSelection = CType(entity, ToolForSelection)
          Dim dt1 As DataTable = Nothing
          cmbStatus.Items.Clear()
          If ent.entityId = 345 Then 'Equipment Tool withdraw 
            'only ว่าง 
            dt1 = CodeDescription.GetCodeList("eqtstatus", "code_value in(2)")
          ElseIf ent.entityId = 348 Then 'Equipment Tool Return
            'only เบิก
            dt1 = CodeDescription.GetCodeList("eqtstatus", "code_value in(3)")
          ElseIf ent.entityId = 349 Then 'Equipment Tool Change Status
            'ว่าง รอซ่อม ส่งซ่อม ชำรุดพัง หาย
            dt1 = CodeDescription.GetCodeList("eqtstatus", "code_value in(2,5,6,7,8)")
          ElseIf ent.entityId = 350 Then 'Equipment Tool Rent
            'only ว่าง และ ให้เช่า
            dt1 = CodeDescription.GetCodeList("eqtstatus", "code_value in(2,4)")
          ElseIf ent.EntityId = 354 Then 'Equipment Tool Rent
            CodeDescription.ListCodeDescriptionInComboBox(cmbStatus, "eqtstatus", "code_value =" & ent.fromstatus.Value.ToString, False)
            cmbStatus.SelectedIndex = 0
            cmbStatus.Enabled = False
          End If
          If dt1 IsNot Nothing Then
            For Each row As DataRow In dt1.Rows
              Dim item As New IdValuePair(CInt(row("code_value")), myService.Parse(CStr(row("code_description"))))
              cmbStatus.Items.Add(item)
            Next
          End If

          If entity.Status.Value <> -1 Then
            CodeDescription.ComboSelect(Me.cmbStatus, entity.Status)
            Me.cmbStatus.Enabled = False
          End If
          If Me.cmbStatus.Items.Count = 0 Then
            Me.cmbStatus.Enabled = False
          End If
          Me.SetCostCenter(CType(ent.CC, CostCenter))
          Me.txtCostCenterCode.Enabled = False
          Me.txtCostCenterName.Enabled = False
          Me.btnCostCenterDialog.Enabled = False
          Me.btnCostCenterPanel.Enabled = False
          Me.btnReset.Enabled = False
        End If
        'If TypeOf entity Is EqtStatus Then
        '  Dim ty As EqtStatus = CType(entity, EqtStatus)
        '  CodeDescription.ListCodeDescriptionInComboBox(cmbStatus, "eqtstatus", "code_value =" & ty.Value.ToString, False)

        '  cmbStatus.Enabled = False
        'End If
        If TypeOf entity Is CostCenter Then

        End If
      Next
    End Sub
#End Region

  End Class
End Namespace

