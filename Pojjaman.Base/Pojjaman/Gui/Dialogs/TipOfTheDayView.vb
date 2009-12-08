Imports Longkong.Core.Services
Imports Longkong.Pojjaman.Services
Imports System.Xml
Imports System
Namespace Longkong.Pojjaman.Gui.Dialogs
    Public Class TipOfTheDayView
        Inherits UserControl
#Region "Members"
        Private m_curtip As Integer
        Private m_didyouknowtext As String
        Private m_drawrect As Rectangle
        Private m_icon As Bitmap
        Private ReadOnly ICON_DISTANCE As Integer
        Private m_resourceService As ResourceService
        Private m_textfont As Font
        Private m_tips As String()
        Private m_titlefont As Font
#End Region

#Region "Constructors"
        Public Sub New(ByVal el As XmlElement)
            Me.ICON_DISTANCE = 16
            Me.m_icon = Nothing
            Me.m_curtip = 0
            Me.m_resourceService = CType(ServiceManager.Services.GetService(GetType(IResourceService)), ResourceService)
            Me.m_titlefont = Me.m_resourceService.LoadFont("Times new Roman", 15, FontStyle.Bold)
            Me.m_textfont = Me.m_resourceService.LoadFont("Times new Roman", 12)
            Me.m_didyouknowtext = Me.m_resourceService.GetString("Dialog.TipOfTheDay.DidYouKnowText")
            Me.m_icon = Me.m_resourceService.GetBitmap("Icons.TipOfTheDayIcon")
            Dim tipList As XmlNodeList = el.ChildNodes
            Dim myStringParserService As StringParserService = CType(ServiceManager.Services.GetService(GetType(StringParserService)), StringParserService)
            Me.m_tips = New String(tipList.Count - 1) {}
            For i As Integer = 0 To tipList.Count - 1
                Me.m_tips(i) = myStringParserService.Parse(tipList.ItemOf(i).InnerText)
            Next
            Me.m_curtip = (New Random).Next Mod tipList.Count
        End Sub
#End Region

#Region "Methods"
        Public Sub NextTip()
            Me.m_curtip = ((Me.m_curtip + 1) Mod Me.m_tips.Length)
            MyBase.Invalidate(Me.m_drawrect)
            MyBase.Update()
        End Sub
        Protected Overrides Sub OnPaint(ByVal pe As PaintEventArgs)
            Dim g As Graphics = pe.Graphics
            g.FillRectangle(Brushes.Gray, 0, 0, CType((Me.m_icon.Width + Me.ICON_DISTANCE), Integer), MyBase.Height)
            g.FillRectangle(Brushes.White, CType((Me.m_icon.Width + Me.ICON_DISTANCE), Integer), 0, CType(((MyBase.Width - Me.m_icon.Width) - Me.ICON_DISTANCE), Integer), MyBase.Height)
            g.DrawImage(Me.m_icon, CType((2 + (Me.ICON_DISTANCE / 2)), Integer), 4)
            g.DrawString(Me.m_didyouknowtext, Me.m_titlefont, Brushes.Black, CType(((Me.m_icon.Width + Me.ICON_DISTANCE) + 4), Single), CType(8.0!, Single))
            g.DrawLine(Pens.Black, New Point((Me.m_icon.Width + Me.ICON_DISTANCE), ((8 + Me.m_titlefont.Height) + 2)), New Point(MyBase.Width, ((8 + Me.m_titlefont.Height) + 2)))
            Me.m_drawrect = New Rectangle((Me.m_icon.Width + Me.ICON_DISTANCE), ((8 + Me.m_titlefont.Height) + 6), ((MyBase.Width - Me.m_icon.Width) - Me.ICON_DISTANCE), (MyBase.Height - ((8 + Me.m_titlefont.Height) + 6)))
            g.DrawString(Me.m_tips(Me.m_curtip), Me.m_textfont, Brushes.Black, RectangleF.op_Implicit(Me.m_drawrect))
        End Sub
        Protected Overrides Sub OnPaintBackground(ByVal pe As PaintEventArgs)
        End Sub
#End Region


    End Class
End Namespace

