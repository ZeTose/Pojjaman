Imports System.Xml

Namespace Longkong.Core.Properties
    Public Class DefaultProperties
        Implements IProperties

#Region "Members"
        Private m_properties As Hashtable
        Private m_PropertyChanged As PropertyEventHandler
#End Region

#Region "Constructors"
        Public Sub New()
            Me.m_properties = New Hashtable
        End Sub
#End Region

#Region "Methods"
        Protected Sub SetValueFromXmlElement(ByVal element As XmlElement)
            For Each el As XmlElement In element.ChildNodes
                If (el.Name = "Property") Then
                    Me.m_properties.Item(el.Attributes.ItemOf("key").InnerText) = el.Attributes.ItemOf("value").InnerText
                ElseIf (el.Name = "XmlConvertableProperty") Then
                    Me.m_properties.Item(el.Attributes.ItemOf("key").InnerText) = el
                Else
                    Throw New UnknownPropertyNodeException(el.Name)
                End If
            Next
        End Sub
        Protected Overridable Sub OnPropertyChanged(ByVal e As PropertyEventArgs)
            RaiseEvent PropertyChanged(Me, e)
        End Sub
#End Region

#Region "IProperties"
        Public Function FromXmlElement(ByVal element As System.Xml.XmlElement) As Object Implements IXmlConvertable.FromXmlElement
            Dim myDefaultProperties As New DefaultProperties
            myDefaultProperties.SetValueFromXmlElement(element)
            Return myDefaultProperties
        End Function

        Public Function ToXmlElement(ByVal doc As System.Xml.XmlDocument) As System.Xml.XmlElement Implements IXmlConvertable.ToXmlElement 'Todo Goto
            Dim propertiesnode As XmlElement = doc.CreateElement("Properties")
            For Each entry As DictionaryEntry In Me.m_properties
                If Not (entry.Value Is Nothing) Then
                    If TypeOf entry.Value Is XmlElement Then
                        propertiesnode.AppendChild(doc.ImportNode(CType(entry.Value, XmlElement), True))
                    ElseIf TypeOf entry.Value Is IXmlConvertable Then
                        Dim el As XmlElement = doc.CreateElement("XmlConvertableProperty")
                        Dim key As XmlAttribute = doc.CreateAttribute("key")
                        key.InnerText = entry.Key.ToString
                        el.Attributes.Append(key)
                        el.AppendChild(CType(entry.Value, IXmlConvertable).ToXmlElement(doc))
                        propertiesnode.AppendChild(el)
                    Else
                        Dim el As XmlElement = doc.CreateElement("Property")
                        Dim key As XmlAttribute = doc.CreateAttribute("key")
                        key.InnerText = entry.Key.ToString
                        el.Attributes.Append(key)
                        Dim val As XmlAttribute = doc.CreateAttribute("value")
                        val.InnerText = entry.Value.ToString
                        el.Attributes.Append(val)
                        propertiesnode.AppendChild(el)
                    End If
                End If
            Next
            Return propertiesnode
        End Function

        Public Function Clone() As IProperties Implements IProperties.Clone
            Dim myDefaultProperties As New DefaultProperties
            myDefaultProperties.m_properties = CType(Me.m_properties.Clone, Hashtable)
            Return myDefaultProperties
        End Function

        Public Overloads Function GetProperty(ByVal key As String) As Object Implements IProperties.GetProperty
            Return Me.GetProperty(key, New Object)
        End Function

        Public Overloads Function GetProperty(ByVal key As String, ByVal defaultvalue As Boolean) As Boolean Implements IProperties.GetProperty
            Return Boolean.Parse(Me.GetProperty(key, CType(defaultvalue, Object)).ToString)
        End Function

        Public Overloads Function GetProperty(ByVal key As String, ByVal defaultvalue As Byte) As Byte Implements IProperties.GetProperty
            Return Byte.Parse(Me.GetProperty(key, CType(defaultvalue, Object)).ToString)
        End Function

        Public Overloads Function GetProperty(ByVal key As String, ByVal defaultvalue As Integer) As Integer Implements IProperties.GetProperty
            Return Integer.Parse(Me.GetProperty(key, CType(defaultvalue, Object)).ToString)
        End Function

        Public Overloads Function GetProperty(ByVal key As String, ByVal defaultvalue As Short) As Short Implements IProperties.GetProperty
            Return Short.Parse(Me.GetProperty(key, CType(defaultvalue, Object)).ToString)
        End Function

        Public Overloads Function GetProperty(ByVal key As String, ByVal defaultvalue As String) As String Implements IProperties.GetProperty
            Return Me.GetProperty(key, CType(defaultvalue, Object)).ToString
        End Function

        Public Overloads Function GetProperty(ByVal key As String, ByVal defaultvalue As System.Enum) As System.Enum Implements IProperties.GetProperty
            Return CType([Enum].Parse(defaultvalue.GetType, Me.GetProperty(key, CType(defaultvalue, Object)).ToString), [Enum])
        End Function

        Public Overloads Function GetProperty(ByVal key As String, ByVal defaultvalue As Object) As Object Implements IProperties.GetProperty
            If Not Me.m_properties.ContainsKey(key) Then
                If (Not defaultvalue Is Nothing) Then
                    Me.m_properties.Item(key) = defaultvalue
                End If
                Return defaultvalue
            End If
            Dim obj As Object = Me.m_properties.Item(key)
            If (TypeOf defaultvalue Is IXmlConvertable AndAlso TypeOf obj Is XmlElement) Then
                obj = CType(defaultvalue, IXmlConvertable).FromXmlElement(CType(CType(obj, XmlElement).FirstChild, XmlElement))
                Me.m_properties.Item(key) = obj
            End If
            Return obj
        End Function

        Public Event PropertyChanged(ByVal sender As Object, ByVal e As PropertyEventArgs) Implements IProperties.PropertyChanged

        Public Sub SetProperty(ByVal key As String, ByVal val As Object) Implements IProperties.SetProperty
            Dim obj As Object = Me.m_properties.Item(key)
            If Not val.Equals(obj) Then
                Me.m_properties.Item(key) = val
                Me.OnPropertyChanged(New PropertyEventArgs(Me, key, obj, val))
            End If
        End Sub
#End Region

    End Class
End Namespace

