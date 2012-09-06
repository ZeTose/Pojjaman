Imports Longkong.Pojjaman.Services
Imports Longkong.Core.Services
Imports Longkong.Pojjaman.PanelDisplayBinding
Imports Longkong.Pojjaman.Gui
Imports Longkong.Pojjaman.Gui.Dialogs
Imports Longkong.Pojjaman.Gui.Pads
Imports Longkong.Pojjaman.Gui.Components
Imports Longkong.Pojjaman.BusinessLogic
Imports Longkong.Pojjaman.DataAccessLayer
Imports Longkong.Pojjaman.Gui.ReportsAndDocs
Imports Longkong.Core.Properties
Imports System.IO
Imports Longkong.AdobeForm
Imports System.Reflection
Imports System.Collections.Generic

Namespace Longkong.Pojjaman.Gui.Panels
  Public Class ListViewItemSelectionPanelView
    'Inherits UserControl
    Inherits AbstractEntityPanelViewContent
    Implements ISimpleListPanel, ICanMove, IPrintableEntity, INewPrintable, INewPrintableEntity

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
    Friend WithEvents pnlFilter As System.Windows.Forms.Panel
    Friend WithEvents lvItem As Longkong.Pojjaman.Gui.Components.PJMListView
    Friend WithEvents pnlFilter2 As System.Windows.Forms.Panel
    Friend WithEvents pnlFilter3 As System.Windows.Forms.Panel
    Friend WithEvents Splitter1 As System.Windows.Forms.Splitter
    Friend WithEvents Splitter2 As System.Windows.Forms.Splitter
    Friend WithEvents ibtnAll As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents ibtnNone As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents ibtnSelectTop As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents txtSelectTop As System.Windows.Forms.TextBox
    Friend WithEvents lblSelectTop As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents chkHilightApproveStatus As System.Windows.Forms.CheckBox
    Friend WithEvents btnShowColorStatus As System.Windows.Forms.Button
    Friend WithEvents btnShowApproveColorStatus As System.Windows.Forms.Button
    Friend WithEvents chkHilightStatus As System.Windows.Forms.CheckBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ListViewItemSelectionPanelView))
      Me.pnlFilter = New System.Windows.Forms.Panel()
      Me.btnShowApproveColorStatus = New System.Windows.Forms.Button()
      Me.btnShowColorStatus = New System.Windows.Forms.Button()
      Me.chkHilightApproveStatus = New System.Windows.Forms.CheckBox()
      Me.chkHilightStatus = New System.Windows.Forms.CheckBox()
      Me.pnlFilter2 = New System.Windows.Forms.Panel()
      Me.Splitter2 = New System.Windows.Forms.Splitter()
      Me.lvItem = New Longkong.Pojjaman.Gui.Components.PJMListView()
      Me.pnlFilter3 = New System.Windows.Forms.Panel()
      Me.lblSelectTop = New System.Windows.Forms.Label()
      Me.txtSelectTop = New System.Windows.Forms.TextBox()
      Me.ibtnAll = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.ibtnNone = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.ibtnSelectTop = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.Label2 = New System.Windows.Forms.Label()
      Me.Splitter1 = New System.Windows.Forms.Splitter()
      Me.pnlFilter.SuspendLayout()
      Me.pnlFilter2.SuspendLayout()
      Me.pnlFilter3.SuspendLayout()
      Me.SuspendLayout()
      '
      'pnlFilter
      '
      Me.pnlFilter.Controls.Add(Me.btnShowApproveColorStatus)
      Me.pnlFilter.Controls.Add(Me.btnShowColorStatus)
      Me.pnlFilter.Controls.Add(Me.chkHilightApproveStatus)
      Me.pnlFilter.Controls.Add(Me.chkHilightStatus)
      Me.pnlFilter.Dock = System.Windows.Forms.DockStyle.Top
      Me.pnlFilter.Location = New System.Drawing.Point(0, 0)
      Me.pnlFilter.Name = "pnlFilter"
      Me.pnlFilter.Size = New System.Drawing.Size(900, 120)
      Me.pnlFilter.TabIndex = 0
      '
      'btnShowApproveColorStatus
      '
      Me.btnShowApproveColorStatus.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.btnShowApproveColorStatus.FlatStyle = System.Windows.Forms.FlatStyle.Popup
      Me.btnShowApproveColorStatus.Location = New System.Drawing.Point(774, 98)
      Me.btnShowApproveColorStatus.Name = "btnShowApproveColorStatus"
      Me.btnShowApproveColorStatus.Size = New System.Drawing.Size(13, 13)
      Me.btnShowApproveColorStatus.TabIndex = 1
      Me.btnShowApproveColorStatus.UseVisualStyleBackColor = True
      '
      'btnShowColorStatus
      '
      Me.btnShowColorStatus.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.btnShowColorStatus.FlatStyle = System.Windows.Forms.FlatStyle.Popup
      Me.btnShowColorStatus.Location = New System.Drawing.Point(659, 98)
      Me.btnShowColorStatus.Name = "btnShowColorStatus"
      Me.btnShowColorStatus.Size = New System.Drawing.Size(13, 13)
      Me.btnShowColorStatus.TabIndex = 1
      Me.btnShowColorStatus.UseVisualStyleBackColor = True
      '
      'chkHilightApproveStatus
      '
      Me.chkHilightApproveStatus.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.chkHilightApproveStatus.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.chkHilightApproveStatus.Location = New System.Drawing.Point(790, 93)
      Me.chkHilightApproveStatus.Name = "chkHilightApproveStatus"
      Me.chkHilightApproveStatus.Size = New System.Drawing.Size(107, 24)
      Me.chkHilightApproveStatus.TabIndex = 0
      Me.chkHilightApproveStatus.Text = "Hilight"
      '
      'chkHilightStatus
      '
      Me.chkHilightStatus.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.chkHilightStatus.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.chkHilightStatus.Location = New System.Drawing.Point(676, 93)
      Me.chkHilightStatus.Name = "chkHilightStatus"
      Me.chkHilightStatus.Size = New System.Drawing.Size(96, 24)
      Me.chkHilightStatus.TabIndex = 0
      Me.chkHilightStatus.Text = "Hilight"
      '
      'pnlFilter2
      '
      Me.pnlFilter2.Controls.Add(Me.Splitter2)
      Me.pnlFilter2.Controls.Add(Me.lvItem)
      Me.pnlFilter2.Controls.Add(Me.pnlFilter3)
      Me.pnlFilter2.Dock = System.Windows.Forms.DockStyle.Fill
      Me.pnlFilter2.Location = New System.Drawing.Point(0, 120)
      Me.pnlFilter2.Name = "pnlFilter2"
      Me.pnlFilter2.Size = New System.Drawing.Size(900, 480)
      Me.pnlFilter2.TabIndex = 2
      '
      'Splitter2
      '
      Me.Splitter2.BackColor = System.Drawing.SystemColors.InactiveCaption
      Me.Splitter2.Dock = System.Windows.Forms.DockStyle.Top
      Me.Splitter2.Location = New System.Drawing.Point(0, 32)
      Me.Splitter2.MinExtra = 5
      Me.Splitter2.MinSize = 5
      Me.Splitter2.Name = "Splitter2"
      Me.Splitter2.Size = New System.Drawing.Size(900, 1)
      Me.Splitter2.TabIndex = 8
      Me.Splitter2.TabStop = False
      '
      'lvItem
      '
      Me.lvItem.AllowSort = True
      Me.lvItem.CheckBoxes = True
      Me.lvItem.Dock = System.Windows.Forms.DockStyle.Fill
      Me.lvItem.FullRowSelect = True
      Me.lvItem.GridLines = True
      Me.lvItem.HideSelection = False
      Me.lvItem.Location = New System.Drawing.Point(0, 32)
      Me.lvItem.MultiSelect = False
      Me.lvItem.Name = "lvItem"
      Me.lvItem.Size = New System.Drawing.Size(900, 448)
      Me.lvItem.SortIndex = -1
      Me.lvItem.SortOrder = System.Windows.Forms.SortOrder.None
      Me.lvItem.TabIndex = 3
      Me.lvItem.UseCompatibleStateImageBehavior = False
      Me.lvItem.View = System.Windows.Forms.View.Details
      '
      'pnlFilter3
      '
      Me.pnlFilter3.BackColor = System.Drawing.SystemColors.Control
      Me.pnlFilter3.Controls.Add(Me.lblSelectTop)
      Me.pnlFilter3.Controls.Add(Me.txtSelectTop)
      Me.pnlFilter3.Controls.Add(Me.ibtnAll)
      Me.pnlFilter3.Controls.Add(Me.ibtnNone)
      Me.pnlFilter3.Controls.Add(Me.ibtnSelectTop)
      Me.pnlFilter3.Controls.Add(Me.Label2)
      Me.pnlFilter3.Dock = System.Windows.Forms.DockStyle.Top
      Me.pnlFilter3.Location = New System.Drawing.Point(0, 0)
      Me.pnlFilter3.Name = "pnlFilter3"
      Me.pnlFilter3.Size = New System.Drawing.Size(900, 32)
      Me.pnlFilter3.TabIndex = 7
      '
      'lblSelectTop
      '
      Me.lblSelectTop.Location = New System.Drawing.Point(312, 4)
      Me.lblSelectTop.Name = "lblSelectTop"
      Me.lblSelectTop.Size = New System.Drawing.Size(80, 23)
      Me.lblSelectTop.TabIndex = 223
      Me.lblSelectTop.Text = "Select Top:"
      Me.lblSelectTop.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'txtSelectTop
      '
      Me.txtSelectTop.Location = New System.Drawing.Point(392, 5)
      Me.txtSelectTop.Name = "txtSelectTop"
      Me.txtSelectTop.Size = New System.Drawing.Size(100, 21)
      Me.txtSelectTop.TabIndex = 222
      '
      'ibtnAll
      '
      Me.ibtnAll.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.ibtnAll.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
      Me.ibtnAll.Location = New System.Drawing.Point(24, 3)
      Me.ibtnAll.Name = "ibtnAll"
      Me.ibtnAll.Size = New System.Drawing.Size(120, 24)
      Me.ibtnAll.TabIndex = 221
      Me.ibtnAll.TabStop = False
      Me.ibtnAll.Text = "เลือกทั้งหมด"
      Me.ibtnAll.ThemedImage = CType(resources.GetObject("ibtnAll.ThemedImage"), System.Drawing.Bitmap)
      '
      'ibtnNone
      '
      Me.ibtnNone.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.ibtnNone.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
      Me.ibtnNone.Location = New System.Drawing.Point(160, 3)
      Me.ibtnNone.Name = "ibtnNone"
      Me.ibtnNone.Size = New System.Drawing.Size(120, 24)
      Me.ibtnNone.TabIndex = 221
      Me.ibtnNone.TabStop = False
      Me.ibtnNone.Text = "ไม่เลือกทั้งหมด"
      Me.ibtnNone.ThemedImage = CType(resources.GetObject("ibtnNone.ThemedImage"), System.Drawing.Bitmap)
      '
      'ibtnSelectTop
      '
      Me.ibtnSelectTop.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.ibtnSelectTop.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
      Me.ibtnSelectTop.Location = New System.Drawing.Point(496, 3)
      Me.ibtnSelectTop.Name = "ibtnSelectTop"
      Me.ibtnSelectTop.Size = New System.Drawing.Size(72, 24)
      Me.ibtnSelectTop.TabIndex = 221
      Me.ibtnSelectTop.TabStop = False
      Me.ibtnSelectTop.Text = "Go!"
      Me.ibtnSelectTop.ThemedImage = Nothing
      '
      'Label2
      '
      Me.Label2.Location = New System.Drawing.Point(320, 4)
      Me.Label2.Name = "Label2"
      Me.Label2.Size = New System.Drawing.Size(80, 23)
      Me.Label2.TabIndex = 223
      Me.Label2.Text = "Label1"
      '
      'Splitter1
      '
      Me.Splitter1.BackColor = System.Drawing.SystemColors.ActiveBorder
      Me.Splitter1.Dock = System.Windows.Forms.DockStyle.Top
      Me.Splitter1.Location = New System.Drawing.Point(0, 120)
      Me.Splitter1.MinExtra = 5
      Me.Splitter1.MinSize = 5
      Me.Splitter1.Name = "Splitter1"
      Me.Splitter1.Size = New System.Drawing.Size(900, 1)
      Me.Splitter1.TabIndex = 7
      Me.Splitter1.TabStop = False
      '
      'ListViewItemSelectionPanelView
      '
      Me.Controls.Add(Me.Splitter1)
      Me.Controls.Add(Me.pnlFilter2)
      Me.Controls.Add(Me.pnlFilter)
      Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Name = "ListViewItemSelectionPanelView"
      Me.Size = New System.Drawing.Size(900, 600)
      Me.pnlFilter.ResumeLayout(False)
      Me.pnlFilter2.ResumeLayout(False)
      Me.pnlFilter3.ResumeLayout(False)
      Me.pnlFilter3.PerformLayout()
      Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Members"
    Private m_filterSubPanel As IFilterSubPanel
    Private m_entity As ISimpleEntity
    Private m_selectedEntity As ISimpleEntity
    Private m_selectedID As Integer
    Private m_selectionMode As Selection

    Private m_basketItems As BasketItemCollection
    Private m_proposedBasketItems As BasketItemCollection
    Private m_oldBasket As BasketItemCollection

    Private m_otherFilters As Filter()
    Private m_imagelist As ImageList
#End Region

#Region "Constructors"
    Public Sub New(ByVal entity As ISimpleEntity, ByVal handler As Object, ByVal basket As BasketDialog, ByVal filters As Filter(), ByVal entities As ArrayList)
      MyBase.New()
      Dim mode As Selection = Selection.MultiSelect
      If TypeOf handler Is NamedEntityOperationDelegate Then
        mode = Selection.SingleSelect
      End If
      m_imagelist = New ImageList
      m_imagelist.Images.Add("Attachment", My.Resources.Attachment)
      Construct(entity, mode, basket, filters, entities)
    End Sub
    Private theBasket As BasketDialog
    Private theEntities As ArrayList
    Private Sub Construct(ByVal entity As ISimpleEntity, ByVal mode As Selection, ByVal basket As BasketDialog, ByVal filters As Filter(), ByVal entities As ArrayList)

      InitializeComponent()

      m_entity = entity

      Me.SetUpCheckHilight()

      'Filter อื่นที่ส่งมาด้วย
      m_otherFilters = filters
      m_selectionMode = mode

      theBasket = basket
      theEntities = entities

    End Sub
    Private Sub SetUpCheckHilight()
      If TypeOf m_entity Is IShowStatusColorAble Then
        If TypeOf m_entity Is IVisibleButtonShowColorListAble Then
          chkHilightStatus.Visible = False
          chkHilightApproveStatus.Visible = False
          btnShowColorStatus.Visible = False
          btnShowApproveColorStatus.Visible = False
        Else
          chkHilightStatus.Visible = True
          chkHilightApproveStatus.Visible = True
          chkHilightStatus.Checked = False
          chkHilightApproveStatus.Checked = False
          btnShowColorStatus.Visible = True
          btnShowApproveColorStatus.Visible = True
        End If
      Else
        chkHilightStatus.Visible = False
        chkHilightApproveStatus.Visible = False
        btnShowColorStatus.Visible = False
        btnShowApproveColorStatus.Visible = False
      End If
    End Sub
    Private Sub ListViewItemSelectionPanelView_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
      CreateColumn()

      m_basketItems = New BasketItemCollection
      m_proposedBasketItems = New BasketItemCollection
      m_oldBasket = New BasketItemCollection

      'Set Labels, Title
      Me.SetLabelText()
      If Not m_entity Is Nothing Then
        Me.TitleName = Me.StringParserService.Parse(m_entity.ListPanelTitle)
      End If
      Me.PanelName = Me.Name

      'Create the Filter Panel
      Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      If theEntities Is Nothing Then
        m_filterSubPanel = myEntityPanelService.GetFilterSubPanel(m_entity)
      Else
        m_filterSubPanel = myEntityPanelService.GetFilterSubPanel(m_entity, theEntities)
      End If
      Dim filterControl As UserControl = CType(Me.m_filterSubPanel, UserControl)
      Me.pnlFilter.Controls.Add(filterControl)
      Me.pnlFilter.Height = filterControl.Height
      AddHandler Me.m_filterSubPanel.SearchButton.Click, AddressOf btnSearch_Click

      Select Case m_selectionMode
        Case Selection.None, Selection.SingleSelect
          Me.lvItem.CheckBoxes = False
          Me.lvItem.StateImageList = m_imagelist
        Case Else
          Me.dlg = theBasket
          Me.lvItem.CheckBoxes = True
      End Select
      If Me.lvItem.CheckBoxes = True Then
        Me.ibtnAll.Visible = True
        Me.ibtnNone.Visible = True
      Else
        Me.ibtnAll.Visible = False
        Me.ibtnNone.Visible = False
        Me.pnlFilter3.Height = 0
      End If

      If Not TypeOf Me.m_entity Is LCIForList Then
        Me.RefreshData("")
      End If
    End Sub
#End Region

#Region "Properties"
    Public Enum Selection
      None
      MultiSelect
      SingleSelect
    End Enum
    Public ReadOnly Property SelectionMode() As Selection
      Get
        Return Me.m_selectionMode
      End Get
    End Property
    Public Property SelectedID() As Integer      Get        Return m_selectedID      End Get      Set(ByVal Value As Integer)        m_selectedID = Value      End Set    End Property
    Private m_forceRefresh As Boolean = False
    Public Property ForceRefreshEntity() As Boolean
      Get
        Return m_forceRefresh
      End Get
      Set(ByVal Value As Boolean)
        m_forceRefresh = Value
      End Set
    End Property
#End Region

#Region "Methods"
    Public Sub PrintDocumentList()
      Dim myPropertyService As PropertyService = CType(ServiceManager.Services.GetService(GetType(PropertyService)), PropertyService)
      'Dim FormPath As String = (myPropertyService.DataDirectory & Path.DirectorySeparatorChar & "forms" & Path.DirectorySeparatorChar & "Adobe" & Path.DirectorySeparatorChar & "documents")
      Dim thePath As String = ""
      Dim paths As FormPaths
      Dim nameForPath As String
      nameForPath = Entity.FullClassName & ".List"
      Dim myProperties As PropertyService = CType(ServiceManager.Services.GetService(GetType(PropertyService)), PropertyService)
      paths = CType(myProperties.GetProperty(nameForPath, New FormPaths(nameForPath, Entity.ClassName, thePath)), FormPaths)
      Dim dlg As New Longkong.Pojjaman.Gui.Dialogs.SelectFormsDialog(paths)
      If dlg.ShowDialog() = DialogResult.OK AndAlso Not dlg.KeyValuePair Is Nothing AndAlso Not dlg.KeyValuePair.Value Is Nothing Then
        thePath = dlg.KeyValuePair.Value
      Else
        Return
      End If
      If IO.File.Exists(thePath) Then
        Dim newReport As DevExpress.XtraReports.UI.XtraReport
        newReport = DevExpress.XtraReports.UI.XtraReport.FromFile(thePath, True)
        If Not EntitySimpleSchema.IsDefaultSchemaByDataSource(m_entity, newReport.DataSourceSchema) Then
          Dim idList As New List(Of Integer)
          Dim _id As Integer
          For Each item As ListViewItem In lvItem.Items
            _id = CInt(item.Tag)
            idList.Add(_id)
          Next
          Dim xtform As New XtraForm(m_entity, thePath, idList)
          xtform.ShowDialog()
        Else
          Dim entityList As New List(Of ISimpleEntity)
          Dim _id As Integer
          For Each item As ListViewItem In lvItem.Items
            _id = CInt(item.Tag)
            Dim entity As ISimpleEntity = SimpleBusinessEntityBase.GetEntity(Me.m_entity.FullClassName, _id)
            entityList.Add(entity)
          Next
          Dim xtform As New XtraForm(CType(entityList(0), INewPrintableEntity), thePath, entityList)
          xtform.ShowDialog()
        End If
      End If


      'Dim PrintingReportType As ReportExtentionType = ReportExtentionType.XMLReport
      'If Not Me.Entity Is Nothing Then
      '  If TypeOf Me.Entity Is IPrintableEntity Then
      '    Dim fileName As String = "GeneralList"
      '    thePath = FormPath & Path.DirectorySeparatorChar & fileName & ".xml"
      '    Dim paths As FormPaths
      '    Dim nameForPath As String
      '    nameForPath = Entity.FullClassName & ".List"
      '    Dim myProperties As PropertyService = CType(ServiceManager.Services.GetService(GetType(PropertyService)), PropertyService)
      '    paths = CType(myProperties.GetProperty(nameForPath, New FormPaths(nameForPath, Entity.ClassName, thePath)), FormPaths)
      '    Dim dlg As New Longkong.Pojjaman.Gui.Dialogs.SelectFormsDialog(paths)
      '    If dlg.ShowDialog() = DialogResult.OK AndAlso Not dlg.KeyValuePair Is Nothing AndAlso Not dlg.KeyValuePair.Value Is Nothing Then
      '      thePath = dlg.KeyValuePair.Value
      '    Else
      '      Return Nothing
      '    End If
      '    If thePath.EndsWith(".rpt") Then
      '      PrintingReportType = ReportExtentionType.CrystalReport
      '    ElseIf thePath.EndsWith(".repx") Then
      '      PrintingReportType = ReportExtentionType.XtraReport
      '    End If
      '    If File.Exists(thePath) Then
      '      '--Report form แบบใหม่--
      '      If PrintingReportType = ReportExtentionType.CrystalReport Then
      '        Dim idList As String = Me.GetEntityIdList
      '        Dim crform As New CrystalForm(Me.Entity, thePath, idList)
      '        crform.ShowDialog()
      '        Return Nothing
      '      ElseIf PrintingReportType = ReportExtentionType.XtraReport Then
      '        'Dim idList As String = Me.GetEntityIdList             
      '        Dim xtform As New XtraForm(Me, thePath, Me.Entity)
      '        xtform.ShowDialog()
      '        Return Nothing
      '      End If
      '      '--ส่วนด้านล่างเป็น form แบบเดิม--
      '      Dim df As New DesignerForm(thePath, Me.lvItem)
      '      Return df.PrintDocument
      '    End If
      '  End If
      'End If
    End Sub

    Public Sub ChangeTitle(ByVal sender As Object, ByVal e As EventArgs) Implements ISimpleListPanel.ChangeTitle
      If Me.WorkbenchWindow.ActiveViewContent Is Me Then
        Me.TitleName = Me.StringParserService.Parse(m_entity.ListPanelTitle)
        Return
      End If
      If Not m_selectedEntity Is Nothing Then
        Me.TitleName = m_selectedEntity.TabPageText
      End If
    End Sub
    Private Function GetColumnString(ByVal s As String) As String
      For Each col As BusinessLogic.Column In Me.m_entity.Columns
        If col.Name.ToLower.EndsWith(s.ToLower) Then
          Return col.Name
        End If
      Next
      'Return ""
      If Not Me.m_entity Is Nothing Then
        Return Me.m_entity.Prefix & s
      Else
        Return ""
      End If
    End Function
    Public Sub OnEntityPropertyChanged(ByVal sender As Object, ByVal e As EventArgs)
      RaiseEvent EntityPropertyChanged(sender, e)
    End Sub
    Private Sub CreateColumn()
      Dim secServ As SecurityService = CType(ServiceManager.Services.GetService(GetType(SecurityService)), SecurityService)
      Dim arr As New ArrayList
      For Each col As BusinessLogic.Column In m_entity.Columns
        Dim accessId As Integer = col.AccessId
        If accessId <> 0 Then
          Dim accessValue As Integer = secServ.GetAccess(accessId)
          If accessValue <= 0 Then
            arr.Add(col)
          End If
        End If
      Next
      For Each col As BusinessLogic.Column In arr
        m_entity.Columns.Remove(col)
      Next
      For Each col As BusinessLogic.Column In m_entity.Columns
        lvItem.Columns.Add(col.Alias, col.Width, col.Alignment)
      Next
    End Sub
    Private cancelHash As Hashtable
    Private refHash As Hashtable
    Private DicCloseRef As Dictionary(Of Decimal, ClosedRef)

    Private docStatusHs As Hashtable
    Private ApproveStatus As Hashtable

    Private Sub SearchData(ByVal order As String)
      Dim t As Date = Now
      lvItem.BeginUpdate()
      lvItem.Items.Clear()
      Dim comparer As IComparer = lvItem.ListViewItemSorter
      lvItem.ListViewItemSorter = Nothing
      'If m_selectionMode = Selection.None Then
      '  lvItem.StateImageList = m_imagelist
      'End If
      Dim filters As Filter() = Me.m_filterSubPanel.GetFilterArray
      Dim otherLength As Integer = 0
      If Not m_otherFilters Is Nothing AndAlso m_otherFilters.Length > 0 Then
        otherLength = m_otherFilters.Length
      End If
      Dim newfilters(filters.Length + otherLength - 1) As Filter
      For i As Integer = 0 To filters.Length - 1
        newfilters(i) = filters(i)
      Next
      If otherLength > 0 Then
        For i As Integer = 0 To otherLength - 1
          newfilters(i + filters.Length) = m_otherFilters(i)
        Next
      End If

      cancelHash = New Hashtable
      refHash = New Hashtable
      DicCloseRef = New Dictionary(Of Decimal, ClosedRef)

      docStatusHs = New Hashtable
      ApproveStatus = New Hashtable


      Dim dt As DataTable = m_entity.GetListDatatable(order, newfilters)

      Dim SumList As New Dictionary(Of BusinessLogic.Column, Decimal)
      For Each row As DataRow In dt.Rows
        Dim deh As New DataRowHelper(row)

        '================FIRST COLUMN=======================================
        Dim firstColumn As BusinessLogic.Column = m_entity.Columns(0)
        Dim firstColumnText As String = ""
        Select Case firstColumn.DataType.FullName.ToLower
          Case "system.datetime"
            Dim val As Nullable(Of Date) = deh.GetValue(Of Date)(firstColumn.Name)
            If val.HasValue Then
              If firstColumn.Format = 2 Then
                firstColumnText = val.Value.ToShortDateString
              Else
                firstColumnText = val.Value.ToShortDateString & ":" & val.Value.ToShortTimeString
              End If
            End If
          Case "system.decimal"
            Dim val As Decimal = deh.GetValue(Of Decimal)(firstColumn.Name, 0)
            firstColumnText = Configuration.FormatToString(val, firstColumn.Format)
          Case Else
            firstColumnText = deh.GetValue(Of String)(firstColumn.Name, "")
            firstColumnText = Me.StringParserService.Parse(firstColumnText)
        End Select
        Dim litem As ListViewItem = Me.lvItem.Items.Add(firstColumnText)
        If firstColumn.IsSum Then
          If Not SumList.ContainsKey(firstColumn) Then
            SumList(firstColumn) = 0
          End If
          SumList(firstColumn) += deh.GetValue(Of Decimal)(firstColumn.Name, 0)
        End If
        '================FIRST COLUMN=======================================
        '=== SET Attach Icon ==========='
        Select Case m_selectionMode
          Case Selection.None, Selection.SingleSelect
            If deh.GetValue(Of Boolean)("hasAttach") Then 'AndAlso m_selectionMode = Selection.None Then
              litem.StateImageIndex = 0
            Else
              litem.StateImageIndex = -1
            End If
          Case Else

        End Select
        '======= Attach ===== 
        litem.Tag = row(Me.m_entity.Prefix & "_id")
        docStatusHs(litem.Tag) = deh.GetValue(Of String)("docstatus")

        If row.Table.Columns.Contains(Me.m_entity.Prefix & "_status") AndAlso Not row.IsNull(Me.m_entity.Prefix & "_status") Then
          cancelHash(litem.Tag) = (CInt(row(Me.m_entity.Prefix & "_status")) = 0)
        Else
          cancelHash(litem.Tag) = False
        End If
        If row.Table.Columns.Contains(Me.m_entity.Prefix & "_isrefed") AndAlso Not row.IsNull(Me.m_entity.Prefix & "_isrefed") Then
          refHash(litem.Tag) = CBool(row(Me.m_entity.Prefix & "_isrefed"))
        Else
          refHash(litem.Tag) = False
        End If



        '===== Set Color สนใจ ปิด อ้างอิงบางส่วน
        If row.Table.Columns.Contains(Me.m_entity.Prefix & "_closedRef") Then
          If Not row.IsNull(Me.m_entity.Prefix & "_closedRef") Then
            DicCloseRef.Add(CDec(litem.Tag), New ClosedRef(CType(row(Me.m_entity.Prefix & "_closedRef"), CRef), CBool(refHash(litem.Tag))))
          Else
            DicCloseRef.Add(CDec(litem.Tag), New ClosedRef(CRef.NonRef, CBool(refHash(litem.Tag))))
          End If
        End If
        '===== Set Color สนใจ ปิด อ้างอิงบางส่วน


        For i As Integer = 1 To m_entity.Columns.Count - 1
          Dim otherColumn As BusinessLogic.Column = m_entity.Columns(i)
          Dim otherColumnText As String = ""
          Select Case otherColumn.DataType.FullName.ToLower
            Case "system.datetime"
              Dim val As Nullable(Of Date) = deh.GetValue(Of Date)(otherColumn.Name)
              If val.HasValue Then
                If otherColumn.Format = 2 Then
                  otherColumnText = val.Value.ToShortDateString
                Else
                  otherColumnText = val.Value.ToShortDateString & ":" & val.Value.ToShortTimeString
                End If
              End If
            Case "system.decimal"
              Dim val As Decimal = deh.GetValue(Of Decimal)(otherColumn.Name, 0)
              otherColumnText = Configuration.FormatToString(val, otherColumn.Format)
            Case Else
              otherColumnText = deh.GetValue(Of String)(otherColumn.Name, "")
              otherColumnText = Me.StringParserService.Parse(otherColumnText)
          End Select
          If otherColumn.IsSum Then
            If Not SumList.ContainsKey(otherColumn) Then
              SumList(otherColumn) = 0
            End If
            SumList(otherColumn) += deh.GetValue(Of Decimal)(otherColumn.Name, 0)
          End If
          litem.SubItems.Add(otherColumnText)
        Next
      Next

      Dim index As Integer = 0
      For Each col As BusinessLogic.Column In m_entity.Columns
        If SumList.ContainsKey(col) Then
          lvItem.Columns(index).Text = col.Alias & " [" & Configuration.FormatToString(SumList(col), col.Format) & "]"
        Else
          lvItem.Columns(index).Text = col.Alias
        End If
        index += 1
      Next

      lvItem.ListViewItemSorter = comparer
      If Not lvItem.ListViewItemSorter Is Nothing Then
        lvItem.Sort()
      End If
      lvItem.EndUpdate()
      SetStatusColor()
      'MessageBox.Show(dt.Rows.Count.ToString & " รายการ, ใช้เวลา: " & Now.Subtract(t).Seconds.ToString & " วินาที")
    End Sub
    Public Enum CRef As Integer
      Closed
      HalfRef
      FullRef
      NonRef
    End Enum
    Private Class ClosedRef

      Private m_cref As CRef
      Public ReadOnly Property ClosedRef As CRef
        Get
          Select Case m_cref
            Case CRef.NonRef
              If IsRef Then
                m_cref = CRef.HalfRef
              Else
                m_cref = CRef.NonRef
              End If
            Case CRef.HalfRef
              If IsRef Then
                m_cref = CRef.HalfRef
              Else
                m_cref = CRef.NonRef
              End If
            Case CRef.FullRef
              m_cref = CRef.FullRef
            Case CRef.Closed
              m_cref = CRef.Closed
          End Select
          Return m_cref
        End Get
      End Property
      Public Property IsRef As Boolean

      Public ReadOnly Property bgColor As Color
        Get
          Dim ret As Color
          Select Case ClosedRef
            Case CRef.Closed
              ret = Color.DarkBlue
            Case CRef.FullRef
              ret = Color.ForestGreen
            Case CRef.HalfRef
              ret = Color.GreenYellow
            Case CRef.NonRef
              ret = SystemColors.Window
          End Select
          Return ret
        End Get
      End Property

      Public ReadOnly Property fontColor As Color
        Get
          Dim ret As Color
          Select Case ClosedRef
            Case CRef.Closed
              ret = Color.White
            Case CRef.FullRef
              ret = SystemColors.ControlText
            Case CRef.HalfRef
              ret = SystemColors.ControlText
            Case CRef.NonRef
              ret = SystemColors.ControlText
          End Select
          Return ret
        End Get
      End Property

      Public Sub New(ByVal Cr As CRef, ByVal Ref As Boolean)
        m_cref = Cr
        IsRef = Ref
      End Sub


    End Class

    Private Sub SetApproveStatusColor()
      If chkHilightApproveStatus.Checked Then
        chkHilightStatus.Checked = False

        Dim currentUserId As Integer = Me.SecurityService.CurrentUser.Id

        For Each item As ListViewItem In Me.lvItem.Items

          Dim docStatusText() As String = docStatusHs(item.Tag).ToString.Split("/"c)
          Dim docStatusType As Integer = 0

          If CInt(docStatusText(4)) > 0 Then 'อนุมัติแล้ว(Approved) 
            'lvItem.SetColors(item, Color.GreenYellow, SystemColors.ControlText)
            'lvItem.SetColors(item, Color.FromArgb(255, 226, 255, 179), Color.Black)
            lvItem.SetColors(item, ConfigurationUser.GetColorConfiguration(currentUserId, "color.approve"), Color.Black)
            If CInt(docStatusText(5)) = 1 Then 'อนุมัติสูงสุดแล้ว(Authorized)
              'lvItem.SetColors(item, Color.Green, SystemColors.ControlText)
              'lvItem.SetColors(item, Color.FromArgb(255, 180, 254, 177), Color.Black)
              lvItem.SetColors(item, ConfigurationUser.GetColorConfiguration(currentUserId, "color.authorize"), Color.Black)
            End If
          Else 'ยังไม่อนุมัติ
            'lvItem.SetColors(item, Color.Ivory, SystemColors.ControlText)
            'lvItem.SetColors(item, Color.Ivory, Color.Black)
            lvItem.SetColors(item, ConfigurationUser.GetColorConfiguration(currentUserId, "color.normal"), Color.Black)
          End If
          If CInt(docStatusText(6)) > 0 Then 'ถูกส่องกลับ(Reject) 
            'lvItem.SetColors(item, Color.Gold, SystemColors.ControlText)
            lvItem.SetColors(item, ConfigurationUser.GetColorConfiguration(currentUserId, "color.reject"), Color.Black)
          End If

          'Select Case CInt(docStatusText(0))
          '  Case 0
          '    lvItem.SetColors(item, Color.Red, Color.White)
          '  Case 2 'บันทึก, ยังไม่ถูกอ้างอิง
          '    lvItem.SetColors(item, Color.Ivory, SystemColors.ControlText)
          '    docStatusType = 2
          '  Case 4 'ผ่านรายการแล้ว
          '    lvItem.SetColors(item, Color.FromArgb(255, 255, 128, 0), SystemColors.ControlText)
          'End Select
          ''If docStatusType = 2 Then
          ''  If CInt(docStatusText(1)) = 1 Then
          ''    Select Case CInt(docStatusText(2))
          ''      Case Is > 0 'ถูกอ้างอิงบางส่วน
          ''        lvItem.SetColors(item, Color.Violet, SystemColors.ControlText)
          ''      Case Else 'ถูกอ้างอิงแล้ว
          ''        lvItem.SetColors(item, Color.FromArgb(192, Color.Magenta), SystemColors.ControlText)
          ''    End Select
          ''  End If
          ''  If CInt(docStatusText(3)) = 1 Then
          ''    lvItem.SetColors(item, Color.Silver, Color.Black) 'ปิด
          ''  End If
          ''End If

        Next
      Else
        lvItem.PaintAlternatingBackColor(Color.White, Color.Khaki)
      End If
    End Sub

    Private Sub SetStatusColor()
      If chkHilightStatus.Checked Then
        chkHilightApproveStatus.Checked = False

        Dim currentUserId As Integer = Me.SecurityService.CurrentUser.Id

        For Each item As ListViewItem In Me.lvItem.Items

          Dim docStatusText() As String = docStatusHs(item.Tag).ToString.Split("/"c)
          Dim docStatusType As Integer = 0

          Select Case CInt(docStatusText(0))
            Case 0 'ยกเลิก
              'lvItem.SetColors(item, Color.Red, Color.White)
              'lvItem.SetColors(item, Color.FromArgb(255, 255, 176, 176), Color.Black)
              lvItem.SetColors(item, ConfigurationUser.GetColorConfiguration(currentUserId, "color.cancel"), Color.Black)
            Case 2 'บันทึก, ยังไม่ถูกอ้างอิง
              'lvItem.SetColors(item, Color.Ivory, SystemColors.ControlText)
              'lvItem.SetColors(item, Color.FromArgb(255, 0, 0, 0), Color.Black)
              lvItem.SetColors(item, ConfigurationUser.GetColorConfiguration(currentUserId, "color.normal"), Color.Black)
              docStatusType = 2
            Case 4 'ผ่านรายการแล้ว
              'lvItem.SetColors(item, Color.FromArgb(255, 255, 128, 0), SystemColors.ControlText)
              'lvItem.SetColors(item, Color.FromArgb(255, 255, 203, 145), Color.Black)
              lvItem.SetColors(item, ConfigurationUser.GetColorConfiguration(currentUserId, "color.glpass"), Color.Black)
          End Select
          If docStatusType = 2 Then
            If CInt(docStatusText(1)) = 1 Then
              Select Case CInt(docStatusText(2))
                Case Is > 0 'ถูกอ้างอิงบางส่วน
                  'lvItem.SetColors(item, Color.Violet, Color.WhiteSmoke)
                  'lvItem.SetColors(item, Color.FromArgb(255, 255, 204, 204), Color.Black)
                  lvItem.SetColors(item, ConfigurationUser.GetColorConfiguration(currentUserId, "color.somereference"), Color.Black)
                Case Else 'ถูกอ้างอิงแล้ว
                  'lvItem.SetColors(item, Color.FromArgb(255, Color.Magenta), Color.WhiteSmoke)
                  'lvItem.SetColors(item, Color.FromArgb(255, 253, 176, 255), Color.Black)
                  lvItem.SetColors(item, ConfigurationUser.GetColorConfiguration(currentUserId, "color.reference"), Color.Black)
              End Select
            End If
            If CInt(docStatusText(3)) = 1 Then
              'lvItem.SetColors(item, Color.Silver, Color.Black) 'ปิด
              'lvItem.SetColors(item, Color.FromArgb(255, 194, 194, 194), Color.Black) 'ปิด
              lvItem.SetColors(item, ConfigurationUser.GetColorConfiguration(currentUserId, "color.close"), Color.Black)
            End If
          End If

          'Dim isRefed As Boolean = False
          'Dim isCancelled As Boolean = False
          'Dim RefClosed As ClosedRef
          'Try
          '  isCancelled = CBool(cancelHash(item.Tag))
          '  isRefed = CBool(refHash(item.Tag))
          '  If DicCloseRef.ContainsKey(CDec(item.Tag)) Then
          '    RefClosed = DicCloseRef.Item(CDec(item.Tag))
          '  End If
          'Catch ex As Exception

          'End Try
          'If RefClosed IsNot Nothing Then
          '  lvItem.SetColors(item, RefClosed.bgColor, RefClosed.fontColor)
          '  'lvItem.SetColors(item, Configuration.GetColorConfiguration(DocumentColor.Cancel), Color.White)
          'ElseIf isRefed Then
          '  lvItem.SetColors(item, Color.ForestGreen, SystemColors.ControlText)
          'ElseIf isCancelled Then
          '  lvItem.SetColors(item, Color.Red, Color.White)
          '  'lvItem.SetColors(item, Configuration.GetColorConfiguration(DocumentColor.Cancel), Color.White)
          'Else
          '  lvItem.SetColors(item, SystemColors.Window, SystemColors.ControlText)
          'End If
        Next
      Else
        lvItem.PaintAlternatingBackColor(Color.White, Color.Khaki)
      End If
    End Sub
#End Region

#Region "Event Handlers"
    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
      Me.SearchData(GetColumnString("_code"))
    End Sub
    Private Sub lvItem_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvItem.SelectedIndexChanged
      'Application.DoEvents()
      If lvItem.SelectedItems.Count > 0 Then
        m_selectedID = CInt(lvItem.SelectedItems(0).Tag)
      End If
      'RefreshSelectedEntity()
      If Not Me.WorkbenchWindow Is Nothing Then
        RefreshEditableStatus()
      End If
    End Sub
    Private Sub RefreshEditableStatus()
      'WorkbenchSingleton.Workbench.RedrawAllComponents()
    End Sub
    Private Sub lvItem_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvItem.DoubleClick
      If Not Me.WorkbenchWindow Is Nothing Then
        If Not TypeOf Me.WorkbenchWindow.ActiveViewContent Is ISecondaryViewContent Then
          Me.WorkbenchWindow.SwitchView(1)
        End If
        Return
      End If
      If Not Me.SelectionMode = Selection.MultiSelect AndAlso Not Me.FindForm Is Nothing Then
        RefreshSelectedEntity() 'UNDONE********************
        Me.OnEntitySelected(Me.SelectedEntity)
        Me.FindForm.Close()
      End If
    End Sub
    Private Sub lvItem_SortChanged() Handles lvItem.SortChanged
      If m_entity Is Nothing Then
        Return
      End If
      lvItem.BeginUpdate()
      Dim indx As Integer = lvItem.SortIndex
      Dim sortOrder As SortOrder = lvItem.SortOrder
      Dim myType As Type = m_entity.Columns(indx).DataType
      If myType Is GetType(Date) Then
        lvItem.ListViewItemSorter = New ListViewHelper.CompareByDate(indx, sortOrder)
      ElseIf myType Is GetType(String) Then
        lvItem.ListViewItemSorter = New ListViewHelper.CompareByText(indx, sortOrder)
      Else
        lvItem.ListViewItemSorter = New ListViewHelper.CompareByNumber(indx, sortOrder)
      End If
      lvItem.Sort()
      lvItem.EndUpdate()
      SetStatusColor()
    End Sub
    Private Sub ibtnAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnAll.Click
      For Each item As ListViewItem In Me.lvItem.Items
        item.Checked = True
      Next
    End Sub
    Private Sub ibtnNone_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnNone.Click
      For Each item As ListViewItem In Me.lvItem.Items
        item.Checked = False
      Next
    End Sub
    Private Sub ibtnSelectTop_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnSelectTop.Click
      Dim count As Integer = 0
      If IsNumeric(Me.txtSelectTop.Text) Then
        count = CInt(Me.txtSelectTop.Text)
      End If
      If count <= 0 Then
        Return
      End If
      Dim i As Integer = 0
      For Each item As ListViewItem In Me.lvItem.Items
        i += 1
        If i <= count Then
          item.Checked = True
        Else
          item.Checked = False
        End If
      Next
    End Sub
#End Region

#Region "ISimpleListPanel"
    Public Event EntitySelected(ByVal e As ISimpleEntity) Implements ISimpleListPanel.EntitySelected
    Public Sub OnEntitySelected(ByVal e As ISimpleEntity)
      RaiseEvent EntitySelected(e)
    End Sub
    Public Event EntityPropertyChanged(ByVal sender As Object, ByVal e As System.EventArgs) Implements ISimpleEntityPanel.EntityPropertyChanged

    Public Sub CheckFormEnable() Implements ISimpleEntityPanel.CheckFormEnable

    End Sub
    Public Sub ClearDetail() Implements ISimpleEntityPanel.ClearDetail

    End Sub
    Public Property Entity() As BusinessLogic.ISimpleEntity Implements ISimpleEntityPanel.Entity
      Get
        Return Me.m_entity
      End Get
      Set(ByVal Value As ISimpleEntity)
        Me.m_entity = Value
      End Set
    End Property
    Public Sub Initialize() Implements ISimpleEntityPanel.Initialize

    End Sub
    Public Sub SetLabelText() Implements ISimpleEntityPanel.SetLabelText
      If Not m_entity Is Nothing Then
        Me.Text = Me.StringParserService.Parse(m_entity.ListPanelTitle)
      End If
      Me.ibtnAll.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ListViewItemSelectionPanelView.ibtnAll}")
      Me.ibtnNone.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ListViewItemSelectionPanelView.ibtnNone}")
      Me.chkHilightStatus.Text = "แสดงสีสถานะ" 'Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ListViewItemSelectionPanelView.chkHilightStatus}")
      Me.chkHilightApproveStatus.Text = "แสดงสีการอนุมัติ" 'Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ListViewItemSelectionPanelView.chkHilightApproveStatus}")
    End Sub
    Public Sub UpdateEntityProperties() Implements ISimpleEntityPanel.UpdateEntityProperties

    End Sub
    Private m_addingIHasConditionBeforeAdding As Boolean = False
    Private Sub CloseHandler(ByVal sender As Object, ByVal e As EventArgs)
      Dim dlg As Longkong.Pojjaman.Gui.Dialogs.PanelDialog = CType(sender, Longkong.Pojjaman.Gui.Dialogs.PanelDialog)
      Dim row As DataRow = CType(dlg.Control, IPreAddView).SelectedRow
      If dlg.DialogResult <> DialogResult.OK OrElse row Is Nothing Then
        Return
      End If
      m_addingIHasConditionBeforeAdding = True
      Dim newInstance As Object
      newInstance = SimpleBusinessEntityBase.GetEntity(Me.m_entity.FullClassName, row)
      If (newInstance Is Nothing) Then
        Debug.WriteLine("Type not found: " & Me.m_entity.FullClassName)
        Return
      End If
      m_selectedEntity = CType(newInstance, ISimpleEntity)
      If Not m_selectedEntity Is Nothing Then
        RemoveHandler m_selectedEntity.TabPageTextChanged, AddressOf Me.ChangeTitle
        AddHandler m_selectedEntity.TabPageTextChanged, AddressOf Me.ChangeTitle
        If TypeOf m_selectedEntity Is ICodeGeneratable Then
          CType(m_selectedEntity, ICodeGeneratable).AutoGen = BusinessLogic.Entity.GetAutoGenStatus(m_selectedEntity.ClassName)
        End If
      End If
      If TypeOf Me.WorkbenchWindow.ActiveViewContent Is ISecondaryViewContent Then
        For Each view As ISimpleEntityPanel In Me.WorkbenchWindow.SubViewContents
          If Not view Is Me Then
            'Performance
            view.Entity = Nothing
            'Performance
            view.Entity = m_selectedEntity
          End If
        Next
      End If
      If Not TypeOf Me.WorkbenchWindow.ActiveViewContent Is ISecondaryViewContent Then
        Me.WorkbenchWindow.SwitchView(1)
      End If
    End Sub
    Public Sub AddNew() Implements ISimpleListPanel.AddNew
      If Not Me.WorkbenchWindow.SubViewContents Is Nothing Then
        Dim svc As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
        Dim preAddView As UserControl = svc.GetPreAddViewForEntity(Me.m_entity)
        If Not preAddView Is Nothing Then
          Dim dlg As New Longkong.Pojjaman.Gui.Dialogs.PanelDialog(preAddView)
          AddHandler dlg.Closed, AddressOf Me.CloseHandler
          dlg.ShowDialog()
          Return
        Else
          m_selectedID = 0
          RefreshSelectedEntity()
        End If
        If Not m_selectedEntity Is Nothing Then
          RemoveHandler m_selectedEntity.TabPageTextChanged, AddressOf Me.ChangeTitle
          AddHandler m_selectedEntity.TabPageTextChanged, AddressOf Me.ChangeTitle
          If TypeOf m_selectedEntity Is ICodeGeneratable Then
            CType(m_selectedEntity, ICodeGeneratable).AutoGen = BusinessLogic.Entity.GetAutoGenStatus(m_selectedEntity.ClassName)
          End If
        End If
        If TypeOf Me.WorkbenchWindow.ActiveViewContent Is ISecondaryViewContent Then
          For Each view As ISimpleEntityPanel In Me.WorkbenchWindow.SubViewContents
            If Not view Is Me Then
              'Performance
              'view.Entity = Nothing
              'Performance
              view.Entity = m_selectedEntity
            End If
          Next
        End If
        If Not TypeOf Me.WorkbenchWindow.ActiveViewContent Is ISecondaryViewContent Then
          Me.WorkbenchWindow.SwitchView(1)
        End If
      End If
    End Sub
    Public Sub RefreshData(ByVal id As String) Implements ISimpleListPanel.RefreshData
      SearchData(GetColumnString("_code"))
      If Me.lvItem.Items.Count = 0 Then
        Return
      End If
      If id Is Nothing OrElse id.Length = 0 Then
        Me.lvItem.Items(0).Selected = True
        Return
      End If
      If Me.lvItem.MultiSelect = False Then
        Me.lvItem.SelectedItems.Clear()
      End If
      Dim item As ListViewItem = ListViewHelper.SearchTag(Me.lvItem, CInt(id))
      If Not item Is Nothing Then
        item.Selected = True
        item.EnsureVisible()
      End If
      Me.lvItem.Focus()
    End Sub
    Public Sub RefreshSelectedEntity()
      'If Not m_selectedEntity Is Nothing AndAlso m_selectedID <> 0 AndAlso m_selectedID = m_selectedEntity.Id Then
      '    Return
      'End If
      m_selectedEntity = Nothing
      If (lvItem.Items.Count = 0 AndAlso Not m_forceRefresh) OrElse m_selectedID = 0 Then
        m_selectedEntity = SimpleBusinessEntityBase.GetEntity(Me.m_entity.FullClassName)
      Else
        m_selectedEntity = SimpleBusinessEntityBase.GetEntity(Me.m_entity.FullClassName, m_selectedID)
      End If
      If Not Me.WorkbenchWindow Is Nothing Then
        If Not m_otherFilters Is Nothing Then
          For Each f As Filter In m_otherFilters
            Dim ty As Type = m_selectedEntity.GetType
            Dim pi As PropertyInfo = ty.GetProperty(f.Name)
            If Not pi Is Nothing Then
              pi.SetValue(m_selectedEntity, f.Value, Nothing)
            End If
            If Not String.IsNullOrEmpty(Me.ForceLabel) Then
              m_selectedEntity.MenuLabel = Me.ForceLabel
            End If
          Next
        End If
      End If
    End Sub
    Public Property SelectedEntity() As BusinessLogic.ISimpleEntity Implements ISimpleListPanel.SelectedEntity
      Get
        Return m_selectedEntity
      End Get
      Set(ByVal Value As BusinessLogic.ISimpleEntity)
        'If m_selectedEntity Is Nothing OrElse CType(m_selectedEntity, Object).Equals(Value) Then
        '    Return
        'End If
        Me.m_selectedEntity = Value
        If Not m_selectedEntity Is Nothing Then
          'เอาออก ให้ตอน save เร็วขึ้น
          'Me.RefreshData(m_selectedEntity.Id.ToString)
        End If
      End Set
    End Property
    Public ReadOnly Property Icon() As String Implements ISimplePanel.Icon
      Get
        Return Me.m_entity.ListPanelIcon
      End Get
    End Property
    Public Sub ShowInPad() Implements ISimplePanel.ShowInPad
      Return
    End Sub
    Public ReadOnly Property Title() As String Implements ISimplePanel.Title
      Get
        Return Me.m_entity.ListPanelTitle
      End Get
    End Property
#End Region

#Region "Overrides"

        Public Overrides ReadOnly Property TabPageText() As String
            Get
                Return "${res:Longkong.Pojjaman.Gui.Panels.ListViewItemSelectionPanelView.TabPageText}" '"รายการ"
            End Get
        End Property


        Public Overrides Sub Deselected()
            If Not Me.WorkbenchWindow.SubViewContents Is Nothing Then
                If Not m_addingIHasConditionBeforeAdding Then
                    RefreshSelectedEntity() 'UNDONE********************
                Else
                    m_addingIHasConditionBeforeAdding = False
                End If
                If Not m_selectedEntity Is Nothing Then
                    RemoveHandler m_selectedEntity.TabPageTextChanged, AddressOf Me.ChangeTitle
                    AddHandler m_selectedEntity.TabPageTextChanged, AddressOf Me.ChangeTitle
                End If
            End If
        End Sub

#End Region

#Region "IClipboardHandler"
    Public Overrides Sub Copy(ByVal sender As Object, ByVal e As System.EventArgs)
      Dim oldData As IDataObject = Clipboard.GetDataObject
      If oldData.GetDataPresent(Me.Entity.FullClassName) Then
        Dim id As Integer = CInt(oldData.GetData(Me.Entity.FullClassName))
      End If

      Dim newData As New DataObject
      newData.SetData(Me.Entity.FullClassName, Me.m_selectedID)
      Clipboard.SetDataObject(newData)
      Me.RefreshEditableStatus()
    End Sub
    Public Overrides ReadOnly Property EnableCopy() As Boolean
      Get
        If Me.m_selectedID <> 0 AndAlso Me.lvItem.SelectedItems.Count > 0 Then
          Return True
        End If
        Return False
      End Get
    End Property
    Public Overrides ReadOnly Property EnablePaste() As Boolean
      Get
        If Not Me.m_filterSubPanel Is Nothing Then
          Return Me.m_filterSubPanel.EnablePaste
        End If
      End Get
    End Property
    Public Overrides Sub Paste(ByVal sender As Object, ByVal e As System.EventArgs)
      If Not Me.m_filterSubPanel Is Nothing AndAlso Me.m_filterSubPanel.EnablePaste Then
        Me.m_filterSubPanel.Paste(sender, e)
      End If
    End Sub
#End Region

#Region "IBasketCollectable"
    Private dlg As BasketDialog
    Public Overrides ReadOnly Property BasketItems() As BusinessLogic.BasketItemCollection
      Get
        m_basketItems.Clear()
        Dim idList As String = ""
        For Each item As ListViewItem In Me.lvItem.CheckedItems
          Dim id As Integer = CInt(item.Tag)
          idList &= "|" & id.ToString & "|"
          ''Dim entity As ISimpleEntity = SimpleEntityFactory.CreateEntity(Me.m_entity.FullClassName, id)
          '     'Dim basketitem As New basketitem(id, entity.Code, entity.FullClassName, entity.Code)
          ''m_basketItems.Add(basketitem)
          If idList.Length > 3000 Then
            Dim filters(0) As Filter
            filters(0) = New Filter("IncludeIdList", idList)
            Dim dt As DataTable = m_entity.GetListDatatable("", filters)
            'For Each lvItem As ListViewItem In Me.lvItem.CheckedItems
            '	Dim rows As DataRow() = dt.Select(m_entity.Prefix & "_id=" & CStr(lvItem.Tag))
            '	If rows.Length > 0 Then
            '		Dim row As DataRow = dt.Select(m_entity.Prefix & "_id=" & CStr(lvItem.Tag))(0)
            '		Dim basketitem As New basketitem(CInt(row(m_entity.Prefix & "_id")), row(m_entity.Prefix & "_code").ToString, m_entity.FullClassName, row(m_entity.Prefix & "_code").ToString)
            '		basketitem.Tag = row
            '		m_basketItems.Add(basketitem)
            '	End If
            'Next
            For Each row As DataRow In dt.Rows
              Dim basketitem As New BasketItem(CInt(row(m_entity.Prefix & "_id")) _
              , row(m_entity.Prefix & "_code").ToString, m_entity.FullClassName _
              , row(m_entity.Prefix & "_code").ToString)
              basketitem.Tag = row
              m_basketItems.Add(basketitem)
            Next
            idList = ""
          End If
        Next

        If idList.Length > 0 Then
          Dim filters(0) As Filter
          filters(0) = New Filter("IncludeIdList", idList)
          Dim dt As DataTable = m_entity.GetListDatatable("", filters)
          'For Each item As ListViewItem In Me.lvItem.CheckedItems
          '	Dim rows As DataRow() = dt.Select(m_entity.Prefix & "_id=" & CStr(item.Tag))
          '	If rows.Length > 0 Then
          '		Dim row As DataRow = dt.Select(m_entity.Prefix & "_id=" & CStr(item.Tag))(0)
          '		Dim basketitem As New BasketItem(CInt(row(m_entity.Prefix & "_id")), row(m_entity.Prefix & "_code").ToString, m_entity.FullClassName, row(m_entity.Prefix & "_code").ToString)
          '		basketitem.Tag = row
          '		m_basketItems.Add(basketitem)
          '	End If
          'Next
          For Each row As DataRow In dt.Rows
            Dim basketitem As New BasketItem(CInt(row(m_entity.Prefix & "_id")) _
            , row(m_entity.Prefix & "_code").ToString, m_entity.FullClassName _
            , row(m_entity.Prefix & "_code").ToString)
            basketitem.Tag = row
            m_basketItems.Add(basketitem)
          Next
        End If

        Return m_basketItems
      End Get
    End Property
    Public Overrides ReadOnly Property ProposedBasketItems() As BusinessLogic.BasketItemCollection
      Get
        Return m_proposedBasketItems
      End Get
    End Property
#End Region

#Region "IKeyReceiver"
    Public Overrides Function ProcessKey(ByVal keyPressed As System.Windows.Forms.Keys) As Boolean
      Select Case keyPressed
        Case Keys.Insert
          Me.AddNew()
          Return True
        Case Else
          Return False
      End Select
    End Function
#End Region

#Region "IPrintable"
    Public Overrides ReadOnly Property CanPrint() As Boolean
      Get
        Return Me.lvItem.Items.Count > 0
      End Get
    End Property
    Private Enum ReportExtentionType
      CrystalReport
      XtraReport
      XMLReport
    End Enum
    Public Overrides ReadOnly Property PrintDocument() As System.Drawing.Printing.PrintDocument
      Get
        Dim myPropertyService As PropertyService = CType(ServiceManager.Services.GetService(GetType(PropertyService)), PropertyService)
        Dim FormPath As String = (myPropertyService.DataDirectory & Path.DirectorySeparatorChar & "forms" & Path.DirectorySeparatorChar & "Adobe" & Path.DirectorySeparatorChar & "documents")
        Dim thePath As String = ""
        Dim PrintingReportType As ReportExtentionType = ReportExtentionType.XMLReport
        If Not Me.Entity Is Nothing Then
          If TypeOf Me.Entity Is IPrintableEntity Then
            Dim fileName As String = "GeneralList"
            thePath = FormPath & Path.DirectorySeparatorChar & fileName & ".xml"
            Dim paths As FormPaths
            Dim nameForPath As String
            nameForPath = Entity.FullClassName & ".List"
            Dim myProperties As PropertyService = CType(ServiceManager.Services.GetService(GetType(PropertyService)), PropertyService)
            paths = CType(myProperties.GetProperty(nameForPath, New FormPaths(nameForPath, Entity.ClassName, thePath)), FormPaths)
            Dim dlg As New Longkong.Pojjaman.Gui.Dialogs.SelectFormsDialog(paths)
            If dlg.ShowDialog() = DialogResult.OK AndAlso Not dlg.KeyValuePair Is Nothing AndAlso Not dlg.KeyValuePair.Value Is Nothing Then
              thePath = dlg.KeyValuePair.Value
            Else
              Return Nothing
            End If
            If thePath.EndsWith(".rpt") Then
              PrintingReportType = ReportExtentionType.CrystalReport
            ElseIf thePath.EndsWith(".repx") Then
              PrintingReportType = ReportExtentionType.XtraReport
            End If
            If File.Exists(thePath) Then
              '--Report form แบบใหม่--
              If PrintingReportType = ReportExtentionType.CrystalReport Then
                Dim idList As String = Me.GetEntityIdList
                Dim crform As New CrystalForm(Me.Entity, thePath, idList)
                crform.ShowDialog()
                Return Nothing
              ElseIf PrintingReportType = ReportExtentionType.XtraReport Then
                'Dim idList As String = Me.GetEntityIdList             
                Dim xtform As New XtraForm(Me, thePath, Me.Entity)
                xtform.ShowDialog()
                Return Nothing
              End If
              '--ส่วนด้านล่างเป็น form แบบเดิม--
              Dim df As New DesignerForm(thePath, Me.lvItem)
              Return df.PrintDocument
            End If
          End If
        End If
      End Get
    End Property
    Private Function GetEntityIdList() As String
      Dim idList As New ArrayList
      Dim idStringList As String = ""
      For Each litem As ListViewItem In Me.lvItem.Items
        idList.Add(CInt(litem.Tag))
      Next

      If idList.Count > 0 Then
        idStringList = String.Join(",", idList.ToArray)
      End If

      Return idStringList
    End Function
#End Region

    Private Sub chkHilight_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkHilightStatus.CheckedChanged
      SetStatusColor()
      'chkHilightApproveStatus.Checked = False
    End Sub
    Private Sub chkHilightApproveStatus_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkHilightApproveStatus.CheckedChanged
      SetApproveStatusColor()
      'chkHilightStatus.Checked = False
    End Sub
#Region "ICanMove"
    Public ReadOnly Property CanMoveNext As Boolean Implements ICanMove.CanMoveNext
      Get
        Dim itemCount As Integer = Me.lvItem.Items.Count
        If itemCount > 0 Then
          'มี Item
          If Me.lvItem.SelectedItems.Count = 0 Then
            'ไม่ได้เลือกอะไรเลย
            Return True
          End If
          If Me.lvItem.SelectedIndices(0) < itemCount - 1 Then
            'ยังไปต่อได้
            Return True
          End If
        End If
        Return False
      End Get
    End Property
    Public ReadOnly Property CanMovePrevious As Boolean Implements ICanMove.CanMovePrevious
      Get
        Dim itemCount As Integer = Me.lvItem.Items.Count
        If itemCount > 0 Then
          'มี Item
          If Me.lvItem.SelectedItems.Count = 0 Then
            'ไม่ได้เลือกอะไรเลย
            Return True
          End If
          If Me.lvItem.SelectedIndices(0) > 0 Then
            'ยังไปต่อได้
            Return True
          End If
        End If
        Return False
      End Get
    End Property
    Public Sub MoveNext() Implements ICanMove.MoveNext
      Dim selectedIndex As Integer = Me.lvItem.SelectedIndices(0)
      Me.lvItem.Items(selectedIndex + 1).Selected = True
      RefreshSelectedEntity() 'UNDONE********************
      If Not m_selectedEntity Is Nothing Then
        RemoveHandler m_selectedEntity.TabPageTextChanged, AddressOf Me.ChangeTitle
        AddHandler m_selectedEntity.TabPageTextChanged, AddressOf Me.ChangeTitle
      End If

      For i As Integer = 1 To Me.WorkbenchWindow.SubViewContents.Count - 1
        If TypeOf Me.WorkbenchWindow.SubViewContents(i) Is AbstractEntityDetailPanelView Then
          Dim myView As AbstractEntityDetailPanelView = CType(Me.WorkbenchWindow.SubViewContents(i), AbstractEntityDetailPanelView)
          myView.InitProgress()
          myView.Entity = SelectedEntity
          myView.EndProgress()
        End If
      Next
    End Sub
    Public Sub MovePrevious() Implements ICanMove.MovePrevious
      Dim selectedIndex As Integer = Me.lvItem.SelectedIndices(0)
      Me.lvItem.Items(selectedIndex - 1).Selected = True
      RefreshSelectedEntity() 'UNDONE********************
      If Not m_selectedEntity Is Nothing Then
        RemoveHandler m_selectedEntity.TabPageTextChanged, AddressOf Me.ChangeTitle
        AddHandler m_selectedEntity.TabPageTextChanged, AddressOf Me.ChangeTitle
      End If

      For i As Integer = 1 To Me.WorkbenchWindow.SubViewContents.Count - 1
        If TypeOf Me.WorkbenchWindow.SubViewContents(i) Is AbstractEntityDetailPanelView Then
          Dim myView As AbstractEntityDetailPanelView = CType(Me.WorkbenchWindow.SubViewContents(i), AbstractEntityDetailPanelView)
          myView.InitProgress()
          myView.Entity = SelectedEntity
          myView.EndProgress()
        End If
      Next
    End Sub
#End Region

    Public Function GetDPICollFromListview() As DocPrintingItemCollection
      Dim dpiColl As New DocPrintingItemCollection
      Dim i As Integer = 0
      Dim dpi As New DocPrintingItem
      For Each item As ListViewItem In lvItem.Items
        i += 1
        For Each col As ColumnHeader In lvItem.Columns
          dpi = New DocPrintingItem
          dpi.Mapping = "Item.RelationId"
          dpi.Value = 1
          dpi.Row = i
          dpi.Table = "Item"
          dpi.DataType = "System.String"
          dpiColl.Add(dpi)

          Dim data As String = item.SubItems(col.Index).Text
          dpi = New DocPrintingItem
          dpi.Mapping = "Item.Col" & col.Index.ToString 'col.Text
          dpi.Value = data
          dpi.Row = i
          dpi.Table = "Item"
          dpi.DataType = "System.String"
          dpiColl.Add(dpi)
        Next
      Next

      Return dpiColl
    End Function

#Region "IPrintableEntity"
    Public Property Code() As String Implements BusinessLogic.IIdentifiable.Code
      Get

      End Get
      Set(ByVal Value As String)

      End Set
    End Property

    Public Property Id() As Integer Implements BusinessLogic.IIdentifiable.Id
      Get

      End Get
      Set(ByVal Value As Integer)

      End Set
    End Property

    Public Function GetDefaultForm() As String Implements BusinessLogic.IPrintableEntity.GetDefaultForm

    End Function

    Public Function GetDefaultFormPath() As String Implements BusinessLogic.IPrintableEntity.GetDefaultFormPath

    End Function

    Public Function GetDocPrintingEntries() As BusinessLogic.DocPrintingItemCollection Implements BusinessLogic.IPrintableEntity.GetDocPrintingEntries
      Dim dpiColl As New DocPrintingItemCollection
      Dim dpi As DocPrintingItem

      Dim newDpiColl As DocPrintingItemCollection = GetDPICollFromListview()
      If Not newDpiColl Is Nothing Then
        dpiColl.AddRange(newDpiColl)
      End If

      dpi = New DocPrintingItem
      dpi.Mapping = "RelationId"
      dpi.Value = 1
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      If TypeOf m_filterSubPanel Is IHasPrintItem Then
        dpiColl.AddRange(CType(m_filterSubPanel, IHasPrintItem).GetDocPrintingEntries)
      End If

      Return dpiColl
    End Function
#End Region

#Region "INewPrintableEntity"
    Public Function GetDocPrintingCollumnsEntries() As DocPrintingItemCollection Implements INewPrintableEntity.GetDocPrintingColumnsEntries
      Dim dpiColl As New DocPrintingItemCollection
      Dim dpi As DocPrintingItem

      For Each col As ColumnHeader In lvItem.Columns
        dpi = New DocPrintingItem
        dpi.Mapping = "Item.RelationId"
        dpi.Value = 1
        dpi.Row = 1
        dpi.Table = "Item"
        dpi.DataType = "System.String"
        dpiColl.Add(dpi)

        dpi = New DocPrintingItem
        dpi.Mapping = "Item.Col" & col.Index.ToString 'col.Text
        dpi.Value = ""
        dpi.Row = 1
        dpi.Table = "Item"
        dpi.DataType = "System.String"
        dpiColl.Add(dpi)
      Next

      dpi = New DocPrintingItem
      dpi.Mapping = "RelationId"
      dpi.Value = 1
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      If TypeOf m_filterSubPanel Is IHasPrintItem Then
        dpiColl.AddRange(CType(m_filterSubPanel, IHasPrintItem).GetDocPrintingEntries)
      End If

      dpiColl.RelationList.Add("general>RelationId>Item>Item.RelationId")

      Return dpiColl
    End Function
    Public Function GetDocPrintingDataEntries() As DocPrintingItemCollection Implements INewPrintableEntity.GetDocPrintingDataEntries
      Return Me.GetDocPrintingEntries
    End Function
#End Region

#Region "InewPrintable"
    Public Sub ShowSelectSchemaDataDialog() Implements INewPrintable.ShowSelectSchemaDataDialog
      If Not Me.Entity Is Nothing Then
        If TypeOf Me.Entity Is ISimpleEntity Then
          'Dim exdata As EntitySimpleSchema = CType(Me.Entity, INewPrintable).SimpleSchema
          'If Not exdata Is Nothing AndAlso Not exdata.DataSet Is Nothing Then
          If TypeOf Me.m_entity Is SimpleBusinessEntityBase Then
            CType(Me.m_entity, SimpleBusinessEntityBase).NewPrintableEntities = Me
          End If
          Dim dialog As New SchemaDataExportDialog(Me, Me.Entity)
          dialog.StartPosition = FormStartPosition.CenterParent
          dialog.ShowDialog()
          'End If
        End If
      End If
    End Sub
#End Region


    Private Sub btnShowColorStatus_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnShowColorStatus.Click, btnShowApproveColorStatus.Click
      Dim currentUserId As Integer = Me.SecurityService.CurrentUser.Id
      Dim colortype As Integer = 0
      If CType(sender, Button).Name = btnShowApproveColorStatus.Name Then
        colortype = 1
      End If

      Dim x As Form

      x = New ShowListViewColorForm(colortype, currentUserId, CType(sender, Button))

      x.ShowDialog()
    End Sub

  End Class
End Namespace

