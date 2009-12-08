Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports System.Windows.Forms

Namespace Longkong.Pojjaman.Gui.Components
    Public Class DefaultSideTabItemFactory
        Implements ISideTabItemFactory

#Region "Constructors"
        Public Sub New()
        End Sub
#End Region

#Region "ISideTabItemFactory"
        Public Overloads Function CreateSideTabItem(ByVal name As String) As VSSideTabItem Implements ISideTabItemFactory.CreateSideTabItem
            Return New VSSideTabItem(name)
        End Function

        Public Overloads Function CreateSideTabItem(ByVal name As String, ByVal tag As Object) As VSSideTabItem Implements ISideTabItemFactory.CreateSideTabItem
            Return New VSSideTabItem(name, tag)
        End Function

        Public Overloads Function CreateSideTabItem(ByVal name As String, ByVal tag As Object, ByVal bitmap As System.Drawing.Bitmap) As VSSideTabItem Implements ISideTabItemFactory.CreateSideTabItem
            Return New VSSideTabItem(name, tag, bitmap)
        End Function
#End Region

    End Class
End Namespace