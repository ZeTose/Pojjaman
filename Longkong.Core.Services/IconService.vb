Imports System
Imports System.IO
Imports System.Windows.Forms
Imports System.Collections
Imports System.Threading
Imports System.Resources
Imports System.Drawing
Imports System.Diagnostics
Imports System.Reflection
Imports System.Xml
Imports System.Configuration
Imports System.Globalization
Imports Longkong.Core.Properties
Imports Longkong.Core.AddIns.Codons
Imports Longkong.Core.AddIns

Namespace Longkong.Core.Services
    Public Class IconService
        Inherits AbstractService

#Region "Members"
        Private m_customIcons As Hashtable
        Private m_extensionHashtable As Hashtable
        Private m_imagelist As imagelist
        Private m_initalsize As Integer
        Private m_projectFileHashtable As Hashtable
        Private Shared ReadOnly m_separators As Char()
        Private m_formTypeHashtble As Hashtable
#End Region

#Region "Constructors"
        Shared Sub New()
            IconService.m_separators = New Char() {Path.DirectorySeparatorChar, Path.VolumeSeparatorChar}
        End Sub
        Public Sub New()
            Me.m_extensionHashtable = New Hashtable
            Me.m_projectFileHashtable = New Hashtable
            Me.m_formTypeHashtble = New Hashtable
            Me.m_customIcons = New Hashtable
            Me.m_initalsize = 0
            Me.m_imagelist = New ImageList
            Me.m_imagelist.ColorDepth = ColorDepth.Depth32Bit
        End Sub
#End Region

#Region "Properties"
        Public ReadOnly Property ImageList() As ImageList
            Get
                Dim myList As ImageList
                SyncLock Me.m_imagelist
                    myList = Me.m_imagelist
                End SyncLock
                Return myList
            End Get
        End Property
#End Region

#Region "Methods"
        Public Function GetBitmap(ByVal name As String) As Bitmap
            If (Not Me.m_customIcons(name) Is Nothing) Then
                Return CType(Me.m_customIcons.Item(name), Bitmap)
            End If
            Dim myResourceService As ResourceService = CType(ServiceManager.Services.GetService(GetType(IResourceService)), ResourceService)
            If (Not myResourceService.GetBitmap(name) Is Nothing) Then
                Return myResourceService.GetBitmap(name)
            End If
            Return myResourceService.GetBitmap("Icons.16x16.MiscFiles")
        End Function
        Public Function GetIcon(ByVal name As String) As Icon
            Return Icon.FromHandle(Me.GetBitmap(name).GetHicon)
        End Function
        Public Function GetImageForFile(ByVal fileName As String) As Image
            Dim img As Image
            SyncLock Me.m_imagelist
                Dim indx As Integer = Me.GetImageIndexForFile(fileName)
                If (indx >= 0) Then
                    Return Me.m_imagelist.Images(indx)
                End If
                img = Nothing
            End SyncLock
            Return img
        End Function
        Public Function GetImageForProjectType(ByVal projectType As String) As Image
            SyncLock Me.m_imagelist
                Dim indx As Integer = Me.GetImageIndexForProjectType(projectType)
                If (indx >= 0) Then
                    Return Me.m_imagelist.Images(indx)
                End If
            End SyncLock
            Return Nothing
        End Function
        Public Function GetImageForFormType(ByVal formType As String) As Image
            SyncLock Me.m_imagelist
                Dim indx As Integer = Me.GetImageIndexForFormType(formType)
                If (indx >= 0) Then
                    Return Me.m_imagelist.Images(indx)
                End If
            End SyncLock
            Return Nothing
        End Function
        Public Function GetImageIndexForFile(ByVal fileName As String) As Integer
            Dim indx As Integer
            SyncLock Me.m_imagelist
                Dim ext As String = Path.GetExtension(fileName).ToUpper
                If (Not Me.m_extensionHashtable(ext) Is Nothing) Then
                    Return CType(Me.m_extensionHashtable(ext), Integer)
                End If
                indx = Me.m_initalsize
            End SyncLock
            Return indx
        End Function
        Public Function GetImageIndexForProjectType(ByVal projectType As String) As Integer
            Dim indx As Integer
            SyncLock Me.m_imagelist
                If (Not Me.m_projectFileHashtable(projectType) Is Nothing) Then
                    Return CType(Me.m_projectFileHashtable(projectType), Integer)
                End If
                indx = CType(Me.m_extensionHashtable(".PRJX"), Integer)
            End SyncLock
            Return indx
        End Function
        Public Function GetImageIndexForFormType(ByVal formType As String) As Integer
            Dim indx As Integer
            SyncLock Me.m_imagelist
                If (Not Me.m_formTypeHashtble(formType) Is Nothing) Then
                    Return CType(Me.m_formTypeHashtble(formType), Integer)
                End If
                indx = -1
            End SyncLock
            Return indx
        End Function
        Private Sub InitializeIcons(ByVal treeNode As IAddInTreeNode)
            Me.m_imagelist.ColorDepth = ColorDepth.Depth32Bit
            Me.m_initalsize = Me.m_imagelist.Images.Count
            Dim myResourceService As ResourceService = CType(ServiceManager.Services.GetService(GetType(IResourceService)), ResourceService)
            SyncLock Me.m_imagelist
                Me.m_imagelist.Images.Add(myResourceService.GetBitmap("Icons.16x16.MiscFiles"))
                Me.m_extensionHashtable(".PRJX") = Me.m_imagelist.Images.Count
                Me.m_imagelist.Images.Add(myResourceService.GetBitmap("Icons.16x16.SolutionIcon"))
                Me.m_extensionHashtable(".CMBX") = Me.m_imagelist.Images.Count
                Me.m_imagelist.Images.Add(myResourceService.GetBitmap("Icons.16x16.CombineIcon"))

                Me.m_formTypeHashtble("Customer") = Me.m_imagelist.Images.Count
                Me.m_imagelist.Images.Add(myResourceService.GetBitmap("VB.Project.Form"))

                For Each codon As IconCodon In treeNode.BuildChildItems(Nothing)
                    Dim img As Image
                    If (Not codon.Location Is Nothing) Then
                        img = New Bitmap(codon.Location)
                        Me.m_customIcons(codon.ID) = img
                    Else
                        If (Not codon.Resource Is Nothing) Then
                            img = Me.GetBitmap(codon.Resource)
                        Else
                            img = Me.GetBitmap(codon.ID)
                        End If
                    End If
                    Me.m_imagelist.Images.Add(img)
                    If (Not codon.Extensions Is Nothing) Then
                        For Each ext As String In codon.Extensions
                            Me.m_extensionHashtable(ext.ToUpper) = (Me.m_imagelist.Images.Count - 1)
                        Next
                    End If
                    If (Not codon.Language Is Nothing) Then
                        Me.m_projectFileHashtable(codon.Language) = (Me.m_imagelist.Images.Count - 1)
                    End If
                Next
            End SyncLock
        End Sub
        Public Overrides Sub InitializeService()
            MyBase.InitializeService()
            Dim iConThread As New Thread(New ThreadStart(AddressOf Me.LoadThread))
            iConThread.IsBackground = True
            iConThread.Priority = ThreadPriority.Normal
            iConThread.Start()
        End Sub
        Private Sub LoadThread()
            Me.InitializeIcons(AddInTreeSingleton.AddInTree.GetTreeNode("/Workspace/Icons"))
        End Sub
        Public Overrides Sub UnloadService()
            MyBase.UnloadService()
            Me.m_imagelist.Dispose()
        End Sub
#End Region

    End Class
End Namespace

