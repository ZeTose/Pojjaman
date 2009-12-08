Imports Longkong.Pojjaman.Internal.Project.Collections
Imports System.Xml.Xsl
Imports System.Xml
Imports System.Xml.XPath
Imports System.IO
Imports System.Text
Namespace Longkong.Pojjaman.Internal.Project
    Public Class ConvertXml

#Region "Constructors"
        Public Sub New()
        End Sub
#End Region

#Region "Methods"
        Public Shared Sub [Convert](ByVal inputFile As String, ByVal xslPath As String, ByVal outputFile As String)
            ConvertXml.Convert(inputFile, xslPath, outputFile, CType(Nothing, XsltArgumentList))
        End Sub
        Public Shared Sub [Convert](ByVal inputFile As String, ByVal xslPath As String, ByVal outputFile As String, ByVal xsltArgList As XsltArgumentList)
            Dim reader1 As XmlReader = ConvertXml.GetXML(inputFile)
            Dim reader2 As XmlReader = ConvertXml.TransformXmlToXml(reader1, xslPath, xsltArgList)
            reader1.Close()
            Dim document1 As New XmlDocument
            document1.Load(reader2)
            document1.Save(outputFile)
        End Sub
        Public Shared Sub [Convert](ByVal inputFile As String, ByVal xslReader As XmlReader, ByVal outputFile As String, ByVal xsltArgList As XsltArgumentList)
            Dim reader1 As XmlReader = ConvertXml.GetXML(inputFile)
            Dim reader2 As XmlReader = ConvertXml.TransformXmlToXml(reader1, xslReader, xsltArgList)
            reader1.Close()
            Dim document1 As New XmlDocument
            document1.Load(reader2)
            document1.Save(outputFile)
        End Sub
        Public Shared Sub [Convert](ByVal inputFile As String, ByVal xslReader As XmlReader, ByVal outputFile As String, ByVal xsltArgList As XsltArgumentList, ByVal encoding As Encoding)
            Dim stream1 As FileStream = New FileStream(inputFile, FileMode.Open, FileAccess.Read)
            Dim reader1 As StreamReader = New StreamReader(stream1, encoding)
            Dim reader2 As New XmlTextReader(inputFile, reader1)
            Dim reader3 As XmlReader = ConvertXml.TransformXmlToXml(reader2, xslReader, xsltArgList)
            Dim document1 As New XmlDocument
            document1.Load(reader3)
            document1.Save(outputFile)
        End Sub
        Public Shared Function ConvertData(ByVal inputXml As String, ByVal xslPath As String, ByVal xsltArgList As XsltArgumentList) As String
            Dim reader1 As New XmlTextReader(New StringReader(inputXml))
            Dim reader2 As XmlReader = ConvertXml.TransformXmlToXml(reader1, xslPath, xsltArgList)
            reader1.Close()
            Dim document1 As New XmlDocument
            document1.Load(reader2)
            Dim writer1 As New StringWriter
            document1.Save(writer1)
            Return writer1.ToString
        End Function
        Public Shared Function ConvertData(ByVal inputXml As String, ByVal xslReader As XmlReader, ByVal xsltArgList As XsltArgumentList) As String
            Dim reader1 As New XmlTextReader(New StringReader(inputXml))
            Dim reader2 As XmlReader = ConvertXml.TransformXmlToXml(reader1, xslReader, xsltArgList)
            reader1.Close()
            Dim document1 As New XmlDocument
            document1.Load(reader2)
            Dim writer1 As New StringWriter
            document1.Save(writer1)
            Return writer1.ToString
        End Function
        Public Shared Function ConvertToString(ByVal inputFile As String, ByVal xslPath As String) As String
            Return ConvertXml.ConvertToString(inputFile, xslPath, Nothing)
        End Function
        Public Shared Function ConvertToString(ByVal inputFile As String, ByVal xslPath As String, ByVal xsltArgList As XsltArgumentList) As String
            Dim reader1 As XmlReader = ConvertXml.GetXML(inputFile)
            Dim reader2 As XmlReader = ConvertXml.TransformXmlToXml(reader1, xslPath, xsltArgList)
            reader1.Close()
            Dim document1 As New XmlDocument
            document1.Load(reader2)
            Dim writer1 As New StringWriter
            document1.Save(writer1)
            Return writer1.ToString
        End Function
        Public Shared Function GetXML(ByVal strInput As String) As XmlReader
            If (strInput.Length = 0) Then
                Return New XmlTextReader("")
            End If
            If (strInput.Substring(0, 1) Is "<") Then
                Return New XmlTextReader(New StringReader(strInput))
            End If
            Return New XmlTextReader(strInput)
        End Function
        Public Shared Function TransformXmlToXml(ByVal oXML As XmlReader, ByVal XSLPath As String, ByVal xsltArgList As XsltArgumentList) As XmlReader
            Dim transform1 As New XslTransform
            transform1.Load(XSLPath)
            Dim document1 As New XPathDocument(oXML)
            Return transform1.Transform(document1, xsltArgList, New XmlUrlResolver)
        End Function
        Public Shared Function TransformXmlToXml(ByVal oXML As XmlReader, ByVal XSLReader As XmlReader, ByVal xsltArgList As XsltArgumentList) As XmlReader
            Dim transform1 As New XslTransform
            transform1.Load(XSLReader, New XmlUrlResolver, GetType(ConvertXml).Assembly.Evidence)
            Dim document1 As New XPathDocument(oXML)
            Return transform1.Transform(document1, xsltArgList, New XmlUrlResolver)
        End Function
#End Region

    End Class
End Namespace




