Imports Longkong.WinFormsUI
Imports Longkong.Pojjaman.Services
Imports Longkong.Core.Properties
Imports Longkong.Core.Services
Imports System.IO
Imports System.Reflection
Namespace Longkong.Pojjaman.Gui
    Public Class PojjamanWorkbenchLayout
        Implements IWorkbenchLayout

#Region "Members"
        Private Shared m_configFileName As String = "MdiLayoutConfig3.xml"
        Private Shared m_propertyService As PropertyService = CType(ServiceManager.Services.GetService(GetType(PropertyService)), PropertyService)
        Private Shared m_configFile As String = Path.Combine(PojjamanWorkbenchLayout.m_propertyService.ConfigDirectory, PojjamanWorkbenchLayout.m_configFileName)

        Private m_contentHash As Hashtable
        Private m_dockPanel As DockPanel
        Private m_oldSelectedWindow As IWorkbenchWindow
        Private m_wbForm As Form
#End Region

#Region "Constructors"
        Public Sub New()
            Me.m_contentHash = New Hashtable
            Me.m_oldSelectedWindow = Nothing
        End Sub
#End Region

#Region "Methods"
        Private Sub ActiveMdiChanged(ByVal sender As Object, ByVal e As EventArgs)
            Me.OnActiveWorkbenchWindowChanged(e)
            Dim myStatusBarService As IStatusBarService = CType(ServiceManager.Services.GetService(GetType(IStatusBarService)), IStatusBarService)
            myStatusBarService.RefreshLanguage()
            myStatusBarService.SetMessage("${res:MainWindow.StatusBar.ReadyMessage}")
            Try
                If Not WorkbenchSingleton.Workbench.ActiveWorkbenchWindow Is Nothing Then
                    If Not WorkbenchSingleton.Workbench.ActiveWorkbenchWindow.ActiveViewContent Is Nothing Then
                        Dim mi As MethodInfo = CType(WorkbenchSingleton.Workbench.ActiveWorkbenchWindow.ActiveViewContent, Object).GetType.GetMethod("SetStatus")
                        If Not mi Is Nothing Then
                            mi.Invoke(WorkbenchSingleton.Workbench.ActiveWorkbenchWindow.ActiveViewContent, Nothing)
                        End If
                    End If
                End If
            Catch ex As Exception

            End Try
        End Sub
        Private Function GetContent(ByVal padTypeName As String) As DockContent
            For Each content As IPadContent In CType(Me.m_wbForm, IWorkbench).PadContentCollection
                If (CType(content, Object).GetType.ToString = padTypeName) Then
                    Return Me.CreateContent(content)
                End If
            Next
            Return Nothing
        End Function
        Private Function CreateContent(ByVal content As IPadContent) As DockContent
            If (Not Me.m_contentHash(content) Is Nothing) Then
                Return CType(Me.m_contentHash(content), DockContent)
            End If
            'Wrap the content in Longkong.WinFormsUI.DockContent
            Dim myContent As New PadContentWrapper(content)
            If (Not content.Icon Is Nothing) Then
                Dim myIconService As IconService = CType(ServiceManager.Services.GetService(GetType(IconService)), IconService)
                myContent.Icon = myIconService.GetIcon(content.Icon)
            End If
            content.Control.Dock = DockStyle.Fill
            myContent.Controls.Add(content.Control)
            myContent.Text = content.Title
            'Add the wrapped content in the HashTable
            Me.m_contentHash(content) = myContent
            AddHandler myContent.Closed, AddressOf ContentClosed
            Return myContent
        End Function
        Public Sub ContentClosed(ByVal sender As Object, ByVal e As EventArgs)
            Me.m_contentHash.Remove(CType(sender, PadContentWrapper).Content)
            WorkbenchSingleton.Workbench.PadContentCollection.Remove(CType(sender, PadContentWrapper).Content)
        End Sub
        Public Sub CloseWindowEvent(ByVal sender As Object, ByVal e As EventArgs)
            Dim cmd As New Longkong.Pojjaman.Commands.SelectPrevWindow
            cmd.Run()
            Dim window As PojjamanWorkspaceWindow = CType(sender, PojjamanWorkspaceWindow)
            If (window.ViewContent Is Nothing) Then
                Return
            End If
            CType(Me.m_wbForm, IWorkbench).CloseContent(window.ViewContent)
            If (window Is Me.m_oldSelectedWindow) Then
                Me.m_oldSelectedWindow = Nothing
            End If
            Me.ActiveMdiChanged(Me, Nothing)
        End Sub
#End Region

#Region "IWorkbenchLayout"
        Public Event ActiveWorkbenchWindowChanged(ByVal sender As Object, ByVal e As System.EventArgs) Implements IWorkbenchLayout.ActiveWorkbenchWindowChanged

        Public ReadOnly Property ActiveWorkbenchwindow() As IWorkbenchWindow Implements IWorkbenchLayout.ActiveWorkbenchwindow
            Get
                If (((Not Me.m_dockPanel Is Nothing) AndAlso (Not Me.m_dockPanel.ActiveDocument Is Nothing)) AndAlso Not Me.m_dockPanel.ActiveDocument.IsDisposed) Then
                    If TypeOf Me.m_dockPanel.ActiveDocument Is IWorkbenchWindow Then
                        Return CType(Me.m_dockPanel.ActiveDocument, IWorkbenchWindow)
                    End If
                End If
                Return Nothing
            End Get
        End Property
        Public Sub Attach(ByVal workbench As IWorkbench) Implements IWorkbenchLayout.Attach
            Me.m_wbForm = CType(workbench, Form)
            Me.m_wbForm.Show()
            Me.m_wbForm.Menu = Nothing
            Me.m_wbForm.Controls.Clear()

            'นี่แหละ DockPanel ที่ host ทุกๆ content ทั้ง pad และ view
            Me.m_dockPanel = New DockPanel
            Me.m_wbForm.Controls.Add(Me.m_dockPanel)
            Me.m_dockPanel.ActiveAutoHideContent = Nothing
            Me.m_dockPanel.Dock = DockStyle.Fill
            AddHandler Me.m_dockPanel.ActiveDocumentChanged, New EventHandler(AddressOf Me.ActiveMdiChanged)

            Dim myStatusBarService As IStatusBarService = CType(ServiceManager.Services.GetService(GetType(IStatusBarService)), IStatusBarService)

            Try
                'หา Layout config file
                If File.Exists(PojjamanWorkbenchLayout.m_configFile) Then
                    Me.m_dockPanel.LoadFromXml(PojjamanWorkbenchLayout.m_configFile, New DeserializeDockContent(AddressOf Me.GetContent))
                Else
                    Me.m_dockPanel.LoadFromXml([Assembly].GetCallingAssembly.GetManifestResourceStream(PojjamanWorkbenchLayout.m_configFileName), New DeserializeDockContent(AddressOf Me.GetContent))
                End If
            Catch ex As Exception
                Console.WriteLine("can't load docking configuration, version clash ? " & ex.Message)
            End Try

            For Each content As IPadContent In workbench.PadContentCollection
                If (Me.m_contentHash(content) Is Nothing) Then
                    Me.ShowPad(content)
                End If
            Next

            For Each content As IViewContent In workbench.ViewContentCollection
                Me.ShowView(content)
            Next

            Me.RedrawAllComponents()
            'Add the Menubars & Toolbars
            Me.m_wbForm.Controls.Add(CType(workbench, IWorkbench).CommandBarManager)
            'Add the Statusbar
            Me.m_wbForm.Controls.Add(myStatusBarService.Control)
        End Sub
        Public Sub Detach() Implements IWorkbenchLayout.Detach
            Try
                If (Not Me.m_dockPanel Is Nothing) Then
                    Me.m_dockPanel.SaveAsXml(PojjamanWorkbenchLayout.m_configFile)
                End If
                For Each window As PojjamanWorkspaceWindow In WorkbenchSingleton.Workbench.ViewContentCollection
                    window.DetachContent()
                    window.ViewContent = Nothing
                Next
                Me.m_wbForm.Controls.Clear()
                If (Not Me.m_dockPanel Is Nothing) Then
                    Me.m_dockPanel.Dispose()
                    Me.m_dockPanel = Nothing
                End If
            Catch ex As Exception
            End Try
        End Sub

        Public Sub ActivatePad(ByVal content As IPadContent) Implements IWorkbenchLayout.ActivatePad
            If (Not content Is Nothing) Then
                CType(Me.m_contentHash(content), DockContent).Show()
            End If
        End Sub
        Public Sub ActivatePad(ByVal content As IPadContent, ByVal rect As System.Drawing.Rectangle) Implements IWorkbenchLayout.ActivatePad
            If (Not content Is Nothing) Then
                CType(Me.m_contentHash(content), DockContent).Show(Me.m_dockPanel, rect)
            End If
        End Sub
        Public Sub ShowPad(ByVal content As IPadContent) Implements IWorkbenchLayout.ShowPad
            If (Me.m_contentHash(content) Is Nothing) Then
                Dim myContent As DockContent = Me.CreateContent(content)
                myContent.Show(Me.m_dockPanel)
            Else
                Dim myContent As DockContent = CType(Me.m_contentHash(content), DockContent)
                myContent.Show(Me.m_dockPanel)
            End If
        End Sub
        Public Sub ShowPad(ByVal content As IPadContent, ByVal rect As System.Drawing.Rectangle) Implements IWorkbenchLayout.ShowPad
            If (Me.m_contentHash(content) Is Nothing) Then
                Dim myContent As DockContent = Me.CreateContent(content)
                myContent.Show(Me.m_dockPanel, rect)
            Else
                Dim myContent As DockContent = CType(Me.m_contentHash(content), DockContent)
                myContent.Show(Me.m_dockPanel, rect)
            End If
        End Sub
        Public Function IsVisible(ByVal padContent As IPadContent) As Boolean Implements IWorkbenchLayout.IsVisible
            If (Not padContent Is Nothing) Then
                Dim content As DockContent = CType(Me.m_contentHash(padContent), DockContent)
                If (Not content Is Nothing) Then
                    Return Not content.IsHidden
                End If
            End If
            Return False
        End Function
        Public Sub HidePad(ByVal content As IPadContent) Implements IWorkbenchLayout.HidePad
            If (Not content Is Nothing) Then
                Dim myContent As DockContent = CType(Me.m_contentHash(content), DockContent)
                If (Not myContent Is Nothing) Then
                    myContent.Hide()
                End If
            End If
        End Sub
        Public Sub ClosePad(ByVal content As IPadContent) Implements IWorkbenchLayout.ClosePad
            If (Not content Is Nothing) Then
                Dim myContent As DockContent = CType(Me.m_contentHash(content), DockContent)
                If (Not myContent Is Nothing) Then
                    myContent.Close()
                End If
            End If
        End Sub
        Public Function ShowView(ByVal content As IViewContent) As IWorkbenchWindow Implements IWorkbenchLayout.ShowView
            content.Control.Visible = True
            content.Control.Dock = DockStyle.Fill
            Dim window As New PojjamanWorkspaceWindow(content)
            AddHandler window.CloseEvent, New EventHandler(AddressOf Me.CloseWindowEvent)
            window.Show(Me.m_dockPanel)
            Return window
        End Function

        Public Sub OnActiveWorkbenchWindowChanged(ByVal e As System.EventArgs) Implements IWorkbenchLayout.OnActiveWorkbenchWindowChanged
            RaiseEvent ActiveWorkbenchWindowChanged(Me, e)
            If (Not Me.m_oldSelectedWindow Is Nothing) Then
                Me.m_oldSelectedWindow.OnWindowDeselected(EventArgs.Empty)
            End If
            Me.m_oldSelectedWindow = Me.ActiveWorkbenchwindow
            If (((Not Me.m_oldSelectedWindow Is Nothing) AndAlso (Not Me.m_oldSelectedWindow.ActiveViewContent Is Nothing)) AndAlso (Not Me.m_oldSelectedWindow.ActiveViewContent.Control Is Nothing)) Then
                Me.m_oldSelectedWindow.OnWindowSelected(EventArgs.Empty)
                Me.m_oldSelectedWindow.ActiveViewContent.SwitchedTo()
                Me.m_oldSelectedWindow.ActiveViewContent.Control.Select()
            End If
        End Sub
        Public Sub RedrawAllComponents() Implements IWorkbenchLayout.RedrawAllComponents
            For Each content As IPadContent In CType(Me.m_wbForm, IWorkbench).PadContentCollection
                Dim myContent As DockContent = CType(Me.m_contentHash(content), DockContent)
                If (Not myContent Is Nothing) Then
                    myContent.Text = content.Title
                End If
            Next
        End Sub
#End Region

#Region "PadContentWrapper Class"
        Private Class PadContentWrapper
            Inherits DockContent

#Region "Members"
            Private m_content As IPadContent
#End Region

#Region "Constructos"
            Public Sub New(ByVal content As IPadContent)
                Me.m_content = content
                Me.KeyPreview = True
                If Not content.DockAreas Is Nothing Then
                    MyBase.DockableAreas = Nothing
                    For Each myDockArea As String In content.DockAreas
                        MyBase.DockableAreas = MyBase.DockableAreas Or CType([Enum].Parse(GetType(DockAreas), myDockArea), DockAreas)
                    Next
                Else
                    MyBase.DockableAreas = DockAreas.DockBottom Or DockAreas.DockTop Or DockAreas.DockRight Or DockAreas.DockLeft Or DockAreas.Float
                End If
                MyBase.HideOnClose = content.HideOnClose
            End Sub
#End Region

#Region "Properties"
            Public ReadOnly Property Content() As IPadContent
                Get
                    Return Me.m_content
                End Get
            End Property
#End Region

#Region "Methods"
            Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
                MyBase.Dispose(disposing)
                If (disposing AndAlso (Not Me.m_content Is Nothing)) Then
                    Me.m_content.Dispose()
                    Me.m_content = Nothing
                End If
            End Sub
            Protected Overrides Function GetPersistString() As String
                Return CType(Me.m_content, Object).GetType.ToString
            End Function
#End Region

            Private Sub PadContentWrapper_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
                Select Case e.KeyCode
                    Case Keys.Enter
                        SendKeys.Send("{tab}")
                        e.Handled = True
                End Select
            End Sub
        End Class
#End Region

    End Class
End Namespace
