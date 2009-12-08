Imports Longkong.Core.Properties
Imports System.Windows.Forms
Imports Longkong.Core.Services
Imports System.Xml
Imports System.IO
Namespace Longkong.Pojjaman.Services
    Public Class FormPath

#Region "Members"
        Private m_name As String
        Private m_path As String
#End Region

#Region "Constructors"
        Public Sub New(ByVal name As String, ByVal path As String)
            If path Is Nothing Then
                path = ""
            End If
            Me.m_name = name
            If Not File.Exists(path) Then
                Dim properties As PropertyService = CType(ServiceManager.Services.GetService(GetType(PropertyService)), PropertyService)
                If Not path.ToLower.StartsWith(properties.DataDirectory.ToLower) Then
                    Me.m_path = properties.DataDirectory & path
                End If
                If Not File.Exists(Me.m_path) Then
                    Me.m_path = path
                End If
            Else
                Me.m_path = path
            End If
        End Sub
#End Region

#Region "Properties"
        Public Property Name() As String            Get                Return m_name            End Get            Set(ByVal Value As String)                m_name = Value            End Set        End Property        Public Property Path() As String            Get                Return m_path            End Get            Set(ByVal Value As String)                m_path = Value            End Set        End Property
#End Region

#Region "Overides"
        Public Overrides Function ToString() As String
            Return Me.Name
        End Function
#End Region

    End Class
    Public Class FormPaths
        Implements IXmlConvertable

#Region "Members"
        Private m_lastFormPath As ArrayList
        Private MAX_LENGTH As Integer
        Private m_currentFormPath As FormPath
        Private m_classname As String
#End Region

#Region "Events"
        Public Event FormPathsChanged As EventHandler
#End Region

#Region "Constructors"
        Public Sub New(ByVal classname As String, ByVal name As String, ByVal path As String)
            m_classname = classname
            m_lastFormPath = New ArrayList
            m_currentFormPath = New FormPath(name, path)
            m_lastFormPath.Add(m_currentFormPath)
        End Sub
        Public Sub New()
            Me.MAX_LENGTH = 10 'ได้ 10 บริษัท
            Me.m_lastFormPath = New ArrayList
        End Sub
        Public Sub New(ByVal element As XmlElement)
            Me.new()
            Me.m_classname = element.Name
            Dim nodes As XmlNodeList = element.Item("FORMPATHS").ChildNodes
            For Each el As XmlElement In element.Item("FORMPATHS").ChildNodes
                If el.Name = "FORMPATH" Then
                    Dim name As String = el.Attributes.ItemOf("name").InnerText
                    Dim path As String = el.Attributes.ItemOf("path").InnerText
                    Dim fp As New FormPath(name, path)
                    Me.m_lastFormPath.Add(fp)
                End If
            Next
        End Sub
#End Region

#Region "Properties"
        Public Property ClassName() As String
            Get
                Return Me.m_classname
            End Get
            Set(ByVal Value As String)
                m_classname = Value
            End Set
        End Property
        Public ReadOnly Property FormPaths() As ArrayList
            Get
                Return Me.m_lastFormPath
            End Get
        End Property
        Public ReadOnly Property CurrentFormPath() As FormPath
            Get
                Return m_currentFormPath
            End Get
        End Property
#End Region

#Region "Methods"
        Public Sub ChangeCurrentFormPath(ByVal name As String)
            Dim formpathToSet As FormPath
            For Each fp As FormPath In Me.m_lastFormPath
                If fp.Name = name Then
                    formpathToSet = fp
                    Exit For
                End If
            Next
            If Not formpathToSet Is Nothing Then
                Me.m_lastFormPath.Remove(formpathToSet)
                If (Me.m_lastFormPath.Count > 0) Then
                    Me.m_lastFormPath.Insert(0, formpathToSet)
                Else
                    Me.m_lastFormPath.Add(formpathToSet)
                End If
                m_currentFormPath = formpathToSet
                Me.OnFormPathsChange()
            End If
        End Sub
        Public Sub AddFormPath(ByVal name As String, ByVal path As String)
            Dim formpathToAdd As New FormPath(name, path)
            For Each fp As FormPath In Me.m_lastFormPath
                If fp.Name = formpathToAdd.Name Then
                    Return
                End If
            Next
            If (Me.m_lastFormPath.Count > 0) Then
                Me.m_lastFormPath.Insert(0, formpathToAdd)
            Else
                Me.m_lastFormPath.Add(formpathToAdd)
            End If
            Me.OnFormPathsChange()
        End Sub
        Public Sub ClearFormPaths()
            Me.m_lastFormPath.Clear()
            Me.OnFormPathsChange()
        End Sub
        Private Sub OnFormPathsChange()
            RaiseEvent FormPathsChanged(Me, Nothing)
        End Sub
#End Region

#Region "IXmlConvertable"
        Public Function FromXmlElement(ByVal element As System.Xml.XmlElement) As Object Implements IXmlConvertable.FromXmlElement
            Return New FormPaths(element)
        End Function
        Public Function ToXmlElement(ByVal doc As System.Xml.XmlDocument) As System.Xml.XmlElement Implements IXmlConvertable.ToXmlElement
            If m_classname Is Nothing Then Return Nothing

            Dim rootEl As XmlElement = doc.CreateElement(m_classname)
            Dim formpathEl As XmlElement = doc.CreateElement("FORMPATHS")
            For Each fp As FormPath In Me.m_lastFormPath
                Dim coEl As XmlElement = doc.CreateElement("FORMPATH")
                Dim name As XmlAttribute = doc.CreateAttribute("name")
                name.InnerText = fp.Name
                coEl.Attributes.Append(name)
                Dim path As XmlAttribute = doc.CreateAttribute("path")
                path.InnerText = fp.Path
                coEl.Attributes.Append(path)
                formpathEl.AppendChild(coEl)
            Next
            rootEl.AppendChild(formpathEl)
            Return rootEl
        End Function
#End Region

    End Class


    Public Class CreditTexts
        Implements IXmlConvertable

#Region "Members"
        Private MAX_LENGTH As Integer
        Private m_creditTexts As ArrayList
#End Region

#Region "Events"
        Public Event CreditTextChanged As EventHandler
#End Region

#Region "Constructors"
        Public Sub New()
            m_creditTexts = New ArrayList
            Me.MAX_LENGTH = 10 'ได้ 10 บริษัท
        End Sub
        Public Sub New(ByVal element As XmlElement)
            Me.new()
            Dim nodes As XmlNodeList = element.ChildNodes
            For Each el As XmlElement In nodes
                If el.Name = "CREDITTEXT" Then
                    Dim value As String = el.Attributes.ItemOf("value").InnerText
                    Me.m_creditTexts.Add(value)
                End If
            Next
        End Sub
#End Region

#Region "Properties"
        Public ReadOnly Property CreditTexts() As ArrayList
            Get
                Return Me.m_creditTexts
            End Get
        End Property
#End Region

#Region "Methods"
        Public Sub AddCreditText(ByVal value As String)
            For Each fp As String In Me.m_creditTexts
                If fp = value Then
                    Return
                End If
            Next
            Me.m_creditTexts.Add(value)
            Me.OnCreditTextChange()
        End Sub
        Public Sub ClearCreditText()
            Me.m_creditTexts.Clear()
            Me.OnCreditTextChange()
        End Sub
        Private Sub OnCreditTextChange()
            RaiseEvent CreditTextChanged(Me, Nothing)
        End Sub
#End Region

#Region "IXmlConvertable"
        Public Function FromXmlElement(ByVal element As System.Xml.XmlElement) As Object Implements IXmlConvertable.FromXmlElement
            Return New CreditTexts(element)
        End Function
        Public Function ToXmlElement(ByVal doc As System.Xml.XmlDocument) As System.Xml.XmlElement Implements IXmlConvertable.ToXmlElement
            Dim rootEl As XmlElement = doc.CreateElement("CREDITTEXTS")
            For Each fp As String In Me.m_creditTexts
                Dim coEl As XmlElement = doc.CreateElement("CREDITTEXT")
                Dim value As XmlAttribute = doc.CreateAttribute("value")
                value.InnerText = fp
                coEl.Attributes.Append(value)
                rootEl.AppendChild(coEl)
            Next
            Return rootEl
        End Function
#End Region

    End Class
End Namespace



