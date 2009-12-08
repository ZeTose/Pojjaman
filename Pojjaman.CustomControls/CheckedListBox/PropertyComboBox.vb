Imports System
Imports System.Diagnostics
Imports System.Drawing
Imports System.Reflection
Imports System.Windows.Forms
Imports System.ComponentModel

Namespace Longkong.Pojjaman.Gui.Components
    Public Class PJMCheckedListBox
        Inherits CheckedListBox

#Region "Must Overrides"
        Protected Overrides Sub RefreshItem(ByVal index As Integer)
            MyBase.RefreshItem(index)
        End Sub

        Protected Overrides Sub SetItemsCore(ByVal items As System.Collections.IList)
            MyBase.SetItemsCore(items)
        End Sub
#End Region

#Region "Overrides"
        Protected Overrides Sub OnMouseDown(ByVal e As System.Windows.Forms.MouseEventArgs)
            MyBase.OnMouseDown(e)
            Me.CheckOnClick = False
        End Sub
#End Region


    End Class
End Namespace

