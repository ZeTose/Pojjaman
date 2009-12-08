Imports Longkong.XmlForms
Imports Longkong.Core.Properties
Imports Longkong.Core.Services
Imports Longkong.Pojjaman.Services
Imports System.Reflection
Namespace Longkong.Pojjaman.Gui.XmlForms
    Public MustInherit Class BasePojjamanUserControl
        Inherits XmlUserControl

#Region "Members"
        Private Shared m_fileUtilityService As FileUtilityService = Nothing
        Private Shared m_iconService As IconService = Nothing
        Private Shared m_menuService As MenuService = Nothing
        Private Shared m_messageService As IMessageService = Nothing
        Private Shared m_propertyService As PropertyService = Nothing
        Private Shared m_resourceService As ResourceService = Nothing
        Private Shared m_stringParserService As StringParserService = Nothing
#End Region

#Region "Constructors"
        Public Sub New(ByVal fileName As String)
            MyBase.New(fileName)
        End Sub
#End Region

#Region "Properties"
        Protected Shared ReadOnly Property FileUtilityService() As FileUtilityService
            Get
                If (BasePojjamanUserControl.m_fileUtilityService Is Nothing) Then
                    BasePojjamanUserControl.m_fileUtilityService = CType(ServiceManager.Services.GetService(GetType(FileUtilityService)), FileUtilityService)
                End If
                Return BasePojjamanUserControl.m_fileUtilityService
            End Get
        End Property
        Protected Shared ReadOnly Property IconService() As IconService
            Get
                If (BasePojjamanUserControl.m_iconService Is Nothing) Then
                    BasePojjamanUserControl.m_iconService = CType(ServiceManager.Services.GetService(GetType(IconService)), IconService)
                End If
                Return BasePojjamanUserControl.m_iconService
            End Get
        End Property
        Protected Shared ReadOnly Property MenuService() As MenuService
            Get
                If (BasePojjamanUserControl.m_menuService Is Nothing) Then
                    BasePojjamanUserControl.m_menuService = CType(ServiceManager.Services.GetService(GetType(MenuService)), MenuService)
                End If
                Return BasePojjamanUserControl.m_menuService
            End Get
        End Property
        Protected Shared ReadOnly Property MessageService() As IMessageService
            Get
                If (BasePojjamanUserControl.m_messageService Is Nothing) Then
                    BasePojjamanUserControl.m_messageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
                End If
                Return BasePojjamanUserControl.m_messageService
            End Get
        End Property
        Protected Shared ReadOnly Property PropertyService() As PropertyService
            Get
                If (BasePojjamanUserControl.m_propertyService Is Nothing) Then
                    BasePojjamanUserControl.m_propertyService = CType(ServiceManager.Services.GetService(GetType(PropertyService)), PropertyService)
                End If
                Return BasePojjamanUserControl.m_propertyService
            End Get
        End Property
        Protected Shared ReadOnly Property ResourceService() As ResourceService
            Get
                If (BasePojjamanUserControl.m_resourceService Is Nothing) Then
                    BasePojjamanUserControl.m_resourceService = CType(ServiceManager.Services.GetService(GetType(ResourceService)), ResourceService)
                End If
                Return BasePojjamanUserControl.m_resourceService
            End Get
        End Property
        Protected Shared ReadOnly Property StringParserService() As StringParserService
            Get
                If (BasePojjamanUserControl.m_stringParserService Is Nothing) Then
                    BasePojjamanUserControl.m_stringParserService = CType(ServiceManager.Services.GetService(GetType(StringParserService)), StringParserService)
                End If
                Return BasePojjamanUserControl.m_stringParserService
            End Get
        End Property
#End Region

#Region "Methods"
        Public Sub SetEnabledStatus(ByVal enabled As Boolean, ByVal ParamArray controlNames As String())
            For Each name As String In controlNames
                Dim myControl As Control = MyBase.ControlDictionary(name)
                If (myControl Is Nothing) Then
                    BasePojjamanUserControl.MessageService.ShowError((name & " not found!"))
                Else
                    myControl.Enabled = enabled
                End If
            Next
        End Sub
        Protected Overrides Sub SetupXmlLoader()
            Me.xmlLoader.StringValueFilter = New PojjamanStringValueFilter
            Me.xmlLoader.PropertyValueCreator = New PojjamanPropertyValueCreator
            Me.xmlLoader.ObjectCreator = New PojjamanObjectCreator
        End Sub
#End Region

    End Class
End Namespace

