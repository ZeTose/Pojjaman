Imports Longkong.Pojjaman.Internal.Project.Collections
Namespace Longkong.Pojjaman.Internal.Project
    Public Interface IProject
        Inherits IDisposable

        ' Events
        Event NameChanged As EventHandler

        ' Methods
        Function CloneConfiguration(ByVal configuration As IConfiguration) As IConfiguration
        Function CreateConfiguration() As IConfiguration
        Function CreateConfiguration(ByVal name As String) As IConfiguration
        Sub LoadProject(ByVal fileName As String)
        Sub SaveProject(ByVal fileName As String)

        ' Properties
        Property ActiveConfiguration() As IConfiguration
        ReadOnly Property BaseDirectory() As String
        ReadOnly Property Configurations() As ConfigurationCollection
        Property Description() As String
        Property EnableViewState() As Boolean
        Property IsDirty() As Boolean
        Property Name() As String
        ReadOnly Property ProjectType() As String
    End Interface

End Namespace




