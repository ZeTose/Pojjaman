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
    Inherits AbstractEntityPanelViewContent
        Implements ISimpleListPanel, ICanMove, IPrintableEntity

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
    Friend WithEvents chkHilight As System.Windows.Forms.CheckBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
      Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(ListViewItemSelectionPanelView))
      Me.pnlFilter = New System.Windows.Forms.Panel
      Me.pnlFilter2 = New System.Windows.Forms.Panel
      Me.Splitter2 = New System.Windows.Forms.Splitter
      Me.lvItem = New Longkong.Pojjaman.Gui.Components.PJMListView
      Me.pnlFilter3 = New System.Windows.Forms.Panel
      Me.lblSelectTop = New System.Windows.Forms.Label
      Me.txtSelectTop = New System.Windows.Forms.TextBox
      Me.ibtnAll = New Longkong.Pojjaman.Gui.Components.ImageButton
      Me.ibtnNone = New Longkong.Pojjaman.Gui.Components.ImageButton
      Me.ibtnSelectTop = New Longkong.Pojjaman.Gui.Components.ImageButton
      Me.Label2 = New System.Windows.Forms.Label
      Me.Splitter1 = New System.Windows.Forms.Splitter
      Me.chkHilight = New System.Windows.Forms.CheckBox
      Me.pnlFilter.SuspendLayout()
      Me.pnlFilter2.SuspendLayout()
      Me.pnlFilter3.SuspendLayout()
      Me.SuspendLayout()
      '
      'pnlFilter
      '
      Me.pnlFilter.Controls.Add(Me.chkHilight)
      Me.pnlFilter.Dock = System.Windows.Forms.DockStyle.Top
      Me.pnlFilter.Location = New System.Drawing.Point(0, 0)
      Me.pnlFilter.Name = "pnlFilter"
      Me.pnlFilter.Size = New System.Drawing.Size(800, 120)
      Me.pnlFilter.TabIndex = 0
      '
      'pnlFilter2
      '
      Me.pnlFilter2.Controls.Add(Me.Splitter2)
      Me.pnlFilter2.Controls.Add(Me.lvItem)
      Me.pnlFilter2.Controls.Add(Me.pnlFilter3)
      Me.pnlFilter2.Dock = System.Windows.Forms.DockStyle.Fill
      Me.pnlFilter2.Location = New System.Drawing.Point(0, 120)
      Me.pnlFilter2.Name = "pnlFilter2"
      Me.pnlFilter2.Size = New System.Drawing.Size(800, 480)
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
      Me.Splitter2.Size = New System.Drawing.Size(800, 1)
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
      Me.lvItem.Size = New System.Drawing.Size(800, 448)
      Me.lvItem.SortIndex = -1
      Me.lvItem.SortOrder = System.Windows.Forms.SortOrder.None
      Me.lvItem.TabIndex = 3
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
      Me.pnlFilter3.Size = New System.Drawing.Size(800, 32)
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
      Me.txtSelectTop.TabIndex = 222
      Me.txtSelectTop.Text = ""
      '
      'ibtnAll
      '
      Me.ibtnAll.Image = CType(resources.GetObject("ibtnAll.Image"), System.Drawing.Image)
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
      Me.ibtnNone.Image = CType(resources.GetObject("ibtnNone.Image"), System.Drawing.Image)
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
      Me.Splitter1.Size = New System.Drawing.Size(800, 1)
      Me.Splitter1.TabIndex = 7
      Me.Splitter1.TabStop = False
      '
      'chkHilight
      '
      Me.chkHilight.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.chkHilight.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.chkHilight.Location = New System.Drawing.Point(8, 88)
      Me.chkHilight.Name = "chkHilight"
      Me.chkHilight.TabIndex = 0
      Me.chkHilight.Text = "Hilight"
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

#End Region

#Region "Constructors"
    Public Sub New(ByVal entity As ISimpleEntity, ByVal handler As Object, ByVal basket As BasketDialog, ByVal filters As Filter(), ByVal entities As ArrayList)
      MyBase.New()
      Dim mode As Selection = Selection.MultiSelect
      If TypeOf handler Is NamedEntityOperationDelegate Then
        mode = Selection.SingleSelect
      End If
      Construct(entity, mode, basket, filters, entities)
    End Sub
    Private theBasket As BasketDialog
    Private theEntities As ArrayList
    Private Sub Construct(ByVal entity As ISimpleEntity, ByVal mode As Selection, ByVal basket As BasketDialog, ByVal filters As Filter(), ByVal entities As ArrayList)

      InitializeComponent()

      chkHilight.Checked = False

      m_entity = entity


      'Filter อื่นที่ส่งมาด้วย
      m_otherFilters = filters
      m_selectionMode = mode

      theBasket = basket
      theEntities = entities

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
    Private Sub SearchData(ByVal order As String)
      Dim t As Date = Now
      lvItem.BeginUpdate()
      lvItem.Items.Clear()
      Dim comparer As IComparer = lvItem.ListViewItemSorter
      lvItem.ListViewItemSorter = Nothing
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

        litem.Tag = row(Me.m_entity.Prefix & "_id")

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
    Private Sub SetStatusColor()
      If chkHilight.Checked Then
        For Each item As ListViewItem In Me.lvItem.Items
          Dim isRefed As Boolean = False
          Dim isCancelled As Boolean = False
          Try
            isCancelled = CBool(cancelHash(item.Tag))
            isRefed = CBool(refHash(item.Tag))
          Catch ex As Exception

          End Try
          If isRefed Then
            lvItem.SetColors(item, Color.ForestGreen, SystemColors.ControlText)
          ElseIf isCancelled Then
            lvItem.SetColors(item, Color.Red, Color.White)
          Else
            lvItem.SetColors(item, SystemColors.Window, SystemColors.ControlText)
          End If
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
        Return "รายการ"
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
    Public Overrides ReadOnly Property PrintDocument() As System.Drawing.Printing.PrintDocument
      Get
        Dim myPropertyService As PropertyService = CType(ServiceManager.Services.GetService(GetType(PropertyService)), PropertyService)
        Dim FormPath As String = (myPropertyService.DataDirectory & Path.DirectorySeparatorChar & "forms" & Path.DirectorySeparatorChar & "Adobe" & Path.DirectorySeparatorChar & "documents")
        Dim thePath As String = ""
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
            If dlg.ShowDialog() = DialogResult.OK Then
              thePath = dlg.KeyValuePair.Value
            Else
              Return Nothing
            End If
            If File.Exists(thePath) Then
              Dim df As New DesignerForm(thePath, Me.lvItem)
              Return df.PrintDocument
            End If
          End If
        End If
      End Get
    End Property
#End Region
    Private Sub chkHilight_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkHilight.CheckedChanged
      SetStatusColor()
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
            For Each item As ListViewItem In lvItem.Items
                i += 1
                For Each col As ColumnHeader In lvItem.Columns
                    Dim data As String = item.SubItems(col.Index).Text
                    Dim dpi As New DocPrintingItem
                    dpi.Mapping = "Item." & col.Text
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

            If TypeOf m_filterSubPanel Is IHasPrintItem Then
                dpiColl.AddRange(CType(m_filterSubPanel, IHasPrintItem).GetDocPrintingEntries)
            End If

            dpiColl.AddRange(GetDPICollFromListview())

            Return dpiColl
        End Function
#End Region

  End Class
End Namespace

