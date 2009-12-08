Imports System.Reflection
Imports System.IO
Imports System.Collections.Specialized
Imports Longkong.Core.Services
Imports Longkong.Core.AddIns.Codons
Imports Longkong.Core.AddIns.Conditions
Imports System.Configuration
Namespace Longkong.Core.AddIns
    Public Class AddInTreeSingleton
        Inherits DefaultAddInTree

#Region "Members"
        Private Shared m_addInDirectories As String()
        Private Shared m_addInTree As IAddInTree
        Public Shared ReadOnly m_defaultCoreDirectory As String
        Private Shared m_ignoreDefaultCoreDirectory As Boolean
#End Region

#Region "Constructors"
        Shared Sub New()
            AddInTreeSingleton.m_addInTree = Nothing
            Dim mydirectory As String = ConfigurationSettings.AppSettings.Item("AddInsDirectory")
            If (Not mydirectory Is Nothing AndAlso Not mydirectory.Length = 0) Then
                AddInTreeSingleton.m_defaultCoreDirectory = mydirectory
            Else
                AddInTreeSingleton.m_defaultCoreDirectory = Path.GetDirectoryName([Assembly].GetEntryAssembly.Location) & Path.DirectorySeparatorChar & ".." & Path.DirectorySeparatorChar & "AddIns"
            End If
            AddInTreeSingleton.m_ignoreDefaultCoreDirectory = False
            AddInTreeSingleton.m_addInDirectories = Nothing
        End Sub
#End Region

#Region "Properties"
        Public Shared ReadOnly Property AddInTree() As IAddInTree
            Get
                If (AddInTreeSingleton.m_addInTree Is Nothing) Then
                    AddInTreeSingleton.CreateAddInTree()
                End If
                Return AddInTreeSingleton.m_addInTree
            End Get
        End Property
#End Region

#Region "Methods"
        Private Shared Sub CreateAddInTree()
            AddInTreeSingleton.m_addInTree = New DefaultAddInTree
            Dim myFileUtilityService As FileUtilityService = CType(ServiceManager.Services.GetService(GetType(FileUtilityService)), FileUtilityService)
            Dim addInFiles As StringCollection = Nothing
            Dim retryList As StringCollection = Nothing
            If Not AddInTreeSingleton.m_ignoreDefaultCoreDirectory Then
                addInFiles = myFileUtilityService.SearchDirectory(AddInTreeSingleton.m_defaultCoreDirectory, "*.addin")
                retryList = AddInTreeSingleton.InsertAddIns(addInFiles)
            Else
                retryList = New StringCollection
            End If
            If (Not AddInTreeSingleton.m_addInDirectories Is Nothing) Then
                For Each path As String In AddInTreeSingleton.m_addInDirectories
                    addInFiles = myFileUtilityService.SearchDirectory(path, "*.addin")
                    Dim partialRetryList As StringCollection = AddInTreeSingleton.InsertAddIns(addInFiles)
                    If (partialRetryList.Count <> 0) Then
                        Dim retryListArray As String() = New String(partialRetryList.Count - 1) {}
                        partialRetryList.CopyTo(retryListArray, 0)
                        retryList.AddRange(retryListArray)
                    End If
                Next
            End If
            Do While (retryList.Count > 0)
                Dim newRetryList As StringCollection = AddInTreeSingleton.InsertAddIns(retryList)
                If (newRetryList.Count = retryList.Count) Then
                    Exit Do
                End If
                retryList = newRetryList
            Loop
            If (retryList.Count > 0) Then
                Throw New ApplicationException(("At least one AddIn uses an undefined codon or condition: " & retryList.Item(0)))
            End If
        End Sub
        Private Shared Function InsertAddIns(ByVal addInFiles As StringCollection) As StringCollection
            Dim retryList As New StringCollection
            For Each addInFile As String In addInFiles
                Dim myAddIn As New AddIn
                Try
                    myAddIn.Initialize(addInFile)
                    AddInTreeSingleton.m_addInTree.InsertAddIn(myAddIn)
                Catch ex As CodonNotFoundException
                    retryList.Add(addInFile)
                Catch ex As ConditionNotFoundException
                    retryList.Add(addInFile)
                Catch ex As Exception
                    Throw New AddInInitializeException(addInFile, ex)
                End Try
            Next
            Return retryList
        End Function
        Public Shared Function SetAddInDirectories(ByVal addInDirectories As String(), ByVal ignoreDefaultCoreDirectory As Boolean) As Boolean
            If ((addInDirectories Is Nothing) OrElse (addInDirectories.Length < 1)) Then
                Return False
            End If
            AddInTreeSingleton.m_addInDirectories = addInDirectories
            AddInTreeSingleton.m_ignoreDefaultCoreDirectory = ignoreDefaultCoreDirectory
            Return True
        End Function
#End Region

    End Class
End Namespace
