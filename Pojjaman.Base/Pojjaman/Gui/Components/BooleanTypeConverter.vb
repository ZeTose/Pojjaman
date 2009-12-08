Imports Longkong.Core.AddIns.Conditions
Imports Longkong.Core.AddIns.Codons
Imports Longkong.Core.Services
Imports Longkong.Pojjaman.Services
Imports System.ComponentModel
Imports Longkong.Pojjaman.Internal.Templates
Imports System.Globalization

Namespace Longkong.Pojjaman.Gui.Components
    Public Class BooleanTypeConverter
        Inherits TypeConverter

#Region "Constructors"
        Public Sub New()
        End Sub
#End Region

#Region "Properties"
        Private ReadOnly Property [True]() As String
            Get
                Dim myStringParserService As StringParserService = CType(ServiceManager.Services.GetService(GetType(StringParserService)), StringParserService)
                Return myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Components.BooleanTypeConverter.TrueString}")
            End Get
        End Property
        Private ReadOnly Property [False]() As String
            Get
                Dim myStringParserService As StringParserService = CType(ServiceManager.Services.GetService(GetType(StringParserService)), StringParserService)
                Return myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Components.BooleanTypeConverter.FalseString}")
            End Get
        End Property
#End Region

#Region "Overrides"
        Public Overloads Overrides Function CanConvertFrom(ByVal context As ITypeDescriptorContext, ByVal sourceType As Type) As Boolean
            If (Not sourceType Is GetType(Boolean)) Then
                Return (sourceType Is GetType(String))
            End If
            Return True
        End Function
        Public Overloads Overrides Function CanConvertTo(ByVal context As ITypeDescriptorContext, ByVal destinationType As Type) As Boolean
            If (Not destinationType Is GetType(Boolean)) Then
                Return (destinationType Is GetType(String))
            End If
            Return True
        End Function
        Public Overloads Overrides Function ConvertFrom(ByVal context As ITypeDescriptorContext, ByVal culture As CultureInfo, ByVal value As Object) As Object
            If TypeOf value Is String Then
                Return (value.ToString = Me.True)
            End If
            Return value
        End Function
        Public Overloads Overrides Function ConvertTo(ByVal context As ITypeDescriptorContext, ByVal culture As CultureInfo, ByVal value As Object, ByVal destinationType As Type) As Object
            If Not TypeOf value Is Boolean Then
                Return value
            End If
            If Not CType(value, Boolean) Then
                Return Me.False
            End If
            Return Me.True
        End Function
        Public Overloads Overrides Function GetStandardValues(ByVal context As ITypeDescriptorContext) As StandardValuesCollection
            Dim objArray1 As Object() = New Object() {Me.True, Me.False}
            Return New StandardValuesCollection(objArray1)
        End Function
        Public Overloads Overrides Function GetStandardValuesExclusive(ByVal context As ITypeDescriptorContext) As Boolean
            Return True
        End Function
        Public Overloads Overrides Function GetStandardValuesSupported(ByVal context As ITypeDescriptorContext) As Boolean
            Return True
        End Function
#End Region

    End Class
End Namespace

