Imports Longkong.XmlForms
Imports Longkong.Core.Properties
Imports Longkong.Core.Services
Imports Longkong.Pojjaman.Services
Imports System.Reflection
Namespace Longkong.Pojjaman.Gui.XmlForms
    Public Class PojjamanPropertyValueCreator
        Implements IPropertyValueCreator

#Region "Constructors"
        Public Sub New()
        End Sub
#End Region

#Region "IPropertyValueCreator"
        Public Function CanCreateValueForType(ByVal propertyType As System.Type) As Boolean Implements IPropertyValueCreator.CanCreateValueForType
            If (Not propertyType Is GetType(Icon)) Then
                Return (propertyType Is GetType(Image))
            End If
            Return True
        End Function

        Public Function CreateValue(ByVal propertyType As System.Type, ByVal valueString As String) As Object Implements IPropertyValueCreator.CreateValue
            Dim myResourceService As ResourceService = CType(ServiceManager.Services.GetService(GetType(IResourceService)), ResourceService)
            If (propertyType Is GetType(Icon)) Then
                Return myResourceService.GetIcon(valueString)
            End If
            If (propertyType Is GetType(Image)) Then
                Return myResourceService.GetBitmap(valueString)
            End If
            Return Nothing
        End Function
#End Region

    End Class
End Namespace

