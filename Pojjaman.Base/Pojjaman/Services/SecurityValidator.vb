Option Strict Off
Imports System.ComponentModel
Imports System.Windows.Forms
Imports System.Drawing
Imports Longkong.Core.Services
Imports Longkong.Pojjaman.Services
Imports Longkong.Pojjaman.BusinessLogic
Namespace Longkong.Pojjaman.Gui.Components
    <ProvideProperty("FailAction", GetType(Control)), _
    ProvideProperty("AccessId", GetType(control)), _
    ProvideProperty("RequiredLevel", GetType(control))> _
    Public Class SecurityValidator
        Inherits System.ComponentModel.Component
        Implements System.ComponentModel.IExtenderProvider

#Region " Component Designer generated code "

        Public Sub New(ByVal Container As System.ComponentModel.IContainer)
            MyClass.New()

            'Required for Windows.Forms Class Composition Designer support
            Container.Add(Me)
        End Sub

        Public Sub New()
            MyBase.New()

            'This call is required by the Component Designer.
            InitializeComponent()

            'Add any initialization after the InitializeComponent() call

        End Sub

        'Component overrides dispose to clean up the component list.
        Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
            If disposing Then
                If Not (components Is Nothing) Then
                    components.Dispose()
                End If
            End If
            MyBase.Dispose(disposing)
        End Sub

        'Required by the Component Designer
        Private components As System.ComponentModel.IContainer

        'NOTE: The following procedure is required by the Component Designer
        'It can be modified using the Component Designer.
        'Do not modify it using the code editor.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            components = New System.ComponentModel.Container
        End Sub

#End Region

#Region "IExtenderProvider"
        Public Function CanExtend(ByVal extendee As Object) As Boolean _
                  Implements System.ComponentModel.IExtenderProvider.CanExtend
            If TypeOf extendee Is Control Then
                Return True
            Else
                Return False
            End If
        End Function
#End Region

#Region "Member"
        Private m_ErrorProvider As ErrorProvider

        Private m_StringParserService As StringParserService

        Private m_securityService As SecurityService

        ' this hashtable holds property values for individual controls
        Friend htProvidedProperties As New Hashtable

#End Region

#Region "Methods"
        Private Function GetAddControl(ByVal ctrl As Control) As SecurityValidatorProvidedProperties
            If htProvidedProperties.Contains(ctrl) Then
                Return DirectCast(htProvidedProperties(ctrl), SecurityValidatorProvidedProperties)
            Else
                ' add an element to the hashtable
                Dim ProvidedProperties As New SecurityValidatorProvidedProperties

                ProvidedProperties.AccessId = 0
                ProvidedProperties.RequiredLevel = 0
                ProvidedProperties.FailAction = FailAction.None

                htProvidedProperties.Add(ctrl, ProvidedProperties)
                Return ProvidedProperties
            End If
        End Function
#End Region

#Region "Event handlers"
        Sub Process(ByVal ctr As control)
            If htProvidedProperties.Contains(ctr) Then
                Dim props As SecurityValidatorProvidedProperties = CType(htProvidedProperties(ctr), SecurityValidatorProvidedProperties)
                If Not SecurityService Is Nothing Then
                    Dim currentUser As User = SecurityService.CurrentUser
                    If Not currentUser Is Nothing AndAlso currentUser.Originated Then
                        Dim requiredAccess As New Access(props.AccessId)
                        If CInt(props.RequiredLevel) > currentUser.GetAccess(requiredAccess) Then
                            'Apply the Action
                            Select Case props.FailAction
                                Case FailAction.None
                                    'Do nothing
                                Case FailAction.Invisible
                                    'Hide
                                    ctr.Visible = False
                                Case FailAction.ReadOnly
                                    ctr.Enabled = False
                            End Select
                        End If
                    End If
                End If
            End If
        End Sub
#End Region

#Region "Get - Set Property for control"

        Function GetAccessId(ByVal ctrl As Control) As Integer
            If htProvidedProperties.Contains(ctrl) Then
                Return DirectCast(htProvidedProperties(ctrl), _
                       SecurityValidatorProvidedProperties).AccessId
            Else
                Return 0
            End If
        End Function
        Sub SetAccessId(ByVal ctrl As Control, ByVal value As Integer)
            GetAddControl(ctrl).AccessId = value
            Process(ctrl)
        End Sub

        Function GetRequiredLevel(ByVal ctrl As Control) As Integer
            If htProvidedProperties.Contains(ctrl) Then
                Return DirectCast(htProvidedProperties(ctrl), _
                       SecurityValidatorProvidedProperties).RequiredLevel
            Else
                Return 0
            End If
        End Function
        Sub SetRequiredLevel(ByVal ctrl As Control, ByVal value As Integer)
            GetAddControl(ctrl).RequiredLevel = value
            Process(ctrl)
        End Sub

        Function GetFailAction(ByVal ctrl As Control) As FailAction
            If htProvidedProperties.Contains(ctrl) Then
                Return DirectCast(htProvidedProperties(ctrl), _
                       SecurityValidatorProvidedProperties).FailAction
            Else
                Return FailAction.None
            End If
        End Function
        Sub SetFailAction(ByVal ctrl As Control, ByVal value As FailAction)
            GetAddControl(ctrl).FailAction = value
            Process(ctrl)
        End Sub
#End Region

#Region "Properties"
        <Browsable(False)> _
        Public ReadOnly Property StringParserService() As StringParserService
            Get
                If m_StringParserService Is Nothing Then
                    m_StringParserService = CType(ServiceManager.Services.GetService(GetType(StringParserService)), StringParserService)
                End If
                Return m_StringParserService
            End Get
        End Property
        <Browsable(False)> _
        Public ReadOnly Property SecurityService() As SecurityService
            Get
                Try
                    If m_securityService Is Nothing Then
                        m_securityService = CType(ServiceManager.Services.GetService(GetType(SecurityService)), SecurityService)
                    End If
                    Return m_securityService
                Catch ex As Exception
                    Return Nothing
                End Try
            End Get
        End Property
#End Region

        Private Class SecurityValidatorProvidedProperties
            Public FailAction As FailAction
            Public AccessId As Integer
            Public RequiredLevel As Integer
        End Class

    End Class

    Public Enum FailAction
        None
        Invisible
        [ReadOnly]
    End Enum
End Namespace


