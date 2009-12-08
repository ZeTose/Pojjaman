
Imports System
Imports System.Drawing
Imports System.ComponentModel
Imports System.Windows.Forms

Namespace Longkong.CustomControl
    <Description("OutlookBarTab Component"), ToolboxItem(False)> _
    Public Class OutlookBarTab
        Inherits System.ComponentModel.Component

#Region "Members"
        Friend Shared EDGE_PADDING As Integer = 4

        Protected m_text As String
        Protected m_textAlignment As StringAlignment
        Protected m_foreColor As Color
        Protected m_tabIcon As Icon
        Protected m_child As Control

        Protected m_tabRect As Rectangle
        Protected m_iconRect As Rectangle
        Protected m_buttonState As ButtonState
        Private m_tabFactory As ISideTabFactory
#End Region

#Region "Constructors"
        Public Sub New()
            m_text = ""
            m_foreColor = System.Drawing.SystemColors.ControlText
            m_child = Nothing
            m_tabIcon = Nothing
            m_textAlignment = StringAlignment.Center
        End Sub
        Public Sub New(ByVal sideTabItemFactory As ISideTabItemFactory)
            Me.New()
            Me.SideTabItemFactory = sideTabItemFactory
            Me.m_child = New ImageListView
        End Sub
        Public Sub New(ByVal name As String)
            Me.New()
            m_text = name
        End Sub
        Public Sub New(ByVal sideBar As OutlookBar, ByVal name As String)
            Me.New(name)
            Me.Child = New ImageListView
        End Sub
#End Region

#Region "Events"
        <Description("Event rasied when the Text property has been modified")> _
        Public Event TextChanged As EventHandler

        <Description("Event rasied when the TextAlignment property has been modified")> _
        Public Event TextAlignmentChanged As EventHandler

        <Description("Event rasied when the ForeColor property has been modified")> _
        Public Event ForeColorChanged As EventHandler

        <Description("Event rasied when the Icon property has been modified")> _
       Public Event IconChanged As EventHandler

        <Description("Event rasied when the Child property has been modified")> _
         Public Event ChildChanged As EventHandler

#End Region

#Region "Properties"
        Public Property SideTabItemFactory() As ISideTabItemFactory
            Get
                If TypeOf Me.Child Is ImageListView Then
                    Return CType(Me.Child, ImageListView).SideTabItemFactory
                End If
            End Get
            Set(ByVal value As ISideTabItemFactory)
                If TypeOf Me.Child Is ITabItem Then
                    CType(Me.Child, ImageListView).SideTabItemFactory = value
                End If
            End Set
        End Property
        Public ReadOnly Property Items() As ImageListView.ListViewItemCollection
            Get
                If TypeOf Me.Child Is ImageListView Then
                    Return CType(Me.Child, ImageListView).Items
                End If
            End Get
        End Property
        <Description("The text displayed on the control tab"), Category("Appearance")> _
        Public Property Text() As String
            Get
                Return m_text
            End Get
            Set(ByVal Value As String)
                If Not m_text.Equals(Value) Then
                    m_text = Value
                    OnTextChanged(New EventArgs)
                End If
            End Set
        End Property

        <Description("Specifies the alignment of the text within the control tab"), Category("Appearance")> _
        Public Property Alignment() As StringAlignment
            Get
                Return m_textAlignment
            End Get
            Set(ByVal Value As StringAlignment)
                If m_textAlignment <> Value Then
                    m_textAlignment = Value
                    OnTextAlignmentChanged(New EventArgs)
                End If
            End Set
        End Property

        <Description("Specifies the color used to render the text on the tab control"), Category("Appearance")> _
        Public Property ForeColor() As Color
            Get
                Return m_foreColor
            End Get
            Set(ByVal Value As Color)
                If Not m_foreColor.Equals(Value) Then
                    m_foreColor = Value
                    OnForeColorChanged(New EventArgs)
                End If
            End Set
        End Property

        <Description("Specifies the Icon to drawn on the control tab"), Category("Appearance")> _
               Public Property Icon() As Icon
            Get
                Return m_tabIcon
            End Get
            Set(ByVal Value As Icon)
                'If Not m_tabIcon Is Nothing AndAlso Not m_tabIcon.Equals(Value) Then
                m_tabIcon = Value
                OnIconChanged(New EventArgs)
                'End If
            End Set
        End Property

        <Description("Child control hosted within the control tab"), Category("Behavior")> _
        Public Property Child() As Control
            Get
                Return m_child
            End Get
            Set(ByVal Value As Control)
                'If Not m_child Is Nothing AndAlso Not m_child.Equals(Value) Then
                m_child = Value
                OnChildChanged(New EventArgs)
                'End If
            End Set
        End Property

        <Browsable(False)> _
        Friend ReadOnly Property ButtonState() As ButtonState
            Get
                Return m_buttonState
            End Get
        End Property


        <Browsable(False)> _
        Friend ReadOnly Property TabRect() As Rectangle
            Get
                Return m_tabRect
            End Get
        End Property
#End Region


#Region "Methods"
        Public Overridable Sub Draw(ByVal g As Graphics, ByVal destRect As Rectangle, ByVal font As Font, ByVal buttonState As ButtonState)
            m_tabRect = destRect
            m_buttonState = buttonState
            DrawButton(g)
            If Not m_tabIcon Is Nothing Then
                DrawIcon(g)
            End If
            DrawText(g, font)
        End Sub
        Public Function HitTest(ByVal pt As Point) As Boolean
            Return m_tabRect.Contains(pt)
        End Function
        Protected Overridable Sub DrawButton(ByVal g As Graphics)
            ControlPaint.DrawButton(g, m_tabRect, m_buttonState)
        End Sub
        Protected Overridable Sub DrawIcon(ByVal g As Graphics)
            Dim top As Integer = m_tabRect.Top + EDGE_PADDING
            Dim left As Integer = m_tabRect.Left + EDGE_PADDING
            Dim width As Integer = m_tabRect.Width
            Dim height As Integer = m_tabRect.Height

            'Does the Icon need scaled?
            If (top + height) >= (m_tabRect.Height - (2 * EDGE_PADDING)) Then
                Dim maxHeight As Double = (m_tabRect.Height - (2 * EDGE_PADDING))
                Dim scaleFactor As Double = maxHeight / height
                height = CInt(height * scaleFactor)
                width = CInt(width * scaleFactor)
            End If

            m_iconRect = New Rectangle(left, top, width, height)
            If m_buttonState = ButtonState.Pushed Then
                m_iconRect.Offset(1, 1)
            End If
            g.DrawIcon(m_tabIcon, m_iconRect)
        End Sub
        Protected Overridable Sub DrawText(ByVal g As Graphics, ByVal font As Font)
            Dim textRect As New RectangleF(m_tabRect.X, m_tabRect.Y, m_tabRect.Width, m_tabRect.Height)
            textRect.X -= 1
            textRect.Width += 1
            textRect.Y -= 1
            'textRect.Height -= EDGE_PADDING
            'Adjust for possible icon
            If Not m_tabIcon Is Nothing Then
                textRect.X += m_iconRect.Width
                textRect.Width -= m_iconRect.Width
            End If

            'Adjust for button state
            If m_buttonState = ButtonState.Pushed Then
                textRect.Offset(1, 1)
            End If

            'Render the Text
            Dim fmt As New StringFormat
            fmt.Alignment = m_textAlignment
            fmt.LineAlignment = StringAlignment.Center
            fmt.Trimming = StringTrimming.EllipsisCharacter
            fmt.FormatFlags = StringFormatFlags.NoWrap Or StringFormatFlags.LineLimit

            Dim textBrush As New SolidBrush(ForeColor)
            g.DrawString(m_text, font, textBrush, textRect, fmt)

            textBrush.Dispose()
        End Sub
        Protected Overridable Sub OnTextChanged(ByVal e As EventArgs)
            RaiseEvent TextChanged(Me, e)
        End Sub
        Protected Overridable Sub OnTextAlignmentChanged(ByVal e As EventArgs)
            RaiseEvent TextAlignmentChanged(Me, e)
        End Sub

        Protected Overridable Sub OnForeColorChanged(ByVal e As EventArgs)
            RaiseEvent ForeColorChanged(Me, e)
        End Sub
        Protected Overridable Sub OnIconChanged(ByVal e As EventArgs)
            RaiseEvent IconChanged(Me, e)
        End Sub
        Protected Overridable Sub OnChildChanged(ByVal e As EventArgs)
            RaiseEvent ChildChanged(Me, e)
        End Sub
#End Region

    End Class

End Namespace