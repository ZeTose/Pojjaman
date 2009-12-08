Imports System
Imports System.Diagnostics
Imports System.Drawing
Imports System.Reflection
Imports System.Windows.Forms
Imports System.ComponentModel

Namespace Longkong.Pojjaman.Gui.Components
    Public Class DropDownLabel
        Inherits Label

#Region "Constructors"
        Public Sub New()
            MyBase.SetStyle(ControlStyles.UserPaint, True)
            MyBase.SetStyle(ControlStyles.DoubleBuffer, True)
            MyBase.SetStyle(ControlStyles.AllPaintingInWmPaint, True)
        End Sub
#End Region

#Region "Methods"
        Protected Overrides Sub OnPaint(ByVal e As PaintEventArgs)
            MyBase.OnPaint(e)
            ControlPaint.DrawSizeGrip(e.Graphics, Color.Black, 0, 0, 16, 16)
        End Sub
#End Region

    End Class
End Namespace

