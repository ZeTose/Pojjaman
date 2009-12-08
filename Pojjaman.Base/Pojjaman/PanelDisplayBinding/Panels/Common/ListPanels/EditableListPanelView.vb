'Imports Longkong.Pojjaman.Services
'Imports Longkong.Core.Services
'Imports Longkong.Pojjaman.PanelDisplayBinding
'Imports Longkong.Pojjaman.Gui
'Imports Longkong.Pojjaman.Gui.Pads
'Imports Longkong.Pojjaman.Gui.Components
'Imports Longkong.Pojjaman.BusinessLogic
'Imports Longkong.Pojjaman.DataAccessLayer
'Namespace Longkong.Pojjaman.Gui.Panels
'    Public Class EditableListPanelView
'        Inherits AbstractEntityPanelViewContent
'        Implements ISimpleListEditablePanel, IValidatable

'#Region " Windows Form Designer generated code "

'        'UserControl overrides dispose to clean up the component list.
'        Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
'            If disposing Then
'                If Not (components Is Nothing) Then
'                    components.Dispose()
'                End If
'            End If
'            MyBase.Dispose(disposing)
'        End Sub

'        'Required by the Windows Form Designer
'        Private components As System.ComponentModel.IContainer

'        'NOTE: The following procedure is required by the Windows Form Designer
'        'It can be modified using the Windows Form Designer.  
'        'Do not modify it using the code editor.
'        Friend WithEvents pnlFilter As System.Windows.Forms.Panel
'        Friend WithEvents Splitter1 As System.Windows.Forms.Splitter
'        Friend WithEvents tgItem As Longkong.Pojjaman.Gui.Components.TreeGrid
'        Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
'        Friend WithEvents Validator As Longkong.Pojjaman.Gui.Components.PJMTextboxValidator
'        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
'            Me.components = New System.ComponentModel.Container
'            Me.pnlFilter = New System.Windows.Forms.Panel
'            Me.Splitter1 = New System.Windows.Forms.Splitter
'            Me.tgItem = New Longkong.Pojjaman.Gui.Components.TreeGrid
'            Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider
'            Me.Validator = New Longkong.Pojjaman.Gui.Components.PJMTextboxValidator(Me.components)
'            CType(Me.tgItem, System.ComponentModel.ISupportInitialize).BeginInit()
'            Me.SuspendLayout()
'            '
'            'pnlFilter
'            '
'            Me.pnlFilter.Dock = System.Windows.Forms.DockStyle.Top
'            Me.pnlFilter.Location = New System.Drawing.Point(0, 0)
'            Me.pnlFilter.Name = "pnlFilter"
'            Me.pnlFilter.Size = New System.Drawing.Size(681, 152)
'            Me.pnlFilter.TabIndex = 0
'            '
'            'Splitter1
'            '
'            Me.Splitter1.Dock = System.Windows.Forms.DockStyle.Top
'            Me.Splitter1.Location = New System.Drawing.Point(0, 152)
'            Me.Splitter1.Name = "Splitter1"
'            Me.Splitter1.Size = New System.Drawing.Size(681, 3)
'            Me.Splitter1.TabIndex = 1
'            Me.Splitter1.TabStop = False
'            '
'            'tgItem
'            '
'            Me.tgItem.AllowNew = True
'            Me.tgItem.AllowSorting = False
'            Me.tgItem.AutoColumnResize = True
'            Me.tgItem.CaptionVisible = False
'            Me.tgItem.Cellchanged = False
'            Me.tgItem.DataMember = ""
'            Me.tgItem.Dock = System.Windows.Forms.DockStyle.Fill
'            Me.tgItem.HeaderBackColor = System.Drawing.Color.Khaki
'            Me.tgItem.HeaderForeColor = System.Drawing.SystemColors.ControlText
'            Me.tgItem.Location = New System.Drawing.Point(0, 155)
'            Me.tgItem.Name = "tgItem"
'            Me.tgItem.Size = New System.Drawing.Size(681, 328)
'            Me.tgItem.SortingArrowColor = System.Drawing.Color.Red
'            Me.tgItem.TabIndex = 200
'            Me.tgItem.TreeManager = Nothing
'            '
'            'ErrorProvider1
'            '
'            Me.ErrorProvider1.ContainerControl = Me
'            '
'            'Validator
'            '
'            Me.Validator.BackcolorChanging = False
'            Me.Validator.DataTable = Nothing
'            Me.Validator.ErrorProvider = Me.ErrorProvider1
'            Me.Validator.GotFocusBackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
'            Me.Validator.HasNewRow = False
'            Me.Validator.InvalidBackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(128, Byte), CType(0, Byte))
'            '
'            'EditableListPanelView
'            '
'            Me.Controls.Add(Me.tgItem)
'            Me.Controls.Add(Me.Splitter1)
'            Me.Controls.Add(Me.pnlFilter)
'            Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
'            Me.Name = "EditableListPanelView"
'            Me.Size = New System.Drawing.Size(681, 483)
'            CType(Me.tgItem, System.ComponentModel.ISupportInitialize).EndInit()
'            Me.ResumeLayout(False)

'        End Sub

'#End Region

'#Region "Members"
'        Private m_filterSubPanel As IFilterSubPanel
'        Private m_entity As ISimpleEntity
'        Private m_selectedEntity As ISimpleEntity
'        Private m_selectedID As Integer
'        Private m_selectionMode As Selection

'        Private m_basketItems As BasketItemCollection
'        Private m_proposedBasketItems As BasketItemCollection

'        Private m_isInitialized As Boolean

'#End Region

'#Region "Constructors"
'        Public Sub New(ByVal entity As ISimpleEntity, ByVal handler As Object, ByVal basket As BasketDialog, ByVal filters As Filter(), ByVal entities As ArrayList)
'            MyBase.New()

'            InitializeComponent()

'            m_entity = entity
'            Me.TitleName = Me.StringParserService.Parse(m_entity.ListPanelTitle)
'            Me.PanelName = Me.Name

'            Me.SetLabelText()
'            Initialize()
'            Me.SetLabelText()

'            Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
'            m_filterSubPanel = myEntityPanelService.GetFilterSubPanel(m_entity)

'            Dim filterControl As UserControl = CType(Me.m_filterSubPanel, UserControl)
'            Me.pnlFilter.Controls.Add(filterControl)
'            Me.pnlFilter.Height = filterControl.Height
'            AddHandler Me.m_filterSubPanel.SearchButton.Click, AddressOf btnSearch_Click
'            AddHandler Me.m_filterSubPanel.SearchHandler, AddressOf Me.btnSearch_Click

'            m_basketItems = New BasketItemCollection
'            m_proposedBasketItems = New BasketItemCollection

'            Me.RefreshData()
'        End Sub
'#End Region

'#Region "Properties"
'        Public Enum Selection
'            None
'            MultiSelect
'            SingleSelect
'        End Enum
'        Public ReadOnly Property SelectionMode() As Selection
'            Get
'                Return Me.m_selectionMode
'            End Get
'        End Property
'#End Region

'#Region "Methods"
'        Public Function GetListDatatable(ByVal ParamArray filters As Filter()) As DataTable
'            Dim ent As ICanEditList = CType(Me.m_entity, ICanEditList)
'            ent.List.RefreshDataSet(filters)
'            Return ent.List.Dataset.Tables(0)
'        End Function
'        Public Sub RefreshData()

'            Dim oldDt As DataTable = CType(tgItem.DataSource, DataTable)
'            If Not oldDt Is Nothing Then
'                RemoveHandler oldDt.RowDeleted, AddressOf RowDeleted
'                RemoveHandler oldDt.ColumnChanging, AddressOf ColumnChanging
'                RemoveHandler oldDt.ColumnChanged, AddressOf ColumnChanged
'            End If

'            Dim dt As DataTable = GetListDatatable(Me.m_filterSubPanel.GetFilterArray)

'            WrapperArrayList.AddItemAddedHandler(dt, AddressOf ItemAdded)

'            m_isInitialized = False

'            Dim ent As ICanEditList = CType(Me.m_entity, ICanEditList)

'            Dim dst As DataGridTableStyle = ent.List.CreateTableStyle()
'            Dim myTreeManger As New TreeManager(dt, tgItem)
'            myTreeManger.SetTableStyle(dst)
'            myTreeManger.AllowSorting = False
'            myTreeManger.AllowDelete = True

'            m_isInitialized = True



'            AddHandler dt.RowDeleted, AddressOf RowDeleted
'            AddHandler dt.ColumnChanging, AddressOf ColumnChanging
'            AddHandler dt.ColumnChanged, AddressOf ColumnChanged
'            Me.Validator.DataTable = dt
'        End Sub
'        Public Sub ChangeTitle(ByVal sender As Object, ByVal e As EventArgs)
'            If Me.WorkbenchWindow.ActiveViewContent Is Me Then
'                Me.TitleName = Me.StringParserService.Parse(m_entity.ListPanelTitle)
'                Return
'            End If
'            If Not m_selectedEntity Is Nothing Then
'                Me.TitleName = m_selectedEntity.TabPageText
'            End If
'        End Sub
'        Private Function GetColumnString(ByVal s As String) As String
'            For Each col As Column In Me.m_entity.Columns
'                If col.Name.ToLower.EndsWith(s.ToLower) Then
'                    Return col.Name
'                End If
'            Next
'            'Return ""
'            If Not Me.m_entity Is Nothing Then
'                Return Me.m_entity.Prefix & s
'            Else
'                Return ""
'            End If
'        End Function
'#End Region

'#Region "Event Handlers"
'        Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
'            RefreshData()
'        End Sub
'        Private Sub btnAddBasketItems_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
'            AddToBasket()
'        End Sub
'        Dim dlg As BasketDialog
'        Private Sub btnShowBasket_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
'            dlg = New BasketDialog
'            Dim myDialog As New Longkong.Pojjaman.Gui.Dialogs.PanelDialog(dlg)
'            myDialog.TopMost = True
'            myDialog.Show()
'        End Sub
'#End Region

'#Region "ISimpleListEditablePanel"
'        Public Sub CheckFormEnable() Implements ISimpleListEditablePanel.CheckFormEnable

'        End Sub
'        Public Sub ClearDetail() Implements ISimpleListEditablePanel.ClearDetail

'        End Sub
'        Public ReadOnly Property List() As IListEditableCollection Implements ISimpleListEditablePanel.List
'            Get
'                Return CType(Me.m_entity, ICanEditList).List
'            End Get
'        End Property
'        Public Property Entity() As ISimpleEntity Implements ISimpleListEditablePanel.Entity
'            Get
'                Return Me.m_entity
'            End Get
'            Set(ByVal Value As ISimpleEntity)
'                Me.m_entity = Value
'            End Set
'        End Property
'        Public Sub Initialize() Implements ISimpleListEditablePanel.Initialize

'        End Sub
'        Public Sub SetLabelText() Implements ISimpleListEditablePanel.SetLabelText

'        End Sub
'        Public Sub UpdateEntityProperties() Implements ISimpleListEditablePanel.UpdateEntityProperties

'        End Sub
'        Public ReadOnly Property Icon() As String Implements ISimplePanel.Icon
'            Get
'                Return Me.m_entity.ListPanelIcon
'            End Get
'        End Property
'        Public Sub ShowInPad() Implements ISimplePanel.ShowInPad
'            Return
'        End Sub
'        Public ReadOnly Property Title() As String Implements ISimplePanel.Title
'            Get
'                Return Me.m_entity.ListPanelTitle
'            End Get
'        End Property
'        Public Event EntityPropertyChanged(ByVal sender As Object, ByVal e As System.EventArgs) Implements ISimpleEntityPanel.EntityPropertyChanged
'#End Region

'#Region "Overrides"
'        Public Overrides ReadOnly Property TabPageText() As String
'            Get
'                Return "รายการ"
'            End Get
'        End Property
'        Public Overrides Sub Deselected()
'            If Not Me.WorkbenchWindow.SubViewContents Is Nothing Then
'                If Not m_selectedEntity Is Nothing Then
'                    AddHandler m_selectedEntity.TabPageTextChanged, AddressOf Me.ChangeTitle
'                End If
'                CType(Me.WorkbenchWindow.SubViewContents(1), ISimpleEntityPanel).Entity = m_selectedEntity
'            End If
'        End Sub
'        Public Overrides Sub Selected()
'            Me.TitleName = Me.StringParserService.Parse(m_entity.ListPanelTitle)
'        End Sub
'#End Region

'#Region "TreeTable Handlers"
'        Private Sub ColumnChanged(ByVal sender As Object, ByVal e As System.Data.DataColumnChangeEventArgs)
'            If Not Me.m_isInitialized Then
'                Return
'            End If
'            If Not e.Row.RowState = DataRowState.Detached Then
'                e.Row.SetColumnError(0, "")
'            Else
'                e.Row.SetColumnError(0, Me.StringParserService.Parse("${res:Global.Error.GridHasNewLine}"))
'                Me.Validator.HasNewRow = True
'            End If
'            Me.WorkbenchWindow.ViewContent.IsDirty = True
'        End Sub
'        Private Sub ColumnChanging(ByVal sender As Object, ByVal e As System.Data.DataColumnChangeEventArgs)
'            If Not Me.m_isInitialized Then
'                Return
'            End If
'            Dim ent As ICanEditList = CType(Me.m_entity, ICanEditList)
'            ent.List.ColumnChanging(sender, e)
'        End Sub
'        Private Sub RowChangedTick(ByVal sender As Object, ByVal e As EventArgs)
'            CType(sender, Timer).Stop()
'            If Not Me.m_isInitialized Then
'                Return
'            End If
'            CType(Me.tgItem.DataSource, DataTable).AcceptChanges()
'            Me.WorkbenchWindow.ViewContent.IsDirty = True
'        End Sub
'        Private Sub RowDeleted(ByVal sender As Object, ByVal e As System.Data.DataRowChangeEventArgs)
'            Dim t As New Timer
'            t.Interval = 1
'            AddHandler t.Tick, AddressOf RowChangedTick
'            t.Start()
'        End Sub
'        Private Sub ItemAdded(ByVal sender As Object, ByVal e As ITemAddedEventArgs)
'            If Not Me.m_isInitialized Then
'                Return
'            End If
'            Me.WorkbenchWindow.ViewContent.IsDirty = True
'            e.Row.SetColumnError(0, "")
'            Me.Validator.HasNewRow = False
'        End Sub
'#End Region

'#Region "IBasketCollectable"
'        Private Sub RefreshProposedBasket()
'            'm_proposedBasketItems.Clear()
'            'For Each item As ListViewItem In Me.lvItem.CheckedItems
'            '    Dim id As Integer = CInt(item.Tag)
'            '    Dim entity As ISimpleEntity = SimpleEntityFactory.CreateEntity(Me.m_entity.FullClassName, id)
'            '    Dim basketitem As New basketitem(id, entity.Code, entity.FullClassName, entity.Code)
'            '    m_proposedBasketItems.Add(basketitem)
'            'Next
'        End Sub
'        Private Sub AddToBasket()
'            RefreshProposedBasket()
'            m_basketItems.AddRange(m_proposedBasketItems)
'            dlg.tvItems.Nodes.Clear()
'            For Each item As IBasketItem In m_basketItems
'                dlg.tvItems.Nodes.Add(item.TextInBasket)
'            Next
'        End Sub

'        Public Overrides ReadOnly Property BasketItems() As BusinessLogic.BasketItemCollection
'            Get
'                Return m_basketItems
'            End Get
'        End Property
'        Public Overrides ReadOnly Property ProposedBasketItems() As BusinessLogic.BasketItemCollection
'            Get
'                Return m_proposedBasketItems
'            End Get
'        End Property
'#End Region

'#Region "IValidatable"
'        Public ReadOnly Property FormValidator() As components.PJMTextboxValidator Implements IValidatable.FormValidator
'            Get
'                Return Me.Validator
'            End Get
'        End Property
'#End Region

'    End Class
'End Namespace

