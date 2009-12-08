Imports Longkong.Core.AddIns.Conditions
Imports Longkong.Core.AddIns.Codons
Imports Longkong.Core.Services
Imports Longkong.Pojjaman.Services
Imports Longkong.CustomControl
Namespace Longkong.Pojjaman.Gui.Components
    Public Class PojjamanSideTabItem
        Inherits VSSideTabItem

#Region "Members"
        Private m_resourceService As resourceService
#End Region

#Region "Constructors"
        Public Sub New(ByVal name As String)
            MyBase.New(name)
            Me.m_resourceService = CType(ServiceManager.Services.GetService(GetType(IResourceService)), ResourceService)
            MyBase.Icon = Me.m_resourceService.GetBitmap("Icons.16x16.SideBarDocument")
        End Sub
        Public Sub New(ByVal name As String, ByVal tag As Object)
            MyBase.New(name, tag)
            Me.m_resourceService = CType(ServiceManager.Services.GetService(GetType(IResourceService)), ResourceService)
            MyBase.Icon = Me.m_resourceService.GetBitmap("Icons.16x16.SideBarDocument")
        End Sub
        Public Sub New(ByVal name As String, ByVal tag As Object, ByVal icon As Bitmap)
            MyBase.New(name, tag, icon)
            Me.m_resourceService = CType(ServiceManager.Services.GetService(GetType(IResourceService)), ResourceService)
        End Sub
#End Region

    End Class
End Namespace

