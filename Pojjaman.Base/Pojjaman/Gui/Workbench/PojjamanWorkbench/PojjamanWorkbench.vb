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
Namespace Longkong.Pojjaman.Gui
  Public Class PojjamanWorkbench
    Inherits Form
    Implements IWorkbench

#Region "Win32"
    'Private Const WM_SETTINGCHANGE As Integer = &H1A

    '<DllImport("kernel32.dll", ExactSpelling:=True)> _
    'Private Overloads Shared Function GetUserDefaultLCID() As Integer
    'End Function

    'Private m_ciOld As New CultureInfo(GetUserDefaultLCID())
    'Protected Overrides Sub WndProc(ByRef m As System.Windows.Forms.Message)
    '    Select Case m.Msg
    '        Case WM_SETTINGCHANGE
    '            If Not IntPtr.op_Equality(m.LParam, IntPtr.Zero) Then
    '                Dim localeCur As Integer = GetUserDefaultLCID()
    '                Dim val As String = Marshal.PtrToStringAuto(m.LParam)
    '                If val = "intl" Then
    '                    If Thread.CurrentThread.CurrentCulture.LCID <> localeCur AndAlso _
    '                    Thread.CurrentThread.CurrentCulture.LCID = m_ciOld.LCID Then
    '                        Thread.CurrentThread.CurrentCulture = New CultureInfo(localeCur)
    '                    Else
    '                        Thread.CurrentThread.CurrentCulture.ClearCachedData()
    '                    End If
    '                    m_ciOld = New CultureInfo(localeCur)
    '                End If
    '            End If
    '    End Select
    '    MyBase.WndProc(m)
    'End Sub
#End Region

#Region "Members"
    Public ToolBars As CommandBar()
    Public TopMenu As CommandBar
    Public SecondMenu As CommandBar
    Private m_commandBarManager As CommandBarManager

    Private m_defaultWindowState As FormWindowState
    Private m_normalBounds As Rectangle
    Private m_applicationMode As ApplicationMode
    Private m_fullscreen As Boolean

    Private m_closeAll As Boolean

    Private m_layout As IWorkbenchLayout

    Private Shared ReadOnly m_mainMenuPath As String = "/Pojjaman/Workbench/MainMenu"
    Private Shared ReadOnly m_secondMenuPath As String = "/Pojjaman/Workbench/SecondMenu"
    Private Shared ReadOnly m_viewContentPath As String = "/Pojjaman/Workbench/Views"
    Protected Shared m_propertyService As PropertyService = CType(ServiceManager.Services.GetService(GetType(PropertyService)), PropertyService)
    Private m_SecurityService As SecurityService

    Private m_padContentCollection As PadContentCollection
    Private m_viewContentCollection As ViewContentCollection
#End Region

#Region "Events"
    Private windowChangeEventHandler As EventHandler
    Private ActiveWorkbenchWindowChangedHandler As EventHandler
#End Region

#Region "Constructors"
    Public Sub New()

      ' Request a license from the LicenseManager. An exception is raised if no license is available
      '_license = DeployLX.Licensing.v3.SecureLicenseManager.Validate(Me, GetType(PojjamanWorkbench), Nothing)
    End Sub
    Public Sub Init()
      Me.m_padContentCollection = New PadContentCollection
      Me.m_viewContentCollection = New ViewContentCollection
      Me.m_closeAll = False
      Me.m_defaultWindowState = FormWindowState.Normal
      Me.m_normalBounds = New Rectangle(0, 0, 640, 480)
      Me.m_layout = Nothing
      Me.m_commandBarManager = New CommandBarManager
      Me.TopMenu = Nothing
      Me.ToolBars = Nothing
      Me.SecondMenu = Nothing
      Dim myResourceService As ResourceService = CType(ServiceManager.Services.GetService(GetType(IResourceService)), ResourceService)
      Me.Text = GetDialogName()
      MyBase.Icon = myResourceService.GetIcon("Icons.PojjamanIcon")
      MyBase.StartPosition = FormStartPosition.Manual
      Me.AllowDrop = True
      Me.windowChangeEventHandler = New EventHandler(AddressOf Me.OnActiveWindowChanged)
    End Sub
    Private Function GetDialogName() As String
      Dim pjmVersion As version = [Assembly].GetEntryAssembly.GetName.Version
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
      ret &= ":PJM=" & version
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
    Private Sub CreateMainMenu()
      Me.TopMenu = New CommandBar(Me.m_commandBarManager, CommandBarStyle.Menu)
      Dim items As CommandBarItem() = CType(AddInTreeSingleton.AddInTree.GetTreeNode(PojjamanWorkbench.m_mainMenuPath).BuildChildItems(Me).ToArray(GetType(CommandBarItem)), CommandBarItem())
      Me.TopMenu.Items.Clear()
      Me.TopMenu.Items.AddRange(items)
      Me.m_commandBarManager.CommandBars.Add(Me.TopMenu)
    End Sub
    Private Sub CreateSecondMenu()
      Me.SecondMenu = New CommandBar(Me.m_commandBarManager, CommandBarStyle.Menu)
      Dim items As CommandBarItem() = CType(AddInTreeSingleton.AddInTree.GetTreeNode(PojjamanWorkbench.m_secondMenuPath).BuildChildItems(Me).ToArray(GetType(CommandBarItem)), CommandBarItem())
      Me.SecondMenu.Items.Clear()
      Me.SecondMenu.Items.AddRange(items)
      Me.m_commandBarManager.CommandBars.Add(Me.SecondMenu)
    End Sub
    Private Sub CreateToolBars()
      If (Me.ToolBars Is Nothing) Then
        Dim myToolbarService As ToolbarService = CType(ServiceManager.Services.GetService(GetType(ToolbarService)), ToolbarService)
        Dim bars As CommandBar() = myToolbarService.CreateToolbars
        Me.ToolBars = bars
      End If
      For Each tb As CommandBar In Me.ToolBars
        Me.m_commandBarManager.CommandBars.Add(tb)
      Next
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
      'Me.CreateSecondMenu()
      Me.CreateToolBars()
      Me.Controls.Add(Me.m_commandBarManager)
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
      For Each content As IPadContent In Me.PadContentCollection
        content.Dispose()
      Next
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
      RaiseEvent ViewClosed(Me, e)
    End Sub
    Protected Overridable Sub OnViewOpened(ByVal e As ViewContentEventArgs)
      RaiseEvent ViewOpened(Me, e)
    End Sub
    Protected Overrides Function ProcessCmdKey(ByRef msg As Message, ByVal keyData As Keys) As Boolean
      If Me.m_commandBarManager.PreProcessMessage(msg) Then
        Return True
      End If
      Return MyBase.ProcessCmdKey(msg, keyData)
    End Function
    Private Sub SetStandardStatusBar(ByVal sender As Object, ByVal e As EventArgs)
      Dim myStatusBarService As IStatusBarService = CType(ServiceManager.Services.GetService(GetType(IStatusBarService)), IStatusBarService)
      myStatusBarService.RefreshLanguage()
      'myStatusBarService.SetMessage("${res:MainWindow.StatusBar.ReadyMessage}")
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
      Me.UpdateContents()
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
    Public Sub UpdatePadContents(ByVal sender As Object, ByVal e As EventArgs)
      For Each content As IPadContent In CType(AddInTreeSingleton.AddInTree.GetTreeNode(PojjamanWorkbench.m_viewContentPath).BuildChildItems(Me).ToArray(GetType(IPadContent)), IPadContent())
        Me.ShowPad(content)
      Next
    End Sub
    Public Sub UpdateToolbars()
      For Each bar As CommandBar In Me.ToolBars
        For Each item As Object In bar.Items
          If TypeOf item Is IStatusUpdate Then
            UpdateModeMenusOrToolBars(item)
            CType(item, IStatusUpdate).UpdateStatus()
          End If
        Next
      Next
    End Sub
    Public Sub UpdateContents()
      Try
        For Each pad As IPadContent In Me.PadContentCollection
          If TypeOf pad Is IContentUpdate Then
            CType(pad, IContentUpdate).UpdateContent()
          End If
        Next
      Catch ex As Exception

      End Try
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
    Public Overloads Function GetPad(ByVal type As System.Type) As IPadContent Implements IWorkbench.GetPad
      For Each pad As IPadContent In Me.PadContentCollection
        If (CType(pad, Object).GetType Is type) Then
          Return pad
        End If
      Next
      Return Nothing
    End Function
    Public Overloads Function GetPad(ByVal entityName As String) As IPadContent Implements IWorkbench.GetPad
      For Each pad As IPadContent In Me.PadContentCollection
        If TypeOf pad Is PanelPad Then
          Dim myPanelPad As PanelPad = CType(pad, PanelPad)
          If TypeOf myPanelPad.Control Is IEntityPanel Then
            If CType(myPanelPad.Control, IEntityPanel).Entity.ClassName = entityName Then
              Return pad
            End If
          End If
        End If
      Next
      Return Nothing
    End Function
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
      For Each view As IViewContent In Me.ViewContentCollection
        If TypeOf view Is PanelView Then
          Dim myPanelView As PanelView = CType(view, PanelView)
          If TypeOf myPanelView.Control Is IEntityPanel Then
            If CType(myPanelView.Control, IEntityPanel).Entity.ClassName = entiyName Then
              Return view
            End If
          End If
        End If
      Next
    End Function
    Public Function GetView(ByVal type As System.Type) As IViewContent Implements IWorkbench.GetView
      For Each view As IViewContent In Me.ViewContentCollection
        If TypeOf view Is PanelView Then
          Dim myPanelView As PanelView = CType(view, PanelView)
          If myPanelView.Control.GetType Is type Then
            Return view
          End If
        End If
      Next
    End Function
    Public ReadOnly Property PadContentCollection() As PadContentCollection Implements IWorkbench.PadContentCollection
      Get
        Return Me.m_padContentCollection
      End Get
    End Property
    Public Sub RedrawEditComponents() Implements IWorkbench.RedrawEditComponents
      For Each item As Object In Me.TopMenu.Items
        If TypeOf item Is IStatusUpdate Then
          UpdateModeMenusOrToolBars(item)
          CType(item, IStatusUpdate).UpdateStatus()
        End If
      Next
      For Each bar As CommandBar In Me.ToolBars
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
      For Each content As IPadContent In Me.m_padContentCollection
        content.RedrawContent()
      Next
      Me.m_layout.RedrawAllComponents()
      Me.Text = Me.GetDialogName
    End Sub
    Public Sub ShowPad(ByVal content As IPadContent) Implements IWorkbench.ShowPad
      Me.PadContentCollection.Add(content)
      If (Not Me.m_layout Is Nothing) Then
        Me.m_layout.ShowPad(content)
      End If
    End Sub
    Public Sub ShowPad(ByVal content As IPadContent, ByVal rect As System.Drawing.Rectangle) Implements IWorkbench.ShowPad
      Me.PadContentCollection.Add(content)
      If (Not Me.m_layout Is Nothing) Then
        Me.m_layout.ShowPad(content, rect)
      End If
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
    Public ReadOnly Property CommandBarManager() As System.Windows.Forms.CommandBarManager Implements IWorkbench.CommandBarManager
      Get
        Return Me.m_commandBarManager
      End Get
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

  End Class
End Namespace