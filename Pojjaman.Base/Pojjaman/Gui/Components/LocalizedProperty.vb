Imports Longkong.Core.AddIns.Conditions
Imports Longkong.Core.AddIns.Codons
Imports Longkong.Core.Services
Imports Longkong.Pojjaman.Services
Imports System.ComponentModel
Imports Longkong.Pojjaman.Internal.Templates
Imports System.Globalization

Namespace Longkong.Pojjaman.Gui.Components
    Public Class LocalizedProperty
        Inherits PropertyDescriptor

#Region "Members"
        Private m_category As String
        Private m_defaultValue As Object
        Private m_description As String
        Private m_localizedName As String
        Private m_name As String
        Private m_type As String
        Private m_typeConverterObject As TypeConverter

        Private Shared m_stringParserService As StringParserService = CType(ServiceManager.Services.GetService(GetType(StringParserService)), StringParserService)

#End Region

#Region "Construtors"
        Public Sub New(ByVal name As String, ByVal type As String, ByVal category As String, ByVal description As String)
            MyBase.New(name, CType(Nothing, Attribute()))
            Me.m_typeConverterObject = Nothing
            Me.m_defaultValue = Nothing
            Me.m_category = category
            Me.m_description = description
            Me.m_name = name
            Me.m_type = type
        End Sub
#End Region

#Region "Properties"
        Public Property DefaultValue() As Object
            Get
                Return Me.m_defaultValue
            End Get
            Set(ByVal value As Object)
                Me.m_defaultValue = value
            End Set
        End Property
        Public Property LocalizedName() As String
            Get
                If (Me.m_localizedName Is Nothing) Then
                    Return Nothing
                End If
                Return LocalizedProperty.m_stringParserService.Parse(Me.m_localizedName)
            End Get
            Set(ByVal value As String)
                Me.m_localizedName = value
            End Set
        End Property
        Public Property TypeConverterObject() As TypeConverter
            Get
                Return Me.m_typeConverterObject
            End Get
            Set(ByVal value As TypeConverter)
                Me.m_typeConverterObject = value
            End Set
        End Property
#End Region

#Region "Overrides"
        Public Overrides Function CanResetValue(ByVal component As Object) As Boolean
            Return (Not Me.m_defaultValue Is Nothing)
        End Function
        Public Overrides ReadOnly Property ComponentType() As System.Type
            Get
                Return Type.GetType(Me.m_type)
            End Get
        End Property
        Public Overrides Function GetValue(ByVal component As Object) As Object
            Dim text1 As String = LocalizedProperty.m_stringParserService.Properties.Item(("Properties." & Me.Name))
            If TypeOf Me.m_typeConverterObject Is BooleanTypeConverter Then
                Return Boolean.Parse(text1)
            End If
            Return text1
        End Function
        Public Overrides ReadOnly Property IsReadOnly() As Boolean
            Get
                Return False
            End Get
        End Property
        Public Overrides ReadOnly Property PropertyType() As System.Type
            Get
                Return Type.GetType(Me.m_type)
            End Get
        End Property
        Public Overrides Sub ResetValue(ByVal component As Object)
            Me.SetValue(component, Me.m_defaultValue)
        End Sub
        Public Overrides Sub SetValue(ByVal component As Object, ByVal value As Object)
            If (Not Me.m_typeConverterObject Is Nothing) Then
                LocalizedProperty.m_stringParserService.Properties.Item(("Properties." & Me.Name)) = Me.m_typeConverterObject.ConvertFrom(value).ToString
            Else
                LocalizedProperty.m_stringParserService.Properties.Item(("Properties." & Me.Name)) = value.ToString
            End If
        End Sub
        Public Overrides Function ShouldSerializeValue(ByVal component As Object) As Boolean
            Return False
        End Function
        Public Overrides ReadOnly Property Category() As String
            Get
                Return LocalizedProperty.m_stringParserService.Parse(Me.m_category)
            End Get
        End Property
        Public Overrides ReadOnly Property Converter() As System.ComponentModel.TypeConverter
            Get
                If (Not Me.m_typeConverterObject Is Nothing) Then
                    Return Me.m_typeConverterObject
                End If
                Return MyBase.Converter
            End Get
        End Property
        Public Overrides ReadOnly Property Description() As String
            Get
                Return LocalizedProperty.m_stringParserService.Parse(Me.m_description)
            End Get
        End Property
        Public Overrides ReadOnly Property DisplayName() As String
            Get
                If ((Not Me.m_localizedName Is Nothing) AndAlso (Me.m_localizedName.Length > 0)) Then
                    Return Me.LocalizedName
                End If
                Return Me.Name
            End Get
        End Property
#End Region



    End Class
End Namespace

