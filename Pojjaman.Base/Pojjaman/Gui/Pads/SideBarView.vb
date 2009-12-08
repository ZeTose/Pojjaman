Imports System.Windows.Forms
Imports System.ComponentModel.Design
Imports Longkong.Core.Services
Imports Longkong.Core.Properties
Imports System.Drawing
Imports Longkong.Pojjaman.Services
Imports System.IO
Imports System.Reflection
Imports System.Xml
Imports System.Text
Imports System.Threading
Imports Longkong.Pojjaman.Gui.Components
Imports Longkong.CustomControl
Imports Longkong.Core
Namespace Longkong.Pojjaman.Gui.Pads
    Public Class SideBarView
        Implements IPadContent

#Region "Members"
        Private m_category As String
        Private m_resourceService As ResourceService
        Private m_shortcut As String()
        Public Shared SideBar As PojjamanSideBar = Nothing
        Private m_StringParserService As StringParserService
        Private m_dockAreas As String()
#End Region

#Region "Constructors"
        Public Sub New()
            Me.m_resourceService = CType(ServiceManager.Services.GetService(GetType(Longkong.Core.Services.IResourceService)), ResourceService)
            Me.m_StringParserService = CType(ServiceManager.Services.GetService(GetType(StringParserService)), StringParserService)
            Try
                Dim doc As New XmlDocument
                Dim myPropertyService As PropertyService = CType(ServiceManager.Services.GetService(GetType(PropertyService)), PropertyService)
                doc.Load((myPropertyService.ConfigDirectory & "SideBarConfig.xml"))
                If ((doc.DocumentElement.Attributes.ItemOf("version") Is Nothing) OrElse (Not doc.DocumentElement.Attributes("version").InnerText = "1.0")) Then
                    Me.GenerateStandardSideBar()
                Else
                    SideBarView.SideBar = New PojjamanSideBar(doc.DocumentElement.Item("SideBar"))
                End If
            Catch ex As Exception
                Me.GenerateStandardSideBar()
            End Try
            Me.GenerateStandardSideBar()
            SideBarView.SideBar.Dock = DockStyle.Fill
        End Sub
#End Region

#Region "Methods"
        Private Sub GenerateStandardSideBar()
            SideBarView.SideBar = New PojjamanSideBar
            Dim tab As New VSSideTab(SideBarView.SideBar, Me.m_StringParserService.Parse("${res:Pojjaman.SideBar.GeneralCategory}"))
            SideBarView.SideBar.Tabs.Add(tab)
            SideBarView.SideBar.ActiveTab = tab
            tab = New VSSideTab(SideBarView.SideBar, Me.m_StringParserService.Parse("${res:Pojjaman.SideBar.ClipboardRing}"))
            tab.IsClipboardRing = True
            tab.CanBeDeleted = False
            tab.CanDragDrop = False
            SideBarView.SideBar.Tabs.Add(tab)
        End Sub
        Protected Overridable Sub OnIconChanged(ByVal e As EventArgs)
            RaiseEvent IconChanged(Me, e)
        End Sub
        Protected Overridable Sub OnTitleChanged(ByVal e As EventArgs)
            RaiseEvent TitleChanged(Me, e)
        End Sub
        Public Shared Sub PutInClipboardRing(ByVal [text] As String)
            If (Not SideBarView.sideBar Is Nothing) Then
                SideBarView.SideBar.PutInClipboardRing(text)
                SideBarView.SideBar.Refresh()
            End If
        End Sub
        Public Sub SaveSideBarViewConfig()
            Dim doc As New XmlDocument
            doc.LoadXml("<SideBarConfig version=""1.0""/>")
            doc.DocumentElement.AppendChild(SideBarView.SideBar.ToXmlElement(doc))
            Dim myPropertyService As PropertyService = CType(ServiceManager.Services.GetService(GetType(PropertyService)), PropertyService)
            Dim myFileUtilityService As FileUtilityService = CType(ServiceManager.Services.GetService(GetType(FileUtilityService)), FileUtilityService)
            myFileUtilityService.ObservedSave(New NamedFileOperationDelegate(AddressOf doc.Save), (myPropertyService.ConfigDirectory & "SideBarConfig.xml"), FileErrorPolicy.ProvideAlternative)
        End Sub
#End Region

#Region "IPadContent"
        Public Event TitleChanged(ByVal sender As Object, ByVal e As System.EventArgs) Implements IPadContent.TitleChanged
        Public Event IconChanged(ByVal sender As Object, ByVal e As System.EventArgs) Implements IPadContent.IconChanged

        Public ReadOnly Property HideOnClose() As Boolean Implements IPadContent.HideOnClose
            Get
                Return True
            End Get
        End Property
        Public Sub BringPadToFront() Implements IPadContent.BringPadToFront
            If Not WorkbenchSingleton.Workbench.WorkbenchLayout.IsVisible(Me) Then
                WorkbenchSingleton.Workbench.WorkbenchLayout.ShowPad(Me)
            End If
            WorkbenchSingleton.Workbench.WorkbenchLayout.ActivatePad(Me)
        End Sub
        Public Property Category() As String Implements IPadContent.Category
            Get
                Return Me.m_category
            End Get
            Set(ByVal Value As String)
                Me.m_category = Value
            End Set
        End Property
        Public ReadOnly Property Control() As System.Windows.Forms.Control Implements IPadContent.Control
            Get
                Return SideBarView.SideBar
            End Get
        End Property

        Public ReadOnly Property Icon() As String Implements IPadContent.Icon
            Get
                Return "Icons.16x16.ToolBar"
            End Get
        End Property
        Public Sub RedrawContent() Implements IPadContent.RedrawContent
            Me.OnTitleChanged(Nothing)
            Me.OnIconChanged(Nothing)
            SideBarView.SideBar.Refresh()
        End Sub
        Public Property Shortcut() As String() Implements IPadContent.Shortcut
            Get
                Return Me.m_shortcut
            End Get
            Set(ByVal Value() As String)
                Me.m_shortcut = Value
            End Set
        End Property
        Public Property Title() As String Implements IPadContent.Title
            Get
                Return Me.m_resourceService.GetString("MainWindow.Windows.ToolbarLabel")
            End Get
            Set(ByVal Value As String)

            End Set
        End Property
        Public Sub Dispose() Implements System.IDisposable.Dispose
            Me.SaveSideBarViewConfig()
            SideBarView.SideBar.Dispose()
        End Sub
        Public Property DockAreas() As String() Implements IPadContent.DockAreas
            Get
                Return Me.m_dockAreas
            End Get
            Set(ByVal Value() As String)
                Me.m_dockAreas = Value
            End Set
        End Property
#End Region

    End Class
End Namespace

