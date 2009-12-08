Imports Longkong.Pojjaman.Gui.XmlForms
Imports Longkong.Core.Properties
Imports Longkong.Core.Services
Imports Longkong.Core.AddIns.Codons
Imports Longkong.Core.AddIns
Imports System.IO
Imports Longkong.Pojjaman.BusinessLogic
Imports System.Configuration
Imports System.Data.SqlClient
Imports Longkong.Pojjaman.Gui.Panels
Imports Longkong.WinFormsUI
Namespace Longkong.Pojjaman.Gui.Dialogs
    Public Class PanelWithDockDialog
        Inherits Form

#Region "Members"
        Private m_control As UserControl
#End Region

#Region "Constructors"
        Private DockPanel As New Longkong.WinFormsUI.DockPanel
        Public Sub New(ByVal theControl As UserControl, ByVal content As IPadContent)
            InitializeComponent()
            DockPanel.Dock = System.Windows.Forms.DockStyle.Fill
            Me.Controls.Add(DockPanel)

            'm_control = theControl
            'If TypeOf m_control Is MapDialog Then
            '    AddHandler m_control.Resize, AddressOf ControlResize
            'Else
            '    Me.ClientSize = m_control.ClientSize
            '    m_control.Dock = DockStyle.Fill
            'End If
            'm_control.Location = New Point(0, 0)
            'Debug.WriteLine(m_control.Size)
            'Me.Text = m_control.Text

            Dim myContent As New PadContentWrapper(content)
            If (Not content.Icon Is Nothing) Then
                Dim myIconService As IconService = CType(ServiceManager.Services.GetService(GetType(IconService)), IconService)
                myContent.Icon = myIconService.GetIcon(content.Icon)
            End If
            content.Control.Dock = DockStyle.Fill
            myContent.Controls.Add(content.Control)
            myContent.Text = content.Title
            myContent.DockableAreas = DockAreas.DockBottom
            myContent.Show(DockPanel)
        End Sub
#End Region

#Region "Properties"
        Public ReadOnly Property Control() As UserControl
            Get
                Return m_control
            End Get
        End Property
#End Region

#Region "Methods"
        Private Sub ControlResize(ByVal sender As Object, ByVal e As System.EventArgs)
            Me.ClientSize = m_control.ClientSize
        End Sub
        Protected Sub InitializeComponent()
            '
            'PanelWithDockDialog
            '
            Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
            Me.ClientSize = New System.Drawing.Size(552, 414)
            Me.KeyPreview = True
            Me.MaximizeBox = False
            Me.MinimizeBox = False
            Me.Name = "PanelWithDockDialog"
            Me.ShowInTaskbar = False
            Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen

        End Sub
        Private Sub PanelWithDockDialog_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
            Select Case e.KeyCode
                Case Keys.Enter
                    SendKeys.Send("{tab}")
                    e.Handled = True
            End Select
        End Sub
#End Region

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

    End Class
End Namespace

