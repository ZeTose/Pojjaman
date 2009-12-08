Imports System.Windows.Forms
Imports System.ComponentModel.Design
Imports Longkong.Core.Services
Imports Longkong.Core.Properties
Imports System.Drawing
Imports Longkong.Pojjaman.Services
Imports System.IO
Imports Microsoft.Win32
Imports System.Text
Imports System.Threading
Imports Longkong.Pojjaman.FormDisplayBinding
Imports Longkong.Pojjaman.Gui.Panels
Imports Longkong.Pojjaman.Gui
Imports Longkong.Pojjaman.Gui.Pads
Namespace Longkong.Pojjaman.PanelDisplayBinding
    Public Class PanelPad
        Inherits AbstractPadContent
        Implements IContentUpdate

#Region "Members"
        Private m_panel As UserControl
        Private m_hideOnClose As Boolean = False
#End Region

#Region "Constructors"
        Public Sub New(ByVal panel As IPanel)
            MyBase.New(panel.Title, panel.Icon)
            Me.m_panel = CType(panel, UserControl)
            AddHandler m_panel.TextChanged, AddressOf Me.TitleChange
            Me.DockAreas = New String() {"DockBottom"} '{"Float","DockBottom"}
        End Sub
        Public Sub New(ByVal panel As IPanel, ByVal hideOnClose As Boolean)
            Me.New(panel)
            Me.m_hideOnClose = hideOnClose
        End Sub
#End Region

#Region "Properties"
        Public Overrides ReadOnly Property Control() As System.Windows.Forms.Control
            Get
                Return Me.m_panel
            End Get
        End Property
        Public Overrides ReadOnly Property HideOnClose() As Boolean
            Get
                Return Me.m_hideOnClose
            End Get
        End Property
#End Region

#Region "Methods"
        Private Sub TitleChange(ByVal sender As Object, ByVal e As EventArgs)
            Me.Title = m_panel.Text
            OnTitleChanged(Nothing)
        End Sub
#End Region

#Region "IContentUpdate"
        Public Sub UpdateContent() Implements IContentUpdate.UpdateContent
            'If Not WorkbenchSingleton.Workbench.ActiveWorkbenchWindow Is Nothing Then
            '    If TypeOf Me.m_panel Is IListDetail Then
            '        If WorkbenchSingleton.Workbench.GetView(CType(Me.m_panel, IListDetail).Entity.ClassName) Is Nothing Then
            '            WorkbenchSingleton.Workbench.WorkbenchLayout.ClosePad(Me)
            '            Return
            '        End If
            '        Dim activeControl As Control = WorkbenchSingleton.Workbench.ActiveWorkbenchWindow.ActiveViewContent.Control
            '        If TypeOf activeControl Is IListPanel Then
            '            If CType(activeControl, IListPanel).Entity.ClassName = CType(Me.m_panel, IListDetail).Entity.ClassName Then
            '                Dim myListPanel As ListPanel = CType(activeControl, ListPanel)
            '                WorkbenchSingleton.Workbench.WorkbenchLayout.ActivatePad(Me)
            '                myListPanel.cm_CurrentChanged(Nothing, Nothing)
            '            End If
            '        ElseIf TypeOf activeControl Is IGroupPanel Then
            '            If CType(activeControl, IGroupPanel).Entity.ClassName = CType(Me.m_panel, IListDetail).Entity.ClassName Then
            '                Dim myGroupPanel As GroupPanelView = CType(activeControl, GroupPanelView)
            '                WorkbenchSingleton.Workbench.WorkbenchLayout.ActivatePad(Me)
            '                'myGroupPanel.SetGroupDetail(myGroupPanel.tvGroup.SelectedNode)
            '            End If
            '        End If
            '    End If
            'Else
            '    WorkbenchSingleton.Workbench.WorkbenchLayout.ClosePad(Me)
            'End If
        End Sub
#End Region

    End Class
End Namespace

