Imports Longkong.Pojjaman.BusinessLogic
Imports Longkong.Pojjaman.Services
Imports Longkong.Core.Services

Namespace Longkong.Pojjaman.Gui.Panels
  Public Class RptBankStatementFilterSubPanel
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
    Friend WithEvents lblDocDateStart As System.Windows.Forms.Label
    Friend WithEvents lblDocDateEnd As System.Windows.Forms.Label
    Friend WithEvents Validator As Longkong.Pojjaman.Gui.Components.PJMTextboxValidator
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents txtDocDateEnd As System.Windows.Forms.TextBox
    Friend WithEvents txtDocDateStart As System.Windows.Forms.TextBox
    Friend WithEvents dtpDocDateStart As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpDocDateEnd As System.Windows.Forms.DateTimePicker
    Friend WithEvents grbDetail As Longkong.Pojjaman.Gui.Components.FixedGroupBox
    Friend WithEvents btnBankacctend As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents txtBankacctend As System.Windows.Forms.TextBox
    Friend WithEvents lblBankacctend As System.Windows.Forms.Label
    Friend WithEvents btnBankacctstart As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents txtBankacctstart As System.Windows.Forms.TextBox
    Friend WithEvents lblBankAcctstart As System.Windows.Forms.Label
    Friend WithEvents txtBankCode As System.Windows.Forms.TextBox
    Friend WithEvents txtBankName As System.Windows.Forms.TextBox
    Friend WithEvents btnBankFind As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents lblBank As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
      Me.components = New System.ComponentModel.Container
      Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(RptBankStatementFilterSubPanel))
      Me.grbMaster = New Longkong.Pojjaman.Gui.Components.FixedGroupBox
      Me.grbDetail = New Longkong.Pojjaman.Gui.Components.FixedGroupBox
      Me.btnBankacctend = New Longkong.Pojjaman.Gui.Components.ImageButton
      Me.txtBankacctend = New System.Windows.Forms.TextBox
      Me.lblBankacctend = New System.Windows.Forms.Label
      Me.btnBankacctstart = New Longkong.Pojjaman.Gui.Components.ImageButton
      Me.txtBankacctstart = New System.Windows.Forms.TextBox
      Me.lblBankAcctstart = New System.Windows.Forms.Label
      Me.txtDocDateEnd = New System.Windows.Forms.TextBox
      Me.txtDocDateStart = New System.Windows.Forms.TextBox
      Me.dtpDocDateStart = New System.Windows.Forms.DateTimePicker
      Me.dtpDocDateEnd = New System.Windows.Forms.DateTimePicker
      Me.lblDocDateStart = New System.Windows.Forms.Label
      Me.lblDocDateEnd = New System.Windows.Forms.Label
      Me.btnSearch = New System.Windows.Forms.Button
      Me.btnReset = New System.Windows.Forms.Button
      Me.Validator = New Longkong.Pojjaman.Gui.Components.PJMTextboxValidator(Me.components)
      Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider
      Me.txtBankCode = New System.Windows.Forms.TextBox
      Me.txtBankName = New System.Windows.Forms.TextBox
      Me.btnBankFind = New Longkong.Pojjaman.Gui.Components.ImageButton
      Me.lblBank = New System.Windows.Forms.Label
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
      Me.grbMaster.Size = New System.Drawing.Size(448, 160)
      Me.grbMaster.TabIndex = 0
      Me.grbMaster.TabStop = False
      Me.grbMaster.Text = "เช็ครับ"
      '
      'grbDetail
      '
      Me.grbDetail.Controls.Add(Me.txtBankCode)
      Me.grbDetail.Controls.Add(Me.txtBankName)
      Me.grbDetail.Controls.Add(Me.btnBankFind)
      Me.grbDetail.Controls.Add(Me.lblBank)
      Me.grbDetail.Controls.Add(Me.btnBankacctend)
      Me.grbDetail.Controls.Add(Me.txtBankacctend)
      Me.grbDetail.Controls.Add(Me.lblBankacctend)
      Me.grbDetail.Controls.Add(Me.btnBankacctstart)
      Me.grbDetail.Controls.Add(Me.txtBankacctstart)
      Me.grbDetail.Controls.Add(Me.lblBankAcctstart)
      Me.grbDetail.Controls.Add(Me.txtDocDateEnd)
      Me.grbDetail.Controls.Add(Me.txtDocDateStart)
      Me.grbDetail.Controls.Add(Me.dtpDocDateStart)
      Me.grbDetail.Controls.Add(Me.dtpDocDateEnd)
      Me.grbDetail.Controls.Add(Me.lblDocDateStart)
      Me.grbDetail.Controls.Add(Me.lblDocDateEnd)
      Me.grbDetail.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.grbDetail.Location = New System.Drawing.Point(16, 16)
      Me.grbDetail.Name = "grbDetail"
      Me.grbDetail.Size = New System.Drawing.Size(416, 104)
      Me.grbDetail.TabIndex = 0
      Me.grbDetail.TabStop = False
      Me.grbDetail.Text = "ข้อมูลทั่วไป"
      '
      'btnBankacctend
      '
      Me.btnBankacctend.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.btnBankacctend.ForeColor = System.Drawing.SystemColors.Control
      Me.btnBankacctend.Image = CType(resources.GetObject("btnBankacctend.Image"), System.Drawing.Image)
      Me.btnBankacctend.Location = New System.Drawing.Point(376, 40)
      Me.btnBankacctend.Name = "btnBankacctend"
      Me.btnBankacctend.Size = New System.Drawing.Size(24, 22)
      Me.btnBankacctend.TabIndex = 11
      Me.btnBankacctend.TabStop = False
      Me.btnBankacctend.ThemedImage = CType(resources.GetObject("btnBankacctend.ThemedImage"), System.Drawing.Bitmap)
      '
      'txtBankacctend
      '
      Me.Validator.SetDataType(Me.txtBankacctend, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtBankacctend, "")
      Me.txtBankacctend.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtBankacctend, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtBankacctend, -15)
      Me.Validator.SetInvalidBackColor(Me.txtBankacctend, System.Drawing.Color.Empty)
      Me.txtBankacctend.Location = New System.Drawing.Point(280, 40)
      Me.Validator.SetMaxValue(Me.txtBankacctend, "")
      Me.Validator.SetMinValue(Me.txtBankacctend, "")
      Me.txtBankacctend.Name = "txtBankacctend"
      Me.Validator.SetRegularExpression(Me.txtBankacctend, "")
      Me.Validator.SetRequired(Me.txtBankacctend, False)
      Me.txtBankacctend.Size = New System.Drawing.Size(96, 21)
      Me.txtBankacctend.TabIndex = 10
      Me.txtBankacctend.Text = ""
      '
      'lblBankacctend
      '
      Me.lblBankacctend.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblBankacctend.ForeColor = System.Drawing.Color.Black
      Me.lblBankacctend.Location = New System.Drawing.Point(248, 40)
      Me.lblBankacctend.Name = "lblBankacctend"
      Me.lblBankacctend.Size = New System.Drawing.Size(24, 18)
      Me.lblBankacctend.TabIndex = 9
      Me.lblBankacctend.Text = "ถึง"
      Me.lblBankacctend.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
      '
      'btnBankacctstart
      '
      Me.btnBankacctstart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.btnBankacctstart.ForeColor = System.Drawing.SystemColors.Control
      Me.btnBankacctstart.Image = CType(resources.GetObject("btnBankacctstart.Image"), System.Drawing.Image)
      Me.btnBankacctstart.Location = New System.Drawing.Point(216, 40)
      Me.btnBankacctstart.Name = "btnBankacctstart"
      Me.btnBankacctstart.Size = New System.Drawing.Size(24, 22)
      Me.btnBankacctstart.TabIndex = 8
      Me.btnBankacctstart.TabStop = False
      Me.btnBankacctstart.ThemedImage = CType(resources.GetObject("btnBankacctstart.ThemedImage"), System.Drawing.Bitmap)
      '
      'txtBankacctstart
      '
      Me.Validator.SetDataType(Me.txtBankacctstart, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtBankacctstart, "")
      Me.txtBankacctstart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtBankacctstart, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtBankacctstart, -15)
      Me.Validator.SetInvalidBackColor(Me.txtBankacctstart, System.Drawing.Color.Empty)
      Me.txtBankacctstart.Location = New System.Drawing.Point(120, 40)
      Me.Validator.SetMaxValue(Me.txtBankacctstart, "")
      Me.Validator.SetMinValue(Me.txtBankacctstart, "")
      Me.txtBankacctstart.Name = "txtBankacctstart"
      Me.Validator.SetRegularExpression(Me.txtBankacctstart, "")
      Me.Validator.SetRequired(Me.txtBankacctstart, False)
      Me.txtBankacctstart.Size = New System.Drawing.Size(96, 21)
      Me.txtBankacctstart.TabIndex = 7
      Me.txtBankacctstart.Text = ""
      '
      'lblBankAcctstart
      '
      Me.lblBankAcctstart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblBankAcctstart.ForeColor = System.Drawing.Color.Black
      Me.lblBankAcctstart.Location = New System.Drawing.Point(8, 40)
      Me.lblBankAcctstart.Name = "lblBankAcctstart"
      Me.lblBankAcctstart.Size = New System.Drawing.Size(104, 18)
      Me.lblBankAcctstart.TabIndex = 6
      Me.lblBankAcctstart.Text = "สมุดเงินฝาก"
      Me.lblBankAcctstart.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'txtDocDateEnd
      '
      Me.Validator.SetDataType(Me.txtDocDateEnd, Longkong.Pojjaman.Gui.Components.DataTypeConstants.DateTimeType)
      Me.Validator.SetDisplayName(Me.txtDocDateEnd, "")
      Me.Validator.SetGotFocusBackColor(Me.txtDocDateEnd, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtDocDateEnd, -15)
      Me.Validator.SetInvalidBackColor(Me.txtDocDateEnd, System.Drawing.Color.Empty)
      Me.txtDocDateEnd.Location = New System.Drawing.Point(280, 16)
      Me.txtDocDateEnd.MaxLength = 10
      Me.Validator.SetMaxValue(Me.txtDocDateEnd, "")
      Me.Validator.SetMinValue(Me.txtDocDateEnd, "")
      Me.txtDocDateEnd.Name = "txtDocDateEnd"
      Me.Validator.SetRegularExpression(Me.txtDocDateEnd, "")
      Me.Validator.SetRequired(Me.txtDocDateEnd, False)
      Me.txtDocDateEnd.Size = New System.Drawing.Size(99, 21)
      Me.txtDocDateEnd.TabIndex = 4
      Me.txtDocDateEnd.Text = ""
      '
      'txtDocDateStart
      '
      Me.Validator.SetDataType(Me.txtDocDateStart, Longkong.Pojjaman.Gui.Components.DataTypeConstants.DateTimeType)
      Me.Validator.SetDisplayName(Me.txtDocDateStart, "")
      Me.Validator.SetGotFocusBackColor(Me.txtDocDateStart, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtDocDateStart, -15)
      Me.Validator.SetInvalidBackColor(Me.txtDocDateStart, System.Drawing.Color.Empty)
      Me.txtDocDateStart.Location = New System.Drawing.Point(120, 16)
      Me.txtDocDateStart.MaxLength = 10
      Me.Validator.SetMaxValue(Me.txtDocDateStart, "")
      Me.Validator.SetMinValue(Me.txtDocDateStart, "")
      Me.txtDocDateStart.Name = "txtDocDateStart"
      Me.Validator.SetRegularExpression(Me.txtDocDateStart, "")
      Me.Validator.SetRequired(Me.txtDocDateStart, False)
      Me.txtDocDateStart.Size = New System.Drawing.Size(99, 21)
      Me.txtDocDateStart.TabIndex = 1
      Me.txtDocDateStart.Text = ""
      '
      'dtpDocDateStart
      '
      Me.dtpDocDateStart.Format = System.Windows.Forms.DateTimePickerFormat.Short
      Me.dtpDocDateStart.Location = New System.Drawing.Point(120, 16)
      Me.dtpDocDateStart.Name = "dtpDocDateStart"
      Me.dtpDocDateStart.Size = New System.Drawing.Size(120, 21)
      Me.dtpDocDateStart.TabIndex = 2
      Me.dtpDocDateStart.TabStop = False
      '
      'dtpDocDateEnd
      '
      Me.dtpDocDateEnd.Format = System.Windows.Forms.DateTimePickerFormat.Short
      Me.dtpDocDateEnd.Location = New System.Drawing.Point(280, 16)
      Me.dtpDocDateEnd.Name = "dtpDocDateEnd"
      Me.dtpDocDateEnd.Size = New System.Drawing.Size(120, 21)
      Me.dtpDocDateEnd.TabIndex = 5
      Me.dtpDocDateEnd.TabStop = False
      '
      'lblDocDateStart
      '
      Me.lblDocDateStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblDocDateStart.ForeColor = System.Drawing.Color.Black
      Me.lblDocDateStart.Location = New System.Drawing.Point(8, 16)
      Me.lblDocDateStart.Name = "lblDocDateStart"
      Me.lblDocDateStart.Size = New System.Drawing.Size(104, 18)
      Me.lblDocDateStart.TabIndex = 0
      Me.lblDocDateStart.Text = "ตั้งแต่วันที่"
      Me.lblDocDateStart.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblDocDateEnd
      '
      Me.lblDocDateEnd.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblDocDateEnd.ForeColor = System.Drawing.Color.Black
      Me.lblDocDateEnd.Location = New System.Drawing.Point(248, 16)
      Me.lblDocDateEnd.Name = "lblDocDateEnd"
      Me.lblDocDateEnd.Size = New System.Drawing.Size(24, 18)
      Me.lblDocDateEnd.TabIndex = 3
      Me.lblDocDateEnd.Text = "ถึง"
      Me.lblDocDateEnd.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
      '
      'btnSearch
      '
      Me.btnSearch.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnSearch.Location = New System.Drawing.Point(360, 128)
      Me.btnSearch.Name = "btnSearch"
      Me.btnSearch.TabIndex = 2
      Me.btnSearch.Text = "ค้นหา"
      '
      'btnReset
      '
      Me.btnReset.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnReset.Location = New System.Drawing.Point(280, 128)
      Me.btnReset.Name = "btnReset"
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
      'txtBankCode
      '
      Me.Validator.SetDataType(Me.txtBankCode, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtBankCode, "")
      Me.txtBankCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtBankCode, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtBankCode, System.Drawing.Color.Empty)
      Me.txtBankCode.Location = New System.Drawing.Point(120, 64)
      Me.txtBankCode.MaxLength = 20
      Me.Validator.SetMaxValue(Me.txtBankCode, "")
      Me.Validator.SetMinValue(Me.txtBankCode, "")
      Me.txtBankCode.Name = "txtBankCode"
      Me.Validator.SetRegularExpression(Me.txtBankCode, "")
      Me.Validator.SetRequired(Me.txtBankCode, False)
      Me.txtBankCode.Size = New System.Drawing.Size(96, 21)
      Me.txtBankCode.TabIndex = 196
      Me.txtBankCode.Text = ""
      '
      'txtBankName
      '
      Me.txtBankName.BackColor = System.Drawing.SystemColors.Control
      Me.Validator.SetDataType(Me.txtBankName, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtBankName, "")
      Me.txtBankName.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtBankName, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtBankName, System.Drawing.Color.Empty)
      Me.txtBankName.Location = New System.Drawing.Point(216, 64)
      Me.Validator.SetMaxValue(Me.txtBankName, "")
      Me.Validator.SetMinValue(Me.txtBankName, "")
      Me.txtBankName.Name = "txtBankName"
      Me.txtBankName.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtBankName, "")
      Me.Validator.SetRequired(Me.txtBankName, False)
      Me.txtBankName.Size = New System.Drawing.Size(160, 21)
      Me.txtBankName.TabIndex = 195
      Me.txtBankName.Text = ""
      '
      'btnBankFind
      '
      Me.btnBankFind.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.btnBankFind.ForeColor = System.Drawing.SystemColors.Control
      Me.btnBankFind.Image = CType(resources.GetObject("btnBankFind.Image"), System.Drawing.Image)
      Me.btnBankFind.Location = New System.Drawing.Point(376, 63)
      Me.btnBankFind.Name = "btnBankFind"
      Me.btnBankFind.Size = New System.Drawing.Size(24, 23)
      Me.btnBankFind.TabIndex = 197
      Me.btnBankFind.TabStop = False
      Me.btnBankFind.ThemedImage = CType(resources.GetObject("btnBankFind.ThemedImage"), System.Drawing.Bitmap)
      '
      'lblBank
      '
      Me.lblBank.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblBank.ForeColor = System.Drawing.Color.Black
      Me.lblBank.Location = New System.Drawing.Point(24, 64)
      Me.lblBank.Name = "lblBank"
      Me.lblBank.Size = New System.Drawing.Size(88, 18)
      Me.lblBank.TabIndex = 194
      Me.lblBank.Text = "ธนาคาร/สาขา"
      Me.lblBank.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'RptBankStatementFilterSubPanel
      '
      Me.Controls.Add(Me.grbMaster)
      Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Name = "RptBankStatementFilterSubPanel"
      Me.Size = New System.Drawing.Size(464, 176)
      Me.grbMaster.ResumeLayout(False)
      Me.grbDetail.ResumeLayout(False)
      Me.ResumeLayout(False)

    End Sub

#End Region

#Region " SetLabelText "
    Public Sub SetLabelText()
      'If Not m_entity Is Nothing Then Me.Text = Me.StringParserService.Parse(Me.m_entity.TabPageText)
      Me.lblDocDateStart.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptBankStatementFilterSubPanel.lblDocDateStart}")
      Me.Validator.SetDisplayName(txtDocDateStart, lblDocDateStart.Text)

      Me.lblBankAcctstart.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptBankStatementFilterSubPanel.lblBankAcctstart}")
      Me.Validator.SetDisplayName(txtBankacctstart, lblBankAcctstart.Text)

      ' Global {ถึง}
      Me.lblDocDateEnd.Text = Me.StringParserService.Parse("${res:Global.FilterPanelTo}")
      Me.Validator.SetDisplayName(txtDocDateEnd, lblDocDateEnd.Text)

      Me.lblBankacctend.Text = Me.StringParserService.Parse("${res:Global.FilterPanelTo}")
      Me.Validator.SetDisplayName(txtBankacctend, lblBankacctend.Text)

      'ธนาคาร/สาขา
      Me.lblBank.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptBankStatementFilterSubPanel.lblBank}")

      ' Button
      Me.btnSearch.Text = Me.StringParserService.Parse("${res:Global.SearchButtonText}")
      Me.btnReset.Text = Me.StringParserService.Parse("${res:Global.ResetButtonText}")

      ' GroupBox
      Me.grbMaster.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptBankStatementFilterSubPanel.grbMaster}")
      Me.grbDetail.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptBankStatementFilterSubPanel.grbDetail}")
    End Sub
#End Region

#Region "Member"
    Private m_DocDateEnd As Date
    Private m_DocDateStart As Date
    Private m_Bank As Bank
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

    Public Property DocDateEnd() As Date      Get        Return m_DocDateEnd      End Get      Set(ByVal Value As Date)        m_DocDateEnd = Value      End Set    End Property    Public Property DocDateStart() As Date      Get        Return m_DocDateStart      End Get      Set(ByVal Value As Date)        m_DocDateStart = Value      End Set    End Property
    Public Property Bank() As Bank
      Get
        Return m_Bank
      End Get
      Set(ByVal Value As Bank)
        m_Bank = Value
      End Set
    End Property
#End Region

#Region "Methods"
    Private Sub RegisterDropdown()
      ' เรียงตาม 
    End Sub
    Private Sub Initialize()
      RegisterDropdown()
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

      Dim dtStart As Date = Date.Now.Subtract(New TimeSpan(7, 0, 0, 0))
      Me.DocDateStart = dtStart
      Me.txtDocDateStart.Text = MinDateToNull(Me.DocDateStart, "")
      Me.dtpDocDateStart.Value = Me.DocDateStart

      Me.DocDateEnd = Date.Now
      Me.txtDocDateEnd.Text = MinDateToNull(Me.DocDateEnd, "")
      Me.dtpDocDateEnd.Value = Me.DocDateEnd

      Me.Bank = New Bank

    End Sub
    Public Overrides Function GetFilterString() As String

    End Function
    Public Overrides Function GetFilterArray() As Filter()
      Dim arr(4) As Filter
      arr(0) = New Filter("DocDateStart", IIf(Me.DocDateStart.Equals(Date.MinValue), DBNull.Value, Me.DocDateStart))
      arr(1) = New Filter("DocDateEnd", IIf(Me.DocDateEnd.Equals(Date.MinValue), DBNull.Value, Me.DocDateEnd))
      arr(2) = New Filter("BankAcctCodeStart", IIf(txtBankacctstart.TextLength > 0, txtBankacctstart.Text, DBNull.Value))
      arr(3) = New Filter("BankAcctCodeEnd", IIf(txtBankacctend.TextLength > 0, txtBankacctend.Text, DBNull.Value))
      arr(4) = New Filter("Bankcode", Me.ValidIdOrDBNull(m_Bank))
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

      'docdate start
      dpi = New DocPrintingItem
      dpi.Mapping = "DocdateStart"
      dpi.Value = Me.txtDocDateStart.Text
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      'Docdate end
      dpi = New DocPrintingItem
      dpi.Mapping = "DocDateEnd"
      dpi.Value = Me.txtDocDateEnd.Text
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      'Bankacct start
      dpi = New DocPrintingItem
      dpi.Mapping = "BankacctStart"
      dpi.Value = Me.txtBankacctstart.Text
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      'Bankacct end
      dpi = New DocPrintingItem
      dpi.Mapping = "BankacctEnd"
      dpi.Value = Me.txtBankacctend.Text
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      'today
      dpi = New DocPrintingItem
      dpi.Mapping = "today"
      dpi.Value = MinDateToNull(Now, "") + " " + Now.ToShortTimeString
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)


      'Bank
      dpi = New DocPrintingItem
      dpi.Mapping = "Bank"
      dpi.Value = Me.txtBankCode.Text
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      Return dpiColl
    End Function
#End Region

#Region " ChangeProperty "
    Private Sub EventWiring()
      AddHandler btnBankacctstart.Click, AddressOf Me.btnBankAccountFind_Click
      AddHandler btnBankacctend.Click, AddressOf Me.btnBankAccountFind_Click

      AddHandler txtDocDateStart.Validated, AddressOf Me.ChangeProperty
      AddHandler txtDocDateEnd.Validated, AddressOf Me.ChangeProperty

      AddHandler dtpDocDateStart.ValueChanged, AddressOf Me.ChangeProperty
      AddHandler dtpDocDateEnd.ValueChanged, AddressOf Me.ChangeProperty

      'AddHandler txtBankCode.Validated, AddressOf Me.ChangeProperty
      'AddHandler btnBankFind.Click, AddressOf Me.btnBankFind_Click

    End Sub

    Private m_dateSetting As Boolean
    Private Sub ChangeProperty(ByVal sender As Object, ByVal e As EventArgs)

      Select Case CType(sender, Control).Name.ToLower
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
        Case "txtbankcode"
          Bank.GetBank(txtBankCode, Me.txtBankName, Bank)

          m_dateSetting = False

        Case Else

      End Select
    End Sub
#End Region

#Region "IClipboardHandler Overrides"
    Public Overrides ReadOnly Property EnablePaste() As Boolean
      Get
        Dim data As IDataObject = Clipboard.GetDataObject
        If data.GetDataPresent((New BankAccount).FullClassName) Then
          If Not Me.ActiveControl Is Nothing Then
            Select Case Me.ActiveControl.Name.ToLower
              Case "txtbankacctstart", "txtbankacctend"
                Return True

            End Select
          End If
        End If
        If data.GetDataPresent((New Bank).FullClassName) Then
          If Not Me.ActiveControl Is Nothing Then
            Select Case Me.ActiveControl.Name.ToLower
              Case "txtbankcode", "txtbankcodeend"
                Return True
            End Select
          End If
        End If

      End Get
    End Property
    Public Overrides Sub Paste(ByVal sender As Object, ByVal e As System.EventArgs)
      Dim data As IDataObject = Clipboard.GetDataObject
      If data.GetDataPresent((New BankAccount).FullClassName) Then
        Dim id As Integer = CInt(data.GetData((New BankAccount).FullClassName))
        Dim entity As New BankAccount(id)
        If Not Me.ActiveControl Is Nothing Then
          Select Case Me.ActiveControl.Name.ToLower
            Case "txtbankacctstart"
              Me.SetBankAccountStartDialog(entity)

            Case "txtbankacctend"
              Me.SetBankAccountEndDialog(entity)

          End Select
        End If
      End If
    End Sub
#End Region

#Region " Event Handlers "
    Private Sub btnBankAccountFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
      Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      Select Case CType(sender, Control).Name.ToLower
        Case "btnbankacctstart"
          myEntityPanelService.OpenListDialog(New BankAccount, AddressOf SetBankAccountStartDialog)

        Case "btnbankacctend"
          myEntityPanelService.OpenListDialog(New BankAccount, AddressOf SetBankAccountEndDialog)

      End Select
    End Sub
    Private Sub SetBankAccountStartDialog(ByVal e As ISimpleEntity)
      Me.txtBankacctstart.Text = e.Code
    End Sub
    Private Sub SetBankAccountEndDialog(ByVal e As ISimpleEntity)
      Me.txtBankacctend.Text = e.Code
    End Sub

    Private Sub btnBankFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBankFind.Click
      Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      myEntityPanelService.OpenListDialog(New Bank, AddressOf SetBank)
    End Sub
    Private Sub SetBank(ByVal e As ISimpleEntity)
      Me.txtBankCode.Text = e.Code
      Bank.GetBank(txtBankCode, txtBankName, Me.Bank)
    End Sub
#End Region

  End Class

End Namespace

