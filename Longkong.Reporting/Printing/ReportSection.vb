Imports System
Imports System.Drawing
Imports System.Collections
Imports System.Drawing.Imaging
Imports System.Drawing.Drawing2D
Imports Microsoft.VisualBasic

Namespace Longkong.Reporting.Printing
    Public MustInherit Class ReportSection

#Region "Members"
        Private m_continued As Boolean
        Private m_fits As Boolean
        Private m_horizontalAlignment As HorizontalAlignment
        Private m_keepTogether As Boolean
        Private m_marginBottom As Single
        Private m_marginLeft As Single
        Private m_marginRight As Single
        Private m_marginTop As Single
        Private m_maxHeight As Single
        Private m_maxWidth As Single
        Private m_requiredSize As SizeF
        Protected m_requiresNonEmptyBounds As Boolean
        Private m_size As SizeF
        Private m_sized As Boolean
        Private m_sizingBounds As Bounds
        Private m_startedPrinting As Boolean
        Private m_useFullHeight As Boolean
        Private m_useFullWidth As Boolean
        Private m_verticalAlignment As VerticalAlignment
#End Region

#Region "Constructors"
        Public Sub New()
            Me.m_requiresNonEmptyBounds = True
        End Sub
#End Region

#Region "Properties"
        Protected Friend ReadOnly Property Continued() As Boolean
            Get
                Return Me.m_continued
            End Get
        End Property
        Protected Friend ReadOnly Property Fits() As Boolean
            Get
                Return Me.m_fits
            End Get
        End Property
        Public Overridable Property HorizontalAlignment() As HorizontalAlignment
            Get
                Return Me.m_horizontalAlignment
            End Get
            Set(ByVal value As HorizontalAlignment)
                Me.m_horizontalAlignment = value
            End Set
        End Property
        Public Property KeepTogether() As Boolean
            Get
                Return Me.m_keepTogether
            End Get
            Set(ByVal value As Boolean)
                Me.m_keepTogether = value
            End Set
        End Property
        Public Overridable WriteOnly Property Margin() As Single
            Set(ByVal value As Single)
                Me.MarginTop = value
                Me.MarginRight = value
                Me.MarginBottom = value
                Me.MarginLeft = value
            End Set
        End Property
        Public Overridable Property MarginBottom() As Single
            Get
                Return Me.m_marginBottom
            End Get
            Set(ByVal value As Single)
                Me.m_marginBottom = value
            End Set
        End Property
        Public Overridable Property MarginLeft() As Single
            Get
                Return Me.m_marginLeft
            End Get
            Set(ByVal value As Single)
                Me.m_marginLeft = value
            End Set
        End Property
        Public Overridable Property MarginRight() As Single
            Get
                Return Me.m_marginRight
            End Get
            Set(ByVal value As Single)
                Me.m_marginRight = value
            End Set
        End Property
        Public Overridable Property MarginTop() As Single
            Get
                Return Me.m_marginTop
            End Get
            Set(ByVal value As Single)
                Me.m_marginTop = value
            End Set
        End Property
        Public Property MaxHeight() As Single
            Get
                Return Me.m_maxHeight
            End Get
            Set(ByVal value As Single)
                Me.m_maxHeight = value
            End Set
        End Property
        Public Property MaxWidth() As Single
            Get
                Return Me.m_maxWidth
            End Get
            Set(ByVal value As Single)
                Me.m_maxWidth = value
            End Set
        End Property
        Protected Friend ReadOnly Property RequiredSize() As SizeF
            Get
                Return Me.m_requiredSize
            End Get
        End Property
        Protected Friend ReadOnly Property Size() As SizeF
            Get
                Return Me.m_size
            End Get
        End Property
        Public Overridable Property UseFullHeight() As Boolean
            Get
                Return Me.m_useFullHeight
            End Get
            Set(ByVal value As Boolean)
                Me.m_useFullHeight = value
            End Set
        End Property
        Public Overridable Property UseFullWidth() As Boolean
            Get
                Return Me.m_useFullWidth
            End Get
            Set(ByVal value As Boolean)
                Me.m_useFullWidth = value
            End Set
        End Property
        Public Overridable Property VerticalAlignment() As VerticalAlignment
            Get
                Return Me.m_verticalAlignment
            End Get
            Set(ByVal value As VerticalAlignment)
                Me.m_verticalAlignment = value
            End Set
        End Property
#End Region

#Region "Methods"
        Public Sub BeginPrint(ByVal g As Graphics)
            If Not Me.m_startedPrinting Then
                Me.DoBeginPrint(g)
                Me.m_startedPrinting = True
            End If
        End Sub
        Protected Overridable Function BoundsChanged(ByVal originalBounds As Bounds, ByVal newBounds As Bounds) As SectionSizeValues
            Dim values1 As SectionSizeValues
            values1 = New SectionSizeValues
            values1.Fits = Me.Fits
            values1.Continued = Me.Continued
            values1.RequiredSize = Me.RequiredSize
            Return values1
        End Function
        Public Sub CalcSize(ByVal reportDocument As ReportDocument, ByVal g As Graphics, ByVal bounds As Bounds)
            Me.BeginPrint(g)
            If (Me.m_requiresNonEmptyBounds AndAlso bounds.IsEmpty) Then
                Me.m_fits = False
            Else
                If Not Me.m_sized Then
                    Me.m_sizingBounds = Me.LimitBounds(bounds)
                    Dim values1 As SectionSizeValues = Me.DoCalcSize(reportDocument, g, Me.m_sizingBounds)
                    Me.SetSize(values1.RequiredSize, bounds)
                    If (Me.m_keepTogether AndAlso values1.Continued) Then
                        Me.m_fits = False
                    Else
                        Me.m_fits = values1.Fits
                    End If
                    Me.m_continued = values1.Continued
                    Me.m_sized = True
                End If
            End If
        End Sub
        Protected MustOverride Sub DoBeginPrint(ByVal g As Graphics)
        Protected MustOverride Function DoCalcSize(ByVal reportDocument As ReportDocument, ByVal g As Graphics, ByVal bounds As Bounds) As SectionSizeValues
        Protected MustOverride Sub DoPrint(ByVal reportDocument As ReportDocument, ByVal g As Graphics, ByVal bounds As Bounds)
        Private Function LimitBounds(ByVal bounds As Bounds) As Bounds
            If ((Me.MaxWidth > 0.0!) AndAlso (bounds.Width > Me.MaxWidth)) Then
                bounds.Limit.X = (bounds.Position.X + Me.MaxWidth)
            End If
            If ((Me.MaxHeight > 0.0!) AndAlso (bounds.Height > Me.MaxHeight)) Then
                bounds.Limit.Y = (bounds.Position.Y + Me.MaxHeight)
            End If
            bounds = bounds.GetBounds(Me.MarginTop, Me.MarginRight, Me.MarginBottom, Me.MarginLeft)
            Return bounds
        End Function
        Public Sub Print(ByVal reportDocument As ReportDocument, ByVal g As Graphics, ByVal bounds As Bounds)
            Dim bounds1 As bounds = Me.LimitBounds(bounds)
            If (Me.m_sized AndAlso (Not bounds1.Equals(Me.m_sizingBounds))) Then
                Dim values1 As SectionSizeValues = Me.BoundsChanged(Me.m_sizingBounds, bounds1)
                Me.SetSize(values1.RequiredSize, bounds)
                Me.m_fits = values1.Fits
                Me.m_continued = values1.Continued
            End If
            Me.CalcSize(reportDocument, g, bounds)
            If Me.m_fits Then
                Me.DoPrint(reportDocument, g, bounds1)
            End If
            Me.ResetSize()
        End Sub
        Public Overridable Sub Reset()
            Me.m_startedPrinting = False
            Me.m_sized = False
            Me.m_fits = False
            Me.m_continued = False
        End Sub
        Public Overridable Sub ResetSize()
            Me.m_sized = False
        End Sub
        Protected Sub SetContinued(ByVal val As Boolean)
            Me.m_continued = val
        End Sub
        Protected Sub SetFits(ByVal val As Boolean)
            Me.m_fits = val
        End Sub
        Protected Overridable Sub SetSize(ByVal requiredSize As SizeF, ByVal bounds As Bounds)
            Me.m_requiredSize = requiredSize
            Me.m_size = New SizeF(0.0!, 0.0!)
            If Me.UseFullWidth Then
                Me.m_size.Width = bounds.Width
            Else
                Me.m_size.Width = ((requiredSize.Width + Me.MarginLeft) + Me.MarginRight)
            End If
            If Me.UseFullHeight Then
                Me.m_size.Height = bounds.Height
            Else
                Me.m_size.Height = ((requiredSize.Height + Me.MarginTop) + Me.MarginBottom)
            End If
            If (Me.MaxWidth > 0.0!) Then
                Me.m_size.Width = Math.Min(Me.m_size.Width, Me.MaxWidth)
            End If
            If (Me.MaxHeight > 0.0!) Then
                Me.m_size.Height = Math.Min(Me.m_size.Height, Me.MaxHeight)
            End If
        End Sub
#End Region

#Region "SectionSizeValues"
        Protected Structure SectionSizeValues
            Public Continued As Boolean
            Public Fits As Boolean
            Public RequiredSize As SizeF
        End Structure
#End Region

    End Class
End Namespace