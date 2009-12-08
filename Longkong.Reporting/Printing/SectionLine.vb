Imports System
Imports System.Drawing
Imports System.Collections
Imports System.Drawing.Imaging
Imports System.Drawing.Drawing2D
Imports Microsoft.VisualBasic

Namespace Longkong.Reporting.Printing
    Public Class SectionLine
        Inherits ReportSection

#Region "Members"
        Private m_direction As direction
        Private m_length As Single
        Private m_pen As Pen
        Private x1 As Single
        Private x2 As Single
        Private y1 As Single
        Private y2 As Single
#End Region

#Region "Constructors"
        Public Sub New(ByVal direction As Direction)
            Me.m_direction = direction
        End Sub
        Public Sub New(ByVal direction As Direction, ByVal pen As Pen)
            Me.m_direction = direction
            Me.m_pen = pen
        End Sub
        Public Sub New(ByVal direction As Direction, ByVal length As Single)
            Me.m_direction = direction
            Me.m_length = length
        End Sub
        Public Sub New(ByVal direction As Direction, ByVal pen As Pen, ByVal length As Single)
            Me.m_direction = direction
            Me.m_pen = pen
            Me.m_length = length
        End Sub
#End Region

#Region "Properties"
        Public Property Direction() As Direction
            Get
                Return Me.m_direction
            End Get
            Set(ByVal value As Direction)
                Me.m_direction = value
            End Set
        End Property
        Public Property Length() As Single
            Get
                Return Me.m_length
            End Get
            Set(ByVal value As Single)
                Me.m_length = value
            End Set
        End Property
        Public Property Pen() As Pen
            Get
                Return Me.m_pen
            End Get
            Set(ByVal value As Pen)
                Me.m_pen = value
            End Set
        End Property
#End Region

#Region "Methods"
        Protected Overrides Function BoundsChanged(ByVal originalBounds As Bounds, ByVal newBounds As Bounds) As SectionSizeValues
            Dim values1 As SectionSizeValues
            Me.SetLinePoints(newBounds)
            values1 = New SectionSizeValues
            values1.Fits = True
            values1.Continued = False
            values1.RequiredSize = Me.GetSizeF
            Return values1
        End Function
        Protected Overrides Sub DoBeginPrint(ByVal g As Graphics)
        End Sub
        Protected Overrides Function DoCalcSize(ByVal reportDocument As ReportDocument, ByVal g As Graphics, ByVal bounds As Bounds) As SectionSizeValues
            Dim values1 As SectionSizeValues
            Me.SetDefaultPen(reportDocument)
            Me.SetLinePoints(bounds)
            values1 = New SectionSizeValues
            values1.Fits = True
            values1.Continued = False
            values1.RequiredSize = Me.GetSizeF
            Return values1
        End Function
        Protected Overrides Sub DoPrint(ByVal reportDocument As ReportDocument, ByVal g As Graphics, ByVal bounds As Bounds)
            g.DrawLine(Me.m_pen, Me.x1, Me.y1, Me.x2, Me.y2)
        End Sub
        Private Function GetSizeF() As SizeF
            Dim single1 As Single = (Me.y2 - Me.y1)
            Dim single2 As Single = (Me.x2 - Me.x1)
            Select Case Me.m_direction
                Case Direction.Vertical
                    single2 = Me.m_pen.Width
                Case Direction.Horizontal
                    single1 = Me.m_pen.Width
            End Select
            Return New SizeF(single2, single1)
        End Function
        Protected Overridable Sub SetDefaultPen(ByVal reportDocument As ReportDocument)
            If (Me.m_pen Is Nothing) Then
                Me.m_pen = reportDocument.NormalPen
            End If
        End Sub
        Protected Overridable Sub SetLinePoints(ByVal bounds As Bounds)
            Dim single1 As Single = (Me.m_pen.Width / 2.0!)
            If (Me.m_direction <> Direction.Horizontal) Then
                Select Case Me.HorizontalAlignment
                    Case HorizontalAlignment.Left
                        Me.x1 = (bounds.Position.X + single1)
                        GoTo Label_01E9
                    Case HorizontalAlignment.Right
                        Me.x1 = (bounds.Limit.X - single1)
                        GoTo Label_01E9
                    Case HorizontalAlignment.Center
                        Me.x1 = ((bounds.Position.X + bounds.Limit.X) / 2.0!)
                        GoTo Label_01E9
                End Select
            Else
                Select Case Me.VerticalAlignment
                    Case VerticalAlignment.Top
                        Me.y1 = (bounds.Position.Y + single1)
                    Case VerticalAlignment.Middle
                        Me.y1 = ((bounds.Position.Y + bounds.Limit.Y) / 2.0!)
                    Case VerticalAlignment.Bottom
                        Me.y1 = (bounds.Limit.Y - single1)
                End Select
                Me.y2 = Me.y1
                If (Me.m_length = 0.0!) Then
                    Me.x1 = bounds.Position.X
                    Me.x2 = bounds.Limit.X
                    GoTo Label_02D5
                End If
                Select Case Me.HorizontalAlignment
                    Case HorizontalAlignment.Left
                        Me.x1 = bounds.Position.X
                        Me.x2 = (Me.x1 + Me.m_length)
                        GoTo Label_02D5
                    Case HorizontalAlignment.Right
                        Me.x2 = bounds.Limit.X
                        Me.x1 = (Me.x2 - Me.m_length)
                        GoTo Label_02D5
                    Case HorizontalAlignment.Center
                        Me.x1 = (bounds.Position.X + ((bounds.Width - Me.m_length) / 2.0!))
                        Me.x2 = (Me.x1 + Me.m_length)
                        GoTo Label_02D5
                    Case Else
                        GoTo Label_02D5
                End Select
            End If
Label_01E9:
            Me.x2 = Me.x1
            If (Me.m_length = 0.0!) Then
                Me.y1 = bounds.Position.Y
                Me.y2 = bounds.Limit.Y
            Else
                Select Case Me.VerticalAlignment
                    Case VerticalAlignment.Top
                        Me.y1 = bounds.Position.Y
                        Me.y2 = (Me.y1 + Me.m_length)
                    Case VerticalAlignment.Middle
                        Me.y1 = (bounds.Position.Y + ((bounds.Height - Me.m_length) / 2.0!))
                        Me.y2 = (Me.y1 + Me.m_length)
                    Case VerticalAlignment.Bottom
                        Me.y2 = bounds.Limit.Y
                        Me.y1 = (Me.y2 - Me.m_length)
                End Select
            End If
Label_02D5:
            Me.x1 = Math.Max(Me.x1, bounds.Position.X)
            Me.x2 = Math.Min(Me.x2, bounds.Limit.X)
            Me.y1 = Math.Max(Me.y1, bounds.Position.Y)
            Me.y2 = Math.Min(Me.y2, bounds.Limit.Y)
        End Sub
#End Region

    End Class
End Namespace