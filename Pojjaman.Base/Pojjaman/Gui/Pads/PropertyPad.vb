Imports System.Windows.Forms
Imports System.ComponentModel.Design
Imports Longkong.Core.Services
Imports Longkong.Core.Properties
Imports System.Drawing
Imports System.ComponentModel
Imports Longkong.Pojjaman.Services
Imports Longkong.Pojjaman.Gui.Components
Namespace Longkong.Pojjaman.Gui.Pads
    Public Class PropertyPad
        Inherits AbstractPadContent

#Region "Members"
        Private Shared m_comboBox As PropertyComboBox = Nothing
        Private Shared m_grid As PropertyGrid = Nothing
        Private Shared m_host As IDesignerHost = Nothing
        Private Shared m_inUpdate As Boolean = False
        Private Shared m_panel As Panel = Nothing
        Private Shared m_shouldUpdateSelectableObjects As Boolean = False
#End Region

#Region "Events"
        Public Shared Event PropertyValueChanged As PropertyValueChangedEventHandler
        Public Shared Event SelectedObjectChanged As EventHandler
#End Region

#Region "Constructors"
        Public Sub New()
            MyBase.New("${res:MainWindow.Windows.PropertiesScoutLabel}", "Icons.16x16.PropertiesIcon")
            PropertyPad.m_panel = New Panel
            Dim myPropertyService As PropertyService = CType(ServiceManager.Services.GetService(GetType(PropertyService)), PropertyService)

            PropertyPad.m_comboBox = New PropertyComboBox
            PropertyPad.m_comboBox.Dock = DockStyle.Top
            PropertyPad.m_comboBox.DropDownStyle = ComboBoxStyle.DropDownList

            AddHandler PropertyPad.m_comboBox.SelectedIndexChanged, New EventHandler(AddressOf Me.ComboBoxSelectedIndexChanged)
            PropertyPad.m_comboBox.Sorted = True

            PropertyPad.m_grid = New PropertyGrid
            AddHandler PropertyPad.m_grid.PropertyValueChanged, New PropertyValueChangedEventHandler(AddressOf Me.PropertyChanged)
            PropertyPad.m_grid.PropertySort = CType(IIf(myPropertyService.GetProperty("FormsDesigner.DesignerOptions.PropertyGridSortAlphabetical", False), PropertySort.Alphabetical, PropertySort.CategorizedAlphabetical), PropertySort)
            PropertyPad.m_grid.Dock = DockStyle.Fill

            PropertyPad.m_panel.Controls.Add(PropertyPad.m_grid)
            PropertyPad.m_panel.Controls.Add(PropertyPad.m_comboBox)

            'Dim service2 As IProjectService = CType(ServiceManager.Services.GetService(GetType(IProjectService)), IProjectService)
            'AddHandler service2.CombineClosed, New CombineEventHandler(AddressOf Me.CombineClosedEvent)
            Dim myMenuService As MenuService = CType(ServiceManager.Services.GetService(GetType(MenuService)), MenuService)
            PropertyPad.m_grid.ContextMenu = myMenuService.CreateContextMenu(Me, "/Pojjaman/Views/PropertyPad/ContextMenu")
        End Sub
#End Region

#Region "Properties"
        Public Overrides ReadOnly Property Control() As System.Windows.Forms.Control
            Get
                Return PropertyPad.m_panel
            End Get
        End Property
        Public Shared ReadOnly Property Grid() As PropertyGrid
            Get
                Return PropertyPad.m_grid
            End Get
        End Property
#End Region

#Region "Methods"
        'Private Sub CombineClosedEvent(ByVal sender As Object, ByVal e As CombineEventArgs)
        '    PropertyPad.SetDesignableObjects(Nothing)
        'End Sub
        Private Sub ComboBoxDrawItem(ByVal sender As Object, ByVal dea As DrawItemEventArgs)
            If ((dea.Index < 0) OrElse (dea.Index >= PropertyPad.m_comboBox.Items.Count)) Then
                Return
            End If
            Dim g As Graphics = dea.Graphics
            Dim b As Brush = SystemBrushes.ControlText
            If ((dea.State And DrawItemState.Selected) = DrawItemState.Selected) Then
                If ((dea.State And DrawItemState.Focus) = DrawItemState.Focus) Then
                    g.FillRectangle(SystemBrushes.Highlight, dea.Bounds)
                    b = SystemBrushes.HighlightText
                Else
                    g.FillRectangle(SystemBrushes.Window, dea.Bounds)
                End If
            Else
                g.FillRectangle(SystemBrushes.Window, dea.Bounds)
            End If
            Dim obj As Object = PropertyPad.m_comboBox.Items(dea.Index)
            Dim xPos As Integer = dea.Bounds.X
            If TypeOf obj Is IComponent Then
                Dim site As ISite = CType(obj, IComponent).Site
                If (Not site Is Nothing) Then
                    Dim name As String = site.Name
                    Dim f As New Font(PropertyPad.m_comboBox.Font, FontStyle.Bold)
                    g.DrawString(name, f, b, CType(xPos, Single), CType(dea.Bounds.Y, Single))
                    Dim ef1 As SizeF = g.MeasureString((name & "-"), f)
                    xPos = (xPos + CType(ef1.Width, Integer))
                End If
            End If
            Dim typeString As String = obj.GetType.ToString
            g.DrawString(typeString, PropertyPad.m_comboBox.Font, b, CType(xPos, Single), CType(dea.Bounds.Y, Single))
        End Sub
        Private Sub ComboBoxMeasureItem(ByVal sender As Object, ByVal mea As MeasureItemEventArgs)
            If ((mea.Index < 0) OrElse (mea.Index >= PropertyPad.m_comboBox.Items.Count)) Then
                mea.ItemHeight = PropertyPad.m_comboBox.Font.Height
            Else
                Dim obj As Object = PropertyPad.m_comboBox.Items(mea.Index)
                Dim size As SizeF = mea.Graphics.MeasureString(obj.GetType.ToString, PropertyPad.m_comboBox.Font)
                mea.ItemHeight = CType(size.Height, Integer)
                mea.ItemWidth = CType(size.Width, Integer)
                If TypeOf obj Is IComponent Then
                    Dim site As ISite = CType(obj, IComponent).Site
                    If (Not site Is Nothing) Then
                        Dim name As String = site.Name
                        Dim f As New Font(PropertyPad.m_comboBox.Font, FontStyle.Bold)
                        mea.ItemWidth = (mea.ItemWidth + CType(mea.Graphics.MeasureString(name + "-", f).Width, Integer))
                    End If
                End If
            End If
        End Sub
        Private Sub ComboBoxSelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs)
            If PropertyPad.m_inUpdate Then
                Return
            End If
            If (Not PropertyPad.m_host Is Nothing) Then
                Dim selectionService As ISelectionService = CType(PropertyPad.m_host.GetService(GetType(ISelectionService)), ISelectionService)
                If (PropertyPad.m_comboBox.SelectedIndex >= 0) Then
                    selectionService.SetSelectedComponents(New Object() {PropertyPad.m_comboBox.Items(PropertyPad.m_comboBox.SelectedIndex)})
                Else
                    PropertyPad.SetDesignableObject(Nothing)
                    selectionService.SetSelectedComponents(New Object() {})
                End If
            End If
            RaiseEvent SelectedObjectChanged(Me, EventArgs.Empty)
        End Sub
        Public Overrides Sub Dispose()
            MyBase.Dispose()
            If (PropertyPad.m_grid Is Nothing) Then
                Return
            End If
            Try
                PropertyPad.m_grid.SelectedObjects = Nothing
            Catch ex As Exception
            End Try
            PropertyPad.m_grid.Dispose()
            PropertyPad.m_grid = Nothing
        End Sub
        Private Sub OnPropertyValueChanged(ByVal sender As Object, ByVal e As PropertyValueChangedEventArgs)
            RaiseEvent PropertyValueChanged(sender, e)
        End Sub
        Private Sub PropertyChanged(ByVal sender As Object, ByVal e As PropertyValueChangedEventArgs)
            Me.OnPropertyValueChanged(sender, e)
        End Sub
        Public Overrides Sub RedrawContent()
            PropertyPad.m_grid.Refresh()
        End Sub
        Public Shared Sub RemoveHost(ByVal host As IDesignerHost)
            PropertyPad.m_host = Nothing
            PropertyPad.m_grid.Site = Nothing
            PropertyPad.SetDesignableObject(Nothing)
            Dim selectionService As ISelectionService = CType(host.GetService(GetType(ISelectionService)), ISelectionService)
            If (Not selectionService Is Nothing) Then
                RemoveHandler selectionService.SelectionChanging, New EventHandler(AddressOf PropertyPad.SelectionChangingHandler)
                RemoveHandler selectionService.SelectionChanged, New EventHandler(AddressOf PropertyPad.SelectionChangedHandler)
            End If
            RemoveHandler host.TransactionClosed, New DesignerTransactionCloseEventHandler(AddressOf PropertyPad.TransactionClose)
            Dim componentChangeService As IComponentChangeService = CType(host.GetService(GetType(IComponentChangeService)), IComponentChangeService)
            If (Not componentChangeService Is Nothing) Then
                RemoveHandler componentChangeService.ComponentAdded, New ComponentEventHandler(AddressOf PropertyPad.UpdateSelectedObjects)
                RemoveHandler componentChangeService.ComponentRemoved, New ComponentEventHandler(AddressOf PropertyPad.UpdateSelectedObjects)
                RemoveHandler componentChangeService.ComponentRename, New ComponentRenameEventHandler(AddressOf PropertyPad.UpdateSelectedObjectsOnRename)
            End If
        End Sub
        Private Shared Sub SelectedObjectsChanged()
            If ((Not PropertyPad.m_grid.SelectedObjects Is Nothing) AndAlso (PropertyPad.m_grid.SelectedObjects.Length = 1)) Then
                For i As Integer = 0 To PropertyPad.m_comboBox.Items.Count - 1
                    If (PropertyPad.m_grid.SelectedObject Is PropertyPad.m_comboBox.Items.Item(i)) Then
                        PropertyPad.m_comboBox.SelectedIndex = i
                        Exit For
                    End If
                Next
            Else
                PropertyPad.m_comboBox.SelectedIndex = -1
            End If
        End Sub
        Public Shared Sub SelectionChangedHandler(ByVal sender As Object, ByVal args As EventArgs)
            Dim selectionService As ISelectionService = CType(sender, ISelectionService)
            If (selectionService Is Nothing) Then
                Return
            End If
            Dim coll As ICollection = selectionService.GetSelectedComponents
            Dim selectedObjects As Object() = New Object(coll.Count - 1) {}
            coll.CopyTo(selectedObjects, 0)
            PropertyPad.m_inUpdate = True
            Try
                PropertyPad.m_grid.SelectedObjects = selectedObjects
                PropertyPad.SelectedObjectsChanged()
            Catch ex As Exception
                Return
            Finally
                PropertyPad.m_inUpdate = False
            End Try
        End Sub
        Public Shared Sub SelectionChangingHandler(ByVal sender As Object, ByVal args As EventArgs)
        End Sub
        Public Shared Sub SetDesignableObject(ByVal obj As Object)
            PropertyPad.m_grid.SelectedObject = obj
            PropertyPad.SelectedObjectsChanged()
        End Sub
        Public Shared Sub SetDesignableObjects(ByVal objs As Object())
            PropertyPad.m_grid.SelectedObjects = objs
            PropertyPad.SelectedObjectsChanged()
        End Sub
        Public Shared Sub SetDesignerHost(ByVal host As IDesignerHost)
            PropertyPad.m_host = host
            If (Not host Is Nothing) Then
                PropertyPad.m_grid.Site = New IDEContainer(host).CreateSite(PropertyPad.m_grid)
                PropertyPad.m_grid.PropertyTabs.AddTabType(GetType(System.Windows.Forms.Design.EventsTab), PropertyTabScope.Document)
                Dim selectionService As ISelectionService = CType(host.GetService(GetType(ISelectionService)), ISelectionService)
                If (Not selectionService Is Nothing) Then
                    AddHandler selectionService.SelectionChanging, New EventHandler(AddressOf PropertyPad.SelectionChangingHandler)
                    AddHandler selectionService.SelectionChanged, New EventHandler(AddressOf PropertyPad.SelectionChangedHandler)
                End If
                AddHandler host.TransactionClosed, New DesignerTransactionCloseEventHandler(AddressOf PropertyPad.TransactionClose)
                Dim componentChangeService As IComponentChangeService = CType(host.GetService(GetType(IComponentChangeService)), IComponentChangeService)
                If (Not componentChangeService Is Nothing) Then
                    AddHandler componentChangeService.ComponentAdded, New ComponentEventHandler(AddressOf PropertyPad.UpdateSelectedObjects)
                    AddHandler componentChangeService.ComponentRemoved, New ComponentEventHandler(AddressOf PropertyPad.UpdateSelectedObjects)
                    AddHandler componentChangeService.ComponentRename, New ComponentRenameEventHandler(AddressOf PropertyPad.UpdateSelectedObjectsOnRename)
                End If
            Else
                PropertyPad.m_grid.Site = Nothing
            End If
        End Sub
        Public Shared Sub SetSelectableObjects(ByVal coll As ICollection)
            PropertyPad.m_inUpdate = True
            Try
                PropertyPad.m_comboBox.Items.Clear()
                If (Not coll Is Nothing) Then
                    For Each obj As Object In coll
                        PropertyPad.m_comboBox.Items.Add(obj)
                    Next
                End If
                PropertyPad.SelectedObjectsChanged()
            Finally
                PropertyPad.m_inUpdate = False
            End Try
        End Sub
        Public Sub ShowHelp()
            If (Not PropertyPad.m_host Is Nothing) Then
                Dim helpService As IHelpService = CType(PropertyPad.m_host.GetService(GetType(IHelpService)), IHelpService)
                helpService.ShowHelpFromKeyword(Nothing)
            End If
        End Sub
        Private Shared Sub TransactionClose(ByVal sender As Object, ByVal e As DesignerTransactionCloseEventArgs)
            If Not PropertyPad.m_shouldUpdateSelectableObjects Then
                Return
            End If
            If (Not PropertyPad.m_host Is Nothing) Then
                PropertyPad.SetSelectableObjects(PropertyPad.m_host.Container.Components)
            End If
            PropertyPad.m_shouldUpdateSelectableObjects = False
        End Sub
        Private Shared Sub UpdateSelectedObjects(ByVal sender As Object, ByVal e As ComponentEventArgs)
            PropertyPad.m_shouldUpdateSelectableObjects = True
        End Sub
        Private Shared Sub UpdateSelectedObjectsOnRename(ByVal sender As Object, ByVal e As ComponentRenameEventArgs)
            PropertyPad.m_shouldUpdateSelectableObjects = True
        End Sub
#End Region

    End Class

End Namespace

