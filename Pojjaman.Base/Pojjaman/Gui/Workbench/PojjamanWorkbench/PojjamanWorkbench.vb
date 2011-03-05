Imports Longkong.Pojjaman.Services
Imports Longkong.Core.AddIns
Imports Longkong.Core.Services
Imports Longkong.Core.Properties
Imports Longkong.Core
Imports System.IO
Imports System.Xml
Imports System.ComponentModel
Imports Longkong.Pojjaman.Gui.Components
Imports Longkong.Pojjaman.Gui.Pads
Imports Longkong.Pojjaman.Gui.Panels
Imports Longkong.Pojjaman.PanelDisplayBinding
Imports Longkong.Pojjaman.BusinessLogic
Imports System.Reflection
Imports Longkong.Pojjaman.DataAccessLayer
Imports System.Runtime.InteropServices
Imports System.Globalization
'Imports Microsoft.WindowsAPICodePack.Taskbar

Namespace Longkong.Pojjaman.Gui
  Public Class PojjamanWorkbench
    Inherits Form
    Implements IWorkbench

#Region "Members"
    Public ToolBars As ToolStrip()
    Public TopMenu As System.Windows.Forms.MenuStrip
    Private m_defaultWindowState As FormWindowState
    Private m_normalBounds As Rectangle
    Private m_applicationMode As ApplicationMode
    Private m_fullscreen As Boolean

    Private m_closeAll As Boolean

    Private m_layout As IWorkbenchLayout

    Private Shared ReadOnly m_mainMenuPath As String = "/Pojjaman/Workbench/MainMenu"
    Protected Shared m_propertyService As PropertyService = CType(ServiceManager.Services.GetService(GetType(PropertyService)), PropertyService)
    Private m_SecurityService As SecurityService

    Private m_viewContentCollection As ViewContentCollection
#End Region

#Region "Events"
    Private windowChangeEventHandler As EventHandler
    Friend WithEvents TestToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents CheckBoxToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AsasToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AsasasToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripButton1 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripButton2 As System.Windows.Forms.ToolStripButton
    Private ActiveWorkbenchWindowChangedHandler As EventHandler
#End Region

#Region "Constructors"
    Public Sub New()
      Me.m_viewContentCollection = New ViewContentCollection
      Me.m_closeAll = False
      Me.m_defaultWindowState = FormWindowState.Normal
      Me.m_normalBounds = New Rectangle(0, 0, 1024, 768)
      Me.m_layout = Nothing
      Dim myResourceService As ResourceService = CType(ServiceManager.Services.GetService(GetType(IResourceService)), ResourceService)
      Me.Text = GetDialogName()
      MyBase.Icon = myResourceService.GetIcon("Icons.PojjamanIcon")
      MyBase.StartPosition = FormStartPosition.Manual
      Me.AllowDrop = True
      Me.windowChangeEventHandler = New EventHandler(AddressOf Me.OnActiveWindowChanged)
    End Sub
    Private Function GetDialogName() As String
      Dim pjmVersion As Version = [Assembly].GetEntryAssembly.GetName.Version
      Dim pjmVersionArray As Object() = New Object() {pjmVersion.Major, ".", pjmVersion.Minor.ToString("00"), ".", pjmVersion.Build.ToString("0000")}
      Dim version As String = String.Concat(pjmVersionArray)
      Dim myResourceService As ResourceService = CType(ServiceManager.Services.GetService(GetType(IResourceService)), ResourceService)
      Dim ret As String = ""
      If Not Me.SecurityService Is Nothing AndAlso Not Me.SecurityService.CurrentUser Is Nothing AndAlso Me.SecurityService.CurrentUser.Originated Then
        ret = myResourceService.GetString("MainWindow.DialogName") & " (" & Me.SecurityService.CurrentUser.Name & ": " & Configuration.GetConfig("CompanyName").ToString & ")"
        Dim dbVersion As String = SqlHelper.GetVersion
        ret &= ":DB=" & dbVersion
      Else
        ret = myResourceService.GetString("MainWindow.DialogName")
      End If
      If Longkong.Pojjaman.BusinessLogic.Configuration.CheckGigaSiteRight Then
        ret &= ":Gigasite=" & version
      Else
      ret &= ":PJM=" & version
      End If
      Return ret
    End Function
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
      If disposing Then

      End If
      MyBase.Dispose(disposing)
    End Sub
#End Region

#Region "Properties"
    Public Property FullScreen() As Boolean
      Get
        Return Me.m_fullscreen
      End Get
      Set(ByVal value As Boolean)
        Me.m_fullscreen = value
        If Me.m_fullscreen Then
          Me.m_defaultWindowState = MyBase.WindowState
          MyBase.Visible = False
          MyBase.FormBorderStyle = FormBorderStyle.None
          MyBase.WindowState = FormWindowState.Maximized
          MyBase.Visible = True
        Else
          MyBase.FormBorderStyle = FormBorderStyle.Sizable
          MyBase.Bounds = Me.m_normalBounds
          MyBase.WindowState = Me.m_defaultWindowState
        End If
      End Set
    End Property
    Public ReadOnly Property SecurityService() As SecurityService
      Get
        If m_SecurityService Is Nothing Then
          m_SecurityService = (CType(ServiceManager.Services.GetService(GetType(SecurityService)), SecurityService))
        End If
        Return m_SecurityService
      End Get
    End Property
#End Region

#Region "Methods"
    Public Sub RefreshMenus() Implements IWorkbench.RefreshMenus
      Me.Controls.AddRange(Me.ToolBars)
      Me.Controls.Add(Me.TopMenu)
      Me.MainMenuStrip = Me.TopMenu
    End Sub
    Private Sub CreateMainMenu()
      Me.TopMenu = New MenuStrip
      Dim items As ToolStripItem() = CType(AddInTreeSingleton.AddInTree.GetTreeNode(PojjamanWorkbench.m_mainMenuPath).BuildChildItems(Me).ToArray(GetType(ToolStripItem)), ToolStripItem())
      Me.TopMenu.LayoutStyle = ToolStripLayoutStyle.Flow
      Me.TopMenu.Items.AddRange(items)
    End Sub
    Private Sub CreateToolBars()
      If (Me.ToolBars Is Nothing) Then
        Dim myToolbarService As ToolbarService = CType(ServiceManager.Services.GetService(GetType(ToolbarService)), ToolbarService)
        Dim bars As ToolStrip() = myToolbarService.CreateToolbars
        Me.ToolBars = bars
      End If
    End Sub
    Public Function GetStoredMemento(ByVal content As IViewContent) As IXmlConvertable
      If ((Not content Is Nothing) AndAlso (Not content.FileName Is Nothing)) Then
        Dim myPropertyService As PropertyService = CType(ServiceManager.Services.GetService(GetType(PropertyService)), PropertyService)
        Dim appDirectory As String = (myPropertyService.ConfigDirectory & "temp")
        If Not Directory.Exists(appDirectory) Then
          Directory.CreateDirectory(appDirectory)
        End If
        Dim fileName As String = content.FileName.Substring(3).Replace("/"c, "."c).Replace("\"c, "."c).Replace(Path.DirectorySeparatorChar, "."c)
        Dim fullFileName As String = (appDirectory & Path.DirectorySeparatorChar & fileName)
        Dim myFileUtilityService As FileUtilityService = CType(ServiceManager.Services.GetService(GetType(FileUtilityService)), FileUtilityService)
        If (myFileUtilityService.IsValidFileName(fullFileName) AndAlso File.Exists(fullFileName)) Then
          Dim prototype As IXmlConvertable = CType(content, IMementoCapable).CreateMemento
          Dim doc As New XmlDocument
          doc.Load(fullFileName)
          Return CType(prototype.FromXmlElement(CType(doc.DocumentElement.ChildNodes.ItemOf(0), XmlElement)), IXmlConvertable)
        End If
      End If
      Return Nothing
    End Function
    Public Sub InitializeWorkspace()
      MyBase.Menu = Nothing
      Me.m_applicationMode = ApplicationMode.Accounting

      Me.ActiveWorkbenchWindowChangedHandler = CType([Delegate].Combine(Me.ActiveWorkbenchWindowChangedHandler, New EventHandler(AddressOf Me.UpdateMenu)), EventHandler)
      AddHandler ActiveWorkbenchWindowChanged, Me.ActiveWorkbenchWindowChangedHandler

      AddHandler MyBase.MenuComplete, New EventHandler(AddressOf Me.SetStandardStatusBar)
      Me.SetStandardStatusBar(Nothing, Nothing)
      Me.CreateMainMenu()
      Me.CreateToolBars()
    End Sub
    Private Sub OnActiveWindowChanged(ByVal sender As Object, ByVal e As EventArgs)
      If (Not Me.m_closeAll AndAlso (Not Me.ActiveWorkbenchWindowChangedHandler Is Nothing)) Then
        Me.ActiveWorkbenchWindowChangedHandler(Me, e)
      End If
    End Sub
    Protected Overrides Sub OnClosed(ByVal e As EventArgs)
      MyBase.OnClosed(e)
      If Not shutDownTM Is Nothing Then
        shutDownTM.Stop()
      End If
      Me.m_closeAll = True
      Me.m_layout.Detach()
    End Sub
    Private Sub ForceCloseTimerTick(ByVal sender As Object, ByVal e As EventArgs)
      If WorkbenchSingleton.Workbench.ViewContentCollection.Count = 0 Then
        OnClosed(e)
        Application.Exit()
      End If
    End Sub
    Private shutDownTM As Timer
    Protected Overrides Sub OnClosing(ByVal e As CancelEventArgs)
      Try
        MyBase.OnClosing(e)
        shutDownTM = New Timer
        shutDownTM.Interval = 500
        AddHandler shutDownTM.Tick, AddressOf ForceCloseTimerTick
        shutDownTM.Start()
        Do While (WorkbenchSingleton.Workbench.ViewContentCollection.Count > 0)
          Dim content As IViewContent = WorkbenchSingleton.Workbench.ViewContentCollection.Item(0)
          content.WorkbenchWindow.CloseWindow(False)
          If (WorkbenchSingleton.Workbench.ViewContentCollection.IndexOf(content) >= 0) Then
            e.Cancel = True
            Return
          End If
        Loop
      Catch ex As Exception
        MessageBox.Show(ex.ToString)
      End Try
    End Sub
    Protected Overrides Sub OnDragDrop(ByVal e As DragEventArgs)
      MyBase.OnDragDrop(e)
      If ((e.Data Is Nothing) OrElse Not e.Data.GetDataPresent(DataFormats.FileDrop)) Then
        Return
      End If
      Dim files As String() = CType(e.Data.GetData(DataFormats.FileDrop), String())
      Dim myFileService As IFileService = CType(ServiceManager.Services.GetService(GetType(IFileService)), IFileService)
      For Each file As String In files
        If System.IO.File.Exists(file) Then
          Try
            myFileService.OpenFile(file)
          Catch ex As Exception
            Debug.WriteLine(ex.Message)
          End Try

        End If
      Next
    End Sub
    Protected Overrides Sub OnDragEnter(ByVal e As DragEventArgs)
      MyBase.OnDragEnter(e)
      If ((Not e.Data Is Nothing) AndAlso e.Data.GetDataPresent(DataFormats.FileDrop)) Then
        Dim files As String() = CType(e.Data.GetData(DataFormats.FileDrop), String())
        For Each file As String In files
          If System.IO.File.Exists(file) Then
            e.Effect = DragDropEffects.Copy
            Return
          End If
        Next
      End If
      e.Effect = DragDropEffects.None
    End Sub
    Protected Overrides Sub OnLocationChanged(ByVal e As EventArgs)
      MyBase.OnLocationChanged(e)
      If (MyBase.WindowState = FormWindowState.Normal) Then
        Me.m_normalBounds = MyBase.Bounds
      End If
    End Sub
    Protected Overrides Sub OnResize(ByVal e As EventArgs)
      MyBase.OnResize(e)
      If (MyBase.WindowState = FormWindowState.Normal) Then
        Me.m_normalBounds = MyBase.Bounds
      End If
    End Sub
    Protected Overridable Sub OnViewClosed(ByVal e As ViewContentEventArgs)
      '=========================Windows 7================================
      Try
        ' Add a new preview
        'Dim preview As New TabbedThumbnail(Me.Parent.Handle, Me.Handle)

        '' Event handlers for this preview
        'AddHandler preview.TabbedThumbnailActivated, AddressOf preview_TabbedThumbnailActivated
        'AddHandler preview.TabbedThumbnailClosed, AddressOf preview_TabbedThumbnailClosed
        'AddHandler preview.TabbedThumbnailMaximized, AddressOf preview_TabbedThumbnailMaximized
        'AddHandler preview.TabbedThumbnailMinimized, AddressOf preview_TabbedThumbnailMinimized

        'TaskbarManager.Instance.TabbedThumbnail.RemoveThumbnailPreview(CType(e.Content, UserControl))
      Catch ex As PlatformNotSupportedException
        'Not Windows 7
      Catch

      End Try
      '=========================Windows 7================================

      RaiseEvent ViewClosed(Me, e)
    End Sub
    Protected Overridable Sub OnViewOpened(ByVal e As ViewContentEventArgs)
      '=========================Windows 7================================
      'Try
      '' Add a new preview
      'Dim preview As New TabbedThumbnail(Me.Handle, CType(e.Content, UserControl).Handle)

      'preview.Title = e.Content.TitleName

      ' '' Event handlers for this preview
      'AddHandler preview.TabbedThumbnailActivated, AddressOf preview_TabbedThumbnailActivated
      'AddHandler preview.TabbedThumbnailClosed, AddressOf preview_TabbedThumbnailClosed
      ''AddHandler preview.TabbedThumbnailMaximized, AddressOf preview_TabbedThumbnailMaximized
      ''AddHandler preview.TabbedThumbnailMinimized, AddressOf preview_TabbedThumbnailMinimized

      'TaskbarManager.Instance.TabbedThumbnail.AddThumbnailPreview(preview)
      'Catch ex As PlatformNotSupportedException
      ''Not Windows 7
      'Catch
      'End Try
      '=========================Windows 7================================
      RaiseEvent ViewOpened(Me, e)
    End Sub
    'Private Sub preview_TabbedThumbnailActivated(ByVal sender As Object, ByVal e As TabbedThumbnailEventArgs)
    '' User selected a tab via the thumbnail preview
    '' Select the corresponding content
    'Dim theContent As IViewContent
    'For Each content As IViewContent In Me.ViewContentCollection
    'If CType(content, UserControl).Handle = e.WindowHandle Then
    '' Select the tab in the application UI as well as taskbar tabbed thumbnail list
    'theContent = content
    'Exit For
    'End If
    'Next

    'If Not theContent Is Nothing Then
    'theContent.WorkbenchWindow.SelectWindow()
    'End If
    '' Also activate our parent form (incase we are minimized, this will restore it)
    'If Me.WindowState = FormWindowState.Minimized Then
    'Me.WindowState = FormWindowState.Normal
    'End If
    'End Sub
    'Private Sub preview_TabbedThumbnailClosed(ByVal sender As Object, ByVal e As TabbedThumbnailEventArgs)
    '' User selected a tab via the thumbnail preview
    '' Close the corresponding content
    'Try
    'Dim theContent As IViewContent
    'For Each content As IViewContent In Me.ViewContentCollection
    'If CType(content, UserControl).Handle = e.WindowHandle Then
    '' Select the tab in the application UI as well as taskbar tabbed thumbnail list
    'theContent = content
    'Exit For
    'End If
    'Next
    'If Not theContent Is Nothing Then
    'theContent.WorkbenchWindow.CloseWindow(False)
    'End If
    'Catch ex As Exception

    'End Try
    'End Sub
    Protected Overrides Function ProcessCmdKey(ByRef msg As Message, ByVal keyData As Keys) As Boolean
      'If Me.m_commandBarManager.PreProcessMessage(msg) Then
      'Return True
      'End If
      Return MyBase.ProcessCmdKey(msg, keyData)
    End Function
    Private Sub SetStandardStatusBar(ByVal sender As Object, ByVal e As EventArgs)
      Dim myStatusBarService As IStatusBarService = CType(ServiceManager.Services.GetService(GetType(IStatusBarService)), IStatusBarService)
      myStatusBarService.RefreshLanguage()
      myStatusBarService.SetMessage("${res:MainWindow.StatusBar.ReadyMessage}")
    End Sub
    Private Sub PojjamanWorkbench_InputLanguageChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.InputLanguageChangedEventArgs) Handles MyBase.InputLanguageChanged
      Dim myStatusBarService As IStatusBarService = CType(ServiceManager.Services.GetService(GetType(IStatusBarService)), IStatusBarService)
      myStatusBarService.RefreshLanguage()
    End Sub
    Public Sub StoreMemento(ByVal content As IViewContent)
      If (content.FileName Is Nothing) Then
        Return
      End If
      Dim myPropertyService As PropertyService = CType(ServiceManager.Services.GetService(GetType(PropertyService)), PropertyService)
      Dim myDirectory As String = (myPropertyService.ConfigDirectory & "temp")
      If Not Directory.Exists(myDirectory) Then
        Directory.CreateDirectory(myDirectory)
      End If

      Dim doc As New XmlDocument
      doc.LoadXml("<?xml version=""1.0""?>" & ChrW(10) & "<Mementoable/>")

      Dim fileAttribute As XmlAttribute = doc.CreateAttribute("file")
      fileAttribute.InnerText = content.FileName
      doc.DocumentElement.Attributes.Append(fileAttribute)

      Dim memento As IXmlConvertable = CType(content, IMementoCapable).CreateMemento

      doc.DocumentElement.AppendChild(memento.ToXmlElement(doc))

      Dim fileName As String = content.FileName.Substring(3).Replace("/"c, "."c).Replace("\"c, "."c).Replace(Path.DirectorySeparatorChar, "."c)
      Dim myFileUtilityService As FileUtilityService = CType(ServiceManager.Services.GetService(GetType(FileUtilityService)), FileUtilityService)
      Dim fullFileName As String = (myDirectory & Path.DirectorySeparatorChar & fileName)
      If myFileUtilityService.IsValidFileName(fullFileName) Then
        myFileUtilityService.ObservedSave(New NamedFileOperationDelegate(AddressOf doc.Save), fullFileName, FileErrorPolicy.ProvideAlternative)
      End If
      doc.RemoveAll()
    End Sub
    Private Sub UpdateMenu(ByVal sender As Object, ByVal e As EventArgs)
      Me.UpdateMenus()
      Me.UpdateToolbars()
    End Sub
    Public Sub UpdateMenus()
      For Each item As Object In Me.TopMenu.Items
        If TypeOf item Is IStatusUpdate Then
          UpdateModeMenusOrToolBars(item)
          CType(item, IStatusUpdate).UpdateStatus()
        End If
      Next
    End Sub
    Private Sub UpdateModeMenusOrToolBars(ByVal item As Object)
      If TypeOf item Is Longkong.Pojjaman.Gui.Components.PJMMenuCheckBox Then
        If TypeOf CType(item, Longkong.Pojjaman.Gui.Components.PJMMenuCheckBox).Command Is Longkong.Pojjaman.Commands.AbstractModeCommand Then
          Dim menuCheckBox As Longkong.Pojjaman.Gui.Components.PJMMenuCheckBox = CType(item, Longkong.Pojjaman.Gui.Components.PJMMenuCheckBox)
          Dim cmd As Longkong.Pojjaman.Commands.AbstractModeCommand = CType(menuCheckBox.Command, Longkong.Pojjaman.Commands.AbstractModeCommand)
          If Me.MultiMode Then
            cmd.IsChecked = (Me.ApplicationMode And cmd.Mode) > Core.AddIns.ApplicationMode.None
          Else
            cmd.IsChecked = (Me.ApplicationMode = cmd.Mode)
          End If
        End If
      End If
      If TypeOf item Is Longkong.Pojjaman.Gui.Components.PJMMenu Then
        Dim menu As Longkong.Pojjaman.Gui.Components.PJMMenu = CType(item, Longkong.Pojjaman.Gui.Components.PJMMenu)
        For Each childItem As Object In menu.Items
          UpdateModeMenusOrToolBars(childItem)
        Next
      End If
    End Sub
    Public Sub UpdateToolbars()
      For Each bar As ToolStrip In Me.ToolBars
        For Each item As Object In bar.Items
          If TypeOf item Is IStatusUpdate Then
            UpdateModeMenusOrToolBars(item)
            CType(item, IStatusUpdate).UpdateStatus()
          End If
        Next
      Next
    End Sub
#End Region

#Region "IWorkbench"
    Public Event ActiveWorkbenchWindowChanged(ByVal sender As Object, ByVal e As System.EventArgs) Implements IWorkbench.ActiveWorkbenchWindowChanged
    Public Event ViewOpened(ByVal sender As Object, ByVal e As ViewContentEventArgs) Implements IWorkbench.ViewOpened
    Public Event ViewClosed(ByVal sender As Object, ByVal e As ViewContentEventArgs) Implements IWorkbench.ViewClosed

    Public Function CreateMemento() As IXmlConvertable Implements IMementoCapable.CreateMemento
      Dim memento As New WorkbenchMemento
      memento.Bounds = Me.m_normalBounds
      If Me.m_fullscreen Then
        memento.DefaultWindowState = Me.m_defaultWindowState
      Else
        memento.DefaultWindowState = MyBase.WindowState
      End If
      memento.WindowState = MyBase.WindowState
      memento.FullScreen = Me.m_fullscreen
      Return memento
    End Function
    Public Sub SetMemento(ByVal xmlMemento As IXmlConvertable) Implements IMementoCapable.SetMemento
      If (Not xmlMemento Is Nothing) Then
        Dim rectangle1 As Rectangle
        Dim memento As WorkbenchMemento = CType(xmlMemento, WorkbenchMemento)
        Me.m_normalBounds = memento.Bounds
        MyBase.Bounds = Me.m_normalBounds
        MyBase.WindowState = memento.WindowState
        Me.m_defaultWindowState = memento.DefaultWindowState
        Me.FullScreen = memento.FullScreen
      End If
    End Sub
    Public ReadOnly Property ActiveWorkbenchWindow() As IWorkbenchWindow Implements IWorkbench.ActiveWorkbenchWindow
      Get
        If (Me.m_layout Is Nothing) Then
          Return Nothing
        End If
        Return Me.m_layout.ActiveWorkbenchwindow
      End Get
    End Property
    Public Sub CloseAllViews() Implements IWorkbench.CloseAllViews
      Try
        Me.m_closeAll = True
        Dim fullList As New ViewContentCollection(Me.m_viewContentCollection)
        For Each content As IViewContent In fullList
          Dim window As IWorkbenchWindow = content.WorkbenchWindow
          window.CloseWindow(False)
        Next
      Finally
        Me.m_closeAll = False
        Me.OnActiveWindowChanged(Nothing, Nothing)
      End Try
    End Sub
    Public Sub CloseContent(ByVal content As IViewContent) Implements IWorkbench.CloseContent
      If (PojjamanWorkbench.m_propertyService.GetProperty("Pojjaman.LoadDocumentProperties", True) AndAlso TypeOf content Is IMementoCapable) Then
        Me.StoreMemento(content)
      End If
      If Me.ViewContentCollection.Contains(content) Then
        Me.ViewContentCollection.Remove(content)
      End If
      Me.OnViewClosed(New ViewContentEventArgs(content))
      content.Dispose()
      content = Nothing
    End Sub
    Public Function GetView(ByVal entity As BusinessLogic.ISimpleEntity) As IViewContent Implements IWorkbench.GetView
      For Each view As IViewContent In Me.ViewContentCollection
        If TypeOf view Is AbstractEntityPanelViewContent Then
          Dim myPanelView As AbstractEntityPanelViewContent = CType(view, AbstractEntityPanelViewContent)
          If TypeOf myPanelView.Control Is ISimpleEntityPanel Then
            Dim panelEntity As BusinessLogic.ISimpleEntity = CType(myPanelView.Control, ISimpleEntityPanel).Entity
            If CType(panelEntity, Object).GetType.FullName = CType(entity, Object).GetType.FullName Then
              Return view
            End If
          End If
        End If
      Next
    End Function
    Public Function GetView(ByVal entiyName As String) As IViewContent Implements IWorkbench.GetView
      'For Each view As IViewContent In Me.ViewContentCollection
      'If TypeOf view Is PanelView Then
      'Dim myPanelView As PanelView = CType(view, PanelView)
      'If TypeOf myPanelView.Control Is IEntityPanel Then
      'If CType(myPanelView.Control, IEntityPanel).Entity.ClassName = entiyName Then
      'Return view
      'End If
      'End If
      'End If
      'Next
    End Function
    Public Function GetView(ByVal type As System.Type) As IViewContent Implements IWorkbench.GetView
      'For Each view As IViewContent In Me.ViewContentCollection
      'If TypeOf view Is PanelView Then
      'Dim myPanelView As PanelView = CType(view, PanelView)
      'If myPanelView.Control.GetType.Equals(type) Then
      'Return view
      'End If
      'End If
      'Next
    End Function
    Public Sub RedrawEditComponents() Implements IWorkbench.RedrawEditComponents
      For Each item As Object In Me.TopMenu.Items
        If TypeOf item Is IStatusUpdate Then
          UpdateModeMenusOrToolBars(item)
          CType(item, IStatusUpdate).UpdateStatus()
        End If
      Next
      For Each bar As ToolStrip In Me.ToolBars
        For Each item As Object In bar.Items
          If TypeOf item Is IStatusUpdate Then
            UpdateModeMenusOrToolBars(item)
            CType(item, IStatusUpdate).UpdateStatus()
          End If
        Next
      Next
    End Sub
    Public Sub RedrawAllComponents() Implements IWorkbench.RedrawAllComponents
      Me.UpdateMenu(Nothing, Nothing)
      For Each content As IViewContent In Me.m_viewContentCollection
        content.RedrawContent()
        If (Not content.WorkbenchWindow Is Nothing) Then
          content.WorkbenchWindow.RedrawContent()
        End If
      Next
      Me.Text = Me.GetDialogName
    End Sub
    Public Sub ShowView(ByVal content As IViewContent) Implements IWorkbench.ShowView
      Me.ViewContentCollection.Add(content)
      If (PojjamanWorkbench.m_propertyService.GetProperty("Pojjaman.LoadDocumentProperties", True) AndAlso TypeOf content Is IMementoCapable) Then
        Try
          Dim memento As IXmlConvertable = Me.GetStoredMemento(content)
          If (Not memento Is Nothing) Then
            CType(content, IMementoCapable).SetMemento(memento)
          End If
        Catch ex As Exception
          Console.WriteLine(("Can't get/set memento : " & ex.ToString))
        End Try
      End If
      Me.m_layout.ShowView(content)
      content.WorkbenchWindow.SelectWindow()
      Me.OnViewOpened(New ViewContentEventArgs(content))
    End Sub
    Public Property Title() As String Implements IWorkbench.Title
      Get
        Return Me.Text
      End Get
      Set(ByVal value As String)
        Me.Text = value
      End Set
    End Property
    Public ReadOnly Property ViewContentCollection() As ViewContentCollection Implements IWorkbench.ViewContentCollection
      Get
        Return Me.m_viewContentCollection
      End Get
    End Property
    Public Property WorkbenchLayout() As IWorkbenchLayout Implements IWorkbench.WorkbenchLayout
      Get
        Return Me.m_layout
      End Get
      Set(ByVal value As IWorkbenchLayout)
        If (Not Me.m_layout Is Nothing) Then
          RemoveHandler Me.m_layout.ActiveWorkbenchWindowChanged, Me.windowChangeEventHandler
          Me.m_layout.Detach()
        End If
        value.Attach(Me)
        Me.m_layout = value
        AddHandler Me.m_layout.ActiveWorkbenchWindowChanged, Me.windowChangeEventHandler
      End Set
    End Property
    Public Property ApplicationMode() As ApplicationMode Implements IWorkbench.ApplicationMode
      Get
        Return m_applicationMode
      End Get
      Set(ByVal Value As ApplicationMode)
        If m_applicationMode <> Value Then
          m_applicationMode = Value
          Me.UpdateMenus()
          Me.UpdateToolbars()
        End If
      End Set
    End Property
    Public Property MultiMode() As Boolean Implements IWorkbench.MultiMode
      Get
        'Todo
        Return False
      End Get
      Set(ByVal Value As Boolean)

      End Set
    End Property
#End Region

    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents FileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Private Sub InitializeComponent()
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(PojjamanWorkbench))
      Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
      Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
      Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator()
      Me.AsasToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
      Me.AsasasToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
      Me.TestToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
      Me.CheckBoxToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
      Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
      Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton()
      Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
      Me.ToolStripButton2 = New System.Windows.Forms.ToolStripButton()
      Me.MenuStrip1.SuspendLayout()
      Me.ToolStrip1.SuspendLayout()
      Me.SuspendLayout()
      '
      'MenuStrip1
      '
      Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.TestToolStripMenuItem})
      Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
      Me.MenuStrip1.Name = "MenuStrip1"
      Me.MenuStrip1.Size = New System.Drawing.Size(705, 24)
      Me.MenuStrip1.TabIndex = 0
      Me.MenuStrip1.Text = "MenuStrip1"
      '
      'FileToolStripMenuItem
      '
      Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItem1, Me.AsasToolStripMenuItem})
      Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
      Me.FileToolStripMenuItem.Size = New System.Drawing.Size(35, 20)
      Me.FileToolStripMenuItem.Text = "File"
      '
      'ToolStripMenuItem1
      '
      Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
      Me.ToolStripMenuItem1.Size = New System.Drawing.Size(149, 6)
      '
      'AsasToolStripMenuItem
      '
      Me.AsasToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AsasasToolStripMenuItem})
      Me.AsasToolStripMenuItem.Name = "AsasToolStripMenuItem"
      Me.AsasToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
      Me.AsasToolStripMenuItem.Text = "asas"
      '
      'AsasasToolStripMenuItem
      '
      Me.AsasasToolStripMenuItem.Name = "AsasasToolStripMenuItem"
      Me.AsasasToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
      Me.AsasasToolStripMenuItem.Text = "asasas"
      '
      'TestToolStripMenuItem
      '
      Me.TestToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CheckBoxToolStripMenuItem})
      Me.TestToolStripMenuItem.Name = "TestToolStripMenuItem"
      Me.TestToolStripMenuItem.Size = New System.Drawing.Size(40, 20)
      Me.TestToolStripMenuItem.Text = "Test"
      '
      'CheckBoxToolStripMenuItem
      '
      Me.CheckBoxToolStripMenuItem.Name = "CheckBoxToolStripMenuItem"
      Me.CheckBoxToolStripMenuItem.Size = New System.Drawing.Size(121, 22)
      Me.CheckBoxToolStripMenuItem.Text = "CheckBox"
      '
      'ToolStrip1
      '
      Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButton1, Me.ToolStripSeparator1, Me.ToolStripButton2})
      Me.ToolStrip1.Location = New System.Drawing.Point(0, 24)
      Me.ToolStrip1.Name = "ToolStrip1"
      Me.ToolStrip1.Size = New System.Drawing.Size(705, 25)
      Me.ToolStrip1.TabIndex = 1
      Me.ToolStrip1.Text = "ToolStrip1"
      '
      'ToolStripButton1
      '
      Me.ToolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
      Me.ToolStripButton1.Image = CType(resources.GetObject("ToolStripButton1.Image"), System.Drawing.Image)
      Me.ToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta
      Me.ToolStripButton1.Name = "ToolStripButton1"
      Me.ToolStripButton1.Size = New System.Drawing.Size(23, 22)
      Me.ToolStripButton1.Text = "ToolStripButton1"
      '
      'ToolStripSeparator1
      '
      Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
      Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
      '
      'ToolStripButton2
      '
      Me.ToolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
      Me.ToolStripButton2.Image = CType(resources.GetObject("ToolStripButton2.Image"), System.Drawing.Image)
      Me.ToolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta
      Me.ToolStripButton2.Name = "ToolStripButton2"
      Me.ToolStripButton2.Size = New System.Drawing.Size(23, 22)
      Me.ToolStripButton2.Text = "ToolStripButton2"
      '
      'PojjamanWorkbench
      '
      Me.ClientSize = New System.Drawing.Size(705, 734)
      Me.Controls.Add(Me.ToolStrip1)
      Me.Controls.Add(Me.MenuStrip1)
      Me.MainMenuStrip = Me.MenuStrip1
      Me.Name = "PojjamanWorkbench"
      Me.MenuStrip1.ResumeLayout(False)
      Me.MenuStrip1.PerformLayout()
      Me.ToolStrip1.ResumeLayout(False)
      Me.ToolStrip1.PerformLayout()
      Me.ResumeLayout(False)
      Me.PerformLayout()

    End Sub

    Private Sub PojjamanWorkbench_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
      '=========================Windows 7================================

      'Try
      'Dim jl As JumpList = JumpList.CreateJumpList
      'Dim cat As New JumpListCustomCategory("Newest Documents")
      'cat.AddJumpListItems(New JumpListLink("http://longkongstudio.com", "PR-0301 (PR)"), _
      'New JumpListLink("http://longkongstudio.com", "PO-0029 (PO)"), _
      'New JumpListLink("http://longkongstudio.com", "SCR-0097 (SC)"))
      'jl.AddCustomCategories(cat)
      'cat = New JumpListCustomCategory("Change Database")
      'cat.AddJumpListItems(New JumpListLink("http://longkongstudio.com", "TNC-01"), _
      'New JumpListLink("http://longkongstudio.com", "TNC-02"))
      'jl.AddCustomCategories(cat)
      'jl.Refresh()
      'Catch ex As PlatformNotSupportedException
      ''Not Windows 7
      'Catch ex As Exception
      'MessageBox.Show(ex.ToString)
      'End Try
      '=========================Windows 7================================
    End Sub
  End Class
End Namespace