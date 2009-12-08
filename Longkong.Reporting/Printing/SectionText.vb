Imports System
Imports System.Drawing
Imports System.Collections
Imports System.Drawing.Imaging
Imports System.Drawing.Drawing2D
Imports Microsoft.VisualBasic

Namespace Longkong.Reporting.Printing
    Public Class SectionText
        Inherits ReportSection

#Region "Members"
        Private m_charIndex As Integer
        Private m_charsFitted As Integer
        Private m_hAlignmentSet As Boolean
        Private m_linesFitted As Integer
        Private m_marginBottomSet As Boolean
        Private m_marginLeftSet As Boolean
        Private m_marginRightSet As Boolean
        Private m_marginTopSet As Boolean
        Private m_minimumWidth As Single
        Private m_singleLineMode As Boolean
        Private m_text As String
        Private m_textFont As Font
        Private m_textLayout As RectangleF
        Private m_textStyle As textStyle
        Private m_textToPrint As String
        Private m_vAlignmentSet As Boolean

        Public Shared debugEnabled As Boolean

#End Region

#Region "Constructors"
        Shared Sub New()
            SectionText.debugEnabled = False
        End Sub
        Public Sub New(ByVal [text] As String, ByVal textStyle As TextStyle)
            Me.m_minimumWidth = 0.001!
            Me.m_singleLineMode = False
            Me.m_hAlignmentSet = False
            Me.m_vAlignmentSet = False
            Me.m_marginLeftSet = False
            Me.m_marginRightSet = False
            Me.m_marginTopSet = False
            Me.m_marginBottomSet = False
            Me.Text = text
            Me.TextStyle = textStyle
        End Sub
#End Region

#Region "Properties"
        Protected Overridable Property CharIndex() As Integer
            Get
                Return Me.m_charIndex
            End Get
            Set(ByVal value As Integer)
                Me.m_charIndex = value
            End Set
        End Property
        Public Overrides Property HorizontalAlignment() As HorizontalAlignment
            Get
                If Me.m_hAlignmentSet Then
                    Return MyBase.HorizontalAlignment
                End If
                Return SectionText.ConvertAlign(Me.TextStyle.StringAlignment)
            End Get
            Set(ByVal value As HorizontalAlignment)
                Me.m_hAlignmentSet = True
                MyBase.HorizontalAlignment = value
            End Set
        End Property
        Public Overrides Property MarginBottom() As Single
            Get
                If Me.m_marginBottomSet Then
                    Return MyBase.MarginBottom
                End If
                Return Me.TextStyle.MarginBottom
            End Get
            Set(ByVal value As Single)
                Me.m_marginBottomSet = True
                MyBase.MarginBottom = value
            End Set
        End Property
        Public Overrides Property MarginLeft() As Single
            Get
                If Me.m_marginLeftSet Then
                    Return MyBase.MarginLeft
                End If
                Return Me.TextStyle.MarginNear
            End Get
            Set(ByVal value As Single)
                Me.m_marginLeftSet = True
                MyBase.MarginLeft = value
            End Set
        End Property
        Public Overrides Property MarginRight() As Single
            Get
                If Me.m_marginRightSet Then
                    Return MyBase.MarginRight
                End If
                Return Me.TextStyle.MarginFar
            End Get
            Set(ByVal value As Single)
                Me.m_marginRightSet = True
                MyBase.MarginRight = value
            End Set
        End Property
        Public Overrides Property MarginTop() As Single
            Get
                If Me.m_marginTopSet Then
                    Return MyBase.MarginTop
                End If
                Return Me.TextStyle.MarginTop
            End Get
            Set(ByVal value As Single)
                Me.m_marginTopSet = True
                MyBase.MarginTop = value
            End Set
        End Property
        Public Property MinimumWidth() As Single
            Get
                Return Me.m_minimumWidth
            End Get
            Set(ByVal value As Single)
                Me.m_minimumWidth = value
            End Set
        End Property
        Public Property SingleLineMode() As Boolean
            Get
                Return Me.m_singleLineMode
            End Get
            Set(ByVal value As Boolean)
                Me.m_singleLineMode = value
            End Set
        End Property
        Public Property [Text]() As String
            Get
                Return Me.m_text
            End Get
            Set(ByVal value As String)
                Me.m_text = value
            End Set
        End Property
        Public Property TextStyle() As TextStyle
            Get
                If (Me.m_textStyle Is Nothing) Then
                    Return TextStyle.Normal
                End If
                Return Me.m_textStyle
            End Get
            Set(ByVal value As TextStyle)
                Me.m_textStyle = value
            End Set
        End Property
        Public Property UseReportHAlignment() As Boolean
            Get
                Return Me.m_hAlignmentSet
            End Get
            Set(ByVal value As Boolean)
                Me.m_hAlignmentSet = value
            End Set
        End Property
        Public Property UseReportVAlignment() As Boolean
            Get
                Return Me.m_vAlignmentSet
            End Get
            Set(ByVal value As Boolean)
                Me.m_vAlignmentSet = value
            End Set
        End Property
        Public Overrides Property VerticalAlignment() As VerticalAlignment
            Get
                If Me.m_vAlignmentSet Then
                    Return MyBase.VerticalAlignment
                End If
                Return Me.TextStyle.VerticalAlignment
            End Get
            Set(ByVal value As VerticalAlignment)
                Me.m_vAlignmentSet = True
                MyBase.VerticalAlignment = value
            End Set
        End Property
#End Region

#Region "Methods"
        Protected Overrides Function BoundsChanged(ByVal originalBounds As Bounds, ByVal newBounds As Bounds) As SectionSizeValues
            Dim flag1 As Boolean = True
            Dim num1 As Integer = Me.GetOrigin
            If (((num1 > 0) AndAlso Me.GetPoint(originalBounds, num1).Equals(Me.GetPoint(newBounds, num1)) AndAlso newBounds.SizeFits(MyBase.RequiredSize))) Then
                flag1 = False
            End If
            If flag1 Then
                Me.ResetSize()
            End If
            Return MyBase.BoundsChanged(originalBounds, newBounds)
        End Function
        Private Function CheckTextLayout(ByVal g As Graphics) As Boolean
            Dim single1 As Single = Me.m_textFont.GetHeight(g)
            Dim flag1 As Boolean = True
            If ((Me.m_textLayout.Height < single1) OrElse (Me.m_textLayout.Width < Me.MinimumWidth)) Then
                flag1 = False
            End If
            If Me.SingleLineMode Then
                Me.m_textLayout.Height = (single1 * 1.5!)
            End If
            Return flag1
        End Function
        Public Shared Function ConvertAlign(ByVal stringAlign As HorizontalAlignment) As StringAlignment
            Dim alignment1 As StringAlignment = StringAlignment.Near
            Select Case stringAlign
                Case Longkong.Reporting.Printing.HorizontalAlignment.Left
                    Return StringAlignment.Near
                Case Longkong.Reporting.Printing.HorizontalAlignment.Right
                    Return StringAlignment.Far
                Case Longkong.Reporting.Printing.HorizontalAlignment.Center
                    Return StringAlignment.Center
            End Select
            Return alignment1
        End Function
        Public Shared Function ConvertAlign(ByVal stringAlign As StringAlignment) As HorizontalAlignment
            Dim alignment1 As HorizontalAlignment = Longkong.Reporting.Printing.HorizontalAlignment.Left
            Select Case stringAlign
                Case StringAlignment.Near
                    Return Longkong.Reporting.Printing.HorizontalAlignment.Left
                Case StringAlignment.Center
                    Return Longkong.Reporting.Printing.HorizontalAlignment.Center
                Case StringAlignment.Far
                    Return Longkong.Reporting.Printing.HorizontalAlignment.Right
            End Select
            Return alignment1
        End Function
        Protected Overrides Sub DoBeginPrint(ByVal g As Graphics)
            Me.CharIndex = 0
        End Sub
        Protected Overrides Function DoCalcSize(ByVal reportDocument As ReportDocument, ByVal g As Graphics, ByVal bounds As Bounds) As SectionSizeValues
            Dim values1 As SectionSizeValues
            values1 = New SectionSizeValues
            Me.m_textFont = Me.TextStyle.GetFont
            Me.m_textLayout = bounds.GetRectangleF
            If Me.CheckTextLayout(g) Then
                Me.m_textToPrint = Me.GetText(reportDocument)
                Return Me.SetTextSize(reportDocument, g, bounds)
            End If
            values1.Fits = False
            Return values1
        End Function
        Protected Overrides Sub DoPrint(ByVal reportDocument As ReportDocument, ByVal g As Graphics, ByVal bounds As Bounds)
            If (Not Me.TextStyle.BackgroundBrush Is Nothing) Then
                Dim ef1 As RectangleF = Me.m_textLayout
                If Me.UseFullWidth Then
                    ef1.X = bounds.Position.X
                    ef1.Width = bounds.Width
                End If
                If Me.UseFullHeight Then
                    ef1.Y = bounds.Position.Y
                    ef1.Height = bounds.Height
                End If
                g.FillRectangle(Me.TextStyle.BackgroundBrush, ef1)
            End If
            g.DrawString(Me.m_textToPrint, Me.m_textFont, Me.TextStyle.Brush, Me.m_textLayout, Me.GetStringFormat)
            If SectionText.debugEnabled Then
                Dim objArray1 As Object() = New Object() {"Draw string '", Me.m_textToPrint, "' at ", Me.m_textLayout}
                Console.WriteLine(String.Concat(objArray1))
            End If
            Me.CharIndex = (Me.CharIndex + Me.m_charsFitted)
        End Sub
        Private Function GetOrigin() As Integer
            Dim num1 As Integer = 0
            If ((Me.HorizontalAlignment = HorizontalAlignment.Center) OrElse (Me.VerticalAlignment = VerticalAlignment.Middle)) Then
                Return -1
            End If
            If (Me.HorizontalAlignment = HorizontalAlignment.Right) Then
                num1 = (num1 Or 1)
            End If
            If (Me.VerticalAlignment = VerticalAlignment.Bottom) Then
                num1 = (num1 Or 2)
            End If
            Return num1
        End Function
        Private Function GetPoint(ByVal bounds As Bounds, ByVal corner As Integer) As PointF
            Debug.Assert(((corner > 0) AndAlso (corner <= 3)), "Illegal origin value.")
            Dim single1 As Single = 0.0!
            Dim single2 As Single = 0.0!
            If ((corner And 1) = 0) Then
                single1 = bounds.Position.X
            Else
                single1 = bounds.Limit.X
            End If
            If ((corner And 2) = 0) Then
                single2 = bounds.Position.Y
            Else
                single2 = bounds.Limit.Y
            End If
            Return New PointF(single1, single2)
        End Function
        Protected Overridable Function GetStringFormat() As StringFormat
            Dim format1 As StringFormat = Me.TextStyle.GetStringFormat
            format1.Alignment = SectionText.ConvertAlign(Me.HorizontalAlignment)
            Return format1
        End Function
        Protected Overridable Function GetText(ByVal reportDocument As ReportDocument) As String
            Return Me.Text.Substring(Me.CharIndex)
        End Function
        Private Function SetTextSize(ByVal doc As ReportDocument, ByVal g As Graphics, ByVal bounds As Bounds) As SectionSizeValues
            Dim values1 As SectionSizeValues
            values1 = New SectionSizeValues
            values1.Fits = True
            Dim ef1 As SizeF = g.MeasureString(Me.m_textToPrint, Me.m_textFont, Me.m_textLayout.Size, Me.GetStringFormat, Me.m_charsFitted, Me.m_linesFitted)
            If (Me.m_charsFitted < Me.m_textToPrint.Length) Then
                If MyBase.KeepTogether Then
                    values1.Fits = False
                    Me.m_charsFitted = 0
                    Me.m_linesFitted = 0
                    Return values1
                End If
                values1.Continued = True
            End If
            Me.m_textLayout = bounds.GetRectangleF(ef1, Me.HorizontalAlignment, Me.VerticalAlignment)
            values1.RequiredSize = Me.m_textLayout.Size
            If SectionText.debugEnabled Then
                Dim objArray1 As Object() = New Object() {"Layout for string '", Me.m_textToPrint, "' is ", Me.m_textLayout}
                Console.WriteLine(String.Concat(objArray1))
            End If
            Return values1
        End Function
#End Region

    End Class
End Namespace