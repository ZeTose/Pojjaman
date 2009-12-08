Imports System
Imports System.Drawing
Imports System.Collections
Imports System.Drawing.Imaging
Imports System.Drawing.Drawing2D
Imports Microsoft.VisualBasic

Namespace Longkong.Reporting.Printing
    Public Structure Bounds

#Region "Members"
        Public Const FudgeFactor As Single = 0.001!
        Public Limit As PointF
        Public Position As PointF
#End Region

#Region "Constructors"
        Public Sub New(ByVal position As PointF, ByVal limit As PointF)
            Me.Position = position
            Me.Limit = limit
        End Sub
        Public Sub New(ByVal posX As Single, ByVal posY As Single, ByVal limitX As Single, ByVal limitY As Single)
            Me.New(New PointF(posX, posY), New PointF(limitX, limitY))
        End Sub
        Public Sub New(ByVal rectangle As RectangleF)
            Me.New(rectangle.Left, rectangle.Top, rectangle.Right, rectangle.Bottom)
        End Sub
#End Region

#Region "Properties"
        Public ReadOnly Property Height() As Single
            Get
                Return (Me.Limit.Y - Me.Position.Y)
            End Get
        End Property
        Public ReadOnly Property Width() As Single
            Get
                Return (Me.Limit.X - Me.Position.X)
            End Get
        End Property
#End Region

#Region "Methods"
        Private Function Check(ByVal rect As RectangleF) As RectangleF
            If (rect.Right > Me.Limit.X) Then
                rect.Width = (rect.Width - (rect.Right - Me.Limit.X))
            End If
            If (rect.Bottom > Me.Limit.Y) Then
                rect.Height = (rect.Height - (rect.Bottom - Me.Limit.Y))
            End If
            Return rect
        End Function
        Public Overloads Overrides Function Equals(ByVal obj As Object) As Boolean
            If Not TypeOf obj Is Bounds Then
                Return False
            End If
            Dim bounds1 As Bounds = CType(obj, Bounds)
            Return ((Me.Position.X = bounds1.Position.X AndAlso Me.Position.Y = bounds1.Position.Y) AndAlso (Me.Limit.X = bounds1.Limit.X AndAlso Me.Limit.Y = bounds1.Limit.Y))
        End Function
        Public Function GetBounds(ByVal size As SizeF) As Bounds
            Dim tf1 As PointF = Me.Position
            tf1.X = (tf1.X + size.Width)
            tf1.Y = (tf1.Y + size.Height)
            Return New Bounds(Me.Position, tf1)
        End Function
        Public Function GetBounds(ByVal size As SizeF, ByVal hAlign As HorizontalAlignment, ByVal vAlign As VerticalAlignment) As Bounds
            Return New Bounds(Me.GetRectangleF(size, hAlign, vAlign))
        End Function
        Public Function GetBounds(ByVal marginTop As Single, ByVal marginRight As Single, ByVal marginBottom As Single, ByVal marginLeft As Single) As Bounds
            Dim tf1 As PointF = Me.Position
            Dim tf2 As PointF = Me.Limit
            tf1.X = (tf1.X + marginLeft)
            tf1.Y = (tf1.Y + marginTop)
            tf2.X = (tf2.X - marginRight)
            tf2.Y = (tf2.Y - marginBottom)
            Return New Bounds(tf1, tf2)
        End Function
        Public Overrides Function GetHashCode() As Integer
            Return Me.GetHashCode
        End Function
        Public Function GetRectangleF() As RectangleF
            Return New RectangleF(Me.Position, Me.GetSizeF)
        End Function
        Public Function GetRectangleF(ByVal size As SizeF, ByVal hAlign As HorizontalAlignment, ByVal vAlign As VerticalAlignment) As RectangleF
            Dim width As Single = size.Width
            Dim height As Single = size.Height
            Dim x As Single = 0.0!
            Dim y As Single = 0.0!
            Select Case hAlign
                Case HorizontalAlignment.Left
                    x = Me.Position.X
                Case HorizontalAlignment.Right
                    x = (Me.Limit.X - width)
                Case HorizontalAlignment.Center
                    x = (Me.Position.X + ((Me.Width - width) / 2.0!))
            End Select
            Select Case vAlign
                Case VerticalAlignment.Top
                    y = Me.Position.Y
                Case VerticalAlignment.Middle
                    y = (Me.Position.Y + ((Me.Height - height) / 2.0!))
                Case VerticalAlignment.Bottom
                    y = (Me.Limit.Y - height)
            End Select
            Return Me.Check(New RectangleF(x, y, width, height))
        End Function
        Public Function GetSizeF() As SizeF
            Return New SizeF(Me.Width, Me.Height)
        End Function
        Public Function IsEmpty() As Boolean
            Return ((Me.Width <= 0.0!) OrElse (Me.Height <= 0.0!))
        End Function
        Public Function SizeFits(ByVal size As SizeF) As Boolean
            Dim single1 As Single = (size.Height - Me.Height)
            Dim single2 As Single = (size.Width - Me.Width)
            Return ((single1 <= 0.001!) AndAlso (single2 <= 0.001!))
        End Function
        Public Overrides Function ToString() As String
            Return (Me.Position.ToString & ", " & Me.Limit.ToString)
        End Function

















#End Region
    End Structure
End Namespace