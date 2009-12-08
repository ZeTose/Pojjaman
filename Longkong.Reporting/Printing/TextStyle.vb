Imports System
Imports System.Drawing
Imports System.Collections
Imports System.Drawing.Imaging
Imports System.Drawing.Drawing2D
Imports Microsoft.VisualBasic

Namespace Longkong.Reporting.Printing
    Public Class TextStyle

#Region "Members"
        Private m_backgroundBrush As brush
        Private m_backgroundBrushSet As Boolean
        Private m_bold As Boolean
        Private m_boldSet As Boolean
        Private m_brush As Brush
        Private m_brushSet As Boolean
        Private m_defaultFormatFlags As StringFormatFlags
        Private m_defaultStringFormat As StringFormat
        Private m_defaultStringTrimming As StringTrimming
        Private m_defaultStyle As TextStyle
        Private m_fontFamily As fontFamily
        Private m_fontFamilySet As Boolean
        Private m_italic As Boolean
        Private m_italicSet As Boolean
        Private m_marginBottom As Single
        Private m_marginBottomSet As Boolean
        Private m_marginFar As Single
        Private m_marginFarSet As Boolean
        Private m_marginNear As Single
        Private m_marginNearSet As Boolean
        Private m_marginTop As Single
        Private m_marginTopSet As Boolean
        Private m_size As Single
        Private m_sizeDelta As Single
        Private m_sizeSet As Boolean
        Private m_stringAlignment As stringAlignment
        Private m_stringAlignmentSet As Boolean
        Private m_underline As Boolean
        Private m_underlineSet As Boolean
        Private m_verticalAlignment As VerticalAlignment
        Private m_verticalAlignmentSet As Boolean

        Public Shared ReadOnly TableHeader As TextStyle
        Public Shared ReadOnly TableRow As TextStyle
        Public Shared ReadOnly UnderlineStyle As TextStyle
        Public Shared ReadOnly Normal As TextStyle
        Public Shared ReadOnly PageFooter As TextStyle
        Public Shared ReadOnly PageHeader As TextStyle
        Public Shared ReadOnly ItalicStyle As TextStyle
        Public Shared ReadOnly Heading1 As TextStyle
        Public Shared ReadOnly Heading2 As TextStyle
        Public Shared ReadOnly Heading3 As TextStyle
        Public Shared ReadOnly BoldStyle As TextStyle
#End Region

#Region "Constructors"
        Shared Sub New()
            TextStyle.Normal = New TextStyle(Nothing)
            TextStyle.Heading1 = New TextStyle(TextStyle.Normal)
            TextStyle.Heading2 = New TextStyle(TextStyle.Normal)
            TextStyle.Heading3 = New TextStyle(TextStyle.Normal)
            TextStyle.PageHeader = New TextStyle(TextStyle.Normal)
            TextStyle.PageFooter = New TextStyle(TextStyle.Normal)
            TextStyle.TableHeader = New TextStyle(TextStyle.Normal)
            TextStyle.TableRow = New TextStyle(TextStyle.Normal)
            TextStyle.BoldStyle = New TextStyle(TextStyle.Normal)
            TextStyle.UnderlineStyle = New TextStyle(TextStyle.Normal)
            TextStyle.ItalicStyle = New TextStyle(TextStyle.Normal)
            TextStyle.ResetStyles()
        End Sub
        Public Sub New(ByVal defaultStyle As TextStyle)
            Me.m_boldSet = False
            Me.m_italicSet = False
            Me.m_underlineSet = False
            Me.m_sizeSet = False
            Me.m_sizeDelta = 0.0!
            Me.m_fontFamilySet = False
            Me.m_brushSet = False
            Me.m_backgroundBrushSet = False
            Me.m_stringAlignmentSet = False
            Me.m_verticalAlignmentSet = False
            Me.m_marginNearSet = False
            Me.m_marginFarSet = False
            Me.m_marginTopSet = False
            Me.m_marginBottomSet = False
            Me.m_defaultStringFormat = StringFormat.GenericDefault
            Me.m_defaultFormatFlags = (StringFormatFlags.NoClip Or StringFormatFlags.LineLimit)
            Me.m_defaultStringTrimming = StringTrimming.Word
            Me.m_defaultStyle = defaultStyle
        End Sub
#End Region

#Region "Proprties"
        Public Property BackgroundBrush() As Brush
            Get
                If Me.m_backgroundBrushSet Then
                    Return Me.m_backgroundBrush
                End If
                Return Me.m_defaultStyle.BackgroundBrush
            End Get
            Set(ByVal value As Brush)
                Me.m_backgroundBrushSet = True
                Me.m_backgroundBrush = value
            End Set
        End Property
        Public Property Bold() As Boolean
            Get
                If Me.m_boldSet Then
                    Return Me.m_bold
                End If
                Return Me.m_defaultStyle.Bold
            End Get
            Set(ByVal value As Boolean)
                Me.m_boldSet = True
                Me.m_bold = value
            End Set
        End Property
        Public Property Brush() As Brush
            Get
                If Me.m_brushSet Then
                    Return Me.m_brush
                End If
                Return Me.m_defaultStyle.Brush
            End Get
            Set(ByVal value As Brush)
                Me.m_brushSet = True
                Me.m_brush = value
            End Set
        End Property
        Public Property FontFamily() As FontFamily
            Get
                If Me.m_fontFamilySet Then
                    Return Me.m_fontFamily
                End If
                Return Me.m_defaultStyle.FontFamily
            End Get
            Set(ByVal value As FontFamily)
                Me.m_fontFamilySet = True
                Me.m_fontFamily = value
            End Set
        End Property
        Public Property Italic() As Boolean
            Get
                If Me.m_italicSet Then
                    Return Me.m_italic
                End If
                Return Me.m_defaultStyle.Italic
            End Get
            Set(ByVal value As Boolean)
                Me.m_italicSet = True
                Me.m_italic = value
            End Set
        End Property
        Public Property MarginBottom() As Single
            Get
                If Me.m_marginBottomSet Then
                    Return Me.m_marginBottom
                End If
                Return Me.m_defaultStyle.MarginBottom
            End Get
            Set(ByVal value As Single)
                Me.m_marginBottomSet = True
                Me.m_marginBottom = value
            End Set
        End Property
        Public Property MarginFar() As Single
            Get
                If Me.m_marginFarSet Then
                    Return Me.m_marginFar
                End If
                Return Me.m_defaultStyle.MarginFar
            End Get
            Set(ByVal value As Single)
                Me.m_marginFarSet = True
                Me.m_marginFar = value
            End Set
        End Property
        Public Property MarginNear() As Single
            Get
                If Me.m_marginNearSet Then
                    Return Me.m_marginNear
                End If
                Return Me.m_defaultStyle.MarginNear
            End Get
            Set(ByVal value As Single)
                Me.m_marginNearSet = True
                Me.m_marginNear = value
            End Set
        End Property
        Public WriteOnly Property Margins() As Single
            Set(ByVal value As Single)
                Me.MarginTop = value
                Me.MarginFar = value
                Me.MarginBottom = value
                Me.MarginNear = value
            End Set
        End Property
        Public Property MarginTop() As Single
            Get
                If Me.m_marginTopSet Then
                    Return Me.m_marginTop
                End If
                Return Me.m_defaultStyle.MarginTop
            End Get
            Set(ByVal value As Single)
                Me.m_marginTopSet = True
                Me.m_marginTop = value
            End Set
        End Property
        Public Property Size() As Single
            Get
                If Me.m_sizeSet Then
                    Return Me.m_size
                End If
                Return (Me.m_defaultStyle.Size + Me.SizeDelta)
            End Get
            Set(ByVal value As Single)
                Me.m_sizeDelta = 0.0!
                Me.m_sizeSet = True
                Me.m_size = value
            End Set
        End Property
        Public Property SizeDelta() As Single
            Get
                Return Me.m_sizeDelta
            End Get
            Set(ByVal value As Single)
                Me.m_sizeDelta = value
            End Set
        End Property
        Public Property StringAlignment() As StringAlignment
            Get
                If Me.m_stringAlignmentSet Then
                    Return Me.m_stringAlignment
                End If
                Return Me.m_defaultStyle.StringAlignment
            End Get
            Set(ByVal value As StringAlignment)
                Me.m_stringAlignmentSet = True
                Me.m_stringAlignment = value
            End Set
        End Property
        Public Property Underline() As Boolean
            Get
                If Me.m_underlineSet Then
                    Return Me.m_underline
                End If
                Return Me.m_defaultStyle.Underline
            End Get
            Set(ByVal value As Boolean)
                Me.m_underlineSet = True
                Me.m_underline = value
            End Set
        End Property
        Public Property VerticalAlignment() As VerticalAlignment
            Get
                If Me.m_verticalAlignmentSet Then
                    Return Me.m_verticalAlignment
                End If
                Return Me.m_defaultStyle.VerticalAlignment
            End Get
            Set(ByVal value As VerticalAlignment)
                Me.m_verticalAlignmentSet = True
                Me.m_verticalAlignment = value
            End Set
        End Property
#End Region

#Region "Methods"
        Public Overridable Function GetFont() As Font
            Dim style1 As FontStyle = FontStyle.Regular
            If Me.Bold Then
                style1 = (style1 Or FontStyle.Bold)
            End If
            If Me.Italic Then
                style1 = (style1 Or FontStyle.Italic)
            End If
            If Me.Underline Then
                style1 = (style1 Or FontStyle.Underline)
            End If
            Return New Font(Me.FontFamily, Me.Size, style1)
        End Function
        Public Overridable Function GetStringFormat() As StringFormat
            Dim format1 As New StringFormat(Me.m_defaultStringFormat)
            format1.FormatFlags = Me.m_defaultFormatFlags
            format1.Trimming = Me.m_defaultStringTrimming
            format1.Alignment = Me.StringAlignment
            Return format1
        End Function
        Public Shared Sub ResetStyles()
            TextStyle.Normal.FontFamily = System.Drawing.FontFamily.GenericSansSerif
            TextStyle.Normal.Size = 10.0!
            TextStyle.Normal.Bold = False
            TextStyle.Normal.Italic = False
            TextStyle.Normal.Underline = False
            TextStyle.Normal.Brush = Brushes.Black
            TextStyle.Normal.BackgroundBrush = Nothing
            TextStyle.Normal.StringAlignment = System.Drawing.StringAlignment.Near
            TextStyle.Normal.MarginTop = 0.0!
            TextStyle.Normal.MarginBottom = 0.0!
            TextStyle.Normal.MarginNear = 0.0!
            TextStyle.Normal.MarginFar = 0.0!
            TextStyle.Normal.VerticalAlignment = Longkong.Reporting.Printing.VerticalAlignment.Top
            TextStyle.Heading1.ResetToDefault()
            TextStyle.Heading1.Bold = True
            TextStyle.Heading1.SizeDelta = 2.0!
            TextStyle.Heading2.ResetToDefault()
            TextStyle.Heading2.Bold = True
            TextStyle.Heading2.SizeDelta = 1.0!
            TextStyle.Heading3.ResetToDefault()
            TextStyle.Heading3.Italic = True
            TextStyle.PageHeader.ResetToDefault()
            TextStyle.PageHeader.StringAlignment = System.Drawing.StringAlignment.Center
            TextStyle.PageHeader.VerticalAlignment = Longkong.Reporting.Printing.VerticalAlignment.Top
            TextStyle.PageFooter.ResetToDefault()
            TextStyle.PageFooter.StringAlignment = System.Drawing.StringAlignment.Center
            TextStyle.PageFooter.VerticalAlignment = Longkong.Reporting.Printing.VerticalAlignment.Bottom
            TextStyle.TableHeader.ResetToDefault()
            TextStyle.TableHeader.Bold = True
            TextStyle.TableRow.ResetToDefault()
            TextStyle.BoldStyle.Bold = True
            TextStyle.UnderlineStyle.Underline = True
            TextStyle.ItalicStyle.Italic = True
        End Sub
        Public Sub ResetToDefault()
            If (Not Me.m_defaultStyle Is Nothing) Then
                Me.m_boldSet = False
                Me.m_italicSet = False
                Me.m_underlineSet = False
                Me.m_sizeSet = False
                Me.m_sizeDelta = 0.0!
                Me.m_fontFamilySet = False
                Me.m_brushSet = False
                Me.m_backgroundBrushSet = False
                Me.m_stringAlignmentSet = False
                Me.m_verticalAlignmentSet = False
                Me.m_marginNearSet = False
                Me.m_marginFarSet = False
                Me.m_marginTopSet = False
                Me.m_marginBottomSet = False
            End If
        End Sub
        Public Overridable Sub SetFromFont(ByVal font As Font)
            Me.FontFamily = font.FontFamily
            Me.Bold = font.Bold
            Me.Italic = font.Italic
            Me.Underline = font.Underline
            Me.Size = font.Size
        End Sub
#End Region

    End Class
End Namespace