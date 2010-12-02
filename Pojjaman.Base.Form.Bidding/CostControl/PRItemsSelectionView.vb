Imports Longkong.Pojjaman.Services
Imports Longkong.Core.Services
Imports Longkong.Pojjaman.PanelDisplayBinding
Imports Longkong.Pojjaman.Gui
Imports Longkong.Pojjaman.Gui.Pads
Imports Longkong.Pojjaman.Gui.Components
Imports Longkong.Pojjaman.BusinessLogic
Imports Longkong.Pojjaman.DataAccessLayer
Namespace Longkong.Pojjaman.Gui.Panels
    Public Class PRItemSelectionView
        Inherits AbstractEntityPanelViewContent
        Implements ISimpleListPanel

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
        Friend WithEvents Splitter1 As System.Windows.Forms.Splitter
        Friend WithEvents grbBasketOperation As Longkong.Pojjaman.Gui.Components.FixedGroupBox
        Friend WithEvents btnAddBasketItems As System.Windows.Forms.Button
        Friend WithEvents btnEmptyBasket As System.Windows.Forms.Button
        Friend WithEvents tgItem As Longkong.Pojjaman.Gui.Components.TreeGrid
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Me.pnlFilter = New System.Windows.Forms.Panel
            Me.grbBasketOperation = New Longkong.Pojjaman.Gui.Components.FixedGroupBox
            Me.btnEmptyBasket = New System.Windows.Forms.Button
            Me.btnAddBasketItems = New System.Windows.Forms.Button
            Me.Splitter1 = New System.Windows.Forms.Splitter
            Me.tgItem = New Longkong.Pojjaman.Gui.Components.TreeGrid
            Me.pnlFilter.SuspendLayout()
            Me.grbBasketOperation.SuspendLayout()
            CType(Me.tgItem, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'pnlFilter
            '
            Me.pnlFilter.Controls.Add(Me.grbBasketOperation)
            Me.pnlFilter.Dock = System.Windows.Forms.DockStyle.Top
            Me.pnlFilter.Location = New System.Drawing.Point(0, 0)
            Me.pnlFilter.Name = "pnlFilter"
            Me.pnlFilter.Size = New System.Drawing.Size(768, 152)
            Me.pnlFilter.TabIndex = 0
            '
            'grbBasketOperation
            '
            Me.grbBasketOperation.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.grbBasketOperation.Controls.Add(Me.btnEmptyBasket)
            Me.grbBasketOperation.Controls.Add(Me.btnAddBasketItems)
            Me.grbBasketOperation.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.grbBasketOperation.Location = New System.Drawing.Point(591, 8)
            Me.grbBasketOperation.Name = "grbBasketOperation"
            Me.grbBasketOperation.Size = New System.Drawing.Size(168, 64)
            Me.grbBasketOperation.TabIndex = 0
            Me.grbBasketOperation.TabStop = False
            Me.grbBasketOperation.Text = "Basket"
            '
            'btnEmptyBasket
            '
            Me.btnEmptyBasket.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.btnEmptyBasket.Location = New System.Drawing.Point(88, 24)
            Me.btnEmptyBasket.Name = "btnEmptyBasket"
            Me.btnEmptyBasket.TabIndex = 1
            Me.btnEmptyBasket.Text = "เท"
            '
            'btnAddBasketItems
            '
            Me.btnAddBasketItems.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.btnAddBasketItems.Location = New System.Drawing.Point(8, 24)
            Me.btnAddBasketItems.Name = "btnAddBasketItems"
            Me.btnAddBasketItems.TabIndex = 0
            Me.btnAddBasketItems.Text = "Add"
            '
            'Splitter1
            '
            Me.Splitter1.Dock = System.Windows.Forms.DockStyle.Top
            Me.Splitter1.Location = New System.Drawing.Point(0, 152)
            Me.Splitter1.Name = "Splitter1"
            Me.Splitter1.Size = New System.Drawing.Size(768, 3)
            Me.Splitter1.TabIndex = 1
            Me.Splitter1.TabStop = False
            '
            'tgItem
            '
            Me.tgItem.AllowNew = True
            Me.tgItem.AllowSorting = False
            Me.tgItem.AlternatingBackColor = System.Drawing.SystemColors.InactiveCaptionText
            Me.tgItem.CaptionVisible = False
            Me.tgItem.Cellchanged = False
            Me.tgItem.DataMember = ""
            Me.tgItem.Dock = System.Windows.Forms.DockStyle.Fill
            Me.tgItem.HeaderBackColor = System.Drawing.Color.Khaki
            Me.tgItem.HeaderForeColor = System.Drawing.SystemColors.ControlText
            Me.tgItem.Location = New System.Drawing.Point(0, 155)
            Me.tgItem.Name = "tgItem"
            Me.tgItem.Size = New System.Drawing.Size(768, 328)
            Me.tgItem.SortingArrowColor = System.Drawing.Color.Red
            Me.tgItem.TabIndex = 7
            Me.tgItem.TreeManager = Nothing
            '
            'PRItemSelectionView
            '
            Me.Controls.Add(Me.tgItem)
            Me.Controls.Add(Me.Splitter1)
            Me.Controls.Add(Me.pnlFilter)
            Me.Name = "PRItemSelectionView"
            Me.Size = New System.Drawing.Size(768, 483)
            Me.pnlFilter.ResumeLayout(False)
            Me.grbBasketOperation.ResumeLayout(False)
            CType(Me.tgItem, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub

#End Region

#Region "Members"
        Private m_filterSubPanel As IFilterSubPanel
        Private m_entity As ISimpleEntity
        Private m_selectedID As Integer

        Private m_basketItems As BasketItemCollection
        Private m_proposedBasketItems As BasketItemCollection

        Private m_groupBys As New ArrayList
        Private m_selectedItems As ArrayList

        Private m_treeManager As TreeManager
#End Region

#Region "Constructors"
        Public Sub New(ByVal entity As ISimpleEntity, ByVal basket As BasketDialog)
            MyBase.New()

            InitializeComponent()
            m_entity = entity
            Me.SetLabelText()
            Me.TitleName = Me.StringParserService.Parse(m_entity.ListPanelTitle)
            Me.PanelName = Me.Name

            'Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
            'm_filterSubPanel = myEntityPanelService.GetFilterSubPanel(m_entity)

            m_filterSubPanel = New PRFilterSubPanel

            Dim filterControl As UserControl = CType(Me.m_filterSubPanel, UserControl)
            Me.pnlFilter.Controls.Add(filterControl)
            Me.pnlFilter.Height = filterControl.Height
            AddHandler Me.m_filterSubPanel.SearchButton.Click, AddressOf btnSearch_Click

            Me.m_groupBys.Add("Code")
            m_selectedItems = New ArrayList
            Me.RefreshData("")

            m_basketItems = New BasketItemCollection
            m_proposedBasketItems = New BasketItemCollection

        End Sub
#End Region

#Region "Methods"
        Private Sub SetSelectedItem()
            m_selectedItems.Clear()
            Dim myTable As TreeTable = CType(tgItem.DataSource, TreeTable)
            For Each row As TreeRow In myTable.Childs
                For Each childRow As TreeRow In row.Childs
                    If Not IsDBNull(childRow("Selected")) Then
                        If CBool(childRow("Selected")) Then
                            m_selectedItems.Add(childRow)
                        End If
                    End If
                Next
            Next
        End Sub
        Private Sub RowIcon_Click(ByVal e As ButtonColumnEventArgs)
            Dim myTable As ExpandableRowDataTable = CType(tgItem.DataSource, ExpandableRowDataTable)
            Dim clickedRow As ExpandableDataRow = CType(myTable.Rows(e.Row), ExpandableDataRow)
            If Not IsDBNull(clickedRow("Selected")) Then
                clickedRow("Selected") = Not CBool(clickedRow("Selected"))
            Else
                clickedRow("Selected") = False
            End If
            For Each row As ExpandableDataRow In myTable.Childs
                Dim checkCount As Integer
                For Each childRow As ExpandableDataRow In row.Childs
                    If e.Row = row.Index Then
                        childRow("Selected") = row("Selected")
                    End If
                    If CBool(childRow("Selected")) Then
                        checkCount += 1
                    End If
                Next
                If checkCount = row.Childs.Count Then
                    row("Selected") = True
                ElseIf checkCount = 0 Then
                    row("Selected") = False
                Else
                    row("Selected") = DBNull.Value
                End If
            Next
        End Sub
        Public Sub ChangeTitle(ByVal sender As Object, ByVal e As EventArgs) Implements ISimpleListPanel.ChangeTitle
            If Me.WorkbenchWindow.ActiveViewContent Is Me Then
                Me.TitleName = Me.StringParserService.Parse(m_entity.ListPanelTitle)
                Return
            End If
            'If Not m_selectedEntity Is Nothing Then
            '    Me.TitleName = m_selectedEntity.TabPageText
            'End If
        End Sub
        Private Sub Group()
            Dim fields As New ArrayList
            fields.Add("Requestor Qty")
            fields.Add("CostCenter OrderedQty")
            fields.Add("Date DummyDate")
            fields.Add("ReceivingDate DummyReceivingDate")
            m_treeManager.GroupTree(m_groupBys, fields, "Entity", False)
        End Sub
        Public Sub SearchData(ByVal order As String)

            Dim dt As TreeTable = PRItemCollection.GetListDatatable(Me.m_filterSubPanel.GetFilterArray)
            Dim dst As DataGridTableStyle = PRItemCollection.CreateListTableStyle()
            m_treeManager = New TreeManager(dt, tgItem)
            m_treeManager.SetTableStyle(dst)
            m_treeManager.AllowSorting = False
            m_treeManager.AllowDelete = False

            'สั่ง group ซะ
            Me.Group()
        End Sub
        Public Function CanGroup() As Boolean
            For Each item As String In Me.m_groupBys
                If item <> "" And item <> "<None>" Then
                    Return True
                End If
            Next
            Return False
        End Function
#End Region

#Region "Event Handlers"
        Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
            Me.SearchData("")
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
        End Sub
        Public Sub UpdateEntityProperties() Implements ISimpleEntityPanel.UpdateEntityProperties

        End Sub
        Public Sub AddNew() Implements ISimpleListPanel.AddNew

        End Sub
        Public Sub RefreshData(ByVal id As String) Implements ISimpleListPanel.RefreshData
            SearchData("")
        End Sub
        Public Property SelectedEntity() As BusinessLogic.ISimpleEntity Implements ISimpleListPanel.SelectedEntity
            Get
                'Return m_selectedEntity
            End Get
            Set(ByVal Value As BusinessLogic.ISimpleEntity)
                'If CType(m_selectedEntity, Object).Equals(Value) Then
                '    Return
                'End If
                'Me.m_selectedEntity = Value
                'If Not m_selectedEntity Is Nothing Then
                '    Me.RefreshData(m_selectedEntity.Id.ToString)
                'End If
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
                'If Not m_selectedEntity Is Nothing Then
                '    AddHandler m_selectedEntity.TabPageTextChanged, AddressOf Me.ChangeTitle
                'End If
                'CType(Me.WorkbenchWindow.SubViewContents(1), ISimpleEntityPanel).Entity = m_selectedEntity
            End If
        End Sub
        Public Overrides Sub Selected()
            Me.RefreshData(Me.SelectedEntity.Id.ToString)
            Me.TitleName = Me.StringParserService.Parse(m_entity.ListPanelTitle)
        End Sub
#End Region

#Region "IBasketCollectable"
        Private dlg As BasketDialog
        Private Sub btnAddBasketItems_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddBasketItems.Click
            AddToBasket()
        End Sub
        Private Sub btnEmptyBasket_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEmptyBasket.Click
            Me.OnEmptyBasket(Me.m_basketItems)
            Me.m_basketItems.Clear()
            If dlg Is Nothing Then
                Return
            End If
            dlg.tvItems.Nodes.Clear()
        End Sub
        Private Sub RefreshProposedBasket()
            SetSelectedItem()
            m_proposedBasketItems.Clear()
            For Each row As TreeRow In m_selectedItems
                Dim basketitem As New basketitem(1, row("Code").ToString, row("Code").ToString, row("Code").ToString)
                m_proposedBasketItems.Add(basketitem)
            Next
            'For Each item As ListViewItem In Me.lvItem.CheckedItems
            '    Dim id As Integer = CInt(item.Tag)
            '    Dim entity As ISimpleEntity = SimpleEntityFactory.CreateEntity(Me.m_entity.FullClassName, id)
            '    Dim basketitem As New basketitem(id, entity.Code, entity.FullClassName, entity.Code)
            '    m_proposedBasketItems.Add(basketitem)
            'Next
        End Sub
        Private Sub AddToBasket()
            If dlg Is Nothing Then
                Return
            End If
            RefreshProposedBasket()
            m_basketItems.AddRange(m_proposedBasketItems)
            dlg.tvItems.Nodes.Clear()
            For Each item As IBasketItem In m_basketItems
                dlg.tvItems.Nodes.Add(item.TextInBasket)
            Next
        End Sub
        Public Overrides ReadOnly Property BasketItems() As BusinessLogic.BasketItemCollection
            Get
                Return m_basketItems
            End Get
        End Property
        Public Overrides ReadOnly Property ProposedBasketItems() As BusinessLogic.BasketItemCollection
            Get
                Return m_proposedBasketItems
            End Get
        End Property

#End Region

    End Class
End Namespace

