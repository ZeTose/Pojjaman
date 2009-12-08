Imports Longkong.Pojjaman.Services
Imports Longkong.Core.Services
Imports Longkong.Pojjaman.BrowserDisplayBinding
Imports Longkong.Pojjaman.Gui
Imports Longkong.Pojjaman.Gui.Panels
Namespace Longkong.Pojjaman.PanelDisplayBinding
    Public Class DetailPanelView
        Inherits AbstractSecondaryViewContent

#Region "Members"
        Protected m_control As UserControl
#End Region

#Region "Constructors"
        Public Sub New(ByVal control As UserControl)
            Me.m_control = control
            Dim strParserSrv As StringParserService = CType(ServiceManager.Services.GetService(GetType(StringParserService)), StringParserService)

            If TypeOf Me.m_control Is IEntityPanel Then
            End If
            Dim myMenuService As MenuService = CType(ServiceManager.Services.GetService(GetType(MenuService)), MenuService)
        End Sub
#End Region

#Region "Propertis"
        Public Overrides ReadOnly Property Control() As Control
            Get
                Return Me.m_control
            End Get
        End Property
#End Region

    End Class
End Namespace

