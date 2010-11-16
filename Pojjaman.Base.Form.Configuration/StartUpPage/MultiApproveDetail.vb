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
Imports Telerik.WinControls.UI

Namespace Longkong.Pojjaman.Gui.Panels
  Public Class MultiApproveDetail
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
    Friend WithEvents ibtnAdd As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents Validator As Longkong.Pojjaman.Gui.Components.PJMTextboxValidator
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents rgbDocumentType As Telerik.WinControls.UI.RadGroupBox
    Friend WithEvents rGrid As Telerik.WinControls.UI.RadGridView
    Friend WithEvents ibtnApprove As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents chkPA As System.Windows.Forms.CheckBox
    Friend WithEvents chkGR As System.Windows.Forms.CheckBox
    Friend WithEvents chkDR As System.Windows.Forms.CheckBox
    Friend WithEvents chkSC As System.Windows.Forms.CheckBox
    Friend WithEvents chkPO As System.Windows.Forms.CheckBox
    Friend WithEvents chkWR As System.Windows.Forms.CheckBox
    Friend WithEvents chkPR As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents chkSelectAll As System.Windows.Forms.CheckBox
    Friend WithEvents chkAlwaysShow As System.Windows.Forms.CheckBox
    Friend WithEvents chkAlwaysShowData As System.Windows.Forms.CheckBox
    Friend WithEvents btnRefresh As System.Windows.Forms.Button
    Friend WithEvents chkShowDetail As System.Windows.Forms.CheckBox
    Friend WithEvents cmbApprovalType As System.Windows.Forms.ComboBox
    Friend WithEvents cmbDateRank As System.Windows.Forms.ComboBox
    Friend WithEvents BreezeTheme As Telerik.WinControls.Themes.BreezeTheme
    Friend WithEvents VistaTheme As Telerik.WinControls.Themes.VistaTheme
    Friend WithEvents grbDetail As Longkong.Pojjaman.Gui.Components.FixedGroupBox
    <System.Diagnostics.DebuggerStepThrough()> Protected Sub InitializeComponent()
      Me.components = New System.ComponentModel.Container()
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MultiApproveDetail))
      Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
      Me.Validator = New Longkong.Pojjaman.Gui.Components.PJMTextboxValidator(Me.components)
      Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
      Me.ibtnApprove = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.chkAlwaysShow = New System.Windows.Forms.CheckBox()
      Me.grbDetail = New Longkong.Pojjaman.Gui.Components.FixedGroupBox()
      Me.cmbApprovalType = New System.Windows.Forms.ComboBox()
      Me.cmbDateRank = New System.Windows.Forms.ComboBox()
      Me.btnRefresh = New System.Windows.Forms.Button()
      Me.GroupBox2 = New System.Windows.Forms.GroupBox()
      Me.chkShowDetail = New System.Windows.Forms.CheckBox()
      Me.chkSelectAll = New System.Windows.Forms.CheckBox()
      Me.rGrid = New Telerik.WinControls.UI.RadGridView()
      Me.rgbDocumentType = New Telerik.WinControls.UI.RadGroupBox()
      Me.chkPA = New System.Windows.Forms.CheckBox()
      Me.chkGR = New System.Windows.Forms.CheckBox()
      Me.chkDR = New System.Windows.Forms.CheckBox()
      Me.chkSC = New System.Windows.Forms.CheckBox()
      Me.chkPO = New System.Windows.Forms.CheckBox()
      Me.chkWR = New System.Windows.Forms.CheckBox()
      Me.chkPR = New System.Windows.Forms.CheckBox()
      Me.chkAlwaysShowData = New System.Windows.Forms.CheckBox()
      Me.BreezeTheme = New Telerik.WinControls.Themes.BreezeTheme()
      Me.VistaTheme = New Telerik.WinControls.Themes.VistaTheme()
      CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.grbDetail.SuspendLayout()
      Me.GroupBox2.SuspendLayout()
      CType(Me.rGrid, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me.rgbDocumentType, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.rgbDocumentType.SuspendLayout()
      Me.SuspendLayout()
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
      'ibtnApprove
      '
      Me.ibtnApprove.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.ibtnApprove.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.ibtnApprove.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.ibtnApprove.Location = New System.Drawing.Point(25, 414)
      Me.ibtnApprove.Name = "ibtnApprove"
      Me.ibtnApprove.Size = New System.Drawing.Size(72, 64)
      Me.ibtnApprove.TabIndex = 334
      Me.ibtnApprove.TabStop = False
      Me.ibtnApprove.ThemedImage = CType(resources.GetObject("ibtnApprove.ThemedImage"), System.Drawing.Bitmap)
      Me.ToolTip1.SetToolTip(Me.ibtnApprove, "ยืนยันการรับของ และบันทึกการจัดสรร")
      '
      'chkAlwaysShow
      '
      Me.chkAlwaysShow.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.chkAlwaysShow.AutoSize = True
      Me.chkAlwaysShow.Checked = True
      Me.chkAlwaysShow.CheckState = System.Windows.Forms.CheckState.Checked
      Me.chkAlwaysShow.Location = New System.Drawing.Point(8, 516)
      Me.chkAlwaysShow.Name = "chkAlwaysShow"
      Me.chkAlwaysShow.Size = New System.Drawing.Size(190, 17)
      Me.chkAlwaysShow.TabIndex = 0
      Me.chkAlwaysShow.Text = "แสดงหน้านี้เสมอตอนเปิดโปรแกรม"
      Me.chkAlwaysShow.UseVisualStyleBackColor = True
      '
      'grbDetail
      '
      Me.grbDetail.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                  Or System.Windows.Forms.AnchorStyles.Left) _
                  Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.grbDetail.Controls.Add(Me.cmbApprovalType)
      Me.grbDetail.Controls.Add(Me.cmbDateRank)
      Me.grbDetail.Controls.Add(Me.btnRefresh)
      Me.grbDetail.Controls.Add(Me.GroupBox2)
      Me.grbDetail.Controls.Add(Me.rgbDocumentType)
      Me.grbDetail.Controls.Add(Me.ibtnApprove)
      Me.grbDetail.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.grbDetail.Location = New System.Drawing.Point(8, 8)
      Me.grbDetail.Name = "grbDetail"
      Me.grbDetail.Size = New System.Drawing.Size(757, 502)
      Me.grbDetail.TabIndex = 179
      Me.grbDetail.TabStop = False
      '
      'cmbApprovalType
      '
      Me.cmbApprovalType.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.cmbApprovalType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbApprovalType.FormattingEnabled = True
      Me.cmbApprovalType.Location = New System.Drawing.Point(512, 289)
      Me.cmbApprovalType.Name = "cmbApprovalType"
      Me.cmbApprovalType.Size = New System.Drawing.Size(236, 21)
      Me.cmbApprovalType.TabIndex = 341
      '
      'cmbDateRank
      '
      Me.cmbDateRank.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.cmbDateRank.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbDateRank.FormattingEnabled = True
      Me.cmbDateRank.Location = New System.Drawing.Point(512, 317)
      Me.cmbDateRank.Name = "cmbDateRank"
      Me.cmbDateRank.Size = New System.Drawing.Size(236, 21)
      Me.cmbDateRank.TabIndex = 341
      '
      'btnRefresh
      '
      Me.btnRefresh.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.btnRefresh.Location = New System.Drawing.Point(512, 344)
      Me.btnRefresh.Name = "btnRefresh"
      Me.btnRefresh.Size = New System.Drawing.Size(70, 23)
      Me.btnRefresh.TabIndex = 336
      Me.btnRefresh.Text = "Refresh"
      Me.btnRefresh.UseVisualStyleBackColor = True
      '
      'GroupBox2
      '
      Me.GroupBox2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                  Or System.Windows.Forms.AnchorStyles.Left) _
                  Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.GroupBox2.Controls.Add(Me.chkShowDetail)
      Me.GroupBox2.Controls.Add(Me.chkSelectAll)
      Me.GroupBox2.Controls.Add(Me.rGrid)
      Me.GroupBox2.Location = New System.Drawing.Point(25, 60)
      Me.GroupBox2.Name = "GroupBox2"
      Me.GroupBox2.Size = New System.Drawing.Size(465, 348)
      Me.GroupBox2.TabIndex = 340
      Me.GroupBox2.TabStop = False
      '
      'chkShowDetail
      '
      Me.chkShowDetail.AutoSize = True
      Me.chkShowDetail.Location = New System.Drawing.Point(104, 19)
      Me.chkShowDetail.Name = "chkShowDetail"
      Me.chkShowDetail.Size = New System.Drawing.Size(139, 17)
      Me.chkShowDetail.TabIndex = 0
      Me.chkShowDetail.Text = "แสดงรายละเอียดทั้งหมด"
      Me.chkShowDetail.UseVisualStyleBackColor = True
      '
      'chkSelectAll
      '
      Me.chkSelectAll.AutoSize = True
      Me.chkSelectAll.Location = New System.Drawing.Point(15, 19)
      Me.chkSelectAll.Name = "chkSelectAll"
      Me.chkSelectAll.Size = New System.Drawing.Size(83, 17)
      Me.chkSelectAll.TabIndex = 0
      Me.chkSelectAll.Text = "เลือกทั้งหมด"
      Me.chkSelectAll.UseVisualStyleBackColor = True
      '
      'rGrid
      '
      Me.rGrid.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                  Or System.Windows.Forms.AnchorStyles.Left) _
                  Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.rGrid.Location = New System.Drawing.Point(0, 42)
      '
      '
      '
      Me.rGrid.MasterGridViewTemplate.EnableGrouping = False
      Me.rGrid.MultiSelect = True
      Me.rGrid.Name = "rGrid"
      Me.rGrid.ShowGroupPanel = False
      Me.rGrid.Size = New System.Drawing.Size(465, 306)
      Me.rGrid.TabIndex = 335
      Me.rGrid.ThemeName = "Vista"
      '
      'rgbDocumentType
      '
      Me.rgbDocumentType.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.rgbDocumentType.Controls.Add(Me.chkPA)
      Me.rgbDocumentType.Controls.Add(Me.chkGR)
      Me.rgbDocumentType.Controls.Add(Me.chkDR)
      Me.rgbDocumentType.Controls.Add(Me.chkSC)
      Me.rgbDocumentType.Controls.Add(Me.chkPO)
      Me.rgbDocumentType.Controls.Add(Me.chkWR)
      Me.rgbDocumentType.Controls.Add(Me.chkPR)
      Me.rgbDocumentType.FooterImageIndex = -1
      Me.rgbDocumentType.FooterImageKey = ""
      Me.rgbDocumentType.HeaderImageIndex = -1
      Me.rgbDocumentType.HeaderImageKey = ""
      Me.rgbDocumentType.HeaderMargin = New System.Windows.Forms.Padding(0)
      Me.rgbDocumentType.HeaderText = "ประเภทเอกสาร"
      Me.rgbDocumentType.Location = New System.Drawing.Point(512, 93)
      Me.rgbDocumentType.Name = "rgbDocumentType"
      Me.rgbDocumentType.Padding = New System.Windows.Forms.Padding(10, 20, 10, 10)
      '
      '
      '
      Me.rgbDocumentType.RootElement.Padding = New System.Windows.Forms.Padding(10, 20, 10, 10)
      Me.rgbDocumentType.Size = New System.Drawing.Size(236, 190)
      Me.rgbDocumentType.TabIndex = 337
      Me.rgbDocumentType.Text = "ประเภทเอกสาร"
      '
      'chkPA
      '
      Me.chkPA.AutoSize = True
      Me.chkPA.Checked = True
      Me.chkPA.CheckState = System.Windows.Forms.CheckState.Checked
      Me.chkPA.Location = New System.Drawing.Point(25, 165)
      Me.chkPA.Name = "chkPA"
      Me.chkPA.Size = New System.Drawing.Size(57, 17)
      Me.chkPA.TabIndex = 0
      Me.chkPA.Text = "รับงาน"
      Me.chkPA.UseVisualStyleBackColor = True
      '
      'chkGR
      '
      Me.chkGR.AutoSize = True
      Me.chkGR.Checked = True
      Me.chkGR.CheckState = System.Windows.Forms.CheckState.Checked
      Me.chkGR.Location = New System.Drawing.Point(25, 142)
      Me.chkGR.Name = "chkGR"
      Me.chkGR.Size = New System.Drawing.Size(56, 17)
      Me.chkGR.TabIndex = 0
      Me.chkGR.Text = "รับของ"
      Me.chkGR.UseVisualStyleBackColor = True
      '
      'chkDR
      '
      Me.chkDR.AutoSize = True
      Me.chkDR.Checked = True
      Me.chkDR.CheckState = System.Windows.Forms.CheckState.Checked
      Me.chkDR.Location = New System.Drawing.Point(25, 119)
      Me.chkDR.Name = "chkDR"
      Me.chkDR.Size = New System.Drawing.Size(83, 17)
      Me.chkDR.TabIndex = 0
      Me.chkDR.Text = "หักค่าใช้จ่าย"
      Me.chkDR.UseVisualStyleBackColor = True
      '
      'chkSC
      '
      Me.chkSC.AutoSize = True
      Me.chkSC.Checked = True
      Me.chkSC.CheckState = System.Windows.Forms.CheckState.Checked
      Me.chkSC.Location = New System.Drawing.Point(25, 96)
      Me.chkSC.Name = "chkSC"
      Me.chkSC.Size = New System.Drawing.Size(135, 17)
      Me.chkSC.TabIndex = 0
      Me.chkSC.Text = "สั่งจ้าง/เปลี่ยนแปลงงาน"
      Me.chkSC.UseVisualStyleBackColor = True
      '
      'chkPO
      '
      Me.chkPO.AutoSize = True
      Me.chkPO.Checked = True
      Me.chkPO.CheckState = System.Windows.Forms.CheckState.Checked
      Me.chkPO.Location = New System.Drawing.Point(25, 73)
      Me.chkPO.Name = "chkPO"
      Me.chkPO.Size = New System.Drawing.Size(50, 17)
      Me.chkPO.TabIndex = 0
      Me.chkPO.Text = "สั่งซื้อ"
      Me.chkPO.UseVisualStyleBackColor = True
      '
      'chkWR
      '
      Me.chkWR.AutoSize = True
      Me.chkWR.Checked = True
      Me.chkWR.CheckState = System.Windows.Forms.CheckState.Checked
      Me.chkWR.Location = New System.Drawing.Point(25, 50)
      Me.chkWR.Name = "chkWR"
      Me.chkWR.Size = New System.Drawing.Size(54, 17)
      Me.chkWR.TabIndex = 0
      Me.chkWR.Text = "ขอจ้าง"
      Me.chkWR.UseVisualStyleBackColor = True
      '
      'chkPR
      '
      Me.chkPR.AutoSize = True
      Me.chkPR.Checked = True
      Me.chkPR.CheckState = System.Windows.Forms.CheckState.Checked
      Me.chkPR.Location = New System.Drawing.Point(25, 27)
      Me.chkPR.Name = "chkPR"
      Me.chkPR.Size = New System.Drawing.Size(51, 17)
      Me.chkPR.TabIndex = 0
      Me.chkPR.Text = "ขอซื้อ"
      Me.chkPR.UseVisualStyleBackColor = True
      '
      'chkAlwaysShowData
      '
      Me.chkAlwaysShowData.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.chkAlwaysShowData.Checked = True
      Me.chkAlwaysShowData.CheckState = System.Windows.Forms.CheckState.Checked
      Me.chkAlwaysShowData.Location = New System.Drawing.Point(204, 515)
      Me.chkAlwaysShowData.Name = "chkAlwaysShowData"
      Me.chkAlwaysShowData.Size = New System.Drawing.Size(236, 19)
      Me.chkAlwaysShowData.TabIndex = 0
      Me.chkAlwaysShowData.Text = "แสดงรายการเสมอตอนเปิดโปรแกรม"
      Me.chkAlwaysShowData.UseVisualStyleBackColor = True
      '
      'MultiApproveDetail
      '
      Me.Controls.Add(Me.chkAlwaysShow)
      Me.Controls.Add(Me.grbDetail)
      Me.Controls.Add(Me.chkAlwaysShowData)
      Me.Name = "MultiApproveDetail"
      Me.Size = New System.Drawing.Size(776, 538)
      CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
      Me.grbDetail.ResumeLayout(False)
      Me.GroupBox2.ResumeLayout(False)
      Me.GroupBox2.PerformLayout()
      CType(Me.rGrid, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me.rgbDocumentType, System.ComponentModel.ISupportInitialize).EndInit()
      Me.rgbDocumentType.ResumeLayout(False)
      Me.rgbDocumentType.PerformLayout()
      Me.ResumeLayout(False)
      Me.PerformLayout()

    End Sub

#End Region

#Region "Members"
    Private m_entity As MultiApproval
    Private m_treeManager As TreeManager
    Private m_isInitialized As Boolean
    Private rTemplate As GridViewTemplate
    Private rRelation As GridViewRelation
    'Private m_tableInitialized As Boolean

    'Private m_period As AccountPeriod
    'Private m_oldRow As TreeRow = Nothing

    'Private m_otherFilters As Filter()
    'Private m_periodCollection As AccountPeriodCollection

    'Private m_year As Date
#End Region

#Region "Constructors"
    Public Sub New(ByVal entity As ISimpleEntity, ByVal handler As Object, ByVal basket As BasketDialog, ByVal filters As Filter(), ByVal entities As ArrayList)
      'Public Sub New()
      MyBase.New()
      InitializeComponent()
      'Me.SetLabelText()
      Initialize()


      m_entity = New MultiApproval(User.CurrentUser.Id, Me.GetListOfApproveType, Me.GetListOfDateRank)
      m_entity.CurrentUserId = User.CurrentUser.Id


      EventWiring()

      ''initial entity
      Me.UpdateEntityProperties()


      'Me.TitleName = m_entity.TabPageText

    End Sub
#End Region

#Region "Properties"
    Private ReadOnly Property MasterCaptionName As String
      Get
        Return "master"
      End Get
    End Property
    Private ReadOnly Property ApprovalCaptionName As String
      Get
        Return Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.MultiApproval.CommentList}") '"รายการอนุมัติ/แสดงความคิดเห็น"
      End Get
    End Property
    Private ReadOnly Property DescriptionDocumentCaptionName As String
      Get
        Return Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.MultiApproval.DocumentDetail}") '"รายละเอียดเอกสาร"
      End Get
    End Property
    Private m_user As SecurityService
    Public ReadOnly Property User As SecurityService
      Get
        If m_user Is Nothing Then
          m_user = CType(ServiceManager.Services.GetService(GetType(SecurityService)), SecurityService)
        End If
        Return m_user
      End Get
    End Property
    Private m_stringParserService As StringParserService
    Public ReadOnly Property StringParserService() As StringParserService
      Get
        If m_stringParserService Is Nothing Then
          m_stringParserService = CType(ServiceManager.Services.GetService(GetType(StringParserService)), StringParserService)
        End If
        Return m_stringParserService
      End Get
    End Property
#End Region

#Region "ISimpleListPanel"
    Public Sub RefreshData(Optional ByVal ForceRefresh As Boolean = False)
      If Not m_entity Is Nothing Then

        Me.m_entity.RefreshDataSource(User.CurrentUser.Id, rGrid, Me.GetListOfDocument, Me.GetListOfApproveType, Me.GetListOfDateRank, ForceRefresh)
        'm_entity.RefreshDocumentList(chkDocumenList)
        'For Each rowinf As GridViewRowInfo In Me.rGrid.Rows
        '  'rowinf.EnsureVisible()
        '  rowinf.Height = 35
        'Next
      End If
    End Sub
    Public Sub ChangeTitle(ByVal sender As Object, ByVal e As System.EventArgs) Implements ISimpleListPanel.ChangeTitle

    End Sub
    Public Sub CheckFormEnable() Implements ISimplePanel.CheckFormEnable

    End Sub
    Public Sub EnableTextBox()

    End Sub
    Public Sub ClearDetail() Implements ISimplePanel.ClearDetail

    End Sub
    Public Sub SetLabelText() Implements ISimplePanel.SetLabelText

    End Sub
    Protected Sub EventWiring()
      AddHandler chkSelectAll.CheckedChanged, AddressOf Me.ChangeProperty
      AddHandler chkAlwaysShow.CheckedChanged, AddressOf Me.ChangeProperty
      AddHandler chkAlwaysShowData.CheckedChanged, AddressOf Me.ChangeProperty
      AddHandler chkShowDetail.CheckedChanged, AddressOf Me.ChangeProperty
      AddHandler rGrid.CellDoubleClick, AddressOf CellDoubleClick
      AddHandler btnRefresh.Click, AddressOf ButtonClick

      AddHandler chkPR.CheckedChanged, AddressOf Me.ChangeProperty
      AddHandler chkWR.CheckedChanged, AddressOf Me.ChangeProperty
      AddHandler chkPO.CheckedChanged, AddressOf Me.ChangeProperty
      AddHandler chkSC.CheckedChanged, AddressOf Me.ChangeProperty
      AddHandler chkDR.CheckedChanged, AddressOf Me.ChangeProperty
      AddHandler chkGR.CheckedChanged, AddressOf Me.ChangeProperty
      AddHandler chkPA.CheckedChanged, AddressOf Me.ChangeProperty

      AddHandler ibtnApprove.Click, AddressOf Me.ButtonApproveClick
      AddHandler rGrid.ValueChanged, AddressOf Me.rGridValueChanged
    End Sub
    Public Sub UpdateEntityProperties() Implements ISimplePanel.UpdateEntityProperties
      m_isInitialized = False
      ClearDetail()
      If m_entity Is Nothing Then
        Return
      End If

      Me.chkAlwaysShow.Checked = Me.m_entity.AlwaysShowPage
      Me.chkAlwaysShowData.Checked = Me.m_entity.AlwaysShowData

      RefreshData(False)

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
      ''Dim dirtyFlag As Boolean = False
      Select Case CType(sender, Control).Name.ToLower
        Case chkSelectAll.Name.ToLower
          Me.ToggleSelection(sender)
        Case chkAlwaysShow.Name.ToLower
          Me.m_entity.AlwaysShowPage = chkAlwaysShow.Checked
        Case chkAlwaysShowData.Name.ToLower
          Me.m_entity.AlwaysShowData = chkAlwaysShowData.Checked
        Case chkPR.Name.ToLower, chkWR.Name.ToLower, chkPO.Name.ToLower, chkSC.Name.ToLower, chkDR.Name.ToLower, chkGR.Name.ToLower, chkPA.Name.ToLower
          ', _
          'rdbWaitforApprove.Name.ToLower, rdbApproved.Name.ToLower, rdbReject.Name.ToLower, rdbNotApprove.Name.ToLower
          Me.m_entity.RefreshDataSource(User.CurrentUser.Id, rGrid, Me.GetListOfDocument, Me.GetListOfApproveType, Me.GetListOfDateRank)
        Case chkShowDetail.Name.ToLower
          Dim isExpand As Boolean = chkShowDetail.Checked
          Me.ExpandAllRows(rGrid, isExpand)
      End Select
    End Sub
    Private Function GetListOfDocument() As ArrayList
      Dim newDocList As New ArrayList
      Dim checkCal As Integer = 0
      Dim docTypeString As String = ""
      If chkPR.Checked Then
        docTypeString = "doctype = " & CType(chkPR.Tag, KeyValuePair).Key
        newDocList.Add(docTypeString)
        checkCal += 1
      End If
      If chkWR.Checked Then
        docTypeString = "doctype = " & CType(chkWR.Tag, KeyValuePair).Key
        newDocList.Add(docTypeString)
        checkCal += 1
      End If
      If chkPO.Checked Then
        docTypeString = "doctype = " & CType(chkPO.Tag, KeyValuePair).Key
        newDocList.Add(docTypeString)
        checkCal += 1
      End If
      If chkSC.Checked Then
        docTypeString = "doctype = " & CType(chkSC.Tag, KeyValuePair).Key
        newDocList.Add(docTypeString)
        checkCal += 1
      End If
      If chkDR.Checked Then
        docTypeString = "doctype = " & CType(chkDR.Tag, KeyValuePair).Key
        newDocList.Add(docTypeString)
        checkCal += 1
      End If
      If chkGR.Checked Then
        docTypeString = "doctype = " & CType(chkGR.Tag, KeyValuePair).Key
        newDocList.Add(docTypeString)
        checkCal += 1
      End If
      If chkPA.Checked Then
        docTypeString = "doctype = " & CType(chkPA.Tag, KeyValuePair).Key
        newDocList.Add(docTypeString)
        checkCal += 1
      End If

      If checkCal = 0 Then 'ไม่เลือกเลยสักตัว
        newDocList.Add("doctype = -1")
      ElseIf checkCal = 7 Then 'เลือกทุกตัว

      End If

      Return newDocList
    End Function
    Private Function GetListOfApproveType() As Integer

      Dim key As IdValuePair = CType(cmbApprovalType.SelectedItem, IdValuePair)

      Return key.Id
    End Function
    Private Function GetListOfDateRank() As Integer

      Dim key As IdValuePair = CType(cmbDateRank.SelectedItem, IdValuePair)

      Return key.Id
    End Function
    Private Sub ToggleSelection(ByVal sender As Object)

      Dim checked As Boolean = CType(sender, CheckBox).Checked

      For Each grd As GridViewDataRowInfo In rGrid.Rows
        If checked Then
          grd.Cells("selected").Value = True
        Else
          grd.Cells("selected").Value = False
        End If
      Next

    End Sub
    Private Sub PropChanged(ByVal sender As Object, ByVal e As PropertyChangedEventArgs)
      'If e.Name = "ItemChanged" Then
      '  Me.WorkbenchWindow.ViewContent.IsDirty = True
      'End If
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
      CreateHeaderGridStyle()
      'CreateHeaderTemplateStyle()

      rGrid.GridElement.BeginUpdate()

      rGrid.MasterGridViewTemplate.ChildGridViewTemplates.Clear()
      rGrid.MasterGridViewTemplate.AllowAddNewRow = False
      rGrid.MasterGridViewTemplate.AllowDeleteRow = False
      rGrid.MasterGridViewTemplate.AllowCellContextMenu = False
      rGrid.MasterGridViewTemplate.AllowColumnResize = True
      rGrid.MasterGridViewTemplate.AllowRowResize = False

      'rGrid.MasterGridViewTemplate.AutoExpandGroups = True

      CreateHeaderTemplateStyle()
      CreateHeaderTemplateStyle2()

      rGrid.GridElement.EndUpdate()

      Dim key As KeyValuePair
      key = New KeyValuePair("6", "Longkong.Pojjaman.BusinessLogic.PO")
      chkPO.Tag = key
      key = New KeyValuePair("7", "Longkong.Pojjaman.BusinessLogic.PR")
      chkPR.Tag = key
      key = New KeyValuePair("45", "Longkong.Pojjaman.BusinessLogic.GoodsReceipt")
      chkGR.Tag = key
      key = New KeyValuePair("289", "Longkong.Pojjaman.BusinessLogic.SC")
      chkSC.Tag = key
      'key = New KeyValuePair("290", "Longkong.Pojjaman.BusinessLogic.VO")
      key = New KeyValuePair("291", "Longkong.Pojjaman.BusinessLogic.DR")
      chkDR.Tag = key
      key = New KeyValuePair("292", "Longkong.Pojjaman.BusinessLogic.PA")
      chkPA.Tag = key
      key = New KeyValuePair("324", "Longkong.Pojjaman.BusinessLogic.WR")
      chkWR.Tag = key


      For Each chk As CheckBox In rgbDocumentType.Controls
        Me.SetAccessDocument(chk)
      Next

      PopulateCombo()
    End Sub
#End Region

#Region "Methods"
    Private Sub PopulateCombo()
      cmbApprovalType.Items.Add(New IdValuePair(5, Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.MultiApproval.WaitForApprove}"))) ' "รออนุมัติ"
      cmbApprovalType.Items.Add(New IdValuePair(4, Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.MultiApproval.Approved}"))) '"อนุมัติแล้ว"
      cmbApprovalType.Items.Add(New IdValuePair(3, Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.MultiApproval.Reject}"))) '"ถูกส่งกลับ"
      cmbApprovalType.Items.Add(New IdValuePair(2, Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.MultiApproval.NonApprove}"))) '"ยังไม่ได้อนุมัติ"

      cmbApprovalType.SelectedIndex = 0

      cmbDateRank.Items.Add(New IdValuePair(-1, Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.MultiApproval.NotSpecific}"))) ' "ไม่ระบุวัน"
      cmbDateRank.Items.Add(New IdValuePair(1, Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.MultiApproval.Todays}"))) ' "ไม่เกินวันนี้"
      cmbDateRank.Items.Add(New IdValuePair(2, Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.MultiApproval.NotOver24Hours}"))) ' "ไม่เกิน 24 ชั่วโมง"
      cmbDateRank.Items.Add(New IdValuePair(3, Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.MultiApproval.NotOver15Days}"))) ' "ไม่เกิน 15 วัน"
      cmbDateRank.Items.Add(New IdValuePair(4, Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.MultiApproval.NotOver4Weeks}"))) ' "ไม่เกิน 4 สัปดาห์"
      cmbDateRank.Items.Add(New IdValuePair(5, Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.MultiApproval.NotOver12Months}"))) ' "ไม่เกิน 12 เดือน"
      'cmbDateRank.Items.Add(New IdValuePair(5, Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.MultiApproval.Over1Year}"))) ' "เกิน 1 ปี"

      cmbDateRank.SelectedIndex = 4
    End Sub
    Private Sub SetAccessDocument(ByVal chk As CheckBox)
      Dim secSrv As SecurityService = CType(ServiceManager.Services.GetService(GetType(SecurityService)), SecurityService)

      Dim key As KeyValuePair = CType(chk.Tag, KeyValuePair)
      Dim fullclassName As String = CStr(key.Value)
      Dim accessId As Integer = Longkong.Pojjaman.BusinessLogic.Entity.GetAccessIdFromFullClassName(fullclassName)
      Dim level As Integer = secSrv.GetAccess(accessId)
      Dim checkString As String = BinaryHelper.DecToBin(level, 5)
      checkString = BinaryHelper.RevertString(checkString)
      If Not CBool(checkString.Substring(0, 1)) Then
        chk.Checked = False
        chk.Enabled = False
      End If
    End Sub
    Private Sub CreateHeader()
      If Me.m_treeManager Is Nothing Then
        Return
      End If

      'Dim indent As String = Space(3)

      '' Level 1.
      'Dim tr As TreeRow = Me.m_treeManager.Treetable.Childs.Add
      'tr("col0") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAPRemain.SupplierCode}") '"รหัสเจ้าหนี้"
      'tr("col1") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAPRemain.SupplierName}") '"ชื่อเจ้าหนี้"
      'tr("col2") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAPRemain.OpenningBalance}") '"ยอดยกมา"
      'tr("col3") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAPRemain.Debt}") '"ยอดซื้อเชื่อ"
      'tr("col4") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAPRemain.Dicount}") '"ยอดลดหนี้"
      'tr("col5") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAPRemain.Pay}") '"ยอดจ่ายชำระ"
      'tr("col6") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAPRemain.EndingBalance}") '"ยอดยกไป"
      'tr("col7") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAPRemain.RetentionOpeningBalance}") '"ยอด Retention ยกมา"
      'tr("col8") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAPRemain.Retention}") '"ยอด Retention"
      'tr("col9") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAPRemain.PayRetention}") '"ยอดจ่ายชำระ Retention"
      'tr("col10") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAPRemain.RetentionEndingBalance}") '"ยอด Retention ยกไป"

    End Sub
    Private Sub PopulateData()
      'Dim dt As DataTable = Me.m_entity.DataSet.Tables(0)
      'If dt.Rows.Count <= 0 Then
      '  Return
      'End If

      'Dim trSupplier As TreeRow
      'Dim trDetail As TreeRow
      'For Each row As DataRow In dt.Rows
      '  trSupplier = Me.m_treeManager.Treetable.Childs.Add
      '  trSupplier.Tag = "Font.Bold"
      '  If Not row.IsNull("stock_code") Then
      '    trSupplier("col0") = row("supplier_code").ToString
      '  End If
      '  If Not row.IsNull("stocki_lineNumber") Then
      '    trSupplier("col1") = row("stocki_lineNumber").ToString
      '  End If

      'Next
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
    Private Sub CreateHeaderGridStyle()
      rGrid.MasterGridViewTemplate.Caption = Me.MasterCaptionName

      'Visible Column =================================================================================

      Dim gridColumn As New GridViewTextBoxColumn("relationApproveId")
      gridColumn.Width = 0
      gridColumn.ReadOnly = True
      gridColumn.IsVisible = False
      rGrid.Columns.Add(gridColumn)

      gridColumn = New GridViewTextBoxColumn("docid")
      gridColumn.Width = 0
      gridColumn.ReadOnly = True
      gridColumn.IsVisible = False
      rGrid.Columns.Add(gridColumn)

      gridColumn = New GridViewTextBoxColumn("doctype")
      gridColumn.Width = 0
      gridColumn.HeaderText = ""
      gridColumn.ReadOnly = True
      gridColumn.IsVisible = False
      rGrid.Columns.Add(gridColumn)

      gridColumn = New GridViewTextBoxColumn("daterank")
      gridColumn.Width = 0
      gridColumn.HeaderText = "" 'Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptEquipmentStatus.AccountName}")
      gridColumn.ReadOnly = True
      gridColumn.IsVisible = False
      rGrid.Columns.Add(gridColumn)

      gridColumn = New GridViewTextBoxColumn("dateranktype")
      gridColumn.Width = 0
      gridColumn.HeaderText = "" 'Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptEquipmentStatus.AccountName}")
      gridColumn.ReadOnly = True
      gridColumn.IsVisible = False
      rGrid.Columns.Add(gridColumn)

      gridColumn = New GridViewTextBoxColumn("apvdoc_linenumber")
      gridColumn.Width = 0
      gridColumn.HeaderText = "" 'Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptEquipmentStatus.AccountName}")
      gridColumn.ReadOnly = True
      gridColumn.IsVisible = False
      rGrid.Columns.Add(gridColumn)

      gridColumn = New GridViewTextBoxColumn("right_app_level")
      gridColumn.Width = 0
      gridColumn.HeaderText = "" 'Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptEquipmentStatus.AccountName}")
      gridColumn.ReadOnly = True
      gridColumn.IsVisible = False
      rGrid.Columns.Add(gridColumn)

      'Visible Column =================================

      gridColumn = New GridViewTextBoxColumn("lineNumber")
      gridColumn.Width = 40
      gridColumn.HeaderText = "" 'Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.MultiApproval.Seq}") '"ลำดับ"
      gridColumn.TextAlignment = ContentAlignment.MiddleLeft
      gridColumn.HeaderTextAlignment = ContentAlignment.MiddleLeft
      gridColumn.ReadOnly = True
      rGrid.Columns.Add(gridColumn)

      Dim chkColumn As New GridViewCheckBoxColumn("selected")
      chkColumn.DataType = GetType(Boolean)
      chkColumn.Width = 15
      chkColumn.TextAlignment = ContentAlignment.MiddleCenter
      chkColumn.HeaderText = ""
      chkColumn.ReadOnly = False
      rGrid.Columns.Add(chkColumn)

      gridColumn = New GridViewTextBoxColumn("right_doctypename")
      gridColumn.Width = 110
      gridColumn.TextAlignment = ContentAlignment.MiddleLeft
      gridColumn.HeaderTextAlignment = ContentAlignment.MiddleLeft
      gridColumn.HeaderText = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.MultiApproval.Document}") '"เอกสาร" 
      gridColumn.ReadOnly = True
      rGrid.Columns.Add(gridColumn)

      gridColumn = New GridViewTextBoxColumn("doccode")
      gridColumn.Width = 135
      gridColumn.TextAlignment = ContentAlignment.MiddleLeft
      gridColumn.HeaderTextAlignment = ContentAlignment.MiddleLeft
      gridColumn.HeaderText = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.MultiApproval.DocCode}") '"เลขที่"
      gridColumn.ReadOnly = True
      rGrid.Columns.Add(gridColumn)

      gridColumn = New GridViewTextBoxColumn("docdate")
      gridColumn.Width = 75
      gridColumn.TextAlignment = ContentAlignment.MiddleCenter
      gridColumn.HeaderTextAlignment = ContentAlignment.MiddleCenter
      gridColumn.HeaderText = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.MultiApproval.DocDate}") '"วันที่"
      'gridColumn.DataType = GetType(DateTime)
      'gridColumn.FormatString = "{0:d}"
      gridColumn.ReadOnly = True
      rGrid.Columns.Add(gridColumn)

      gridColumn = New GridViewTextBoxColumn("amount")
      gridColumn.Width = 90
      gridColumn.TextAlignment = ContentAlignment.MiddleRight
      gridColumn.HeaderTextAlignment = ContentAlignment.MiddleRight
      gridColumn.HeaderText = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.MultiApproval.Amount}") '"ยอดเงินรวม" 
      'gridColumn.DataType = GetType(Decimal)
      'gridColumn.FormatString = "{0:N}"
      gridColumn.ReadOnly = True
      rGrid.Columns.Add(gridColumn)

      gridColumn = New GridViewTextBoxColumn("lasteditdocname")
      gridColumn.Width = 135
      gridColumn.TextAlignment = ContentAlignment.MiddleLeft
      gridColumn.HeaderTextAlignment = ContentAlignment.MiddleLeft
      gridColumn.HeaderText = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.MultiApproval.LastEditor}") '"ผู้ปรับปรุงสถานะล่าสุด" 
      gridColumn.ReadOnly = True
      rGrid.Columns.Add(gridColumn)

      gridColumn = New GridViewTextBoxColumn("lasteditdocstatus")
      gridColumn.Width = 175
      gridColumn.TextAlignment = ContentAlignment.MiddleLeft
      gridColumn.HeaderTextAlignment = ContentAlignment.MiddleLeft
      gridColumn.HeaderText = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.MultiApproval.LastStatus}") '"สถานะล่าสุด"
      gridColumn.ReadOnly = True
      rGrid.Columns.Add(gridColumn)

      'gridColumn = New GridViewTextBoxColumn("lasteditDocDate")
      'gridColumn.Width = 0
      'gridColumn.TextAlignment = ContentAlignment.MiddleCenter
      'gridColumn.HeaderTextAlignment = ContentAlignment.MiddleCenter
      'gridColumn.HeaderText = "วันที่ปรับปรุง" 'Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptEquipmentStatus.AccountName}")
      'gridColumn.DataType = GetType(DateTime)
      'gridColumn.FormatString = "{0:d}"
      'gridColumn.ReadOnly = True
      ''gridColumn.IsVisible = False
      'rGrid.Columns.Add(gridColumn)

      gridColumn = New GridViewTextBoxColumn("apvdoc_comment")
      gridColumn.Width = 135
      gridColumn.TextAlignment = ContentAlignment.MiddleLeft
      gridColumn.HeaderTextAlignment = ContentAlignment.MiddleLeft
      gridColumn.HeaderText = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.MultiApproval.Comment}") '"ความคิดเห็น" 
      gridColumn.ReadOnly = True
      rGrid.Columns.Add(gridColumn)

    End Sub
    Private Sub CreateHeaderTemplateStyle()
      Dim gTemplate As New GridViewTemplate(rGrid)
      gTemplate.Caption = Me.ApprovalCaptionName
      gTemplate.ChildViewTabsPosition = TabPositions.Top
      gTemplate.AllowRowResize = False

      gTemplate.AllowAddNewRow = False
      gTemplate.AllowDeleteRow = False
      gTemplate.AllowCellContextMenu = False
      gTemplate.AllowColumnResize = True
      gTemplate.AutoGenerateColumns = False
      'gTemplate.ShowRowHeaderColumn = False

      Dim gridColumn As New GridViewTextBoxColumn("relationApproveId")
      gridColumn.Width = 0
      gridColumn.ReadOnly = True
      gridColumn.IsVisible = False
      gTemplate.Columns.Add(gridColumn)

      gridColumn = New GridViewTextBoxColumn("apvdoc_linenumber")
      gridColumn.Width = 40
      gridColumn.HeaderText = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.MultiApproval.Seq}") '"ลำดับ"
      gridColumn.TextAlignment = ContentAlignment.MiddleLeft
      gridColumn.HeaderTextAlignment = ContentAlignment.MiddleLeft
      gridColumn.ReadOnly = True
      gTemplate.Columns.Add(gridColumn)

      gridColumn = New GridViewTextBoxColumn("apvdoc_comment")
      gridColumn.Width = 350
      gridColumn.TextAlignment = ContentAlignment.MiddleLeft
      gridColumn.HeaderTextAlignment = ContentAlignment.MiddleLeft
      gridColumn.HeaderText = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.MultiApproval.Comment}") ' "ความคิดเห็น" 
      gridColumn.ReadOnly = True
      gTemplate.Columns.Add(gridColumn)

      gridColumn = New GridViewTextBoxColumn("docdate")
      gridColumn.Width = 150
      gridColumn.TextAlignment = ContentAlignment.MiddleCenter
      gridColumn.HeaderTextAlignment = ContentAlignment.MiddleCenter
      gridColumn.HeaderText = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.MultiApproval.DocDate}") '"วันที่"
      'gridColumn.DataType = GetType(DateTime)
      'gridColumn.FormatString = "{0:d}"
      gridColumn.ReadOnly = True
      gTemplate.Columns.Add(gridColumn)

      gridColumn = New GridViewTextBoxColumn("lasteditorName")
      gridColumn.Width = 150
      gridColumn.TextAlignment = ContentAlignment.MiddleLeft
      gridColumn.HeaderTextAlignment = ContentAlignment.MiddleLeft
      gridColumn.HeaderText = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.MultiApproval.Commentator}") '"ผู้แสดงความคิดเห็น"
      gridColumn.ReadOnly = True
      gTemplate.Columns.Add(gridColumn)

      gridColumn = New GridViewTextBoxColumn("approveStatus")
      gridColumn.Width = 135
      gridColumn.TextAlignment = ContentAlignment.MiddleLeft
      gridColumn.HeaderTextAlignment = ContentAlignment.MiddleLeft
      gridColumn.HeaderText = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.MultiApproval.Status}") '"สถานะการอนุมัติ" 
      gridColumn.ReadOnly = True
      gTemplate.Columns.Add(gridColumn)

      'gTemplate.ShowColumnHeaders = False
      rGrid.MasterGridViewTemplate.ChildGridViewTemplates.Add(gTemplate)

      Dim relation1 As New GridViewRelation(rGrid.MasterGridViewTemplate)
      relation1.RelationName = "approvedoc"
      relation1.ParentColumnNames.Add("relationApproveId")
      relation1.ChildColumnNames.Add("relationApproveId")
      relation1.ChildTemplate = gTemplate
      rGrid.Relations.Add(relation1)

      'Dim relation2 As New GridViewRelation(rGrid.MasterGridViewTemplate)
      'relation2.RelationName = "approvedoc2"
      'relation2.ParentColumnNames.Add("doctype")
      'relation2.ChildColumnNames.Add("apvdoc_entityType")
      'relation2.ChildTemplate = gTemplate
      'rGrid.Relations.Add(relation2)
    End Sub
    Private Sub CreateHeaderTemplateStyle2()
      Dim gTemplate As New GridViewTemplate(rGrid)
      gTemplate.Caption = Me.DescriptionDocumentCaptionName
      gTemplate.ChildViewTabsPosition = TabPositions.Top
      gTemplate.AllowRowResize = False
      gTemplate.ShowColumnHeaders = False
      'gTemplate.AllowRowResize = True

      gTemplate.AllowAddNewRow = False
      gTemplate.AllowDeleteRow = False
      gTemplate.AllowCellContextMenu = False
      gTemplate.AllowColumnResize = True
      gTemplate.AutoGenerateColumns = False

      'gTemplate.ShowRowHeaderColumn = False

      Dim gridColumn As New GridViewTextBoxColumn("relationApproveId")
      gridColumn.Width = 0
      gridColumn.ReadOnly = True
      gridColumn.IsVisible = False
      gTemplate.Columns.Add(gridColumn)

      gridColumn = New GridViewTextBoxColumn("cc_code")
      gridColumn.Width = 550
      gridColumn.TextAlignment = ContentAlignment.MiddleLeft
      gridColumn.HeaderTextAlignment = ContentAlignment.MiddleLeft
      gridColumn.HeaderText = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.MultiApproval.CostCenterCode}") '"รหัส Cost Center"
      gridColumn.ReadOnly = True
      gridColumn.DisableHTMLRendering = False
      gTemplate.Columns.Add(gridColumn)

      gridColumn = New GridViewTextBoxColumn("cc_name")
      gridColumn.Width = 550
      gridColumn.TextAlignment = ContentAlignment.MiddleLeft
      gridColumn.HeaderTextAlignment = ContentAlignment.MiddleLeft
      gridColumn.HeaderText = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.MultiApproval.CostCenterName}") '"ชื่อ Cost Center"
      gridColumn.ReadOnly = True
      gridColumn.DisableHTMLRendering = False
      gTemplate.Columns.Add(gridColumn)

      gridColumn = New GridViewTextBoxColumn("supplier_code")
      gridColumn.Width = 550
      gridColumn.TextAlignment = ContentAlignment.MiddleLeft
      gridColumn.HeaderTextAlignment = ContentAlignment.MiddleLeft
      gridColumn.HeaderText = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.MultiApproval.SupplierCode}") '"รหัสผู้ขาย/ผู้รับเหมา"
      gridColumn.ReadOnly = True
      gridColumn.DisableHTMLRendering = False
      gTemplate.Columns.Add(gridColumn)

      gridColumn = New GridViewTextBoxColumn("supplier_name")
      gridColumn.Width = 550
      gridColumn.TextAlignment = ContentAlignment.MiddleLeft
      gridColumn.HeaderTextAlignment = ContentAlignment.MiddleLeft
      gridColumn.HeaderText = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.MultiApproval.SupplierName}") '"ชื่อผู้ขาย/ผู้รับเหมา"
      gridColumn.ReadOnly = True
      gridColumn.DisableHTMLRendering = False
      gTemplate.Columns.Add(gridColumn)

      rGrid.MasterGridViewTemplate.ChildGridViewTemplates.Add(gTemplate)

      Dim relation1 As New GridViewRelation(rGrid.MasterGridViewTemplate)
      relation1.RelationName = "apvdoc"
      relation1.ParentColumnNames.Add("relationApproveId")
      relation1.ChildColumnNames.Add("relationApproveId")
      relation1.ChildTemplate = gTemplate
      rGrid.Relations.Add(relation1)

      'Dim viewMsDef As New HtmlViewDefinition
      'viewMsDef.RowTemplate.ReadXml("")

      Dim viewDef As New HtmlViewDefinition()
      viewDef.RowTemplate.Rows.Add(New RowDefinition())
      viewDef.RowTemplate.Rows.Add(New RowDefinition())
      viewDef.RowTemplate.Rows.Add(New RowDefinition())
      viewDef.RowTemplate.Rows.Add(New RowDefinition())

      viewDef.RowTemplate.Rows(0).Cells.Add(New CellDefinition("cc_code", 0, 1, 1))
      viewDef.RowTemplate.Rows(1).Cells.Add(New CellDefinition("cc_name", 0, 1, 1))
      viewDef.RowTemplate.Rows(2).Cells.Add(New CellDefinition("supplier_code", 0, 1, 1))
      viewDef.RowTemplate.Rows(3).Cells.Add(New CellDefinition("supplier_name", 0, 1, 1))


      'viewDef.RowTemplate.Rows(0).Cells.Add(New CellDefinition("name", 0, 1, 1))
      'viewDef.RowTemplate.Rows(1).Cells.Add(New CellDefinition("name", 0, 1, 1))
      Me.rGrid.MasterGridViewTemplate.ChildGridViewTemplates(1).ViewDefinition = viewDef
      'Dim relation2 As New GridViewRelation(rGrid.MasterGridViewTemplate)
      'relation2.RelationName = "approvedoc2"
      'relation2.ParentColumnNames.Add("doctype")
      'relation2.ChildColumnNames.Add("apvdoc_entityType")
      'relation2.ChildTemplate = gTemplate
      'rGrid.Relations.Add(relation2)
    End Sub
    Private Sub radGridView1_CellFormatting(ByVal sender As Object, ByVal e As CellFormattingEventArgs) Handles rGrid.CellFormatting
      Dim column As GridViewDataColumn = TryCast(e.CellElement.ColumnInfo, GridViewDataColumn)
      If column IsNot Nothing Then
        If column.OwnerTemplate.Caption = Me.DescriptionDocumentCaptionName Then
          If column.FieldName = "cc_code" Then
            e.CellElement.Text = "<html><b>" & e.CellElement.ColumnInfo.HeaderText & ": </b> " & _
              e.CellElement.RowInfo.Cells("cc_code").Value.ToString()
          End If
          If column.FieldName = "supplier_code" Then
            e.CellElement.Text = "<html><b>" & e.CellElement.ColumnInfo.HeaderText & ": </b>" & _
              e.CellElement.RowInfo.Cells("supplier_code").Value.ToString()
          End If
          If column.FieldName = "cc_name" Then
            e.CellElement.Text = "<html><b>" & e.CellElement.ColumnInfo.HeaderText & ": </b> " & _
              e.CellElement.RowInfo.Cells("cc_name").Value.ToString()
          End If
          If column.FieldName = "supplier_name" Then
            e.CellElement.Text = "<html><b>" & e.CellElement.ColumnInfo.HeaderText & ": </b>" & _
              e.CellElement.RowInfo.Cells("supplier_name").Value.ToString()
          End If
        End If
        'If column.OwnerTemplate.Caption = Me.MasterCaptionName Then
        '  If column.FieldName.ToLower = "lasteditdocstatus" Then
        '    e.CellElement.Text = e.CellElement.RowInfo.Cells("lastEditdocStatus").Value.ToString() & _
        '      Space(2) & "(" & e.CellElement.RowInfo.Cells("daterank").Value.ToString & _
        '      Space(1) & MultiApproval.GetDateUnitName(e.CellElement.RowInfo.Cells("dateranktype").Value) & ")"
        '  End If
        '  '  If column.FieldName = "docdate" Then
        '  '    e.CellElement.Text = e.CellElement.FormatString("{0:d}")
        '  '  End If
        '  '  If column.FieldName = "amount" Then
        '  '    e.CellElement.Text = String.Format("{0:n}", e.CellElement.RowInfo.Cells("amount").Value)
        '  '  End If
        'End If
      End If
      'If column IsNot Nothing AndAlso column.OwnerTemplate.Caption = "Performance" Then
      '  If e.CellElement.RowInfo.Tag Is Nothing Then
      '    chart.Series.Clear(chart.Series.Add(GetRowData(CType(e.CellElement.RowInfo, GridViewRowInfo))))
      '    e.CellElement.RowInfo.Tag = chart.GetBitmap()
      '  End If
      '  e.CellElement.Image = TryCast(e.CellElement.RowInfo.Tag, Image)
      '  e.CellElement.DrawBorder = False
      '  e.CellElement.Text = ""
      '  e.CellElement.Padding = New Padding(10, 0, 0, 0)
      'End If
    End Sub
    Private Sub radGridView1_ViewRowFormatting(ByVal sender As Object, ByVal e As RowFormattingEventArgs) Handles rGrid.ViewRowFormatting
      Dim row As GridDetailViewRowElement = TryCast(e.RowElement, GridDetailViewRowElement)
      If row IsNot Nothing Then
        row.ContentCell.ChildTableElement.Padding = New Padding(0, 8, 0, 8)
        'If e.RowElement.ViewTemplate.Caption = Me.MasterCaptionName Then
        '  e.RowElement.BackColor = Color.AntiqueWhite
        'End If
      End If
    End Sub
    Private Sub radGridView1_ChildViewExpanded(ByVal sender As Object, ByVal e As ChildViewExpandedEventArgs) Handles rGrid.ChildViewExpanded
      'e.ChildRow.ChildViewInfos(0).Rows(0).Height = 45
      e.ChildRow.ChildViewInfos(1).Rows(0).Height = 120
      e.ChildRow.ChildViewInfos(1).Rows(0).IsSelected = False
      'e.ChildRow.ChildViewInfos(1).Rows(1).Height = 50
    End Sub
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
      'Dim code As Object = e.Row("code")
      'Dim startdate As Object = e.Row("startdate")
      'Dim enddate As Object = e.Row("enddate")

      'Select Case e.Column.ColumnName.ToLower
      '  Case "code"
      '    code = e.ProposedValue
      '  Case "startdate"
      '    startdate = e.ProposedValue
      '  Case "enddate"
      '    enddate = e.ProposedValue
      'End Select

      'Dim isBlankRow As Boolean = False
      'If (IsDBNull(code) OrElse code.ToString.Length = 0) _
      '    And (IsDBNull(startdate) OrElse CDate(startdate).Equals(Date.MinValue)) _
      '    And (IsDBNull(enddate) OrElse CDate(enddate).Equals(Date.MinValue)) _
      '    Then
      '  isBlankRow = True
      'End If

      'If Not isBlankRow Then
      '  If IsDBNull(code) OrElse CStr(code).Length = 0 Then
      '    e.Row.SetColumnError("code", Me.StringParserService.Parse("${res:Global.Error.NoPeriodCode}"))
      '  Else
      '    e.Row.SetColumnError("code", "")
      '  End If
      '  If IsDBNull(startdate) OrElse CStr(startdate).Length = 0 Then
      '    e.Row.SetColumnError("startdate", Me.StringParserService.Parse("${res:Global.Error.NoPeriodStartDate}"))
      '  Else
      '    e.Row.SetColumnError("startdate", "")
      '  End If
      '  If IsDBNull(enddate) OrElse CStr(enddate).Length = 0 Then
      '    e.Row.SetColumnError("enddate", Me.StringParserService.Parse("${res:Global.Error.NoPeriodEndDate}"))
      '  Else
      '    e.Row.SetColumnError("enddate", "")
      '  End If
      'End If
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
    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

      Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
      Dim currentUserId As Integer = currentUserId
      'If SecurityService.CurrentUser Is Nothing Then
      '  msgServ.ShowMessage("${res:Global.Error.NoUser}")
      '  Me.OnSaved(New SaveEventArgs(False))
      '  SecurityService.UpdateAccessTable()
      '  WorkbenchSingleton.Workbench.RedrawEditComponents()
      '  Return
      'End If


      'currentUserId = SecurityService.CurrentUser.Id

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

      'If Not msgServ.AskQuestionFormatted("${res:Longkong.Pojjaman.Gui.Panels.StockSequence.ReSequence}", New String() {Me.m_entity.DateStart.ToShortDateString, Me.m_entity.DateEnd.ToShortDateString}) Then
      '  Return
      'End If

      'Dim aThreadStart As New Threading.ThreadStart(AddressOf Save)
      'Dim aThread As New Thread(aThreadStart)
      'aThread.Name = "SaveThred"

      'EnableTextBox()
      'SetProgress()
      'aThread.Start()

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
      'lblProgress.Text = "Processing : " & stTime(2).ToString("00") & ":" & _
      '                                     stTime(1).ToString("00") & ":" & _
      '                                     stTime(0).ToString("00")
      'stTime(0) += 1
      'If stTime(0) = 60 Then
      '  stTime(1) += 1
      '  stTime(0) = 0
      'End If
      'If stTime(1) = 60 Then
      '  stTime(2) += 1
      '  stTime(1) = 0
      '  stTime(0) = 0
      'End If

      'If ProgressBar1.Value = 50 Then
      '  ProgressBar1.Value = 1
      'End If
    End Sub
    Private Sub btnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    End Sub

#End Region

#Region "Overrides"
    Public Overrides ReadOnly Property TabPageText() As String
      Get
        Return Me.m_entity.ListPanelTitle
      End Get
    End Property
    Public Overloads Overrides Sub Save()
      'OnSaving(New EventArgs)
      'Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
      'Dim currentUserId As Integer = currentUserId
      'If SecurityService.CurrentUser Is Nothing Then
      '  msgServ.ShowMessage("${res:Global.Error.NoUser}")
      '  Me.OnSaved(New SaveEventArgs(False))
      '  SecurityService.UpdateAccessTable()
      '  WorkbenchSingleton.Workbench.RedrawEditComponents()
      '  Return
      'End If
      'currentUserId = SecurityService.CurrentUser.Id

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

      'Dim errorMessage As String = Me.m_entity.Save(currentUserId).Message

      'ProgressBar1.Value = 50
      'Timer1.Enabled = False
      'If Not IsNumeric(errorMessage) AndAlso errorMessage.Length > 0 Then 'Todo
      '  msgServ.ShowMessage(errorMessage)
      '  Me.OnSaved(New SaveEventArgs(False))
      'Else
      '  msgServ.ShowMessage("${res:Global.Info.DataSaved}")
      '  'CType(Me, ISimpleListPanel).RefreshData("")
      '  Me.IsDirty = False
      '  Me.OnSaved(New SaveEventArgs(True))
      'End If

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
    Public ReadOnly Property FormValidator() As Components.PJMTextboxValidator Implements IValidatable.FormValidator
      Get
        Return Me.Validator
      End Get
    End Property
#End Region

#Region "IClipboardHandler Overrides"
#End Region

#Region "IKeyReceiver"
    Public Overrides Function ProcessKey(ByVal keyPressed As System.Windows.Forms.Keys) As Boolean
      'Try
      '  Select Case keyPressed
      '    Case Keys.Insert
      '      'ibtnBlank_Click(Nothing, Nothing)
      '      Return True
      '    Case Keys.Delete
      '      If Me.tgItem.Focused Then
      '        'ibtnDelRow_Click(Nothing, Nothing)
      '        Return True
      '      Else
      '        Return False
      '      End If
      '    Case Else
      '      Return False
      '  End Select
      'Catch ex As Exception
      '  Throw ex
      'End Try
    End Function
#End Region


    Private Sub btnReSave_Click(ByVal sender As Object, ByVal e As System.EventArgs)
      'Dim resaveStock As New ReSaveStock
      ''resaveStock.DateStart = txtDocDateStart.Text
      ''resaveStock.DateEnd = txtDocDateEnd.Text
      ''resaveStock.DateStart = Data.UpdateStatus.Value
      'resaveStock.save()
    End Sub

    Private Sub CellDoubleClick(ByVal sender As Object, ByVal e As Telerik.WinControls.UI.GridViewCellEventArgs)
      If Me.m_entity Is Nothing OrElse e.ColumnIndex = -1 Then
        Return
      End If

      Dim docId As Integer
      Dim docType As Integer

      'ห้ามตั้งชื่อ Column ใน Child Table เป็น DocId, DocType เด็ดขาดเพระยังเช็คไม่ได้ว่า Double click ใน Grid แม่หรือ Grid ลูก
      If TypeOf sender Is GridDataCellElement Then
        If CType(sender, GridDataCellElement).ViewTemplate.Caption.ToLower = "รายการอนุมัติ/แสดงความคิดเห็น" Then
          'docId = rGrid.MasterGridViewTemplate.ChildGridViewTemplates("Details").Rows(1).Cells(0).Value
          'docType = CType(sender, GridDataCellElement).ViewTemplate.Rows(0).Cells(0).Value
          Return
        ElseIf CType(sender, GridDataCellElement).ViewTemplate.Caption.ToLower = "master" Then
          docId = rGrid.Rows(e.RowIndex).Cells("DocId").Value
          docType = rGrid.Rows(e.RowIndex).Cells("DocType").Value
        End If
      End If

      If docId > 0 AndAlso docType > 0 Then
        Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
        Dim en As SimpleBusinessEntityBase = SimpleBusinessEntityBase.GetEntity(Longkong.Pojjaman.BusinessLogic.Entity.GetFullClassName(docType), docId)
        myEntityPanelService.OpenDetailPanel(en)
      End If
    End Sub

    Private Sub ButtonClick(ByVal sender As System.Object, ByVal e As System.EventArgs)
      Me.RefreshData(True)
    End Sub

    Private Sub ButtonApproveClick(ByVal sender As System.Object, ByVal e As System.EventArgs)
    
      If Me.m_entity.IsSelected(rGrid) Then
        Dim dlg As New MultiApprovalCommentForm(Me.m_entity)
        dlg.StartPosition = FormStartPosition.CenterParent
        'dlg.StartPosition = FormStartPosition.WindowsDefaultBounds
        Dim resoult As DialogResult
        resoult = dlg.ShowDialog()
        If resoult = DialogResult.OK Then
          Me.RefreshData(True)
        End If
      End If

    End Sub

    Private Sub ExpandAllRows(ByVal grid As RadGridView, ByVal expand As Boolean)
      grid.GridElement.BeginUpdate()
      For Each row As GridViewRowInfo In grid.Rows
        row.IsExpanded = expand
      Next
      grid.GridElement.EndUpdate()
    End Sub

    Private Sub rGridValueChanged(ByVal sender As Object, ByVal e As EventArgs)
      'If TypeOf Me.rGrid.ActiveEditor Is RadCheckBoxEditor Then
      '  'Console.WriteLine(Me.rGrid.CurrentCell.RowIndex)
      '  'Console.WriteLine(Me.rGrid.ActiveEditor.Value)

      '  Dim docId As Integer
      '  Dim docType As Integer
      '  docId = rGrid.Rows(e.RowIndex).Cells("DocId").Value
      '  docType = rGrid.Rows(e.RowIndex).Cells("DocType").Value

      '  Me.m_entity.SetToggleSelection(Me.rGrid.ActiveEditor.Value, Me.rGrid.CurrentCell.RowIndex)
      'End If
    End Sub

    Private Sub rGrid_ChildViewExpanding(ByVal sender As Object, ByVal e As Telerik.WinControls.UI.ChildViewExpandingEventArgs) Handles rGrid.ChildViewExpanding
      'Dim docid As Integer = e.ParentRow.Cells("docid").Value
      'Dim doctype As Integer = e.ParentRow.Cells("doctype").Value

      'e.Cancel = False

      'If Not Me.m_entity.GetApproveDoc(docid, doctype) Then
      '  e.Cancel = True
      'End If

    End Sub

  End Class
End Namespace