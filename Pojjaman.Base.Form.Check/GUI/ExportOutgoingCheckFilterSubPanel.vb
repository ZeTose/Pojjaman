Imports Longkong.Pojjaman.BusinessLogic
Imports Longkong.Pojjaman.Services
Imports Longkong.Core.Services

Namespace Longkong.Pojjaman.Gui.Panels
  Public Class ExportOutgoingCheckFilterSubPanel
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
    Friend WithEvents btnSearch As System.Windows.Forms.Button
    Friend WithEvents btnReset As System.Windows.Forms.Button
    Friend WithEvents grbDocDate As Longkong.Pojjaman.Gui.Components.FixedGroupBox
    Friend WithEvents lblDocDateStart As System.Windows.Forms.Label
    Friend WithEvents lblDocDateEnd As System.Windows.Forms.Label
    Friend WithEvents dtpDocDateStart As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpDocDateEnd As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtBankName As System.Windows.Forms.TextBox
    Friend WithEvents btnBankFind As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents txtBankCode As System.Windows.Forms.TextBox
    Friend WithEvents txtDocDateStart As System.Windows.Forms.TextBox
    Friend WithEvents txtDocDateEnd As System.Windows.Forms.TextBox
    Friend WithEvents Validator As Longkong.Pojjaman.Gui.Components.PJMTextboxValidator
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents grbCode As Longkong.Pojjaman.Gui.Components.FixedGroupBox
    Friend WithEvents txtCode As System.Windows.Forms.TextBox
    Friend WithEvents lblCode As System.Windows.Forms.Label
    Friend WithEvents lblBank As System.Windows.Forms.Label
    Friend WithEvents txtBankAcctCode As System.Windows.Forms.TextBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
      Me.components = New System.ComponentModel.Container()
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ExportOutgoingCheckFilterSubPanel))
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
      Me.txtBankName = New System.Windows.Forms.TextBox()
      Me.btnBankFind = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.txtBankCode = New System.Windows.Forms.TextBox()
      Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
      Me.Validator = New Longkong.Pojjaman.Gui.Components.PJMTextboxValidator(Me.components)
      Me.txtBankAcctCode = New System.Windows.Forms.TextBox()
      Me.grbCode = New Longkong.Pojjaman.Gui.Components.FixedGroupBox()
      Me.lblCode = New System.Windows.Forms.Label()
      Me.txtCode = New System.Windows.Forms.TextBox()
      Me.lblBank = New System.Windows.Forms.Label()
      Me.grbDetail.SuspendLayout()
      Me.grbDocDate.SuspendLayout()
      CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.grbCode.SuspendLayout()
      Me.SuspendLayout()
      '
      'grbDetail
      '
      Me.grbDetail.Controls.Add(Me.grbCode)
      Me.grbDetail.Controls.Add(Me.grbDocDate)
      Me.grbDetail.Controls.Add(Me.btnSearch)
      Me.grbDetail.Controls.Add(Me.btnReset)
      Me.grbDetail.Controls.Add(Me.txtBankName)
      Me.grbDetail.Controls.Add(Me.lblBank)
      Me.grbDetail.Controls.Add(Me.btnBankFind)
      Me.grbDetail.Controls.Add(Me.txtBankCode)
      Me.grbDetail.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.grbDetail.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.grbDetail.Location = New System.Drawing.Point(8, 8)
      Me.grbDetail.Name = "grbDetail"
      Me.grbDetail.Size = New System.Drawing.Size(611, 144)
      Me.grbDetail.TabIndex = 0
      Me.grbDetail.TabStop = False
      Me.grbDetail.Text = "เช็คจ่าย"
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
      Me.grbDocDate.Location = New System.Drawing.Point(374, 20)
      Me.grbDocDate.Name = "grbDocDate"
      Me.grbDocDate.Size = New System.Drawing.Size(228, 77)
      Me.grbDocDate.TabIndex = 1
      Me.grbDocDate.TabStop = False
      Me.grbDocDate.Text = "วันที่ให้มีผล"
      '
      'txtDocDateStart
      '
      Me.txtDocDateStart.BackColor = System.Drawing.SystemColors.Window
      Me.Validator.SetDataType(Me.txtDocDateStart, Longkong.Pojjaman.Gui.Components.DataTypeConstants.DateTimeType)
      Me.Validator.SetDisplayName(Me.txtDocDateStart, "")
      Me.Validator.SetGotFocusBackColor(Me.txtDocDateStart, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtDocDateStart, System.Drawing.Color.Empty)
      Me.txtDocDateStart.Location = New System.Drawing.Point(74, 20)
      Me.Validator.SetMinValue(Me.txtDocDateStart, "")
      Me.txtDocDateStart.Name = "txtDocDateStart"
      Me.Validator.SetRegularExpression(Me.txtDocDateStart, "")
      Me.Validator.SetRequired(Me.txtDocDateStart, False)
      Me.txtDocDateStart.Size = New System.Drawing.Size(116, 21)
      Me.txtDocDateStart.TabIndex = 0
      '
      'txtDocDateEnd
      '
      Me.txtDocDateEnd.BackColor = System.Drawing.SystemColors.Window
      Me.Validator.SetDataType(Me.txtDocDateEnd, Longkong.Pojjaman.Gui.Components.DataTypeConstants.DateTimeType)
      Me.Validator.SetDisplayName(Me.txtDocDateEnd, "")
      Me.Validator.SetGotFocusBackColor(Me.txtDocDateEnd, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtDocDateEnd, System.Drawing.Color.Empty)
      Me.txtDocDateEnd.Location = New System.Drawing.Point(74, 44)
      Me.Validator.SetMinValue(Me.txtDocDateEnd, "")
      Me.txtDocDateEnd.Name = "txtDocDateEnd"
      Me.Validator.SetRegularExpression(Me.txtDocDateEnd, "")
      Me.Validator.SetRequired(Me.txtDocDateEnd, False)
      Me.txtDocDateEnd.Size = New System.Drawing.Size(116, 21)
      Me.txtDocDateEnd.TabIndex = 1
      '
      'lblDocDateStart
      '
      Me.lblDocDateStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblDocDateStart.ForeColor = System.Drawing.Color.Black
      Me.lblDocDateStart.Location = New System.Drawing.Point(12, 20)
      Me.lblDocDateStart.Name = "lblDocDateStart"
      Me.lblDocDateStart.Size = New System.Drawing.Size(56, 18)
      Me.lblDocDateStart.TabIndex = 0
      Me.lblDocDateStart.Text = "ตั้งแต่"
      Me.lblDocDateStart.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblDocDateEnd
      '
      Me.lblDocDateEnd.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblDocDateEnd.ForeColor = System.Drawing.Color.Black
      Me.lblDocDateEnd.Location = New System.Drawing.Point(12, 44)
      Me.lblDocDateEnd.Name = "lblDocDateEnd"
      Me.lblDocDateEnd.Size = New System.Drawing.Size(56, 18)
      Me.lblDocDateEnd.TabIndex = 2
      Me.lblDocDateEnd.Text = "ถึง"
      Me.lblDocDateEnd.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'dtpDocDateStart
      '
      Me.dtpDocDateStart.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
      Me.dtpDocDateStart.Location = New System.Drawing.Point(74, 20)
      Me.dtpDocDateStart.Name = "dtpDocDateStart"
      Me.dtpDocDateStart.Size = New System.Drawing.Size(144, 21)
      Me.dtpDocDateStart.TabIndex = 2
      '
      'dtpDocDateEnd
      '
      Me.dtpDocDateEnd.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
      Me.dtpDocDateEnd.Location = New System.Drawing.Point(74, 44)
      Me.dtpDocDateEnd.Name = "dtpDocDateEnd"
      Me.dtpDocDateEnd.Size = New System.Drawing.Size(144, 21)
      Me.dtpDocDateEnd.TabIndex = 3
      '
      'btnSearch
      '
      Me.btnSearch.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnSearch.Location = New System.Drawing.Point(527, 111)
      Me.btnSearch.Name = "btnSearch"
      Me.btnSearch.Size = New System.Drawing.Size(75, 23)
      Me.btnSearch.TabIndex = 3
      Me.btnSearch.Text = "ค้นหา"
      '
      'btnReset
      '
      Me.btnReset.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnReset.Location = New System.Drawing.Point(449, 111)
      Me.btnReset.Name = "btnReset"
      Me.btnReset.Size = New System.Drawing.Size(75, 23)
      Me.btnReset.TabIndex = 2
      Me.btnReset.Text = "เคลียร์"
      '
      'txtBankName
      '
      Me.txtBankName.BackColor = System.Drawing.SystemColors.Control
      Me.Validator.SetDataType(Me.txtBankName, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtBankName, "")
      Me.txtBankName.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtBankName, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtBankName, System.Drawing.Color.Empty)
      Me.txtBankName.Location = New System.Drawing.Point(185, 111)
      Me.Validator.SetMinValue(Me.txtBankName, "")
      Me.txtBankName.Name = "txtBankName"
      Me.txtBankName.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtBankName, "")
      Me.Validator.SetRequired(Me.txtBankName, False)
      Me.txtBankName.Size = New System.Drawing.Size(160, 21)
      Me.txtBankName.TabIndex = 15
      '
      'btnBankFind
      '
      Me.btnBankFind.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnBankFind.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.btnBankFind.ForeColor = System.Drawing.SystemColors.Control
      Me.btnBankFind.Location = New System.Drawing.Point(344, 111)
      Me.btnBankFind.Name = "btnBankFind"
      Me.btnBankFind.Size = New System.Drawing.Size(24, 23)
      Me.btnBankFind.TabIndex = 4
      Me.btnBankFind.TabStop = False
      Me.btnBankFind.ThemedImage = CType(resources.GetObject("btnBankFind.ThemedImage"), System.Drawing.Bitmap)
      '
      'txtBankCode
      '
      Me.Validator.SetDataType(Me.txtBankCode, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtBankCode, "")
      Me.txtBankCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtBankCode, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtBankCode, System.Drawing.Color.Empty)
      Me.txtBankCode.Location = New System.Drawing.Point(97, 111)
      Me.Validator.SetMinValue(Me.txtBankCode, "")
      Me.txtBankCode.Name = "txtBankCode"
      Me.Validator.SetRegularExpression(Me.txtBankCode, "")
      Me.Validator.SetRequired(Me.txtBankCode, False)
      Me.txtBankCode.Size = New System.Drawing.Size(88, 21)
      Me.txtBankCode.TabIndex = 3
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
      'txtBankAcctCode
      '
      Me.Validator.SetDataType(Me.txtBankAcctCode, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtBankAcctCode, "")
      Me.txtBankAcctCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtBankAcctCode, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtBankAcctCode, System.Drawing.Color.Empty)
      Me.txtBankAcctCode.Location = New System.Drawing.Point(120, 98)
      Me.Validator.SetMinValue(Me.txtBankAcctCode, "")
      Me.txtBankAcctCode.Name = "txtBankAcctCode"
      Me.Validator.SetRegularExpression(Me.txtBankAcctCode, "")
      Me.Validator.SetRequired(Me.txtBankAcctCode, False)
      Me.txtBankAcctCode.Size = New System.Drawing.Size(88, 21)
      Me.txtBankAcctCode.TabIndex = 14
      '
      'grbCode
      '
      Me.grbCode.Controls.Add(Me.txtCode)
      Me.grbCode.Controls.Add(Me.lblCode)
      Me.grbCode.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.grbCode.Location = New System.Drawing.Point(11, 20)
      Me.grbCode.Name = "grbCode"
      Me.grbCode.Size = New System.Drawing.Size(357, 77)
      Me.grbCode.TabIndex = 1
      Me.grbCode.TabStop = False
      Me.grbCode.Text = "เลขที่เอกสาร export, เอกสารเช็ค, เลขที่เช็ค, เลขที่ PV"
      '
      'lblCode
      '
      Me.lblCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblCode.ForeColor = System.Drawing.Color.Black
      Me.lblCode.Location = New System.Drawing.Point(8, 36)
      Me.lblCode.Name = "lblCode"
      Me.lblCode.Size = New System.Drawing.Size(70, 18)
      Me.lblCode.TabIndex = 0
      Me.lblCode.Text = "เลขที่"
      Me.lblCode.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'txtCode
      '
      Me.Validator.SetDataType(Me.txtCode, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtCode, "")
      Me.txtCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtCode, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtCode, System.Drawing.Color.Empty)
      Me.txtCode.Location = New System.Drawing.Point(86, 35)
      Me.Validator.SetMinValue(Me.txtCode, "")
      Me.txtCode.Name = "txtCode"
      Me.Validator.SetRegularExpression(Me.txtCode, "")
      Me.Validator.SetRequired(Me.txtCode, False)
      Me.txtCode.Size = New System.Drawing.Size(248, 21)
      Me.txtCode.TabIndex = 0
      '
      'lblBank
      '
      Me.lblBank.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblBank.ForeColor = System.Drawing.Color.Black
      Me.lblBank.Location = New System.Drawing.Point(19, 111)
      Me.lblBank.Name = "lblBank"
      Me.lblBank.Size = New System.Drawing.Size(70, 18)
      Me.lblBank.TabIndex = 13
      Me.lblBank.Text = "ธนาคาร:"
      Me.lblBank.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'ExportOutgoingCheckFilterSubPanel
      '
      Me.Controls.Add(Me.grbDetail)
      Me.Name = "ExportOutgoingCheckFilterSubPanel"
      Me.Size = New System.Drawing.Size(634, 192)
      Me.grbDetail.ResumeLayout(False)
      Me.grbDetail.PerformLayout()
      Me.grbDocDate.ResumeLayout(False)
      Me.grbDocDate.PerformLayout()
      CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
      Me.grbCode.ResumeLayout(False)
      Me.grbCode.PerformLayout()
      Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Member"
    Private m_bank As New Bank
    Private m_checkstatus As OutgoingCheckDocStatus
    Private docDateStart As Date
    Private docDateEnd As Date
#End Region

#Region "Constructors"
    Public Sub New()
      MyBase.New()

      InitializeComponent()
      Initialize()

      SetLabelText()
      LoopControl(Me)
    End Sub
#End Region

#Region "Properties"
    Private Property Bank() As Bank
      Get
        Return m_bank
      End Get
      Set(ByVal Value As Bank)
        m_bank = Value
      End Set
    End Property
#End Region

#Region "Methods"
    Private Sub Initialize()
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
      For Each ctrl As Control In grbDetail.Controls
        If TypeOf ctrl Is TextBox Then
          ctrl.Text = ""
        End If
      Next

      Me.Bank = New Bank

      Dim generalDocDateStartBeforeToday As Long = Configuration.GetConfig("GeneralDocDateStartBeforeToday")
      Dim generalDocDateEndAfterToday As Long = Configuration.GetConfig("GeneralDocDateEndAfterToday")
      Dim generalDueDateStartBeforeToday As Long = Configuration.GetConfig("GeneralDueDateStartBeforeToday")
      Dim generalDueDateEndAfterToday As Long = Configuration.GetConfig("GeneralDueDateEndAfterToday")

      Me.dtpDocDateStart.Value = DateAdd(DateInterval.Day, generalDocDateStartBeforeToday, Now.Date)
      Me.dtpDocDateEnd.Value = DateAdd(DateInterval.Day, generalDocDateEndAfterToday, Now.Date)

      Me.txtDocDateStart.Text = Me.MinDateToNull(DateAdd(DateInterval.Day, generalDocDateStartBeforeToday, Now.Date), "")
      Me.txtDocDateEnd.Text = Me.MinDateToNull(DateAdd(DateInterval.Day, generalDocDateEndAfterToday, Now.Date), "")

      EntityRefresh()
    End Sub

    Public Overrides Function GetFilterArray() As Filter()
      Dim arr(3) As Filter
      arr(0) = New Filter("code", IIf(txtCode.TextLength = 0, DBNull.Value, txtCode.Text))
      arr(1) = New Filter("bank", Me.ValidIdOrDBNull(Me.Bank))
      arr(2) = New Filter("DocDateStart", ValidDateOrDBNull(docDateStart))
      arr(3) = New Filter("DocDateEnd", ValidDateOrDBNull(docDateEnd))
      Return arr
    End Function

    Public Overrides ReadOnly Property SearchButton() As System.Windows.Forms.Button
      Get
        Return Me.btnSearch
      End Get
    End Property
#End Region

#Region "Event Handlers"
    Private Sub btnReset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReset.Click
      ClearCriterias()
      Me.btnSearch.PerformClick()
    End Sub
    ' BankAccount
    Private Sub txtBankCode_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtBankCode.Validated
      Bank.GetBank(txtBankCode, txtBankName, Me.Bank)
    End Sub
    Private Sub btnBankFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBankFind.Click
      Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      myEntityPanelService.OpenListDialog(New Bank, AddressOf SetBankDialog)
    End Sub
    Private Sub SetBankDialog(ByVal e As ISimpleEntity)
      Me.txtBankCode.Text = e.Code
      Bank.GetBank(txtBankCode, txtBankName, Me.Bank)
    End Sub

#End Region

#Region "IClipboardHandler Overrides"
    Public Overrides ReadOnly Property EnablePaste() As Boolean
      Get
        Dim data As IDataObject = Clipboard.GetDataObject
        If data.GetDataPresent((New Supplier).FullClassName) Then
          If Not Me.ActiveControl Is Nothing Then
            Select Case Me.ActiveControl.Name.ToLower
              Case "txtsuppliercode", "txtsuppliername"
                Return True
            End Select
          End If
        End If
        If data.GetDataPresent((New BankAccount).FullClassName) Then
          If Not Me.ActiveControl Is Nothing Then
            Select Case Me.ActiveControl.Name.ToLower
              Case "txtbankacctcode", "txtbankacctname"
                Return True
            End Select
          End If
        End If
      End Get
    End Property
#End Region

    Public Sub SetLabelText()
      'If Not m_entity Is Nothing Then Me.Text = Me.StringParserService.Parse(Me.m_entity.TabPageText)
      Me.grbDetail.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ExportOutgoingCheckFilterSubPanel.grbDetail}")
      Me.lblCode.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ExportOutgoingCheckFilterSubPanel.lblCode}")
      Me.grbDocDate.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ExportOutgoingCheckFilterSubPanel.grbDocDate}")
      Me.lblBank.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ExportOutgoingCheckFilterSubPanel.lblBankAcct}")
      Me.grbCode.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ExportOutgoingCheckFilterSubPanel.grbCode}")

      Me.btnSearch.Text = Me.StringParserService.Parse("${res:Global.SearchButtonText}")
      Me.btnReset.Text = Me.StringParserService.Parse("${res:Global.ResetButtonText}")
      Me.lblDocDateStart.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.OutgoingCheckFilterSubPanel.lblDocDateStart}")
      Me.lblDocDateEnd.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.OutgoingCheckFilterSubPanel.lblDocDateEnd}")

      'Me.lblCqcode.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.OutgoingCheckFilterSubPanel.lblCqcode}")
    End Sub
    Public Overrides Property Entities() As System.Collections.ArrayList
      Get
        Return MyBase.Entities
      End Get
      Set(ByVal Value As System.Collections.ArrayList)
        MyBase.Entities = Value
        'EntityRefresh()
      End Set
    End Property
    Private Sub EntityRefresh()
      If Entities Is Nothing Then
        Return
      End If
      'For Each entity As ISimpleEntity In Entities

      '  If TypeOf entity Is OutgoingCheck Then
      '    ' set me.Includeref
      '    Me.IncludeRef = False

      '    Dim obj As OutgoingCheck = CType(entity, OutgoingCheck)
      '    If Not obj.DocStatus Is Nothing Then
      '      For Each item As IdValuePair In cmbStatus.Items
      '        If item.Id = obj.DocStatus.Value Then
      '          Me.cmbStatus.SelectedItem = item
      '        End If
      '      Next
      '      'Me.cmbStatus.SelectedIndex = obj.DocStatus.Value
      '      Me.cmbStatus.Enabled = False
      '    End If

      '    ' recieve person
      '    If obj.Supplier.Originated Then
      '      Me.SetSupplierDialog(obj.Supplier)
      '      Me.txtSupplierCode.Enabled = False
      '      Me.txtSupplierName.Enabled = False
      '      Me.btnSupplierEdit.Enabled = False
      '      Me.btnSupplierFind.Enabled = False
      '    End If
      '    ' customer 
      '    If obj.Bankacct.Originated Then
      '      Me.SetBankAccounDialog(obj.Bankacct)
      '      Me.txtBankAcctCode.Enabled = False
      '      Me.txtBankAcctName.Enabled = False
      '      Me.btnBankAcctEdit.Enabled = False
      '      Me.btnBankAcctFind.Enabled = False
      '    End If
      '  End If
      '  If TypeOf entity Is Supplier Then
      '    Me.SetSupplierDialog(CType(entity, Supplier))
      '    Me.txtSupplierCode.Enabled = False
      '    Me.txtSupplierName.Enabled = False
      '    Me.btnSupplierEdit.Enabled = False
      '    Me.btnSupplierFind.Enabled = False
      '  End If

      'Next
    End Sub
  End Class
End Namespace

