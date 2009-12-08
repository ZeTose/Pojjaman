Imports Longkong.Pojjaman.Gui.Components
Imports System.Drawing.Drawing2D
Imports System.Drawing.Design
Imports System.ComponentModel
Imports System.ComponentModel.Design
Imports System.Windows.Forms.Design
Namespace Longkong.FormTable
    <Designer(GetType(CheckControlDesigner))> _
    Public Class CheckControl
        Inherits BasePropertyControl
        Implements IDrawable

        Public Enum GlyphType
            Arrow
            Bullet
            Checkmark
        End Enum
#Region "Members"
        Private m_borderColor As Color

        Private m_site As ISite

        Private m_dashStyle As DashStyle

        Protected m_outline As GraphicsPath
        Protected m_regionOutline As GraphicsPath

        Private m_glyph As GlyphType
        Private m_logic As String
#End Region

#Region "Constructors"
        Public Sub New()
            MyBase.New()
            InitializeComponent()

            Me.SetStyle(ControlStyles.SupportsTransparentBackColor Or _
            ControlStyles.DoubleBuffer Or _
            ControlStyles.AllPaintingInWmPaint Or _
            ControlStyles.UserPaint, True)

            Me.SetStyle(ControlStyles.ResizeRedraw, True)
            Me.BorderColor = Color.Black
            Me.Width = 10
            Me.Height = 10
            m_glyph = GlyphType.Checkmark
        End Sub
#End Region

#Region " Windows Form Designer generated code "
        'UserControl overrides dispose to clean up the component list.
        Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
            If disposing Then
                If Not (components Is Nothing) Then
                    components.Dispose()
                End If
            End If
            MyBase.Dispose(disposing)
        End Sub

        'Required by the Windows Form Designer
        Private components As System.ComponentModel.IContainer

        'NOTE: The following procedure is required by the Windows Form Designer
        'It can be modified using the Windows Form Designer.  
        'Do not modify it using the code editor.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        End Sub

#End Region

#Region "Properties"
        <ControlProperty("เงื่อนไข", Description:="ถ้าเงื่อนไขนี้เป็นจริงจึงจะปรากฏเครื่องหมาย", Category:="ข้อมูล")> _
        Public Property Logic() As String            Get                Return m_logic            End Get            Set(ByVal Value As String)                m_logic = Value            End Set        End Property
        <ControlProperty("รูปแบบ", Description:="รูปแบบ", Category:="ลักษณะ")> _
        Public Property Glyph() As GlyphType            Get                Return m_glyph            End Get            Set(ByVal Value As GlyphType)                m_glyph = Value                Me.Invalidate()            End Set        End Property
        <ControlProperty("สีของเส้นขอบ", Description:="สีของเส้นขอบ", Category:="ลักษณะ")> _
        Public Property BorderColor() As Color            Get                Return m_borderColor            End Get            Set(ByVal Value As Color)                m_borderColor = Value                Me.Invalidate()            End Set        End Property
        <ControlProperty("ลักษณะเส้น", Description:="ลักษณะเส้น", Category:="ลักษณะ")> _        Public Property DashStyle() As DashStyle            Get                Return m_dashStyle            End Get            Set(ByVal Value As DashStyle)                m_dashStyle = Value                Me.Invalidate()            End Set        End Property
        <ControlProperty("ตำแหน่ง", Description:="ตำแหน่ง", Category:="การจัดวาง")> _
        Public Shadows Property Location() As Point
            Get
                Return MyBase.Location
            End Get
            Set(ByVal Value As Point)
                MyBase.Location = Value
            End Set
        End Property
        <ControlProperty("ขนาด", Description:="ขนาด", Category:="การจัดวาง")> _
        Public Shadows Property Size() As Size
            Get
                Return MyBase.Size
            End Get
            Set(ByVal Value As Size)
                MyBase.Size = Value
            End Set
        End Property
#End Region

#Region "Hiding Properties"
        <Browsable(False)> _
        Public Overrides Property BackColor() As System.Drawing.Color
            Get
                Return MyBase.BackColor
            End Get
            Set(ByVal Value As System.Drawing.Color)
            End Set
        End Property
        <Browsable(False)> _
        Public Overrides Property Font() As System.Drawing.Font
            Get
                Return MyBase.Font
            End Get
            Set(ByVal Value As System.Drawing.Font)
            End Set
        End Property
        Public Overrides Property Site() As System.ComponentModel.ISite
            Get
                Return m_site
            End Get
            Set(ByVal Value As System.ComponentModel.ISite)
                m_site = Value
            End Set
        End Property
        <Browsable(False)> _
        Public Overrides Property ForeColor() As System.Drawing.Color
            Get
                Return MyBase.ForeColor
            End Get
            Set(ByVal Value As System.Drawing.Color)
                MyBase.ForeColor = Value
                Me.Invalidate()
            End Set
        End Property
        <Browsable(False)> _
        Public Shadows Property Text() As String
            Get

            End Get
            Set(ByVal Value As String)

            End Set
        End Property
        <Browsable(False)> _
        Public Overrides Property Cursor() As System.Windows.Forms.Cursor
            Get

            End Get
            Set(ByVal Value As System.Windows.Forms.Cursor)

            End Set
        End Property
        <Browsable(False)> _
        Public Overrides Property Dock() As System.Windows.Forms.DockStyle
            Get

            End Get
            Set(ByVal Value As System.Windows.Forms.DockStyle)

            End Set
        End Property
        <Browsable(False)> _
        Public Shadows Property ImeMode() As ImeMode
            Get

            End Get
            Set(ByVal Value As ImeMode)

            End Set
        End Property
        <Browsable(False)> _
        Public Shadows Property TabIndex() As Integer
            Get

            End Get
            Set(ByVal Value As Integer)

            End Set
        End Property
        <Browsable(False)> _
        Public Shadows Property RightToLeft() As Boolean
            Get

            End Get
            Set(ByVal Value As Boolean)

            End Set
        End Property
        <Browsable(False)> _
        Public Shadows Property Enabled() As Boolean
            Get

            End Get
            Set(ByVal Value As Boolean)

            End Set
        End Property
        <Browsable(False)> _
        Public Shadows Property TabStop() As Boolean
            Get

            End Get
            Set(ByVal Value As Boolean)

            End Set
        End Property
        <Browsable(False), ControlProperty("วิซิเบิ้ล", Description:="วิซิเบิ้ล", Category:="ลักษณะ")> _
        Public Shadows Property Visble() As Boolean
            Get
                Return MyBase.Visible
            End Get
            Set(ByVal Value As Boolean)
                MyBase.Visible = True
            End Set
        End Property
        <Browsable(False)> _
        Public Overrides Property ContextMenu() As System.Windows.Forms.ContextMenu
            Get

            End Get
            Set(ByVal Value As System.Windows.Forms.ContextMenu)

            End Set
        End Property
        <Browsable(False)> _
        Public Shadows Property AccessibleDescription() As String
            Get

            End Get
            Set(ByVal Value As String)

            End Set
        End Property
        <Browsable(False)> _
        Public Shadows Property AccessibleName() As String
            Get

            End Get
            Set(ByVal Value As String)

            End Set
        End Property
        <Browsable(False)> _
        Public Shadows Property AccessibleRole() As AccessibleRole
            Get

            End Get
            Set(ByVal Value As AccessibleRole)

            End Set
        End Property
        <Browsable(False)> _
        Public Overrides Property AllowDrop() As Boolean
            Get
                Return False
            End Get
            Set(ByVal Value As Boolean)

            End Set
        End Property
        <Browsable(False)> _
        Public Overrides Property Anchor() As System.Windows.Forms.AnchorStyles
            Get

            End Get
            Set(ByVal Value As System.Windows.Forms.AnchorStyles)

            End Set
        End Property
        <Browsable(False)> _
        Public Overrides Property BackgroundImage() As System.Drawing.Image
            Get

            End Get
            Set(ByVal Value As System.Drawing.Image)

            End Set
        End Property
#End Region

#Region "Overrides"
        Public Overloads Sub Draw(ByVal g As System.Drawing.Graphics, ByVal loc As System.Drawing.Point) Implements IDrawable.Draw
            SetOutLine(loc)
            Dim reg As New Region(m_regionOutline)

            Me.Region = reg

            Dim p As New Pen(m_borderColor, 1)
            p.DashStyle = Me.m_dashStyle

            g.SmoothingMode = SmoothingMode.HighQuality
            g.DrawPath(p, m_outline)
            Dim gl As MenuGlyph
            Select Case Me.m_glyph
                Case GlyphType.Arrow
                    gl = MenuGlyph.Arrow
                Case GlyphType.Bullet
                    gl = MenuGlyph.Bullet
                Case GlyphType.Checkmark
                    gl = MenuGlyph.Checkmark
            End Select
            ControlPaint.DrawMenuGlyph(g, New Rectangle(loc.X + 2, loc.Y + 2, Width - 3, Height - 3), gl)
            p.Dispose()
        End Sub
        Public Overloads Sub Draw(ByVal g As System.Drawing.Graphics, ByVal loc As System.Drawing.Point, ByVal data As String) Implements IDrawable.Draw
            Me.Draw(g, loc)
        End Sub
        Public Overloads Sub Draw(ByVal g As System.Drawing.Graphics, ByVal loc As System.Drawing.Point, ByVal image As Image) Implements IDrawable.Draw
            Me.Draw(g, loc)
        End Sub
        Protected Overrides Sub OnPaint(ByVal e As System.Windows.Forms.PaintEventArgs)
            Me.Draw(e.Graphics, New Point(0, 0))
            MyBase.OnPaint(e)
        End Sub
        Protected Overridable Sub SetOutLine(ByVal loc As Point)
            m_outline = New GraphicsPath
            m_outline.AddRectangle(New Rectangle(loc.X + 1, loc.Y + 1, Width - 2, Height - 2))
            m_regionOutline = New GraphicsPath
            m_regionOutline.AddRectangle(New Rectangle(loc.X, loc.Y, Width, Height))
        End Sub
#End Region

        Public Property Data() As String Implements IDrawable.Data
            Get

            End Get
            Set(ByVal Value As String)

            End Set
        End Property
    End Class
    Public Class CheckControlDesigner
        Inherits ControlDesigner

        Sub New()
        End Sub

        Public Overrides ReadOnly Property SelectionRules() As System.Windows.Forms.Design.SelectionRules
            Get
                Return SelectionRules.Moveable Or _
                  SelectionRules.AllSizeable Or _
                SelectionRules.Visible
            End Get
        End Property
    End Class
End Namespace