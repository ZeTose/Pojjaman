Imports System
Imports System.Windows.Forms
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Drawing.Text
Imports System.Diagnostics
Imports System.Collections
Namespace Longkong.Pojjaman.Gui.Components
    Public Class IconMenu
        Inherits MenuItem

#Region "Members"
        Private Shared m_window As Color
        ' Some useful properties to change the color of your menu
        Private Shared m_backColor As Color
        Private Shared m_barColor As Color
        Private Shared m_selectionColor As Color
        Private Shared m_frameColor As Color

        Private Shared m_iconSize As Integer = SystemInformation.SmallIconSize.Width + 4
        Private Shared m_itemHeight As Integer
        Private Shared doColorUpdate As Boolean = False
        Private m_shortcutText As String = ""
        Private m_icon As Image = Nothing
        Private Shared BITMAP_SIZE As Integer = 16
        Private Shared STRIPE_WIDTH As Integer = m_iconSize + 4
#End Region

#Region "Constructors"
        Public Sub New()
            MyBase.New()
            Me.OwnerDraw = True
            UpdateColors()
        End Sub
        Private Sub New(ByVal name As String)
            MyBase.New(name)
            Me.OwnerDraw = True
            UpdateColors()
        End Sub
        Private Sub New(ByVal name As String, ByVal handler As EventHandler)
            MyBase.New(name, handler)
            Me.OwnerDraw = True
            UpdateColors()
        End Sub
        Private Sub New(ByVal name As String, ByVal items As IconMenu())
            MyBase.New(name, items)
            Me.OwnerDraw = True
            UpdateColors()
        End Sub
        Private Sub New(ByVal name As String, ByVal handler As EventHandler, ByVal shortcut As Shortcut)
            MyBase.New(name, handler, shortcut)
            Me.OwnerDraw = True
            UpdateColors()
        End Sub
        Private Sub New(ByVal mergeType As MenuMerge, ByVal mergeOrder As Integer, ByVal shortcut As Shortcut, ByVal name As String, ByVal onClick As EventHandler, ByVal onPopup As EventHandler, ByVal onSelect As EventHandler, ByVal items As IconMenu())
            MyBase.New(mergeType, mergeOrder, shortcut, name, onClick, onPopup, onSelect, items)
            Me.OwnerDraw = True
            UpdateColors()
        End Sub
        Private Sub New(ByVal name As String, ByVal img As Image)
            Me.New(name)
            m_icon = img
        End Sub
        Private Sub New(ByVal name As String, ByVal handler As EventHandler, ByVal img As Image)
            Me.New(name, handler)
            m_icon = img
        End Sub

        Private Sub New(ByVal name As String, ByVal handler As EventHandler, ByVal shortcut As Shortcut, ByVal img As Image)
            Me.New(name, handler, shortcut)
            m_icon = img
        End Sub
#End Region

#Region "Properties"
        Public Property Icon() As Image
            Get
                Return m_icon
            End Get
            Set(ByVal Value As Image)
                m_icon = Value
            End Set
        End Property

        Public Property ShortcutText() As String
            Get
                Return m_shortcutText
            End Get
            Set(ByVal Value As String)
                m_shortcutText = Value
            End Set
        End Property

        Public Property SelectionColor() As Color
            Get
                Return m_selectionColor
            End Get
            Set(ByVal Value As Color)
                m_selectionColor = Value
            End Set
        End Property

        Public Property BackColor() As Color
            Get
                Return m_backColor
            End Get
            Set(ByVal Value As Color)
                m_backColor = Value
            End Set
        End Property

        Public Property BarColor() As Color
            Get
                Return m_barColor
            End Get
            Set(ByVal Value As Color)
                m_barColor = Value
            End Set
        End Property

        Public Property FrameColor() As Color
            Get
                Return m_frameColor
            End Get
            Set(ByVal Value As Color)
                m_frameColor = Value
            End Set
        End Property
#End Region

#Region "Methods"
        Private Sub UpdateColors()
            Return
            m_window = SystemColors.Window
            m_backColor = SystemColors.ControlLightLight
            m_barColor = SystemColors.Control
            m_selectionColor = SystemColors.Highlight
            m_frameColor = SystemColors.Highlight

            Dim wa As Integer = CInt(m_window.A)
            Dim wr As Integer = CInt(m_window.R)
            Dim wg As Integer = CInt(m_window.G)
            Dim wb As Integer = CInt(m_window.B)

            Dim mna As Integer = CInt(m_backColor.A)
            Dim mnr As Integer = CInt(m_backColor.R)
            Dim mng As Integer = CInt(m_backColor.G)
            Dim mnb As Integer = CInt(m_backColor.B)

            Dim sta As Integer = CInt(m_barColor.A)
            Dim str As Integer = CInt(m_barColor.R)
            Dim stg As Integer = CInt(m_barColor.G)
            Dim stb As Integer = CInt(m_barColor.B)

            Dim sla As Integer = CInt(m_selectionColor.A)
            Dim slr As Integer = CInt(m_selectionColor.R)
            Dim slg As Integer = CInt(m_selectionColor.G)
            Dim slb As Integer = CInt(m_selectionColor.B)

            m_backColor = Color.FromArgb(wr - CInt(((wr - mnr) * 2) / 5), wg - CInt(((wg - mng) * 2) / 5), wb - CInt(((wb - mnb) * 2) / 5))
            m_barColor = Color.FromArgb(wr - CInt(((wr - str) * 4) / 5), wg - CInt(((wg - stg) * 4) / 5), wb - CInt(((wb - stb) * 4) / 5))
            m_selectionColor = Color.FromArgb(wr - CInt(((wr - slr) * 2) / 5), wg - CInt(((wg - slg) * 2) / 5), wb - CInt(((wb - slb) * 2) / 5))
        End Sub

        Private Shared Sub UpdateMenuColors()
            doColorUpdate = True
        End Sub

        Private Sub DoUpdateMenuColors()
            UpdateColors()
            doColorUpdate = False
        End Sub

        Protected Overrides Sub OnMeasureItem(ByVal e As MeasureItemEventArgs)
            MyBase.OnMeasureItem(e)

            If Shortcut <> Shortcut.None Then
                Dim myText As String = ""
                Dim key As Integer = CInt(Shortcut)
                Dim ch As Integer = key And &HFF
                If ((CInt(Keys.Control) And key) > 0) Then myText += "Ctrl+"
                If ((CInt(Keys.Shift) And key) > 0) Then myText += "Shift+"
                If ((CInt(Keys.Alt) And key) > 0) Then myText += "Alt+"

                If (ch >= CInt(Shortcut.F1) And ch <= CInt(Shortcut.F12)) Then
                    myText &= "F" & (ch - CInt(Shortcut.F1) + 1)
                Else
                    If (Shortcut = Shortcut.Del) Then
                        myText &= "Del"
                    Else
                        myText &= Chr(ch)
                    End If
                End If
                m_shortcutText = myText
            End If

            If (Text = "-") Then
                e.ItemHeight = 8
                e.ItemWidth = 4
                Return
            End If

            Dim topLevel As Boolean = (Parent Is Parent.GetMainMenu())
            Dim tempShortcutText As String = m_shortcutText
            If (topLevel) Then
                tempShortcutText = ""
            End If
            Dim textwidth As Integer = CInt(e.Graphics.MeasureString(Text + tempShortcutText, SystemInformation.MenuFont).Width)
            Dim extraHeight As Integer = 4
            e.ItemHeight = SystemInformation.MenuHeight + extraHeight
            If (topLevel) Then
                e.ItemWidth = textwidth - 5
            Else
                e.ItemWidth = Math.Max(160, textwidth + 50)
            End If
            m_itemHeight = e.ItemHeight
        End Sub

        Protected Overrides Sub OnDrawItem(ByVal e As DrawItemEventArgs)
            If (doColorUpdate) Then
                DoUpdateMenuColors()
            End If

            MyBase.OnDrawItem(e)

            Dim g As Graphics = e.Graphics
            Dim bounds As Rectangle = e.Bounds
            Dim selected As Boolean = ((e.State And DrawItemState.Selected) > 0)
            Dim toplevel As Boolean = (Parent Is Parent.GetMainMenu())
            Dim hasicon As Boolean = (Not m_icon Is Nothing)
            Dim enabled As Boolean = Me.Enabled

            DrawBackground(g, bounds, e.State, toplevel, hasicon, enabled)

            If (Checked) Then
                DrawCheckmark(g, bounds, selected)
            End If
            If (RadioCheck) Then
                DrawRadioCheckmark(g, bounds, selected)
            End If
            If hasicon Then
                DrawIcon(g, Icon, bounds, selected, enabled, Checked)
            End If

            If (Me.Text = "-") Then
                DrawSeparator(g, bounds)
            Else
                DrawMenuText(g, bounds, Me.Text, ShortcutText, enabled, toplevel, e.State)
            End If
        End Sub

        Private Sub DrawRadioCheckmark(ByVal g As Graphics, ByVal bounds As Rectangle, ByVal selected As Boolean)
            Dim checkTop As Integer = bounds.Top + CInt((m_itemHeight - BITMAP_SIZE) / 2)
            Dim checkLeft As Integer = bounds.Left + CInt((STRIPE_WIDTH - BITMAP_SIZE) / 2)
            ControlPaint.DrawMenuGlyph(g, New Rectangle(checkLeft, checkTop, BITMAP_SIZE, BITMAP_SIZE), MenuGlyph.Bullet)
            g.DrawRectangle(New Pen(FrameColor), checkLeft - 1, checkTop - 1, BITMAP_SIZE + 1, BITMAP_SIZE + 1)
        End Sub

        Private Sub DrawCheckmark(ByVal g As Graphics, ByVal bounds As Rectangle, ByVal selected As Boolean)
            Dim checkTop As Integer = bounds.Top + CInt((m_itemHeight - BITMAP_SIZE) / 2)
            Dim checkLeft As Integer = bounds.Left + CInt((STRIPE_WIDTH - BITMAP_SIZE) / 2)
            ControlPaint.DrawMenuGlyph(g, New Rectangle(checkLeft, checkTop, BITMAP_SIZE, BITMAP_SIZE), MenuGlyph.Checkmark)
            g.DrawRectangle(New Pen(FrameColor), checkLeft - 1, checkTop - 1, BITMAP_SIZE + 1, BITMAP_SIZE + 1)
        End Sub

        Private Sub DrawIcon(ByVal g As Graphics, ByVal icon As Image, ByVal bounds As Rectangle, ByVal selected As Boolean, ByVal enabled As Boolean, ByVal ischecked As Boolean)
            Dim iconTop As Integer = bounds.Top + CInt((m_itemHeight - BITMAP_SIZE) / 2)
            Dim iconLeft As Integer = bounds.Left + CInt((STRIPE_WIDTH - BITMAP_SIZE) / 2)
            If enabled Then
                If selected And Not ischecked Then
                    ControlPaint.DrawImageDisabled(g, icon, iconLeft + 1, iconTop, Me.m_selectionColor)
                    g.DrawImage(icon, iconLeft - 1, iconTop - 2)
                Else
                    g.DrawImage(icon, iconLeft + 1, iconTop)
                End If
            Else
                ControlPaint.DrawImageDisabled(g, icon, iconLeft + 1, iconTop, SystemColors.HighlightText)
            End If
        End Sub

        Private Sub DrawSeparator(ByVal g As Graphics, ByVal bounds As Rectangle)
            Dim y As Integer = bounds.Y + CInt(bounds.Height / 2)
            g.DrawLine(New Pen(SystemColors.ControlDark), bounds.X + m_iconSize + 7, y, bounds.X + bounds.Width - 2, y)
        End Sub

        Private Sub DrawBackground(ByVal g As Graphics, ByVal bounds As Rectangle, ByVal state As DrawItemState, ByVal toplevel As Boolean, ByVal hasicon As Boolean, ByVal enabled As Boolean)

            Dim selected As Boolean = (state And DrawItemState.Selected) > 0
            Dim gradientEndColor As Color = AddColor(m_barColor, 30)
            Dim myGradientBrush As LinearGradientBrush
            If Not (m_barColor.Equals(SystemColors.Menu)) Then
                Debug.WriteLine(m_barColor.ToString)
            End If
            If (selected Or ((state And DrawItemState.HotLight) > 0)) Then
                If (toplevel And selected) Then
                    bounds.Inflate(-1, 0)
                    myGradientBrush = New LinearGradientBrush(bounds, gradientEndColor, m_barColor, LinearGradientMode.Vertical)
                    g.FillRectangle(myGradientBrush, bounds)
                    g.DrawLine(New Pen(m_frameColor), bounds.Left, bounds.Top, bounds.Right, bounds.Top)
                    g.DrawLine(New Pen(m_frameColor), bounds.Left, bounds.Top, bounds.Left, bounds.Bottom)
                    g.DrawLine(New Pen(m_frameColor), bounds.Right, bounds.Top, bounds.Right, bounds.Bottom)
                    ' ControlPaint.DrawBorder3D(g, bounds.Left, bounds.Top, bounds.Width, bounds.Height, Border3DStyle.RaisedInner, Border3DSide.Top Or Border3DSide.Left Or Border3DSide.Right)
                Else
                    If (enabled) Then
                        g.FillRectangle(New SolidBrush(m_selectionColor), bounds)
                        g.DrawRectangle(New Pen(m_frameColor), bounds.X, bounds.Y, bounds.Width - 1, bounds.Height - 1)
                    Else
                        g.FillRectangle(New SolidBrush(m_barColor), bounds)
                        bounds.X += STRIPE_WIDTH
                        bounds.Width -= STRIPE_WIDTH
                        g.FillRectangle(New SolidBrush(m_backColor), bounds)
                    End If
                End If
            Else
                gradientEndColor = AddColor(m_barColor, 40)
                If Not toplevel Then
                    'g.DrawLine(New Pen(m_frameColor), bounds.Left - 1, bounds.Top - 1, bounds.Right + 1, bounds.Top - 1)
                    'g.DrawLine(New Pen(m_frameColor), bounds.Left - 1, bounds.Top - 1, bounds.Left - 1, bounds.Bottom - 1)
                    'g.DrawLine(New Pen(m_frameColor), bounds.Right + 1, bounds.Top - 1, bounds.Right + 1, bounds.Bottom - 1)
                    Dim gradientRect As Rectangle = bounds
                    gradientRect.Width = CInt(STRIPE_WIDTH / 2)
                    gradientRect.X = CInt(STRIPE_WIDTH / 2) - 1
                    myGradientBrush = New LinearGradientBrush(gradientRect, gradientEndColor, m_barColor, LinearGradientMode.Horizontal)
                    g.FillRectangle(myGradientBrush, gradientRect)
                    gradientRect.X = bounds.X
                    g.FillRectangle(New SolidBrush(gradientEndColor), gradientRect)
                    bounds.X += STRIPE_WIDTH - 1
                    bounds.Width -= STRIPE_WIDTH
                    g.FillRectangle(New SolidBrush(m_backColor), bounds)
                Else
                    bounds.Height += 1
                    g.FillRectangle(New SolidBrush(m_barColor), bounds)
                End If
            End If
        End Sub
        Private Function AddColor(ByVal rgb As Integer, ByVal value As Integer) As Integer
            If rgb + value > 255 Then
                rgb = 255
            ElseIf rgb + value < 0 Then
                rgb = 0
            Else
                rgb = rgb + value
            End If
            Return rgb
        End Function
        Function AddColor(ByVal oldColor As Color, ByVal value As Integer, Optional ByVal changeAlpha As Boolean = False) As Color
            Dim a As Integer = oldColor.A
            If changeAlpha Then
                a = AddColor(a, value)
            End If
            Dim r As Integer = AddColor(oldColor.R, value)
            Dim g As Integer = AddColor(oldColor.G, value)
            Dim b As Integer = AddColor(oldColor.B, value)
            Return Color.FromArgb(a, r, g, b)
        End Function
        Private Sub DrawMenuText(ByVal g As Graphics, ByVal bounds As Rectangle, ByVal myText As String, ByVal shortcut As String, ByVal enabled As Boolean, ByVal toplevel As Boolean, ByVal state As DrawItemState)
            Dim myStringFormat As New StringFormat
            If (state And DrawItemState.NoAccelerator) > 0 Then
                myStringFormat.HotkeyPrefix = HotkeyPrefix.Hide
            Else
                myStringFormat.HotkeyPrefix = HotkeyPrefix.Show
            End If

            If (toplevel) Then
                Dim index As Integer = myText.IndexOf("&")
                If (index <> -1) Then
                    myText = myText.Remove(index, 1)
                End If
            End If

            Dim textwidth As Integer = CInt(g.MeasureString(myText, SystemInformation.MenuFont).Width)
            Dim x As Integer
            If toplevel Then
                x = bounds.Left + CInt((bounds.Width - textwidth) / 2)
            Else
                x = bounds.Left + m_iconSize + 10
            End If
            Dim topGap As Integer = 4
            If (toplevel) Then topGap = 2
            Dim y As Integer = bounds.Top + topGap
            Dim myBrush As Brush = Nothing

            If (Not enabled) Then
                myBrush = New SolidBrush(SystemColors.GrayText)
            Else
                myBrush = New SolidBrush(SystemColors.MenuText)
            End If
            g.DrawString(myText, SystemInformation.MenuFont, myBrush, x, y, myStringFormat)
            If (Not toplevel) Then
                myStringFormat.FormatFlags = myStringFormat.FormatFlags Or StringFormatFlags.DirectionRightToLeft
                g.DrawString(shortcut, SystemInformation.MenuFont, myBrush, bounds.Width - 10, bounds.Top + topGap, myStringFormat)
            End If
        End Sub
#End Region

    End Class
End Namespace

