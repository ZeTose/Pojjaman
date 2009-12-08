Imports Longkong.Core.Services
Imports Longkong.Core.AddIns.Codons
Imports Longkong.Core.AddIns.Conditions
Imports System.Reflection
Imports System.IO
Namespace Longkong.Core.AddIns
    Public Class DefaultAddInTree
        Implements IAddInTree

#Region "Members"
        Private m_addIns As AddInCollection
        Private m_codonFactory As CodonFactory
        Private m_conditionFactory As ConditionFactory
        Private m_registeredAssemblies As Hashtable
        Private m_root As DefaultAddInTreeNode
#End Region

#Region "Constructors"
        Friend Sub New()
            Me.m_addIns = New AddInCollection
            Me.m_root = New DefaultAddInTreeNode
            Me.m_conditionFactory = New ConditionFactory
            Me.m_codonFactory = New CodonFactory
            Me.m_registeredAssemblies = New Hashtable
            Me.LoadCodonsAndConditions([Assembly].GetExecutingAssembly)
        End Sub
#End Region

#Region "Methods"
        Private Sub AddExtensions(ByVal extension As AddIn.Extension)
            Dim localRoot As DefaultAddInTreeNode = Me.CreatePath(Me.m_root, extension.Path)
            For Each codon As ICodon In extension.CodonCollection
                Dim localPath As DefaultAddInTreeNode = Me.CreatePath(localRoot, codon.ID)
                If (Not localPath.Codon Is Nothing) Then
                    Throw New DuplicateCodonException(codon.ID)
                End If
                localPath.Codon = codon
                localPath.ConditionCollection = CType(extension.Conditions.Item(codon.ID), ConditionCollection)
            Next
        End Sub
        Private Function CreatePath(ByVal localRoot As DefaultAddInTreeNode, ByVal path As String) As DefaultAddInTreeNode
            If ((path Is Nothing) OrElse (path.Length = 0)) Then
                Return localRoot
            End If
            Dim splittedPath As String() = path.Split(New Char() {"/"c})
            Dim curPath As DefaultAddInTreeNode = localRoot
            For i As Integer = 0 To splittedPath.Length - 1
                Dim nextPath As DefaultAddInTreeNode = CType(curPath.ChildNodes.Item(splittedPath(i)), DefaultAddInTreeNode)
                If (nextPath Is Nothing) Then
                    nextPath = New DefaultAddInTreeNode
                    curPath.ChildNodes.Item(splittedPath(i)) = nextPath
                End If
                curPath = nextPath
            Next
            Return curPath
        End Function
        Private Sub LoadCodonsAndConditions(ByVal [assembly] As [Assembly])
            Try
                Dim resourceService As IResourceService = CType(ServiceManager.Services.GetService(GetType(IResourceService)), IResourceService)
                resourceService.RegisterAssembly([assembly])
                For Each myType As Type In [assembly].GetTypes
                    Try
                        If Not myType.IsAbstract Then
                            If (myType.IsSubclassOf(GetType(AbstractCodon)) AndAlso (Not Attribute.GetCustomAttribute(myType, GetType(CodonNameAttribute)) Is Nothing)) Then
                                Me.CodonFactory.AddCodonBuilder(New CodonBuilder(myType.FullName, [assembly]))
                            Else
                                If (myType.IsSubclassOf(GetType(AbstractCondition)) AndAlso (Not Attribute.GetCustomAttribute(myType, GetType(ConditionAttribute)) Is Nothing)) Then
                                    Me.ConditionFactory.Builders.Add(New ConditionBuilder(myType.FullName, [assembly]))
                                End If
                            End If
                        End If
                    Catch ex As Exception
                        System.Windows.Forms.MessageBox.Show(ex.ToString & ":" & myType.FullName)
                    End Try
                Next
            Catch ex As ReflectionTypeLoadException
                For Each childEx As Exception In ex.LoaderExceptions
                    System.Windows.Forms.MessageBox.Show(childEx.ToString)
                Next
            Catch ex As Exception
                System.Windows.Forms.MessageBox.Show(ex.ToString & ":" & [assembly].FullName)
            End Try

        End Sub
        Public Sub ShowCodonTree()
            Me.ShowCodonTree(Me.m_root, "")
        End Sub
        Private Sub ShowCodonTree(ByVal node As IAddInTreeNode, ByVal ident As String)
            For Each entry As DictionaryEntry In node.ChildNodes
                Me.ShowCodonTree(CType(entry.Value, IAddInTreeNode), (ident & ChrW(9)))
            Next
        End Sub
#End Region

#Region "IAddInTree"
        Public ReadOnly Property AddIns() As AddInCollection Implements IAddInTree.AddIns
            Get
                Return Me.m_addIns
            End Get
        End Property
        Public ReadOnly Property CodonFactory() As Codons.CodonFactory Implements IAddInTree.CodonFactory
            Get
                Return Me.m_codonFactory
            End Get
        End Property
        Public ReadOnly Property ConditionFactory() As Conditions.ConditionFactory Implements IAddInTree.ConditionFactory
            Get
                Return Me.m_conditionFactory
            End Get
        End Property
        Public Function GetTreeNode(ByVal path As String) As IAddInTreeNode Implements IAddInTree.GetTreeNode
            If ((path Is Nothing) OrElse (path.Length = 0)) Then
                Return Me.m_root
            End If
            Dim splittedPath As String() = path.Split(New Char() {"/"c})
            Dim curPath As DefaultAddInTreeNode = Me.m_root
            Dim i As Integer = 0
            For i = 0 To splittedPath.Length - 1
                Dim nextPath As DefaultAddInTreeNode = CType(curPath.ChildNodes.Item(splittedPath(i)), DefaultAddInTreeNode)
                If (nextPath Is Nothing) Then
                    Throw New TreePathNotFoundException(path)
                End If
                curPath = nextPath
            Next
            Return curPath
        End Function
        Public Sub InsertAddIn(ByVal addIn As AddIn) Implements IAddInTree.InsertAddIn
            Me.AddIns.Add(addIn)
            For Each myExtension As addIn.Extension In addIn.Extensions
                Me.AddExtensions(myExtension)
            Next
        End Sub
        Public Function LoadAssembly(ByVal fileName As String) As System.Reflection.Assembly Implements IAddInTree.LoadAssembly
            Dim fileExists As Boolean = False
            If File.Exists(fileName) Then
                fileExists = True
                fileName = Path.GetFullPath(fileName)
            End If
            Dim myAssembly As [Assembly] = CType(Me.m_registeredAssemblies(fileName), [Assembly])
            If (myAssembly Is Nothing) Then
                Dim asm As [Assembly] = Nothing
                If fileExists Then
                    asm = [Assembly].LoadFrom(fileName)
                End If
                If (asm Is Nothing) Then
                    asm = [Assembly].Load(fileName)
                End If
                If (asm Is Nothing) Then
                    asm = [Assembly].LoadWithPartialName(fileName)
                End If
                myAssembly = asm
                Me.m_registeredAssemblies.Item(fileName) = myAssembly
                Me.LoadCodonsAndConditions(myAssembly)
            End If
            Return myAssembly
        End Function
        Public Sub RemoveAddIn(ByVal addIn As AddIn) Implements IAddInTree.RemoveAddIn
            Throw New ApplicationException("Implement ME!")
        End Sub
#End Region

    End Class
End Namespace
