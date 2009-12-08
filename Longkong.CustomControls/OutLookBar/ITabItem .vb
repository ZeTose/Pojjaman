Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports System.Windows.Forms

Namespace Longkong.CustomControl
    Public Interface ITabItem
        Function CalcHeight(ByVal g As Graphics, ByVal font As Font, ByVal width As Integer, ByVal LargeImage As Boolean) As Integer
        Sub Draw(ByVal g As Graphics, ByVal font As Font, ByVal foreBrush As Brush, ByVal location As Point, _
        ByVal maxWidth As Integer, ByVal state As ListViewItemState)
        'Sub DrawImage(ByVal g As Graphics, ByVal destRect As Rectangle, ByVal state As ListViewItemState)
        Sub DrawLarge(ByVal g As Graphics, ByVal font As Font, ByVal foreBrush As Brush, _
       ByVal location As Point, ByVal maxWidth As Integer, ByVal state As ListViewItemState)
        Sub DrawSmall(ByVal g As Graphics, ByVal font As Font, ByVal foreBrush As Brush, _
        ByVal location As Point, ByVal maxWidth As Integer, ByVal state As ListViewItemState)
        ReadOnly Property Height() As Integer
        Property Parent() As ImageListView
        ReadOnly Property Location() As Point
        Property Text() As String
        Property Tag() As Object
        Function HitTest(ByVal pt As Point) As Boolean
        WriteOnly Property Icon() As Bitmap
    End Interface
End Namespace