Imports Longkong.XmlForms
Imports Longkong.Core.Properties
Imports Longkong.Core.Services
Imports Longkong.Pojjaman.Services
Imports System.Reflection
Namespace Longkong.Pojjaman.Gui.XmlForms
    Public Class PojjamanObjectCreator
        Inherits DefaultObjectCreator

#Region "Members"
        Private Shared m_propertyService As PropertyService = CType(ServiceManager.Services.GetService(GetType(PropertyService)), PropertyService)
#End Region

#Region "Constructors"
        Public Sub New()
        End Sub
#End Region

#Region "Methods"
        Public Overrides Function CreateObject(ByVal name As String) As Object
            Dim obj As Object = MyBase.CreateObject(name)
            If (Not obj Is Nothing) Then
                Try
                    Dim info As PropertyInfo = obj.GetType.GetProperty("FlatStyle")
                    If (info Is Nothing) Then
                        Return obj
                    End If
                    If TypeOf obj Is Label Then
                        info.SetValue(obj, FlatStyle.Standard, Nothing)
                        Return obj
                    End If
                    info.SetValue(obj, FlatStyle.System, Nothing)
                Catch ex As Exception
                End Try
            End If
            Return obj
        End Function
#End Region

    End Class
End Namespace

