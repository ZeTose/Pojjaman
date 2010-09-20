Imports Longkong.Core.Properties
Imports Longkong.Core.Services
Imports Longkong.Core.AddIns
Namespace Longkong.Core.Services
  Public Class ServiceManager

#Region "Members"
    Private Shared m_defaultServiceManager As ServiceManager
    Private m_serviceList As ArrayList
    Private m_servicesHashtable As Hashtable
#End Region

#Region "Constructors"
    Shared Sub New()
      ServiceManager.m_defaultServiceManager = New ServiceManager
    End Sub
    Private Sub New()
      Me.m_serviceList = New ArrayList
      Me.m_servicesHashtable = New Hashtable
      Try
        Me.AddService(New PropertyService)
        Me.AddService(New StringParserService)
        Me.AddService(New FileUtilityService)
        Me.AddService(New ConfigurationService)
      Catch ex As Exception

      End Try

    End Sub
#End Region

#Region "Properties"
    Public Shared ReadOnly Property Services() As ServiceManager
      Get
        Return ServiceManager.m_defaultServiceManager
      End Get
    End Property
#End Region

#Region "Methods"
    Public Sub AddService(ByVal service As IService)
      Me.m_serviceList.Add(service)
    End Sub
    Public Sub AddServices(ByVal services As IService())
      For Each service As IService In services
        Me.AddService(service)
      Next
    End Sub
    Public Function GetService(ByVal serviceType As Type) As IService
      Dim s As IService = CType(Me.m_servicesHashtable.Item(serviceType), IService)
      If (Not s Is Nothing) Then
        Return s
      End If
      For Each service As IService In Me.m_serviceList
        If Me.IsInstanceOfType(serviceType, service) Then
          Me.m_servicesHashtable.Item(serviceType) = service
          Return service
        End If
      Next
      Return Nothing
    End Function
    Public Sub InitializeServicesSubsystem(ByVal servicesPath As String)
      Me.AddServices(CType(AddInTreeSingleton.AddInTree.GetTreeNode(servicesPath).BuildChildItems(Me).ToArray(GetType(IService)), IService()))
      For Each service As IService In Me.m_serviceList
        service.InitializeService()
      Next
    End Sub
    Private Function IsInstanceOfType(ByVal type As Type, ByVal service As IService) As Boolean
      Dim serviceType As type = CType(service, Object).GetType
      For Each iface As type In serviceType.GetInterfaces
        If (iface Is type) Then
          Return True
        End If
      Next
      Do While (Not serviceType Is GetType(Object))
        If (type Is serviceType) Then
          Return True
        End If
        serviceType = serviceType.BaseType
      Loop
      Return False
    End Function
    Public Sub UnloadAllServices()
      For Each service As IService In Me.m_serviceList
        service.UnloadService()
      Next
    End Sub
#End Region

  End Class
End Namespace

