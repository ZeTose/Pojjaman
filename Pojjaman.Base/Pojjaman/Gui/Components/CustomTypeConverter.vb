Imports Longkong.Core.AddIns.Conditions
Imports Longkong.Core.AddIns.Codons
Imports Longkong.Core.Services
Imports Longkong.Pojjaman.Services
Imports System.ComponentModel
Imports Longkong.Pojjaman.Internal.Templates
Imports System.Globalization
Namespace Longkong.Pojjaman.Gui.Components
    Public Class CustomTypeConverter
        Inherits TypeConverter

#Region "Members"
        Private m_templateType As TemplateType
#End Region

#Region "Consructors"
        Public Sub New(ByVal templateType As TemplateType)
            Me.m_templateType = templateType
        End Sub
#End Region

#Region "Overrides"
        Public Overloads Overrides Function CanConvertFrom(ByVal context As ITypeDescriptorContext, ByVal sourceType As Type) As Boolean
            Return (sourceType Is GetType(String))
        End Function
        Public Overloads Overrides Function CanConvertTo(ByVal context As ITypeDescriptorContext, ByVal destinationType As Type) As Boolean
            Return (destinationType Is GetType(String))
        End Function
        Public Overloads Overrides Function ConvertFrom(ByVal context As ITypeDescriptorContext, ByVal culture As CultureInfo, ByVal value As Object) As Object
            If (Not Me.m_templateType.Pairs(value) Is Nothing) Then
                Return Me.m_templateType.Pairs(value)
            End If
            Return value.ToString
        End Function
        Public Overloads Overrides Function ConvertTo(ByVal context As ITypeDescriptorContext, ByVal culture As CultureInfo, ByVal value As Object, ByVal destinationType As Type) As Object
            For Each entry As DictionaryEntry In Me.m_templateType.Pairs
                If (entry.Value.ToString Is value.ToString) Then
                    Return entry.Key
                End If
            Next
            Return value.ToString
        End Function
        Public Overloads Overrides Function GetStandardValues(ByVal context As ITypeDescriptorContext) As StandardValuesCollection
            Dim standardValues As New ArrayList
            For Each entry As DictionaryEntry In Me.m_templateType.Pairs
                standardValues.Add(entry.Key)
            Next
            Return New StandardValuesCollection(standardValues)
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

