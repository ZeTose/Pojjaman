Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports System.Windows.Forms

Namespace Longkong.Pojjaman.Gui.Components
    Public Interface ISideTabItemFactory
        Function CreateSideTabItem(ByVal name As String) As VSSideTabItem
        Function CreateSideTabItem(ByVal name As String, ByVal tag As Object) As VSSideTabItem
        Function CreateSideTabItem(ByVal name As String, ByVal tag As Object, ByVal bitmap As Bitmap) As VSSideTabItem
    End Interface
End Namespace