Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports System.Windows.Forms

Namespace Longkong.CustomControl
    Public Interface ISideTabItemFactory
        Function CreateSideTabItem(ByVal name As String) As TabItem
        Function CreateSideTabItem(ByVal name As String, ByVal tag As Object) As TabItem
        Function CreateSideTabItem(ByVal name As String, ByVal tag As Object, ByVal bitmap As Bitmap) As TabItem
    End Interface
End Namespace