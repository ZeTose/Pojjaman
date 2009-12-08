Imports Longkong.Pojjaman.Gui.Components
Imports System.Drawing.Drawing2D
Imports System.Drawing.Design
Imports System.ComponentModel
Imports System.ComponentModel.Design
Imports System.Windows.Forms.Design
Namespace Longkong.FormTable
    Public Class DataBoxControl
        Inherits BasePropertyControl
        Implements IDrawable

#Region "Members"
        Private m_borderColor As Color

        Private m_site As ISite

        Private m_data As String
        Private m_alignment As HorizontalAlignment
        Private m_dashStyle As DashStyle

        Protected m_outline As GraphicsPath
        Protected m_regionOutline As GraphicsPath

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
            m_data = ""
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
        <ControlProperty("สีของเส้นขอบ", Description:="สีของเส้นขอบ", Category:="ลักษณะ")> _
        Public Property BorderColor() As Color            Get                Return m_borderColor            End Get            Set(ByVal Value As Color)                m_borderColor = Value                Me.Invalidate()            End Set        End Property        <ControlProperty("สีพื้น", Description:="สีพื้น", Category:="ลักษณะ")> _
        Public Overrides Property BackColor() As System.Drawing.Color
            Get
                Return MyBase.BackColor
            End Get
            Set(ByVal Value As System.Drawing.Color)
                MyBase.BackColor = Value
                Me.Invalidate()
            End Set
        End Property
        <ControlProperty("ฟ้อนท์", Description:="ฟ้อนท์", Category:="ลักษณะ")> _
        Public Overrides Property Font() As System.Drawing.Font
            Get
                Return MyBase.Font
            End Get
            Set(ByVal Value As System.Drawing.Font)
                MyBase.Font = Value
                Me.Invalidate()
            End Set
        End Property
        <ControlProperty("ลักษณะเส้น", Description:="ลักษณะเส้น", Category:="ลักษณะ")> _
        Public Property DashStyle() As DashStyle            Get                Return m_dashStyle            End Get            Set(ByVal Value As DashStyle)                m_dashStyle = Value                Me.Invalidate()            End Set        End Property
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
        <ControlProperty("การจัดวางแนวนอน", Description:="การจัดวางแนวนอน", Category:="การจัดวาง")> _
        Public Property Alignment() As HorizontalAlignment            Get                Return m_alignment            End Get            Set(ByVal Value As HorizontalAlignment)                m_alignment = Value                Me.Invalidate()            End Set        End Property
        <ControlProperty("ข้อมูล", Description:="ข้อมูล", Category:="ข้อมูล"), Editor(GetType(DataFieldTypeEditor), GetType(UITypeEditor))> _
        Public Shadows Property Data() As String Implements IDrawable.Data
            Get
                Return m_data
            End Get
            Set(ByVal Value As String)
                m_data = Value
                Me.Invalidate()
            End Set
        End Property
#End Region

#Region "Methods"

#End Region

#Region "Overrides"
        Public Overloads Sub Draw(ByVal g As System.Drawing.Graphics, ByVal loc As System.Drawing.Point) Implements IDrawable.Draw
            SetOutLine(loc)
            Dim reg As New Region(m_regionOutline)

            Me.Region = reg

            g.FillRegion(New SolidBrush(Me.BackColor), New Region(Me.m_outline))

            Dim p As New Pen(m_borderColor, 1)
            p.DashStyle = Me.m_dashStyle

            g.SmoothingMode = SmoothingMode.HighQuality
            g.DrawPath(p, m_outline)
            p.Dispose()

            Dim textSize As SizeF = g.MeasureString(m_data, Me.Font)
            Dim startPoint As Integer
            Dim horizontalInterval As Integer = 5
            Dim verticalInterval As Integer = CInt((Me.Height / 2) - (textSize.Height / 2))
            Dim stf As New StringFormat
            stf.Trimming = StringTrimming.Word
            stf.FormatFlags = StringFormatFlags.NoClip
            Select Case Me.m_alignment
                Case HorizontalAlignment.Center
                    stf.LineAlignment = StringAlignment.Center
                    stf.Alignment = StringAlignment.Center
                    startPoint = CInt((Me.Width / 2) - (textSize.Width / 2))
                Case HorizontalAlignment.Left
                    stf.LineAlignment = StringAlignment.Center
                    stf.Alignment = StringAlignment.Near
                    startPoint = horizontalInterval
                Case HorizontalAlignment.Right
                    stf.LineAlignment = StringAlignment.Center
                    stf.Alignment = StringAlignment.Far
                    startPoint = CInt(Me.Width - textSize.Width - horizontalInterval)
            End Select
            Dim drawRect As New RectangleF(loc.X, loc.Y, Me.Width, Me.Height)
            g.DrawString(Data, Me.Font, New SolidBrush(Me.ForeColor), drawRect, stf)
            'g.DrawString(Me.m_data, Me.Font, New SolidBrush(Me.ForeColor), loc.X + startPoint, loc.Y + verticalInterval)
        End Sub
        Public Overloads Sub Draw(ByVal g As System.Drawing.Graphics, ByVal loc As System.Drawing.Point, ByVal data As String) Implements IDrawable.Draw
            Me.m_data = data
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

#Region "Hiding Properties"
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

    End Class
End Namespace