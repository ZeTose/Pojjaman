Imports System
Imports System.Diagnostics
Imports System.Drawing
Imports System.Reflection
Imports System.Windows.Forms
Imports System.ComponentModel

Namespace Longkong.Pojjaman.Gui.Components
    Public Class PropertyComboBox
        Inherits ComboBox

#Region "Members"

#End Region

#Region "Constructors"
        Public Sub New()
            MyBase.New()
            Me.DrawMode = DrawMode.OwnerDrawFixed
        End Sub
#End Region

#Region "Overrides"
        Protected Overrides Sub OnDrawItem(ByVal dea As System.Windows.Forms.DrawItemEventArgs)
            If ((dea.Index < 0) OrElse (dea.Index >= Me.Items.Count)) Then
                Return
            End If
            Dim g As Graphics = dea.Graphics
            Dim b As Brush = SystemBrushes.ControlText
            If ((dea.State And DrawItemState.Selected) = DrawItemState.Selected) Then
                If ((dea.State And DrawItemState.Focus) = DrawItemState.Focus) Then
                    g.FillRectangle(SystemBrushes.Highlight, dea.Bounds)
                    b = SystemBrushes.HighlightText
                Else
                    g.FillRectangle(SystemBrushes.Window, dea.Bounds)
                End If
            Else
                g.FillRectangle(SystemBrushes.Window, dea.Bounds)
            End If
            Dim obj As Object = Me.Items(dea.Index)
            Dim xPos As Integer = dea.Bounds.X
            If TypeOf obj Is IComponent Then
                Dim site As ISite = CType(obj, IComponent).Site
                If (Not site Is Nothing) Then
                    Dim name As String = site.Name
                    Dim f As New Font(Me.Font, FontStyle.Bold)
                    g.DrawString(name, f, b, CType(xPos, Single), CType(dea.Bounds.Y, Single))
                    Dim ef1 As SizeF = g.MeasureString((name & "-"), f)
                    xPos = (xPos + CType(ef1.Width, Integer))
                End If
            End If
            Dim typeString As String = obj.GetType.ToString
            g.DrawString(typeString, Me.Font, b, CType(xPos, Single), CType(dea.Bounds.Y, Single))
        End Sub
        Protected Overrides Sub OnMeasureItem(ByVal mea As System.Windows.Forms.MeasureItemEventArgs)
            If ((mea.Index < 0) OrElse (mea.Index >= Me.Items.Count)) Then
                mea.ItemHeight = Me.Font.Height
            Else
                Dim obj As Object = Me.Items(mea.Index)
                Dim size As SizeF = mea.Graphics.MeasureString(obj.GetType.ToString, Me.Font)
                mea.ItemHeight = CType(size.Height, Integer)
                mea.ItemWidth = CType(size.Width, Integer)
                If TypeOf obj Is IComponent Then
                    Dim site As ISite = CType(obj, IComponent).Site
                    If (Not site Is Nothing) Then
                        Dim name As String = site.Name
                        Dim f As New Font(Me.Font, FontStyle.Bold)
                        mea.ItemWidth = (mea.ItemWidth + CType(mea.Graphics.MeasureString(name + "-", f).Width, Integer))
                    End If
                End If
            End If
        End Sub
#End Region


    End Class
End Namespace

