Imports Longkong.Pojjaman.DataAccessLayer
Imports Longkong.Pojjaman.BusinessLogic
Imports System.Data.SqlClient
Imports System.IO
Imports System.Configuration
Imports Longkong.Core.Services
Namespace Longkong.Pojjaman.BusinessLogic
    Public Class CodeDescriptionService
        Implements IService, ICodeDescriptions

#Region "Members"
        Private m_CodeDescriptions As Hashtable
        Private m_CodeDescriptionChanged As CodeDescriptionsEventHandler
#End Region

#Region "Constructors"
        Public Sub New()
            Try
                Me.LoadProperties()
            Catch ex As Exception
                MessageBox.Show("Can't load property file", "Warning")
            End Try
        End Sub
#End Region

#Region "Methods"
        Private Sub LoadProperties()
            'If Not Directory.Exists(PropertyService.m_configDirectory) Then
            '    Directory.CreateDirectory(PropertyService.m_configDirectory)
            'End If
            'If Not Me.LoadPropertiesFromStream((PropertyService.m_configDirectory & PropertyService.m_propertyFileName)) Then
            '    If Not Me.LoadPropertiesFromStream(Me.DataDirectory & Path.DirectorySeparatorChar & "options" & Path.DirectorySeparatorChar & PropertyService.m_propertyFileName) Then
            '        Throw New PropertyFileLoadException
            '    End If
            'End If
        End Sub
#End Region

#Region "IService"
        Public Event Initialize(ByVal sender As Object, ByVal e As System.EventArgs) Implements Core.Services.IService.Initialize
        Public Event Unload(ByVal sender As Object, ByVal e As System.EventArgs) Implements Core.Services.IService.Unload

        Public Sub InitializeService() Implements Core.Services.IService.InitializeService
            Me.OnInitialize(EventArgs.Empty)
        End Sub
        Public Sub UnloadService() Implements Core.Services.IService.UnloadService
            Me.SaveCodeDescriptions()
            Me.OnUnload(EventArgs.Empty)
        End Sub
        Protected Overridable Sub OnInitialize(ByVal e As EventArgs)
            RaiseEvent Initialize(Me, e)
        End Sub
        Protected Overridable Sub OnUnload(ByVal e As EventArgs)
            RaiseEvent Unload(Me, e)
        End Sub
        Private Sub SaveCodeDescriptions()
            'Todo: Me.WritePropertiesToFile((PropertyService.m_configDirectory & PropertyService.m_propertyFileName))
        End Sub
#End Region

#Region "ICodeDescriptions"
        Public Overloads Function GetValue(ByVal key As String) As Object Implements ICodeDescriptions.GetValue
            Return Me.GetValue(key, New Object)
        End Function
        Public Overloads Function GetValue(ByVal key As String, ByVal defaultvalue As Boolean) As Boolean Implements ICodeDescriptions.GetValue
            Return Boolean.Parse(Me.GetValue(key, CType(defaultvalue, Object)).ToString)
        End Function
        Public Overloads Function GetValue(ByVal key As String, ByVal defaultvalue As Byte) As Byte Implements ICodeDescriptions.GetValue
            Return Byte.Parse(Me.GetValue(key, CType(defaultvalue, Object)).ToString)
        End Function
        Public Overloads Function GetValue(ByVal key As String, ByVal defaultvalue As Integer) As Integer Implements ICodeDescriptions.GetValue
            Return Integer.Parse(Me.GetValue(key, CType(defaultvalue, Object)).ToString)
        End Function
        Public Overloads Function GetValue(ByVal key As String, ByVal defaultvalue As Short) As Short Implements ICodeDescriptions.GetValue
            Return Short.Parse(Me.GetValue(key, CType(defaultvalue, Object)).ToString)
        End Function
        Public Overloads Function GetValue(ByVal key As String, ByVal defaultvalue As String) As String Implements ICodeDescriptions.GetValue
            Return Me.GetValue(key, CType(defaultvalue, Object)).ToString
        End Function
        Public Overloads Function GetValue(ByVal key As String, ByVal defaultvalue As System.Enum) As System.Enum Implements ICodeDescriptions.GetValue
            Return CType([Enum].Parse(defaultvalue.GetType, Me.GetValue(key, CType(defaultvalue, Object)).ToString), [Enum])
        End Function
        Public Overloads Function GetValue(ByVal key As String, ByVal defaultvalue As Object) As Object Implements ICodeDescriptions.GetValue
            If Not Me.m_CodeDescriptions.ContainsKey(key) Then
                If (Not defaultvalue Is Nothing) Then
                    Me.m_CodeDescriptions.Item(key) = defaultvalue
                End If
                Return defaultvalue
            End If
            Dim obj As Object = Me.m_CodeDescriptions(key)
            'If (TypeOf defaultvalue Is IXmlConvertable AndAlso TypeOf obj Is XmlElement) Then
            '    obj = CType(defaultvalue, IXmlConvertable).FromXmlElement(CType(CType(obj, XmlElement).FirstChild, XmlElement))
            '    Me.m_CodeDescriptions(key) = obj
            'End If
            Return obj
        End Function
        Public Sub SetCodeDescription(ByVal key As String, ByVal val As Object) Implements ICodeDescriptions.SetCodeDescription

        End Sub
#End Region

    End Class
End Namespace
