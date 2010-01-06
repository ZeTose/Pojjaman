Imports Longkong.Pojjaman.BusinessLogic
Imports Longkong.Pojjaman.TextHelper
Imports Longkong.Pojjaman.Gui.Components
Imports Longkong.Core.Services
Imports System.Reflection
Imports Longkong.Pojjaman.DataAccessLayer
Imports Longkong.Pojjaman.Services
Imports System.Drawing.Printing
Imports Longkong.Pojjaman.Gui.ReportsAndDocs
Imports System.Drawing
Imports System.Drawing.Drawing2D
Namespace Longkong.Pojjaman.Gui.Panels
  Public Class PettyCashClaimDetail
    Inherits AbstractEntityDetailPanelView
    Implements IValidatable
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
    Friend WithEvents lblCode As System.Windows.Forms.Label
    Friend WithEvents txtNote As System.Windows.Forms.TextBox
    Friend WithEvents lblNote As System.Windows.Forms.Label
    Friend WithEvents txtAmount As System.Windows.Forms.TextBox
    Friend WithEvents lblAmount As System.Windows.Forms.Label
    Friend WithEvents tgItem As Longkong.Pojjaman.Gui.Components.TreeGrid
    Friend WithEvents txtGross As System.Windows.Forms.TextBox
    Friend WithEvents lblGross As System.Windows.Forms.Label
    Friend WithEvents lblGrossUnit As System.Windows.Forms.Label
    Friend WithEvents lblAmountUnit As System.Windows.Forms.Label
    Friend WithEvents lblPettyCash As System.Windows.Forms.Label
    Friend WithEvents txtPettyCashCode As System.Windows.Forms.TextBox
    Friend WithEvents chkAutorun As System.Windows.Forms.CheckBox
    Friend WithEvents txtDocDate As System.Windows.Forms.TextBox
    Friend WithEvents dtpDocDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblDocDate As System.Windows.Forms.Label
    Friend WithEvents ibtnShowPettyCash As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents txtPettyCashName As System.Windows.Forms.TextBox
    Friend WithEvents ibtnShowPettyCashDialog As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents lblItem As System.Windows.Forms.Label
    Friend WithEvents ibtnDelRow As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents ibtnGetItems As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents Validator As Longkong.Pojjaman.Gui.Components.PJMTextboxValidator
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents cmbCode As System.Windows.Forms.ComboBox
    <System.Diagnostics.DebuggerStepThrough()> Protected Sub InitializeComponent()
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(PettyCashClaimDetail))
      Me.lblCode = New System.Windows.Forms.Label()
      Me.txtNote = New System.Windows.Forms.TextBox()
      Me.lblNote = New System.Windows.Forms.Label()
      Me.txtGross = New System.Windows.Forms.TextBox()
      Me.lblGross = New System.Windows.Forms.Label()
      Me.lblGrossUnit = New System.Windows.Forms.Label()
      Me.txtAmount = New System.Windows.Forms.TextBox()
      Me.lblAmount = New System.Windows.Forms.Label()
      Me.lblAmountUnit = New System.Windows.Forms.Label()
      Me.tgItem = New Longkong.Pojjaman.Gui.Components.TreeGrid()
      Me.ibtnShowPettyCash = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.txtPettyCashName = New System.Windows.Forms.TextBox()
      Me.ibtnShowPettyCashDialog = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.lblPettyCash = New System.Windows.Forms.Label()
      Me.txtPettyCashCode = New System.Windows.Forms.TextBox()
      Me.chkAutorun = New System.Windows.Forms.CheckBox()
      Me.txtDocDate = New System.Windows.Forms.TextBox()
      Me.dtpDocDate = New System.Windows.Forms.DateTimePicker()
      Me.lblDocDate = New System.Windows.Forms.Label()
      Me.lblItem = New System.Windows.Forms.Label()
      Me.ibtnDelRow = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.ibtnGetItems = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.ToolTip1 = New System.Windows.Forms.ToolTip()
      Me.Validator = New Longkong.Pojjaman.Gui.Components.PJMTextboxValidator()
      Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider()
      Me.cmbCode = New System.Windows.Forms.ComboBox()
      Me.SuspendLayout()
      '
      'lblCode
      '
      Me.lblCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblCode.ForeColor = System.Drawing.Color.Black
      Me.lblCode.Location = New System.Drawing.Point(8, 16)
      Me.lblCode.Name = "lblCode"
      Me.lblCode.Size = New System.Drawing.Size(112, 18)
      Me.lblCode.TabIndex = 5
      Me.lblCode.Text = "รหัสเอกสาร:"
      Me.lblCode.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'txtNote
      '
      Me.Validator.SetDataType(Me.txtNote, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtNote, "")
      Me.txtNote.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtNote, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtNote, -15)
      Me.Validator.SetInvalidBackColor(Me.txtNote, System.Drawing.Color.Empty)
      Me.txtNote.Location = New System.Drawing.Point(128, 88)
      Me.Validator.SetMinValue(Me.txtNote, "")
      Me.txtNote.Name = "txtNote"
      Me.Validator.SetRegularExpression(Me.txtNote, "")
      Me.Validator.SetRequired(Me.txtNote, False)
      Me.txtNote.Size = New System.Drawing.Size(552, 21)
      Me.txtNote.TabIndex = 3
      Me.txtNote.TabStop = False
      '
      'lblNote
      '
      Me.lblNote.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblNote.ForeColor = System.Drawing.Color.Black
      Me.lblNote.Location = New System.Drawing.Point(8, 88)
      Me.lblNote.Name = "lblNote"
      Me.lblNote.Size = New System.Drawing.Size(112, 18)
      Me.lblNote.TabIndex = 22
      Me.lblNote.Text = "หมายเหตุ:"
      Me.lblNote.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'txtGross
      '
      Me.Validator.SetDataType(Me.txtGross, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtGross, "")
      Me.Validator.SetGotFocusBackColor(Me.txtGross, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtGross, System.Drawing.Color.Empty)
      Me.txtGross.Location = New System.Drawing.Point(440, 63)
      Me.Validator.SetMinValue(Me.txtGross, "")
      Me.txtGross.Name = "txtGross"
      Me.txtGross.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtGross, "")
      Me.Validator.SetRequired(Me.txtGross, False)
      Me.txtGross.Size = New System.Drawing.Size(128, 21)
      Me.txtGross.TabIndex = 20
      '
      'lblGross
      '
      Me.lblGross.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblGross.ForeColor = System.Drawing.Color.Black
      Me.lblGross.Location = New System.Drawing.Point(288, 64)
      Me.lblGross.Name = "lblGross"
      Me.lblGross.Size = New System.Drawing.Size(144, 18)
      Me.lblGross.TabIndex = 19
      Me.lblGross.Text = "จำนวนที่ต้องจ่าย:"
      Me.lblGross.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblGrossUnit
      '
      Me.lblGrossUnit.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblGrossUnit.ForeColor = System.Drawing.Color.Black
      Me.lblGrossUnit.Location = New System.Drawing.Point(576, 64)
      Me.lblGrossUnit.Name = "lblGrossUnit"
      Me.lblGrossUnit.Size = New System.Drawing.Size(32, 18)
      Me.lblGrossUnit.TabIndex = 21
      Me.lblGrossUnit.Text = "บาท"
      Me.lblGrossUnit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      '
      'txtAmount
      '
      Me.Validator.SetDataType(Me.txtAmount, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtAmount, "")
      Me.Validator.SetGotFocusBackColor(Me.txtAmount, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtAmount, System.Drawing.Color.Empty)
      Me.txtAmount.Location = New System.Drawing.Point(128, 63)
      Me.Validator.SetMinValue(Me.txtAmount, "")
      Me.txtAmount.Name = "txtAmount"
      Me.txtAmount.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtAmount, "")
      Me.Validator.SetRequired(Me.txtAmount, False)
      Me.txtAmount.Size = New System.Drawing.Size(128, 21)
      Me.txtAmount.TabIndex = 14
      '
      'lblAmount
      '
      Me.lblAmount.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblAmount.ForeColor = System.Drawing.Color.Black
      Me.lblAmount.Location = New System.Drawing.Point(8, 64)
      Me.lblAmount.Name = "lblAmount"
      Me.lblAmount.Size = New System.Drawing.Size(112, 18)
      Me.lblAmount.TabIndex = 13
      Me.lblAmount.Text = "วงเงิน:"
      Me.lblAmount.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblAmountUnit
      '
      Me.lblAmountUnit.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblAmountUnit.ForeColor = System.Drawing.Color.Black
      Me.lblAmountUnit.Location = New System.Drawing.Point(256, 64)
      Me.lblAmountUnit.Name = "lblAmountUnit"
      Me.lblAmountUnit.Size = New System.Drawing.Size(32, 18)
      Me.lblAmountUnit.TabIndex = 15
      Me.lblAmountUnit.Text = "บาท"
      Me.lblAmountUnit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      '
      'tgItem
      '
      Me.tgItem.AllowNew = False
      Me.tgItem.AllowSorting = False
      Me.tgItem.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                  Or System.Windows.Forms.AnchorStyles.Left) _
                  Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.tgItem.AutoColumnResize = True
      Me.tgItem.CaptionVisible = False
      Me.tgItem.Cellchanged = False
      Me.tgItem.DataMember = ""
      Me.tgItem.HeaderForeColor = System.Drawing.SystemColors.ControlText
      Me.tgItem.Location = New System.Drawing.Point(8, 136)
      Me.tgItem.Name = "tgItem"
      Me.tgItem.Size = New System.Drawing.Size(720, 176)
      Me.tgItem.SortingArrowColor = System.Drawing.Color.Red
      Me.tgItem.TabIndex = 4
      Me.tgItem.TreeManager = Nothing
      '
      'ibtnShowPettyCash
      '
      Me.ibtnShowPettyCash.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.ibtnShowPettyCash.Image = CType(resources.GetObject("ibtnShowPettyCash.Image"), System.Drawing.Image)
      Me.ibtnShowPettyCash.Location = New System.Drawing.Point(568, 40)
      Me.ibtnShowPettyCash.Name = "ibtnShowPettyCash"
      Me.ibtnShowPettyCash.Size = New System.Drawing.Size(24, 23)
      Me.ibtnShowPettyCash.TabIndex = 12
      Me.ibtnShowPettyCash.TabStop = False
      Me.ibtnShowPettyCash.ThemedImage = CType(resources.GetObject("ibtnShowPettyCash.ThemedImage"), System.Drawing.Bitmap)
      '
      'txtPettyCashName
      '
      Me.txtPettyCashName.BackColor = System.Drawing.SystemColors.Control
      Me.Validator.SetDataType(Me.txtPettyCashName, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtPettyCashName, "")
      Me.Validator.SetGotFocusBackColor(Me.txtPettyCashName, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtPettyCashName, System.Drawing.Color.Empty)
      Me.txtPettyCashName.Location = New System.Drawing.Point(256, 40)
      Me.Validator.SetMinValue(Me.txtPettyCashName, "")
      Me.txtPettyCashName.Name = "txtPettyCashName"
      Me.txtPettyCashName.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtPettyCashName, "")
      Me.Validator.SetRequired(Me.txtPettyCashName, False)
      Me.txtPettyCashName.Size = New System.Drawing.Size(288, 21)
      Me.txtPettyCashName.TabIndex = 10
      Me.txtPettyCashName.TabStop = False
      '
      'ibtnShowPettyCashDialog
      '
      Me.ibtnShowPettyCashDialog.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.ibtnShowPettyCashDialog.ForeColor = System.Drawing.SystemColors.Control
      Me.ibtnShowPettyCashDialog.Image = CType(resources.GetObject("ibtnShowPettyCashDialog.Image"), System.Drawing.Image)
      Me.ibtnShowPettyCashDialog.Location = New System.Drawing.Point(544, 40)
      Me.ibtnShowPettyCashDialog.Name = "ibtnShowPettyCashDialog"
      Me.ibtnShowPettyCashDialog.Size = New System.Drawing.Size(24, 23)
      Me.ibtnShowPettyCashDialog.TabIndex = 11
      Me.ibtnShowPettyCashDialog.TabStop = False
      Me.ibtnShowPettyCashDialog.ThemedImage = CType(resources.GetObject("ibtnShowPettyCashDialog.ThemedImage"), System.Drawing.Bitmap)
      '
      'lblPettyCash
      '
      Me.lblPettyCash.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblPettyCash.Location = New System.Drawing.Point(8, 40)
      Me.lblPettyCash.Name = "lblPettyCash"
      Me.lblPettyCash.Size = New System.Drawing.Size(112, 18)
      Me.lblPettyCash.TabIndex = 9
      Me.lblPettyCash.Text = "วงเงินสดย่อย:"
      Me.lblPettyCash.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'txtPettyCashCode
      '
      Me.txtPettyCashCode.BackColor = System.Drawing.SystemColors.Window
      Me.Validator.SetDataType(Me.txtPettyCashCode, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtPettyCashCode, "")
      Me.Validator.SetGotFocusBackColor(Me.txtPettyCashCode, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtPettyCashCode, -15)
      Me.Validator.SetInvalidBackColor(Me.txtPettyCashCode, System.Drawing.Color.Empty)
      Me.txtPettyCashCode.Location = New System.Drawing.Point(128, 40)
      Me.Validator.SetMinValue(Me.txtPettyCashCode, "")
      Me.txtPettyCashCode.Name = "txtPettyCashCode"
      Me.Validator.SetRegularExpression(Me.txtPettyCashCode, "")
      Me.Validator.SetRequired(Me.txtPettyCashCode, True)
      Me.txtPettyCashCode.Size = New System.Drawing.Size(128, 21)
      Me.txtPettyCashCode.TabIndex = 2
      '
      'chkAutorun
      '
      Me.chkAutorun.Appearance = System.Windows.Forms.Appearance.Button
      Me.chkAutorun.Image = CType(resources.GetObject("chkAutorun.Image"), System.Drawing.Image)
      Me.chkAutorun.Location = New System.Drawing.Point(256, 16)
      Me.chkAutorun.Name = "chkAutorun"
      Me.chkAutorun.Size = New System.Drawing.Size(21, 21)
      Me.chkAutorun.TabIndex = 6
      '
      'txtDocDate
      '
      Me.Validator.SetDataType(Me.txtDocDate, Longkong.Pojjaman.Gui.Components.DataTypeConstants.DateTimeType)
      Me.Validator.SetDisplayName(Me.txtDocDate, "")
      Me.Validator.SetGotFocusBackColor(Me.txtDocDate, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtDocDate, -15)
      Me.Validator.SetInvalidBackColor(Me.txtDocDate, System.Drawing.Color.Empty)
      Me.txtDocDate.Location = New System.Drawing.Point(424, 16)
      Me.Validator.SetMinValue(Me.txtDocDate, "")
      Me.txtDocDate.Name = "txtDocDate"
      Me.Validator.SetRegularExpression(Me.txtDocDate, "")
      Me.Validator.SetRequired(Me.txtDocDate, True)
      Me.txtDocDate.Size = New System.Drawing.Size(126, 21)
      Me.txtDocDate.TabIndex = 1
      '
      'dtpDocDate
      '
      Me.dtpDocDate.CustomFormat = "dd/MM/yyyy"
      Me.dtpDocDate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.dtpDocDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
      Me.dtpDocDate.Location = New System.Drawing.Point(424, 16)
      Me.dtpDocDate.Name = "dtpDocDate"
      Me.dtpDocDate.Size = New System.Drawing.Size(144, 21)
      Me.dtpDocDate.TabIndex = 8
      Me.dtpDocDate.TabStop = False
      '
      'lblDocDate
      '
      Me.lblDocDate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblDocDate.ForeColor = System.Drawing.Color.Black
      Me.lblDocDate.Location = New System.Drawing.Point(336, 17)
      Me.lblDocDate.Name = "lblDocDate"
      Me.lblDocDate.Size = New System.Drawing.Size(88, 18)
      Me.lblDocDate.TabIndex = 7
      Me.lblDocDate.Text = "วันที่:"
      Me.lblDocDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblItem
      '
      Me.lblItem.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblItem.ForeColor = System.Drawing.Color.Black
      Me.lblItem.Location = New System.Drawing.Point(8, 120)
      Me.lblItem.Name = "lblItem"
      Me.lblItem.Size = New System.Drawing.Size(96, 18)
      Me.lblItem.TabIndex = 23
      Me.lblItem.Text = "รายการ"
      Me.lblItem.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      '
      'ibtnDelRow
      '
      Me.ibtnDelRow.Image = CType(resources.GetObject("ibtnDelRow.Image"), System.Drawing.Image)
      Me.ibtnDelRow.Location = New System.Drawing.Point(117, 112)
      Me.ibtnDelRow.Name = "ibtnDelRow"
      Me.ibtnDelRow.Size = New System.Drawing.Size(24, 24)
      Me.ibtnDelRow.TabIndex = 269
      Me.ibtnDelRow.TabStop = False
      Me.ibtnDelRow.ThemedImage = CType(resources.GetObject("ibtnDelRow.ThemedImage"), System.Drawing.Bitmap)
      '
      'ibtnGetItems
      '
      Me.ibtnGetItems.Image = CType(resources.GetObject("ibtnGetItems.Image"), System.Drawing.Image)
      Me.ibtnGetItems.Location = New System.Drawing.Point(88, 112)
      Me.ibtnGetItems.Name = "ibtnGetItems"
      Me.ibtnGetItems.Size = New System.Drawing.Size(24, 24)
      Me.ibtnGetItems.TabIndex = 270
      Me.ibtnGetItems.TabStop = False
      Me.ibtnGetItems.ThemedImage = CType(resources.GetObject("ibtnGetItems.ThemedImage"), System.Drawing.Bitmap)
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
      'cmbCode
      '
      Me.cmbCode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.ErrorProvider1.SetIconPadding(Me.cmbCode, -15)
      Me.cmbCode.Location = New System.Drawing.Point(128, 16)
      Me.cmbCode.Name = "cmbCode"
      Me.cmbCode.Size = New System.Drawing.Size(128, 21)
      Me.cmbCode.TabIndex = 271
      '
      'PettyCashClaimDetail
      '
      Me.Controls.Add(Me.cmbCode)
      Me.Controls.Add(Me.ibtnGetItems)
      Me.Controls.Add(Me.ibtnDelRow)
      Me.Controls.Add(Me.chkAutorun)
      Me.Controls.Add(Me.txtDocDate)
      Me.Controls.Add(Me.dtpDocDate)
      Me.Controls.Add(Me.lblDocDate)
      Me.Controls.Add(Me.ibtnShowPettyCash)
      Me.Controls.Add(Me.txtPettyCashName)
      Me.Controls.Add(Me.ibtnShowPettyCashDialog)
      Me.Controls.Add(Me.lblPettyCash)
      Me.Controls.Add(Me.txtPettyCashCode)
      Me.Controls.Add(Me.tgItem)
      Me.Controls.Add(Me.txtGross)
      Me.Controls.Add(Me.lblGross)
      Me.Controls.Add(Me.lblGrossUnit)
      Me.Controls.Add(Me.lblCode)
      Me.Controls.Add(Me.txtNote)
      Me.Controls.Add(Me.lblNote)
      Me.Controls.Add(Me.txtAmount)
      Me.Controls.Add(Me.lblAmount)
      Me.Controls.Add(Me.lblAmountUnit)
      Me.Controls.Add(Me.lblItem)
      Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Name = "PettyCashClaimDetail"
      Me.Size = New System.Drawing.Size(736, 352)
      Me.ResumeLayout(False)
      Me.PerformLayout()

    End Sub

#End Region

#Region "Members"
    Private m_entity As PettyCashClaim
    Private m_isInitialized As Boolean = False
    Private m_treeManager As TreeManager
    Private m_combocodeindex As Integer
#End Region

#Region "Property"
    Private Property ComboCodeIndex() As Integer
      Get
        If m_combocodeindex = -1 Then
          If cmbCode.Items.Count > 0 Then
            m_combocodeindex = 0
          End If
        End If
        Return m_combocodeindex
      End Get
      Set(ByVal Value As Integer)
        m_combocodeindex = Value
      End Set
    End Property
#End Region

#Region "Constructors"
    Public Sub New()
      MyBase.New()
      Me.InitializeComponent()
      Me.SetLabelText()
      Initialize()

      Dim dt As TreeTable = PettyCashClaim.GetSchemaTable()
      Dim dst As DataGridTableStyle = PettyCashClaim.CreateTableStyle()
      m_treeManager = New TreeManager(dt, tgItem)
      m_treeManager.SetTableStyle(dst)
      m_treeManager.AllowSorting = False
      m_treeManager.AllowDelete = False
      tgItem.AllowNew = False

      EventWiring()
    End Sub
#End Region

#Region "IListDetail"
    Public Overrides Sub CheckFormEnable()
      If Me.m_entity Is Nothing Then
        Return
      End If
      If Me.m_entity.Status.Value = 0 _
      OrElse Me.m_entity.Status.Value >= 3 _
      OrElse Me.m_entity.Payment.Status.Value = 0 _
      OrElse Me.m_entity.Payment.Status.Value >= 3 _
      Then
        Me.Enabled = False
      Else
        Me.Enabled = True
      End If
    End Sub
    Public Overrides Sub ClearDetail()
      For Each crlt As Control In Me.Controls
        If crlt.Name.StartsWith("txt") Then
          crlt.Text = ""
        End If
      Next
      Me.dtpDocDate.Value = Now
    End Sub
    Public Overrides Sub SetLabelText()
      If Not m_entity Is Nothing Then Me.Text = Me.StringParserService.Parse(Me.m_entity.TabPageText)
      Me.lblCode.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PettyCashClaimDetail.lblCode}")
      Me.lblNote.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PettyCashClaimDetail.lblNote}")
      Me.lblAmount.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PettyCashClaimDetail.lblAmount}")
      Me.lblGross.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PettyCashClaimDetail.lblGross}")
      Me.lblGrossUnit.Text = Me.StringParserService.Parse("${res:Global.CurrencyUnit}")
      Me.lblAmountUnit.Text = Me.StringParserService.Parse("${res:Global.CurrencyUnit}")
      Me.lblPettyCash.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PettyCashClaimDetail.lblPettyCash}")
      Me.lblDocDate.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PettyCashClaimDetail.lblDocDate}")
      Me.lblItem.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PettyCashClaimDetail.lblItem}")
    End Sub
    Protected Overrides Sub EventWiring()
      AddHandler cmbCode.TextChanged, AddressOf Me.ChangeProperty
      AddHandler cmbCode.SelectedIndexChanged, AddressOf Me.ChangeProperty
      AddHandler txtNote.TextChanged, AddressOf Me.ChangeProperty

      AddHandler txtDocDate.Validated, AddressOf Me.ChangeProperty
      AddHandler dtpDocDate.ValueChanged, AddressOf Me.ChangeProperty

      AddHandler txtPettyCashCode.Validated, AddressOf Me.ChangeProperty
    End Sub
    ' แสดงค่าข้อมูลของลูกค้าลงใน control ที่อยู่บนฟอร์ม
    Public Overrides Sub UpdateEntityProperties()
      m_isInitialized = False
      ClearDetail()
      If m_entity Is Nothing Then
        Return
      End If

      'cmbCode.Items.Clear()
      'cmbCode.DropDownStyle = ComboBoxStyle.Simple
      'cmbCode.Text = m_entity.Code
      'BusinessLogic.Entity.PopulateCodeCombo(Me.cmbCode, Me.m_entity.EntityId)
      'UpdateAutogen ทำแทนแล้ว
      m_oldCode = m_entity.Code
      txtNote.Text = m_entity.Note

      Me.chkAutorun.Checked = Me.m_entity.AutoGen
      Me.UpdateAutogenStatus()

      txtDocDate.Text = MinDateToNull(Me.m_entity.DocDate, Me.StringParserService.Parse("${res:Global.BlankDateText}"))
      dtpDocDate.Value = MinDateToNow(Me.m_entity.DocDate)


      'Load Items**********************************************************
      Me.m_treeManager.Treetable = Me.m_entity.ItemTable
      AddHandler Me.m_entity.PropertyChanged, AddressOf PropChanged
      Me.Validator.DataTable = m_treeManager.Treetable
      '********************************************************************

      m_entity.UpdateGross()
      UpdateAmount()
      UpdatePC()

      RefreshBlankGrid()

      SetStatus()
      SetLabelText()
      CheckFormEnable()
      m_isInitialized = True
    End Sub
    Private Sub UpdatePC()
      Dim oldFlag As Boolean = m_isInitialized
      m_isInitialized = False
      txtPettyCashCode.Text = m_entity.PettyCash.Code
      txtPettyCashName.Text = m_entity.PettyCash.Name
      txtAmount.Text = Configuration.FormatToString(m_entity.PettyCash.Amount, DigitConfig.Price)
      m_isInitialized = oldFlag
    End Sub
    Private Sub UpdateAmount()
      Me.txtGross.Text = Configuration.FormatToString(m_entity.Gross, DigitConfig.Price)
    End Sub
    Private Sub PropChanged(ByVal sender As Object, ByVal e As PropertyChangedEventArgs)
      If e.Name = "ItemChanged" Then
        UpdateAmount()
        Me.WorkbenchWindow.ViewContent.IsDirty = True
      End If
    End Sub
    Private m_dateSetting As Boolean = False
    Public Sub ChangeProperty(ByVal sender As Object, ByVal e As EventArgs)
      If Me.m_entity Is Nothing Or Not m_isInitialized Then
        Return
      End If
      Dim dirtyFlag As Boolean = False
      Select Case CType(sender, Control).Name.ToLower
        Case "cmbcode"
          'เพิ่ม AutoCode
          If TypeOf cmbCode.SelectedItem Is AutoCodeFormat Then
            Me.m_entity.AutoCodeFormat = CType(cmbCode.SelectedItem, AutoCodeFormat)
            Me.m_entity.OnGlChanged()
          End If
          dirtyFlag = True
        Case "txtnote"
          Me.m_entity.Note = txtNote.Text
          dirtyFlag = True
        Case "dtpdocdate"
          If Not Me.m_entity.DocDate.Equals(dtpDocDate.Value) Then
            If Not m_dateSetting Then
              Me.txtDocDate.Text = MinDateToNull(dtpDocDate.Value, Me.StringParserService.Parse("${res:Global.BlankDateText}"))
              Me.m_entity.DocDate = dtpDocDate.Value
            End If
            dirtyFlag = True
          End If
        Case "txtdocdate"
          m_dateSetting = True
          If Not Me.txtDocDate.Text.Length = 0 AndAlso Me.Validator.GetErrorMessage(Me.txtDocDate) = "" Then
            Dim theDate As Date = CDate(Me.txtDocDate.Text)
            If Not Me.m_entity.DocDate.Equals(theDate) Then
              dtpDocDate.Value = theDate
              Me.m_entity.DocDate = dtpDocDate.Value
              dirtyFlag = True
            End If
          Else
            Me.m_entity.DocDate = Date.Now
            Me.m_entity.DocDate = Date.MinValue
            dirtyFlag = True
          End If
          m_dateSetting = False
        Case "txtpettycashcode"
          dirtyFlag = PettyCash.GetPettyCash(txtPettyCashCode, txtPettyCashName, Me.m_entity.PettyCash)
          m_entity.UpdateGross()
          UpdateAmount()
          UpdatePC()
          RefreshBlankGrid()
      End Select
      Me.WorkbenchWindow.ViewContent.IsDirty = Me.WorkbenchWindow.ViewContent.IsDirty Or dirtyFlag
      CheckFormEnable()
    End Sub
    Public Sub SetStatus()
      'If m_entity.Canceled Then
      '    lblStatus.Text = "ยกเลิก: " & m_entity.CancelDate.ToShortDateString & _
      '    " " & m_entity.CancelDate.ToShortTimeString & _
      '    "  โดย:" & m_entity.CancelPerson.Name
      'ElseIf m_entity.Edited Then
      '    lblStatus.Text = "แก้ไขล่าสุด: " & m_entity.LastEditDate.ToShortDateString & _
      '    " " & m_entity.LastEditDate.ToShortTimeString & _
      '    "  โดย:" & m_entity.LastEditor.Name
      'ElseIf m_entity.Originated Then
      '    lblStatus.Text = "เพิ่มเข้าสู่ระบบ: " & m_entity.OriginDate.ToShortDateString & _
      '    " " & m_entity.OriginDate.ToShortTimeString & _
      '    "  โดย:" & m_entity.Originator.Name
      'Else
      '    lblStatus.Text = "ยังไม่บันทึก"
      'End If
    End Sub
    Public Overrides Property Entity() As ISimpleEntity
      Get
        Return Me.m_entity
      End Get
      Set(ByVal Value As ISimpleEntity)
        If Not m_entity Is Nothing Then
          RemoveHandler Me.m_entity.PropertyChanged, AddressOf PropChanged
          Me.m_entity = Nothing
        End If
        Me.m_entity = CType(Value, PettyCashClaim)
        'Hack:
        Me.m_entity.OnTabPageTextChanged(m_entity, EventArgs.Empty)
        UpdateEntityProperties()
      End Set
    End Property

    Public Overrides Sub Initialize()
      'PopulateRequestor()
      'PopulateCostCenter()
    End Sub
#End Region

#Region "Event Handlers"
    Private Sub chkAutorun_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkAutorun.CheckedChanged
      UpdateAutogenStatus()
    End Sub
    Private m_oldCode As String = ""
    Private Sub UpdateAutogenStatus()
      If Me.chkAutorun.Checked Then
        Me.cmbCode.DropDownStyle = ComboBoxStyle.DropDown
        Dim currentUserId As Integer = Me.SecurityService.CurrentUser.Id
        BusinessLogic.Entity.NewPopulateCodeCombo(Me.cmbCode, Me.m_entity.EntityId, currentUserId)
        If Me.m_entity.Code Is Nothing OrElse Me.m_entity.Code.Length = 0 Then
          If Me.cmbCode.Items.Count > 0 Then
            Me.m_entity.Code = CType(Me.cmbCode.Items(0), AutoCodeFormat).Format
            Me.cmbCode.SelectedIndex = 0
            Me.m_entity.AutoCodeFormat = CType(Me.cmbCode.Items(0), AutoCodeFormat)
          End If
        Else
          Me.cmbCode.SelectedIndex = Me.cmbCode.FindStringExact(Me.m_entity.Code)
          If TypeOf Me.cmbCode.SelectedItem Is AutoCodeFormat Then
            Me.m_entity.AutoCodeFormat = CType(Me.cmbCode.SelectedItem, AutoCodeFormat)
          End If
        End If

        'Me.txtCode.Text = BusinessLogic.Entity.GetAutoCodeFormat(Me.m_entity.EntityId)
        'Hack: set Code เป็น "" เอง
        'Me.m_entity.Code = ""
        m_oldCode = Me.cmbCode.Text
        Me.m_entity.Code = m_oldCode
        Me.m_entity.AutoGen = True
      Else
        ' Me.Validator.SetRequired(Me.txtCode, True)
        Me.cmbCode.DropDownStyle = ComboBoxStyle.Simple
        Me.cmbCode.Text = m_oldCode
        'Me.txtCode.ReadOnly = False
        Me.m_entity.AutoGen = False
      End If
    End Sub
    Private Sub ibtnDelRow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnDelRow.Click
      Dim index As Integer = Me.tgItem.CurrentRowIndex
      If index > Me.m_entity.MaxRowIndex Then
        Return
      End If
      Me.m_entity.Remove(index)
      Me.tgItem.CurrentRowIndex = index
      RefreshBlankGrid()
      Me.WorkbenchWindow.ViewContent.IsDirty = True
    End Sub
    Private Sub ibtnGetItems_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnGetItems.Click
      Me.m_entity.LoadNewItems()
      m_entity.UpdateGross()
      UpdateAmount()
    End Sub
#End Region

#Region "IValidatable"
    Public ReadOnly Property FormValidator() As components.PJMTextboxValidator Implements IValidatable.FormValidator
      Get
        Return Me.Validator
      End Get
    End Property
#End Region

#Region "Overrides"
    'Public Overrides Sub NotifyAfterSave(ByVal successful As Boolean)
    '    If Not successful Then
    '        Return
    '    End If
    '    Me.Entity = New PR(Me.Entity.Id)
    '    Dim listPanel As ISimpleListPanel = CType(Me.WorkbenchWindow.ViewContent, ISimpleListPanel)
    '    listPanel.SelectedEntity = Me.Entity
    'End Sub
    Public Overrides ReadOnly Property TabPageIcon() As String
      Get
        Return (New PettyCash).DetailPanelIcon
      End Get
    End Property
#End Region

#Region "Event of Button controls"
    Private Sub ibtnShowPettyCashDialog_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnShowPettyCashDialog.Click
      Dim myEntityPanelService As IEntityPanelService = _
       CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      Dim filters(0) As Filter
      filters(0) = New Filter("pc_closed", 0)
      myEntityPanelService.OpenListDialog(New PettyCash, AddressOf SetPettyCash, filters)
    End Sub
    Private Sub ibtnShowPettyCash_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnShowPettyCash.Click
      Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      myEntityPanelService.OpenPanel(New PettyCash)
    End Sub
    Private Sub SetPettyCash(ByVal e As ISimpleEntity)
      Me.txtPettyCashCode.Text = e.Code
      Me.WorkbenchWindow.ViewContent.IsDirty = _
          Me.WorkbenchWindow.ViewContent.IsDirty _
          Or PettyCash.GetPettyCash(txtPettyCashCode, txtPettyCashName, Me.m_entity.PettyCash)
      m_entity.UpdateGross()
      UpdateAmount()
      UpdatePC()
      RefreshBlankGrid()
    End Sub
#End Region

#Region "IClipboardHandler Overrides"
    Public Overrides ReadOnly Property EnablePaste() As Boolean
      Get
        Dim data As IDataObject = Clipboard.GetDataObject
        If data.GetDataPresent((New PettyCash).FullClassName) Then
          If Not Me.ActiveControl Is Nothing Then
            Select Case Me.ActiveControl.Name.ToLower
              Case "txtpettycashcode", "txtpettycashname"
                Return True
            End Select
          End If
        End If
        Return False
      End Get
    End Property
    Public Overrides Sub Paste(ByVal sender As Object, ByVal e As System.EventArgs)
      Dim data As IDataObject = Clipboard.GetDataObject
      If data.GetDataPresent((New PettyCash).FullClassName) Then
        Dim id As Integer = CInt(data.GetData((New PettyCash).FullClassName))
        Dim entity As New PettyCash(id)
        If Not Me.ActiveControl Is Nothing Then
          Select Case Me.ActiveControl.Name.ToLower
            Case "txtpettycashcode", "txtpettycashname"
              Me.SetPettyCash(entity)
          End Select
        End If
      End If
    End Sub
#End Region

#Region "Grid Resizing"
    Private Sub tgItem_Resize(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tgItem.Resize
      If Me.m_entity Is Nothing Then
        Return
      End If
      RefreshBlankGrid()
    End Sub
    Private Sub RefreshBlankGrid()
      'If Me.tgItem.Height = 0 Then
      '    Return
      'End If
      'Dim dirtyFlag As Boolean = Me.WorkbenchWindow.ViewContent.IsDirty
      'Dim index As Integer = tgItem.CurrentRowIndex
      'Dim maxVisibleCount As Integer
      'Dim tgRowHeight As Integer = 17
      'maxVisibleCount = CInt(Math.Floor((Me.tgItem.Height - tgRowHeight) / tgRowHeight))
      'Do While Me.m_entity.ItemTable.Childs.Count < maxVisibleCount - 1
      '    'เพิ่มแถวจนเต็ม
      '    Me.m_entity.AddBlankRow(1)
      'Loop
      'If Me.m_entity.MaxRowIndex = maxVisibleCount - 2 Then
      '    If Me.m_entity.ItemTable.Childs.Count < maxVisibleCount - 1 Then
      '        'เพิ่มอีก 1 แถว ถ้ามีข้อมูลจนถึงแถวสุดท้าย
      '        Me.m_entity.AddBlankRow(1)
      '    End If
      'End If
      'Do While Me.m_entity.ItemTable.Childs.Count > maxVisibleCount - 1 And Me.m_entity.ItemTable.Childs.Count - 2 <> Me.m_entity.MaxRowIndex
      '    'ลบแถวที่ไม่จำเป็น
      '    Me.m_entity.Remove(Me.m_entity.ItemTable.Childs.Count - 1)
      'Loop
      'Me.m_entity.ItemTable.AcceptChanges()
      'tgItem.CurrentRowIndex = Math.Max(0, index)
      'Me.WorkbenchWindow.ViewContent.IsDirty = dirtyFlag

      If Me.tgItem.Height = 0 Then
        Return
      End If
      Dim dirtyFlag As Boolean = Me.WorkbenchWindow.ViewContent.IsDirty
      Dim index As Integer = tgItem.CurrentRowIndex

      Do Until Me.m_treeManager.Treetable.Rows.Count > tgItem.VisibleRowCount
        'เพิ่มแถวจนเต็ม
        Me.m_entity.AddBlankRow(1)
      Loop

      If Me.m_entity.MaxRowIndex = Me.m_treeManager.Treetable.Rows.Count - 1 Then
        'เพิ่มอีก 1 แถว ถ้ามีข้อมูลจนถึงแถวสุดท้าย
        Me.m_treeManager.Treetable.Childs.Add()
      End If

      Me.m_treeManager.Treetable.AcceptChanges()
      tgItem.CurrentRowIndex = Math.Max(0, index)
      Me.WorkbenchWindow.ViewContent.IsDirty = dirtyFlag
    End Sub
#End Region

  End Class
End Namespace