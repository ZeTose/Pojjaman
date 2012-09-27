Imports Longkong.Pojjaman.BusinessLogic
Imports longkong.Pojjaman.Services
Imports Longkong.Core.Services

Namespace Longkong.Pojjaman.Gui.Panels
  Public Class RptMatCountDetailFilterSubPanel
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
    Friend WithEvents btnToCCend As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents txtToCCend As System.Windows.Forms.TextBox
    Friend WithEvents lblToCCend As System.Windows.Forms.Label
    Friend WithEvents btnToCCstart As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents txtToCCstart As System.Windows.Forms.TextBox
    Friend WithEvents lblToCCstart As System.Windows.Forms.Label
    Friend WithEvents txtDocDateEnd As System.Windows.Forms.TextBox
    Friend WithEvents dtpDocDateEnd As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblDocDateEnd As System.Windows.Forms.Label
    Friend WithEvents txtLciend As System.Windows.Forms.TextBox
    Friend WithEvents lblLciend As System.Windows.Forms.Label
    Friend WithEvents txtLcistart As System.Windows.Forms.TextBox
    Friend WithEvents lblLcistart As System.Windows.Forms.Label
    Friend WithEvents btnLciend As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents btnLcistart As Longkong.Pojjaman.Gui.Components.ImageButton
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Me.components = New System.ComponentModel.Container
            Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(RptMatCountDetailFilterSubPanel))
            Me.grbMaster = New Longkong.Pojjaman.Gui.Components.FixedGroupBox
            Me.grbDetail = New Longkong.Pojjaman.Gui.Components.FixedGroupBox
            Me.btnLciend = New Longkong.Pojjaman.Gui.Components.ImageButton
            Me.btnLcistart = New Longkong.Pojjaman.Gui.Components.ImageButton
            Me.txtLciend = New System.Windows.Forms.TextBox
            Me.lblLciend = New System.Windows.Forms.Label
            Me.txtLcistart = New System.Windows.Forms.TextBox
            Me.lblLcistart = New System.Windows.Forms.Label
            Me.txtDocDateEnd = New System.Windows.Forms.TextBox
            Me.dtpDocDateEnd = New System.Windows.Forms.DateTimePicker
            Me.lblDocDateEnd = New System.Windows.Forms.Label
            Me.btnToCCend = New Longkong.Pojjaman.Gui.Components.ImageButton
            Me.txtToCCend = New System.Windows.Forms.TextBox
            Me.lblToCCend = New System.Windows.Forms.Label
            Me.btnToCCstart = New Longkong.Pojjaman.Gui.Components.ImageButton
            Me.txtToCCstart = New System.Windows.Forms.TextBox
            Me.lblToCCstart = New System.Windows.Forms.Label
            Me.btnSearch = New System.Windows.Forms.Button
            Me.btnReset = New System.Windows.Forms.Button
            Me.Validator = New Longkong.Pojjaman.Gui.Components.PJMTextboxValidator(Me.components)
            Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider
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
            Me.grbMaster.Size = New System.Drawing.Size(488, 152)
            Me.grbMaster.TabIndex = 0
            Me.grbMaster.TabStop = False
            Me.grbMaster.Text = "เช็ครับ"
            '
            'grbDetail
            '
            Me.grbDetail.Controls.Add(Me.btnLciend)
            Me.grbDetail.Controls.Add(Me.btnLcistart)
            Me.grbDetail.Controls.Add(Me.txtLciend)
            Me.grbDetail.Controls.Add(Me.lblLciend)
            Me.grbDetail.Controls.Add(Me.txtLcistart)
            Me.grbDetail.Controls.Add(Me.lblLcistart)
            Me.grbDetail.Controls.Add(Me.txtDocDateEnd)
            Me.grbDetail.Controls.Add(Me.dtpDocDateEnd)
            Me.grbDetail.Controls.Add(Me.lblDocDateEnd)
            Me.grbDetail.Controls.Add(Me.btnToCCend)
            Me.grbDetail.Controls.Add(Me.txtToCCend)
            Me.grbDetail.Controls.Add(Me.lblToCCend)
            Me.grbDetail.Controls.Add(Me.btnToCCstart)
            Me.grbDetail.Controls.Add(Me.txtToCCstart)
            Me.grbDetail.Controls.Add(Me.lblToCCstart)
            Me.grbDetail.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.grbDetail.Location = New System.Drawing.Point(16, 16)
            Me.grbDetail.Name = "grbDetail"
            Me.grbDetail.Size = New System.Drawing.Size(464, 96)
            Me.grbDetail.TabIndex = 0
            Me.grbDetail.TabStop = False
            Me.grbDetail.Text = "ข้อมูลทั่วไป"
            '
            'btnLciend
            '
            Me.btnLciend.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.btnLciend.ForeColor = System.Drawing.SystemColors.Control
            Me.btnLciend.Image = CType(resources.GetObject("btnLciend.Image"), System.Drawing.Image)
            Me.btnLciend.Location = New System.Drawing.Point(408, 64)
            Me.btnLciend.Name = "btnLciend"
            Me.btnLciend.Size = New System.Drawing.Size(24, 22)
            Me.btnLciend.TabIndex = 14
            Me.btnLciend.TabStop = False
            Me.btnLciend.ThemedImage = CType(resources.GetObject("btnLciend.ThemedImage"), System.Drawing.Bitmap)
            '
            'btnLcistart
            '
            Me.btnLcistart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.btnLcistart.ForeColor = System.Drawing.SystemColors.Control
            Me.btnLcistart.Image = CType(resources.GetObject("btnLcistart.Image"), System.Drawing.Image)
            Me.btnLcistart.Location = New System.Drawing.Point(248, 64)
            Me.btnLcistart.Name = "btnLcistart"
            Me.btnLcistart.Size = New System.Drawing.Size(24, 22)
            Me.btnLcistart.TabIndex = 11
            Me.btnLcistart.TabStop = False
            Me.btnLcistart.ThemedImage = CType(resources.GetObject("btnLcistart.ThemedImage"), System.Drawing.Bitmap)
            '
            'txtLciend
            '
            Me.Validator.SetDataType(Me.txtLciend, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtLciend, "")
            Me.txtLciend.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtLciend, System.Drawing.Color.Empty)
            Me.ErrorProvider1.SetIconPadding(Me.txtLciend, -15)
            Me.Validator.SetInvalidBackColor(Me.txtLciend, System.Drawing.Color.Empty)
            Me.txtLciend.Location = New System.Drawing.Point(312, 64)
            Me.Validator.SetMaxValue(Me.txtLciend, "")
            Me.Validator.SetMinValue(Me.txtLciend, "")
            Me.txtLciend.Name = "txtLciend"
            Me.Validator.SetRegularExpression(Me.txtLciend, "")
            Me.Validator.SetRequired(Me.txtLciend, False)
            Me.txtLciend.Size = New System.Drawing.Size(96, 21)
            Me.txtLciend.TabIndex = 13
            Me.txtLciend.Text = ""
            '
            'lblLciend
            '
            Me.lblLciend.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblLciend.ForeColor = System.Drawing.Color.Black
            Me.lblLciend.Location = New System.Drawing.Point(280, 64)
            Me.lblLciend.Name = "lblLciend"
            Me.lblLciend.Size = New System.Drawing.Size(24, 18)
            Me.lblLciend.TabIndex = 12
            Me.lblLciend.Text = "ถึง"
            Me.lblLciend.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'txtLcistart
            '
            Me.Validator.SetDataType(Me.txtLcistart, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtLcistart, "")
            Me.txtLcistart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtLcistart, System.Drawing.Color.Empty)
            Me.ErrorProvider1.SetIconPadding(Me.txtLcistart, -15)
            Me.Validator.SetInvalidBackColor(Me.txtLcistart, System.Drawing.Color.Empty)
            Me.txtLcistart.Location = New System.Drawing.Point(152, 64)
            Me.Validator.SetMaxValue(Me.txtLcistart, "")
            Me.Validator.SetMinValue(Me.txtLcistart, "")
            Me.txtLcistart.Name = "txtLcistart"
            Me.Validator.SetRegularExpression(Me.txtLcistart, "")
            Me.Validator.SetRequired(Me.txtLcistart, False)
            Me.txtLcistart.Size = New System.Drawing.Size(96, 21)
            Me.txtLcistart.TabIndex = 10
            Me.txtLcistart.Text = ""
            '
            'lblLcistart
            '
            Me.lblLcistart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblLcistart.ForeColor = System.Drawing.Color.Black
            Me.lblLcistart.Location = New System.Drawing.Point(8, 64)
            Me.lblLcistart.Name = "lblLcistart"
            Me.lblLcistart.Size = New System.Drawing.Size(136, 18)
            Me.lblLcistart.TabIndex = 9
            Me.lblLcistart.Text = "ตั้งแต่รหัสวัสดุ"
            Me.lblLcistart.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtDocDateEnd
            '
            Me.Validator.SetDataType(Me.txtDocDateEnd, Longkong.Pojjaman.Gui.Components.DataTypeConstants.DateTimeType)
            Me.Validator.SetDisplayName(Me.txtDocDateEnd, "")
            Me.Validator.SetGotFocusBackColor(Me.txtDocDateEnd, System.Drawing.Color.Empty)
            Me.ErrorProvider1.SetIconPadding(Me.txtDocDateEnd, -15)
            Me.Validator.SetInvalidBackColor(Me.txtDocDateEnd, System.Drawing.Color.Empty)
            Me.txtDocDateEnd.Location = New System.Drawing.Point(152, 16)
            Me.txtDocDateEnd.MaxLength = 10
            Me.Validator.SetMaxValue(Me.txtDocDateEnd, "")
            Me.Validator.SetMinValue(Me.txtDocDateEnd, "")
            Me.txtDocDateEnd.Name = "txtDocDateEnd"
            Me.Validator.SetRegularExpression(Me.txtDocDateEnd, "")
            Me.Validator.SetRequired(Me.txtDocDateEnd, False)
            Me.txtDocDateEnd.Size = New System.Drawing.Size(99, 21)
            Me.txtDocDateEnd.TabIndex = 1
            Me.txtDocDateEnd.Text = ""
            '
            'dtpDocDateEnd
            '
            Me.dtpDocDateEnd.Format = System.Windows.Forms.DateTimePickerFormat.Short
            Me.dtpDocDateEnd.Location = New System.Drawing.Point(152, 16)
            Me.dtpDocDateEnd.Name = "dtpDocDateEnd"
            Me.dtpDocDateEnd.Size = New System.Drawing.Size(120, 21)
            Me.dtpDocDateEnd.TabIndex = 2
            Me.dtpDocDateEnd.TabStop = False
            '
            'lblDocDateEnd
            '
            Me.lblDocDateEnd.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblDocDateEnd.ForeColor = System.Drawing.Color.Black
            Me.lblDocDateEnd.Location = New System.Drawing.Point(16, 16)
            Me.lblDocDateEnd.Name = "lblDocDateEnd"
            Me.lblDocDateEnd.Size = New System.Drawing.Size(128, 18)
            Me.lblDocDateEnd.TabIndex = 0
            Me.lblDocDateEnd.Text = "ณ วันที่"
            Me.lblDocDateEnd.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'btnToCCend
            '
            Me.btnToCCend.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.btnToCCend.ForeColor = System.Drawing.SystemColors.Control
            Me.btnToCCend.Image = CType(resources.GetObject("btnToCCend.Image"), System.Drawing.Image)
            Me.btnToCCend.Location = New System.Drawing.Point(408, 40)
            Me.btnToCCend.Name = "btnToCCend"
            Me.btnToCCend.Size = New System.Drawing.Size(24, 22)
            Me.btnToCCend.TabIndex = 8
            Me.btnToCCend.TabStop = False
            Me.btnToCCend.ThemedImage = CType(resources.GetObject("btnToCCend.ThemedImage"), System.Drawing.Bitmap)
            '
            'txtToCCend
            '
            Me.Validator.SetDataType(Me.txtToCCend, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtToCCend, "")
            Me.txtToCCend.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtToCCend, System.Drawing.Color.Empty)
            Me.ErrorProvider1.SetIconPadding(Me.txtToCCend, -15)
            Me.Validator.SetInvalidBackColor(Me.txtToCCend, System.Drawing.Color.Empty)
            Me.txtToCCend.Location = New System.Drawing.Point(312, 40)
            Me.Validator.SetMaxValue(Me.txtToCCend, "")
            Me.Validator.SetMinValue(Me.txtToCCend, "")
            Me.txtToCCend.Name = "txtToCCend"
            Me.Validator.SetRegularExpression(Me.txtToCCend, "")
            Me.Validator.SetRequired(Me.txtToCCend, False)
            Me.txtToCCend.Size = New System.Drawing.Size(96, 21)
            Me.txtToCCend.TabIndex = 7
            Me.txtToCCend.Text = ""
            '
            'lblToCCend
            '
            Me.lblToCCend.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblToCCend.ForeColor = System.Drawing.Color.Black
            Me.lblToCCend.Location = New System.Drawing.Point(280, 40)
            Me.lblToCCend.Name = "lblToCCend"
            Me.lblToCCend.Size = New System.Drawing.Size(24, 18)
            Me.lblToCCend.TabIndex = 6
            Me.lblToCCend.Text = "ถึง"
            Me.lblToCCend.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'btnToCCstart
            '
            Me.btnToCCstart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.btnToCCstart.ForeColor = System.Drawing.SystemColors.Control
            Me.btnToCCstart.Image = CType(resources.GetObject("btnToCCstart.Image"), System.Drawing.Image)
            Me.btnToCCstart.Location = New System.Drawing.Point(248, 40)
            Me.btnToCCstart.Name = "btnToCCstart"
            Me.btnToCCstart.Size = New System.Drawing.Size(24, 22)
            Me.btnToCCstart.TabIndex = 5
            Me.btnToCCstart.TabStop = False
            Me.btnToCCstart.ThemedImage = CType(resources.GetObject("btnToCCstart.ThemedImage"), System.Drawing.Bitmap)
            '
            'txtToCCstart
            '
            Me.Validator.SetDataType(Me.txtToCCstart, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtToCCstart, "")
            Me.txtToCCstart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtToCCstart, System.Drawing.Color.Empty)
            Me.ErrorProvider1.SetIconPadding(Me.txtToCCstart, -15)
            Me.Validator.SetInvalidBackColor(Me.txtToCCstart, System.Drawing.Color.Empty)
            Me.txtToCCstart.Location = New System.Drawing.Point(152, 40)
            Me.Validator.SetMaxValue(Me.txtToCCstart, "")
            Me.Validator.SetMinValue(Me.txtToCCstart, "")
            Me.txtToCCstart.Name = "txtToCCstart"
            Me.Validator.SetRegularExpression(Me.txtToCCstart, "")
            Me.Validator.SetRequired(Me.txtToCCstart, False)
            Me.txtToCCstart.Size = New System.Drawing.Size(96, 21)
            Me.txtToCCstart.TabIndex = 4
            Me.txtToCCstart.Text = ""
            '
            'lblToCCstart
            '
            Me.lblToCCstart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblToCCstart.ForeColor = System.Drawing.Color.Black
            Me.lblToCCstart.Location = New System.Drawing.Point(8, 40)
            Me.lblToCCstart.Name = "lblToCCstart"
            Me.lblToCCstart.Size = New System.Drawing.Size(136, 18)
            Me.lblToCCstart.TabIndex = 3
            Me.lblToCCstart.Text = "ตั้งแต่ Cost Center ขอเบิก"
            Me.lblToCCstart.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'btnSearch
            '
            Me.btnSearch.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.btnSearch.Location = New System.Drawing.Point(392, 120)
            Me.btnSearch.Name = "btnSearch"
            Me.btnSearch.TabIndex = 2
            Me.btnSearch.Text = "ค้นหา"
            '
            'btnReset
            '
            Me.btnReset.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.btnReset.Location = New System.Drawing.Point(312, 120)
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
            'RptMatCountDetailFilterSubPanel
            '
            Me.Controls.Add(Me.grbMaster)
            Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Name = "RptMatCountDetailFilterSubPanel"
            Me.Size = New System.Drawing.Size(512, 168)
            Me.grbMaster.ResumeLayout(False)
            Me.grbDetail.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

#End Region

#Region " SetLabelText "
    Public Sub SetLabelText()
      'If Not m_entity Is Nothing Then Me.Text = Me.StringParserService.Parse(Me.m_entity.TabPageText)

      Me.lblToCCstart.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptMatCountDetailFilterSubPanel.lblToCCstart}")
      Me.Validator.SetDisplayName(txtToCCstart, lblToCCstart.Text)

      ' Global {ถึง}
      Me.lblDocDateEnd.Text = Me.StringParserService.Parse("${res:Global.FilterPanelTo}")
      Me.Validator.SetDisplayName(txtDocDateEnd, lblDocDateEnd.Text)

      Me.lblToCCend.Text = Me.StringParserService.Parse("${res:Global.FilterPanelTo}")
      Me.Validator.SetDisplayName(txtToCCend, lblToCCend.Text)

      ' Button
      Me.btnSearch.Text = Me.StringParserService.Parse("${res:Global.SearchButtonText}")
      Me.btnReset.Text = Me.StringParserService.Parse("${res:Global.ResetButtonText}")

      ' GroupBox
      Me.grbMaster.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptMatCountDetailFilterSubPanel.grbMaster}")
            Me.grbDetail.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptMatCountDetailFilterSubPanel.grbDetail}")

            Me.lblLcistart.Text = Me.StringParserService.Parse("${res:Global.Lcistart}")
            Me.lblLciend.Text = Me.StringParserService.Parse("${res:Global.FilterPanelTo}")

    End Sub
#End Region

#Region "Member"
    Private m_DocDateEnd As Date
    Private m_DocDateStart As Date
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
#End Region

#Region "Methods"
    Private Sub RegisterDropdown()
      ' เรียงตาม 
      'RptMatReturnFilterOrderBy.ListCodeDescriptionInComboBox(Me.cmbOrderBy, "rpt_matreturn")
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

      Me.DocDateEnd = Date.Now
      Me.txtDocDateEnd.Text = MinDateToNull(Me.DocDateEnd, "")
      Me.dtpDocDateEnd.Value = Me.DocDateEnd

    End Sub
    Public Overrides Function GetFilterString() As String

    End Function
    Public Overrides Function GetFilterArray() As Filter()
      Dim arr(5) As Filter
      arr(0) = New Filter("DocDateEnd", IIf(Me.DocDateEnd.Equals(Date.MinValue), DBNull.Value, Me.DocDateEnd))
      arr(1) = New Filter("ToCCCodeStart", IIf(txtToCCstart.TextLength > 0, txtToCCstart.Text, DBNull.Value))
      arr(2) = New Filter("ToCCCodeEnd", IIf(txtToCCend.TextLength > 0, txtToCCend.Text, DBNull.Value))
      arr(3) = New Filter("userRight", CType(ServiceManager.Services.GetService(GetType(SecurityService)), SecurityService).CurrentUser.Id)
      arr(4) = New Filter("LCIStart", IIf(txtLcistart.TextLength > 0, txtLcistart.Text, DBNull.Value))
      arr(5) = New Filter("LCIEnd", IIf(txtLciend.TextLength > 0, txtLciend.Text, DBNull.Value))
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

      'DocDateEnd
      dpi = New DocPrintingItem
      dpi.Mapping = "DocDateEnd"
      dpi.Value = txtDocDateEnd.Text
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      'CostCenterStart
      dpi = New DocPrintingItem
      dpi.Mapping = "CostCenterStart"
      dpi.Value = txtToCCstart.Text
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      'CostCenterEnd
      dpi = New DocPrintingItem
      dpi.Mapping = "CostCenterEnd"
      dpi.Value = txtToCCend.Text
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

            'LciCodeStart
            dpi = New DocPrintingItem
            dpi.Mapping = "LciCodeStart"
            dpi.Value = txtLcistart.Text
            dpi.DataType = "System.String"
            dpiColl.Add(dpi)

            'LciCodeStart
            dpi = New DocPrintingItem
            dpi.Mapping = "LciCodeEnd"
            dpi.Value = txtLciend.Text
            dpi.DataType = "System.String"
            dpiColl.Add(dpi)

      Return dpiColl
    End Function
#End Region

#Region " ChangeProperty "
    Private Sub EventWiring()

      AddHandler btnToCCstart.Click, AddressOf Me.btnCostcenterFind_Click
      AddHandler btnToCCend.Click, AddressOf Me.btnCostcenterFind_Click

      AddHandler btnLcistart.Click, AddressOf Me.btnLCIFind_Click
      AddHandler btnLciend.Click, AddressOf Me.btnLCIFind_Click

      AddHandler txtToCCstart.Validated, AddressOf Me.ChangeProperty
      AddHandler txtToCCend.Validated, AddressOf Me.ChangeProperty

      AddHandler txtDocDateEnd.Validated, AddressOf Me.ChangeProperty

      AddHandler dtpDocDateEnd.ValueChanged, AddressOf Me.ChangeProperty
    End Sub

    Private m_dateSetting As Boolean
    Private Sub ChangeProperty(ByVal sender As Object, ByVal e As EventArgs)

      Select Case CType(sender, Control).Name.ToLower
        Case "txttoccstart"
          CostCenter.GetCostCenter(txtToCCstart, tempTxt, tempCC1, CType(ServiceManager.Services.GetService(GetType(SecurityService)), SecurityService).CurrentUser.Id)
        Case "txttoccend"
          CostCenter.GetCostCenter(txtToCCend, tempTxt, tempCC2, CType(ServiceManager.Services.GetService(GetType(SecurityService)), SecurityService).CurrentUser.Id)


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
        If data.GetDataPresent((New CostCenter).FullClassName) Then
          If Not Me.ActiveControl Is Nothing Then
            Select Case Me.ActiveControl.Name.ToLower

              Case "txttoccstart", "txttoccend"
                Return True
            End Select
          End If
        End If
      End Get
    End Property
    Public Overrides Sub Paste(ByVal sender As Object, ByVal e As System.EventArgs)
      Dim data As IDataObject = Clipboard.GetDataObject
      If data.GetDataPresent((New CostCenter).FullClassName) Then
        Dim id As Integer = CInt(data.GetData((New CostCenter).FullClassName))
        Dim entity As New CostCenter(id)
        If Not Me.ActiveControl Is Nothing Then
          Select Case Me.ActiveControl.Name.ToLower

            Case "txttoccstart"
              Me.SetToCCStartDialog(entity)

            Case "txttoccend"
              Me.SetToCCEndDialog(entity)

          End Select
        End If
      End If
    End Sub
#End Region

#Region " Event Handlers "
    Private Sub btnCostcenterFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
      Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      Select Case CType(sender, Control).Name.ToLower

        Case "btntoccstart"
          myEntityPanelService.OpenTreeDialog(New CostCenter, AddressOf SetToCCStartDialog)

        Case "btntoccend"
          myEntityPanelService.OpenTreeDialog(New CostCenter, AddressOf SetToCCEndDialog)

      End Select
    End Sub
    Private tempTxt As New TextBox
    Private tempCC1 As New CostCenter
    Private tempCC2 As New CostCenter
    Private Sub SetToCCStartDialog(ByVal e As ISimpleEntity)
      Me.txtToCCstart.Text = e.Code
      CostCenter.GetCostCenter(txtToCCstart, tempTxt, tempCC1, CType(ServiceManager.Services.GetService(GetType(SecurityService)), SecurityService).CurrentUser.Id)
    End Sub
    Private Sub SetToCCEndDialog(ByVal e As ISimpleEntity)
      Me.txtToCCend.Text = e.Code
      CostCenter.GetCostCenter(txtToCCend, tempTxt, tempCC2, CType(ServiceManager.Services.GetService(GetType(SecurityService)), SecurityService).CurrentUser.Id)
    End Sub

    ' LCI item ..
    Private Sub btnLCIFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
      Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      Select Case CType(sender, Control).Name.ToLower
        Case "btnlcistart"
          myEntityPanelService.OpenListDialog(New LCIItem, AddressOf SetLCIStartDialog)
        Case "btnlciend"
          myEntityPanelService.OpenListDialog(New LCIItem, AddressOf SetLCIEndDialog)
      End Select

    End Sub

    Private Sub SetLCIStartDialog(ByVal e As ISimpleEntity)
      Me.txtLcistart.Text = e.Code
    End Sub
    Private Sub SetLCIEndDialog(ByVal e As ISimpleEntity)
      Me.txtLciend.Text = e.Code
    End Sub
#End Region

        Private Sub grbMaster_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles grbMaster.Enter

        End Sub
    End Class
End Namespace

