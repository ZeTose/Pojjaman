Imports System.Configuration
Imports System.IO
Imports System.Reflection
Imports System.Environment
Imports System.Windows.Forms
Imports System.Xml
Imports Longkong.Core.Services
Namespace Longkong.Core.Properties
  Public Class ConfigurationService
    Inherits DefaultProperties
    Implements IService

#Region "Members"
    Private Shared m_configDirectory As String
    'Private Shared m_dataDirectory As String
    Private Shared ReadOnly m_propertyFileName As String
    Private Shared ReadOnly m_propertyFileVersion As String
    Private Shared ReadOnly m_propertyXmlRootNodeName As String
#End Region

#Region "Constructors"
    Shared Sub New()
      ConfigurationService.m_propertyFileName = "PojjamanConfigurations.xml"
      ConfigurationService.m_propertyFileVersion = "1.1"
      ConfigurationService.m_propertyXmlRootNodeName = "PojjamanProperties"
      ConfigurationService.m_configDirectory = (Path.GetDirectoryName([Assembly].GetEntryAssembly.Location) &
                                                Path.DirectorySeparatorChar & ".." & Path.DirectorySeparatorChar & "data" &
                                                Path.DirectorySeparatorChar & "options" & Path.DirectorySeparatorChar)

      'ConfigurationService.m_configDirectory = ConfigurationSettings.AppSettings.Item("ConfigDirectory")
      'If ConfigurationService.m_configDirectory Is Nothing OrElse ConfigurationService.m_configDirectory.Length = 0 Then
      '  ConfigurationService.m_configDirectory = Environment.GetFolderPath(SpecialFolder.ApplicationData) & Path.DirectorySeparatorChar & "Longkong" & Path.DirectorySeparatorChar & "Pojjaman" & Path.DirectorySeparatorChar
      'End If
      'Dim mydirectory As String = ConfigurationSettings.AppSettings.Item("DataDirectory")
      'If (Not mydirectory Is Nothing) Then
      '  ConfigurationService.m_dataDirectory = mydirectory
      'Else
      '  ConfigurationService.m_dataDirectory = Path.GetDirectoryName([Assembly].GetEntryAssembly.Location) & Path.DirectorySeparatorChar & ".." & Path.DirectorySeparatorChar & "data"
      'End If
    End Sub
    Public Sub New()
      Try
        Me.LoadProperties()
      Catch exception1 As PropertyFileLoadException
        MessageBox.Show("Can't load property file", "Warning")
      End Try
    End Sub
#End Region

#Region "Properties"
    Public ReadOnly Property ConfigDirectory() As String
      Get
        Return ConfigurationService.m_configDirectory
      End Get
    End Property
    'Public ReadOnly Property DataDirectory() As String
    '  Get
    '    'Return ConfigurationService.m_dataDirectory
    '  End Get
    'End Property
#End Region

#Region "Methods"
    Protected Overridable Sub OnInitialize(ByVal e As EventArgs)
      RaiseEvent Initialize(Me, e)
    End Sub
    Protected Overridable Sub OnUnload(ByVal e As EventArgs)
      RaiseEvent Unload(Me, e)
    End Sub

    Public Sub SaveProperties()
      Me.WritePropertiesToFile((ConfigurationService.m_configDirectory & ConfigurationService.m_propertyFileName))
    End Sub

    Private Sub WritePropertiesToFile(ByVal fileName As String)
      Dim doc As New XmlDocument
      doc.LoadXml("<?xml version=""1.0""?>" & ChrW(10) & "<" & ConfigurationService.m_propertyXmlRootNodeName & " fileversion = """ & ConfigurationService.m_propertyFileVersion & """ />")
      doc.DocumentElement.AppendChild(Me.ToXmlElement(doc))
      Dim myFileUtilityService As FileUtilityService = CType(ServiceManager.Services.GetService(GetType(FileUtilityService)), FileUtilityService)
      myFileUtilityService.ObservedSave(New NamedFileOperationDelegate(AddressOf doc.Save), fileName, FileErrorPolicy.ProvideAlternative)
    End Sub
    Public Shared Sub SetConfigDirectory(ByVal confDir As String)
      ConfigurationService.m_configDirectory = confDir
    End Sub
    Private Sub LoadProperties()
      If Not Directory.Exists(ConfigurationService.m_configDirectory) Then
        Directory.CreateDirectory(ConfigurationService.m_configDirectory)
      End If
      If Not Me.LoadPropertiesFromStream((ConfigurationService.m_configDirectory & ConfigurationService.m_propertyFileName)) Then
        'If Not Me.LoadPropertiesFromStream(Me.DataDirectory & Path.DirectorySeparatorChar & "options" & Path.DirectorySeparatorChar & ConfigurationService.m_propertyFileName) Then
        Throw New PropertyFileLoadException
        'End If
      End If
    End Sub
    Private Function LoadPropertiesFromStream(ByVal filename As String) As Boolean
      Try
        Dim doc As New XmlDocument
        doc.Load(filename)
        If (Not doc.DocumentElement.Attributes.ItemOf("fileversion").InnerText = ConfigurationService.m_propertyFileVersion) Then
          Return False
        End If
        MyBase.SetValueFromXmlElement(doc.DocumentElement.Item("Properties"))
      Catch exception1 As Exception
        Console.WriteLine(("Exception while load properties from stream :" & ChrW(10) & " " & exception1.ToString))
        Return False
      End Try
      Return True
    End Function
#End Region

#Region "IService"
    Public Event Initialize(ByVal sender As Object, ByVal e As System.EventArgs) Implements Services.IService.Initialize
    Public Event Unload(ByVal sender As Object, ByVal e As System.EventArgs) Implements Services.IService.Unload

    Public Sub InitializeService() Implements Services.IService.InitializeService
      Me.OnInitialize(EventArgs.Empty)
    End Sub

    Public Sub UnloadService() Implements Services.IService.UnloadService
      Me.SaveProperties()
      Me.OnUnload(EventArgs.Empty)
    End Sub
#End Region

  End Class
End Namespace

