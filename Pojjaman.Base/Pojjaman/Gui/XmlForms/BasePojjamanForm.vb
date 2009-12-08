Imports Longkong.XmlForms
Imports Longkong.Core.Properties
Imports Longkong.Core.Services
Imports Longkong.Pojjaman.Services
Namespace Longkong.Pojjaman.Gui.XmlForms
    Public MustInherit Class BasePojjamanForm
        Inherits XmlForm

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
        Public Sub New()
        End Sub
#End Region

#Region "Properties"
        Protected Shared ReadOnly Property FileUtilityService() As FileUtilityService
            Get
                If (BasePojjamanForm.m_fileUtilityService Is Nothing) Then
                    BasePojjamanForm.m_fileUtilityService = CType(ServiceManager.Services.GetService(GetType(FileUtilityService)), FileUtilityService)
                End If
                Return BasePojjamanForm.m_fileUtilityService
            End Get
        End Property
        Protected Shared ReadOnly Property IconService() As IconService
            Get
                If (BasePojjamanForm.m_iconService Is Nothing) Then
                    BasePojjamanForm.m_iconService = CType(ServiceManager.Services.GetService(GetType(IconService)), IconService)
                End If
                Return BasePojjamanForm.m_iconService
            End Get
        End Property
        Protected Shared ReadOnly Property MenuService() As MenuService
            Get
                If (BasePojjamanForm.m_menuService Is Nothing) Then
                    BasePojjamanForm.m_menuService = CType(ServiceManager.Services.GetService(GetType(MenuService)), MenuService)
                End If
                Return BasePojjamanForm.m_menuService
            End Get
        End Property
        Protected Shared ReadOnly Property MessageService() As IMessageService
            Get
                If (BasePojjamanForm.m_messageService Is Nothing) Then
                    BasePojjamanForm.m_messageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
                End If
                Return BasePojjamanForm.m_messageService
            End Get
        End Property
        Protected Shared ReadOnly Property PropertyService() As PropertyService
            Get
                If (BasePojjamanForm.m_propertyService Is Nothing) Then
                    BasePojjamanForm.m_propertyService = CType(ServiceManager.Services.GetService(GetType(PropertyService)), PropertyService)
                End If
                Return BasePojjamanForm.m_propertyService
            End Get
        End Property
        Protected Shared ReadOnly Property ResourceService() As ResourceService
            Get
                If (BasePojjamanForm.m_resourceService Is Nothing) Then
                    BasePojjamanForm.m_resourceService = CType(ServiceManager.Services.GetService(GetType(ResourceService)), ResourceService)
                End If
                Return BasePojjamanForm.m_resourceService
            End Get
        End Property
        Protected Shared ReadOnly Property StringParserService() As StringParserService
            Get
                If (BasePojjamanForm.m_stringParserService Is Nothing) Then
                    BasePojjamanForm.m_stringParserService = CType(ServiceManager.Services.GetService(GetType(StringParserService)), StringParserService)
                End If
                Return BasePojjamanForm.m_stringParserService
            End Get
        End Property
#End Region

#Region "Methods"
        Public Sub SetEnabledStatus(ByVal enabled As Boolean, ByVal ParamArray controlNames As String())
            For Each name As String In controlNames
                Dim myControl As Control = MyBase.ControlDictionary(name)
                If (myControl Is Nothing) Then
                    BasePojjamanForm.MessageService.ShowError((name & " not found!"))
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

