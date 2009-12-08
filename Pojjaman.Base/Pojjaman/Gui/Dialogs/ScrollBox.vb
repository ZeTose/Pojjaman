Imports Longkong.Core.Services
Imports Longkong.Core.Properties
Imports Longkong.Pojjaman.Services
Namespace Longkong.Pojjaman.Gui.Dialogs
    Public Class ScrollBox
        Inherits UserControl

#Region "Members"
        Private m_curText As Integer
        Private m_image As Image
        Private m_scroll As Integer
        Private m_text As String()
        Private m_textHeights As Integer()
        Private m_timer As Timer
#End Region

#Region "Constructors"
        Public Sub New()
            Me.m_scroll = -220
            Me.m_curText = 0
            MyBase.SetStyle(ControlStyles.DoubleBuffer, True)
            MyBase.SetStyle(ControlStyles.AllPaintingInWmPaint, True)
            Dim myResourceService As ResourceService = CType(ServiceManager.Services.GetService(GetType(IResourceService)), ResourceService)
            Me.Font = myResourceService.LoadFont("Tahoma", 10)

            Try
                Dim myProperties As PropertyService = CType(ServiceManager.Services.GetService(GetType(PropertyService)), PropertyService)
                Dim credits As CreditTexts = CType(myProperties.GetProperty("", New CreditTexts), CreditTexts)
                credits.CreditTexts.ToArray(GetType(String))
                Dim texts(credits.CreditTexts.Count - 1) As String
                For i As Integer = 0 To texts.Length - 1
                    texts(i) = credits.CreditTexts(i).ToString
                Next
                Me.m_text = texts
            Catch ex As Exception
                'MessageBox.Show(ex.Message & ":" & ex.StackTrace)
            End Try
            'Me.m_text = New String() { _
            '"Developers: KRISS, Keng, Neng, Kae, Dear, I, T", _
            '"Support: Pueng, Jua", _
            '"Executives: JingJor, BigBote, Tousna, Aong+", _
            '"Sales: Da, Gift, Lie", _
            '"Accounting Support: Nong" _
            '}

            'For Each text As String In Me.m_text
            '    MessageBox.Show(text)
            'Next

            Me.m_timer = New Timer
            Me.m_timer.Interval = 40
            AddHandler Me.m_timer.Tick, New EventHandler(AddressOf Me.ScrollDown)
            Me.m_timer.Start()
        End Sub
#End Region

#Region "Properties"
        Public Property Image() As Image
            Get
                Return Me.m_image
            End Get
            Set(ByVal value As Image)
                Me.m_image = value
            End Set
        End Property
        Public Property ScrollY() As Integer
            Get
                Return Me.m_scroll
            End Get
            Set(ByVal value As Integer)
                Me.m_scroll = value
            End Set
        End Property
        Public Property Quotes() As String()
            Get
                Return Me.m_text
            End Get
            Set(ByVal Value As String())
                Me.m_text = Value
            End Set
        End Property
#End Region

#Region "Methods"
        Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
            If disposing Then
                Me.m_timer.Stop()
                For Each myControl As Control In MyBase.Controls
                    myControl.Dispose()
                Next
            End If
            MyBase.Dispose(disposing)
        End Sub
    Protected Overrides Sub OnPaint(ByVal pe As PaintEventArgs)
      If Me.m_text Is Nothing OrElse Me.m_text.Length = 0 Then
        Return
      End If
      Dim g As Graphics = pe.Graphics
      If (Me.m_textHeights Is Nothing) Then
        Me.m_textHeights = New Integer(Me.m_text.Length - 1) {}
        For i As Integer = 0 To Me.m_text.Length - 1
          Dim ef1 As SizeF = g.MeasureString(Me.m_text(i), Me.Font, New SizeF(CType((MyBase.Width / 2), Single), CType((MyBase.Height * 2), Single)))
          Me.m_textHeights(i) = CType(ef1.Height, Integer)
        Next
      End If
      g.DrawString(Me.m_text(Me.m_curText), Me.Font, Brushes.Black, New RectangleF(8, -Me.m_scroll, CInt(MyBase.Width / 2), (MyBase.Height * 2)))
      If (Me.m_scroll > Me.m_textHeights(Me.m_curText)) Then
        Me.m_curText = ((Me.m_curText + 1) Mod Me.m_text.Length)
        Me.m_scroll = (-Me.m_textHeights(Me.m_curText) - MyBase.Height)
      End If
    End Sub
    Protected Overrides Sub OnPaintBackground(ByVal pe As PaintEventArgs)
      If (Not Me.m_image Is Nothing) Then
        pe.Graphics.DrawImage(Me.m_image, 0, 0, MyBase.Width, MyBase.Height)
      End If
    End Sub
    Private Sub ScrollDown(ByVal sender As Object, ByVal e As EventArgs)
      Me.m_scroll += 1
      Me.Refresh()
    End Sub
#End Region

    End Class
End Namespace

