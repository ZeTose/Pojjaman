Imports Longkong.Core.Properties
Imports System.Text.RegularExpressions
Imports Longkong.Core.Services
Namespace Longkong.Core.Services
    Public Class StringParserService
        Inherits AbstractService
#Region "Members"
        Private Shared ReadOnly m_pattern As Regex
        Private m_properties As PropertyDictionary
        Private m_stringTagProviders As Hashtable
#End Region

#Region "Constructors"
        Shared Sub New()
            StringParserService.m_pattern = New Regex("\$\{([^\}]*)\}")
        End Sub
        Public Sub New()
            Me.m_properties = New PropertyDictionary
            Me.m_stringTagProviders = New Hashtable
            Dim dictionary1 As IDictionary = Environment.GetEnvironmentVariables
            Dim text1 As String
            For Each text1 In dictionary1.Keys
                Me.Properties.Add(("env:" & text1), CType(dictionary1.Item(text1), String))
            Next
        End Sub
#End Region

#Region "Properties"
        Public ReadOnly Property Properties() As PropertyDictionary
            Get
                Return Me.m_properties
            End Get
        End Property
#End Region

#Region "Methods"
        Public Function Parse(ByVal input As String) As String
            Return Me.Parse(input, Nothing)
        End Function
        Public Sub Parse(ByRef inputs As String())
            Dim num1 As Integer = inputs.GetLowerBound(0)
            Do While (num1 <= inputs.GetUpperBound(0))
                inputs(num1) = Me.Parse(inputs(num1), Nothing)
                num1 += 1
            Loop
        End Sub

        Public Function Parse(ByVal input As String, ByVal customTags(,) As String) As String
            Dim output As String = input
            If Not (input Is Nothing) Then
                For Each m As Match In m_pattern.Matches(input)
                    If m.Length > 0 Then
                        Dim token As String = m.ToString
                        Dim propertyName As String = m.Groups(1).Captures(0).Value
                        Dim propertyValue As String = Nothing
                        Select Case propertyName.ToUpper
                            Case "USER"
                                propertyValue = Environment.UserName
                            Case "DATE"
                                propertyValue = DateTime.Today.ToShortDateString
                            Case "TIME"
                                propertyValue = DateTime.Now.ToShortTimeString
                            Case Else
                                propertyValue = Nothing
                                If Not (customTags Is Nothing) Then
                                    For j As Integer = 0 To customTags.GetLength(0) - 1
                                        If propertyName.ToUpper = customTags(j, 0).ToUpper Then
                                            propertyValue = customTags(j, 1)
                                            Exit For
                                        End If
                                    Next
                                End If
                                If propertyValue Is Nothing Then
                                    propertyValue = Properties(propertyName.ToUpper)
                                End If
                                If propertyValue Is Nothing Then
                                    Dim stringTagProvider As IStringTagProvider = CType(m_stringTagProviders(propertyName.ToUpper()), IStringTagProvider)
                                    If Not (stringTagProvider Is Nothing) Then
                                        propertyValue = stringTagProvider.Convert(propertyName.ToUpper)
                                    End If
                                End If
                                If propertyValue Is Nothing Then
                                    Dim k As Integer = propertyName.IndexOf(":"c)
                                    If k > 0 Then
                                        Select Case propertyName.Substring(0, k).ToUpper
                                            Case "RES"
                                                Dim resourceService As IResourceService = CType(ServiceManager.Services.GetService(GetType(IResourceService)), IResourceService)
                                                If Not (resourceService Is Nothing) Then
                                                    Try
                                                        propertyValue = Parse(resourceService.GetString(propertyName.Substring(k + 1)), customTags)
                                                    Catch ex As Exception
                                                        propertyValue = Nothing
                                                    End Try
                                                End If
                                            Case "PROPERTY"
                                                Dim propertyService As propertyService = CType(ServiceManager.Services.GetService(GetType(propertyService)), propertyService)
                                                propertyValue = propertyService.GetProperty(propertyName.Substring(k + 1)).ToString
                                        End Select
                                    End If
                                End If
                        End Select
                        If Not (propertyValue Is Nothing) Then
                            output = output.Replace(token, propertyValue)
                        End If
                    End If
                Next
            End If
            Return output
        End Function
#End Region

    End Class
End Namespace

