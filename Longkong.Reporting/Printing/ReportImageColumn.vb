Imports System
Imports System.Drawing
Imports System.Collections
Imports System.Drawing.Imaging
Imports System.Drawing.Drawing2D
Imports Microsoft.VisualBasic

Namespace Longkong.Reporting.Printing
    Public Class ReportImageColumn
        Inherits ReportDataColumn

#Region "Members"
        Public ImageHeight As Single
        Public ImageWidth As Single
#End Region

#Region "Constructors"
        Public Sub New(ByVal field As String, ByVal maxWidth As Single)
            MyBase.New(field, maxWidth)
            Me.ImageWidth = 0.2!
            Me.ImageHeight = 0.2!
        End Sub
#End Region

#Region "Methods"
        Protected Overridable Function GetImage(ByVal drv As DataRowView) As Image
            Dim obj1 As Object = drv.Item(MyBase.Field)
            Return CType(obj1, Image)
        End Function
        Private Function GetImageRect(ByVal bounds As Bounds, ByVal image As Image, ByVal textStyle As TextStyle) As RectangleF
            Dim ef2 As SizeF
            Dim ef1 As SizeF = bounds.GetSizeF
            ef2 = New SizeF(Me.ImageWidth, Me.ImageHeight)
            Return bounds.GetRectangleF(ef2, SectionText.ConvertAlign(textStyle.StringAlignment), textStyle.VerticalAlignment)
        End Function
        Public Overrides Function SizePaintCell(ByVal g As Graphics, ByVal headerRow As Boolean, ByVal alternatingRow As Boolean, ByVal summaryRow As Boolean, ByVal drv As DataRowView, ByVal x As Single, ByVal y As Single, ByVal width As Single, ByVal height As Single, ByVal sizeOnly As Boolean) As SizeF
            Dim ef1 As SizeF
            Dim bounds1 As Bounds
            If (headerRow OrElse summaryRow) Then
                Return MyBase.SizePaintCell(g, headerRow, alternatingRow, summaryRow, drv, x, y, width, height, sizeOnly)
            End If
            ef1 = New SizeF(width, height)
            Dim image1 As Image = Me.GetImage(drv)
            Dim style1 As TextStyle = Me.GetTextStyle(headerRow, alternatingRow, summaryRow)
            Dim single1 As Single = ((style1.MarginNear + style1.MarginFar) + MyBase.RightPenWidth)
            Dim single2 As Single = (style1.MarginTop + style1.MarginBottom)
            bounds1 = New Bounds(x, y, (x + width), (y + height))
            Dim bounds2 As Bounds = bounds1.GetBounds(style1.MarginTop, (style1.MarginFar + MyBase.RightPenWidth), style1.MarginBottom, style1.MarginNear)
            Dim ef2 As SizeF = bounds2.GetSizeF
            If sizeOnly Then
                If (image1 Is Nothing) Then
                    ef1.Width = 0.0!
                    ef1.Height = 0.0!
                    Return ef1
                End If
                ef1.Width = Me.ImageWidth
                ef1.Height = Me.ImageHeight
                Return ef1
            End If
            If (Not style1.BackgroundBrush Is Nothing) Then
                g.FillRectangle(style1.BackgroundBrush, bounds1.GetRectangleF)
            End If
            If (Not image1 Is Nothing) Then
                Dim ef3 As RectangleF = Me.GetImageRect(bounds2, image1, style1)
                g.DrawImage(image1, ef3)
            End If
            Return ef1
        End Function
#End Region

    End Class
End Namespace