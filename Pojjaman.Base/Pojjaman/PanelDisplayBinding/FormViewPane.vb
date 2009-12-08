Imports Longkong.Pojjaman.Services
Imports Longkong.Core.Services
Namespace Longkong.Pojjaman.FormDisplayBinding
    Public Class FormViewPane
        Inherits UserControl

#Region "Members"
        Private m_pane As Panel
        Private m_isHandleCreated As Boolean
        Private m_lastUrl As String
        Private m_toolBar As ToolBar
        Private m_topPanel As Panel
        Private m_urlTextBox As TextBox
#End Region

#Region "Constructors"
        Public Sub New(ByVal showNavigation As Boolean)
            Me.m_pane = Nothing
            Me.m_topPanel = New Panel
            Me.m_toolBar = New ToolBar
            Me.m_urlTextBox = New TextBox
            Me.m_isHandleCreated = False
            Me.m_lastUrl = Nothing
            Me.Dock = DockStyle.Fill
            MyBase.Size = New Size(500, 500)
            If showNavigation Then
                Me.m_topPanel.Size = New Size(MyBase.Width, 25)
                Me.m_topPanel.Dock = DockStyle.Top
                MyBase.Controls.Add(Me.m_topPanel)
                Me.m_toolBar.Dock = DockStyle.None
                For i As Integer = 0 To 4 - 1
                    Dim button1 As New ToolBarButton
                    button1.ImageIndex = i
                    Me.m_toolBar.Buttons.Add(button1)
                Next
                Dim service1 As ResourceService = CType(ServiceManager.Services.GetService(GetType(IResourceService)), ResourceService)
                Me.m_toolBar.ImageList = New ImageList
                Me.m_toolBar.ImageList.ColorDepth = ColorDepth.Depth32Bit
                Me.m_toolBar.ImageList.Images.Add(service1.GetBitmap("Icons.16x16.BrowserBefore"))
                Me.m_toolBar.ImageList.Images.Add(service1.GetBitmap("Icons.16x16.BrowserAfter"))
                Me.m_toolBar.ImageList.Images.Add(service1.GetBitmap("Icons.16x16.BrowserCancel"))
                Me.m_toolBar.ImageList.Images.Add(service1.GetBitmap("Icons.16x16.BrowserRefresh"))
                Me.m_toolBar.Appearance = ToolBarAppearance.Flat
                Me.m_toolBar.Divider = False
                AddHandler Me.m_toolBar.ButtonClick, New ToolBarButtonClickEventHandler(AddressOf Me.ToolBarClick)
                Me.m_toolBar.Location = New Point(0, 0)
                Me.m_toolBar.Size = New Size((4 * Me.m_toolBar.ButtonSize.Width), 25)
                Me.m_topPanel.Controls.Add(Me.m_toolBar)
                Me.m_urlTextBox.Location = New Point((4 * Me.m_toolBar.ButtonSize.Width), 2)
                Me.m_urlTextBox.Size = New Size(((MyBase.Width - (4 * Me.m_toolBar.ButtonSize.Width)) - 1), 21)
                Me.m_urlTextBox.Anchor = (AnchorStyles.Right Or (AnchorStyles.Left Or AnchorStyles.Top))
                AddHandler Me.m_urlTextBox.KeyPress, New KeyPressEventHandler(AddressOf Me.KeyPressEvent)
                Me.m_topPanel.Controls.Add(Me.m_urlTextBox)
            End If
            Me.m_pane = New Panel
            Me.m_pane.Dock = DockStyle.Fill
            AddHandler Me.m_pane.HandleCreated, New EventHandler(AddressOf Me.CreatedWebBrowserHandle)
            'AddHandler Me.m_pane.TitleChange, New DWebBrowserEvents2_TitleChangeEventHandler(AddressOf Me.TitleChange)
            MyBase.Controls.Add(Me.m_pane)
            If showNavigation Then
                MyBase.Controls.Add(Me.m_topPanel)
            End If
        End Sub
#End Region

#Region "Properties"
        Public ReadOnly Property Panel() As Panel
            Get
                Return Me.m_pane
            End Get
        End Property
#End Region

#Region "Methods"
        Public Sub CreatedWebBrowserHandle(ByVal sender As Object, ByVal evArgs As EventArgs)
            Me.m_isHandleCreated = True
            If (Not Me.m_lastUrl Is Nothing) Then
            End If
        End Sub
        Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
            MyBase.Dispose(disposing)
            If disposing Then
                Me.m_pane.Dispose()
            End If
        End Sub
        Private Sub KeyPressEvent(ByVal sender As Object, ByVal ex As KeyPressEventArgs)
            If (ex.KeyChar = ChrW(13)) Then
            End If
        End Sub
        Private Sub ToolBarClick(ByVal sender As Object, ByVal e As ToolBarButtonClickEventArgs)
            Try
                Select Case Me.m_toolBar.Buttons.IndexOf(e.Button)
                    Case 0
                        Return
                    Case 1
                        Return
                    Case 2
                        Return
                    Case 3
                        Return
                End Select
            Catch exception1 As Exception
            End Try
        End Sub
#End Region

    End Class
End Namespace

