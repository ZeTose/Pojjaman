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
    Public Class PanelDockingDialog
        Inherits Form

#Region "Members"
        Private m_control As UserControl
#End Region

#Region "Constructors"
        Private DockPanel As New Longkong.WinFormsUI.DockPanel
        Public Sub New(ByVal theControl As UserControl, ByVal dlg As UserControl)
            InitializeComponent()
            DockPanel.Dock = System.Windows.Forms.DockStyle.Fill
            Me.Controls.Add(DockPanel)

            Me.ClientSize = theControl.ClientSize

            Dim window As New ControlWrapper(theControl)
            window.DockableAreas = DockAreas.Document
            window.Show(Me.DockPanel)

            Dim myContent As New ControlWrapper(dlg)
            Dim myIconService As IconService = CType(ServiceManager.Services.GetService(GetType(IconService)), IconService)
            myContent.Icon = myIconService.GetIcon("Icons.16x16.Basket")
            myContent.Text = dlg.Name
            myContent.DockableAreas = DockAreas.DockBottom
            myContent.Show(DockPanel)
            If TypeOf dlg Is BasketDialog Then
                AddHandler CType(dlg, BasketDialog).ibtnClear.Click, AddressOf CloseMe
            End If
        End Sub
        Public Sub New(ByVal theControls As UserControl(), ByVal dlg As UserControl, ByVal activeIndex As Integer)
            InitializeComponent()
            DockPanel.Dock = System.Windows.Forms.DockStyle.Fill
            Me.Controls.Add(DockPanel)

            Me.ClientSize = theControls(0).ClientSize

            Dim activeWindow As DockContent
            For i As Integer = 0 To theControls.Length - 1
                Dim window As New ControlWrapper(theControls(i))
                window.DockableAreas = DockAreas.Document
                If TypeOf theControls(i) Is ISimpleEntityPanel Then
                    window.Text = CType(theControls(i), ISimpleEntityPanel).Entity.TabPageText
                    If window.Text.EndsWith("()") Then
                        window.Text = window.Text.TrimEnd("()".ToCharArray)
                    End If
                    If window.Text.EndsWith(":") Then
                        window.Text = window.Text.TrimEnd(":".ToCharArray)
                    End If
                End If
                window.Show(Me.DockPanel)
                If i = activeIndex Then activeWindow = window
            Next
            If Not activeWindow Is Nothing Then
                activeWindow.Show(Me.DockPanel)
            End If

            Dim myContent As New ControlWrapper(dlg)
            Dim myIconService As IconService = CType(ServiceManager.Services.GetService(GetType(IconService)), IconService)
            myContent.Icon = myIconService.GetIcon("Icons.16x16.Basket")
            myContent.Text = "Basket"
            myContent.DockableAreas = DockAreas.DockBottom
            myContent.Show(DockPanel)
            If TypeOf dlg Is BasketDialog Then
                AddHandler CType(dlg, BasketDialog).ibtnClear.Click, AddressOf CloseMe
            End If
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
        Private Sub CloseMe(ByVal sender As Object, ByVal e As EventArgs)
            Me.Close()
        End Sub
        Private Sub ControlResize(ByVal sender As Object, ByVal e As System.EventArgs)
            Me.ClientSize = m_control.ClientSize
        End Sub
        Protected Sub InitializeComponent()
            '
            'PanelDockingDialog
            '
            Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
            Me.ClientSize = New System.Drawing.Size(552, 414)
            Me.KeyPreview = True
            Me.MaximizeBox = False
            Me.MinimizeBox = False
            Me.Name = "PanelDockingDialog"
            Me.ShowInTaskbar = False
            Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen

        End Sub
        Private Sub PanelDockingDialog_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
            Select Case e.KeyCode
                Case Keys.Enter
                    SendKeys.Send("{tab}")
                    e.Handled = True
            End Select
        End Sub
#End Region

        Private Class ControlWrapper
            Inherits DockContent

#Region "Members"
            Private m_dlg As UserControl
#End Region

#Region "Constructors"
            Public Sub New(ByVal dlg As UserControl)
                Me.m_dlg = dlg
                dlg.Dock = DockStyle.Fill
                Me.Controls.Add(dlg)
                Me.KeyPreview = True
                MyBase.HideOnClose = False
            End Sub
#End Region

#Region "Methods"
            Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
                MyBase.Dispose(disposing)
                If (disposing AndAlso (Not Me.m_dlg Is Nothing)) Then
                    Me.m_dlg.Dispose()
                    Me.m_dlg = Nothing
                End If
            End Sub
            Protected Overrides Function GetPersistString() As String
                Return CType(Me.m_dlg, Object).GetType.ToString
            End Function
#End Region

#Region "Events"
            Private Sub PadContentWrapper_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
                Select Case e.KeyCode
                    Case Keys.Enter
                        SendKeys.Send("{tab}")
                        e.Handled = True
                End Select
            End Sub
#End Region

        End Class

    End Class
End Namespace

