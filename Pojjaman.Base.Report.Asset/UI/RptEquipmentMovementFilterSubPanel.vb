Imports Longkong.Pojjaman.BusinessLogic
Imports longkong.Pojjaman.Services
Imports Longkong.Core.Services

Namespace Longkong.Pojjaman.Gui.Panels
  Public Class RptEquipmentMovementFilterSubPanel
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
    Friend WithEvents txtCCCodeStart As System.Windows.Forms.TextBox
    Friend WithEvents lblCCStart As System.Windows.Forms.Label
    Friend WithEvents txtEQCodeEnd As System.Windows.Forms.TextBox
    Friend WithEvents lblEQEnd As System.Windows.Forms.Label
    Friend WithEvents txtEQCodeStart As System.Windows.Forms.TextBox
    Friend WithEvents lblEQCode As System.Windows.Forms.Label
    Friend WithEvents btnEQStartFind As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents btnEQEndFind As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents btnCCStartFind As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents ChkCancel As System.Windows.Forms.CheckBox
    Friend WithEvents txttmp As System.Windows.Forms.TextBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
      Me.components = New System.ComponentModel.Container()
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(RptEquipmentMovementFilterSubPanel))
      Me.grbMaster = New Longkong.Pojjaman.Gui.Components.FixedGroupBox()
      Me.ChkCancel = New System.Windows.Forms.CheckBox()
      Me.grbDetail = New Longkong.Pojjaman.Gui.Components.FixedGroupBox()
      Me.btnCCStartFind = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.btnEQEndFind = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.btnEQStartFind = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.txtCCCodeStart = New System.Windows.Forms.TextBox()
      Me.lblCCStart = New System.Windows.Forms.Label()
      Me.txtEQCodeEnd = New System.Windows.Forms.TextBox()
      Me.lblEQEnd = New System.Windows.Forms.Label()
      Me.txtEQCodeStart = New System.Windows.Forms.TextBox()
      Me.lblEQCode = New System.Windows.Forms.Label()
      Me.txtDocDateEnd = New System.Windows.Forms.TextBox()
      Me.txtDocDateStart = New System.Windows.Forms.TextBox()
      Me.dtpDocDateStart = New System.Windows.Forms.DateTimePicker()
      Me.dtpDocDateEnd = New System.Windows.Forms.DateTimePicker()
      Me.lblDocDateStart = New System.Windows.Forms.Label()
      Me.lblDocDateEnd = New System.Windows.Forms.Label()
      Me.btnSearch = New System.Windows.Forms.Button()
      Me.btnReset = New System.Windows.Forms.Button()
      Me.Validator = New Longkong.Pojjaman.Gui.Components.PJMTextboxValidator(Me.components)
      Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
      Me.txttmp = New System.Windows.Forms.TextBox()
      Me.grbMaster.SuspendLayout()
      Me.grbDetail.SuspendLayout()
      CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.SuspendLayout()
      '
      'grbMaster
      '
      Me.grbMaster.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                  Or System.Windows.Forms.AnchorStyles.Left) _
                  Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.grbMaster.Controls.Add(Me.ChkCancel)
      Me.grbMaster.Controls.Add(Me.grbDetail)
      Me.grbMaster.Controls.Add(Me.btnSearch)
      Me.grbMaster.Controls.Add(Me.btnReset)
      Me.grbMaster.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.grbMaster.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.grbMaster.Location = New System.Drawing.Point(12, 8)
      Me.grbMaster.Name = "grbMaster"
      Me.grbMaster.Size = New System.Drawing.Size(449, 163)
      Me.grbMaster.TabIndex = 0
      Me.grbMaster.TabStop = False
      Me.grbMaster.Text = "ค้นหา"
      '
      'ChkCancel
      '
      Me.ChkCancel.Location = New System.Drawing.Point(8, 117)
      Me.ChkCancel.Name = "ChkCancel"
      Me.ChkCancel.Size = New System.Drawing.Size(240, 24)
      Me.ChkCancel.TabIndex = 4
      Me.ChkCancel.Text = "แสดงสินทรัพย์ยกเลิกสถานะ และ Write off"
      '
      'grbDetail
      '
      Me.grbDetail.Controls.Add(Me.btnCCStartFind)
      Me.grbDetail.Controls.Add(Me.btnEQEndFind)
      Me.grbDetail.Controls.Add(Me.btnEQStartFind)
      Me.grbDetail.Controls.Add(Me.txtCCCodeStart)
      Me.grbDetail.Controls.Add(Me.lblCCStart)
      Me.grbDetail.Controls.Add(Me.txtEQCodeEnd)
      Me.grbDetail.Controls.Add(Me.lblEQEnd)
      Me.grbDetail.Controls.Add(Me.txtEQCodeStart)
      Me.grbDetail.Controls.Add(Me.lblEQCode)
      Me.grbDetail.Controls.Add(Me.txtDocDateEnd)
      Me.grbDetail.Controls.Add(Me.txtDocDateStart)
      Me.grbDetail.Controls.Add(Me.dtpDocDateStart)
      Me.grbDetail.Controls.Add(Me.dtpDocDateEnd)
      Me.grbDetail.Controls.Add(Me.lblDocDateStart)
      Me.grbDetail.Controls.Add(Me.lblDocDateEnd)
      Me.grbDetail.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.grbDetail.Location = New System.Drawing.Point(6, 16)
      Me.grbDetail.Name = "grbDetail"
      Me.grbDetail.Size = New System.Drawing.Size(435, 95)
      Me.grbDetail.TabIndex = 0
      Me.grbDetail.TabStop = False
      Me.grbDetail.Text = "ข้อมูลทั่วไป"
      '
      'btnCCStartFind
      '
      Me.btnCCStartFind.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnCCStartFind.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.btnCCStartFind.ForeColor = System.Drawing.SystemColors.Control
      Me.btnCCStartFind.Location = New System.Drawing.Point(208, 62)
      Me.btnCCStartFind.Name = "btnCCStartFind"
      Me.btnCCStartFind.Size = New System.Drawing.Size(24, 22)
      Me.btnCCStartFind.TabIndex = 31
      Me.btnCCStartFind.TabStop = False
      Me.btnCCStartFind.ThemedImage = CType(resources.GetObject("btnCCStartFind.ThemedImage"), System.Drawing.Bitmap)
      '
      'btnEQEndFind
      '
      Me.btnEQEndFind.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnEQEndFind.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.btnEQEndFind.ForeColor = System.Drawing.SystemColors.Control
      Me.btnEQEndFind.Location = New System.Drawing.Point(380, 39)
      Me.btnEQEndFind.Name = "btnEQEndFind"
      Me.btnEQEndFind.Size = New System.Drawing.Size(24, 22)
      Me.btnEQEndFind.TabIndex = 30
      Me.btnEQEndFind.TabStop = False
      Me.btnEQEndFind.ThemedImage = CType(resources.GetObject("btnEQEndFind.ThemedImage"), System.Drawing.Bitmap)
      '
      'btnEQStartFind
      '
      Me.btnEQStartFind.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnEQStartFind.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.btnEQStartFind.ForeColor = System.Drawing.SystemColors.Control
      Me.btnEQStartFind.Location = New System.Drawing.Point(208, 39)
      Me.btnEQStartFind.Name = "btnEQStartFind"
      Me.btnEQStartFind.Size = New System.Drawing.Size(24, 22)
      Me.btnEQStartFind.TabIndex = 29
      Me.btnEQStartFind.TabStop = False
      Me.btnEQStartFind.ThemedImage = CType(resources.GetObject("btnEQStartFind.ThemedImage"), System.Drawing.Bitmap)
      '
      'txtCCCodeStart
      '
      Me.Validator.SetDataType(Me.txtCCCodeStart, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtCCCodeStart, "")
      Me.txtCCCodeStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtCCCodeStart, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtCCCodeStart, -15)
      Me.Validator.SetInvalidBackColor(Me.txtCCCodeStart, System.Drawing.Color.Empty)
      Me.txtCCCodeStart.Location = New System.Drawing.Point(112, 63)
      Me.Validator.SetMaxValue(Me.txtCCCodeStart, "")
      Me.Validator.SetMinValue(Me.txtCCCodeStart, "")
      Me.txtCCCodeStart.Name = "txtCCCodeStart"
      Me.Validator.SetRegularExpression(Me.txtCCCodeStart, "")
      Me.Validator.SetRequired(Me.txtCCCodeStart, False)
      Me.txtCCCodeStart.Size = New System.Drawing.Size(96, 21)
      Me.txtCCCodeStart.TabIndex = 6
      Me.txtCCCodeStart.Text = ""
      '
      'lblCCStart
      '
      Me.lblCCStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblCCStart.ForeColor = System.Drawing.Color.Black
      Me.lblCCStart.Location = New System.Drawing.Point(6, 63)
      Me.lblCCStart.Name = "lblCCStart"
      Me.lblCCStart.Size = New System.Drawing.Size(104, 18)
      Me.lblCCStart.TabIndex = 26
      Me.lblCCStart.Text = "CostCenter เจ้าของ"
      Me.lblCCStart.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'txtEQCodeEnd
      '
      Me.Validator.SetDataType(Me.txtEQCodeEnd, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtEQCodeEnd, "")
      Me.txtEQCodeEnd.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtEQCodeEnd, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtEQCodeEnd, -15)
      Me.Validator.SetInvalidBackColor(Me.txtEQCodeEnd, System.Drawing.Color.Empty)
      Me.txtEQCodeEnd.Location = New System.Drawing.Point(277, 39)
      Me.Validator.SetMinValue(Me.txtEQCodeEnd, "")
      Me.txtEQCodeEnd.Name = "txtEQCodeEnd"
      Me.Validator.SetRegularExpression(Me.txtEQCodeEnd, "")
      Me.Validator.SetRequired(Me.txtEQCodeEnd, False)
      Me.txtEQCodeEnd.Size = New System.Drawing.Size(102, 21)
      Me.txtEQCodeEnd.TabIndex = 5
      '
      'lblEQEnd
      '
      Me.lblEQEnd.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblEQEnd.ForeColor = System.Drawing.Color.Black
      Me.lblEQEnd.Location = New System.Drawing.Point(247, 39)
      Me.lblEQEnd.Name = "lblEQEnd"
      Me.lblEQEnd.Size = New System.Drawing.Size(24, 18)
      Me.lblEQEnd.TabIndex = 9
      Me.lblEQEnd.Text = "ถึง"
      Me.lblEQEnd.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
      '
      'txtEQCodeStart
      '
      Me.Validator.SetDataType(Me.txtEQCodeStart, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtEQCodeStart, "")
      Me.txtEQCodeStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtEQCodeStart, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtEQCodeStart, -15)
      Me.Validator.SetInvalidBackColor(Me.txtEQCodeStart, System.Drawing.Color.Empty)
      Me.txtEQCodeStart.Location = New System.Drawing.Point(112, 39)
      Me.Validator.SetMinValue(Me.txtEQCodeStart, "")
      Me.txtEQCodeStart.Name = "txtEQCodeStart"
      Me.Validator.SetRegularExpression(Me.txtEQCodeStart, "")
      Me.Validator.SetRequired(Me.txtEQCodeStart, False)
      Me.txtEQCodeStart.Size = New System.Drawing.Size(96, 21)
      Me.txtEQCodeStart.TabIndex = 4
      '
      'lblEQCode
      '
      Me.lblEQCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblEQCode.ForeColor = System.Drawing.Color.Black
      Me.lblEQCode.Location = New System.Drawing.Point(16, 39)
      Me.lblEQCode.Name = "lblEQCode"
      Me.lblEQCode.Size = New System.Drawing.Size(88, 18)
      Me.lblEQCode.TabIndex = 6
      Me.lblEQCode.Text = "รหัสเครื่องจักร:"
      Me.lblEQCode.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'txtDocDateEnd
      '
      Me.Validator.SetDataType(Me.txtDocDateEnd, Longkong.Pojjaman.Gui.Components.DataTypeConstants.DateTimeType)
      Me.Validator.SetDisplayName(Me.txtDocDateEnd, "")
      Me.Validator.SetGotFocusBackColor(Me.txtDocDateEnd, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtDocDateEnd, -15)
      Me.Validator.SetInvalidBackColor(Me.txtDocDateEnd, System.Drawing.Color.Empty)
      Me.txtDocDateEnd.Location = New System.Drawing.Point(277, 16)
      Me.txtDocDateEnd.MaxLength = 10
      Me.Validator.SetMinValue(Me.txtDocDateEnd, "")
      Me.txtDocDateEnd.Name = "txtDocDateEnd"
      Me.Validator.SetRegularExpression(Me.txtDocDateEnd, "")
      Me.Validator.SetRequired(Me.txtDocDateEnd, False)
      Me.txtDocDateEnd.Size = New System.Drawing.Size(102, 21)
      Me.txtDocDateEnd.TabIndex = 1
      '
      'txtDocDateStart
      '
      Me.Validator.SetDataType(Me.txtDocDateStart, Longkong.Pojjaman.Gui.Components.DataTypeConstants.DateTimeType)
      Me.Validator.SetDisplayName(Me.txtDocDateStart, "")
      Me.Validator.SetGotFocusBackColor(Me.txtDocDateStart, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtDocDateStart, -15)
      Me.Validator.SetInvalidBackColor(Me.txtDocDateStart, System.Drawing.Color.Empty)
      Me.txtDocDateStart.Location = New System.Drawing.Point(112, 16)
      Me.txtDocDateStart.MaxLength = 10
      Me.Validator.SetMinValue(Me.txtDocDateStart, "")
      Me.txtDocDateStart.Name = "txtDocDateStart"
      Me.Validator.SetRegularExpression(Me.txtDocDateStart, "")
      Me.Validator.SetRequired(Me.txtDocDateStart, False)
      Me.txtDocDateStart.Size = New System.Drawing.Size(96, 21)
      Me.txtDocDateStart.TabIndex = 0
      '
      'dtpDocDateStart
      '
      Me.dtpDocDateStart.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
      Me.dtpDocDateStart.Location = New System.Drawing.Point(112, 16)
      Me.dtpDocDateStart.Name = "dtpDocDateStart"
      Me.dtpDocDateStart.Size = New System.Drawing.Size(129, 21)
      Me.dtpDocDateStart.TabIndex = 2
      Me.dtpDocDateStart.TabStop = False
      '
      'dtpDocDateEnd
      '
      Me.dtpDocDateEnd.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
      Me.dtpDocDateEnd.Location = New System.Drawing.Point(292, 16)
      Me.dtpDocDateEnd.Name = "dtpDocDateEnd"
      Me.dtpDocDateEnd.Size = New System.Drawing.Size(120, 21)
      Me.dtpDocDateEnd.TabIndex = 5
      Me.dtpDocDateEnd.TabStop = False
      '
      'lblDocDateStart
      '
      Me.lblDocDateStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblDocDateStart.ForeColor = System.Drawing.Color.Black
      Me.lblDocDateStart.Location = New System.Drawing.Point(16, 16)
      Me.lblDocDateStart.Name = "lblDocDateStart"
      Me.lblDocDateStart.Size = New System.Drawing.Size(88, 18)
      Me.lblDocDateStart.TabIndex = 0
      Me.lblDocDateStart.Text = "ตั้งแต่"
      Me.lblDocDateStart.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblDocDateEnd
      '
      Me.lblDocDateEnd.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblDocDateEnd.ForeColor = System.Drawing.Color.Black
      Me.lblDocDateEnd.Location = New System.Drawing.Point(247, 16)
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
      Me.btnSearch.Location = New System.Drawing.Point(361, 131)
      Me.btnSearch.Name = "btnSearch"
      Me.btnSearch.Size = New System.Drawing.Size(75, 23)
      Me.btnSearch.TabIndex = 2
      Me.btnSearch.Text = "ค้นหา"
      '
      'btnReset
      '
      Me.btnReset.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnReset.Location = New System.Drawing.Point(281, 131)
      Me.btnReset.Name = "btnReset"
      Me.btnReset.Size = New System.Drawing.Size(75, 23)
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
      'txttmp
      '
      Me.Validator.SetDataType(Me.txttmp, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txttmp, "")
      Me.txttmp.Enabled = False
      Me.Validator.SetGotFocusBackColor(Me.txttmp, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txttmp, -15)
      Me.Validator.SetInvalidBackColor(Me.txttmp, System.Drawing.Color.Empty)
      Me.txttmp.Location = New System.Drawing.Point(521, 88)
      Me.txttmp.MaxLength = 10
      Me.Validator.SetMinValue(Me.txttmp, "")
      Me.txttmp.Name = "txttmp"
      Me.Validator.SetRegularExpression(Me.txttmp, "")
      Me.Validator.SetRequired(Me.txttmp, False)
      Me.txttmp.Size = New System.Drawing.Size(102, 21)
      Me.txttmp.TabIndex = 6
      Me.txttmp.Visible = False
      '
      'RptEquipmentMovementFilterSubPanel
      '
      Me.Controls.Add(Me.txttmp)
      Me.Controls.Add(Me.grbMaster)
      Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Name = "RptEquipmentMovementFilterSubPanel"
      Me.Size = New System.Drawing.Size(677, 185)
      Me.grbMaster.ResumeLayout(False)
      Me.grbDetail.ResumeLayout(False)
      Me.grbDetail.PerformLayout()
      CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
      Me.ResumeLayout(False)
      Me.PerformLayout()

    End Sub

#End Region

#Region " SetLabelText "
    Public Sub SetLabelText()
      'If Not m_entity Is Nothing Then Me.Text = Me.StringParserService.Parse(Me.m_entity.TabPageText)
      Me.lblEQCode.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptEquipmentStatus.EquipmentCode}")
      Me.Validator.SetDisplayName(txtEQCodeStart, lblEQCode.Text)

      Me.lblDocDateStart.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.Rpt271FilterSubPanel.lblDocDateStart}")
      Me.Validator.SetDisplayName(txtDocDateStart, lblDocDateStart.Text)

      Me.lblCCStart.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptAssetProfitLossFilterSubPanel.lblCC}")
      Me.Validator.SetDisplayName(txtCCCodeStart, lblCCStart.Text)

      ' Global {ถึง}
      Me.lblEQEnd.Text = Me.StringParserService.Parse("${res:Global.FilterPanelTo}")
      Me.Validator.SetDisplayName(txtEQCodeEnd, lblEQEnd.Text)

      Me.lblDocDateEnd.Text = Me.StringParserService.Parse("${res:Global.FilterPanelTo}")
      Me.Validator.SetDisplayName(txtDocDateEnd, lblDocDateEnd.Text)

      ' Button
      Me.btnSearch.Text = Me.StringParserService.Parse("${res:Global.SearchButtonText}")
      Me.btnReset.Text = Me.StringParserService.Parse("${res:Global.ResetButtonText}")

      ' GroupBox
      Me.grbMaster.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.Rpt271FilterSubPanel.grbMaster}")
      Me.grbDetail.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.Rpt271FilterSubPanel.grbDetail}")
    End Sub
#End Region

#Region "Member"
    Private m_equipmentstart As EquipmentItem
    Private m_equipmentend As EquipmentItem

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
    Public Property equipmentstart() As EquipmentItem
      Get
        Return m_equipmentstart
      End Get
      Set(ByVal Value As EquipmentItem)
        m_equipmentstart = Value
      End Set
    End Property
    Public Property EquipmentEnd() As EquipmentItem
      Get
        Return m_equipmentend
      End Get
      Set(ByVal Value As EquipmentItem)
        m_equipmentend = Value
      End Set
    End Property

    Public Property DocDateEnd() As Date      Get        Return m_DocDateEnd      End Get      Set(ByVal Value As Date)        m_DocDateEnd = Value      End Set    End Property    Public Property DocDateStart() As Date      Get        Return m_DocDateStart      End Get      Set(ByVal Value As Date)        m_DocDateStart = Value      End Set    End Property

    Public Property CostCenter() As CostCenter
      Get
        Return m_cc
      End Get
      Set(ByVal Value As CostCenter)
        m_cc = Value
      End Set
    End Property
#End Region

#Region "Methods"

    Private Sub Initialize()
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

      Me.CostCenter = New CostCenter

      Me.equipmentstart = New EquipmentItem
      Me.EquipmentEnd = New EquipmentItem


      Dim dtStart As Date = Date.Now.Subtract(New TimeSpan(7, 0, 0, 0))
      Me.DocDateStart = dtStart
      Me.txtDocDateStart.Text = MinDateToNull(Me.DocDateStart, "")
      Me.dtpDocDateStart.Value = Me.DocDateStart

      Me.DocDateEnd = Date.Now
      Me.txtDocDateEnd.Text = MinDateToNull(Me.DocDateEnd, "")
      Me.dtpDocDateEnd.Value = Me.DocDateEnd

      Me.ChkCancel.Checked = False

    End Sub
    Public Overrides Function GetFilterString() As String

    End Function
    Public Overrides Function GetFilterArray() As Filter()
      Dim arr(6) As Filter
      arr(0) = New Filter("DocDateStart", IIf(Me.DocDateStart.Equals(Date.MinValue), DBNull.Value, Me.DocDateStart))
      arr(1) = New Filter("DocDateEnd", IIf(Me.DocDateEnd.Equals(Date.MinValue), DBNull.Value, Me.DocDateEnd))
      arr(2) = New Filter("EquipmentCodeStart", IIf(txtEQCodeStart.TextLength > 0, txtEQCodeStart.Text, DBNull.Value))
      arr(3) = New Filter("EquipmentCodeEnd", IIf(txtEQCodeEnd.TextLength > 0, txtEQCodeEnd.Text, DBNull.Value))
      arr(4) = New Filter("CostCenter", IIf(txtCCCodeStart.TextLength > 0, txtCCCodeStart.Text, DBNull.Value))
      arr(5) = New Filter("userRight", CType(ServiceManager.Services.GetService(GetType(SecurityService)), SecurityService).CurrentUser.Id)
      arr(6) = New Filter("ChkCancel", IIf(ChkCancel.Checked, 1, 0))
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

#Region " IReportFilterSubPanel "
    Public Function GetFixValueCollection() As BusinessLogic.DocPrintingItemCollection Implements IReportFilterSubPanel.GetFixValueCollection
      Dim dpiColl As New DocPrintingItemCollection
      Dim dpi As DocPrintingItem

      'Docdate Start
      dpi = New DocPrintingItem
      dpi.Mapping = "DocdateStart"
      dpi.Value = Me.txtDocDateStart.Text
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      'Docdate End
      dpi = New DocPrintingItem
      dpi.Mapping = "DocdateEnd"
      dpi.Value = Me.txtDocDateEnd.Text
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      'EquipmentCodeStart 
      dpi = New DocPrintingItem
      dpi.Mapping = "EquipmentCodeStart"
      dpi.Value = Me.txtEQCodeStart.Text
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      'EquipmentCodeEnd
      dpi = New DocPrintingItem
      dpi.Mapping = "EquipmentCodeEnd"
      dpi.Value = Me.txtEQCodeEnd.Text
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      'CostCenterStart
      dpi = New DocPrintingItem
      dpi.Mapping = "Costcenter"
      dpi.Value = Me.txtCCCodeStart.Text
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      'today
      dpi = New DocPrintingItem
      dpi.Mapping = "today"
      dpi.Value = MinDateToNull(Now, "") + " : " + Now.ToShortTimeString
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      Return dpiColl
    End Function
#End Region

#Region " ChangeProperty "
    Private Sub EventWiring()
      AddHandler btnEQStartFind.Click, AddressOf Me.btnEQFind_Click
      AddHandler btnEQEndFind.Click, AddressOf Me.btnEQFind_Click

      AddHandler btnCCStartFind.Click, AddressOf Me.btnCCFind_Click
      'AddHandler btnCCEndFind.Click, AddressOf Me.btnCCFind_Click

      AddHandler txtDocDateStart.Validated, AddressOf Me.ChangeProperty
      AddHandler txtDocDateEnd.Validated, AddressOf Me.ChangeProperty

      AddHandler txtCCCodeStart.Validated, AddressOf Me.ChangeProperty

      AddHandler dtpDocDateStart.ValueChanged, AddressOf Me.ChangeProperty
      AddHandler dtpDocDateEnd.ValueChanged, AddressOf Me.ChangeProperty
    End Sub

    Private m_dateSetting As Boolean
    'Private m_ccSetting As Boolean = False

    Private Sub ChangeProperty(ByVal sender As Object, ByVal e As EventArgs)

      Select Case CType(sender, Control).Name.ToLower
        Case "txtcccodestart"
          'If Not m_ccSetting Then
          CostCenter.GetCostCenter(txtCCCodeStart, txttmp, Me.CostCenter, CType(ServiceManager.Services.GetService(GetType(SecurityService)), SecurityService).CurrentUser.Id)
          'Else
          'm_ccSetting = False
          'End If

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

        Case Else

      End Select
    End Sub
#End Region

#Region "IClipboardHandler Overrides"
    Public Overrides ReadOnly Property EnablePaste() As Boolean
      Get
        Dim data As IDataObject = Clipboard.GetDataObject
        If data.GetDataPresent((New Supplier).FullClassName) Then
          If Not Me.ActiveControl Is Nothing Then
            Select Case Me.ActiveControl.Name.ToLower
              Case "txtEQcodestart", "txtEQcodeend"
                Return True
            End Select
          End If
        End If
        ' CostCenter
        If data.GetDataPresent((New CostCenter).FullClassName) Then
          If Not Me.ActiveControl Is Nothing Then
            Select Case Me.ActiveControl.Name.ToLower
              Case "txtcccodestart"
                Return True
            End Select
          End If
        End If
      End Get
    End Property
    Public Overrides Sub Paste(ByVal sender As Object, ByVal e As System.EventArgs)
      Dim data As IDataObject = Clipboard.GetDataObject
      If data.GetDataPresent((New Supplier).FullClassName) Then
        Dim id As Integer = CInt(data.GetData((New Supplier).FullClassName))
        Dim entity As New Supplier(id)
        If Not Me.ActiveControl Is Nothing Then
          Select Case Me.ActiveControl.Name.ToLower
            Case "txtEQcodestart"
              Me.SetEQStartDialog(entity)

            Case "txtEQcodeend"
              Me.SetEQEndDialog(entity)

          End Select
        End If
      End If
      ' CostCenter
      If data.GetDataPresent((New CostCenter).FullClassName) Then
        Dim id As Integer = CInt(data.GetData((New CostCenter).FullClassName))
        Dim entity As New CostCenter(id)
        If Not Me.ActiveControl Is Nothing Then
          Select Case Me.ActiveControl.Name.ToLower
            Case "txtcccodestart"
              Me.SetCCCodeStartDialog(entity)

            Case "txtcccodestart"
              Me.SetCCCodeStartDialog(entity)
          End Select
        End If
      End If
    End Sub
#End Region

#Region " Event Handlers "
    Private Sub btnEQFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
      Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      Select Case CType(sender, Control).Name.ToLower
        Case "btneqstartfind"
          myEntityPanelService.OpenListDialog(New EquipmentItem, AddressOf SetEQStartDialog)

        Case "btneqendfind"
          myEntityPanelService.OpenListDialog(New EquipmentItem, AddressOf SetEQEndDialog)
      End Select
    End Sub
    Private Sub btnCCFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
      Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      Select Case CType(sender, Control).Name.ToLower
        Case "btnccstartfind"

          myEntityPanelService.OpenTreeDialog(New CostCenter, AddressOf SetCCCodeStartDialog)

      End Select
    End Sub
    Private Sub SetEQStartDialog(ByVal e As ISimpleEntity)
      Me.txtEQCodeStart.Text = e.Code
      EquipmentItem.GetEquipmentItem(txtEQCodeStart, txttmp, Me.equipmentstart)
    End Sub
    Private Sub SetEQEndDialog(ByVal e As ISimpleEntity)
      Me.txtEQCodeEnd.Text = e.Code
      EquipmentItem.GetEquipmentItem(txtEQCodeEnd, txttmp, Me.EquipmentEnd)
    End Sub
    Private Sub SetCCCodeStartDialog(ByVal e As ISimpleEntity)
      'm_ccSetting = True
      Me.txtCCCodeStart.Text = e.Code
      CostCenter.GetCostCenter(txtCCCodeStart, txttmp, Me.CostCenter, CType(ServiceManager.Services.GetService(GetType(SecurityService)), SecurityService).CurrentUser.Id)
    End Sub
#End Region

    Private Function settingsPanel() As Object
      Throw New NotImplementedException
    End Function

  End Class
End Namespace

