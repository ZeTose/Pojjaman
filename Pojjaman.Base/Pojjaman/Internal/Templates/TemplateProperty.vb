Imports System.Xml
Imports System.IO
Imports Longkong.Core.Services
Imports Longkong.Core.Properties
Imports System.Collections.Specialized
Namespace Longkong.Pojjaman.Internal.Templates
    Public Class TemplateProperty

#Region "Members"
        Private m_category As String
        Private m_defaultValue As String
        Private m_description As String
        Private m_localizedName As String
        Private m_name As String
        Private m_type As String
#End Region

#Region "Constructors"
        Public Sub New(ByVal propertyElement As XmlElement)
            Me.m_name = propertyElement.GetAttribute("name")
            Me.m_localizedName = propertyElement.GetAttribute("localizedName")
            Me.m_type = propertyElement.GetAttribute("type")
            Me.m_category = propertyElement.GetAttribute("category")
            Me.m_description = propertyElement.GetAttribute("description")
            Me.m_defaultValue = propertyElement.GetAttribute("defaultValue")
        End Sub
#End Region

#Region "Properties"
        Public ReadOnly Property Category() As String
            Get
                Return Me.m_category
            End Get
        End Property
        Public ReadOnly Property DefaultValue() As String
            Get
                Return Me.m_defaultValue
            End Get
        End Property
        Public ReadOnly Property Description() As String
            Get
                Return Me.m_description
            End Get
        End Property
        Public ReadOnly Property LocalizedName() As String
            Get
                Return Me.m_localizedName
            End Get
        End Property
        Public ReadOnly Property Name() As String
            Get
                Return Me.m_name
            End Get
        End Property
        Public ReadOnly Property Type() As String
            Get
                Return Me.m_type
            End Get
        End Property
#End Region

    End Class
End Namespace




