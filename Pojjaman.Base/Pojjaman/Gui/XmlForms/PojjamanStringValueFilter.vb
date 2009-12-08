Imports Longkong.XmlForms
Imports Longkong.Core.Properties
Imports Longkong.Core.Services
Imports Longkong.Pojjaman.Services
Imports System.Reflection
Namespace Longkong.Pojjaman.Gui.XmlForms
    Public Class PojjamanStringValueFilter
        Implements IStringValueFilter

#Region "Members"
        Private m_propertyService As PropertyService
        Private m_stringParserService As StringParserService
#End Region

#Region "Constructors"
        Public Sub New()
            Me.m_stringParserService = CType(ServiceManager.Services.GetService(GetType(StringParserService)), StringParserService)
            Me.m_propertyService = CType(ServiceManager.Services.GetService(GetType(PropertyService)), PropertyService)
        End Sub
#End Region

#Region "IStringValueFilter"
        Public Function GetFilteredValue(ByVal originalValue As String) As String Implements IStringValueFilter.GetFilteredValue
            Return Me.m_stringParserService.Parse(originalValue)
        End Function
#End Region

    End Class
End Namespace

