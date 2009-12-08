Imports Longkong.Pojjaman.Gui.Components
Imports System.Drawing.Drawing2D
Imports System.ComponentModel
Imports System.ComponentModel.Design
Imports System.Windows.Forms.Design
Namespace Longkong.FormTable
    Public Interface IDrawable
        Sub Draw(ByVal g As Graphics, ByVal loc As Point)
        Sub Draw(ByVal g As Graphics, ByVal loc As Point, ByVal data As String)
        Sub Draw(ByVal g As Graphics, ByVal loc As Point, ByVal image As Image)
        Property Data() As String
    End Interface
End Namespace