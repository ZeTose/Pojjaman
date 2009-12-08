Namespace Pojjaman.UI
    Public Class WedgedTextBox
        Inherits System.Windows.Forms.UserControl
#Region "Members"
        Private m_wedged As Boolean
        Private m_wedgeAlign As WedgeAlignment
        Private m_wedgeColor As Color
        Private m_wedgeSize As Size
        Private m_wedgeBorder As Integer
        Dim path As System.Drawing.Drawing2D.GraphicsPath
#End Region

#Region " Windows Form Designer generated code "

        Public Sub New()
            MyBase.New()

            'This call is required by the Windows Form Designer.
            InitializeComponent()
            m_wedged = False
            m_wedgeAlign = WedgeAlignment.TopRight
            m_wedgeColor = SystemColors.ControlText
            m_wedgeSize = New Size(4, 4)
            m_wedgeBorder = 0
            Me.SetStyle(ControlStyles.DoubleBuffer, True)
            'Add any initialization after the InitializeComponent() call

        End Sub

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
        Private WithEvents m_textBox As System.Windows.Forms.TextBox
        Friend WithEvents Panel1 As System.Windows.Forms.Panel
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Me.m_textBox = New System.Windows.Forms.TextBox
            Me.Panel1 = New System.Windows.Forms.Panel
            Me.SuspendLayout()
            '
            'm_textBox
            '
            Me.m_textBox.Dock = System.Windows.Forms.DockStyle.Fill
            Me.m_textBox.Location = New System.Drawing.Point(0, 0)
            Me.m_textBox.Name = "m_textBox"
            Me.m_textBox.TabIndex = 0
            Me.m_textBox.Text = "TextBox1"
            '
            'Panel1
            '
            Me.Panel1.Location = New System.Drawing.Point(2, 2)
            Me.Panel1.Name = "Panel1"
            Me.Panel1.Size = New System.Drawing.Size(4, 4)
            Me.Panel1.TabIndex = 1
            '
            'WedgedTextBox
            '
            Me.Controls.Add(Me.Panel1)
            Me.Controls.Add(Me.m_textBox)
            Me.Name = "WedgedTextBox"
            Me.Size = New System.Drawing.Size(100, 20)
            Me.ResumeLayout(False)

        End Sub

#End Region

#Region "Properties"
        Public Property WedgeBorder() As Integer
            Get
                Return m_wedgeBorder
            End Get
            Set(ByVal Value As Integer)
                m_wedgeBorder = Value
                Invalidate()
            End Set
        End Property
        Public Property WedgeSize() As Size
            Get
                Return m_wedgeSize
            End Get
            Set(ByVal Value As Size)
                m_wedgeSize = Value
                Invalidate()
            End Set
        End Property
        Public ReadOnly Property TextBox() As TextBox
            Get
                Return Me.m_textBox
            End Get
        End Property
        Public Property Wedged() As Boolean
            Get
                Return m_wedged
            End Get
            Set(ByVal Value As Boolean)
                m_wedged = Value
                Invalidate()
            End Set
        End Property
        Public Property WedgeColor() As Color
            Get
                Return m_wedgeColor
            End Get
            Set(ByVal Value As Color)
                m_wedgeColor = Value
                Invalidate()
            End Set
        End Property
        Public Property WedgeAign() As WedgeAlignment
            Get
                Return m_wedgeAlign
            End Get
            Set(ByVal Value As WedgeAlignment)
                m_wedgeAlign = Value
                Invalidate()
            End Set
        End Property
#End Region

#Region "Enums"
        Public Enum WedgeAlignment
            TopLeft
            TopRight
            BottomLeft
            BottomRight
        End Enum
#End Region

        Private Sub Panel1_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Panel1.Paint
            Dim g As Graphics = e.Graphics
            g.Clear(m_textBox.BackColor)
            g.FillPath(New SolidBrush(Me.m_wedgeColor), path)
        End Sub

        Private Sub WedgedTextBox_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles MyBase.Paint
            If Not Me.m_wedged Then
                Panel1.Visible = False
                Exit Sub
            End If
            Panel1.Size = m_wedgeSize
            Panel1.Visible = True
            Dim p As New Point
            path = New System.Drawing.Drawing2D.GraphicsPath
            Select Case Me.m_wedgeAlign
                Case WedgeAlignment.BottomLeft
                    p.X = 2 + m_wedgeBorder
                    p.Y = Me.Height - Panel1.Height - 1 - m_wedgeBorder
                    path.AddLines(New Point() {New Point(0, Panel1.Height), New Point(Panel1.Width, Panel1.Height), New Point(0, 0)})
                Case WedgeAlignment.BottomRight
                    p.X = Me.Width - 1 - Panel1.Width - m_wedgeBorder
                    p.Y = Me.Height - 1 - Panel1.Height - m_wedgeBorder
                    path.AddLines(New Point() {New Point(Panel1.Width, Panel1.Height), New Point(0, Panel1.Height), New Point(Panel1.Width, 0)})
                Case WedgeAlignment.TopLeft
                    p.X = 2 + m_wedgeBorder
                    p.Y = 2 + m_wedgeBorder
                    path.AddLines(New Point() {New Point(0, 0), New Point(Panel1.Width, 0), New Point(0, Panel1.Height)})
                Case WedgeAlignment.TopRight
                    p.X = Me.Width - Panel1.Width - 2 - m_wedgeBorder
                    p.Y = 2 + m_wedgeBorder
                    path.AddLines(New Point() {New Point(0, 0), New Point(Panel1.Width, 0), New Point(Panel1.Width, Panel1.Height)})
            End Select
            Panel1.Location = p
            Panel1.Invalidate()
        End Sub
    End Class
End Namespace
