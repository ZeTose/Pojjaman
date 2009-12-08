Imports Longkong.Pojjaman.Services
Imports Longkong.Core.Services
Imports Longkong.Pojjaman.PanelDisplayBinding
Imports Longkong.Pojjaman.Gui
Imports Longkong.Pojjaman.Gui.Pads
Imports Longkong.Pojjaman.Gui.Components
Imports Longkong.Pojjaman.BusinessLogic
Imports Longkong.Pojjaman.DataAccessLayer
Namespace Longkong.Pojjaman.Gui.Panels
    Public Class ItemSelectionPanelView
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
        Friend WithEvents dgList As Longkong.Pojjaman.Gui.Components.PJMDataGrid
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Me.pnlFilter = New System.Windows.Forms.Panel
            Me.Splitter1 = New System.Windows.Forms.Splitter
            Me.dgList = New Longkong.Pojjaman.Gui.Components.PJMDataGrid
            CType(Me.dgList, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'pnlFilter
            '
            Me.pnlFilter.Dock = System.Windows.Forms.DockStyle.Top
            Me.pnlFilter.Location = New System.Drawing.Point(0, 0)
            Me.pnlFilter.Name = "pnlFilter"
            Me.pnlFilter.Size = New System.Drawing.Size(681, 152)
            Me.pnlFilter.TabIndex = 0
            '
            'Splitter1
            '
            Me.Splitter1.Dock = System.Windows.Forms.DockStyle.Top
            Me.Splitter1.Location = New System.Drawing.Point(0, 152)
            Me.Splitter1.Name = "Splitter1"
            Me.Splitter1.Size = New System.Drawing.Size(681, 3)
            Me.Splitter1.TabIndex = 1
            Me.Splitter1.TabStop = False
            '
            'dgList
            '
            Me.dgList.AllowColumnDrag = True
            Me.dgList.AllowColumnResize = True
            Me.dgList.AllowNew = False
            Me.dgList.AllowRowDeletion = False
            Me.dgList.AlternatingBackColor = System.Drawing.Color.WhiteSmoke
            Me.dgList.AutoColumnResize = True
            Me.dgList.CaptionVisible = False
            Me.dgList.CustomColumnHeaders = False
            Me.dgList.DataMember = ""
            Me.dgList.Dock = System.Windows.Forms.DockStyle.Fill
            Me.dgList.FullRowSelect = True
            Me.dgList.HeaderFont = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.dgList.HeaderForeColor = System.Drawing.SystemColors.ControlText
            Me.dgList.Location = New System.Drawing.Point(0, 155)
            Me.dgList.m_dataTable = Nothing
            Me.dgList.Name = "dgList"
            Me.dgList.RowHeadersVisible = False
            Me.dgList.ShowColumnHeaderWhileDragging = True
            Me.dgList.ShowColumnWhileDragging = True
            Me.dgList.Size = New System.Drawing.Size(681, 328)
            Me.dgList.TabIndex = 2
            '
            'ItemSelectionPanelView
            '
            Me.Controls.Add(Me.dgList)
            Me.Controls.Add(Me.Splitter1)
            Me.Controls.Add(Me.pnlFilter)
            Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Name = "ItemSelectionPanelView"
            Me.Size = New System.Drawing.Size(681, 483)
            CType(Me.dgList, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub

#End Region

#Region "Members"
        Private m_filterSubPanel As IFilterSubPanel
        Private m_entity As ISimpleEntity
        Private m_selectedEntity As ISimpleEntity
        Private dv As DataView
        Private rv As DataRowView
        Private cm As CurrencyManager

        Private m_selectionMode As Selection
#End Region

#Region "Constructors"
        Public Sub New(ByVal entity As ISimpleEntity, ByVal mode As Selection)
            MyBase.New()

            InitializeComponent()
            m_entity = entity
            Me.SetLabelText()
            Me.TitleName = Me.Text
            Me.PanelName = Me.Name

            Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
            m_filterSubPanel = myEntityPanelService.GetFilterSubPanel(m_entity)

            Dim filterControl As UserControl = CType(Me.m_filterSubPanel, UserControl)
            Me.pnlFilter.Controls.Add(filterControl)
            Me.pnlFilter.Height = filterControl.Height
            AddHandler Me.m_filterSubPanel.SearchButton.Click, AddressOf btnSearch_Click
            Me.RefreshData("")
            dgList.TableStyles.Add(CreateTableStyle)

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
        Public Sub ChangeTitle(ByVal sender As Object, ByVal e As EventArgs) Implements ISimpleListPanel.ChangeTitle
            If Me.WorkbenchWindow.ActiveViewContent Is Me Then
                Me.TitleName = Me.Text
            ElseIf Not Me.m_selectedEntity Is Nothing Then
                Me.TitleName = Me.m_selectedEntity.TabPageText
            End If
        End Sub
        Private Function GetColumnString(ByVal s As String) As String
            For Each col As Column In Me.m_entity.Columns
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
        Private Function CreateTableStyle() As DataGridTableStyle
            Dim dst As New DataGridTableStyle
            dst.MappingName = m_entity.ClassName
            dst.AlternatingBackColor = dgList.AlternatingBackColor
            dst.PreferredRowHeight = dgList.PreferredRowHeight
            dst.RowHeadersVisible = dgList.RowHeadersVisible
            'Dim checkColumn As New DataGridCheckBoxColumn
            'checkColumn.Width = 60
            'dst.GridColumnStyles.Add(checkColumn)
            For Each col As Column In m_entity.Columns
                Dim cs As New DataGridTextColumn
                cs.MappingName = col.Name
                cs.HeaderText = Me.StringParserService.Parse(col.Alias)
                cs.Width = col.Width
                cs.NullText = ""
                dst.GridColumnStyles.Add(cs)
            Next
            Return dst
        End Function
        Public Sub SearchData(ByVal order As String)
            Dim sortString As String = ""
            If Not IsNothing(dv) Then
                sortString = dv.Sort
            End If
            If sortString = "" Then
                sortString = GetColumnString("_code")
            End If

            dgList.DataSource = m_entity.GetListDatatable(order, Me.m_filterSubPanel.GetFilterArray)
            cm = CType(Me.BindingContext(dgList.DataSource, dgList.DataMember), CurrencyManager)
            dv = CType(cm.List, DataView)
            dv.AllowNew = False
            dv.AllowEdit = False
            dv.AllowDelete = False
            AddHandler cm.CurrentChanged, AddressOf cm_CurrentChanged
            AddHandler cm.ItemChanged, AddressOf cm_ItemChanged
            dv.Sort = sortString
        End Sub
        Private Function FindRowIndex(ByVal id As String) As Integer
            Dim col As String = GetColumnString("_id")
            'Hack: offset
            Dim offset As Integer = 0
            If dv.Sort.Length = 0 Then
                offset = 0 '1
            End If
            For i As Integer = 0 To dv.Count - 1
                If dv(i)(col).ToString = id Then
                    Return i + offset
                End If
            Next
            Return -1
        End Function
        Public Sub SelectNewEntity()
            Me.m_selectedEntity = SimpleBusinessEntityBase.GetEntity(Me.m_entity.FullClassName)
        End Sub
#End Region

#Region "Event Handlers"
        Private Sub dgList_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgList.KeyDown
            'If e.KeyCode = Keys.Enter And dv.Count > 0 Then
            '    dgList.Select(cm.Position)
            '    CType(Me.DetailPanel, Control).Focus()
            'End If
        End Sub
        Private Sub dgList_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgList.Leave
            If dv.Count > 0 Then
                dgList.Select(cm.Position)
            End If
        End Sub
        Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
            Me.SearchData(GetColumnString("_code"))
            cm.Position = 0
            cm_CurrentChanged(cm, New EventArgs)
        End Sub
        Private Sub cm_ItemChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.ItemChangedEventArgs)
            If Not IsNothing(rv) Then
                cm.Position = FindRowIndex(rv(GetColumnString("_id")).ToString) 'currentPos
            Else
                cm.Position = 0
            End If
            dgList.ScrollToRow(cm.Position)
            cm_CurrentChanged(cm, New EventArgs)
        End Sub
        Public Sub cm_CurrentChanged(ByVal sender As Object, ByVal e As EventArgs)
            'Me.StatusBarService.SetMessage("${res:MainWindow.StatusBar.ReadyMessage}")
            Me.m_selectedEntity = Nothing
            If dv.Count > 0 Then
                Me.m_selectedEntity = SimpleBusinessEntityBase.GetEntity(Me.m_entity.FullClassName, CInt(dgList(dgList.CurrentCell.RowNumber, 0))) 'SimpleEntityFactory.CreateEntity(Me.m_entity.FullClassName, CInt(dgList(dgList.CurrentCell.RowNumber, 0)))
                If Me.m_selectedEntity Is Nothing Then
                    Me.m_selectedEntity = SimpleBusinessEntityBase.GetEntity(Me.m_entity.FullClassName)
                End If
            Else
                Me.SelectNewEntity()
            End If
            If Not Me.m_selectedEntity Is Nothing Then
                AddHandler Me.m_selectedEntity.TabPageTextChanged, AddressOf Me.ChangeTitle
                Me.StatusBarService.SetMessage(Me.m_selectedEntity.Code)
            End If
        End Sub
        Private Sub dgList_ColumnHeaderClicked(ByVal sender As Object, ByVal e As ColumnHeaderClickEventArgs) Handles dgList.ColumnHeaderClicked
            If (Not IsNothing(cm)) And dv.Count > 0 Then
                rv = CType(cm.Current, DataRowView)
            End If
        End Sub
        Private Sub dgList_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgList.DoubleClick
            If Not Me.WorkbenchWindow Is Nothing Then
                If Not TypeOf Me.WorkbenchWindow.ActiveViewContent Is ISecondaryViewContent Then
                    Me.WorkbenchWindow.SwitchView(1)
                End If
            End If
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

        End Sub
        Public Sub UpdateEntityProperties() Implements ISimpleEntityPanel.UpdateEntityProperties

        End Sub
        Public Sub AddNew() Implements ISimpleListPanel.AddNew
            If Not Me.WorkbenchWindow.SubViewContents Is Nothing Then
                Me.m_selectedEntity = SimpleBusinessEntityBase.GetEntity(Me.m_entity.FullClassName)
                If Not m_selectedEntity Is Nothing Then
                    AddHandler Me.m_selectedEntity.TabPageTextChanged, AddressOf Me.ChangeTitle
                End If
                If Not TypeOf Me.WorkbenchWindow.ActiveViewContent Is ISecondaryViewContent Then
                    Me.WorkbenchWindow.SwitchView(1)
                Else
                    If Not Me.WorkbenchWindow.SubViewContents Is Nothing Then
                        CType(Me.WorkbenchWindow.SubViewContents(1), ISimpleEntityPanel).Entity = Me.m_selectedEntity
                    End If
                End If
            End If
        End Sub
        Public Sub RefreshData(ByVal id As String) Implements ISimpleListPanel.RefreshData
            Dim currentPos As Integer = 0
            If Not IsNothing(cm) Then
                currentPos = cm.Position
                If cm.Position >= 0 Then
                    rv = dv(currentPos)
                End If
            End If
            SearchData(GetColumnString("_code"))
            If id <> "" Then
                cm.Position = FindRowIndex(id)
            ElseIf Not IsNothing(rv) Then
                cm.Position = FindRowIndex(rv(GetColumnString("_id")).ToString)
            Else
                cm.Position = currentPos
            End If
            dgList.ScrollToRow(cm.Position)
            cm_CurrentChanged(cm, New EventArgs)
        End Sub
        Public Property SelectedEntity() As BusinessLogic.ISimpleEntity Implements ISimpleListPanel.SelectedEntity
            Get
                Return m_selectedEntity
            End Get
            Set(ByVal Value As BusinessLogic.ISimpleEntity)
                If m_selectedEntity Is Value Then
                    Return
                End If
                Me.m_selectedEntity = Value
                If Not m_selectedEntity Is Nothing Then
                    Me.RefreshData(m_selectedEntity.Id.ToString)
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
                CType(Me.WorkbenchWindow.SubViewContents(1), ISimpleEntityPanel).Entity = Me.m_selectedEntity
            End If
        End Sub
        Public Overrides Sub Selected()
            Me.RefreshData(Me.SelectedEntity.Id.ToString)
            Me.TitleName = Me.StringParserService.Parse(m_entity.ListPanelTitle)
        End Sub
#End Region

    End Class
End Namespace

