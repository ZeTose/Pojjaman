Imports System
Imports System.Diagnostics
Imports System.Collections
Imports System.Collections.Specialized
Imports System.IO
Imports System.Reflection
Imports System.Resources
Imports System.Xml
Imports System.Xml.Schema
Imports System.Text

Imports System.Windows.Forms
Imports Longkong.Core.Services
Imports Longkong.Core.AddIns.Conditions
Imports Longkong.Core.AddIns.Codons
Namespace Longkong.Core.AddIns
    Public Class AddIn

#Region "Members"
        Private m_author As String
        Private m_copyright As String
        Private m_description As String
        Private m_errors As ArrayList
        Private m_extensions As ArrayList
        Private m_fileName As String
        Private m_fileUtilityService As FileUtilityService
        Private m_name As String
        Private m_runtimeLibraries As Hashtable
        Private m_url As String
        Private m_version As String
#End Region

#Region "Constructors"
        Public Sub New()
            Me.m_name = Nothing
            Me.m_author = Nothing
            Me.m_copyright = Nothing
            Me.m_url = Nothing
            Me.m_description = Nothing
            Me.m_version = Nothing
            Me.m_fileName = Nothing
            Me.m_runtimeLibraries = New Hashtable
            Me.m_extensions = New ArrayList
            Me.m_fileUtilityService = CType(ServiceManager.Services.GetService(GetType(FileUtilityService)), FileUtilityService)
            Me.m_errors = Nothing
        End Sub
#End Region

#Region "Properties"
        Public ReadOnly Property Author() As String
            Get
                Return Me.m_author
            End Get
        End Property
        Public ReadOnly Property Copyright() As String
            Get
                Return Me.m_copyright
            End Get
        End Property
        Public ReadOnly Property Description() As String
            Get
                Return Me.m_description
            End Get
        End Property
        Public ReadOnly Property Extensions() As ArrayList
            Get
                Return Me.m_extensions
            End Get
        End Property
        Public ReadOnly Property FileName() As String
            Get
                Return Me.m_fileName
            End Get
        End Property
        Public ReadOnly Property Name() As String
            Get
                Return Me.m_name
            End Get
        End Property
        Public ReadOnly Property RuntimeLibraries() As Hashtable
            Get
                Return Me.m_runtimeLibraries
            End Get
        End Property
        Public ReadOnly Property Url() As String
            Get
                Return Me.m_url
            End Get
        End Property
        Public ReadOnly Property Version() As String
            Get
                Return Me.m_version
            End Get
        End Property
#End Region

#Region "Methods"
        Sub AddCodonsToExtension(ByVal e As Extension, ByVal el As XmlElement, ByVal conditions As ConditionCollection) 'TODO: Revise the GOTO
            For Each o As Object In el.ChildNodes
                If TypeOf o Is XmlElement Then
                    Dim curEl As XmlElement = CType(o, XmlElement)
                    Select Case curEl.Name
                        Case "And", "Or", "Not", "Condition"
                            'Just ignore
                        Case "Conditional"
                            Dim condition As ICondition = Nothing
                            If ((curEl.Attributes.Count = 0) OrElse ((curEl.Attributes.Count = 1) AndAlso (Not curEl.Attributes.ItemOf("action") Is Nothing))) Then
                                condition = Me.BuildComplexCondition(curEl)
                                If (Not curEl.Attributes.ItemOf("action") Is Nothing) Then
                                    condition.Action = CType([Enum].Parse(GetType(ConditionFailedAction), curEl.Attributes.ItemOf("action").InnerText), ConditionFailedAction)
                                End If
                                If (condition Is Nothing) Then
                                    Throw New AddInTreeFormatException("empty conditional, no condition definition found.")
                                End If
                            Else
                                condition = AddInTreeSingleton.AddInTree.ConditionFactory.CreateCondition(Me, curEl)
                                Me.AutoInitializeAttributes(condition, curEl)
                            End If
                            conditions.Add(condition)
                            Me.AddCodonsToExtension(e, curEl, conditions)
                            conditions.RemoveAt((conditions.Count - 1))
                        Case Else
                            Dim codon As ICodon = AddInTreeSingleton.AddInTree.CodonFactory.CreateCodon(Me, curEl)
                            Me.AutoInitializeAttributes(codon, curEl)
                            e.Conditions.Item(codon.ID) = New ConditionCollection(conditions)
                            If (((codon.InsertAfter Is Nothing) AndAlso (codon.InsertBefore Is Nothing)) AndAlso (e.CodonCollection.Count > 0)) Then
                                codon.InsertAfter = New String() {CType(e.CodonCollection.Item((e.CodonCollection.Count - 1)), ICodon).ID}
                            End If
                            e.CodonCollection.Add(codon)
                            If (curEl.ChildNodes.Count > 0) Then
                                Dim newExtension As New Extension((e.Path & "/"c & codon.ID))
                                Me.AddCodonsToExtension(newExtension, curEl, conditions)
                                Me.m_extensions.Add(newExtension)
                            End If
                    End Select
                End If
            Next
        End Sub
        Private Sub AddExtensions(ByVal el As XmlElement)
            If (el.Attributes.ItemOf("path") Is Nothing) Then
                Throw New AddInLoadException("One extension node has no path attribute defined.")
            End If
            Dim e As New Extension(el.Attributes.ItemOf("path").InnerText)
            Me.AddCodonsToExtension(e, el, New ConditionCollection)
            Me.m_extensions.Add(e)
        End Sub
        Private Sub AddRuntimeLibraries(ByVal myPath As String, ByVal el As XmlElement)
            For Each o As Object In el.ChildNodes
                If TypeOf o Is XmlElement Then
                    Dim curEl As XmlElement = CType(o, XmlElement)
                    If (curEl.Attributes.ItemOf("assembly") Is Nothing) Then
                        Throw New AddInLoadException("One import node has no assembly attribute defined.")
                    End If
                    Dim assemblyName As String = curEl.Attributes.ItemOf("assembly").InnerText
                    Dim pathName As String = CStr(IIf(System.IO.Path.IsPathRooted(assemblyName), assemblyName, (Me.m_fileUtilityService.GetDirectoryNameWithSeparator(myPath) & assemblyName)))
                    Dim asm As [Assembly] = AddInTreeSingleton.AddInTree.LoadAssembly(pathName)
                    Me.m_runtimeLibraries(assemblyName) = asm
                End If
            Next
        End Sub
        Private Sub AutoInitializeAttributes(ByVal customizer As Object, ByVal codonNode As XmlNode)
            Dim currentType As Type = customizer.GetType
            Do While (Not currentType Is GetType(Object))
                Dim fieldInfoArray As FieldInfo() = currentType.GetFields((BindingFlags.NonPublic Or BindingFlags.Instance))
                For Each myFieldInfo As FieldInfo In fieldInfoArray
                    Dim codonAttribute As XmlMemberAttributeAttribute = CType(Attribute.GetCustomAttribute(myFieldInfo, GetType(XmlMemberAttributeAttribute)), XmlMemberAttributeAttribute)
                    If (Not codonAttribute Is Nothing) Then
                        Dim node As XmlNode = codonNode.SelectSingleNode(("@" & codonAttribute.Name))
                        If ((node Is Nothing) AndAlso codonAttribute.IsRequired) Then
                            Throw New AddInLoadException(String.Format("{0} is a required attribute for node '{1}' ", codonAttribute.Name, codonNode.Name))
                        End If
                        If (Not node Is Nothing) Then
                            If myFieldInfo.FieldType.IsSubclassOf(GetType([Enum])) Then
                                myFieldInfo.SetValue(customizer, Convert.ChangeType([Enum].Parse(myFieldInfo.FieldType, node.Value), myFieldInfo.FieldType))
                            Else
                                Dim myPathAttribute As PathAttribute = CType(Attribute.GetCustomAttribute(myFieldInfo, GetType(PathAttribute)), PathAttribute)
                                If (Not myPathAttribute Is Nothing) Then
                                    myFieldInfo.SetValue(customizer, (Me.m_fileUtilityService.GetDirectoryNameWithSeparator(Path.GetDirectoryName(Me.m_fileName)) & Convert.ChangeType(node.Value, myFieldInfo.FieldType).ToString))
                                Else
                                    myFieldInfo.SetValue(customizer, Convert.ChangeType(node.Value, myFieldInfo.FieldType))
                                End If
                            End If
                        End If
                    End If
                    Dim codonArrayAttribute As XmlMemberArrayAttribute = CType(Attribute.GetCustomAttribute(myFieldInfo, GetType(XmlMemberArrayAttribute)), XmlMemberArrayAttribute)
                    If (Not codonArrayAttribute Is Nothing) Then
                        Dim node As XmlNode = codonNode.SelectSingleNode(("@" & codonArrayAttribute.Name))
                        If ((node Is Nothing) AndAlso codonArrayAttribute.IsRequired) Then
                            Throw New ApplicationException(String.Format("{0} is a required attribute.", codonArrayAttribute.Name))
                        End If
                        If (Not node Is Nothing) Then
                            Dim attrArray As String() = node.Value.Split(codonArrayAttribute.Separator)
                            myFieldInfo.SetValue(customizer, attrArray)
                        End If
                    End If
                Next
                currentType = currentType.BaseType
            Loop
        End Sub
        Private Function BuildComplexCondition(ByVal el As XmlElement) As ICondition
            If (Not el.Item("Or") Is Nothing) Then
                Return Me.GetCondition(el.Item("Or"))
            End If
            If (Not el.Item("And") Is Nothing) Then
                Return Me.GetCondition(el.Item("And"))
            End If
            If (Not el.Item("Not") Is Nothing) Then
                Return Me.GetCondition(el.Item("Not"))
            End If
            If (Not el.Item("Condition") Is Nothing) Then
                Return Me.GetCondition(el.Item("Condition"))
            End If
            Return Nothing
        End Function
        Public Function CreateObject(ByVal className As String) As Object
            Dim newInstance As Object
            For Each library As DictionaryEntry In Me.m_runtimeLibraries
                Dim asm As [Assembly] = CType(library.Value, [Assembly])
                Dim mytypes As Type() = asm.GetTypes
                Try
                    newInstance = CType(library.Value, [Assembly]).CreateInstance(className)
                Catch ex As Exception
                    MessageBox.Show(ex.Message & ":" & className)
                End Try
                If (Not newInstance Is Nothing) Then
                    Return newInstance
                End If
            Next
            newInstance = [Assembly].GetExecutingAssembly.CreateInstance(className)
            If (newInstance Is Nothing) Then
                For Each asm As [Assembly] In Me.m_runtimeLibraries.Values
                    newInstance = asm.CreateInstance(className)
                    If (Not newInstance Is Nothing) Then
                        Exit For
                    End If
                Next
                If (newInstance Is Nothing) Then
                    newInstance = [Assembly].GetCallingAssembly.CreateInstance(className)
                End If
            End If
            If (newInstance Is Nothing) Then
                'MessageBox.Show(("Type not found: " & className & ". Please check : " & Me.m_fileName), "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1)
            End If
            Return newInstance
        End Function
        Public Function CreateObject(ByVal className As String, ByVal ParamArray args() As Object) As Object
            Dim newInstance As Object
            For Each library As DictionaryEntry In Me.m_runtimeLibraries
                Dim asm As [Assembly] = CType(library.Value, [Assembly])
                Dim mytypes As Type() = asm.GetTypes
                Try
                    newInstance = CType(library.Value, [Assembly]).CreateInstance(className, True, BindingFlags.CreateInstance, Nothing, args, Nothing, Nothing)
                Catch ex As Exception
                    MessageBox.Show(ex.Message & ":" & className)
                End Try
                If (Not newInstance Is Nothing) Then
                    Return newInstance
                End If
            Next
            newInstance = [Assembly].GetExecutingAssembly.CreateInstance(className, True, BindingFlags.CreateInstance, Nothing, args, Nothing, Nothing)
            If (newInstance Is Nothing) Then
                For Each asm As [Assembly] In Me.m_runtimeLibraries.Values
                    Try
                        newInstance = asm.CreateInstance(className, True, BindingFlags.CreateInstance, Nothing, args, Nothing, Nothing)

                    Catch ex As Exception
                        MessageBox.Show(asm.FullName)
                    End Try
                    If (Not newInstance Is Nothing) Then
                        Exit For
                    End If
                Next
                If (newInstance Is Nothing) Then
                    newInstance = [Assembly].GetCallingAssembly.CreateInstance(className, True, BindingFlags.CreateInstance, Nothing, args, Nothing, Nothing)
                End If
            End If
            If (newInstance Is Nothing) Then
                'MessageBox.Show(("Type not found: " & className & ". Please check : " & Me.m_fileName), "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1)
            End If
            Return newInstance
        End Function
        Private Function GetCondition(ByVal el As XmlElement) As ICondition
            Dim conditions As New ConditionCollection
            For Each child As XmlElement In el.ChildNodes
                conditions.Add(Me.GetCondition(child))
            Next
            Select Case el.Name
                Case "Condition"
                    If (conditions.Count > 0) Then
                        Throw New AddInTreeFormatException("Condition node childs found. (doesn't make sense)")
                    End If
                    Dim c As ICondition = AddInTreeSingleton.AddInTree.ConditionFactory.CreateCondition(Me, el)
                    Me.AutoInitializeAttributes(c, el)
                    Return c
                Case "And"
                    If (conditions.Count <= 1) Then
                        Throw New AddInTreeFormatException("And node with none or only one child found.")
                    End If
                    Return New AndCondition(conditions)
                Case "Or"
                    If (conditions.Count <= 1) Then
                        Throw New AddInTreeFormatException("Or node with none or only one child found.")
                    End If
                    Return New OrCondition(conditions)
                Case "Not"
                    If (conditions.Count > 1) Then
                        Throw New AddInTreeFormatException("Not node with more than one child found")
                    End If
                    If (conditions.Count = 0) Then
                        Throw New AddInTreeFormatException("Not node without child found.")
                    End If
                    Return New NegatedCondition(conditions)
            End Select
            Throw New AddInTreeFormatException(("node " & el.Name & " not valid in expression."))
        End Function
        Public Sub Initialize(ByVal fileName As String) 'Todo :Goto
            Me.m_fileName = fileName
            Dim doc As New XmlDocument
            doc.Load(New XmlTextReader(fileName))
            If (Not Me.m_errors Is Nothing) Then
                Me.ReportErrors(fileName)
                Me.m_errors = Nothing
            Else
                Try
                    Me.m_name = doc.DocumentElement.Attributes.ItemOf("name").InnerText
                    Me.m_author = doc.DocumentElement.Attributes.ItemOf("author").InnerText
                    Me.m_copyright = doc.DocumentElement.Attributes.ItemOf("copyright").InnerText
                    Me.m_url = doc.DocumentElement.Attributes.ItemOf("url").InnerText
                    Me.m_description = doc.DocumentElement.Attributes.ItemOf("description").InnerText
                    Me.m_version = doc.DocumentElement.Attributes.ItemOf("version").InnerText
                Catch ex As Exception
                    Throw New AddInLoadException("No or malformed 'AddIn' node")
                End Try
                For Each o As Object In doc.DocumentElement.ChildNodes
                    If TypeOf o Is XmlElement Then
                        Dim curEl As XmlElement = CType(o, XmlElement)
                        Select Case curEl.Name
                            Case "Runtime"
                                AddRuntimeLibraries(Path.GetDirectoryName(fileName), curEl)
                            Case "Extension"
                                AddExtensions(curEl)
                        End Select
                    End If
                Next
            End If
        End Sub
        Private Sub ReportErrors(ByVal fileName As String)
            Dim msg As New StringBuilder
            msg.Append(("Could not load addin definition file" & ChrW(10) & " " & fileName & ChrW(10) & ". Reason:" & ChrW(10) & ChrW(10)))
            For Each args As ValidationEventArgs In Me.m_errors
                msg.Append(args.Message)
                msg.Append(Console.Out.NewLine)
            Next
            MessageBox.Show(msg.ToString, "Pojjaman", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End Sub
        Private Sub ValidationHandler(ByVal sender As Object, ByVal args As ValidationEventArgs)
            If (Me.m_errors Is Nothing) Then
                Me.m_errors = New ArrayList
            End If
            Me.m_errors.Add(args)
        End Sub
#End Region

#Region "Extension Class"
        Public Class Extension

#Region "Members"
            Private m_codonCollection As ArrayList
            Private m_conditions As Hashtable
            Private m_path As String
#End Region

#Region "Constructors"
            Public Sub New(ByVal path As String)
                Me.m_codonCollection = New ArrayList
                Me.m_conditions = New Hashtable
                Me.m_path = path
            End Sub
#End Region

#Region "Properties"
            Public Property CodonCollection() As ArrayList
                Get
                    Return Me.m_codonCollection
                End Get
                Set(ByVal value As ArrayList)
                    Me.m_codonCollection = value
                End Set
            End Property
            Public ReadOnly Property Conditions() As Hashtable
                Get
                    Return Me.m_conditions
                End Get
            End Property
            Public Property Path() As String
                Get
                    Return Me.m_path
                End Get
                Set(ByVal value As String)
                    Me.m_path = value
                End Set
            End Property
#End Region

#Region "Methods"
            Public Overrides Function ToString() As String
                Return "[Extension: Path = " & Me.m_path & ", codonCollection.Count = " & Me.m_codonCollection.Count & "]"
            End Function
#End Region

        End Class
#End Region

    End Class
End Namespace
