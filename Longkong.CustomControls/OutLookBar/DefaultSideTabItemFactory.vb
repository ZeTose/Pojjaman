Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports System.Windows.Forms

Namespace Longkong.CustomControl
    Public Class DefaultSideTabItemFactory
        Implements ISideTabItemFactory

#Region "Constructors"
        Public Sub New()
        End Sub
#End Region

#Region "ISideTabItemFactory"
        Public Overloads Function CreateSideTabItem(ByVal name As String) As TabItem Implements ISideTabItemFactory.CreateSideTabItem
            Return New TabItem(name)
        End Function

        Public Overloads Function CreateSideTabItem(ByVal name As String, ByVal tag As Object) As TabItem Implements ISideTabItemFactory.CreateSideTabItem
            Return New TabItem(name, tag)
        End Function

        Public Overloads Function CreateSideTabItem(ByVal name As String, ByVal tag As Object, ByVal bitmap As System.Drawing.Bitmap) As TabItem Implements ISideTabItemFactory.CreateSideTabItem
            Return New TabItem(name, tag, bitmap)
        End Function
#End Region

    End Class
End Namespace