Imports Longkong.Core.AddIns.Codons
Imports Longkong.Pojjaman.Services
Imports Longkong.Core.Services
Imports Longkong.Core.Properties
Imports Longkong.Pojjaman.Gui
Imports Longkong.Pojjaman.Gui.Dialogs
Imports System.IO
Imports Longkong.Pojjaman.BusinessLogic
Imports System.Reflection
Imports Longkong.Pojjaman.DataAccessLayer
Namespace Longkong.Pojjaman.Commands
  Public Class StartPojjamanWorkbenchCommand
    Inherits AbstractCommand

#Region "Members"
    Private m_isCalled As Boolean
    Private Const m_workbenchMemento As String = "Pojjaman.Workbench.WorkbenchMemento"
    Private idleEventHandler As EventHandler

    Public Shared NODBCHECK As Boolean = False
#End Region

#Region "Constructors"
    Public Sub New()
      Me.m_isCalled = False
    End Sub
#End Region

#Region "Methods"
    Public Overrides Sub Run()
      Dim workBenchForm As Form = CType(WorkbenchSingleton.Workbench, Form)

      'RDScreenForm.RDScreen.ShowDialog()

      Dim mySecurityService As SecurityService = CType(ServiceManager.Services.GetService(GetType(SecurityService)), SecurityService)
      Dim ret As DialogResult
      Dim loginUser As User
      Do While ret <> DialogResult.Cancel And (loginUser Is Nothing OrElse Not loginUser.Originated)
        ret = mySecurityService.Login
        loginUser = mySecurityService.CurrentUser
      Loop
      If ret = DialogResult.Cancel Then
        Application.ExitThread()
        Return
      End If
      Dim myResourceService As ResourceService = CType(ServiceManager.Services.GetService(GetType(IResourceService)), ResourceService)
      If Not loginUser Is Nothing AndAlso loginUser.Originated Then
        MessageBox.Show(myResourceService.GetString("MainWindow.WelcomeMessage") & " " & loginUser.Name)
        workBenchForm.Text = myResourceService.GetString("MainWindow.DialogName") & " (" & mySecurityService.CurrentUser.Name & ": " & Configuration.GetConfig("CompanyName").ToString & ")"
        Dim pjmVersion As Version = [Assembly].GetEntryAssembly.GetName.Version
        Dim pjmVersionArray As Object() = New Object() {pjmVersion.Major, ".", pjmVersion.Minor.ToString("00"), ".", pjmVersion.Build.ToString("0000")}
        Dim version As String = String.Concat(pjmVersionArray)
        workBenchForm.Text = myResourceService.GetString("MainWindow.DialogName") & " (" & loginUser.Name & ": " & Configuration.GetConfig("CompanyName").ToString & ")"
        Dim dbVersion As String = SqlHelper.GetVersion
        workBenchForm.Text &= ":DB=" & dbVersion
        workBenchForm.Text &= ":PJM=" & version
      End If

      If Not NODBCHECK Then
        Dim dbVersion As String = SqlHelper.GetVersion
        If dbVersion = "0" Then
          MessageBox.Show(myResourceService.GetString("Global.Error.OldDatabase"))
          Application.ExitThread()
          Return
        End If

        Dim pjmVersion As Version = [Assembly].GetEntryAssembly.GetName.Version
        Dim pjmVersionArray As Object() = New Object() {pjmVersion.Major, ".", pjmVersion.Minor.ToString("00"), ".", pjmVersion.Build.ToString("0000")}
        Dim version As String = String.Concat(pjmVersionArray)

        If version = dbVersion Then
          'Do nothing
        ElseIf Not SqlHelper.IsCompatible(version, dbVersion) Then
          If version > dbVersion Then
            MessageBox.Show(String.Format(myResourceService.GetString("Global.Error.PleaseUpdateDB"), dbVersion, version))
          Else
            MessageBox.Show(String.Format(myResourceService.GetString("Global.Error.PleaseUpdateProgram"), dbVersion, version))
          End If
          Application.ExitThread()
          Return
        End If
      End If

      Dim myPropertyService As PropertyService = CType(ServiceManager.Services.GetService(GetType(PropertyService)), PropertyService)
      Try
        workBenchForm.Show()
        Me.idleEventHandler = New EventHandler(AddressOf Me.ShowTipOfTheDay)
        AddHandler Application.Idle, Me.idleEventHandler
        Dim noLoadPrev As Boolean = False
        Dim textArray1 As String() = SplashScreenForm.GetRequestedFileList
        If (Not noLoadPrev AndAlso myPropertyService.GetProperty("Pojjaman.LoadPrevProjectOnStartup", False)) Then
          Dim obj1 As Object = myPropertyService.GetProperty("Longkong.Pojjaman.Gui.MainWindow.RecentOpen")
          If TypeOf obj1 Is RecentOpen Then
            Dim open1 As RecentOpen = CType(obj1, RecentOpen)
            If (open1.RecentProject.Count > 0) Then
              'service3.OpenCombine(open1.RecentProject.Item(0).ToString)
            End If
          End If
        End If
        workBenchForm.Focus()
        Application.AddMessageFilter(New FormKeyHandler)
        Application.Run(workBenchForm)
        Try
          myPropertyService.SetProperty("Pojjaman.Workbench.WorkbenchMemento", WorkbenchSingleton.Workbench.CreateMemento)
        Catch ex As Exception
          Console.WriteLine(("Exception while saving workbench state: " & ex.ToString))
        End Try
      Catch ex As Exception

      End Try
    End Sub
    Private Sub ShowTipOfTheDay(ByVal sender As Object, ByVal e As EventArgs)
      If Me.m_isCalled Then
        RemoveHandler Application.Idle, Me.idleEventHandler
      Else
        Me.m_isCalled = True
        Dim myPropertyService As PropertyService = CType(ServiceManager.Services.GetService(GetType(PropertyService)), PropertyService)
        If myPropertyService.GetProperty("Longkong.Pojjaman.Gui.Dialog.TipOfTheDayView.ShowTipsAtStartup", True) Then
          Dim myViewTipOfTheDay As New ViewTipOfTheDay
          myViewTipOfTheDay.Run()
        End If
      End If
    End Sub
#End Region

#Region "FormKeyHandler Class"
    Private Class FormKeyHandler
      Implements IMessageFilter

#Region "Members"
      Private Const keyPressedMessage As Integer = 256
#End Region

#Region "Constructors"
      Public Sub New()
      End Sub
#End Region

#Region "IMessageFilter"
      Public Function PreFilterMessage(ByRef m As System.Windows.Forms.Message) As Boolean Implements System.Windows.Forms.IMessageFilter.PreFilterMessage
        If (m.Msg = keyPressedMessage) Then
          Dim keys As keys = (CType(m.WParam.ToInt32, keys) Or Control.ModifierKeys)
          If (((keys = keys.Escape) AndAlso (Not WorkbenchSingleton.Workbench.ActiveWorkbenchWindow Is Nothing)) AndAlso (Not WorkbenchSingleton.Workbench.ActiveWorkbenchWindow.ActiveViewContent.Control.ContainsFocus AndAlso (Form.ActiveForm Is CType(WorkbenchSingleton.Workbench, Form)))) Then
            WorkbenchSingleton.Workbench.ActiveWorkbenchWindow.ActiveViewContent.Control.Focus()
            Return True
          End If
        End If
        Return False
      End Function
#End Region

    End Class
#End Region

  End Class

End Namespace
