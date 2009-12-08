Imports Longkong.Pojjaman.Services
Imports Longkong.Core.Services
Imports Longkong.Pojjaman.PanelDisplayBinding
Imports Longkong.Pojjaman.Gui
Imports Longkong.Pojjaman.Gui.Pads
Imports Longkong.Pojjaman.Gui.Components
Imports Longkong.Pojjaman.BusinessLogic
Imports Longkong.Pojjaman.DataAccessLayer
Namespace Longkong.Pojjaman.Gui.Panels
    Public Class GoodsSoldSelectionView
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
        Friend WithEvents tgItem As Longkong.Pojjaman.Gui.Components.TreeGrid
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Me.pnlFilter = New System.Windows.Forms.Panel
            Me.Splitter1 = New System.Windows.Forms.Splitter
            Me.tgItem = New Longkong.Pojjaman.Gui.Components.TreeGrid
            CType(Me.tgItem, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'pnlFilter
            '
            Me.pnlFilter.Dock = System.Windows.Forms.DockStyle.Top
            Me.pnlFilter.Location = New System.Drawing.Point(0, 0)
            Me.pnlFilter.Name = "pnlFilter"
            Me.pnlFilter.Size = New System.Drawing.Size(768, 152)
            Me.pnlFilter.TabIndex = 0
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
            Me.tgItem.AllowNew = False
            Me.tgItem.AllowSorting = False
            Me.tgItem.AlternatingBackColor = System.Drawing.SystemColors.InactiveCaptionText
            Me.tgItem.AutoColumnResize = True
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
            'GoodsSoldSelectionView
            '
            Me.Controls.Add(Me.tgItem)
            Me.Controls.Add(Me.Splitter1)
            Me.Controls.Add(Me.pnlFilter)
            Me.Name = "GoodsSoldSelectionView"
            Me.Size = New System.Drawing.Size(768, 483)
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
        Private m_groupBys As ArrayList

        Private m_treeManager As TreeManager

        Private m_selectionMode As Selection

        Private m_oldBasket As BasketItemCollection

        Private m_otherFilters As Filter()
#End Region

#Region "Constructors"
        Public Sub New(ByVal entity As ISimpleEntity, ByVal mode As Selection, ByVal basket As BasketDialog, ByVal filters As Filter(), ByVal entities As ArrayList)
            MyBase.New()

            InitializeComponent()
            m_entity = entity
            Me.SetLabelText()
            Me.TitleName = Me.StringParserService.Parse(m_entity.ListPanelTitle)
            Me.PanelName = Me.Name

            'Hack
            m_filterSubPanel = New GoodsSoldFilterSubPanel
            m_filterSubPanel.Entities = entities

            Dim filterControl As UserControl = CType(Me.m_filterSubPanel, UserControl)
            Me.pnlFilter.Controls.Add(filterControl)
            Me.pnlFilter.Height = filterControl.Height
            m_otherFilters = filters

            m_groupBys = New ArrayList
            Me.m_groupBys.Add("Code")

            AddHandler Me.m_filterSubPanel.SearchButton.Click, AddressOf btnSearch_Click
            Me.m_filterSubPanel.SearchButton.PerformClick()

            m_basketItems = New BasketItemCollection
            m_proposedBasketItems = New BasketItemCollection
            m_oldBasket = New BasketItemCollection

            m_selectionMode = mode
        End Sub
        Public Sub New(ByVal entity As ISimpleEntity, ByVal basket As BasketDialog, ByVal filters As Filter(), ByVal entities As ArrayList)
            Me.new(entity, Selection.MultiSelect, basket, filters, entities)
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
#End Region

#Region "Methods"
        Private Sub RowIcon_Click(ByVal e As ButtonColumnEventArgs)
            Dim myTable As TreeTable = Me.m_treeManager.Treetable
            Dim clickedRow As TreeRow = CType(myTable.Rows(e.Row), TreeRow)
            For Each row As TreeRow In myTable.Childs
                Dim checkCount As Integer = 0
                For Each childRow As TreeRow In row.Childs
                    If e.Row = row.Index Then
                        'คลิกโดนแม่
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
            fields.Add("FromCostcenter Qty")
            fields.Add("Date DummyDate")
            fields.Add("DueDate DummyDueDate")
            m_treeManager.GroupTree(m_groupBys, fields, "Entity", False)
        End Sub
        Public Sub SearchData(ByVal order As String)

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

            Dim dt As TreeTable = GoodsSoldItem.GetListDatatable(newfilters)
            Dim dst As DataGridTableStyle = CreateListTableStyle()
            m_treeManager = New TreeManager(dt, tgItem)
            m_treeManager.SetTableStyle(dst)
            m_treeManager.AllowSorting = False
            m_treeManager.AllowDelete = False

            'สั่ง group ซะ
            Me.Group()
            For Each row As TreeRow In Me.m_treeManager.Treetable.Childs
                row.State = RowExpandState.Expanded
                row("Selected") = False
            Next
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

#Region "Style"
        Public Function CreateListTableStyle() As DataGridTableStyle
            Dim dst As New DataGridTableStyle
            dst.MappingName = "GoodsSoldItems"

            Dim csSelected As New DataGridCheckBoxColumn
            csSelected.MappingName = "Selected"
            csSelected.HeaderText = ""
            AddHandler csSelected.Click, AddressOf RowIcon_Click

            Dim csDescription As New TreeTextColumn  'PlusMinusTreeTextColumn
            csDescription.MappingName = "Entity"
            csDescription.HeaderText = "Entity"
            csDescription.NullText = ""
            csDescription.Width = 180
            csDescription.ReadOnly = True

            Dim csQty As New TreeTextColumn
            csQty.MappingName = "Qty"
            csQty.HeaderText = "Qty"
            csQty.NullText = ""
            csQty.ReadOnly = True


            Dim csDate As New TreeTextColumn
            csDate.MappingName = "DummyDate"
            csDate.HeaderText = "Date"
            csDate.NullText = ""
            csDate.DataAlignment = HorizontalAlignment.Center
            csDate.Width = 100
            csDate.Format = "d"
            csDate.ReadOnly = True

            Dim csDueDate As New TreeTextColumn
            csDueDate.MappingName = "DummyDueDate"
            csDueDate.HeaderText = "DueDate"
            csDueDate.NullText = ""
            csDueDate.DataAlignment = HorizontalAlignment.Center
            csDueDate.Width = 100
            csDueDate.Format = "d"
            csDueDate.ReadOnly = True

            Dim csFromCostcenter As New TreeTextColumn
            csFromCostcenter.MappingName = "FromCostcenter"
            csFromCostcenter.HeaderText = "FromCostcenter"
            csFromCostcenter.NullText = ""
            csFromCostcenter.DataAlignment = HorizontalAlignment.Center
            csFromCostcenter.Width = 100
            csFromCostcenter.ReadOnly = True

            dst.GridColumnStyles.Add(csSelected)
            dst.GridColumnStyles.Add(csDescription)
            dst.GridColumnStyles.Add(csQty)
            dst.GridColumnStyles.Add(csDate)
            dst.GridColumnStyles.Add(csDueDate)
            'dst.GridColumnStyles.Add(csFromCostcenter)
            Return dst
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
        Public Overrides ReadOnly Property BasketItems() As BusinessLogic.BasketItemCollection
            Get
                m_basketItems.Clear()
                Dim myTable As TreeTable = CType(tgItem.DataSource, TreeTable)
                For Each row As TreeRow In myTable.Childs
                    For Each childRow As TreeRow In row.Childs
                        If Not IsDBNull(childRow("Selected")) Then
                            If CBool(childRow("Selected")) Then
                                Dim id As Integer = CInt(childRow("stock_id"))
                                Dim stockCode As String = CStr(childRow("Code"))
                                Dim fullClassName As String = "Longkong.Pojjaman.BusinessLogic.GoodsSoldItem"
                                Dim entityName As String = CStr(childRow("Entity"))
                                Dim lineNumber As Integer = CInt(childRow("LineNumber"))
                                Dim qty As Decimal = CDec(childRow("Qty"))
                                Dim textInBasket As String = entityName & ":" & qty.ToString
                                Dim bi As New StockBasketItem(id, stockCode, fullClassName, textInBasket, lineNumber, qty, entityName)
                                m_basketItems.Add(bi)
                            End If
                        End If
                    Next
                Next
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

