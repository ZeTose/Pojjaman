Imports Longkong.Core.Services
Imports Longkong.Pojjaman.Services
Namespace Longkong.Pojjaman.Gui
    Public MustInherit Class AbstractPadContent
        Implements IPadContent

#Region "Members"
        Private m_category As String
        Private m_icon As String
        Private m_shortcut As String()
        Private m_title As String
        Private m_dockAreas As String()
#End Region

#Region "Constructors"
        Public Sub New()
        End Sub
        Public Sub New(ByVal title As String, ByVal iconResoureName As String)
            Me.m_category = Nothing
            Me.m_shortcut = Nothing
            Me.m_title = title
            Me.m_icon = iconResoureName
        End Sub
        Public Sub New(ByVal title As String)
            Me.New(title, Nothing)
        End Sub
#End Region

#Region "Methods"
        Protected Overridable Sub OnIconChanged(ByVal e As EventArgs)
            RaiseEvent IconChanged(Me, e)
        End Sub
        Protected Overridable Sub OnTitleChanged(ByVal e As EventArgs)
            RaiseEvent TitleChanged(Me, e)
        End Sub
#End Region

#Region "IPadContent"
        Public Event TitleChanged(ByVal sender As Object, ByVal e As System.EventArgs) Implements IPadContent.TitleChanged
        Public Event IconChanged(ByVal sender As Object, ByVal e As System.EventArgs) Implements IPadContent.IconChanged

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
            Set(ByVal value As String)
                Me.m_category = value
            End Set
        End Property
        Public MustOverride ReadOnly Property Control() As System.Windows.Forms.Control Implements IPadContent.Control
        Public Overridable ReadOnly Property Icon() As String Implements IPadContent.Icon
            Get
                Return Me.m_icon
            End Get
        End Property
        Public Overridable Sub RedrawContent() Implements IPadContent.RedrawContent
        End Sub
        Public Property Shortcut() As String() Implements IPadContent.Shortcut
            Get
                Return Me.m_shortcut
            End Get
            Set(ByVal value As String())
                Me.m_shortcut = value
            End Set
        End Property
        Public Property DockAreas() As String() Implements IPadContent.DockAreas
            Get
                Return Me.m_dockAreas
            End Get
            Set(ByVal Value As String())
                Me.m_dockAreas = Value
            End Set
        End Property
        Public Overridable Property Title() As String Implements IPadContent.Title
            Get
                Dim service1 As StringParserService = CType(ServiceManager.Services.GetService(GetType(StringParserService)), StringParserService)
                Return service1.Parse(Me.m_title)
            End Get
            Set(ByVal Value As String)
                Me.m_title = Value
            End Set
        End Property
        Public Overridable Sub Dispose() Implements System.IDisposable.Dispose
        End Sub
        Public Overridable ReadOnly Property HideOnClose() As Boolean Implements IPadContent.HideOnClose
            Get
                Return True
            End Get
        End Property
#End Region


    End Class
End Namespace

