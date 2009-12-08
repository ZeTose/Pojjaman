Imports Longkong.Core.AddIns.Conditions
Imports Longkong.Core.AddIns.Codons
Imports Longkong.Core.Services
Imports Longkong.Pojjaman.Services
Namespace Longkong.Pojjaman.Gui.Components
    Public Class PojjamanSideTabItemFactory
        Implements ISideTabItemFactory

#Region "Constructors"
        Public Sub New()
        End Sub
#End Region

#Region "Methods"
        Public Overloads Function CreateSideTabItem(ByVal name As String) As VSSideTabItem Implements ISideTabItemFactory.CreateSideTabItem
            Return New PojjamanSideTabItem(name)
        End Function

        Public Overloads Function CreateSideTabItem(ByVal name As String, ByVal tag As Object) As VSSideTabItem Implements ISideTabItemFactory.CreateSideTabItem
            Return New PojjamanSideTabItem(name, tag)
        End Function

        Public Overloads Function CreateSideTabItem(ByVal name As String, ByVal tag As Object, ByVal bitmap As System.Drawing.Bitmap) As VSSideTabItem Implements ISideTabItemFactory.CreateSideTabItem
            Return New PojjamanSideTabItem(name, tag, bitmap)
        End Function
#End Region

    End Class
End Namespace

