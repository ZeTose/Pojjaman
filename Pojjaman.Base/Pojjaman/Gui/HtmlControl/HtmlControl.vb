Imports Longkong.Pojjaman.Gui
Imports System.Windows.Forms
Imports SHDocVw
Namespace Longkong.Pojjaman.Gui.HtmlControl
  Public Delegate Sub BrowserNavigateEventHandler(ByVal s As Object, ByVal e As BrowserNavigateEventArgs)

  Public Class HtmlControl
    Inherits AxHost
    Implements IWebBrowserEvents

#Region "Members"
    Private m_control As IWebBrowser = Nothing
    Private m_cookie As ConnectionPointCookie
    Private m_cssStyleSheet As String = ""
    Private m_html As String = ""
    Private m_initialized As Boolean = False
    Private m_url As String = "about:blank"
    Public Const OLEIVERB_UIACTIVATE As Integer = -4
#End Region

#Region "Events"
    Public Event BeforeNavigate As BrowserNavigateEventHandler
    Public Event NavigateComplete As BrowserNavigateEventHandler
#End Region

#Region "Constructors"
    Public Sub New()
      MyBase.New("8856f961-340a-11d0-a96b-00c04fd705a2")
    End Sub
#End Region

#Region "Properties"
    Public Property CascadingStyleSheet() As String
      Get
        Return Me.m_cssStyleSheet
      End Get
      Set(ByVal value As String)
        Me.m_cssStyleSheet = value
        Me.ApplyCascadingStyleSheet()
      End Set
    End Property
    Public WriteOnly Property Html() As String
      Set(ByVal value As String)
        Me.m_html = value
        Me.ApplyBody(Me.m_html)
      End Set
    End Property
    Public WriteOnly Property Url() As String
      Set(ByVal value As String)
        'Me.m_url = value
        'If Me.m_initialized Then
        '  Dim obj1 As Object = 0
        '  Dim obj2 As Object = String.Empty
        '  Dim obj3 As Object = String.Empty
        '  Dim obj4 As Object = String.Empty
        '  Dim browser As IWebBrowser2 = CType(Me.m_control, IWebBrowser2)
        '  browser.Silent = True
        '  Me.m_control.Navigate(Me.m_url, obj1, obj2, obj3, obj4)
        'End If
      End Set
    End Property
#End Region

#Region "Methods"
    Private Sub ApplyBody(ByVal val As String)
      Try
        If (Me.m_control Is Nothing) Then
          Return
        End If
        Dim element As IHTMLElement = Nothing
        Dim doc As IHTMLDocument2 = Me.m_control.GetDocument
        If (Not doc Is Nothing) Then
          element = doc.GetBody
        End If
        If (Not element Is Nothing) Then
          Me.UIActivate()
          element.SetInnerHTML(val)
        End If
      Catch ex As Exception
      End Try
    End Sub
    Private Sub ApplyCascadingStyleSheet()
      If (Not Me.m_control Is Nothing) Then
        Dim doc As IHTMLDocument2 = Me.m_control.GetDocument
        If (Not doc Is Nothing) Then
          doc.CreateStyleSheet(Me.m_cssStyleSheet, 0)
        End If
      End If
    End Sub
    Protected Overrides Sub AttachInterfaces()
      Try
        Me.m_control = CType(MyBase.GetOcx, IWebBrowser)
      Catch ex As Exception
      End Try
    End Sub
    Protected Overrides Sub CreateSink()
      Try
        Me.m_cookie = New ConnectionPointCookie(MyBase.GetOcx, Me, GetType(IWebBrowserEvents))
      Catch ex As Exception
      End Try
    End Sub
    Public Sub DelayedInitialize()
      Me.m_initialized = True
      If (Me.m_html.Length > 0) Then
        Me.ApplyBody(Me.m_html)
      End If
      Me.UIActivate()
      Me.ApplyCascadingStyleSheet()
    End Sub
    Private Sub DelayedInitializeCaller(ByVal sender As Object, ByVal e As BrowserNavigateEventArgs)
      Dim invoker As MethodInvoker = New MethodInvoker(AddressOf Me.DelayedInitialize)
      MyBase.BeginInvoke(invoker)
      RemoveHandler NavigateComplete, AddressOf DelayedInitializeCaller
    End Sub
    Protected Overrides Sub DetachSink()
      Try
        Me.m_cookie.Disconnect()
      Catch ex As Exception
      End Try
    End Sub
    Protected Overrides Sub OnHandleCreated(ByVal e As EventArgs)
      MyBase.OnHandleCreated(e)
      AddHandler BeforeNavigate, AddressOf DelayedInitializeCaller
      Dim obj1 As Object = 0
      Dim obj2 As Object = String.Empty
      Dim obj3 As Object = String.Empty
      Dim obj4 As Object = String.Empty
      'Dim browser As IWebBrowser2 = CType(Me.m_control, IWebBrowser2)
      'browser.Silent = True
      Me.m_control.Navigate(Me.m_url, obj1, obj2, obj3, obj4)
    End Sub
    Private Sub UIActivate()
      MyBase.DoVerb(OLEIVERB_UIACTIVATE)
    End Sub
#End Region

#Region "IWebBrowserEvents"
    Public Sub RaiseBeforeNavigate(ByVal url As String, ByVal flags As Integer, ByVal targetFrameName As String, ByRef postData As Object, ByVal headers As String, ByRef cancel As Boolean) Implements IWebBrowserEvents.RaiseBeforeNavigate
      If Me.m_initialized Then
        Dim e As New BrowserNavigateEventArgs(url, False)
        RaiseEvent BeforeNavigate(Me, e)
        cancel = e.Cancel
      End If
    End Sub
    Public Sub RaiseNavigateComplete(ByVal url As String) Implements IWebBrowserEvents.RaiseNavigateComplete
      Dim e As New BrowserNavigateEventArgs(url, False)
      RaiseEvent NavigateComplete(Me, e)
    End Sub
#End Region

  End Class
End Namespace