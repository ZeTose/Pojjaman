Imports System.Configuration
Imports System.IO
Imports System.Reflection
Imports System.Environment
Imports System.Windows.Forms
Imports System.Xml
Imports Longkong.Core.Services
Namespace Longkong.Core.Properties
  Public Class PropertyService
    Inherits DefaultProperties
    Implements IService

#Region "Members"
    Private Shared m_configDirectory As String
    Private Shared m_dataDirectory As String
    Private Shared ReadOnly m_propertyFileName As String
    Private Shared ReadOnly m_propertyFileVersion As String
    Private Shared ReadOnly m_propertyXmlRootNodeName As String
#End Region

#Region "Constructors"
    Shared Sub New()
      PropertyService.m_propertyFileName = "PojjamanProperties.xml"
      PropertyService.m_propertyFileVersion = "1.1"
      PropertyService.m_propertyXmlRootNodeName = "PojjamanProperties"
      PropertyService.m_configDirectory = ConfigurationSettings.AppSettings.Item("ConfigDirectory")
      If PropertyService.m_configDirectory Is Nothing OrElse PropertyService.m_configDirectory.Length = 0 Then
        PropertyService.m_configDirectory = Environment.GetFolderPath(SpecialFolder.ApplicationData) & Path.DirectorySeparatorChar & "Longkong" & Path.DirectorySeparatorChar & "Pojjaman" & Path.DirectorySeparatorChar
      End If
      Dim mydirectory As String = ConfigurationSettings.AppSettings.Item("DataDirectory")
      If (Not mydirectory Is Nothing) Then
        PropertyService.m_dataDirectory = mydirectory
      Else
        PropertyService.m_dataDirectory = Path.GetDirectoryName([Assembly].GetEntryAssembly.Location) & Path.DirectorySeparatorChar & ".." & Path.DirectorySeparatorChar & "data"
      End If
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
        Return PropertyService.m_configDirectory
      End Get
    End Property
    Public ReadOnly Property DataDirectory() As String
      Get
        Return PropertyService.m_dataDirectory
      End Get
    End Property
#End Region

#Region "Methods"
    Protected Overridable Sub OnInitialize(ByVal e As EventArgs)
      RaiseEvent Initialize(Me, e)
    End Sub
    Protected Overridable Sub OnUnload(ByVal e As EventArgs)
      RaiseEvent Unload(Me, e)
    End Sub

    Public Sub SaveProperties()
      Me.WritePropertiesToFile((PropertyService.m_configDirectory & PropertyService.m_propertyFileName))
    End Sub

    Private Sub WritePropertiesToFile(ByVal fileName As String)
      Dim doc As New XmlDocument
      doc.LoadXml("<?xml version=""1.0""?>" & ChrW(10) & "<" & PropertyService.m_propertyXmlRootNodeName & " fileversion = """ & PropertyService.m_propertyFileVersion & """ />")
      doc.DocumentElement.AppendChild(Me.ToXmlElement(doc))
      Dim myFileUtilityService As FileUtilityService = CType(ServiceManager.Services.GetService(GetType(FileUtilityService)), FileUtilityService)
      myFileUtilityService.ObservedSave(New NamedFileOperationDelegate(AddressOf doc.Save), fileName, FileErrorPolicy.ProvideAlternative)
    End Sub
    Public Shared Sub SetConfigDirectory(ByVal confDir As String)
      PropertyService.m_configDirectory = confDir
    End Sub
    Private Sub LoadProperties()
      If Not Directory.Exists(PropertyService.m_configDirectory) Then
        Directory.CreateDirectory(PropertyService.m_configDirectory)
      End If
      If Not Me.LoadPropertiesFromStream((PropertyService.m_configDirectory & PropertyService.m_propertyFileName)) Then
        If Not Me.LoadPropertiesFromStream(Me.DataDirectory & Path.DirectorySeparatorChar & "options" & Path.DirectorySeparatorChar & PropertyService.m_propertyFileName) Then
          Throw New PropertyFileLoadException
        End If
      End If
    End Sub
    Private Function LoadPropertiesFromStream(ByVal filename As String) As Boolean
      Try
        Dim doc As New XmlDocument
        doc.Load(filename)
        If (Not doc.DocumentElement.Attributes.ItemOf("fileversion").InnerText = PropertyService.m_propertyFileVersion) Then
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

