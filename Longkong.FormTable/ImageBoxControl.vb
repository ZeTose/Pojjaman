Imports Longkong.Pojjaman.Gui.Components
Imports System.Drawing.Drawing2D
Imports System.ComponentModel
Imports System.ComponentModel.Design
Imports System.Windows.Forms.Design
Imports System.Drawing.Design
Namespace Longkong.FormTable
    Public Class ImageBoxControl
        Inherits BasePropertyControl
        Implements IDrawable

#Region "Members"
        Private m_borderColor As Color

        Private m_site As ISite

        Private m_imagePath As String = ""
        Private m_image As Image
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
        Public Property BorderColor() As Color            Get                Return m_borderColor            End Get            Set(ByVal Value As Color)                m_borderColor = Value                Me.Invalidate()            End Set        End Property        <ControlProperty("สีพื้น", Description:="สีพื้น", Category:="ลักษณะ")> _
        Public Overrides Property BackColor() As System.Drawing.Color
            Get
                Return MyBase.BackColor
            End Get
            Set(ByVal Value As System.Drawing.Color)
                MyBase.BackColor = Value
                Me.Invalidate()
            End Set
        End Property
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

        <ControlProperty("รูปภาพ", Description:="รูปภาพ", Category:="ข้อมูล"), Editor(GetType(FileNameEditor), GetType(UITypeEditor))> _
        Public Property ImagePath() As String            Get                Return m_imagePath            End Get            Set(ByVal Value As String)                m_imagePath = Value                Try                    If m_imagePath.Length <> 0 Then                        m_image = Image.FromFile(m_imagePath)                    End If                Catch ex As Exception
                    m_image = Nothing
                End Try                Me.Invalidate()            End Set        End Property
#End Region

#Region "Methods"

#End Region

#Region "Overrides"
        Public Overloads Sub Draw(ByVal g As System.Drawing.Graphics, ByVal loc As System.Drawing.Point) Implements IDrawable.Draw
            Dim outline As New GraphicsPath
            outline.AddRectangle(New Rectangle(loc.X, loc.Y, Width - 1, Height - 1))
            Dim p As New Pen(m_borderColor, 1)
            p.DashStyle = DashStyle.Solid

            g.SmoothingMode = SmoothingMode.HighQuality
            g.DrawPath(p, outline)
            p.Dispose()

            If m_image Is Nothing Then
                g.FillRectangle(New SolidBrush(Me.BackColor), New Rectangle(loc.X, loc.Y, Width - 2, Me.Height - 2))
                g.DrawString(Me.ImagePath, Me.Font, New SolidBrush(Me.ForeColor), loc.X + 1, loc.Y + 1)
            Else
                g.DrawImage(m_image, loc.X + 1, loc.Y + 1, Me.Width - 2, Me.Height - 2)
            End If
        End Sub
        Public Overloads Sub Draw(ByVal g As System.Drawing.Graphics, ByVal loc As System.Drawing.Point, ByVal data As String) Implements IDrawable.Draw
            Me.Draw(g, loc)
        End Sub
        Public Overloads Sub Draw(ByVal g As System.Drawing.Graphics, ByVal loc As System.Drawing.Point, ByVal image As Image) Implements IDrawable.Draw
            Me.m_image = image
            Me.Draw(g, loc)
        End Sub
        Protected Overrides Sub OnPaint(ByVal e As System.Windows.Forms.PaintEventArgs)
            Me.Draw(e.Graphics, New Point(0, 0))
            MyBase.OnPaint(e)

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
        Public Overrides Property Font() As System.Drawing.Font
            Get
                Return MyBase.Font
            End Get
            Set(ByVal Value As System.Drawing.Font)
                MyBase.Font = Value
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

        Public Property Data() As String Implements IDrawable.Data
            Get

            End Get
            Set(ByVal Value As String)

            End Set
        End Property
    End Class
End Namespace