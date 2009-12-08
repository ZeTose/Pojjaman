Imports Longkong.Core.Properties
Imports System.Windows.Forms
Imports Longkong.Core.Services
Imports Longkong.Pojjaman.Internal.Parser
Imports System.Xml
Imports System.IO
Namespace Longkong.Pojjaman.Services
    Public Class RecentOpen
        Implements IXmlConvertable

#Region "Members"
        Private m_lastfile As ArrayList
        Private m_lastproject As ArrayList
        Private m_lastEntity As ArrayList
        Private MAX_LENGTH As Integer
#End Region

#Region "Events"
        Public Event RecentFileChanged As EventHandler
        Public Event RecentProjectChanged As EventHandler
        Public Event RecentEntityChanged As EventHandler
#End Region

#Region "Constructors"
        Public Sub New()
            Me.MAX_LENGTH = 10
            Me.m_lastfile = New ArrayList
            Me.m_lastproject = New ArrayList
            Me.m_lastEntity = New ArrayList
        End Sub
        Public Sub New(ByVal element As XmlElement)
            Me.new()
            Dim list1 As XmlNodeList = element.Item("FILES").ChildNodes
            For i As Integer = 0 To list1.Count - 1
                If File.Exists(list1.ItemOf(i).InnerText) Then
                    Me.m_lastfile.Add(list1.ItemOf(i).InnerText)
                End If
            Next
            list1 = element.Item("PROJECTS").ChildNodes
            For i As Integer = 0 To list1.Count - 1
                If File.Exists(list1.ItemOf(i).InnerText) Then
                    Me.m_lastproject.Add(list1.ItemOf(i).InnerText)
                End If
            Next
            list1 = element.Item("ENTITIES").ChildNodes
            For i As Integer = 0 To list1.Count - 1
                If File.Exists(list1.ItemOf(i).InnerText) Then
                    Me.m_lastEntity.Add(list1.ItemOf(i).InnerText)
                End If
            Next
        End Sub
#End Region

#Region "Properties"
        Public ReadOnly Property RecentFile() As ArrayList
            Get
                Return Me.m_lastfile
            End Get
        End Property
        Public ReadOnly Property RecentProject() As ArrayList
            Get
                Return Me.m_lastproject
            End Get
        End Property
        Public ReadOnly Property RecentEntity() As ArrayList
            Get
                Return Me.m_lastEntity
            End Get
        End Property
#End Region

#Region "Methods"
        Public Sub AddLastFile(ByVal name As String)
            Dim filesToRemove As New ArrayList
            For Each file As Object In Me.m_lastfile
                If file.ToString.ToLower = name.ToLower Then
                    filesToRemove.Add(file)
                End If
            Next
            For Each file As Object In filesToRemove
                Me.m_lastfile.Remove(file)
            Next
            Do While (Me.m_lastfile.Count >= Me.MAX_LENGTH)
                Me.m_lastfile.RemoveAt((Me.m_lastfile.Count - 1))
            Loop
            If (Me.m_lastfile.Count > 0) Then
                Me.m_lastfile.Insert(0, name)
            Else
                Me.m_lastfile.Add(name)
            End If
            Me.OnRecentFileChange()
        End Sub
        Public Sub AddLastProject(ByVal name As String)
            Dim projectsToremove As New ArrayList
            For Each project As Object In Me.m_lastproject
                projectsToremove.Add(project)
            Next
            For Each project As Object In projectsToremove
                Me.m_lastproject.Remove(project)
            Next
            Do While (Me.m_lastproject.Count >= Me.MAX_LENGTH)
                Me.m_lastproject.RemoveAt((Me.m_lastproject.Count - 1))
            Loop
            If (Me.m_lastproject.Count > 0) Then
                Me.m_lastproject.Insert(0, name)
            Else
                Me.m_lastproject.Add(name)
            End If
            Me.OnRecentProjectChange()
        End Sub
        Public Sub AddLastEntity(ByVal entity As BusinessLogic.ISimpleEntity)
            Dim entitiesToRemove As New ArrayList
            For Each ent As BusinessLogic.ISimpleEntity In Me.m_lastEntity
                If ent.TabPageText = entity.TabPageText Then
                    entitiesToRemove.Add(ent)
                End If
            Next
            For Each ent As Object In entitiesToRemove
                Me.m_lastEntity.Remove(ent)
            Next
            Do While (Me.m_lastEntity.Count >= Me.MAX_LENGTH)
                Me.m_lastEntity.RemoveAt((Me.m_lastEntity.Count - 1))
            Loop
            If (Me.m_lastEntity.Count > 0) Then
                Me.m_lastEntity.Insert(0, entity)
            Else
                Me.m_lastEntity.Add(entity)
            End If
            Me.OnRecentEntityChange()
        End Sub
        Public Sub ClearRecentFiles()
            Me.m_lastfile.Clear()
            Me.OnRecentFileChange()
        End Sub
        Public Sub ClearRecentProjects()
            Me.m_lastproject.Clear()
            Me.OnRecentProjectChange()
        End Sub
        Public Sub ClearRecentEntities()
            Me.m_lastEntity.Clear()
            Me.OnRecentEntityChange()
        End Sub
        Public Sub FileRemoved(ByVal sender As Object, ByVal e As FileEventArgs)
            For i As Integer = 0 To Me.m_lastfile.Count - 1
                Dim text1 As String = Me.m_lastfile.Item(i).ToString
                If (e.FileName Is text1) Then
                    Me.m_lastfile.RemoveAt(i)
                    Me.OnRecentFileChange()
                    Return
                End If
            Next
        End Sub
        Public Sub FileRenamed(ByVal sender As Object, ByVal e As FileEventArgs)
            For i As Integer = 0 To Me.m_lastfile.Count - 1
                Dim text1 As String = Me.m_lastfile.Item(i).ToString
                If (e.SourceFile Is text1) Then
                    Me.m_lastfile.RemoveAt(i)
                    Me.m_lastfile.Insert(i, e.TargetFile)
                    Me.OnRecentFileChange()
                    Return
                End If
            Next
        End Sub
        Private Sub OnRecentFileChange()
            RaiseEvent RecentFileChanged(Me, Nothing)
        End Sub
        Private Sub OnRecentProjectChange()
            RaiseEvent RecentProjectChanged(Me, Nothing)
        End Sub
        Private Sub OnRecentEntityChange()
            RaiseEvent RecentEntityChanged(Me, Nothing)
        End Sub
#End Region

#Region "IXmlConvertable"
        Public Function FromXmlElement(ByVal element As System.Xml.XmlElement) As Object Implements IXmlConvertable.FromXmlElement
            Return New RecentOpen(element)
        End Function

        Public Function ToXmlElement(ByVal doc As System.Xml.XmlDocument) As System.Xml.XmlElement Implements IXmlConvertable.ToXmlElement
            Dim rootEl As XmlElement = doc.CreateElement("RECENT")
            Dim filesEl As XmlElement = doc.CreateElement("FILES")
            For Each fileName As String In Me.m_lastfile
                Dim fileEl As XmlElement = doc.CreateElement("FILE")
                fileEl.InnerText = fileName
                filesEl.AppendChild(fileEl)
            Next
            Dim projectsEl As XmlElement = doc.CreateElement("PROJECTS")
            For Each projectName As String In Me.m_lastproject
                Dim projectEl As XmlElement = doc.CreateElement("PROJECT")
                projectEl.InnerText = projectName
                projectsEl.AppendChild(projectEl)
            Next
            Dim entitiesEl As XmlElement = doc.CreateElement("ENTITIES")
            For Each entity As BusinessLogic.ISimpleEntity In Me.m_lastEntity
                Dim entityEl As XmlElement = doc.CreateElement("ENTITY")
                entityEl.InnerText = entity.ClassName
                entitiesEl.AppendChild(entityEl)
            Next
            rootEl.AppendChild(filesEl)
            rootEl.AppendChild(projectsEl)
            rootEl.AppendChild(entitiesEl)
            Return rootEl
        End Function
#End Region

    End Class
End Namespace



