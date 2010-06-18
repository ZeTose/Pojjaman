Imports System.Configuration
Imports System.Xml
Imports Longkong.Core
Imports Longkong.Core.Services
Imports Longkong.Core.AddIns
Imports Longkong.Core.AddIns.Codons
Imports Longkong.Pojjaman.Gui
Imports Longkong.Pojjaman.Gui.Dialogs
Imports Longkong.Pojjaman.Services
Imports Longkong.Core.Properties
Imports System.Threading
Imports Longkong.Pojjaman.Commands
Namespace Pojjaman
  Public Class PojjamanMain
    Implements IDisposable

#Region "Members"
    Private Shared m_commandLineArgs As String()
#End Region

#Region "Constructors"
    Shared Sub New()
      PojjamanMain.m_commandLineArgs = Nothing
    End Sub
    Public Sub New()

    End Sub
#End Region

#Region "Properies"
    Public Shared ReadOnly Property CommandLineArgs() As String()
      Get
        Return PojjamanMain.m_commandLineArgs
      End Get
    End Property
#End Region

#Region "Methods"
    <STAThread()> _
    Public Shared Sub Main(ByVal args As String())
      Application.EnableVisualStyles()
      PojjamanMain.m_commandLineArgs = args
      Dim noLogo As Boolean = False
      Dim noPassword As Boolean = False
      Dim noDBCheck As Boolean = False
      SplashScreenForm.SetCommandLineArgs(args)
      For Each parameter As String In SplashScreenForm.GetParameterList
        Select Case parameter.ToUpper
          Case "NOLOGO"
            noLogo = True
          Case "NOPASSWORD"
            noPassword = True
          Case "NODBCHECK"
            noDBCheck = True
          Case "ALLOWTAB"
            StartPojjamanWorkbenchCommand.ALLOWTAB = True
        End Select
      Next
      If Not noLogo Then
        SplashScreenForm.SplashScreen.Show()
      End If
      StartPojjamanWorkbenchCommand.NODBCHECK = noDBCheck
      AddHandler Application.ThreadException, New ThreadExceptionEventHandler(AddressOf ShowErrorBox)

      Dim ignoreDefaultPath As Boolean = False
      Dim addInDirs As String() = AddInSettingsHandler.GetAddInDirectories(ignoreDefaultPath)
      AddInTreeSingleton.SetAddInDirectories(addInDirs, False)
      Dim commands As ArrayList = Nothing
      Try
        ServiceManager.Services.AddService(New MessageService)
        ServiceManager.Services.AddService(New ResourceService)
        ServiceManager.Services.AddService(New IconService)
        ServiceManager.Services.InitializeServicesSubsystem("/Workspace/Services")
        'GetTreeNode --> BuildChildItems --> commands
        commands = AddInTreeSingleton.AddInTree.GetTreeNode("/Workspace/Autostart").BuildChildItems(Nothing)
        If (Not SplashScreenForm.SplashScreen Is Nothing) Then
          SplashScreenForm.SplashScreen.TopMost = False
        End If
        Dim pwdSet As Boolean = False
        For i As Integer = 0 To (commands.Count - 1) - 1
          CType(commands(i), ICommand).Run()
          If Not pwdSet Then
            Dim secServe As SecurityService = CType(ServiceManager.Services.GetService(GetType(SecurityService)), SecurityService)
            If Not secServe Is Nothing Then
              SecurityService.NoPassword = noPassword
              pwdSet = True
            End If
          End If
        Next
      Catch e As XmlException
        MessageBox.Show(("Could not load XML :" & Environment.NewLine & e.Message))
        Return
      Catch e As System.ComponentModel.LicenseException
        If (Not SplashScreenForm.SplashScreen Is Nothing) Then
          SplashScreenForm.SplashScreen.Close()
        End If
        Dim dlg As New LicenseErrorBox(e)
        'Dim dlg As New LicenseErrorBox
        dlg.ShowDialog()
        Return
      Catch e As Exception
        MessageBox.Show(("Loading error, please reinstall :" & Environment.NewLine & e.ToString))
        Return
      Finally
        If (Not SplashScreenForm.SplashScreen Is Nothing) Then
          SplashScreenForm.SplashScreen.Close()
        End If
      End Try
      Try
        If (commands.Count > 0) Then
          CType(commands((commands.Count - 1)), ICommand).Run()
        End If
      Finally
        ServiceManager.Services.UnloadAllServices()
        For Each fileName As String In ShowPrintLog.FileList
          Try
            IO.File.Delete(fileName)
          Catch ex As Exception

          End Try
        Next
      End Try
    End Sub

    Private Shared Sub ShowErrorBox(ByVal sender As Object, ByVal eargs As ThreadExceptionEventArgs)
      Dim e As Exception = eargs.Exception
      If TypeOf eargs.Exception Is SqlClient.SqlException Then
        If eargs.Exception.Message = "Timeout expired.  The timeout period elapsed prior to completion of the operation or the server is not responding." Then
          e = New Exception("การเรียกข้อมูลจากฐานข้อมูลช้าเกินไป ไม่สามารถทำงานต่อได้")
        End If
      End If
      Select Case New ExceptionBox(e).ShowDialog
        Case DialogResult.Abort
          Application.Exit()
          Return
        Case DialogResult.Retry, DialogResult.Ignore, DialogResult.Yes
          Return
      End Select
    End Sub

#End Region

    Public Sub Dispose() Implements System.IDisposable.Dispose
    End Sub
  End Class
End Namespace
