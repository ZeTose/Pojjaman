Imports System.Xml
Imports System.IO
Imports Longkong.Core.Services
Imports Longkong.Core.Properties
Imports System.Collections.Specialized
Namespace Longkong.Pojjaman.Internal.Templates
    Public Class TemplateType

#Region "Members"
        Private m_name As String
        Private m_pairs As Hashtable
#End Region

#Region "Constuctors"
        Public Sub New(ByVal enumType As XmlElement)
            Me.m_pairs = New Hashtable
            Me.m_name = enumType.GetAttribute("name")
            For Each el As XmlElement In enumType.ChildNodes
                Me.m_pairs.Item(el.GetAttribute("name")) = el.GetAttribute("value")
            Next
        End Sub
#End Region

#Region "Properties"
        Public ReadOnly Property Name() As String
            Get
                Return Me.m_name
            End Get
        End Property
        Public ReadOnly Property Pairs() As Hashtable
            Get
                Return Me.m_pairs
            End Get
        End Property
#End Region

    End Class
End Namespace




