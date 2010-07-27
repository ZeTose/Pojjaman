Imports Longkong.Pojjaman.BusinessLogic
Imports Longkong.Pojjaman.Services
Imports Longkong.Core.Services
Namespace Longkong.Pojjaman.Gui.Panels
  Public Class GoodsReceiptForSelectFilterSubPanel
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
    Friend WithEvents grbDocDate As Longkong.Pojjaman.Gui.Components.FixedGroupBox
    Friend WithEvents lblDocDateStart As System.Windows.Forms.Label
    Friend WithEvents lblDocDateEnd As System.Windows.Forms.Label
    Friend WithEvents dtpDocDateStart As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpDocDateEnd As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblCC As System.Windows.Forms.Label
    Friend WithEvents txtCostCenterCode As System.Windows.Forms.TextBox
    Friend WithEvents txtCostCenterName As System.Windows.Forms.TextBox
    Friend WithEvents btnCostCenterDialog As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents btnCostCenterPanel As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents lblBlank As System.Windows.Forms.Label
    Friend WithEvents txtBlank As System.Windows.Forms.TextBox
    Friend WithEvents grbMainDetail As Longkong.Pojjaman.Gui.Components.FixedGroupBox
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents Validator As Longkong.Pojjaman.Gui.Components.PJMTextboxValidator
    Friend WithEvents txtDocDateStart As System.Windows.Forms.TextBox
    Friend WithEvents txtDocDateEnd As System.Windows.Forms.TextBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
      Me.components = New System.ComponentModel.Container()
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(GoodsReceiptForSelectFilterSubPanel))
      Me.lblCode = New System.Windows.Forms.Label()
      Me.txtCode = New System.Windows.Forms.TextBox()
      Me.grbDetail = New Longkong.Pojjaman.Gui.Components.FixedGroupBox()
      Me.grbDocDate = New Longkong.Pojjaman.Gui.Components.FixedGroupBox()
      Me.txtDocDateStart = New System.Windows.Forms.TextBox()
      Me.txtDocDateEnd = New System.Windows.Forms.TextBox()
      Me.lblDocDateStart = New System.Windows.Forms.Label()
      Me.lblDocDateEnd = New System.Windows.Forms.Label()
      Me.dtpDocDateStart = New System.Windows.Forms.DateTimePicker()
      Me.dtpDocDateEnd = New System.Windows.Forms.DateTimePicker()
      Me.btnSearch = New System.Windows.Forms.Button()
      Me.btnReset = New System.Windows.Forms.Button()
      Me.grbMainDetail = New Longkong.Pojjaman.Gui.Components.FixedGroupBox()
      Me.lblBlank = New System.Windows.Forms.Label()
      Me.txtBlank = New System.Windows.Forms.TextBox()
      Me.btnCostCenterPanel = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.txtCostCenterCode = New System.Windows.Forms.TextBox()
      Me.txtCostCenterName = New System.Windows.Forms.TextBox()
      Me.btnCostCenterDialog = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.lblCC = New System.Windows.Forms.Label()
      Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
      Me.Validator = New Longkong.Pojjaman.Gui.Components.PJMTextboxValidator(Me.components)
      Me.grbDetail.SuspendLayout()
      Me.grbDocDate.SuspendLayout()
      Me.grbMainDetail.SuspendLayout()
      CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.SuspendLayout()
      '
      'lblCode
      '
      Me.lblCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblCode.ForeColor = System.Drawing.Color.Black
      Me.lblCode.Location = New System.Drawing.Point(3, 16)
      Me.lblCode.Name = "lblCode"
      Me.lblCode.Size = New System.Drawing.Size(98, 18)
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
      Me.txtCode.Location = New System.Drawing.Point(101, 16)
      Me.Validator.SetMinValue(Me.txtCode, "")
      Me.txtCode.Name = "txtCode"
      Me.Validator.SetRegularExpression(Me.txtCode, "")
      Me.Validator.SetRequired(Me.txtCode, False)
      Me.txtCode.Size = New System.Drawing.Size(275, 21)
      Me.txtCode.TabIndex = 0
      '
      'grbDetail
      '
      Me.grbDetail.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                  Or System.Windows.Forms.AnchorStyles.Left) _
                  Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.grbDetail.Controls.Add(Me.grbDocDate)
      Me.grbDetail.Controls.Add(Me.btnSearch)
      Me.grbDetail.Controls.Add(Me.btnReset)
      Me.grbDetail.Controls.Add(Me.grbMainDetail)
      Me.grbDetail.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.grbDetail.Location = New System.Drawing.Point(7, 0)
      Me.grbDetail.Name = "grbDetail"
      Me.grbDetail.Size = New System.Drawing.Size(652, 119)
      Me.grbDetail.TabIndex = 0
      Me.grbDetail.TabStop = False
      '
      'grbDocDate
      '
      Me.grbDocDate.Controls.Add(Me.txtDocDateStart)
      Me.grbDocDate.Controls.Add(Me.txtDocDateEnd)
      Me.grbDocDate.Controls.Add(Me.lblDocDateStart)
      Me.grbDocDate.Controls.Add(Me.lblDocDateEnd)
      Me.grbDocDate.Controls.Add(Me.dtpDocDateStart)
      Me.grbDocDate.Controls.Add(Me.dtpDocDateEnd)
      Me.grbDocDate.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.grbDocDate.Location = New System.Drawing.Point(399, 12)
      Me.grbDocDate.Name = "grbDocDate"
      Me.grbDocDate.Size = New System.Drawing.Size(240, 71)
      Me.grbDocDate.TabIndex = 3
      Me.grbDocDate.TabStop = False
      Me.grbDocDate.Text = "วันที่เอกสาร"
      '
      'txtDocDateStart
      '
      Me.txtDocDateStart.BackColor = System.Drawing.SystemColors.Window
      Me.Validator.SetDataType(Me.txtDocDateStart, Longkong.Pojjaman.Gui.Components.DataTypeConstants.DateTimeType)
      Me.Validator.SetDisplayName(Me.txtDocDateStart, "")
      Me.Validator.SetGotFocusBackColor(Me.txtDocDateStart, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtDocDateStart, System.Drawing.Color.Empty)
      Me.txtDocDateStart.Location = New System.Drawing.Point(92, 16)
      Me.Validator.SetMinValue(Me.txtDocDateStart, "")
      Me.txtDocDateStart.Name = "txtDocDateStart"
      Me.Validator.SetRegularExpression(Me.txtDocDateStart, "")
      Me.Validator.SetRequired(Me.txtDocDateStart, False)
      Me.txtDocDateStart.Size = New System.Drawing.Size(118, 20)
      Me.txtDocDateStart.TabIndex = 1
      '
      'txtDocDateEnd
      '
      Me.txtDocDateEnd.BackColor = System.Drawing.SystemColors.Window
      Me.Validator.SetDataType(Me.txtDocDateEnd, Longkong.Pojjaman.Gui.Components.DataTypeConstants.DateTimeType)
      Me.Validator.SetDisplayName(Me.txtDocDateEnd, "")
      Me.Validator.SetGotFocusBackColor(Me.txtDocDateEnd, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtDocDateEnd, System.Drawing.Color.Empty)
      Me.txtDocDateEnd.Location = New System.Drawing.Point(92, 40)
      Me.Validator.SetMinValue(Me.txtDocDateEnd, "")
      Me.txtDocDateEnd.Name = "txtDocDateEnd"
      Me.Validator.SetRegularExpression(Me.txtDocDateEnd, "")
      Me.Validator.SetRequired(Me.txtDocDateEnd, False)
      Me.txtDocDateEnd.Size = New System.Drawing.Size(118, 20)
      Me.txtDocDateEnd.TabIndex = 2
      '
      'lblDocDateStart
      '
      Me.lblDocDateStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblDocDateStart.ForeColor = System.Drawing.Color.Black
      Me.lblDocDateStart.Location = New System.Drawing.Point(6, 17)
      Me.lblDocDateStart.Name = "lblDocDateStart"
      Me.lblDocDateStart.Size = New System.Drawing.Size(86, 18)
      Me.lblDocDateStart.TabIndex = 2
      Me.lblDocDateStart.Text = "ตั้งแต่"
      Me.lblDocDateStart.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblDocDateEnd
      '
      Me.lblDocDateEnd.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblDocDateEnd.ForeColor = System.Drawing.Color.Black
      Me.lblDocDateEnd.Location = New System.Drawing.Point(6, 41)
      Me.lblDocDateEnd.Name = "lblDocDateEnd"
      Me.lblDocDateEnd.Size = New System.Drawing.Size(86, 18)
      Me.lblDocDateEnd.TabIndex = 3
      Me.lblDocDateEnd.Text = "ถึง"
      Me.lblDocDateEnd.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'dtpDocDateStart
      '
      Me.dtpDocDateStart.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
      Me.dtpDocDateStart.Location = New System.Drawing.Point(92, 16)
      Me.dtpDocDateStart.Name = "dtpDocDateStart"
      Me.dtpDocDateStart.Size = New System.Drawing.Size(136, 20)
      Me.dtpDocDateStart.TabIndex = 4
      '
      'dtpDocDateEnd
      '
      Me.dtpDocDateEnd.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
      Me.dtpDocDateEnd.Location = New System.Drawing.Point(92, 40)
      Me.dtpDocDateEnd.Name = "dtpDocDateEnd"
      Me.dtpDocDateEnd.Size = New System.Drawing.Size(136, 20)
      Me.dtpDocDateEnd.TabIndex = 5
      '
      'btnSearch
      '
      Me.btnSearch.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnSearch.Location = New System.Drawing.Point(565, 90)
      Me.btnSearch.Name = "btnSearch"
      Me.btnSearch.Size = New System.Drawing.Size(75, 23)
      Me.btnSearch.TabIndex = 5
      Me.btnSearch.Text = "Search"
      '
      'btnReset
      '
      Me.btnReset.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnReset.Location = New System.Drawing.Point(484, 90)
      Me.btnReset.Name = "btnReset"
      Me.btnReset.Size = New System.Drawing.Size(75, 23)
      Me.btnReset.TabIndex = 4
      Me.btnReset.Text = "Reset"
      '
      'grbMainDetail
      '
      Me.grbMainDetail.Controls.Add(Me.lblBlank)
      Me.grbMainDetail.Controls.Add(Me.txtBlank)
      Me.grbMainDetail.Controls.Add(Me.btnCostCenterPanel)
      Me.grbMainDetail.Controls.Add(Me.txtCostCenterCode)
      Me.grbMainDetail.Controls.Add(Me.txtCode)
      Me.grbMainDetail.Controls.Add(Me.txtCostCenterName)
      Me.grbMainDetail.Controls.Add(Me.lblCode)
      Me.grbMainDetail.Controls.Add(Me.btnCostCenterDialog)
      Me.grbMainDetail.Controls.Add(Me.lblCC)
      Me.grbMainDetail.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.grbMainDetail.Location = New System.Drawing.Point(8, 12)
      Me.grbMainDetail.Name = "grbMainDetail"
      Me.grbMainDetail.Size = New System.Drawing.Size(385, 102)
      Me.grbMainDetail.TabIndex = 0
      Me.grbMainDetail.TabStop = False
      Me.grbMainDetail.Text = "รายละเอียดทั่วไป"
      '
      'lblBlank
      '
      Me.lblBlank.BackColor = System.Drawing.Color.Transparent
      Me.lblBlank.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblBlank.ForeColor = System.Drawing.SystemColors.WindowText
      Me.lblBlank.Location = New System.Drawing.Point(22, 67)
      Me.lblBlank.Name = "lblBlank"
      Me.lblBlank.Size = New System.Drawing.Size(79, 18)
      Me.lblBlank.TabIndex = 5
      Me.lblBlank.Text = "Blank:"
      Me.lblBlank.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'txtBlank
      '
      Me.Validator.SetDataType(Me.txtBlank, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtBlank, "")
      Me.Validator.SetGotFocusBackColor(Me.txtBlank, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtBlank, System.Drawing.Color.Empty)
      Me.txtBlank.Location = New System.Drawing.Point(102, 67)
      Me.Validator.SetMinValue(Me.txtBlank, "")
      Me.txtBlank.Name = "txtBlank"
      Me.Validator.SetRegularExpression(Me.txtBlank, "")
      Me.Validator.SetRequired(Me.txtBlank, False)
      Me.txtBlank.Size = New System.Drawing.Size(238, 20)
      Me.txtBlank.TabIndex = 6
      '
      'btnCostCenterPanel
      '
      Me.btnCostCenterPanel.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnCostCenterPanel.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.btnCostCenterPanel.Location = New System.Drawing.Point(353, 42)
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
      Me.txtCostCenterCode.Location = New System.Drawing.Point(101, 42)
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
      Me.txtCostCenterName.Location = New System.Drawing.Point(181, 42)
      Me.Validator.SetMinValue(Me.txtCostCenterName, "")
      Me.txtCostCenterName.Name = "txtCostCenterName"
      Me.txtCostCenterName.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtCostCenterName, "")
      Me.Validator.SetRequired(Me.txtCostCenterName, False)
      Me.txtCostCenterName.Size = New System.Drawing.Size(149, 20)
      Me.txtCostCenterName.TabIndex = 9
      Me.txtCostCenterName.TabStop = False
      '
      'btnCostCenterDialog
      '
      Me.btnCostCenterDialog.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnCostCenterDialog.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.btnCostCenterDialog.ForeColor = System.Drawing.SystemColors.Control
      Me.btnCostCenterDialog.Location = New System.Drawing.Point(329, 42)
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
      Me.lblCC.Location = New System.Drawing.Point(0, 42)
      Me.lblCC.Name = "lblCC"
      Me.lblCC.Size = New System.Drawing.Size(101, 18)
      Me.lblCC.TabIndex = 6
      Me.lblCC.Text = "CostCente :"
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
      'GoodsReceiptForSelectFilterSubPanel
      '
      Me.Controls.Add(Me.grbDetail)
      Me.Name = "GoodsReceiptForSelectFilterSubPanel"
      Me.Size = New System.Drawing.Size(666, 122)
      Me.grbDetail.ResumeLayout(False)
      Me.grbDocDate.ResumeLayout(False)
      Me.grbDocDate.PerformLayout()
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
    Private m_ccFrom As StoreCostCenter
    Private m_lci As LCIItem
    Private dummyCC As New CostCenter
    Private dummyLci As New LCIItem
    Private docDateStart As Date
    Private docDateEnd As Date
#End Region

#Region "Methods"
    Public Sub Initialize()
      AddHandler txtDocDateStart.Validated, AddressOf Me.ChangeProperty
      AddHandler dtpDocDateStart.ValueChanged, AddressOf Me.ChangeProperty
      AddHandler txtDocDateEnd.Validated, AddressOf Me.ChangeProperty
      AddHandler dtpDocDateEnd.ValueChanged, AddressOf Me.ChangeProperty

      ClearCriterias()
    End Sub
    Private m_dateSetting As Boolean
    Public Sub ChangeProperty(ByVal sender As Object, ByVal e As EventArgs)
      Dim dirtyFlag As Boolean = False
      Select Case CType(sender, Control).Name.ToLower
        Case "dtpdocdatestart"
          If Not Me.docDateStart.Equals(dtpDocDateStart.Value) Then
            If Not m_dateSetting Then
              Me.txtDocDateStart.Text = MinDateToNull(dtpDocDateStart.Value, Me.StringParserService.Parse("${res:Global.BlankDateText}"))
              Me.docDateStart = dtpDocDateStart.Value
            End If
            dirtyFlag = True
          End If
        Case "txtdocdatestart"
          m_dateSetting = True
          If Not Me.txtDocDateStart.Text.Length = 0 AndAlso Me.Validator.GetErrorMessage(Me.txtDocDateStart) = "" Then
            Dim theDate As Date = CDate(Me.txtDocDateStart.Text)
            If Not Me.docDateStart.Equals(theDate) Then
              dtpDocDateStart.Value = theDate
              Me.docDateStart = dtpDocDateStart.Value
              dirtyFlag = True
            End If
          Else
            Me.dtpDocDateStart.Value = Date.Now
            Me.docDateStart = Date.MinValue
            dirtyFlag = True
          End If
          m_dateSetting = False
        Case "dtpdocdateend"
          If Not Me.docDateEnd.Equals(dtpDocDateEnd.Value) Then
            If Not m_dateSetting Then
              Me.txtDocDateEnd.Text = MinDateToNull(dtpDocDateEnd.Value, Me.StringParserService.Parse("${res:Global.BlankDateText}"))
              Me.docDateEnd = dtpDocDateEnd.Value
            End If
            dirtyFlag = True
          End If
        Case "txtdocdateend"
          m_dateSetting = True
          If Not Me.txtDocDateEnd.Text.Length = 0 AndAlso Me.Validator.GetErrorMessage(Me.txtDocDateEnd) = "" Then
            Dim theDate As Date = CDate(Me.txtDocDateEnd.Text)
            If Not Me.docDateEnd.Equals(theDate) Then
              dtpDocDateEnd.Value = theDate
              Me.docDateEnd = dtpDocDateEnd.Value
              dirtyFlag = True
            End If
          Else
            Me.dtpDocDateEnd.Value = Date.Now
            Me.docDateEnd = Date.MinValue
            dirtyFlag = True
          End If
          m_dateSetting = False
        Case Else
      End Select
    End Sub
    Private Sub ClearCriterias()
      Me.txtCode.Text = ""

      Me.txtCostCenterCode.Text = ""
      Me.txtCostCenterName.Text = ""
      Me.m_cc = New CostCenter
      Me.m_ccFrom = New StoreCostCenter
      Me.EntityRefresh()

      'Me.txtRequestorCode.Text = ""
      'Me.txtRequestorName.Text = ""
      Me.m_requestor = New Employee

      'Me.txtLCI.Text = ""
      'Me.txtLCIName.Text = ""
      Me.m_lci = New LCIItem

      Me.txtBlank.Text = ""

      Me.dtpDocDateStart.Value = DateAdd(DateInterval.Day, -14, Now.Date)
      Me.dtpDocDateEnd.Value = Now.Date

      Me.txtDocDateStart.Text = Me.MinDateToNull(DateAdd(DateInterval.Day, -14, Now.Date), "")
      Me.txtDocDateEnd.Text = Me.MinDateToNull(Now.Date, "")

      Me.docDateStart = DateAdd(DateInterval.Month, -1, Now.Date)
      Me.docDateEnd = Now.Date

    End Sub
    Public Sub SetLabelText()
      Me.grbDetail.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PRFilterSubPanel.grbDetail}")
      Me.lblCode.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PRFilterSubPanel.lblCode}")
      Me.btnSearch.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PRFilterSubPanel.btnSearch}")
      Me.btnReset.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PRFilterSubPanel.btnReset}")
      Me.grbDocDate.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PRFilterSubPanel.grbDocDate}")
      Me.lblDocDateStart.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PRFilterSubPanel.lblDocDateStart}")
      Me.lblDocDateEnd.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PRFilterSubPanel.lblDocDateEnd}")
      'Me.lblRequestor.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PRFilterSubPanel.lblRequestor}")
      Me.lblCC.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PRFilterSubPanel.lblCC}")
      'Me.grbItem.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PRFilterSubPanel.grbItem}")
      'Me.lblLCI.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PRFilterSubPanel.lblLCI}")
      Me.lblBlank.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PRFilterSubPanel.lblBlank}")
      Me.grbMainDetail.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PRFilterSubPanel.grbMainDetail}")
      'Me.lblCostCenterFrom.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PRFilterSubPanel.CostCenterFrom}")
    End Sub
    Public Overrides Function GetFilterArray() As Filter()
      Dim arr(5) As Filter
      arr(0) = New Filter("code", IIf(Me.txtCode.Text.Length = 0, DBNull.Value, Me.txtCode.Text))
      arr(1) = New Filter("docdatestart", ValidDateOrDBNull(docDateStart))
      arr(2) = New Filter("docdateend", ValidDateOrDBNull(docDateEnd))
      arr(3) = New Filter("itemName", IIf(Me.txtBlank.Text.Length = 0, DBNull.Value, Me.txtBlank.Text))
      'arr(5) = New Filter("lci_id", IIf(Me.m_lci.Valid, Me.m_lci.Id, DBNull.Value))
      arr(4) = New Filter("userRight", CType(ServiceManager.Services.GetService(GetType(SecurityService)), SecurityService).CurrentUser.Id)
      arr(5) = New Filter("cc_id", IIf(Me.m_cc.Valid, Me.m_cc.Id, DBNull.Value))
      'arr(8) = New Filter("fromCC_id", IIf(Me.m_ccFrom.Valid, Me.m_ccFrom.Id, DBNull.Value))
      Return arr
    End Function
    Public Overrides ReadOnly Property SearchButton() As System.Windows.Forms.Button
      Get
        Return Me.btnSearch
      End Get
    End Property
#End Region

#Region "Event Handlers"
    Private Sub txtRequestorCode_Validated(ByVal sender As Object, ByVal e As System.EventArgs)
      'Employee.GetEmployee(txtRequestorCode, txtRequestorName, Me.m_requestor)
    End Sub
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
    Private Sub txtLCI_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs)
      'LCIItem.GetLciitem(txtLCI, txtLCIName, Me.m_lci)
    End Sub
    Private Sub SetLCi(ByVal e As ISimpleEntity)
      'Me.txtLCI.Text = e.Code
      'LCIItem.GetLciitem(txtLCI, txtLCIName, Me.m_lci)
    End Sub
    Private Sub ibtnShowLCIDialog_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
      Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      myEntityPanelService.OpenListDialog(New LCIItem, AddressOf SetLCi)
    End Sub
    Private Sub btnReset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReset.Click
      ClearCriterias()
      Me.btnSearch.PerformClick()
    End Sub
    Private Sub btnRequestorDialog_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
      Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      myEntityPanelService.OpenListDialog(New Employee, AddressOf SetRequestor)
    End Sub
    Private Sub SetRequestor(ByVal e As ISimpleEntity)
      'Me.txtRequestorCode.Text = e.Code
      'Employee.GetEmployee(txtRequestorCode, txtRequestorName, Me.m_requestor)
    End Sub
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
            Me.SetRequestor(entity)
        End Select
      End If
      If data.GetDataPresent((dummyLci).FullClassName) Then
        Dim id As Integer = CInt(data.GetData((New LCIItem).FullClassName))
        Dim entity As New LCIItem(id)
        Select Case Me.ActiveControl.Name.ToLower
          Case "txtlci", "txtlciname"
            Me.SetLCi(entity)
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
      If Entities Is Nothing Then
        Return
      End If
      For Each entity As ISimpleEntity In Entities

        If TypeOf entity Is PR Then
          'If entity.Status.Value <> -1 Then
          '  CodeDescription.ComboSelect(Me.cmbStatus, entity.Status)
          '  Me.cmbStatus.Enabled = False
          'End If
        End If
        If TypeOf entity Is CostCenter Then
          Me.SetCostCenter(CType(entity, CostCenter))
          Me.txtCostCenterCode.Enabled = False
          Me.txtCostCenterName.Enabled = False
          Me.btnCostCenterDialog.Enabled = False
          Me.btnCostCenterPanel.Enabled = False
        End If
        If TypeOf entity Is RequestCostCenter Then
          'Me.SetCostCenter(CType(entity, CostCenter))
          Me.m_cc = CType(entity, RequestCostCenter)
          Me.txtCostCenterCode.Text = Me.m_cc.Code
          Me.txtCostCenterName.Text = Me.m_cc.Name
          Me.txtCostCenterCode.Enabled = False
          Me.txtCostCenterName.Enabled = False
          Me.btnCostCenterDialog.Enabled = False
          Me.btnCostCenterPanel.Enabled = False
        End If
        'If TypeOf entity Is StoreCostCenter Then
        '  Me.m_ccFrom = CType(entity, StoreCostCenter)
        '  Me.txtCostCenterFrom.Text = Me.m_ccFrom.Code & " : " & Me.m_ccFrom.Name
        'End If
      Next
    End Sub
#End Region

    Private Sub txtCostCenterName_TabIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCostCenterName.TabIndexChanged

    End Sub

  End Class
End Namespace

