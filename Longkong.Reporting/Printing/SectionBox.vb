Imports System
Imports System.Drawing
Imports System.Collections
Imports System.Drawing.Imaging
Imports System.Drawing.Drawing2D
Imports Microsoft.VisualBasic

Namespace Longkong.Reporting.Printing
    Public Class SectionBox
        Inherits SectionContainer


#Region "Members"
        Private m_background As Brush
        Private m_border As BorderPens
        Private m_borderBounds As Bounds
        Private m_contentBounds As Bounds
        Private m_height As Single
        Private m_heightPercent As Single
        Private m_offsetLeft As Single
        Private m_offsetTop As Single
        Private m_paddingBottom As Single
        Private m_paddingBounds As Bounds
        Private m_paddingLeft As Single
        Private m_paddingRight As Single
        Private m_paddingTop As Single
        Private m_width As Single
        Private m_widthPercent As Single
#End Region

#Region "Constructors"
        Public Sub New()
            Me.m_border = New BorderPens
        End Sub
#End Region

#Region "Properties"
        Public Property Background() As Brush
            Get
                Return Me.m_background
            End Get
            Set(ByVal value As Brush)
                Me.m_background = value
            End Set
        End Property
        Public WriteOnly Property Border() As Pen
            Set(ByVal value As Pen)
                Me.BorderTop = value
                Me.BorderRight = value
                Me.BorderBottom = value
                Me.BorderLeft = value
            End Set
        End Property
        Public Property BorderBottom() As Pen
            Get
                Return Me.m_border.Bottom
            End Get
            Set(ByVal value As Pen)
                Me.m_border.Bottom = value
            End Set
        End Property
        Public Property BorderLeft() As Pen
            Get
                Return Me.m_border.Left
            End Get
            Set(ByVal value As Pen)
                Me.m_border.Left = value
            End Set
        End Property
        Public Property BorderRight() As Pen
            Get
                Return Me.m_border.Right
            End Get
            Set(ByVal value As Pen)
                Me.m_border.Right = value
            End Set
        End Property
        Public Property BorderTop() As Pen
            Get
                Return Me.m_border.Top
            End Get
            Set(ByVal value As Pen)
                Me.m_border.Top = value
            End Set
        End Property
        Public Property Height() As Single
            Get
                Return Me.m_height
            End Get
            Set(ByVal value As Single)
                Me.m_height = value
            End Set
        End Property
        Public Property HeightPercent() As Single
            Get
                Return Me.m_heightPercent
            End Get
            Set(ByVal value As Single)
                If ((value < 0.0!) OrElse (value > 100.0!)) Then
                    Throw New ArgumentException("HeightPercent must be between 0 and 100, inclusive")
                End If
                Me.m_heightPercent = value
            End Set
        End Property
        Public Property OffsetLeft() As Single
            Get
                Return Me.m_offsetLeft
            End Get
            Set(ByVal value As Single)
                Me.m_offsetLeft = value
            End Set
        End Property
        Public Property OffsetTop() As Single
            Get
                Return Me.m_offsetTop
            End Get
            Set(ByVal value As Single)
                Me.m_offsetTop = value
            End Set
        End Property
        Public WriteOnly Property Padding() As Single
            Set(ByVal value As Single)
                Me.PaddingTop = value
                Me.PaddingRight = value
                Me.PaddingBottom = value
                Me.PaddingLeft = value
            End Set
        End Property
        Public Property PaddingBottom() As Single
            Get
                Return Me.m_paddingBottom
            End Get
            Set(ByVal value As Single)
                Me.m_paddingBottom = value
            End Set
        End Property
        Public Property PaddingLeft() As Single
            Get
                Return Me.m_paddingLeft
            End Get
            Set(ByVal value As Single)
                Me.m_paddingLeft = value
            End Set
        End Property
        Public Property PaddingRight() As Single
            Get
                Return Me.m_paddingRight
            End Get
            Set(ByVal value As Single)
                Me.m_paddingRight = value
            End Set
        End Property
        Public Property PaddingTop() As Single
            Get
                Return Me.m_paddingTop
            End Get
            Set(ByVal value As Single)
                Me.m_paddingTop = value
            End Set
        End Property
        Private ReadOnly Property SizeToContentsHeight() As Boolean
            Get
                Return ((Me.HeightPercent = 0.0!) AndAlso (Me.Height = 0.0!))
            End Get
        End Property
        Private ReadOnly Property SizeToContentsWidth() As Boolean
            Get
                Return ((Me.WidthPercent = 0.0!) AndAlso (Me.Width = 0.0!))
            End Get
        End Property
        Public Property Width() As Single
            Get
                Return Me.m_width
            End Get
            Set(ByVal value As Single)
                Me.m_width = value
            End Set
        End Property
        Public Property WidthPercent() As Single
            Get
                Return Me.m_widthPercent
            End Get
            Set(ByVal value As Single)
                If ((value < 0.0!) OrElse (value > 100.0!)) Then
                    Throw New ArgumentException("WidthPercent must be between 0 and 100, inclusive")
                End If
                Me.m_widthPercent = value
            End Set
        End Property
#End Region

#Region "Methods"
        Public Overrides Function AddSection(ByVal section As ReportSection) As Integer
            If (Me.m_sections.Count > 0) Then
                Throw New ApplicationException("Only one section may be directly added to box. Use another container like Layered to hold additional sections.")
            End If
            Return Me.m_sections.Add(section)
        End Function
        Protected Overrides Function BoundsChanged(ByVal originalBounds As Bounds, ByVal newBounds As Bounds) As SectionSizeValues
            Dim values1 As SectionSizeValues
            values1 = New SectionSizeValues
            values1.Fits = MyBase.Fits
            values1.Continued = MyBase.Continued
            values1.RequiredSize = MyBase.RequiredSize
            Return values1
        End Function
        Protected Overrides Sub DoBeginPrint(ByVal g As Graphics)
        End Sub
        Protected Overrides Function DoCalcSize(ByVal reportDocument As ReportDocument, ByVal g As Graphics, ByVal bounds As Bounds) As SectionSizeValues
            Dim values1 As SectionSizeValues
            Dim ef1 As SizeF
            bounds.Position.X = (bounds.Position.X + Me.OffsetLeft)
            bounds.Position.Y = (bounds.Position.Y + Me.OffsetTop)
            values1 = New SectionSizeValues
            values1.Fits = True
            values1.Continued = False
            ef1 = New SizeF(0.0!, 0.0!)
            If (Not MyBase.CurrentSection Is Nothing) Then
                MyBase.CurrentSection.CalcSize(reportDocument, g, Me.GetMaxContentBounds(bounds))
                ef1 = MyBase.CurrentSection.Size
            End If
            Me.m_borderBounds = Me.GetBorderBounds(bounds, ef1)
            Me.m_paddingBounds = Me.m_border.GetInnerBounds(Me.m_borderBounds)
            Me.m_contentBounds = Me.m_paddingBounds.GetBounds(Me.PaddingTop, Me.PaddingRight, Me.PaddingBottom, Me.PaddingLeft)
            values1.RequiredSize = Me.m_borderBounds.GetSizeF
            Return values1
        End Function
        Protected Overrides Sub DoPrint(ByVal reportDocument As ReportDocument, ByVal g As Graphics, ByVal bounds As Bounds)
            Me.m_border.DrawBorder(g, Me.m_borderBounds)
            If (Not Me.Background Is Nothing) Then
                g.FillRectangle(Me.Background, Me.m_paddingBounds.GetRectangleF)
            End If
            If (Not MyBase.CurrentSection Is Nothing) Then
                MyBase.CurrentSection.Print(reportDocument, g, Me.m_contentBounds)
            End If
        End Sub
        Private Function GetBorderBounds(ByVal bounds As Bounds, ByVal contentSize As SizeF) As Bounds
            Dim ef1 As SizeF = bounds.GetSizeF
            If Me.SizeToContentsWidth Then
                ef1.Width = ((((contentSize.Width + Me.PaddingLeft) + Me.PaddingRight) + Me.m_border.LeftWidth) + Me.m_border.RightWidth)
            Else
                Dim single1 As Single = Me.Width
                If (Me.WidthPercent > 0.0!) Then
                    single1 = (bounds.Width * (Me.WidthPercent / 100.0!))
                End If
                ef1.Width = ((single1 - Me.MarginLeft) - Me.MarginRight)
            End If
            If Me.SizeToContentsHeight Then
                ef1.Height = ((((contentSize.Height + Me.PaddingTop) + Me.PaddingBottom) + Me.m_border.LeftWidth) + Me.m_border.RightWidth)
            Else
                Dim single2 As Single = Me.Height
                If (Me.HeightPercent > 0.0!) Then
                    single2 = (bounds.Height * (Me.HeightPercent / 100.0!))
                End If
                ef1.Height = ((single2 - Me.MarginTop) - Me.MarginBottom)
            End If
            Return bounds.GetBounds(ef1, Me.HorizontalAlignment, Me.VerticalAlignment)
        End Function
        Private Function GetMaxContentBounds(ByVal bounds As Bounds) As Bounds
            bounds.Position.X = (bounds.Position.X + (Me.m_border.LeftWidth + Me.PaddingLeft))
            bounds.Position.Y = (bounds.Position.Y + (Me.m_border.TopWidth + Me.PaddingTop))
            If (Me.Width > 0.0!) Then
                Dim single1 As Single = ((((((Me.Width - Me.MarginLeft) - Me.MarginRight) - Me.m_border.LeftWidth) - Me.m_border.RightWidth) - Me.PaddingLeft) - Me.PaddingRight)
                bounds.Limit.X = (bounds.Position.X + single1)
            Else
                If (Me.WidthPercent > 0.0!) Then
                    Dim single2 As Single = ((((((((bounds.Width * Me.WidthPercent) / 100.0!) - Me.MarginLeft) - Me.MarginRight) - Me.m_border.LeftWidth) - Me.m_border.RightWidth) - Me.PaddingLeft) - Me.PaddingRight)
                    bounds.Limit.X = (bounds.Position.X + single2)
                Else
                    bounds.Limit.X = (bounds.Limit.X - (Me.m_border.RightWidth + Me.PaddingRight))
                End If
            End If
            If (Me.Height > 0.0!) Then
                Dim single3 As Single = ((((((Me.Height - Me.MarginTop) - Me.MarginBottom) - Me.m_border.TopWidth) - Me.m_border.BottomWidth) - Me.PaddingTop) - Me.PaddingBottom)
                bounds.Limit.Y = (bounds.Position.Y + single3)
                Return bounds
            End If
            If (Me.HeightPercent > 0.0!) Then
                Dim single4 As Single = ((((((((bounds.Height * Me.HeightPercent) / 100.0!) - Me.MarginTop) - Me.MarginBottom) - Me.m_border.TopWidth) - Me.m_border.BottomWidth) - Me.PaddingTop) - Me.PaddingBottom)
                bounds.Limit.Y = (bounds.Position.Y + single4)
                Return bounds
            End If
            bounds.Limit.Y = (bounds.Limit.Y - (Me.m_border.BottomWidth + Me.PaddingBottom))
            Return bounds
        End Function
#End Region

    End Class
End Namespace