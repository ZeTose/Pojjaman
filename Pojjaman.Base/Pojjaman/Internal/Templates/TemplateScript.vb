Imports System.Xml
Imports System.IO
Imports Longkong.Core.Services
Imports Longkong.Core.Properties
Imports System.Collections.Specialized
Namespace Longkong.Pojjaman.Internal.Templates
    Public Class TemplateScript

#Region "Members"
        Private m_languageName As String
        Private m_runAt As String
        Private m_scriptSourceCode As String
#End Region

#Region "Constructors"
        Public Sub New(ByVal scriptConfig As XmlElement)
            Me.m_languageName = scriptConfig.GetAttribute("language")
            Me.m_runAt = scriptConfig.GetAttribute("runAt")
            Me.m_scriptSourceCode = scriptConfig.InnerText
        End Sub
#End Region

#Region "Properties"
        Public ReadOnly Property LanguageName() As String
            Get
                Return Me.m_languageName
            End Get
        End Property
        Public ReadOnly Property RunAt() As String
            Get
                Return Me.m_runAt
            End Get
        End Property
        Private ReadOnly Property SourceText() As String
            Get
                Return ("public class ScriptObject : System.MarshalByRefObject { " & Me.m_scriptSourceCode & "}")
            End Get
        End Property
#End Region

    End Class
End Namespace




