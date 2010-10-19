Imports System.Windows.Forms
Imports Longkong.Core.Services
Imports Longkong.Pojjaman.Internal.Parser
Imports Longkong.Pojjaman.Gui.Components
Namespace Longkong.Pojjaman.Services
  Public Class DefaultStatusBarService
    Inherits AbstractService
    Implements IStatusBarService

#Region "Members"
    Private m_lastMessage As String
    Private m_statusBar As PJMStatusBar
    Private m_stringParserService As stringParserService
    Private m_wasError As Boolean
#End Region

#Region "Constructors"
    Public Sub New()
      Me.m_statusBar = Nothing
      Me.m_stringParserService = CType(ServiceManager.Services.GetService(GetType(StringParserService)), StringParserService)
      Me.m_wasError = False
      Me.m_lastMessage = ""
      Me.m_statusBar = New PJMStatusBar(Me)
    End Sub
#End Region

#Region "Methods"
    Public Sub Dispose()
      If (Not Me.m_statusBar Is Nothing) Then
        Me.m_statusBar.Dispose()
        Me.m_statusBar = Nothing
      End If
    End Sub
    Public Sub Update()
    End Sub
#End Region

#Region "IStatusBarService"
    Public Property CancelEnabled() As Boolean Implements IStatusBarService.CancelEnabled
      Get
        If (Not Me.m_statusBar Is Nothing) Then
          Return Me.m_statusBar.CancelEnabled
        End If
        Return False
      End Get
      Set(ByVal value As Boolean)
        Me.m_statusBar.CancelEnabled = value
      End Set

    End Property

    Public ReadOnly Property Control() As System.Windows.Forms.Control Implements IStatusBarService.Control
      Get
        Return Me.m_statusBar
      End Get
    End Property

    Public ReadOnly Property ProgressMonitor() As Longkong.Pojjaman.Gui.IProgressMonitor Implements IStatusBarService.ProgressMonitor
      Get
        Return Me.m_statusBar
      End Get
    End Property

    Public Sub RedrawStatusbar() Implements IStatusBarService.RedrawStatusbar
      If Me.m_wasError Then
        Me.ShowErrorMessage(Me.m_lastMessage)
      Else
        Me.SetMessage(Me.m_lastMessage)
      End If
    End Sub

    Public Sub RefreshLanguage() Implements IStatusBarService.RefreshLanguage
      Dim lang As String = System.Windows.Forms.InputLanguage.CurrentInputLanguage.Culture.Name
      If Not lang Is Nothing AndAlso lang.Length > 2 Then
        lang = Left(lang, 2).ToUpper
      End If
      Me.m_statusBar.LanguageStatusBarPanel.Text = lang
    End Sub

    Public Sub SetCaretPosition(ByVal x As Integer, ByVal y As Integer, ByVal charOffset As Integer) Implements IStatusBarService.SetCaretPosition
      Dim textArray1(,) As String = New String(3 - 1, 2 - 1) {}
      textArray1(0, 0) = "Line"
      textArray1(0, 1) = String.Format("{0,-10}", (y + 1))
      textArray1(1, 0) = "Column"
      textArray1(1, 1) = String.Format("{0,-5}", (x + 1))
      textArray1(2, 0) = "Character"
      textArray1(2, 1) = String.Format("{0,-5}", (charOffset + 1))
      Me.m_statusBar.CursorStatusBarPanel.Text = Me.m_stringParserService.Parse("${res:StatusBarService.CursorStatusBarPanelText}", textArray1)
    End Sub

    Public Sub SetInsertMode(ByVal insertMode As Boolean) Implements IStatusBarService.SetInsertMode
      Me.m_statusBar.ModeStatusBarPanel.Text = CStr(IIf(insertMode, Me.m_stringParserService.Parse("${res:StatusBarService.CaretModes.Insert}"), Me.m_stringParserService.Parse("${res:StatusBarService.CaretModes.Overwrite}")))
    End Sub

    Public Overloads Sub SetMessage(ByVal message As String) Implements IStatusBarService.SetMessage
      Me.m_lastMessage = message
      Me.m_statusBar.SetMessage(Me.m_stringParserService.Parse(message))
    End Sub

    Public Overloads Sub SetMessage(ByVal image As System.Drawing.Image, ByVal message As String) Implements IStatusBarService.SetMessage
      Me.m_statusBar.SetMessage(image, Me.m_stringParserService.Parse(message))
    End Sub

    Public Sub ShowErrorMessage(ByVal message As String) Implements IStatusBarService.ShowErrorMessage
      Me.m_statusBar.ShowErrorMessage(Me.m_stringParserService.Parse(message))
    End Sub

    Public Sub SetStatusMessage(ByVal message As String, ByVal color As Color) Implements IStatusBarService.SetStatusMessage
      Me.m_statusBar.SetStatusMessage(message)
      Me.m_statusBar.StatusColorMode = color
    End Sub

    Public Sub SetStatusMessage(ByVal image As Image, ByVal message As String, ByVal color As Color) Implements IStatusBarService.SetStatusMessage
      Me.m_statusBar.SetStatusMessage(image, message)
      Me.m_statusBar.StatusColorMode = color
    End Sub
  
#End Region

  End Class
End Namespace



