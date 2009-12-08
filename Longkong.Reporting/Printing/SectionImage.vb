Imports System
Imports System.Drawing
Imports System.Collections
Imports System.Drawing.Imaging
Imports System.Drawing.Drawing2D
Imports Microsoft.VisualBasic

Namespace Longkong.Reporting.Printing
    Public Class SectionImage
        Inherits ReportSection

#Region "Members"
        Private m_image As image
        Private m_imageRect As RectangleF
        Private m_opacity As Single
        Private m_preserveAspectRatio As Boolean
#End Region

#Region "Constructors"
        Public Sub New(ByVal image As Image)
            Me.m_preserveAspectRatio = True
            Me.Transparency = 0.0!
            Me.Image = image
        End Sub
#End Region

#Region "Properties"
        Public Overridable Property Image() As Image
            Get
                Return Me.m_image
            End Get
            Set(ByVal value As Image)
                Me.m_image = value
            End Set
        End Property
        Public Property PreserveAspectRatio() As Boolean
            Get
                Return Me.m_preserveAspectRatio
            End Get
            Set(ByVal value As Boolean)
                Me.m_preserveAspectRatio = value
            End Set
        End Property
        Public Property Transparency() As Single
            Get
                Return (100.0! - (Me.m_opacity * 100.0!))
            End Get
            Set(ByVal value As Single)
                If ((value < 0.0!) OrElse (value > 100.0!)) Then
                    Throw New ArgumentException("Transparency must be between 0 and 100")
                End If
                Me.m_opacity = ((100.0! - value) / 100.0!)
            End Set
        End Property
#End Region

#Region "Methods"
        Protected Overrides Function BoundsChanged(ByVal originalBounds As Bounds, ByVal newBounds As Bounds) As SectionSizeValues
            Dim values1 As SectionSizeValues
            values1 = New SectionSizeValues
            Me.m_imageRect = Me.GetImageRect(newBounds)
            values1.RequiredSize = Me.m_imageRect.Size
            values1.Fits = newBounds.SizeFits(values1.RequiredSize)
            values1.Continued = False
            Return values1
        End Function
        Protected Overrides Sub DoBeginPrint(ByVal g As Graphics)
        End Sub
        Protected Overrides Function DoCalcSize(ByVal reportDocument As ReportDocument, ByVal g As Graphics, ByVal bounds As Bounds) As SectionSizeValues
            Dim values1 As SectionSizeValues
            values1 = New SectionSizeValues
            Me.m_imageRect = Me.GetImageRect(bounds)
            values1.RequiredSize = Me.m_imageRect.Size
            values1.Fits = bounds.SizeFits(values1.RequiredSize)
            values1.Continued = False
            Return values1
        End Function
        Protected Overrides Sub DoPrint(ByVal reportDocument As ReportDocument, ByVal g As Graphics, ByVal bounds As Bounds)
            Me.DrawImage(g, Me.m_image, Me.m_imageRect)
        End Sub
        Private Sub DrawImage(ByVal g As Graphics, ByVal image As Image, ByVal destRect As RectangleF)
            Dim tfArray2 As PointF() = New PointF() {New PointF(destRect.Left, destRect.Top), New PointF(destRect.Right, destRect.Top), New PointF(destRect.Left, destRect.Bottom)}
            Dim tfArray1 As PointF() = tfArray2
            Dim matrix1 As New ColorMatrix
            matrix1.Matrix00 = 1.0!
            matrix1.Matrix11 = 1.0!
            matrix1.Matrix22 = 1.0!
            matrix1.Matrix33 = Me.m_opacity
            matrix1.Matrix44 = 1.0!
            Dim attributes1 As New ImageAttributes
            attributes1.SetColorMatrix(matrix1, ColorMatrixFlag.Default, ColorAdjustType.Bitmap)
            g.DrawImage(image, tfArray1, New RectangleF(0, 0, image.Width, image.Height), GraphicsUnit.Pixel, attributes1)
        End Sub
        Private Function GetImageRect(ByVal bounds As Bounds) As RectangleF
            Dim ef2 As SizeF
            Dim ef1 As SizeF = bounds.GetSizeF
            Dim single1 As Single = (ef1.Width / CType(Me.Image.Width, Single))
            Dim single2 As Single = (ef1.Height / CType(Me.Image.Height, Single))
            If Me.PreserveAspectRatio Then
                Dim single3 As Single = Math.Min(single1, single2)
                single1 = single3
                single2 = single3
            End If
            Dim single4 As Single = (single1 * Me.Image.Width)
            Dim single5 As Single = (single2 * Me.Image.Height)
            ef2 = New SizeF(single4, single5)
            Return bounds.GetRectangleF(ef2, Me.HorizontalAlignment, Me.VerticalAlignment)
        End Function
#End Region

    End Class
End Namespace