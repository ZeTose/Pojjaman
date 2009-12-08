Imports System.Windows.Forms
Imports System.ComponentModel.Design
Imports Longkong.Core.Services
Imports Longkong.Core.Properties
Imports System.Drawing
Imports System.ComponentModel
Imports Longkong.Pojjaman.Services
Namespace Longkong.Pojjaman.Gui.Pads
    Public Class IDEContainer
        Inherits Container

#Region "Members"
        Private m_serviceProvider As IServiceProvider
#End Region

#Region "Costructors"
        Public Sub New(ByVal sp As IServiceProvider)
            Me.m_serviceProvider = sp
        End Sub
#End Region

#Region "Methods"
        Public Overloads Function CreateSite(ByVal component As IComponent) As ISite
            Return Me.CreateSite(component, "UNKNOWN_SITE")
        End Function
        Protected Overloads Overrides Function CreateSite(ByVal component As IComponent, ByVal name As String) As ISite
            Dim site1 As ISite = MyBase.CreateSite(component, name)
            Return New IDESite(component, Me, name)
        End Function
        Protected Overrides Function GetService(ByVal serviceType As Type) As Object
            Dim obj1 As Object = MyBase.GetService(serviceType)
            If (obj1 Is Nothing) Then
                obj1 = Me.m_serviceProvider.GetService(serviceType)
            End If
            Return obj1
        End Function
#End Region

        Private Class IDESite
            Implements ISite, IServiceProvider

#Region "Members"
            Private m_component As IComponent
            Private m_container As IDEContainer
            Private m_name As String
#End Region

#Region "Constructors"
            Public Sub New(ByVal sitedComponent As IComponent, ByVal site As IDEContainer, ByVal aName As String)
                Me.m_component = sitedComponent
                Me.m_container = site
                Me.m_name = aName
            End Sub
#End Region

#Region "ISite"
            Public ReadOnly Property Component() As System.ComponentModel.IComponent Implements System.ComponentModel.ISite.Component
                Get
                    Return Me.m_component
                End Get
            End Property

            Public ReadOnly Property Container() As System.ComponentModel.IContainer Implements System.ComponentModel.ISite.Container
                Get
                    Return Me.m_container
                End Get
            End Property

            Public ReadOnly Property DesignMode() As Boolean Implements System.ComponentModel.ISite.DesignMode
                Get
                    Return False
                End Get
            End Property

            Public Property Name() As String Implements System.ComponentModel.ISite.Name
                Get
                    Return Me.m_name
                End Get
                Set(ByVal value As String)
                    Me.m_name = value
                End Set
            End Property
#End Region

#Region "IServiceProvider"
            Public Function GetService(ByVal serviceType As System.Type) As Object Implements System.IServiceProvider.GetService
                Return Me.m_container.GetService(serviceType)
            End Function
#End Region

        End Class

    End Class
End Namespace

