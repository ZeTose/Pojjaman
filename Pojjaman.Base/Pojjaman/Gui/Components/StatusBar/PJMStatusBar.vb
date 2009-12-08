Imports System.Drawing
Imports Longkong.Pojjaman.Services
Namespace Longkong.Pojjaman.Gui.Components
    Public Class PJMStatusBar
        Inherits AxStatusBar
        Implements IProgressMonitor

#Region "Members"
        Private m_cancelEnabled As Boolean
        Private m_cursorStatusBarPanel As AxStatusBarPanel
        Private m_modeStatusBarPanel As AxStatusBarPanel
        Private m_languageStatusBarPanel As AxStatusBarPanel
        Private m_oldMessage As String
        Private m_statusProgressBar As ProgressBar
        Private m_txtStatusBarPanel As AxStatusBarPanel
#End Region

#Region "Constructors"
        Public Sub New(ByVal manager As IStatusBarService)
            Me.m_statusProgressBar = New ProgressBar
            Me.m_txtStatusBarPanel = New AxStatusBarPanel
            Me.m_cursorStatusBarPanel = New AxStatusBarPanel
            Me.m_modeStatusBarPanel = New AxStatusBarPanel
            Me.m_languageStatusBarPanel = New AxStatusBarPanel
            Me.m_oldMessage = Nothing
            Me.m_txtStatusBarPanel.Width = 500
            Me.m_txtStatusBarPanel.AutoSize = StatusBarPanelAutoSize.Spring
            MyBase.Panels.Add(Me.m_txtStatusBarPanel)
            Me.m_statusProgressBar.Width = 200
            Me.m_statusProgressBar.Height = 14
            Me.m_statusProgressBar.Location = New Point(160, 6)
            Me.m_statusProgressBar.Minimum = 0
            Me.m_statusProgressBar.Visible = False
            MyBase.Controls.Add(Me.m_statusProgressBar)
            Me.m_cursorStatusBarPanel.Width = 200
            Me.m_cursorStatusBarPanel.AutoSize = StatusBarPanelAutoSize.None
            Me.m_cursorStatusBarPanel.Alignment = HorizontalAlignment.Left
            MyBase.Panels.Add(Me.m_cursorStatusBarPanel)

            Me.m_languageStatusBarPanel.Width = 30
            Me.m_languageStatusBarPanel.AutoSize = StatusBarPanelAutoSize.None
            Me.m_languageStatusBarPanel.Alignment = HorizontalAlignment.Center
            MyBase.Panels.Add(Me.m_languageStatusBarPanel)

            Me.m_modeStatusBarPanel.Width = 44
            Me.m_modeStatusBarPanel.AutoSize = StatusBarPanelAutoSize.None
            Me.m_modeStatusBarPanel.Alignment = HorizontalAlignment.Right
            MyBase.Panels.Add(Me.m_modeStatusBarPanel)

            MyBase.Font = New Font("Tahoma", 8, FontStyle.Regular)
            MyBase.ShowPanels = True
        End Sub
#End Region

#Region "Properties"
        Public Property CancelEnabled() As Boolean
            Get
                Return Me.m_cancelEnabled
            End Get
            Set(ByVal value As Boolean)
                Me.m_cancelEnabled = value
            End Set
        End Property
        Public ReadOnly Property CursorStatusBarPanel() As AxStatusBarPanel
            Get
                Return Me.m_cursorStatusBarPanel
            End Get
        End Property
        Public ReadOnly Property ModeStatusBarPanel() As AxStatusBarPanel
            Get
                Return Me.m_modeStatusBarPanel
            End Get
        End Property
        Public ReadOnly Property LanguageStatusBarPanel() As AxStatusBarPanel
            Get
                Return Me.m_languageStatusBarPanel
            End Get
        End Property
#End Region

#Region "Methods"
        Public Sub SetMessage(ByVal message As String)
            Me.m_txtStatusBarPanel.Text = message
        End Sub
        Public Sub SetMessage(ByVal image As Image, ByVal message As String)
            Me.m_txtStatusBarPanel.Text = message
        End Sub
        Public Sub ShowErrorMessage(ByVal message As String)
            Me.m_txtStatusBarPanel.Text = ("Error : " & message)
        End Sub
        Public Sub ShowErrorMessage(ByVal image As Image, ByVal message As String)
            Me.m_txtStatusBarPanel.Text = ("Error : " & message)
        End Sub
#End Region

#Region "IProgressMonitor"
        Public Sub BeginTask(ByVal name As String, ByVal totalWork As Integer) Implements IProgressMonitor.BeginTask
            Me.m_oldMessage = Me.m_txtStatusBarPanel.Text
            'Me.SetMessage(name)
            Me.m_statusProgressBar.Maximum = totalWork
            Me.m_statusProgressBar.Left = ((Me.m_txtStatusBarPanel.Width - Me.m_statusProgressBar.Width) - 4)
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
#End Region

    End Class
End Namespace
