Imports Longkong.Pojjaman.Services
Imports Longkong.Core.Services

Imports Longkong.Pojjaman.Gui
Imports Longkong.Pojjaman.BusinessLogic
Imports Longkong.Pojjaman.Gui.Components
Imports System.Globalization
Imports System.Reflection
Imports System.Drawing.Printing
Imports Longkong.Pojjaman.TextHelper
Imports Longkong.Pojjaman.Gui.ReportsAndDocs
Imports System
Imports System.Threading
Namespace Longkong.Pojjaman.Gui.Panels
  Public Class StockSequenceDetail
    Inherits AbstractEntityPanelViewContent
    Implements IValidatable, ISimpleListPanel
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
    Friend WithEvents tgItem As Longkong.Pojjaman.Gui.Components.TreeGrid
    Friend WithEvents ibtnAdd As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents Validator As Longkong.Pojjaman.Gui.Components.PJMTextboxValidator
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents grbDetail As Longkong.Pojjaman.Gui.Components.FixedGroupBox
    Friend WithEvents lblItem As System.Windows.Forms.Label
    Friend WithEvents FixedGroupBox1 As Longkong.Pojjaman.Gui.Components.FixedGroupBox
    Friend WithEvents txtDocDateStart As System.Windows.Forms.TextBox
    Friend WithEvents txtDocDateEnd As System.Windows.Forms.TextBox
    Friend WithEvents dtpDocDateStart As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpDocDateEnd As System.Windows.Forms.DateTimePicker
    Friend WithEvents btnOK As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents btnPreview As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents lblDateStart As System.Windows.Forms.Label
    Friend WithEvents lblDateEnd As System.Windows.Forms.Label
    Friend WithEvents grbGeneral As Longkong.Pojjaman.Gui.Components.FixedGroupBox
    Friend WithEvents ProgressBar1 As System.Windows.Forms.ProgressBar
    Friend WithEvents lblProgress As System.Windows.Forms.Label
    Friend WithEvents btnReSave As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents chkRecalUnitCost As System.Windows.Forms.CheckBox
    <System.Diagnostics.DebuggerStepThrough()> Protected Sub InitializeComponent()
      Me.tgItem = New Longkong.Pojjaman.Gui.Components.TreeGrid()
      Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider()
      Me.Validator = New Longkong.Pojjaman.Gui.Components.PJMTextboxValidator()
      Me.txtDocDateStart = New System.Windows.Forms.TextBox()
      Me.txtDocDateEnd = New System.Windows.Forms.TextBox()
      Me.ToolTip1 = New System.Windows.Forms.ToolTip()
      Me.grbDetail = New Longkong.Pojjaman.Gui.Components.FixedGroupBox()
      Me.lblItem = New System.Windows.Forms.Label()
      Me.grbGeneral = New Longkong.Pojjaman.Gui.Components.FixedGroupBox()
      Me.lblProgress = New System.Windows.Forms.Label()
      Me.ProgressBar1 = New System.Windows.Forms.ProgressBar()
      Me.btnOK = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.btnPreview = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.FixedGroupBox1 = New Longkong.Pojjaman.Gui.Components.FixedGroupBox()
      Me.chkRecalUnitCost = New System.Windows.Forms.CheckBox()
      Me.lblDateStart = New System.Windows.Forms.Label()
      Me.dtpDocDateStart = New System.Windows.Forms.DateTimePicker()
      Me.lblDateEnd = New System.Windows.Forms.Label()
      Me.dtpDocDateEnd = New System.Windows.Forms.DateTimePicker()
      Me.btnReSave = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.grbDetail.SuspendLayout()
      Me.grbGeneral.SuspendLayout()
      Me.FixedGroupBox1.SuspendLayout()
      Me.SuspendLayout()
      '
      'tgItem
      '
      Me.tgItem.AllowNew = True
      Me.tgItem.AllowSorting = False
      Me.tgItem.AlternatingBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
      Me.tgItem.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                  Or System.Windows.Forms.AnchorStyles.Left) _
                  Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.tgItem.AutoColumnResize = True
      Me.tgItem.BackgroundColor = System.Drawing.Color.DimGray
      Me.tgItem.CaptionBackColor = System.Drawing.Color.SaddleBrown
      Me.tgItem.CaptionVisible = False
      Me.tgItem.Cellchanged = False
      Me.tgItem.DataMember = ""
      Me.tgItem.GridLineColor = System.Drawing.Color.Wheat
      Me.tgItem.HeaderBackColor = System.Drawing.Color.Gold
      Me.tgItem.HeaderForeColor = System.Drawing.SystemColors.ControlText
      Me.tgItem.Location = New System.Drawing.Point(8, 232)
      Me.tgItem.Name = "tgItem"
      Me.tgItem.Size = New System.Drawing.Size(736, 208)
      Me.tgItem.SortingArrowColor = System.Drawing.Color.Red
      Me.tgItem.TabIndex = 166
      Me.tgItem.TreeManager = Nothing
      Me.tgItem.Visible = False
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
      'txtDocDateStart
      '
      Me.Validator.SetDataType(Me.txtDocDateStart, Longkong.Pojjaman.Gui.Components.DataTypeConstants.DateTimeType)
      Me.Validator.SetDisplayName(Me.txtDocDateStart, "")
      Me.Validator.SetGotFocusBackColor(Me.txtDocDateStart, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtDocDateStart, System.Drawing.Color.Empty)
      Me.txtDocDateStart.Location = New System.Drawing.Point(112, 16)
      Me.txtDocDateStart.MaxLength = 20
      Me.Validator.SetMinValue(Me.txtDocDateStart, "")
      Me.txtDocDateStart.Name = "txtDocDateStart"
      Me.Validator.SetRegularExpression(Me.txtDocDateStart, "")
      Me.Validator.SetRequired(Me.txtDocDateStart, True)
      Me.txtDocDateStart.Size = New System.Drawing.Size(115, 21)
      Me.txtDocDateStart.TabIndex = 2
      '
      'txtDocDateEnd
      '
      Me.Validator.SetDataType(Me.txtDocDateEnd, Longkong.Pojjaman.Gui.Components.DataTypeConstants.DateTimeType)
      Me.Validator.SetDisplayName(Me.txtDocDateEnd, "")
      Me.Validator.SetGotFocusBackColor(Me.txtDocDateEnd, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtDocDateEnd, System.Drawing.Color.Empty)
      Me.txtDocDateEnd.Location = New System.Drawing.Point(112, 40)
      Me.txtDocDateEnd.MaxLength = 20
      Me.Validator.SetMinValue(Me.txtDocDateEnd, "")
      Me.txtDocDateEnd.Name = "txtDocDateEnd"
      Me.Validator.SetRegularExpression(Me.txtDocDateEnd, "")
      Me.Validator.SetRequired(Me.txtDocDateEnd, True)
      Me.txtDocDateEnd.Size = New System.Drawing.Size(115, 21)
      Me.txtDocDateEnd.TabIndex = 2
      '
      'grbDetail
      '
      Me.grbDetail.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                  Or System.Windows.Forms.AnchorStyles.Left) _
                  Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.grbDetail.Controls.Add(Me.tgItem)
      Me.grbDetail.Controls.Add(Me.lblItem)
      Me.grbDetail.Controls.Add(Me.grbGeneral)
      Me.grbDetail.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.grbDetail.Location = New System.Drawing.Point(8, 8)
      Me.grbDetail.Name = "grbDetail"
      Me.grbDetail.Size = New System.Drawing.Size(752, 448)
      Me.grbDetail.TabIndex = 179
      Me.grbDetail.TabStop = False
      Me.grbDetail.Text = "รายละเอียด"
      '
      'lblItem
      '
      Me.lblItem.BackColor = System.Drawing.Color.Transparent
      Me.lblItem.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblItem.Location = New System.Drawing.Point(8, 208)
      Me.lblItem.Name = "lblItem"
      Me.lblItem.Size = New System.Drawing.Size(160, 18)
      Me.lblItem.TabIndex = 165
      Me.lblItem.Text = "Supplier:"
      Me.lblItem.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      Me.lblItem.Visible = False
      '
      'grbGeneral
      '
      Me.grbGeneral.Controls.Add(Me.btnReSave)
      Me.grbGeneral.Controls.Add(Me.lblProgress)
      Me.grbGeneral.Controls.Add(Me.ProgressBar1)
      Me.grbGeneral.Controls.Add(Me.btnOK)
      Me.grbGeneral.Controls.Add(Me.btnPreview)
      Me.grbGeneral.Controls.Add(Me.FixedGroupBox1)
      Me.grbGeneral.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.grbGeneral.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.grbGeneral.Location = New System.Drawing.Point(8, 16)
      Me.grbGeneral.Name = "grbGeneral"
      Me.grbGeneral.Size = New System.Drawing.Size(360, 168)
      Me.grbGeneral.TabIndex = 179
      Me.grbGeneral.TabStop = False
      '
      'lblProgress
      '
      Me.lblProgress.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblProgress.ForeColor = System.Drawing.SystemColors.WindowText
      Me.lblProgress.Location = New System.Drawing.Point(8, 136)
      Me.lblProgress.Name = "lblProgress"
      Me.lblProgress.Size = New System.Drawing.Size(176, 18)
      Me.lblProgress.TabIndex = 335
      Me.lblProgress.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      '
      'ProgressBar1
      '
      Me.ProgressBar1.Location = New System.Drawing.Point(240, 120)
      Me.ProgressBar1.Name = "ProgressBar1"
      Me.ProgressBar1.Size = New System.Drawing.Size(112, 8)
      Me.ProgressBar1.TabIndex = 334
      Me.ProgressBar1.Visible = False
      '
      'btnOK
      '
      Me.btnOK.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnOK.ForeColor = System.Drawing.Color.Black
      Me.btnOK.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
      Me.btnOK.Location = New System.Drawing.Point(280, 136)
      Me.btnOK.Name = "btnOK"
      Me.btnOK.Size = New System.Drawing.Size(72, 23)
      Me.btnOK.TabIndex = 333
      Me.btnOK.Text = "ตกลง"
      Me.btnOK.ThemedImage = Nothing
      '
      'btnPreview
      '
      Me.btnPreview.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.btnPreview.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnPreview.ForeColor = System.Drawing.Color.Black
      Me.btnPreview.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
      Me.btnPreview.Location = New System.Drawing.Point(200, 136)
      Me.btnPreview.Name = "btnPreview"
      Me.btnPreview.Size = New System.Drawing.Size(72, 23)
      Me.btnPreview.TabIndex = 333
      Me.btnPreview.Text = "Preview"
      Me.btnPreview.ThemedImage = Nothing
      Me.btnPreview.Visible = False
      '
      'FixedGroupBox1
      '
      Me.FixedGroupBox1.Controls.Add(Me.chkRecalUnitCost)
      Me.FixedGroupBox1.Controls.Add(Me.txtDocDateStart)
      Me.FixedGroupBox1.Controls.Add(Me.lblDateStart)
      Me.FixedGroupBox1.Controls.Add(Me.dtpDocDateStart)
      Me.FixedGroupBox1.Controls.Add(Me.txtDocDateEnd)
      Me.FixedGroupBox1.Controls.Add(Me.lblDateEnd)
      Me.FixedGroupBox1.Controls.Add(Me.dtpDocDateEnd)
      Me.FixedGroupBox1.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.FixedGroupBox1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.FixedGroupBox1.Location = New System.Drawing.Point(8, 16)
      Me.FixedGroupBox1.Name = "FixedGroupBox1"
      Me.FixedGroupBox1.Size = New System.Drawing.Size(344, 104)
      Me.FixedGroupBox1.TabIndex = 179
      Me.FixedGroupBox1.TabStop = False
      '
      'chkRecalUnitCost
      '
      Me.chkRecalUnitCost.Checked = True
      Me.chkRecalUnitCost.CheckState = System.Windows.Forms.CheckState.Checked
      Me.chkRecalUnitCost.Location = New System.Drawing.Point(112, 72)
      Me.chkRecalUnitCost.Name = "chkRecalUnitCost"
      Me.chkRecalUnitCost.Size = New System.Drawing.Size(200, 24)
      Me.chkRecalUnitCost.TabIndex = 7
      Me.chkRecalUnitCost.Text = "คำนวณต้นทุนก่อน Re-FIFO"
      '
      'lblDateStart
      '
      Me.lblDateStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblDateStart.ForeColor = System.Drawing.SystemColors.WindowText
      Me.lblDateStart.Location = New System.Drawing.Point(16, 16)
      Me.lblDateStart.Name = "lblDateStart"
      Me.lblDateStart.Size = New System.Drawing.Size(96, 18)
      Me.lblDateStart.TabIndex = 6
      Me.lblDateStart.Text = "หลังจากวันที่:"
      Me.lblDateStart.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'dtpDocDateStart
      '
      Me.dtpDocDateStart.CustomFormat = "dd/MM/yyyy"
      Me.dtpDocDateStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.dtpDocDateStart.Format = System.Windows.Forms.DateTimePickerFormat.Custom
      Me.dtpDocDateStart.Location = New System.Drawing.Point(112, 16)
      Me.dtpDocDateStart.Name = "dtpDocDateStart"
      Me.dtpDocDateStart.Size = New System.Drawing.Size(144, 21)
      Me.dtpDocDateStart.TabIndex = 3
      Me.dtpDocDateStart.TabStop = False
      '
      'lblDateEnd
      '
      Me.lblDateEnd.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblDateEnd.ForeColor = System.Drawing.SystemColors.WindowText
      Me.lblDateEnd.Location = New System.Drawing.Point(16, 40)
      Me.lblDateEnd.Name = "lblDateEnd"
      Me.lblDateEnd.Size = New System.Drawing.Size(96, 18)
      Me.lblDateEnd.TabIndex = 6
      Me.lblDateEnd.Text = "ถึงวันที่:"
      Me.lblDateEnd.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'dtpDocDateEnd
      '
      Me.dtpDocDateEnd.CustomFormat = "dd/MM/yyyy"
      Me.dtpDocDateEnd.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.dtpDocDateEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom
      Me.dtpDocDateEnd.Location = New System.Drawing.Point(112, 40)
      Me.dtpDocDateEnd.Name = "dtpDocDateEnd"
      Me.dtpDocDateEnd.Size = New System.Drawing.Size(144, 21)
      Me.dtpDocDateEnd.TabIndex = 3
      Me.dtpDocDateEnd.TabStop = False
      '
      'btnReSave
      '
      Me.btnReSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.btnReSave.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnReSave.ForeColor = System.Drawing.Color.Black
      Me.btnReSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
      Me.btnReSave.Location = New System.Drawing.Point(8, 136)
      Me.btnReSave.Name = "btnReSave"
      Me.btnReSave.Size = New System.Drawing.Size(72, 23)
      Me.btnReSave.TabIndex = 336
      Me.btnReSave.Text = "ReSave"
      Me.btnReSave.ThemedImage = Nothing
      '
      'StockSequenceDetail
      '
      Me.Controls.Add(Me.grbDetail)
      Me.Name = "StockSequenceDetail"
      Me.Size = New System.Drawing.Size(776, 464)
      Me.grbDetail.ResumeLayout(False)
      Me.grbGeneral.ResumeLayout(False)
      Me.FixedGroupBox1.ResumeLayout(False)
      Me.FixedGroupBox1.PerformLayout()
      Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Members"
    Private m_entity As StockSequence
    Private m_treeManager As TreeManager

    Private m_isInitialized As Boolean

    'Private m_tableInitialized As Boolean

    'Private m_period As AccountPeriod
    'Private m_oldRow As TreeRow = Nothing

    'Private m_otherFilters As Filter()
    'Private m_periodCollection As AccountPeriodCollection

    'Private m_year As Date
#End Region

#Region "Constructors"
    Public Sub New(ByVal entity As ISimpleEntity, ByVal handler As Object, ByVal basket As BasketDialog, ByVal filters As Filter(), ByVal entities As ArrayList)
      MyBase.New()
      InitializeComponent()
      Me.SetLabelText()
      Initialize()

      m_entity = New StockSequence("***") 'Hack by julawut
      Me.m_entity.IsRecalUnitCost = True 'Hack by julawut

      ' Me.WorkbenchWindow.ViewContent.IsDirty = False 'Hack by julawut
      'm_otherFilters = filters

      Dim dt As TreeTable = Me.GetSchemaTable()
      Dim dst As DataGridTableStyle = Me.CreateTableStyle()
      m_treeManager = New TreeManager(dt, tgItem)
      m_treeManager.SetTableStyle(dst)
      m_treeManager.AllowSorting = False
      m_treeManager.AllowDelete = False
      tgItem.AllowNew = False

      CreateHeader()
      'WrapperArrayList.AddItemAddedHandler(dt, AddressOf ItemAdded)
      'AddHandler dt.ColumnChanging, AddressOf Treetable_ColumnChanging
      'AddHandler dt.ColumnChanged, AddressOf Treetable_ColumnChanged
      'AddHandler dt.RowDeleted, AddressOf ItemDelete

      EventWiring()

      'initial entity
      Me.UpdateEntityProperties()
      Me.TitleName = m_entity.TabPageText

      CheckFormEnable()

      LoopControl(Me)
    End Sub
#End Region

#Region "Properties"
    
#End Region

#Region "ISimpleListPanel"
    Public Sub ChangeTitle(ByVal sender As Object, ByVal e As System.EventArgs) Implements ISimpleListPanel.ChangeTitle

    End Sub
    Public Sub CheckFormEnable() Implements ISimplePanel.CheckFormEnable
      'If Me.m_entity.IsReSequenced Then
      '  Me.txtDocDateStart.Enabled = False
      '  Me.dtpDocDateStart.Enabled = False
      'Else
      Me.txtDocDateStart.Enabled = True
      Me.dtpDocDateStart.Enabled = True
      'End If
      Me.txtDocDateEnd.Enabled = True
      Me.dtpDocDateEnd.Enabled = True
      Me.btnOK.Enabled = True
      Me.chkRecalUnitCost.Enabled = True
      Dim currentUserId As Integer = Me.SecurityService.CurrentUser.Id
      Dim currentUserName As String = Me.SecurityService.CurrentUser.Name
      btnReSave.Visible = False
      If currentUserId = 1 OrElse currentUserName = "Pojjaman" Then
        btnReSave.Visible = True
      End If
    End Sub
    Public Sub EnableTextBox()
      Me.txtDocDateStart.Enabled = False
      Me.dtpDocDateStart.Enabled = False
      Me.txtDocDateEnd.Enabled = False
      Me.dtpDocDateEnd.Enabled = False
      Me.btnOK.Enabled = False
      Me.chkRecalUnitCost.Enabled = False
    End Sub
    Public Sub ClearDetail() Implements ISimplePanel.ClearDetail

    End Sub
    Public Sub SetLabelText() Implements ISimplePanel.SetLabelText
      If Not m_entity Is Nothing Then Me.Text = Me.StringParserService.Parse(Me.m_entity.TabPageText)
      Me.grbDetail.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.StockSequence.grbDetail}")
      'Me.grbGeneral.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.StockSequence.grbGeneral}")
      'Me.lblItem.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.StockSequence.lblItem}")
      Me.lblDateStart.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.StockSequence.lblDateStart}")
      Me.lblDateEnd.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.StockSequence.lblDateEnd}")
      Me.chkRecalUnitCost.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.StockSequence.chkRecalUnitCost}")
      Me.btnOK.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.StockSequence.btnOK}")
      Me.Validator.SetDisplayName(Me.txtDocDateStart, lblDateStart.Text)
      Me.Validator.SetDisplayName(Me.txtDocDateEnd, lblDateEnd.Text)
    End Sub
    Protected Sub EventWiring()
      AddHandler txtDocDateStart.Validated, AddressOf Me.ChangeProperty
      AddHandler dtpDocDateStart.ValueChanged, AddressOf Me.ChangeProperty
      AddHandler txtDocDateEnd.Validated, AddressOf Me.ChangeProperty
      AddHandler dtpDocDateEnd.ValueChanged, AddressOf Me.ChangeProperty
      AddHandler chkRecalUnitCost.CheckedChanged, AddressOf Me.ChangeProperty
    End Sub
    'Private Sub TextHandler(ByVal sender As Object, ByVal e As EventArgs)
    '  If Me.m_entity Is Nothing Or Not m_isInitialized Then
    '    Return
    '  End If
    '  Select Case CType(sender, Control).Name.ToLower
    '    Case "txttoccpersoncode"
    '      toCCPersonCodeChanged = True
    '    Case "txttocostcentercode"
    '      toCCCodeChanged = True
    '    Case "txtfromccpersoncode"
    '      fromCCPersonCodeChanged = True
    '    Case "txtfromcostcentercode"
    '      fromCCCodeChanged = True
    '  End Select
    'End Sub
    Public Sub UpdateEntityProperties() Implements ISimplePanel.UpdateEntityProperties
      m_isInitialized = False
      ClearDetail()
      If m_entity Is Nothing Then
        Return
      End If

      txtDocDateStart.Text = MinDateToNull(Me.m_entity.DateStart, Me.StringParserService.Parse("${res:Global.BlankDateText}"))
      dtpDocDateStart.Value = MinDateToNow(Me.m_entity.DateStart)
      txtDocDateEnd.Text = MinDateToNull(Me.m_entity.DateEnd, Me.StringParserService.Parse("${res:Global.BlankDateText}"))
      dtpDocDateEnd.Value = MinDateToNow(Me.m_entity.DateEnd)

      'Hack
      'Me.IsDirty = False

      SetStatus()
      'SetLabelText()
      CheckFormEnable()
      m_isInitialized = True
    End Sub
    Private m_dateSetting As Boolean = False
    Public Sub ChangeProperty(ByVal sender As Object, ByVal e As EventArgs)
      If Me.m_entity Is Nothing Or Not m_isInitialized Then
        Return
      End If
      'Dim dirtyFlag As Boolean = False
      Select Case CType(sender, Control).Name.ToLower
        Case "dtpdocdatestart"
          If Not Me.m_entity.DateStart.Equals(dtpDocDateStart.Value) Then
            If Not m_dateSetting Then
              Me.txtDocDateStart.Text = MinDateToNull(dtpDocDateStart.Value, Me.StringParserService.Parse("${res:Global.BlankDateText}"))
              Me.m_entity.DateStart = dtpDocDateStart.Value
            End If
            'dirtyFlag = True
          End If
        Case "txtdocdatestart"
          m_dateSetting = True
          If Not Me.txtDocDateStart.Text.Length = 0 AndAlso Me.Validator.GetErrorMessage(Me.txtDocDateStart) = "" Then
            Dim theDate As Date = CDate(Me.txtDocDateStart.Text)
            If Not Me.m_entity.DateStart.Equals(theDate) Then
              dtpDocDateStart.Value = theDate
              Me.m_entity.DateStart = dtpDocDateStart.Value
              'dirtyFlag = True
            End If
          Else
            Me.m_entity.DateStart = Date.Now
            Me.m_entity.DateStart = Date.MinValue
            'dirtyFlag = True
          End If
          m_dateSetting = False
        Case "dtpdocdateend"
          If Not Me.m_entity.DateEnd.Equals(dtpDocDateEnd.Value) Then
            If Not m_dateSetting Then
              Me.txtDocDateEnd.Text = MinDateToNull(dtpDocDateEnd.Value, Me.StringParserService.Parse("${res:Global.BlankDateText}"))
              Me.m_entity.DateEnd = dtpDocDateEnd.Value
            End If
            'dirtyFlag = True
          End If
        Case "txtdocdateend"
          m_dateSetting = True
          If Not Me.txtDocDateEnd.Text.Length = 0 AndAlso Me.Validator.GetErrorMessage(Me.txtDocDateEnd) = "" Then
            Dim theDate As Date = CDate(Me.txtDocDateEnd.Text)
            If Not Me.m_entity.DateEnd.Equals(theDate) Then
              dtpDocDateEnd.Value = theDate
              Me.m_entity.DateEnd = dtpDocDateEnd.Value
              'dirtyFlag = True
            End If
          Else
            Me.m_entity.DateEnd = Date.Now
            Me.m_entity.DateEnd = Date.MinValue
            'dirtyFlag = True
          End If
          m_dateSetting = False
        Case "chkrecalunitcost"
          If Me.chkRecalUnitCost.Checked Then
            Me.m_entity.IsRecalUnitCost = 1
          Else
            Me.m_entity.IsRecalUnitCost = 0
          End If

      End Select
      'Me.WorkbenchWindow.ViewContent.IsDirty = Me.WorkbenchWindow.ViewContent.IsDirty Or dirtyFlag
      CheckFormEnable()
    End Sub
    Private Sub PropChanged(ByVal sender As Object, ByVal e As PropertyChangedEventArgs)
      If e.Name = "ItemChanged" Then
        Me.WorkbenchWindow.ViewContent.IsDirty = True
      End If
    End Sub
    Public Sub SetStatus()

    End Sub
    Public Sub ShowInPad() Implements ISimplePanel.ShowInPad

    End Sub

    Public ReadOnly Property Title() As String Implements ISimplePanel.Title
      Get
        If Not m_entity Is Nothing Then
          Return Me.m_entity.ListPanelTitle
        End If
      End Get
    End Property
    Public Property Entity() As BusinessLogic.ISimpleEntity Implements ISimpleEntityPanel.Entity
      Get
        Return m_entity
      End Get
      Set(ByVal Value As BusinessLogic.ISimpleEntity)

      End Set
    End Property

    Public Event EntityPropertyChanged(ByVal sender As Object, ByVal e As System.EventArgs) Implements ISimpleEntityPanel.EntityPropertyChanged

    Public Sub AddNew() Implements ISimpleListPanel.AddNew

    End Sub

    Private Sub OnEntitySelected(ByVal entity As ISimpleEntity)
      RaiseEvent EntitySelected(entity)
    End Sub
    Public Event EntitySelected(ByVal entity As BusinessLogic.ISimpleEntity) Implements ISimpleListPanel.EntitySelected

    Public Sub RefreshData(ByVal id As String) Implements ISimpleListPanel.RefreshData
      UpdateEntityProperties()
    End Sub

    Public Property SelectedEntity() As BusinessLogic.ISimpleEntity Implements ISimpleListPanel.SelectedEntity
      Get
      End Get
      Set(ByVal Value As BusinessLogic.ISimpleEntity)
      End Set
    End Property
    Public ReadOnly Property Icon() As String Implements ISimplePanel.Icon
      Get

      End Get
    End Property

    Public Sub Initialize() Implements ISimplePanel.Initialize
      'PopulateCombo()
    End Sub
#End Region

#Region "Methods"
    Private Sub CreateHeader()
      If Me.m_treeManager Is Nothing Then
        Return
      End If

      Dim indent As String = Space(3)

      ' Level 1.
      Dim tr As TreeRow = Me.m_treeManager.Treetable.Childs.Add
      tr("col0") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAPRemain.SupplierCode}") '"รหัสเจ้าหนี้"
      tr("col1") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAPRemain.SupplierName}") '"ชื่อเจ้าหนี้"
      tr("col2") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAPRemain.OpenningBalance}") '"ยอดยกมา"
      tr("col3") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAPRemain.Debt}") '"ยอดซื้อเชื่อ"
      tr("col4") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAPRemain.Dicount}") '"ยอดลดหนี้"
      tr("col5") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAPRemain.Pay}") '"ยอดจ่ายชำระ"
      tr("col6") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAPRemain.EndingBalance}") '"ยอดยกไป"
      tr("col7") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAPRemain.RetentionOpeningBalance}") '"ยอด Retention ยกมา"
      tr("col8") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAPRemain.Retention}") '"ยอด Retention"
      tr("col9") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAPRemain.PayRetention}") '"ยอดจ่ายชำระ Retention"
      tr("col10") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAPRemain.RetentionEndingBalance}") '"ยอด Retention ยกไป"

    End Sub
    Private Sub PopulateData()
      Dim dt As DataTable = Me.m_entity.DataSet.Tables(0)
      If dt.Rows.Count <= 0 Then
        Return
      End If

      Dim trSupplier As TreeRow
      Dim trDetail As TreeRow
      For Each row As DataRow In dt.Rows
        trSupplier = Me.m_treeManager.Treetable.Childs.Add
        trSupplier.Tag = "Font.Bold"
        If Not row.IsNull("stock_code") Then
          trSupplier("col0") = row("supplier_code").ToString
        End If
        If Not row.IsNull("stocki_lineNumber") Then
          trSupplier("col1") = row("stocki_lineNumber").ToString
        End If

      Next
    End Sub
    Public Function ValidIdOrDBNull(ByVal entity As SimpleBusinessEntityBase) As Object
      If entity Is Nothing OrElse Not entity.Valid Then
        Return DBNull.Value
      End If
      Return entity.Id
    End Function
    Public Function ValidDateOrDBNull(ByVal myDate As Date) As Object
      If myDate.Equals(Date.MinValue) Then
        Return DBNull.Value
      End If
      Return myDate
    End Function
    Public Function MinDateToNull(ByVal dt As Date, ByVal nullString As String) As String
      If dt.Equals(Date.MinValue) Then
        Return nullString
      End If
      Return dt.ToShortDateString
    End Function
    Public Function MinDateToNow(ByVal dt As Date) As Date
      If dt.Equals(Date.MinValue) Then
        dt = Now
      End If
      Return dt
    End Function
#End Region

#Region "Style"
    'Private Function GetLockingComboTable() As DataTable
    '  Dim dt As New DataTable
    '  dt.Columns.Add(New DataColumn("Value"))
    '  dt.Columns.Add(New DataColumn("Description"))

    '  Dim row As DataRow = dt.NewRow
    '  row("Value") = 0
    '  row("Description") = "No Lock"
    '  dt.Rows.Add(row)

    '  row = dt.NewRow
    '  row("Value") = 1
    '  row("Description") = "GL Lock"
    '  dt.Rows.Add(row)

    '  row = dt.NewRow
    '  row("Value") = 2
    '  row("Description") = "All Lock"
    '  dt.Rows.Add(row)

    '  Return dt
    'End Function
    Public Function CreateTableStyle() As DataGridTableStyle
      Dim dst As New DataGridTableStyle
      dst.MappingName = "StockSequence"
      Dim widths As New ArrayList
      Dim iCol As Integer = 10 'IIf(Me.ShowDetailInGrid = 0, 6, 7)

      widths.Add(100)
      widths.Add(200)
      widths.Add(150)
      widths.Add(100)
      widths.Add(100)
      widths.Add(100)
      widths.Add(100)
      widths.Add(120)
      widths.Add(120)
      widths.Add(120)
      widths.Add(120)

      For i As Integer = 0 To iCol
        If i = 1 Then
          Dim cs As New PlusMinusTreeTextColumn
          cs.MappingName = "col" & i
          cs.HeaderText = ""
          cs.Width = CInt(widths(i))
          cs.NullText = ""
          cs.Alignment = HorizontalAlignment.Left
          cs.ReadOnly = True
          cs.Format = "s"
          'AddHandler cs.CheckCellHilighted, AddressOf Me.SetHilightValues
          dst.GridColumnStyles.Add(cs)
        Else
          Dim cs As New TreeTextColumn(i, True, Color.Khaki)
          cs.MappingName = "col" & i
          cs.HeaderText = ""
          cs.Width = CInt(widths(i))
          cs.NullText = ""
          cs.Alignment = HorizontalAlignment.Left
          'If Me.m_showDetailInGrid <> 0 Then
          '  Select Case i
          '    Case 0, 1, 2
          '      cs.Alignment = HorizontalAlignment.Left
          '      cs.DataAlignment = HorizontalAlignment.Left
          '      cs.Format = "s"
          '    Case Else
          '      cs.Alignment = HorizontalAlignment.Right
          '      cs.DataAlignment = HorizontalAlignment.Right
          '      cs.Format = "d"
          '  End Select
          'Else
          '  Select Case i
          '    Case 0, 1
          '      cs.Alignment = HorizontalAlignment.Left
          '      cs.DataAlignment = HorizontalAlignment.Left
          '      cs.Format = "s"
          '    Case Else
          '      cs.Alignment = HorizontalAlignment.Right
          '      cs.DataAlignment = HorizontalAlignment.Right
          '      cs.Format = "d"
          '  End Select
          'End If

          cs.ReadOnly = True

          'AddHandler cs.CheckCellHilighted, AddressOf Me.SetHilightValues
          dst.GridColumnStyles.Add(cs)
        End If
      Next

      Return dst
    End Function
    Public Function GetSchemaTable() As TreeTable
      Dim myDatatable As New TreeTable("Report")
      myDatatable.Columns.Add(New DataColumn("col0", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("col1", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("col2", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("col3", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("col4", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("col5", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("col6", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("col7", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("col8", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("col9", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("col10", GetType(String)))

      Return myDatatable
    End Function
#End Region

#Region "TreeTable Handlers"
    Public Sub ValidateRow(ByVal e As DataColumnChangeEventArgs)
      Dim code As Object = e.Row("code")
      Dim startdate As Object = e.Row("startdate")
      Dim enddate As Object = e.Row("enddate")

      Select Case e.Column.ColumnName.ToLower
        Case "code"
          code = e.ProposedValue
        Case "startdate"
          startdate = e.ProposedValue
        Case "enddate"
          enddate = e.ProposedValue
      End Select

      Dim isBlankRow As Boolean = False
      If (IsDBNull(code) OrElse code.ToString.Length = 0) _
          And (IsDBNull(startdate) OrElse CDate(startdate).Equals(Date.MinValue)) _
          And (IsDBNull(enddate) OrElse CDate(enddate).Equals(Date.MinValue)) _
          Then
        isBlankRow = True
      End If

      If Not isBlankRow Then
        If IsDBNull(code) OrElse CStr(code).Length = 0 Then
          e.Row.SetColumnError("code", Me.StringParserService.Parse("${res:Global.Error.NoPeriodCode}"))
        Else
          e.Row.SetColumnError("code", "")
        End If
        If IsDBNull(startdate) OrElse CStr(startdate).Length = 0 Then
          e.Row.SetColumnError("startdate", Me.StringParserService.Parse("${res:Global.Error.NoPeriodStartDate}"))
        Else
          e.Row.SetColumnError("startdate", "")
        End If
        If IsDBNull(enddate) OrElse CStr(enddate).Length = 0 Then
          e.Row.SetColumnError("enddate", Me.StringParserService.Parse("${res:Global.Error.NoPeriodEndDate}"))
        Else
          e.Row.SetColumnError("enddate", "")
        End If
      End If
    End Sub
    Public Function ValidateRow(ByVal row As TreeRow) As Boolean
      Dim code As Object = row("code")
      Dim startdate As Object = row("startdate")
      Dim enddate As Object = row("enddate")

      Dim flag As Boolean = True
      If (IsDBNull(code) OrElse code.ToString.Length = 0) _
          And (IsDBNull(startdate) OrElse CDate(startdate).Equals(Date.MinValue)) _
          And (IsDBNull(enddate) OrElse CDate(enddate).Equals(Date.MinValue)) _
          Then
        flag = False
      End If

      Return flag
    End Function
    Private m_updating As Boolean = False
    Private Function DupCode(ByVal e As DataColumnChangeEventArgs) As Boolean
      If IsDBNull(e.ProposedValue) Then
        Return False
      End If
      For Each row As TreeRow In Me.m_treeManager.Treetable.Rows
        If Not row Is e.Row Then
          If Not row.IsNull("code") Then
            If e.ProposedValue.ToString.ToLower = row("code").ToString.ToLower Then
              Return True
            End If
          End If
        End If
      Next
      Return False
    End Function
#End Region

#Region "Event Handlers"
    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click

      Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
      Dim currentUserId As Integer = currentUserId
      If SecurityService.CurrentUser Is Nothing Then
        msgServ.ShowMessage("${res:Global.Error.NoUser}")
        Me.OnSaved(New SaveEventArgs(False))
        SecurityService.UpdateAccessTable()
        WorkbenchSingleton.Workbench.RedrawEditComponents()
        Return
      End If


      currentUserId = SecurityService.CurrentUser.Id

      'If validator.GetErrorMessage(txtDocDateStart).Length <> 0 Then
      '  msgServ.ShowMessage(validator.ValidationSummary)
      '  Return
      'End If
      If Not Validator Is Nothing Then
        If Not Validator.ValidationSummary Is Nothing AndAlso Validator.ValidationSummary.Length > 0 Then
          msgServ.ShowMessage(Validator.ValidationSummary)
          Me.OnSaved(New SaveEventArgs(False))
          SecurityService.UpdateAccessTable()
          WorkbenchSingleton.Workbench.RedrawEditComponents()
          Return
        End If
      End If

      If Not msgServ.AskQuestionFormatted("${res:Longkong.Pojjaman.Gui.Panels.StockSequence.ReSequence}", New String() {Me.m_entity.DateStart.ToShortDateString, Me.m_entity.DateEnd.ToShortDateString}) Then
        Return
      End If

      Dim aThreadStart As New Threading.ThreadStart(AddressOf Save)
      Dim aThread As New Thread(aThreadStart)
      aThread.Name = "SaveThred"

      EnableTextBox()
      SetProgress()
      aThread.Start()

      'Save()
       'Dim bThreadStart As New Threading.ThreadStart(AddressOf SetProgress)
      'Dim bThread As New Thread(bThreadStart)
      'bThread.Name = "ProgressThred"
      'bThread.Start()

    End Sub
    Dim Timer1 As New System.Windows.Forms.Timer
    'Dim countWatch As DateTime = New DateTime(Now.Year, 1, 1, 23, 59, 59)
    Dim stTime(3) As Integer

    Private Sub SetProgress()
      'ProgressBar1.Minimum = 0
      'ProgressBar1.Maximum = 50
      'ProgressBar1.Value = 0
      'ProgressBar1.Visible = True

      AddHandler Timer1.Tick, AddressOf Timer1_Tick
      Timer1.Interval = 1000 '50
      Timer1.Enabled = True
      Timer1.Start()
    End Sub
    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs)
      'ProgressBar1.Value += 1

      'countWatch = DateAdd(DateInterval.Second, 0.05, countWatch)
      lblProgress.Text = "Processing : " & stTime(2).ToString("00") & ":" & _
                                           stTime(1).ToString("00") & ":" & _
                                           stTime(0).ToString("00")
      stTime(0) += 1
      If stTime(0) = 60 Then
        stTime(1) += 1
        stTime(0) = 0
      End If
      If stTime(1) = 60 Then
        stTime(2) += 1
        stTime(1) = 0
        stTime(0) = 0
      End If

      'If ProgressBar1.Value = 50 Then
      '  ProgressBar1.Value = 1
      'End If
    End Sub
    Private Sub btnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPreview.Click
    End Sub

#End Region

#Region "Overrides"
    Public Overrides ReadOnly Property TabPageText() As String
      Get
        Return Me.m_entity.ListPanelTitle
      End Get
    End Property
    Public Overloads Overrides Sub Save()
      OnSaving(New EventArgs)
      Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
      Dim currentUserId As Integer = currentUserId
      'If SecurityService.CurrentUser Is Nothing Then
      '  msgServ.ShowMessage("${res:Global.Error.NoUser}")
      '  Me.OnSaved(New SaveEventArgs(False))
      '  SecurityService.UpdateAccessTable()
      '  WorkbenchSingleton.Workbench.RedrawEditComponents()
      '  Return
      'End If
      currentUserId = SecurityService.CurrentUser.Id

      ''If validator.GetErrorMessage(txtDocDateStart).Length <> 0 Then
      ''  msgServ.ShowMessage(validator.ValidationSummary)
      ''  Return
      ''End If
      'If Not Validator Is Nothing Then
      '  If Not Validator.ValidationSummary Is Nothing AndAlso Validator.ValidationSummary.Length > 0 Then
      '    msgServ.ShowMessage(Validator.ValidationSummary)
      '    Me.OnSaved(New SaveEventArgs(False))
      '    SecurityService.UpdateAccessTable()
      '    WorkbenchSingleton.Workbench.RedrawEditComponents()
      '    Return
      '  End If
      'End If

      'EnableTextBox()

      'If Not Me.WorkbenchWindow.SubViewContents Is Nothing AndAlso Me.WorkbenchWindow.SubViewContents.Count > 0 Then
      '  For Each content As IBaseViewContent In Me.WorkbenchWindow.SubViewContents
      '    If TypeOf content Is IValidatable Then
      '      Dim validator As Gui.Components.PJMTextboxValidator = CType(content, IValidatable).FormValidator
      '      If Not validator Is Nothing Then
      '        If Not validator.ValidationSummary Is Nothing AndAlso validator.ValidationSummary.Length > 0 Then
      '          msgServ.ShowMessage(validator.ValidationSummary)
      '          Me.OnSaved(New SaveEventArgs(False))
      '          SecurityService.UpdateAccessTable()
      '          WorkbenchSingleton.Workbench.RedrawEditComponents()
      '          Return
      '        End If
      '      End If
      '    End If
      '  Next
      'End If

      Dim errorMessage As String = Me.m_entity.Save(currentUserId).Message

      ProgressBar1.Value = 50
      Timer1.Enabled = False
      If Not IsNumeric(errorMessage) AndAlso errorMessage.Length > 0 Then 'Todo
        msgServ.ShowMessage(errorMessage)
        Me.OnSaved(New SaveEventArgs(False))
      Else
        msgServ.ShowMessage("${res:Global.Info.DataSaved}")
        'CType(Me, ISimpleListPanel).RefreshData("")
        Me.IsDirty = False
        Me.OnSaved(New SaveEventArgs(True))
      End If

      'SecurityService.UpdateAccessTable()
      'WorkbenchSingleton.Workbench.RedrawEditComponents()

      'lblProgress.Text = ""
      'ProgressBar1.Visible = False
      ''CheckFormEnable()

      'm_entity = New StockSequence("***") 'Hack by julawut
      'Me.UpdateEntityProperties()

      'GC.Collect()
    End Sub
#End Region

#Region "IValidatable"
    Public ReadOnly Property FormValidator() As components.PJMTextboxValidator Implements IValidatable.FormValidator
      Get
        Return Me.Validator
      End Get
    End Property
#End Region

#Region "IClipboardHandler Overrides"
#End Region

#Region "IKeyReceiver"
    Public Overrides Function ProcessKey(ByVal keyPressed As System.Windows.Forms.Keys) As Boolean
      Try
        Select Case keyPressed
          Case Keys.Insert
            'ibtnBlank_Click(Nothing, Nothing)
            Return True
          Case Keys.Delete
            If Me.tgItem.Focused Then
              'ibtnDelRow_Click(Nothing, Nothing)
              Return True
            Else
              Return False
            End If
          Case Else
            Return False
        End Select
      Catch ex As Exception
        Throw ex
      End Try
    End Function
#End Region


    Private Sub btnReSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnReSave.Click
      Dim resaveStock As New ReSaveStock
      resaveStock.DateStart = txtDocDateStart.Text
      resaveStock.DateEnd = txtDocDateEnd.Text
      resaveStock.DateStart = dtpDocDateStart.Value
      resaveStock.save()
    End Sub
  End Class
End Namespace