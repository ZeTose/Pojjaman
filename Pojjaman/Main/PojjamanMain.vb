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
    Private Const WorkbenchMemento As String = "Pojjaman.Workbench.WorkbenchMemento"
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
        End Select
      Next
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

        Dim myWorkBench As New PojjamanWorkbench
        If Not noLogo Then
          DrawSplashText()
          SplashScreenForm.SplashScreen.Show()
          System.Threading.Thread.CurrentThread.Sleep(2000)
        End If

        'GetTreeNode --> BuildChildItems --> commands
        commands = AddInTreeSingleton.AddInTree.GetTreeNode("/Workspace/Autostart").BuildChildItems(Nothing)
        myWorkBench.Init()
        WorkbenchSingleton.Workbench = myWorkBench
        myWorkBench.InitializeWorkspace()
        Dim myPropertyService As PropertyService = CType(ServiceManager.Services.GetService(GetType(PropertyService)), PropertyService)
        myWorkBench.SetMemento(CType(myPropertyService.GetProperty(WorkbenchMemento, New WorkbenchMemento), IXmlConvertable))
        myWorkBench.UpdatePadContents(Nothing, Nothing)
        WorkbenchSingleton.CreateWorkspace()
        'If (Not SplashScreenForm.SplashScreen Is Nothing) Then
        '    SplashScreenForm.SplashScreen.TopMost = False
        'End If
        Dim pwdSet As Boolean = False
        For i As Integer = 0 To (commands.Count - 1) - 1
          CType(commands(i), ICommand).Run()
          If Not pwdSet Then
            Dim secServe As SecurityService = CType(ServiceManager.Services.GetService(GetType(SecurityService)), SecurityService)
            If Not secServe Is Nothing Then
              secServe.NoPassword = noPassword
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
      Catch ex As Exception
        MessageBox.Show(ex.ToString)
      Finally
        ServiceManager.Services.UnloadAllServices()
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

    Private Shared Sub DrawSplashText()
      'Dim license As DeployLX.Licensing.v3.SecureLicense = CType(WorkbenchSingleton.Workbench, PojjamanWorkbench)._license

      'Dim name As String = ""
      'Dim serial As String = ""
      'Dim organization As String = ""
      'Dim myStringParserService As StringParserService = CType(ServiceManager.Services.GetService(GetType(StringParserService)), StringParserService)
      'If license.IsTrial Then
      '  serial = "Trial"
      'Else
      '  name = license.Username
      '  serial = license.SerialNumber
      '  organization = license.Organization
      'End If

      'Dim prodInfo As New clsAssInfo(System.Reflection.Assembly.GetExecutingAssembly)

      'Dim im As Image = SplashScreenForm.SplashScreen.BackgroundImage
      'Dim g As Graphics = Graphics.FromImage(im)
      'Dim fn As Font = New System.Drawing.Font("Tahoma", 2.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      'Dim sf As New StringFormat
      'sf.Alignment = StringAlignment.Far

      'g.DrawString(myStringParserService.Parse("${res:Pojjaman.PojjamanNameLabel}") & Environment.NewLine & _
      'myStringParserService.Parse("${res:Pojjaman.VersionLabel}") & Space(1) & prodInfo.Version & Environment.NewLine & _
      'myStringParserService.Parse("${res:Pojjaman.CopyRightLabel}"), _
      'fn, _
      'New SolidBrush(Color.Gray), _
      'New RectangleF(90, 150, 400, 300), _
      'sf)

      'g.DrawString(myStringParserService.Parse("${res:Pojjaman.LicenseImprovLabel}"), fn, _
      'New SolidBrush(Color.Gray), _
      'New RectangleF(90, 195, 400, 300), _
      'sf)
      'g.DrawString(name, fn, _
      'New SolidBrush(Color.FromArgb(64, 64, 64)), _
      'New RectangleF(90, 207, 400, 300), _
      'sf)
      'g.DrawString(organization, fn, _
      'New SolidBrush(Color.FromArgb(64, 64, 64)), _
      'New RectangleF(90, 219, 400, 300), _
      'sf)

      'g.DrawString(myStringParserService.Parse("${res:Pojjaman.OwnerNameLabel}") & Environment.NewLine & _
      'myStringParserService.Parse("${res:Pojjaman.SoftwareHouseNoLabel}") & Environment.NewLine & _
      'myStringParserService.Parse("${res:Pojjaman.SoftwareHouseDescriptionabel}"), fn, _
      'New SolidBrush(Color.Gray), _
      'New RectangleF(90, 236, 400, 300), _
      'sf)
      'g.DrawString(serial, fn, _
      'New SolidBrush(Color.FromArgb(64, 64, 64)), _
      'New RectangleF(90, 275, 400, 300), _
      'sf)

      'SplashScreenForm.SplashScreen.Invalidate()
    End Sub

#End Region

    Public Sub Dispose() Implements System.IDisposable.Dispose
    End Sub
  End Class
End Namespace
