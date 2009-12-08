Imports System.Windows.Forms
Imports System.ComponentModel
Imports System.Collections.Specialized
Namespace Longkong.Core.Properties
    Public Class PropertyDictionary
        Inherits DictionaryBase

#Region "Members"
        Private m_readOnlyProperties As StringCollection
#End Region

#Region "Constructors"
        Public Sub New()
            Me.m_readOnlyProperties = New StringCollection
        End Sub
#End Region

#Region "Properties"
        Default Public Property Item(ByVal name As String) As String
            Get
                Return CType(MyBase.Dictionary.Item(name.ToUpper), String)
            End Get
            Set(ByVal value As String)
                MyBase.Dictionary.Item(name.ToUpper) = value
            End Set
        End Property
#End Region

#Region "Methods"
        Public Sub Add(ByVal name As String, ByVal value As String)
            If Not Me.m_readOnlyProperties.Contains(name) Then
                MyBase.Dictionary.Add(name, value)
            End If
        End Sub
        Public Sub AddReadOnly(ByVal name As String, ByVal value As String)
            If Not Me.m_readOnlyProperties.Contains(name) Then
                Me.m_readOnlyProperties.Add(name)
                MyBase.Dictionary.Add(name, value)
            End If
        End Sub
        Protected Overrides Sub OnClear()
            Me.m_readOnlyProperties.Clear()
        End Sub
#End Region

    End Class
End Namespace
