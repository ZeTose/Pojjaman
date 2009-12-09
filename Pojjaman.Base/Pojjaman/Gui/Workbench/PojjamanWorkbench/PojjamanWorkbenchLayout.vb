Imports WeifenLuo.WinFormsUI.Docking
Imports Longkong.Pojjaman.Services
Imports Longkong.Core.Properties
Imports Longkong.Core.Services
Imports System.IO
Imports System.Reflection
Imports Longkong.Pojjaman.Commands
Imports Microsoft.WindowsAPICodePack.Taskbar

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
        'If (((Not Me.m_dockPanel Is Nothing) AndAlso (Not Me.m_dockPanel.ActiveDocument Is Nothing)) AndAlso Not Me.m_dockPanel.ActiveDocument.IsDisposed) Then
        'If TypeOf Me.m_dockPanel.ActiveDocument Is IWorkbenchWindow Then
        'Return CType(Me.m_dockPanel.ActiveDocument, IWorkbenchWindow)
        'End If
        'End If
        If (((Not Me.m_dockPanel Is Nothing) AndAlso (Not Me.m_dockPanel.ActiveDocument Is Nothing))) Then
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
      m_dockPanel.DocumentStyle = DocumentStyle.DockingWindow
            Me.m_wbForm.Controls.Add(Me.m_dockPanel)
            Me.m_dockPanel.ActiveAutoHideContent = Nothing
            Me.m_dockPanel.Dock = DockStyle.Fill
            AddHandler Me.m_dockPanel.ActiveDocumentChanged, New EventHandler(AddressOf Me.ActiveMdiChanged)

            Dim myStatusBarService As IStatusBarService = CType(ServiceManager.Services.GetService(GetType(IStatusBarService)), IStatusBarService)

            For Each content As IViewContent In workbench.ViewContentCollection
                Me.ShowView(content)
            Next

      'Add Menus & Toolbars
      workbench.RefreshMenus()

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
#End Region

#Region "PadContentWrapper Class"
    'Private Class PadContentWrapper
    'Inherits DockContent

    '#Region "Members"
    'Private m_content As IPadContent
    '#End Region

    '#Region "Constructos"
    'Public Sub New(ByVal content As IPadContent)
    'Me.m_content = content
    'Me.KeyPreview = True
    'If Not content.DockAreas Is Nothing Then
    'MyBase.DockAreas = Nothing
    'For Each myDockArea As String In content.DockAreas
    'MyBase.DockAreas = MyBase.DockAreas Or CType([Enum].Parse(GetType(DockAreas), myDockArea), DockAreas)
    'Next
    'Else
    'MyBase.DockAreas = DockAreas.DockBottom Or DockAreas.DockTop Or DockAreas.DockRight Or DockAreas.DockLeft Or DockAreas.Float
    'End If
    'MyBase.HideOnClose = content.HideOnClose
    'End Sub
    '#End Region

    '#Region "Properties"
    'Public ReadOnly Property Content() As IPadContent
    'Get
    'Return Me.m_content
    'End Get
    'End Property
    '#End Region

    '#Region "Methods"
    'Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
    'MyBase.Dispose(disposing)
    'If (disposing AndAlso (Not Me.m_content Is Nothing)) Then
    'Me.m_content.Dispose()
    'Me.m_content = Nothing
    'End If
    'End Sub
    'Protected Overrides Function GetPersistString() As String
    'Return CType(Me.m_content, Object).GetType.ToString
    'End Function
    '#End Region

    'Private Sub PadContentWrapper_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
    'Select Case e.KeyCode
    'Case Keys.Enter
    'If StartPojjamanWorkbenchCommand.ALLOWTAB Then
    'SendKeys.Send("{tab}")
    'End If
    'e.Handled = True
    'End Select
    'End Sub
    'End Class
#End Region

    End Class
End Namespace
