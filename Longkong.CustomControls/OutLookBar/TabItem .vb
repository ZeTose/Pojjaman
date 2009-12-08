Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports System.Windows.Forms

Namespace Longkong.CustomControl
    <ToolboxItem(False)> _
     Public Class TabItem
        Inherits System.ComponentModel.Component
        Implements ITabItem

#Region "Members"
        Private Shared EDGE_PADDING As Integer = 4
        Private Shared TEXT_PADDING As Integer = 4 '12
        Private Shared LARGE As Integer = 32
        Private Shared SMALL As Integer = 16

        Private m_text As String
        Private m_imageIndex As Integer
        Private m_imageRect As Rectangle
        Private m_textRect As Rectangle
        Private m_fontHeight As Double
        Private m_image As Image
        Private m_fontLines As Integer
        Private m_height As Integer
        Private m_location As Point
        Private m_tag As Object
        Friend m_parent As ImageListView
#End Region

#Region "Constructors"
        Public Sub New()
            m_parent = Nothing
            m_imageRect = New Rectangle(0, 0, 0, 0)
            m_textRect = New Rectangle(0, 0, 0, 0)
            m_image = Nothing
            m_height = 0
        End Sub

        Public Sub New(ByVal name As String)
            Me.New()
            Dim num1 As Integer = name.IndexOf(ChrW(10))
            If (num1 > 0) Then
                Me.m_text = name.Substring(0, num1)
            Else
                Me.m_text = name
            End If
        End Sub

        Public Sub New(ByVal name As String, ByVal tag As Object)
            Me.New(name)
            Me.m_tag = tag
        End Sub

        Public Sub New(ByVal name As String, ByVal tag As Object, ByVal image As Bitmap)
            Me.New(name, tag)
            m_image = image
        End Sub
#End Region

#Region "Properties"
        Public Property Tag() As Object Implements ITabItem.Tag
            Get
                Return Me.m_tag
            End Get
            Set(ByVal Value As Object)
                Me.m_tag = Value
            End Set
        End Property
        <Description("Text displayed for the current item"), Category("Appearance")> _
        Public Property Text() As String Implements ITabItem.Text
            Get
                Return m_text
            End Get
            Set(ByVal Value As String)
                m_text = Value
            End Set
        End Property

        <Browsable(False)> _
        Public Property Parent() As ImageListView Implements ITabItem.Parent
            Get
                Return m_parent
            End Get
            Set(ByVal Value As ImageListView)
                m_parent = Value
            End Set
        End Property

        <Browsable(False)> _
        Public ReadOnly Property Height() As Integer Implements ITabItem.Height
            Get
                Return m_height
            End Get
        End Property

        <Browsable(False)> _
        Public ReadOnly Property Location() As Point Implements ITabItem.Location
            Get
                Return m_location
            End Get
        End Property
#End Region


        Public Function HitTest(ByVal pt As Point) As Boolean Implements ITabItem.HitTest
            Return m_imageRect.Contains(pt) Or m_textRect.Contains(pt)
        End Function

        Public Function CalcHeight(ByVal g As Graphics, ByVal font As Font, ByVal width As Integer, ByVal LargeImage As Boolean) As Integer Implements ITabItem.CalcHeight
            m_height = SMALL
            'calc the height of the Text
            Dim fontSize As SizeF = g.MeasureString(Text, font)
            m_fontHeight = fontSize.Height
            m_fontLines = 1
            If (LargeImage) Then
                m_height += TEXT_PADDING
                If (fontSize.Width > width) Then
                    'Need to wrap the text
                    m_height = CInt(m_height + 2 * fontSize.Height)
                    m_fontLines = 2
                Else
                    m_height += CInt(fontSize.Height)
                End If
            End If
            Return m_height
        End Function

        Public Sub Draw(ByVal g As Graphics, ByVal font As Font, ByVal foreBrush As Brush, ByVal location As Point, _
        ByVal maxWidth As Integer, ByVal state As ListViewItemState) Implements ITabItem.Draw
            If m_height = 0 Or m_imageIndex = -1 Then
                Return
            End If
            m_location = location
            'DrawSmall(g, font, foreBrush, location, maxWidth, state)
            DrawLarge(g, font, foreBrush, location, maxWidth, state)
        End Sub

        Public Sub DrawSmall(ByVal g As Graphics, ByVal font As Font, ByVal foreBrush As Brush, _
        ByVal location As Point, ByVal maxWidth As Integer, ByVal state As ListViewItemState) Implements ITabItem.DrawSmall
            m_imageRect = New Rectangle(m_location.X + EDGE_PADDING, m_location.Y, SMALL, SMALL)
            m_textRect = New Rectangle(m_location.X + (2 * EDGE_PADDING) + m_imageRect.Width, location.Y, maxWidth, CInt(m_fontHeight))

            Dim fmt As New StringFormat
            fmt.Alignment = StringAlignment.Near
            fmt.LineAlignment = StringAlignment.Center
            fmt.Trimming = StringTrimming.EllipsisCharacter
            fmt.FormatFlags = StringFormatFlags.NoWrap
            Dim rectf As New RectangleF(m_textRect.X, m_textRect.Y, m_textRect.Width, m_textRect.Height)
            g.DrawString(Text, font, foreBrush, rectf, fmt)

            DrawImage(g, m_imageRect, state)
        End Sub

        Public Sub DrawLarge(ByVal g As Graphics, ByVal font As Font, ByVal foreBrush As Brush, _
       ByVal location As Point, ByVal maxWidth As Integer, ByVal state As ListViewItemState) Implements ITabItem.DrawLarge
            m_imageRect = New Rectangle(CInt(m_location.X + (maxWidth / 2) - (LARGE / 2)), m_location.Y, LARGE, LARGE)
            m_textRect = New Rectangle(location.X + EDGE_PADDING, m_imageRect.Bottom + TEXT_PADDING, maxWidth, CInt(m_fontLines * m_fontHeight))

            Dim fmt As New StringFormat
            fmt.Alignment = StringAlignment.Center
            fmt.LineAlignment = StringAlignment.Center
            fmt.Trimming = StringTrimming.EllipsisCharacter
            Dim rectf As New RectangleF(m_textRect.X, m_textRect.Y, m_textRect.Width, m_textRect.Height)
            g.DrawString(Text, font, foreBrush, rectf, fmt)

            DrawImage(g, m_imageRect, state)
        End Sub

        Private Sub DrawImage(ByVal g As Graphics, ByVal destRect As Rectangle, ByVal state As ListViewItemState)
            Dim drawRect As Rectangle = destRect
            Select Case state
                Case ListViewItemState.Normal
                    ControlPaint.DrawBorder3D(g, drawRect, Border3DStyle.Adjust, Border3DSide.All)
                    g.DrawImage(m_image, drawRect)
                Case ListViewItemState.Pushed
                    drawRect.Inflate(-2, -2)
                    ControlPaint.DrawBorder3D(g, drawRect, Border3DStyle.Adjust Or Border3DStyle.SunkenInner, Border3DSide.All)

                    drawRect.Inflate(2, 2)
                    drawRect.X += 1
                    drawRect.Width -= 2
                    drawRect.Y += 1
                    drawRect.Height -= 2
                    g.DrawImage(m_image, drawRect)

                Case ListViewItemState.Hover
                    drawRect.Inflate(-2, -2)
                    ControlPaint.DrawBorder3D(g, drawRect, Border3DStyle.Adjust Or Border3DStyle.RaisedOuter, Border3DSide.All)

                    drawRect.X -= 1
                    drawRect.Width += 2
                    drawRect.Y -= 1
                    drawRect.Height += 2
                    g.DrawImage(m_image, drawRect)
            End Select
        End Sub

        Public WriteOnly Property Icon() As System.Drawing.Bitmap Implements ITabItem.Icon
            Set(ByVal Value As System.Drawing.Bitmap)
                Me.m_image = Value
            End Set
        End Property

    End Class
End Namespace