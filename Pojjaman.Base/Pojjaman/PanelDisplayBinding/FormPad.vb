Imports Longkong.Pojjaman.Services
Imports Longkong.Core.Services
Imports Longkong.Pojjaman.BrowserDisplayBinding
Imports Longkong.Pojjaman.Gui
Namespace Longkong.Pojjaman.FormDisplayBinding
    Public Class FormPad
        Inherits AbstractPadContent

#Region "Members"
        Protected m_formViewPane As UserControl
#End Region

#Region "Constructors"
        Public Sub New()
            Me.New(True)
        End Sub
        Public Sub New(ByVal showNavigation As Boolean)
            Me.m_formViewPane = New FormViewPane(showNavigation)
            Dim strParserSrv As StringParserService = CType(ServiceManager.Services.GetService(GetType(StringParserService)), StringParserService)
        End Sub
        Public Sub New(ByVal title As String)
            MyBase.New(title)
        End Sub
        Public Sub New(ByVal pane As UserControl, ByVal title As String)
            MyBase.New(title)
            Me.m_formViewPane = pane

        End Sub
#End Region

#Region "Properties"
        Public Overrides ReadOnly Property Control() As Control
            Get
                Return Me.m_formViewPane
            End Get
        End Property
#End Region

#Region "Methods"
        Public Overrides Sub Dispose()
            Me.m_formViewPane.Dispose()
        End Sub
#End Region

    End Class
End Namespace

