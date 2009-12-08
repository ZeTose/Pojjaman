Imports System.Drawing
Namespace Longkong.Pojjaman.Gui.Components
    Public Class AxStatusBarPanel
        Inherits StatusBarPanel

#Region "Members"
        Private sFormat As StringFormat
#End Region

#Region "Constructors"
        Public Sub New()
            Me.sFormat = New StringFormat
            MyBase.Style = StatusBarPanelStyle.OwnerDraw
            MyBase.BorderStyle = StatusBarPanelBorderStyle.None
            Me.sFormat.LineAlignment = StringAlignment.Center
        End Sub

#End Region

#Region "Methods"
        Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
            If disposing Then
                Me.sFormat.Dispose()
            End If
        End Sub
        Protected Overridable Sub DrawBorder(ByVal drawEventArgs As StatusBarDrawItemEventArgs)
            drawEventArgs.Graphics.DrawRectangle(SystemPens.ControlDark, New Rectangle(drawEventArgs.Bounds.X, drawEventArgs.Bounds.Y, (drawEventArgs.Bounds.Width - 1), (drawEventArgs.Bounds.Height - 1)))
        End Sub
        Public Overridable Sub DrawPanel(ByVal drawEventArgs As StatusBarDrawItemEventArgs)
            Dim graphics1 As Graphics = drawEventArgs.Graphics
            Select Case MyBase.Alignment
                Case HorizontalAlignment.Left
                    Me.sFormat.Alignment = StringAlignment.Near
                Case HorizontalAlignment.Right
                    Me.sFormat.Alignment = StringAlignment.Far
                Case HorizontalAlignment.Center
                    Me.sFormat.Alignment = StringAlignment.Center
            End Select
            graphics1.DrawString(MyBase.Text, drawEventArgs.Font, SystemBrushes.ControlText, CType(RectangleF.op_Implicit(drawEventArgs.Bounds), RectangleF), Me.sFormat)
            Me.DrawBorder(drawEventArgs)
        End Sub
#End Region
    End Class
End Namespace
