Imports System.Drawing
Imports Longkong.Pojjaman.Services
Namespace Longkong.Pojjaman.Gui.Components
  Public Class PJMStatusBar
    Inherits StatusStrip 'AxStatusBar
    Implements IProgressMonitor

#Region "Members"
    Private m_cancelEnabled As Boolean
    Private m_oldMessage As String
    Private m_statusColorMode As Color

    Private m_txtStatusBarPanel As ToolStripStatusLabel
    Private m_statusProgressBar As ToolStripProgressBar
    Private m_languageStatusBarPanel As ToolStripStatusLabel
    Private m_modeStatusBarPanel As ToolStripStatusLabel

    'Private m_txtStatusBarPanel As AxStatusBarPanel
    'Private m_cursorStatusBarPanel As AxStatusBarPanel
    'Private m_modeStatusBarPanel As AxStatusBarPanel
    'Private m_languageStatusBarPanel As AxStatusBarPanel
    'Private m_statusProgressBar As ProgressBar

#End Region

#Region "Constructors"
    Public Sub New(ByVal manager As IStatusBarService)
      Me.m_txtStatusBarPanel = New ToolStripStatusLabel
      'Me.m_staturProgressBar.BackColor = System.Drawing.Color.Red
      Me.m_txtStatusBarPanel.Name = "m_txtStatusBarPanel"
      'Me.m_txtStatusBarPanel.Size = New System.Drawing.Size(400, 17)
      Me.m_txtStatusBarPanel.Spring = True
      Me.m_txtStatusBarPanel.Text = ""
      Me.m_txtStatusBarPanel.TextAlign = ContentAlignment.MiddleLeft
      MyBase.Items.Add(Me.m_txtStatusBarPanel)

      Me.m_statusProgressBar = New ToolStripProgressBar
      Me.m_statusProgressBar.Name = "m_statusProgressBar"
      Me.m_statusProgressBar.Size = New System.Drawing.Size(180, 17)
      Me.m_statusProgressBar.Visible = False
      MyBase.Items.Add(Me.m_statusProgressBar)

      Dim m_separator1 As New ToolStripSeparator
      m_separator1.Name = "m_separator1"
      MyBase.Items.Add(m_separator1)

      Me.m_modeStatusBarPanel = New ToolStripStatusLabel
      'Me.m_staturProgressBar.BackColor = System.Drawing.Color.Red
      Me.m_modeStatusBarPanel.Spring = False
      Me.m_modeStatusBarPanel.Name = "m_modeStatusBarPanel"
      Me.m_modeStatusBarPanel.Size = New System.Drawing.Size(300, 17)
      Me.m_modeStatusBarPanel.Text = ""
      Me.m_modeStatusBarPanel.TextAlign = ContentAlignment.MiddleLeft
      MyBase.Items.Add(Me.m_modeStatusBarPanel)

      Dim m_separator2 As New ToolStripSeparator
      m_separator2.Name = "m_separator1"
      MyBase.Items.Add(m_separator2)

      Me.m_languageStatusBarPanel = New ToolStripStatusLabel
      'Me.m_staturProgressBar.BackColor = System.Drawing.Color.Red
      Me.m_languageStatusBarPanel.Spring = False
      Me.m_languageStatusBarPanel.Name = "m_languageStatusBarPanel"
      Me.m_languageStatusBarPanel.Size = New System.Drawing.Size(50, 17)
      Me.m_languageStatusBarPanel.Text = ""
      Me.m_languageStatusBarPanel.TextAlign = ContentAlignment.MiddleCenter
      MyBase.Items.Add(Me.m_languageStatusBarPanel)

      'Me.m_statusProgressBar = New ProgressBar
      'Me.m_txtStatusBarPanel = New AxStatusBarPanel
      'Me.m_cursorStatusBarPanel = New AxStatusBarPanel
      'Me.m_modeStatusBarPanel = New AxStatusBarPanel
      'Me.m_languageStatusBarPanel = New AxStatusBarPanel
      'Me.m_oldMessage = Nothing
      'Me.m_txtStatusBarPanel.Width = 500
      'Me.m_txtStatusBarPanel.AutoSize = StatusBarPanelAutoSize.Spring
      'MyBase.Panels.Add(Me.m_txtStatusBarPanel)
      'Me.m_statusProgressBar.Width = 200
      'Me.m_statusProgressBar.Height = 14
      'Me.m_statusProgressBar.Location = New Point(160, 6)
      'Me.m_statusProgressBar.Minimum = 0
      'Me.m_statusProgressBar.Visible = False
      'MyBase.Controls.Add(Me.m_statusProgressBar)
      'Me.m_cursorStatusBarPanel.Width = 200
      'Me.m_cursorStatusBarPanel.AutoSize = StatusBarPanelAutoSize.None
      'Me.m_cursorStatusBarPanel.Alignment = HorizontalAlignment.Left
      'MyBase.Panels.Add(Me.m_cursorStatusBarPanel)

      'Me.m_languageStatusBarPanel.Width = 30
      'Me.m_languageStatusBarPanel.AutoSize = StatusBarPanelAutoSize.None
      'Me.m_languageStatusBarPanel.Alignment = HorizontalAlignment.Center
      'MyBase.Panels.Add(Me.m_languageStatusBarPanel)

      'Me.m_modeStatusBarPanel.Width = 44
      'Me.m_modeStatusBarPanel.AutoSize = StatusBarPanelAutoSize.None
      'Me.m_modeStatusBarPanel.Alignment = HorizontalAlignment.Right
      'MyBase.Panels.Add(Me.m_modeStatusBarPanel)

      'MyBase.Font = New Font("Tahoma", 8, FontStyle.Regular)
      'MyBase.ShowPanels = True
    End Sub
#End Region

#Region "Properties"
    Public Property StatusColorMode As Color
      Get
        Return m_statusColorMode
      End Get
      Set(ByVal value As Color)
        m_statusColorMode = value
        Me.CursorStatusBarPanel.BackColor = value
        Me.ModeStatusBarPanel.BackColor = value
        Me.LanguageStatusBarPanel.BackColor = value
      End Set
    End Property

    Public Property CancelEnabled() As Boolean
      Get
        Return Me.m_cancelEnabled
      End Get
      Set(ByVal value As Boolean)
        Me.m_cancelEnabled = value
      End Set
    End Property

    Public ReadOnly Property CursorStatusBarPanel As ToolStripStatusLabel
      Get
        Return m_txtStatusBarPanel
      End Get
    End Property
    Public ReadOnly Property ModeStatusBarPanel() As ToolStripStatusLabel
      Get
        Return Me.m_modeStatusBarPanel
      End Get
    End Property
    Public ReadOnly Property LanguageStatusBarPanel() As ToolStripStatusLabel
      Get
        Return m_languageStatusBarPanel
      End Get
    End Property


    'Public ReadOnly Property CursorStatusBarPanel() As AxStatusBarPanel
    '  Get
    '    Return Me.m_cursorStatusBarPanel
    '  End Get
    'End Property
    'Public ReadOnly Property ModeStatusBarPanel() As AxStatusBarPanel
    '  Get
    '    Return Me.m_modeStatusBarPanel
    '  End Get
    'End Property
    'Public ReadOnly Property LanguageStatusBarPanel() As AxStatusBarPanel
    '  Get
    '    Return Me.m_languageStatusBarPanel
    '  End Get
    'End Property
#End Region

#Region "Methods"
    Public Sub SetMessage(ByVal message As String)
      Me.CursorStatusBarPanel.Text = message
    End Sub
    Public Sub SetMessage(ByVal image As Image, ByVal message As String)
      Me.CursorStatusBarPanel.Text = message
      Me.CursorStatusBarPanel.Image = image
    End Sub
    Public Sub ShowErrorMessage(ByVal message As String)
      Me.CursorStatusBarPanel.Text = ("Error : " & message)
    End Sub
    Public Sub ShowErrorMessage(ByVal image As Image, ByVal message As String)
      Me.CursorStatusBarPanel.Text = ("Error : " & message)
      Me.CursorStatusBarPanel.Image = image
    End Sub
    Public Sub SetStatusMessage(ByVal message As String)
      Me.ModeStatusBarPanel.Text = message
    End Sub
    Public Sub SetStatusMessage(ByVal image As Image, ByVal message As String)
      Me.ModeStatusBarPanel.Text = message
      Me.ModeStatusBarPanel.Image = image
    End Sub
    'Public Sub SetMessage(ByVal message As String)
    '  Me.m_txtStatusBarPanel.Text = message
    'End Sub
    'Public Sub SetMessage(ByVal image As Image, ByVal message As String)
    '  Me.m_txtStatusBarPanel.Text = message
    'End Sub
    'Public Sub ShowErrorMessage(ByVal message As String)
    '  Me.m_txtStatusBarPanel.Text = ("Error : " & message)
    'End Sub
    'Public Sub ShowErrorMessage(ByVal image As Image, ByVal message As String)
    '  Me.m_txtStatusBarPanel.Text = ("Error : " & message)
    'End Sub
    'Public Sub SetIcon(ByVal ico As Icon)
    '  Me.m_cursorStatusBarPanel.Icon = ico
    'End Sub
#End Region

#Region "IProgressMonitor"
    Public Sub BeginTask(ByVal name As String, ByVal totalWork As Integer) Implements IProgressMonitor.BeginTask
      Me.m_oldMessage = Me.CursorStatusBarPanel.Text
      'Me.SetMessage(name)
      Me.m_statusProgressBar.Maximum = totalWork
      'Me.m_statusProgressBar.Left = ((Me.m_txtStatusBarPanel.Width - Me.m_statusProgressBar.Width) - 4)
      Me.m_statusProgressBar.Visible = True
    End Sub
    Public Property Canceled() As Boolean Implements IProgressMonitor.Canceled
      Get
        Return (Me.m_oldMessage Is Nothing)
      End Get
      Set(ByVal Value As Boolean)
        Me.Done()
      End Set
    End Property
    Public Sub Done() Implements IProgressMonitor.Done
      'Me.SetMessage(Me.m_oldMessage)
      Me.m_oldMessage = Nothing
      Me.m_statusProgressBar.Visible = False
    End Sub
    Public Property TaskName() As String Implements IProgressMonitor.TaskName
      Get
        Return ""
      End Get
      Set(ByVal Value As String)
      End Set
    End Property
    Public Sub Worked(ByVal work As Integer) Implements IProgressMonitor.Worked
      Me.m_statusProgressBar.Value = work
    End Sub

    'Public Sub BeginTask(ByVal name As String, ByVal totalWork As Integer) Implements IProgressMonitor.BeginTask
    '  Me.m_oldMessage = Me.m_txtStatusBarPanel.Text
    '  'Me.SetMessage(name)
    '  Me.m_statusProgressBar.Maximum = totalWork
    '  Me.m_statusProgressBar.Left = ((Me.m_txtStatusBarPanel.Width - Me.m_statusProgressBar.Width) - 4)
    '  Me.m_statusProgressBar.Visible = True
    'End Sub
    'Public Property Canceled() As Boolean Implements IProgressMonitor.Canceled
    '  Get
    '    Return (Me.m_oldMessage Is Nothing)
    '  End Get
    '  Set(ByVal Value As Boolean)
    '    Me.Done()
    '  End Set
    'End Property
    'Public Sub Done() Implements IProgressMonitor.Done
    '  'Me.SetMessage(Me.m_oldMessage)
    '  Me.m_oldMessage = Nothing
    '  Me.m_statusProgressBar.Visible = False
    'End Sub
    'Public Property TaskName() As String Implements IProgressMonitor.TaskName
    '  Get
    '    Return ""
    '  End Get
    '  Set(ByVal Value As String)
    '  End Set
    'End Property
    'Public Sub Worked(ByVal work As Integer) Implements IProgressMonitor.Worked
    '  Me.m_statusProgressBar.Value = work
    'End Sub
#End Region

  End Class
End Namespace
