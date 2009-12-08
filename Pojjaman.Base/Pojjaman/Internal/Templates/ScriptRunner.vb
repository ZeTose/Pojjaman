Imports System.Xml
Imports System.IO
Imports Longkong.Core.Services
Imports Longkong.Core.Properties
Imports System.Collections.Specialized
Imports System.Text.RegularExpressions
Imports System.Reflection
Imports System.CodeDom.Compiler
Imports System.Text
Imports System.Runtime.InteropServices
Namespace Longkong.Pojjaman.Internal.Templates
    Public Class ScriptRunner

#Region "Members"
        Private m_file As FileDescriptionTemplate
        Private m_item As FileTemplate

        Private Shared ReadOnly m_replaceRegex As New Regex("""")
        Private Shared ReadOnly m_scriptRegex As New Regex("<%.*?%>")
#End Region

#Region "Constructors"
        Public Sub New()
        End Sub
#End Region

#Region "Methods"
        Private Function CompileAndGetOutput(ByVal fileContent As String) As String
            'Dim myTempFileCollection As New TempFileCollection
            'Dim text1 As String = Path.Combine(myTempFileCollection.BasePath, myTempFileCollection.TempDir)
            'Directory.CreateDirectory(text1)
            'Dim text2 As String = Path.Combine(text1, "InternalGeneratedScript.cs")
            'Dim text3 As String = Path.Combine(text1, "A.DLL")
            'myTempFileCollection.AddFile(text2, False)
            'myTempFileCollection.AddFile(text3, False)
            'Dim writer1 As New StreamWriter(text2)
            'writer1.Write(fileContent)
            'writer1.Close()
            'Dim text4 As String = String.Empty
            'Dim text5 As String = String.Empty
            'Dim textArray1 As String() = New String() {Me.GetCompilerName, " /target:library ""/out:", text3, """ """, text2, """"}
            'Executor.ExecWaitWithCapture(String.Concat(textArray1), myTempFileCollection, text4, text5)
            'If Not File.Exists(text3) Then
            '    Dim service1 As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
            '    Dim reader1 As StreamReader = File.OpenText(text4)
            '    Dim text6 As String = reader1.ReadToEnd
            '    reader1.Close()
            '    service1.ShowMessage(text6)
            '    Return (">>>>ERROR IN CODE GENERATION GENERATED SCRIPT WAS:" & ChrW(10) & fileContent & ChrW(10) & ">>>>END")
            'End If
            'Dim assembly1 As [Assembly] = [Assembly].Load(Me.GetBytes(text3))
            'Dim obj1 As Object = assembly1.CreateInstance("Template")
            'Dim service2 As StringParserService = CType(ServiceManager.Services.GetService(GetType(StringParserService)), StringParserService)
            'Dim property1 As TemplateProperty
            'For Each property1 In Me.m_item.Properties
            '    Dim info1 As FieldInfo = obj1.GetType.GetField(property1.Name)
            '    Dim t As Type = CType(IIf(property1.Type.StartsWith("Types:"), GetType(String), Type.GetType(property1.Type)), Type)
            '    Dim value As Object = CType(service2.Properties.Item(("Properties." & property1.Name)), gettype(t))
            '    info1.SetValue(obj1, value)
            'Next
            'Dim info2 As MethodInfo = obj1.GetType.GetMethod("GenerateOutput")
            'Dim text7 As String = info2.Invoke(obj1, Nothing).ToString
            'myTempFileCollection.Delete()
            'Return text7
        End Function
        Public Function CompileScript(ByVal item As FileTemplate, ByVal file As FileDescriptionTemplate) As String
            Dim m As Match = ScriptRunner.m_scriptRegex.Match(file.Content)
            m = m.NextMatch
            If m.Success Then
                Me.m_item = item
                Me.m_file = file
                Return Me.CompileAndGetOutput(Me.GenerateCode)
            End If
            Return file.Content
        End Function
        Private Function GenerateCode() As String
            Dim builder1 As New StringBuilder
            Dim num1 As Integer = 0
            builder1.Append("public class Template {" & ChrW(10))
            Dim property1 As TemplateProperty
            For Each property1 In Me.m_item.Properties
                builder1.Append("public ")
                If property1.Type.StartsWith("Types:") Then
                    builder1.Append("string")
                Else
                    builder1.Append(property1.Type)
                End If
                builder1.Append(" "c)
                builder1.Append(property1.Name)
                builder1.Append(";" & ChrW(10))
            Next
            builder1.Append("public string GenerateOutput() {" & ChrW(10))
            builder1.Append("System.Text.StringBuilder outPut = new System.Text.StringBuilder();" & ChrW(10))
            Dim match1 As Match = ScriptRunner.m_scriptRegex.Match(Me.m_file.Content)
            Do While match1.Success
                Dim group1 As Group = match1.Groups.Item(0)
                builder1.Append("outPut.Append(@""")
                builder1.Append(Me.m_file.Content.Substring(num1, (group1.Index - num1)))
                builder1.Append(""");" & ChrW(10))
                builder1.Append(group1.Value.Substring(2, (group1.Length - 4)))
                num1 = (group1.Index + group1.Length)
                match1 = match1.NextMatch
            Loop
            builder1.Append("outPut.Append(@""")
            Dim text1 As String = ScriptRunner.m_replaceRegex.Replace(Me.m_file.Content.Substring(num1, (Me.m_file.Content.Length - num1)), """""")
            builder1.Append(text1)
            builder1.Append(""");" & ChrW(10))
            builder1.Append("return outPut.ToString();" & ChrW(10))
            builder1.Append("}}" & ChrW(10))
            Return builder1.ToString
        End Function
        Private Function GetBytes(ByVal fileName As String) As Byte()
            Dim buffer2 As Byte()
            Dim stream1 As FileStream = New FileStream(fileName, FileMode.Open)
            Dim num1 As Integer = CInt(stream1.Length)
            Dim buffer1 As Byte() = New Byte(num1 - 1) {}
            stream1.Read(buffer1, 0, CType(num1, Integer))
            stream1.Close()
            buffer2 = buffer1
            Return buffer2
        End Function
        Private Function GetCompilerName() As String
            Dim text1 As String = RuntimeEnvironment.GetRuntimeDirectory
            Return """" & Path.Combine(text1, "csc.exe") & """"
        End Function
#End Region

    End Class
End Namespace




